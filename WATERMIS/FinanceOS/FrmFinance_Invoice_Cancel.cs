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
    public partial class FrmFinance_Invoice_Cancel : Form
    {

        public FrmFinance_Invoice_Cancel()
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

        /// <summary>
        /// 发票ID
        /// </summary>
        public string strInvoicePrintID = "";

        /// <summary>
        /// 收费ID
        /// </summary>
        public string strChargeID = "";

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
        public string strWaterUserID = "", strWaterUserName = "", strWaterUserAddressAndTel = "",
             strWaterUserFPTaxNO = "", strWaterUserFPBankNameAndAccountNO = "",
             strInvoiceType = "", strInvoiceCancel = "", strInvoiceBatchID = "", strInvoiceNO = "", strMemo = "";

        /// <summary>
        /// 待打发票明细
        /// </summary>
        public DataTable dtFPDetail = new DataTable();

        /// <summary>
        /// 发票总金额
        /// </summary>
        public decimal decWorkResolveSumFee = 0;

        private void FrmFinance_Invoice_PrintShow_Load(object sender, EventArgs e)
        {
            //收费记录表：Meter_Charge
            //收费项目表：Meter_WorkResolveFee
            //说明：从Meter_WorkResolveFee表中可以查出所有收费项目

            dgList.AutoGenerateColumns = false;

            BindInvoiceBatch(cmbBatch);

            GetMaxInvoiceNO();

            FillFPMessage();
        }
        private void FillFPMessage()
        {
            txtWaterUserName.Text = strWaterUserName;
            txtWaterUserFPTaxNO.Text = strWaterUserFPTaxNO;
            txtWaterUserAddress.Text = strWaterUserAddressAndTel;
            txtWaterUserBankAccount.Text = strWaterUserFPBankNameAndAccountNO;

            txtCompanyName.Text = strCompanyName;
            txtCompanyFPTaxNO.Text = strCompanyTaxNO;
            txtCompanyAddress.Text = strCompanyAddressAndTel;
            txtCompanyBankNameAndAccountNO.Text = strCompanyBankNameAndAccountNO;
            txtPayee.Text = strCompanyPayee;
            txtChecker.Text = strCompanyChecker;

            dgList.DataSource = dtFPDetail;

            txtCapMoney.Text = RMBToCapMoney.CmycurD(decWorkResolveSumFee);
            txtSumMoney.Text = decWorkResolveSumFee.ToString("F2");

            txtInvoiceNO.Text = strInvoiceNO;

            cmbBatch.SelectedValue = strInvoiceBatchID;

            if (strInvoiceType == "普通发票")
                rbNormal.Checked = true;
            else
                rbZZ.Checked = true;

            txtMemo.Text = strMemo;

            if (strInvoiceCancel == "正常")
            {
                labInvoiceState.Text = "正常";
                toolCancel.Enabled = true;
                toolChangeInvoiceNO.Enabled = true;
            }
                else
                 labInvoiceState.Text=strInvoiceCancel;
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
            if (strInvoicePrintID== "")
            {
                mes.Show("未检测到发票ID,请重新打开此窗体");
                return;
            }
            string strCancelReason="";
            if (toolCancelReason.SelectedIndex == -1)
            {
                mes.Show("请选择作废原因!");
                toolCancelReason.Focus();
                return;
            }
            else if (toolCancelReason.SelectedIndex == 0)
                strCancelReason = "2";
            else if(toolCancelReason.SelectedIndex == 1)
                strCancelReason = "3";

            if (mes.ShowQ("确定要作废此发票吗?") != DialogResult.OK)
                return;

            try
            {
                string strSQL = string.Format(@"BEGIN TRAN 
                            UPDATE Meter_WorkResolveFee_Invoice SET InvoiceCancel='{0}',InvoiceCancelDatetime=getdate(),InvoiceCancelWorkerID='{1}',
                            InvoiceCancelWorkerName='{2}' WHERE InvoicePrintID='{3}' 
                UPDATE Meter_Charge SET INVOICEPRINTSIGN=NULL WHERE CHARGEID='{4}' 
                IF @@ERROR<>0 
                ROLLBACK TRAN  
                ELSE  
                COMMIT TRAN",
                    strCancelReason, strLoginID, strLoginName, strInvoicePrintID, strChargeID);

                if (BllMeter_WorkResolveFee_Invoice_Detail.ExcuteSQL(strSQL) > 0)
                {
                    toolChangeInvoiceNO.Enabled = false;
                    labInvoiceState.Text = toolCancelReason.Text;
                    ((FrmFinance_Invoice_Scrap)Owner).isModify = true;
                    mes.Show("作废成功!");
                }
            }
            catch (Exception ex)
            {
                mes.Show("作废失败,原因:"+ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }

        private void toolChangeInvoiceNO_Click(object sender, EventArgs e)
        {
            if (strInvoicePrintID == "")
                return;
            if (cmbBatch.SelectedValue == null || cmbBatch.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择发票批次!");
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
            txtInvoiceNO.Text = txtInvoiceNO.Text.Trim().PadLeft(8,'0');
            try
            {
                if (mes.ShowQ("确定要变更发票号吗?") == DialogResult.OK)
                {
                    string strSQL = string.Format(@"UPDATE Meter_WorkResolveFee_Invoice SET InvoiceBatchID='{0}',InvoiceBatchName='{1}',InvoiceNO='{2}'
                                ,InvoiceCancelMemo='{4}' WHERE InvoicePrintID='{3}'", cmbBatch.SelectedValue.ToString(), cmbBatch.Text, txtInvoiceNO.Text,
                                    strInvoicePrintID, strLoginName + " 变更发票号");
                    if (BllMeter_WorkResolveFee_Invoice_Detail.ExcuteSQL(strSQL) > 0)
                    {
                        ((FrmFinance_Invoice_Scrap)Owner).isModify = true;
                        mes.Show("变更发票号成功!");
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show("变更失败,原因:"+ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }
    }
}
