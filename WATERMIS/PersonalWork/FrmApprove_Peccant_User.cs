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

        private List<string> _MeterList = new List<string>();

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

            dt = new SqlServerHelper().GetDataTable("BASE_AREA", "PARENTID<>'0'", "areaId");
            ControlBindHelper.BindComboBoxData(this.areaId, dt, "areaName", "areaId");

            dt = new SqlServerHelper().GetDataTable("BASE_DUAN", "PARENTID<>'0'", "DUANID");
            ControlBindHelper.BindComboBoxData(this.DUANID, dt, "DUANNAME", "DUANID");

            dt = new SqlServerHelper().GetDataTable("Base_Archives", "", "CreateTypeID");
            ControlBindHelper.BindComboBoxData(this.CreateTypeID, dt, "CreateType", "CreateTypeID");

            dt = new SqlServerHelper().GetDataTable("BASE_COMMUNITY", "PARENTID<>'0'", "COMMUNITYID");
            ControlBindHelper.BindComboBoxData(this.COMMUNITYID, dt, "COMMUNITYNAME", "COMMUNITYID");

            dt = new SqlServerHelper().GetDataTable("base_login", "isMeterReader=1", "loginId");
            ControlBindHelper.BindComboBoxData(this.meterReaderID, dt, "userName", "loginId");

            dt = new SqlServerHelper().GetDataTable("base_login", "isCharger=1", "loginId");
            ControlBindHelper.BindComboBoxData(this.chargerID, dt, "userName", "loginId");

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
                CreateTypeID.Text = hp["CREATETYPE"].ToString();

            dt = sysidal.GetUserMaterByTaskID(TaskID);
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _MeterList.Add(dr["MeterID"].ToString());
                }

                LB_MeterInfo.Text = "水表数量：" + dt.Rows.Count;
            }

            Hashtable Hps = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            Btn_Submit.Enabled = string.IsNullOrEmpty(Hps["ISPASS"].ToString()) ? true : bool.Parse(Hps["ISPASS"].ToString()) ? false : true;

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
                if(PIANID.SelectedValue==null||PIANID.SelectedValue==DBNull.Value)
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
                if (CreateTypeID.SelectedValue == null || CreateTypeID.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择建档类型");
                CreateTypeID.Focus();
                return;
            }
                if (!ordernumber.ValidateState)
                {
                    mes.Show("请输入正确的顺序号");
                    ordernumber.Focus();
                    return;
                }

            ComputerName = new Computer().ComputerName;
            ip = new Computer().IpAddress;

            Hashtable hs = new Hashtable();
            hs["ModifyUser"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            hs["ModifyDate"] = DateTime.Now.ToString();
            hs["operatorID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString(); ;
            hs["operatorName"]=AppDomain.CurrentDomain.GetData("USERNAME").ToString();

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
            hs["agentsign"] = (agentsign.SelectedValue ==null||agentsign.SelectedValue==DBNull.Value) ? 0 : agentsign.SelectedValue;
            hs["bankId"] = bankId.SelectedValue;
            hs["BankAcountNumber"] = BankAcountNumber.Text;
            hs["chargeType"] = (chargeType.SelectedValue == null || chargeType.SelectedValue == DBNull.Value) ? 0 : chargeType.SelectedValue;
            hs["CreateType"] = CreateTypeID.Text;
            hs["CreateUserDate"] =mes.GetDatetimeNow();
            hs["ordernumber"] = ordernumber.Text;

            if (string.IsNullOrEmpty(_waterUserId))
            {
                _waterUserId = GETTABLEID.GetTableID("", "WATERUSER");
            }
            hs["waterUserId"] = _waterUserId;
            hs["waterUserNO"] = _waterUserId;
            if (new SqlServerHelper().Submit_AddOrEdit("Meter_Install_Peccant", "TaskID", TaskID, hs))
            {
                DataTable dd = new SqlServerHelper().GetDateTableBySql(string.Format("SELECT RIGHT(MAX(waterMeterNo),2) FROM waterMeter WHERE waterUserId='{0}'", _waterUserId));
                int MeterCount = string.IsNullOrEmpty(dd.Rows[0][0].ToString()) ? 0 : int.Parse(dd.Rows[0][0].ToString());
                MeterCount++;
                if (_MeterList.Count > 0)
                {
                    for (int i = 0; i < _MeterList.Count; i++)
                    {
                        string NewMeterID = _waterUserId + (MeterCount + i).ToString().PadLeft(2, '0');
                        Hashtable hnb = new Hashtable();
                        hnb["waterMeterId"] = NewMeterID;
                        hnb["waterMeterNo"] = NewMeterID;
                        hnb["waterUserId"] = _waterUserId;
                        new SqlServerHelper().Submit_AddOrEdit("Meter", "MeterID", _MeterList[i], hnb);
                    }
                }

                if (sysidal.Approve_Single_Append(TaskID))
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

        private void PL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void memo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
