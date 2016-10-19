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
using System.Runtime.InteropServices;

namespace WATERFEEMANAGE
{
    public partial class frmPrintInvoice : Form
    {
        public frmPrintInvoice()
        {
            InitializeComponent();
        }
        #region 发票打印接口相关函数
        /// <summary>
        /// 功能：发票开具初始化
        /// </summary>
        /// <param name="hCurWnd">传入参数：为ERP当前的窗口句柄</param>
        /// <returns></returns>
        [DllImport("InvKey.dll")]
        private static extern bool FPInfoInit(IntPtr hCurWnd);

        /// <summary>
        /// 功能：发票添加
        /// </summary>
        /// <param name="FPClientName">购方名称</param>
        /// <param name="FPClientTaxCode">购方税号</param>
        /// <param name="FPClientBankAccount">购方开户行及账号</param>
        /// <param name="FPClientAddressTel">购方地址电话</param>
        /// <param name="FPSellerBankAccount">销方开户行及账号</param>
        /// <param name="FPSellerAddressTel">销方地址电话</param>
        /// <param name="FPNotes">备注</param>
        /// <param name="FPInvoicer">开票人</param>
        /// <param name="FPChecker">复核人 可以为空</param>
        /// <param name="FPCashier">收款人 可以为空</param>
        /// <param name="FPListName">如不为空，则开具销货清单，应为“（详见销货清单）”</param>
        /// <param name="FPState">0:只导入不开票 1：开票不打印 2：开票并打印</param>
        /// <param name="InvQDState">0：正常开具清单 1：不足8条开具清单</param>
        /// <returns></returns>
        [DllImport("InvKey.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool AddFPData(string FPClientName, string FPClientTaxCode, string FPClientBankAccount, string FPClientAddressTel,
            string FPSellerBankAccount, string FPSellerAddressTel, string FPNotes, string FPInvoicer, string FPChecker, string FPCashier,
            string FPListName, int FPState, int InvQDState);

        /// <summary>
        /// 初始化明细信息,如果要保证总金额不变，传入含税总金额，单价传入0，MXPriceKind传入1，开票软件上显示的是单价（含税）和金额（含税）就可以了
        /// </summary>
        /// <returns></returns>
        [DllImport("InvKey.dll")]
        private static extern bool MXInfoInit();

        /// <summary>
        /// 添加明细
        /// </summary>
        /// <param name="MXGoodsName">商品或劳务名称</param>
        /// <param name="MXStandard">规格型号</param>
        /// <param name="MXUnit">计量单位 如果为空，忽略数量和单价</param>
        /// <param name="MXNumber">数量</param>
        /// <param name="MXPrice">单价</param>
        /// <param name="MXAmount">金额 可以不传，由开票软件计算，如传入应符合计算关系</param>
        /// <param name="MXTaxRate">税率 17、13、4、0等  0.17对应17 0.13对应13 4对应0.04</param>
        /// <param name="MXPriceKind">含税价标志 单价和金额的种类，0为不含税价，1为含税价</param>
        /// <param name="MXTaxAmount">税额 可以不传，由开票软件计算，如传入应符合计算关系</param>
        /// <returns></returns>
        [DllImport("InvKey.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool AddMXData(byte[] MXGoodsName, byte[] MXStandard, byte[] MXUnit, double MXNumber,
            double MXPrice, double MXAmount, int MXTaxRate, int MXPriceKind, double MXTaxAmount);

        /// <summary>
        /// 发票开具
        /// </summary>
        /// <param name="outInvTypeCode">出参:发票代码</param>
        /// <param name="outInvNumber">出参:发票号码</param>
        /// <returns></returns>
        [DllImport("InvKey.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool FPInvoice(StringBuilder outInvTypeCode, StringBuilder outInvNumber);

        /// <summary>
        /// 获取发票数据
        /// </summary>
        /// <param name="outInvTypeCode">出参:发票代码</param>
        /// <param name="outInvNumber">出参:发票号码</param>
        /// <returns></returns>
        [DllImport("InvKey.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool GetFPInfo(StringBuilder outInvTypeCode, StringBuilder outInvNumber);

        /// <summary>
        /// 关闭接口
        /// </summary>
        /// <returns></returns>
        [DllImport("InvKey.dll")]
        private static extern bool CloseInvKey();

        //接口调用规范：
        //1、	将带有注册信息的login.ini配置文件放置到接口软件的根目录下；
        //2、	启动“开票软件”，将界面打开到开票界面；
        //3、	调用FPInfoInit，初始化发票；
        //4、	调用AddFPData，添加发票；
        //5、	调用MXInfoInit，初始化明细，多条明细只调用一次；
        //6、	调用AddMXData，添加明细，添加一条明细调用一次。
        //7、	调用FPInvoice，填开发票。
        //8、	退出程序时，调用CloseInvKey。
        #endregion

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        BLLINVOICEFETCH BLLINVOICEFETCH = new BLLINVOICEFETCH();

        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLoginID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strLoginName = "";

        /// <summary>
        /// 登陆用户所属组ID
        /// </summary>
        private string strGroupID = "";

        private void frmPrintInvoice_Load(object sender, EventArgs e)
        {
            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }
            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strLoginName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            BindWaterMeterType();
            BindInvoiceBatch(cmbBatch);
            //获取新的发票号码
            if (cmbBatch.SelectedValue != null && cmbBatch.SelectedValue != DBNull.Value)
            {
                DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLoginID, cmbBatch.SelectedValue.ToString());
                if (dtNewInvoiceNO.Rows.Count > 0)
                {
                    object objInvoiceBatch = dtNewInvoiceNO.Rows[0]["INVOICEBATCHID"];
                    if (objInvoiceBatch != null && objInvoiceBatch != DBNull.Value)
                    {
                        cmbBatch.SelectedValue = objInvoiceBatch.ToString();
                    }
                    object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                    if (Information.IsNumeric(objInvoiceNO))
                    {
                        txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                    }
                }
            }
        }

        DataTable dtWaterMeterType = new DataTable();

        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType()
        {
            dtWaterMeterType = BLLWATERMETERTYPE.Query("");
            DataRow dr = dtWaterMeterType.NewRow();
            dr["waterMeterTypeValue"] = "请选择";
            dr["waterMeterTypeId"] = DBNull.Value;
            dtWaterMeterType.Rows.InsertAt(dr, 0);
            cmbWaterMeterType.DataSource = dtWaterMeterType;
            cmbWaterMeterType.DisplayMember = "waterMeterTypeValue";
            cmbWaterMeterType.ValueMember = "waterMeterTypeId";
        }
        /// <summary>
        /// 绑定发票批次
        /// </summary>
        /// <param name="cmb"></param>
        private void BindInvoiceBatch(ComboBox cmb)
        {
            DataTable dt = BLLINVOICEFETCH.Query(" AND ISENABLE='1' ORDER BY INVOICEFETCHBATCHID DESC");
            DataView dvInvoiceBatch = dt.DefaultView;
            cmb.DataSource = dvInvoiceBatch.ToTable(true, "INVOICEFETCHBATCHID", "INVOICEBATCHNAME");
            cmb.DisplayMember = "INVOICEBATCHNAME";
            cmb.ValueMember = "INVOICEFETCHBATCHID";

            if (dvInvoiceBatch.Count == 0)
            {
                mes.Show("从发票领用记录表内未检测到可用的发票,发票将无法打印!");
            }
        }

        private void cmbWaterMeterType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
            {
                txtWaterPrice.Text = "0";
                txtExtraChargePrice1.Text = "0";
                txtExtraChargePrice2.Text = "0";


                decimal decWaterTotalNumber = 0;
                string strTrapezoidPrice = "";

                if (!Information.IsNumeric(txtWaterToltalNumber.Text))
                {
                    txtWaterToltalNumber.Text = "0";
                    decWaterTotalNumber = 0;
                }
                else
                {
                    txtWaterToltalNumber.Text = Math.Ceiling(Convert.ToDouble(txtWaterToltalNumber.Text)).ToString();
                    decWaterTotalNumber = Convert.ToDecimal(txtWaterToltalNumber.Text);
                }

                DataRow[] dr = dtWaterMeterType.Select(" waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'");
                if (dr.Length > 0)
                {
                    object objTrapezoidPrice = dr[0]["trapezoidPrice"];
                    if (objTrapezoidPrice != null && objTrapezoidPrice != DBNull.Value)
                        strTrapezoidPrice = objTrapezoidPrice.ToString();
                    else
                    {
                        mes.Show("获取阶梯水价失败,请重新打开窗体!");
                        return;
                    }
                    string[] strWaterMeterRecordTrapePrice = GetAvePrice(decWaterTotalNumber, strTrapezoidPrice);
                    txtWaterPrice.Text = strWaterMeterRecordTrapePrice[0];
                    //计算水费
                    txtWaterTotalCharge.Text = strWaterMeterRecordTrapePrice[2];

                    object objExtraCharge = dr[0]["extraCharge"];
                    if (objExtraCharge != null && objExtraCharge != DBNull.Value)
                    {
                        string[] strAllExtraFee = objExtraCharge.ToString().Split('|');
                        for (int j = 0; j < strAllExtraFee.Length; j++)
                        {
                            string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                            if (strSingleExtraFee[0].Contains("F"))
                            {
                                string strNum = strSingleExtraFee[0].Substring(1, 1);
                                if (strNum == "1")
                                {
                                    txtExtraChargePrice1.Text= strSingleExtraFee[1];
                                }
                                if (strNum == "2")
                                {
                                    txtExtraChargePrice2.Text = strSingleExtraFee[1];
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        ///根据用水类别的阶梯水价获取平均单价和计算过程
        /// </summary>
        /// <returns></returns>
        private string[] GetAvePrice(decimal decTotalNumber, string strTrapePriceString)
        {
            string[] strComputeTrape = new string[3];
            //string strTrapePriceString="0-32:1.52|32-50:2.3|50-80:3.5|80-100:4.5|100-120:6";
            string[] strTrapePrice = strTrapePriceString.Split('|');
            decimal decWaterSum = 0, decWaterTotalNumber = decTotalNumber;
            for (int i = strTrapePrice.Length - 1; i >= 0; i--)
            {
                string[] strJTAndPrice = strTrapePrice[i].Split(':');
                string[] strJT = strJTAndPrice[0].Split('-');
                if (Information.IsNumeric(strJT[0]) && Information.IsNumeric(strJT[1]))
                {
                    if (decTotalNumber > Convert.ToDecimal(strJT[0]) && decTotalNumber <= Convert.ToDecimal(strJT[1]))
                    {
                        decWaterSum += (decTotalNumber - Convert.ToDecimal(strJT[0])) * (Convert.ToDecimal(strJTAndPrice[1]));

                        if (strComputeTrape[1] != null)
                            strComputeTrape[1] += "+(" + decTotalNumber.ToString() + "-" + strJT[0] + ")*" + strJTAndPrice[1];
                        else
                            strComputeTrape[1] += "计算过程:(" + decTotalNumber.ToString() + "-" + strJT[0] + ")*" + strJTAndPrice[1];

                        decTotalNumber = Convert.ToDecimal(strJT[0]);
                        //decTotalNumber = decTotalNumber - Convert.ToDecimal(strJT[0]);
                    }
                    else
                        continue;
                }

            }
            if (decWaterTotalNumber > 0)
                strComputeTrape[0] = (decWaterSum / decWaterTotalNumber).ToString("f3");
            else
                strComputeTrape[0] = "0";
            strComputeTrape[1] += "=" + decWaterSum.ToString() + "÷" + decWaterTotalNumber.ToString() + "=" + strComputeTrape[0];
            strComputeTrape[2] = decWaterSum.ToString("F2");
            return strComputeTrape;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCharge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_MouseClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        frmWaitSearchCanCancel frmWaitSearchCanCancel = new frmWaitSearchCanCancel();
        private void btInvoicePrint_Click(object sender, EventArgs e)
        {

            if (cmbBatch.SelectedValue == null || cmbBatch.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择发票批次!");
                cmbBatch.Focus();
                return;
            }
            if (txtInvoiceNO.Text.Trim() == "")
            {
                mes.Show("请输入起始发票号码!");
                txtInvoiceNO.Focus();
                return;
            }
            else
            {
                if (!Information.IsNumeric(txtInvoiceNO.Text))
                {
                    mes.Show("发票号码只能由数字组成!");
                    txtInvoiceNO.Focus();
                    return;
                }
            }
            if (txtWaterUserName.Text.Trim() == "")
            {
                mes.Show("请输入用户名!");
                txtWaterUserName.Focus();
                return;
            }
            if (!Information.IsNumeric(txtTotalCharge.Text))
            {
                mes.Show("水费总计为零，无法打印发票!!");
                txtTotalCharge.Focus();
                return;
            }

            if (cmbWaterMeterType.SelectedValue == null || cmbWaterMeterType.SelectedValue == DBNull.Value)
            {
                mes.Show("用水性质为空，无法打印发票!!");
                cmbWaterMeterType.Focus();
                return;
            }

            #region 检查起始发票号是否可用
            DataTable dtCheckInvoiceExists = BLLWATERFEECHARGE.QueryChargeView(" AND INVOICENO='" + txtInvoiceNO.Text + "' AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICECANCEL<>'3'");
            if (dtCheckInvoiceExists.Rows.Count > 0)
            {
                if (mes.ShowQ("发票批次为'" + cmbBatch.Text + "'票号为'" + txtInvoiceNO.Text + "'的发票已使用，确定使用此发票号打印吗?") != DialogResult.OK)
                {
                    txtInvoiceNO.Focus();
                    return;
                }
            }
            #endregion

            //发票开具初始化
            bool isSuccess = FPInfoInit(this.Handle);
            if (!isSuccess)
            {
                mes.Show("发票开具初始化失败,请重试!");
                return;
            }
            else
            {
                StringBuilder strInvTypeCode = new StringBuilder();
                StringBuilder strInvNumber = new StringBuilder();
                bool ret = GetFPInfo(strInvTypeCode, strInvNumber);
                if (ret)
                {
                    if (strInvNumber.ToString() != txtInvoiceNO.Text)
                    {
                        mes.Show("当前发票号与税控系统发票号不一致，请设置新的发票号!");
                        txtInvoiceNO.SelectAll();
                        return;
                    }
                }
                else
                {
                    mes.Show("获取税控系统发票号失败,请重试!");
                    return;
                }
            }

            DateTime dtNow = mes.GetDatetimeNow();

            int intReadMeterRecordYear = dtNow.Year, intReadMeterRecordMonth = dtNow.Month, intWaterMeterLastNumber = 0,
                intWaterMeterEndNumber = 0, intTotalNumber = Convert.ToInt32(txtWaterToltalNumber.Text);

            string strwaterUserName = txtWaterUserName.Text, strWaterMeterNo = "", strWaterUserAddress = txtWaterUserAddress.Text,
                strWaterMeterTypeId = cmbWaterMeterType.SelectedValue.ToString(), strWaterMeterTypeName = cmbWaterMeterType.Text;

            decimal decAvePrice = Convert.ToDecimal(txtWaterPrice.Text), decWaterTotalCharge = Convert.ToDecimal(txtWaterTotalCharge.Text),
                decExtraCharge1 = Convert.ToDecimal(txtExtraCharge1.Text), decExtraCharge2 = Convert.ToDecimal(txtExtraCharge2.Text),
                decTotalCharge = Convert.ToDecimal(txtTotalCharge.Text), decExtraChargePrice1 = Convert.ToDecimal(txtExtraChargePrice1.Text),
                decExtraChargePrice2 = Convert.ToDecimal(txtExtraChargePrice2.Text);

            DataTable dtHistoryWaterFeeTemp = BLLWATERFEECHARGE.QueryLS(" AND waterUserId='99999999'");
            DataRow dr = dtHistoryWaterFeeTemp.NewRow();
            dr["waterUserName"] = strwaterUserName;
            dr["waterUserAddress"] = strWaterUserAddress;
            dr["totalNumber"] = intTotalNumber;
            dr["avePrice"] = decAvePrice;
            dr["waterTotalCharge"] = decWaterTotalCharge;
            dr["extraChargePrice1"] = decExtraChargePrice1;
            dr["extraChargePrice2"] = decExtraChargePrice2;
            dr["extraCharge1"] = decExtraCharge1;
            dr["extraCharge2"] = decExtraCharge2;
            //dr["extraTotalCharge"] = decExtraCharge1;
            dr["totalCharge"] = decTotalCharge;
            dr["readMeterRecordYear"] = intReadMeterRecordYear;
            dr["readMeterRecordMonth"] = intReadMeterRecordMonth;
            dr["waterMeterTypeId"] = strWaterMeterTypeId;
            dr["waterMeterTypeName"] = strWaterMeterTypeName;

            dr["TOTALNUMBERCHARGE"] = intTotalNumber;
            dr["WATERTOTALCHARGECHARGE"] = decWaterTotalCharge;
            dr["EXTRACHARGECHARGE2"] = decExtraChargePrice2;
            dr["EXTRACHARGECHARGE1"] = decExtraChargePrice1;
            dr["TOTALCHARGECHARGE"] = decTotalCharge;

            dtHistoryWaterFeeTemp.Rows.Add(dr);

            try
            {
                // /*
                if (decTotalCharge >= 100000)
                {
                #region 发票票额超过9999的
                    int intPerTotalNumber = 0;
                    switch (strWaterMeterTypeId)
                    {
                        case "0001":
                            intPerTotalNumber = 45450;//2.2元
                            break;
                        case "0002":
                            intPerTotalNumber = 39998;//2.5
                            break;
                        case "0003":
                            intPerTotalNumber = 18000;//5.55
                            break;
                        case "0004":
                            intPerTotalNumber = 23250;//4.3
                            break;
                        case "0005":
                            intPerTotalNumber = 23250;//4.3
                            break;
                        case "0006":
                            intPerTotalNumber = 23250;//4.3
                            break;
                        case "0007":
                            intPerTotalNumber = 23250;//4.3
                            break;
                    }

                    int intPrintCount = (int)Math.Ceiling(intTotalNumber / (decimal)intPerTotalNumber);
                    for (int intInvoiceCount = intPrintCount - 1; intInvoiceCount >= 0; intInvoiceCount--)
                    {
                        decimal decWaterTotalChargeInvoice = 0, decExtraCharge1Invoice = 0, decExtraCharge2Invoice = 0, decTotalChargeInvoice;
                        int intPerTotalNumberInvoice = 0;
                        if (intInvoiceCount == intPrintCount - 1)
                        {
                            intPerTotalNumberInvoice = intTotalNumber - (intPrintCount - 1) * intPerTotalNumber;

                            dtHistoryWaterFeeTemp.Rows[0]["TOTALNUMBERCHARGE"] = intPerTotalNumberInvoice;

                            decWaterTotalChargeInvoice = intPerTotalNumberInvoice * decAvePrice;
                            dtHistoryWaterFeeTemp.Rows[0]["WATERTOTALCHARGECHARGE"] = decWaterTotalChargeInvoice.ToString("F2");

                            decExtraCharge1Invoice = intPerTotalNumberInvoice * decExtraChargePrice1;
                            if (decExtraCharge1Invoice == 0)
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = DBNull.Value;
                            else
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = decExtraCharge1Invoice.ToString("F2");

                            decExtraCharge2Invoice = decWaterTotalCharge * decExtraChargePrice2;
                            if (decExtraCharge2Invoice == 0)
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = DBNull.Value;
                            else
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = decExtraCharge2Invoice.ToString("F2");

                            decTotalChargeInvoice = decWaterTotalChargeInvoice + decExtraCharge1Invoice + decExtraCharge2Invoice;
                            dtHistoryWaterFeeTemp.Rows[0]["TOTALCHARGECHARGE"] = decTotalChargeInvoice.ToString("F2");
                        }
                        else
                        {
                            //发票开具初始化
                            bool isSuccess1 = FPInfoInit(this.Handle);
                            if (!isSuccess1)
                            {
                                mes.Show("发票开具初始化失败,请重试!");
                                return;
                            }
                            else
                            {
                                StringBuilder strInvTypeCode = new StringBuilder();
                                StringBuilder strInvNumber = new StringBuilder();
                                bool ret = GetFPInfo(strInvTypeCode, strInvNumber);
                                if (ret)
                                {
                                    if (strInvNumber.ToString() != txtInvoiceNO.Text)
                                    {
                                            bgGetFPNO.RunWorkerAsync();
                                            frmWaitSearchCanCancel = new frmWaitSearchCanCancel();
                                            frmWaitSearchCanCancel.strTip = "准备打印发票号为'" + txtInvoiceNO.Text + "'的发票";
                                            if (frmWaitSearchCanCancel.ShowDialog() == DialogResult.Cancel)
                                                return;
                                    }
                                }
                                else
                                {
                                    mes.Show("获取税控系统发票号失败,请重试!");
                                    return;
                                }
                            }
                            intPerTotalNumberInvoice = intPerTotalNumber;
                            dtHistoryWaterFeeTemp.Rows[0]["waterMeterLastNumber"] = DBNull.Value;

                            dtHistoryWaterFeeTemp.Rows[0]["waterMeterEndNumber"] = DBNull.Value;

                            dtHistoryWaterFeeTemp.Rows[0]["TOTALNUMBERCHARGE"] = intPerTotalNumber;

                            decWaterTotalChargeInvoice = intPerTotalNumber * decAvePrice;
                            dtHistoryWaterFeeTemp.Rows[0]["WATERTOTALCHARGECHARGE"] = decWaterTotalChargeInvoice.ToString("F2");

                            decExtraCharge1Invoice = intPerTotalNumber * decExtraChargePrice1;
                            if (decExtraCharge1Invoice == 0)
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = DBNull.Value;
                            else
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = decExtraCharge1Invoice.ToString("F2");

                            decExtraCharge2Invoice = intPerTotalNumber * decExtraChargePrice2;
                            if (decExtraCharge2Invoice == 0)
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = DBNull.Value;
                            else
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = decExtraCharge2Invoice.ToString("F2");

                            decTotalChargeInvoice = decWaterTotalChargeInvoice + decExtraCharge1Invoice + decExtraCharge2Invoice;
                            dtHistoryWaterFeeTemp.Rows[0]["TOTALCHARGECHARGE"] = decTotalChargeInvoice.ToString("F2");
                        }

                        MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW1 = new MODELCHARGEINVOICEPRINT();
                        MODELCHARGEINVOICEPRINTNEW1.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID("", "CHARGEINVOICEPRINT");
                        //MODELCHARGEINVOICEPRINTNEW1.CHARGEID = objChargeID.ToString();
                        MODELCHARGEINVOICEPRINTNEW1.INVOICECANCEL = "0";
                        MODELCHARGEINVOICEPRINTNEW1.INVOICENO = txtInvoiceNO.Text;
                        MODELCHARGEINVOICEPRINTNEW1.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                        MODELCHARGEINVOICEPRINTNEW1.INVOICEBATCHNAME = cmbBatch.Text;
                        MODELCHARGEINVOICEPRINTNEW1.INVOICEPRINTDATETIME = mes.GetDatetimeNow();

                        MODELCHARGEINVOICEPRINTNEW1.waterMeterNo = strWaterMeterNo;
                        MODELCHARGEINVOICEPRINTNEW1.waterUserName = strwaterUserName;
                        MODELCHARGEINVOICEPRINTNEW1.waterUserAddress = strWaterUserAddress;
                        MODELCHARGEINVOICEPRINTNEW1.readMeterRecordYear = intReadMeterRecordYear;
                        MODELCHARGEINVOICEPRINTNEW1.readMeterRecordMonth = intReadMeterRecordMonth;
                        MODELCHARGEINVOICEPRINTNEW1.waterMeterLastNumber = intWaterMeterLastNumber;
                        MODELCHARGEINVOICEPRINTNEW1.waterMeterEndNumber = intWaterMeterEndNumber;
                        MODELCHARGEINVOICEPRINTNEW1.totalNumber = intPerTotalNumberInvoice;
                        MODELCHARGEINVOICEPRINTNEW1.avePrice = decAvePrice;
                        MODELCHARGEINVOICEPRINTNEW1.waterTotalCharge = decWaterTotalChargeInvoice;
                        MODELCHARGEINVOICEPRINTNEW1.extraCharge1 = decExtraCharge1Invoice;
                        MODELCHARGEINVOICEPRINTNEW1.extraCharge2 = decExtraCharge2Invoice;
                        MODELCHARGEINVOICEPRINTNEW1.totalCharge = decTotalChargeInvoice;
                        MODELCHARGEINVOICEPRINTNEW1.waterMeterTypeId = strWaterMeterTypeId;
                        MODELCHARGEINVOICEPRINTNEW1.waterMeterTypeName = strWaterMeterTypeName;

                        if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW1))
                        {
                            #region 打印发票
                            try
                            {
                                byte[] byNull = Encoding.Unicode.GetBytes("");
                                string strFPMemo = "";//发票备注
                                        strFPMemo = "第" + (intInvoiceCount + 1) + "/" + intPrintCount + "张";

                                if (AddFPData(strwaterUserName, "", "", strWaterUserAddress , "", "", strFPMemo, strLoginName, null, null, null, 2, 0))
                                {
                                    if (MXInfoInit())
                                    {
                                        byte[] byShuiFei = Encoding.Unicode.GetBytes("水费");
                                        byte[] byUnit = Encoding.Unicode.GetBytes("吨");
                                        //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decAvePrice) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decAvePrice) / 1.03, 3, 0, Convert.ToDouble(decAvePrice) * Convert.ToDouble(intTotalNumber)))
                                        if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intPerTotalNumberInvoice), 0, (double)decWaterTotalChargeInvoice, 3, 1, 0))
                                        {

                                        }
                                        else
                                        {
                                            mes.Show("添加发票明细'水费'错误,请重试!");
                                            return;
                                        }
                                        if (decExtraChargePrice2 > 0)
                                        {
                                            byte[] byFujiaFei = Encoding.Unicode.GetBytes("附加费");
                                            if (AddMXData(byFujiaFei, byNull, byUnit, Convert.ToDouble(intPerTotalNumberInvoice), 0, (double)decExtraCharge2Invoice, 3, 1, 0))
                                            //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice2) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice2) * Convert.ToDouble(intTotalNumber)))
                                            //if (AddMXData(byFujiaFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, 0, 3, 0, 0))
                                            {

                                            }
                                            else
                                            {
                                                mes.Show("添加发票明细'附加费'错误,请重试!");
                                                return;
                                            }
                                        }
                                        if (decExtraChargePrice1 > 0)
                                        {
                                            byte[] byWuShuiChuLiFei = Encoding.Unicode.GetBytes("污水处理费");
                                            if (AddMXData(byWuShuiChuLiFei, byNull, byUnit, Convert.ToDouble(intPerTotalNumberInvoice), 0, (double)decExtraCharge1Invoice, 3, 1, 0))
                                            //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice1) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice1) * Convert.ToDouble(intTotalNumber)))
                                            //if (AddMXData(byWuShuiChuLiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, 0, 3, 0, 0))
                                            {
                                            }
                                            else
                                            {
                                                mes.Show("添加发票明细'污水处理费'错误,请重试!");
                                                return;
                                            }
                                        }
                                        StringBuilder strInvTypeCode = new StringBuilder();
                                        StringBuilder strInvNumber = new StringBuilder();
                                        if (!FPInvoice(strInvTypeCode, strInvNumber))
                                        {
                                            mes.Show("发票填开错误,请从税控软件里手动打印号码为'" + txtInvoiceNO.Text + "'的发票!");
                                            return;
                                        }
                                        txtInvoiceNO.Text =(Convert.ToInt64(txtInvoiceNO.Text) + 1).ToString().PadLeft(8, '0');
                                    }
                                    else
                                    {
                                        mes.Show("发票明细初始化错误,请重试!");
                                        return;
                                    }
                                }
                                else
                                {
                                    mes.Show("发票添加错误,请重试!");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                mes.Show("打印发票时失败,请重打此发票。\n原因:" + ex.ToString());
                                log.Write(ex.ToString(), MsgType.Error);
                                return;
                            }
                            #endregion

                            #region 打印发票原来的
                            //DataSet ds = new DataSet();
                            ////DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                            ////DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                            ////dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                            //DataTable dtInvoice = dtHistoryWaterFeeTemp;
                            //dtInvoice.TableName = "普通发票模板";
                            //ds.Tables.Add(dtInvoice.Copy());
                            //FastReport.Report report1 = new FastReport.Report();
                            //try
                            //{
                            //    // load the existing report
                            //    report1.Load(Application.StartupPath + @"\PRINTModel\自定义普通发票模板.frx");
                            //    // register the dataset
                            //    report1.RegisterData(ds);
                            //    report1.GetDataSource("普通发票模板").Enabled = true;
                            //    // run the report
                            //    //report1.Show();
                            //    //report1.Prepare();
                            //    report1.PrintSettings.ShowDialog = false;
                            //    report1.Print();
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                            //finally
                            //{
                            //    // free resources used by report
                            //    report1.Dispose();
                            //}
                            #endregion
                            //try
                            //{
                            //    //更新收费表已打发票标志
                            //    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                            //    MODELWATERFEECHARGE.CHARGEID = MODELCHARGEINVOICEPRINTNEW1.CHARGEID;
                            //    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";
                            //    if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                            //    {
                            //        //dtHistoryWaterFee.Rows[i]["CHARGEINVOICEPRINTID"] = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                            //        //dtHistoryWaterFee.Rows[i]["INVOICEBATCHNAME"] = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                            //        //dtHistoryWaterFee.Rows[i]["INVOICENO"] = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                            //        //dtHistoryWaterFee.Rows[i]["INVOICECANCEL"] = "正常";
                            //        foreach (DataRow drCharge in drCount)
                            //        {
                            //            drCharge["CHARGEINVOICEPRINTID"] = MODELCHARGEINVOICEPRINTNEW1.CHARGEINVOICEPRINTID;
                            //            drCharge["INVOICEBATCHNAME"] = MODELCHARGEINVOICEPRINTNEW1.INVOICEBATCHNAME;
                            //            drCharge["INVOICENO"] = MODELCHARGEINVOICEPRINTNEW1.INVOICENO;
                            //            drCharge["INVOICECANCEL"] = "正常";
                            //            drCharge["INVOICEPRINTSIGN"] = "1";
                            //        }

                            //        //btInvoicePrint.Enabled = false;
                            //        //mes.Show("发票补打成功!新的发票号为'" + MODELCHARGEINVOICEPRINTNEW.INVOICENO + "'");

                            //        #region 打印发票
                            //        DataSet ds = new DataSet();
                            //        //DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                            //        //DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                            //        //dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                            //        DataTable dtInvoice = dtHistoryWaterFeeTemp;
                            //        dtInvoice.TableName = "普通发票模板";
                            //        ds.Tables.Add(dtInvoice.Copy());
                            //        FastReport.Report report1 = new FastReport.Report();
                            //        try
                            //        {
                            //            // load the existing report
                            //            report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                            //            // register the dataset
                            //            report1.RegisterData(ds);
                            //            report1.GetDataSource("普通发票模板").Enabled = true;
                            //            // run the report
                            //            //report1.Show();
                            //            //report1.Prepare();
                            //            report1.PrintSettings.ShowDialog = false;
                            //            report1.Print();
                            //        }
                            //        catch (Exception ex)
                            //        {
                            //            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //        }
                            //        finally
                            //        {
                            //            // free resources used by report
                            //            report1.Dispose();
                            //        }
                            //        #endregion

                            //        //获取新的发票号码
                            //        strStartInvoiceNO = (Convert.ToInt32(strStartInvoiceNO) + 1).ToString().PadLeft(8, '0');
                            //    }
                            //    else
                            //    {
                            //        BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW1.CHARGEID);
                            //        mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，请重新设置发票起始号后继续打印!");
                            //        return;
                            //    }
                            //}
                            //catch (Exception ex)
                            //{
                            //    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW1.CHARGEID);
                            //    mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，原因:" + ex.ToString());
                            //    log.Write(ex.ToString(), MsgType.Error);
                            //    return;
                            //}
                        }
                        else
                        {
                            //BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID);
                            mes.Show("大额发票第'" + (intPrintCount + 1).ToString() + "行'插入发票表失败!");
                            return;
                        }
                    }
                #endregion
                }
                else
                {
                    MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                    MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID("", "CHARGEINVOICEPRINT");
                    //MODELCHARGEINVOICEPRINTNEW.CHARGEID = objChargeID.ToString();
                    MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                    MODELCHARGEINVOICEPRINTNEW.INVOICENO = txtInvoiceNO.Text;
                    MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                    MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatch.Text;
                    MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTDATETIME = mes.GetDatetimeNow();

                    MODELCHARGEINVOICEPRINTNEW.waterUserName = strwaterUserName;
                    MODELCHARGEINVOICEPRINTNEW.waterUserAddress = strWaterUserAddress;
                    MODELCHARGEINVOICEPRINTNEW.readMeterRecordYear = intReadMeterRecordYear;
                    MODELCHARGEINVOICEPRINTNEW.readMeterRecordMonth = intReadMeterRecordMonth;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterLastNumber = intWaterMeterLastNumber;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterEndNumber = intWaterMeterEndNumber;
                    MODELCHARGEINVOICEPRINTNEW.totalNumber = intTotalNumber;
                    MODELCHARGEINVOICEPRINTNEW.avePrice = decAvePrice;
                    MODELCHARGEINVOICEPRINTNEW.waterTotalCharge = decWaterTotalCharge;
                    MODELCHARGEINVOICEPRINTNEW.extraCharge1 = decExtraCharge1;
                    MODELCHARGEINVOICEPRINTNEW.extraCharge2 = decExtraCharge2;
                    MODELCHARGEINVOICEPRINTNEW.totalCharge = decTotalCharge;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterTypeId = strWaterMeterTypeId;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterTypeName = strWaterMeterTypeName;
                    MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTWORKERID = strLoginID;
                    MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTWORKERNAME = strLoginName;

                    if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW))
                    {

                        #region 打印发票
                        try
                        {
                            byte[] byNull = Encoding.Unicode.GetBytes("");
                            string strFPMemo = "";//发票备注
                            //if (drCount.Length > 1)
                            //    strFPMemo = "表本号:" + strMeterReadingNO + ";水表编号:" + strWaterMeterNo;
                            //else
                            //    strFPMemo = "表本号:" + strMeterReadingNO + ";水表编号:" + strWaterMeterNo + "上期读数:" + intWaterMeterLastNumber.ToString() + ";本期读数:" + intWaterMeterEndNumber.ToString();

                            if (AddFPData(strwaterUserName, "", "", strWaterUserAddress, "", "", strFPMemo, strLoginName, null, null, null, 2, 0))
                            {
                                if (MXInfoInit())
                                {
                                    byte[] byShuiFei = Encoding.Unicode.GetBytes("水费");
                                    byte[] byUnit = Encoding.Unicode.GetBytes("吨");
                                    //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decAvePrice) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decAvePrice) / 1.03, 3, 0, Convert.ToDouble(decAvePrice) * Convert.ToDouble(intTotalNumber)))
                                    if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), 0, (double)decWaterTotalCharge, 3, 1, 0))
                                    {

                                    }
                                    else
                                    {
                                        mes.Show("添加发票明细'水费'错误,请重试!");
                                        return;
                                    }
                                    if (decExtraChargePrice2 > 0)
                                    {
                                        byte[] byFujiaFei = Encoding.Unicode.GetBytes("附加费");
                                        if (AddMXData(byFujiaFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), 0, (double)decExtraCharge2, 3, 1, 0))
                                        //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice2) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice2) * Convert.ToDouble(intTotalNumber)))
                                        //if (AddMXData(byFujiaFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, 0, 3, 0, 0))
                                        {

                                        }
                                        else
                                        {
                                            mes.Show("添加发票明细'附加费'错误,请重试!");
                                            return;
                                        }
                                    }
                                    if (decExtraChargePrice1 > 0)
                                    {
                                        byte[] byWuShuiChuLiFei = Encoding.Unicode.GetBytes("污水处理费");
                                        if (AddMXData(byWuShuiChuLiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), 0, (double)decExtraCharge1, 3, 1, 0))
                                        //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice1) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice1) * Convert.ToDouble(intTotalNumber)))
                                        //if (AddMXData(byWuShuiChuLiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, 0, 3, 0, 0))
                                        {
                                        }
                                        else
                                        {
                                            mes.Show("添加发票明细'污水处理费'错误,请重试!");
                                            return;
                                        }
                                    }
                                    StringBuilder strInvTypeCode = new StringBuilder();
                                    StringBuilder strInvNumber = new StringBuilder();
                                    if (!FPInvoice(strInvTypeCode, strInvNumber))
                                    {
                                        mes.Show("发票填开错误,请从税控软件里手动打印号码为'" + txtInvoiceNO.Text + "'的发票!");
                                        return;
                                    }
                                    txtInvoiceNO.Text = (Convert.ToInt64(txtInvoiceNO.Text) + 1).ToString().PadLeft(8, '0');
                                }
                                else
                                {
                                    mes.Show("发票明细初始化错误,请重试!");
                                    return;
                                }
                            }
                            else
                            {
                                mes.Show("发票添加错误,请重试!");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            mes.Show("打印发票时失败,请重新打印。\n原因:" + ex.ToString());
                            log.Write(ex.ToString(), MsgType.Error);
                            return;
                        }
                        #endregion

                        #region 打印发票原来的
                        //DataSet ds = new DataSet();
                        ////DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                        ////DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                        ////dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                        //DataTable dtInvoice = dtHistoryWaterFeeTemp;
                        //dtInvoice.TableName = "普通发票模板";
                        //ds.Tables.Add(dtInvoice.Copy());
                        //FastReport.Report report1 = new FastReport.Report();
                        //try
                        //{
                        //    // load the existing report
                        //    report1.Load(Application.StartupPath + @"\PRINTModel\自定义普通发票模板.frx");
                        //    // register the dataset
                        //    report1.RegisterData(ds);
                        //    report1.GetDataSource("普通发票模板").Enabled = true;
                        //    // run the report
                        //    //report1.Show();
                        //    //report1.Prepare();
                        //    report1.PrintSettings.ShowDialog = false;
                        //    report1.Print();
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        //finally
                        //{
                        //    // free resources used by report
                        //    report1.Dispose();
                        //}
                        #endregion
                        //try
                        //{
                        //    //更新收费表已打发票标志
                        //    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                        //    MODELWATERFEECHARGE.CHARGEID = MODELCHARGEINVOICEPRINTNEW.CHARGEID;
                        //    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";
                        //    if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                        //    {
                        //        //dtHistoryWaterFee.Rows[i]["CHARGEINVOICEPRINTID"] = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                        //        //dtHistoryWaterFee.Rows[i]["INVOICEBATCHNAME"] = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                        //        //dtHistoryWaterFee.Rows[i]["INVOICENO"] = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                        //        //dtHistoryWaterFee.Rows[i]["INVOICECANCEL"] = "正常";
                        //        foreach (DataRow drCharge in drCount)
                        //        {
                        //            drCharge["CHARGEINVOICEPRINTID"] = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                        //            drCharge["INVOICEBATCHNAME"] = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                        //            drCharge["INVOICENO"] = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                        //            drCharge["INVOICECANCEL"] = "正常";
                        //            drCharge["INVOICEPRINTSIGN"] = "1";
                        //        }

                        //        //btInvoicePrint.Enabled = false;
                        //        //mes.Show("发票补打成功!新的发票号为'" + MODELCHARGEINVOICEPRINTNEW.INVOICENO + "'");

                        //        #region 打印发票
                        //        DataSet ds = new DataSet();
                        //        //DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                        //        //DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                        //        //dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                        //        DataTable dtInvoice = dtHistoryWaterFeeTemp;
                        //        dtInvoice.TableName = "普通发票模板";
                        //        ds.Tables.Add(dtInvoice.Copy());
                        //        FastReport.Report report1 = new FastReport.Report();
                        //        try
                        //        {
                        //            // load the existing report
                        //            report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                        //            // register the dataset
                        //            report1.RegisterData(ds);
                        //            report1.GetDataSource("普通发票模板").Enabled = true;
                        //            // run the report
                        //            //report1.Show();
                        //            //report1.Prepare();
                        //            report1.PrintSettings.ShowDialog = false;
                        //            report1.Print();
                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //        finally
                        //        {
                        //            // free resources used by report
                        //            report1.Dispose();
                        //        }
                        //        #endregion

                        //        //获取新的发票号码
                        //        strStartInvoiceNO = (Convert.ToInt32(strStartInvoiceNO) + 1).ToString().PadLeft(8, '0');
                        //    }
                        //    else
                        //    {
                        //        BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                        //        mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，请重新设置发票起始号后继续打印!");
                        //        return;
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                        //    mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，原因:" + ex.ToString());
                        //    log.Write(ex.ToString(), MsgType.Error);
                        //    return;
                        //}
                        //05308488317
                    }
                    //else
                    //{
                    //    //BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID);
                    //    mes.Show("收费单据ID为空，请选择要打印发票的单据!");
                    //    return;
                    //}
                }
            }
            catch (Exception ex)
            {
                mes.Show("发票打印失败,原因:" + ex.ToString());
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
            ////获取新的发票号码
            //DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLoginID);
            //if (dtNewInvoiceNO.Rows.Count > 0)
            //{
            //    object objInvoiceBatch = dtNewInvoiceNO.Rows[0]["INVOICEBATCHID"];
            //    if (objInvoiceBatch != null && objInvoiceBatch != DBNull.Value)
            //    {
            //        cmbBatch.SelectedValue = objInvoiceBatch.ToString();
            //    }
            //    object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
            //    if (Information.IsNumeric(objInvoiceNO))
            //    {
            //        txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
            //    }
            //}
        }

        private void txtWaterToltalNumber_TextChanged(object sender, EventArgs e)
        {
            int intTotalNumber = 0;
            decimal decPrice = 0, decExtraChargePrice1 = 0, decExtraChargePrice2 = 0,
                    decWaterFee = 0, decExtraCharge1 = 0, decExtrCharge2 = 0, decSum = 0;

            if (!Information.IsNumeric(txtWaterToltalNumber.Text))
                txtWaterToltalNumber.Text = "0";

            if (!Information.IsNumeric(txtWaterPrice.Text))
                txtWaterPrice.Text = "0";

            if (!Information.IsNumeric(txtExtraChargePrice1.Text))
                txtExtraChargePrice1.Text = "0";

            if (!Information.IsNumeric(txtExtraChargePrice2.Text))
                txtExtraChargePrice2.Text = "0";

            intTotalNumber = Convert.ToInt32(txtWaterToltalNumber.Text);
            decPrice = Convert.ToDecimal(txtWaterPrice.Text);
            decExtraChargePrice1 = Convert.ToDecimal(txtExtraChargePrice1.Text);
            decExtraChargePrice2 = Convert.ToDecimal(txtExtraChargePrice2.Text);

            decWaterFee = decPrice * intTotalNumber;
            decExtraCharge1 = decExtraChargePrice1 * intTotalNumber;
            decExtrCharge2 = decExtraChargePrice2 * intTotalNumber;
            decSum = decWaterFee + decExtraCharge1 + decExtrCharge2;

            txtWaterTotalCharge.Text = decWaterFee.ToString("F2");
            txtExtraCharge1.Text = decExtraCharge1.ToString("F2");
            txtExtraCharge2.Text = decExtrCharge2.ToString("F2");
            txtTotalCharge.Text = decSum.ToString("F2");
        }

        private void txtWaterTotalCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            //检测是否已经输入了小数点 
            bool IsContainsDot = txt.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
        }

        private void txtWaterToltalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)22)
            {
                e.Handled = true;
            }
        }

        private void txtTotalCharge_TextChanged(object sender, EventArgs e)
        {
            if (Information.IsNumeric(txtTotalCharge.Text))
            {
                if (Convert.ToDecimal(txtTotalCharge.Text) > 0)
                    btInvoicePrint.Enabled = true;
                else
                    btInvoicePrint.Enabled = false;
            }
        }

        private void bgGetFPNO_DoWork(object sender, DoWorkEventArgs e)
        {
            StringBuilder strInvTypeCode = new StringBuilder();
            StringBuilder strInvNumber = new StringBuilder();
            while (strInvNumber.ToString() != txtInvoiceNO.Text)
            {
                bool ret = GetFPInfo(strInvTypeCode, strInvNumber);
            }
        }

        private void bgGetFPNO_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!frmWaitSearchCanCancel.IsDisposed)
                frmWaitSearchCanCancel.DialogResult = DialogResult.OK;
        }
    }
}
