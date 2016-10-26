using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using DBinterface.IDAL;
using Common.DotNetUI;
using BASEFUNCTION;

namespace WorkFlow
{
    public partial class FrmWorkTask_Manage : DockContentEx
    {
        private Finance_IDAL fdal = new Finance_Dal();

        private string TaskID = string.Empty;
        private string PointSort = string.Empty;
        private string ResolveID = string.Empty;
        private string TableName = string.Empty;
        private bool _IsFinal = true;

        public FrmWorkTask_Manage()
        {
            InitializeComponent();
        }

        private void FrmWorkTask_Manage_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            ControlBindHelper.BindComboBoxData(this.CB_ID, fdal.GetTableList(), "Table_Name_CH", "TableID", true);

            DataTable dt = new DataTable();
            string sqlstr = "SELECT DISTINCT CreateMonth,CreateMonth AS CreateMonthVALUE FROM View_WorkBase";
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            ControlBindHelper.BindComboBoxData(this.CB_Month, dt, "CreateMonthVALUE", "CreateMonth", true);
            sqlstr = "SELECT DISTINCT CreateDay,CreateDay AS CreateDayVALUE FROM View_WorkBase";
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            ControlBindHelper.BindComboBoxData(this.CB_Day, fdal.GetChargeDay(), "CreateDayVALUE", "CreateDay", true);

            ShowData();
        }

        private void ShowData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT MW.*,VW.waterUserId,VW.waterUserName,VW.CreateDate,VW.waterPhone,VW.ApplyUser,VW.waterUserAddress,VW.prestore,VW.TableID,VW.TableName,VW.Table_Name_CH,(SELECT Value FROM Meter_WorkTaskState WHERE ID=MW.[STATE]) AS STATES  FROM Meter_WorkTask MW , View_WorkBase VW WHERE MW.TaskID=VW.TaskID ");

            if (!CB_ID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VW.TableID='{0}'", CB_ID.SelectedValue);
            }
            if (!CB_Month.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VW.CreateMonth='{0}'", CB_Month.SelectedValue);
            }
            if (!CB_Day.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VW.CreateDay='{0}'", CB_Day.SelectedValue);
            }
            if (!TB_Keys.Text.Equals(""))
            {
                sb.AppendFormat(" AND (waterUserName LIKE '%{0}%' OR ApplyUser LIKE '%{0}%' OR waterPhone LIKE '%{0}%' OR waterUserId LIKE '%{0}%' OR VW.SD LIKE '%{0}%')", TB_Keys.Text.Trim());
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "waterUserId", "用户ID" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "waterUserAddress", "地址" },
                                                           { "prestore", "账户余额" },
                                                           { "ApplyPhone", "联系电话" },
                                                           { "AcceptUser", "受理人" },
                                                           { "STATES", "审批状态" },
                                                           { "CreateDate", "申请时间" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "Table_Name_CH", "合计" }, { "prestore", "" } };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageOrderType = "DESC";
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

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
              DataGridView dgList = (DataGridView)sender;
              if (dgList.CurrentRow != null)
              {
                  FrmWorkTask_Goto frm = new FrmWorkTask_Goto();
                  frm.TaskID = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                  frm.TableName = dgList.CurrentRow.Cells["TableName"].Value.ToString();
                  frm.Table_Name_CH = dgList.CurrentRow.Cells["Table_Name_CH"].Value.ToString();
                  frm.SD = dgList.CurrentRow.Cells["SD"].Value.ToString();
                  if (frm.ShowDialog() == DialogResult.OK)
                  {
                      ShowData();
                  }
              }
        }

    }
}
