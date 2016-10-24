using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;

namespace FinanceOS
{
    public partial class FrmFinance_Receivable : Form
    {
        public FrmFinance_Receivable()
        {
            InitializeComponent();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                FrmFinance_Receivable_OP frm = new FrmFinance_Receivable_OP();
               
                if (frm.ShowDialog() == DialogResult.OK)
                {
                   
                }
            }
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

        private void FrmFinance_Receivable_Shown(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT Meter_Table.TableID,Meter_Table.Table_Name_CH FROM View_WorkBase,Meter_Table WHERE View_WorkBase.TableID=Meter_Table.TableID AND View_WorkBase.[State] IN (1,2,5)");
            ControlBindHelper.BindComboBoxData(this.CB_ID, dt, "Table_Name_CH", "TableID", true);

            dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT CreateMonth,CreateMonth AS CreateMonthVALUE FROM View_TaskFee");
            ControlBindHelper.BindComboBoxData(this.CB_Month, dt, "CreateMonthVALUE", "CreateMonth", true);

            dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT CreateDay,CreateDay AS CreateDayVALUE FROM View_TaskFee");
            ControlBindHelper.BindComboBoxData(this.CB_Day, dt, "CreateDayVALUE", "CreateDay", true);

            ShowData();
        }

        private void ShowData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( @"SELECT MT.Table_Name_CH,VW.SD,VW.waterUserId,VW.waterUserName,VW.ApplyUser,VT.FEE,VW.waterPhone,VT.CreateDate,VT.PointTime,VW.TableID,VT.TaskID,VT.STATES,VW.ID
FROM View_TaskFee VT  LEFT JOIN View_WorkBase VW ON VT.TaskID=VW.TASKID,Meter_Table MT WHERE VW.TableID=MT.TableID AND VT.States=0 AND VW.[State] IN (1,2,5)");

            if (!CB_ID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VW.ID='{0}'",CB_ID.SelectedValue);
            }
            if (!CB_Month.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.CreateMonth='{0}'",CB_Month.SelectedValue);
            }
            if (!CB_Day.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.CreateDay='{0}'",CB_Day.SelectedValue);
            }
            if (!TB_Keys.Text.Equals(""))
            {

            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "waterUserId", "户名ID" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "FEE", "应收合计" },
                                                           { "ApplyPhone", "联系电话" },
                                                           { "CreateDate", "申请时间" }
            };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "PointTime";
            uC_DataGridView_Page1.PageOrderType = "DESC";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void FrmFinance_Receivable_Load(object sender, EventArgs e)
        {
              }

       
    }
}
