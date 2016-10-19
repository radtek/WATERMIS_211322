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
    public partial class frmWaterFeeRemitSearch : DockContentEx
    {
        public frmWaterFeeRemitSearch()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        BLLWATERFEEREMIT BLLWATERFEEREMIT = new BLLWATERFEEREMIT();


        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
            BindWaterMeterType(cmbWaterMeterType);

            cmbCancelState.SelectedIndex = 1;
        }
        private void BindAreaNO(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
                dt = BLLAREA.Query("");
            else
                dt = BLLAREA.Query(" AND areaId<>'0000'");

            cmb.DataSource = dt;
            cmb.DisplayMember = "areaName";
            cmb.ValueMember = "areaId";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        private void BindPianNO(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
                dt = BLLBASE_PIAN.Query("");
            else
                dt = BLLBASE_PIAN.Query(" AND PIANID<>'0000'");
            cmb.DataSource = dt;
            cmb.DisplayMember = "PIANNAME";
            cmb.ValueMember = "PIANID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        private void BindDuanNO(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
                dt = BLLBASE_DUAN.Query("");
            else
                dt = BLLBASE_DUAN.Query(" AND DUANID<>'0000'");
            cmb.DataSource = dt;
            cmb.DisplayMember = "DUANNAME";
            cmb.ValueMember = "DUANID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType(ComboBox cmb)
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "";
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterMeterTypeValue";
            cmb.ValueMember = "waterMeterTypeId";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader(ComboBox cmb, string strType)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
            if (strType == "0")
            {
                DataRow dr = dt.NewRow();
                dr["USERNAME"] = "全部";
                dr["LOGINID"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        private void toolSearch_Click(object sender, EventArgs e)
        {
            dgList.DataSource = null;
            RefreshData();
        }

        Thread TD;
        private void RefreshData()
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
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
                log.Write("水费减免界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("水费减免界面:" + ex.ToString(), MsgType.Error);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        DataTable dtWaterMeterList = new DataTable();
        private void LoadData()
        {
            try
            {
                string strFilter = " ";

                if (txtWaterUserNOSearch.Text.Trim() != "")
                {
                    if (txtWaterUserNOSearch.Text.Length < 6)
                        strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                    else
                        strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
                }

                if (cmbWaterMeterType.SelectedValue != DBNull.Value && cmbWaterMeterType.SelectedValue != null)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

                if (txtWaterUserNameSearch.Text.Trim() != "")
                    strFilter += " AND waterUserName LIKE '%" + txtWaterUserNameSearch.Text + "%' ";

                if (cmbAreaNOS.SelectedIndex > 0)
                    strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
                if (cmbPianNOS.SelectedIndex > 0)
                    strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
                if (cmbDuanNOS.SelectedIndex > 0)
                    strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

                if (cmbIsMeterRead.SelectedIndex > 0)
                    strFilter += " AND chargeState='" + cmbIsMeterRead.SelectedIndex.ToString() + "'";

                if (cmbCancelState.SelectedIndex > 0)
                    strFilter += " AND REMITCANCEL='" + (cmbCancelState.SelectedIndex - 1).ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND REMITDATETIME BETWEEN '" + dtpStart.Text + "' AND '"+dtpEnd.Text+"'";

                    strFilter += " ORDER BY areaNO,pianNO,duanNO,ordernumber";

                    dtWaterMeterList = BLLWATERFEEREMIT.QueryView(strFilter);
                    dgList.DataSource = dtWaterMeterList;
                #region 先计算滞纳金后绑定datagridview
                //dgList.DataSource = null;
                if (dtWaterMeterList.Rows.Count > 0)
                {
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;

                //    DataTable dtWaterMeterListOld = dtWaterMeterList.Copy();
                //    dtWaterMeterList.Rows.Add();
                //    dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["waterUserNO"] = "合计:";

                //    //计算用户数量
                //    DataView dvWaterUserListSum = dtWaterMeterListOld.DefaultView;
                //    int intWaterUserListCount = dvWaterUserListSum.ToTable(true, "waterUserId").Rows.Count;
                //    dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["waterUserName"] = intWaterUserListCount;

                //    //计算水表数量
                //    object objCount = dtWaterMeterListOld.Compute("COUNT(waterMeterNo)", "true");
                //    if (Information.IsNumeric(objCount))
                //        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["waterMeterNo"] = Convert.ToInt32(objCount);

                //    //统计水费小计
                //    object objSumWaterToltalCharge = dtWaterMeterListOld.Compute("SUM(waterTotalCharge)", "");
                //    if (Information.IsNumeric(objSumWaterToltalCharge))
                //        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["waterTotalCharge"] = Convert.ToDecimal(objSumWaterToltalCharge).ToString("F2");

                //    //统计附加费
                //    object objSumextraTotalCharge= dtWaterMeterListOld.Compute("SUM(extraTotalCharge)", "");
                //    if (Information.IsNumeric(objSumextraTotalCharge))
                //        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["extraTotalCharge"] = Convert.ToDecimal(objSumextraTotalCharge).ToString("F2");

                //    //统计滞纳金
                //    object objSumOVERDUE = dtWaterMeterListOld.Compute("SUM(OVERDUEGET)", "");
                //    if (Information.IsNumeric(objSumOVERDUE))
                //        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["OVERDUEGET"] = Convert.ToDecimal(objSumOVERDUE).ToString("F2");

                //    //统计水费总计
                //    object objSumtotalCharge = dtWaterMeterListOld.Compute("SUM(totalCharge)", "");
                //    if (Information.IsNumeric(objSumtotalCharge))
                //        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["totalCharge"] = Convert.ToDecimal(objSumtotalCharge).ToString("F2");

                //    //统计减免后水费总计
                //    object objTOTALCHARGEEND = dtWaterMeterListOld.Compute("SUM(TOTALCHARGEEND)", "");
                //    if (Information.IsNumeric(objTOTALCHARGEEND))
                //        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["TOTALCHARGEEND"] = Convert.ToDecimal(objTOTALCHARGEEND).ToString("F2");

                //    dgList.DataSource = dtWaterMeterList;
                //}
                //else
                //{
                //    toolPrint.Enabled = false;
                //    toolPrintPreview.Enabled = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
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

            //DataTable dt = (DataTable)dgList.DataSource;
            DataTable dt = GetDgvToTable(dgList);
            DataTable dtPrint = dt.Copy();
            DataColumn dc1 = new DataColumn("totalChargeOld", typeof(decimal));
            dtPrint.Columns.Add(dc1);
            //dtPrint.Columns["totalChargeOld"].Expression = "OVERDUEGET + totalCharge";


            DataColumn dc2 = new DataColumn("REMITSUM", typeof(decimal));
            dtPrint.Columns.Add(dc2);

            for (int i = 0; i < dtPrint.Rows.Count-1; i++)
            {
                dtPrint.Rows[i]["totalChargeOld"] = (Information.IsNumeric(dtPrint.Rows[i]["totalCharge"]) ? Convert.ToDecimal(dtPrint.Rows[i]["totalCharge"]) : 0) +
                    (Information.IsNumeric(dtPrint.Rows[i]["OVERDUEGET"]) ? Convert.ToDecimal(dtPrint.Rows[i]["OVERDUEGET"]) : 0);

                dtPrint.Rows[i]["REMITSUM"] = (Information.IsNumeric(dtPrint.Rows[i]["REMITWATERFEE"]) ? Convert.ToDecimal(dtPrint.Rows[i]["REMITWATERFEE"]) : 0) +
                    (Information.IsNumeric(dtPrint.Rows[i]["REMITEXTRAFEE"]) ? Convert.ToDecimal(dtPrint.Rows[i]["REMITEXTRAFEE"]) : 0) +
                    (Information.IsNumeric(dtPrint.Rows[i]["REMITOVERDUE"]) ? Convert.ToDecimal(dtPrint.Rows[i]["REMITOVERDUE"]) : 0);
            }

            //统计未减免总水费小计
            object objSumToltalCharge = dtPrint.Compute("SUM(totalChargeOld)", "");
            if (Information.IsNumeric(objSumToltalCharge))
                dtPrint.Rows[dtPrint.Rows.Count - 1]["totalChargeOld"] = Convert.ToDecimal(objSumToltalCharge).ToString("F2");

            //统计减免总水费小计
            object objSumRemit = dtPrint.Compute("SUM(REMITSUM)", "");
            if (Information.IsNumeric(objSumRemit))
                dtPrint.Rows[dtPrint.Rows.Count - 1]["REMITSUM"] = Convert.ToDecimal(objSumRemit).ToString("F2");

            dtPrint.TableName = "水费减免明细模板";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\水费减免明细模板.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("水费减免明细模板").Enabled = true;
                report1.Prepare();
                report1.PrintSettings.ShowDialog = false;
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
            DataColumn dc1 = new DataColumn("totalChargeOld", typeof(decimal));
            dtPrint.Columns.Add(dc1);
            //dtPrint.Columns["totalChargeOld"].Expression = "OVERDUEGET + totalCharge";


            DataColumn dc2 = new DataColumn("REMITSUM", typeof(decimal));
            dtPrint.Columns.Add(dc2);

            for (int i = 0; i < dtPrint.Rows.Count-1; i++)
            {
                dtPrint.Rows[i]["totalChargeOld"] = (Information.IsNumeric(dtPrint.Rows[i]["totalCharge"]) ? Convert.ToDecimal(dtPrint.Rows[i]["totalCharge"]) : 0) +
                    (Information.IsNumeric(dtPrint.Rows[i]["OVERDUEGET"]) ? Convert.ToDecimal(dtPrint.Rows[i]["OVERDUEGET"]) : 0);

                dtPrint.Rows[i]["REMITSUM"] = (Information.IsNumeric(dtPrint.Rows[i]["REMITWATERFEE"]) ? Convert.ToDecimal(dtPrint.Rows[i]["REMITWATERFEE"]) : 0) +
                    (Information.IsNumeric(dtPrint.Rows[i]["REMITEXTRAFEE"]) ? Convert.ToDecimal(dtPrint.Rows[i]["REMITEXTRAFEE"]) : 0) +
                    (Information.IsNumeric(dtPrint.Rows[i]["REMITOVERDUE"]) ? Convert.ToDecimal(dtPrint.Rows[i]["REMITOVERDUE"]) : 0);
            }

            //统计未减免总水费小计
            object objSumToltalCharge = dtPrint.Compute("SUM(totalChargeOld)", "");
            if (Information.IsNumeric(objSumToltalCharge))
                dtPrint.Rows[dtPrint.Rows.Count - 1]["totalChargeOld"] = Convert.ToDecimal(objSumToltalCharge).ToString("F2");

            //统计减免总水费小计
            object objSumRemit = dtPrint.Compute("SUM(REMITSUM)", "");
            if (Information.IsNumeric(objSumRemit))
                dtPrint.Rows[dtPrint.Rows.Count - 1]["REMITSUM"] = Convert.ToDecimal(objSumRemit).ToString("F2");

            dtPrint.TableName = "水费减免明细模板";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\水费减免明细模板.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("水费减免明细模板").Enabled = true;
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
                    object obj = dgv.Rows[count].Cells[countsub].Value;
                    if (obj != null && obj != DBNull.Value)
                        dr[countsub] = dgv.Rows[count].Cells[countsub].Value.ToString();
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
            if (dgList.Columns[e.ColumnIndex].Name == "chargeState")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "已抄表";
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "已预收";
                    else if (e.Value.ToString() == "3")
                        e.Value = "已收费";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "REMITCANCEL")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "已作废";
                    }
                    else if (e.Value.ToString() == "0")
                        e.Value = "正常";
            }
        }

        private void dgList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgList.Rows[dgList.Rows.Count - 1].Cells["waterUserNO"].Value = "合计:";

            DataTable dtWaterMeterListTemp = dtWaterMeterList.Copy();
            //计算用户数量
            DataView dvWaterUserListSum = dtWaterMeterListTemp.DefaultView;
            int intWaterUserListCount = dvWaterUserListSum.ToTable(true, "waterUserId").Rows.Count;
            dgList.Rows[dgList.Rows.Count - 1].Cells["waterUserName"].Value = intWaterUserListCount;

            //计算水表数量
            object objCount = dtWaterMeterListTemp.Compute("COUNT(waterMeterNo)", "true");
            if (Information.IsNumeric(objCount))
                dgList.Rows[dgList.Rows.Count - 1].Cells["waterMeterNo"].Value = Convert.ToInt32(objCount);

            //统计水费小计
            object objSumWaterToltalCharge = dtWaterMeterListTemp.Compute("SUM(waterTotalCharge)", "");
            if (Information.IsNumeric(objSumWaterToltalCharge))
                dgList.Rows[dgList.Rows.Count - 1].Cells["waterTotalCharge"].Value = Convert.ToDecimal(objSumWaterToltalCharge).ToString("F2");

            //统计水费小计
            object objSumWaterREMITWATERFEE = dtWaterMeterListTemp.Compute("SUM(REMITWATERFEE)", "");
            if (Information.IsNumeric(objSumWaterREMITWATERFEE))
                dgList.Rows[dgList.Rows.Count - 1].Cells["REMITWATERFEE"].Value = Convert.ToDecimal(objSumWaterREMITWATERFEE).ToString("F2");

            //统计附加费
            object objSumextraTotalCharge = dtWaterMeterListTemp.Compute("SUM(extraTotalCharge)", "");
            if (Information.IsNumeric(objSumextraTotalCharge))
                dgList.Rows[dgList.Rows.Count - 1].Cells["extraTotalCharge"].Value = Convert.ToDecimal(objSumextraTotalCharge).ToString("F2");

            //统计水费小计
            object objSumWaterREMITEXTRAFEE = dtWaterMeterListTemp.Compute("SUM(REMITEXTRAFEE)", "");
            if (Information.IsNumeric(objSumWaterREMITEXTRAFEE))
                dgList.Rows[dgList.Rows.Count - 1].Cells["REMITEXTRAFEE"].Value = Convert.ToDecimal(objSumWaterREMITEXTRAFEE).ToString("F2");

            //统计滞纳金
            object objSumOVERDUE = dtWaterMeterListTemp.Compute("SUM(OVERDUEGET)", "");
            if (Information.IsNumeric(objSumOVERDUE))
                dgList.Rows[dgList.Rows.Count - 1].Cells["OVERDUEGET"].Value = Convert.ToDecimal(objSumOVERDUE).ToString("F2");

            //统计滞纳金
            object objSumREMITOVERDUE = dtWaterMeterListTemp.Compute("SUM(REMITOVERDUE)", "");
            if (Information.IsNumeric(objSumREMITOVERDUE))
                dgList.Rows[dgList.Rows.Count - 1].Cells["REMITOVERDUE"].Value = Convert.ToDecimal(objSumREMITOVERDUE).ToString("F2");

            //统计水费总计
            object objSumtotalCharge = dtWaterMeterListTemp.Compute("SUM(totalCharge)", "");
            if (Information.IsNumeric(objSumtotalCharge))
                dgList.Rows[dgList.Rows.Count - 1].Cells["totalCharge"].Value = Convert.ToDecimal(objSumtotalCharge).ToString("F2");

            //统计减免后水费总计
            object objTOTALCHARGEEND = dtWaterMeterListTemp.Compute("SUM(TOTALCHARGEEND)", "");
            if (Information.IsNumeric(objTOTALCHARGEEND))
                dgList.Rows[dgList.Rows.Count - 1].Cells["TOTALCHARGEEND"].Value = Convert.ToDecimal(objTOTALCHARGEEND).ToString("F2");
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

        private void btSetMonth_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btSetMonth, 0, btSetMonth.Width + 1);
        }
    }
}
