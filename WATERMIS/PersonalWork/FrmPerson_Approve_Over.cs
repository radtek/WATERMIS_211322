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
    public partial class FrmPerson_Approve_Over : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        private string loginid = "";

        public FrmPerson_Approve_Over()
        {
            InitializeComponent();
        }





        private void SearchData()
        {
            string sqlstr = string.Format(@"SELECT * FROM  (SELECT CASE MWR.IsPass WHEN '1' THEN '√' WHEN '0' THEN '×' ELSE '-' END AS IsPass,(SELECT VALUE FROM Meter_WorkTaskState WHERE ID=MW.STATE) AS STATE,MWR.UserOpinion,MW.TaskName,MW.TaskCode,MWR.DoName,MW.PointTime,MWR.TimeLimit,MW.TaskID,MWR.ResolveID,MWR.PointSort,MWR.PointName,MW.SD,loginId,CreateDate
  FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort>MWR.PointSort
  AND ','+loginId+',' like '%,'+'{0}'+',%' AND MWR.IsPass IS NOT NULL) M  ", loginid);

            if (!string.IsNullOrEmpty(uC_SearchApprove1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchApprove1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "TaskName", "审批名称" }, 
                                                           { "WorkName", "审批类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "STATE", "审批状态" }, 
                                                           { "IsPass", "我的审批" }, 
                                                           { "UserOpinion", "处理意见" }, 
                                                           { "PointName", "审批进度" }, 
                                                           { "DoName", "审批事项" } ,
                                                           { "PointTime", "审批时间" } ,
                                                           { "TimeLimit", "审批期限（天）" }, 
                                                           { "AcceptUser", "受理人" }, 
                                                           { "AcceptDate", "申请时间" }
                                                          
            };
            //uC_DataGridView_Page1.FieldStatis = new string[,] { { "AcceptID", "合计" }, { "Abate", "" }, { "IsAbate", "" } };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
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
