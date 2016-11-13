using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace PersonalWork
{
    public partial class FrmPerson_Approve : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        private string loginid = "";

        public FrmPerson_Approve()
        {
            InitializeComponent();
        }

        private void SearchData()
        {
   //         SELECT * FROM  (SELECT MW.TaskName,MW.TaskCode,MWR.DoName,MW.PointTime,MWR.TimeLimit,MW.TaskID,MWR.ResolveID,MWR.PointSort,MWR.PointName,MW.SD,MWR.WorkName,MW.AcceptUser,MW.AcceptDate,MWR.CreateDate,MWR.isPass,loginId
   //FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort AND ','+loginId+',' like '%,'+'{0}'+',%' AND MW.[State]=1) M 

            string sqlstr = string.Format(@"SELECT * FROM 
 (SELECT MW.TaskName,MW.TaskCode,MWR.DoName,MW.PointTime,MWR.TimeLimit,MW.TaskID,MWR.ResolveID,MWR.PointSort,MWR.PointName,
 MW.SD,MWR.WorkName,MW.AcceptUser,MW.AcceptDate,MWR.CreateDate,MWR.isPass,MWR.loginId,VW.waterUserName,VW.waterPhone,VW.waterUserAddress
   FROM Meter_WorkTask MW LEFT JOIN View_WorkBase VW ON MW.TaskID=VW.TaskID,Meter_WorkResolve MWR 
   WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort AND ','+MWR.loginId+',' like '%,'+'{0}'+',%' AND MW.[State]=1) M", loginid);

            if (!string.IsNullOrEmpty(uC_SearchApprove1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchApprove1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "WorkName", "审批类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "waterUserName", "用户名" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "waterUserAddress", "地址" }, 
                                                           { "PointName", "审批进度" }, 
                                                           { "PointName", "审批进度" }, 
                                                           { "DoName", "审批事项" } ,
                                                           { "PointTime", "处理开始时间" } ,
                                                           { "TimeLimit", "审批期限（天）" }, 
                                                           { "AcceptUser", "受理人" }, 
                                                           { "AcceptDate", "申请时间" }
                                                          
            };
            //uC_DataGridView_Page1.FieldStatis = new string[,] { { "AcceptID", "合计" }, { "Abate", "" }, { "IsAbate", "" } };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.FiledColor = "isPass";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_DataGridView_Page1_CellClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList != null)
            {
                if (dgList.CurrentRow != null)
                {
                    string taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                    uC_FlowList1.TaskId = taskid;
                    uC_FlowList1.DataBind();

                }
            }
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList != null)
            {
                if (dgList.CurrentRow != null)
                {
                    string TaskID = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                    string ResolveID = dgList.CurrentRow.Cells["ResolveID"].Value.ToString();
                    string PointSort = dgList.CurrentRow.Cells["PointSort"].Value.ToString();
                    string TaskCode = dgList.CurrentRow.Cells["TaskCode"].Value.ToString();

                    string FrmAssemblyName = string.Empty;
                    string FormName = string.Empty;
                    if (sysidal.GetAssemblyName(ResolveID, ref FrmAssemblyName, ref FormName))
                    {
                        Hashtable ht = new Hashtable();
                        string path = FrmAssemblyName;
                        string name = FrmAssemblyName + "." + FormName;
                        Form Frm = (Form)Assembly.Load(path).CreateInstance(name);
                        ht["ResolveID"] = ResolveID;
                        ht["PointSort"] = PointSort;
                        ht["TaskID"] = TaskID;
                        Frm.Tag = ht;
                        Frm.ShowDialog();
                        if (Frm.DialogResult == DialogResult.OK)
                        {
                            this.SearchData();
                        }
                    }
                }
            }
        }

        private void FrmPerson_Approve_Load(object sender, EventArgs e)
        {
            loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            uC_SearchApprove1.Init(loginid);
            SearchData();
        }

        private void uC_SearchApprove1_BtnEvent(object sender, EventArgs e)
        {
            SearchData();
        }

    }
}
