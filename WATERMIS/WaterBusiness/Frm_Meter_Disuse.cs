using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WaterBusiness
{
    public partial class Frm_Meter_Disuse : Form
    {
        public Frm_Meter_Disuse()
        {
            InitializeComponent();
        }
        
        private void uC_SearchModule1_Load(object sender, EventArgs e)
        {
            uC_SearchModule1.Init();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT MD.DisuseID,MD.AcceptID,MD.QueryKey,MD.WaterUserNO,MD.waterUserName,MD.ApplyUser,MD.ApplyPhone,
MD.SubmitDate,MWT.Value AS State,MD.TaskID,MD.DisuseDescribe,MD.waterMeterIDs,
CreateDate,contractNO
FROM Meter_Disuse MD LEFT JOIN Meter_WorkTaskState MWT ON MD.State=MWT.ID  ";
            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "WaterUserNO", "户号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "ApplyPhone", "联系电话" },
                                                           { "contractNO", "合同编号" },
                                                           { "waterMeterIDs", "水表编号" },
                                                           { "DisuseDescribe", "报停原因" },
                                                           { "QueryKey", "查询密码" },
                                                           { "FlowState", "状态" }, 
                                                           { "SubmitDate", "申请时间" },
                                                           { "Memo", "备注" }
                                                          
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
