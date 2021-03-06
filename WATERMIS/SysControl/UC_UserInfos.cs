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
    public partial class UC_UserInfos : UserControl
    {
        public UC_UserInfos()
        {
            InitializeComponent();
        }

       

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        public void InitData(string waterUserNO)
        {
            if (!string.IsNullOrEmpty(waterUserNO))
            {
                Hashtable ht = sysidal.GetWaterUserInfoByWaterUserNO(waterUserNO);
                new SqlServerHelper().BindHashTableToForm(ht, this.panel2.Controls);

                Hashtable hts = new SqlServerHelper().GetHashtableById("V_WATERMETER", "waterUserId", waterUserNO);
                if (hts.Contains("WATERMETERSIZEVALUE"))
                {
                    TB_WATERMETERSIZEVALUE.Text=hts["WATERMETERSIZEVALUE"].ToString();
                }
            }
        }

    }
}
