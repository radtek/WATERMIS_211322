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
    public partial class frmPrestoreTransfer : DockContentEx
    {
        public frmPrestoreTransfer()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            tb2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb2, true, null);
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

        private void btSearch_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (txtWaterUserNOSearch1.Text.Trim() != "")
            {
                if (txtWaterUserNOSearch1.Text.Length < 6)
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch1.Text.PadLeft(5, '0') + "'";
                else
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch1.Text + "'";
            }

            if (txtWaterUserNameSearch1.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch1.Text.Trim() + "%'";

            if (txtAddress1.Text.Trim() != "")
                strFilter += " AND waterUserAddress LIKE '%" + txtAddress1.Text + "%'";
            LoadDebtsDate(strFilter);
        }

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
                    frm.strFormType = "5";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {

                    }
                    else
                    {
                        btCharge.Enabled = false;
                        txtWaterUserNOSearch1.Focus();
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
                    txtWaterUserID1.Text = objWaterUserID.ToString();

                    #region 生成用户信息
                    object objWaterUserMes = dtUserList.Rows[0]["waterUserNO"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserNO1.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserName"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserName1.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserNameCode"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtNameCode1.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserTelphoneNO"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserPhone1.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterPhone"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        if (txtWaterUserPhone1.Text!="")
                        txtWaterUserPhone1.Text += ";" + objWaterUserMes.ToString();
                        else
                            txtWaterUserPhone1.Text = objWaterUserMes.ToString();
                    }

                    object objWaterUser = dtUserList.Rows[0]["areaNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtAreaNO1.Text = objWaterUser.ToString();
                    }
                    else
                        txtAreaNO1.Clear();
                    objWaterUser = dtUserList.Rows[0]["pianNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtPianNO1.Text = objWaterUser.ToString();
                    }
                    else
                        txtPianNO1.Clear();
                    objWaterUser = dtUserList.Rows[0]["duanNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtDuanNO1.Text = objWaterUser.ToString();
                    }
                    else
                        txtDuanNO1.Clear();
                    objWaterUser = dtUserList.Rows[0]["COMMUNITYNAME"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtCommunity1.Text = objWaterUser.ToString();
                    }
                    else
                        txtCommunity1.Clear();

                    objWaterUser = dtUserList.Rows[0]["buildingNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtBuildingNO1.Text = objWaterUser.ToString();
                    }
                    else
                        txtBuildingNO1.Clear();
                    objWaterUser = dtUserList.Rows[0]["unitNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtUnitNO1.Text = objWaterUser.ToString();
                    }
                    else
                        txtUnitNO1.Clear();


                    objWaterUserMes = dtUserList.Rows[0]["waterMeterTypeId"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeID1.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeID1.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["waterMeterTypeValue"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeValue1.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeValue1.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["WATERMETERTYPECLASSID"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeClassID1.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeClassID1.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["WATERMETERTYPECLASSNAME"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeClassName1.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeClassName1.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["WATERUSERTYPEID"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserTypeID1.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserTypeName"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserType1.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserAddress"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserAddress1.Text = objWaterUserMes.ToString();
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
                        txtMeterReaderID1.Text = objWaterUser.ToString();
                    }
                    else
                        txtMeterReaderID1.Clear();
                    objWaterUser = dtUserList.Rows[0]["meterReaderName"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtMeterReader1.Text = objWaterUser.ToString();
                    }
                    else
                        txtMeterReader1.Clear();
                    objWaterUser = dtUserList.Rows[0]["chargerName"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtCharger1.Text = objWaterUser.ToString();
                    }
                    else
                        txtCharger1.Clear();
                    objWaterUser = dtUserList.Rows[0]["CHARGERID"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtChargerID1.Text = objWaterUser.ToString();
                    }
                    else
                        txtChargerID1.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["ordernumber"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtOrderNumber1.Text = objWaterUserMes.ToString();
                    }


                    //查询用户余额
                    objWaterUserMes = dtUserList.Rows[0]["prestore"];
                    if (Information.IsNumeric(objWaterUserMes))
                    {
                        txtYSQQYE.Text = Convert.ToDecimal(objWaterUserMes).ToString("F2");
                    }
                    try
                    {
                        DataTable dtWaterMeterCount = BLLwaterMeter.Query(" AND WATERUSERID='" + txtWaterUserID1.Text + "' AND waterMeterState='1'");
                        txtWaterMeterCount1.Text = dtWaterMeterCount.Rows.Count + " 块";
                    }
                    catch (Exception ex)
                    {
                        log.Write(ex.ToString(), MsgType.Error);
                    }

                    ////如果用户是非预存交费用户，则不允许收费
                    //object objWaterUserChargeType = dtUserList.Rows[0]["chargeType"];
                    //if (objWaterUserChargeType != null && objWaterUserChargeType != DBNull.Value)
                    //{
                    //    if (objWaterUserChargeType.ToString() == "0")
                    //    {
                    //        mes.Show("用户'" + txtWaterUserName1.Text + "'为非预存用户,无法执行收费操作!");
                    //        return;
                    //    }
                    //}

                    //如果用户存在欠费金额，则不允退费
                    object objWaterUserQF = BLLreadMeterRecord.QueryQFByWaterUser(objWaterUserID.ToString());
                    if (Information.IsNumeric(objWaterUserQF))
                    {
                        txtWaterFee.Text = Convert.ToDecimal(objWaterUserQF).ToString("F2");
                        //if (Convert.ToDecimal(objWaterUserQF) > 0)
                        //{
                        //    mes.Show("当前用户存在欠费余额,无法执行退费操作!");
                        //    return;
                        //}
                    }
                    else
                        txtWaterFee.Text = "0";

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
            if (txtWaterUserID1.Text.Trim() == "")
            {
                mes.Show("未找到待转用户ID信息,请重新查询后重试!");
                txtWaterUserNOSearch1.Focus();
                return;
            }
            if (txtWaterUserID2.Text.Trim() == "")
            {
                mes.Show("未找到转入用户ID信息,请重新查询后重试!");
                txtWaterUserNOSearch2.Focus();
                return;
            }

            decimal decMoney = 0, decPrestore = 0;
            if (!Information.IsNumeric(txtMoney.Text))
            {
                mes.Show("请输入正确的转款金额!");
                txtMoney.SelectAll();
                txtMoney.Focus();
                return;
            }
            decMoney = Convert.ToDecimal(txtMoney.Text);
            decPrestore = Convert.ToDecimal(txtYSQQYE.Text);

            if ((decPrestore - decMoney) < 0)
            {
                mes.Show("转款金额不能大于账户余额!");
                txtMoney.SelectAll();
                txtMoney.Focus();
                return;
            }

            //如果用户存在欠费金额，则不允转款费
            object objWaterUserQF = BLLreadMeterRecord.QueryQFByWaterUser(txtWaterUserID1.Text.Trim());
            if (Information.IsNumeric(objWaterUserQF))
            {
                txtWaterFee.Text = Convert.ToDecimal(objWaterUserQF).ToString("F2");
                if (Convert.ToDecimal(objWaterUserQF) > 0)
                {
                    if (mes.ShowQ("当前待转用户存在欠费信息,是否继续转款？") != DialogResult.OK)
                        return;
                }
            }
            else
                txtWaterFee.Text = "0";

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
                MODELWATERFEECHARGE.CHARGEClASS = "7";//收费类型是用户余额退费 
                MODELWATERFEECHARGE.CHARGEBCSS =0;
                MODELWATERFEECHARGE.CHARGEYSQQYE = decPrestore;
                MODELWATERFEECHARGE.CHARGEYSBCSZ = 0 - decMoney;
                MODELWATERFEECHARGE.CHARGEYSJSYE = MODELWATERFEECHARGE.CHARGEYSQQYE + MODELWATERFEECHARGE.CHARGEYSBCSZ;
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
                MODELWATERFEECHARGE.MEMO = "转款给用户:" + txtWaterUserID2.Text + "(" + txtWaterUserName2.Text+")" + txtMemo.Text;
                if (BLLWATERFEECHARGE.Insert(MODELWATERFEECHARGE))
                {
                    try
                    {
                        MODELPRESTORERUNNINGACCOUNT MODELPRESTORERUNNINGACCOUNT = new MODELPRESTORERUNNINGACCOUNT();
                        MODELPRESTORERUNNINGACCOUNT.PRESTORERUNNINGACCOUNTID = GETTABLEID.GetTableID(strLoginID, "PRESTORERUNNINGACCOUNT");
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERID = txtWaterUserID1.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERNO = txtWaterUserNO1.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERNAME = txtWaterUserName1.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERNAMECODE = txtNameCode1.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERPHONE = txtWaterUserPhone1.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERADDRESS = txtWaterUserAddress1.Text;
                        if (Information.IsNumeric(txtWaterUserPeopleCount1.Text))
                            MODELPRESTORERUNNINGACCOUNT.WATERUSERPEOPLECOUNT = Convert.ToInt16(txtWaterUserPeopleCount1.Text);
                        MODELPRESTORERUNNINGACCOUNT.AREANO = txtAreaNO1.Text;
                        MODELPRESTORERUNNINGACCOUNT.PIANNO = txtPianNO1.Text;
                        MODELPRESTORERUNNINGACCOUNT.DUANNO = txtDuanNO1.Text;
                        MODELPRESTORERUNNINGACCOUNT.COMMUNITYID = txtCommunityID1.Text;
                        MODELPRESTORERUNNINGACCOUNT.COMMUNITYNAME = txtCommunity1.Text;
                        if (Information.IsNumeric(txtOrderNumber1.Text))
                            MODELPRESTORERUNNINGACCOUNT.ORDERNUMBER = Convert.ToInt16(txtOrderNumber1.Text);
                        //MODELPRESTORERUNNINGACCOUNT.BUILDINGNO = txtBuildingNO.Text;
                        //MODELPRESTORERUNNINGACCOUNT.UNITNO = txtUnitNO.Text;
                        MODELPRESTORERUNNINGACCOUNT.METERREADERID = txtMeterReaderID1.Text;
                        MODELPRESTORERUNNINGACCOUNT.METERREADERNAME = txtMeterReader1.Text;
                        MODELPRESTORERUNNINGACCOUNT.CHARGERID = txtChargerID1.Text;
                        MODELPRESTORERUNNINGACCOUNT.CHARGERNAME = txtCharger1.Text;
                        MODELPRESTORERUNNINGACCOUNT.waterMeterTypeId = txtWaterMeterTypeID1.Text;
                        MODELPRESTORERUNNINGACCOUNT.waterMeterTypeValue = txtWaterMeterTypeValue1.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERMETERTYPECLASSID = txtWaterMeterTypeClassID1.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERMETERTYPECLASSNAME = txtWaterMeterTypeClassName1.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPEID = txtWaterUserTypeID1.Text;
                        MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPENAME = txtWaterUserType1.Text;
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

                            //更新余额
                            string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CHARGEYSJSYE + " WHERE waterUserId='" + txtWaterUserID1.Text + "'";
                            if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                            {
                                string strError = "转款失败:更新编号为'" + txtWaterUserID1.Text + "'的待转用户余额失败!";
                                
                                //回滚退费记录
                                BLLPRESTORERUNNINGACCOUNT.Delete(MODELPRESTORERUNNINGACCOUNT.PRESTORERUNNINGACCOUNTID);

                                BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                mes.Show(strError);
                                log.Write(strError, MsgType.Error);
                            }
                            try
                            {
                                MODELWATERFEECHARGE MODELWATERFEECHARGE2 = new MODELWATERFEECHARGE();
                                MODELWATERFEECHARGE2.CHARGEID = GETTABLEID.GetTableID(strLoginID, "WATERFEECHARGE");
                                MODELWATERFEECHARGE2.CHARGETYPEID = "1";
                                MODELWATERFEECHARGE2.CHARGEClASS = "7";//收费类型是用户余额退费 
                                MODELWATERFEECHARGE2.CHARGEBCSS = 0;
                                MODELWATERFEECHARGE2.CHARGEYSQQYE = Convert.ToDecimal(txtYSQQYE2.Text);
                                MODELWATERFEECHARGE2.CHARGEYSBCSZ = decMoney;
                                MODELWATERFEECHARGE2.CHARGEYSJSYE = MODELWATERFEECHARGE2.CHARGEYSQQYE + MODELWATERFEECHARGE2.CHARGEYSBCSZ;
                                MODELWATERFEECHARGE2.CHARGEWORKERID = strLoginID;
                                MODELWATERFEECHARGE2.CHARGEWORKERNAME = strLoginName;
                                MODELWATERFEECHARGE2.CHARGEDATETIME = mes.GetDatetimeNow();
                                MODELWATERFEECHARGE2.INVOICEPRINTSIGN = "0";
                                if (chkReceipt.Checked)
                                {
                                    MODELWATERFEECHARGE2.RECEIPTPRINTCOUNT = 1;
                                    MODELWATERFEECHARGE2.RECEIPTNO = txtReceiptNO.Text;
                                }
                                MODELWATERFEECHARGE2.INVOICEPRINTSIGN = "0";
                                MODELWATERFEECHARGE2.MEMO = "转入款从用户:" + txtWaterUserID1.Text + "(" + txtWaterUserName1.Text +")"+ txtMemo.Text;
                                if (BLLWATERFEECHARGE.Insert(MODELWATERFEECHARGE2))
                                {
                                    try
                                    {
                                        MODELPRESTORERUNNINGACCOUNT MODELPRESTORERUNNINGACCOUNT2 = new MODELPRESTORERUNNINGACCOUNT();
                                        MODELPRESTORERUNNINGACCOUNT2.PRESTORERUNNINGACCOUNTID = GETTABLEID.GetTableID(strLoginID, "PRESTORERUNNINGACCOUNT");
                                        MODELPRESTORERUNNINGACCOUNT2.WATERUSERID = txtWaterUserID2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.WATERUSERNO = txtWaterUserNO2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.WATERUSERNAME = txtWaterUserName2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.WATERUSERNAMECODE = txtNameCode2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.WATERUSERPHONE = txtWaterUserPhone2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.WATERUSERADDRESS = txtWaterUserAddress2.Text;
                                        if (Information.IsNumeric(txtWaterUserPeopleCount2.Text))
                                            MODELPRESTORERUNNINGACCOUNT2.WATERUSERPEOPLECOUNT = Convert.ToInt16(txtWaterUserPeopleCount2.Text);
                                        MODELPRESTORERUNNINGACCOUNT2.AREANO = txtAreaNO2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.PIANNO = txtPianNO2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.DUANNO = txtDuanNO2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.COMMUNITYID = txtCommunityID2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.COMMUNITYNAME = txtCommunity2.Text;
                                        if (Information.IsNumeric(txtOrderNumber2.Text))
                                            MODELPRESTORERUNNINGACCOUNT2.ORDERNUMBER = Convert.ToInt16(txtOrderNumber2.Text);
                                        //MODELPRESTORERUNNINGACCOUNT2.BUILDINGNO = txtBuildingNO.Text;
                                        //MODELPRESTORERUNNINGACCOUNT2.UNITNO = txtUnitNO.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.METERREADERID = txtMeterReaderID2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.METERREADERNAME = txtMeterReader2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.CHARGERID = txtChargerID2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.CHARGERNAME = txtCharger2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.waterMeterTypeId = txtWaterMeterTypeID2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.waterMeterTypeValue = txtWaterMeterTypeValue2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.WATERMETERTYPECLASSID = txtWaterMeterTypeClassID2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.WATERMETERTYPECLASSNAME = txtWaterMeterTypeClassName2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.WATERUSERTYPEID = txtWaterUserTypeID2.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.WATERUSERTYPENAME = txtWaterUserType2.Text;
                                        //MODELPRESTORERUNNINGACCOUNT2.WATERUSERHOUSETYPE = txtWaterUserHouseType.Text;
                                        //MODELPRESTORERUNNINGACCOUNT2.CREATETYPE = txtCreateType.Text;
                                        //MODELPRESTORERUNNINGACCOUNT2.MEMO = txtMemo.Text;
                                        MODELPRESTORERUNNINGACCOUNT2.CHARGEID = MODELWATERFEECHARGE2.CHARGEID;
                                        if (BLLPRESTORERUNNINGACCOUNT.Insert(MODELPRESTORERUNNINGACCOUNT2))
                                        {
                                            //txtYSQQYE.Text = txtJSYE.Text;
                                            //txtWaterFeeReal.Text =( Convert.ToDecimal(txtWaterFee.Text) - Convert.ToDecimal(txtYSQQYE.Text)).ToString();
                                            //txtBCYC.Text = "0";
                                            btCharge.Enabled = false;

                                            //更新余额
                                            string strUpdatePrestore2 = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE2.CHARGEYSJSYE + " WHERE waterUserId='" + txtWaterUserID2.Text + "'";
                                            if (!BLLwaterUser.UpdateSQL(strUpdatePrestore2))
                                            {
                                                string strError = "转款失败:更新编号为'" + txtWaterUserID2.Text + "'的转入用户余额失败!";

                                                //回滚退费记录
                                                BLLPRESTORERUNNINGACCOUNT.Delete(MODELPRESTORERUNNINGACCOUNT2.PRESTORERUNNINGACCOUNTID);

                                                BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                                mes.Show(strError);
                                                log.Write(strError, MsgType.Error);
                                            }
                                            //如果勾选了打收据，打印收据
                                            if (chkReceipt.Checked)
                                            {
                                                //--打印收据
                                                #region
                                                FastReport.Report report1 = new FastReport.Report();
                                                try
                                                {
                                                    // load the existing report
                                                    report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\转款收据模板.frx");

                                                    (report1.FindObject("txtJFDatetime") as FastReport.TextObject).Text = MODELWATERFEECHARGE.CHARGEDATETIME.ToString("yyyy-MM-dd HH:mm:ss");
                                                    (report1.FindObject("txtWaterUserNO") as FastReport.TextObject).Text = txtWaterUserNO1.Text;
                                                    (report1.FindObject("txtWaterUserName") as FastReport.TextObject).Text = txtWaterUserName1.Text;
                                                    (report1.FindObject("txtWaterUserAddress") as FastReport.TextObject).Text = txtWaterUserAddress1.Text;
                                                    (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额:            " + MODELWATERFEECHARGE.CHARGEYSQQYE.ToString("F2");

                                                    (report1.FindObject("txtBCTF") as FastReport.TextObject).Text = "本次转款: " + MODELWATERFEECHARGE.CHARGEYSBCSZ;
                                                    (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额:            " + MODELWATERFEECHARGE.CHARGEYSJSYE.ToString("F2");

                                                    (report1.FindObject("txtZhuanruWaterUserID") as FastReport.TextObject).Text = "转入用户:" + MODELPRESTORERUNNINGACCOUNT2.WATERUSERID + "—" + MODELPRESTORERUNNINGACCOUNT2.WATERUSERNAME;
                                                    (report1.FindObject("txtZhuanRuWaterUserAddress") as FastReport.TextObject).Text = "地    址:" + MODELPRESTORERUNNINGACCOUNT2.WATERUSERADDRESS;
                                                    (report1.FindObject("txtZhuanRuQQYE") as FastReport.TextObject).Text = "前期余额:            " + MODELWATERFEECHARGE2.CHARGEYSQQYE.ToString("F2");
                                                    (report1.FindObject("txtZhuanRuJSYE") as FastReport.TextObject).Text = "结算余额: " + MODELWATERFEECHARGE2.CHARGEYSJSYE.ToString("F2");
                                                    (report1.FindObject("txtWorkerName") as FastReport.TextObject).Text = strLoginName;


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
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            catch (Exception ex)
                            {

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

        private void btSearch2_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (txtWaterUserNOSearch2.Text.Trim() != "")
            {
                if (txtWaterUserNOSearch2.Text.Length < 6)
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch2.Text.PadLeft(5, '0') + "'";
                else
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch2.Text + "'";
            }

            if (txtWaterUserNameSearch2.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch2.Text.Trim() + "%'";

            if (txtAddress2.Text.Trim() != "")
                strFilter += " AND waterUserAddress LIKE '%" + txtAddress2.Text + "%'";

            LoadDebtsDate2(strFilter);
        }

        /// <summary>
        /// 选择的用户编号
        /// </summary>
        public string strSelectWaterUser2 = "";

        /// <summary>
        /// 获取欠费用户列表
        /// </summary>
        /// <param name="strFilter"></param>
        private void LoadDebtsDate2(string strFilter)
        {

            foreach (Control con in gpbWaterUserMES2.Controls)
            {
                if (con is TextBox)
                    con.Text = "";
            }
            txtYSQQYE2.Text = "0";
            txtWaterFee2.Text = "0";
            txtWaterFeeReal2.Text = "0";

            DataTable dtUserList = BLLwaterUser.QueryInitialWaterUser(strFilter);
            if (dtUserList.Rows.Count > 0)
            {
                if (dtUserList.Rows.Count > 1)
                {
                    frmSingleChargeSelectWaterUser frm = new frmSingleChargeSelectWaterUser();
                    frm.dtWaterUserList = dtUserList;
                    frm.Owner = this;
                    frm.strFormType = "6";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {

                    }
                    else
                    {
                        //btCharge.Enabled = false;
                        txtWaterUserNOSearch1.Focus();
                        return;
                    }
                }
                else
                {
                    object objWaterUserIDSingle = dtUserList.Rows[0]["WATERUSERID"];
                    if (objWaterUserIDSingle != null && objWaterUserIDSingle != DBNull.Value)
                    {
                        strSelectWaterUser2 = objWaterUserIDSingle.ToString();
                    }
                }
                if (strSelectWaterUser2 == "")
                {
                    mes.Show("获取用户号失败,请重新查询!");
                    return;
                }
                if (strSelectWaterUser == strSelectWaterUser2)
                {
                    mes.Show("待转户与转入户不能相同!");
                    return;
                }
                DataView dvUserList = dtUserList.DefaultView;
                dvUserList.RowFilter = "WATERUSERID='" + strSelectWaterUser2 + "'";
                dtUserList = dvUserList.ToTable();
                object objWaterUserID = dtUserList.Rows[0]["waterUserId"];
                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                {
                    txtWaterUserID2.Text = objWaterUserID.ToString();

                    #region 生成用户信息
                    object objWaterUserMes = dtUserList.Rows[0]["waterUserNO"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserNO2.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserName"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserName2.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserNameCode"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtNameCode2.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserTelphoneNO"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserPhone2.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterPhone"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        if (txtWaterUserPhone2.Text != "")
                            txtWaterUserPhone2.Text += ";" + objWaterUserMes.ToString();
                        else
                            txtWaterUserPhone2.Text = objWaterUserMes.ToString();
                    }

                    object objWaterUser = dtUserList.Rows[0]["areaNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtAreaNO2.Text = objWaterUser.ToString();
                    }
                    else
                        txtAreaNO2.Clear();
                    objWaterUser = dtUserList.Rows[0]["pianNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtPianNO2.Text = objWaterUser.ToString();
                    }
                    else
                        txtPianNO2.Clear();
                    objWaterUser = dtUserList.Rows[0]["duanNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtDuanNO2.Text = objWaterUser.ToString();
                    }
                    else
                        txtDuanNO2.Clear();
                    objWaterUser = dtUserList.Rows[0]["COMMUNITYNAME"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtCommunity2.Text = objWaterUser.ToString();
                    }
                    else
                        txtCommunity2.Clear();

                    objWaterUser = dtUserList.Rows[0]["buildingNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtBuildingNO2.Text = objWaterUser.ToString();
                    }
                    else
                        txtBuildingNO2.Clear();
                    objWaterUser = dtUserList.Rows[0]["unitNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtUnitNO2.Text = objWaterUser.ToString();
                    }
                    else
                        txtUnitNO2.Clear();


                    objWaterUserMes = dtUserList.Rows[0]["waterMeterTypeId"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeID2.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeID2.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["waterMeterTypeValue"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeValue2.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeValue2.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["WATERMETERTYPECLASSID"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeClassID2.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeClassID2.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["WATERMETERTYPECLASSNAME"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterMeterTypeClassName2.Text = objWaterUserMes.ToString();
                    }
                    else
                        txtWaterMeterTypeClassName2.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["WATERUSERTYPEID"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserTypeID2.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserTypeName"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserType2.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserAddress"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserAddress2.Text = objWaterUserMes.ToString();
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
                        txtMeterReaderID2.Text = objWaterUser.ToString();
                    }
                    else
                        txtMeterReaderID2.Clear();
                    objWaterUser = dtUserList.Rows[0]["meterReaderName"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtMeterReader2.Text = objWaterUser.ToString();
                    }
                    else
                        txtMeterReader2.Clear();
                    objWaterUser = dtUserList.Rows[0]["chargerName"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtCharger2.Text = objWaterUser.ToString();
                    }
                    else
                        txtCharger2.Clear();
                    objWaterUser = dtUserList.Rows[0]["CHARGERID"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtChargerID2.Text = objWaterUser.ToString();
                    }
                    else
                        txtChargerID2.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["ordernumber"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtOrderNumber2.Text = objWaterUserMes.ToString();
                    }


                    //查询用户余额
                    objWaterUserMes = dtUserList.Rows[0]["prestore"];
                    if (Information.IsNumeric(objWaterUserMes))
                    {
                        txtYSQQYE2.Text = Convert.ToDecimal(objWaterUserMes).ToString("F2");
                    }
                    try
                    {
                        DataTable dtWaterMeterCount = BLLwaterMeter.Query(" AND WATERUSERID='" + txtWaterUserID2.Text + "' AND waterMeterState='1'");
                        txtWaterMeterCount2.Text = dtWaterMeterCount.Rows.Count + " 块";
                    }
                    catch (Exception ex)
                    {
                        log.Write(ex.ToString(), MsgType.Error);
                    }

                    //如果用户存在欠费金额，则不允退费
                    object objWaterUserQF = BLLreadMeterRecord.QueryQFByWaterUser(objWaterUserID.ToString());
                    if (Information.IsNumeric(objWaterUserQF))
                    {
                        txtWaterFee2.Text = Convert.ToDecimal(objWaterUserQF).ToString("F2");
                    }
                    else
                        txtWaterFee2.Text = "0";
                    #endregion
                }

            }
            else
            {
                mes.Show("未找到用户信息!");
                return;
            }
        }

        private void txtWaterUserNOSearch2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch2_Click(null, null);
            }
        }
        private void txtBCSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //检测是否已经输入了小数点 
            bool IsContainsDot = this.txtMoney.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {
                btCharge.Focus();
            }
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            if (txtMoney.Text.Trim() == "")
            {
                txtMoney.Text = "0";
                txtMoney.SelectAll();
                txtMoney.Focus();
            }
        }

        private void txtMoney_Click(object sender, EventArgs e)
        {
            txtMoney.SelectAll();
            txtMoney.Focus();
        }

    }
}
