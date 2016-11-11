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

namespace WATERFEEMANAGE
{
    public partial class frmRestoreChargeCancel : DockContentEx
    {
        public frmRestoreChargeCancel()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            tb2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb2, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLINVOICEFETCH BLLINVOICEFETCH = new BLLINVOICEFETCH();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        RMBToCapMoney RMBToCapMoney = new RMBToCapMoney();
        BLLRECEIPTFETCH BLLRECEIPTFETCH = new BLLRECEIPTFETCH();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();

        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strLoginName = "";

        /// <summary>
        /// 登陆用户所属分组
        /// </summary>
        private string strGroupID= "";

        private void frmRestoreChargeCancel_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            dgHistoryWaterFee.AutoGenerateColumns = false;

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
                strLoginName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            //this.Text = "预存冲减与发票补打——当前收款员:" + strLoginName;

            BindChargeWorkerName();

            object objGroup = AppDomain.CurrentDomain.GetData("GROUPID");
            if (objGroup != null && objGroup != DBNull.Value)
            {
                strGroupID = objGroup.ToString();
                //如果非系统管理员，则只能统计自己的收费明细
                if (strGroupID != "0001")
                {
                    cmbChargerWorkName.SelectedValue = strLogID;
                    cmbChargerWorkName.Enabled = false;
                }
            }

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year,dtNow.Month,dtNow.Day,0,0,0);
            dtpEnd.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
            //dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);
            //dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1); 

            txtWaterUserNOSearch.Focus();
            BindInvoiceBatch(cmbBatch);
            BindMeterReader();
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

