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
    public partial class frmWaterMeterChargeOnAccount : DockContentEx
    {
        public frmWaterMeterChargeOnAccount()
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

        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENT = new BLLBASE_DEPARTMENT();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLAREA BLLAREA = new BLLAREA();
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

        private void frmWaterMeterChargeCancel_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            BindChargeWorkerName();

            dgHistoryWaterFee.AutoGenerateColumns = false;

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);

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

            //获取用户组ID
            object objGroup = AppDomain.CurrentDomain.GetData("GROUPID");
            if (objGroup != null && objGroup != DBNull.Value)
            {
                strGroupID = objGroup.ToString();
                //如果非系统管理员，则只能统计自己的收费明细
                if (strGroupID != "0001")
                {
                    cmbChargerWorkName.SelectedValue = strLoginID;
                    cmbChargerWorkName.Enabled = false;
                }
            }
            else
            {
                mes.Show("收费员所属组获取失败!请重新打开该窗体!");
                this.Close();
            }

            //this.Text = "大厅坐收——当前收费员:" + strLoginName;

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
            cmbChargeState.SelectedIndex = 0;
            txtWaterUserNO.Focus();
            BindWaterMeterType();
            GenerateTree();
            GetCompanyFPMes();
            BindChargerName(cmbCharger);
            BindWaterUserType(cmbWaterUserType);
            BindChargeType(cmbChargeTypeOld);
            BindChargeType(cmbChargeTypeNew);
        }

        /// <summary>
        /// 绑定收费类型
        /// </summary>
        private void BindChargeType(ComboBox cmb)
        {
            DataTable dt = BLLCHARGETYPE.QUERY("");
            DataRow dr = dt.NewRow();
            cmb.DataSource = dt;
            cmb.DisplayMember = "CHARGETYPENAME";
            cmb.ValueMember = "CHARGETYPEID";
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
        /// 绑定收款员
        /// </summary>
        private void BindChargeWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND IsCashier='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbChargerWorkName.DataSource = dt;
            cmbChargerWorkName.DisplayMember = "USERNAME";
            cmbChargerWorkName.ValueMember = "LOGINID";
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
        /// 绑定用户类别
        /// </summary>
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
            }
            #endregion
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

        private void dgHistoryWaterFee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgHistoryWaterFee.Columns[e.ColumnIndex].Name == "INVOICECANCEL")
            {
                object objInvoiceCancel = e.Value;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                {
                    if (objInvoiceCancel.ToString() == "0")
                        e.Value = "正常";//如果有正常状态的发票就不能打印第二次  只能先作废再打印
                    else if (objInvoiceCancel.ToString() == "1")
                        e.Value = "冲减作废";
                    else if (objInvoiceCancel.ToString() == "2")
                        e.Value = "损坏作废";
                    else if (objInvoiceCancel.ToString() == "3")
                        e.Value = "未打作废";
                }
                else
                    e.Value = "未打发票";

            }
            if (dgHistoryWaterFee.Columns[e.ColumnIndex].Name == "CHARGETYPEID")
            {
                object objChargeType = e.Value;
                if (objChargeType != null && objChargeType != DBNull.Value)
                    if (objChargeType.ToString() == "1")
                        e.Value = "现金";//如果有正常状态的发票就不能打印第二次  只能先作废再打印
                    else if (objChargeType.ToString() == "1")
                        e.Value = "作废";
            }
            if (dgHistoryWaterFee.Columns[e.ColumnIndex].Name == "chargeState")
            {
                object objChargeType = e.Value;
                if (objChargeType != null && objChargeType != DBNull.Value)
                    if (objChargeType.ToString() == "3")
                        e.Value = "已收费";//如果有正常状态的发票就不能打印第二次  只能先作废再打印
                    else if (objChargeType.ToString() == "2")
                        e.Value = "挂账";
                    else if (objChargeType.ToString() == "1")
                        e.Value = "未收费";

            }
        }

        private void txtChargeNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(null, null);
            }
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
                log.Write("单据(解)挂账界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("单据(解)挂账界面:" + ex.ToString(), MsgType.Error);
            }
        }
        private void LoadData(string[] strNodeID)
        {
            try
            {
                string strFilter = strNodeID[2] + strSeniorFilterHidden + " AND  INVOICECANCEL='0' ";//只可查询到已打印发票且发票状态正常的收费单据

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
                if (chkChargeDateTime.Checked)
                {
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Value.ToString() + "' AND '" + dtpEnd.Text + "'";
                }

                if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (cmbWaterUserType.SelectedValue != null && cmbWaterUserType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterUserTypeId='" + cmbWaterUserType.SelectedValue.ToString() + "'";

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (cmbCharger.SelectedValue != null && cmbCharger.SelectedValue != DBNull.Value)
                    strFilter += " AND chargerID='" + cmbCharger.SelectedValue.ToString() + "'";

                if (cmbChargeState.SelectedIndex > 0)
                    strFilter += " AND CHARGESTATE='"+(cmbChargeState.SelectedIndex+1).ToString()+"'";

                if (txtYearAndMonth.Text.Length == 6)
                {
                    string strYear = txtYearAndMonth.Text.Substring(0, 4), strMonth = txtYearAndMonth.Text.Substring(4, 2);
                    //查询条件
                    strFilter += " AND  readMeterRecordYear=" + strYear + " AND readMeterRecordMonth=" + strMonth;
                }

                dtHistoryWaterFee = BLLWATERFEECHARGE.QueryLS(strFilter + " ORDER BY INVOICEPRINTDATETIME");
                dgHistoryWaterFee.DataSource = dtHistoryWaterFee;
                if (dtHistoryWaterFee.Rows.Count == 0)
                {
                    btSetOnAccount.Enabled = false;
                    btSetNoOnAccount.Enabled = false;
                }
                else
                {
                    btSetOnAccount.Enabled = true;
                    btSetNoOnAccount.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Write("增值税专用发票补打界面:" + ex.ToString(), MsgType.Error);
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


        private void txtYearAndMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                txtYearAndMonth.Clear();
        }

        private void btSetOnAccount_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月结，无法执行此操作!");
                return;
            }
            if (strGroupID != "0001")
            {
                objJZ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZ != null && objJZ != DBNull.Value)
                {
                    if (objJZ.ToString() == "是")
                    {
                        mes.Show("该单据已经结账，无法执行此操作!");
                        return;
                    }
                }
            }
            if (dgHistoryWaterFee.SelectedRows.Count > 0)
                if (mes.ShowQ("确定要将所有选择的行挂账处理吗?") != DialogResult.OK)
                    return;

            DateTime dtNow = mes.GetDatetimeNow();

            for (int i = 0; i < dgHistoryWaterFee.SelectedRows.Count; i++)
            {
                string strWaterUserName = "",strWaterUserID="";

                dtNow = dtNow.AddSeconds(1);//区分不同行的审核时间

                object objWaterUserName=dgHistoryWaterFee.SelectedRows[i].Cells["waterUserName"].Value;
                if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                    strWaterUserName = objWaterUserName.ToString();

                object objWaterUserID=dgHistoryWaterFee.SelectedRows[i].Cells["waterUserId"].Value;
                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                    strWaterUserID = objWaterUserID.ToString();

                //如果已挂账状态不允许再次挂账
                object objChargeState = dgHistoryWaterFee.SelectedRows[i].Cells["chargestate"].FormattedValue;
                if (objChargeState != null && objChargeState != DBNull.Value)
                    if (objChargeState.ToString() == "挂账")
                        continue;

                object objReadMeterRecordID = dgHistoryWaterFee.SelectedRows[i].Cells["readMeterRecordId"].Value;
                if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
                {
                    string strSQL = "UPDATE readMeterRecord SET chargeState='2' WHERE readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                    int intExcuteRow = 0;
                    try
                    {
                        intExcuteRow = BLLreadMeterRecord.Excute(strSQL);
                    }
                    catch (Exception ex)
                    {
                        log.Write(ex.ToString(), MsgType.Error);
                        mes.Show("更新收费状态失败:" + ex.Message);
                    }
                    if (intExcuteRow > 0)
                    {
                        decimal decPrestore = 0, decJSYE = 0;//挂账时更新前期余额和结算余额
                        DataTable dtPrestore = BLLwaterUser.QueryUserPrestore(" AND WATERUSERID='"+strWaterUserID+"'");
                        if(dtPrestore.Rows.Count>0)
                        {
                            object objPrestore = dtPrestore.Rows[0]["prestore"];
                            if (Information.IsNumeric(objPrestore))
                                decPrestore = Convert.ToDecimal(objPrestore);

                            object objJSYE= dtPrestore.Rows[0]["USERAREARAGE"];
                            if (Information.IsNumeric(objJSYE))
                                decJSYE = Convert.ToDecimal(objJSYE);
                        }
                        object objChargeID = dgHistoryWaterFee.SelectedRows[i].Cells["CHARGEID"].Value;
                        if (objChargeID != null && objChargeID != DBNull.Value)
                        {
                            MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                            MODELWATERFEECHARGE.CHARGEYSQQYE = decPrestore;
                            MODELWATERFEECHARGE.CHARGEYSJSYE = decJSYE;
                            MODELWATERFEECHARGE.CHARGEDATETIME = dtNow;
                            MODELWATERFEECHARGE.CHARGEID = objChargeID.ToString();
                            bool isSuccess = false;
                            try
                            {
                                isSuccess = BLLWATERFEECHARGE.UpdateChargeDateTime(MODELWATERFEECHARGE);
                            }
                            catch (Exception ex)
                            {
                                log.Write(ex.ToString(), MsgType.Error);
                                mes.Show("更新收费单号'" + MODELWATERFEECHARGE.CHARGEID + "'挂账时间失败!\r\n原因:"+ex.Message+"\r\n单据挂账失败,请重试!");

                                //回滚抄表状态
                                strSQL = "UPDATE readMeterRecord SET chargeState='3' WHERE readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                                BLLreadMeterRecord.Excute(strSQL);
                                return;
                            }
                            if (isSuccess)
                            {
                                dgHistoryWaterFee.SelectedRows[i].Cells["CHARGEDATETIME"].Value = MODELWATERFEECHARGE.CHARGEDATETIME.ToString();
                                dgHistoryWaterFee.SelectedRows[i].Cells["chargeState"].Value = "挂账";
                            }
                            else
                            {
                                mes.Show("更新收费单号'" + MODELWATERFEECHARGE.CHARGEID + "'挂账时间失败!单据挂账失败,请重试!");
                                //回滚抄表状态
                                strSQL = "UPDATE readMeterRecord SET chargeState='3' WHERE readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                                BLLreadMeterRecord.Excute(strSQL);
                                return;
                            }
                        }
                    }
                    else
                    {
                        mes.Show("用户'" + strWaterUserName + "'收费单据挂账失败,请重试!");
                        return;
                    }
                }
            }
        }

        private void btSetNoOnAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgHistoryWaterFee.SelectedRows.Count > 0)
                    if (mes.ShowQ("确定要将所有选择的行解除挂账处理吗?") != DialogResult.OK)
                        return;

                DateTime dtNow = mes.GetDatetimeNow();

                for (int i = 0; i < dgHistoryWaterFee.SelectedRows.Count; i++)
                {
                    string strWaterUserName = "", strWaterUserID = "", strChargeState = "";

                    dtNow = dtNow.AddSeconds(1);

                    object objWaterUserID = dgHistoryWaterFee.SelectedRows[i].Cells["waterUserId"].Value;
                    if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        strWaterUserID = objWaterUserID.ToString();

                    object objWaterUserName = dgHistoryWaterFee.SelectedRows[i].Cells["waterUserName"].Value;
                    if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                        strWaterUserName = objWaterUserName.ToString();

                    //如果已收费状态不允许再次解挂
                    object objChargeState = dgHistoryWaterFee.SelectedRows[i].Cells["chargestate"].FormattedValue;
                    if (objChargeState != null && objChargeState != DBNull.Value)
                        if (objChargeState.ToString() == "已收费")
                            continue;

                    object objReadMeterRecordID = dgHistoryWaterFee.SelectedRows[i].Cells["readMeterRecordId"].Value;
                    if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
                    {
                        string strSQL = "UPDATE readMeterRecord SET chargeState='3' WHERE readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                        int intExcuteRow = 0;
                        try
                        {
                            intExcuteRow = BLLreadMeterRecord.Excute(strSQL);
                        }
                        catch (Exception ex)
                        {
                            log.Write(ex.ToString(), MsgType.Error);
                            mes.Show("更新收费状态失败:" + ex.Message);
                        }
                        if (intExcuteRow > 0)
                        {
                            decimal decPrestore = 0, decJSYE = 0;//挂账时更新前期余额和结算余额
                            DataTable dtPrestore = BLLwaterUser.QueryUserPrestore(" AND WATERUSERID='" + strWaterUserID + "'");
                            if (dtPrestore.Rows.Count > 0)
                            {
                                object objPrestore = dtPrestore.Rows[0]["prestore"];
                                if (Information.IsNumeric(objPrestore))
                                    decPrestore = Convert.ToDecimal(objPrestore);

                                object objJSYE = dtPrestore.Rows[0]["USERAREARAGE"];
                                if (Information.IsNumeric(objJSYE))
                                    decJSYE = Convert.ToDecimal(objJSYE);
                            }

                            object objChargeID = dgHistoryWaterFee.SelectedRows[i].Cells["CHARGEID"].Value;
                            if (objChargeID != null && objChargeID != DBNull.Value)
                            {
                                MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                                MODELWATERFEECHARGE.CHARGEDATETIME = dtNow;
                                MODELWATERFEECHARGE.CHARGEYSQQYE = decPrestore;
                                MODELWATERFEECHARGE.CHARGEYSJSYE = decJSYE;
                                MODELWATERFEECHARGE.CHARGEID = objChargeID.ToString();
                                bool isSuccess = false;
                                try
                                {
                                    isSuccess=BLLWATERFEECHARGE.UpdateChargeDateTime(MODELWATERFEECHARGE);
                                }
                                catch (Exception ex)
                                {
                                    log.Write(ex.ToString(),MsgType.Error);
                                    mes.Show("更新收费单号'" + MODELWATERFEECHARGE.CHARGEID + "'收费时间失败!\r\n原因:"+ex.Message+"\r\n单据解除挂账失败,请重试!");

                                    //回滚抄表状态
                                    strSQL = "UPDATE readMeterRecord SET chargeState='2' WHERE readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                                    BLLreadMeterRecord.Excute(strSQL);
                                    return;
                                }
                                if (isSuccess)
                                {
                                    dgHistoryWaterFee.SelectedRows[i].Cells["CHARGEDATETIME"].Value = MODELWATERFEECHARGE.CHARGEDATETIME.ToString();
                                    dgHistoryWaterFee.SelectedRows[i].Cells["chargeState"].Value = "已收费";
                                }
                                else
                                {
                                    mes.Show("更新收费单号'" + MODELWATERFEECHARGE.CHARGEID + "'收费时间失败!单据解除挂账失败,请重试!");
                                    //回滚抄表状态
                                    strSQL = "UPDATE readMeterRecord SET chargeState='2' WHERE readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                                    BLLreadMeterRecord.Excute(strSQL);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            mes.Show("用户'" + strWaterUserName + "'收费单据解除挂账失败,请重试!");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.ToString(),MsgType.Error);
                mes.Show("错误:"+ex.Message);
            }
        }

        private void dgHistoryWaterFee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            object objID = dgHistoryWaterFee.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (objID != null && objID != DBNull.Value)
            {
                txtID.Text = objID.ToString();

                object objChargeTypeID = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGETYPEID"].Value;
                if (objChargeTypeID != null && objChargeTypeID != DBNull.Value)
                    cmbChargeTypeOld.SelectedValue = objChargeTypeID.ToString();
            }
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            if (cmbChargeTypeNew.SelectedValue == null || cmbChargeTypeNew.SelectedValue == DBNull.Value)
            {
                mes.Show("新的收款方式不能为空!");
                return;
            }
            if (dgHistoryWaterFee.CurrentRow == null)
                return;

            string strID=cmbChargeTypeNew.SelectedValue.ToString();
            if (strID=="2"||strID=="3")
            {
                if (txtJYLSH.Text.Trim() == "")
                {
                    mes.Show("请输入交易凭证号!");
                    return;
                }
            }
            try
            {
                object objChargeID = dgHistoryWaterFee.CurrentRow.Cells["CHARGEID"].Value;
                if (objChargeID != null && objChargeID != DBNull.Value)
                {
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = objChargeID.ToString();
                    MODELWATERFEECHARGE.CHARGETYPEID = strID;
                    if (strID == "2" || strID == "3")
                        MODELWATERFEECHARGE.POSRUNNINGNO = txtJYLSH.Text;

                    if (BLLWATERFEECHARGE.UpdateChargeType(MODELWATERFEECHARGE))
                    {
                        dgHistoryWaterFee.CurrentRow.Cells["CHARGETYPEID"].Value = MODELWATERFEECHARGE.CHARGETYPEID;
                        dgHistoryWaterFee.CurrentRow.Cells["CHARGETYPENAME"].Value = cmbChargeTypeNew.Text;
                        dgHistoryWaterFee.CurrentRow.Cells["POSRUNNINGNO"].Value = MODELWATERFEECHARGE.POSRUNNINGNO;
                        mes.Show("修改成功!");
                    }
                    else
                    {
                        mes.Show("修改失败!");
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show("修改收款方式失败,原因:"+ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }

        private void 反月结ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            object objChargeID = dgHistoryWaterFee.CurrentRow.Cells["CHARGEID"].Value;
            if (objChargeID != null && objChargeID != DBNull.Value)
            {
                if (mes.ShowQ("确定要将单号为'" + objChargeID.ToString() + "'的收费单据反月结吗?") == DialogResult.OK)
                {
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = objChargeID.ToString();
                    //MODELWATERFEECHARGE.SETTLEACCOUNTSSSID = null;
                    MODELWATERFEECHARGE.MONTHCHECKSTATE = "0";
                    if (BLLWATERFEECHARGE.UpdateMonthCheckState(MODELWATERFEECHARGE, " AND CHARGEID='" + objChargeID.ToString() + "'") > 0)
                    {
                        dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value = DBNull.Value;
                        mes.Show("反月结成功!");
                    }
                    else
                    {
                        mes.Show("反月结失败,请重新选择单据后重试!");
                    }
                }
            }
            else
            {
                mes.Show("获取单号失败,请重新选择要操作的单号!");
                return;
            }
        }

        private void 反日结ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;

            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月账，无法执行此操作!");
                return;
            }
            object objChargeID = dgHistoryWaterFee.CurrentRow.Cells["CHARGEID"].Value;
            if (objChargeID != null && objChargeID != DBNull.Value)
            {
                if (mes.ShowQ("确定要将单号为'" + objChargeID.ToString() + "'的收费单据反日结吗?") == DialogResult.OK)
                {
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = objChargeID.ToString();
                    MODELWATERFEECHARGE.DAYCHECKSTATE = "0";
                    if (BLLWATERFEECHARGE.UpdateDayCheckState(MODELWATERFEECHARGE, " AND CHARGEID='" + objChargeID.ToString() + "'") > 0)
                    {
                        dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value = "否";
                        mes.Show("反日结成功!");
                    }
                    else
                    {
                        mes.Show("反日结失败,请重新选择单据后重试!");
                    }
                }
            }
            else
            {
                mes.Show("获取单号失败,请重新选择要操作的单号!");
                return;
            }
        }

        private void dgHistoryWaterFee_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (strGroupID == "0001")
                {
                    dgHistoryWaterFee.CurrentCell = dgHistoryWaterFee.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
    }
}
