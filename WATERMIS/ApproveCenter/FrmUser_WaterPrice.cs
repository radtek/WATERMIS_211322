using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApproveCenter
{
    public partial class FrmUser_WaterPrice : Form
    {
        public FrmUser_WaterPrice()
        {
            InitializeComponent();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {

            string sqlstr = @"SELECT * FROM 
(SELECT UW.*
,(SELECT waterMeterTypeValue FROM waterMeterType WHERE waterMeterTypeId=UW.waterMeterTypeId) AS waterMeterType_CurrentName
,(SELECT waterMeterTypeValue FROM waterMeterType WHERE waterMeterTypeId=UW.waterMeterType_New) AS waterMeterType_NewName
,CASE WHEN OPState=1 THEN '变更完成' ELSE '-' END AS OPStateName
,CASE WHEN IsLong=1 THEN '是' ELSE '-' END AS IsLongName
,CASE WHEN IsMonth=1 THEN '是' ELSE '-' END AS IsMonthName
,MWT.Value AS FLOWSTATE FROM User_WaterPrice UW,Meter_WorkTaskState MWT WHERE UW.State=MWT.ID) P";

            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "FLOWSTATE", "审批状态" }, 
                                                           { "waterUserNO", "户号" }, 
                                                           { "waterUserName", "用户名" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "SubmitDate", "申请时间" },
                                                           { "waterMeterType_CurrentName", "原用水性质" }, 
                                                           { "waterMeterType_NewName", "变更后用水性质" } ,
                                                           { "UserName", "抄表员" } ,
                                                           { "IsMonthName", "当月变更" }, 
                                                           { "IsLongName", "长期变更" } ,
                                                           { "OPStateName", "变更状态" } ,
                                                           { "OPUser", "变更操作员" } ,
                                                           { "OPDate", "变更日期" } ,
                                                           { "WaterPriceDescribe", "变更原因" },
                                                           { "Memo", "备注" }   
            };
            //uC_DataGridView_Page1.FieldStatis = new string[,] { { "ApplyUser", "合计" }, { "CHARGEBCSS_IN", "" } };
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
