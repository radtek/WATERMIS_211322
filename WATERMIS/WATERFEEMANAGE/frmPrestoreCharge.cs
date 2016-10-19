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
    public partial class frmPrestoreCharge : DockContentEx
    {
        public frmPrestoreCharge()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();
        BLLRECEIPTFETCH BLLRECEIPTFETCH = new BLLRECEIPTFETCH();

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
        /// 所属组
        /// </summary>
        private string strGroupID = "";

        /// <summary>
        /// 传入的用户ID参数，如果是从收费界面传过来的直接查询到该用户，如果是单独打开的预存界面则不查询。
        /// </summary>
        public string strWaterUserID = "";

        /// <summary>
        /// 抄表员电话
        /// </summary>
        public string strMeterReaderTel = "";

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

            object objGroup = AppDomain.CurrentDomain.GetData("GROUPID");
            if (objGroup != null && objGroup != DBNull.Value)
            {
                strGroupID = objGroup.ToString();
            }

            this.Text = "水费预存——当前收费员:" + strLoginName;

            BindChargeType();
            chkReceipt.Checked = true;

            if (strWaterUserID != "")
            {
                txtWaterUserNOSearch.Text = strWaterUserID;
                btSearch_Click(null,null);
            }
            this.txtMeterReaderTel.Text = strMeterReaderTel;
        }
        /// <summary>
        /// 绑定收款方式
        /// </summary>
        private void BindChargeType()
        {
            DataTable dt = BLLCHARGETYPE.QUERY("");
            DataRow dr = dt.NewRow();
            cmbChargeType.DataSource = dt;
            cmbChargeType.DisplayMember = "CHARGETYPENAME";
            cmbChargeType.ValueMember = "CHARGETYPEID";
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
                if (txtWaterUserNOSearch.Text.Length > 5)
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim() + "'";
                else
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.Trim().PadLeft(5, '0') + "'";

            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

            if (txtNameCodeS.Text.Trim() != "")
                strFilter += " AND waterUserNameCode like '%" + txtNameCodeS.Text.Trim() + "%'";

            if (txtAddress.Text.Trim() != "")
                strFilter += " AND waterUserAddress LIKE '%" + txtAddress.Text + "%'";
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
            txtBCYC.Text = "0";
            txtJSYE.Text = "0";
            txtMemo.Clear();

            txtJYLSH.Clear();            
            cmbChargeType.SelectedIndex = 0;

            btCharge.Enabled = false;

            dgHistoryWaterFee.DataSource = null;
            btSearchLS.Enabled = false;

            txtInvoiceNO.Clear();//清空发票号

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
                if (dtUserList.Rows.Count > 500)
                {
                    mes.Show("符合条件的用户大约500户,请设置更多查询条件!");
                    return;
                }
                if (dtUserList.Rows.Count > 1)
                {
                    frmSingleChargeSelectWaterUser frm = new frmSingleChargeSelectWaterUser();
                    frm.dtWaterUserList = dtUserList;
                    frm.Owner = this;
                    frm.strFormType = "2";

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
                        if (txtWaterUserPhone.Text != "")
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

                    //objWaterUser = dtUserList.Rows[0]["buildingNO"];
                    //if (objWaterUser != null && objWaterUser != DBNull.Value)
                    //{
                    //    txtBuildingNO.Text = objWaterUser.ToString();
                    //}
                    //else
                    //    txtBuildingNO.Clear();
                    //objWaterUser = dtUserList.Rows[0]["unitNO"];
                    //if (objWaterUser != null && objWaterUser != DBNull.Value)
                    //{
                    //    txtUnitNO.Text = objWaterUser.ToString();
                    //}
                    //else
                    //    txtUnitNO.Clear();

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

                    //objWaterUserMes = dtUserList.Rows[0]["waterUserHouseTypeS"];
                    //if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    //{
                    //    txtWaterUserHouseType.Text = objWaterUserMes.ToString();
                    //}

                    //objWaterUserMes = dtUserList.Rows[0]["chargeTypeS"];
                    //if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    //{
                    //    txtWaterUserChargetype.Text = objWaterUserMes.ToString();
                    //}

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

                    objWaterUser = dtUserList.Rows[0]["waterMeterStateS"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtWaterUserState.Text = objWaterUser.ToString();
                    }
                    else
                        txtWaterUserState.Clear();
                    //try
                    //{
                    //    DataTable dtWaterMeterCount = BLLwaterMeter.Query(" AND WATERUSERID='" + txtWaterUserID.Text + "' AND waterMeterState='1'");
                    //    txtWaterMeterCount.Text = dtWaterMeterCount.Rows.Count + " 块";
                    //}
                    //catch (Exception ex)
                    //{
                    //    log.Write(ex.ToString(),MsgType.Error);
                    //}

                    //int intWaterMeterCount = 0, intWaterMeterValidCount = 0, intWaterMeterUnvalidCount = 0;
                    //DataTable dtWaterMeter = BLLwaterMeter.Query(" AND WATERUSERID='" + strSelectWaterUser + "'");
                    //if (dtWaterMeter.Rows.Count > 0)
                    //{
                    //    intWaterMeterCount = dtWaterMeter.Rows.Count;
                    //    DataRow[] drValid = dtWaterMeter.Select("waterMeterState='1'");
                    //    intWaterMeterValidCount = drValid.Length;
                    //    if (intWaterMeterCount - intWaterMeterValidCount > 0)
                    //    {
                    //        mes.Show("该用户共 " + intWaterMeterCount + " 块水表,其中报停 " + (intWaterMeterCount - intWaterMeterValidCount) + " 块");
                    //    }
                    //}
                    //else
                    //{
                    //    mes.Show("未检测到该用户的水表信息!");
                    //}
                        
                    //如果用户是非预存交费用户，则不允许收费
                    //object objWaterUserChargeType = dtUserList.Rows[0]["chargeType"];
                    //if (objWaterUserChargeType != null && objWaterUserChargeType != DBNull.Value)
                    //{
                    //    if (objWaterUserChargeType.ToString() == "0")
                    //    {
                    //        mes.Show("用户'" + txtWaterUserName.Text + "'为非预存用户,无法执行收费操作!");
                    //        return;
                    //    }
                    //}

                    ////查询用户欠费总金额
                    //DataTable dtWaterUserDebts = BLLreadMeterRecord.QueryDebts(" AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim().PadLeft(8, '0') + "'");//根据用户汇总欠费金额
                    //if (dtWaterUserDebts.Rows.Count > 0)
                    //{
                    //    object objDebts = dtWaterUserDebts.Rows[0]["DEBTSSUM"];
                    //    if (Information.IsNumeric(objDebts))
                    //    {
                    //        txtWaterFee.Text = Convert.ToDecimal(objWaterUserMes).ToString("F2");
                    //    }
                    //}
                    //txtWaterFeeReal.Text = (Convert.ToDecimal(txtWaterFee.Text) - Convert.ToDecimal(txtYSQQYE.Text)).ToString();
                    txtBCYC.Focus();
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
                mes.Show("未找到用户信息!");
                txtWaterUserNOSearch.Focus();
                return;
            }
            if (!Information.IsNumeric(txtBCYC.Text))
                return;
            else
                if (Convert.ToDecimal(txtBCYC.Text) <= 0)
                {
                    mes.Show("预存金额不能为'0'");
                    txtBCYC.Focus();
                    return;
                }
            if (chkInvoiceSingle.Checked)
            {
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
                    txtInvoiceNO.Text = txtInvoiceNO.Text.PadLeft(8, '0');

                    #region 发票验证
                    /*
                        DataTable dtCheckInvoiceExists = BLLWATERFEECHARGE.QueryChargeView(" AND INVOICENO='" + txtInvoiceNO.Text + "' AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                        if (dtCheckInvoiceExists.Rows.Count > 0)
                        {
                            mes.Show("发票批次为'" + cmbBatch.Text + "'票号为'" + txtInvoiceNO.Text + "'的发票已使用，请重新输入发票号码!");
                            txtInvoiceNO.Focus();
                            return;
                        }
                        else
                        {
                            DataTable dtInvoiceFetch = BLLINVOICEFETCH.Query(" AND  INVOICEFETCHBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                            #region 验证发票领取记录是否存在
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
                         * */
                    #endregion
                }
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

                if (strGroupID != "0001")
                {

                    #region 验证是否在领取记录中
                    DataTable dtReceiptNO = new DataTable();
                    bool isExists = false;
                    dtReceiptNO = BLLRECEIPTFETCH.Query(" AND RECEIPTFETCHERID='" + strLoginID + "'");
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
                        mes.Show("收据号'" + txtReceiptNO.Text + "'不在领取记录中,无法打印!");
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
            }
            if (cmbChargeType.SelectedValue == null || cmbChargeType.SelectedValue == DBNull.Value)
            {
                mes.Show("收款方式不能为空!");
                cmbChargeType.Focus();
                return;
            }
            else
            {
                if (cmbChargeType.SelectedValue.ToString() == "2")
                {
                    if (txtJYLSH.Text.Trim() == "")
                    {
                        mes.Show("请输入POS机收费的交易流水号!");
                        txtJYLSH.Focus();
                        return;
                    }
                }
            }

            try
            {
                MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLoginID, "WATERFEECHARGE");
                MODELWATERFEECHARGE.CHARGETYPEID = cmbChargeType.SelectedValue.ToString();
                if (cmbChargeType.SelectedValue.ToString() == "2")
                {
                    MODELWATERFEECHARGE.POSRUNNINGNO = txtJYLSH.Text;
                }
                MODELWATERFEECHARGE.CHARGEClASS = "2";//收费类型是水费预收
                MODELWATERFEECHARGE.CHARGEBCSS = Convert.ToDecimal(txtBCYC.Text);
                MODELWATERFEECHARGE.CHARGEYSQQYE = Convert.ToDecimal(txtYSQQYE.Text);
                MODELWATERFEECHARGE.CHARGEYSBCSZ = Convert.ToDecimal(txtBCYC.Text);
                MODELWATERFEECHARGE.CHARGEYSJSYE = Convert.ToDecimal(txtJSYE.Text);
                MODELWATERFEECHARGE.CHARGEWORKERID = strLoginID;
                MODELWATERFEECHARGE.CHARGEWORKERNAME = strLoginName;
                MODELWATERFEECHARGE.CHARGEDATETIME = mes.GetDatetimeNow();
                MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                if (chkReceipt.Checked)
                {
                    MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 1;
                    MODELWATERFEECHARGE.RECEIPTNO = txtReceiptNO.Text;
                }
                if (chkInvoiceSingle.Checked)
                {
                    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";

                }
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
                        if(Information.IsNumeric(txtWaterUserPeopleCount.Text))
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
                        MODELPRESTORERUNNINGACCOUNT.MEMO = txtMemo.Text;
                        MODELPRESTORERUNNINGACCOUNT.CHARGEID = MODELWATERFEECHARGE.CHARGEID;
                        if (BLLPRESTORERUNNINGACCOUNT.Insert(MODELPRESTORERUNNINGACCOUNT))
                        {
                            //txtYSQQYE.Text = txtJSYE.Text;
                            //txtWaterFeeReal.Text =( Convert.ToDecimal(txtWaterFee.Text) - Convert.ToDecimal(txtYSQQYE.Text)).ToString();
                            //txtBCYC.Text = "0";
                            try
                            {
                                //更新余额
                                string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CHARGEYSJSYE + " WHERE waterUserId='" + txtWaterUserID.Text + "'";
                                if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                {
                                    string strError = "更新用户编号为'" + txtWaterUserID.Text + "'的余额失败,请重新收费!";
                                    mes.Show(strError);
                                    log.Write(strError, MsgType.Error);
                                    //回滚预存流水表
                                    BLLPRESTORERUNNINGACCOUNT.Delete(MODELPRESTORERUNNINGACCOUNT.PRESTORERUNNINGACCOUNTID);
                                    //回滚收费记录表
                                    BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                }
                            }
                            catch (Exception ex)
                            {
                                mes.Show("更新用户余额失败,请重新收费。原因:"+Environment.NewLine+ex.Message);
                                log.Write("更新用户余额失败,原因:"+ex.ToString(), MsgType.Error);
                                //回滚预存流水表
                                BLLPRESTORERUNNINGACCOUNT.Delete(MODELPRESTORERUNNINGACCOUNT.PRESTORERUNNINGACCOUNTID);
                                //回滚收费记录表
                                BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                return;
                            }

                            btCharge.Enabled = false;
                            btSearchLS_Click(null, null);
                            if (chkInvoiceSingle.Checked)
                            {

                                try
                                {
                                    MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT = new MODELCHARGEINVOICEPRINT();
                                    //插入发票表
                                    MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID("", "CHARGEINVOICEPRINT");
                                    MODELCHARGEINVOICEPRINT.CHARGEID = MODELWATERFEECHARGE.CHARGEID;
                                    MODELCHARGEINVOICEPRINT.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                                    MODELCHARGEINVOICEPRINT.INVOICEBATCHNAME = cmbBatch.Text;
                                    MODELCHARGEINVOICEPRINT.INVOICENO = txtInvoiceNO.Text;
                                    MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";
                                    MODELCHARGEINVOICEPRINT.INVOICEPRINTDATETIME = mes.GetDatetimeNow();
                                    if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINT))
                                    {

                                    }
                                    else
                                    {
                                        mes.Show("插入发票记录失败!请补打发票!");
                                        log.Write("插入发票记录失败!", MsgType.Error);
                                        return;
                                    }
                                }
                                catch (Exception exxx)
                                {
                                    mes.Show("插入发票表失败!原因:" + exxx.Message);
                                    log.Write(exxx.ToString(), MsgType.Error);
                                    return;
                                }
                            }
                            //如果勾选了打收据，打印收据
                            else if (chkReceipt.Checked)
                            {
                                //--打印收据
                                #region
                                FastReport.Report report1 = new FastReport.Report();
                                try
                                {
                                    //DataTable dtLastRecord = BLLwaterUser.QuerySQL("SELECT TOP 1 * FROM  readMeterRecord WHERE WATERUSERID='" +
                                    //    strWaterUserID + "' AND checkState='1' AND chargeState<>'0' ORDER BY readMeterRecordDate DESC");
                                    DataTable dtLastRecord = BLLwaterUser.QuerySQL("SELECT TOP 1 readMeterRecordId,readMeterRecordYearAndMonth,waterMeterLastNumber," +
                                        "(CASE chargeState WHEN 0  THEN waterMeterLastNumber " +
                                        "ELSE waterMeterEndNumber END) AS waterMeterEndNumber " +
                                        "FROM readMeterRecord " +
                                        "WHERE WATERUSERID='" +
                                        strWaterUserID + "' ORDER BY readMeterRecordYearAndMonth DESC,readMeterRecordDate DESC");
                                    DataTable dtTemp=dtLastRecord.Clone();
                                    dtTemp.Columns["readMeterRecordYearAndMonth"].DataType = typeof(string);
                                    if (dtLastRecord.Rows.Count > 0)
                                    {
                                        dtTemp.ImportRow(dtLastRecord.Rows[0]);
                                        object objReadMeterRecordYearAndMonth = dtTemp.Rows[0]["readMeterRecordYearAndMonth"];
                                        if (Information.IsDate(objReadMeterRecordYearAndMonth))
                                            dtTemp.Rows[0]["readMeterRecordYearAndMonth"] = Convert.ToDateTime(objReadMeterRecordYearAndMonth).ToString("yyyy-MM");
                                    }
                                    //DataTable dtTemp = dtLastRecord.Copy();
                                    DataSet ds = new DataSet();
                                    dtTemp.TableName = "营业坐收收据模板";
                                    ds.Tables.Add(dtTemp);
                                    // load the existing report
                                    report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\预存收费收据模板.frx");

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
                                    string strBCSS = MODELWATERFEECHARGE.CHARGEBCSS.ToString("F2");
                                    (report1.FindObject("txtBCJF") as FastReport.TextObject).Text = "本次预存:         " + strBCSS;
                                    (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额: " + MODELWATERFEECHARGE.CHARGEYSJSYE.ToString("F2");

                                    //if (cmbChargeType.SelectedValue.ToString() == "2")
                                    //{
                                    //    (report1.FindObject("txtPOSRUNNINGNO") as FastReport.TextObject).Text = "交易流水号: " + MODELWATERFEECHARGE.POSRUNNINGNO;
                                    //}
                                    (report1.FindObject("txtChargeWorkerName") as FastReport.TextObject).Text = strLoginName;
                                    (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + txtReceiptNO.Text;

                                    (report1.FindObject("txtMeterReader") as FastReport.TextObject).Text = txtMeterReader.Text;
                                    (report1.FindObject("txtMeterReaderTel") as FastReport.TextObject).Text = txtMeterReaderTel.Text;

                                    string strCapMoney = RMBToCapMoney.CmycurD(strBCSS);
                                    if (cmbChargeType.SelectedValue.ToString() == "2")
                                    {
                                        (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney + Environment.NewLine + "交易流水号:" + txtJYLSH.Text;
                                    }
                                    else
                                        (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;
                                    //string strDecimal = strBCSS.Split('.')[1];//小数部分
                                    //string strInteger = strBCSS.Split('.')[0];//小数部分
                                    ////bool isZero = false;
                                    //if (Convert.ToUInt16(strDecimal.Substring(1, 1)) > 0)
                                    //{
                                    //    //isZero = true;
                                    //    string strDecimal2 = ConvertChinese(strDecimal.Substring(1, 1));
                                    //    (report1.FindObject("txt0") as FastReport.TextObject).Text = strDecimal2;
                                    //}
                                    //else
                                    //    (report1.FindObject("txt0") as FastReport.TextObject).Text = "零";

                                    //if (Convert.ToUInt16(strDecimal.Substring(0, 1)) > 0)
                                    //{
                                    //    //isZero = true;
                                    //    string strDecimal1 = ConvertChinese(strDecimal.Substring(0, 1));
                                    //    (report1.FindObject("txt1") as FastReport.TextObject).Text = strDecimal1;
                                    //}
                                    //else
                                    //{
                                    //    //if (isZero)
                                    //    //{
                                    //        (report1.FindObject("txt1") as FastReport.TextObject).Text = "零";
                                    //    //}
                                    //}
                                    //for (int i = 1; i <= strInteger.Length; i++)
                                    //{
                                    //    string strInt = strInteger.Substring(strInteger.Length - i, 1);
                                    //    if (Convert.ToUInt16(strInt) > 0)
                                    //    {
                                    //        //isZero = true;
                                    //        (report1.FindObject("txt" + (i + 1).ToString()) as FastReport.TextObject).Text = ConvertChinese(strInt);
                                    //    }
                                    //    else
                                    //    {
                                    //        //if (isZero)
                                    //        //{
                                    //            (report1.FindObject("txt" + (i + 1).ToString()) as FastReport.TextObject).Text = "零";
                                    //        //}
                                    //    }
                                    //}

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
                        }
                        else
                        {
                            mes.Show("插入预收流水表失败,请重新收费!");
                            BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                            return;
                        }
                    }
                    catch (Exception exx)
                    {
                        mes.Show("插入预收流水表失败,请重新收费!原因:" + Environment.NewLine +exx.Message);
                        log.Write("插入预收流水表失败!原因:" + exx.ToString(), MsgType.Error);
                        BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show("预收失败,请重新收费!原因:" + Environment.NewLine +ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
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
            strFilter += " ORDER BY CHARGEDATETIME DESC";
            DataTable dt = BLLPRESTORERUNNINGACCOUNT.Query(strFilter);
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
        private void txtBCYC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //检测是否已经输入了小数点 
            bool IsContainsDot = this.txtBCYC.Text.Contains(".");
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
                labInvoiceBatch.Visible = false;
                cmbBatch.Visible = false;
                labInvoiceNO.Visible = false;
                txtInvoiceNO.Visible = false;
                chkInvoiceSingle.Checked = false;

                labReceiptNO.Visible = true;
                txtReceiptNO.Visible = true;
            }
        }
        private void chkInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInvoiceSingle.Checked)
            {
                labInvoiceBatch.Visible = true;
                cmbBatch.Visible = true;
                labInvoiceNO.Visible = true;
                txtInvoiceNO.Visible = true;
                chkReceipt.Checked = false;

                labReceiptNO.Visible = false;
                txtReceiptNO.Visible = false;
            }
            else
            {
                labInvoiceBatch.Visible = false;
                cmbBatch.Visible = false;
                labInvoiceNO.Visible = false;
                txtInvoiceNO.Visible = false;
            }
        }

        private void txtBCYC_Click(object sender, EventArgs e)
        {
            txtBCYC.SelectAll();
        }

        private void txtBCYC_TextChanged(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtBCYC.Text))
                txtBCYC.Text = "0";
            if (Convert.ToDecimal(txtBCYC.Text) > 0)
            {
                decimal decQQYE = 0;
                if (Information.IsNumeric(txtYSQQYE.Text))
                    decQQYE = Convert.ToDecimal(txtYSQQYE.Text);
                txtJSYE.Text = (Convert.ToDecimal(txtBCYC.Text) + decQQYE).ToString();
            }
        }

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(null, null);
            }
        }

        private void frmPrestoreCharge_Activated(object sender, EventArgs e)
        {
            if(strWaterUserID!="")
            txtBCYC.Focus();
        }

        private void txtWaterUserPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtWaterUserID.Text != "")
                {
                    string strUpdateSQL = "UPDATE WATERUSER SET waterUserTelphoneNO='" + txtWaterUserPhone.Text + "',waterPhone=null WHERE WATERUSERID='" + txtWaterUserID.Text + "'";
                    if (BLLwaterUser.ExcuteSQL(strUpdateSQL)==0)
                    {
                        mes.Show("更新用户电话信息失败，请重试!");
                    }
                    txtBCYC.Focus();
                    txtBCYC.SelectAll();
                }
            }
        }

        private void txtJSYE_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
