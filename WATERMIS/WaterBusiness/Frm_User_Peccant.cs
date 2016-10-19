using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WaterBusiness
{
    public partial class Frm_User_Peccant : Form
    {
        public Frm_User_Peccant()
        {
            InitializeComponent();
        }
       
        private void uC_SearchModule1_Load(object sender, EventArgs e)
        {
            uC_SearchModule1.Init();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT TaskID,AcceptID,WaterUserNO,waterUserName,ApplyUser,ApplyPhone,PeccantAdress,QueryKey,MWS.Value as FlowState,
MIS.Memo,CreateDate,
(SELECT PeccantType FROM User_Peccant_Type WHERE PeccantTypeID=MIS.PeccantTypeID) AS PeccantType
,PecantDescribe,
(SELECT PeccantMode FROM User_Peccant_Mode WHERE PeccantModeID=MIS.PeccantModeID) AS PeccantMode
 FROM User_Peccant MIS left join Meter_WorkTaskState MWS on MIS.State=MWS.ID   ";
            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "WaterUserNO", "户号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "发现人" },
                                                           { "ApplyPhone", "联系电话" },
                                                           { "PeccantAdress", "违章地址" },
                                                           { "PecantDescribe", "违章说明" },
                                                           { "PeccantType", "违章类型" },
                                                           { "PeccantMode", "违章处理" },
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
