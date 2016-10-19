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
    public partial class frmWaterFeeSummaryPreview_Year : DockContentEx
    {
        public frmWaterFeeSummaryPreview_Year()
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

        BLLwaterUser BLLwaterUser = new BLLwaterUser();

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
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day,23,59,59);
            dtpEnd.Value = dtMonthEnd;
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
                log.Write("用水情况一览表界面:" + ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
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
                log.Write("用水情况一览表界面:" + ex.ToString(), MsgType.Error);
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

        /// <summary>
        /// 查询条件
        /// </summary>
        string strFilter = "";
        private void LoadData()
        {
            try
            {
                    strFilter = " AND readMeterRecordYearAndMonth BETWEEN '" + dtpStart.Value + "' AND '" + dtpEnd.Value + "'";

                    int intXSHS = 0, intSQYHS = 0,intQMYHS = 0, 
                    intWaterUserFSSLCount = 0, intTotalNumber = 0,
                    intSSHS = 0, intSSSL = 0,
                    intWQHS = 0, intWQSL = 0;

                decimal decYSZJ = 0, decYSSF = 0, decYSWSCLF = 0, decYSFJF = 0,
                        decSSZJ = 0, decSSSF = 0, decSSWSCLF = 0, decSSFJF = 0,decOverDue=0,
                        decWQZJ = 0, decWQSF = 0, decWQWSCLF = 0, decWQFJF = 0;

                    string strSQL = "SELECT COUNT(*) AS 数量 FROM WATERUSER WHERE waterUserCreateDate BETWEEN '" + dtpStartSearch.Value + "' AND '" + dtpEndSearch.Value + "'";

                    DataTable dtWaterUser = BLLWATERFEECHARGE.QueryBySQL(strSQL);
                    object objWaterUser = dtWaterUser.Rows[0]["数量"];
                    if (Information.IsNumeric(objWaterUser))
                        intXSHS = Convert.ToInt32(objWaterUser);

                //新上户数
                labXSHS.Text =intXSHS.ToString();

                string strSQLFSSLHS = "SELECT DISTINCT WATERUSERID FROM (SELECT * FROM V_YSACCOUNTS_READMETERRECORD_CONTAINOVERDUE WHERE totalNumber>0 " + strFilter + ") AS AA";
                DataTable dtFSSLHS = BLLwaterUser.QuerySQL(strSQLFSSLHS);
                intWaterUserFSSLCount = dtFSSLHS.Rows.Count;

                //期初户数
                    string strLastWaterUserCountSQL = "SELECT DISTINCT WATERUSERID FROM readMeterRecord " +
                        "WHERE  DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1).AddMonths(-1) + "')=0 "+
                    "  AND waterUserState<>'注销'";
                        //"  AND waterUserState<>'注销' ";
                    DataTable dtSQYHS = BLLwaterUser.QuerySQL(strLastWaterUserCountSQL);
                    intSQYHS = dtSQYHS.Rows.Count;

                    //期末户数
                    string strEndWaterUserCountSQL = "SELECT DISTINCT WATERUSERID FROM readMeterRecord " +
                        "WHERE DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtpEnd.Value + "')=0 " +
                    "  AND waterUserState<>'注销'";
                    DataTable dtQMYHS = BLLwaterUser.QuerySQL(strEndWaterUserCountSQL);
                    intQMYHS = dtQMYHS.Rows.Count;

                DateTime dtSQSJS=Convert.ToDateTime(dtpStart.Value);
                DateTime dtSQSJ=new DateTime(2015,12,1);
                int intDiff = dtSQSJS.Year * 12 + dtSQSJS.Month - dtSQSJ.Year * 12 - dtSQSJ.Month;
                if (intDiff == 1)
                    labYCHS.Text = "55399";
                else
                labYCHS.Text = intSQYHS.ToString();
                
                //发生用数量户数
                labFSYSHS.Text =intWaterUserFSSLCount.ToString();

                 string strSQLBY = "SELECT SUM(totalNumber) AS 用水量," +
                        "SUM(waterTotalChargeEND) AS 水费,SUM(extraCharge1) AS 污水处理费," +
                        "SUM(extraCharge2) AS 附加费," +
                        //"SUM(OVERDUEEND) AS 滞纳金, SUM(totalCharge+OVERDUEEND) AS 应收总计, " +
                        "SUM(OVERDUEEND) AS 滞纳金, SUM(totalCharge) AS 应收总计, " +
                        "SUM(CASE WHEN chargeState='3' THEN 0 ELSE totalCharge END) AS 尾欠总计,SUM(CASE WHEN chargeState='3' THEN 0 ELSE totalNumber END) AS 尾欠水量," +
                        "SUM(CASE WHEN chargeState='3' THEN 0 ELSE waterTotalChargeEND END) AS 尾欠水费,SUM(CASE WHEN chargeState='3' THEN 0 ELSE extraCharge1 END) AS 尾欠污水处理费," +
                        "SUM(CASE WHEN chargeState='3' THEN 0 ELSE extraCharge2 END) AS 尾欠附加费," +
                        "SUM(CASE WHEN chargeState<>'3' THEN 0 ELSE totalCharge END) AS 实收总计,SUM(CASE WHEN chargeState<>'3' THEN 0 ELSE totalNumber END) AS 实收水量," +
                        "SUM(CASE WHEN chargeState<>'3' THEN 0 ELSE waterTotalChargeEND END) AS 实收水费,SUM(CASE WHEN chargeState<>'3' THEN 0 ELSE extraCharge1 END) AS 实收污水处理费," +
                        "SUM(CASE WHEN chargeState<>'3' THEN 0 ELSE extraCharge2 END) AS 实收附加费 " +
                     "FROM V_YSACCOUNTS_READMETERRECORD_CONTAINOVERDUE WHERE 1=1 AND waterUserState<>'注销' " + strFilter;
                     //"FROM V_YSACCOUNTS_READMETERRECORD_CONTAINOVERDUE WHERE 1=1 " + strFilter;

                 dtWaterMeterList = BLLWATERFEECHARGE.QueryBySQL(strSQLBY);
                 if (dtWaterMeterList.Rows.Count > 0)
                 {
                    object obj = dtWaterMeterList.Rows[0]["用水量"];
                     if (Information.IsNumeric(obj))
                         intTotalNumber = Convert.ToInt32(obj);
                     obj = dtWaterMeterList.Rows[0]["应收总计"];
                     if (Information.IsNumeric(obj))
                         decYSZJ = Convert.ToDecimal(obj);
                     obj = dtWaterMeterList.Rows[0]["水费"];
                     if (Information.IsNumeric(obj))
                         decYSSF = Convert.ToDecimal(obj);
                     obj = dtWaterMeterList.Rows[0]["污水处理费"];
                     if (Information.IsNumeric(obj))
                         decYSWSCLF = Convert.ToDecimal(obj);
                     obj = dtWaterMeterList.Rows[0]["附加费"];
                     if (Information.IsNumeric(obj))
                         decYSFJF = Convert.ToDecimal(obj);

                     obj = dtWaterMeterList.Rows[0]["尾欠总计"];
                     if (Information.IsNumeric(obj))
                         decWQZJ = Convert.ToDecimal(obj);
                     obj = dtWaterMeterList.Rows[0]["尾欠水量"];
                     if (Information.IsNumeric(obj))
                         intWQSL = Convert.ToInt32(obj);
                     obj = dtWaterMeterList.Rows[0]["尾欠水费"];
                     if (Information.IsNumeric(obj))
                         decWQSF = Convert.ToDecimal(obj);
                     obj = dtWaterMeterList.Rows[0]["尾欠污水处理费"];
                     if (Information.IsNumeric(obj))
                         decWQWSCLF = Convert.ToDecimal(obj);
                     obj = dtWaterMeterList.Rows[0]["尾欠附加费"];
                     if (Information.IsNumeric(obj))
                         decWQFJF = Convert.ToDecimal(obj);
                 }
                   string strSSSQL ="";
                 strSSSQL = "SELECT COUNT(DISTINCT WATERUSERID) AS 实收户数,SUM(totalNumber) AS 实收水量," +
                                  "SUM(waterTotalCharge) AS 实收水费,SUM(extraCharge1) AS 实收污水处理费," +
                                  "SUM(extraCharge2) AS 实收附加费,SUM(totalCharge) AS 实收水费小计," +
                                  "SUM(OVERDUEEND) AS 滞纳金, SUM(totalChargeEND) AS 实收水费总计," +
                                  "SUM(CHARGEYSBCSZ) AS 预存增减,SUM(CHARGEBCSS) AS 实收金额总计 " +
                      "FROM (SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE CHARGEDATETIME BETWEEN '" + dtpStart.Value + "' AND '" + dtpEnd.Value + "') AS AA";
          

                 dtWaterMeterList = BLLWATERFEECHARGE.QueryBySQL(strSSSQL);
                  if (dtWaterMeterList.Rows.Count > 0)
                  {
                      object obj = dtWaterMeterList.Rows[0]["实收金额总计"];
                      if (Information.IsNumeric(obj))
                          decSSZJ = Convert.ToDecimal(obj);
                      obj = dtWaterMeterList.Rows[0]["实收户数"];
                      if (Information.IsNumeric(obj))
                          intSSHS = Convert.ToInt32(obj);
                      obj = dtWaterMeterList.Rows[0]["实收水量"];
                      if (Information.IsNumeric(obj))
                          intSSSL = Convert.ToInt32(obj);
                      obj = dtWaterMeterList.Rows[0]["实收水费"];
                      if (Information.IsNumeric(obj))
                          decSSSF = Convert.ToDecimal(obj);
                      obj = dtWaterMeterList.Rows[0]["实收污水处理费"];
                      if (Information.IsNumeric(obj))
                          decSSWSCLF = Convert.ToDecimal(obj);
                      obj = dtWaterMeterList.Rows[0]["实收附加费"];
                      if (Information.IsNumeric(obj))
                          decSSFJF = Convert.ToDecimal(obj);
                      obj = dtWaterMeterList.Rows[0]["滞纳金"];
                      if (Information.IsNumeric(obj))
                          decOverDue = Convert.ToDecimal(obj);
                  }

                //总户数
                  labYMHS.Text = intQMYHS.ToString();

                  labYSZJ.Text = decYSZJ.ToString("F2");
                  labYSYSL.Text = intTotalNumber.ToString();
                  labYSSF.Text = decYSSF.ToString("F2");
                  labYSWSSF.Text = decYSWSCLF.ToString("F2");
                  labYSFJF.Text = decYSFJF.ToString("F2");

                  labWQZJ.Text = decWQZJ.ToString("F2");
                  labWQSL.Text = intWQSL.ToString();
                  labWQSF.Text = decWQSF.ToString("F2");
                  labWQWSCLF.Text = decWQWSCLF.ToString("F2");
                  labWQFJF.Text = decWQFJF.ToString("F2");

                  labSSZJ.Text = decSSZJ.ToString("F2");
                  labSSSL.Text = intSSSL.ToString();
                  labSSSF.Text = decSSSF.ToString("F2");
                  labSSWSCLF.Text = decSSWSCLF.ToString("F2");
                  labSSFJF.Text = decSSFJF.ToString("F2");
                  labSSHS.Text = intSSHS.ToString();
                  labOverDue.Text = decOverDue.ToString("F2");

                  //string strSQLSSHS = "SELECT DISTINCT WATERUSERID FROM (SELECT * FROM V_YSACCOUNTS_READMETERRECORD_CONTAINOVERDUE WHERE totalNumber>0 AND CHARGESTATE='3' " + strFilter + ") AS AA";
                  //DataTable dtSSHS = BLLwaterUser.QuerySQL(strSQLSSHS);
                  //intSSHS = dtSSHS.Rows.Count;
                  //labSSHS.Text = intSSHS.ToString();

                  string strSQLWQHS = "SELECT DISTINCT WATERUSERID FROM (SELECT * FROM V_YSACCOUNTS_READMETERRECORD_CONTAINOVERDUE WHERE CHARGESTATE<>'3' AND totalCharge>0 " + strFilter + ") AS AA";
                  DataTable dtWQHS = BLLwaterUser.QuerySQL(strSQLWQHS);
                  intWQHS = dtWQHS.Rows.Count;
                  labWQHS.Text = intWQHS.ToString();

                  int intLJQFSL = 0, intLJQFHS = 0;
                  decimal deLJQFZJ = 0, decLJQFSF = 0, decLJQFWSCLF = 0, decLJQFFJF = 0;
                  string strYSLeiJi = "SELECT COUNT(DISTINCT WATERUSERID) AS 累计欠费户数,SUM(totalCharge) AS 累计欠费总计, " +
                        "SUM(totalNumber) AS 累计欠费水量," +
                          "SUM(waterTotalChargeEND) AS 累计欠费水费," +
                          "SUM(extraCharge1) AS 累计欠费污水处理费," +
                          "SUM(extraCharge2) AS 累计欠费附加费 " +
                      " FROM V_YSDETAIL_BYWATERMETER WHERE WATERUSERID IN (SELECT WATERUSERID FROM V_YSACCOUNTS_READMETERRECORD_CONTAINOVERDUE WHERE 1=1 " +
                      //" FROM V_YSACCOUNTS_READMETERRECORD_CONTAINOVERDUE WHERE 1=1 " +
                       strFilter + ") AND CHARGESTATE<>'3' AND totalCharge>0";
                  DataTable dtYSLeiJI = BLLWATERFEECHARGE.QueryBySQL(strYSLeiJi);
                  if (dtYSLeiJI.Rows.Count > 0)
                  {
                      object objLJQF = dtYSLeiJI.Rows[0]["累计欠费总计"];
                      if (Information.IsNumeric(objLJQF))
                          deLJQFZJ = Convert.ToDecimal(objLJQF);

                      objLJQF = dtYSLeiJI.Rows[0]["累计欠费户数"];
                      if (Information.IsNumeric(objLJQF))
                          intLJQFHS = Convert.ToInt32(objLJQF);

                      objLJQF = dtYSLeiJI.Rows[0]["累计欠费水量"];
                      if (Information.IsNumeric(objLJQF))
                          intLJQFSL = Convert.ToInt32(objLJQF);

                      objLJQF = dtYSLeiJI.Rows[0]["累计欠费水费"];
                      if (Information.IsNumeric(objLJQF))
                          decLJQFSF = Convert.ToDecimal(objLJQF);

                      objLJQF = dtYSLeiJI.Rows[0]["累计欠费污水处理费"];
                      if (Information.IsNumeric(objLJQF))
                          decLJQFWSCLF = Convert.ToDecimal(objLJQF);

                      objLJQF = dtYSLeiJI.Rows[0]["累计欠费附加费"];
                      if (Information.IsNumeric(objLJQF))
                          decLJQFFJF = Convert.ToDecimal(objLJQF);
                  }
                  labLJQFZJ.Text = deLJQFZJ.ToString("F2");
                  labLJQFSL.Text = intLJQFSL.ToString();
                  labLJQFHS.Text = intLJQFHS.ToString();
                  labLJQFSF.Text = decLJQFSF.ToString("F2");
                  labLJQFWSCLF.Text = decLJQFWSCLF.ToString("F2");
                  labLJQFFJF.Text = decLJQFFJF.ToString("F2");
                  //decimal decBusinessMoneyLast = 0, decFinanceMoneyLast = 0, decSum = 0, decOverDueMoney = 0,
                  //    decBCSZ = 0, decYSXiaoJi = 0, decBusinessMoney = 0, decFinanceMoney = 0;
                  //DataTable dtAccount = BLLACCOUNTSRUNNING.Query(" AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpEndSearch.Value + "')=0");
                  //if (dtAccount.Rows.Count > 0)
                  //{
                  //    object objMoney = dtAccount.Rows[0]["BUSINESSMONEYLAST"];
                  //    if (Information.IsNumeric(objMoney))
                  //    {
                  //        decBusinessMoneyLast = Convert.ToDecimal(objMoney);
                  //    }
                  //    objMoney = dtAccount.Rows[0]["FINANCEMONEYLAST"];
                  //    if (Information.IsNumeric(objMoney))
                  //    {
                  //        decFinanceMoneyLast = Convert.ToDecimal(objMoney);
                  //    }
                  //}

                  //strSQL = "SELECT " +
                  //                "SUM(OVERDUEEND) AS 滞纳金, SUM(totalChargeEND) AS 实收水费总计," +
                  //                "SUM(CHARGEYSBCSZ) AS 预存增减,SUM(CHARGEBCSS) AS 实收金额总计 " +
                  //    "FROM (SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE 1=1 " + " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'" +") AS AA";
                  //DataTable dtYS = BLLWATERFEECHARGE.QueryBySQL(strSQL);
                  //obj = dtYS.Rows[0]["滞纳金"];
                  //if (Information.IsNumeric(obj))
                  //    decOverDueMoney = Convert.ToDecimal(obj);
                  //obj = dtYS.Rows[0]["实收金额总计"];
                  //if (Information.IsNumeric(obj))
                  //    decSum = Convert.ToDecimal(obj);
                  //decBusinessMoney = decBusinessMoneyLast - decYSZJ + decSum - decOverDueMoney;

                  //labSQZMJE.Text =decBusinessMoneyLast.ToString("F2");
                  //labBQZJ.Text = (decSum - decOverDueMoney - decYSZJ).ToString("F2");
                  //labBQZMJE.Text = decBusinessMoney.ToString("F2");


                //if (dtWaterMeterList.Rows.Count > 0)
                //{
                //    toolPrint.Enabled = true;
                //    toolPrintPreview.Enabled = true;
                //}
                //else
                //{
                //    toolPrint.Enabled = false;
                //    toolPrintPreview.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        string[] strMonth = {"一","二","三","四","五","六","七","八","九","十","十一","十二" };
        private void toolPrint_Click(object sender, EventArgs e)
        {
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\用水情况一览表.frx");
                (report1.FindObject("Cell3") as FastReport.TextObject).Text = labYCHS.Text;
                (report1.FindObject("Cell8") as FastReport.TextObject).Text = labXSHS.Text;
                (report1.FindObject("Cell13") as FastReport.TextObject).Text = labXHHS.Text;
                (report1.FindObject("Cell148") as FastReport.TextObject).Text = labYMHS.Text;

                (report1.FindObject("Cell33") as FastReport.TextObject).Text = labYSZJ.Text;
                (report1.FindObject("Cell43") as FastReport.TextObject).Text = labFSYSHS.Text;
                (report1.FindObject("Cell48") as FastReport.TextObject).Text = labYSYSL.Text;
                (report1.FindObject("Cell38") as FastReport.TextObject).Text = labYSSF.Text;
                (report1.FindObject("Cell58") as FastReport.TextObject).Text = labYSWSSF.Text;
                (report1.FindObject("Cell63") as FastReport.TextObject).Text = labYSFJF.Text;

                (report1.FindObject("Cell68") as FastReport.TextObject).Text = labSSZJ.Text;
                (report1.FindObject("Cell108") as FastReport.TextObject).Text = labSSSL.Text;
                (report1.FindObject("Cell103") as FastReport.TextObject).Text = labSSHS.Text;
                (report1.FindObject("Cell53") as FastReport.TextObject).Text = labSSSF.Text;
                (report1.FindObject("Cell28") as FastReport.TextObject).Text = labSSWSCLF.Text;
                (report1.FindObject("Cell18") as FastReport.TextObject).Text = labSSFJF.Text;
                (report1.FindObject("Cell113") as FastReport.TextObject).Text = labOverDue.Text;

                (report1.FindObject("Cell73") as FastReport.TextObject).Text = labWQZJ.Text;
                (report1.FindObject("Cell98") as FastReport.TextObject).Text = labWQSL.Text;
                (report1.FindObject("Cell93") as FastReport.TextObject).Text = labWQHS.Text;
                (report1.FindObject("Cell88") as FastReport.TextObject).Text = labWQSF.Text;
                (report1.FindObject("Cell83") as FastReport.TextObject).Text = labWQWSCLF.Text;
                (report1.FindObject("Cell78") as FastReport.TextObject).Text = labWQFJF.Text;

                (report1.FindObject("Cell118") as FastReport.TextObject).Text = labLJQFZJ.Text;
                (report1.FindObject("Cell123") as FastReport.TextObject).Text = labLJQFHS.Text;
                (report1.FindObject("Cell128") as FastReport.TextObject).Text = labLJQFSL.Text;
                (report1.FindObject("Cell133") as FastReport.TextObject).Text = labLJQFSF.Text;
                (report1.FindObject("Cell138") as FastReport.TextObject).Text = labLJQFWSCLF.Text;
                (report1.FindObject("Cell143") as FastReport.TextObject).Text = labLJQFFJF.Text;

                if (GetMonth(dtpStartSearch.Value, dtpEndSearch.Value) > 1)
                    (report1.FindObject("txtTitle") as FastReport.TextObject).Text = dtpStartSearch.Value.ToString("yyyy-MM") + "至" + dtpEndSearch.Value.ToString("yyyy-MM") + "月份用水情况一览表";
                else
                    (report1.FindObject("txtTitle") as FastReport.TextObject).Text = strMonth[dtpEndSearch.Value.Month - 1] + "月份用水情况一览表";

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
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\用水情况一览表.frx");
                (report1.FindObject("Cell3") as FastReport.TextObject).Text = labYCHS.Text;
                (report1.FindObject("Cell8") as FastReport.TextObject).Text = labXSHS.Text;
                (report1.FindObject("Cell13") as FastReport.TextObject).Text = labXHHS.Text;
                (report1.FindObject("Cell148") as FastReport.TextObject).Text = labYMHS.Text;

                (report1.FindObject("Cell33") as FastReport.TextObject).Text = labYSZJ.Text;
                (report1.FindObject("Cell43") as FastReport.TextObject).Text = labFSYSHS.Text;
                (report1.FindObject("Cell48") as FastReport.TextObject).Text = labYSYSL.Text;
                (report1.FindObject("Cell38") as FastReport.TextObject).Text = labYSSF.Text;
                (report1.FindObject("Cell58") as FastReport.TextObject).Text = labYSWSSF.Text;
                (report1.FindObject("Cell63") as FastReport.TextObject).Text = labYSFJF.Text;

                (report1.FindObject("Cell68") as FastReport.TextObject).Text = labSSZJ.Text;
                (report1.FindObject("Cell108") as FastReport.TextObject).Text = labSSSL.Text;
                (report1.FindObject("Cell103") as FastReport.TextObject).Text = labSSHS.Text;
                (report1.FindObject("Cell53") as FastReport.TextObject).Text = labSSSF.Text;
                (report1.FindObject("Cell28") as FastReport.TextObject).Text = labSSWSCLF.Text;
                (report1.FindObject("Cell18") as FastReport.TextObject).Text = labSSFJF.Text;
                (report1.FindObject("Cell113") as FastReport.TextObject).Text = labOverDue.Text;

                (report1.FindObject("Cell73") as FastReport.TextObject).Text = labWQZJ.Text;
                (report1.FindObject("Cell98") as FastReport.TextObject).Text = labWQSL.Text;
                (report1.FindObject("Cell93") as FastReport.TextObject).Text = labWQHS.Text;
                (report1.FindObject("Cell88") as FastReport.TextObject).Text = labWQSF.Text;
                (report1.FindObject("Cell83") as FastReport.TextObject).Text = labWQWSCLF.Text;
                (report1.FindObject("Cell78") as FastReport.TextObject).Text = labWQFJF.Text;

                (report1.FindObject("Cell118") as FastReport.TextObject).Text = labLJQFZJ.Text;
                (report1.FindObject("Cell123") as FastReport.TextObject).Text = labLJQFHS.Text;
                (report1.FindObject("Cell128") as FastReport.TextObject).Text = labLJQFSL.Text;
                (report1.FindObject("Cell133") as FastReport.TextObject).Text = labLJQFSF.Text;
                (report1.FindObject("Cell138") as FastReport.TextObject).Text = labLJQFWSCLF.Text;
                (report1.FindObject("Cell143") as FastReport.TextObject).Text = labLJQFFJF.Text;

                //(report1.FindObject("Cell28") as FastReport.TextObject).Text = labSQZMJE.Text;
                //(report1.FindObject("Cell18") as FastReport.TextObject).Text = labBQZJ.Text;
                //(report1.FindObject("Cell23") as FastReport.TextObject).Text = labBQZMJE.Text;

                if (GetMonth(dtpStartSearch.Value,dtpEndSearch.Value)>1)
                (report1.FindObject("txtTitle") as FastReport.TextObject).Text =dtpStartSearch.Value.ToString("yyyy-MM")+"至" +dtpEndSearch.Value.ToString("yyyy-MM") + "月份用水情况一览表";
                else
                    (report1.FindObject("txtTitle") as FastReport.TextObject).Text = strMonth[dtpEndSearch.Value.Month-1] + "月份用水情况一览表";

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
