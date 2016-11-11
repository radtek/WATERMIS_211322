using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using BASEFUNCTION;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using MODEL;

namespace FinanceOS
{
    public partial class FrmFinance_Invoice_PrintShow : Form
    {

        public FrmFinance_Invoice_PrintShow()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
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
        private static extern bool AddFPData([MarshalAs(UnmanagedType.LPTStr)] string FPClientName, [MarshalAs(UnmanagedType.LPTStr)] string FPClientTaxCode,
           [MarshalAs(UnmanagedType.LPTStr)] string FPClientBankAccount, [MarshalAs(UnmanagedType.LPTStr)] string FPClientAddressTel,
           [MarshalAs(UnmanagedType.LPTStr)] string FPSellerBankAccount, [MarshalAs(UnmanagedType.LPTStr)] string FPSellerAddressTel,
           [MarshalAs(UnmanagedType.LPTStr)] string FPNotes, [MarshalAs(UnmanagedType.LPTStr)] string FPInvoicer,
           [MarshalAs(UnmanagedType.LPTStr)] string FPChecker, [MarshalAs(UnmanagedType.LPTStr)] string FPCashier,
           [MarshalAs(UnmanagedType.LPTStr)] string FPListName, int FPState, int InvQDState);

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
        private static extern bool AddMXData([MarshalAs(UnmanagedType.LPTStr)] string MXGoodsName, [MarshalAs(UnmanagedType.LPTStr)] string MXStandard,
           [MarshalAs(UnmanagedType.LPTStr)] string MXUnit, double MXNumber,
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
        BLLINVOICEFETCH BLLINVOICEFETCH = new BLLINVOICEFETCH();
        BllMeter_WorkResolveFee_Invoice_Detail BllMeter_WorkResolveFee_Invoice_Detail = new BllMeter_WorkResolveFee_Invoice_Detail();
        Messages mes = new Messages();
        RMBToCapMoney RMBToCapMoney = new RMBToCapMoney();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        GETTABLEID GETTABLEID = new GETTABLEID();

        /// <summary>
        /// 收费ID
        /// </summary>
        public string ChargeID = string.Empty;

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        public string strLoginID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        public string strLoginName = "";

        /// <summary>
        /// 公司名称
        /// </summary>
        public string strCompanyName = "";

        /// <summary>
        /// 公司纳税人识别号
        /// </summary>
        public string strCompanyTaxNO = "";

        /// <summary>
        /// 公司地址和电话
        /// </summary>
        public string strCompanyAddressAndTel = "";

        /// <summary>
        /// 开户行及账号
        /// </summary>
        public string strCompanyBankNameAndAccountNO = "";

        /// <summary>
        /// 收款人
        /// </summary>
        public string strCompanyPayee = "";

        /// <summary>
        /// 复核人
        /// </summary>
        public string strCompanyChecker = "";

        /// <summary>
        /// 用户基础信息
        /// </summary>
        public string strWaterUserID = "", strWaterUserName = "", strWaterUserAddress = "",
             strWaterUserTel = "", strWaterUserFPTaxNO = "", strWaterUserFPBankNameAndAccountNO = "",
                    strTable_Name_CH = "",strFeeDepID="",strFeeDepName="";

        /// <summary>
        /// 待打发票明细
        /// </summary>
        public DataTable dtFPDetail = new DataTable();

        /// <summary>
        /// 本次收费应收总金额，与发票金额比对。如果已打发票金额>=应收总金额,则更新收费表里的发票打印标志。
        /// </summary>
        private decimal decWorkResolveSumFee = 0;

        private void FrmFinance_Invoice_PrintShow_Load(object sender, EventArgs e)
        {
            //收费记录表：Meter_Charge
            //收费项目表：Meter_WorkResolveFee
            //说明：从Meter_WorkResolveFee表中可以查出所有收费项目

            dgList.AutoGenerateColumns = false;
            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                if (dgList.Columns[i].Name == "InvoiceTitle" || dgList.Columns[i].Name == "Units" || dgList.Columns[i].Name == "Quantity" || dgList.Columns[i].Name == "Price")
                    dgList.Columns[i].ReadOnly = false;
                else
                    dgList.Columns[i].ReadOnly = true;
            }

            BindInvoiceBatch(cmbBatch);

            GetMaxInvoiceNO();

            FillFPMessage();
        }
        private void FillFPMessage()
        {
            txtWaterUserName.Text = strWaterUserName;
            txtWaterUserFPTaxNO.Text = strWaterUserFPTaxNO;
            txtWaterUserAddress.Text = strWaterUserAddress + " " + strWaterUserTel;
            txtWaterUserBankAccount.Text = strWaterUserFPBankNameAndAccountNO;

            txtCompanyName.Text = strCompanyName;
            txtCompanyFPTaxNO.Text = strCompanyTaxNO;
            txtCompanyAddress.Text = strCompanyAddressAndTel;
            txtCompanyBankNameAndAccountNO.Text = strCompanyBankNameAndAccountNO;
            txtPayee.Text = strCompanyPayee;
            txtChecker.Text = strCompanyChecker;

            txtInvoiceOpener.Text = strLoginName;

            dgList.DataSource = dtFPDetail;

            decimal decSumMoney = 0;
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                decimal decTaxPercent = 0.03m;
                decimal decTaxMoney = 0;
                decimal decMoney = 0;
                object obj = dgList.Rows[i].Cells["TaxPercent"].Value;
                if (Information.IsNumeric(obj))
                    decTaxPercent = Convert.ToDecimal(obj);
                else
                    dgList.Rows[i].Cells["TaxPercent"].Value = decTaxPercent;

                obj = dgList.Rows[i].Cells["Fee"].Value;
                if (Information.IsNumeric(obj))
                    decMoney = Convert.ToDecimal(obj);

                decTaxMoney = decTaxPercent * decMoney / (1 + decTaxPercent);
                dgList.Rows[i].Cells["TaxMoney"].Value = decTaxMoney.ToString("F4");

                decSumMoney += decMoney;
            }

