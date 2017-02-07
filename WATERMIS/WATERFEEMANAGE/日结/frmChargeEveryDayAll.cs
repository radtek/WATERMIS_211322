using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BLL;
using MODEL;
using BASEFUNCTION;

namespace WATERFEEMANAGE
{
    public partial class frmChargeEveryDayAll : Form
    {
        public frmChargeEveryDayAll()
        {
            InitializeComponent();
        }
        BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        Messages mes = new Messages();

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";
        private void frmChargeEveryDay_Load(object sender, EventArgs e)
        {
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

            this.Text = "收款结算——当前操作员:" + strUserName;

            //object objGroup = AppDomain.CurrentDomain.GetData("GROUPID");
            //if (objGroup != null && objGroup != DBNull.Value)
            //{
            //    //如果非系统管理员，则只能统计自己的收费明细
            //    if (objGroup.ToString() != "0001")
            //    {
            //        cmbChargerWorkName.SelectedValue = strLogID;
            //        cmbChargerWorkName.Enabled = false;
            //    }
            //}
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtStart=new DateTime(dtNow.Year,dtNow.Month,1);
            string strDate = dtStart.ToString("yyyy-MM-dd") + " 00:00:00";
            if (Information.IsDate(strDate))
            {
                dtpStart.Value = Convert.ToDateTime(strDate);
            }

            DateTime dtEnd = dtStart.AddMonths(1).AddDays(-1);
            string strEndDate = dtEnd.ToString("yyyy-MM-dd") + " 23:59:59";
            if (Information.IsDate(strDate))
            {
                dtpEnd.Value = Convert.ToDateTime(strEndDate);
            }

            toolSearch_Click(null, null);
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND IsCashier='1'");
            DataRow dr = dt.NewRow();
            cmbChargerWorkName.DataSource = dt;
            cmbChargerWorkName.DisplayMember = "USERNAME";
            cmbChargerWorkName.ValueMember = "LOGINID";
        }

        //水费收取本次应收，本次实收，本次实收现金，本次实收pos机收费，本次收支，预存前期余额，本次收支，本次收支现金，本次收支pos机，结算余额
        decimal decBCYS = 0, decYSBCSS = 0, decYSBCSSXJ = 0, decYSBCSSPOS = 0, decYSBCSSZHUANZHANG = 0, decYSBCSZ = 0, decYCQQYE = 0,
            decYCBCSZ = 0, decYCBCSZXJ = 0, decYCBCSZPOS = 0, decYCJSYE = 0, decYCBCSZZHUANZHANG = 0;

        //水费单据数量，预存单据数量
        int intYSCount = 0, intYSRECEIPRNOCOUNT = 0, intYCCount = 0;

