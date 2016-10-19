using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using BLL;
using BASEFUNCTION;
using FastReport;

namespace STATISTIALREPORTS
{
    public partial class frmChargeInvoicePrintSearch : DockContentEx
    {
        public frmChargeInvoicePrintSearch()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        //BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();


        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            //for (int i = 0; i < dgList.Columns.Count; i++)
            //{
            //    //禁止列排序
            //    dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            cmbInvoiceState.SelectedIndex = 1;
            BindChargeWorkerName();
            BindWaterMeterType();
            //BindWaterUserType(cmbWaterUserTypeSearch);
        }
        /// <summary>
        /// 绑定用户类别
        /// </summary>
        /// <param name="cmb"></param>
        private void BindWaterUserType(ComboBox cmb)
        {
            DataTable dt = BLLwaterUserType.Query("");
            DataRow dr = dt.NewRow();
            dr["waterUserTypeName"] = "全部";
            dr["waterUserTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterUserTypeName";
            cmb.ValueMember = "waterUserTypeId";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }

        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType()
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "全部";
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbWaterMeterType.DataSource = dt;
            cmbWaterMeterType.DisplayMember = "waterMeterTypeValue";
            cmbWaterMeterType.ValueMember = "waterMeterTypeId";
            cmbWaterMeterType.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmbWaterMeterType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND IsCashier='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "全部";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbChargerWorkName.DataSource = dt;
            cmbChargerWorkName.DisplayMember = "USERNAME";
            cmbChargerWorkName.ValueMember = "LOGINID";
            cmbChargerWorkName.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmbChargerWorkName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilterS = "";
            string strStartInvoiceNO = "", strEndInvoiceNO = "";
            if (chkInvoiceRange.Checked)
            {
                if (!Information.IsNumeric(txtStartNO.Text))
                {
                    mes.Show("发票起始号码只能为数字!");
                    txtStartNO.Focus();
                    return;
                }
                else
                {
                    strStartInvoiceNO = Convert.ToInt32(txtStartNO.Text).ToString().PadLeft(8, '0');
                }
                if (Information.IsNumeric(txtEndNO.Text))
                {
                    if (Convert.ToInt32(txtStartNO.Text) > Convert.ToInt32(txtEndNO.Text))
                    {
                        mes.Show("发票起始号码不能大于终止号码!");
                        txtEndNO.Focus();
                        return;
                    }
                    strEndInvoiceNO = Convert.ToInt32(txtEndNO.Text).ToString().PadLeft(8, '0');
                }
                if (strStartInvoiceNO != "")
                {
                    if (strEndInvoiceNO != "")
                        strFilterS += " AND INVOICENO BETWEEN '" + strStartInvoiceNO + "' AND '" + strEndInvoiceNO + "'";
                    else
                        strFilterS += " AND INVOICENO>='" + strStartInvoiceNO + "'";
                }
            }
            RefreshData(strFilterS);
        }

