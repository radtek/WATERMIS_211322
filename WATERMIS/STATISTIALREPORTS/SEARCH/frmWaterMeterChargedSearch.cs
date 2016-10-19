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
    public partial class frmWaterMeterChargedSearch : DockContentEx
    {
        public frmWaterMeterChargedSearch()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();

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
                ////禁止列排序
                //dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                //if (dgList.Columns[i].Name == "cellSelect")
                //{
                //    //本月读数可编辑
                //    dgList.Columns[i].ReadOnly = false;
                //}
                //else
                //    dgList.Columns[i].ReadOnly = true;

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
            DateTime dtMonthStart=new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;
            dtpStartPrint.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtpEndPrint.Value = dtMonthEnd;
            dtpEnd.Value = dtMonthEnd;

            GetExtraFeeName();
            BindWaterMeterType(cmbWaterMeterType);
            BindChargeWorkerName(cmbChargerWorkName);
            BindCharger(cmbCharger);

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
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
                    //dgList.Columns["extraCharge" + (i + 1).ToString()].HeaderText = objExtraFee.ToString();
                    dgList.Columns["extraChargePrice" + (i + 1).ToString()].HeaderText = objExtraFee.ToString() + "单价";

                    object objExtraChargeState = dt.Rows[i]["extraChargeState"];
                    if (objExtraChargeState != null && objExtraChargeState != DBNull.Value)
                    {
                        if (objExtraChargeState.ToString() == "启用")
                        {
                            //dgList.Columns["extraCharge" + (i + 1).ToString()].Visible = true;
                            dgList.Columns["extraChargePrice" + (i + 1).ToString()].Visible = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绑定用户类别
        /// </summary>
        /// <param name="cmb"></param>
        private void BindWaterUserType(ComboBox cmb)
        {
            DataTable dt = BLLwaterUserType.Query("");
            DataRow dr = dt.NewRow();
            dr["waterUserTypeName"] = "";
            dr["waterUserTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterUserTypeName";
            cmb.ValueMember = "waterUserTypeId";
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
        /// 绑定托收银行
        /// </summary>
        /// <param name="cmb"></param>
        private void BindBank(ComboBox cmb)
        {
            DataTable dt = BLLBASE_BANK.Query("");
            DataRow dr = dt.NewRow();
            dr["bankName"] = "";
            dr["bankId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "bankName";
            cmb.ValueMember = "bankId";
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
                log.Write("收费明细查询界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("收费明细查询界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 存储查询到的水表列表
        /// </summary>
        DataTable dtWaterMeterList = new DataTable();

        /// <summary>
        /// 存储统计行信息
        /// </summary>
        DataTable dtClone = new DataTable();
        private void LoadData()
        {
            try
            {
                string strFilter = strSeniorFilterHidden;
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

                if (chkYearAndMonth.Checked)
                    strFilter += " AND readMeterRecordYearAndMonth BETWEEN '" + dtpStartPrint.Text + "' AND '" + dtpEndPrint.Text + "'";

                if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (cmbCharger.SelectedValue != null && cmbCharger.SelectedValue != DBNull.Value)
                    strFilter += " AND chargerID='" + cmbCharger.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                ////查询出DISTINCT 收费记录，便于统计总金额
                //string strSQL = "SELECT CHARGEID,CHARGEBCYS,CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE FROM WATERFEECHARGE WHERE CHARGEID IN ("+
                //    " SELECT CHARGEID FROM V_CHARGE WHERE 1=1 "+strFilter+")";
                //DataTable dtChargeList = BLLWATERFEECHARGE.QueryBySQL(strSQL);

                //交费户数，水量
                int intJFHS = 0, intTotalNumber = 0, intDJSL = 0;

                //水费，污水处理费，附加费，滞纳金，水费小计，水费总计，实交金额，预存增减，结算余额
                decimal decWaterTotalCharge = 0, decExcharge1 = 0, decExcharge2 = 0, decOverDue = 0, 
                    decTotalCharge = 0, decTotalChargeEnd = 0,decYSJE=0, decSJJE = 0, decYCZJ = 0, decJSJE = 0;

                DataTable dtWaterUserCount = BLLWATERFEECHARGE.QueryBySQL("SELECT DISTINCT waterUserId FROM V_WATERFEEANDPRESTORECHARGE WHERE 1=1 " + strFilter);
                intJFHS = dtWaterUserCount.Rows.Count;

                strFilter += " ORDER BY  CHARGEWORKERID,CHARGEDATETIME";

                dtWaterMeterList = BLLWATERFEECHARGE.QueryWaterFeeAndPrestoreCharge(strFilter);
                intDJSL = dtWaterMeterList.Rows.Count;

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;

                    dtClone = dtWaterMeterList.Clone();
                    DataRow drLast = dtClone.NewRow();

                    drLast["CHARGEWORKERNAME"] = "合计:";

                    object objSumtotalNumber = dtWaterMeterList.Compute("SUM(totalNumber)", "");
                    if (Information.IsNumeric(objSumtotalNumber))
                    {
                        drLast["totalNumber"] = Convert.ToInt32(objSumtotalNumber);
                        intTotalNumber = Convert.ToInt32(objSumtotalNumber);
                    }

                    object objSumWaterToltalChargeEnd = dtWaterMeterList.Compute("SUM(waterTotalCharge)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                    {
                        drLast["waterTotalCharge"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");
                        decWaterTotalCharge = Convert.ToDecimal(objSumWaterToltalChargeEnd);
                    }

                    object objSumextraTotalCharge1 = dtWaterMeterList.Compute("SUM(extraCharge1)", "");
                    if (Information.IsNumeric(objSumextraTotalCharge1))
                    {
                        drLast["extraCharge1"] = Convert.ToDecimal(objSumextraTotalCharge1).ToString("F2");
                        decExcharge1=Convert.ToDecimal(objSumextraTotalCharge1);
                    }

                    object objSumextraTotalCharge2 = dtWaterMeterList.Compute("SUM(extraCharge2)", "");
                    if (Information.IsNumeric(objSumextraTotalCharge2))
                    {
                        drLast["extraCharge2"] = Convert.ToDecimal(objSumextraTotalCharge2).ToString("F2");
                        decExcharge2 = Convert.ToDecimal(objSumextraTotalCharge2);
                    }


                    object objSumOVERDUEEND = dtWaterMeterList.Compute("SUM(OVERDUEEND)", "");
                    if (Information.IsNumeric(objSumOVERDUEEND))
                    {
                        drLast["OVERDUEEND"] = Convert.ToDecimal(objSumOVERDUEEND).ToString("F2");
                        decOverDue = Convert.ToDecimal(objSumOVERDUEEND);
                    }

                    object objSumtotalCharge = dtWaterMeterList.Compute("SUM(totalCharge)", "");
                    if (Information.IsNumeric(objSumtotalCharge))
                    {
                        drLast["totalCharge"] = Convert.ToDecimal(objSumtotalCharge).ToString("F2");
                        decTotalCharge = Convert.ToDecimal(objSumtotalCharge);
                    }

                    object objSumtotalChargeEND = dtWaterMeterList.Compute("SUM(totalChargeEND)", "");
                    if (Information.IsNumeric(objSumtotalChargeEND))
                    {
                        drLast["totalChargeEND"] = Convert.ToDecimal(objSumtotalChargeEND).ToString("F2");
                        decTotalChargeEnd = Convert.ToDecimal(objSumtotalChargeEND);
                    }

                    #region 合计收费明细
                    //DataView dvWaterMeterListOld = dtWaterMeterListOld.DefaultView;
                    ////DataTable dtChargeList = dvWaterMeterListOld.ToTable(true, "CHARGEID", "CHARGEBCYS", "CHARGEBCSS", "CHARGEYSQQYE", "CHARGEYSBCSZ", "CHARGEYSJSYE");

                    //object objChargeIdCount = dtWaterMeterList.Compute("COUNT(CHARGEID)", "true");
                    //if (Information.IsNumeric(objChargeIdCount))
                    //    drLast["CHARGEID"] = "共" + Convert.ToInt32(objChargeIdCount) + "条";

                    object objSumChargeBCYS = dtWaterMeterList.Compute("SUM(CHARGEBCYS)", "");
                    if (Information.IsNumeric(objSumChargeBCYS))
                    {
                        drLast["CHARGEBCYS"] = Convert.ToDecimal(objSumChargeBCYS).ToString("F2");
                        decYSJE = Convert.ToDecimal(objSumChargeBCYS);
                    }

                    object objSumChargeBCSS = dtWaterMeterList.Compute("SUM(CHARGEBCSS)", "");
                    if (Information.IsNumeric(objSumChargeBCSS))
                    {
                        drLast["CHARGEBCSS"] = Convert.ToDecimal(objSumChargeBCSS).ToString("F2");
                        decSJJE = Convert.ToDecimal(objSumChargeBCSS);
                    }

                    object objSumChargeYSBCSZ = dtWaterMeterList.Compute("SUM(CHARGEYSBCSZ)", "");
                    if (Information.IsNumeric(objSumChargeYSBCSZ))
                    {
                        drLast["CHARGEYSBCSZ"] = Convert.ToDecimal(objSumChargeYSBCSZ).ToString("F2");
                        decYCZJ = Convert.ToDecimal(objSumChargeYSBCSZ);
                    }

                    object objSumChargeJSYE = dtWaterMeterList.Compute("SUM(CHARGEYSJSYE)", "");
                    if (Information.IsNumeric(objSumChargeJSYE))
                    {
                        drLast["CHARGEYSJSYE"] = Convert.ToDecimal(objSumChargeJSYE).ToString("F2");
                        decJSJE = Convert.ToDecimal(objSumChargeJSYE);
                    }
                    #endregion
                    dgList.DataSource = dtWaterMeterList;
                    //dgList.DataSource = dtWaterMeterList;
                }
                else
                {
                    dgList.DataSource = null;

                    toolPrint.Enabled = false;
                    toolPrintPreview.Enabled = false;
                }

                labDJSL.Text = intDJSL.ToString();
                labJFCount.Text = intJFHS.ToString();
                labWaterTotalNumber.Text = intTotalNumber.ToString();
                labWaterTotalFee.Text = decWaterTotalCharge.ToString("F2");
                labExtraCharge1.Text = decExcharge1.ToString("F2");
                labExtraCharge2.Text = decExcharge2.ToString("F2");
                labSFXiaoJi.Text = decTotalCharge.ToString("F2");
                labOverDue.Text = decOverDue.ToString("F2");
                labSFHJ.Text = decTotalChargeEnd.ToString("F2");
                labYSHJ.Text = decYSJE.ToString("F2");
                labSJJE.Text = decSJJE.ToString("F2");
                labYCZJ.Text = decYCZJ.ToString("F2");
                labJSYE.Text = decJSJE.ToString("F2");
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
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
            DataTable dtRecordTemp = dtWaterMeterList.Clone();
            dtRecordTemp.Columns["readMeterRecordYearAndMonth"].DataType = typeof(string);
            foreach (DataRow dr in dtWaterMeterList.Rows)
            {
                dtRecordTemp.ImportRow(dr);
            }
            for (int i = 0; i < dtRecordTemp.Rows.Count; i++)
            {
                object obj = dtRecordTemp.Rows[i]["readMeterRecordYearAndMonth"];
                if (Information.IsDate(obj))
                    dtRecordTemp.Rows[i]["readMeterRecordYearAndMonth"] = Convert.ToDateTime(obj).ToString("yyyy-MM");
                //object objWaterMeterNO = dtRecord.Rows[i]["waterMeterNo"];
                //if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                //    if (objWaterMeterNO.ToString().Length > 7)
                //        dtRecord.Rows[i]["waterMeterNo"] = objWaterMeterNO.ToString().Substring(6, 2);
            }

            DataTable dtPrint = dtRecordTemp.Copy();
            dtPrint.TableName = "收费明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\实收明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("收费明细表").Enabled = true;
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
            if (dtWaterMeterList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtRecordTemp = dtWaterMeterList.Clone();
            dtRecordTemp.Columns["readMeterRecordYearAndMonth"].DataType = typeof(string);
            foreach (DataRow dr in dtWaterMeterList.Rows)
            {
                dtRecordTemp.ImportRow(dr);
            }
            for (int i = 0; i < dtRecordTemp.Rows.Count; i++)
            {
                object obj = dtRecordTemp.Rows[i]["readMeterRecordYearAndMonth"];
                if (Information.IsDate(obj))
                    dtRecordTemp.Rows[i]["readMeterRecordYearAndMonth"] = Convert.ToDateTime(obj).ToString("yyyy-MM");
                //object objWaterMeterNO = dtRecord.Rows[i]["waterMeterNo"];
                //if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                //    if (objWaterMeterNO.ToString().Length > 7)
                //        dtRecord.Rows[i]["waterMeterNo"] = objWaterMeterNO.ToString().Substring(6, 2);
            }

            DataTable dtPrint = dtRecordTemp.Copy();
            dtPrint.TableName = "收费明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\实收明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("收费明细表").Enabled = true;
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
        }/// <summary>
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
        #region 自定义方法
        /// <summary>
        /// 画单元格
        /// </summary>
        /// <param name="e"></param>
        private void DrawCell(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            Brush gridBrush = new SolidBrush(dgList.GridColor);
            SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int cellwidth;
            //上面相同的行数
            int UpRows = 0;
            //下面相同的行数
            int DownRows = 0;
            //总行数
            int count = 0;
            cellwidth = e.CellBounds.Width;
            Pen gridLinePen = new Pen(gridBrush);
            string curValue = e.FormattedValue == null ? "" : e.FormattedValue.ToString().Trim();
            string curValueID = dgList.Rows[e.RowIndex].Cells["waterUserNO"].Value == null ? "" : dgList.Rows[e.RowIndex].Cells["waterUserNO"].Value.ToString().Trim();
            //if (!string.IsNullOrEmpty(curValue))
            //{
            #region 获取下面的行数
            for (int i = e.RowIndex; i < dgList.Rows.Count; i++)
            {
                object objValue = dgList.Rows[i].Cells[e.ColumnIndex].FormattedValue;
                string strValue = objValue == null ? "" : objValue.ToString();
                if (strValue.Equals(curValue) && dgList.Rows[i].Cells["waterUserNO"].Value.ToString().Equals(curValueID))
                //if (dgList.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                {
                    //dgList.Rows[i].Cells[e.ColumnIndex].Selected = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;

                    DownRows++;
                    if (e.RowIndex != i)
                    {
                        cellwidth = cellwidth < dgList.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgList.Rows[i].Cells[e.ColumnIndex].Size.Width;
                    }
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region 获取上面的行数
            for (int i = e.RowIndex; i >= 0; i--)
            {
                object objValue = dgList.Rows[i].Cells[e.ColumnIndex].FormattedValue;
                string strValue = objValue == null ? "" : objValue.ToString();
                if (strValue.Equals(curValue) && dgList.Rows[i].Cells["waterUserNO"].Value.ToString().Equals(curValueID))
                //if (dgList.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                {
                    //dgList.Rows[i].Cells[e.ColumnIndex].Selected = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
                    UpRows++;
                    if (e.RowIndex != i)
                    {
                        cellwidth = cellwidth < dgList.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgList.Rows[i].Cells[e.ColumnIndex].Size.Width;
                    }
                }
                else
                {
                    break;
                }
            }
            #endregion
            count = DownRows + UpRows - 1;
            if (count < 2)
            {
                return;
            }
            //}
            if (dgList.Rows[e.RowIndex].Selected)
            {
                backBrush.Color = e.CellStyle.SelectionBackColor;
                fontBrush.Color = e.CellStyle.SelectionForeColor;
            }
            //以背景色填充
            e.Graphics.FillRectangle(backBrush, e.CellBounds);
            //画字符串
            PaintingFont(e, cellwidth, UpRows, DownRows, count);
            if (DownRows == 1)
            {
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                count = 0;
            }
            // 画右边线
            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

            e.Handled = true;
        }
        /// <summary>
        /// 画字符串
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cellwidth"></param>
        /// <param name="UpRows"></param>
        /// <param name="DownRows"></param>
        /// <param name="count"></param>
        private void PaintingFont(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, int cellwidth, int UpRows, int DownRows, int count)
        {
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
            int fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
            int cellheight = e.CellBounds.Height;

            if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomCenter)
            {
                e.Graphics.DrawString((String)e.FormattedValue, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft)
            {
                e.Graphics.DrawString((String)e.FormattedValue, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
            {
                e.Graphics.DrawString((String)e.FormattedValue, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
            {
                e.Graphics.DrawString((String)e.FormattedValue, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
            {
                e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
            {
                e.Graphics.DrawString((String)e.FormattedValue, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter)
            {
                e.Graphics.DrawString((String)e.FormattedValue, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft)
            {
                e.Graphics.DrawString((String)e.FormattedValue, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
            {
                e.Graphics.DrawString((String)e.FormattedValue, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else
            {
                e.Graphics.DrawString((String)e.FormattedValue, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
        }
        #endregion

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "3";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                toolSearch_Click(null,null);
        }

        private void 今天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();

            if (strButtonID == "2")
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                dtpStart.Value = dtMonthStart;

                DateTime dtMonthEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
                dtpEnd.Value = dtMonthEnd;
            }
            else
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                dtpStartPrint.Value = dtMonthStart;

                DateTime dtMonthEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
                dtpEndPrint.Value = dtMonthEnd;
            }
        }

        private void 本月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            if (strButtonID == "2")
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
                dtpStart.Value = dtMonthStart;

                DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEnd.Value = dtMonthEnd;
            }
            else
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
                dtpStartPrint.Value = dtMonthStart;

                DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEndPrint.Value = dtMonthEnd;
            }
        }

        private void 上月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            if (strButtonID == "2")
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
                DateTime dtLastMonth = dtMonthStart.AddMonths(-1);
                dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtLastMonth.Day, 0, 0, 0);
                dtpStart.Value = dtLastMonth;

                DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEnd.Value = dtMonthEnd;
            }
            else
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
                DateTime dtLastMonth = dtMonthStart.AddMonths(-1);
                dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtLastMonth.Day, 0, 0, 0);
                dtpStartPrint.Value = dtLastMonth;

                DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEndPrint.Value = dtMonthEnd;
            }
        }

        private void 下月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            if (strButtonID == "2")
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
                DateTime dtLastMonth = dtMonthStart.AddMonths(1);
                dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtMonthStart.Day, 0, 0, 0);
                dtpStart.Value = dtLastMonth;

                DateTime dtMonthEnd = dtMonthStart.AddMonths(2).AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEnd.Value = dtMonthEnd;
            }
            else
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
                DateTime dtLastMonth = dtMonthStart.AddMonths(1);
                dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtMonthStart.Day, 0, 0, 0);
                dtpStartPrint.Value = dtLastMonth;

                DateTime dtMonthEnd = dtMonthStart.AddMonths(2).AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEndPrint.Value = dtMonthEnd;
            }
        }

        private void 本年ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            if (strButtonID == "2")
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
                DateTime dtLastMonth = new DateTime(dtMonthStart.Year, 1, 1, 0, 0, 0);
                dtpStart.Value = dtLastMonth;

                DateTime dtMonthEnd = dtMonthStart.AddYears(1).AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEnd.Value = dtMonthEnd;
            }
            else
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
                DateTime dtLastMonth = new DateTime(dtMonthStart.Year, 1, 1, 0, 0, 0);
                dtpStartPrint.Value = dtLastMonth;

                DateTime dtMonthEnd = dtMonthStart.AddYears(1).AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEndPrint.Value = dtMonthEnd;
            }
        }

        private void 上年ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            if (strButtonID == "2")
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
                DateTime dtLastYear = new DateTime(dtMonthStart.AddYears(-1).Year, 1, 1, 0, 0, 0);
                dtpStart.Value = dtLastYear;

                DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEnd.Value = dtMonthEnd;
            }
            else
            {
                DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
                DateTime dtLastYear = new DateTime(dtMonthStart.AddYears(-1).Year, 1, 1, 0, 0, 0);
                dtpStartPrint.Value = dtLastYear;

                DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
                dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
                dtpEndPrint.Value = dtMonthEnd;
            }
        }

        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strButtonID == "2")
            {
                DateTime dtLastYear = new DateTime(2000, 1, 1);
                dtpStart.Value = dtLastYear;

                DateTime dtMonthEnd = new DateTime(3000, 1, 1, 23, 59, 59);
                dtpEnd.Value = dtMonthEnd;
            }
            else
            {
                DateTime dtLastYear = new DateTime(2000, 1, 1);
                dtpStartPrint.Value = dtLastYear;

                DateTime dtMonthEnd = new DateTime(3000, 1, 1, 23, 59, 59);
                dtpEndPrint.Value = dtMonthEnd;
            }
        }

        string strButtonID = "1";
        private void btSetMonth_Click(object sender, EventArgs e)
        {
            strButtonID = "1";
            contextMenuStrip1.Show(btSetMonth, 0, btSetMonth.Width + 1);
        }

        private void btSetMonthCharge_Click(object sender, EventArgs e)
        {
            strButtonID = "2";
            contextMenuStrip1.Show(btSetMonthCharge, 0, btSetMonth.Width + 1);
        }
       
    }
}
