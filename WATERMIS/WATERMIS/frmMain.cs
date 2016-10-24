using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using METERREADINGMACHINE;
using WATERUSERMETERMANAGE;
using BASEMANAGE;
using SYSMANAGE;
using WATERFEEMANAGE;
using INVOICEMANAGE;
using STATISTIALREPORTS;
using BASEFUNCTION;
using BLL;
using System.IO;
using System.Configuration;
using MODEL;
using AppManage.Map;
using MeterInstall;
using PersonalWork;
using WorkFlow;
using AppManage;
using WaterBusiness;
using ApproveCenter;
using FinanceOS;


namespace WATERMIS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            string strName = ConfigurationSettings.AppSettings["WINDOWSKIN"];
            this.skinEngine1.SkinFile = Application.StartupPath + @"\skin\" + strName ;
            //this.skinEngine1.SkinFile = Application.StartupPath + @"\skin\MP10.ssk";
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }
        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        /// <summary>
        /// 组ID
        /// </summary>
        private string strGroupID = "";

        BLLBASE_AUTHORITY BLLBASE_AUTHORITY = new BLLBASE_AUTHORITY();
        BLLMESSAGERECEIVE BLLMESSAGERECEIVE = new BLLMESSAGERECEIVE();

        private void frmMain_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            this.dockPanel1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\Images\mainBackground.jpg");
            this.dockPanel1.BackgroundImageLayout = ImageLayout.Stretch;

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            //获取用户组ID
            if (AppDomain.CurrentDomain.GetData("GROUPID") != null && AppDomain.CurrentDomain.GetData("GROUPID") != DBNull.Value)
                strGroupID = AppDomain.CurrentDomain.GetData("GROUPID").ToString();

            if (strGroupID != "0001")
                for (int i = 0; i < menuStrip1.Items.Count; i++)
                {
                    ToolStripMenuItem subItem = (ToolStripMenuItem)menuStrip1.Items[i];
                    object objTag = subItem.Tag;
                    if (objTag != null && objTag != DBNull.Value)
                        if (objTag.ToString() == "0")
                            continue;
                    EnableMenu(subItem);
                }

            this.toolUserName.Text =strUserName;
        }
        /// <summary>
        /// 根据权限判断菜单的有无
        /// </summary>
        /// <param name="item"></param>
        private void EnableMenu(ToolStripMenuItem item)
        {
            //存储分割线菜单，控制起显示、隐藏用
            ToolStripSeparator toolSeparator = null;

            if (BLLBASE_AUTHORITY.GetAutority(strGroupID, item.Name) > 0)
                item.Visible = true;
            else
                item.Visible = false;
            ToolStripMenuItem subItem = item;
            for (int j = 0; j < subItem.DropDownItems.Count; j++)
            {
                if (!(subItem.DropDownItems[j] is ToolStripSeparator))
                {
                    ToolStripMenuItem subItemSub = (ToolStripMenuItem)subItem.DropDownItems[j];
                    object objTag = subItemSub.Tag;
                    if (objTag != null && objTag != DBNull.Value)
                        if (objTag.ToString() == "0")
                        {
                            if (toolSeparator != null)
                                toolSeparator.Visible = true;
                            continue;
                        }
                    if (BLLBASE_AUTHORITY.GetAutority(strGroupID, subItemSub.Name) > 0)
                    {
                        subItemSub.Visible = true;
                        if (toolSeparator != null)
                            toolSeparator.Visible = true;
                    }
                    else
                        subItemSub.Visible = false;
                    if (subItemSub.DropDownItems.Count > 0)
                    EnableMenu(subItemSub);
                }
                else
                {
                    toolSeparator = (ToolStripSeparator)subItem.DropDownItems[j];
                    toolSeparator.Visible = false;
                }
            }
        }
        private void GoTo(System.Windows.Forms.Form frmParent, DockContentEx frmChildren, bool OpenMax)
        {
            ((DockContentEx)frmChildren).Show(this.dockPanel1);
        }
        public void GoTo(System.Windows.Forms.Form frmParent, System.Windows.Forms.Form frmChildren, bool OpenMax)
        {
            bool isOpen = true;
            foreach (System.Windows.Forms.Form form in frmParent.MdiChildren)//遍历已打开的MDI
            {
                if (form.Name == frmChildren.Name)
                {
                    //frmChildren.Activate();//赋予焦点
                    //frmChildren.Visible = true;
                    isOpen = false;
                    form.Activate();
                    form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    break;
                }
            }
            if (isOpen)//如果没有找到相同窗体则打开新窗体
            {
                frmChildren.MdiParent = frmParent;//设置父窗体
                frmChildren.Show();
                if (OpenMax)
                    frmChildren.WindowState = System.Windows.Forms.FormWindowState.Maximized;//设置窗体最大化
            }
        }
        private void 操作员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserManage frm = new frmUserManage();
            frm.Show(this.dockPanel1);
            //GoTo(this, frm, true);
            
        }

        private void 部门管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDepartment frm = new FrmDepartment();
            frm.Show(this.dockPanel1);
        }

        private void 职务管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPost frm = new frmPost();
            frm.Show(this.dockPanel1);
        }

        private void 公司信息设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanyMes frm = new frmCompanyMes();
            frm.ShowDialog();
        }

        private void 组管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGroup frm = new frmGroup();
            frm.Show(this.dockPanel1);
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 锁定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLock frm = new frmLock();
            frm.menuStrip = this.menuStrip1;
            frm.Show(this.dockPanel1);
        }

        private void 备份数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackUp frm = new frmBackUp();
            frm.Show(this.dockPanel1);
        }

        private void 还原数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRestore frm = new frmRestore();
            frm.Show(this.dockPanel1);
        }

        private void 区域管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAreaManage frm = new frmAreaManage();
            frm.Show(this.dockPanel1);
        }

        private void 银行管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBankManage frm = new frmBankManage();
            frm.Show(this.dockPanel1);
        }

        private void 水表位置管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeTerPosition frm = new frmWaterMeTerPosition();
            frm.Show(this.dockPanel1);
        }

        private void 用户类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterUserType frm = new frmWaterUserType();
            frm.Show(this.dockPanel1);
        }

        private void 水表口径管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterSize frm = new frmWaterMeterSize();
            frm.Show(this.dockPanel1);
        }

        private void 附加费管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExtraChargeManage frm = new frmExtraChargeManage();
            frm.Show(this.dockPanel1);
        }

        private void 用水性质管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterType frm = new frmWaterMeterType();
            frm.Show(this.dockPanel1);
        }

        private void 用户管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmWaterUserAndMeter frm = new frmWaterUserAndMeter();
            frm.Show(this.dockPanel1);
        }

        private void 批量修改用户及水表信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatchModifyWaterUserMesAndWaterMeterMes frm = new frmBatchModifyWaterUserMesAndWaterMeterMes();
            frm.Show(this.dockPanel1);
        }

        private void 手工抄表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterRead frm = new frmWaterMeterRead();
            frm.Show(this.dockPanel1);
        }

        private void 水费审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadCheck frm = new frmWaterMeterReadCheck();
            frm.Show(this.dockPanel1);
        }

        private void 水费反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadUnCheck frm = new frmWaterMeterReadUnCheck();
            frm.Show(this.dockPanel1);
        }

        private void 营业坐收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadSingleCharge frm = new frmWaterMeterReadSingleCharge();
            frm.Show(this.dockPanel1);
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFilePath = Application.StartupPath + @"\skin\" + ((ToolStripMenuItem)sender).Text + ".ssk";
            if (File.Exists(strFilePath))
            {
                this.skinEngine1.SkinFile = strFilePath;
                ModifyConfig(((ToolStripMenuItem)sender).Text + ".ssk");
                //((ToolStripMenuItem)sender).Checked = true;
            }
        }

        private void ModifyConfig(string strName)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == "USERNAME")
                {
                    isModified = true;
                }
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isModified)
            {
                config.AppSettings.Settings.Remove("WINDOWSKIN");
            }
            config.AppSettings.Settings.Add("WINDOWSKIN", strName);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }

        private void 营业批量收费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadBatchCharge frm = new frmWaterMeterReadBatchCharge();
            frm.Show(this.dockPanel1);
        }

        private void 预存收费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrestoreCharge frm = new frmPrestoreCharge();
            frm.ShowDialog();
        }

        private void 预存冲减与发票补打ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRestoreChargeCancel frm = new frmRestoreChargeCancel();
            frm.Show(this.dockPanel1);
        }

        private void 用户余额初始化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterUserPrestoreSearch frm = new frmWaterUserPrestoreSearch();
            frm.Show(this.dockPanel1);
        }

        private void 用户余额初始化ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmWaterUserPrestoreInitial frm = new frmWaterUserPrestoreInitial();
            frm.Show(this.dockPanel1);
        }

        private void 水费减免ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadRemitCharge frm = new frmWaterMeterReadRemitCharge();
            frm.Show(this.dockPanel1);
        }

        private void 全部关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Form form in this.MdiChildren)//遍历已打开的MDI
            {
                form.Close();
            }
        }

        private void 抄表初始化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadInitial frm = new frmWaterMeterReadInitial();
            frm.ShowDialog();
        }

        private void 发票领取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceFetch frm = new frmInvoiceFetch();
            frm.Show(this.dockPanel1);
        }

        private void 用户明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterUserSearch frm = new frmWaterUserSearch();
            frm.Show(this.dockPanel1);
        }

        private void 报表设计器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportDesigner frm = new frmReportDesigner();
            frm.Show(this.dockPanel1);
        }

        private void 水表明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterSearch frm = new frmWaterMeterSearch();
            frm.Show(this.dockPanel1);
        }

        private void 水表应收明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterYSMXSearch frm = new frmWaterMeterYSMXSearch();
            frm.Show(this.dockPanel1);
        }

        private void 用户应收明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterUserYSMXSearch frm = new frmWaterUserYSMXSearch();
            frm.Show(this.dockPanel1);
        }

        private void 收费明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargeSearch frm = new frmWaterMeterChargeSearch();
            frm.Show(this.dockPanel1);
        }

        private void 收费冲减明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargeCancelSearch frm = new frmWaterMeterChargeCancelSearch();
            frm.Show(this.dockPanel1);
        }

        private void 发票使用明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChargeInvoicePrintSearch frm = new frmChargeInvoicePrintSearch();
            frm.Show(this.dockPanel1);
        }

        private void 预存冲减明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrestoreChargeCancelSearch frm = new frmPrestoreChargeCancelSearch();
            frm.Show(this.dockPanel1);
        }

        private void 预存明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrestoreChargeSearch frm = new frmPrestoreChargeSearch();
            frm.Show(this.dockPanel1);
        }

        private void 查抄率统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReadMeterRecordPecent frm = new frmReadMeterRecordPecent();
            frm.Show(this.dockPanel1);
        }

        private void 收费率统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargePercent frm = new frmWaterMeterChargePercent();
            frm.Show(this.dockPanel1);
        }

        private void 用水用户统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterUserStatistics frm = new frmWaterUserStatistics();
            frm.Show(this.dockPanel1);
        }

        private void 水表统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterStatistics frm = new frmWaterMeterStatistics();
            frm.Show(this.dockPanel1);
        }

        private void 应收水费统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmWaterUserYSStatistics frm = new frmWaterUserYSStatistics();
            frmWaterMeterYSStatics frm = new frmWaterMeterYSStatics();
            frm.Show(this.dockPanel1);
        }

        private void 权限设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogAuthority frm = new frmLogAuthority();
            frm.Show(this.dockPanel1);
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModifyPWD frm = new frmModifyPWD();
            frm.ShowDialog();
        }

        private void 向抄表机导入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmToMachineManage frm = new frmToMachineManage();
            frm.ShowDialog();
        }

        private void 从抄表机导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFromMachineManage frm = new frmFromMachineManage();
            frm.ShowDialog();
        }

        private void 抄表机设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMeterReadingMachineManage frm = new frmMeterReadingMachineManage();
            frm.ShowDialog();
        }

        private void 收费发票统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChargeInvoicePrintStatistisc frm = new frmChargeInvoicePrintStatistisc();
            frm.Show(this.dockPanel1);
        }

        private void 二次抄表初始化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadInitialSencond frm = new frmWaterMeterReadInitialSencond();
            frm.ShowDialog();
        }

        private void 自定额发票打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintInvoice frm = new frmPrintInvoice();
            frm.ShowDialog();
        }

        private void 收费结算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChargeEveryDay frm = new frmChargeEveryDay();
            frm.ShowDialog();
        }

        private void 系统日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOperateLog frm = new frmOperateLog();
            frm.Show(this.dockPanel1);
        }

        private void 预存收费统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterPrestoreChargeStatistics frm = new frmWaterPrestoreChargeStatistics();
            frm.Show(this.dockPanel1);
        }

        private void 营销收费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadSingleChargeAll frm = new frmWaterMeterReadSingleChargeAll();
            frm.Show(this.dockPanel1);
        }

        private void 预存用户水费结算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrestoreWaterUserManualCharge frm = new frmPrestoreWaterUserManualCharge();
            frm.Show(this.dockPanel1);
        }

        private void 通知单作废与补打ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformRePrintAndCancel frm = new frmInformRePrintAndCancel();
            frm.Show(this.dockPanel1);
        }

        private void 水费减免明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterFeeRemitSearch frm = new frmWaterFeeRemitSearch();
            frm.Show(this.dockPanel1);
        }

        private void 异常抄表分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReadMeterExceptionSearch frm = new frmReadMeterExceptionSearch();
            frm.Show(this.dockPanel1);
        }

        private void 向抄表机导入数据自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmToMachineManageCustomData frm = new frmToMachineManageCustomData();
            frm.ShowDialog();
        }

        private void 红字冲销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRedCancelSelectItem frm = new frmRedCancelSelectItem();
            frm.ShowDialog(); 
        }

        private void 用户开票信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterUserFPMes frm = new frmWaterUserFPMes();
            frm.ShowDialog();
        }

        private void 增值税普通发票开具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargeInvoiceRePrint frm = new frmWaterMeterChargeInvoiceRePrint();
            //frmWaterMeterChargeInvoicePrint frm = new frmWaterMeterChargeInvoicePrint();
            frm.Show(this.dockPanel1);
        }

        private void 变更审批表打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeExaminePrint frm = new frmChangeExaminePrint();
            frm.ShowDialog();
        }

        private void 营销收费统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterChargeStatistics frm = new frmWaterChargeStatistics();
            frm.Show(this.dockPanel1);
        }

        private void 营销收费统计新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterChargeStatisticsNew frm = new frmWaterChargeStatisticsNew();
            frm.Show(this.dockPanel1);
        }

        private void 水表抄表情况查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReadMeterRecordSearch frm = new frmReadMeterRecordSearch();
            frm.Show(this.dockPanel1);
        }

        private void 未收情况统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterDebtStatisc frm = new frmWaterMeterDebtStatisc();
            frm.Show(this.dockPanel1);
        }

        private void 未收情况明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterDebtSearch frm = new frmWaterMeterDebtSearch();
            frm.Show(this.dockPanel1);
        }

        private void 自定额发票作废ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintInvoiceCancel frm = new frmPrintInvoiceCancel();
            frm.Show(this.dockPanel1);
        }

        private void 用户退费管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrestoreReturnBack frm = new frmPrestoreReturnBack();
            frm.Show(this.dockPanel1);
        }

        private void 通知单统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformStatistics frm = new frmInformStatistics();
            frm.Show(this.dockPanel1);
        }

        private void 发票库存录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceStocks frm = new frmInvoiceStocks();
            frm.Show(this.dockPanel1);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BLLOPERATORLOG BLLOPERATORLOG = new BLLOPERATORLOG();

                MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                MODELOPERATORLOG.LOGCONTENT = "用户:" + strLogID + "-" + strUserName + "退出";
                //MODELOPERATORLOG.METERREADINGID = cmbWaterUserMeterReadingNO.SelectedValue.ToString();
                MODELOPERATORLOG.LOGTYPE = "5";  //5登陆日志
                MODELOPERATORLOG.OPERATORID = strLogID;
                MODELOPERATORLOG.OPERATORNAME = strUserName;
                BLLOPERATORLOG.Insert(MODELOPERATORLOG);
            }
            catch (Exception ex)
            {

            }
        }

        private void 大厅收费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChargeStatistics frm = new frmChargeStatistics();
            frm.Show(this.dockPanel1);
        }

        /// <summary>
        /// 查询收件箱未查看的消息
        /// </summary>
        DataTable dtNotice = new DataTable();
        private void bgNotice_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //查询未读未删除的消息
                dtNotice = BLLMESSAGERECEIVE.Query("  AND MESSAGERECEIVERID='" + strLogID + "' AND MESSAGERECEIVE.ISDELETE='0' AND MESSAGEREADEDSIGN='0' AND ISPOPSHOW='0' ");
            }
            catch (Exception ex)
            {
               
            }
        }

        private void trNotice_Tick(object sender, EventArgs e)
        {
            if(!bgNotice.IsBusy)
            bgNotice.RunWorkerAsync();
        }

        private void bgNotice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //DataTable dt = BLLMESSAGERECEIVE.Query(" AND MESSAGERECEIVERID='" + strLogID + "' AND ISDELETE='0' AND MESSAGEREADEDSIGN='0' ");
            for (int i = 0; i < dtNotice.Rows.Count; i++)
            {
                string strReceiveID = "", strTilte = "", strContent = "", strFromName = "", strClass = "";
                object obj = dtNotice.Rows[i]["MESSAGERECEIVEID"];
                if (obj != null && obj != DBNull.Value)
                {
                    strReceiveID = obj.ToString();
                    obj = dtNotice.Rows[i]["MESSAGESENDERNAME"];
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFromName = obj.ToString();
                    }
                    obj = dtNotice.Rows[i]["MESSAGETITLE"];
                    if (obj != null && obj != DBNull.Value)
                    {
                        strTilte = obj.ToString();
                    }
                    obj = dtNotice.Rows[i]["MESSAGECONTENT"];
                    if (obj != null && obj != DBNull.Value)
                    {
                        strContent = obj.ToString();
                    }
                    obj = dtNotice.Rows[i]["MESSAGECLASS"];
                    if (obj != null && obj != DBNull.Value)
                    {
                        strClass = obj.ToString();
                    }
                    frmNotice frm = new frmNotice();
                    frm.strFormTitle = "新消息";
                    frm.strTitle = strTilte;
                    frm.strContent = strContent;
                    frm.strReceiveID = strReceiveID;
                    frm.strFromName = strFromName;
                    frm.strClass = strClass;
                    frm.Show();
                    BLLMESSAGERECEIVE.UpdatePopSign(strReceiveID);
                }
            }
        }

        private void 消息发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSendMessage frm = new frmSendMessage();
            frm.Show(this.dockPanel1);
            //frm.Show(this.dockPanel1);
        }

        private void 已发消息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMessageSendSearch frm = new frmMessageSendSearch();
            frm.Show(this.dockPanel1);
        }

        private void 消息信箱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMessageReceiveSearch frm = new frmMessageReceiveSearch();
            frm.Show(this.dockPanel1);
        }

        private void 片区管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPianManage frm = new frmPianManage();
            frm.Show(this.dockPanel1);
        }

        private void 段号管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDuanManage frm = new frmDuanManage();
            frm.Show(this.dockPanel1);
        }

        private void 小区管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCommunityManage frm = new frmCommunityManage();
            frm.Show(this.dockPanel1);
        }

        private void 抄表收费员互换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMeterReaderEachOther frm = new frmMeterReaderEachOther();
            frm.ShowDialog();
        }

        private void 未初始化明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadUnInitialSearch frm = new frmWaterMeterReadUnInitialSearch();
            frm.Show(this.dockPanel1);
        }

        private void 发票批次管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatchManage frm = new frmBatchManage();
            frm.ShowDialog();
        }

        private void 通知单打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterFeeInformPrint frm = new frmWaterFeeInformPrint();
            frm.Show(this.dockPanel1);            
        }

        private void 大厅收费统计核算员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChargeStatistics frm = new frmChargeStatistics();
            frm.Show(this.dockPanel1);            
        }

        private void 收费结算核算员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterFeeCheck frm = new frmWaterFeeCheck();
            frm.Show(this.dockPanel1);            
        }

        private void 收费冲减与收据补打ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargeCancel frm = new frmWaterMeterChargeCancel();
            frm.Show(this.dockPanel1);
        }

        private void 手工抄表管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadCanModify frm = new frmWaterMeterReadCanModify();
            frm.Show(this.dockPanel1);
        }

        private void 发票预打ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargeValueAddedPrint frm = new frmWaterMeterChargeValueAddedPrint();
            frm.Show(this.dockPanel1);
        }

        private void 发票补打ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargeValueAddedrRePrint frm = new frmWaterMeterChargeValueAddedrRePrint();
            frm.Show(this.dockPanel1);
        }

        private void 单据解挂账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargeOnAccount frm = new frmWaterMeterChargeOnAccount();
            frm.Show(this.dockPanel1);
        }

        private void 历史台账查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReadMeterRecordOldSearch frm = new frmReadMeterRecordOldSearch();
            frm.Show(this.dockPanel1);
        }

        private void 发票开具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargeInvoiceRePrint frm = new frmWaterMeterChargeInvoiceRePrint();
            //frmWaterMeterChargeInvoicePrint frm = new frmWaterMeterChargeInvoicePrint();
            frm.Show(this.dockPanel1);
        }

        private void 发票作废与变更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargeInvoicePrint frm = new frmWaterMeterChargeInvoicePrint();
            frm.Show(this.dockPanel1);
        }

        private void 实收明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargedSearch frm = new frmWaterMeterChargedSearch();
            frm.Show(this.dockPanel1);
        }

        private void 实收统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargedStatics frm = new frmWaterMeterChargedStatics();
            frm.Show(this.dockPanel1);
        }

        private void 用水情况一览表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterFeeSummaryPreview_Year frm = new frmWaterFeeSummaryPreview_Year();
            frm.Show(this.dockPanel1);
        }

        private void 实收陈欠统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargedOldStatics frm = new frmWaterMeterChargedOldStatics();
            frm.Show(this.dockPanel1);
        }

        private void 应收欠费统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterYSDebtStatics frm = new frmWaterMeterYSDebtStatics();
            frm.Show(this.dockPanel1);
        }

        private void 月末结账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargedStaticsJieZhang frm = new frmWaterMeterChargedStaticsJieZhang();
            frm.Show(this.dockPanel1);
        }

        private void 月结报表应收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterFeeJieZhangYSSearch frm = new frmWaterFeeJieZhangYSSearch();
            frm.Show(this.dockPanel1);
        }

        private void 月结报表实收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterFeeJieZhangSSSearch frm = new frmWaterFeeJieZhangSSSearch();
            frm.Show(this.dockPanel1);
        }

        private void 应收全年汇总表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterYSStatics_AllYear frm = new frmWaterMeterYSStatics_AllYear();
            frm.Show(this.dockPanel1);
        }

        private void 实收全年汇总表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterMeterChargedStatics_ALLYear frm = new frmWaterMeterChargedStatics_ALLYear();
            frm.Show(this.dockPanel1);
        }

        private void 预收账款余额查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountsRunning frm = new frmAccountsRunning();
            frm.Show(this.dockPanel1);
        }

        private void 收据领取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReceiptFetch frm = new frmReceiptFetch();
            frm.Show(this.dockPanel1);
        }

        private void 台账查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterUserReadMeterRecordSearch frm = new frmWaterUserReadMeterRecordSearch();
            frm.Show(this.dockPanel1);
        }

        private void 一户式查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterUserSearchAll frm = new frmWaterUserSearchAll();
            frm.Show(this.dockPanel1);
        }

        private void 抄表情况说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReadMeterRecordNullSearch frm = new frmReadMeterRecordNullSearch();
            frm.Show(this.dockPanel1);
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            frmFromMachineManage_ZhenZhong frm = new frmFromMachineManage_ZhenZhong();
            frm.ShowDialog();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            frmToMachineManage_ZhenZhong frm = new frmToMachineManage_ZhenZhong();
            frm.ShowDialog();
        }

        private void 用户转款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrestoreTransfer frm = new frmPrestoreTransfer();
            frm.Show(this.dockPanel1);
        }

        private void 台账编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWaterUserSearchAll_CanModify frm = new frmWaterUserSearchAll_CanModify();
            frm.Show(this.dockPanel1);
        }

        private void 未抄表情况说明管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNullReadReason frm = new frmNullReadReason();
            frm.Show(this.dockPanel1);
        }

        private void 流程管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWorkFlow frm = new FrmWorkFlow();
            GoTo(this, frm, true);
        }

        private void 节点管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Meter_WorkPoint frm = new Meter_WorkPoint();
            GoTo(this, frm, true);
        }

        private void 审批项目管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Meter_WorkDo frm = new Meter_WorkDo();
            GoTo(this, frm, true);
        }

        private void 收费项目管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChargeList frm = new FrmChargeList();
            GoTo(this, frm, true);
        }

        private void 水表管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmMeterManage frm = new FrmMeterManage();
            GoTo(this, frm, true);
        }

        private void 业扩管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain();
            frm.dockPanel2 = this.dockPanel1;
            GoTo(this, frm, true);
        }

        private void 审批中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonalCenter frm = new FrmPersonalCenter();
            GoTo(this, frm, true);
        }

        private void 营业审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmApproveMain frm = new FrmApproveMain();
            frm.dockPanel2 = this.dockPanel1;
            GoTo(this, frm, true);
        }

        private void 业扩收费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFinanceCenter frm = new FrmFinanceCenter();
            GoTo(this, frm, true);

        }
    }
}
