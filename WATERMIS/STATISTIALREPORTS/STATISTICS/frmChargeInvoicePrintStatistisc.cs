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
    public partial class frmChargeInvoicePrintStatistisc : DockContentEx
    {
        public frmChargeInvoicePrintStatistisc()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();
        BLLAREA BLLAREA = new BLLAREA();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);

        //BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        

        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            //dgList.AutoGenerateColumns = false;

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Text =dtNow.Year+"-"+dtNow.Month+"-01 00:00:00";
            dtpStartCharge.Text = dtNow.Year + "-" + dtNow.Month + "-01 00:00:00";

            BindWaterMeterType();
            BindChargeWorkerName();
            BindWaterUserType(cmbWaterUserTypeSearch);
            BindArea();
            BindMeterReading();
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbChargerWorkName.DataSource = dt;
            cmbChargerWorkName.DisplayMember = "USERNAME";
            cmbChargerWorkName.ValueMember = "LOGINID";
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
        }

        DataTable dtMeterReading = new DataTable();
        /// <summary>
        /// 绑定抄表本
        /// </summary>
        private void BindMeterReading()
        {
            dtMeterReading = BLLmeterReading.Query("");
            DataRow dr = dtMeterReading.NewRow();
            dr["meterReadingNO"] = "全部";
            dr["meterReadingID"] = DBNull.Value;
            dtMeterReading.Rows.InsertAt(dr, 0);
            cmbWaterUserMeterReadingNO.DataSource = dtMeterReading;
            cmbWaterUserMeterReadingNO.DisplayMember = "meterReadingNO";
            cmbWaterUserMeterReadingNO.ValueMember = "meterReadingID";
        }
        /// <summary>
        /// 绑定区域
        /// </summary>
        private void BindArea()
        {
            DataTable dt = BLLAREA.Query(" AND areaId<>'0000'");
            DataRow dr = dt.NewRow();
            dr["areaName"] = "全部";
            dr["areaId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbArea.DataSource = dt;
            cmbArea.DisplayMember = "areaName";
            cmbArea.ValueMember = "areaId";
        }
        /// <summary>
        /// 绑定托收银行
        /// </summary>
        /// <param name="cmb"></param>
        private void BindBank(ComboBox cmb)
        {
            DataTable dt = BLLBASE_BANK.Query("");
            DataRow dr = dt.NewRow();
            dr["bankName"] = "全部";
            dr["bankId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "bankName";
            cmb.ValueMember = "bankId";
        }
        private void toolSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        Thread TD;
        private void RefreshData()
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
                LoadData();
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("收费发票统计界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("收费发票统计界面:" + ex.ToString(), MsgType.Error);
            }
        }
        private void LoadData()
        {
            try
            {
                string strFilter = "  ";
                if (txtWaterUserNOSearch.Text.Trim() != "")
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim().PadLeft(8, '0') + "'";

                if (txtWaterUserNameSearch.Text.Trim() != "")
                    strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

                if (cmbWaterUserTypeSearch.SelectedValue != null && cmbWaterUserTypeSearch.SelectedValue != DBNull.Value)
                    strFilter += " AND waterUserTypeId='" + cmbWaterUserTypeSearch.SelectedValue.ToString() + "'";

                if (chkZSH.Checked)
                    strFilter += " AND waterUserTypeId<>'0004'";

                if (cmbWaterUserMeterReadingNO.SelectedValue != null && cmbWaterUserMeterReadingNO.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReadingID='" + cmbWaterUserMeterReadingNO.SelectedValue.ToString() + "'";

                if (cmbArea.SelectedValue != null && cmbArea.SelectedValue != DBNull.Value)
                    strFilter += " AND areaId='" + cmbArea.SelectedValue.ToString() + "'";

                if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (txtSummaryNO.Text.Trim() != "")
                    strFilter += " AND waterMeterParentId LIKE '%" + txtSummaryNO.Text.Trim().PadLeft(8, '0') + "'";

                if (cmbWaterFeeYear.Text != "")
                    strFilter += " AND readMeterRecordYear='" + cmbWaterFeeYear.Text + "'";

                if (cmbWaterFeeMonth.Text != "")
                    strFilter += " AND readMeterRecordMonth='" + cmbWaterFeeMonth.Text + "'";

                if (chkInvoiceDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStartCharge.Text + "' AND '" + dtpEndCharge.Text + "'";

                if (chkInvoiceDateTime.Checked)
                    strFilter += " AND INVOICEPRINTDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                strFilter += " AND INVOICECANCEL='0'";

                //if (cmbInvoiceState.SelectedIndex > 0)
                //{
                //    if (cmbInvoiceState.SelectedIndex == 1)
                //    {
                //        strFilter += " AND INVOICECANCEL='0'";
                //    }
                //    else if (cmbInvoiceState.SelectedIndex == 2)
                //    {
                //        strFilter += " AND INVOICECANCEL<>0";
                //    }
                //}

                //strFilter += " ORDER BY CHARGEWORKERID,waterMeterTypeId";
                //DataTable dtWaterMeterList = BLLCHARGEINVOICEPRINT.Query(strFilter);
                DataTable dtWaterMeterList = BLLCHARGEINVOICEPRINT.StaticsInvoiceByChargeWorkID(strFilter + strSeniorFilterHidden);
                dgList.DataSource = dtWaterMeterList;

                for (int i = 0; i < dgList.Columns.Count; i++)
                {
                    //禁止列排序
                    dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (dgList.Rows.Count > 0)
                {
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;

                    DataTable dtWaterMeterListOld = dtWaterMeterList.Copy();
                    dtWaterMeterList.Rows.Add();
                    dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["收费员"] = "合计:";

                    object objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(发票数量)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["发票数量"] = Convert.ToInt64(objSumWaterToltalChargeEnd);


                    objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(用水量)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["用水量"] = Convert.ToInt64(objSumWaterToltalChargeEnd);

                    objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(水费)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["水费"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");

                    objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(污水处理费)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["污水处理费"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");

                    objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(附加费)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["附加费"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");

                    objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(总金额)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["总金额"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");
                }
                else
                {
                    toolPrint.Enabled = false;
                    toolPrintPreview.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
            }
        }


        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dt = GetDgvToTable(dgList);
            //(DataTable)dgList.DataSource;
            DataTable dtPrint = dt.Copy();
            dtPrint.TableName = "收费发票统计(收费员)";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收费发票统计(收费员).frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("收费发票统计(收费员)").Enabled = true;
                report1.PrintSettings.ShowDialog = false;
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
            if (dgList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();

            //DataTable dt = (DataTable)dgList.DataSource;
            DataTable dt = GetDgvToTable(dgList);
            DataTable dtPrint = dt.Copy();
            dtPrint.TableName = "收费发票统计(收费员)";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收费发票统计(收费员).frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("收费发票统计(收费员)").Enabled = true;
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
            for (int count = 0; count < dgv.Rows.Count-1; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    object obj = dgv.Rows[count].Cells[countsub].FormattedValue;
                    if (obj != null && obj!=DBNull.Value)
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
                        e.Value = "发票未打印";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "CHARGEClASS")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "水费";
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "预存";
            }
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "2";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtMeterReading.Rows.Count > 0)
            {
                DataTable dtMeterReadingNO = dtMeterReading.Copy();
                DataView dvMeterReadingNO = dtMeterReadingNO.DefaultView;
                string strFilter = "";
                if (cmbArea.SelectedValue != null && cmbArea.SelectedValue != DBNull.Value)
                {
                    strFilter += "(areaId='" + cmbArea.SelectedValue.ToString() + "' OR areaId is null)";
                }
                //if (cmbMeterReader.SelectedValue != null && cmbMeterReader.SelectedValue != DBNull.Value)
                //{
                //    if(strFilter!="")
                //    strFilter += " AND (loginId='" + cmbMeterReader.SelectedValue.ToString() + "' OR loginId is null)";
                //    else
                //        strFilter += " (loginId='" + cmbMeterReader.SelectedValue.ToString() + "' OR loginId is null)";
                //}
                dvMeterReadingNO.RowFilter = strFilter;
                cmbWaterUserMeterReadingNO.DataSource = dvMeterReadingNO.ToTable();
            }
        }
       
    }
}
