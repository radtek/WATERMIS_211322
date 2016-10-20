﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;
using System.Collections;

namespace WaterBusiness
{
    public partial class Frm_Meter_Disuse_Add2 : Form
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        private string waterUserId = "";
        public string key;
        private string strLogID;
        private string strName;
        private string strRealName;

        private float _Price = 0f;

        public Frm_Meter_Disuse_Add2()
        {
            InitializeComponent();
        }

        private void setWaterUserId(string value)
        {
            waterUserId = value;
            if (string.IsNullOrEmpty(waterUserId))
            {
                Btn_Submit.Enabled = false;
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

        private void uC_UserMeterDetails1_Load(object sender, EventArgs e)
        {
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            //判断用户水表状态和用户是否已经在走报停流程
            if (sysidal.IsDisabledUser(waterUserId))
            {
                MessageBox.Show("用户状态不可用或存在未完成审批！");
                return;
            }
            
            bool FormCheck =DisuseDescribe.ValidateState& WaterNum.ValidateState;
            if (!FormCheck)
            {
                MessageBox.Show("信息不完整！");
                return;
            }
            if (!string.IsNullOrEmpty(waterUserId))
            {
                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashTableByControl(this.panel2.Controls);

                string _TableName = "Meter_Disuse";
                string _TablePkName = "DisuseID";
                string _FlowCode = "Meter_Disuse2";
                string _TaskName = "水表报停-监察";

                ht[_TablePkName] = Guid.NewGuid().ToString();
                string SDNO = new SqlServerHelper().GetSDByTable(_TableName);
                ht["ACCEPTID"] = SDNO;
                ht["LOGINID"] = strLogID;
                ht["SD"] = SDNO;
                ht["QueryKey"] = "123456";
                ht["userName"] = strRealName;
                ht["DisuserType"] = 1;
                ht["WaterUserNO"] = waterUserId;
                ht["waterUserName"] = uC_UserMeterDetails1.uC_UserDetails1.WaterUserName.Text;
                ht["waterUserAddress"] = uC_UserMeterDetails1.uC_UserDetails1.waterUserAddress.Text;

                if (new SqlServerHelper().Submit_AddOrEdit(_TableName, _TablePkName, "", ht))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht[_TablePkName].ToString(), SDNO, _TableName, _TablePkName, _TaskName, _FlowCode);
                    if (result)
                    {
                        MessageBox.Show("任务创建成功！");
                        waterUserId = "";
                        uC_UserMeterDetails1.Clear();
                        new SqlServerHelper().ClearControls(panel2.Controls);
                    }
                    else
                    {
                        MessageBox.Show("任务创建失败！");
                    }
                }
            }

        }

        private void uC_UserSearch1_BtnSearchEvent(object sender, EventArgs e)
        {
            DataGridView dgWaterUser = (DataGridView)sender;

            if (dgWaterUser.CurrentRow != null)
            {
                this.setWaterUserId(dgWaterUser.CurrentRow.Cells["dgwaterUserId"].Value.ToString());
                uC_UserMeterDetails1.initData(waterUserId);
                //获取用户用水性质

                _Price = sysidal.GetUserWaterPrice(waterUserId);
                WaterPrice.Text = _Price.ToString();
            }
        }

        private void WaterNum_TextChanged(object sender, EventArgs e)
        {
            int _WaterNum = 0;
            if (int.TryParse(WaterNum.Text,out _WaterNum))
            {
                WaterFee.Text = (_WaterNum * _Price).ToString();
            }
        }


    }
}
