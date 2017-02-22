using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using Common.DotNetUI;
using DBinterface.DAL;
using DBinterface.IDAL;
using System.Collections;
using Common.DotNetData;
using Common.WinDevices;
using Microsoft.VisualBasic;

namespace PersonalWork
{
    public partial class FrmApprove_Peccant_User : Form
    {
        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        private string _waterUserId = "";

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;

        private bool skip = false;
        private string ComputerName = "";
        private string ip = "";
        private string DepartementID = "0";

        private string strWaterMeterID = "";

        public FrmApprove_Peccant_User()
        {
            InitializeComponent();
        }

        private void FrmApprove_Peccant_User_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            #region //2017-2-22 RONG
            bool IsAllowEdit = false;
            if (ht.Contains("Edit"))
            {
                if (bool.TryParse(ht["Edit"].ToString(), out IsAllowEdit))
                {

                }
            }
            Btn_Submit.Enabled = IsAllowEdit;
            #endregion
            BindCombox();
        }

        private void BindCombox()
        {
            //DataTable dt = new SqlServerHelper().GetDataTable("V_METERREADING", "", "meterReadingID");
            //ControlBindHelper.BindComboBoxData(this.meterReadingID, dt, "meterReadingNO", "meterReadingID");//抄表本：meterReadingNO；区域：areaName

            DataTable dt = new SqlServerHelper().GetDataTable("BASE_BANK", "", "bankId");
            ControlBindHelper.BindComboBoxData(this.bankId, dt, "bankName", "bankId", true);

            dt = new SqlServerHelper().GetDataTable("User_Agentsign", "", "Agentsign");
            ControlBindHelper.BindComboBoxData(this.agentsign, dt, "Agent", "Agentsign");

            dt = new SqlServerHelper().GetDataTable("User_ChargeType", "", "ChargeType");
            ControlBindHelper.BindComboBoxData(this.chargeType, dt, "Charge", "ChargeType");

            dt = new SqlServerHelper().GetDataTable("BASE_PIAN", "PARENTID<>'0'", "PIANID");
            ControlBindHelper.BindComboBoxData(this.PIANID, dt, "PIANNAME", "PIANID");

            dt = new SqlServerHelper().GetDataTable("BASE_AREA", "areaId<>'0'", "areaName");
            ControlBindHelper.BindComboBoxData(this.areaId, dt, "areaName", "areaId");

            dt = new SqlServerHelper().GetDataTable("BASE_DUAN", "PARENTID<>'0'", "DUANNAME");
            ControlBindHelper.BindComboBoxData(this.DUANID, dt, "DUANNAME", "DUANID");

            dt = new SqlServerHelper().GetDataTable("Base_Archives", "", "CreateTypeID");
            ControlBindHelper.BindComboBoxData(this.CreateType, dt, "CreateType", "CreateTypeID");

            dt = new SqlServerHelper().GetDataTable("BASE_COMMUNITY", "PARENTID<>'0'", "COMMUNITYNAME");
            ControlBindHelper.BindComboBoxData(this.COMMUNITYID, dt, "COMMUNITYNAME", "COMMUNITYID");

            dt = new SqlServerHelper().GetDataTable("base_login", "isMeterReader=1", "userName");
            ControlBindHelper.BindComboBoxData(this.meterReaderID, dt, "userName", "loginId");

            dt = new SqlServerHelper().GetDataTable("base_login", "isCharger=1", "userName");
            ControlBindHelper.BindComboBoxData(this.chargerID, dt, "userName", "loginId");

            dt = new SqlServerHelper().GetDataTable("waterMeterPosition", "", "waterMeterPositionId");
            ControlBindHelper.BindComboBoxData(this.waterMeterPositionName, dt, "waterMeterPositionName", "waterMeterPositionId");

            dt = new SqlServerHelper().GetDataTable("waterMeterSize", "", "waterMeterSizeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterSizeId, dt, "waterMeterSizeValue", "waterMeterSizeId");

            dt = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterTypeId, dt, "waterMeterTypeValue", "waterMeterTypeId");

            dt = new SqlServerHelper().GetDataTable("Meter_waterMeterState", "", "waterMeterStateID");
            ControlBindHelper.BindComboBoxData(this.waterMeterState, dt, "waterMeterState", "waterMeterStateID");

            dt = new SqlServerHelper().GetDataTable("V_WATERUSER_CONNECTWATERMETER", " isSummaryMeter='2'", "waterUserName");
            ControlBindHelper.BindComboBoxData(this.waterMeterParentId, dt, "waterUserName", "waterMeterId", true);

            Hashtable hp = new SqlServerHelper().GetHashtableById("Meter_Install_Peccant", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(hp, this.PL.Controls);
            _waterUserId = hp["WATERUSERID"].ToString();

            if (hp["PIANNO"] != null && hp["PIANNO"] != DBNull.Value)
                PIANID.Text = hp["PIANNO"].ToString();

            if (hp["AREANO"] != null && hp["AREANO"] != DBNull.Value)
                areaId.Text = hp["AREANO"].ToString();

            if (hp["DUANNO"] != null && hp["DUANNO"] != DBNull.Value)
                DUANID.Text = hp["DUANNO"].ToString();

            if (hp["CREATETYPE"] != null && hp["CREATETYPE"] != DBNull.Value)
                CreateType.Text = hp["CREATETYPE"].ToString();

            dt = sysidal.GetUserMaterByTaskID(TaskID);
            if (dt.Rows.Count > 0)
            {
                object objWaterMes = dt.Rows[0]["MeterID"];
                if (objWaterMes != null && objWaterMes != DBNull.Value)
                {
                    strWaterMeterID = objWaterMes.ToString();

                    Hashtable ht = new SqlServerHelper().GetHashtableById("Meter", "MeterID", strWaterMeterID);
                    new SqlServerHelper().BindHashTableToForm(ht, PL.Controls);

                    objWaterMes = ht["WATERMETERPOSITIONMEMO"];
                    if (objWaterMes != null && objWaterMes != DBNull.Value)
                    {
                        waterMeterPositionName.Text = objWaterMes.ToString();
                    }
                }
            }

            Hashtable Hps = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            Btn_Submit.Enabled = string.IsNullOrEmpty(Hps["ISPASS"].ToString()) ? true : bool.Parse(Hps["ISPASS"].ToString()) ? false : true;
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (PIANID.SelectedValue == null || PIANID.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择片号");
                PIANID.Focus();
                return;
            }
            if (areaId.SelectedValue == null || areaId.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择区号");
                areaId.Focus();
                return;
            }
            if (DUANID.SelectedValue == null || DUANID.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择段号");
                DUANID.Focus();
                return;
            }
            if (COMMUNITYID.SelectedValue == null || COMMUNITYID.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择小区名称");
                COMMUNITYID.Focus();
                return;
            }
            if (meterReaderID.SelectedValue == null || meterReaderID.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择抄表员");
                meterReaderID.Focus();
                return;
            }
            if (chargerID.SelectedValue == null || COMMUNITYID.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择收费员");
                chargerID.Focus();
                return;
            }
            if (CreateType.SelectedValue == null || CreateType.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择建档类型");
                CreateType.Focus();
                return;
            }
            if (!Information.IsNumeric(ordernumber.Text))
            {
                mes.Show("请输入正确的顺序号");
                ordernumber.Focus();
                return;
            }
            if (!Information.IsNumeric(waterMeterStartNumber.Text))
            {
                mes.Show("请输入正确的初始读数");
                waterMeterStartNumber.Focus();
                return;
            }
            if (!Information.IsNumeric(WATERFIXVALUE.Text))
            {
                mes.Show("请输入正确的定量用水量");
                WATERFIXVALUE.Focus();
                return;
            }
            if (waterMeterPositionName.SelectedValue == null || waterMeterPositionName.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择水表位置!");
                waterMeterPositionName.Focus();
                return;
            }
            if (waterMeterTypeId.SelectedValue == null || waterMeterTypeId.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择用水性质!");
                waterMeterTypeId.Focus();
                return;
            }
            if (waterMeterState.SelectedValue == null || waterMeterState.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择水表状态!");
                waterMeterState.Focus();
                return;
            }
            if (waterMeterSizeId.SelectedValue == null || waterMeterSizeId.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择水表口径!");
                waterMeterSizeId.Focus();
                return;
            }


            ComputerName = new Computer().ComputerName;
            ip = new Computer().IpAddress;

            Hashtable hs = new Hashtable();
            hs["ModifyUser"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            hs["ModifyDate"] = DateTime.Now.ToString();
            hs["operatorID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString(); ;
            hs["operatorName"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            hs["pianNO"] = PIANID.Text;
            hs["areaNO"] = areaId.Text;
            hs["duanNO"] = DUANID.Text;
            hs["CommunityID"] = COMMUNITYID.SelectedValue;
            hs["COMMUNITYNAME"] = COMMUNITYID.Text;
            hs["BuildingNO"] = BuildingNO.Text;
            hs["UnitNO"] = UnitNO.Text;
            hs["meterReaderID"] = meterReaderID.SelectedValue;
            hs["meterReaderName"] = meterReaderID.Text;
            hs["chargerID"] = chargerID.SelectedValue;
            hs["chargerName"] = chargerID.Text;
            hs["agentsign"] = (agentsign.SelectedValue == null || agentsign.SelectedValue == DBNull.Value) ? 0 : agentsign.SelectedValue;
            hs["bankId"] = bankId.SelectedValue;
            hs["BankAcountNumber"] = BankAcountNumber.Text;
            hs["chargeType"] = (chargeType.SelectedValue == null || chargeType.SelectedValue == DBNull.Value) ? 0 : chargeType.SelectedValue;
            hs["CreateType"] = CreateType.SelectedValue;
            hs["CreateUserDate"] = mes.GetDatetimeNow();
            hs["ordernumber"] = ordernumber.Text;
            hs["Memo"] = Memo.Text;

            if (string.IsNullOrEmpty(_waterUserId))
            {
                _waterUserId = GETTABLEID.GetTableID("", "WATERUSER");
            }
            hs["waterUserId"] = _waterUserId;
            hs["waterUserNO"] = _waterUserId;
            if (new SqlServerHelper().Submit_AddOrEdit("Meter_Install_Peccant", "TaskID", TaskID, hs))
            {
                //取该用户下最大的水表顺序号
                DataTable dd = new SqlServerHelper().GetDateTableBySql(string.Format("SELECT RIGHT(MAX(waterMeterNo),2) FROM waterMeter WHERE waterUserId='{0}'", _waterUserId));
                int MeterCount = string.IsNullOrEmpty(dd.Rows[0][0].ToString()) ? 0 : int.Parse(dd.Rows[0][0].ToString());
                MeterCount++;

                string NewMeterID = _waterUserId + (MeterCount + 1).ToString().PadLeft(2, '0');
                Hashtable hnb = new Hashtable();
                hnb["waterMeterId"] = NewMeterID;
                hnb["waterMeterNo"] = NewMeterID;
                hnb["waterUserId"] = _waterUserId;
                hnb["waterMeterPositionName"] = waterMeterPositionName.Text;
                hnb["waterMeterPositionId"] = waterMeterPositionName.SelectedValue;
                hnb["waterMeterSizeId"] = waterMeterSizeId.SelectedValue;
                hnb["waterMeterStartNumber"] = waterMeterStartNumber.Text;
                hnb["waterMeterTypeId"] = waterMeterTypeId.SelectedValue;
                hnb["waterMeterParentId"] = waterMeterParentId.SelectedValue;
                hnb["waterMeterState"] = waterMeterState.SelectedValue;
                hnb["IsReverse"] = IsReverse.Checked?'1':'0';
                hnb["WATERFIXVALUE"] = WATERFIXVALUE.Text;
                hnb["waterMeterMode"] = waterMeterMode.Text;
                hnb["WATERMETERLOCKNO"] = WATERMETERLOCKNO.Text;

                new SqlServerHelper().Submit_AddOrEdit("Meter", "MeterID", strWaterMeterID, hnb);

                if (sysidal.Approve_Peccant_Append(TaskID))
                {
                    int count = sysidal.UpdateApprove_Peccant_defalut(ResolveID, true, "新增用户（水表）", ip, ComputerName, PointSort, TaskID);

                    if (count > 0)
                    {
                        Btn_Submit.Enabled = false;
                        MessageBox.Show("增户成功！");
                    }
                    else
                    {
                        Btn_Submit.Enabled = true;
                    }
                }
            }
        }

        private void waterMeterStartNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
