using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;

namespace SysControl
{
    public partial class UC_Approve_Infos : UserControl
    {
        public UC_Approve_Infos()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        public void InitData(string TaskID)
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterUserType", "", "waterUserTypeId");
            ControlBindHelper.BindComboBoxData(this.waterUserTypeId, dt, "waterUserTypeName", "waterUserTypeId");

            DataTable dt2 = new SqlServerHelper().GetDataTable("waterUserHouseType", "", "waterUserHouseTypeID");
            ControlBindHelper.BindComboBoxData(this.waterUserHouseType, dt2, "waterUserHouseType", "waterUserHouseTypeID");

            if (!string.IsNullOrEmpty(TaskID))
            {
                Hashtable ht = sysidal.GetMeter_Install_SingleInfos(TaskID);
                new SqlServerHelper().BindHashTableToForm(ht, this.panel2.Controls);
            }
        }

    }
}
