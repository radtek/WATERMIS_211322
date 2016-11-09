using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using MODEL;
using BLL;
using BASEFUNCTION;
using System.Runtime.InteropServices;

namespace SYSMANAGE
{
    public partial class frmWaterMeterChargedStaticsJieZhang : DockContentEx
    {
        public frmWaterMeterChargedStaticsJieZhang()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }
        #region 记事本API
        /// <summary>
        /// 传递消息给记事本
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        /// <summary>
        /// 查找句柄
        /// </summary>
        /// <param name="hwndParent"></param>
        /// <param name="hwndChildAfter"></param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindow"></param>
        /// <returns></returns>
        [DllImport("User32.DLL")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        /// <summary>
        /// 记事本需要的常量
        /// </summary>
        public const uint WM_SETTEXT = 0x000C;
        #endregion

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        GETTABLEID GETTABLEID = new GETTABLEID();
        BLLSETTLEACCOUNTSS BLLSETTLEACCOUNTSS = new BLLSETTLEACCOUNTSS();
        BLLSETTLEACCOUNTYS BLLSETTLEACCOUNTYS = new BLLSETTLEACCOUNTYS();

        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();

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
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;
        }
        private void toolSearch_Click(object sender, EventArgs e)
        {
            dgListDangQi.DataSource = null;
            dtpDateTimeSearch.Value = dtpStart.Value;
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

        /// <summary>
        /// 存储查询到的列表
        /// </summary>
        DataTable dtWaterMeterListDangQi = new DataTable();
        DataTable dtWaterMeterListChenQian = new DataTable();
        DataTable dtWaterMeterListYingShou = new DataTable();

        /// <summary>
        /// 存储统计行信息
        /// </summary>
        DataTable dtClone = new DataTable();

        /// <summary>
        /// 查询条件
        /// </summary>
        string strFilter = "";
        private void LoadData()
        {
            try
            {
                string strStatisticsDangQi = "", strStatisticsChenQian = "", strStatisticsYingShou = "";
                strFilter = "";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpStart.Text + "'";

                //strStatisticsDangQi = "SELECT WATERMETERTYPECLASSID AS 分类编号,WATERMETERTYPECLASSNAME AS 分类名称,waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质" +
                strStatisticsDangQi = "SELECT WATERMETERTYPECLASSID AS 分类编号,WATERMETERTYPECLASSNAME AS 分类名称" +
                        ",COUNT(*) AS 单据数,COUNT(DISTINCT INVOICENO) AS 发票数量,COUNT(DISTINCT RECEIPTNO) AS 收据数量,SUM(totalNumber) AS 用水量," +
                        "SUM(waterTotalCharge) AS 水费,SUM(extraCharge1) AS 污水处理费," +
                        "SUM(extraCharge2) AS 附加费,SUM(totalCharge) AS 实收水费小计," +
                        "SUM(OVERDUEEND) AS 滞纳金, SUM(totalChargeEND) AS 实收水费总计," +
                        "SUM(CHARGEYSBCSZ) AS 预存增减,SUM(CHARGEBCSS) AS 实收金额总计 " +
                        "FROM (SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE DATEDIFF(MONTH,CHARGEDATETIME,'" + dtpStart.Value + "')=0" +
                        " AND DATEDIFF(MONTH,CHARGEDATETIME,readMeterRecordYearAndMonth)=0) AS AA" +
                    //" GROUP BY WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,waterMeterTypeId,waterMeterTypeName ";
                " GROUP BY WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME ";

                //strStatisticsChenQian = "SELECT WATERMETERTYPECLASSID AS 分类编号,WATERMETERTYPECLASSNAME AS 分类名称,waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质" +
                strStatisticsChenQian = "SELECT WATERMETERTYPECLASSID AS 分类编号,WATERMETERTYPECLASSNAME AS 分类名称" +
                    ",COUNT(*) AS 单据数,COUNT(DISTINCT INVOICENO) AS 发票数量,COUNT(DISTINCT RECEIPTNO) AS 收据数量,SUM(totalNumber) AS 用水量," +
                                "SUM(waterTotalCharge) AS 水费,SUM(extraCharge1) AS 污水处理费," +
                                "SUM(extraCharge2) AS 附加费,SUM(totalCharge) AS 实收水费小计," +
                                "SUM(OVERDUEEND) AS 滞纳金, SUM(totalChargeEND) AS 实收水费总计," +
                                "SUM(CHARGEYSBCSZ) AS 预存增减,SUM(CHARGEBCSS) AS 实收金额总计 " +
                    "FROM (SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE DATEDIFF(MONTH,CHARGEDATETIME,'" + dtpStart.Value + "')=0" +
                    " AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,CHARGEDATETIME)>0) AS AA" +
                    //" GROUP BY WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,waterMeterTypeId,waterMeterTypeName ";
                " GROUP BY WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME ";

                //strStatisticsYingShou = "SELECT WATERMETERTYPECLASSID AS 分类编号,WATERMETERTYPECLASSNAME AS 分类名称,waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质" +
                strStatisticsYingShou = "SELECT WATERMETERTYPECLASSID AS 分类编号,WATERMETERTYPECLASSNAME AS 分类名称" +
                    ",COUNT(DISTINCT WATERUSERID) AS 总户数," +
                    "SUM(CASE WHEN chargeState<>'0' AND checkState='1' AND totalNumber>0  THEN 1 ELSE 0 END) AS 用水户数," +
                    "0.00 AS 账户余额,0.00 AS 累计欠费,0.00 AS 结算余额,SUM(totalNumber) AS 用水量," +
                                "SUM(waterTotalChargeEND) AS 水费,SUM(extraCharge1) AS 污水处理费," +
                                "SUM(extraCharge2) AS 附加费,SUM(totalCharge) AS 应收小计," +
                    "SUM(OVERDUEEND) AS 滞纳金, SUM(totalCharge+OVERDUEEND) AS 应收总计, " +
                    "SUM(CASE WHEN chargeState='3' THEN 0 ELSE totalCharge END) AS 未收总计,SUM(CASE WHEN chargeState='3' THEN totalCharge+OVERDUEEND ELSE 0 END) AS 已收总计 " +
                    "FROM (SELECT * FROM V_YSACCOUNTS_READMETERRECORD_CONTAINOVERDUE WHERE DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtpStart.Value + "')=0) AS AA" +
                    //" GROUP BY WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,waterMeterTypeId,waterMeterTypeName ";
                " GROUP BY WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME ";

                dtWaterMeterListDangQi = BLLWATERFEECHARGE.QueryBySQL(strStatisticsDangQi);
                dgListDangQi.DataSource = dtWaterMeterListDangQi;

                dtWaterMeterListChenQian = BLLWATERFEECHARGE.QueryBySQL(strStatisticsChenQian);
                dgListChenQian.DataSource = dtWaterMeterListChenQian;

                dtWaterMeterListYingShou = BLLWATERFEECHARGE.QueryBySQL(strStatisticsYingShou);
                #region 填充用户余额
                for (int j = 0; j < dtWaterMeterListYingShou.Rows.Count; j++)
                {
                    string strFilterTJ = "";
                    object objYSFilter = dtWaterMeterListYingShou.Rows[j]["分类编号"];
                    if (objYSFilter != null && objYSFilter != DBNull.Value)
                        strFilterTJ += " AND WATERMETERTYPECLASSID='" + objYSFilter.ToString() + "'";

                    //object objYSFilter = dtWaterMeterListYingShou.Rows[j]["用水性质编号"];
                    //if (objYSFilter != null && objYSFilter != DBNull.Value)
                    //    strFilterTJ += " AND waterMeterTypeId='" + objYSFilter.ToString() + "'";

                    decimal deLJQF = 0, decPrestore = 0;
                    DataTable dtYSLeiJI = BLLWATERFEECHARGE.QueryBySQL("SELECT SUM(CASE WHEN chargeState='3' THEN 0 ELSE  totalCharge END) AS YSQIANFEI " +
                        " FROM V_YSDETAIL_BYWATERMETER WHERE WATERUSERID IN (SELECT WATERUSERID FROM readMeterRecord WHERE DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtpStart.Value + "')=0 "
                        + strFilterTJ + ")");
                    if (dtYSLeiJI.Rows.Count > 0)
                    {
                        object obj = dtYSLeiJI.Rows[0]["YSQIANFEI"];
                        if (Information.IsNumeric(obj))
                            deLJQF = Convert.ToDecimal(obj);
                    }
                    dtWaterMeterListYingShou.Rows[j]["累计欠费"] = deLJQF;

                    DataTable dtSumRow = BLLWATERFEECHARGE.QueryBySQL("SELECT SUM(prestore) AS 账户余额 FROM WATERUSER WHERE WATERUSERID IN" +
                        "(SELECT WATERUSERID FROM readMeterRecord WHERE DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtpStart.Value + "')=0 " + strFilterTJ + ")");
                    if (dtSumRow.Rows.Count > 0)
                    {
                        object objSumRow = dtSumRow.Rows[0]["账户余额"];
                        if (Information.IsNumeric(objSumRow))
                        {
                            dtWaterMeterListYingShou.Rows[j]["账户余额"] = objSumRow;
                            decPrestore = Convert.ToDecimal(objSumRow);
                        }
                    }
                    dtWaterMeterListYingShou.Rows[j]["结算余额"] = decPrestore - deLJQF;
                }
                #endregion
                dgListYingShou.DataSource = dtWaterMeterListYingShou;
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
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

        private void dgListYingShou_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region 合计行
            //DataRow dr = dtWaterMeterList.NewRow();

            object obj = dtWaterMeterListYingShou.Compute("SUM(总户数)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["总户数"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(用水户数)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["用水户数"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(账户余额)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["账户余额"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(累计欠费)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["累计欠费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(结算余额)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["结算余额"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(用水量)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["用水量"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(水费)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["水费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(污水处理费)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["污水处理费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(附加费)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["附加费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(应收小计)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["应收小计"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(滞纳金)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["滞纳金"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(应收总计)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["应收总计"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(未收总计)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["未收总计"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(已收总计)", "");
            if (Information.IsNumeric(obj))
                dgListYingShou.Rows[dgListYingShou.Rows.Count - 1].Cells["已收总计"].Value = Convert.ToDecimal(obj);
            #endregion
        }

        private void toolSaveAccounts_Click(object sender, EventArgs e)
        {
            #region 检测是否有未审核、未结算或未生台账信息
            try
            {
                string strWarningString = "";//存储提醒有未审核和未结算的提示

                string strFilter = " AND CHECKSTATE='0' AND CHARGESTATE='1' AND totalCharge<>0 ";
                DataTable dtUnchecked = BLLreadMeterRecord.Query(strFilter);
                if (dtUnchecked.Rows.Count > 0)
                {
                    strWarningString = "==================未审核信息:==================";
                    for (int i = 0; i < dtUnchecked.Rows.Count; i++)
                    {
                        strWarningString += "\r\n";

                        object obj = dtUnchecked.Rows[i]["readMeterRecordYearAndMonth"];
                        if (Information.IsDate(obj))
                        {
                            strWarningString += "月份:" + Convert.ToDateTime(obj).ToString("yyyy-MM");
                        }
                        obj = dtUnchecked.Rows[i]["waterUserId"];
                        if (obj != null && obj != DBNull.Value)
                        {
                            if (strWarningString.Trim() != "")
                                strWarningString += ",用户号:" + obj.ToString();
                            else
                                strWarningString = "用户号:" + obj.ToString();
                        }
                        obj = dtUnchecked.Rows[i]["totalCharge"];
                        if (Information.IsNumeric(obj))
                        {
                            if (strWarningString.Trim() != "")
                                strWarningString += ",水费:" + Convert.ToDecimal(obj).ToString("F2");
                            else
                                strWarningString = "水费:" + Convert.ToDecimal(obj).ToString("F2");
                        }
                    }
                }

                strFilter = " AND TOTALFEE>0 AND USERAREARAGE>=0 ";
                DataTable dtUnJieSuan = BLLwaterUser.QueryUserPrestore(strFilter);
                if (dtUnJieSuan.Rows.Count > 0)
                {
                    if (strWarningString.Trim() != "")
                        strWarningString += "\r\n==================未结算信息:==================";
                    else
                        strWarningString = "==================未结算信息:==================";

                    for (int i = 0; i < dtUnJieSuan.Rows.Count; i++)
                    {
                        strWarningString += "\r\n";

                        object obj = dtUnJieSuan.Rows[i]["waterUserId"];
                        if (obj != null && obj != DBNull.Value)
                        {
                            if (strWarningString.Trim() != "")
                                strWarningString += "用户号:" + obj.ToString();
                            else
                                strWarningString = "用户号:" + obj.ToString();
                        }
                        obj = dtUnJieSuan.Rows[i]["TOTALFEE"];
                        if (Information.IsNumeric(obj))
                        {
                            if (strWarningString.Trim() != "")
                                strWarningString += ",未结水费:" + Convert.ToDecimal(obj).ToString("F2");
                            else
                                strWarningString = "未结水费:" + Convert.ToDecimal(obj).ToString("F2");
                        }
                    }
                }

                string strSQL = "SELECT * FROM WATERUSER WHERE prestore<>0 AND WATERUSERID NOT IN (SELECT WATERUSERID FROM readMeterRecord WHERE DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtpDateTimeSearch.Value.ToShortDateString() + "')=0)";
                DataTable dtUnInitial = BLLwaterUser.QuerySQL(strSQL);
                if (dtUnInitial.Rows.Count > 0)
                {
                    if (strWarningString.Trim() != "")
                        strWarningString += "\r\n============有余额但未生成台账用户:=============";
                    else
                        strWarningString = "============有余额但未生成台账用户:=============";

                    for (int i = 0; i < dtUnInitial.Rows.Count; i++)
                    {
                        strWarningString += "\r\n";

                        object obj = dtUnInitial.Rows[i]["waterUserId"];
                        if (obj != null && obj != DBNull.Value)
                        {
                            if (strWarningString.Trim() != "")
                                strWarningString += "用户号:" + obj.ToString();
                            else
                                strWarningString = "用户号:" + obj.ToString();
                        }
                        obj = dtUnInitial.Rows[i]["waterUserCreateDate"];
                        if (Information.IsDate(obj))
                        {
                            if (strWarningString.Trim() != "")
                                strWarningString += ",建档时间:" + Convert.ToDateTime(obj).ToString("yyyy-MM-dd HH:mm:ss");
                            else
                                strWarningString = "建档时间:" + Convert.ToDateTime(obj).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }
                }

                strSQL = "SELECT * FROM readMeterRecord WHERE waterTotalCharge+extraCharge1+extraCharge2<>totalCharge";
                DataTable dtTotalProblem = BLLwaterUser.QuerySQL(strSQL);
                if (dtTotalProblem.Rows.Count > 0)
                {
                    if (strWarningString.Trim() != "")
                        strWarningString += "\r\n============总金额与费用明细之和不等的用户:=============";
                    else
                        strWarningString = "============总金额与费用明细之和不等的用户:=============";

                    for (int i = 0; i < dtTotalProblem.Rows.Count; i++)
                    {
                        strWarningString += "\r\n";

                        object obj = dtTotalProblem.Rows[i]["waterUserId"];
                        if (obj != null && obj != DBNull.Value)
                        {
                            if (strWarningString.Trim() != "")
                                strWarningString += "用户号:" + obj.ToString();
                            else
                                strWarningString = "用户号:" + obj.ToString();
                        }
                        obj = dtTotalProblem.Rows[i]["readMeterRecordYearAndMonth"];
                        if (Information.IsDate(obj))
                        {
                            if (strWarningString.Trim() != "")
                                strWarningString += ",水费月份:" + Convert.ToDateTime(obj).ToString("yyyy-MM");
                            else
                                strWarningString = "水费月份:" + Convert.ToDateTime(obj).ToString("yyyy-MM");
                        }
                    }
                }
                if (strWarningString.Trim() != "")
                {
                    mes.Show("存在异常信息，点击确定按钮查看详情!");
                    System.Diagnostics.Process Proc;

                    try
                    {
                        // 启动记事本
                        Proc = new System.Diagnostics.Process();
                        Proc.StartInfo.FileName = "notepad.exe";
                        Proc.StartInfo.UseShellExecute = false;
                        Proc.StartInfo.RedirectStandardInput = true;
                        Proc.StartInfo.RedirectStandardOutput = true;

                        Proc.Start();
                    }
                    catch
                    {
                        Proc = null;
                    }

                    if (Proc != null)
                    {
                        // 调用 API, 传递数据
                        while (Proc.MainWindowHandle == IntPtr.Zero)
                        {
                            Proc.Refresh();
                        }
                        IntPtr vHandle = FindWindowEx(Proc.MainWindowHandle, IntPtr.Zero, "Edit", null);

                        // 传递数据给记事本
                        SendMessage(vHandle, WM_SETTEXT, 0, strWarningString);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show("获取异常信息失败,原因:" + ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
            #endregion

            #region 检测本月是否已经月结
            try
            {
                string strYueJieSign = "0";
                string strFilter = " AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpDateTimeSearch.Value.ToString("yyyy-MM-dd") + "')=0";
                DataTable dtYueJieSS = BLLSETTLEACCOUNTSS.Query(strFilter);
                if (dtYueJieSS.Rows.Count > 0)
                    strYueJieSign = "1";

                strFilter = " AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpDateTimeSearch.Value.ToString("yyyy-MM-dd") + "')=0";
                DataTable dtYueJieYS = BLLSETTLEACCOUNTYS.Query(strFilter);
                if (dtYueJieYS.Rows.Count > 0)
                    strYueJieSign = "2";
                if (strYueJieSign != "0")
                    if (mes.ShowQ("存在已经结账数据,确定要重新将本月收费数据结账吗?") == DialogResult.OK)
                    {
                        string strDeleteYS = "DELETE FROM SETTLEACCOUNTYS WHERE DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpDateTimeSearch.Value.ToString("yyyy-MM-dd") + "')=0";
                        BLLSETTLEACCOUNTYS.ExcuteSQL(strDeleteYS);

                        string strDeleteSS = "DELETE FROM SETTLEACCOUNTSS WHERE DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpDateTimeSearch.Value.ToString("yyyy-MM-dd") + "')=0";
                        BLLSETTLEACCOUNTSS.ExcuteSQL(strDeleteSS);
                    }
                    else
                        return;
            }
            catch (Exception ex)
            {
                mes.Show("检测本月结账状态失败,原因:"+ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
            #endregion

            try
            {
                if (dgListYingShou.Rows.Count == 0)
                {
                    mes.Show("未找到需要结账处理的应收数据,请先查询后再执行结账操作!");
                    return;
                }
                if (mes.ShowQ("确定要将'" + dtpDateTimeSearch.Value.ToString("yyyy-MM") + "'月份的数据结账吗?") != DialogResult.OK)
                {
                    return;
                }
                DateTime dtNow = mes.GetDatetimeNow();
                for (int i = 0; i < dgListYingShou.Rows.Count - 1; i++)
                {
                    string strFilterTJ = "";
                    object objYSFilter = dgListYingShou.Rows[i].Cells["分类编号"].Value;
                    if (objYSFilter != null && objYSFilter != DBNull.Value)
                        strFilterTJ += " AND WATERMETERTYPECLASSID='" + objYSFilter.ToString() + "'";

                    //object objYSFilter = dgListYingShou.Rows[i].Cells["用水性质编号"].Value;
                    //if (objYSFilter != null && objYSFilter != DBNull.Value)
                    //    strFilterTJ += " AND waterMeterTypeId='" + objYSFilter.ToString() + "'";

                    #region 生成MODEL并更新台账
                    MODELSETTLEACCOUNTYS MODELSETTLEACCOUNTYS = new MODELSETTLEACCOUNTYS();
                    MODELSETTLEACCOUNTYS.SETTLEACCOUNTSYSID = GETTABLEID.GetTableID("", "SETTLEACCOUNTYS");
                    MODELSETTLEACCOUNTYS.ACCOUNTSYEARANDMONTH = dtpDateTimeSearch.Value;
                    MODELSETTLEACCOUNTYS.ACCOUNTSDATETIME = dtNow;
                    MODELSETTLEACCOUNTYS.ACCOUNTSWORKERID = strLogID;
                    MODELSETTLEACCOUNTYS.ACCOUNTSWORKERNAME = strUserName;

                    object obj = dgListYingShou.Rows[i].Cells["分类编号"].Value;
                    if (obj != null && obj != DBNull.Value)
                        MODELSETTLEACCOUNTYS.WATERMETERTYPECLASSID = obj.ToString();
                    obj = dgListYingShou.Rows[i].Cells["分类名称"].Value;
                    if (obj != null && obj != DBNull.Value)
                        MODELSETTLEACCOUNTYS.WATERMETERTYPECLASSNAME = obj.ToString();
                    //object obj = dgListYingShou.Rows[i].Cells["用水性质编号"].Value;
                    //if (obj != null && obj != DBNull.Value)
                    //    MODELSETTLEACCOUNTYS.waterMeterTypeId = obj.ToString();
                    //obj = dgListYingShou.Rows[i].Cells["用水性质"].Value;
                    //if (obj != null && obj != DBNull.Value)
                    //    MODELSETTLEACCOUNTYS.waterMeterTypeName = obj.ToString();

                    obj = dgListYingShou.Rows[i].Cells["总户数"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.WATERUSERCOUNT = Convert.ToInt32(obj);

                    obj = dgListYingShou.Rows[i].Cells["用水户数"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.YSHSCOUNT = Convert.ToInt32(obj);

                    obj = dgListYingShou.Rows[i].Cells["账户余额"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.WATERUSERPRESTORE = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["累计欠费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.LJQF = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["结算余额"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.JSYE = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["用水量"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.TOTALNUMBER = Convert.ToInt32(obj);

                    obj = dgListYingShou.Rows[i].Cells["水费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.WATERTOTALCHARGE = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["污水处理费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.EXTRACHARGE1 = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["附加费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.EXTRACHARGE2 = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["应收小计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.TOTALCHARGE = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["滞纳金"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.OVERDUEMONEY = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["应收总计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.TOTALCHARGEEND = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["未收总计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.TOTALCHARGEUNGET = Convert.ToDecimal(obj);

                    obj = dgListYingShou.Rows[i].Cells["已收总计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTYS.TOTALCHARGEGET = Convert.ToDecimal(obj);

                    if (BLLSETTLEACCOUNTYS.Insert(MODELSETTLEACCOUNTYS))
                    {
                        try
                        {
                            string strSQLUpdateRecord = "UPDATE readMeterRecord SET SETTLEACCOUNTSYSID='" + MODELSETTLEACCOUNTYS.SETTLEACCOUNTSYSID + "'" +
                                " WHERE DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtpDateTimeSearch.Value + "')=0 " + strFilterTJ;
                            BLLSETTLEACCOUNTYS.ExcuteSQL(strSQLUpdateRecord);
                            dgListYingShou.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        catch (Exception ex)
                        {
                            mes.Show("更新台账结账标志失败,请重新结账,原因:" + ex.Message);
                            log.Write(ex.ToString(), MsgType.Error);
                            //回滚结账记录
                            BLLSETTLEACCOUNTYS.Delete(MODELSETTLEACCOUNTYS.SETTLEACCOUNTSYSID);
                        }
                    }
                    #endregion
                }

                tabControl1.SelectedIndex = 1;
                for (int i = 0; i < dgListDangQi.Rows.Count - 1; i++)
                {
                    string strFilterTJ = "";
                    object objYSFilter = dgListDangQi.Rows[i].Cells["分类编号"].Value;
                    if (objYSFilter != null && objYSFilter != DBNull.Value)
                        strFilterTJ += " AND WATERMETERTYPECLASSID='" + objYSFilter.ToString() + "'";

                    //object objYSFilter = dgListDangQi.Rows[i].Cells["用水性质编号"].Value;
                    //if (objYSFilter != null && objYSFilter != DBNull.Value)
                    //    strFilterTJ += " AND waterMeterTypeId='" + objYSFilter.ToString() + "'";

                    #region 生成MODEL并更新台账
                    MODELSETTLEACCOUNTSS MODELSETTLEACCOUNTSS = new MODELSETTLEACCOUNTSS();
                    MODELSETTLEACCOUNTSS.SETTLEACCOUNTSSSID = GETTABLEID.GetTableID("", "SETTLEACCOUNTSS");
                    MODELSETTLEACCOUNTSS.ACCOUNTSYEARANDMONTH = dtpDateTimeSearch.Value;
                    MODELSETTLEACCOUNTSS.ACCOUNTSDATETIME = dtNow;
                    MODELSETTLEACCOUNTSS.ACCOUNTSWORKERID = strLogID;
                    MODELSETTLEACCOUNTSS.ACCOUNTSWORKERNAME = strUserName;

                    object obj = dgListDangQi.Rows[i].Cells["分类编号"].Value;
                    if (obj != null && obj != DBNull.Value)
                        MODELSETTLEACCOUNTSS.WATERMETERTYPECLASSID = obj.ToString();
                    obj = dgListDangQi.Rows[i].Cells["分类名称"].Value;
                    if (obj != null && obj != DBNull.Value)
                        MODELSETTLEACCOUNTSS.WATERMETERTYPECLASSNAME = obj.ToString();
                    //obj = dgListDangQi.Rows[i].Cells["用水性质编号"].Value;
                    //if (obj != null && obj != DBNull.Value)
                    //    MODELSETTLEACCOUNTSS.waterMeterTypeId = obj.ToString();
                    //obj = dgListDangQi.Rows[i].Cells["用水性质"].Value;
                    //if (obj != null && obj != DBNull.Value)
                    //    MODELSETTLEACCOUNTSS.waterMeterTypeName = obj.ToString();

                    obj = dgListDangQi.Rows[i].Cells["单据数"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.BILLCOUNT = Convert.ToInt32(obj);

                    obj = dgListDangQi.Rows[i].Cells["发票数量"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.INVOICECOUNT = Convert.ToInt32(obj);

                    obj = dgListDangQi.Rows[i].Cells["收据数量"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.RECEIPTNOCOUNT = Convert.ToInt32(obj);

                    obj = dgListDangQi.Rows[i].Cells["用水量"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.TOTALNUMBER = Convert.ToInt32(obj);

                    obj = dgListDangQi.Rows[i].Cells["水费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.WATERTOTALCHARGE = Convert.ToDecimal(obj);

                    obj = dgListDangQi.Rows[i].Cells["污水处理费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.EXTRACHARGE1 = Convert.ToDecimal(obj);

                    obj = dgListDangQi.Rows[i].Cells["附加费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.EXTRACHARGE2 = Convert.ToDecimal(obj);

                    obj = dgListDangQi.Rows[i].Cells["实收水费小计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.TOTALCHARGE = Convert.ToDecimal(obj);

                    obj = dgListDangQi.Rows[i].Cells["滞纳金"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.OVERDUEMONEY = Convert.ToDecimal(obj);

                    obj = dgListDangQi.Rows[i].Cells["实收水费总计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.TOTALCHARGEEND = Convert.ToDecimal(obj);

                    obj = dgListDangQi.Rows[i].Cells["预存增减"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.YCZJ = Convert.ToDecimal(obj);

                    obj = dgListDangQi.Rows[i].Cells["实收金额总计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.SSJE = Convert.ToDecimal(obj);

                    MODELSETTLEACCOUNTSS.SSTYPE = "1";//当期

                    if (BLLSETTLEACCOUNTSS.Insert(MODELSETTLEACCOUNTSS))
                    {
                        try
                        {
                            string strSQLUpdateRecord = "UPDATE WATERFEECHARGE SET SETTLEACCOUNTSSSID='" + MODELSETTLEACCOUNTSS.SETTLEACCOUNTSSSID + "'" +
                                " WHERE CHARGEID IN " +
                                "(SELECT CHARGEID FROM V_WATERFEEANDPRESTORECHARGE WHERE DATEDIFF(MONTH,CHARGEDATETIME,'" + dtpDateTimeSearch.Value + "')=0" +
                                " AND DATEDIFF(MONTH,CHARGEDATETIME,readMeterRecordYearAndMonth)=0 " + strFilterTJ + ")";
                            BLLSETTLEACCOUNTSS.ExcuteSQL(strSQLUpdateRecord);
                            dgListDangQi.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        catch (Exception ex)
                        {
                            mes.Show("更新台账结账标志失败,请重新结账,原因:" + ex.Message);
                            log.Write(ex.ToString(), MsgType.Error);
                            //回滚结账记录
                            BLLSETTLEACCOUNTSS.Delete(MODELSETTLEACCOUNTSS.SETTLEACCOUNTSSSID);
                            return;
                        }
                    }
                    #endregion
                }
                for (int i = 0; i < dgListChenQian.Rows.Count - 1; i++)
                {
                    string strFilterTJ = "";
                    object objYSFilter = dgListChenQian.Rows[i].Cells["分类编号"].Value;
                    if (objYSFilter != null && objYSFilter != DBNull.Value)
                        strFilterTJ += " AND WATERMETERTYPECLASSID='" + objYSFilter.ToString() + "'";

                    //object objYSFilter = dgListChenQian.Rows[i].Cells["用水性质编号"].Value;
                    //if (objYSFilter != null && objYSFilter != DBNull.Value)
                    //    strFilterTJ += " AND waterMeterTypeId='" + objYSFilter.ToString() + "'";

                    #region 生成MODEL并更新台账
                    MODELSETTLEACCOUNTSS MODELSETTLEACCOUNTSS = new MODELSETTLEACCOUNTSS();
                    MODELSETTLEACCOUNTSS.SETTLEACCOUNTSSSID = GETTABLEID.GetTableID("", "SETTLEACCOUNTSS");
                    MODELSETTLEACCOUNTSS.ACCOUNTSYEARANDMONTH = dtpDateTimeSearch.Value;
                    MODELSETTLEACCOUNTSS.ACCOUNTSDATETIME = dtNow;
                    MODELSETTLEACCOUNTSS.ACCOUNTSWORKERID = strLogID;
                    MODELSETTLEACCOUNTSS.ACCOUNTSWORKERNAME = strUserName;

                    object obj = dgListChenQian.Rows[i].Cells["分类编号"].Value;
                    if (obj != null && obj != DBNull.Value)
                        MODELSETTLEACCOUNTSS.WATERMETERTYPECLASSID = obj.ToString();
                    obj = dgListChenQian.Rows[i].Cells["分类名称"].Value;
                    if (obj != null && obj != DBNull.Value)
                        MODELSETTLEACCOUNTSS.WATERMETERTYPECLASSNAME = obj.ToString();
                    //obj = dgListChenQian.Rows[i].Cells["用水性质编号"].Value;
                    //if (obj != null && obj != DBNull.Value)
                    //    MODELSETTLEACCOUNTSS.waterMeterTypeId = obj.ToString();
                    //obj = dgListChenQian.Rows[i].Cells["用水性质"].Value;
                    //if (obj != null && obj != DBNull.Value)
                    //    MODELSETTLEACCOUNTSS.waterMeterTypeName = obj.ToString();

                    obj = dgListChenQian.Rows[i].Cells["单据数"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.BILLCOUNT = Convert.ToInt32(obj);

                    obj = dgListChenQian.Rows[i].Cells["发票数量"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.INVOICECOUNT = Convert.ToInt32(obj);

                    obj = dgListChenQian.Rows[i].Cells["收据数量"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.RECEIPTNOCOUNT = Convert.ToInt32(obj);

                    obj = dgListChenQian.Rows[i].Cells["用水量"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.TOTALNUMBER = Convert.ToInt32(obj);

                    obj = dgListChenQian.Rows[i].Cells["水费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.WATERTOTALCHARGE = Convert.ToDecimal(obj);

                    obj = dgListChenQian.Rows[i].Cells["污水处理费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.EXTRACHARGE1 = Convert.ToDecimal(obj);

                    obj = dgListChenQian.Rows[i].Cells["附加费"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.EXTRACHARGE2 = Convert.ToDecimal(obj);

                    obj = dgListChenQian.Rows[i].Cells["实收水费小计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.TOTALCHARGE = Convert.ToDecimal(obj);

                    obj = dgListChenQian.Rows[i].Cells["滞纳金"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.OVERDUEMONEY = Convert.ToDecimal(obj);

                    obj = dgListChenQian.Rows[i].Cells["实收水费总计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.TOTALCHARGEEND = Convert.ToDecimal(obj);

                    obj = dgListChenQian.Rows[i].Cells["预存增减"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.YCZJ = Convert.ToDecimal(obj);

                    obj = dgListChenQian.Rows[i].Cells["实收金额总计"].Value;
                    if (Information.IsNumeric(obj))
                        MODELSETTLEACCOUNTSS.SSJE = Convert.ToDecimal(obj);

                    MODELSETTLEACCOUNTSS.SSTYPE = "2";//陈欠

                    if (BLLSETTLEACCOUNTSS.Insert(MODELSETTLEACCOUNTSS))
                    {
                        try
                        {
                            string strSQLUpdateRecord = "UPDATE WATERFEECHARGE SET SETTLEACCOUNTSSSID='" + MODELSETTLEACCOUNTSS.SETTLEACCOUNTSSSID + "'" +
                                " WHERE CHARGEID IN " +
                                "(SELECT CHARGEID FROM V_WATERFEEANDPRESTORECHARGE WHERE DATEDIFF(MONTH,CHARGEDATETIME,'" + dtpDateTimeSearch.Value + "')=0" +
                                " AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,CHARGEDATETIME)>0 " + strFilterTJ + ")";
                            BLLSETTLEACCOUNTSS.ExcuteSQL(strSQLUpdateRecord);
                            dgListChenQian.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        catch (Exception ex)
                        {
                            mes.Show("更新台账结账标志失败,请重新结账,原因:" + ex.Message);
                            log.Write(ex.ToString(), MsgType.Error);
                            //回滚结账记录
                            BLLSETTLEACCOUNTSS.Delete(MODELSETTLEACCOUNTSS.SETTLEACCOUNTSSSID);
                            return;
                        }
                    }
                    #endregion
                }
                mes.Show("月结完成!");
            }
            catch (Exception ex)
            {
                mes.Show("结账失败,原因:" + ex.Message);
                log.Write("结账失败,原因:" + ex.ToString(), MsgType.Error);
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

        private void toolExcel_Click(object sender, EventArgs e)
        {
            string strCaption = "";
            if (GetMonth(dtpStart.Value, dtpStart.Value) > 1)
            {
                strCaption = dtpStart.Value.Month + "-" + dtpStart.Value.Month + "月份水费实收统计表";
            }
            else
                strCaption = dtpStart.Value.Month + "月份水费实收统计表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgListDangQi);
        }

        private void dgListDangQi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region 合计行
            //DataRow dr = dtWaterMeterList.NewRow();

            object obj = dtWaterMeterListDangQi.Compute("SUM(单据数)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["单据数"].Value = Convert.ToInt32(obj);

            dtWaterMeterListDangQi.Compute("SUM(发票数量)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["发票数量"].Value = Convert.ToInt32(obj);

            dtWaterMeterListDangQi.Compute("SUM(收据数量)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["收据数量"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListDangQi.Compute("SUM(用水量)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["用水量"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListDangQi.Compute("SUM(水费)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["水费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListDangQi.Compute("SUM(污水处理费)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["污水处理费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListDangQi.Compute("SUM(附加费)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["附加费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListDangQi.Compute("SUM(实收水费小计)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["实收水费小计"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListDangQi.Compute("SUM(滞纳金)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["滞纳金"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListDangQi.Compute("SUM(实收水费总计)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["实收水费总计"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListDangQi.Compute("SUM(预存增减)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["预存增减"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListDangQi.Compute("SUM(实收金额总计)", "");
            if (Information.IsNumeric(obj))
                dgListDangQi.Rows[dgListDangQi.Rows.Count - 1].Cells["实收金额总计"].Value = Convert.ToDecimal(obj);
            #endregion
        }

        private void dgListChenQian_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region 合计行
            //DataRow dr = dtWaterMeterList.NewRow();

            object obj = dtWaterMeterListChenQian.Compute("SUM(单据数)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["单据数"].Value = Convert.ToInt32(obj);

            dtWaterMeterListChenQian.Compute("SUM(发票数量)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["发票数量"].Value = Convert.ToInt32(obj);

            dtWaterMeterListChenQian.Compute("SUM(收据数量)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["收据数量"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListChenQian.Compute("SUM(用水量)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["用水量"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListChenQian.Compute("SUM(水费)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["水费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListChenQian.Compute("SUM(污水处理费)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["污水处理费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListChenQian.Compute("SUM(附加费)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["附加费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListChenQian.Compute("SUM(实收水费小计)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["实收水费小计"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListChenQian.Compute("SUM(滞纳金)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["滞纳金"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListChenQian.Compute("SUM(实收水费总计)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["实收水费总计"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListChenQian.Compute("SUM(预存增减)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["预存增减"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListChenQian.Compute("SUM(实收金额总计)", "");
            if (Information.IsNumeric(obj))
                dgListChenQian.Rows[dgListChenQian.Rows.Count - 1].Cells["实收金额总计"].Value = Convert.ToDecimal(obj);
            #endregion
        }
    }
}
