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
    public partial class frmWaterMeterChargedStatics : DockContentEx
    {
        public frmWaterMeterChargedStatics()
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

            BindChargeWorkerName(cmbChargerWorkName);
            BindCharger(cmbCharger);
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
            dr["USERNAME"] = "全部";
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
            dr["USERNAME"] = "全部";
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
            dgList.DataSource = null;
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
                string strStatisticsContent = "", strStatisticsGroupBy = "";
                strFilter = strSeniorFilterHidden;

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (cmbCharger.SelectedValue != null && cmbCharger.SelectedValue != DBNull.Value)
                    strFilter += " AND chargerID='" + cmbCharger.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                if (chkPianNO.Checked)
                {
                    strStatisticsContent = "pianNO AS 片号";
                    strStatisticsGroupBy = "pianNO";
                }

                if (chkAreaNO.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",areaNO AS 区号";
                        strStatisticsGroupBy += ",areaNO";
                    }
                    else
                    {
                        strStatisticsContent = "areaNO AS 区号";
                        strStatisticsGroupBy = "areaNO";
                    }
                }

                if (chkDuanNO.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",duanNO AS 段号";
                        strStatisticsGroupBy += ",duanNO";
                    }
                    else
                    {
                        strStatisticsContent = "duanNO AS 段号";
                        strStatisticsGroupBy = "duanNO";
                    }
                }

                if (chkRecordMonth.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",readMeterRecordYearAndMonth AS 水费月份";
                        strStatisticsGroupBy += ",readMeterRecordYearAndMonth";
                    }
                    else
                    {
                        strStatisticsContent = "readMeterRecordYearAndMonth AS 水费月份";
                        strStatisticsGroupBy = "readMeterRecordYearAndMonth";
                    }
                }

                if (chkWaterUserType.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",waterUserTypeId AS 用户类别编号,waterUserTypeName AS 用户类别";
                        strStatisticsGroupBy += ",waterUserTypeId,waterUserTypeName";
                    }
                    else
                    {
                        strStatisticsContent = "waterUserTypeId AS 用户类别编号,waterUserTypeName AS 用户类别";
                        strStatisticsGroupBy = "waterUserTypeId,waterUserTypeName";
                    }
                }

                if (chkWaterMeterTypeClass.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",WATERMETERTYPECLASSNAME AS 用水性质分类";
                        strStatisticsGroupBy += ",WATERMETERTYPECLASSNAME";
                    }
                    else
                    {
                        strStatisticsContent = "WATERMETERTYPECLASSNAME AS 用水性质分类";
                        strStatisticsGroupBy = "WATERMETERTYPECLASSNAME";
                    }
                }

                if (chkWaterMeterType.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",WATERMETERTYPEID AS 用水性质编号,waterMeterTypeName AS 用水性质名称";
                        strStatisticsGroupBy += ",WATERMETERTYPEID,waterMeterTypeName";
                    }
                    else
                    {
                        strStatisticsContent = "WATERMETERTYPEID AS 用水性质编号,waterMeterTypeName AS 用水性质名称";
                        strStatisticsGroupBy = "WATERMETERTYPEID,waterMeterTypeName";
                    }
                }

                if (chkCharger.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",chargerID AS 收费员编号,chargerName AS 收费员姓名";
                        strStatisticsGroupBy += ",chargerID,chargerName";
                    }
                    else
                    {
                        strStatisticsContent = "chargerID AS 收费员编号,chargerName AS 收费员姓名";
                        strStatisticsGroupBy = "chargerID,chargerName";
                    }
                }

                if (chkMeterReader.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",meterReaderID AS 抄表员编号,meterReaderName AS 抄表员姓名";
                        strStatisticsGroupBy += ",meterReaderID,meterReaderName";
                    }
                    else
                    {
                        strStatisticsContent = "meterReaderID AS 抄表员编号,meterReaderName AS 抄表员姓名";
                        strStatisticsGroupBy = "meterReaderID,meterReaderName";
                    }
                }

                if (chkChargeWorker.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",CHARGEWORKERID AS 收款员编号,CHARGEWORKERNAME AS 收款员姓名";
                        strStatisticsGroupBy += ",CHARGEWORKERID,CHARGEWORKERNAME";
                    }
                    else
                    {
                        strStatisticsContent = "CHARGEWORKERID AS 收款员编号,CHARGEWORKERNAME AS 收款员姓名";
                        strStatisticsGroupBy = "CHARGEWORKERID,CHARGEWORKERNAME";
                    }
                }

                if (strStatisticsContent != "")
                {
                    strStatisticsGroupBy = " GROUP BY " + strStatisticsGroupBy + " ORDER BY " + strStatisticsGroupBy;
                    strStatisticsContent = "SELECT " + strStatisticsContent +
                        ",COUNT(*) AS 单据数,COUNT(DISTINCT WATERUSERID) AS 户数,SUM(totalNumber) AS 用水量," +
                        "SUM(waterTotalCharge) AS 水费,SUM(extraCharge1) AS 污水处理费," +
                        "SUM(extraCharge2) AS 附加费,SUM(totalCharge) AS 实收水费小计," +
                        "SUM(OVERDUEEND) AS 滞纳金, SUM(totalChargeEND) AS 实收水费总计," +
                        "SUM(CHARGEYSBCSZ) AS 预存增减,SUM(CHARGEBCSS) AS 实收金额总计 " +
                        "FROM (SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE 1=1 " + strFilter + ") AS AA ";
                    strStatisticsContent = strStatisticsContent + strStatisticsGroupBy ;
                }
                else
                {
                    strStatisticsContent = "SELECT COUNT(*) AS 单据数,COUNT(DISTINCT WATERUSERID) AS 户数,SUM(totalNumber) AS 用水量," +
                                    "SUM(waterTotalCharge) AS 水费,SUM(extraCharge1) AS 污水处理费," +
                                    "SUM(extraCharge2) AS 附加费,SUM(totalCharge) AS 实收水费小计," +
                                    "SUM(OVERDUEEND) AS 滞纳金, SUM(totalChargeEND) AS 实收水费总计," +
                                    "SUM(CHARGEYSBCSZ) AS 预存增减,SUM(CHARGEBCSS) AS 实收金额总计 " +
                        "FROM (SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE 1=1 " + strFilter + ") AS AA ";
                }

                dtWaterMeterList = BLLWATERFEECHARGE.QueryBySQL(strStatisticsContent);

                #region 合计行
                //DataRow dr = dtWaterMeterList.NewRow();
                //object obj = dtWaterMeterList.Compute("SUM(户数)", "");
                //if (Information.IsNumeric(obj))
                //    dr["户数"] = Convert.ToInt32(obj);

                //obj = dtWaterMeterList.Compute("SUM(用水量)", "");
                //if (Information.IsNumeric(obj))
                //    dr["用水量"] = Convert.ToInt32(obj);

                //obj = dtWaterMeterList.Compute("SUM(水费)", "");
                //if (Information.IsNumeric(obj))
                //    dr["水费"] = Convert.ToDecimal(obj);

                //obj = dtWaterMeterList.Compute("SUM(污水处理费)", "");
                //if (Information.IsNumeric(obj))
                //    dr["污水处理费"] = Convert.ToDecimal(obj);

                //obj = dtWaterMeterList.Compute("SUM(附加费)", "");
                //if (Information.IsNumeric(obj))
                //    dr["附加费"] = Convert.ToDecimal(obj);

                //obj = dtWaterMeterList.Compute("SUM(小计)", "");
                //if (Information.IsNumeric(obj))
                //    dr["小计"] = Convert.ToDecimal(obj);

                //obj = dtWaterMeterList.Compute("SUM(滞纳金)", "");
                //if (Information.IsNumeric(obj))
                //    dr["滞纳金"] = Convert.ToDecimal(obj);

                //obj = dtWaterMeterList.Compute("SUM(水费总计)", "");
                //if (Information.IsNumeric(obj))
                //    dr["水费总计"] = Convert.ToDecimal(obj);

                //obj = dtWaterMeterList.Compute("SUM(预存增减)", "");
                //if (Information.IsNumeric(obj))
                //    dr["预存增减"] = Convert.ToDecimal(obj);

                //obj = dtWaterMeterList.Compute("SUM(实收金额)", "");
                //if (Information.IsNumeric(obj))
                //    dr["实收金额"] = Convert.ToDecimal(obj);
                //dtWaterMeterList.Rows.Add(dr);
                dgList.DataSource = dtWaterMeterList;
                //dgList.Rows[dgList.Rows.Count-1].Frozen = true;
                #endregion

                if (chkRecordMonth.Checked)
                    dgList.Columns["水费月份"].DefaultCellStyle.Format = "yyyy-MM";

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;
                    toolPrintYY.Enabled = true;
                    toolPrintPreviewYY.Enabled = true;
                    toolSaveAccounts.Enabled = true;
                    toolExcel.Enabled = true;
                    //toolExcel.Enabled = true;
                    //toolUpdateAccounts.Enabled = true;
                }
                else
                {
                    toolPrint.Enabled = false;
                    toolPrintPreview.Enabled = false;
                    toolPrintYY.Enabled = false;
                    toolPrintPreviewYY.Enabled = false;
                    toolSaveAccounts.Enabled = false;
                    toolExcel.Enabled = false;
                    //toolExcel.Enabled = false;
                    //toolUpdateAccounts.Enabled = false;
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
            dtPrint.TableName = "实收水费统计(按用水性质)";

            bool CanPrint = false;
            for (int i = 0; i < dtPrint.Columns.Count; i++)
            {
                if (dtPrint.Columns[i].ColumnName == "用水性质分类")
                {
                    dtPrint.Rows[dtPrint.Rows.Count - 1]["用水性质分类"] = "合计:";
                    CanPrint = true;
                    break;
                }
            }
            if (!CanPrint)
            {
                mes.Show("只能用用水性质分类统计的报表才能打印!");
                return;
            }
            decimal decBusinessMoneyLast = 0, decFinanceMoneyLast = 0, decYSMoney = 0, decSum = 0, decOverDueMoney = 0, decBCSZ = 0, decYSXiaoJi = 0;
            DataTable dtAccount = BLLACCOUNTSRUNNING.Query(" AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpEndSearch.Value + "')=0");
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
                objMoney = dtAccount.Rows[0]["YSMONEY"];
                if (Information.IsNumeric(objMoney))
                {
                    decYSMoney = Convert.ToDecimal(objMoney);
                }
            }
            else
            {
                mes.Show("请先从应收统计界面生成'" + dtpEndSearch.Value.ToString("yyyy-MM") + "'月份的预收账款信息后再预览!");
                return;
            }

            object objSum = dtPrint.Rows[dtPrint.Rows.Count - 1]["实收金额总计"];
            if (Information.IsNumeric(objSum))
                decSum = Convert.ToDecimal(objSum);

            objSum = dtPrint.Rows[dtPrint.Rows.Count - 1]["实收水费小计"];
            if (Information.IsNumeric(objSum))
                decYSXiaoJi = Convert.ToDecimal(objSum);

            objSum = dtPrint.Rows[dtPrint.Rows.Count - 1]["滞纳金"];
            if (Information.IsNumeric(objSum))
                decOverDueMoney = Convert.ToDecimal(objSum);

            objSum = dtPrint.Rows[dtPrint.Rows.Count - 1]["预存增减"];
            if (Information.IsNumeric(objSum))
                decBCSZ = Convert.ToDecimal(objSum);

            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\应收水费统计模板\实收水费统计(月汇总财务报表).frx");
                (report1.FindObject("Cell226") as FastReport.TextObject).Text = dtpEndSearch.Value.Month + "月份实收表";
                (report1.FindObject("Cell239") as FastReport.Table.TableCell).Text = dtpEndSearch.Value.Month + "月份实收金额";
                (report1.FindObject("Cell248") as FastReport.TextObject).Text = decSum.ToString("F2");
                (report1.FindObject("Cell260") as FastReport.TextObject).Text = (decBusinessMoneyLast - decYSMoney + decSum - decOverDueMoney).ToString("F2");
                (report1.FindObject("Cell272") as FastReport.TextObject).Text = decBCSZ.ToString("F2");
                (report1.FindObject("Cell296") as FastReport.TextObject).Text = (decYSMoney - decYSXiaoJi).ToString("F2");
                //(report1.FindObject("Cell308") as FastReport.TextObject).Text = (decBusinessMoneyLast - decFinanceMoneyLast + decYSMoney - decYSXiaoJi).ToString("F2");
                (report1.FindObject("Cell320") as FastReport.TextObject).Text = (decFinanceMoneyLast + decBCSZ).ToString("F2");
                (report1.FindObject("txtTitle") as FastReport.TextObject).Text = "建平县自来水公司" + dtpEndSearch.Value.Year + "年分月实收汇总表";
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("实收水费统计(按用水性质)").Enabled = true;
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
            dtPrint.TableName = "实收水费统计(按用水性质)";

            bool CanPrint = false;
            for (int i = 0; i < dtPrint.Columns.Count; i++)
            {
                if (dtPrint.Columns[i].ColumnName == "用水性质分类")
                {
                    dtPrint.Rows[dtPrint.Rows.Count - 1]["用水性质分类"] = "合计:";
                    CanPrint = true;
                    break;
                }
            }
            if (!CanPrint)
            {
                mes.Show("只能用用水性质分类统计的报表才能打印!");
                return;
            }
            decimal decBusinessMoneyLast = 0, decFinanceMoneyLast = 0, decYSMoney = 0, decSum = 0, decOverDueMoney = 0, decBCSZ = 0, decYSXiaoJi = 0;
            DataTable dtAccount = BLLACCOUNTSRUNNING.Query(" AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpEndSearch.Value + "')=0");
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
                objMoney = dtAccount.Rows[0]["YSMONEY"];
                if (Information.IsNumeric(objMoney))
                {
                    decYSMoney = Convert.ToDecimal(objMoney);
                }
            }
            else
            {
                mes.Show("请先从应收统计界面生成'"+dtpEndSearch.Value.ToString("yyyy-MM")+"'月份的预收账款信息后再预览!");
                return;
            }

            object objSum = dtPrint.Rows[dtPrint.Rows.Count - 1]["实收金额总计"];
            if (Information.IsNumeric(objSum))
                decSum = Convert.ToDecimal(objSum);

            objSum = dtPrint.Rows[dtPrint.Rows.Count - 1]["实收水费小计"];
            if (Information.IsNumeric(objSum))
                decYSXiaoJi = Convert.ToDecimal(objSum);
            
            objSum = dtPrint.Rows[dtPrint.Rows.Count - 1]["滞纳金"];
            if (Information.IsNumeric(objSum))
                decOverDueMoney = Convert.ToDecimal(objSum);

            objSum = dtPrint.Rows[dtPrint.Rows.Count - 1]["预存增减"];
            if (Information.IsNumeric(objSum))
                decBCSZ = Convert.ToDecimal(objSum);

            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\应收水费统计模板\实收水费统计(月汇总财务报表).frx");
                (report1.FindObject("Cell226") as FastReport.TextObject).Text = dtpEndSearch.Value.Month + "月份实收表";
                (report1.FindObject("Cell239") as FastReport.Table.TableCell).Text = dtpEndSearch.Value.Month + "月份实收金额";
                (report1.FindObject("Cell248") as FastReport.TextObject).Text = decSum.ToString("F2");
                (report1.FindObject("Cell260") as FastReport.TextObject).Text = (decBusinessMoneyLast - decYSMoney + decSum - decOverDueMoney).ToString("F2");
                (report1.FindObject("Cell272") as FastReport.TextObject).Text = decBCSZ.ToString("F2");
                (report1.FindObject("Cell296") as FastReport.TextObject).Text = (decYSMoney - decYSXiaoJi).ToString("F2");
                //(report1.FindObject("Cell308") as FastReport.TextObject).Text = (decBusinessMoneyLast - decFinanceMoneyLast + decYSMoney - decYSXiaoJi).ToString("F2");
                (report1.FindObject("Cell320") as FastReport.TextObject).Text = (decFinanceMoneyLast + decBCSZ).ToString("F2");
                (report1.FindObject("txtTitle") as FastReport.TextObject).Text = "建平县自来水公司" + dtpEndSearch.Value.Year + "年分月实收汇总表";
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("实收水费统计(按用水性质)").Enabled = true;
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

        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex == dgList.Rows.Count - 1)
                return;
            string strFilterTJ="";
            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                if (dgList.Columns[i].Name == "片号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND pianNO='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "区号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND areaNO='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "段号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND duanNO='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "水费月份")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        if (Information.IsDate(obj.ToString() + "-01"))
                        {
                            strFilterTJ += " AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + obj.ToString() + "')=0";
                        }
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "收费员编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND chargerID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "抄表员编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND meterReaderID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "用户类别编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND WATERUSERTYPEID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "用水性质分类")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND WATERMETERTYPECLASSNAME='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "收款员编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND CHARGEWORKERID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "用水性质编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND WATERMETERTYPEID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
            }
            string strSQLSelect = "SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE 1=1 "+strFilterTJ+strFilter;
            DataTable dtSelect = BLLWATERFEECHARGE.QueryBySQL(strSQLSelect);
            frmWaterMeterChargedStatisticsSearch frm = new frmWaterMeterChargedStatisticsSearch();
            frm.dtWaterMeterList = dtSelect;
            frm.ShowDialog();
        }

        private void dgList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region 合计行
            //DataRow dr = dtWaterMeterList.NewRow();
            
            object obj = dtWaterMeterList.Compute("SUM(单据数)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["单据数"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterList.Compute("SUM(户数)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["户数"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterList.Compute("SUM(用水量)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["用水量"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterList.Compute("SUM(水费)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["水费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(污水处理费)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["污水处理费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(附加费)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["附加费"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(实收水费小计)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["实收水费小计"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(滞纳金)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["滞纳金"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(实收水费总计)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["实收水费总计"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(预存增减)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["预存增减"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(实收金额总计)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["实收金额总计"].Value = Convert.ToDecimal(obj);
            //dtWaterMeterList.Rows.Add(dr);
            //dgList.DataSource = dtWaterMeterList;
            //dgList.Rows[dgList.Rows.Count-1].Frozen = true;
            #endregion
        }

        private void toolSaveAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GetMonth(dtpStartSearch.Value, dtpEndSearch.Value) > 1)
                //{
                //    mes.Show("预收账款的保存只能为某月份!");
                //    return;
                //}
                decimal decBusinessMoneyLast = 0, decFinanceMoneyLast = 0, decYSMoney = 0, decSum = 0, decOverDueMoney = 0,
                    decBCSZ = 0, decYSXiaoJi = 0, decBusinessMoney = 0, decFinanceMoney = 0;
                DataTable dtAccount = BLLACCOUNTSRUNNING.Query(" AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpEndSearch.Value + "')=0");
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
                    objMoney = dtAccount.Rows[0]["YSMONEY"];
                    if (Information.IsNumeric(objMoney))
                    {
                        decYSMoney = Convert.ToDecimal(objMoney);
                    }
                }
                else
                {
                    mes.Show("请先从应收统计界面生成'" + dtpEndSearch.Value.ToString("yyyy-MM") + "'月份的预收账款信息后再保存本月预收账款!");
                    return;
                }

                object objSum = dgList.Rows[dgList.Rows.Count - 1].Cells["实收金额总计"].Value;
                if (Information.IsNumeric(objSum))
                    decSum = Convert.ToDecimal(objSum);

                objSum = dgList.Rows[dgList.Rows.Count - 1].Cells["实收水费小计"].Value;
                if (Information.IsNumeric(objSum))
                    decYSXiaoJi = Convert.ToDecimal(objSum);

                objSum = dgList.Rows[dgList.Rows.Count - 1].Cells["滞纳金"].Value;
                if (Information.IsNumeric(objSum))
                    decOverDueMoney = Convert.ToDecimal(objSum);

                objSum = dgList.Rows[dgList.Rows.Count - 1].Cells["预存增减"].Value;
                if (Information.IsNumeric(objSum))
                    decBCSZ = Convert.ToDecimal(objSum);

                decBusinessMoney = decBusinessMoneyLast - decYSMoney + decSum - decOverDueMoney;
                decFinanceMoney = decFinanceMoneyLast + decBCSZ;

                if (mes.ShowQ("确定要保存 '" + dtpEndSearch.Value.ToString("yyyy-MM") + "' 月份的预收账款信息吗?\r\n点击确定将保存以下信息:\r\n" +
                    "本期(" + dtpStartSearch.Value.AddMonths(-1).ToString("yyyy-MM") + ")预收账款用户余额（营业）:" + decBusinessMoney.ToString("F2") + "\r\n" +
                    "本期(" + dtpStartSearch.Value.AddMonths(-1).ToString("yyyy-MM") + ")预收账款用户余额（财会）:" + decFinanceMoney.ToString("F2")) == DialogResult.OK)
                {
                    DataTable dt = BLLACCOUNTSRUNNING.Query(" AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpEndSearch.Value + "')=0");
                    if (dt.Rows.Count > 0)
                    {
                        object objID = dt.Rows[0]["ACCOUNTSID"];
                        if (objID != null && objID != DBNull.Value)
                        {
                            string strSQLUpdate = "UPDATE ACCOUNTSRUNNING SET BUSINESSMONEY=" + decBusinessMoney + ",FINANCEMONEY=" + decFinanceMoney +
                                ",ACCOUNTSDATETIME='" + mes.GetDatetimeNow() + "',OPERATORID='" + strLogID + "',OPERATORNAME='" + strUserName +
                                "' WHERE ACCOUNTSID=" + objID.ToString();
                            if (BLLACCOUNTSRUNNING.ExcuteSQL(strSQLUpdate) > 0)
                            {
                                mes.Show("预收账款更新成功!");
                            }
                            else
                                mes.Show("预收账款更新失败,请重试!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show("更新预收账款失败,原因:" + ex.Message);
                log.Write("更新预收账款失败,原因:" + ex.ToString(), MsgType.Error);
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
            if (GetMonth(dtpStartSearch.Value, dtpEndSearch.Value) > 1)
            {
                strCaption = dtpStartSearch.Value.Month + "-" + dtpEndSearch.Value.Month + "月份水费实收统计表";
            }
            else
                strCaption = dtpEndSearch.Value.Month + "月份水费实收统计表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
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

        private void toolPrintYY_Click(object sender, EventArgs e)
        {
            if (dtWaterMeterList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtPrint = GetDgvToTable(dgList);
            dtPrint.TableName = "实收水费统计(按用水性质)";

            bool CanPrint = false;
            for (int i = 0; i < dtPrint.Columns.Count; i++)
            {
                if (dtPrint.Columns[i].ColumnName == "用水性质分类")
                {
                    dtPrint.Rows[dtPrint.Rows.Count - 1]["用水性质分类"] = "合计:";
                    CanPrint = true;
                    break;
                }
            }
            if (!CanPrint)
            {
                mes.Show("只能用用水性质分类统计的报表才能打印!");
                return;
            }
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\应收水费统计模板\实收水费统计(营业).frx");
                (report1.FindObject("txtTitle") as FastReport.TextObject).Text = "建平县自来水公司" + dtpEndSearch.Value.Year + "年" + dtpEndSearch.Value.Month + "月份实收汇总表";
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("实收水费统计(按用水性质)").Enabled = true;
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

        private void toolPrintPreviewYY_Click(object sender, EventArgs e)
        {
            if (dtWaterMeterList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtPrint = GetDgvToTable(dgList);
            dtPrint.TableName = "实收水费统计(按用水性质)";

            bool CanPrint = false;
            for (int i = 0; i < dtPrint.Columns.Count; i++)
            {
                if (dtPrint.Columns[i].ColumnName == "用水性质分类")
                {
                    dtPrint.Rows[dtPrint.Rows.Count - 1]["用水性质分类"] = "合计:";
                    CanPrint = true;
                    break;
                }
            }
            if (!CanPrint)
            {
                mes.Show("只能用用水性质分类统计的报表才能打印!");
                return;
            }
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\应收水费统计模板\实收水费统计(营业).frx");
                (report1.FindObject("txtTitle") as FastReport.TextObject).Text = "建平县自来水公司" + dtpEndSearch.Value.Year + "年" + dtpEndSearch.Value.Month + "月份实收汇总表";
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("实收水费统计(按用水性质)").Enabled = true;
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
    }
}
