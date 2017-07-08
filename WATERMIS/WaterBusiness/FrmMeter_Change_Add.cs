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
using Common.DotNetData;

namespace WaterBusiness
{
    public partial class FrmMeter_Change_Add : Form
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        private PersonalWork_IDAL peridal = new PersonalWork_DAL();

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
                string sqlstr = string.Format("SELECT SD,CreateDate FROM Meter_Change WHERE WaterUserNO='{0}' AND State IN (1,2,3)", waterUserId);
                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                if (DataTableHelper.IsExistRows(dt))
                {
                    if (MessageBox.Show(string.Format("已经存在【{0}】的申请记录，记录编号：{1}，申请时间：{2}。是否要继续？", uC_UserMeterDetails1.uC_UserDetails1.WaterUserName.Text, dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString()), "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        SaveInfo();
                    }
                }
                else
                {
                    SaveInfo();
                }
            }
        }
        private void SaveInfo()
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
                    //V_WATERMETER

                    Hashtable htu = new SqlServerHelper().GetHashtableById("V_WATERMETER", "waterUserId", waterUserId);

                    string FlowCode = peridal.GetWorkCodeByUserType("09", htu["WATERMETERTYPECLASSID"].ToString());

                    FlowCode = string.IsNullOrEmpty(FlowCode) ? "Meter_Change" : FlowCode;

                    bool result = new SqlServerHelper().CreateWorkTask(ht["ChangeID"].ToString(), SDNO, "Meter_Change", "ChangeID", "用户换表", FlowCode);
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
