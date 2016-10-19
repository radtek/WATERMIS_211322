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

namespace SysControl
{
    public partial class UC_UserDetails : UserControl
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        public UC_UserDetails()
        {
            InitializeComponent();
        }

        public void initData(string waterUserId)
        {
            Hashtable ht = sysidal.GetWaterUserInfos(waterUserId);
            new SqlServerHelper().BindHashTableToForm(ht, this.gbWaterUser.Controls);
        }

        public void Clear()
        {
            new SqlServerHelper().ClearControls(gbWaterUser.Controls);
        }
    }
}
