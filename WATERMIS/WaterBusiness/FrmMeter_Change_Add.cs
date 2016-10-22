using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace WaterBusiness
{
    public partial class FrmMeter_Change_Add : Form
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        private string waterUserId = "";
        private string strLogID;
        private string strName;
        private string strRealName;

        public FrmMeter_Change_Add()
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

        private void FrmMeter_Change_Add_Load(object sender, EventArgs e)
        {
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(waterUserId))
            {
                if (ChangeDescribe.ValidateState & ApplyUser.ValidateState & waterPhone.ValidateState)
                {
                    Hashtable ht = new Hashtable();
                    ht = new SqlServerHelper().GetHashTableByControl(this.panel1.Controls);

                    ht["ChangeID"] = Guid.NewGuid().ToString();
                    string SDNO = new SqlServerHelper().GetSDByTable("Meter_Change");
                    ht["ACCEPTID"] = SDNO;
                    ht["LOGINID"] = strLogID;
                    ht["SD"] = SDNO;
                    ht["QueryKey"] = "123456";
                    ht["userName"] = strRealName;
                    ht["WaterUserNO"] = waterUserId;
                    ht["waterUserName"] = uC_UserMeterDetails1.uC_UserDetails1.WaterUserName.Text;
                    ht["waterUserAddress"] = uC_UserMeterDetails1.uC_UserDetails1.waterUserAddress.Text;

                    if (new SqlServerHelper().Submit_AddOrEdit("Meter_Change", "ChangeID", "", ht))
                    {
                        bool result = new SqlServerHelper().CreateWorkTask(ht["ChangeID"].ToString(), SDNO, "Meter_Change", "ChangeID", "用户换表", "Meter_Change1");
                        if (result)
                        {
                            MessageBox.Show("任务创建成功！");
                            waterUserId = "";
                            uC_UserMeterDetails1.Clear();
                            new SqlServerHelper().ClearControls(panel1.Controls);
                        }
                        else
                        {
                            MessageBox.Show("任务创建失败！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("信息不完整！");
                    return;
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
            }
        }
    }
}