            decWorkResolveSumFee = decSumMoney;

            txtCapMoney.Text = RMBToCapMoney.CmycurD(decSumMoney);
            txtSumMoney.Text = decSumMoney.ToString("F2");

            if (strFeeDepID == "010003")
            {
                mes.Show("管道安装处费用信息,请确认");
            }
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
                mes.Show("从发票领用记录表内未检测到可用的发票,新发票无法开具!");
            }
        }
        private void cmbBatch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetMaxInvoiceNO();
        }

        /// <summary>
        /// 获取最大发票号
        /// </summary>
        private void GetMaxInvoiceNO()
        {
            //获取新的发票号码
            if (cmbBatch.SelectedValue != null && cmbBatch.SelectedValue != DBNull.Value)
            {
                DataTable dtNewInvoiceNO = BllMeter_WorkResolveFee_Invoice_Detail.GetMaxInvoiceNO_MeterWork(strLoginID, cmbBatch.SelectedValue.ToString());
                if (dtNewInvoiceNO.Rows.Count > 0)
                {
                    object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                    if (Information.IsNumeric(objInvoiceNO))
                    {
                        txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                    }
                }
                else
                    txtInvoiceNO.Text = "00000001";
            }
        }

        private void dgList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //    return;

            //if (e.Button == MouseButtons.Right)
            //{
            //    dgList.ClearSelection();
            //    dgList.CurrentCell = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            //}
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

        private void dgList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "Quantity" || dgList.Columns[e.ColumnIndex].Name == "Price")
            {
                decimal decSumMoney = 0;
                decimal decTaxPercent = 0.03m;
                decimal decTaxMoney = 0;
                decimal decMoney = 0;
                decimal decQuantity = 0;
                decimal decPrice = 0;

                object obj = dgList.Rows[e.RowIndex].Cells["Quantity"].Value;
                if (Information.IsNumeric(obj))
                    decQuantity = Convert.ToDecimal(obj);

                obj = dgList.Rows[e.RowIndex].Cells["Price"].Value;
                if (Information.IsNumeric(obj))
                    decPrice = Convert.ToDecimal(obj);

                decMoney = decQuantity * decPrice;
                dgList.Rows[e.RowIndex].Cells["Fee"].Value = decMoney.ToString("F4");

                obj = dgList.Rows[e.RowIndex].Cells["TaxPercent"].Value;
                if (Information.IsNumeric(obj))
                    decTaxPercent = Convert.ToDecimal(obj);

                for (int i = 0; i < dgList.Rows.Count; i++)
                {
                    obj = dgList.Rows[i].Cells["TaxPercent"].Value;
                    if (Information.IsNumeric(obj))
                        decTaxPercent = Convert.ToDecimal(obj);

                    obj = dgList.Rows[i].Cells["Fee"].Value;
                    if (Information.IsNumeric(obj))
                        decMoney = Convert.ToDecimal(obj);

                    decTaxMoney = decTaxPercent * decMoney / (1 + decTaxPercent);
                    dgList.Rows[i].Cells["TaxMoney"].Value = decTaxMoney.ToString("F4");

                    decSumMoney += decMoney;
                }
                txtCapMoney.Text = RMBToCapMoney.CmycurD(decSumMoney);
                txtSumMoney.Text = decSumMoney.ToString("F2");
            }
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count == 0)
            {
                return;
            }
            dgList.EndEdit();

            if (cmbBatch.SelectedValue == null || cmbBatch.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择发票批次!");
                cmbBatch.Focus();
                return;
            }
            if (txtInvoiceNO.Text.Trim() == "")
            {
                mes.Show("请输入发票号码!");
                txtInvoiceNO.Focus();
                return;
            }
            else
            {
                if (txtInvoiceNO.Text.Length > 8)
                {
                    mes.Show("发票号码长度应小于9位，请确定发票号是否正确!");
                    txtInvoiceNO.Focus();
                    return;
                }
                if (!Information.IsNumeric(txtInvoiceNO.Text))
                {
                    mes.Show("发票号码只能由数字组成!");
                    txtInvoiceNO.Focus();
                    return;
                }
            }
            txtInvoiceNO.Text = txtInvoiceNO.Text.PadLeft(8, '0');

            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                object obj = dgList.Rows[i].Cells["Quantity"].Value;
                if (!Information.IsNumeric(obj))
                {
                    mes.Show("第 " + (i + 1).ToString() + "行 数量不正确,请重新填写!");
                    return;
                }
                else if (Convert.ToDecimal(obj) == 0)
                {
                    mes.Show("第 " + (i + 1).ToString() + "行 数量为零,请重新填写!");
                    return;
                }

                obj = dgList.Rows[i].Cells["Price"].Value;
                if (!Information.IsNumeric(obj))
                {
                    mes.Show("第 " + (i + 1).ToString() + "行 单价不正确,请重新填写!");
                    return;
                }
                else if (Convert.ToDecimal(obj) == 0)
                {
                    mes.Show("第 " + (i + 1).ToString() + "行 单价为零,请重新填写!");
                    return;
                }

                obj = dgList.Rows[i].Cells["Fee"].Value;
                if (!Information.IsNumeric(obj))
                {
                    mes.Show("第 " + (i + 1).ToString() + "行 金额(含税)不正确,请重新填写!");
                    return;
                }
                else if (Convert.ToDecimal(obj) == 0)
                {
                    mes.Show("第 " + (i + 1).ToString() + "行 金额(含税)为零,请重新填写!");
                    return;
                }

                obj = dgList.Rows[i].Cells["TaxPercent"].Value;
                if (!Information.IsNumeric(obj))
                {
                    mes.Show("第 " + (i + 1).ToString() + "行 税率不正确,请重新填写!");
                    return;
                }
                else if (Convert.ToDecimal(obj) == 0)
                {
                    mes.Show("第 " + (i + 1).ToString() + "行 税率为零,请重新填写!");
                    return;
                }
            }

            #region 检查起始发票号是否可用
            DataTable dtCheckInvoiceExists = BllMeter_WorkResolveFee_Invoice_Detail.QueryMeterWorkInvoice(" AND INVOICENO='" + txtInvoiceNO.Text + "' AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICECANCEL<>'3' ");
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
            StringBuilder strInvTypeCode1 = new StringBuilder();
            StringBuilder strInvNumber1 = new StringBuilder();
            bool ret = GetFPInfo(strInvTypeCode1, strInvNumber1);
            if (ret)
            {
                if (strInvNumber1.ToString() != txtInvoiceNO.Text)
                {
                    mes.Show("当前发票号与税控系统发票号不一致，请设置新的发票号!" + Environment.NewLine + "设置发票号:" + txtInvoiceNO.Text + Environment.NewLine + "系统发票号:" + strInvNumber1);
                    txtInvoiceNO.SelectAll();
                    return;
                }
            }
            else
            {
                mes.Show("获取税控系统发票号失败,请重试!");
                return;
            }

            #region 打印发票
            try
            {
                if (AddFPData(strWaterUserName, txtWaterUserFPTaxNO.Text, txtWaterUserBankAccount.Text, txtWaterUserAddress.Text, strCompanyBankNameAndAccountNO,
                                strCompanyAddressAndTel, txtMemo.Text, strLoginName, strCompanyChecker, strCompanyPayee, null, 2, 0))
                {
                    if (MXInfoInit())
                    {
                        for (int i = 0; i < dgList.Rows.Count; i++)
                        {
                            double dbNumber = Convert.ToDouble(dgList.Rows[i].Cells["Quantity"].Value);
                            double dbSumMoney = Convert.ToDouble(dgList.Rows[i].Cells["Fee"].Value);

                            int intTaxPercent = (int)(Convert.ToDecimal(dgList.Rows[i].Cells["TaxPercent"].Value) * 100);

                            string strUnit = "";
                            string strFeeInvoiceTitle = "";
                            object obj = dgList.Rows[i].Cells["InvoiceTitle"].Value;
                            if (obj != null && obj != DBNull.Value)
                                strFeeInvoiceTitle = obj.ToString();

                            obj = dgList.Rows[i].Cells["Units"].Value;
                            if (obj != null && obj != DBNull.Value)
                                strUnit = obj.ToString();

                            if (AddMXData(strFeeInvoiceTitle, "", strUnit, dbNumber, 0, dbSumMoney, intTaxPercent, 1, 0))
                            {

                            }
                            else
                            {
                                mes.Show("添加第 " + (i + 1).ToString() + "行 发票明细'" + strFeeInvoiceTitle + "'错误,请重试!");
                                return;
                            }
                        }
                        StringBuilder strInvTypeCode = new StringBuilder();
                        StringBuilder strInvNumber = new StringBuilder();
                        if (!FPInvoice(strInvTypeCode, strInvNumber))
                        {
                            mes.Show("发票填开错误,请重试!");
                            return;
                        }
                        bool isOK = CloseInvKey();

                        try
                        {
                            //发票打印成功后，开始处理数据库部分
                            ModelMeter_WorkResolveFee_Invoice ModelMeter_WorkResolveFee_Invoice = new ModelMeter_WorkResolveFee_Invoice();
                            ModelMeter_WorkResolveFee_Invoice.InvoicePrintID = GETTABLEID.GetTableID(strLoginID, "Meter_WorkResolveFee_Invoice");
                            ModelMeter_WorkResolveFee_Invoice.ChargeID = ChargeID;
                            ModelMeter_WorkResolveFee_Invoice.InvoiceBatchID = cmbBatch.SelectedValue.ToString();
                            ModelMeter_WorkResolveFee_Invoice.InvoiceBatchName = cmbBatch.Text;
                            ModelMeter_WorkResolveFee_Invoice.InvoiceNO = txtInvoiceNO.Text;
                            ModelMeter_WorkResolveFee_Invoice.WaterUserID = strWaterUserID;
                            ModelMeter_WorkResolveFee_Invoice.WaterUserName = txtWaterUserName.Text;
                            ModelMeter_WorkResolveFee_Invoice.WaterUserAddress = txtWaterUserAddress.Text;
                            ModelMeter_WorkResolveFee_Invoice.WaterUserFPTaxNO = txtWaterUserFPTaxNO.Text;
                            ModelMeter_WorkResolveFee_Invoice.WaterUserFPBankNameAndAccountNO = txtWaterUserBankAccount.Text;
                            ModelMeter_WorkResolveFee_Invoice.Table_Name_CH = strTable_Name_CH;
                            ModelMeter_WorkResolveFee_Invoice.InvoiceFeeDepID = strFeeDepID;
                            ModelMeter_WorkResolveFee_Invoice.InvoiceFeeDepName = strFeeDepName;
                            ModelMeter_WorkResolveFee_Invoice.InvoiceTotalFeeMoney = Convert.ToDecimal(txtSumMoney.Text);
                            ModelMeter_WorkResolveFee_Invoice.CompanyName = strCompanyName;
                            ModelMeter_WorkResolveFee_Invoice.CompanyAddress = strCompanyAddressAndTel;
                            ModelMeter_WorkResolveFee_Invoice.CompanyFPTaxNO = strCompanyTaxNO;
                            ModelMeter_WorkResolveFee_Invoice.CompanyFPBankNameAndAccountNO = strCompanyBankNameAndAccountNO;
                            ModelMeter_WorkResolveFee_Invoice.Payee = strCompanyPayee;
                            ModelMeter_WorkResolveFee_Invoice.Checker = strCompanyChecker;
                            ModelMeter_WorkResolveFee_Invoice.InvoicePrintWorkerID = strLoginID;
                            ModelMeter_WorkResolveFee_Invoice.InvoicePrintWorker = strLoginName;
                            ModelMeter_WorkResolveFee_Invoice.InvoiceType = rbNormal.Checked ? "1" : "2"; //普通发票还是专用发票
                            ModelMeter_WorkResolveFee_Invoice.Memo = txtMemo.Text;
                            if (BllMeter_WorkResolveFee_Invoice_Detail.Insert(ModelMeter_WorkResolveFee_Invoice))
                            {
                                try
                                {
                                    for (int i = 0; i < dgList.Rows.Count; i++)
                                    {
                                        ModelMeter_WorkResolveFee_Invoice_Detail ModelMeter_WorkResolveFee_Invoice_Detail = new ModelMeter_WorkResolveFee_Invoice_Detail();
                                        ModelMeter_WorkResolveFee_Invoice_Detail.InvoicePrintID = ModelMeter_WorkResolveFee_Invoice.InvoicePrintID;
                                        ModelMeter_WorkResolveFee_Invoice_Detail.DetailIndex = i + 1;
                                        ModelMeter_WorkResolveFee_Invoice_Detail.FeeItem = dgList.Rows[i].Cells["FeeItem"].Value.ToString();
                                        ModelMeter_WorkResolveFee_Invoice_Detail.FeeItemInvoiceTitle = dgList.Rows[i].Cells["InvoiceTitle"].Value.ToString();
                                        object objUnit = dgList.Rows[i].Cells["Units"].Value;
                                        if (objUnit != null && objUnit != DBNull.Value)
                                            ModelMeter_WorkResolveFee_Invoice_Detail.Units = objUnit.ToString();
                                        ModelMeter_WorkResolveFee_Invoice_Detail.Quantity = decimal.Parse(dgList.Rows[i].Cells["Quantity"].Value.ToString());
                                        ModelMeter_WorkResolveFee_Invoice_Detail.Price = decimal.Parse(dgList.Rows[i].Cells["Price"].Value.ToString());
                                        ModelMeter_WorkResolveFee_Invoice_Detail.TaxPercent = decimal.Parse(dgList.Rows[i].Cells["TaxPercent"].Value.ToString());
                                        ModelMeter_WorkResolveFee_Invoice_Detail.TaxMoney = decimal.Parse(dgList.Rows[i].Cells["TaxMoney"].Value.ToString());
                                        ModelMeter_WorkResolveFee_Invoice_Detail.TotalMoney = decimal.Parse(dgList.Rows[i].Cells["Fee"].Value.ToString());
                                        if (BllMeter_WorkResolveFee_Invoice_Detail.InsertDetail(ModelMeter_WorkResolveFee_Invoice_Detail))
                                        {
                                            
                                        }
                                        else
                                        {
                                            BllMeter_WorkResolveFee_Invoice_Detail.Delete(ModelMeter_WorkResolveFee_Invoice.InvoicePrintID);
                                            mes.Show("插入发票项目明细失败,请重试");
                                            return;
                                        }
                                    }
                                    try
                                    {
                                        decimal decSumInvoiceSumFee = 0;

                                        string strGetSumFee = @"SELECT SUM(InvoiceTotalFeeMoney) FROM Meter_WorkResolveFee_Invoice WHERE CHARGEID='" + ChargeID + "'";
                                        object objSumFee = BllMeter_WorkResolveFee_Invoice_Detail.GetSingle(strGetSumFee);
                                        if (Information.IsNumeric(objSumFee))
                                            decSumInvoiceSumFee = Convert.ToDecimal(objSumFee);

                                        if (decSumInvoiceSumFee >= decWorkResolveSumFee)
                                        {
                                            string strUpdateInvoiceSign = "UPDATE Meter_Charge SET INVOICEPRINTSIGN='1' WHERE CHARGEID='" + ChargeID + "'";
                                            int intRows = BllMeter_WorkResolveFee_Invoice_Detail.ExcuteSQL(strUpdateInvoiceSign);
                                            if (intRows == 0)
                                            {
                                                mes.Show("更新发票标志失败,请重新打印发票!");
                                                return;
                                            }
                                            toolPrint.Enabled = false;
                                            labInvoiceState.Visible = true;
                                            ((FrmFinance_Invoice_Print)Owner).isModify = true;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        mes.Show("更新发票标志失败,原因:" + ex.Message);
                                        log.Write(ex.ToString(), MsgType.Error);
                                        BllMeter_WorkResolveFee_Invoice_Detail.Delete(ModelMeter_WorkResolveFee_Invoice.InvoicePrintID);
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    mes.Show("插入发票项目明细失败,原因:" + ex.Message);
                                    log.Write(ex.ToString(), MsgType.Error);
                                    BllMeter_WorkResolveFee_Invoice_Detail.Delete(ModelMeter_WorkResolveFee_Invoice.InvoicePrintID);
                                    return;
                                }
                            }
                            else
                            {
                                mes.Show("插入发票记录失败,请补登发票号!");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            mes.Show("插入发票记录失败,请补登发票号!\n原因:" + ex.Message);
                            log.Write(ex.ToString(), MsgType.Error);
                            return;
                        }
                    }
                    else
                    {
                        mes.Show("发票明细初始化错误,请重试!");
                        return;
                    }
                }
                else
                {
                    mes.Show("添加发票基础信息错误,请重试!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show("发票打印错误:" + ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
            #endregion
        }
    }
}
