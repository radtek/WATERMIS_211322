using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;

namespace WaterBusiness
{
    public partial class FrmMeter_Change : Form
    {
        public FrmMeter_Change()
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
(SELECT MC.ChangeID,MC.AcceptID,MC.QueryKey,MC.WaterUserNO,MC.waterUserName,MC.waterUserAddress,MW.PointSort,MC.loginId,MC.State,
MWS.Value AS StateS,MC.TaskID,MC.SubmitDate,MC.waterMeterId,MC.ChangeDescribe,CreateDate,MC.waterPhone 
FROM Meter_Change MC left join Meter_WorkTaskState MWS on MC.State=MWS.ID left join Meter_WorkTask MW on MC.TaskID=MW.TaskID) T";
            if (!string.IsNullOrEmpty(uC_SearchBase1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchBase1.sb.ToString();
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "WaterUserNO", "户号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "waterUserAddress", "地址" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "QueryKey", "查询密码" }, 
                                                           { "ChangeDescribe", "换表原因" } ,
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
            uC_SearchBase1.WorkCode = "Meter_Change";
            uC_SearchBase1.PkName = new string[] { "AcceptID", "waterUserName", "WaterUserNO", "ChangeDescribe", "waterPhone", "waterUserAddress", "Memo" };
            uC_SearchBase1.Init();
        }
    }
}
