using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace PersonalWork
{
    public partial class FrmPerson_Approve_Scrap : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        private string loginid = "";

        public FrmPerson_Approve_Scrap()
        {
            InitializeComponent();
        }

        private void SearchData()
        {
//            string sqlstr = string.Format(@"SELECT * FROM  
//(SELECT MW.TaskName,WorkName,MW.TaskCode,MWR.DoName,MW.PointTime,MW.TaskID,MWR.ResolveID,MWR.PointName,MW.SD,loginId,userName,MW.AcceptUser,MW.AcceptDate,UserOpinion,CreateDate
//  FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MWR.MakeVoided=1  
// AND ','+loginId+',' like '%,'+'{0}'+',%' 
//AND MW.[State]=4) M ", loginid);
            string sqlstr = string.Format(@"SELECT * FROM  
(SELECT MW.TaskName,WorkName,MW.TaskCode,MWR.DoName,MW.PointTime,MW.TaskID,MWR.ResolveID,MWR.PointName,MW.SD,loginId,userName,MW.AcceptUser,MW.AcceptDate,UserOpinion,CreateDate
  FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MWR.MakeVoided=1  
AND MW.[State]=4) M ", loginid);

            if (!string.IsNullOrEmpty(uC_SearchApprove1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchApprove1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "TaskName", "审批名称" }, 
                                                           { "WorkName", "审批类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "PointName", "审批进度" }, 
                                                           { "DoName", "审批事项" } ,
                                                           { "userName", "作废人" } ,
                                                           { "UserOpinion", "作废原因" }, 
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
