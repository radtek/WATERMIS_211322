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
    public partial class frmWaterUserAndMeter : DockContentEx
    {
        public frmWaterUserAndMeter()
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

        /// <summary>
        /// 存储未修改之前的用户信息
        /// </summary>
        MODELWaterUser MODELWaterUserOld = new MODELWaterUser();

        /// <summary>
        /// 存储未修改之前的水表信息
        /// </summary>
        MODELwaterMeter MODELwaterMeterOld = new MODELwaterMeter();

        private void frmWATERUSERANDMETER_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            dgWaterUser.AutoGenerateColumns = false;
            dgWaterMeter.AutoGenerateColumns = false;

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

            DisEnableControls(gbWaterMeter, "用户水表");
            DisEnableControls(gbWaterUser, "用水用户");

            BindWaterMeterType(cmbWaterType);
            BindWaterMeterType(cmbWaterMeterTypeChange);
            BindWaterMeterSize();
            BindWaterMeterPosition();
            //BindWaterMeterSummary();//815138547
            BindBank(cmbAgentBank);
            BindWaterUserType(cmbUserType);

            BindAreaNO(cmbAreaNOS,"0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS,"0");
            BindCharger(cmbChargerS, "0");

            BindAreaNO(cmbAreaNO,"1");
            BindPianNO(cmbPianNO, "1");
            BindDuanNO(cmbDuanNO, "1");
            BindCommunity(cmbCommunity, "1");
            BindMeterReader(cmbMeterReader, "1");
            BindCharger(cmbCharger, "1");
            BindParentID();

        }
        /// <summary>
        /// 绑定总表
        /// </summary>
        private void BindParentID()
        {
            DataTable dtParent = BLLwaterMeter.QuerySummary("");
            DataRow dr = dtParent.NewRow();
            dr["waterUserName"] = "";
            dr["waterMeterId"] = DBNull.Value;
            dtParent.Rows.InsertAt(dr, 0);
            cmbMeterParentName.DataSource = dtParent;

            cmbMeterParentName.DisplayMember = "waterUserName";
            cmbMeterParentName.ValueMember = "waterMeterId";
            cmbMeterParentName.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmbMeterParentName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
        }
        private void BindCommunity(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
            {
                dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000' ORDER BY COMMUNITYNAME");
                DataRow dr = dt.NewRow();
                dr["COMMUNITYNAME"] = "全部小区";
                dr["COMMUNITYID"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
            }
            else
                dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000' ORDER BY COMMUNITYNAME");
            cmb.DataSource = dt;
            cmb.DisplayMember = "COMMUNITYNAME";
            cmb.ValueMember = "COMMUNITYID";

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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
            DataRow dr = dt.NewRow();
            dr["waterUserTypeName"] = "";
            dr["waterUserTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
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
        ///// <summary>
        ///// 绑定总表
        ///// </summary>
        //private void BindWaterMeterSummary()
        //{
        //    DataTable dt = BLLwaterMeter.QuerySummary("");
        //    DataRow dr = dt.NewRow();
        //    dr["waterMeterNo"] = "";
        //    dr["waterMeterId"] = DBNull.Value;
        //    dt.Rows.InsertAt(dr, 0);
        //    cmbWaterMeterIsSummary.DataSource = dt;
        //    cmbWaterMeterIsSummary.DisplayMember = "waterMeterNo";
        //    cmbWaterMeterIsSummary.ValueMember = "waterMeterId";
        //}


        private void dgWaterUser_SelectionChanged(object sender, EventArgs e)
        {
            MODELWaterUserOld = new MODELWaterUser();
            if (dgWaterUser.CurrentRow == null)
            {
                return;
            }
            txtWaterUserID.Clear();
            ClearWaterUser(gbWaterUser);
            ClearWaterUser(gbWaterMeter);
            gbWaterMeter.Enabled = true;
            object obj = dgWaterUser.CurrentRow.Cells["waterUserId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserID.Text = obj.ToString();
                MODELWaterUserOld.waterUserId = obj.ToString();
                DataTable dt = BLLwaterMeter.Query(" AND waterUserId='" + obj.ToString() + "'");
                dgWaterMeter.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(0, 0);
                    //dgWaterMeter_CellClick(null,ex);
                    dgWaterMeter_RowEnter(null, ex);
                }
                else
                {
                    toolDeleteWaterMeter.Enabled = false;
                    toolModifyWaterMeter.Enabled = false;
                }
            }
            else
                txtWaterUserID.Clear();

            obj = dgWaterUser.CurrentRow.Cells["waterUserNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserNO.Text = obj.ToString();
                MODELWaterUserOld.waterUserNO = obj.ToString();
            }
            else
                txtWaterUserNO.Clear();
            obj = dgWaterUser.CurrentRow.Cells["waterUserName"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserName.Text = obj.ToString();
                MODELWaterUserOld.waterUserName = obj.ToString();
            }

            obj = dgWaterUser.CurrentRow.Cells["waterUserNameCode"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtCode.Text = obj.ToString();
                MODELWaterUserOld.waterUserNameCode = obj.ToString();
            }
            obj = dgWaterUser.CurrentRow.Cells["waterUserPeopleCount"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserCount.Text = obj.ToString();
                MODELWaterUserOld.waterUserPeopleCount = obj.ToString();
            }
            obj = dgWaterUser.CurrentRow.Cells["waterUserAddress"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserAddress.Text = obj.ToString();
                MODELWaterUserOld.waterUserAddress = obj.ToString();
            }
            obj = dgWaterUser.CurrentRow.Cells["waterUserCerficateType"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtCerficateType.Text = obj.ToString();
                cmbCerficateType.Text = obj.ToString();
                MODELWaterUserOld.waterUserCerficateType = obj.ToString();
            }
            obj = dgWaterUser.CurrentRow.Cells["waterUserCerficateNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtCerficateNO.Text = obj.ToString();
                MODELWaterUserOld.waterUserCerficateNO = obj.ToString();
            }
            obj = dgWaterUser.CurrentRow.Cells["waterUserTelphoneNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserTel.Text = obj.ToString();
                MODELWaterUserOld.waterUserTelphoneNO = obj.ToString();
            }
            obj = dgWaterUser.CurrentRow.Cells["waterPhone"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtPhone.Text = obj.ToString();
                MODELWaterUserOld.waterPhone = obj.ToString();
            }
            obj = dgWaterUser.CurrentRow.Cells["areaNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtAreaNO.Text = obj.ToString();
                cmbAreaNO.Text = obj.ToString();
                MODELWaterUserOld.areaNO = obj.ToString();
            }
            else
                cmbAreaNO.SelectedValue = DBNull.Value;

            obj = dgWaterUser.CurrentRow.Cells["pianNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtPianNO.Text = obj.ToString();
                cmbPianNO.Text = obj.ToString();
                MODELWaterUserOld.pianNO = obj.ToString();
            }
            else
                cmbPianNO.SelectedValue = DBNull.Value;
            obj = dgWaterUser.CurrentRow.Cells["duanNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtDuanNO.Text = obj.ToString();
                cmbDuanNO.Text = obj.ToString();
                MODELWaterUserOld.duanNO = obj.ToString();
            }
            else
                cmbDuanNO.SelectedValue = DBNull.Value;
            obj = dgWaterUser.CurrentRow.Cells["communityID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbCommunity.SelectedValue = obj.ToString();
                MODELWaterUserOld.communityID = obj.ToString();

                obj = dgWaterUser.CurrentRow.Cells["COMMUNITYNAME"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    txtCommunity.Text = obj.ToString();
                }
            }
            else
                cmbCommunity.SelectedValue = DBNull.Value;
            obj = dgWaterUser.CurrentRow.Cells["buildingNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtBuildingNO.Text = obj.ToString();
                MODELWaterUserOld.buildingNO = obj.ToString();
            }
            obj = dgWaterUser.CurrentRow.Cells["unitNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtUnitNO.Text = obj.ToString();
                MODELWaterUserOld.unitNO = obj.ToString();
            }

            obj = dgWaterUser.CurrentRow.Cells["ordernumber"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtOrderNumber.Text = obj.ToString();
                MODELWaterUserOld.ordernumber = Convert.ToInt32(obj);
            }
            obj = dgWaterUser.CurrentRow.Cells["meterReaderID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbMeterReader.SelectedValue = obj.ToString();
                MODELWaterUserOld.meterReaderID = obj.ToString();
                obj = dgWaterUser.CurrentRow.Cells["meterReaderName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    txtWaterUserMeterReader.Text = obj.ToString();
                    MODELWaterUserOld.meterReaderName = obj.ToString();
                }
            }
            else
                cmbMeterReader.SelectedValue = DBNull.Value;

            obj = dgWaterUser.CurrentRow.Cells["chargerID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbCharger.SelectedValue = obj.ToString();
                MODELWaterUserOld.chargerID = obj.ToString();
                obj = dgWaterUser.CurrentRow.Cells["chargerName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    txtCharger.Text = obj.ToString();
                    MODELWaterUserOld.chargerName = obj.ToString();
                }
            }
            else
                cmbCharger.SelectedValue = DBNull.Value;

            obj = dgWaterUser.CurrentRow.Cells["waterUserTypeName"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserType.Text = obj.ToString();
            }
            else
                txtWaterUserType.Clear();

            obj = dgWaterUser.CurrentRow.Cells["waterUserTypeId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbUserType.SelectedValue = obj.ToString();
                MODELWaterUserOld.waterUserTypeId = obj.ToString();
            }
            else
                cmbUserType.Text = "";

            obj = dgWaterUser.CurrentRow.Cells["agentsign"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserAgentSign.Text = obj.ToString();
                cmbAgentSign.Text = obj.ToString();
                if (obj.ToString() == "不托收")
                    MODELWaterUserOld.agentsign = "2";
                else
                    MODELWaterUserOld.agentsign = "1";
            }
            else
            {
                txtWaterUserAgentSign.Clear();
                cmbAgentBank.Text = "";
            }
            obj = dgWaterUser.CurrentRow.Cells["bankName"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserBank.Text = obj.ToString();
            }
            else
                txtWaterUserBank.Clear();
            obj = dgWaterUser.CurrentRow.Cells["bankId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbAgentBank.SelectedValue = obj.ToString();
                MODELWaterUserOld.bankId = obj.ToString();
            }
            else
                cmbAgentBank.Text = "";
            obj = dgWaterUser.CurrentRow.Cells["BankAcountNumber"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserBankNO.Text = obj.ToString();
                MODELWaterUserOld.BankAcountNumber = obj.ToString();
            }
            else
                txtWaterUserBankNO.Clear();

            obj = dgWaterUser.CurrentRow.Cells["waterUserHouseTypeS"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserHouseType.Text = obj.ToString();
                cmbUserHouseType.Text = obj.ToString();
                if (obj.ToString() == "楼房")
                    MODELWaterUserOld.waterUserHouseType = "1";
                else
                    MODELWaterUserOld.waterUserHouseType = "2";
            }
            else
            {
                txtWaterUserHouseType.Clear();
                cmbUserHouseType.Text = "";
            }
            obj = dgWaterUser.CurrentRow.Cells["chargeTypeS"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserChargeType.Text = obj.ToString();
                cmbWaterUserChargeType.Text = obj.ToString();
                if (obj.ToString() == "预存")
                    MODELWaterUserOld.chargeType = "1";
                else
                    MODELWaterUserOld.chargeType = "0";
            }
            else
            {
                txtWaterUserChargeType.Clear();
                cmbWaterUserChargeType.Text = "";
            }
            obj = dgWaterUser.CurrentRow.Cells["memo"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterUserMemo.Text = obj.ToString();
                MODELWaterUserOld.MEMO = obj.ToString();
            }

            obj = dgWaterUser.CurrentRow.Cells["createType"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtCreateType.Text = obj.ToString();
                cmbCreateType.Text = obj.ToString();
                MODELWaterUserOld.createType = obj.ToString();
            }
            else
                cmbCreateType.Text = "";

            obj = dgWaterUser.CurrentRow.Cells["waterUserCreateDate"].Value;
            if (Information.IsDate(obj))
            {
                labCreateDateTime.Text = Convert.ToDateTime(obj).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
                labCreateDateTime.Text = "";

            obj = dgWaterUser.CurrentRow.Cells["waterUserUpdateDate"].Value;
            if (Information.IsDate(obj))
            {
                labUpdateDateTime.Text = Convert.ToDateTime(obj).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
                labUpdateDateTime.Text = "";

            obj = dgWaterUser.CurrentRow.Cells["operatorName"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                labOperator.Text = obj.ToString();
            }
            else
                labOperator.Text = "";
        }
        /// <summary>
        /// 清空文本框内容
        /// </summary>
        /// <param name="conContainer">容器name</param>
        private void ClearWaterUser(Control conContainer)
        {
            foreach (Control con in conContainer.Controls)
            {
                if (con is TextBox)
                {
                    con.Text = "";
                }
            }
        }

        /// <summary>
        /// 使得控件可以编辑
        /// </summary>
        /// <param name="conContainer"></param>
        private void EnableControls(Control conContainer, string strType)
        {
            foreach (Control con in conContainer.Controls)
            {
                if (con is TextBox)
                {
                    ((TextBox)con).ReadOnly = false;
                    ((TextBox)con).ForeColor = Color.Blue;
                }
                if (con is ComboBox)
                {
                    ((ComboBox)con).Visible = true;
                    ((ComboBox)con).ForeColor = Color.Blue;
                }
            }

            if (strType == "用水用户")
            {
                txtCerficateType.Visible = false;
                txtAreaNO.Visible = false;
                txtPianNO.Visible = false;
                txtDuanNO.Visible = false;
                txtCommunity.Visible = false;

                txtWaterUserType.Visible = false;
                txtWaterUserAgentSign.Visible = false;
                txtWaterUserBank.Visible = false;
                txtWaterUserHouseType.Visible = false;
                txtWaterUserChargeType.Visible = false;

                txtWaterUserMeterReader.Visible = false;
                txtCharger.Visible = false;
                txtWaterUserMeterReader.Visible = false;
                txtCreateType.Visible = false;
            }
            if (strType == "用户水表")
            {
                txtWaterMeterPosition.Visible = false;
                txtWaterMeterSize.Visible = false;
                txtWaterMeterState.Visible = false;
                //txtWaterMeterType.Visible = false;
                //txtWaterMeterTypeChange.Visible = false;
                //txtWaterMeterIsSummary.Visible = false;
                txtWaterMeterProofDate.Visible = false;
                txtIsSummary.Visible = false;
                txtWaterMeterIsSummary.Visible = false;


                chkUseChange.Enabled = true;
            }
        }

        /// <summary>
        /// 使得控件禁止编辑
        /// </summary>
        /// <param name="conContainer"></param>
        private void DisEnableControls(Control conContainer, string strType)
        {
            foreach (Control con in conContainer.Controls)
            {
                if (con is TextBox)
                {
                    ((TextBox)con).ReadOnly = true;
                    //((TextBox)con).ForeColor = SystemColors.WindowText;
                }
                if (con is ComboBox)
                {
                    ((ComboBox)con).Visible = false;
                }
            }
            if (strType == "用水用户")
            {
                txtCerficateType.Visible = true;
                txtAreaNO.Visible = true;
                txtPianNO.Visible = true;
                txtDuanNO.Visible = true;
                txtCommunity.Visible = true;
                txtCreateType.Visible = true;

                txtWaterUserType.Visible = true;
                txtWaterUserAgentSign.Visible = true;
                txtWaterUserBank.Visible = true;
                txtWaterUserHouseType.Visible = true;
                txtWaterUserChargeType.Visible = true;

                txtWaterUserMeterReader.Visible = true;
                txtCharger.Visible = true;
                txtWaterUserMeterReader.Visible = true;
            }
            if (strType == "用户水表")
            {
                txtWaterMeterPosition.Visible = true;
                txtWaterMeterSize.Visible = true;
                txtWaterMeterState.Visible = true;
                txtWaterMeterType.Visible = true;
                txtWaterMeterIsSummary.Visible = true;
                txtWaterMeterProofDate.Visible = true;
                txtIsSummary.Visible = true;
                txtWaterMeterIsSummary.Visible = true;

                txtWaterMeterTypeChange.Visible = true;
                chkUseChange.Enabled = false;
            }

        }

        private bool isAddWaterUser = false;
        private void toolAddUser_Click(object sender, EventArgs e)
        {
            if (toolAddUser.Text == "添加")
            {
                //ClearWaterUser(gbWaterUser);
                EnableControls(gbWaterUser, "用水用户");
                toolAddUser.Text = "取消";
                toolDeleteUser.Enabled = false;
                toolSaveUser.Enabled = true;
                toolWaterUserModify.Enabled = false;

                //禁用水表控件
                tbWaterMeter.Enabled = false;
                dgWaterMeter.DataSource = null;
                ClearWaterUser(gbWaterMeter);

                cmbAgentSign.Text = "不托收";
                cmbIsSummary.Text = "分表";
                cmbUserHouseType.Text = "正常";
                //cmbUserType.SelectedIndex = 0;
                //cmbWaterSize.seleced

                //trMeterReading.Enabled = false;
                gpUserList.Enabled = false;
                isAddWaterUser = true;
                txtWaterUserNO.Text = GETTABLEID.GetTableID("", "WATERUSER");
                txtWaterUserName.Clear();
                txtWaterUserBankNO.Clear();
                txtWaterUserBank.Clear();
                txtPhone.Clear();
                txtCerficateNO.Clear();
                txtWaterUserTel.Clear();
                txtWaterUserMemo.Clear();
                txtWaterUserBankNO.Clear();

                txtWaterUserName.Focus();

                chkIsReverse.Enabled = true;
            }
            else
            {
                dgWaterUser_SelectionChanged(null, null);
                DisEnableControls(gbWaterUser, "用水用户");
                toolAddUser.Text = "添加";
                toolDeleteUser.Enabled = true;
                toolSaveUser.Enabled = false;
                toolWaterUserModify.Enabled = true;

                gpUserList.Enabled = true;
                //启用水表控件
                tbWaterMeter.Enabled = true;

                isAddWaterUser = false;

                chkIsReverse.Enabled = false;

            }
        }

        private void toolWaterUserModify_Click(object sender, EventArgs e)
        {
            if (toolWaterUserModify.Text == "修改")
            {
                if (txtWaterUserID.Text.Trim() == "")
                {
                    mes.Show("系统检测到用户ID为空,请重新选择要修改的用户信息!");
                    return;
                }

                EnableControls(gbWaterUser, "用水用户");
                toolWaterUserModify.Text = "取消";
                toolDeleteUser.Enabled = false;
                toolSaveUser.Enabled = true;
                toolAddUser.Enabled = false;

                gpUserList.Enabled = false;

                //水表禁用控件
                tbWaterMeter.Enabled = false;
                isAddWaterUser = false;
                txtWaterUserName.Focus();
            }
            else
            {
                dgWaterUser_SelectionChanged(null, null);
                DisEnableControls(gbWaterUser, "用水用户");
                toolWaterUserModify.Text = "修改";
                toolDeleteUser.Enabled = true;
                toolSaveUser.Enabled = false;
                toolAddUser.Enabled = true;

                gpUserList.Enabled = true;

                //启用水表控件
                tbWaterMeter.Enabled = true;

                isAddWaterUser = false;
            }
        }

        private void toolSaveUser_Click(object sender, EventArgs e)
        {
            if (txtWaterUserName.Text.Trim() == "")
            {
                mes.Show("请输入用户名称!");
                txtWaterUserName.Focus();
                return;
            }
            if (txtWaterUserCount.Text.Trim() == "")
            {
                mes.Show("请输入人口数量!");
                txtWaterUserCount.Focus();
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
                if (cmbUserType.SelectedValue == null || cmbUserType.SelectedValue == DBNull.Value)
                {
                    mes.Show("请选择用户类别!");
                    cmbUserType.Focus();
                    return;
                }
            if (cmbCreateType.SelectedIndex<0)
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
            if (cmbCerficateType.Text != "")
            {
                if (txtCerficateNO.Text.Trim() == "")
                {
                    mes.Show("请输入证件编号!");
                    txtCerficateNO.Focus();
                    return;
                }
            }
            if (cmbWaterUserChargeType.Text == "")
            {
                mes.Show("请选择交费方式!");
                cmbWaterUserChargeType.Focus();
                return;
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
            MODELWaterUser.ordernumber = Convert.ToInt32(txtOrderNumber.Text);

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

            if (isAddWaterUser)
            {
                MODELWaterUser.waterUserNO = GETTABLEID.GetTableID("", "WATERUSER");
                MODELWaterUser.waterUserId = MODELWaterUser.waterUserNO;
            MODELWaterUser.waterUserCreateDate = mes.GetDatetimeNow();
                if (BLLwaterUser.InsertwaterUser(MODELWaterUser))
                {
                    MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                    MODELOPERATORLOG.METERREADINGID = MODELWaterUser.meterReadingID;
                    MODELOPERATORLOG.LOGCONTENT = "新增用户:" + MODELWaterUser.waterUserId + "-" + MODELWaterUser.waterUserName;
                    MODELOPERATORLOG.LOGTYPE = "1";  //1代表用户 2代表水表
                    MODELOPERATORLOG.OPERATORID = strLogID;
                    MODELOPERATORLOG.OPERATORNAME = strLogName;
                    BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                }
                else
                {
                    mes.Show("保存失败!请检查填写项目是否符合验证规则!");
                    return;
                }
            }
            else
            {
                MODELWaterUser.waterUserUpdateDate = mes.GetDatetimeNow();
                MODELWaterUser.waterUserNO = txtWaterUserNO.Text;
                MODELWaterUser.waterUserId = MODELWaterUser.waterUserNO;
                if (BLLwaterUser.UpdateUser(MODELWaterUser))
                {
                    #region 变更日志
                    string strModifyLog="";
                    if (MODELWaterUserOld.waterUserId == MODELWaterUser.waterUserId)
                    {
                        if ((MODELWaterUserOld.waterUserName == null ? "" : MODELWaterUserOld.waterUserName) != MODELWaterUser.waterUserName)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更用户名:" + MODELWaterUserOld.waterUserName + "→" + MODELWaterUser.waterUserName;
                            else
                                strModifyLog ="变更用户名:" + MODELWaterUserOld.waterUserName + "→" + MODELWaterUser.waterUserName;
                        }
                        if ((MODELWaterUserOld.waterPhone == null ? "" : MODELWaterUserOld.waterPhone) != MODELWaterUser.waterPhone)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更联系方式:" + MODELWaterUserOld.waterPhone + "→" + MODELWaterUser.waterPhone;
                            else
                                strModifyLog = "变更联系方式:" + MODELWaterUserOld.waterPhone + "→" + MODELWaterUser.waterPhone;
                        }
                        if ((MODELWaterUserOld.waterUserAddress == null ? "" : MODELWaterUserOld.waterUserAddress) != MODELWaterUser.waterUserAddress)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更地址:" + MODELWaterUserOld.waterUserAddress + "→" + MODELWaterUser.waterUserAddress;
                            else
                                strModifyLog = "变更地址:" + MODELWaterUserOld.waterUserAddress + "→" + MODELWaterUser.waterUserAddress;
                        }
                        if (MODELWaterUserOld.waterUserPeopleCount != MODELWaterUser.waterUserPeopleCount)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更人口数:" + MODELWaterUserOld.waterUserPeopleCount + "→" + MODELWaterUser.waterUserPeopleCount;
                            else
                                strModifyLog = "变更人口数:" + MODELWaterUserOld.waterUserPeopleCount + "→" + MODELWaterUser.waterUserPeopleCount;
                        }
                        if (MODELWaterUserOld.meterReadingID != MODELWaterUser.meterReadingID)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更抄表本:" + MODELWaterUserOld.meterReadingID + "→" + MODELWaterUser.meterReadingID;
                            else
                                strModifyLog = "变更抄表本:" + MODELWaterUserOld.meterReadingID + "→" + MODELWaterUser.meterReadingID;
                        }
                        if (MODELWaterUserOld.meterReadingPageNo != MODELWaterUser.meterReadingPageNo)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更页号:" + MODELWaterUserOld.meterReadingPageNo + "→" + MODELWaterUser.meterReadingPageNo;
                            else
                                strModifyLog = "变更页号:" + MODELWaterUserOld.meterReadingPageNo + "→" + MODELWaterUser.meterReadingPageNo;
                        }
                        if (MODELWaterUserOld.waterUserTypeId != MODELWaterUser.waterUserTypeId)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更用户类别:" + MODELWaterUserOld.waterUserTypeId + "→" + MODELWaterUser.waterUserTypeId;
                            else
                                strModifyLog = "变更用户类别:" + MODELWaterUserOld.waterUserTypeId + "→" + MODELWaterUser.waterUserTypeId;
                        }
                        if (MODELWaterUserOld.waterUserHouseType != MODELWaterUser.waterUserHouseType)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更户型:" + (MODELWaterUserOld.waterUserHouseType == "1" ? "楼房" : "平房") + "→" + (MODELWaterUser.waterUserHouseType == "1" ? "楼房" : "平房");
                            else
                                strModifyLog = "变更户型:" + (MODELWaterUserOld.waterUserHouseType == "1" ? "楼房" : "平房") + "→" + (MODELWaterUser.waterUserHouseType == "1" ? "楼房" : "平房");
                        }
                        if (MODELWaterUserOld.agentsign != MODELWaterUser.agentsign)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更托收:" + (MODELWaterUserOld.agentsign == "1" ? "托收" : "不托收") + "→" + (MODELWaterUser.agentsign == "1" ? "托收" : "不托收");
                            else
                                strModifyLog = "变更托收:" + (MODELWaterUserOld.agentsign == "1" ? "托收" : "不托收") + "→" + (MODELWaterUser.agentsign == "1" ? "托收" : "不托收");
                        }
                        if (MODELWaterUserOld.bankId != MODELWaterUser.bankId)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更托收银行:" + MODELWaterUserOld.bankId + "→" + MODELWaterUser.bankId;
                            else
                                strModifyLog = "变更托收银行:" + MODELWaterUserOld.bankId + "→" + MODELWaterUser.bankId;
                        }
                        if (MODELWaterUserOld.BankAcountNumber != MODELWaterUser.BankAcountNumber)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更银行账户:" + MODELWaterUserOld.BankAcountNumber + "→" + MODELWaterUser.BankAcountNumber;
                            else
                                strModifyLog = "变更银行账户:" + MODELWaterUserOld.BankAcountNumber + "→" + MODELWaterUser.BankAcountNumber;
                        }
                        if ((MODELWaterUserOld.MEMO == null ? "" : MODELWaterUserOld.MEMO) != MODELWaterUser.MEMO)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更备注:" + MODELWaterUserOld.MEMO + "→" + MODELWaterUser.MEMO;
                            else
                                strModifyLog = "变更备注:" + MODELWaterUserOld.MEMO + "→" + MODELWaterUser.MEMO;
                        }
                        if (MODELWaterUserOld.ordernumber != MODELWaterUser.ordernumber)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更顺序号:" + MODELWaterUserOld.ordernumber + "→" + MODELWaterUser.ordernumber;
                            else
                                strModifyLog = "变更顺序号:" + MODELWaterUserOld.ordernumber + "→" + MODELWaterUser.ordernumber;
                        }
                        if (MODELWaterUserOld.chargeType != MODELWaterUser.chargeType)
                        {
                            if (strModifyLog != "")
                                strModifyLog += "," + "变更交费类型:" + MODELWaterUserOld.chargeType + "→" + MODELWaterUser.chargeType;
                            else
                                strModifyLog = "变更交费类型:" + MODELWaterUserOld.chargeType + "→" + MODELWaterUser.chargeType;
                        }
                        if (strModifyLog != "")
                        {
                            strModifyLog = "用户编号:" + MODELWaterUser.waterUserId+"," + strModifyLog;
                            MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();     
                            MODELOPERATORLOG.METERREADINGID = MODELWaterUser.meterReadingID;
                            MODELOPERATORLOG.LOGCONTENT = strModifyLog;
                            MODELOPERATORLOG.LOGTYPE = "1";  //1代表用户 2代表水表
                            MODELOPERATORLOG.OPERATORID = strLogID;
                            MODELOPERATORLOG.OPERATORNAME = strLogName;
                            BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                        }
                    }
                    #endregion
                }
                else
                {
                    mes.Show("保存失败!请检查填写项目是否符合验证规则!");
                    return;
                }
            }
            DisEnableControls(gbWaterUser, "用水用户");

            btSearch_Click(null,null);
            for (int i = 0; i < dgWaterUser.Rows.Count; i++)
            {
                object objWaterUserID = dgWaterUser.Rows[i].Cells["waterUserId"].Value;
                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                {
                    if (objWaterUserID.ToString() == MODELWaterUser.waterUserId)
                    {
                        dgWaterUser.ClearSelection();
                        dgWaterUser.CurrentCell = dgWaterUser.Rows[i].Cells["waterUserName"];
                        dgWaterUser_SelectionChanged(null, null);
                        break;
                    }
                }
            }

            toolDeleteUser.Enabled = true;
            toolSaveUser.Enabled = false;
            toolAddUser.Text = "添加";
            toolAddUser.Enabled = true;
            toolWaterUserModify.Enabled = true;
            toolWaterUserModify.Text = "修改";
            gpUserList.Enabled = true;
            tbWaterMeter.Enabled = true;

            //toolStripWaterMeter.Enabled = true;
        }

        private void toolDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgWaterUser.CurrentRow == null)
            {
                return;
            }
            object obj = dgWaterUser.CurrentRow.Cells["waterUserId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                string strID = obj.ToString(), strWaterUserNO = "", strWaterUserName = "";
                obj = dgWaterUser.CurrentRow.Cells["waterUserName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterUserName = obj.ToString();
                }
                obj = dgWaterUser.CurrentRow.Cells["waterUserNO"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterUserNO = obj.ToString();
                }
                if (mes.ShowQ("确定要删除用户" + strWaterUserNO + "-" + strWaterUserName + "及水表信息吗?") == DialogResult.OK)
                {
                    MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                    MODELOPERATORLOG.LOGCONTENT = "删除用户:" + strID + "-" + strWaterUserName;
                   //MODELOPERATORLOG.METERREADINGID= cmbWaterUserMeterReadingNO.SelectedValue.ToString();
                    MODELOPERATORLOG.LOGTYPE = "1";  //1代表用户 2代表水表
                    MODELOPERATORLOG.OPERATORID = strLogID;
                    MODELOPERATORLOG.OPERATORNAME = strLogName;
                    BLLOPERATORLOG.Insert(MODELOPERATORLOG);

                    int intWaterMeterCount = dgWaterMeter.Rows.Count;
                    if (dgWaterMeter.Rows.Count > 0)
                    {
                        if (BLLwaterMeter.DeleteByUser(strID))
                        {
                            dgWaterMeter.DataSource = null;
                            if (BLLwaterUser.DeleteUser(strID))
                            {
                                MODELOPERATORLOG = new MODELOPERATORLOG();
                                MODELOPERATORLOG.LOGCONTENT = "删除用户:" + strID + "-" + strWaterUserName + "及水表" + intWaterMeterCount + "块";
                                //MODELOPERATORLOG.METERREADINGID = cmbWaterUserMeterReadingNO.SelectedValue.ToString();
                                MODELOPERATORLOG.LOGTYPE = "2";  //1代表用户 2代表水表
                                MODELOPERATORLOG.OPERATORID = strLogID;
                                MODELOPERATORLOG.OPERATORNAME = strLogName;
                                BLLOPERATORLOG.Insert(MODELOPERATORLOG);


                                dgWaterUser.Rows.Remove(dgWaterUser.CurrentRow);
                                if (dgWaterUser.Rows.Count == 0)
                                {
                                    txtWaterMeterID.Clear();
                                    txtWaterUserID.Clear();
                                    ClearWaterUser(gbWaterMeter);
                                    ClearWaterUser(gbWaterUser);
                                    gbWaterMeter.Enabled = false;
                                }
                            }
                            else
                            {
                                mes.Show("用户删除失败,请重新选择用户后再删除!");
                                return;
                            }
                        }
                        else
                        {
                            mes.Show("用户水表删除失败,请重新选择用户后再删除!");
                            return;
                        }
                    }
                    else
                        if (BLLwaterUser.DeleteUser(strID))
                        {
                            dgWaterUser.Rows.Remove(dgWaterUser.CurrentRow);
                            if (dgWaterUser.Rows.Count == 0)
                            {
                                ClearWaterUser(gbWaterMeter);
                                ClearWaterUser(gbWaterUser);
                            }
                        }
                        else
                        {
                            mes.Show("用户删除失败,请重新选择用户后再删除!");
                            return;
                        }

                }
            }
        }

        private void txtWaterUserCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private bool isAddWaterMeter = false;
        private void toolAddWaterMeter_Click(object sender, EventArgs e)
        {
            if (toolAddWaterMeter.Text == "添加")
            {
                toolAddWaterMeter.Text = "取消";
                toolModifyWaterMeter.Enabled = false;
                toolDeleteWaterMeter.Enabled = false;
                toolSaveWaterMeter.Enabled = true;
                cmbWaterMeterState.Text = "正常";
                gbWaterUser.Enabled = false;
                //dgWaterUser.Enabled = false;
                gpUserList.Enabled = false;
                dgWaterMeter.Enabled = false;

                txtWaterMeterID.Clear();
                //ClearWaterUser(gbWaterMeter);
                EnableControls(gbWaterMeter, "用户水表");

                txtWaterMeterMagnification.Text = "1";
                txtProofreadingPeriod.Text = "0";
                txtWaterMeterMaxRange.Text = "999999";
                txtWaterMeterFixedValue.Text = "0";
                txtWaterMeterStartNum.Text = "0";
                chkIsReverse.Checked = false;

                chkUseChange.Checked = false;

                txtWaterMeterNO.Text = GETTABLEID.GetTableID(txtWaterUserNO.Text, "WATERMETER");
                isAddWaterMeter = true;
            }
            else
            {
                toolAddWaterMeter.Text = "添加";
                toolModifyWaterMeter.Enabled = true;
                toolDeleteWaterMeter.Enabled = true;
                toolSaveWaterMeter.Enabled = false;
                gbWaterUser.Enabled = true;
                gpUserList.Enabled = true;
                dgWaterMeter.Enabled = true;

                DisEnableControls(gbWaterMeter, "用户水表");

                if (dgWaterMeter.CurrentRow != null)
                {
                    //DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(1, dgWaterMeter.CurrentRow.Index);
                    //dgWaterMeter_CellClick(null, ex);
                }
                isAddWaterMeter = false;
            }
        }
        private void toolModifyWaterMeter_Click(object sender, EventArgs e)
        {
            if (toolModifyWaterMeter.Text == "修改")
            {
                if (txtWaterMeterID.Text.Trim() == "")
                {
                    mes.Show("系统检测到用户水表ID为空,请重新选择要修改的水表信息!");
                    return;
                }
                toolModifyWaterMeter.Text = "取消";
                toolAddWaterMeter.Enabled = false;
                toolDeleteWaterMeter.Enabled = false;
                toolSaveWaterMeter.Enabled = true;
                gbWaterUser.Enabled = false;
                //dgWaterUser.Enabled = false;
                gpUserList.Enabled = false;
                dgWaterMeter.Enabled = false;

                EnableControls(gbWaterMeter, "用户水表");
                isAddWaterMeter = false;

                chkIsReverse.Enabled = true;
            }
            else
            {
                toolModifyWaterMeter.Text = "修改";
                toolAddWaterMeter.Enabled = true;
                toolDeleteWaterMeter.Enabled = true;
                toolSaveWaterMeter.Enabled = false;
                gbWaterUser.Enabled = true;
                gpUserList.Enabled = true;
                dgWaterMeter.Enabled = true;

                DisEnableControls(gbWaterMeter, "用户水表");
                chkIsReverse.Enabled = false;
            }
        }

        //private bool isAddMeterReading = false;
        //private void toolAdd_Click(object sender, EventArgs e)
        //{
        //    if (toolAdd.Text == "添加抄表本")
        //    {
        //        toolAdd.Text = "取消";
        //        toolDelete.Enabled = false;
        //        txtID.Clear();
        //        txtNO.Clear();
        //        txtMemo.Clear();
        //        txtGenerateDate.Clear();
        //        EnableControls(tpBaseMes, "");
        //        isAddMeterReading = true;
        //        trMeterReading.Enabled = false;
        //        //toolSave.Enabled = true;
        //    }
        //    else
        //    {
        //        toolAdd.Text = "添加抄表本";
        //        toolDelete.Enabled = true;
        //        EnableControls(tpBaseMes, "");
        //        isAddMeterReading = false;
        //        trMeterReading.Enabled = true;
        //        TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
        //        trMeterReading_AfterSelect(null, ex);
        //    }
        //}

        //private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        //{
            
        //}

        //private void toolDelete_Click(object sender, EventArgs e)
        //{
        //    if (trMeterReading.SelectedNode == null)
        //        return;
        //    string strNodeID = trMeterReading.SelectedNode.Name;
        //    string strNodeName = trMeterReading.SelectedNode.Text;
        //    string[] strNodeIDSpit = strNodeID.Split('|');
        //    if (strNodeIDSpit[1] != "无关ID" && strNodeIDSpit[1] != "")
        //    {
        //        if (mes.ShowQ("确定要删除抄表本为\"" + strNodeName + "\"的信息吗?") == DialogResult.OK)
        //            if (BLLmeterReading.Delete(strNodeIDSpit[1]))
        //            {
        //                trMeterReading.Nodes.Remove(trMeterReading.SelectedNode);
        //                BLLwaterUser.UpdateUserByMeterReading(strNodeIDSpit[1]);//将属于要删除的抄表本的用户的抄表本置为空
        //                BindMeterReading();
        //                for (int i = 0; i < trMeterReading.Nodes.Count; i++)
        //                {
        //                    DeleteMeterReadingNode(trMeterReading.Nodes[i], strNodeIDSpit[1]);
        //                }
        //            }
        //    }
        //}

        ///// <summary>
        ///// 删除指定ID的树形NODE
        ///// </summary>
        ///// <param name="tnParent">父级NODE</param>
        ///// <param name="strID">要删除的NODE的ID</param>
        //private void DeleteMeterReadingNode(TreeNode tnParent, string strID)
        //{
        //    for (int i = 0; i < tnParent.Nodes.Count; i++)
        //    {
        //        string strNodeName = tnParent.Nodes[i].Name;
        //        string[] strNodeIDSpit = strNodeName.Split('|');
        //        if (strNodeIDSpit[1] == strID)
        //            trMeterReading.Nodes.Remove(tnParent.Nodes[i]);
        //        else
        //        {
        //            DeleteMeterReadingNode(tnParent.Nodes[i], strID);
        //        }
        //    }
        //}
        //private void toolSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtNO.Text.Trim() == "")
        //        {
        //            mes.Show("请输入抄表本号!");
        //            txtNO.Focus();
        //            return;
        //        }
        //        if (cmbMeterReader.SelectedValue == null || cmbMeterReader.SelectedValue == DBNull.Value)
        //        {
        //            mes.Show("请选择抄表员!");
        //            cmbMeterReader.Focus();
        //            return;
        //        }
        //        if (cmbArea.SelectedValue == null || cmbArea.SelectedValue == DBNull.Value)
        //        {
        //            mes.Show("请选择所属区域!");
        //            cmbArea.Focus();
        //            return;
        //        }
        //        MODELmeterReading MODELmeterReading = new MODELmeterReading();
        //        MODELmeterReading.meterReadingNO = txtNO.Text;
        //        MODELmeterReading.loginId = cmbMeterReader.SelectedValue.ToString();
        //        MODELmeterReading.AREAID = cmbArea.SelectedValue.ToString();

        //        if(cmbCharger.SelectedValue!=DBNull.Value&&cmbCharger.SelectedValue!=null)
        //        MODELmeterReading.CHARGERID = cmbCharger.SelectedValue.ToString();

        //        MODELmeterReading.createDate = mes.GetDatetimeNow();
        //        MODELmeterReading.MEMO = txtMemo.Text;
        //        if (isAddMeterReading)
        //        {
        //            MODELmeterReading.meterReadingID = GETTABLEID.GetTableID("", "METERREADING");
        //            if (BLLmeterReading.Insert(MODELmeterReading))
        //            {
        //                AddGenerateTree(MODELmeterReading.meterReadingID);
        //                toolAdd.Text = "添加抄表本";
        //            }
        //            else
        //            {
        //                mes.Show("添加失败,请重新保存!");
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (txtID.Text == "")
        //            {
        //                mes.Show("如果要添加抄表本，请先点击“添加”按钮。\r如果要修改抄表本，请先选择要修改的抄表本!");
        //                txtNO.Focus();
        //                return;
        //            }
        //            MODELmeterReading.meterReadingID = txtID.Text;
        //            if (BLLmeterReading.Update(MODELmeterReading))
        //            {
        //                trMeterReading.SelectedNode.Text = MODELmeterReading.meterReadingNO;
        //            }
        //            else
        //            {
        //                mes.Show("添加失败,请重新保存!");
        //                return;
        //            }

        //        }

        //        isAddMeterReading = false;
        //        toolDelete.Enabled = true;
        //        trMeterReading.Enabled = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        mes.Show(ex.Message);
        //        log.Write(ex.Message, MsgType.Error);
        //    }
        //}

        ///// <summary>
        ///// 添加表本后生成抄表本树形结构
        ///// </summary>
        //private void AddGenerateTree(string strNodeID)
        //{
        //    trMeterReading.Nodes.Clear();
        //    TreeNode trNodeSelected = null;

        //    #region 生成抄表本树形结构
        //    TreeNode tnHeadMeterReading = trMeterReading.Nodes.Add("|无关ID|", "全部表本", 0, 1);
        //    DataTable dtMeterReading = BLLmeterReading.Query(" ORDER BY meterReadingNO");
        //    for (int i = 0; i < dtMeterReading.Rows.Count; i++)
        //    {
        //        string strID = "", strName = "";
        //        object objID = dtMeterReading.Rows[i]["meterReadingID"];
        //        if (objID != null && objID != DBNull.Value)
        //        {
        //            strID = "METERREADING|" + objID.ToString() + "| AND meterReadingID='" + objID.ToString() + "'";
        //            object objName = dtMeterReading.Rows[i]["meterReadingNO"];
        //            if (objName != null && objName != DBNull.Value)
        //            {
        //                strName = objName.ToString();
        //            }
        //            TreeNode trNodeAdd = tnHeadMeterReading.Nodes.Add(strID, strName, 0, 1);
        //            if (objID.ToString() == strNodeID)
        //                trNodeSelected = trNodeAdd;
        //        }
        //    }
        //    tnHeadMeterReading.Nodes.Add("|无关ID| AND meterReadingID=''", "表本为空", 0, 1);
        //    tnHeadMeterReading.ExpandAll();
        //    //tnHeadMeterReading.Checked = true;
        //    #endregion

        //    #region 按区域生成抄表本树形结构
        //    TreeNode tnHeadArea = trMeterReading.Nodes.Add("|无关ID|", "全部区域", 0, 1);
        //    DataTable dtArea = BLLAREA.Query(" AND AREAID<>'0000'");
        //    for (int i = 0; i < dtArea.Rows.Count; i++)
        //    {
        //        string strID = "", strName = "";
        //        object objID = dtArea.Rows[i]["areaId"];
        //        if (objID != null && objID != DBNull.Value)
        //        {
        //            strID = "AREA|无关ID| AND areaId='" + objID.ToString() + "'";
        //        }
        //        object objName = dtArea.Rows[i]["areaName"];
        //        if (objName != null && objName != DBNull.Value)
        //        {
        //            strName = objName.ToString();
        //        }
        //        TreeNode tnAreaMeterReading = tnHeadArea.Nodes.Add(strID, strName, 0, 1);
        //        if (strID != "")
        //        {
        //            DataTable dtAreaMeterReading = BLLmeterReading.Query(" AND AREAID='" + objID.ToString() + "' ORDER BY meterReadingNO");
        //            for (int j = 0; j < dtAreaMeterReading.Rows.Count; j++)
        //            {
        //                string strMeterReadingID = "", strMeterReadingName = "";
        //                object objMeterReadingID = dtAreaMeterReading.Rows[j]["meterReadingID"];
        //                if (objMeterReadingID != null && objMeterReadingID != DBNull.Value)
        //                {
        //                    strMeterReadingID = "METERREADING|" + objMeterReadingID.ToString() + "| AND meterReadingID='" + objMeterReadingID.ToString() + "'";
        //                }
        //                object objMeterReadingName = dtAreaMeterReading.Rows[j]["meterReadingNO"];
        //                if (objMeterReadingName != null && objMeterReadingName != DBNull.Value)
        //                {
        //                    strMeterReadingName = objMeterReadingName.ToString();
        //                }
        //                tnAreaMeterReading.Nodes.Add(strMeterReadingID, strMeterReadingName, 0, 1);
        //            }
        //        }
        //    }
        //    tnHeadArea.Nodes.Add("|无关ID| AND meterReadingID=''", "区域为空", 0, 1);
        //    #endregion

        //    #region 按抄表员生成抄表本树形结构
        //    TreeNode tnHeadMeterReader = trMeterReading.Nodes.Add("|无关ID|", "全部抄表员", 0, 1);
        //    DataTable dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是'");
        //    for (int i = 0; i < dtMeterReader.Rows.Count; i++)
        //    {
        //        string strID = "", strName = "";
        //        object objID = dtMeterReader.Rows[i]["LOGINID"];
        //        if (objID != null && objID != DBNull.Value)
        //        {
        //            strID = "METERREADER|无关ID| AND LOGINID='" + objID.ToString() + "'";
        //        }
        //        object objName = dtMeterReader.Rows[i]["USERNAME"];
        //        if (objName != null && objName != DBNull.Value)
        //        {
        //            strName = objName.ToString();
        //        }
        //        TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
        //        if (strID != "")
        //        {
        //            DataTable dtMeterReaderMeterReading = BLLmeterReading.Query(" AND LOGINID='" + objID.ToString() + "' ORDER BY meterReadingNO");
        //            for (int j = 0; j < dtMeterReaderMeterReading.Rows.Count; j++)
        //            {
        //                string strMeterReadingID = "", strMeterReadingName = "";
        //                object objMeterReadingID = dtMeterReaderMeterReading.Rows[j]["meterReadingID"];
        //                if (objMeterReadingID != null && objMeterReadingID != DBNull.Value)
        //                {
        //                    strMeterReadingID = "METERREADING|" + objMeterReadingID.ToString() + "| AND meterReadingID='" + objMeterReadingID.ToString() + "'";
        //                }
        //                object objMeterReadingName = dtMeterReaderMeterReading.Rows[j]["meterReadingNO"];
        //                if (objMeterReadingName != null && objMeterReadingName != DBNull.Value)
        //                {
        //                    strMeterReadingName = objMeterReadingName.ToString();
        //                }
        //                tnMeterReaderMeterReading.Nodes.Add(strMeterReadingID, strMeterReadingName, 0, 1);
        //            }
        //        }
        //    }
        //    tnHeadMeterReader.Nodes.Add("|无关ID| AND meterReadingID=''", "抄表员为空", 0, 1);
        //    #endregion
        //    trMeterReading.SelectedNode = trNodeSelected;
        //}

        private void dgWaterMeter_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgWaterMeter.CurrentRow == null)
            //{
            //    toolDeleteWaterMeter.Enabled = false;
            //    return;
            //}
            //toolDeleteWaterMeter.Enabled = true;
            //object obj = dgWaterMeter.CurrentRow.Cells["waterMeterId"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterID.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterNo"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterNO.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterStartNumber"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterNO.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterPositionId"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    cmbWaterMeterPosition.SelectedValue = obj;
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterPositionName"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterPosition.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterSizeId"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    cmbWaterMeterSize.SelectedValue = obj;
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterSizeValue"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterSize.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterStateS"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterState.Text = obj.ToString();
            //    cmbWaterMeterState.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterTypeId"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    cmbWaterType.SelectedValue = obj;
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterTypeValue"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterType.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterStartNumber"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterStartNum.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterProduct"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterProductor.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterSerialNumber"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterSerialNum.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterMode"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterModel.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterMagnification"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterMagnification.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterMaxRange"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterMaxRange.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterProofreadingDate"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterProofDate.Text = obj.ToString();
            //    if (Information.IsDate(obj))
            //        dtpProofDate.Value = Convert.ToDateTime(obj);
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterNoParent"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterIsSummary.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["waterMeterParentId"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    cmbWaterMeterIsSummary.SelectedValue = obj;
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["WATERFIXVALUE"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterFixedValue.Text = obj.ToString();
            //}
            //obj = dgWaterMeter.CurrentRow.Cells["memoWaterMeter"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterMemo.Text = obj.ToString();
            //}
        }

        private void toolDeleteWaterMeter_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgWaterMeter.CurrentRow == null)
                    return;
                string strID = "", strNO = "";
                object obj = dgWaterMeter.CurrentRow.Cells["waterMeterId"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strID = obj.ToString();
                    obj = dgWaterMeter.CurrentRow.Cells["waterMeterNo"].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strNO = obj.ToString();
                        if (mes.ShowQ("确定要删除水表编号为\"" + strNO + "\"的信息吗?") == DialogResult.OK)
                        {
                            if (BLLwaterMeter.Delete(strID))
                            {
                                MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                                MODELOPERATORLOG.LOGCONTENT = "删除水表:" + strID;
                                //MODELOPERATORLOG.METERREADINGID = cmbWaterUserMeterReadingNO.SelectedValue.ToString();
                                MODELOPERATORLOG.LOGTYPE = "2";  //1代表用户 2代表水表
                                MODELOPERATORLOG.OPERATORID = strLogID;
                                MODELOPERATORLOG.OPERATORNAME = strLogName;
                                BLLOPERATORLOG.Insert(MODELOPERATORLOG);

                                dgWaterMeter.Rows.Remove(dgWaterMeter.CurrentRow);
                                if (dgWaterMeter.Rows.Count == 0)
                                {
                                    txtWaterMeterID.Clear();
                                    ClearWaterUser(gbWaterMeter);
                                    toolDeleteWaterMeter.Enabled = false;
                                    toolModifyWaterMeter.Enabled = false;
                                }
                            }
                            else
                            {
                                mes.Show("删除失败,请重新选择用户后再执行水表删除操作!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.Message, MsgType.Error);
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

        private void dgWaterMeter_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(null,null);
            }
            //if (dtUserList.Rows.Count > 0)
            //{
            //    DataTable dtUserListTemp = dtUserList.Copy();
            //    DataView dv = dtUserListTemp.DefaultView;
            //    dv.RowFilter = QueryWaterUser();
            //    dv.Sort = SortWaterUser();
            //    dgWaterUser.DataSource = dv;

            //    //计算水表数量
            //    labUserCount.Text = "用水用户" + dv.Count + "户";
            //}
            //else
            //    labUserCount.Text = "用水用户0户";
        }

        private void toolSaveWaterMeter_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cmbWaterMeterPosition.SelectedValue == null || cmbWaterMeterPosition.SelectedValue == DBNull.Value)
                //{
                //    mes.Show("请选择水表位置!");
                //    cmbWaterMeterPosition.Focus();
                //    return;
                //}
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

                if (chkUseChange.Checked)
                {
                    if (txtChangeMonth.Text.Trim() == "")
                    {
                        mes.Show("请输入开始执行新水价的月份!");
                        txtChangeMonth.Focus();
                        return;
                    }
                    else
                    {
                        string strMonth = txtChangeMonth.Text;
                        if (strMonth.Length != 6)
                        {
                            mes.Show("开始执行新水价的月份只能为6位，例如201509!");
                            txtChangeMonth.Focus();
                            return;
                        }
                        else
                        {
                            strMonth = strMonth.Substring(0,4) + "-" + strMonth.Substring(4,2) + "-01";
                            if (!Information.IsDate(strMonth))
                            {
                                mes.Show("请输入正确的执行新水价月份，例如201509!");
                                txtChangeMonth.Focus();
                                return;
                            }
                        }
                    }
                    if (cmbWaterMeterTypeChange.SelectedValue == null || cmbWaterMeterTypeChange.SelectedValue == DBNull.Value)
                    {
                        mes.Show("请选择启用变更的用水性质!");
                        cmbWaterMeterTypeChange.Focus();
                        return;
                    }
                }
                if (txtWaterMeterStartNum.Text.Trim() == "")
                    txtWaterMeterStartNum.Text = "0";
                if (txtWaterMeterMagnification.Text.Trim() == "")
                    txtWaterMeterMagnification.Text = "1";
                if (txtWaterMeterFixedValue.Text.Trim() == "")
                    txtWaterMeterFixedValue.Text = "0";
                MODELwaterMeter MODELwaterMeter = new MODELwaterMeter();
                //if(cmbWaterMeterPosition.SelectedValue!=null&&cmbWaterMeterPosition.SelectedValue!=DBNull.Value)
                //    MODELwaterMeter.waterMeterPositionId = cmbWaterMeterPosition.SelectedValue.ToString();
                MODELwaterMeter.waterMeterPositionName = cmbWaterMeterPosition.Text;
                MODELwaterMeter.waterMeterSizeId = cmbWaterMeterSize.SelectedValue.ToString();
                //if (cmbWaterMeterState.Text == "正常")
                //{
                //    MODELwaterMeter.waterMeterState = "1";
                //    //MODELwaterMeter.STARTUSEDATETIME = mes.GetDatetimeNow();
                //}
                //if (cmbWaterMeterState.Text == "停水")
                //    MODELwaterMeter.waterMeterState = "2";
                //if (cmbWaterMeterState.Text == "报废")
                //    MODELwaterMeter.waterMeterState = "3";
                MODELwaterMeter.waterMeterState = (cmbWaterMeterState.SelectedIndex + 1).ToString();

                MODELwaterMeter.waterMeterTypeId = cmbWaterType.SelectedValue.ToString();
                if (chkUseChange.Checked)
                {
                    MODELwaterMeter.ISUSECHANGE = "1";
                    MODELwaterMeter.CHANGEMONTH = txtChangeMonth.Text;
                    MODELwaterMeter.waterMeterTypeIdChange =cmbWaterMeterTypeChange.SelectedValue.ToString();
                }
                else
                    MODELwaterMeter.ISUSECHANGE = "0";

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
                MODELwaterMeter.waterUserId = txtWaterUserID.Text;
                MODELwaterMeter.isSummaryMeter = (cmbIsSummary.SelectedIndex + 1).ToString();//分表为1  总表为2

                if (cmbMeterParentName.SelectedValue != null && cmbMeterParentName.SelectedValue != DBNull.Value)
                    MODELwaterMeter.waterMeterParentId = cmbMeterParentName.SelectedValue.ToString();
                else
                    MODELwaterMeter.waterMeterParentId = null;

                if (chkIsReverse.Checked)
                    MODELwaterMeter.IsReverse = "1";
                else
                    MODELwaterMeter.IsReverse = "0";

                MODELwaterMeter.MEMO = txtWaterMeterMemo.Text;
                if (isAddWaterMeter)
                {
                    MODELwaterMeter.waterMeterId = GETTABLEID.GetTableID(txtWaterUserNO.Text, "WATERMETER");
                    MODELwaterMeter.waterMeterNo = MODELwaterMeter.waterMeterId;
                    MODELwaterMeter.STARTUSEDATETIME = mes.GetDatetimeNow();
                    if (!BLLwaterMeter.Insert(MODELwaterMeter))
                    {
                        mes.Show("保存失败,请确认是否符合验证规则!");
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
                else
                {
                    MODELwaterMeter.waterMeterId = txtWaterMeterID.Text;
                    MODELwaterMeter.waterMeterNo = txtWaterMeterNO.Text;
                    if (!BLLwaterMeter.Update(MODELwaterMeter))
                    {
                        mes.Show("保存失败,请确认是否符合验证规则!");
                        return;
                    }
                    else
                    {
                        #region 变更日志
                        string strModifyLog = "";
                        if (MODELwaterMeterOld.waterMeterId == MODELwaterMeter.waterMeterId)
                        {
                            if (MODELwaterMeterOld.waterMeterStartNumber != MODELwaterMeter.waterMeterStartNumber)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更初始读数:" + MODELwaterMeterOld.waterMeterStartNumber + "→" + MODELwaterMeter.waterMeterStartNumber;
                                else
                                    strModifyLog = "变更初始读数:" + MODELwaterMeterOld.waterMeterStartNumber + "→" + MODELwaterMeter.waterMeterStartNumber;
                            }
                            if (MODELwaterMeterOld.waterMeterPositionName != MODELwaterMeter.waterMeterPositionName)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更水表位置:" + MODELwaterMeterOld.waterMeterPositionName + "→" + MODELwaterMeter.waterMeterPositionName;
                                else
                                    strModifyLog = "变更水表位置:" + MODELwaterMeterOld.waterMeterPositionName + "→" + MODELwaterMeter.waterMeterPositionName;
                            }
                            if (MODELwaterMeterOld.waterMeterState != MODELwaterMeter.waterMeterState)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更水表状态:" + MODELwaterMeterOld.waterMeterState + "→" + MODELwaterMeter.waterMeterState;
                                else
                                    strModifyLog = "变更水表状态:" + MODELwaterMeterOld.waterMeterState + "→" + MODELwaterMeter.waterMeterState;
                            }
                            if (MODELwaterMeterOld.waterMeterSizeId != MODELwaterMeter.waterMeterSizeId)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更水表口径:" + MODELwaterMeterOld.waterMeterSizeId + "→" + MODELwaterMeter.waterMeterSizeId;
                                else
                                    strModifyLog = "变更水表口径:" + MODELwaterMeterOld.waterMeterSizeId + "→" + MODELwaterMeter.waterMeterSizeId;
                            }
                            if (MODELwaterMeterOld.waterMeterTypeId != MODELwaterMeter.waterMeterTypeId)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更用水性质:" + MODELwaterMeterOld.waterMeterTypeId + "→" + MODELwaterMeter.waterMeterTypeId;
                                else
                                    strModifyLog = "变更用水性质:" + MODELwaterMeterOld.waterMeterTypeId + "→" + MODELwaterMeter.waterMeterTypeId;
                            }
                            if (MODELwaterMeterOld.WATERFIXVALUE != MODELwaterMeter.WATERFIXVALUE)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更定量用水:" + MODELwaterMeterOld.WATERFIXVALUE + "→" + MODELwaterMeter.WATERFIXVALUE;
                                else
                                    strModifyLog = "变更定量用水:" + MODELwaterMeterOld.WATERFIXVALUE + "→" + MODELwaterMeter.WATERFIXVALUE;
                            }
                            if (MODELwaterMeterOld.waterMeterProduct != MODELwaterMeter.waterMeterProduct)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更生产厂家:" + MODELwaterMeterOld.waterMeterProduct + "→" + MODELwaterMeter.waterMeterProduct;
                                else
                                    strModifyLog = "变更生产厂家:" + MODELwaterMeterOld.waterMeterProduct + "→" + MODELwaterMeter.waterMeterProduct;
                            }
                            if (MODELwaterMeterOld.waterMeterSerialNumber != MODELwaterMeter.waterMeterSerialNumber)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更出厂编号:" + MODELwaterMeterOld.waterMeterSerialNumber + "→" + MODELwaterMeter.waterMeterSerialNumber;
                                else
                                    strModifyLog = "变更出厂编号:" + MODELwaterMeterOld.waterMeterSerialNumber + "→" + MODELwaterMeter.waterMeterSerialNumber;
                            }
                            if (MODELwaterMeterOld.waterMeterMode != MODELwaterMeter.waterMeterMode)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更规格型号:" + MODELwaterMeterOld.waterMeterMode + "→" + MODELwaterMeter.waterMeterMode;
                                else
                                    strModifyLog = "变更规格型号:" + MODELwaterMeterOld.waterMeterMode + "→" + MODELwaterMeter.waterMeterMode;
                            }
                            if (MODELwaterMeterOld.waterMeterMagnification != MODELwaterMeter.waterMeterMagnification)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更倍率:" + MODELwaterMeterOld.waterMeterMagnification + "→" + MODELwaterMeter.waterMeterMagnification;
                                else
                                    strModifyLog = "变更倍率:" + MODELwaterMeterOld.waterMeterMagnification + "→" + MODELwaterMeter.waterMeterMagnification;
                            }
                            if (MODELwaterMeterOld.waterMeterMaxRange != MODELwaterMeter.waterMeterMaxRange)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更最大量程:" + MODELwaterMeterOld.waterMeterMaxRange + "→" + MODELwaterMeter.waterMeterMaxRange;
                                else
                                    strModifyLog = "变更最大量程:" + MODELwaterMeterOld.waterMeterMaxRange + "→" + MODELwaterMeter.waterMeterMaxRange;
                            }
                            if (MODELwaterMeterOld.waterMeterProofreadingDate != MODELwaterMeter.waterMeterProofreadingDate)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更鉴定日期:" + MODELwaterMeterOld.waterMeterProofreadingDate + "→" + MODELwaterMeter.waterMeterProofreadingDate;
                                else
                                    strModifyLog = "变更鉴定日期:" + MODELwaterMeterOld.waterMeterProofreadingDate + "→" + MODELwaterMeter.waterMeterProofreadingDate;
                            }
                            if (MODELwaterMeterOld.waterMeteProofreadingPeriod != MODELwaterMeter.waterMeteProofreadingPeriod)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更鉴定周期:" + MODELwaterMeterOld.waterMeteProofreadingPeriod + "→" + MODELwaterMeter.waterMeteProofreadingPeriod;
                                else
                                    strModifyLog = "变更鉴定周期:" + MODELwaterMeterOld.waterMeteProofreadingPeriod + "→" + MODELwaterMeter.waterMeteProofreadingPeriod;
                            }
                            if (MODELwaterMeterOld.isSummaryMeter != MODELwaterMeter.isSummaryMeter)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更总表标志:" + MODELwaterMeterOld.isSummaryMeter + "→" + MODELwaterMeter.isSummaryMeter;
                                else
                                    strModifyLog = "变更总表标志:" + MODELwaterMeterOld.isSummaryMeter + "→" + MODELwaterMeter.isSummaryMeter;
                            }
                            if (MODELwaterMeterOld.waterMeterParentId != MODELwaterMeter.waterMeterParentId)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更所属总表:" + MODELwaterMeterOld.waterMeterParentId + "→" + MODELwaterMeter.waterMeterParentId;
                                else
                                    strModifyLog = "变更所属总表:" + MODELwaterMeterOld.waterMeterParentId + "→" + MODELwaterMeter.waterMeterParentId;
                            }
                            if (MODELwaterMeterOld.MEMO != MODELwaterMeter.MEMO)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更备注:" + MODELwaterMeterOld.MEMO + "→" + MODELwaterMeter.MEMO;
                                else
                                    strModifyLog = "变更备注:" + MODELwaterMeterOld.MEMO + "→" + MODELwaterMeter.MEMO;
                            }
                            if (MODELwaterMeterOld.MEMO != MODELwaterMeter.MEMO)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更备注:" + MODELwaterMeterOld.MEMO + "→" + MODELwaterMeter.MEMO;
                                else
                                    strModifyLog = "变更备注:" + MODELwaterMeterOld.MEMO + "→" + MODELwaterMeter.MEMO;
                            }
                            if (MODELwaterMeterOld.ISUSECHANGE != MODELwaterMeter.ISUSECHANGE)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更启用月份变更水价状态:" + MODELwaterMeterOld.ISUSECHANGE + "→" + MODELwaterMeter.ISUSECHANGE;
                                else
                                    strModifyLog = "变更启用月份变更水价状态:" + MODELwaterMeterOld.ISUSECHANGE + "→" + MODELwaterMeter.ISUSECHANGE;
                            }
                            if (MODELwaterMeterOld.CHANGEMONTH != MODELwaterMeter.CHANGEMONTH)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更自动变更水价月份:" + MODELwaterMeterOld.CHANGEMONTH + "→" + MODELwaterMeter.CHANGEMONTH;
                                else
                                    strModifyLog = "变更自动变更水价月份:" + MODELwaterMeterOld.CHANGEMONTH + "→" + MODELwaterMeter.CHANGEMONTH;
                            }
                            if (MODELwaterMeterOld.waterMeterTypeIdChange != MODELwaterMeter.waterMeterTypeIdChange)
                            {
                                if (strModifyLog != "")
                                    strModifyLog += "," + "变更自动变更水价:" + MODELwaterMeterOld.waterMeterTypeIdChange + "→" + MODELwaterMeter.waterMeterTypeIdChange;
                                else
                                    strModifyLog = "变更自动变更水价:" + MODELwaterMeterOld.waterMeterTypeIdChange + "→" + MODELwaterMeter.waterMeterTypeIdChange;
                            }
                            if (strModifyLog != "")
                            {
                                strModifyLog = "水表编号:" + MODELwaterMeter.waterMeterId + "," + strModifyLog;
                                MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                                //MODELOPERATORLOG.METERREADINGID = cmbWaterUserMeterReadingNO.SelectedValue.ToString();
                                MODELOPERATORLOG.LOGCONTENT = strModifyLog;
                                MODELOPERATORLOG.LOGTYPE = "2";  //1代表用户 2代表水表
                                MODELOPERATORLOG.OPERATORID = strLogID;
                                MODELOPERATORLOG.OPERATORNAME = strLogName;
                                BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                            }
                        }
                        #endregion
                    }
                }

                toolAddWaterMeter.Text = "添加";
                toolModifyWaterMeter.Text = "修改";
                toolAddWaterMeter.Enabled = true;
                toolModifyWaterMeter.Enabled = true;
                toolDeleteWaterMeter.Enabled = true;
                toolSaveWaterMeter.Enabled = false;
                gbWaterUser.Enabled = true;
                gpUserList.Enabled = true;
                dgWaterMeter.Enabled = true;
                isAddWaterMeter = false;

                DisEnableControls(gbWaterMeter, "用户水表");

                dgWaterUser_SelectionChanged(null, null);
                for (int i = 0; i < dgWaterMeter.Rows.Count; i++)
                {
                    object objWaterUserID = dgWaterMeter.Rows[i].Cells["waterMeterId"].Value;
                    if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                    {
                        if (objWaterUserID.ToString() == MODELwaterMeter.waterMeterId)
                        {
                            dgWaterMeter.ClearSelection();
                            dgWaterMeter.CurrentCell = dgWaterMeter.Rows[i].Cells["waterMeterNo"];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.Message, MsgType.Error);
            }
        }

        private void dgWaterMeter_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                toolDeleteWaterMeter.Enabled = false;
                toolModifyWaterMeter.Enabled = true;
                return;
            }
            MODELwaterMeterOld = new MODELwaterMeter();

            txtWaterMeterID.Clear();
            ClearWaterUser(gbWaterMeter);
            toolDeleteWaterMeter.Enabled = true;
            toolModifyWaterMeter.Enabled = true;

            object obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterID.Text = obj.ToString();
                MODELwaterMeterOld.waterMeterId = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterNo"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterNO.Text = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterStartNumber"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterStartNum.Text = obj.ToString();
                MODELwaterMeterOld.waterMeterStartNumber = Convert.ToInt32(obj);
            }
            //obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterPositionId"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    cmbWaterMeterPosition.SelectedValue = obj;
            //    obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterPositionName"].Value;
            //    if (obj != null && obj != DBNull.Value)
            //    {
            //        txtWaterMeterPosition.Text = obj.ToString();
            //        MODELwaterMeterOld.waterMeterPositionName = obj.ToString();
            //    }
            //}
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterPositionName"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterPosition.Text = obj.ToString();
                cmbWaterMeterPosition.Text = obj.ToString();
                MODELwaterMeterOld.waterMeterPositionName = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterSizeId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbWaterMeterSize.SelectedValue = obj;
                MODELwaterMeterOld.waterMeterSizeId = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterSizeValue"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterSize.Text = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterStateS"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterState.Text = obj.ToString();
                cmbWaterMeterState.Text = obj.ToString();
                if (obj.ToString() == "正常")
                    MODELwaterMeterOld.waterMeterState ="1";
                else if (obj.ToString() == "注销")
                    MODELwaterMeterOld.waterMeterState = "2";
                else if (obj.ToString() == "换表")
                    MODELwaterMeterOld.waterMeterState = "3";
                else if (obj.ToString() == "未启用")
                    MODELwaterMeterOld.waterMeterState = "4";
                else if (obj.ToString() == "欠费停水")
                    MODELwaterMeterOld.waterMeterState = "5";
                else if (obj.ToString() == "违章停水")
                    MODELwaterMeterOld.waterMeterState = "6";
                else if (obj.ToString() == "坏表")
                    MODELwaterMeterOld.waterMeterState = "7";
                else if (obj.ToString() == "待审核")
                    MODELwaterMeterOld.waterMeterState = "8";
                else if (obj.ToString() == "待拆迁")
                    MODELwaterMeterOld.waterMeterState = "9";
            }

