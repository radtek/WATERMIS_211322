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

namespace FinanceOS
{
    public partial class FrmFinance_Invoice_Print : Form
    {
        private Finance_IDAL fdal = new Finance_Dal();

        public FrmFinance_Invoice_Print()
        {
            InitializeComponent();
        }

        private void FrmFinance_Invoice_Print_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        private void BindData()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql(@"SELECT DISTINCT Meter_Table.TableID,Meter_Table.Table_Name_CH FROM View_WorkBase,Meter_Table WHERE View_WorkBase.TableID=Meter_Table.TableID AND View_WorkBase.[State]=5
AND TaskID IN (SELECT TaskID FROM View_TaskFee WHERE StateS=1 AND IsFinal=0 AND [State]=5)");
            ControlBindHelper.BindComboBoxData(this.CB_ID, dt, "Table_Name_CH", "TableID", true);
            dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT CreateMonth,CreateMonth AS CreateMonthVALUE FROM View_TaskFee WHERE StateS=1 AND IsFinal=0 AND [State]=5");
            ControlBindHelper.BindComboBoxData(this.CB_Month, dt, "CreateMonthVALUE", "CreateMonth", true);

            ShowData();
        }

        private void ShowData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT VF.FEE,VF.TaskID,VF.ChargeID,VF.CHARGEWORKERID,VF.CHARGEWORKERNAME,VF.ChargeMonth,VF.ChargeDay,VF.DepartementID,
(SELECT departmentName FROM base_department WHERE departmentID=  VF.DepartementID) AS DepartementName,VF.ChargeDate ,
VW.ID,VW.SD,VW.waterUserId,VW.waterUserName,VW.waterUserAddress,VW.TableName,VW.Table_Name_CH 
FROM View_TaskFee VF LEFT JOIN View_WorkBase VW ON VF.TaskID=VW.TaskID,Meter_Charge MC
WHERE VF.StateS=1 AND VF.IsFinal=0 AND VF.[State]=5 AND VF.ChargeID=MC.CHARGEID AND ISNULL(MC.INVOICEPRINTSIGN,'')<>1");

            if (!CB_ID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VW.TableID='{0}'", CB_ID.SelectedValue);
            }
            if (!CB_Month.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VF.ChargeMonth='{0}'", CB_Month.SelectedValue);
            }
          
            if (!TB_Keys.Text.Equals(""))
            {
                sb.AppendFormat(" AND (VW.waterUserName LIKE '%{0}%' OR VW.waterUserId LIKE '%{0}%' OR VW.SD LIKE '%{0}%')", TB_Keys.Text.Trim());
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "waterUserId", "用户ID" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "FEE", "费用合计" },
                                                           { "CHARGEWORKERNAME", "收费员" },
                                                           { "ChargeDate", "收费时间" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "Table_Name_CH", "合计" }, { "FEE", "" } };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "ChargeDate";
            uC_DataGridView_Page1.PageOrderType = "DESC";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_DataGridView_Page1_CellClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dgList = (DataGridView)sender;
            //if (dgList.CurrentRow != null)
            //{
            //    string taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
            //    if (!string.IsNullOrEmpty(taskid))
            //    {
            //        uC_FlowList1.TaskId = taskid;
            //        uC_FlowList1.DataBind();
            //    }
            //}
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                FrmFinance_Invoice_PrintShow frm = new FrmFinance_Invoice_PrintShow();
                frm.ChargeID = dgList.CurrentRow.Cells["ChargeID"].Value.ToString();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ShowData();
                }
            }
        }

    }
}