        DataTable dtMeterReader = new DataTable();
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader()
        {
            dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
        }
        /// <summary>
        /// 绑定发票批次
        /// </summary>
        /// <param name="cmb"></param>
        private void BindInvoiceBatch(ComboBox cmb)
        {
            DataTable dt = BLLINVOICEFETCH.Query(" AND ISENABLE='1' ORDER BY INVOICEFETCHBATCHID DESC");
            DataView dvInvoiceBatch = dt.DefaultView;
            cmbBatch.DataSource = dvInvoiceBatch.ToTable(true, "INVOICEFETCHBATCHID", "INVOICEBATCHNAME");
            cmb.DisplayMember = "INVOICEBATCHNAME";
            cmb.ValueMember = "INVOICEFETCHBATCHID";

            if (dvInvoiceBatch.Count == 0)
            {
                mes.Show("从发票领用记录表内未检测到可用的发票,发票将无法打印!");
            }
        }
        /// <summary>
        /// 绑定收费员
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
        void dgHistoryWaterFee_MouseWheel(object sender, MouseEventArgs e)
        {
            int rowIndex = this.dgHistoryWaterFee.CurrentRow.Index;
            this.dgHistoryWaterFee.ClearSelection();

            if (e.Delta > 0)
            {
                if (rowIndex > 0)
                {
                    this.dgHistoryWaterFee.CurrentCell = this.dgHistoryWaterFee.Rows[rowIndex - 1].Cells[0];
                    this.dgHistoryWaterFee.Rows[rowIndex - 1].Selected = true;
                }
                else
                {
                    this.dgHistoryWaterFee.CurrentCell = this.dgHistoryWaterFee.Rows[rowIndex].Cells[0];
                    this.dgHistoryWaterFee.Rows[rowIndex].Selected = true;
                }
            }
            else
            {
                if (rowIndex < this.dgHistoryWaterFee.Rows.Count - 1)
                {
                    this.dgHistoryWaterFee.CurrentCell = this.dgHistoryWaterFee.Rows[rowIndex + 1].Cells[0];
                    this.dgHistoryWaterFee.Rows[rowIndex + 1].Selected = true;
                }
                else
                {
                    this.dgHistoryWaterFee.CurrentCell = this.dgHistoryWaterFee.Rows[rowIndex].Cells[0];
                    this.dgHistoryWaterFee.Rows[rowIndex].Selected = true;
                }
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
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
                LoadDebtsDate();
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("预存冲减与发票补打界面:" + ex.ToString(), MsgType.Error);
                //TD.Abort();
            }
        }
        //传递给线程的方法.
        private void showwaitfrm()
        {
            try
            {
                frmWait waitfrm = new frmWait();
                waitfrm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Write("预存冲减与发票补打界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 获取欠费用户列表
        /// </summary>
        /// <param name="strFilter"></param>
        private void LoadDebtsDate()
        {
            txtYSQQYE.Text = "0";
            txtBCJY.Text = "0";
            txtYSJSYE.Text = "0";
            txtMemo.Clear();

            string strFilter = "";
            DateTime dtNow = mes.GetDatetimeNow();
            if (txtChargeNO.Text.Trim() != "")
            {
                if (txtChargeNO.Text.Trim().Length < 6)
                    strFilter += " AND CHARGEID='" + dtNow.ToString("yyyyMMdd") + "YS" + txtChargeNO.Text.PadLeft(6, '0') + "'";
                else
                    strFilter += " AND CHARGEID='" + txtChargeNO.Text + "'";
            }

            if (txtWaterUserNOSearch.Text.Trim() != "")
            {
                if (txtWaterUserNOSearch.Text.Length < 6)
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                else
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
            }

            if (txtWaterUserNameSearch.Text.Trim() != "")
            {
                strFilter += " AND WATERUSERNAME LIKE '%" + txtWaterUserNameSearch.Text + "%'";
            }
            if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
            {
                strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";
            }
            if (chkChargeDateTime.Checked)
            {
                strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Value.ToString() + "' AND '" + dtpEnd.Value.ToString() + "'";
            }

            txtChargeID.Clear();
            txtInvoiceNO.Clear();

            //获取新的收据号码,8位收据号
            DataTable dtNewReceriptNO = BLLWATERFEECHARGE.GetMaxReceiptNO(strLogID);
            if (dtNewReceriptNO.Rows.Count > 0)
            {
                object objReceiptNO = dtNewReceriptNO.Rows[0]["RECEIPTNO"];
                if (Information.IsNumeric(objReceiptNO))
                {
                    txtReceiptNO.Text = (Convert.ToInt64(objReceiptNO) + 1).ToString().PadLeft(8, '0');
                }
            }

            //获取新的发票号码
            if (cmbBatch.SelectedValue != null && cmbBatch.SelectedValue != DBNull.Value)
            {
                DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLogID, cmbBatch.SelectedValue.ToString());
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

            DataTable dtHistoryPrestoreCharge = BLLPRESTORERUNNINGACCOUNT.Query(strFilter + " ORDER BY CHARGEDATETIME DESC");

            dgHistoryWaterFee.DataSource = dtHistoryPrestoreCharge;
            if (dtHistoryPrestoreCharge.Rows.Count == 0)
            {
                btCancelCharge.Enabled = false;
                btInvoiceCancel.Enabled = false;
                btInvoicePrint.Enabled = false;
                btReceiptPrint.Enabled = false;
            }
            else
            {
                btCancelCharge.Enabled = true;
                btInvoiceCancel.Enabled = true;
                btInvoicePrint.Enabled = true;
                btReceiptPrint.Enabled = true;

                DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(2,0);
                dgHistoryWaterFee_CellClick(null, ex);
            }
        }

        private void dgHistoryWaterFee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            txtChargeID.Clear();
            txtChargeInvoicePrintID.Clear();

            object objChargeTypeID = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGETYPEID"].Value;
            if (objChargeTypeID != null && objChargeTypeID != DBNull.Value)
                cmbChargeTypeOld.SelectedValue = objChargeTypeID.ToString();

            object objChargeInvoicePrintID = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGEINVOICEPRINTID"].Value;
            if (objChargeInvoicePrintID != null && objChargeInvoicePrintID != DBNull.Value)
            {
                txtChargeInvoicePrintID.Text = objChargeInvoicePrintID.ToString();
                btInvoiceCancel.Enabled = true;

                object objInvoiceCancel = dgHistoryWaterFee.Rows[e.RowIndex].Cells["INVOICECANCEL"].Value;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                    if (objInvoiceCancel.ToString() == "正常")
                    {
                        btInvoiceCancel.Enabled = true;
                        btInvoicePrint.Enabled = false;//如果有正常状态的发票就不能打印第二次  只能先作废再打印
                    }
                    else
                    {
                        btInvoiceCancel.Enabled = false;
                        btInvoicePrint.Enabled = true;
                    }
                else
                {
                    btInvoicePrint.Enabled = true;
                }
            }
            else
            {
                btInvoiceCancel.Enabled = false;
                btInvoicePrint.Enabled = true;
            }

            object objChargeID = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGEID"].Value;
            if (objChargeID != null && objChargeID != DBNull.Value)
            {
                txtChargeID.Text = objChargeID.ToString();
                txtBCSS.Text = "0";

                //用户预存金额
                object objRestoreMoney = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGEYSBCSZ"].Value;
                if (Information.IsNumeric(objRestoreMoney))
                    txtBCSS.Text = objRestoreMoney.ToString();


                txtYSQQYE.Text = "0";
                //查询用户余额
                object objWaterUserID = dgHistoryWaterFee.Rows[e.RowIndex].Cells["waterUserId"].Value;
                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                {
                    object objWaterUserPreStore = BLLwaterUser.GetPrestore(" AND waterUserId='" + objWaterUserID.ToString() + "'");
                    if (Information.IsNumeric(objWaterUserPreStore))
                        txtYSQQYE.Text = objWaterUserPreStore.ToString();
                }
                txtBCJY.Text =(0-Convert.ToDecimal(txtBCSS.Text)).ToString();
                txtYSJSYE.Text = (Convert.ToDecimal(txtYSQQYE.Text) - Convert.ToDecimal(txtBCSS.Text)).ToString(); ;

                btCancelCharge.Enabled = true;
                btReceiptPrint.Enabled = true;
            }
            else
            {
                btCancelCharge.Enabled = false;
                btReceiptPrint.Enabled = false;
                btInvoicePrint.Enabled = false;
            }
        }

        private void btCancelCharge_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月账，无法执行此操作!");
                return;
            }
            if (strGroupID != "0001")
            {
                object objJZRJ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZRJ != null && objJZRJ != DBNull.Value)
                {
                    if (objJZRJ.ToString() == "是")
                    {
                        mes.Show("该单据已日账，无法执行此操作!");
                        return;
                    }
                }
            }
            try
            {
                if (txtChargeID.Text.Trim() != "")
                {
                    object objChargeCancel = dgHistoryWaterFee.CurrentRow.Cells["CHARGECANCEL"].Value;
                    if (objChargeCancel != null && objChargeCancel != DBNull.Value)
                        if (objChargeCancel.ToString() == "作废")
                        {
                            mes.Show("该收费单已经冲减,无需再次冲减!");
                            return;
                        }

                    if (!Information.IsNumeric(txtBCSS.Text))
                        txtBCSS.Text = "0";

                    if (!Information.IsNumeric(txtYSQQYE.Text))
                        txtYSQQYE.Text = "0";

                    if (Convert.ToDecimal(txtYSQQYE.Text) < Convert.ToDecimal(txtBCSS.Text))
                    {
                        mes.Show("用户余额不足，无法完成冲减!");
                        return;
                    }
                    if (txtMemo.Text.Trim() == "")
                    {
                        mes.Show("请填写冲减原因!");
                        txtMemo.Focus();
                        return;
                    }
                    string strWaterUserName = "", strWaterUserNO = "", strWaterUserID = "";

                    object objWaterUserID = dgHistoryWaterFee.CurrentRow.Cells["waterUserNO"].Value;
                    if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        strWaterUserID = objWaterUserID.ToString();
                    else
                    {
                        mes.Show("获取用户ID失败,请重新选择冲减单据!");
                        return;
                    }
                    object objWaterUserName = dgHistoryWaterFee.CurrentRow.Cells["waterUserName"].Value;
                    if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                        strWaterUserName = objWaterUserName.ToString();

                    object objWaterUserNO = dgHistoryWaterFee.CurrentRow.Cells["waterUserNO"].Value;
                    if (objWaterUserNO != null && objWaterUserNO != DBNull.Value)
                        strWaterUserNO = objWaterUserNO.ToString();

                    if (mes.ShowQ("确定要将用户'" + strWaterUserNO + "-" + strWaterUserName + "'的收费单据'" + txtChargeID.Text + "'冲减吗?") != DialogResult.OK)
                        return;

                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = txtChargeID.Text;
                    MODELWATERFEECHARGE.CHARGECANCEL = "1";
                    MODELWATERFEECHARGE.CANCELYSQQYE = Convert.ToDecimal(txtYSQQYE.Text);
                    MODELWATERFEECHARGE.CANCELYSBCSZ = Convert.ToDecimal(txtBCJY.Text);
                    MODELWATERFEECHARGE.CANCELYSJSYE = Convert.ToDecimal(txtYSJSYE.Text);
                    MODELWATERFEECHARGE.CANCELWORKERID = strLogID;
                    MODELWATERFEECHARGE.CANCELWORKERNAME = strLoginName;
                    MODELWATERFEECHARGE.CANCELDATETIME = mes.GetDatetimeNow();
                    MODELWATERFEECHARGE.CANCELMEMO = txtMemo.Text;

                    if (BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE))
                    {
                        try
                        {
                            if (txtChargeInvoicePrintID.Text.Trim() != "")
                            {
                                #region 含有发票的先作废发票再更新余额
                                MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT = new MODELCHARGEINVOICEPRINT();
                                MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID = txtChargeInvoicePrintID.Text;
                                MODELCHARGEINVOICEPRINT.INVOICECANCEL = "1";
                                MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = strLogID;
                                MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = strLoginName;
                                MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME = mes.GetDatetimeNow();
                                MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = txtMemo.Text;
                                if (BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT))
                                {
                                    //打印发票

                                    //更新余额
                                    try
                                    {
                                        string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CANCELYSJSYE + " WHERE waterUserId='" + strWaterUserID + "'";
                                        if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                        {
                                            //回滚收费表
                                            MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                            MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                            MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                            MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                            MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                            MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                            MODELWATERFEECHARGE.CANCELMEMO = null;
                                            BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                            //回滚发票状态
                                            MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID = txtChargeInvoicePrintID.Text;
                                            MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";
                                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = null;
                                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = null;
                                            //MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME = DateTime.Now;
                                            MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = null;
                                            BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT);



                                            string strError = "冲减失败!原因:更新用户编号为'" + strWaterUserID + "'的余额失败!";
                                            mes.Show(strError);
                                            log.Write(strError, MsgType.Error);
                                            return;
                                        }
                                        else
                                            try
                                            {
                                                for (int i = dgHistoryWaterFee.Rows.Count - 1; i > -1; i--)
                                                {
                                                    object objChargeID = dgHistoryWaterFee.Rows[i].Cells["CHARGEID"].Value;
                                                    if (objChargeID != null && objChargeID != DBNull.Value)
                                                    {
                                                        if (objChargeID.ToString() == MODELWATERFEECHARGE.CHARGEID)
                                                            dgHistoryWaterFee.Rows.Remove(dgHistoryWaterFee.Rows[i]);
                                                    }
                                                }
                                            }
                                            catch (Exception exx)
                                            {
                                                mes.Show(exx.Message);
                                                log.Write(exx.ToString(), MsgType.Error);
                                            }
                                    }
                                    catch (Exception ex)
                                    {
                                        //回滚收费表
                                        MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                        MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                        MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                        MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                        MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                        MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                        MODELWATERFEECHARGE.CANCELMEMO = null;
                                        BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                        //回滚发票状态
                                        MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID = txtChargeInvoicePrintID.Text;
                                        MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";
                                        MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = null;
                                        MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = null;
                                        ////MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME = DateTime.Now;
                                        MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = null;
                                        BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT);


                                        string strError = "更新用户编号为'" + strWaterUserID + "'的余额失败,原因:" + Environment.NewLine + ex.Message + Environment.NewLine + "请手动初始化预收余额!";
                                        mes.Show(strError);
                                        log.Write(ex.ToString(), MsgType.Error);
                                        return;
                                    }
                                }
                                else
                                {
                                    //回滚收费表
                                    MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                    MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                    MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                    MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                    MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                    MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                    MODELWATERFEECHARGE.CANCELMEMO = null;
                                    BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);
                                    mes.Show("更新发票状态失败!请重新选择要冲减的单据!");
                                    return;
                                }
                                #endregion
                            }
                            else
                            {
                                #region 没有发票的更新余额
                                //打印发票

                                //更新余额
                                try
                                {
                                    string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CANCELYSJSYE + " WHERE waterUserId='" + strWaterUserID + "'";
                                    if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                    {
                                        //回滚收费表
                                        MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                        MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                        MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                        MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                        MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                        MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                        MODELWATERFEECHARGE.CANCELMEMO = null;
                                        BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                        string strError = "冲减失败!原因:更新用户编号为'" + strWaterUserID + "'的余额失败!";
                                        mes.Show(strError);
                                        log.Write(strError, MsgType.Error);
                                        return;
                                    }
                                    else
                                        try
                                        {
                                            for (int i = dgHistoryWaterFee.Rows.Count - 1; i > -1; i--)
                                            {
                                                object objChargeID = dgHistoryWaterFee.Rows[i].Cells["CHARGEID"].Value;
                                                if (objChargeID != null && objChargeID != DBNull.Value)
                                                {
                                                    if (objChargeID.ToString() == MODELWATERFEECHARGE.CHARGEID)
                                                        dgHistoryWaterFee.Rows.Remove(dgHistoryWaterFee.Rows[i]);
                                                }
                                            }
                                        }
                                        catch (Exception exx)
                                        {
                                            mes.Show(exx.Message);
                                            log.Write(exx.ToString(), MsgType.Error);
                                        }
                                }
                                catch (Exception ex)
                                {
                                    //回滚收费表
                                    MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                    MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                    MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                    MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                    MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                    MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                    MODELWATERFEECHARGE.CANCELMEMO = null;
                                    BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                    string strError = "更新用户编号为'" + strWaterUserID + "'的余额失败,原因:" + Environment.NewLine + ex.Message + Environment.NewLine + "请手动初始化预收余额!";
                                    mes.Show(strError);
                                    log.Write(ex.ToString(), MsgType.Error);
                                    return;
                                }
                                #endregion
                            }
                        }
                        catch (Exception ex)
                        {
                            //回滚收费表
                            MODELWATERFEECHARGE.CHARGECANCEL = "0";
                            MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                            MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                            MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                            MODELWATERFEECHARGE.CHARGEWORKERID = null;
                            MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                            MODELWATERFEECHARGE.CANCELMEMO = null;
                            BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);
                            mes.Show("更新发票状态失败,原因:" + ex.Message);
                            log.Write("更新发票状态失败,原因:" + ex.ToString(), MsgType.Error);
                            return;
                        }
                    }
                    else
                    {
                        mes.Show("更新收费状态失败!请重新选择要冲减的单据!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show("更新收费状态失败,原因:" + ex.Message);
                log.Write("更新收费状态失败,原因:" + ex.ToString(), MsgType.Error);
                return;
            }
        }

        private void dgHistoryWaterFee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgHistoryWaterFee.Columns[e.ColumnIndex].Name == "INVOICECANCEL")
            {
                object objInvoiceCancel = dgHistoryWaterFee.Rows[e.RowIndex].Cells["INVOICECANCEL"].Value;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                {
                    if (objInvoiceCancel.ToString() == "0")
                        dgHistoryWaterFee.Rows[e.RowIndex].Cells["INVOICECANCEL"].Value = "正常";//如果有正常状态的发票就不能打印第二次  只能先作废再打印
                    else if (objInvoiceCancel.ToString() == "1")
                        dgHistoryWaterFee.Rows[e.RowIndex].Cells["INVOICECANCEL"].Value = "冲减作废";
                    else if (objInvoiceCancel.ToString() == "2")
                        dgHistoryWaterFee.Rows[e.RowIndex].Cells["INVOICECANCEL"].Value = "损坏作废";
                    else if (objInvoiceCancel.ToString() == "3")
                        dgHistoryWaterFee.Rows[e.RowIndex].Cells["INVOICECANCEL"].Value = "未打作废";
                }
                else
                    dgHistoryWaterFee.Rows[e.RowIndex].Cells["INVOICECANCEL"].Value = "未打发票";
            }
            if (dgHistoryWaterFee.Columns[e.ColumnIndex].Name == "CHARGECANCEL")
            {
                object objInvoiceCancel = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGECANCEL"].Value;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                    if (objInvoiceCancel.ToString() == "0")
                        dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGECANCEL"].Value = "正常";//如果有正常状态的发票就不能打印第二次  只能先作废再打印
                    else if (objInvoiceCancel.ToString() == "1")
                        dgHistoryWaterFee.Rows[e.RowIndex].Cells["INVOICECHARGECANCELCANCEL"].Value = "作废";
            }
        }


        private void btInvoiceCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgHistoryWaterFee.CurrentRow == null)
                    return;
                if (strGroupID == "0001")
                {
                    object objJZ = dgHistoryWaterFee.CurrentRow.Cells["MONTHCHECKSTATES"].Value;
                    if (objJZ != null && objJZ != DBNull.Value)
                    {
                        if (objJZ.ToString() == "是")
                        {
                            mes.Show("该单据已经结账，无法执行此操作!");
                            return;
                        }
                    }
                }
                else
                {
                    object objJZ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                    if (objJZ != null && objJZ != DBNull.Value)
                    {
                        if (objJZ.ToString() == "是")
                        {
                            mes.Show("该单据已经结账，无法执行此操作!");
                            return;
                        }
                    }
                }
                object objInvoiceCancel = dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                    if (objInvoiceCancel.ToString() == "作废")
                    {
                        mes.Show("该发票已经作废,无需再次作废!");
                        return;
                    }
                if (txtChargeInvoicePrintID.Text.Trim() != "" && txtChargeID.Text.Trim() != "")
                {
                    if (txtChargeID.Text.Trim() == "")
                    {
                        mes.Show("预存单号获取失败,无法作废发票!");
                        return;
                    }
                    string strInvoiceNO = "";
                    object objInvoiceNO = dgHistoryWaterFee.CurrentRow.Cells["INVOICENO"].Value;
                    if (objInvoiceNO != null && objInvoiceNO != DBNull.Value)
                    {
                        strInvoiceNO = objInvoiceNO.ToString();
                    }

                    if (cmbInvoiceCancelReason.SelectedIndex < 1)
                    {
                        cmbInvoiceCancelReason.Focus();
                        mes.Show("请选择发票作废原因!");
                        return;
                    }

                    if (mes.ShowQ("确定要将票号为'" + strInvoiceNO + "'的发票作废吗?") != DialogResult.OK)
                        return;
                    MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT = new MODELCHARGEINVOICEPRINT();
                    MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID = txtChargeInvoicePrintID.Text;
                    MODELCHARGEINVOICEPRINT.INVOICECANCEL = (cmbInvoiceCancelReason.SelectedIndex + 1).ToString();
                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = strLogID;
                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = strLoginName;
                    MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME = mes.GetDatetimeNow();
                    MODELCHARGEINVOICEPRINT.CHARGEID = txtChargeID.Text;
                    //MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = txtMemo.Text;
                    if (BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT))
                    {
                        //更新收费表已打发票标志
                        if (txtChargeID.Text.Trim() != "")
                        {
                            MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                            MODELWATERFEECHARGE.CHARGEID = txtChargeID.Text;
                            MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                            if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                            {
                            }
                        }
                        dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value = "作废";
                        btInvoiceCancel.Enabled = false;
                        btInvoicePrint.Enabled = true;
                        mes.Show("票号为'" + strInvoiceNO + "'的发票作废成功!");
                    }
                }
                else
                {
                    mes.Show("收费单号或发票单据号为空,发票作废失败!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message + "发票作废失败!请重新选择要变更的单据!");
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
        }

        private void btInvoicePrint_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            if (strGroupID == "0001")
            {
                object objJZ = dgHistoryWaterFee.CurrentRow.Cells["MONTHCHECKSTATES"].Value;
                if (objJZ != null && objJZ != DBNull.Value)
                {
                    if (objJZ.ToString() == "是")
                    {
                        mes.Show("该单据已经结账，无法执行此操作!");
                        return;
                    }
                }
            }
            else
            {
                object objJZ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZ != null && objJZ != DBNull.Value)
                {
                    if (objJZ.ToString() == "是")
                    {
                        mes.Show("该单据已经结账，无法执行此操作!");
                        return;
                    }
                }
            }

            object objInvoiceCancel = dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value;
            if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                if (objInvoiceCancel.ToString() == "正常")
                {
                    mes.Show("该收费单已打印发票，如需更换发票请先点击'发票作废'后再补打或者直接点击'发票变更'更换发票!");
                    return;
                }
            // 补打发票
            if (cmbBatch.SelectedValue == null || cmbBatch.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择发票批次!");
                cmbBatch.Focus();
                return;
            }
            if (txtInvoiceNO.Text.Trim() == "")
            {
                mes.Show("请输入补打的发票号码!");
                txtInvoiceNO.Focus();
                return;
            }
            txtInvoiceNO.Text = txtInvoiceNO.Text.PadLeft(8, '0');
            DataTable dtCheckInvoiceExists = BLLWATERFEECHARGE.QueryChargeView(" AND INVOICENO='" + txtInvoiceNO.Text + "' AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICECANCEL<>'3'");
            if (dtCheckInvoiceExists.Rows.Count > 0)
            {
                mes.Show("发票批次为'" + cmbBatch.Text + "'票号为'" + txtInvoiceNO.Text + "'的发票已使用，请重新输入发票号码!");
                txtInvoiceNO.Focus();
                return;
            }
            else
            {
                DataTable dtInvoiceFetch = BLLINVOICEFETCH.Query(" AND  INVOICEFETCHBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                #region 验证发票领取记录是否重复
                bool isExist = false;
                for (int i = 0; i < dtInvoiceFetch.Rows.Count; i++)
                {
                    long intStartNO = 0, intEndNO = 0;
                    object obj = dtInvoiceFetch.Rows[i]["INVOICEFETCHSTARTNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intStartNO = Convert.ToInt64(obj);
                    }
                    obj = dtInvoiceFetch.Rows[i]["INVOICEFETCHENDNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intEndNO = Convert.ToInt64(obj);
                    }
                    if (Convert.ToInt64(txtInvoiceNO.Text) >= intStartNO && Convert.ToInt64(txtInvoiceNO.Text) <= intEndNO)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    mes.Show("批次为'" + cmbBatch.Text + "'的发票起始号码不在领取记录中,请确认发票号码是否正确!");
                    txtInvoiceNO.Focus();
                    return;
                }
                #endregion
            }
            string strWaterUserName = "", strWaterUserNO = "";
            object objWaterUserName = dgHistoryWaterFee.CurrentRow.Cells["waterUserName"].Value;
            if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                strWaterUserName = objWaterUserName.ToString();

            object objWaterUserNO = dgHistoryWaterFee.CurrentRow.Cells["waterUserNO"].Value;
            if (objWaterUserNO != null && objWaterUserNO != DBNull.Value)
                strWaterUserNO = objWaterUserNO.ToString();

            if (mes.ShowQ("确定要将用户'" + strWaterUserNO + "-" + strWaterUserName + "'的收费单据'" + txtChargeID.Text + "'补打票号为'" + txtInvoiceNO.Text + "'的发票吗?") != DialogResult.OK)
                return;
            try
            {
                MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID("", "CHARGEINVOICEPRINT");
                MODELCHARGEINVOICEPRINTNEW.CHARGEID = txtChargeID.Text;
                MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                MODELCHARGEINVOICEPRINTNEW.INVOICENO = txtInvoiceNO.Text;
                MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatch.Text;
                MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTDATETIME = mes.GetDatetimeNow();
                if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW))
                {
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = txtChargeID.Text;
                    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";
                    if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                    {

                    }
                    dgHistoryWaterFee.CurrentRow.Cells["CHARGEINVOICEPRINTID"].Value = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                    dgHistoryWaterFee.CurrentRow.Cells["INVOICEBATCHNAME"].Value = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                    dgHistoryWaterFee.CurrentRow.Cells["INVOICENO"].Value = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                    dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value = "正常";
                    //mes.Show("发票补打成功!新的发票号为'" + MODELCHARGEINVOICEPRINTNEW.INVOICENO + "'");

                    //打印发票

                    //获取新的发票号码
                    if (cmbBatch.SelectedValue != null && cmbBatch.SelectedValue != DBNull.Value)
                    {
                        DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLogID, cmbBatch.SelectedValue.ToString());
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
                else
                {
                    mes.Show("发票补打失败!请重新选择要补打发票的单据!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show("发票补打失败!原因:" + ex.Message);
                log.Write("发票补打失败!原因:" + ex.ToString(), MsgType.Error);
                return;
            }
        }

        private void btReceiptPrint_Click(object sender, EventArgs e)
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
                        mes.Show("该单据已日结，无法执行此操作!");
                        return;
                    }
                }
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

            if (strGroupID != "0001")
            {

                #region 验证是否在领取记录中
                DataTable dtReceiptNO = new DataTable();
                bool isExists = false;
                dtReceiptNO = BLLRECEIPTFETCH.Query(" AND RECEIPTFETCHERID='" + strLogID + "'");
                if (dtReceiptNO.Rows.Count == 0)
                {
                    mes.Show("收据号'" + txtReceiptNO.Text + "'不在领取记录中,请领取收据!");
                    return;
                }
                for (int i = 0; i < dtReceiptNO.Rows.Count; i++)
                {
                    long intStartNO = 0, intEndNO = 0;
                    object obj = dtReceiptNO.Rows[i]["RECEIPTFETCHSTARTNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intStartNO = Convert.ToInt64(obj);
                    }
                    obj = dtReceiptNO.Rows[i]["RECEIPTFETCHENDNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intEndNO = Convert.ToInt64(obj);
                    }
                    if (Convert.ToInt64(txtReceiptNO.Text) >= intStartNO && Convert.ToInt64(txtReceiptNO.Text) <= intEndNO)
                    {
                        isExists = true;
                        break;
                    }
                }
                #endregion

                if (!isExists)
                {
                    mes.Show("收据号'" + txtReceiptNO.Text + "'不在领取记录中,请领取收据!");
                    return;
                }
            }
            if (BLLWATERFEECHARGE.IsExistReceiptNO(txtReceiptNO.Text))
            {
                if (mes.ShowQ("系统检测到号码为'" + txtReceiptNO.Text + "'的收据已使用,确定使用此号码吗?") != DialogResult.OK)
                {
                    txtReceiptNO.SelectAll();
                    return;
                }
            }
            string strWaterUserName = "", strWaterUserNO = "", strWaterUserAddress = "", strQQYE = "",
                strBCYS = "", strBCSS = "", strJSYE = "", strSFSJ = "", strWorkerName = "",
                    strMeterReaderID = "", strMeterReaderName = "", strMeterReaderTel = "";

            object objWaterUserName = dgHistoryWaterFee.CurrentRow.Cells["waterUserName"].Value;
            if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                strWaterUserName = objWaterUserName.ToString();

            object objWaterUserNO = dgHistoryWaterFee.CurrentRow.Cells["waterUserNO"].Value;
            if (objWaterUserNO != null && objWaterUserNO != DBNull.Value)
                strWaterUserNO = objWaterUserNO.ToString();

            object objWaterUserAddress = dgHistoryWaterFee.CurrentRow.Cells["waterUserAddress"].Value;
            if (objWaterUserAddress != null && objWaterUserAddress != DBNull.Value)
                strWaterUserAddress = objWaterUserAddress.ToString();

            object objJSYE = dgHistoryWaterFee.CurrentRow.Cells["CHARGEYSJSYE"].Value;
            if (Information.IsNumeric(objJSYE))
                strJSYE = Convert.ToDecimal(objJSYE).ToString("F2");

            object objBCSS = dgHistoryWaterFee.CurrentRow.Cells["CHARGEYSBCSZ"].Value;
            if (Information.IsNumeric(objBCSS))
                strBCSS = Convert.ToDecimal(objBCSS).ToString("F2");

            object objQQYE = dgHistoryWaterFee.CurrentRow.Cells["CHARGEYSQQYE"].Value;
            if (Information.IsNumeric(objQQYE))
                strQQYE = Convert.ToDecimal(objQQYE).ToString("F2");

            object objSFSJ = dgHistoryWaterFee.CurrentRow.Cells["CHARGEDATETIME"].Value;
            if (Information.IsDate(objSFSJ))
                strSFSJ = Convert.ToDateTime(objSFSJ).ToString("yyyy-MM-dd HH:mm:ss");
            else
            {
                strSFSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            object objWorkerName = dgHistoryWaterFee.CurrentRow.Cells["CHARGEWORKERNAME"].Value;
            if (objWorkerName != null && objWorkerName != DBNull.Value)
                strWorkerName = objWorkerName.ToString();

            object objmeterReaderID = dgHistoryWaterFee.CurrentRow.Cells["meterReaderID"].Value;
            if (objmeterReaderID != null && objmeterReaderID != DBNull.Value)
            {
                strMeterReaderID = objmeterReaderID.ToString();
                DataRow[] dr = dtMeterReader.Select("loginId='" + strMeterReaderID + "'");
                if (dr.Length > 0)
                {
                    object objmeterReaderName = dr[0]["loginName"];
                    if (objmeterReaderName != null && objmeterReaderName != DBNull.Value)
                    {
                        strMeterReaderName = objmeterReaderName.ToString();
                    }
                    objmeterReaderName = dr[0]["telePhoneNO"];
                    if (objmeterReaderName != null && objmeterReaderName != DBNull.Value)
                    {
                        strMeterReaderTel = objmeterReaderName.ToString();
                    }
                }

            }

            try
            {
                //更新收费表已打发票标志
                if (txtChargeID.Text.Trim() != "")
                {
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = txtChargeID.Text;
                    MODELWATERFEECHARGE.RECEIPTNO = txtReceiptNO.Text;
                    if (BLLWATERFEECHARGE.UpdateReceiptPrintCount(MODELWATERFEECHARGE))
                    {
                        //--打印收据
                        #region
                        FastReport.Report report1 = new FastReport.Report();
                        try
                        {
                            DataTable dtLastRecord = BLLwaterUser.QuerySQL("SELECT TOP 1 * FROM  readMeterRecord WHERE WATERUSERID='" +
                                strWaterUserNO + "' AND checkState='1' AND chargeState<>'0' ORDER BY readMeterRecordDate DESC");
                            //DataTable dtTemp = dtLastRecord.Copy();
                            DataTable dtTemp = dtLastRecord.Clone();
                            dtTemp.Columns["readMeterRecordYearAndMonth"].DataType = typeof(string);
                            if (dtLastRecord.Rows.Count > 0)
                            {
                                dtTemp.ImportRow(dtLastRecord.Rows[0]);
                                object objReadMeterRecordYearAndMonth=dtTemp.Rows[0]["readMeterRecordYearAndMonth"];
                                if (Information.IsDate(objReadMeterRecordYearAndMonth))
                                    dtTemp.Rows[0]["readMeterRecordYearAndMonth"] = Convert.ToDateTime(objReadMeterRecordYearAndMonth).ToString("yyyy-MM");
                            }
                            DataSet ds = new DataSet();
                            dtTemp.TableName = "营业坐收收据模板";
                            ds.Tables.Add(dtTemp);
                            // load the existing report
                            report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\预存收费收据模板.frx");


                            (report1.FindObject("txtDateTime") as FastReport.TextObject).Text = strSFSJ;
                            //if (cmbChargeType.SelectedValue.ToString() == "2")
                            //{
                            //    (report1.FindObject("Cell45") as FastReport.Table.TableCell).Text = txtWaterUserNO.Text + "   交易流水号:" + txtJYLSH.Text;
                            //}
                            //else
                            (report1.FindObject("CellWaterUserNO") as FastReport.Table.TableCell).Text = strWaterUserNO;
                            (report1.FindObject("CellWaterUserName") as FastReport.Table.TableCell).Text = strWaterUserName;
                            (report1.FindObject("CellWaterUserAddress") as FastReport.Table.TableCell).Text = strWaterUserAddress;

                            (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额: " + strQQYE;
                            //string strBCSS = MODELWATERFEECHARGE.CHARGEBCSS.ToString("F2");
                            (report1.FindObject("txtBCJF") as FastReport.TextObject).Text = "本次预存:         " + strBCSS;
                            (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额: " + strJSYE;

                            //if (cmbChargeType.SelectedValue.ToString() == "2")
                            //{
                            //    (report1.FindObject("txtPOSRUNNINGNO") as FastReport.TextObject).Text = "交易流水号: " + MODELWATERFEECHARGE.POSRUNNINGNO;
                            //}
                            (report1.FindObject("txtChargeWorkerName") as FastReport.TextObject).Text = strWorkerName;
                            (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + txtReceiptNO.Text;

                            (report1.FindObject("txtMeterReader") as FastReport.TextObject).Text = strMeterReaderName;
                            (report1.FindObject("txtMeterReaderTel") as FastReport.TextObject).Text = strMeterReaderTel;

                            string strCapMoney = RMBToCapMoney.CmycurD(strBCSS);
                            (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;
                            //if (cmbChargeType.SelectedValue.ToString() == "2")
                            //{
                            //    (report1.FindObject("Cell82") as FastReport.Table.TableCell).Text = strCapMoney + "   交易流水号:" + txtJYLSH.Text;
                            //}
                            //else
                            //(report1.FindObject("Cell82") as FastReport.Table.TableCell).Text = strCapMoney;

                            report1.RegisterData(ds);
                            report1.PrintSettings.ShowDialog = false;
                            report1.Prepare();
                            report1.Print();

                            //获取新的收据号码,8位收据号
                            if (Information.IsNumeric(txtReceiptNO.Text))
                            {
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
                        mes.Show("更新收据打印标志失败!");
                        return;
                    }
                }
                else
                {
                    mes.Show("更新收据打印标志失败!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show("收据打印失败!原因:" + ex.Message);
                log.Write("收据打印失败!原因:" + ex.ToString(), MsgType.Error);
                return;
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

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btSearch_Click(null,null);
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
                        dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value =DBNull.Value;
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

        private void btModify_Click(object sender, EventArgs e)
        {
            if (cmbChargeTypeNew.SelectedValue == null || cmbChargeTypeNew.SelectedValue == DBNull.Value)
            {
                mes.Show("新的收款方式不能为空!");
                return;
            }
            if (dgHistoryWaterFee.CurrentRow == null)
                return;

            string strID = cmbChargeTypeNew.SelectedValue.ToString();
            if (strID == "2" || strID == "3")
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
                mes.Show("修改收款方式失败,原因:" + ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
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

        private void btSetMonth_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(btSetMonth, 0, btSetMonth.Width + 1);
        }
    }
}
