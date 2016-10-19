using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SysControl;

namespace MeterInstall
{
    public partial class FrmRecordsGroup : Form
    {
        public FrmRecordsGroup()
        {
            InitializeComponent();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = "SELECT GroupID,TaskID,AcceptID,waterUserName,ApplyUser,waterPhone,waterUserPeopleCount,QueryKey,MWS.Value as FlowState,SubmitDate,waterUserAddress,MIS.Memo,CreateDate FROM Meter_Install_Group MIS left join Meter_WorkTaskState MWS on MIS.State=MWS.ID ";
            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "waterUserName", "单位名称" }, 
                                                           { "ApplyUser", "申请人" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "waterUserPeopleCount", "用户数" } ,
                                                           { "QueryKey", "查询密码" }, 
                                                           { "FlowState", "状态" } ,
                                                           { "SubmitDate", "申请时间" },
                                                           { "waterUserAddress", "地址" }, 
                                                           { "Memo", "备注" }   
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "AcceptID", "合计" }, { "waterUserPeopleCount", "" }};

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

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            //FrmGroupPeople_Show frm = new FrmGroupPeople_Show();
            //frm.GroupID = dgList.CurrentRow.Cells["GroupID"].Value.ToString();
            //frm.ShowDialog();

            FrmGroup frm = new FrmGroup();
            frm.key = dgList.CurrentRow.Cells["GroupID"].Value.ToString();
            frm.taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
            frm.ShowDialog();
        }
    }
}
