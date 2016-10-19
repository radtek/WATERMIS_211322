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

        private void uC_SearchModule1_Load(object sender, EventArgs e)
        {
            uC_SearchModule1.Init();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = "SELECT UU.AcceptID,UU.waterUserName,UU.WaterUserNO,UU.ApplyUser,UU.CertificateNO,UU.waterPhone,UU.QueryKey,UU.Memo,UU.ContractNO,MW.Value AS State,UU.SubmitDate,UU.waterUserAddress,UU.TaskID,UU.UnsubscribeID,CreateDate FROM User_Unsubscribe UU LEFT JOIN Meter_WorkTaskState MW ON UU.State=MW.ID  ";
            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
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
                                                           { "State", "状态" }, 
                                                           { "SubmitDate", "申请时间" },
                                                           { "waterUserAddress", "地址" }
                                                          
            };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
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

        
    }
}
