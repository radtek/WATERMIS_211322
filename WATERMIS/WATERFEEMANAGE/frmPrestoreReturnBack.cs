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
using System.Threading;

namespace WATERFEEMANAGE
{
    public partial class frmPrestoreReturnBack : DockContentEx
    {
        public frmPrestoreReturnBack()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLINVOICEFETCH BLLINVOICEFETCH = new BLLINVOICEFETCH();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
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
        private void frmPrestoreCharge_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgHistoryWaterFee.AutoGenerateColumns = false;
            //dgHistoryWaterFee.MouseWheel += new MouseEventHandler(dgHistoryWaterFee_MouseWheel);//加入鼠标滚动事件

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

            this.Text = "用户余额退费——当前收费员:" + strLoginName;

            chkReceipt.Checked = true;
        }

        /// <summary>
        /// 绑定用户类型
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
            string strFilter = "";
            if (txtWaterUserNOSearch.Text.Trim() != "")
            {
                if (txtWaterUserNOSearch.Text.Length < 6)
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                else
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
            }

            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

            if (txtNameCodeS.Text.Trim() != "")
                strFilter += " AND waterUserNameCode like '%" + txtNameCodeS.Text.Trim() + "%'";

            if (txtAddress.Text.Trim() != "")
                strFilter += " AND waterUserAddress LIKE '%" + txtAddress.Text + "%'";
            LoadDebtsDate(strFilter);
        }
        //Thread TD;
        //private void RefreshData()
        //{
        //    try
        //    {
        //        TD = new Thread(showwaitfrm);
        //        TD.Start();
        //        //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
        //        LoadDebtsDate();
        //        TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Write("水费预收界面:" + ex.ToString(), MsgType.Error);
        //        TD.Abort();
        //    }
        //}
        ////传递给线程的方法.
        //private void showwaitfrm()
        //{
        //    try
        //    {
        //        frmWait waitfrm = new frmWait();
        //        waitfrm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Write("水费预收界面:" + ex.ToString(), MsgType.Error);
        //    }
        //}

        /// <summary>
        /// 选择的用户编号
        /// </summary>
        public string strSelectWaterUser = "";
        /// <summary>
        /// 获取欠费用户列表
        /// </summary>
        /// <param name="strFilter"></param>
        private void LoadDebtsDate(string strFilter)
        {

            foreach (Control con in gpbWaterUserMES.Controls)
            {
                if (con is TextBox)
                    con.Text = "";
            }
            txtYSQQYE.Text = "0";
            txtWaterFee.Text = "0";
            txtWaterFeeReal.Text = "0";
            txtMemo.Clear();

            btCharge.Enabled = false;

            dgHistoryWaterFee.DataSource = null;
            btSearchLS.Enabled = false;

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

            DataTable dtUserList = BLLwaterUser.QueryInitialWaterUser(strFilter);
            if (dtUserList.Rows.Count > 0)
            {
                //if (dtUserList.Rows.Count > 500)
                //{
                //    mes.Show("符合条件的用户大约500户,请设置更多查询条件!");
                //    return;
                //}
                if (dtUserList.Rows.Count > 1)
                {
                    frmSingleChargeSelectWaterUser frm = new frmSingleChargeSelectWaterUser();
                    frm.dtWaterUserList = dtUserList;
                    frm.Owner = this;
                    frm.strFormType = "4";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {

                    }
                    else
                    {
                        //dgWaterList.DataSource = null;
                        //labTip.Text = "未找到用户信息";
                        btSearchLS.Enabled = false;
                        btCharge.Enabled = false;
                        txtWaterUserNOSearch.Focus();
                        return;
                    }
                }
                else
                {
                    object objWaterUserIDSingle = dtUserList.Rows[0]["WATERUSERID"];
                    if (objWaterUserIDSingle != null && objWaterUserIDSingle != DBNull.Value)
                    {
                        strSelectWaterUser = objWaterUserIDSingle.ToString();
                    }
                }
                if (strSelectWaterUser == "")
                {
                    mes.Show("获取用户号失败,请重新查询!");
                    return;
                }
                DataView dvUserList = dtUserList.DefaultView;
                dvUserList.RowFilter = "WATERUSERID='" + strSelectWaterUser + "'";
                dtUserList = dvUserList.ToTable();
                object objWaterUserID = dtUserList.Rows[0]["waterUserId"];
                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                {
                    txtWaterUserID.Text = objWaterUserID.ToString();

                    #region 生成用户信息
                    object objWaterUserMes = dtUserList.Rows[0]["waterUserNO"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserNO.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserName"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserName.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserNameCode"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtNameCode.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserTelphoneNO"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserPhone.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterPhone"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        if (txtWaterUserPhone.Text!="")
                        txtWaterUserPhone.Text += ";" + objWaterUserMes.ToString();
                        else
                            txtWaterUserPhone.Text = objWaterUserMes.ToString();
                    }

                    object objWaterUser = dtUserList.Rows[0]["areaNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtAreaNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtAreaNO.Clear();
                    objWaterUser = dtUserList.Rows[0]["pianNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtPianNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtPianNO.Clear();
                    objWaterUser = dtUserList.Rows[0]["duanNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtDuanNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtDuanNO.Clear();
                    objWaterUser = dtUserList.Rows[0]["COMMUNITYNAME"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtCommunity.Text = objWaterUser.ToString();
                    }
                    else
                        txtCommunity.Clear();

                    objWaterUser = dtUserList.Rows[0]["buildingNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtBuildingNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtBuildingNO.Clear();
                    objWaterUser = dtUserList.Rows[0]["unitNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtUnitNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtUnitNO.Clear();


                    objWaterUserMes = dtUserList.Rows[0]["waterMeterTypeId"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeID.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeID.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["waterMeterTypeValue"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeValue.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeValue.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["WATERMETERTYPECLASSID"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeClassID.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeClassID.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["WATERMETERTYPECLASSNAME"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeClassName.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeClassName.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["WATERUSERTYPEID"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserTypeID.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserTypeName"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserType.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserAddress"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserAddress.Text = objWaterUserMes.ToString();
                    }
                    //objWaterUser = dtUserList.Rows[0]["createType"];
                    //if (objWaterUser != null && objWaterUser != DBNull.Value)
                    //{
                    //    txtCreateType.Text = objWaterUser.ToString();
                    //}
                    //else
                    //    txtCreateType.Clear();
                    objWaterUser = dtUserList.Rows[0]["METERREADERID"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtMeterReaderID.Text = objWaterUser.ToString();
                       DataTable dtLoginID= BLLBASE_LOGIN.QueryUser(" AND loginId='"+objWaterUser.ToString()+"'");
                       objWaterUser = dtLoginID.Rows[0]["telePhoneNO"];
                       if (objWaterUser != null && objWaterUser != DBNull.Value)
                           txtMeterReaderTel.Text = objWaterUser.ToString();
                    }
                    else
                        txtMeterReaderID.Clear();
                    objWaterUser = dtUserList.Rows[0]["meterReaderName"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtMeterReader.Text = objWaterUser.ToString();
                    }
                    else
                        txtMeterReader.Clear();
                    objWaterUser = dtUserList.Rows[0]["chargerName"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtCharger.Text = objWaterUser.ToString();
                    }
                    else
                        txtCharger.Clear();
                    objWaterUser = dtUserList.Rows[0]["CHARGERID"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtChargerID.Text = objWaterUser.ToString();
                    }
                    else
                        txtChargerID.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["ordernumber"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtOrderNumber.Text = objWaterUserMes.ToString();
                    }


                    //查询用户余额
                    objWaterUserMes = dtUserList.Rows[0]["prestore"];
                    if (Information.IsNumeric(objWaterUserMes))
                    {
                        txtYSQQYE.Text = Convert.ToDecimal(objWaterUserMes).ToString("F2");
                    }
                    //try
                    //{
                    //    DataTable dtWaterMeterCount = BLLwaterMeter.Query(" AND WATERUSERID='" + txtWaterUserID.Text + "' AND waterMeterState='1'");
                    //    txtWaterMeterCount.Text = dtWaterMeterCount.Rows.Count + " 块";
                    //}
                    //catch (Exception ex)
                    //{
                    //    log.Write(ex.ToString(), MsgType.Error);
                    //}

                    //如果用户是非预存交费用户，则不允许收费
                    object objWaterUserChargeType = dtUserList.Rows[0]["chargeType"];
                    if (objWaterUserChargeType != null && objWaterUserChargeType != DBNull.Value)
                    {
                        if (objWaterUserChargeType.ToString() == "0")
                        {
                            mes.Show("用户'" + txtWaterUserName.Text + "'为非预存用户,无法执行收费操作!");
                            return;
                        }
                    }

                    //如果用户存在欠费金额，则不允退费
                    object objWaterUserQF = BLLreadMeterRecord.QueryQFByWaterUser(objWaterUserID.ToString());
                    if (Information.IsNumeric(objWaterUserQF))
                    {
                        txtWaterFee.Text = Convert.ToDecimal(objWaterUserQF).ToString("F2");
                        if (Convert.ToDecimal(objWaterUserQF) > 0)
                        {
                            mes.Show("当前用户存在欠费余额,无法执行退费操作!");
                            return;
                        }
                    }
                    else
                        txtWaterFee.Text = "0";

                    object objWaterMeterState = dtUserList.Rows[0]["waterMeterState"];
                    if(objWaterMeterState!=null&&objWaterMeterState!=DBNull.Value)
                        if (objWaterMeterState.ToString() != "2")
                        {
                            mes.Show("请先走销户审批流程!");
                            return;
                        }

                    btSearchLS.Enabled = true;
                    btCharge.Enabled = true;
                    #endregion
                }

            }
            else
            {
                mes.Show("未找到用户信息!");
                return;
            }
        }

        private void btCharge_Click(object sender, EventArgs e)
        {
            if (txtWaterUserID.Text.Trim() == "")
            {
                mes.Show("未找到用户ID信息,请重新查询后重试!");
                txtWaterUserNOSearch.Focus();
                return;
            }

            //如果用户存在欠费金额，则不允退费
            object objWaterUserQF = BLLreadMeterRecord.QueryQFByWaterUser(txtWaterUserID.Text.Trim());
            if (Information.IsNumeric(objWaterUserQF))
            {
                txtWaterFee.Text = Convert.ToDecimal(objWaterUserQF).ToString("F2");
                if (Convert.ToDecimal(objWaterUserQF) > 0)
                {
                    mes.Show("当前用户存在欠费余额,无法执行退费操作!");
                    return;
                }
            }
            else
                txtWaterFee.Text = "0";

            if (Convert.ToDecimal(txtYSQQYE.Text) <= 0)
            {
                mes.Show("用户预存余额为0，无需退费!");
                txtYSQQYE.Focus();
                return;
            }

            if (chkReceipt.Checked)
            {
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
            }

            try
            {
                MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLoginID, "WATERFEECHARGE");
                MODELWATERFEECHARGE.CHARGETYPEID ="1";
                MODELWATERFEECHARGE.CHARGEClASS = "6";//收费类型是用户余额退费 
                MODELWATERFEECHARGE.CHARGEYSQQYE = Convert.ToDecimal(txtYSQQYE.Text);
                MODELWATERFEECHARGE.CHARGEBCSS = 0 - MODELWATERFEECHARGE.CHARGEYSQQYE;
                MODELWATERFEECHARGE.CHARGEYSBCSZ = 0-MODELWATERFEECHARGE.CHARGEYSQQYE;
                MODELWATERFEECHARGE.CHARGEYSJSYE =0;
                MODELWATERFEECHARGE.CHARGEWORKERID = strLoginID;
                MODELWATERFEECHARGE.CHARGEWORKERNAME = strLoginName;
                MODELWATERFEECHARGE.CHARGEDATETIME = mes.GetDatetimeNow();
                MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                if (chkReceipt.Checked)
                {
                    MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 1;
                    MODELWATERFEECHARGE.RECEIPTNO = txtReceiptNO.Text;
                }
                MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                MODELWATERFEECHARGE.MEMO = txtMemo.Text;
                if (BLLWATERFEECHARGE.Insert(MODELWATERFEECHARGE))
                {
                    try
                    {
                        MODELPRESTORERUNNINGACCOUNT MODELPRESTORERUNNINGACCOUNT = new MODELPRESTORERUNNINGACCOUNT();
                        MODELPRESTORERUNNINGACCOUNT.PRESTORERUNNINGACCOUNTID = GETTABLEID.GetTableID(strLoginID, "PRESTORERUNNINGACCOUNT");
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERID = txtWaterUserID.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERNO = txtWaterUserNO.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERNAME = txtWaterUserName.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERNAMECODE = txtNameCode.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERPHONE = txtWaterUserPhone.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERADDRESS = txtWaterUserAddress.Text;
                        if (Information.IsNumeric(txtWaterUserPeopleCount.Text))
                            MODELPRESTORERUNNINGACCOUNT.WATERUSERPEOPLECOUNT = Convert.ToInt16(txtWaterUserPeopleCount.Text);
                        MODELPRESTORERUNNINGACCOUNT.AREANO = txtAreaNO.Text;
                        MODELPRESTORERUNNINGACCOUNT.PIANNO = txtPianNO.Text;
                        MODELPRESTORERUNNINGACCOUNT.DUANNO = txtDuanNO.Text;
                        MODELPRESTORERUNNINGACCOUNT.COMMUNITYID = txtCommunityID.Text;
                        MODELPRESTORERUNNINGACCOUNT.COMMUNITYNAME = txtCommunity.Text;
                        if (Information.IsNumeric(txtOrderNumber.Text))
                            MODELPRESTORERUNNINGACCOUNT.ORDERNUMBER = Convert.ToInt16(txtOrderNumber.Text);
                        //MODELPRESTORERUNNINGACCOUNT.BUILDINGNO = txtBuildingNO.Text;
                        //MODELPRESTORERUNNINGACCOUNT.UNITNO = txtUnitNO.Text;
                        MODELPRESTORERUNNINGACCOUNT.METERREADERID = txtMeterReaderID.Text;
                        MODELPRESTORERUNNINGACCOUNT.METERREADERNAME = txtMeterReader.Text;
                        MODELPRESTORERUNNINGACCOUNT.CHARGERID = txtChargerID.Text;
                        MODELPRESTORERUNNINGACCOUNT.CHARGERNAME = txtCharger.Text;
                        MODELPRESTORERUNNINGACCOUNT.waterMeterTypeId = txtWaterMeterTypeID.Text;
                        MODELPRESTORERUNNINGACCOUNT.waterMeterTypeValue = txtWaterMeterTypeValue.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERMETERTYPECLASSID = txtWaterMeterTypeClassID.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERMETERTYPECLASSNAME = txtWaterMeterTypeClassName.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPEID = txtWaterUserTypeID.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPENAME = txtWaterUserType.Text;
                        //MODELPRESTORERUNNINGACCOUNT.WATERUSERHOUSETYPE = txtWaterUserHouseType.Text;
                        //MODELPRESTORERUNNINGACCOUNT.CREATETYPE = txtCreateType.Text;
                        //MODELPRESTORERUNNINGACCOUNT.MEMO = txtMemo.Text;
                        MODELPRESTORERUNNINGACCOUNT.CHARGEID = MODELWATERFEECHARGE.CHARGEID;
                        if (BLLPRESTORERUNNINGACCOUNT.Insert(MODELPRESTORERUNNINGACCOUNT))
                        {
                            //txtYSQQYE.Text = txtJSYE.Text;
                            //txtWaterFeeReal.Text =( Convert.ToDecimal(txtWaterFee.Text) - Convert.ToDecimal(txtYSQQYE.Text)).ToString();
                            //txtBCYC.Text = "0";
                            btCharge.Enabled = false;
                            btSearchLS_Click(null, null);

                            //更新余额
                            string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CHARGEYSJSYE + " WHERE waterUserId='" + txtWaterUserID.Text + "'";
                            if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                            {
                                string strError = "更新用户编号为'" + txtWaterUserID.Text + "'的余额失败,请手动添加预收余额!";
                                mes.Show(strError);
                                log.Write(strError, MsgType.Error);
                            }
                            //如果勾选了打收据，打印收据
                            else if (chkReceipt.Checked)
                            {
                                //--打印收据
                                #region
                                FastReport.Report report1 = new FastReport.Report();
                                try
                                {
                                    report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\退费收据模板.frx");

                                    (report1.FindObject("txtDateTime") as FastReport.TextObject).Text = MODELWATERFEECHARGE.CHARGEDATETIME.ToString("yyyy-MM-dd HH:mm:ss");
                                    //if (cmbChargeType.SelectedValue.ToString() == "2")
                                    //{
                                    //    (report1.FindObject("Cell45") as FastReport.Table.TableCell).Text = txtWaterUserNO.Text + "   交易流水号:" + txtJYLSH.Text;
                                    //}
                                    //else
                                    (report1.FindObject("CellWaterUserNO") as FastReport.Table.TableCell).Text = txtWaterUserNO.Text;
                                    (report1.FindObject("CellWaterUserName") as FastReport.Table.TableCell).Text = txtWaterUserName.Text;
                                    (report1.FindObject("CellWaterUserAddress") as FastReport.Table.TableCell).Text = txtWaterUserAddress.Text;

                                    (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额: " + MODELWATERFEECHARGE.CHARGEYSQQYE.ToString("F2");
                                    (report1.FindObject("txtBCTF") as FastReport.TextObject).Text = "本次退费:         " + MODELWATERFEECHARGE.CHARGEYSBCSZ;
                                    (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额: " + MODELWATERFEECHARGE.CHARGEYSJSYE.ToString("F2");

                                    //if (cmbChargeType.SelectedValue.ToString() == "2")
                                    //{
                                    //    (report1.FindObject("txtPOSRUNNINGNO") as FastReport.TextObject).Text = "交易流水号: " + MODELWATERFEECHARGE.POSRUNNINGNO;
                                    //}
                                    (report1.FindObject("txtChargeWorkerName") as FastReport.TextObject).Text = strLoginName;
                                    (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + txtReceiptNO.Text;

                                    (report1.FindObject("txtMeterReader") as FastReport.TextObject).Text = txtMeterReader.Text;
                                    (report1.FindObject("txtMeterReaderTel") as FastReport.TextObject).Text = txtMeterReaderTel.Text;

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
                        }
                    }
                    catch (Exception exx)
                    {
                        mes.Show("插入预收流水表失败!原因:" + exx.Message);
                        log.Write(exx.ToString(), MsgType.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show("预收失败!原因:" + ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
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
        private void btSearchLS_Click(object sender, EventArgs e)
        {
            string strFilter = " AND WATERUSERID='" + txtWaterUserID.Text + "'";
            if (rbLastThreeMonth.Checked)
            {
                strFilter += " AND DATEDIFF(MONTH,CHARGEDATETIME,GETDATE())<4";
            }
            else if (rbLastSixMonth.Checked)
            {
                strFilter += " AND DATEDIFF(MONTH,CHARGEDATETIME,GETDATE())<7";
            }
            else if (rbDateTime.Checked)
            {
                strFilter += " AND  CHARGEDATETIME BETWEEN '"+dtpStart.Text+"' AND '"+dtpEnd.Text+"'";
            }
            strFilter += " ORDER BY CHARGEDATETIME";
            //DataTable dt = BLLPRESTORERUNNINGACCOUNT.Query(strFilter);
            DataTable dt =  BLLWATERFEECHARGE.QueryWaterFeeAndPrestoreCharge(strFilter);
            dgHistoryWaterFee.DataSource = dt;
        }

        private void txtInvoiceNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void dgHistoryWaterFee_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {//判断是不是列Header
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

        private void chkReceipt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReceipt.Checked)
            {
                labReceiptNO.Visible = true;
                txtReceiptNO.Visible = true;
            }
        }

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(null, null);
            }
        }

        private void dgHistoryWaterFee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgHistoryWaterFee.Columns[e.ColumnIndex].Name == "CHARGEClASS")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if(e.Value.ToString()=="1")
                        e.Value = "水费";
                    else if (e.Value.ToString() == "2")
                        e.Value = "预存";
                    else if (e.Value.ToString() == "3")
                        e.Value = "结算水费";
                    else if (e.Value.ToString() == "4")
                        e.Value = "红冲水费";
                    else if (e.Value.ToString() == "5")
                        e.Value = "红冲预存";
                    else if (e.Value.ToString() == "6")
                        e.Value = "退费";
                }
            }
        }

    }
}
