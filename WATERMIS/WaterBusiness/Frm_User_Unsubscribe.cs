using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using System.Data.SqlClient;

namespace WaterBusiness
{
    public partial class Frm_User_Unsubscribe : Form
    {
        public Frm_User_Unsubscribe()
        {
            InitializeComponent();
        }

        private void uC_DataGridView_Page1_CellClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                string taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                if (!string.IsNullOrEmpty(taskid))
                {
                    uC_FlowList1.TaskId = taskid;
                    uC_FlowList1.DataBind();
                }
            }
        }

        private void uC_SearchBase1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM 
(SELECT UU.AcceptID,UU.waterUserName,UU.WaterUserNO,UU.ApplyUser,UU.CertificateNO,UU.waterPhone,UU.QueryKey,UU.Memo,UU.ContractNO,MW.PointSort,UU.loginId,UU.State,
MWS.Value AS StateS,UU.SubmitDate,UU.waterUserAddress,UU.TaskID,UU.UnsubscribeID,CreateDate FROM 
User_Unsubscribe UU LEFT JOIN Meter_WorkTaskState MWS ON UU.State=MWS.ID left join Meter_WorkTask MW on UU.TaskID=MW.TaskID) T";
           
            if (!string.IsNullOrEmpty(uC_SearchBase1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchBase1.sb.ToString();
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "WaterUserNO", "户号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "CertificateNO", "证件号码" },
                                                           { "waterPhone", "联系电话" },
                                                           { "QueryKey", "查询密码" },
                                                           { "Memo", "销户原因" },
                                                           { "ContractNO", "合同编号" },
                                                           { "StateS", "状态" }, 
                                                           { "SubmitDate", "申请时间" },
                                                           { "waterUserAddress", "地址" }
                                                          
            };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_SearchBase1_Load(object sender, EventArgs e)
        {
            uC_SearchBase1.WorkCode = "User_Unsubscribe";
            uC_SearchBase1.PkName = new string[] { "AcceptID", "waterUserName", "WaterUserNO", "ApplyUser", "waterPhone", "waterUserAddress", "Memo" };
            uC_SearchBase1.Init();
        }

        
    }
}