//            正常
//注销
//换表
//未启用
//欠费停水
//违章停水
//坏表
//待审核
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["IsReverse"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                if (obj.ToString() == "1")
                    chkIsReverse.Checked = true;
                else
                    chkIsReverse.Checked = false;
            }
            else
                chkIsReverse.Checked = false;
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterTypeId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbWaterType.SelectedValue = obj;

                MODELwaterMeterOld.waterMeterTypeId = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterTypeValue"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterType.Text = obj.ToString();
            }

            #region 显示设定的自动变更用水性质
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["ISUSECHANGE"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                    MODELwaterMeterOld.ISUSECHANGE = obj.ToString();
                if (obj.ToString() == "0")
                {
                    txtChangeMonth.Clear();
                    txtWaterMeterTypeChange.Clear();
                    chkUseChange.Checked = false;
                }
                else
                {
                    chkUseChange.Checked = true;
                    obj = dgWaterMeter.Rows[e.RowIndex].Cells["CHANGEMONTH"].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        txtChangeMonth.Text = obj.ToString();
                        MODELwaterMeterOld.CHANGEMONTH = obj.ToString();

                        obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterTypeIdChange"].Value;
                        if (obj != null && obj != DBNull.Value)
                        {
                            cmbWaterMeterTypeChange.SelectedValue = obj.ToString();
                            txtWaterMeterTypeChange.Text = cmbWaterMeterTypeChange.Text;
                            MODELwaterMeterOld.waterMeterTypeIdChange = obj.ToString();
                        }
                    }
                }
            }
            #endregion

            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterProduct"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterProductor.Text = obj.ToString();

                MODELwaterMeterOld.waterMeterProduct = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterSerialNumber"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterSerialNum.Text = obj.ToString();

                MODELwaterMeterOld.waterMeterSerialNumber = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterMode"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterModel.Text = obj.ToString();

                MODELwaterMeterOld.waterMeterMode = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["WATERMETERLOCKNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtLockNO.Text = obj.ToString();

                MODELwaterMeterOld.WATERMETERLOCKNO = obj.ToString();
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterMagnification"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterMagnification.Text = obj.ToString();

                MODELwaterMeterOld.waterMeterMagnification =Convert.ToInt32(obj);
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterMaxRange"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterMaxRange.Text = obj.ToString();

                MODELwaterMeterOld.waterMeterMaxRange = Convert.ToInt32(obj);
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterProofreadingDate"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                if (Information.IsDate(obj))
                {
                    txtWaterMeterProofDate.Text = Convert.ToDateTime(obj).ToShortDateString();
                    dtpProofDate.Value = Convert.ToDateTime(obj);

                    MODELwaterMeterOld.waterMeterProofreadingDate = Convert.ToDateTime(obj);
                }
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeteProofreadingPeriod"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtProofreadingPeriod.Text = obj.ToString();

                MODELwaterMeterOld.waterMeteProofreadingPeriod = Convert.ToInt32(obj);
            }
            //obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterNoParent"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtWaterMeterIsSummary.Text = obj.ToString();
            //}
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterParentId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbMeterParentName.SelectedValue = obj.ToString();

                obj = dgWaterMeter.Rows[e.RowIndex].Cells["waterMeterParentName"].Value;
                if (obj != null && obj != DBNull.Value)
                    txtWaterMeterIsSummary.Text = obj.ToString();

                MODELwaterMeterOld.waterMeterParentId = obj.ToString();
            }
            else
            {
                cmbMeterParentName.SelectedValue = DBNull.Value;
            }

            obj = dgWaterMeter.Rows[e.RowIndex].Cells["WATERFIXVALUE"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterFixedValue.Text = obj.ToString();

                MODELwaterMeterOld.WATERFIXVALUE = Convert.ToInt32(obj);
            }
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["isSummaryMeterS"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtIsSummary.Text = obj.ToString();
                cmbIsSummary.Text = obj.ToString();

                if (obj.ToString()=="分表")
                MODELwaterMeterOld.isSummaryMeter ="1";
                else
                    MODELwaterMeterOld.isSummaryMeter = "2";
            }
            else
                cmbIsSummary.SelectedValue = DBNull.Value;
            obj = dgWaterMeter.Rows[e.RowIndex].Cells["memoWaterMeter"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtWaterMeterMemo.Text = obj.ToString();

                MODELwaterMeterOld.MEMO = obj.ToString();
            }
        }

        /// <summary>
        /// 存储Excel导入时发现的问题。
        /// </summary>
        string strErrorMes = "";

        /// <summary>
        /// 存储打开的EXCEL文件，包含路径
        /// </summary>
        string strFileNamePath = "";

        /// <summary>
        /// 存储导入的类型，根据此类型后台判断是导入哪种表：1 用户表，2水表表
        /// </summary>
        string strExcelType = "";

        /// <summary>
        /// EXCEL版本
        /// </summary>
        string strExcelVision = "Excel 5.0";

        /// <summary>
        /// 判断导入时是否出错
        /// </summary>
        bool isError = false;

        private void toolImportExcel_Click(object sender, EventArgs e)
        {
            strErrorMes = "";
            strFileNamePath = "";
            strExcelType = "1";
            isError = false;

            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xls)|*.xls";
            OpenFileDialog.RestoreDirectory = true;
            OpenFileDialog.FilterIndex = 0;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFileDialog.FilterIndex == 1)
                    strExcelVision = "Excel 5.0";
                else
                    strExcelVision = "Excel 12.0";
                
                strFileNamePath = OpenFileDialog.FileName;
                bgWorkImportWaterUser.RunWorkerAsync();
            }
        }

        private void bgWorkImportWaterUser_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime dtImportNow = mes.GetDatetimeNow();

                string strConnectExcel = "";
                strErrorMes = "文件:" + strFileNamePath;

                toolImportUserTip.Text = "正在打开Excel...";
                strConnectExcel = "SELECT * FROM OpenDataSource" +
                    "('Microsoft.Jet.OLEDB.4.0','" +
                    "Data Source=\"" + strFileNamePath + "\";" +
                    "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用水用户档案表$]";

                DataTable dtWaterUser = BLLwaterUser.QuerySQL(strConnectExcel);
                toolImportUserTip.Text = "正在校验Excel...";
                if (dtWaterUser.Rows.Count == 0)
                {
                    strErrorMes += Environment.NewLine + "没有导入任何数据，文件为空!";
                    isError = true;
                }
                else
                {
                    //验证是否存在用户号为空的行
                    toolImportUserTip.Text = "正在验证用户号...";
                    DataRow[] drs = dtWaterUser.Select("用户号 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在用户号为空的行。";
                        isError = true;
                    }

                    //验证是否存在用户号不足6位的行
                    drs = dtWaterUser.Select("LEN(用户号)<>6");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在不足6位的用户号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["用户号"];
                            else
                                strErrorMes += "," + drs[i]["用户号"];
                        }
                        isError = true;
                    }

                    //验证是否存在抄表本为空的行
                    toolImportUserTip.Text = "正在验证区号...";
                    drs = dtWaterUser.Select("区号 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在区号为空的用户号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["用户号"];
                            else
                                strErrorMes += "," + drs[i]["用户号"];
                        }
                        isError = true;
                    }

                    //验证是否存在抄表本为空的行
                    toolImportUserTip.Text = "正在验证片号...";
                    drs = dtWaterUser.Select("区号 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在片号为空的用户号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["用户号"];
                            else
                                strErrorMes += "," + drs[i]["用户号"];
                        }
                        isError = true;
                    }

                    //验证是否存在抄表本为空的行
                    toolImportUserTip.Text = "正在验证段号...";
                    drs = dtWaterUser.Select("区号 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在段号为空的用户号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["用户号"];
                            else
                                strErrorMes += "," + drs[i]["用户号"];
                        }
                        isError = true;
                    }

                    //SQL验证是否存在 顺序号为空的行
                    toolImportUserTip.Text = "正在验证顺序号是否为空...";
                    drs = dtWaterUser.Select("顺序号 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在顺序号为空的用户号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["用户号"];
                            else
                                strErrorMes += "," + drs[i]["用户号"];
                        }
                        isError = true;
                    }

                    //SQL验证是否存在 顺序号为空的行
                    toolImportUserTip.Text = "正在验证小区代码是否为空...";
                    drs = dtWaterUser.Select("小区代码 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在小区代码为空的用户号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["用户号"];
                            else
                                strErrorMes += "," + drs[i]["用户号"];
                        }
                        isError = true;
                    }

                    //SQL判断 顺序号是否为数字
                    toolImportUserTip.Text = "正在验证顺序号是否数字...";
                    string strConnectExcelIsNumeric = "SELECT 用户号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用水用户档案表$] WHERE ISNUMERIC(顺序号)=0";
                    DataTable dtWaterUserOrderNumIsNumeric = BLLwaterUser.QuerySQL(strConnectExcelIsNumeric);
                    if (dtWaterUserOrderNumIsNumeric.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在顺序号不为数字的用户号:";
                        for (int i = 0; i < dtWaterUserOrderNumIsNumeric.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterUserOrderNumIsNumeric.Rows[i]["用户号"];
                            else
                                strErrorMes += "," + dtWaterUserOrderNumIsNumeric.Rows[i]["用户号"];
                        }
                        isError = true;
                    }

                    //SQL判断 顺序号是否为整型
                    toolImportUserTip.Text = "正在验证顺序号是否整型...";
                    string strConnectExcelIsInt = "SELECT 用户号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用水用户档案表$] WHERE ISNUMERIC(顺序号)=1 AND  CEILING(顺序号)<>顺序号";
                    DataTable dtWaterUserOrderNumIsInt = BLLwaterUser.QuerySQL(strConnectExcelIsInt);
                    if (dtWaterUserOrderNumIsInt.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在顺序号不为整数的用户号:";
                        for (int i = 0; i < dtWaterUserOrderNumIsInt.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterUserOrderNumIsInt.Rows[i]["用户号"];
                            else
                                strErrorMes += "," + dtWaterUserOrderNumIsInt.Rows[i]["用户号"];
                        }
                        isError = true;
                    }

                    //判断用户号是否重复
                    toolImportUserTip.Text = "正在验证用户号是否重复...";
                    string strConnectExcelGroupBy = "SELECT 用户号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用水用户档案表$] GROUP BY 用户号 HAVING COUNT(用户号)>1";

                    DataTable dtWaterUserGroupBy = BLLwaterUser.QuerySQL(strConnectExcelGroupBy);
                    if (dtWaterUserGroupBy.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在重复的用户号:";
                        for (int i = 0; i < dtWaterUserGroupBy.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterUserGroupBy.Rows[i]["用户号"];
                            else
                                strErrorMes += "," + dtWaterUserGroupBy.Rows[i]["用户号"];
                        }
                        isError = true;
                    }

                    //验证是否存在已使用过的用户号
                    toolImportUserTip.Text = "正在验证用户号是否使用...";
                    string strConnectExcelExist = "SELECT 用户号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用水用户档案表$] " +
                          " WHERE 用户号 IN (SELECT waterUserId FROM waterUser)";

                    DataTable dtWaterUserIDExist = BLLwaterUser.QuerySQL(strConnectExcelExist);
                    if (dtWaterUserIDExist.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在已使用过的用户号:";
                        for (int i = 0; i < dtWaterUserIDExist.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterUserIDExist.Rows[i]["用户号"];
                            else
                                strErrorMes += "," + dtWaterUserIDExist.Rows[i]["用户号"];
                        }
                        isError = true;
                    }
                }
                if (isError)
                {
                    toolImportUserTip.Text = "";
                    frmImportExcelErrorMes frm = new frmImportExcelErrorMes();
                    frm.strError = strErrorMes;
                    frm.strExcelType = "1";
                    frm.ShowDialog();
                }
                else
                {
                    string strImportExcel = "INSERT INTO dbo.waterUser(waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress," +
                                    "meterReadingID,meterReadingPageNo,waterUserTypeId,waterUserState,ordernumber,waterUserCreateDate)" +
                                    "select 用户号,用户号,用户名,联系方式,地址,抄表本号代码,页号,用户类别代码,用户状态代码 ,顺序号,'" +dtImportNow.ToString()+
                                  "' FROM OpenDataSource('Microsoft.Jet.OLEDB.4.0','" +
                                  "Data Source=\"" + strFileNamePath + "\";" +
                                  "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用水用户档案表$]";
                    int intRows = BLLwaterUser.ExcuteSQL(strImportExcel);
                    toolImportUserTip.Text = "成功导入:" + intRows.ToString() + "条数据!";
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
                toolImportUserTip.Text = "";
            }
        }

        private void toolImportWaterMeterExcel_Click(object sender, EventArgs e)
        {
            strErrorMes = "";
            strFileNamePath = "";
            strExcelType = "2";
            isError = false;

            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx";
            OpenFileDialog.RestoreDirectory = true;
            OpenFileDialog.FilterIndex = 0;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFileDialog.FilterIndex == 1)
                    strExcelVision = "Excel 5.0";
                else
                    strExcelVision = "Excel 12.0";

                strFileNamePath = OpenFileDialog.FileName;
                bgWorkImportWaterMeter.RunWorkerAsync();
            }
        }

        private void bgWorkImportWaterMeter_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime dtImportNow = mes.GetDatetimeNow();
                string strConnectExcel = "";
                strErrorMes = "文件:" + strFileNamePath;

                toolImportWaterMeterExcelTip.Text = "正在打开Excel...";
                strConnectExcel = "SELECT * FROM OpenDataSource" +
                    "('Microsoft.Jet.OLEDB.4.0','" +
                    "Data Source=\"" + strFileNamePath + "\";" +
                    "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用户水表档案表$]";

                DataTable dtWaterMeter = BLLwaterUser.QuerySQL(strConnectExcel);
                toolImportWaterMeterExcelTip.Text = "正在校验Excel...";
                if (dtWaterMeter.Rows.Count == 0)
                {
                    strErrorMes += Environment.NewLine + "没有导入任何数据，文件为空!";
                    isError = true;
                }
                else
                {
                    //验证是否存在水表号为空的行
                    toolImportWaterMeterExcelTip.Text = "正在验证水表编号...";
                    DataRow[] drs = dtWaterMeter.Select("水表编号 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在水表编号为空的行。";
                        isError = true;
                    }

                    //验证是否存在水表编号不足10位的行
                    drs = dtWaterMeter.Select("LEN(水表编号)<>10");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在不足10位的水表编号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["水表编号"];
                            else
                                strErrorMes += "," + drs[i]["水表编号"];
                        }
                        isError = true;
                    }


                    //验证是否存在用户号不足8位的行
                    drs = dtWaterMeter.Select("LEN(用户号)<>8");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在用户号不足8位的水表编号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["水表编号"];
                            else
                                strErrorMes += "," + drs[i]["水表编号"];
                        }
                        isError = true;
                    }

                    //验证是否存在水表编号与用户号不匹配行
                    toolImportWaterMeterExcelTip.Text = "正在验证水表与用户匹配性...";
                    string strConnectExcelMeterNo = "SELECT 水表编号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用户水表档案表$] WHERE LEFT(水表编号,8)<>用户号";
                    DataTable dtWaterMeterMeterNo = BLLwaterUser.QuerySQL(strConnectExcelMeterNo);
                    if (dtWaterMeterMeterNo.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在与用户号不匹配的水表编号:";
                        for (int i = 0; i < dtWaterMeterMeterNo.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterMeterMeterNo.Rows[i]["水表编号"];
                            else
                                strErrorMes += "," + dtWaterMeterMeterNo.Rows[i]["水表编号"];
                        }
                        isError = true;
                    }

                    //验证是否存在用水类别代码为空的行
                    toolImportWaterMeterExcelTip.Text = "正在验证用水类别代码...";
                    drs = dtWaterMeter.Select("用水类别代码 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在用水类别代码为空的水表编号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["水表编号"];
                            else
                                strErrorMes += "," + drs[i]["水表编号"];
                        }
                        isError = true;
                    }

                    //SQL验证是否存在 顺序号为空的行
                    toolImportWaterMeterExcelTip.Text = "正在验证初始读数是否为空...";
                    drs = dtWaterMeter.Select("初始读数 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在初始读数为空的水表编号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["水表编号"];
                            else
                                strErrorMes += "," + drs[i]["水表编号"];
                        }
                        isError = true;
                    }

                    //SQL验证是否存在用户状态为空的行
                    toolImportWaterMeterExcelTip.Text = "正在验证水表状态代码...";
                    drs = dtWaterMeter.Select("水表状态代码 IS NULL");
                    if (drs.Length > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在水表状态为空的水表编号:";
                        for (int i = 0; i < drs.Length; i++)
                        {
                            if (i == 0)
                                strErrorMes += drs[i]["水表编号"];
                            else
                                strErrorMes += "," + drs[i]["水表编号"];
                        }
                        isError = true;
                    }

                    //SQL判断 初始读数是否为数字
                    toolImportWaterMeterExcelTip.Text = "正在验证初始读数是否数字...";
                    string strConnectExcelIsNumeric = "SELECT 水表编号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用户水表档案表$] WHERE ISNUMERIC(初始读数)=0";
                    DataTable dtWaterUserOrderNumIsNumeric = BLLwaterUser.QuerySQL(strConnectExcelIsNumeric);
                    if (dtWaterUserOrderNumIsNumeric.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在初始读数不为数字的水表编号:";
                        for (int i = 0; i < dtWaterUserOrderNumIsNumeric.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterUserOrderNumIsNumeric.Rows[i]["水表编号"];
                            else
                                strErrorMes += "," + dtWaterUserOrderNumIsNumeric.Rows[i]["水表编号"];
                        }
                        isError = true;
                    }


                    //SQL判断 顺序号是否为整型
                    toolImportWaterMeterExcelTip.Text = "正在验证初始读数是否整型...";
                    string strConnectExcelIsInt = "SELECT 水表编号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用户水表档案表$] WHERE CEILING(初始读数)<>初始读数 AND ISNUMERIC(初始读数)=0";
                    DataTable dtWaterUserOrderNumIsInt = BLLwaterUser.QuerySQL(strConnectExcelIsInt);
                    if (dtWaterUserOrderNumIsInt.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在初始读数不为整数的水表编号:";
                        for (int i = 0; i < dtWaterUserOrderNumIsInt.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterUserOrderNumIsInt.Rows[i]["水表编号"];
                            else
                                strErrorMes += "," + dtWaterUserOrderNumIsInt.Rows[i]["水表编号"];
                        }
                        isError = true;
                    }

                    //判断水表编号是否重复
                    toolImportWaterMeterExcelTip.Text = "正在验证水表编号是否重复...";
                    string strConnectExcelGroupBy = "SELECT 水表编号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用户水表档案表$] GROUP BY 水表编号 HAVING COUNT(水表编号)>1";

                    DataTable dtWaterUserGroupBy = BLLwaterUser.QuerySQL(strConnectExcelGroupBy);
                    if (dtWaterUserGroupBy.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在重复的水表编号:";
                        for (int i = 0; i < dtWaterUserGroupBy.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterUserGroupBy.Rows[i]["水表编号"];
                            else
                                strErrorMes += "," + dtWaterUserGroupBy.Rows[i]["水表编号"];
                        }
                        isError = true;
                    }

                    //验证是否存在已使用过的水表编号
                    toolImportWaterMeterExcelTip.Text = "正在验证水表编号是否使用...";
                    string strConnectExcelExist = "SELECT 水表编号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用户水表档案表$] " +
                          " WHERE 水表编号 IN (select watermeterid from waterMeter)";

                    DataTable dtWaterUserIDExist = BLLwaterUser.QuerySQL(strConnectExcelExist);
                    if (dtWaterUserIDExist.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在已使用过的水表编号:";
                        for (int i = 0; i < dtWaterUserIDExist.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterUserIDExist.Rows[i]["水表编号"];
                            else
                                strErrorMes += "," + dtWaterUserIDExist.Rows[i]["水表编号"];
                        }
                        isError = true;
                    }

                    //验证是否存在已使用过的水表编号
                    toolImportWaterMeterExcelTip.Text = "正在验证用户号是否存在...";
                    string strConnectExcelExistWaterUserNO = "SELECT 水表编号 FROM OpenDataSource" +
                          "('Microsoft.Jet.OLEDB.4.0','" +
                          "Data Source=\"" + strFileNamePath + "\";" +
                          "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用户水表档案表$] " +
                          " WHERE 用户号 NOT IN (SELECT WATERUSERID FROM waterUser)";

                    DataTable dtWaterMeterExistWaterUserNO = BLLwaterUser.QuerySQL(strConnectExcelExistWaterUserNO);
                    if (dtWaterMeterExistWaterUserNO.Rows.Count > 0)
                    {
                        strErrorMes += Environment.NewLine + "存在用户号未导入的水表编号:";
                        for (int i = 0; i < dtWaterMeterExistWaterUserNO.Rows.Count; i++)
                        {
                            if (i == 0)
                                strErrorMes += dtWaterMeterExistWaterUserNO.Rows[i]["水表编号"];
                            else
                                strErrorMes += "," + dtWaterMeterExistWaterUserNO.Rows[i]["水表编号"];
                        }
                        isError = true;
                    }
                }
                if (isError)
                {
                    toolImportWaterMeterExcelTip.Text = "";
                    frmImportExcelErrorMes frm = new frmImportExcelErrorMes();
                    frm.strError = strErrorMes;
                    frm.strExcelType = "2";
                    frm.ShowDialog();
                }
                else
                {
                    string strImportExcel = "INSERT INTO dbo.waterMeter(waterUserId,waterMeterNo,waterMeterId,waterMeterPositionName,waterMeterSizeId," +
                                    "waterMeterState,waterMeterTypeId,waterMeterStartNumber,isSummaryMeter,waterMeterParentId,STARTUSEDATETIME)" +
                                    "select 用户号,水表编号,水表编号,水表位置,水表口径代码,水表状态代码,用水类别代码,初始读数,总分表,所属总表编号,'"+dtImportNow.ToString()+
                                    "' FROM OpenDataSource('Microsoft.Jet.OLEDB.4.0','" +
                                  "Data Source=\"" + strFileNamePath + "\";" +
                                  "Extended properties=\"" + strExcelVision + ";HDR=Yes;IMEX=1;\"')...[用户水表档案表$]";
                    int intRows = BLLwaterUser.ExcuteSQL(strImportExcel);
                    toolImportWaterMeterExcelTip.Text = "成功导入:" + intRows.ToString() + "条数据!";
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
                toolImportWaterMeterExcelTip.Text = "";
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string strFilter = strSeniorFilterHidden, strFilterWaterMeter = "";

            string strSearch = txtWaterUserNOSearch.Text;
            strFilter += " AND (waterUserNO LIKE '%" + strSearch + "%' OR waterUserName LIKE '%" + strSearch +
                "%' OR waterUserAddress LIKE '%" + strSearch + "%') ";

            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
            if (cmbPianNOS.SelectedIndex > 0)
                strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";
            if (cmbCommunityS.SelectedIndex > 0)
                strFilter += " AND communityID='" + cmbCommunityS.SelectedValue.ToString() + "'";
            if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";
            if (cmbChargerS.SelectedValue != null && cmbChargerS.SelectedValue != DBNull.Value)
                strFilter += " AND chargerID='" + cmbChargerS.SelectedValue.ToString() + "'";

            strFilterWaterMeter = strFilter;

            strFilter += " ORDER BY areaNO,pianNO,duanNO,ordernumber";

            //if (rbPQD.Checked)
            //    strFilter += " ORDER BY areaNO,pianNO,duanNO,ordernumber";
            //if (rbWaterUserName.Checked)
            //    strFilter += " ORDER BY waterUserName";
            //if (rbWaterUserNO.Checked)
            //    strFilter += " ORDER BY waterUserNO";

            RefreshData(strFilter, strFilterWaterMeter);
        }

        Thread TD;
        private void RefreshData(string strFilter, string strFilterWaterMeter)
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
                LoadData(strFilter,strFilterWaterMeter);
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("用户及水表管理界面:" + ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
            }
            finally
            {
                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
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
                log.Write("用水用户明细表界面:" + ex.ToString(), MsgType.Error);
            }
        }
        /// <summary>
        /// 存储查询到的用户列表
        /// </summary>
        DataTable dtWaterUserList = new DataTable();
        private void LoadData(string strFilter, string strFilterWaterMeter)
        {
                dtWaterUserList = BLLwaterUser.QueryUser(strFilter);

                dgWaterUser.DataSource = dtWaterUserList;
                dgWaterUser.Columns["waterUserNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //ucPageSetUp1.InitialUC(this.dgWaterUser, dtWaterUserList, null);

                //获取用户下的所有水表
                DataTable dtWaterMeter = new DataTable();

                if (dgWaterUser.Rows.Count == 0)
                {
                    dgWaterMeter.DataSource = null;
                    //dgWaterUser.DataSource = null;
                    ClearWaterUser(gbWaterUser);
                    ClearWaterUser(gbWaterMeter);
                    gbWaterMeter.Enabled = false;
                    labUserCount.Text = "用户0户,水表0块";

                    txtWaterUserID.Clear();
                    txtWaterMeterID.Clear();
                    return;
                }
                else
                {
                    dtWaterMeter = BLLwaterMeter.Query(" AND WATERUSERID IN ( SELECT WATERUSERID FROM V_WATERUSER_BYCOMMUNITY WHERE 1=1 " + strFilterWaterMeter + ")");
                    gbWaterMeter.Enabled = true;
                }

                //计算水表数量
                labUserCount.Text = "用户" + dtWaterUserList.Rows.Count + "户,水表" + dtWaterMeter.Rows.Count + "块";
        }

        private void btReOrder_Click(object sender, EventArgs e)
        {
            if (dtWaterUserList.Rows.Count == 0)
            {
                mes.Show("未找到用户列表!");
                return;
            }
            try
            {
                //检测抄表本是否是一个，如果不是一个无法排序
                DataView dvWaterUserList = dtWaterUserList.DefaultView;
                DataTable dtDistinctMeterReadingID = dvWaterUserList.ToTable(true, "areaNO", "pianNO", "duanNO");
                if (dtDistinctMeterReadingID.Rows.Count > 1)
                {
                    mes.Show("检测到列表内含有多个段号，请选择一个片区段后执行排序操作!");
                    return;
                }
                string strAreaNO = "", strPianNO = "",strDuanNO="";
                object objAreaNO = dgWaterUser.Rows[0].Cells["areaNO"].Value;
                if (objAreaNO != null && objAreaNO != DBNull.Value)
                {
                    strAreaNO = objAreaNO.ToString();
                }
                object objDuanNO = dgWaterUser.Rows[0].Cells["duanNO"].Value;
                if (objDuanNO != null && objDuanNO != DBNull.Value)
                {
                    strDuanNO = objDuanNO.ToString();
                }
                object objPianNO = dgWaterUser.Rows[0].Cells["pianNO"].Value;
                if (objPianNO != null && objPianNO != DBNull.Value)
                {
                    strPianNO = objPianNO.ToString();
                }

                if (mes.ShowQ("确定要将列表内的用户重新排列抄表顺序吗?") == DialogResult.OK)
                {
                    //int intWaterUserCount=dgWaterUser.Rows.Count;
                    for (int i = 0; i < dgWaterUser.Rows.Count; i++)
                    {
                        object objWaterUserID = dgWaterUser.Rows[i].Cells["waterUserId"].Value;
                        if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        {
                            string strSQL = "UPDATE WATERUSER SET ordernumber=" + (i + 1).ToString() + " WHERE waterUserId='" + objWaterUserID.ToString() + "'";
                            if (BLLwaterUser.UpdateSQL(strSQL))
                            {
                                dgWaterUser.Rows[i].Cells["ordernumber"].Value = i + 1;
                            }
                        }
                    }
                    MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                    MODELOPERATORLOG.LOGCONTENT = "段号:'"+strPianNO+"-"+strAreaNO+"-"+strDuanNO +"'重新排序";
                    //MODELOPERATORLOG.METERREADINGID = strMeterReadingID;
                    MODELOPERATORLOG.LOGTYPE = "1";  //1代表用户 2代表水表
                    MODELOPERATORLOG.OPERATORID = strLogID;
                    MODELOPERATORLOG.OPERATORNAME = strLogName;
                    BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                    mes.Show("重新排序完成!");
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
            }
        }
        PinYinConvert PinYinConvert = new PinYinConvert();
        private void txtWaterUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtWaterUserName.Text.Trim() != ""&&toolSaveUser.Enabled)
                txtCode.Text = GetChineseSpell(txtWaterUserName.Text);
            else
                txtCode.Clear();
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmWaterUserSeniorSearch frm = new frmWaterUserSeniorSearch();
            frm.Owner = this;
            frm.strSign = "1";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
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
                return cnChar;
            }
            else return cnChar;
        }

        private void txtWaterUserNOSearch_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("可输入用户号、用户名、地址信息", txtWaterUserNOSearch,3000);
        }

        private void txtChangeMonth_MouseEnter(object sender, EventArgs e)
        {
            toolTipMonth.Show("请输入6位年月，例如201602", txtChangeMonth,5000);
        }
        ///// <summary>
        ///// 获取一串汉字的拼音声母
        ///// </summary>
        ///// <param name="chinese">Unicode格式的汉字字符串</param>
        ///// <returns>拼音声母字符串</returns>
        ///// <example>
        ///// “旺旺软件工作室”转换为“wwrjgzs”
        ///// </example>
        //public static String ConvertPinyin(String chinese)
        //{
        //    char[] buffer = new char[chinese.Length];
        //    for (int i = 0; i < chinese.Length; i++)
        //    {
        //        buffer[i] = ConvertToPinYin(chinese[i]);
        //    }
        //    return new String(buffer);
        //}

        ///// <summary>
        ///// 获取一个汉字的拼音声母
        ///// </summary>
        ///// <param name="chinese">Unicode格式的一个汉字</param>
        ///// <returns>汉字的声母</returns>
        //public static char ConvertToPinYin(Char chinese)
        //{
        //    Encoding gb2312 = Encoding.GetEncoding("GB2312");
        //    Encoding unicode = Encoding.Unicode;

        //    // Convert the string into a byte[].
        //    byte[] unicodeBytes = unicode.GetBytes(new Char[] { chinese });
        //    // Perform the conversion from one encoding to the other.
        //    byte[] asciiBytes = Encoding.Convert(unicode, gb2312, unicodeBytes);

        //    // 计算该汉字的GB-2312编码
        //    int n = (int)asciiBytes[0] << 8;
        //    if (asciiBytes.Length>1)
        //    n += (int)asciiBytes[1];

        //    // 根据汉字区域码获取拼音声母
        //    if (In(0xB0A1, 0xB0C4, n)) return 'a';
        //    if (In(0XB0C5, 0XB2C0, n)) return 'b';
        //    if (In(0xB2C1, 0xB4ED, n)) return 'c';
        //    if (In(0xB4EE, 0xB6E9, n)) return 'd';
        //    if (In(0xB6EA, 0xB7A1, n)) return 'e';
        //    if (In(0xB7A2, 0xB8c0, n)) return 'f';
        //    if (In(0xB8C1, 0xB9FD, n)) return 'g';
        //    if (In(0xB9FE, 0xBBF6, n)) return 'h';
        //    if (In(0xBBF7, 0xBFA5, n)) return 'j';
        //    if (In(0xBFA6, 0xC0AB, n)) return 'k';
        //    if (In(0xC0AC, 0xC2E7, n)) return 'l';
        //    if (In(0xC2E8, 0xC4C2, n)) return 'm';
        //    if (In(0xC4C3, 0xC5B5, n)) return 'n';
        //    if (In(0xC5B6, 0xC5BD, n)) return 'o';
        //    if (In(0xC5BE, 0xC6D9, n)) return 'p';
        //    if (In(0xC6DA, 0xC8BA, n)) return 'q';
        //    if (In(0xC8BB, 0xC8F5, n)) return 'r';
        //    if (In(0xC8F6, 0xCBF0, n)) return 's';
        //    if (In(0xCBFA, 0xCDD9, n)) return 't';
        //    if (In(0xCDDA, 0xCEF3, n)) return 'w';
        //    if (In(0xCEF4, 0xD188, n)) return 'x';
        //    if (In(0xD1B9, 0xD4D0, n)) return 'y';
        //    if (In(0xD4D1, 0xD7F9, n)) return 'z';
        //    return '\0';
        //}

        //private static bool In(int Lp, int Hp, int Value)
        //{
        //    return ((Value <= Hp) && (Value >= Lp));
        //}
    }
}
