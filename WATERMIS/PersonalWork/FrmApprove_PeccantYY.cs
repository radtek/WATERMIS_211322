using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.WinDevices;
using DBUtility;
using System.Data.SqlClient;
using System.Collections;
using Common.DotNetUI;
using Common.DotNetData;
using DBinterface;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace PersonalWork
{
    public partial class FrmApprove_PeccantYY : Form
    {
        public Hashtable ht = new Hashtable();
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        private string TaskID = string.Empty;

        public FrmApprove_PeccantYY()
        {
            InitializeComponent();
        }
       
        private void FrmApprove_Single_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
        }
        private void FrmApprove_Single_Shown(object sender, EventArgs e)
        {
            uC_ApproveList1.InitData(TaskID);
            InitData(TaskID);

            string FrmAssemblyName = string.Empty;
            string FormName = string.Empty;

            if (sysidal.GetAssemblyNameDetail(ht["ResolveID"].ToString(), ref FrmAssemblyName, ref FormName))
            {
                CreateForm.ShowPannel(FormName, FrmAssemblyName, PL_Proc, ht);
            }
        }
        public void InitData(string TaskID)
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterUserType", "", "waterUserTypeId");
            ControlBindHelper.BindComboBoxData(this.waterUserTypeId, dt, "waterUserTypeName", "waterUserTypeId");

            DataTable dt2 = new SqlServerHelper().GetDataTable("waterUserHouseType", "", "waterUserHouseTypeID");
            ControlBindHelper.BindComboBoxData(this.waterUserHouseType, dt2, "waterUserHouseType", "waterUserHouseTypeID");

            if (!string.IsNullOrEmpty(TaskID))
            {
                Hashtable ht = sysidal.GetMeter_Install_PeccantInfos(TaskID);
                new SqlServerHelper().BindHashTableToForm(ht, this.gpMes.Controls);
            }
        }

        private void FrmApprove_Single_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
