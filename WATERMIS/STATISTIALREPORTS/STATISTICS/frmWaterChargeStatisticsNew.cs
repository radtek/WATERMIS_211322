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
    public partial class frmWaterChargeStatisticsNew : DockContentEx
    {
        public frmWaterChargeStatisticsNew()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();
        BLLAREA BLLAREA = new BLLAREA();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();

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
            BindChargeWorkerName();

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员编号获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            //this.Text = "收款结算——当前操作员:" + strUserName;

            object objGroup = AppDomain.CurrentDomain.GetData("GROUPID");
            if (objGroup != null && objGroup != DBNull.Value)
            {
                //如果非系统管理员，则只能统计自己的收费明细
                if (objGroup.ToString() != "0001")
                {
                    cmbChargerWorkName.SelectedValue = strLogID;
                    cmbChargerWorkName.Enabled = false;
                }
            }

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                //禁止列排序
                dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            BindWaterMeterType();
            BindWaterUserType(cmbWaterUserTypeSearch);
            BindArea();
            //BindMeterReader();
            BindMeterReading();
            BindBank(cmbWaterUserAgentBankSearch);
            BindChargeType();
            //BindWaterMeterType();
            cmbType.SelectedIndex = 0;

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year,dtNow.Month,1);
            cmbMFYH.SelectedIndex = 0;
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
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "全部";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbChargerWorkName.DataSource = dt;
            cmbChargerWorkName.DisplayMember = "USERNAME";
            cmbChargerWorkName.ValueMember = "LOGINID";
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

        DataTable dtMeterReading=new DataTable();
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
        /// 绑定收款方式
        /// </summary>
        private void BindChargeType()
        {
            DataTable dt = BLLCHARGETYPE.QUERY(" ");
            DataRow dr = dt.NewRow();
            dr["CHARGETYPENAME"] = "";
            dr["CHARGETYPEID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbChargeType.DataSource = dt;
            cmbChargeType.DisplayMember = "CHARGETYPENAME";
            cmbChargeType.ValueMember = "CHARGETYPEID";
        }
        ///// <summary>
        ///// 绑定抄表员
        ///// </summary>
        //private void BindMeterReader()
        //{
        //    DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
        //    DataRow dr = dt.NewRow();
        //    dr["USERNAME"] = "全部";
        //    dr["LOGINID"] = DBNull.Value;
        //    dt.Rows.InsertAt(dr, 0);
        //    cmbMeterReader.DataSource = dt;
        //    cmbMeterReader.DisplayMember = "USERNAME";
        //    cmbMeterReader.ValueMember = "LOGINID";
        //}
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

        //存储统计类型
        string strStaticsName = "";
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

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("收费统计界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("收费统计界面:" + ex.ToString(), MsgType.Error);
            }
        }
        private void LoadData()
        {
            try
            {
                string strFilter = strSeniorFilterHidden;
                if (txtWaterUserNOSearch.Text.Trim() != "")
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim().PadLeft(8, '0') + "'";

                if (txtWaterUserNameSearch.Text.Trim() != "")
                    strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

                if (cmbWaterUserTypeSearch.SelectedValue != null && cmbWaterUserTypeSearch.SelectedValue != DBNull.Value)
                    strFilter += " AND waterUserTypeId='" + cmbWaterUserTypeSearch.SelectedValue.ToString() + "'";

                if (cmbMFYH.SelectedIndex > 0)
                {
                    if (cmbMFYH.SelectedIndex == 1)
                        strFilter += " AND memo='MFYH@'";
                    else if (cmbMFYH.SelectedIndex == 2)
                        strFilter += " AND (MEMO<>'MFYH@' OR MEMO is null) ";
                }

                if (chkZSH.Checked)
                    strFilter += " AND waterUserTypeId<>'0004'";

                if (cmbWaterUserMeterReadingNO.SelectedValue != null && cmbWaterUserMeterReadingNO.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReadingID='" + cmbWaterUserMeterReadingNO.SelectedValue.ToString() + "'";

                if (cmbArea.SelectedValue != null && cmbArea.SelectedValue != DBNull.Value)
                    strFilter += " AND areaId='" + cmbArea.SelectedValue.ToString() + "'";

                if (cmbWaterUserIsAgentSearch.Text != "")
                    strFilter += " AND agentsign='" + cmbWaterUserIsAgentSearch.SelectedIndex.ToString() + "'";

                if (cmbWaterUserAgentBankSearch.SelectedValue != null && cmbWaterUserAgentBankSearch.SelectedValue != DBNull.Value)
                    strFilter += " AND bankId='" + cmbWaterUserAgentBankSearch.SelectedValue.ToString() + "'";

                if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (cmbChargeType.SelectedValue != null && cmbChargeType.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGETYPEID='" + cmbChargeType.SelectedValue.ToString() + "'";

                if (cmbWaterFeeYear.Text != "")
                    strFilter += " AND readMeterRecordYear=" + cmbWaterFeeYear.Text;

                if (cmbWaterFeeMonth.Text != "")
                    strFilter += " AND readMeterRecordMonth=" + cmbWaterFeeMonth.Text;

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                dgList.DataSource = null;

                DataTable dtStastics = BLLWATERFEECHARGE.WaterChargeStatisticsNew(strFilter + strSeniorFilterHidden, cmbType.Text);
                DataTable dtTemp = dtStastics.Copy();
                switch (cmbType.Text)
                {
                    case "收费员":
                        #region 统计信息
                        DataRow dr = dtTemp.Rows.Add();
                        dr["收费员"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["用水量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;
                        

                        object objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按收费员)";
                        break;
                    case "收费方式":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["收费方式"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按收费方式)";
                        break;
                    case "用户类型":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["用户类型"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按用户类型)";
                        break;
                    case "抄表本":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["抄表本"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按抄表本)";
                        break;
                    case "区域":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["区域名称"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按区域)";
                        break;
                    case "抄表员":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["抄表员"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按抄表员)";
                        break;
                    case "银行托收":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["银行托收"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按银行托收)";
                        break;
                    case "托收银行":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["托收银行"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按托收银行)";
                        break;
                    case "用水性质":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["用水性质"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按用水性质)";
                        break;
                    case "用户名":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["用户名"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收金额"] = 0;
                        dr["实收金额"] = 0;
                        dr["余额增减"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum).ToString("F2");

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "收费统计新(按用户名)";
                        break;
                }

                if (dgList.Rows.Count > 0)
                {
                    for (int i = 0; i < dgList.Columns.Count; i++)
                    {
                        //禁止列排序
                        dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dgList.Columns[i].DefaultCellStyle.Format = "0.##";

                        if (dgList.Columns[i].Name == "水费小计")
                            dgList.Columns[i].Visible = false;
                    }
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;
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
            dtPrint.TableName =strStaticsName;
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收费统计模板\" + strStaticsName + ".frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource(strStaticsName).Enabled = true;
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
            dtPrint.TableName = strStaticsName;
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收费统计模板\" + strStaticsName + ".frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource(strStaticsName).Enabled = true;
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
        public  DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            int intCount = dgv.Rows.Count;
            if (strStaticsName == "收费统计新(按收费员)")
                intCount = intCount - 1;
            for (int count = 0; count < intCount; count++)
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

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "12";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }
    }
}
