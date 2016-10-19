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
    public partial class frmWaterMeterChargeCancelSearch : DockContentEx
    {
        public frmWaterMeterChargeCancelSearch()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        //BLLmeterReading BLLmeterReading = new BLLmeterReading();
        //BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();
        //BLLAREA BLLAREA = new BLLAREA();
        //BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        //BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        //BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();

        //BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        

        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;
            dgList.Columns["readMeterRecordYearAndMonth"].DefaultCellStyle.Format = "yyyy-MM";

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                //隐藏附加费列
                if (dgList.Columns[i].Name == "extraChargePrice1" || dgList.Columns[i].Name == "extraCharge1" ||
                    dgList.Columns[i].Name == "extraChargePrice2" || dgList.Columns[i].Name == "extraCharge2" ||
                    dgList.Columns[i].Name == "extraChargePrice3" || dgList.Columns[i].Name == "extraCharge3" ||
                    dgList.Columns[i].Name == "extraChargePrice4" || dgList.Columns[i].Name == "extraCharge4" ||
                    dgList.Columns[i].Name == "extraChargePrice5" || dgList.Columns[i].Name == "extraCharge5" ||
                    dgList.Columns[i].Name == "extraChargePrice6" || dgList.Columns[i].Name == "extraCharge6" ||
                    dgList.Columns[i].Name == "extraChargePrice7" || dgList.Columns[i].Name == "extraCharge7" ||
                    dgList.Columns[i].Name == "extraChargePrice8" || dgList.Columns[i].Name == "extraCharge8")
                {
                    dgList.Columns[i].Visible = false;
                }
            }
            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);

            GetExtraFeeName();
            BindWaterMeterType(cmbWaterMeterType);
            BindChargeWorkerName(cmbChargerWorkName);
            BindCharger(cmbCharger);

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
        }
        /// <summary>
        /// 根据附加费表生成附加费列及单价
        /// </summary>
        private void GetExtraFeeName()
        {
            DataTable dt = BLLEXTRACHARGE.Query(" ORDER BY extraChargeID");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object objExtraFee = dt.Rows[i]["extraChargeName"];
                if (objExtraFee != null && objExtraFee != DBNull.Value)
                {
                    dgList.Columns["extraCharge" + (i + 1).ToString()].HeaderText = objExtraFee.ToString();
                    dgList.Columns["extraChargePrice" + (i + 1).ToString()].HeaderText = objExtraFee.ToString() + "单价";

                    object objExtraChargeState = dt.Rows[i]["extraChargeState"];
                    if (objExtraChargeState != null && objExtraChargeState != DBNull.Value)
                    {
                        if (objExtraChargeState.ToString() == "启用")
                        {
                            dgList.Columns["extraCharge" + (i + 1).ToString()].Visible = true;
                            dgList.Columns["extraChargePrice" + (i + 1).ToString()].Visible = true;
                        }
                    }
                }
            }
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
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND IsCashier='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
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
        /// 绑定收费员
        /// </summary>
        private void BindCharger(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1' ");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                LoadData();

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("收费冲减明细查询界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("收费冲减明细查询界面:" + ex.ToString(), MsgType.Error);
            }
        }
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

                if (txtWaterUserNameSearch.Text.Trim() != "")
                    strFilter += " AND waterUserName LIKE '%" + txtWaterUserNameSearch.Text + "%' ";


                if (cmbAreaNOS.SelectedIndex > 0)
                    strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
                if (cmbPianNOS.SelectedIndex > 0)
                    strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
                if (cmbDuanNOS.SelectedIndex > 0)
                    strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

                if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (cmbCharger.SelectedValue != null && cmbCharger.SelectedValue != DBNull.Value)
                    strFilter += " AND chargerID='" + cmbCharger.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                if (chkCancelDateTime.Checked)
                    strFilter += " AND CANCELDATETIME BETWEEN '" + dtpCancelStart.Text + "' AND '" + dtpCancelEnd.Text + "'";

                if (txtYearAndMonth.Text.Length == 6)
                {
                    string strYear = txtYearAndMonth.Text.Substring(0, 4), strMonth = txtYearAndMonth.Text.Substring(4, 2);
                    //查询条件
                    strFilter += " AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,'"+strYear+"-"+strMonth+"-01')=0 ";
                }

                strFilter += " ORDER BY CANCELDATETIME DESC";
                DataTable dtWaterMeterList = BLLWATERFEECHARGE.QueryChargeCancel(strFilter);
                dgList.DataSource = dtWaterMeterList;
                if (dgList.Rows.Count > 0)
                {
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;

                    #region 将用到的附加费显示出来
                    //for (int i = 0; i < dgList.Rows.Count; i++)
                    //{
                    //    //将用到的附加费列显示出来
                    //    object objWaterMeterTypeID = dgList.Rows[i].Cells["waterMeterTypeId"].Value;
                    //    if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
                    //    {
                    //        object objExtraFee = BLLWATERMETERTYPE.GetExtraCharge(" AND waterMeterTypeId='" + objWaterMeterTypeID.ToString() + "'");
                    //        if (objExtraFee != null && objExtraFee != DBNull.Value)
                    //        {
                    //            string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                    //            for (int j = 0; j < strAllExtraFee.Length; j++)
                    //            {
                    //                string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                    //                if (strSingleExtraFee[0].Contains("F"))
                    //                {
                    //                    string strNum = strSingleExtraFee[0].Substring(1, 1);
                    //                    dgList.Columns["extraCharge" + strNum].Visible = true;
                    //                    dgList.Columns["extraChargePrice" + strNum].Visible = true;
                    //                    dgList.Rows[i].Cells["extraChargePrice" + strNum].Value = strSingleExtraFee[1];
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion

                    DataTable dtWaterMeterListOld = dtWaterMeterList.Copy();
                    dtWaterMeterList.Rows.Add();
                    dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["CANCELWORKERNAME"] = "合计:";

                    object objCount = dtWaterMeterListOld.Compute("COUNT(waterMeterNo)", "true");
                    if (Information.IsNumeric(objCount))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["waterMeterNo"] = Convert.ToInt32(objCount);


                    object objSumtotalNumber = dtWaterMeterListOld.Compute("SUM(totalNumber)", "");
                    if (Information.IsNumeric(objSumtotalNumber))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["totalNumber"] = Convert.ToInt64(objSumtotalNumber);

                    object objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(waterTotalCharge)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["waterTotalCharge"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");

                    object objSumextraTotalChargeend = dtWaterMeterListOld.Compute("SUM(extraTotalCharge)", "");
                    if (Information.IsNumeric(objSumextraTotalChargeend))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["extraTotalCharge"] = Convert.ToDecimal(objSumextraTotalChargeend).ToString("F2");

                    object objSumOVERDUEEND = dtWaterMeterListOld.Compute("SUM(OVERDUEMONEY)", "");
                    if (Information.IsNumeric(objSumOVERDUEEND))
                        dgList.Rows[dtWaterMeterList.Rows.Count - 1].Cells["OVERDUEMONEY"].Value = Convert.ToDecimal(objSumOVERDUEEND).ToString("F2");

                    object objSumtotalChargeEND = dtWaterMeterListOld.Compute("SUM(totalCharge)", "");
                    if (Information.IsNumeric(objSumtotalChargeEND))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["totalCharge"] = Convert.ToDecimal(objSumtotalChargeEND).ToString("F2");

                    #region 合计收费明细
                    DataView dvWaterMeterListOld = dtWaterMeterListOld.DefaultView;
                    DataTable dtChargeList = dvWaterMeterListOld.ToTable(true, "CHARGEID", "CHARGEBCYS", "CHARGEBCSS", "CHARGEYSQQYE", "CHARGEYSBCSZ", "CHARGEYSJSYE");

                    object objChargeIdCount = dtChargeList.Compute("COUNT(CHARGEID)", "true");
                    if (Information.IsNumeric(objChargeIdCount))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["CHARGEID"] = Convert.ToInt32(objChargeIdCount);

                    object objSumChargeBCYS = dtChargeList.Compute("SUM(CHARGEBCYS)", "");
                    if (Information.IsNumeric(objSumChargeBCYS))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["CHARGEBCYS"] = Convert.ToDecimal(objSumChargeBCYS).ToString("F2");

                    object objSumChargeBCSS = dtChargeList.Compute("SUM(CHARGEBCSS)", "");
                    if (Information.IsNumeric(objSumChargeBCSS))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["CHARGEBCSS"] = Convert.ToDecimal(objSumChargeBCSS).ToString("F2");

                    object objSumChargeYSQQYE = dtChargeList.Compute("SUM(CHARGEYSQQYE)", "");
                    if (Information.IsNumeric(objSumChargeYSQQYE))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["CHARGEYSQQYE"] = Convert.ToDecimal(objSumChargeYSQQYE).ToString("F2");

                    object objSumChargeYSJSYE = dtChargeList.Compute("SUM(CHARGEYSJSYE)", "");
                    if (Information.IsNumeric(objSumChargeYSJSYE))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["CHARGEYSJSYE"] = Convert.ToDecimal(objSumChargeYSJSYE).ToString("F2");
                    #endregion

                    #region 获取用户数量
                    DataTable dtWaterUser = dvWaterMeterListOld.ToTable(true, "waterUserNO");
                    object objUserIDCount = dtWaterUser.Compute("COUNT(waterUserNO)", "true");
                    if (Information.IsNumeric(objUserIDCount))
                        dtWaterMeterList.Rows[dtWaterMeterList.Rows.Count - 1]["waterUserNO"] = Convert.ToInt32(objUserIDCount);
                    #endregion
                    //dgList.DataSource = dtWaterMeterList;
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
            DataTable dtPrint = dt.DefaultView.ToTable(true, "CHARGEID", "CANCELWORKERNAME", "CANCELDATETIME", "CANCELMEMO", "WATERTOTALCHARGECHARGE",
                "EXTRATOTALCHARGECHARGE", "OVERDUEMONEYCHARGE", "TOTALCHARGECHARGE", "CHARGEBCYS", "CHARGEBCSS", "CHARGEDATETIME", "CHARGEWORKERNAME", "waterUserNO",
                "waterUserName", "waterPhone", "waterUserAddress", "INVOICEBATCHNAME", "INVOICENO");
            dtPrint.TableName = "收费冲减明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收费冲减明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("收费冲减明细表").Enabled = true;
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
            //DataTable dtPrint = dt.Copy();
            DataTable dtPrint = dt.DefaultView.ToTable(true, "CHARGEID", "CANCELWORKERNAME", "CANCELDATETIME", "CANCELMEMO", "WATERTOTALCHARGECHARGE",
                "EXTRATOTALCHARGECHARGE", "OVERDUEMONEYCHARGE", "TOTALCHARGECHARGE", "CHARGEBCYS", "CHARGEBCSS", "CHARGEDATETIME", "CHARGEWORKERNAME", "waterUserNO",
                "waterUserName", "waterPhone", "waterUserAddress", "INVOICEBATCHNAME", "INVOICENO");
            dtPrint.TableName = "收费冲减明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收费冲减明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("收费冲减明细表").Enabled = true;
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
                    if (obj != null && obj!=DBNull.Value)
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
        private void btRight_Click(object sender, EventArgs e)
        {
            if (txtYearAndMonth.Text.Trim() == "")
            {
                DateTime dtNow = mes.GetDatetimeNow();
                txtYearAndMonth.Text = dtNow.ToString("yyyyMM");
                return;
            }
            if (txtYearAndMonth.Text.Length != 6)
            {
                mes.Show("系统检测到月份格式不正确,请重新打开窗体!");
                return;
            }
            string strDate = txtYearAndMonth.Text.Substring(0, 4) + "-" + txtYearAndMonth.Text.Substring(4, 2) + "-" + "01";
            if (Information.IsDate(strDate))
            {
                txtYearAndMonth.Text = Convert.ToDateTime(strDate).AddMonths(1).ToString("yyyyMM");
            }
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            if (txtYearAndMonth.Text.Trim() == "")
            {
                DateTime dtNow = mes.GetDatetimeNow();
                txtYearAndMonth.Text = dtNow.ToString("yyyyMM");
                return;
            }
            if (txtYearAndMonth.Text.Length != 6)
            {
                mes.Show("系统检测到月份格式不正确,请重新打开窗体!");
                return;
            }
            string strDate = txtYearAndMonth.Text.Substring(0, 4) + "-" + txtYearAndMonth.Text.Substring(4, 2) + "-" + "01";
            if (Information.IsDate(strDate))
            {
                txtYearAndMonth.Text = Convert.ToDateTime(strDate).AddMonths(-1).ToString("yyyyMM");
            }
        }       
    }
}
