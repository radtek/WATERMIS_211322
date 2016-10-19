using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BASEFUNCTION;
using MODEL;
using BLL;
using System.Threading;

namespace WATERUSERMETERMANAGE
{
    public partial class frmBatchAddWaterUserAndMeter : Form
    {
        public frmBatchAddWaterUserAndMeter()
        {
            InitializeComponent();
            
            tbWaterMeter.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tbWaterMeter, true, null);
        }

        //BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();
        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();

        BLLwaterMeterPosition BLLwaterMeterPosition = new BLLwaterMeterPosition();
        BLLwaterMeterSize BLLwaterMeterSize = new BLLwaterMeterSize();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLOPERATORLOG BLLOPERATORLOG = new BLLOPERATORLOG();

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
        private string strLogName = "";

        public string strAreaNO = "", strPianNO = "", strDuanNO = "", strCommunityID = "", strMeterReaderID = "", strChargerID = "", strOrderNumber = "";

        public string strType = "0";

        private void frmBatchAddWaterUserAndMeter_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("操作员ID获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strLogName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            BindWaterMeterType(cmbWaterType);
            BindWaterMeterSize();
            BindWaterMeterPosition();
            //BindWaterMeterSummary();//815138547
            BindBank(cmbAgentBank);
            BindWaterUserType(cmbUserType);

            BindAreaNO(cmbAreaNO, "1");
            BindPianNO(cmbPianNO, "1");
            BindDuanNO(cmbDuanNO, "1");
            BindCommunity(cmbCommunity, "1");
            BindMeterReader(cmbMeterReader, "1");
            BindCharger(cmbCharger, "1");

            GetMaxWaterUserNO();

            cmbAgentSign.SelectedIndex = 0;
            cmbWaterUserChargeType.SelectedIndex = 1;
            cmbUserHouseType.SelectedIndex = 0;
            cmbWaterMeterState.SelectedIndex = 0;
            cmbIsSummary.SelectedIndex = 0;
            cmbCreateType.SelectedIndex = 0;

            if (strType == "1")
            {
                cmbPianNO.Text = strPianNO;
                cmbAreaNO.Text = strAreaNO;
                cmbDuanNO.Text = strDuanNO;
                cmbCommunity.SelectedValue = strCommunityID;
                cmbMeterReader.SelectedValue = strMeterReaderID;
                cmbCharger.SelectedValue = strChargerID;
                if(Information.IsNumeric(strOrderNumber))
                txtOrderNumber.Text=(Convert.ToInt32(strOrderNumber)+1).ToString();
            }
        }
        private void GetMaxWaterUserNO()
        {
            DataTable dt=BLLwaterUser.QuerySQL("SELECT MAX(WATERUSERID) AS WATERUSERID FROM WATERUSER");
            object objWaterUserNO = dt.Rows[0]["WATERUSERID"];                
            if (objWaterUserNO != null && objWaterUserNO != DBNull.Value)
            {
                string strMaxWaterUserNO=objWaterUserNO.ToString();
                if (strMaxWaterUserNO.Length == 6)
                    if (Information.IsNumeric(strMaxWaterUserNO.Substring(1, 5)))
                        txtWaterUserNOStart.Text = "U"+(Convert.ToInt32(objWaterUserNO.ToString().Substring(1, 5)) + 1).ToString();
            }
        }
        private void BindAreaNO(ComboBox cmb,string strType)
        {
            DataTable dt=new DataTable();
            if(strType=="0")
            dt = BLLAREA.Query("");
            else
                dt = BLLAREA.Query(" AND areaId<>'0000'");

            cmb.DataSource = dt;
            cmb.DisplayMember = "areaName";
            cmb.ValueMember = "areaId";
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
        }
        private void BindCommunity(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
                dt = BLLBASE_COMMUNITY.Query("");
            else
                dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000'");
            cmb.DataSource = dt;
            cmb.DisplayMember = "COMMUNITYNAME";
            cmb.ValueMember = "COMMUNITYID";
        }
        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType(ComboBox cmb)
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterMeterTypeValue";
            cmb.ValueMember = "waterMeterTypeId";
        }
        /// <summary>
        /// 绑定水表口径
        /// </summary>
        private void BindWaterMeterSize()
        {
            DataTable dt = BLLwaterMeterSize.Query("");
            cmbWaterMeterSize.DataSource = dt;
            cmbWaterMeterSize.DisplayMember = "waterMeterSizeValue";
            cmbWaterMeterSize.ValueMember = "waterMeterSizeId";
        }
        private void BindBank(ComboBox cmb)
        {
            DataTable dt = BLLBASE_BANK.Query("");
            DataRow dr = dt.NewRow();
            dr["bankName"] = "";
            dr["bankId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "bankName";
            cmb.ValueMember = "bankId";
        }
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader(ComboBox cmb,string strType)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
            if (strType == "0")
            {
                DataRow dr = dt.NewRow();
                dr["USERNAME"] = "全部";
                dr["LOGINID"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
        }
        /// <summary>
        /// 绑定收费员，如果strType为0，则添加‘全部’项
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="strType"></param>
        private void BindCharger(ComboBox cmb, string strType)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
            if (strType == "0")
            {
                DataRow dr = dt.NewRow();
                dr["USERNAME"] = "全部";
                dr["LOGINID"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
        }

        private void BindWaterUserType(ComboBox cmb)
        {
            DataTable dt = BLLwaterUserType.Query("");
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterUserTypeName";
            cmb.ValueMember = "waterUserTypeId";
            if (dt.Rows.Count == 0)
            {
                mes.Show("请先添加用户类别档案后再进行用户操作!");
                gbWaterMeter.Enabled = false;
                gbWaterUser.Enabled = false;
            }
        }
        /// <summary>
        /// 绑定水表位置
        /// </summary>
        private void BindWaterMeterPosition()
        {
            DataTable dt = BLLwaterMeterPosition.Query("");
            cmbWaterMeterPosition.DataSource = dt;
            cmbWaterMeterPosition.DisplayMember = "waterMeterPositionName";
            cmbWaterMeterPosition.ValueMember = "waterMeterPositionId";
        }

        private void toolSaveUser_Click(object sender, EventArgs e)
        {
            #region 用户验证
            int intStartNO = 0, intCount = 1, intOrderNumberStart = 1;
            if (txtWaterUserNOStart.Text.Trim() == "")
            {
                mes.Show("请输入用户编号!");
                txtWaterUserNOStart.Focus();
                return;
            }
            else
            {
                string strWaterUserNOStart = txtWaterUserNOStart.Text;
                if (strWaterUserNOStart.Length == 6)
                {
                    if (strWaterUserNOStart.Substring(0, 1) != "U")
                    {
                        mes.Show("用户号由'U'+5位数字组成,请重新填写!");
                        txtWaterUserNOStart.SelectAll();
                        return;
                    }
                    else
                    {
                        if (!Information.IsNumeric(strWaterUserNOStart.Substring(1, 5)))
                        {
                            mes.Show("用户号由'U'+5位数字组成,请重新填写!");
                            txtWaterUserNOStart.SelectAll();
                            return;
                        }
                        else
                            intStartNO = Convert.ToInt32(strWaterUserNOStart.Substring(1, 5));
                    }
                }
                else
                {
                    mes.Show("用户号由'U'+5位数字组成,请重新填写!");
                    txtWaterUserNOStart.SelectAll();
                    return;
                }
            }
            if (!Information.IsNumeric(txtCount.Text))
            {
                mes.Show("请输入正确的数量!");
                txtCount.SelectAll();
                return;
            }
            else
            {
                if (Convert.ToInt16(txtCount.Text) < 1)
                {
                    mes.Show("请输入大于0的整数!");
                    txtCount.SelectAll();
                    return;
                }
                else
                    intCount = Convert.ToInt16(txtCount.Text);
            }

            //if (txtWaterUserName.Text.Trim() == "")
            //{
            //    mes.Show("请输入用户名称!");
            //    txtWaterUserName.Focus();
            //    return;
            //}
            if (txtWaterUserCount.Text.Trim() == "")
            {
                mes.Show("请输入人口数量!");
                txtWaterUserCount.Focus();
                return;
            }

            string strWaterUserIsExist = "SELECT * FROM WATERUSER WHERE WATERUSERID BETWEEN 'U" + intStartNO.ToString().PadLeft(5, '0')
                + "' AND 'U" + (intStartNO + intCount).ToString().PadLeft(5, '0') + "'";
            DataTable dtWaterUserQuery = BLLwaterUser.QuerySQL(strWaterUserIsExist);
            if (dtWaterUserQuery.Rows.Count > 0)
            {
                string strWaterUserIDS = "";
                for (int i = 0; i < dtWaterUserQuery.Rows.Count; i++)
                {
                    object objWaterUserID = dtWaterUserQuery.Rows[i]["WATERUSERID"];
                    if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                    {
                        if (strWaterUserIDS == "")
                            strWaterUserIDS = objWaterUserID.ToString();
                        else
                            strWaterUserIDS += ";" + objWaterUserID.ToString();
                    }
                }
                mes.Show("存在已使用的用户号'" + strWaterUserIDS + "'");
                return;
            }

            if (cmbAreaNO.SelectedValue == null || cmbAreaNO.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择区号!");
                cmbAreaNO.Focus();
                return;
            }
            if (cmbPianNO.SelectedValue == null || cmbPianNO.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择片号!");
                cmbPianNO.Focus();
                return;
            }
            if (cmbDuanNO.SelectedValue == null || cmbDuanNO.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择段号!");
                cmbDuanNO.Focus();
                return;
            }
            if (cmbCommunity.SelectedValue == null || cmbCommunity.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择小区!");
                cmbCommunity.Focus();
                return;
            }
            if (cmbMeterReader.SelectedValue == null || cmbMeterReader.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择抄表员!");
                cmbMeterReader.Focus();
                return;
            }
            if (cmbCharger.SelectedValue == null || cmbCharger.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择收费员!");
                cmbCharger.Focus();
                return;
            }
            if (cmbCreateType.SelectedIndex < 0)
            {
                mes.Show("请选择建档类型!");
                cmbCreateType.Focus();
                return;
            }
            if (!Information.IsNumeric(txtOrderNumber.Text))
            {
                mes.Show("请输入正确的顺序号!");
                txtOrderNumber.Focus();
                return;
            }
            else
                intOrderNumberStart = Convert.ToInt32(txtOrderNumber.Text);

            if (cmbCerficateType.Text != "")
            {
                if (txtCerficateNO.Text.Trim() == "")
                {
                    mes.Show("请输入证件编号!");
                    cmbUserType.Focus();
                    return;
                }
            }
            if (cmbWaterUserChargeType.Text == "")
            {
                mes.Show("请选择交费方式!");
                cmbWaterUserChargeType.Focus();
                return;
            }
            if (cmbAgentSign.Text == "")
            {
                mes.Show("请设置银行是否托收!");
                cmbAgentSign.Focus();
                return;
            }
            else
            {
                if (cmbAgentSign.Text == "托收")
                {
                    if (cmbAgentBank.SelectedValue == null || cmbAgentBank.SelectedValue == DBNull.Value)
                    {
                        mes.Show("请选择托收银行!");
                        cmbAgentBank.Focus();
                        return;
                    }
                    if (txtWaterUserBankNO.Text.Trim() == "")
                    {
                        mes.Show("请输入银行卡号!");
                        txtWaterUserBankNO.Focus();
                        return;
                    }
                }
            }
            #endregion

            #region 水表验证

            if (cmbWaterMeterSize.SelectedValue == null || cmbWaterMeterSize.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择水表口径!");
                cmbWaterMeterSize.Focus();
                return;
            }
            if (cmbWaterType.SelectedValue == null || cmbWaterType.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择用水类别!");
                cmbWaterType.Focus();
                return;
            }
            if (cmbWaterMeterState.Text == "")
            {
                mes.Show("请选择水表状态!");
                cmbWaterMeterState.Focus();
                return;
            }
            if (!Information.IsNumeric(txtWaterMeterStartNum.Text))
            {
                mes.Show("初始读数只能为整数!");
                txtWaterMeterStartNum.Focus();
                return;
            }
            if (!Information.IsNumeric(txtWaterMeterMagnification.Text))
            {
                mes.Show("倍率只能为整数!");
                txtWaterMeterMagnification.Focus();
                return;
            }
            if (!Information.IsNumeric(txtWaterMeterMaxRange.Text))
            {
                mes.Show("最大量程只能为整数!");
                txtWaterMeterMaxRange.Focus();
                return;
            }
            if (!Information.IsNumeric(txtProofreadingPeriod.Text))
            {
                mes.Show("鉴定周期只能为整数!");
                txtProofreadingPeriod.Focus();
                return;
            }
            if (!Information.IsNumeric(txtWaterMeterFixedValue.Text))
            {
                mes.Show("定量用水只能为整数!");
                txtWaterMeterFixedValue.Focus();
                return;
            }
            if (cmbIsSummary.Text == "")
            {
                mes.Show("请选择是否为总表!");
                cmbIsSummary.Focus();
                return;
            }
            if (txtWaterMeterIsSummary.Text.Trim() != "")
            {
                if (txtWaterMeterIsSummary.Text.Trim().Length != 8 && txtWaterMeterIsSummary.Text.Trim().Length != 6)
                {
                    mes.Show("总表编号只能为6位用户号或者8位水表编号!");
                    txtWaterMeterIsSummary.Focus();
                    return;
                }
            }
            #endregion

#region 自动排序
            try
            {
        string strSQL="UPDATE WATERUSER SET ordernumber=ordernumber+"+intCount+" WHERE areaNO='"+strAreaNO+
            "' AND pianNO='"+strPianNO+"' AND duanNO='"+strDuanNO+"' AND ordernumber>="+intOrderNumberStart;

            BLLwaterUser.ExcuteSQL(strSQL);
            }
            catch(Exception ex)
            {
                mes.Show("自动排序失败,批量添加成功后请手动排序!");
            }
#endregion

            for (int i = 0; i < intCount; i++)
            {
                try
                {
                    MODELWaterUser MODELWaterUser = new MODELWaterUser();
                    //MODELWaterUser.waterUserNO = GETTABLEID.GetTableID("", "WATERUSER");
                    MODELWaterUser.waterUserName = txtWaterUserName.Text;
                    MODELWaterUser.waterUserNameCode = txtCode.Text;
                    MODELWaterUser.waterUserAddress = txtWaterUserAddress.Text;
                    MODELWaterUser.waterUserCerficateType = cmbCerficateType.Text;
                    MODELWaterUser.waterUserCerficateNO = txtCerficateNO.Text;
                    MODELWaterUser.waterUserTelphoneNO = txtWaterUserTel.Text;
                    MODELWaterUser.waterPhone = txtPhone.Text;
                    MODELWaterUser.waterUserPeopleCount = txtWaterUserCount.Text;
                    MODELWaterUser.areaNO = cmbAreaNO.Text;
                    MODELWaterUser.pianNO = cmbPianNO.Text;
                    MODELWaterUser.duanNO = cmbDuanNO.Text;
                    MODELWaterUser.communityID = cmbCommunity.SelectedValue.ToString();
                    MODELWaterUser.buildingNO = txtBuildingNO.Text;
                    MODELWaterUser.unitNO = txtUnitNO.Text;
                    MODELWaterUser.waterUserTypeId = cmbUserType.SelectedValue.ToString();
                    MODELWaterUser.chargeType = cmbWaterUserChargeType.SelectedIndex.ToString();

                    MODELWaterUser.waterUserHouseType = cmbUserHouseType.Text;
                    if (MODELWaterUser.waterUserHouseType == "楼房")
                    {
                        MODELWaterUser.waterUserHouseType = "1";
                    }
                    else
                        MODELWaterUser.waterUserHouseType = "2";

                    MODELWaterUser.meterReaderID = cmbMeterReader.SelectedValue.ToString();
                    MODELWaterUser.meterReaderName = cmbMeterReader.Text;

                    MODELWaterUser.chargerID = cmbCharger.SelectedValue.ToString();
                    MODELWaterUser.chargerName = cmbCharger.Text;

                    //MODELWaterUser.meterReadingID = cmbWaterUserMeterReadingNO.SelectedValue.ToString();
                    //MODELWaterUser.meterReadingPageNo = txtMeterReadingPageNO.Text;
                    MODELWaterUser.ordernumber = intOrderNumberStart+i;

                    MODELWaterUser.agentsign = cmbAgentSign.Text;
                    if (MODELWaterUser.agentsign == "托收")
                    {
                        MODELWaterUser.agentsign = "1";
                        MODELWaterUser.bankId = cmbAgentBank.SelectedValue.ToString();
                        MODELWaterUser.BankAcountNumber = txtWaterUserBankNO.Text;
                    }
                    else
                        MODELWaterUser.agentsign = "2";

                    MODELWaterUser.createType = cmbCreateType.Text;
                    MODELWaterUser.MEMO = txtWaterUserMemo.Text;
                    MODELWaterUser.operatorName = strLogName;

                    MODELWaterUser.waterUserNO = "U" + (intStartNO+i).ToString().PadLeft(5, '0');
                    MODELWaterUser.waterUserId = MODELWaterUser.waterUserNO;
                    MODELWaterUser.waterUserCreateDate = mes.GetDatetimeNow();
                    if (BLLwaterUser.InsertwaterUser(MODELWaterUser))
                    {
                        try
                        {
                            MODELwaterMeter MODELwaterMeter = new MODELwaterMeter();
                            //if(cmbWaterMeterPosition.SelectedValue!=null&&cmbWaterMeterPosition.SelectedValue!=DBNull.Value)
                            //    MODELwaterMeter.waterMeterPositionId = cmbWaterMeterPosition.SelectedValue.ToString();
                            MODELwaterMeter.waterMeterPositionName = cmbWaterMeterPosition.Text;
                            MODELwaterMeter.waterMeterSizeId = cmbWaterMeterSize.SelectedValue.ToString();

                            //如果正常则添加启用时间
                            if (cmbWaterMeterState.Text == "正常")
                            {
                                MODELwaterMeter.waterMeterState = "1";
                                MODELwaterMeter.STARTUSEDATETIME = mes.GetDatetimeNow();
                            }
                            //if (cmbWaterMeterState.Text == "停水")
                            //    MODELwaterMeter.waterMeterState = "2";
                            //if (cmbWaterMeterState.Text == "报废")
                                MODELwaterMeter.waterMeterState = (cmbWaterMeterState.SelectedIndex+1).ToString();
                            MODELwaterMeter.waterMeterTypeId = cmbWaterType.SelectedValue.ToString();

                            MODELwaterMeter.WATERFIXVALUE = Convert.ToInt32(txtWaterMeterFixedValue.Text);
                            MODELwaterMeter.waterMeterStartNumber = Convert.ToInt32(txtWaterMeterStartNum.Text);
                            MODELwaterMeter.waterMeterProduct = txtWaterMeterProductor.Text;
                            MODELwaterMeter.waterMeterSerialNumber = txtWaterMeterSerialNum.Text;
                            MODELwaterMeter.waterMeterMode = txtWaterMeterModel.Text;
                            MODELwaterMeter.WATERMETERLOCKNO = txtLockNO.Text;
                            MODELwaterMeter.waterMeterMaxRange = Convert.ToInt32(txtWaterMeterMaxRange.Text);
                            //if (Information.IsDate(txtWaterMeterProofDate.Text))
                            //    MODELwaterMeter.waterMeterProofreadingDate = Convert.ToDateTime(txtWaterMeterProofDate.Text);
                            MODELwaterMeter.waterMeterProofreadingDate = dtpProofDate.Value;
                            MODELwaterMeter.waterMeteProofreadingPeriod = Convert.ToInt32(txtProofreadingPeriod.Text);
                            MODELwaterMeter.waterMeterMagnification = Convert.ToInt32(txtWaterMeterMagnification.Text);
                            MODELwaterMeter.waterUserId = MODELWaterUser.waterUserId;
                            MODELwaterMeter.isSummaryMeter = (cmbIsSummary.SelectedIndex + 1).ToString();//分表为1  总表为2
                            MODELwaterMeter.waterMeterParentId = txtWaterMeterIsSummary.Text;

                            MODELwaterMeter.IsReverse = "0";

                            MODELwaterMeter.MEMO = txtWaterMeterMemo.Text;
                            MODELwaterMeter.waterMeterId = MODELWaterUser.waterUserId + "01";
                            MODELwaterMeter.waterMeterNo = MODELwaterMeter.waterMeterId;
                            //MODELwaterMeter.STARTUSEDATETIME = mes.GetDatetimeNow();
                            if (!BLLwaterMeter.Insert(MODELwaterMeter))
                            {
                                mes.Show("添加用户编号为'" + MODELWaterUser.waterUserId + "'的水表信息时保存失败!请检查填写项目是否符合验证规则!");
                                return;
                            }
                            else
                            {
                                MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                                MODELOPERATORLOG.LOGCONTENT = "新增水表:" + MODELwaterMeter.waterMeterId;
                                //MODELOPERATORLOG.METERREADINGID = cmbWaterUserMeterReadingNO.SelectedValue.ToString();
                                MODELOPERATORLOG.LOGTYPE = "2";  //1代表用户 2代表水表
                                MODELOPERATORLOG.OPERATORID = strLogID;
                                MODELOPERATORLOG.OPERATORNAME = strLogName;
                                BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                            }
                        }
                        catch (Exception ex)
                        {
                            //回滚用户表
                            BLLwaterUser.DeleteUser(MODELWaterUser.waterUserId);

                            mes.Show(ex.Message);
                            log.Write(ex.ToString(), MsgType.Error);
                            return;
                        }
                    }
                    else
                    {
                        mes.Show("添加用户编号为'" + MODELWaterUser.waterUserId + "'时保存失败!请检查填写项目是否符合验证规则!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    mes.Show(ex.Message);
                    log.Write(ex.ToString(), MsgType.Error);
                    return;
                }
            }
            DataTable dtList = BLLwaterMeter.QueryConnectWaterUser(" AND WATERUSERID BETWEEN 'U" + intStartNO.ToString().PadLeft(5, '0')
                + "' AND 'U" + (intStartNO + intCount).ToString().PadLeft(5, '0') + "'");
            dgList.DataSource = dtList;
        }

        private void txtWaterUserCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void dgWaterUser_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        PinYinConvert PinYinConvert = new PinYinConvert();
        private void txtWaterUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtWaterUserName.Text.Trim() != "")
                txtCode.Text = GetChineseSpell(txtWaterUserName.Text);
            else
                txtCode.Clear();
        }
        static public string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }

        static public string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }
    }
}
