using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApproveCenter
{
    public partial class FrmUser_ChargeAbate : Form
    {
        public FrmUser_ChargeAbate()
        {
            InitializeComponent();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM (SELECT UR.*,SubString(CONVERT(varchar(100),readMeterRecordYearAndMonth,23),0,8) AS YearAndMonth, MWT.Value AS ApproveState,CASE WHEN IsAbate=1 THEN '已减免' ELSE '-' END AS IsAbateState FROM User_ChargeAbate UR,Meter_WorkTaskState MWT WHERE UR.State=MWT.ID) M ";

            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "ApproveState", "审批状态" }, 
                                                           //{ "readMeterRecordYear", "年份" } ,
                                                           //{ "readMeterRecordMonth", "月份" } ,
                                                           { "YearAndMonth", "月份" } ,
                                                           { "waterUserNO", "户号" }, 
                                                           { "waterUserName", "用户名" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "SubmitDate", "申请时间" },
                                                           { "UserName", "抄表员" }, 
                                                           { "Abate", "减免金额" }, 
                                                           { "IsAbateState", "减免状态" } ,
                                                           { "CHARGEWORKERDate", "减免时间" } ,
                                                           { "CHARGEWORKERNAME", "操作人" },
                                                           { "Memo", "备注" }   
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "AcceptID", "合计" }, { "Abate", "" }, { "IsAbate", "" } };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_SearchModule1_Load(object sender, EventArgs e)
        {
            uC_SearchModule1.Init();
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
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
