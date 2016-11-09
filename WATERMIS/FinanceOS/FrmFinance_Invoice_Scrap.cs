using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BLL;
using BASEFUNCTION;

namespace FinanceOS
{
    public partial class FrmFinance_Invoice_Scrap : Form
    {
        public FrmFinance_Invoice_Scrap()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        public string strLoginID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        public string strLoginName = "";

        Messages mes = new Messages();
        BllMeter_WorkResolveFee_Invoice_Detail BllMeter_WorkResolveFee_Invoice_Detail = new BllMeter_WorkResolveFee_Invoice_Detail();

        /// <summary>
        /// 弹出界面是否修改，如果修改则重新查询
        /// </summary>
        public bool isModify = false;

        private void FrmFinance_Invoice_Scrap_Load(object sender, EventArgs e)
        {
            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strLoginName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            cmbState.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            BindWorkType();
        }
        /// <summary>
        /// 绑定业务类型
        /// </summary>
        private void BindWorkType()
        {
            string strSQL = "SELECT DISTINCT Table_Name_CH AS DisplayValue, Table_Name_CH AS DisplayName FROM Meter_WorkResolveFee_Invoice ORDER BY Table_Name_CH";
            DataTable dt = BllMeter_WorkResolveFee_Invoice_Detail.Query(strSQL);
            DataRow dr = dt.NewRow();
            dr["DisplayName"] = "全部";
            dr["DisplayValue"] =DBNull.Value;
            dt.Rows.InsertAt(dr,0);
            CB_ID.DataSource = dt;
            CB_ID.DisplayMember = "DisplayName";
            CB_ID.ValueMember = "DisplayValue";
        }
        private void ShowData()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(@"SELECT InvoicePrintID,ChargeID,InvoiceBatchID,InvoiceBatchName,InvoiceNO,WaterUserName,WaterUserAddress,WaterUserFPTaxNO,WaterUserFPBankNameAndAccountNO, ");
            strSQL.Append(@"Table_Name_CH,InvoiceFeeDepID,InvoiceFeeDepName,InvoiceTotalFeeMoney,CompanyName,CompanyAddress,CompanyFPTaxNO,CompanyFPBankNameAndAccountNO,Payee,");
            strSQL.Append(@"Checker,InvoicePrintWorkerID,InvoicePrintWorker,InvoicePrintDateTime,(CASE InvoiceType WHEN '1' THEN '普通发票' ELSE '专用发票' END) AS InvoiceType,");
            strSQL.Append(@"(CASE InvoiceCancel WHEN '0' THEN '正常' WHEN '1' THEN '退款作废' WHEN '2' THEN '损坏作废' WHEN '3' THEN '未打作废' END) AS InvoiceCancel,Memo, ");
            strSQL.Append(@"InvoiceCancelDatetime,InvoiceCancelWorkerID,InvoiceCancelWorkerName,InvoiceCancelMemo ");
            strSQL.Append(@"FROM Meter_WorkResolveFee_Invoice WHERE 1=1 ");

            if (CB_ID.SelectedValue != null && CB_ID.SelectedValue != DBNull.Value)
                strSQL.Append(" AND Table_Name_CH='" + CB_ID.Text + "'");

            if (chkDateTime.Checked)
                strSQL.Append(" AND InvoicePrintDateTime BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'");

            if (TB_Keys.Text.Trim() != "")
                strSQL.Append(" AND (WaterUserName LIKE '%" + TB_Keys.Text.Trim() + "%' OR WaterUserAddress LIKE '%" + TB_Keys.Text.Trim() + "%')");

            if (chkInvoiceRange.Checked)
            {
                if (txtStartNO.Text.Trim() != "")
                {
                    txtStartNO.Text = txtStartNO.Text.Trim().PadLeft(8, '0');
                    strSQL.Append(" AND InvoiceNO>='" + txtStartNO.Text + "'");
                }
                if (txtEndNO.Text.Trim() != "")
                {
                    txtEndNO.Text = txtEndNO.Text.Trim().PadLeft(8, '0');
                    strSQL.Append(" AND InvoiceNO<='" + txtStartNO.Text + "'");
                }
            }

            if (cmbState.SelectedIndex == 1)
                strSQL.Append(" AND InvoiceCancel='0'");
            else if (cmbState.SelectedIndex == 2)
                strSQL.Append(" AND InvoiceCancel<>'0'");

