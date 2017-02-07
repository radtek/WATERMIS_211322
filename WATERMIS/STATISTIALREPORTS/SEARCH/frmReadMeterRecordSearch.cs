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
    public partial class frmReadMeterRecordSearch : DockContentEx
    {
        public frmReadMeterRecordSearch()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();

        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();

        BLLwaterUser BLLwaterUser = new BLLwaterUser();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();


        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);

            dgList.Columns["readMeterRecordYearAndMonth"].DefaultCellStyle.Format = "yyyy-MM";

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                //禁止列排序
                //dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //BindWaterMeterType();

            //BindMeterReader();

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
            //BindWaterMeterSummary();
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
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbMeterReaderS.DataSource = dt;
            cmbMeterReaderS.DisplayMember = "USERNAME";
            cmbMeterReaderS.ValueMember = "LOGINID";
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
        }
        ///// <summary>
        ///// 绑定用水类别
        ///// </summary>
        //private void BindWaterMeterType()
        //{
        //    DataTable dt = BLLWATERMETERTYPE.Query("");
        //    DataRow dr = dt.NewRow();
        //    dr["waterMeterTypeValue"] = "";
        //    dr["waterMeterTypeId"] = DBNull.Value;
        //    dt.Rows.InsertAt(dr, 0);
        //    cmbWaterMeterType.DataSource = dt;
        //    cmbWaterMeterType.DisplayMember = "waterMeterTypeValue";
        //    cmbWaterMeterType.ValueMember = "waterMeterTypeId";
        //}
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
                log.Write("已抄水表明细查询界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("已抄水表明细查询界面:" + ex.ToString(), MsgType.Error);
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
                string strFilter =strSeniorFilterHidden;
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
                if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

                if (chkYearAndMonth.Checked)
                {
                    strFilter += " AND readMeterRecordYearAndMonth BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";
                }

                if (cmbIsMeterRead.SelectedIndex > 0)
                    if(cmbIsMeterRead.SelectedIndex==2)
                    strFilter += " AND chargeState>'0'";
                    else if (cmbIsMeterRead.SelectedIndex == 1)
                        strFilter += " AND chargeState='0'";
                    else if (cmbIsMeterRead.SelectedIndex == 3)
                        strFilter += " AND chargeState='3'";


                if (cmbIsChecked.SelectedIndex > 0)
                    strFilter += " AND checkstate='" + (cmbIsChecked.SelectedIndex-1).ToString() + "'";

                if (chkPeriod.Checked)
                {
                    if (Information.IsNumeric(txtPeriod.Text) && Convert.ToDecimal(txtPeriod.Text)>0)
                        strFilter += " AND NotReadMonthCount>" + Convert.ToInt32(txtPeriod.Text);
                    else
                    {
                        mes.Show("请输入正确的未抄期数");
                        return;
                    }
                }

                if (chkTotalNum.Checked)
                {
                    if (Information.IsNumeric(txtTotalNumStart.Text) && Convert.ToDecimal(txtTotalNumStart.Text) >= 0)
                        strFilter += " AND totalNumber>" + Convert.ToInt32(txtTotalNumStart.Text);
                    else
                    {
                        mes.Show("请输入正确的起始用水量");
                        return;
                    }
                    if (Information.IsNumeric(txtTotalNumEnd.Text) && Convert.ToDecimal(txtTotalNumEnd.Text) >= 0)
                        strFilter += " AND totalNumber<=" + Convert.ToInt32(txtTotalNumEnd.Text);
                }

                //用户余额
                decimal decWaterUserPreStore = 0, decYCJE = 0, decSFJE=0,decSFZJ = 0,decYSZJ=0,decYSXIAOJI=0, decSJYISHOU = 0, decSJQFJE = 0,
                        decExtraCharge1 = 0, decExtraCharge2 = 0, decWaterTotalFee = 0, decJSYE = 0, decOverDueMoney = 0;

                int intWaterUserCount = 0, intWaterUserYSCount = 0, intWaterTotalNumber = 0;
                string strGetWaterUserPrestore = "SELECT SUM(prestore) AS PRESTORE FROM WATERUSER WHERE WATERUSERID IN (SELECT WATERUSERID FROM readMeterRecord WHERE 1=1" +
                   strFilter + ")";
                DataTable dtWaterUser = BLLwaterUser.QuerySQL(strGetWaterUserPrestore);
                if (dtWaterUser.Rows.Count > 0)
                {
                    object objWaterUserPrestore = dtWaterUser.Rows[0]["PRESTORE"];
                    if (Information.IsNumeric(objWaterUserPrestore))
                        decWaterUserPreStore = Convert.ToDecimal(objWaterUserPrestore);
                }
                //string strGetWaterUserYSCount = "SELECT COUNT(*) AS SHULIANG FROM WATERUSER WHERE WATERUSERID IN (SELECT WATERUSERID FROM V_YSDETAIL_BYWATERMETER WHERE 1=1" +
                //   strFilter + ")";
                //DataTable dtWaterUserYSCount = BLLwaterUser.QuerySQL(strGetWaterUserPrestore);
                //if (dtWaterUserYSCount.Rows.Count > 0)
                //{

                //    object objWaterUserYSCount = dtWaterUserYSCount.Rows[0]["SHULIANG"];
                //    if (Information.IsNumeric(objWaterUserYSCount))
                //        intWaterUserCount = Convert.ToInt32(objWaterUserYSCount);
                //}

                DataTable dtYSLeiJI = BLLwaterUser.QuerySQL("SELECT SUM(CASE WHEN chargeState='3' THEN 0 ELSE  totalCharge END) AS YSQIANFEI " +
                    //"SUM(CASE chargeState WHEN '3' THEN totalChargeEND ELSE '0' END) AS YSYISHOU," +
                    //"SUM(totalCharge) AS YSXIAOJI," +
                    //"SUM(CASE chargeState WHEN '3' THEN totalChargeEND ELSE totalCharge END) AS YSZJ," +
                    //"SUM(CASE chargeState WHEN '3' THEN OVERDUEEND ELSE '0' END) AS YSOVERDUEMONEY" +
                    " FROM V_YSDETAIL_BYWATERMETER WHERE WATERUSERID IN (SELECT WATERUSERID FROM readMeterRecord WHERE 1=1" +
                   strFilter + ")");
                if (dtYSLeiJI.Rows.Count > 0)
                {
                    object obj = dtYSLeiJI.Rows[0]["YSQIANFEI"];
                    if (Information.IsNumeric(obj))
                        decSJQFJE = Convert.ToDecimal(obj);

                    //obj = dtYSLeiJI.Rows[0]["YSYISHOU"];
                    //if (Information.IsNumeric(obj))
                    //    decSJYISHOU = Convert.ToDecimal(obj);

                    //obj = dtYSLeiJI.Rows[0]["YSXIAOJI"];
                    //if (Information.IsNumeric(obj))
                    //    decYSXIAOJI = Convert.ToDecimal(obj);

                    //obj = dtYSLeiJI.Rows[0]["YSOVERDUEMONEY"];
                    //if (Information.IsNumeric(obj))
                    //    decOverDueMoney = Convert.ToDecimal(obj);

                    //obj = dtYSLeiJI.Rows[0]["YSZJ"];
                    //if (Information.IsNumeric(obj))
                    //    decYSZJ = Convert.ToDecimal(obj);
                }

                DataTable dtYS = BLLwaterUser.QuerySQL("SELECT "+
                    //"SUM(CASE chargeState WHEN '3' THEN totalCharge ELSE '0' END) AS YSYISHOU," +
                    "SUM(totalCharge) AS YSXIAOJI," +
                    "SUM(CASE chargeState WHEN '3' THEN totalChargeEND ELSE totalCharge END) AS YSZJ " +
                    //"SUM(CASE chargeState WHEN '3' THEN OVERDUEEND ELSE '0' END) AS YSOVERDUEMONEY" +
                    " FROM V_YSDETAIL_BYWATERMETER WHERE 1=1" +
               strFilter);
                if (dtYS.Rows.Count > 0)
                {
                    //object obj = dtYS.Rows[0]["YSQIANFEI"];
                    //if (Information.IsNumeric(obj))
                    //    decSJQFJE = Convert.ToDecimal(obj);

                    //object obj = dtYS.Rows[0]["YSYISHOU"];
                    //if (Information.IsNumeric(obj))
                    //    decSJYISHOU = Convert.ToDecimal(obj);

                    object obj = dtYS.Rows[0]["YSXIAOJI"];
                    if (Information.IsNumeric(obj))
                        decYSXIAOJI = Convert.ToDecimal(obj);

                    //obj = dtYS.Rows[0]["YSOVERDUEMONEY"];
                    //if (Information.IsNumeric(obj))
                    //    decOverDueMoney = Convert.ToDecimal(obj);

                    obj = dtYS.Rows[0]["YSZJ"];
                    if (Information.IsNumeric(obj))
                        decYSZJ = Convert.ToDecimal(obj);
                }

                string strYCJE = "SELECT SUM(CHARGEBCSS) FROM V_PRESTORERUNNINGACCOUNT_VALID WHERE WATERUSERID IN (SELECT WATERUSERID FROM readMeterRecord WHERE 1=1" +
                   strFilter + ")";
                object objWaterUserYCJE = BLLwaterUser.QuerySQLReturnOBJ(strYCJE);
                if (Information.IsNumeric(objWaterUserYCJE))
                    decYCJE = Convert.ToDecimal(objWaterUserYCJE);

                string strSFZJ = "SELECT SUM(CHARGEYSBCSZ) FROM V_CHARGE WHERE WATERUSERID IN (SELECT WATERUSERID FROM readMeterRecord WHERE 1=1" +
                   strFilter + ")";
                object objWaterUserSFZJ = BLLwaterUser.QuerySQLReturnOBJ(strSFZJ);
                if (Information.IsNumeric(objWaterUserSFZJ))
                    decSFZJ = Convert.ToDecimal(objWaterUserSFZJ);

                string strSFJE = "SELECT SUM(CHARGEBCSS) FROM V_CHARGE WHERE WATERUSERID IN (SELECT WATERUSERID FROM readMeterRecord WHERE 1=1" +
                   strFilter + ")";
                object objWaterUserSFJE = BLLwaterUser.QuerySQLReturnOBJ(strSFJE);
                if (Information.IsNumeric(objWaterUserSFJE))
                    decSFJE = Convert.ToDecimal(objWaterUserSFJE);

                string strYISHOU = "SELECT SUM(totalChargeend) FROM V_CHARGE WHERE WATERUSERID IN (SELECT WATERUSERID FROM readMeterRecord WHERE 1=1" +
                   strFilter + ")";
                object objYISHOU = BLLwaterUser.QuerySQLReturnOBJ(strYISHOU);
                if (Information.IsNumeric(objYISHOU))
                    decSJYISHOU = Convert.ToDecimal(objYISHOU);

                string strOverDue = "SELECT SUM(OVERDUEEND) FROM V_CHARGE WHERE WATERUSERID IN (SELECT WATERUSERID FROM readMeterRecord WHERE 1=1" +
                   strFilter + ")";
                object objOverDue = BLLwaterUser.QuerySQLReturnOBJ(strOverDue);
                if (Information.IsNumeric(objOverDue))
                    decOverDueMoney = Convert.ToDecimal(objOverDue);

                object objWaterUserYSCount = BLLwaterUser.QuerySQLReturnOBJ("SELECT COUNT(*) FROM V_YSDETAIL_BYWATERMETER WHERE  chargeState>'0' AND totalNumber>0 " + strFilter);
                if (Information.IsNumeric(objWaterUserYSCount))
                    intWaterUserYSCount = Convert.ToInt32(objWaterUserYSCount);


                //strFilter += " AND checkState='1' ORDER BY readMeterRecordYear,readMeterRecordMonth,areaNO,pianNO,duanNO,ordernumber";
                strFilter += " AND WATERMETERNUMBERCHANGESTATE='0' ORDER BY readMeterRecordYear,readMeterRecordMonth,areaNO,pianNO,duanNO,ordernumber";

                dtWaterMeterList = BLLreadMeterRecord.Query(strFilter);


                #region 绑定datagridview
                if (dtWaterMeterList.Rows.Count > 0)
                {
                    //dtClone = dtWaterMeterList.Clone();
                    //DataRow drLast = dtClone.NewRow();

                    //drLast["waterUserNO"] = "合计:";

                    ////计算用户数量
                    ////drLast["waterUserName"] = dtDistinctWaterUser.Rows.Count;

                    ////计算水表数量
                    //drLast["waterMeterNo"] = "共" + dtWaterMeterList.Rows.Count + "行";

                    DataTable dtWaterMeterListOld = dtWaterMeterList.Copy();

                    //统计用水量总计
                    object objSumWaterToltalNumber = dtWaterMeterListOld.Compute("SUM(totalNumber)", "");
                    if (Information.IsNumeric(objSumWaterToltalNumber))
                    {
                        //drLast["totalNumber"] = Convert.ToInt32(objSumWaterToltalNumber);
                        intWaterTotalNumber = Convert.ToInt32(objSumWaterToltalNumber);
                    }

                    //统计水费小计
                    object objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(waterTotalCharge)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                    {
                        //drLast["waterTotalChargeend"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");
                        decWaterTotalFee = Convert.ToDecimal(objSumWaterToltalChargeEnd);
                    }
                    //统计污水处理费
                    object objSumextraTotalCharge1 = dtWaterMeterListOld.Compute("SUM(extraCharge1)", "");
                    if (Information.IsNumeric(objSumextraTotalCharge1))
                    {
                        //drLast["extraTotalChargeend"] = Convert.ToDecimal(objSumextraTotalCharge1).ToString("F2");
                        decExtraCharge1 = Convert.ToDecimal(objSumextraTotalCharge1);
                    }
                    //统计附加费
                    object objSumextraTotalCharge2 = dtWaterMeterListOld.Compute("SUM(extraCharge2)", "");
                    if (Information.IsNumeric(objSumextraTotalCharge2))
                    {
                        //drLast["extraTotalChargeend"] = Convert.ToDecimal(objSumextraTotalCharge2).ToString("F2");
                        decExtraCharge2 = Convert.ToDecimal(objSumextraTotalCharge2);
                    }

                    labCount.Text = dtWaterMeterList.Rows.Count.ToString();
                    labYSCount.Text = intWaterUserYSCount.ToString();
                    labWaterTotalNumber.Text = intWaterTotalNumber.ToString();
                    labWaterTotalFee.Text = decWaterTotalFee.ToString("F2");
                    labExtraCharge1.Text = decExtraCharge1.ToString("F2");
                    labExtraCharge2.Text = decExtraCharge2.ToString("F2");
                    labYSXIAOJI.Text = decYSXIAOJI.ToString("F2");
                    labOverDueMoney.Text = decOverDueMoney.ToString("F2");
                    labYSZJ.Text = decYSZJ.ToString("F2");
                    labYISHOUJINE.Text = decSJYISHOU.ToString("F2");
                    labQFJE.Text = decSJQFJE.ToString("F2");
                    labYEZJ.Text = (decYCJE + decSFZJ).ToString("F2");
                    labSJJE.Text = (decSFJE + decYCJE).ToString("F2");
                    labYCYE.Text = decWaterUserPreStore.ToString("F2");
                    labYHYE.Text = (decWaterUserPreStore - decSJQFJE).ToString("F2");

                    dgList.DataSource = dtWaterMeterList;
                    //dtClone.Rows.Add(drLast);
                    //ucPageSetUp1.InitialUC(this.dgList, dtWaterMeterList, dtClone);

                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;
                }
                else
                {
                    dgList.DataSource = null;
                    toolPrint.Enabled = false;
                    toolPrintPreview.Enabled = false;
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
            if (dtWaterMeterList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtPrint = dtWaterMeterList.Copy();
            if (dtClone.Rows.Count > 0)
                dtPrint.ImportRow(dtClone.Rows[0]);
            dtPrint.TableName = "已抄水表明细查询";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\已抄水表明细查询.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("已抄水表明细查询").Enabled = true;
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
            DataTable dtPrint = dtWaterMeterList.Copy();
            if (dtClone.Rows.Count > 0)
                dtPrint.ImportRow(dtClone.Rows[0]);
            dtPrint.TableName = "已抄水表明细查询";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\已抄水表明细查询.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("已抄水表明细查询").Enabled = true;
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
            string curValue = e.Value == null ? "" : e.Value.ToString().Trim();
            string curValueID = dgList.Rows[e.RowIndex].Cells["waterUserId"].Value == null ? "" : dgList.Rows[e.RowIndex].Cells["waterUserId"].Value.ToString().Trim();
            //if (!string.IsNullOrEmpty(curValue))
            //{
            #region 获取下面的行数
            for (int i = e.RowIndex; i < dgList.Rows.Count; i++)
            {
                object objValue = dgList.Rows[i].Cells[e.ColumnIndex].Value;
                string strValue = objValue == null ? "" : objValue.ToString();
                if (strValue.Equals(curValue) && dgList.Rows[i].Cells["waterUserId"].Value.ToString().Equals(curValueID))
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
                object objValue = dgList.Rows[i].Cells[e.ColumnIndex].Value;
                string strValue = objValue == null ? "" : objValue.ToString();
                if (strValue.Equals(curValue) && dgList.Rows[i].Cells["waterUserId"].Value.ToString().Equals(curValueID))
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
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
            {
                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
        }
        #endregion

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "waterUserHouseType")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "楼房";
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "平房";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "agentsign")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "托收";
                        dgList.Columns["bankName"].Visible = true;
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "不托收";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "checkState")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "已审核";
                        dgList.Columns["checkDateTime"].Visible = true;
                        dgList.Columns["checker"].Visible = true;
                    }
                    else if (e.Value.ToString() == "0")
                        e.Value = "未审核";
            }
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
                    else if (e.Value.ToString() == "0")
                        e.Value = "未抄表";
            }
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "5";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
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

        private void txtPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
