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

        private void uC_SearchBase1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM
(SELECT MM.MaintainID,MM.AcceptID,MM.QueryKey,MM.WaterUserNO,MM.waterUserName,
MM.waterPhone,MWS.Value AS StateS,MM.TaskID,MM.ApplyUser,MM.SubmitDate,
MM.MaintainDescribe,MMT.MaintainType,CreateDate,MW.PointSort,MM.loginId,MM.State
FROM Meter_Maintain MM LEFT JOIN Meter_WorkTaskState MWS ON MM.State=MWS.ID 
LEFT JOIN Meter_MaintainType MMT ON MM.MaintainTypeID=MMT.MaintainTypeID 
left join Meter_WorkTask MW on MM.TaskID=MW.TaskID) T";

            if (!string.IsNullOrEmpty(uC_SearchBase1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchBase1.sb.ToString();
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
                                                           { "StateS", "状态" } ,
                                                           { "SubmitDate", "申请时间" },
                                                           { "Memo", "备注" }   
            };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_SearchBase1_Load(object sender, EventArgs e)
        {
            uC_SearchBase1.WorkCode = "Meter_Maintain_1";
            uC_SearchBase1.PkName = new string[] { "AcceptID", "waterUserName", "WaterUserNO", "waterPhone", "waterUserAddress", "Memo", "MaintainDescribe" };
            uC_SearchBase1.Init();
        }
    }
}
