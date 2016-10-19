using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace SysControl
{
    public partial class UC_UserMeterDetails : UserControl
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        public UC_UserMeterDetails()
        {
            InitializeComponent();
        }

        public void initData(string waterUserId)
        {
            uC_UserDetails1.initData(waterUserId);
            dgWaterMeter.DataSource = sysidal.GetWaterMeterByUserID(waterUserId);
        }

        public void Clear()
        {
            uC_UserDetails1.Clear();
            dgWaterMeter.DataSource = null;
        }
    }
}