        private void toolSearch_Click(object sender, EventArgs e)
        {
            //水费收取本次应收，本次实收，本次实收现金，本次实收pos机收费，本次收支，预存前期余额，本次收支，本次收支现金，本次收支pos机，结算余额
            decBCYS = decYSBCSS = decYSBCSSXJ = decYSBCSSPOS =decYSBCSSZHUANZHANG= decYSBCSZ = decYCQQYE 
                = decYCBCSZ = decYCBCSZXJ = decYCBCSZPOS = decYCJSYE = decYCBCSZZHUANZHANG = 0;

            //水费单据数量，预存单据数量
            intYSCount = intYCCount = intYSRECEIPRNOCOUNT = 0;

            string strFilter = "";
            if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
            {
                strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";
            }
            txtWorkerNameSearch.Text = cmbChargerWorkName.Text;
            if (chkChargeDateTime.Checked)
            {
                strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";
                dtpStartSearch.Value = dtpStart.Value;
                dtpEndSearch.Value = dtpEnd.Value;
            }

            //保存结账查询条件，点击结账时用
            txtFilter.Text = strFilter;
            labBCSS.Text ="0 元";

            #region 获取收费冲减余额及实收明细
            DataTable dtWaterMeterList = BLLWATERFEECHARGE.SumWaterFeeCharge(strFilter,strLogID);
            if (dtWaterMeterList.Rows.Count > 0)
            {
                object objYSCOUNT = dtWaterMeterList.Rows[0]["YSCOUNT"];
                if (Information.IsNumeric(objYSCOUNT))
                    intYSCount = Convert.ToInt32(objYSCOUNT);

                object objYSRECEIPTNOCOUNT = dtWaterMeterList.Rows[0]["YSRECEIPTNOCOUNT"];
                if (Information.IsNumeric(objYSRECEIPTNOCOUNT))
                    intYSRECEIPRNOCOUNT = Convert.ToInt32(objYSRECEIPTNOCOUNT);

                object objYSBCYS = dtWaterMeterList.Rows[0]["BCYS"];
                if (Information.IsNumeric(objYSBCYS))
                    decBCYS = Convert.ToDecimal(objYSBCYS);

                object objYSBCSS = dtWaterMeterList.Rows[0]["YSBCSS"];
                if (Information.IsNumeric(objYSBCSS))
                    decYSBCSS = Convert.ToDecimal(objYSBCSS);

                object objYSBCSSXJ = dtWaterMeterList.Rows[0]["YSBCSSXJ"];
                if (Information.IsNumeric(objYSBCSSXJ))
                    decYSBCSSXJ = Convert.ToDecimal(objYSBCSSXJ);

                object objYSBCSSPOS = dtWaterMeterList.Rows[0]["YSBCSSPOS"];
                if (Information.IsNumeric(objYSBCSSPOS))
                    decYSBCSSPOS = Convert.ToDecimal(objYSBCSSPOS);

                object objYSBCSSZHUANZHANG = dtWaterMeterList.Rows[0]["YSBCSSZHUANZHANG"];
                if (Information.IsNumeric(objYSBCSSZHUANZHANG))
                    decYSBCSSZHUANZHANG = Convert.ToDecimal(objYSBCSSZHUANZHANG);

                object objYSBCSZ = dtWaterMeterList.Rows[0]["YSBCSZ"];
                if (Information.IsNumeric(objYSBCSZ))
                    decYSBCSZ = Convert.ToDecimal(objYSBCSZ);

                object objYCCOUNT = dtWaterMeterList.Rows[0]["YCCOUNT"];
                if (Information.IsNumeric(objYCCOUNT))
                    intYCCount = Convert.ToInt32(objYCCOUNT);

                intYSRECEIPRNOCOUNT = intYSRECEIPRNOCOUNT - intYCCount;//减去预存的收据剩下的正好是收费的收据

                object objYCQQYE = dtWaterMeterList.Rows[0]["YCQQYE"];
                if (Information.IsNumeric(objYCQQYE))
                    decYCQQYE = Convert.ToDecimal(objYCQQYE);

                object objYCBCSZ = dtWaterMeterList.Rows[0]["YCBCSZ"];
                if (Information.IsNumeric(objYCBCSZ))
                    decYCBCSZ = Convert.ToDecimal(objYCBCSZ);

                object objYCBCSZXJ = dtWaterMeterList.Rows[0]["YCBCSZXJ"];
                if (Information.IsNumeric(objYCBCSZXJ))
                    decYCBCSZXJ = Convert.ToDecimal(objYCBCSZXJ);

                object objYCBCSZPOS = dtWaterMeterList.Rows[0]["YCBCSZPOS"];
                if (Information.IsNumeric(objYCBCSZPOS))
                    decYCBCSZPOS = Convert.ToDecimal(objYCBCSZPOS);

                object objYCBCSSZHUANZHANG = dtWaterMeterList.Rows[0]["YCBCSSZHUANZHANG"];
                if (Information.IsNumeric(objYCBCSSZHUANZHANG))
                    decYCBCSZZHUANZHANG = Convert.ToDecimal(objYCBCSSZHUANZHANG);

                object objYCJSYE = dtWaterMeterList.Rows[0]["YCJSYE"];
                if (Information.IsNumeric(objYCJSYE))
                    decYCJSYE = Convert.ToDecimal(objYCJSYE);


                object objBCSS = dtWaterMeterList.Rows[0]["BCSS"];
                if (Information.IsNumeric(objBCSS))
                    labBCSS.Text = Convert.ToDecimal(objBCSS).ToString("F2") + " 元";
            }

            labWaterFeeCharge.Text = "发票:" + intYSCount.ToString() + "张," + "收据:" + intYSRECEIPRNOCOUNT.ToString() + "张,应收水费:" + decBCYS.ToString("F2") + "元,余额增减:" + decYSBCSZ.ToString("F2") + "元";
            labYSBCSS.Text = "实收金额:" + decYSBCSS.ToString("F2") + "元(现金:" + decYSBCSSXJ.ToString("F2") + "元;POS机收费:" + decYSBCSSPOS.ToString("F2") + "元;转账汇款:" +
                decYSBCSSZHUANZHANG.ToString("F2") + "元)";

            labYCCharge.Text = "单据数量:" + intYCCount.ToString() + "张,前期余额:" + decYCQQYE.ToString("F2") + "元,结算余额:" + decYCJSYE.ToString("F2") + "元";
            labYCBCSZ.Text = "实收金额:" + decYCBCSZ.ToString("F2") + "元(现金:" + decYCBCSZXJ.ToString("F2") + "元;POS机收费:" + decYCBCSZPOS.ToString("F2") + "元;转账汇款:" +
                decYCBCSZZHUANZHANG.ToString("F2") + "元)";
            #endregion
        }

