using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using DBinterface.IDAL;
using DBinterface.DAL;
using System.Collections;
using Common.DotNetData;

namespace FinanceOS
{
    public partial class FrmFinance_Receivable : Form
    {
        private Finance_IDAL fdal = new Finance_Dal();

        private string TaskID = string.Empty;
        private string PointSort = string.Empty;
        private string ResolveID = string.Empty;
        private string TableName = string.Empty;
        private bool _IsFinal = true;

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
                object obj = dgList.CurrentRow.Cells["TaskID"].Value;
                if (obj == null || obj == DBNull.Value)
                    return;
                TaskID = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                _IsFinal = bool.Parse(dgList.CurrentRow.Cells["IsFinal"].Value.ToString());

                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkTask", "TaskID", TaskID);
                PointSort = ht["POINTSORT"].ToString();

                Hashtable htt = new SqlServerHelper().GetHashtableById("View_WorkBase", "TaskID", TaskID);
                if (htt.Contains("TABLENAME"))
                {
                    TableName = htt["TABLENAME"].ToString();
                }

                string sqlstr = string.Format("SELECT * FROM Meter_WorkResolve MWR WHERE MWR.TaskID='{0}' AND PointSort={1} AND IsCashier=1 AND loginId LIKE '%{2}%'", TaskID, PointSort, AppDomain.CurrentDomain.GetData("LOGINID").ToString());
                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                if (DataTableHelper.IsExistRows(dt))
                {
                    ResolveID = dt.Rows[0]["ResolveID"].ToString();

                    if (_IsFinal)
                    {
                        FrmFinance_Receivable_OP frm = new FrmFinance_Receivable_OP();
                        frm.TaskID = TaskID;
                        frm.PointSort = PointSort;
                        frm.ResolveID = ResolveID;
                        frm.TableName = TableName;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            ShowData();
                        }
                    }
                    else
                    {
                        FrmFinance_Receivable_JS frm = new FrmFinance_Receivable_JS();
                        frm.TaskID = TaskID;
                        frm.PointSort = PointSort;
                        frm.ResolveID = ResolveID;
                        frm.TableName = TableName;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            ShowData();
                        }
                    }
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
            ControlBindHelper.BindComboBoxData(this.CB_ID, fdal.GetTableList(), "Table_Name_CH", "TableID", true);

            ControlBindHelper.BindComboBoxData(this.CB_Month, fdal.GetChargeMonth(), "CreateMonthVALUE", "CreateMonth", true);

            ControlBindHelper.BindComboBoxData(this.CB_Day, fdal.GetChargeDay(), "CreateDayVALUE", "CreateDay", true);

            ShowData();
        }

        private void ShowData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(fdal.ChargeSqlList());

            sb.Append(" AND VT.States=0 ");

            if (!CB_ID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VW.TableID='{0}'", CB_ID.SelectedValue);
            }
            if (!CB_Month.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.CreateMonth='{0}'", CB_Month.SelectedValue);
            }
            if (!CB_Day.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.CreateDay='{0}'", CB_Day.SelectedValue);
            }
            if (!TB_Keys.Text.Equals(""))
            {
                sb.AppendFormat(" AND (waterUserName LIKE '%{0}%' OR ApplyUser LIKE '%{0}%' OR waterPhone LIKE '%{0}%' OR waterUserId LIKE '%{0}%' OR SD LIKE '%{0}%')", TB_Keys.Text.Trim());
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "waterUserId", "用户ID" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "FEE", "应收合计" },
                                                           { "ApplyPhone", "联系电话" },
                                                           { "CreateDate", "申请时间" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "Table_Name_CH", "合计" }, { "FEE", "" } };
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
