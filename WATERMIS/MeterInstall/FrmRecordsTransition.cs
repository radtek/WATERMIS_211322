using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MeterInstall
{
    public partial class FrmRecordsTransition : Form
    {
        public FrmRecordsTransition()
        {
            InitializeComponent();
        }

        private void FrmRecordsTransition_Load(object sender, EventArgs e)
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

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                FrmTransition frm = new FrmTransition();
                frm.key = dgList.CurrentRow.Cells["TransitionID"].Value.ToString();
                frm.state = dgList.CurrentRow.Cells["State"].Value.ToString();
                frm.taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    uC_SearchModule1_BtnEvent(null, null);
                }
            }
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM (SELECT TaskID,TransitionID,AcceptID,waterUserName,ApplyUser,waterPhone,
CASE IsBoost WHEN '1' THEN '√' ELSE '' END AS IsBoost,waterUserPeopleCount,QueryKey,
[State],MWS.Value as FlowState,SubmitDate,waterUserAddress,MIT.Memo,CreateDate,ProjectArea,WaterUseOverDate,WaterUseStartDate
FROM Meter_Install_Transition MIT left join  
Meter_WorkTaskState MWS on MIT.State=MWS.ID) M ";

            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "waterUserName", "申请单位（个人）" }, 
                                                           { "ApplyUser", "负责人" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "FlowState", "状态" } ,
                                                           { "AcceptDate", "申请时间" },
                                                           { "waterUserAddress", "地址" }, 
                                                           { "WaterUseStartDate", "用水开始日期" }, 
                                                           { "WaterUseOverDate", "用水结束日期" }, 
                                                           { "ProjectArea", "建筑面积" }, 
                                                           { "Memo", "备注" }   
            };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }
    }
}
