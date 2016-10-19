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
    public partial class frmWaterUserSearchAll : DockContentEx
    {
        public frmWaterUserSearchAll()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLwaterUser BLLwaterUser = new BLLwaterUser();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();

        /// <summary>
        /// 用户号
        /// </summary>
        public string strWaterUserID = "";

        /// <summary>
        /// 用户号
        /// </summary>
        public string strWaterUserName = "";

        /// <summary>
        /// 地址
        /// </summary>
        public string strWaterUserAddress = "";

        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;

            dgList.Columns["readMeterRecordYearAndMonth"].DefaultCellStyle.Format = "yyyy-MM";

            txtWaterUserNOSearch.Text = strWaterUserID;
        }

        private void toolSearch_Click(object sender, EventArgs e)
        {
            if (txtWaterUserNOSearch.Text.Trim() == "")
            {
                mes.Show("请输入用户号、用户名或用户地址!");
                return;
            }
            LoadData();
        }

        //Thread TD;
        //private void RefreshData()
        //{
        //    try
        //    {
        //        TD = new Thread(showwaitfrm);
        //        TD.Start();
        //        //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
        //        Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
        //        LoadData();

        //        if (!waitfrm.IsDisposed)
        //        {
        //            waitfrm.Close();
        //        }
        //        //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Write("收费明细查询界面:" + ex.ToString(), MsgType.Error);
        //        //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
        //    }
        //}
        ////传递给线程的方法.
        //frmWaitSearch waitfrm = null;
        //private void showwaitfrm()
        //{
        //    try
        //    {
        //        waitfrm = new frmWaitSearch();
        //        waitfrm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Write("收费明细查询界面:" + ex.ToString(), MsgType.Error);
        //    }
        //}

        /// <summary>
        /// 存储查询到的水表列表
        /// </summary>
       public DataTable dtWaterMeterList = new DataTable();

        /// <summary>
        /// 存储统计行信息
        /// </summary>
       DataTable dtClone = new DataTable();

       /// <summary>
       /// 选择的用户编号
       /// </summary>
       public string strSelectWaterUser = "";
        private void LoadData()
        {
            try
            {
                //string strFilter = "";
                //if (txtWaterUserNOSearch.Text.Trim() != "")
                //{
                //    if (txtWaterUserNOSearch.Text.Length < 6)
                //    {
                //        strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                //        txtWaterUserNOSearch.Text = "U" + txtWaterUserNOSearch.Text.PadLeft(5, '0');
                //    }
                //    else
                //        strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
                //}

                string strSearch = txtWaterUserNOSearch.Text;
                string strFilterWaterUser = " AND (waterUserNO LIKE '%" + strSearch + "%' OR waterUserName LIKE '%" + strSearch +
                    "%' OR waterUserAddress LIKE '%" + strSearch + "%') ";

                #region 用户基础信息
                DataTable dtWaterUserMes = BLLwaterUser.QueryInitialWaterUser(strFilterWaterUser);
                if (dtWaterUserMes.Rows.Count > 0)
                {
                    if (dtWaterUserMes.Rows.Count > 1)
                    {
                        frmSingleChargeSelectWaterUser frm = new frmSingleChargeSelectWaterUser();
                        frm.dtWaterUserList = dtWaterUserMes;
                        frm.Owner = this;
                        frm.strFormType = "1";

                        if (frm.ShowDialog() == DialogResult.OK)
                        {

                        }
                        else
                        {
                            txtWaterUserNOSearch.Focus();
                            return;
                        }
                    }
                    else
                    {
                        object objWaterUserIDSingle = dtWaterUserMes.Rows[0]["WATERUSERID"];
                        if (objWaterUserIDSingle != null && objWaterUserIDSingle != DBNull.Value)
                        {
                            strSelectWaterUser = objWaterUserIDSingle.ToString();
                        }
                    }
                }
                else
                {
                    mes.Show("未找到符合条件的用户信息!");
                    return;
                }

                DataView dvUserList = dtWaterUserMes.DefaultView;
                dvUserList.RowFilter = "WATERUSERID='" + strSelectWaterUser + "'";
                dtWaterUserMes = dvUserList.ToTable();

                txtWaterUserNOSearch.Text = strSelectWaterUser;

                object objWaterUserMes = dtWaterUserMes.Rows[0]["waterUserName"];
                if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    strWaterUserName = objWaterUserMes.ToString();

                objWaterUserMes = dtWaterUserMes.Rows[0]["waterUserId"];
                if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    strWaterUserID = objWaterUserMes.ToString();

                objWaterUserMes = dtWaterUserMes.Rows[0]["waterUserAddress"];
                if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    strWaterUserAddress = objWaterUserMes.ToString();
                #endregion

                string strFilter = " AND WATERUSERID='"+strSelectWaterUser+"' ";

                if (chkHSL.Checked)
                    strFilter += " AND TOTALNUMBER>0 ";

                if (chkDateTime.Checked)
                    strFilter += " AND readMeterRecordYearAndMonth BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                string strSQL = "SELECT * FROM V_WATERUSERALLSEARCH WHERE 1=1 " + strFilter + " ORDER BY ORDERDATETIME,CHARGEID";
                dtWaterMeterList = BLLwaterUser.QuerySQL(strSQL);
                //交费户数，水量
                int intJFHS = 0, intTotalNumber = 0, intDJSL = 0;

                //水费，污水处理费，附加费，滞纳金，水费小计，水费总计，实交金额，预存增减，结算余额
                decimal decWaterTotalCharge = 0, decExcharge1 = 0, decExcharge2 = 0, decOverDue = 0,
                    decTotalCharge = 0, decTotalChargeEnd = 0, decYSJE = 0, decSJJE = 0,
                    decWaterUserPreStore = 0, decSJYISHOU = 0, decLJQF = 0;

                string strGetWaterUserPrestore = "SELECT SUM(prestore) AS PRESTORE,SUM(TOTALFEE) AS LJQF FROM V_WATERUSERAREARAGE " +
                    " WHERE WATERUSERID IN (SELECT WATERUSERID FROM V_WATERUSERALLSEARCH WHERE 1=1 " + strFilter + ")";
                DataTable dtWaterUser = BLLwaterUser.QuerySQL(strGetWaterUserPrestore);
                if (dtWaterUser.Rows.Count > 0)
                {
                    object objWaterUserPrestore = dtWaterUser.Rows[0]["PRESTORE"];
                    if (Information.IsNumeric(objWaterUserPrestore))
                        decWaterUserPreStore = Convert.ToDecimal(objWaterUserPrestore);

                    object objLJQF = dtWaterUser.Rows[0]["LJQF"];
                    if (Information.IsNumeric(objLJQF))
                        decLJQF = Convert.ToDecimal(objLJQF);
                }
                labeLJQF.Text = decLJQF.ToString("F2");
                labYHYE.Text = decWaterUserPreStore.ToString("F2");
                labJSYE.Text = (decWaterUserPreStore - decLJQF).ToString("F2");


                //DataTable dtWaterUserCount = BLLwaterUser.QuerySQL("SELECT DISTINCT waterUserId FROM V_WATERFEEANDPRESTORECHARGE WHERE 1=1 " + strFilter);

                ////DataView dv = dtWaterMeterList.DefaultView;
                ////DataTable dtDistinctWaterUser = dv.ToTable(true, "waterUserId");
                //intJFHS = dtWaterUserCount.Rows.Count;

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;
                    toolExportToExl.Enabled = true;

                    dtClone = dtWaterMeterList.Clone();
                    DataRow drLast = dtClone.NewRow();

                    drLast["waterUserName"] = "合计:";

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
                        decExcharge1 = Convert.ToDecimal(objSumextraTotalCharge1);
                    }

                    object objSumextraTotalCharge2 = dtWaterMeterList.Compute("SUM(extraCharge2)", "");
                    if (Information.IsNumeric(objSumextraTotalCharge2))
                    {
                        drLast["extraCharge2"] = Convert.ToDecimal(objSumextraTotalCharge2).ToString("F2");
                        decExcharge2 = Convert.ToDecimal(objSumextraTotalCharge2);
                    }


                    object objSumOVERDUEEND = dtWaterMeterList.Compute("SUM(OVERDUEMONEY)", "");
                    if (Information.IsNumeric(objSumOVERDUEEND))
                    {
                        drLast["OVERDUEMONEY"] = Convert.ToDecimal(objSumOVERDUEEND).ToString("F2");
                        decOverDue = Convert.ToDecimal(objSumOVERDUEEND);
                    }

                    object objSumtotalCharge = dtWaterMeterList.Compute("SUM(totalCharge)", "");
                    if (Information.IsNumeric(objSumtotalCharge))
                    {
                        drLast["totalCharge"] = Convert.ToDecimal(objSumtotalCharge).ToString("F2");
                        decTotalCharge = Convert.ToDecimal(objSumtotalCharge);
                    }

                    //object objSumtotalChargeEND = dtWaterMeterList.Compute("SUM(totalChargeEND)", "");
                    //if (Information.IsNumeric(objSumtotalChargeEND))
                    //{
                    //    drLast["totalChargeEND"] = Convert.ToDecimal(objSumtotalChargeEND).ToString("F2");
                    //    decTotalChargeEnd = Convert.ToDecimal(objSumtotalChargeEND);
                    //}

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
                    #endregion
                    dgList.DataSource = dtWaterMeterList;
                    //dgList.DataSource = dtWaterMeterList;
                }
                else
                {
                    dgList.DataSource = null;

                    toolPrint.Enabled = false;
                    toolPrintPreview.Enabled = false;
                    toolExportToExl.Enabled = false;
                }

                labWaterTotalNumber.Text = intTotalNumber.ToString();
                labWaterTotalFee.Text = decWaterTotalCharge.ToString("F2");
                labExtraCharge1.Text = decExcharge1.ToString("F2");
                labExtraCharge2.Text = decExcharge2.ToString("F2");
                labSFXiaoJi.Text = decTotalCharge.ToString("F2");
                labOverDue.Text = decOverDue.ToString("F2");

                labYSHJ.Text = (decTotalCharge + decOverDue).ToString("F2");
                labSJJE.Text = decSJJE.ToString("F2");
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
            dtPrint.TableName = "收费明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\一户式查询打印.frx");
                (report1.FindObject("txtWaterUserNO") as FastReport.TextObject).Text = "用户号:" + strWaterUserID;
                (report1.FindObject("txtWaterUserName") as FastReport.TextObject).Text = "用户名:" + strWaterUserName;
                (report1.FindObject("txtWaterUserAddress") as FastReport.TextObject).Text = "地  址:" + strWaterUserAddress;
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
            DataTable dtPrint = GetDgvToTable(dgList);
            dtPrint.TableName = "收费明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\一户式查询打印.frx");
                (report1.FindObject("txtWaterUserNO") as FastReport.TextObject).Text ="用户号:"+ strWaterUserID;
                (report1.FindObject("txtWaterUserName") as FastReport.TextObject).Text = "用户名:" + strWaterUserName;
                (report1.FindObject("txtWaterUserAddress") as FastReport.TextObject).Text = "地  址:" + strWaterUserAddress;
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
            if (dgList.Columns[e.ColumnIndex].Name == "chargeState")
            {
                object obj = e.Value;
                if (obj != null && obj != DBNull.Value)
                {
                    if (obj.ToString() == "0")
                        e.Value = "未抄表";
                    else if (obj.ToString() == "1")
                        e.Value = "已抄表";
                    else if (obj.ToString() == "2")
                        e.Value = "已预收";
                    else if (e.Value.ToString() == "3")
                        e.Value = "已收费";
                }
            }
            if (dgList.Columns[e.ColumnIndex].Name == "checkState")
            {
                object obj = e.Value;
                if (obj != null && obj != DBNull.Value)
                {
                    if (obj.ToString() == "0")
                        e.Value = "未审核";
                    else if (obj.ToString() == "1")
                        e.Value = "已审核";
                }
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
            if (dgList.Columns[e.ColumnIndex].Name == "IsReverse")
            {
                object obj = e.Value;
                if (obj != null && obj != DBNull.Value)
                {
                    if (obj.ToString() == "0")
                        e.Value = "否";
                    else if (obj.ToString() == "1")
                        e.Value = "是";
                }
            }
            if (dgList.Columns[e.ColumnIndex].Name == "isSummaryMeter")
            {
                object obj = e.Value;
                if (obj != null && obj != DBNull.Value)
                {
                    if (obj.ToString() == "1")
                        e.Value = "分表";
                    else if (obj.ToString() == "2")
                        e.Value = "总表";
                }
            }
        }
        private void dgList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgList.Rows[dgList.Rows.Count - 1].Cells["waterUserName"].Value = "合计:";

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


            object objSumOVERDUEEND = dtWaterMeterList.Compute("SUM(OVERDUEMONEY)", "");
            if (Information.IsNumeric(objSumOVERDUEEND))
            {
                dgList.Rows[dgList.Rows.Count - 1].Cells["OVERDUEMONEY"].Value = Convert.ToDecimal(objSumOVERDUEEND).ToString("F2");
            }

            object objSumtotalCharge = dtWaterMeterList.Compute("SUM(totalCharge)", "");
            if (Information.IsNumeric(objSumtotalCharge))
            {
                dgList.Rows[dgList.Rows.Count - 1].Cells["totalCharge"].Value = Convert.ToDecimal(objSumtotalCharge).ToString("F2");
            }

            object objSumYStotalCharge = dtWaterMeterList.Compute("SUM(ystotal)", "");
            if (Information.IsNumeric(objSumYStotalCharge))
            {
                dgList.Rows[dgList.Rows.Count - 1].Cells["ystotal"].Value = Convert.ToDecimal(objSumYStotalCharge).ToString("F2");
            }

            //object objSumtotalChargeEND = dtWaterMeterList.Compute("SUM(totalChargeEND)", "");
            //if (Information.IsNumeric(objSumtotalChargeEND))
            //{
            //    dgList.Rows[dgList.Rows.Count - 1].Cells["totalChargeEND"].Value = Convert.ToDecimal(objSumtotalChargeEND).ToString("F2");
            //}

            #region 合计收费明细

            object objSumChargeBCYS = dtWaterMeterList.Compute("SUM(CHARGEBCYS)", "");
            if (Information.IsNumeric(objSumChargeBCYS))
            {
                dgList.Rows[dgList.Rows.Count - 1].Cells["CHARGEBCYS"].Value = Convert.ToDecimal(objSumChargeBCYS).ToString("F2");
            }

            object objSumChargeBCSS = dtWaterMeterList.Compute("SUM(CHARGEBCSS)", "");
            if (Information.IsNumeric(objSumChargeBCSS))
            {
                dgList.Rows[dgList.Rows.Count - 1].Cells["CHARGEBCSS"].Value = Convert.ToDecimal(objSumChargeBCSS).ToString("F2");
            }

            object objSumChargeYSBCSZ = dtWaterMeterList.Compute("SUM(CHARGEYSBCSZ)", "");
            if (Information.IsNumeric(objSumChargeYSBCSZ))
            {
                dgList.Rows[dgList.Rows.Count - 1].Cells["CHARGEYSBCSZ"].Value = Convert.ToDecimal(objSumChargeYSBCSZ).ToString("F2");
            }
            #endregion
        }

        private void 今天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();

            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day,0,0,0);
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
            DateTime dtMonthStart = new DateTime(dtNow.Year,1, 1);
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

            DateTime dtMonthEnd = new DateTime(3000, 1,1, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void btSetMonth_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btSetMonth,0,btSetMonth.Width+1);
        }

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtWaterUserNOSearch.Text.Trim() != "")
                    toolSearch_Click(null, null);
            }
        }

        private void toolExportToExl_Click(object sender, EventArgs e)
        {
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel("一户式台账明细查询", dgList);
        }
       
    }
}
