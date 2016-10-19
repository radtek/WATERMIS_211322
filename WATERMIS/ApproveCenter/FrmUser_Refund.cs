using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApproveCenter
{
    public partial class FrmUser_Refund : Form
    {
        public FrmUser_Refund()
        {
            InitializeComponent();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM ( SELECT UR.*,MWT.Value AS ApproveState,CASE WHEN IsRefund=1 THEN '已退款' ELSE '受理中' END AS RefundState FROM User_Refund UR,Meter_WorkTaskState MWT WHERE UR.State=MWT.ID) M ";
           
            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "ApproveState", "审批状态" }, 
                                                           { "waterUserNO", "户号" }, 
                                                           { "ApplyUser", "用户名" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "SubmitDate", "申请时间" },
                                                           { "CHARGEID_IN", "收费单号" }, 
                                                           { "CHARGEBCSS_IN", "收费金额" } ,
                                                           { "RefundState", "退款状态" } ,
                                                           { "CHARGEID_Out", "退款单号" }, 
                                                           { "CHARGEID_OutTime", "退款时间" } ,
                                                           { "CHARGEWORKERNAME", "退款操作员" } ,
                                                           { "RefundDescribe", "退款原因" },
                                                           { "Memo", "备注" }   
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "ApplyUser", "合计" }, { "CHARGEBCSS_IN", "" } };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_SearchModule1_Load(object sender, EventArgs e)
        {
            uC_SearchModule1.Init();
        }

        private void uC_DataGridView_Page1_Load(object sender, EventArgs e)
        {

        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList!=null)
            {
                if (dgList.CurrentRow != null)
                {
                    string taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                    uC_FlowList1.TaskId = taskid;
                    uC_FlowList1.DataBind();

                }
            }
        }

        private void PL_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
