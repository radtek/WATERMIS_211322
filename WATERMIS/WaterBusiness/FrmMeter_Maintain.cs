using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WaterBusiness
{
    public partial class FrmMeter_Maintain : Form
    {
        public FrmMeter_Maintain()
        {
            InitializeComponent();
        }
       
        private void uC_SearchModule1_Load(object sender, EventArgs e)
        {
            uC_SearchModule1.Init();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = "SELECT MM.MaintainID,MM.AcceptID,MM.QueryKey,MM.WaterUserNO,MM.waterUserName,MM.waterPhone,MW.Value AS State,MM.TaskID,MM.ApplyUser,MM.SubmitDate,MM.MaintainDescribe,MMT.MaintainType,CreateDate  FROM Meter_Maintain MM LEFT JOIN Meter_WorkTaskState MW ON MM.State=MW.ID LEFT JOIN Meter_MaintainType MMT ON MM.MaintainTypeID=MMT.MaintainTypeID ";
            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "WaterUserNO", "户号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "QueryKey", "查询密码" }, 
                                                           { "MaintainType", "故障类型" } ,
                                                           { "MaintainDescribe", "故障描述" } ,
                                                           { "State", "状态" } ,
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
                uC_FlowList1.TaskId = taskid;
                uC_FlowList1.DataBind();

            }
        }
    }
}
