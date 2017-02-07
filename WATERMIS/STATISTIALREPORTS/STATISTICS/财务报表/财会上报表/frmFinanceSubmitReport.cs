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
    public partial class frmFinanceSubmitReport : DockContentEx
    {
        public frmFinanceSubmitReport()
        {
            InitializeComponent();
        }

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLACCOUNTSRUNNING BLLACCOUNTSRUNNING = new BLLACCOUNTSRUNNING();

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";        

        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart=new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtpEnd.Value = dtMonthEnd;
        }
        private void toolSearch_Click(object sender, EventArgs e)
        {
            dtpStartSearch.Value = dtpStart.Value;
            dtpEndSearch.Value = dtpEnd.Value;
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
                log.Write("实收统计界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("实收统计界面:" + ex.ToString(), MsgType.Error);
            }
        }

        private void LoadData()
        {
            DataTable dtWaterMeterList = new DataTable();

            decimal decBusinessMoneyLast = 0, decFinanceMoneyLast = 0,
                decBYYSMoney = 0, decBYYSWaterFee = 0, decBYYSExtraCharge1 = 0, decBYYSExtraCharge2 = 0,
                decBYSSMoney = 0, decBYSSXJMoney = 0, decBYSSWaterFee = 0, decBYSSExtraCharge1 = 0, decBYSSExtraCharge2 = 0,
                decYCZJ = 0, decOverDueMoney = 0, decBYSSMoneySum = 0,
                decBusinessMoneyBY = 0, decFinanceMoneyBY = 0,
                decBYYSMoneyRZ = 0, decBYYSWaterFeeRZ = 0, decBYYSExtraCharge1RZ = 0, decBYYSExtraCharge2RZ = 0;

            try
            {
                #region 应收金额
                string strFilter = "";
                if (chkChargeDateTime.Checked)
                    strFilter += " AND readMeterRecordYearAndMonth BETWEEN '" + new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1) + "' AND '" + new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, 1, 23, 59, 59).AddMonths(1).AddDays(-1) + "'";
                string strStatisticsContent = "SELECT " +
                                "SUM(waterTotalChargeEND) AS 水费,SUM(extraCharge1) AS 污水处理费," +
                                "SUM(extraCharge2) AS 附加费,SUM(totalCharge) AS 应收小计 " +
                    "FROM V_YSACCOUNTS_READMETERRECORD_CONTAINOVERDUE WHERE 1=1 " + strFilter;

                dtWaterMeterList = BLLWATERFEECHARGE.QueryBySQL(strStatisticsContent);

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    object obj = dtWaterMeterList.Rows[0]["水费"];
                    if (Information.IsNumeric(obj))
                        decBYYSWaterFee = Convert.ToDecimal(obj);
                    obj = dtWaterMeterList.Rows[0]["污水处理费"];
                    if (Information.IsNumeric(obj))
                        decBYYSExtraCharge1 = Convert.ToDecimal(obj);
                    obj = dtWaterMeterList.Rows[0]["附加费"];
                    if (Information.IsNumeric(obj))
                        decBYYSExtraCharge2 = Convert.ToDecimal(obj);

                    decBYYSMoney = decBYYSWaterFee + decBYYSExtraCharge1 + decBYYSExtraCharge2;
                }
                #endregion
                #region 实收金额
                strFilter = "";
                if (chkChargeDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                strStatisticsContent = "SELECT " +
                                 "SUM(waterTotalCharge) AS 水费,SUM(extraCharge1) AS 污水处理费," +
                                 "SUM(extraCharge2) AS 附加费,SUM(totalCharge) AS 实收水费小计," +
                                 "SUM(OVERDUEEND) AS 滞纳金, SUM(totalChargeEND) AS 实收水费总计," +
                                 "SUM(CHARGEYSBCSZ) AS 预存增减,SUM(CHARGEBCSS) AS 实收金额总计 " +
                     "FROM (SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE 1=1 " + strFilter + ") AS AA ";

                dtWaterMeterList = BLLWATERFEECHARGE.QueryBySQL(strStatisticsContent);

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    object obj = dtWaterMeterList.Rows[0]["水费"];
                    if (Information.IsNumeric(obj))
                        decBYSSWaterFee = Convert.ToDecimal(obj);
                    obj = dtWaterMeterList.Rows[0]["污水处理费"];
                    if (Information.IsNumeric(obj))
                        decBYSSExtraCharge1 = Convert.ToDecimal(obj);
                    obj = dtWaterMeterList.Rows[0]["附加费"];
                    if (Information.IsNumeric(obj))
                        decBYSSExtraCharge2 = Convert.ToDecimal(obj);
                    obj = dtWaterMeterList.Rows[0]["预存增减"];
                    if (Information.IsNumeric(obj))
                        decYCZJ = Convert.ToDecimal(obj);
                    obj = dtWaterMeterList.Rows[0]["滞纳金"];
                    if (Information.IsNumeric(obj))
                        decOverDueMoney = Convert.ToDecimal(obj);
                    obj = dtWaterMeterList.Rows[0]["实收金额总计"];
                    if (Information.IsNumeric(obj))
                        decBYSSMoneySum = Convert.ToDecimal(obj);

                    decBYSSMoney = decBYSSWaterFee + decBYSSExtraCharge1 + decBYSSExtraCharge2 + decYCZJ;
                    decBYSSXJMoney = decBYSSWaterFee + decBYSSExtraCharge1 + decBYSSExtraCharge2;
                }
                #endregion

                #region 应收入账金额
                decBYYSMoneyRZ = decBYYSMoney - decBYSSXJMoney;
                decBYYSWaterFeeRZ = decBYYSWaterFee - decBYSSWaterFee;
                decBYYSExtraCharge1RZ = decBYYSExtraCharge1 - decBYSSExtraCharge1;
                decBYYSExtraCharge2RZ = decBYYSExtraCharge2 - decBYSSExtraCharge2;
                #endregion
                
                #region 营业及财务余额
                DataTable dtAccount = BLLACCOUNTSRUNNING.Query(" AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpEnd.Value + "')=0");
                if (dtAccount.Rows.Count > 0)
                {
                    object objMoney = dtAccount.Rows[0]["BUSINESSMONEYLAST"];
                    if (Information.IsNumeric(objMoney))
                    {
                        decBusinessMoneyLast = Convert.ToDecimal(objMoney);
                    }
                    objMoney = dtAccount.Rows[0]["FINANCEMONEYLAST"];
                    if (Information.IsNumeric(objMoney))
                    {
                        decFinanceMoneyLast = Convert.ToDecimal(objMoney);
                    }
                }
                decBusinessMoneyBY = decBusinessMoneyLast - decBYYSMoney + decBYSSMoney;
                decFinanceMoneyBY = decFinanceMoneyLast + decYCZJ;
                #endregion

                label22.Text = decBusinessMoneyLast.ToString("F2");
                label23.Text = decFinanceMoneyLast.ToString("F2");
                label24.Text = decBYYSMoney.ToString("F2");
                label25.Text = decBYYSWaterFee.ToString("F2");
                label26.Text = decBYYSExtraCharge1.ToString("F2");
                label27.Text = decBYYSExtraCharge2.ToString("F2");
                label28.Text = decBYSSMoney.ToString("F2");
                label29.Text = decBYSSXJMoney.ToString("F2");
                label30.Text = decBYSSWaterFee.ToString("F2");
                label31.Text = decBYSSExtraCharge1.ToString("F2");
                label32.Text = decBYSSExtraCharge2.ToString("F2");
                label33.Text = decYCZJ.ToString("F2");
                label34.Text = decOverDueMoney.ToString("F2");
                label35.Text = decBYSSMoneySum.ToString("F2");
                label36.Text = decBusinessMoneyBY.ToString("F2");
                label37.Text = decBYYSMoneyRZ.ToString("F2");
                label38.Text = decBYYSWaterFeeRZ.ToString("F2");
                label39.Text = decBYYSExtraCharge1RZ.ToString("F2");
                label40.Text = decBYYSExtraCharge2RZ.ToString("F2");
                label41.Text = decFinanceMoneyBY.ToString("F2");
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        public int GetMonth(DateTime dtSart, DateTime dtEnd)
        {
            int Month = 0;
            if ((dtEnd.Year - dtSart.Year) == 0)
            {
                Month = dtEnd.Month - dtSart.Month;
            }
            if ((dtEnd.Year - dtSart.Year) >= 1)
            {
                if (dtEnd.Month - dtSart.Month < 0)
                {
                    Month = (dtEnd.Year - dtSart.Year - 1) * 12 + (12 - dtSart.Month) + dtEnd.Month + 1;
                }
                else
                {
                    Month = (dtEnd.Year - dtSart.Year) * 12 + dtEnd.Month - dtSart.Month + 1;
                }
            }
            return Month;
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
