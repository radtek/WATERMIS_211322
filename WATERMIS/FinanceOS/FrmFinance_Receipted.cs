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

namespace FinanceOS
{
    public partial class FrmFinance_Receipted : Form
    {
        private Finance_IDAL fdal = new Finance_Dal();

        public FrmFinance_Receipted()
        {
            InitializeComponent();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dgList = (DataGridView)sender;
            //if (dgList.CurrentRow != null)
            //{
            //    FrmFinance_Receivable_OP frm = new FrmFinance_Receivable_OP();
            //    frm.TaskID = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {

            //    }
            //}
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

        private void FrmFinance_Receipted_Shown(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            ControlBindHelper.BindComboBoxData(this.CB_ID, fdal.GetTableList(), "Table_Name_CH", "TableID", true);

            ControlBindHelper.BindComboBoxData(this.CB_Month, fdal.GetChargeMonth(), "CreateMonthVALUE", "CreateMonth", true);

            ControlBindHelper.BindComboBoxData(this.CB_Day, fdal.GetChargeDay(), "CreateDayVALUE", "CreateDay", true);

            string sqlstr = @"SELECT DISTINCT VT.CHARGEWORKERID,CHARGEWORKERNAME
FROM View_TaskFee VT  LEFT JOIN View_WorkBase VW ON VT.TaskID=VW.TASKID,Meter_Table MT WHERE VW.TableID=MT.TableID AND VW.[State] IN (1,2,5) AND VT.States=1 ";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            ControlBindHelper.BindComboBoxData(this.CHARGEWORKERID, dt, "CHARGEWORKERNAME", "CHARGEWORKERID", true);

            ShowData();
        }

        private void ShowData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MT.Table_Name_CH,VW.SD,VW.waterUserId,VW.waterUserName,VW.ApplyUser,VT.FEE,VW.waterPhone,VT.CreateDate,VT.PointTime,VW.TableID,VT.TaskID,VT.STATES,VW.ID,VT.ChargeID,VT.CHARGEWORKERNAME,VT.ChargeDate
FROM View_TaskFee VT  LEFT JOIN View_WorkBase VW ON VT.TaskID=VW.TASKID,Meter_Table MT WHERE VW.TableID=MT.TableID AND VW.[State] IN (1,2,5) AND VT.States=1 ");

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
                sb.AppendFormat(" AND (waterUserName LIKE '%{0}%' OR ApplyUser LIKE '%{0}%' OR waterPhone LIKE '%{0}%' OR waterUserId LIKE '%{0}%' OR SD LIKE '%{0}%' )", TB_Keys.Text.Trim());
            }
            if (!CHARGEWORKERID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.CHARGEWORKERID='{0}'", CHARGEWORKERID.SelectedValue);
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "ChargeID", "收费流水号" }, 
                                                           { "ChargeDate", "收费时间" }, 
                                                           { "CHARGEWORKERNAME", "收费员" }, 
                                                           { "FEE", "收费金额" },
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "SD", "业务流水号" }, 
                                                           { "waterUserId", "用户ID" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "ApplyPhone", "联系电话" },
                                                           { "CreateDate", "申请时间" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "ChargeID", "合计" }, { "FEE", "" } };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "ChargeDate";
            uC_DataGridView_Page1.PageOrderType = "DESC";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();


           
        }
    }
}
