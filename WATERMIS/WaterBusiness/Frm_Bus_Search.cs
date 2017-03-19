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
    public partial class Frm_Bus_Search : DockContentEx
    {
        public Frm_Bus_Search()
        {
            InitializeComponent();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM
(SELECT V.*,L.userName,W.Value AS FlowState 
FROM  View_TABLEUNION V  LEFT JOIN V_LOGIN L ON V.LOGINID=L.loginId,Meter_WorkTaskState W 
WHERE V.State=W.ID) M";

            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "waterUserAddress", "地址" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "Table_Name_CH", "报装类型" } ,
                                                           { "userName", "受理人" } ,
                                                           { "FlowState", "状态" } ,
                                                           { "CreateDate", "创建时间" }
            };
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
            if (dgList.CurrentRow != null)
            {
                string taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                uC_FlowList1.TaskId = taskid;
                uC_FlowList1.DataBind();

            }
        }
    }
}