            if (cmbType.SelectedIndex == 1)
                strSQL.Append(" AND InvoiceType='1'");
            else  if (cmbType.SelectedIndex == 2)
                strSQL.Append(" AND InvoiceType='2'");

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "DepartementName", "所属部门" },
                                                           { "waterUserId", "用户ID" }, 
                                                           { "WaterUserName", "户名" }, 
                                                           { "waterUserAddress", "地址" }, 
                                                           { "waterPhone", "联系方式" }, 
                                                           { "InvoiceBatchName", "发票批次" },
                                                           { "InvoiceNO", "发票号" },
                                                           { "InvoiceCancel", "发票状态" },
                                                           { "InvoiceType", "发票类型" },
                                                           { "InvoicePrintDateTime", "打印时间" }, 
                                                           { "InvoicePrintWorker", "打印人员" },
                                                           { "InvoiceTotalFeeMoney", "发票金额" },
                                                           { "InvoiceCancelDatetime", "作废时间" },
                                                           { "InvoiceCancelWorkerName", "作废人员" },
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "Table_Name_CH", "合计" }, { "InvoiceTotalFeeMoney", "" } };
            uC_DataGridView_Page1.SqlString = strSQL.ToString();
            uC_DataGridView_Page1.PageOrderField = "InvoicePrintDateTime";
            uC_DataGridView_Page1.PageOrderType = "DESC";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            //是否修改
            isModify = false;

            DataGridView dg = (DataGridView)sender;
            if (dg != null)
            {
                string strInvoicePrintID = "", strChargeID = "", strCompanyName = "", strCompanyTaxNO = "", strCompanyAddressAndTel = "", strCompanyBankNameAndAccountNO = "",
                    strCompanyPayee = "", strCompanyChecker = "", strWaterUserName = "", strWaterUserAddressAndTel = "",
              strWaterUserFPTaxNO = "", strWaterUserFPBankNameAndAccountNO = "", strInvoiceType = "", strInvoiceCancel = "",
              strInvoiceBatchID = "", strInvoiceNO = "", strMemo = "";

                decimal decInvoiceTotalFeeMoney = 0;

                object obj = dg.Rows[e.RowIndex].Cells["InvoicePrintID"].Value;
                if (obj != null && obj != DBNull.Value && obj.ToString() != "")
                {
                    strInvoicePrintID=obj.ToString();
                    StringBuilder str = new StringBuilder();
                    str.Append("SELECT * FROM Meter_WorkResolveFee_Invoice A INNER JOIN Meter_WorkResolveFee_Invoice_Detail B ON A.InvoicePrintID=B.InvoicePrintID ");
                    str.Append("AND A.InvoicePrintID='" + strInvoicePrintID + "' ");
                    DataTable dtInvoiceDetail = BllMeter_WorkResolveFee_Invoice_Detail.Query(str.ToString());

                    obj = dg.Rows[e.RowIndex].Cells["ChargeID"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strChargeID = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["CompanyName"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strCompanyName = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["CompanyAddress"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strCompanyAddressAndTel = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["CompanyFPTaxNO"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strCompanyTaxNO = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["CompanyFPBankNameAndAccountNO"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strCompanyBankNameAndAccountNO = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["Payee"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strCompanyPayee = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["Checker"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strCompanyChecker = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["WaterUserName"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strWaterUserName = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["WaterUserAddress"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strWaterUserAddressAndTel = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["WaterUserFPTaxNO"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strWaterUserFPTaxNO = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["WaterUserFPBankNameAndAccountNO"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strWaterUserFPBankNameAndAccountNO = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["InvoiceCancel"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strInvoiceCancel = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["InvoiceType"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strInvoiceType = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["InvoiceTotalFeeMoney"].Value;
                    if (Information.IsNumeric(obj))
                        decInvoiceTotalFeeMoney = Convert.ToDecimal(obj);

                    obj = dg.Rows[e.RowIndex].Cells["InvoiceType"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strInvoiceType = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["InvoiceBatchID"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strInvoiceBatchID = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["InvoiceNO"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strInvoiceNO = obj.ToString();

                    obj = dg.Rows[e.RowIndex].Cells["Memo"].Value;
                    if (obj != null && obj != DBNull.Value)
                        strMemo = obj.ToString();

                    FrmFinance_Invoice_Cancel frm = new FrmFinance_Invoice_Cancel();
                    frm.strLoginID = strLoginID;
                    frm.strLoginName = strLoginName;
                    frm.strWaterUserName = strWaterUserName;
                    frm.strWaterUserAddressAndTel = strWaterUserAddressAndTel;
                    frm.strWaterUserFPTaxNO = strWaterUserFPTaxNO;
                    frm.strWaterUserFPBankNameAndAccountNO = strWaterUserFPBankNameAndAccountNO;

                    frm.strCompanyName = strCompanyName;
                    frm.strCompanyAddressAndTel = strCompanyAddressAndTel;
                    frm.strCompanyBankNameAndAccountNO = strCompanyBankNameAndAccountNO;
                    frm.strCompanyTaxNO = strCompanyTaxNO;
                    frm.strCompanyPayee = strCompanyPayee;
                    frm.strCompanyChecker = strCompanyChecker;

                    frm.strInvoiceType = strInvoiceType;
                    frm.strInvoiceCancel = strInvoiceCancel;

                    frm.decWorkResolveSumFee = decInvoiceTotalFeeMoney;
                    frm.strInvoiceBatchID = strInvoiceBatchID;
                    frm.strInvoiceNO = strInvoiceNO;
                    frm.strMemo = strMemo;

                    frm.dtFPDetail = dtInvoiceDetail;

                    frm.strInvoicePrintID = strInvoicePrintID;
                    frm.strChargeID = strChargeID;
                    frm.Owner = this;
                    frm.ShowDialog();

                    if (isModify)
                    {
                        ShowData();
                    }
                }
                else
                {
                    mes.Show("获取发票ID失败,请重新查询后再试!");
                }
            }
        }
        private void btSetMonth_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btSetMonth, 0, btSetMonth.Width + 1);
        }
        private void 今天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();

            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 本月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 上月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            DateTime dtLastMonth = dtMonthStart.AddMonths(-1);
            dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtLastMonth.Day, 0, 0, 0);
            dtpStart.Value = dtLastMonth;

            DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 下月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            DateTime dtLastMonth = dtMonthStart.AddMonths(1);
            dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtMonthStart.Day, 0, 0, 0);
            dtpStart.Value = dtLastMonth;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(2).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 本年ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
            DateTime dtLastMonth = new DateTime(dtMonthStart.Year, 1, 1, 0, 0, 0);
            dtpStart.Value = dtLastMonth;

            DateTime dtMonthEnd = dtMonthStart.AddYears(1).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 上年ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
            DateTime dtLastYear = new DateTime(dtMonthStart.AddYears(-1).Year, 1, 1, 0, 0, 0);
            dtpStart.Value = dtLastYear;

            DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtLastYear = new DateTime(2000, 1, 1);
            dtpStart.Value = dtLastYear;

            DateTime dtMonthEnd = new DateTime(3000, 1, 1, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }
    }
}
