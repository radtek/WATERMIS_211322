using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using DBinterface.IDAL;
using System.Collections;
using Common.DotNetUI;
using Common.DotNetData;
using SysControl;

namespace PersonalWork
{
    public partial class FrmApprove_Single_Attr : Form
    {

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

        public FrmApprove_Single_Attr()
        {
            InitializeComponent();
        }
       

        private void FrmApprove_Single_Attr_Load(object sender, EventArgs e)
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
            BindUserInfo();
        }

        private void BindUserInfo()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterUserType", "", "waterUserTypeId");
            ControlBindHelper.BindComboBoxData(this.waterUserTypeId, dt, "waterUserTypeName", "waterUserTypeId");

            DataTable dt2 = new SqlServerHelper().GetDataTable("waterUserHouseType", "", "waterUserHouseTypeID");
            ControlBindHelper.BindComboBoxData(this.waterUserHouseType, dt2, "waterUserHouseType", "waterUserHouseTypeID");

            if (!string.IsNullOrEmpty(TaskID))
            {
                Hashtable ht = sysidal.GetMeter_Install_SingleInfos(TaskID);
                new SqlServerHelper().BindHashTableToForm(ht, this.PL.Controls);
            }

            BindUserMeter();
        }

        private void BindUserMeter()
        {
           // string sqlstr = string.Format("SELECT M.MeterID FROM METER M LEFT JOIN METER_USER MU ON M.MeterID=MU.MeterID WHERE MU.TaskID='{0}' ", TaskID);
           // DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);

            DataTable dt = sysidal.GetUserMaterByTaskID(TaskID);
            if (DataTableHelper.IsExistRows(dt))
            {
                this.FP.Controls.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    UC_MeterInfo UM = new UC_MeterInfo();
                    UM.MeterID = dr[0].ToString();
                    UM.InitData();
                    this.FP.Controls.Add(UM);
                }
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            Hashtable hs = new SqlServerHelper().GetHashTableByControl(this.PL.Controls);

            new SqlServerHelper().Submit_AddOrEdit("Meter_Install_Single", "TaskID", TaskID, hs);
            foreach (Control c in this.FP.Controls)
            {
                if (c is UC_MeterInfo)
                {
                    UC_MeterInfo UM = (UC_MeterInfo)c;

                    Hashtable hu = new SqlServerHelper().GetHashTableByControl(UM.Controls);
                    new SqlServerHelper().Submit_AddOrEdit("Meter", "MeterID", UM.MeterID, hu);
                }
            }

            int count = sysidal.UpdateApprove_Single_defalut(ResolveID, true, "用户信息审核完成", ip, ComputerName, PointSort, TaskID);

            if (count > 0)
            {
                MessageBox.Show("审批成功！");
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

      
    }
}