        private void toolDayCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string strFilter = " AND ISNULL(CHARGECANCEL,'0')='0' ";
                if (txtFilter.Text == "")
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";
                else
                    strFilter += txtFilter.Text;

                MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                MODELWATERFEECHARGE.DAYCHECKSTATE = "1";
                MODELWATERFEECHARGE.DAYCHECKWORKERNAME = strUserName;
                MODELWATERFEECHARGE.DAYCHECKDATETIME = mes.GetDatetimeNow();
                int intCount = BLLWATERFEECHARGE.UpdateDayCheckState(MODELWATERFEECHARGE, strFilter);
                mes.Show("成功审核:" + intCount + "条收费单据");
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        private void toolPrintPreview_Click(object sender, EventArgs e)
        {
            #region
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\日结明细单模板.frx");

                (report1.FindObject("txtYSCOUNT") as FastReport.TextObject).Text = "发票数量:" +intYSCount + "张";
                (report1.FindObject("txtYSSF") as FastReport.TextObject).Text = "应收水费:" + decBCYS.ToString("F2")+"元";
                (report1.FindObject("txtSSSF") as FastReport.TextObject).Text = "实收金额:" + decYSBCSS.ToString("F2") + "元";
                (report1.FindObject("txtSSSFXJ") as FastReport.TextObject).Text = "现金:" + decYSBCSSXJ.ToString("F2") + "元";
                (report1.FindObject("txtSSSFPOS") as FastReport.TextObject).Text = "POS机:" + decYSBCSSPOS.ToString("F2") + "元";
                (report1.FindObject("txtSSSFZHUANZHANG") as FastReport.TextObject).Text = "转账汇款:" + decYSBCSSZHUANZHANG.ToString("F2") + "元";
                (report1.FindObject("txtYEZJ") as FastReport.TextObject).Text = "余额增减:" + decYSBCSZ.ToString("F2") + "元";

                (report1.FindObject("txtYCCount") as FastReport.TextObject).Text = "单据数量:" + intYCCount + "张";
                (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额:" + decYCQQYE.ToString("F2") + "元";
                (report1.FindObject("txtYCSF") as FastReport.TextObject).Text = "预存收费:" + decYCBCSZ.ToString("F2") + "元";
                (report1.FindObject("txtYCSFXJ") as FastReport.TextObject).Text = "现金:" + decYCBCSZXJ.ToString("F2") + "元";
                (report1.FindObject("txtYCSFPOS") as FastReport.TextObject).Text = "POS机:" + decYCBCSZPOS.ToString("F2") + "元";
                (report1.FindObject("txtYCSFZHUANZHANG") as FastReport.TextObject).Text = "转账汇款:" + decYCBCSZZHUANZHANG.ToString("F2") + "元";
                (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额::" + decYCJSYE.ToString("F2") + "元";

                (report1.FindObject("txtJEZJ") as FastReport.TextObject).Text = "金额总计: " + labBCSS.Text;
                (report1.FindObject("txtDateTime") as FastReport.TextObject).Text = "统计时间:" + dtpStartSearch.Value.ToString("yyyy-MM-dd HH:mm:ss") + " 至 " + dtpEndSearch.Value.ToString("yyyy-MM-dd HH:mm:ss");

                (report1.FindObject("txtWorkerName") as FastReport.TextObject).Text = "收 费 员:" + txtWorkerNameSearch.Text;
                report1.Show();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // free resources used by report
                report1.Dispose();
            }
            #endregion
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            #region
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\日结明细单模板.frx");

                (report1.FindObject("txtYSCOUNT") as FastReport.TextObject).Text = "发票数量:" + intYSCount + "张";
                (report1.FindObject("txtYSSF") as FastReport.TextObject).Text = "应收水费:" + decBCYS.ToString("F2") + "元";
                (report1.FindObject("txtSSSF") as FastReport.TextObject).Text = "实收金额:" + decYSBCSS.ToString("F2") + "元";
                (report1.FindObject("txtSSSFXJ") as FastReport.TextObject).Text = "现金:" + decYSBCSSXJ.ToString("F2") + "元";
                (report1.FindObject("txtSSSFPOS") as FastReport.TextObject).Text = "POS机:" + decYSBCSSPOS.ToString("F2") + "元";
                (report1.FindObject("txtSSSFZHUANZHANG") as FastReport.TextObject).Text = "转账汇款:" + decYSBCSSZHUANZHANG.ToString("F2") + "元";
                (report1.FindObject("txtYEZJ") as FastReport.TextObject).Text = "余额增减:" + decYSBCSZ.ToString("F2") + "元";

                (report1.FindObject("txtYCCount") as FastReport.TextObject).Text = "单据数量:" + intYCCount + "张";
                (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额:" + decYCQQYE.ToString("F2") + "元";
                (report1.FindObject("txtYCSF") as FastReport.TextObject).Text = "预存收费:" + decYCBCSZ.ToString("F2") + "元";
                (report1.FindObject("txtYCSFXJ") as FastReport.TextObject).Text = "现金:" + decYCBCSZXJ.ToString("F2") + "元";
                (report1.FindObject("txtYCSFPOS") as FastReport.TextObject).Text = "POS机:" + decYCBCSZPOS.ToString("F2") + "元";
                (report1.FindObject("txtYCSFZHUANZHANG") as FastReport.TextObject).Text = "转账汇款:" + decYCBCSZZHUANZHANG.ToString("F2") + "元";
                (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额::" + decYCJSYE.ToString("F2") + "元";

                (report1.FindObject("txtJEZJ") as FastReport.TextObject).Text = "金额总计: " + labBCSS.Text;
                (report1.FindObject("txtDateTime") as FastReport.TextObject).Text = "统计时间:" + dtpStartSearch.Value.ToString("yyyy-MM-dd HH:mm:ss") + " 至 " + dtpEndSearch.Value.ToString("yyyy-MM-dd HH:mm:ss");

                (report1.FindObject("txtWorkerName") as FastReport.TextObject).Text = "收 费 员:" + txtWorkerNameSearch.Text;

                report1.PrintSettings.ShowDialog = false;
                report1.Prepare();
                report1.Print();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // free resources used by report
                report1.Dispose();
            }
            #endregion
        }
    }
}
