using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApproveCenter
{
    public partial class FrmUser_AddWater : Form
    {
        public FrmUser_AddWater()
        {
            InitializeComponent();
        }

        private void FrmUser_AddWater_Load(object sender, EventArgs e)
        {

        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM  (SELECT UA.*,MWT.Value AS ApproveState,CASE WHEN IsAdd=1 THEN '已交费' ELSE '-' END AS IsAddState 
 FROM User_AddWater UA,Meter_WorkTaskState MWT WHERE UA.State=MWT.ID) M ";

            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "ApproveState", "审批状态" }, 
                                                           { "readMeterRecordYearAndMonth", "月份" } ,
                                                           { "waterUserNO", "户号" }, 
                                                           { "waterUserName", "用户名" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "SubmitDate", "申请时间" },
                                                           { "UserName", "抄表员" }, 
                                                           { "totalNumber", "补交水量" }, 
                                                           { "TotalChargeEND", "费用总计" }, 
                                                           { "IsAddState", "补交状态" } ,
                                                           { "CHARGEWORKERDate", "补交时间" } ,
                                                           { "CHARGEWORKERNAME", "操作人" },
                                                           { "AddDescribe", "补交原因" }   
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "AcceptID", "合计" }, { "totalNumber", "" }, { "TotalChargeEND", "" } };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_SearchModule1_Load(object sender, EventArgs e)
        {
            uC_SearchModule1.Init();
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
    }
}
