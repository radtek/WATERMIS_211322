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
using MODEL;
using BASEFUNCTION;
using System.Runtime.InteropServices;

namespace WATERFEEMANAGE
{
    public partial class frmWaterMeterChargeValueAddedPrint : DockContentEx
    {
        public frmWaterMeterChargeValueAddedPrint()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
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

        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENT = new BLLBASE_DEPARTMENT();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLreadMeterRecordCancel BLLreadMeterRecordCancel = new BLLreadMeterRecordCancel();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        BLLINVOICEFETCH BLLINVOICEFETCH = new BLLINVOICEFETCH();
        RMBToCapMoney RMBToCapMoney = new RMBToCapMoney();

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

        /// <summary>
        /// 公司名称
        /// </summary>
        private string strCompanyName = "";

        /// <summary>
        /// 公司纳税人识别号
        /// </summary>
        private string strCompanyTaxNO = "";

        /// <summary>
        /// 公司地址和电话
        /// </summary>
        private string strCompanyAddressAndTel = "";

        /// <summary>
        /// 开户行及账号
        /// </summary>
        private string strCompanyBankNameAndAccountNO = "";

        /// <summary>
        /// 收款人
        /// </summary>
        private string strCompanyPayee = "";

        /// <summary>
        /// 复核人
        /// </summary>
        private string strCompanyChecker = "";

        private void frmWaterMeterChargeCancel_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            dgHistoryWaterFee.AutoGenerateColumns = false;
            dgHistoryWaterFee.Columns["readMeterRecordYearAndMonth"].DefaultCellStyle.Format = "yyyy-MM";

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

            for (int i = 0; i < dgHistoryWaterFee.Columns.Count; i++)
            {
                //隐藏附加费列
                if (dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS1" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS1" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS2" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS2" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS3" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS3" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS4" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS4" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS5" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS5" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS6" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS6" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS7" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS7" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS8" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS8")
                {
                    dgHistoryWaterFee.Columns[i].Visible = false;
                }
            }
            GetExtraFeeName();
            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            txtWaterUserNO.Focus();
            BindInvoiceBatch(cmbBatch);
            BindWaterMeterType();
            GenerateTree();
            GetCompanyFPMes();
            BindChargerName(cmbCharger);
            BindWaterUserType(cmbWaterUserType);
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
                    dgHistoryWaterFee.Columns["extraChargeLS" + (i + 1).ToString()].HeaderText = objExtraFee.ToString();
                    dgHistoryWaterFee.Columns["extraChargePriceLS" + (i + 1).ToString()].HeaderText = objExtraFee.ToString() + "单价";