        Thread TD;
        private void RefreshData(string strFilterS)
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
                LoadData(strFilterS);
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("发票使用明细查询界面:" + ex.ToString(), MsgType.Error);
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
        }
        //传递给线程的方法.
        frmWaitSearch waitfrm = null;
        private void showwaitfrm()
        {
            try
            {
                waitfrm = new frmWaitSearch();
                waitfrm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Write("发票使用明细查询界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 存储查询到的水表列表
        /// </summary>
        DataTable dtWaterMeterList = new DataTable();

        private void LoadData(string strFilterS)
        {
            try
            {
                string strFilter = strFilterS;

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                if (chbInvoicePrintDateTime.Checked)
                    strFilter += " AND INVOICEPRINTDATETIME BETWEEN '" + dtpStartPrint.Text + "' AND '" + dtpEndPrint.Text + "'";

                if (cmbInvoiceState.SelectedIndex > 0)
                {
                    if (cmbInvoiceState.SelectedIndex == 1)
                    {
                        strFilter += " AND INVOICECANCEL='0'";
                    }
                    else if (cmbInvoiceState.SelectedIndex == 2)
                    {
                        strFilter += " AND INVOICECANCEL<>0";
                    }
                }

                if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (txtWaterUserNameSearch.Text != "")
                    strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

                strFilter += " ORDER BY CHARGEWORKERID,INVOICEBATCHID,INVOICENO";
                dtWaterMeterList = BLLCHARGEINVOICEPRINT.Query(strFilter);

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;
                    toolExportToExl.Enabled = true;

                    dgList.DataSource = dtWaterMeterList;
                }
                else
                {
                    toolPrint.Enabled = false;
                    toolPrintPreview.Enabled = false;
                    toolExportToExl.Enabled = false;
                    dgList.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }


        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (dtWaterMeterList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtPrint = GetDgvToTable(dgList);
            dtPrint.TableName = "发票使用明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\发票使用明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("发票使用明细表").Enabled = true;
                report1.Prepare();
                report1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // free resources used by report
                report1.Dispose();
            }
        }

        private void toolPrintPreview_Click(object sender, EventArgs e)
        {
            if (dtWaterMeterList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtPrint = GetDgvToTable(dgList);
            dtPrint.TableName = "发票使用明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\发票使用明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("发票使用明细表").Enabled = true;
                // run the report
                report1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // free resources used by report
                report1.Dispose();
            }
        }
        /// <summary>
        /// 方法实现把dgv里的数据完整的复制到一张内存表
        /// </summary>
        /// <param name="dgv">dgv控件作为参数</param>
        /// <returns>返回临时内存表</returns>
        public static DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    object obj = dgv.Rows[count].Cells[countsub].FormattedValue;
                    if (obj != null && obj != DBNull.Value)
                        dr[countsub] = dgv.Rows[count].Cells[countsub].FormattedValue.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void dgList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //判断是不是列Header
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                //单元格描绘  
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                //决定行号码描绘的范围   
                //不管e.AdvancedBorderStyle和e.CellStyle.Padding  
                Rectangle indexRect = e.CellBounds; indexRect.Inflate(-2, -2);
                //行号码描绘  
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, indexRect, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                //描绘完后通知 
                e.Handled = true;
            }
        }

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "INVOICECANCEL")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "正常";
                    }
                    else if (e.Value.ToString() == "1")
                        e.Value = "冲减作废";
                    else if (e.Value.ToString() == "2")
                        e.Value = "发票污损作废";
                    else if (e.Value.ToString() == "3")
                        e.Value = "发票未打作废";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "CHARGEClASS")
            {
                object obj = e.Value;
                if (obj != null && obj != DBNull.Value)
                {
                    if (obj.ToString() == "1")
                        e.Value = "收取水费";
                    else if (obj.ToString() == "2")
                        e.Value = "预存水费";
                    if (obj.ToString() == "3")
                        e.Value = "收取水费";
                    else if (obj.ToString() == "4")
                        e.Value = "红冲水费";
                    else if (obj.ToString() == "5")
                        e.Value = "红冲预存";
                    else if (obj.ToString() == "6")
                        e.Value = "余额退费";
                    else if (obj.ToString() == "7")
                        e.Value = "余额转户";
                }
            }
        }

        private void toolExportToExl_Click(object sender, EventArgs e)
        {
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel("发票使用明细表", dgList);
        }

        private void dgList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgList.Rows.Count > 0)
            {
                dgList.Rows[dgList.Rows.Count - 1].Cells["CHARGEWORKERNAME"].Value = "合计:";

                dgList.Rows[dgList.Rows.Count - 1].Cells["chargeID"].Value = dgList.Rows.Count - 1+"行";

                object objSumtotalNumber = dtWaterMeterList.Compute("SUM(totalNumber)", "");
                if (Information.IsNumeric(objSumtotalNumber))
                {
                    dgList.Rows[dgList.Rows.Count - 1].Cells["totalNumber"].Value = Convert.ToInt32(objSumtotalNumber);
                }

                object objSumWaterToltalChargeEnd = dtWaterMeterList.Compute("SUM(waterTotalCharge)", "");
                if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                {
                    dgList.Rows[dgList.Rows.Count - 1].Cells["waterTotalCharge"].Value = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");
                }

                object objSumextraTotalCharge1 = dtWaterMeterList.Compute("SUM(extraCharge1)", "");
                if (Information.IsNumeric(objSumextraTotalCharge1))
                {
                    dgList.Rows[dgList.Rows.Count - 1].Cells["extraCharge1"].Value = Convert.ToDecimal(objSumextraTotalCharge1).ToString("F2");
                }

                object objSumextraTotalCharge2 = dtWaterMeterList.Compute("SUM(extraCharge2)", "");
                if (Information.IsNumeric(objSumextraTotalCharge2))
                {
                    dgList.Rows[dgList.Rows.Count - 1].Cells["extraCharge2"].Value = Convert.ToDecimal(objSumextraTotalCharge2).ToString("F2");
                }

                object objSumtotalCharge = dtWaterMeterList.Compute("SUM(totalCharge)", "");
                if (Information.IsNumeric(objSumtotalCharge))
                {
                    dgList.Rows[dgList.Rows.Count - 1].Cells["totalCharge"].Value = Convert.ToDecimal(objSumtotalCharge).ToString("F2");
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