                    object objExtraChargeState = dt.Rows[i]["extraChargeState"];
                    if (objExtraChargeState != null && objExtraChargeState != DBNull.Value)
                    {
                        if (objExtraChargeState.ToString() == "启用")
                        {
                            dgHistoryWaterFee.Columns["extraChargeLS" + (i + 1).ToString()].Visible = true;
                            dgHistoryWaterFee.Columns["extraChargePriceLS" + (i + 1).ToString()].Visible = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 绑定用户类别
        /// </summary>
        private void BindWaterUserType(ComboBox cmb)
        {
            DataTable dt = BLLwaterUserType.Query("");
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterUserTypeName";
            cmb.ValueMember = "waterUserTypeId";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
        /// 获取公司开票信息
        /// </summary>
        private void GetCompanyFPMes()
        {
            DataTable dtCompany = BLLBASE_DEPARTMENT.QueryDep(" AND departmentID='01'");
            if (dtCompany.Rows.Count > 0)
            {
                object objCompany = dtCompany.Rows[0]["departmentName"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyName = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["FPAddressAndTel"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyAddressAndTel = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["FPTaxNO"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyTaxNO = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["FPBankNameAndAccountNO"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyBankNameAndAccountNO = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["Payee"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyPayee = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["Checker"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyChecker = objCompany.ToString();
            }
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargerName(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
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
            cmbWaterMeterType.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmbWaterMeterType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }

        private DataTable dtMeterReader = new DataTable();
        /// <summary>
        /// 按抄表本、区域、抄表员动态生成抄表本树形结构
        /// </summary>
        private void GenerateTree()
        {
            trMeterReading.Nodes.Clear();
            #region 按抄表员生成抄表本树形结构
            TreeNode tnHeadMeterReader = trMeterReading.Nodes.Add("|无关ID|", "全部抄表员", 0, 1);
            dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是'");
            for (int i = 0; i < dtMeterReader.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object objID = dtMeterReader.Rows[i]["LOGINID"];
                if (objID != null && objID != DBNull.Value)
                {
                    strID = "METERREADER|无关ID| AND meterReaderID='" + objID.ToString() + "'";
                }
                object objName = dtMeterReader.Rows[i]["USERNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
                trMeterReading.SelectedNode = tnHeadMeterReader;
                tnHeadMeterReader.Expand();
            #endregion
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
        frmWaitSearchCanCancel frmWaitSearchCanCancel = new frmWaitSearchCanCancel();
        private void btInvoicePrint_Click(object sender, EventArgs e)
        {
            #region 发票连打-将收费列表内的应收记录打印发票

            if (dgHistoryWaterFee.Rows.Count == 0)
            {
                btInvoicePrint.Enabled = false;
                return;
            }

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

            //获取连打起始号及终止号
            int intStartRow = 0, intEndRow = dtHistoryWaterFee.Rows.Count;
            if (!Information.IsNumeric(txtStartRow.Text))
            {
                mes.Show("请输入连打起始行号!");
                txtStartRow.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtStartRow.Text) < 1)
                {
                    mes.Show("连打起始行号不能小于1!");
                    txtStartRow.Focus();
                    return;
                }
                intStartRow = Convert.ToInt32(txtStartRow.Text);
            }
            if (Information.IsNumeric(txtEndRow.Text))
            {
                if (Convert.ToInt32(txtStartRow.Text) > Convert.ToInt32(txtEndRow.Text))
                {
                    mes.Show("连打起始行号不能大于终止行号!");
                    txtEndRow.Focus();
                    return;
                }
                if (Convert.ToInt32(txtEndRow.Text) < dtHistoryWaterFee.Rows.Count)
                    intEndRow = Convert.ToInt32(txtEndRow.Text);
            }

            txtInvoiceNO.Text = txtInvoiceNO.Text.PadLeft(8, '0');  //8位发票号

            int intEndInoviceNO = Convert.ToInt32(txtInvoiceNO.Text) + intEndRow - intStartRow + 1;  //得到发票终止最大号

            string strStartInvoiceNO = txtInvoiceNO.Text;
            string strEndInvoiceNO = intEndInoviceNO.ToString().PadLeft(8, '0');

            #region 检查起始发票号是否可用
            //DataTable dtCheckInvoiceExists = BLLWATERFEECHARGE.QueryChargeView(" AND INVOICENO='" + txtInvoiceNO.Text + "' AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICECANCEL<>'3'");
            DataTable dtCheckInvoiceExists = BLLWATERFEECHARGE.QueryChargeView(" AND INVOICENO='" + txtInvoiceNO.Text + "' AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICECANCEL<>'3' ");
            if (dtCheckInvoiceExists.Rows.Count > 0)
            {
                if (mes.ShowQ("发票批次为'" + cmbBatch.Text + "'票号为'" + txtInvoiceNO.Text + "'的发票已使用，确定使用此发票号打印吗?") != DialogResult.OK)
                {
                    txtInvoiceNO.Focus();
                    return;
                }
            }
            else
            {
                //DataTable dtInvoiceFetch = BLLINVOICEFETCH.Query(" AND  INVOICEFETCHBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                #region 验证发票是否包含在领取记录里
                //bool isExist = false;
                //for (int i = 0; i < dtInvoiceFetch.Rows.Count; i++)
                //{
                //    long intStartNO = 0, intEndNO = 0;
                //    object obj = dtInvoiceFetch.Rows[i]["INVOICEFETCHSTARTNO"];
                //    if (Information.IsNumeric(obj))
                //    {
                //        intStartNO = Convert.ToInt64(obj);
                //    }
                //    obj = dtInvoiceFetch.Rows[i]["INVOICEFETCHENDNO"];
                //    if (Information.IsNumeric(obj))
                //    {
                //        intEndNO = Convert.ToInt64(obj);
                //    }
                //    if (Convert.ToInt64(txtInvoiceNO.Text) >= intStartNO && Convert.ToInt64(txtInvoiceNO.Text) <= intEndNO)
                //    {
                //        isExist = true;
                //        break;
                //    }
                //}
                //if (!isExist)
                //{
                //    mes.Show("批次为'" + cmbBatch.Text + "'的发票起始号'" + txtInvoiceNO.Text + "'不在领取记录中,请确认发票号码是否正确!");
                //    txtInvoiceNO.Focus();
                //    return;
                //}
                #endregion
            }
            #endregion

            if (mes.ShowQ("确定要打印第'" + intStartRow.ToString() + "'行至第'" + intEndRow.ToString() + "'行水费信息的发票吗？") != DialogResult.OK)
                return;
                //发票开具初始化
                bool isSuccess = FPInfoInit(this.Handle);
                if (!isSuccess)
                {
                    mes.Show("发票开具初始化失败,请重试!");
                    return;
                }

            for (int i = intStartRow - 1; i < intEndRow; i++)
            {
                    StringBuilder strInvTypeCode1 = new StringBuilder();
                    StringBuilder strInvNumber1 = new StringBuilder();
                    bool ret = GetFPInfo(strInvTypeCode1, strInvNumber1);
                    if (ret)
                    {
                        if (strInvNumber1.ToString() != txtInvoiceNO.Text)
                        {
                            if (i == intStartRow - 1)
                            {
                                mes.Show("当前发票号与税控系统发票号不一致，请设置新的发票号!"+Environment.NewLine+"设置发票号:"+txtInvoiceNO.Text+Environment.NewLine+"系统发票号:"+strInvNumber1);
                                txtInvoiceNO.SelectAll();
                                return;
                            }
                            else
                            {
                                bgGetFPNO.RunWorkerAsync();
                                frmWaitSearchCanCancel = new frmWaitSearchCanCancel();
                                frmWaitSearchCanCancel.strTip = "准备打印第" + (i + 1).ToString() + "行，发票号为'" + txtInvoiceNO.Text + "'";
                                if (frmWaitSearchCanCancel.ShowDialog() == DialogResult.Cancel)
                                    return;
                            }
                        }
                    }
                    else
                    {
                        mes.Show("获取税控系统发票号失败,请重试!");
                        return;
                    }

                    object objReadMeterRecordId = dgHistoryWaterFee.Rows[i].Cells["readMeterRecordId"].Value;
                if (objReadMeterRecordId == null || objReadMeterRecordId == DBNull.Value)
                    continue;

                object objPrintState = dgHistoryWaterFee.Rows[i].Cells["PRINTSTATE"].Value;
                if (objPrintState != null && objPrintState != DBNull.Value)
                    if (objPrintState.ToString() == "已打印")
                        return;

                #region 发票明细字段
                int intReadMeterRecordYear = 0, intReadMeterRecordMonth = 0, intWaterMeterLastNumber = 0, intWaterMeterEndNumber = 0, intTotalNumber = 0;
                string strWaterUserID = "", strWaterUserNO = "", strWaterMeterNO = "", strMeterReadingNO = "", strwaterUserName = "", strWaterMeterNo = "",
                    strWaterUserAddress = "", strWaterUserTel = "", strWaterUserTaxNO = "",
                    strWaterUserBankAccountNO = "", strWaterMeterTypeId = "", strWaterMeterTypeName = "", strWaterPositionName = "",
                    strMeterReaderName = "", strMeterReaderTel = "";

                decimal decAvePrice = 0, decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decTotalCharge = 0,
                    decExtraChargePrice1 = 0, decExtraChargePrice2 = 0, decBCSS = 0, decQQYE = 0, decJSYE = 0, decOverDue = 0;

                object obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterNo"].Value;
                if (obj!=null&&obj!=DBNull.Value)
                {
                    strWaterMeterNO = obj.ToString();
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["readMeterRecordYearAndMonth"].Value;
                if (Information.IsDate(obj))
                {
                    intReadMeterRecordYear = Convert.ToDateTime(obj).Year;
                    intReadMeterRecordMonth = Convert.ToDateTime(obj).Month;
                }
                //obj = dgHistoryWaterFee.Rows[i].Cells["readMeterRecordMonth"].Value;
                //if (Information.IsNumeric(obj))
                //{
                //    intReadMeterRecordMonth = Convert.ToInt32(obj);
                //}
                 obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterLastNumber"].Value;
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterLastNumber = Convert.ToInt32(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterEndNumber"].Value;
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterEndNumber = Convert.ToInt32(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["totalNumber"].Value;
                if (Information.IsNumeric(obj))
                {
                    intTotalNumber = Convert.ToInt32(obj);
                    if (intTotalNumber == 0)
                        continue;
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterTotalChargeEND"].Value;
                if (Information.IsNumeric(obj))
                {
                    decWaterTotalCharge = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["extraChargePriceLS1"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraChargePrice1 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["extraChargeLS1"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge1 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["extraChargePriceLS2"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraChargePrice2 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["extraChargeLS2"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge2 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["totalChargeEND"].Value;
                if (Information.IsNumeric(obj))
                {
                    decTotalCharge = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["OVERDUEEND"].Value;
                if (Information.IsNumeric(obj))
                {
                    decOverDue = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterTypeId"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeId = obj.ToString();
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterTypeName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeName = obj.ToString();
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterUserName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strwaterUserName = obj.ToString();
                }

                //object objWaterUserTypeID = dgHistoryWaterFee.Rows[i].Cells["waterUserTypeId"].Value;
                //if (objWaterUserTypeID != null && objWaterUserTypeID != DBNull.Value)
                //{
                //    if (objWaterUserTypeID.ToString() == "0004")//如果是增值税用水，户名、地址、开票信息从基础信息里取出来。
                //    {
                        obj = dgHistoryWaterFee.Rows[i].Cells["WATERUSERID"].Value;
                        if (obj != null && obj != DBNull.Value)
                        {
                            strWaterUserID = obj.ToString();
                            DataTable dtWaterUserMes = BLLwaterUser.QueryUser(" AND WATERUSERID='" + strWaterUserID + "'");
                            if (dtWaterUserMes.Rows.Count > 0)
                            {
                                object objWaterUserMes = dtWaterUserMes.Rows[0]["waterPhone"];
                                if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                                {
                                    strWaterUserTel = objWaterUserMes.ToString();
                                }
                                objWaterUserMes = dtWaterUserMes.Rows[0]["waterUserAddress"];
                                if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                                {
                                    strWaterUserAddress = objWaterUserMes.ToString();
                                }
                                objWaterUserMes = dtWaterUserMes.Rows[0]["FPTaxNO"];
                                if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                                {
                                    strWaterUserTaxNO = objWaterUserMes.ToString();
                                }
                                objWaterUserMes = dtWaterUserMes.Rows[0]["FPBankNameAndAccountNO"];
                                if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                                {
                                    strWaterUserBankAccountNO = objWaterUserMes.ToString();
                                }
                                objWaterUserMes = dtWaterUserMes.Rows[0]["waterUserNO"];
                                if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                                {
                                    strWaterUserNO = objWaterUserMes.ToString();
                                }
                                objWaterUserMes = dtWaterUserMes.Rows[0]["waterUserName"];
                                if (obj != null && obj != DBNull.Value)
                                {
                                    strwaterUserName = objWaterUserMes.ToString();
                                }
                                objWaterUserMes = dtWaterUserMes.Rows[0]["prestore"];
                                if (Information.IsNumeric(objWaterUserMes))
                                {
                                    decQQYE = Convert.ToDecimal(objWaterUserMes);
                                }
                            }
                        }
                //    }
                //}

                //抄表员电话
                obj = dgHistoryWaterFee.Rows[i].Cells["meterReaderID"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    DataRow[] dr = dtMeterReader.Select("loginId='" + obj.ToString() + "'");
                    if (dr.Length > 0)
                    {
                        obj = dr[0]["TELEPHONENO"];
                        if (obj != null && obj != DBNull.Value)
                            strMeterReaderTel = obj.ToString();
                    }
                }
                if (strwaterUserName == "")
                    continue;

                //如果是增值税票，需要提示本次打印的是水费还是污水处理费及附加费，如果是，水费可打印增值税发票，污水费和附加费需要打印普通发票
                bool isZZS = false;
                object objWaterUserTypeID = dgHistoryWaterFee.Rows[i].Cells["waterUserTypeId"].Value;
                if (objWaterUserTypeID != null && objWaterUserTypeID != DBNull.Value)
                {
                    if (objWaterUserTypeID.ToString() == "0004")//如果是增值税用水，户名、地址、开票信息从基础信息里取出来。
                    {
                        isZZS = true;

                    }
                }
                #endregion
                try
                {
                    DateTime dtChargeDateTime = mes.GetDatetimeNow();//获取当前服务器时间

                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLoginID, "WATERFEECHARGE");
                    MODELWATERFEECHARGE.TOTALNUMBERCHARGE = intTotalNumber;
                    MODELWATERFEECHARGE.WATERTOTALCHARGE = decWaterTotalCharge;
                    MODELWATERFEECHARGE.EXTRACHARGECHARGE1 = decExtraCharge1;
                    MODELWATERFEECHARGE.EXTRACHARGECHARGE2 = decExtraCharge2;
                    MODELWATERFEECHARGE.EXTRATOTALCHARGE = decExtraCharge1 + decExtraCharge2;
                    MODELWATERFEECHARGE.OVERDUEMONEY = decOverDue;
                    MODELWATERFEECHARGE.TOTALCHARGE = decTotalCharge;
                    MODELWATERFEECHARGE.CHARGETYPEID = "1";
                    MODELWATERFEECHARGE.CHARGEClASS = "1";//收费类型是正常收取
                    MODELWATERFEECHARGE.CHARGEBCYS = decTotalCharge;
                    MODELWATERFEECHARGE.CHARGEBCSS = decTotalCharge;
                    MODELWATERFEECHARGE.CHARGEYSQQYE = decQQYE;
                    MODELWATERFEECHARGE.CHARGEYSBCSZ = 0;
                    MODELWATERFEECHARGE.CHARGEYSJSYE = decQQYE;
                    MODELWATERFEECHARGE.CHARGEWORKERID = strLoginID;
                    MODELWATERFEECHARGE.CHARGEWORKERNAME = strLoginName;
                    MODELWATERFEECHARGE.CHARGEDATETIME = dtChargeDateTime;

                    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";

                    MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 0;
                    MODELWATERFEECHARGE.RECEIPTNO = null;
                    try
                    {
                        if (BLLWATERFEECHARGE.InsertFP(MODELWATERFEECHARGE))
                        {

                            MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                            MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID(strLoginID, "CHARGEINVOICEPRINT");
                            MODELCHARGEINVOICEPRINTNEW.CHARGEID = MODELWATERFEECHARGE.CHARGEID;
                            MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                            MODELCHARGEINVOICEPRINTNEW.INVOICENO = strStartInvoiceNO;
                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatch.Text;
                            MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTDATETIME =dtChargeDateTime;

                            MODELCHARGEINVOICEPRINTNEW.waterMeterNo = strWaterMeterNo;
                            MODELCHARGEINVOICEPRINTNEW.waterUserName = strwaterUserName;
                            MODELCHARGEINVOICEPRINTNEW.waterUserAddress = strWaterUserAddress;
                            MODELCHARGEINVOICEPRINTNEW.readMeterRecordYear = intReadMeterRecordYear;
                            MODELCHARGEINVOICEPRINTNEW.readMeterRecordMonth = intReadMeterRecordMonth;
                            MODELCHARGEINVOICEPRINTNEW.waterMeterLastNumber = intWaterMeterLastNumber;
                            MODELCHARGEINVOICEPRINTNEW.waterMeterEndNumber = intWaterMeterEndNumber;
                            MODELCHARGEINVOICEPRINTNEW.totalNumber = intTotalNumber;
                            MODELCHARGEINVOICEPRINTNEW.avePrice = decAvePrice;
                            MODELCHARGEINVOICEPRINTNEW.extraChargePrice1 = decExtraChargePrice1;
                            MODELCHARGEINVOICEPRINTNEW.extraChargePrice2 = decExtraChargePrice2;
                            MODELCHARGEINVOICEPRINTNEW.taxRate = 3;
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
                                try
                                {
                                            MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                                            MODELreadMeterRecord.chargeState = "3";
                                            MODELreadMeterRecord.chargeID = MODELWATERFEECHARGE.CHARGEID;

                                            //把未减免前的滞纳金保存到抄表记录表里
                                                MODELreadMeterRecord.OVERDUEMONEY = decOverDue;

                                                MODELreadMeterRecord.readMeterRecordId = objReadMeterRecordId.ToString();
                                                if (BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord))
                                                {
                                                    dgHistoryWaterFee.Rows[i].Cells["PRINTSTATE"].Value = "已打印";
                                                    #region 打印发票
                                                    try
                                                    {
                                                        byte[] byNull = Encoding.Unicode.GetBytes("");
                                                        //string strMemo = "本次实收:" + MODELWATERFEECHARGE.CHARGEBCSS.ToString() + ";前期余额:" + MODELWATERFEECHARGE.CHARGEYSQQYE.ToString() +
                                                        //    ";结算余额:" + MODELWATERFEECHARGE.CHARGEYSQQYE.ToString() + ";滞纳金:" + decOverDue.ToString() + Environment.NewLine + "用户编号:" + strWaterUserNO +
                                                        //     ";上期读数:" + intWaterMeterLastNumber.ToString() + ";本期读数:" + intWaterMeterEndNumber.ToString() +
                                                        //     (strMeterReaderTel == "" ? "" : "" + Environment.NewLine + "抄表员电话:" + strMeterReaderTel);
                                                        
                                                        string strMemo = "用户编号:" + strWaterUserNO;//增值税不打印备注信息

                                                        //if (AddFPData(strwaterUserName, "", "", strWaterUserAddress + strWaterUserTel, "", "", strMemo, strLoginName, null, null, null, 2, 0))
                                                        if (AddFPData(strwaterUserName, strWaterUserTaxNO, strWaterUserBankAccountNO, strWaterUserAddress + strWaterUserTel, strCompanyBankNameAndAccountNO,
                                        strCompanyAddressAndTel, strMemo, strLoginName, strCompanyChecker, strCompanyPayee, null, 2, 0))
                                                        {
                                                            if (MXInfoInit())
                                                            {
                                                                //byte[] byShuiFei = Encoding.Unicode.GetBytes("水费");
                                                                //byte[] byUnit = Encoding.Unicode.GetBytes("吨");
                                                                string strShuiFei = "水费";
                                                                string strUnit = "吨";
                                                                //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decAvePrice) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decAvePrice) / 1.03, 3, 0, Convert.ToDouble(decAvePrice) * Convert.ToDouble(intTotalNumber)))
                                                                //if (decWaterTotalCharge>0)  //如果水费为空，但是附加费或者污水处理费不能空，可以单独打印污水处理费。
                                                                if (AddMXData(strShuiFei, "", strUnit, Convert.ToDouble(intTotalNumber), 0, Convert.ToDouble(decWaterTotalCharge), 3, 1, 0))
                                                                {

                                                                }
                                                                else
                                                                {
                                                                    mes.Show("添加发票明细'水费'错误,请重试!");
                                                                    //回滚发票记录
                                                                    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                    return;
                                                                }
                                                                if (decExtraCharge2 > 0 && !isZZS)   //如果是增值税用户，不打印附加费
                                                                {
                                                                    string strFuJiaFei = "附加费";
                                                                    //byte[] byFujiaFei = Encoding.Unicode.GetBytes("附加费");
                                                                    if (AddMXData(strFuJiaFei, "", strUnit, Convert.ToDouble(intTotalNumber), 0, Convert.ToDouble(decExtraCharge2), 3, 1, 0))
                                                                    //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice2) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice2) * Convert.ToDouble(intTotalNumber)))
                                                                    //if (AddMXData(byFujiaFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, 0, 3, 0, 0))
                                                                    {

                                                                    }
                                                                    else
                                                                    {
                                                                        mes.Show("添加发票明细'附加费'错误,请重试!");
                                                                        //回滚发票记录
                                                                        BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                        return;
                                                                    }
                                                                }
                                                                if (decExtraCharge1 > 0 && !isZZS)  //如果是增值税用户，不打印污水费
                                                                {
                                                                    string strWuShuiChuLiFei = "污水处理费";
                                                                    //byte[] byWuShuiChuLiFei = Encoding.Unicode.GetBytes("污水处理费");
                                                                    if (AddMXData(strWuShuiChuLiFei, "", strUnit, Convert.ToDouble(intTotalNumber), 0, Convert.ToDouble(decExtraCharge1), 3, 1, 0))
                                                                    //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice1) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice1) * Convert.ToDouble(intTotalNumber)))
                                                                    //if (AddMXData(byWuShuiChuLiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, 0, 3, 0, 0))
                                                                    {
                                                                    }
                                                                    else
                                                                    {
                                                                        mes.Show("添加发票明细'污水处理费'错误,请重试!");
                                                                        //回滚发票记录
                                                                        BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                        return;
                                                                    }
                                                                }
                                                                StringBuilder strInvTypeCode = new StringBuilder();
                                                                StringBuilder strInvNumber = new StringBuilder();
                                                                if (!FPInvoice(strInvTypeCode, strInvNumber))
                                                                {
                                                                    mes.Show("发票填开错误,请从税控软件里手动打印号码为'" + txtInvoiceNO + "'的发票!");
                                                                    //回滚发票记录
                                                                    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                    return;
                                                                }
                                                               bool isOK= CloseInvKey();
                                                            }
                                                            else
                                                            {
                                                                mes.Show("发票明细初始化错误,请重试!");
                                                                //回滚发票记录
                                                                BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                return;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            mes.Show("发票添加错误,请重试!");
                                                            //回滚发票记录
                                                            BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                            return;
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        mes.Show("打印第'" + (i + 1).ToString() + "'行发票时失败,请使用'补打发票'功能打印此行发票。\n原因:" + ex.ToString());
                                                        log.Write(ex.ToString(), MsgType.Error);
                                                        return;
                                                    }
                                                    #endregion
                                                }
                                                else
                                                {
                                                    mes.Show("打印第'" + (i + 1).ToString() + "'行时更新抄表记录表!");
                                                    //回滚收费记录
                                                    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                    BLLWATERFEECHARGE.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                    return;
                                                }
                                        //获取新的发票号码
                                        strStartInvoiceNO = (Convert.ToInt32(strStartInvoiceNO) + 1).ToString().PadLeft(8, '0');
                                        txtInvoiceNO.Text = strStartInvoiceNO;
                                }
                                catch (Exception ex)
                                {
                                    mes.Show("打印第'" + (i + 1).ToString() + "'行时更新抄表记录表，原因:" + ex.ToString());
                                    log.Write(ex.ToString(), MsgType.Error);

                                    //回滚收费记录
                                    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                    BLLWATERFEECHARGE.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                    return;
                                }
                            }
                            else
                            {
                                //BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID);
                                mes.Show("收费单据ID为空，请选择要打印发票的单据!");
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show("第'" + (i + 1).ToString() + "'行收费失败，请重新打印发票!");
                        return;
                    }
                }

                catch (Exception ex)
                {
                    mes.Show("打印第'" + (i + 1).ToString() + "'行时失败!原因:" + ex.Message);
                    log.Write("打印发票失败!原因:" + ex.ToString(), MsgType.Error);
                    return;
                }
            }
            #endregion
        }

        /// <summary>
        /// 将一位数字转换成中文大写数字
        /// </summary>
        private string ConvertChinese(string str)
        {
            string cstr = "";
            switch (str)
            {
                case "0": cstr = "零"; break;
                case "1": cstr = "壹"; break;
                case "2": cstr = "贰"; break;
                case "3": cstr = "叁"; break;
                case "4": cstr = "肆"; break;
                case "5": cstr = "伍"; break;
                case "6": cstr = "陆"; break;
                case "7": cstr = "柒"; break;
                case "8": cstr = "捌"; break;
                case "9": cstr = "玖"; break;
            }
            return (cstr);
        }

        private void txtChargeNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(null, null);
            }
        }

        private void dgHistoryWaterFee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            txtStartRow.Text = (e.RowIndex + 1).ToString();
            txtEndRow.Text = txtStartRow.Text;
        }

        /// <summary>
        /// 存储所有查询到的收费记录
        /// </summary>
        DataTable dtHistoryWaterFee = new DataTable();
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode == null)
                return;

            TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
            trMeterReading_AfterSelect(null, ex);
        }
        /// <summary>
        /// 是否是第一次打开窗体标志，如果是第一次打开窗体，不检索数据库中的数据，否则开始检索。
        /// </summary>
        bool isFirstOpen = true;
        private void trMeterReading_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isFirstOpen)
            {
                isFirstOpen = false;
                return;
            }
            if (e.Node == null)
                return;
            string strNodeID = e.Node.Name;
            string[] strNodeIDSpit = strNodeID.Split('|');
            RefreshData(strNodeIDSpit);
        }
        Thread TD;
        private void RefreshData(string[] strNodeID)
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                LoadData(strNodeID);
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("发票预打界面:" + ex.ToString(), MsgType.Error);
                //mes.Show(ex.Message);
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
                log.Write("发票预打界面:" + ex.ToString(), MsgType.Error);
            }
        }
        private void LoadData(string[] strNodeID)
        {
            try
            {
                txtInvoiceNO.Clear();

                string strFilter = strNodeID[2] + strSeniorFilterHidden ;

                if (txtWaterUserNO.Text.Trim() != "")
                {
                    if (txtWaterUserNO.Text.Length < 6)
                        strFilter += " AND waterUserNO='U" + txtWaterUserNO.Text.PadLeft(5, '0') + "'";
                    else
                        strFilter += " AND waterUserNO='" + txtWaterUserNO.Text + "'";
                }
                if (txtWaterUserName.Text.Trim() != "")
                {
                    strFilter += " AND waterUserName LIKE '%" + txtWaterUserName.Text + "%'";
                }

                if (cmbCharger.SelectedValue != null && cmbCharger.SelectedValue != DBNull.Value)
                    strFilter += " AND chargerID='" + cmbCharger.SelectedValue.ToString() + "'";

                if (cmbAreaNOS.SelectedIndex > 0)
                    strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
                if (cmbPianNOS.SelectedIndex > 0)
                    strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
                if (cmbDuanNOS.SelectedIndex > 0)
                    strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

                if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (cmbWaterUserType.SelectedValue != null && cmbWaterUserType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterUserTypeId='" + cmbWaterUserType.SelectedValue.ToString() + "'";

                if (txtYearAndMonth.Text.Length == 6)
                {
                    string strYear = txtYearAndMonth.Text.Substring(0, 4), strMonth = txtYearAndMonth.Text.Substring(4, 2);
                    //查询条件
                    strFilter += " AND  readMeterRecordYear=" + strYear + " AND readMeterRecordMonth=" + strMonth;
                }

                //获取新的发票号码
                if (cmbBatch.SelectedValue != null && cmbBatch.SelectedValue != DBNull.Value)
                {
                    DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLoginID, cmbBatch.SelectedValue.ToString());
                    if (dtNewInvoiceNO.Rows.Count > 0)
                    {
                        object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                        if (Information.IsNumeric(objInvoiceNO))
                        {
                            txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                        }
                    }
                }
                //获取新的收据号码,8位收据号
                DataTable dtNewReceriptNO = BLLWATERFEECHARGE.GetMaxReceiptNO(strLoginID);
                if (dtNewReceriptNO.Rows.Count > 0)
                {
                    object objReceiptNO = dtNewReceriptNO.Rows[0]["RECEIPTNO"];
                    if (Information.IsNumeric(objReceiptNO))
                    {
                        txtReceiptNO.Text = (Convert.ToInt64(objReceiptNO) + 1).ToString().PadLeft(8, '0');
                    }
                }

                //从应收里查询增值税待开发票的
                dtHistoryWaterFee = BLLreadMeterRecord.QueryYSDetailByWaterMeter(strFilter + " AND checkState='1' AND chargeState='1' "+
                    "AND totalChargeEND>0  ORDER BY pianNO,areaNO,duanNO");
                dgHistoryWaterFee.DataSource = dtHistoryWaterFee;
                if (dtHistoryWaterFee.Rows.Count == 0)
                {
                    btInvoicePrint.Enabled = false;
                    btPrintReceipt.Enabled = false;
                }
                else
                {
                    btInvoicePrint.Enabled = true;
                    btPrintReceipt.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Write("发票预打界面:" + ex.ToString(), MsgType.Error);
                //mes.Show(ex.Message);
            }
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            if (txtYearAndMonth.Text.Trim() == "")
            {
                DateTime dtNow = mes.GetDatetimeNow();
                txtYearAndMonth.Text = dtNow.ToString("yyyyMM");
                return;
            }
            if (txtYearAndMonth.Text.Length != 6)
            {
                mes.Show("系统检测到月份格式不正确,请重新打开窗体!");
                return;
            }
            string strDate = txtYearAndMonth.Text.Substring(0, 4) + "-" + txtYearAndMonth.Text.Substring(4, 2) + "-" + "01";
            if (Information.IsDate(strDate))
            {
                txtYearAndMonth.Text = Convert.ToDateTime(strDate).AddMonths(1).ToString("yyyyMM");
            }
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            if (txtYearAndMonth.Text.Trim() == "")
            {
                DateTime dtNow = mes.GetDatetimeNow();
                txtYearAndMonth.Text = dtNow.ToString("yyyyMM");
                return;
            }
            if (txtYearAndMonth.Text.Length != 6)
            {
                mes.Show("系统检测到月份格式不正确,请重新打开窗体!");
                return;
            }
            string strDate = txtYearAndMonth.Text.Substring(0, 4) + "-" + txtYearAndMonth.Text.Substring(4, 2) + "-" + "01";
            if (Information.IsDate(strDate))
            {
                txtYearAndMonth.Text = Convert.ToDateTime(strDate).AddMonths(-1).ToString("yyyyMM");
            }
        }

        private void dgHistoryWaterFee_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void txtStartRow_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void frmWaterMeterChargeInvoicePrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseInvKey();
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "1";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
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

        private void cmbBatch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //获取新的发票号码
            if (cmbBatch.SelectedValue != null && cmbBatch.SelectedValue != DBNull.Value)
            {
                DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLoginID, cmbBatch.SelectedValue.ToString());
                if (dtNewInvoiceNO.Rows.Count > 0)
                {
                    object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                    if (Information.IsNumeric(objInvoiceNO))
                    {
                        txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                    }
                }
            }
        }

        private void txtYearAndMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                txtYearAndMonth.Clear();
        }

        private void btPrintReceipt_Click(object sender, EventArgs e)
        {
            #region 收据连打-将收费列表内的应收记录打印收据

            if (dgHistoryWaterFee.Rows.Count == 0)
            {
                btPrintReceipt.Enabled = false;
                return;
            }
                if (txtReceiptNO.Text.Trim() == "")
                {
                    mes.Show("请输入收据号!");
                    txtReceiptNO.Focus();
                    return;
                }
                if (!Information.IsNumeric(txtReceiptNO.Text))
                {
                    mes.Show("收据号只能由数字组成!");
                    txtReceiptNO.SelectAll();
                    return;
                }
                txtReceiptNO.Text = txtReceiptNO.Text.PadLeft(8, '0');
                if (BLLWATERFEECHARGE.IsExistReceiptNO(txtReceiptNO.Text))
                {
                    if (mes.ShowQ("系统检测到号码为'" + txtReceiptNO.Text + "'的收据已使用,确定使用此号码吗?") != DialogResult.OK)
                    {
                        txtReceiptNO.SelectAll();
                        return;
                    }
                }


            //获取连打起始号及终止号
            int intStartRow = 0, intEndRow = dtHistoryWaterFee.Rows.Count;
            if (!Information.IsNumeric(txtStartRow.Text))
            {
                mes.Show("请输入连打起始行号!");
                txtStartRow.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtStartRow.Text) < 1)
                {
                    mes.Show("连打起始行号不能小于1!");
                    txtStartRow.Focus();
                    return;
                }
                intStartRow = Convert.ToInt32(txtStartRow.Text);
            }
            if (Information.IsNumeric(txtEndRow.Text))
            {
                if (Convert.ToInt32(txtStartRow.Text) > Convert.ToInt32(txtEndRow.Text))
                {
                    mes.Show("连打起始行号不能大于终止行号!");
                    txtEndRow.Focus();
                    return;
                }
                if (Convert.ToInt32(txtEndRow.Text) < dtHistoryWaterFee.Rows.Count)
                    intEndRow = Convert.ToInt32(txtEndRow.Text);
            }

            txtReceiptNO.Text = txtReceiptNO.Text.PadLeft(8, '0');  //8位发票号

            //int intEndInoviceNO = Convert.ToInt32(txtReceiptNO.Text) + intEndRow - intStartRow + 1;  //得到发票终止最大号

            string strStartInvoiceNO = txtReceiptNO.Text;
            //string strEndInvoiceNO = intEndInoviceNO.ToString().PadLeft(8, '0');

            if (mes.ShowQ("确定要预收第'" + intStartRow.ToString() + "'行至第'" + intEndRow.ToString() + "'行水费信息并打印收据吗？") != DialogResult.OK)
                return;

            for (int i = intStartRow - 1; i < intEndRow; i++)
            {
                object objReadMeterRecordId = dtHistoryWaterFee.Rows[i]["readMeterRecordId"];
                if (objReadMeterRecordId == null || objReadMeterRecordId == DBNull.Value)
                    continue;

                object objPrintState = dgHistoryWaterFee.Rows[i].Cells["PRINTSTATE"].Value;
                if (objPrintState != null && objPrintState != DBNull.Value)
                    if (objPrintState.ToString() == "已打印")
                        return;

                #region 明细字段
                int intReadMeterRecordYear = 0, intReadMeterRecordMonth = 0, intWaterMeterLastNumber = 0, intWaterMeterEndNumber = 0, intTotalNumber = 0;
                string strWaterUserID = "", strWaterUserNO = "", strWaterMeterNO = "", strMeterReadingNO = "", strwaterUserName = "", strWaterMeterNo = "",
                    strWaterUserAddress = "", strWaterUserTel = "", strWaterUserTaxNO = "",
                    strWaterUserBankAccountNO = "", strWaterMeterTypeId = "", strWaterMeterTypeName = "", strWaterPositionName = "",
                    strMeterReaderName = "", strMeterReaderTel = "";

                decimal decAvePrice = 0, decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decTotalCharge = 0,
                    decExtraChargePrice1 = 0, decExtraChargePrice2 = 0, decBCSS = 0, decQQYE = 0, decJSYE = 0, decOverDue = 0;


                object obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterNo"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterNO = obj.ToString();
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["readMeterRecordYearAndMonth"].Value;
                if (Information.IsDate(obj))
                {
                    intReadMeterRecordYear = Convert.ToDateTime(obj).Year;
                    intReadMeterRecordMonth = Convert.ToDateTime(obj).Month;
                }
                //obj = dgHistoryWaterFee.Rows[i].Cells["readMeterRecordMonth"].Value;
                //if (Information.IsNumeric(obj))
                //{
                //    intReadMeterRecordMonth = Convert.ToInt32(obj);
                //}
                obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterLastNumber"].Value;
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterLastNumber = Convert.ToInt32(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterEndNumber"].Value;
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterEndNumber = Convert.ToInt32(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["totalNumber"].Value;
                if (Information.IsNumeric(obj))
                {
                    intTotalNumber = Convert.ToInt32(obj);
                    if (intTotalNumber == 0)
                        continue;
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterTotalChargeEND"].Value;
                if (Information.IsNumeric(obj))
                {
                    decWaterTotalCharge = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["extraChargePriceLS1"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraChargePrice1 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["extraChargeLS1"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge1 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["extraChargePriceLS2"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraChargePrice2 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["extraChargeLS2"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge2 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["totalChargeEND"].Value;
                if (Information.IsNumeric(obj))
                {
                    decTotalCharge = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["OVERDUEEND"].Value;
                if (Information.IsNumeric(obj))
                {
                    decOverDue = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterTypeId"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeId = obj.ToString();
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterMeterTypeName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeName = obj.ToString();
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterUserNO"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterUserNO = obj.ToString();
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterUserName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strwaterUserName = obj.ToString();
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["waterUserAddress"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterUserAddress = obj.ToString();
                }
                obj = dgHistoryWaterFee.Rows[i].Cells["meterReaderName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strMeterReaderName = obj.ToString();
                }
                DataTable dtRecord = dtHistoryWaterFee.Clone();
                DataRow dataRow = (dgHistoryWaterFee.Rows[i].DataBoundItem as DataRowView).Row;
                dtRecord.ImportRow(dataRow);

                //抄表员电话
                obj = dgHistoryWaterFee.Rows[i].Cells["meterReaderID"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    DataRow[] dr = dtMeterReader.Select("loginId='" + obj.ToString() + "'");
                    if (dr.Length > 0)
                    {
                        obj = dr[0]["TELEPHONENO"];
                        if (obj != null && obj != DBNull.Value)
                            strMeterReaderTel = obj.ToString();
                    }
                }

                #endregion
                try
                {
                    DateTime dtChargeDateTime = mes.GetDatetimeNow();//获取当前服务器时间

                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLoginID, "WATERFEECHARGE");
                    MODELWATERFEECHARGE.TOTALNUMBERCHARGE = intTotalNumber;
                    MODELWATERFEECHARGE.WATERTOTALCHARGE = decWaterTotalCharge;
                    MODELWATERFEECHARGE.EXTRACHARGECHARGE1 = decExtraCharge1;
                    MODELWATERFEECHARGE.EXTRACHARGECHARGE2 = decExtraCharge2;
                    MODELWATERFEECHARGE.EXTRATOTALCHARGE = decExtraCharge1 + decExtraCharge2;
                    MODELWATERFEECHARGE.OVERDUEMONEY = decOverDue;
                    MODELWATERFEECHARGE.TOTALCHARGE = decTotalCharge;
                    MODELWATERFEECHARGE.CHARGETYPEID = "1";
                    MODELWATERFEECHARGE.CHARGEClASS = "1";//收费类型是正常收取
                    MODELWATERFEECHARGE.CHARGEBCYS = decTotalCharge;
                    MODELWATERFEECHARGE.CHARGEBCSS = decTotalCharge;
                    MODELWATERFEECHARGE.CHARGEYSQQYE = decQQYE;
                    MODELWATERFEECHARGE.CHARGEYSBCSZ = 0;
                    MODELWATERFEECHARGE.CHARGEYSJSYE = decQQYE;
                    MODELWATERFEECHARGE.CHARGEWORKERID = strLoginID;
                    MODELWATERFEECHARGE.CHARGEWORKERNAME = strLoginName;
                    MODELWATERFEECHARGE.CHARGEDATETIME = dtChargeDateTime;

                    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";

                    MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 1;
                    MODELWATERFEECHARGE.RECEIPTNO = strStartInvoiceNO;
                    try
                    {
                        if (BLLWATERFEECHARGE.InsertSJ(MODELWATERFEECHARGE))
                        {
                                try
                                {
                                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                                    MODELreadMeterRecord.chargeState = "3";
                                    MODELreadMeterRecord.chargeID = MODELWATERFEECHARGE.CHARGEID;

                                    //把未减免前的滞纳金保存到抄表记录表里
                                    MODELreadMeterRecord.OVERDUEMONEY = decOverDue;

                                    MODELreadMeterRecord.readMeterRecordId = objReadMeterRecordId.ToString();
                                    if (BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord))
                                    {
                                        dgHistoryWaterFee.Rows[i].Cells["PRINTSTATE"].Value = "已打印";
                                            #region 打印收据
                                            DataSet ds = new DataSet();
                                            DataTable dtRecordTemp = dtRecord.Clone();
                                            dtRecordTemp.Columns["readMeterRecordYearAndMonth"].DataType = typeof(string);
                                            for (int j = 0; j < dtRecord.Rows.Count; j++)
                                            {
                                                dtRecordTemp.ImportRow(dtRecord.Rows[j]);
                                            }

                                            for (int j = 0; j < dtRecordTemp.Rows.Count; j++)
                                            {
                                                object objYearAndMonth = dtRecordTemp.Rows[j]["readMeterRecordYearAndMonth"];
                                                if (Information.IsDate(objYearAndMonth))
                                                    dtRecordTemp.Rows[j]["readMeterRecordYearAndMonth"] = Convert.ToDateTime(objYearAndMonth).ToString("yyyy-MM");
                                            }
                                            dtRecordTemp.TableName = "营业坐收收据模板";
                                            ds.Tables.Add(dtRecordTemp);
                                            FastReport.Report report1 = new FastReport.Report();
                                            try
                                            {
                                                // load the existing report
                                                report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\营业坐收收据模板.frx");

                                                (report1.FindObject("Cell65") as FastReport.Table.TableCell).Text = dtChargeDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                                                (report1.FindObject("Cell45") as FastReport.Table.TableCell).Text =strWaterUserNO;
                                                (report1.FindObject("Cell43") as FastReport.Table.TableCell).Text = strwaterUserName;
                                                (report1.FindObject("Cell48") as FastReport.Table.TableCell).Text =strWaterUserAddress;
                                                (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额:" + decQQYE.ToString("F2");
                                                (report1.FindObject("txtBCSF") as FastReport.TextObject).Text = "水费合计:" + decTotalCharge.ToString("F2");

                                                (report1.FindObject("txtBCJF") as FastReport.TextObject).Text = "本次实收:    " + decTotalCharge.ToString("F2");
                                                (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额:" + decQQYE.ToString("F2");

                                                    (report1.FindObject("Cell63") as FastReport.Table.TableCell).Text = strLoginName;

                                                (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = txtReceiptNO.Text;
                                                (report1.FindObject("Cell82") as FastReport.Table.TableCell).Text =strMeterReaderName;
                                                (report1.FindObject("Cell84") as FastReport.Table.TableCell).Text =strMeterReaderTel;

                                                string strCapMoney = RMBToCapMoney.CmycurD(decTotalCharge.ToString("F2"));
                                                    (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = strCapMoney;
                                                // register the dataset
                                                report1.RegisterData(ds);
                                                report1.GetDataSource("营业坐收收据模板").Enabled = true;
                                                //report1.Show();
                                                report1.PrintSettings.ShowDialog = false;
                                                report1.Prepare();
                                                report1.Print();

                                                //获取新的收据号码,8位收据号
                                                if (Information.IsNumeric(strStartInvoiceNO))
                                                {
                                                    strStartInvoiceNO = (Convert.ToInt64(txtReceiptNO.Text) + 1).ToString().PadLeft(8, '0');
                                                    txtReceiptNO.Text = (Convert.ToInt64(txtReceiptNO.Text) + 1).ToString().PadLeft(8, '0');
                                                }
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
                                    else
                                    {
                                        mes.Show("打印第'" + (i + 1).ToString() + "'行时更新抄表记录表!");
                                        //回滚收费记录
                                        BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    mes.Show("打印第'" + (i + 1).ToString() + "'行时更新抄表记录表，原因:" + ex.ToString());
                                    log.Write(ex.ToString(), MsgType.Error);

                                    //回滚收费记录
                                    BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                    return;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show("第'" + (i + 1).ToString() + "'行收费失败，请重新打印发票!");
                        return;
                    }
                }

                catch (Exception ex)
                {
                    mes.Show("打印第'" + (i + 1).ToString() + "'行时失败!原因:" + ex.Message);
                    log.Write("打印发票失败!原因:" + ex.ToString(), MsgType.Error);
                    return;
                }
            }
            #endregion
        }
    }
}
