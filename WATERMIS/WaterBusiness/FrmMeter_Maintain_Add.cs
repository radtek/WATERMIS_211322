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
    public partial class FrmMeter_Maintain_Add : Form
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();
        private PersonalWork_IDAL personidal = new PersonalWork_DAL();

        private string waterUserId = "";
        private string strLogID;
        private string strName;
        private string strRealName;

        public FrmMeter_Maintain_Add()
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

        private void FrmMeter_Maintain_Add_Load(object sender, EventArgs e)
        {
            BindMaintainType();
        }

        private void BindMaintainType()
        {
            MaintainTypeID.DataSource = personidal.GetMaintainType();
            MaintainTypeID.DisplayMember = "MaintainType";
            MaintainTypeID.ValueMember = "MaintainTypeID";
        }

        private void dgWaterUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgWaterUser.CurrentRow != null)
            {
                this.setWaterUserId(dgWaterUser.CurrentRow.Cells["dgwaterUserId"].Value.ToString());
                initData();
            }
        }
        void initData()
        {
            if (!string.IsNullOrEmpty(waterUserId))
            {
                Hashtable ht = sysidal.GetWaterUserInfos(waterUserId);
                new SqlServerHelper().BindHashTableToForm(ht, this.gbWaterUser.Controls);

                dgWaterMeter.DataSource = sysidal.GetWaterMeterByUserID(waterUserId);
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
                if (string.IsNullOrEmpty(TB_Memo.Text))
                {
                    MessageBox.Show("信息不完整！");
                    return;
                }
                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashTableByControl(this.panel2.Controls);

                ht.Remove("TB_MEMO");
                ht["Memo"] = TB_Memo.Text;
                ht["MaintainID"] = Guid.NewGuid().ToString();
                string SDNO = new SqlServerHelper().GetSDByTable("Meter_Maintain");
                ht["ACCEPTID"] = SDNO;
                ht["LOGINID"] = strLogID;
                ht["SD"] = SDNO;
                ht["QueryKey"] = "123456";
                ht["userName"] = strRealName;
                ht["WaterUserNO"] = waterUserId;
                ht["waterUserName"] = WaterUserName.Text;
                ht["waterUserAddress"] = waterUserAddress.Text;
                ht["waterPhone"] = waterPhone.Text;

                string FlowCode = MaintainTypeID.SelectedValue.Equals("0") ? "Meter_Maintain_1" : MaintainTypeID.SelectedValue.Equals("1") ? "Meter_Maintain_2" : MaintainTypeID.SelectedValue.Equals("2") ? "Meter_Maintain_3" : "Meter_Maintain_1";

                if (new SqlServerHelper().Submit_AddOrEdit("Meter_Maintain", "MaintainID", "", ht))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["MaintainID"].ToString(), SDNO, "Meter_Maintain", "MaintainID", "故障报修", FlowCode);
                    if (result)
                    {
                        MessageBox.Show("任务创建成功！");
                        waterUserId = "";
                        new SqlServerHelper().ClearControls(gbWaterUser.Controls);
                        new SqlServerHelper().ClearControls(panel2.Controls);
                        dgWaterMeter.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("任务创建失败！");
                    }
                }
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            dgWaterUser.DataSource = sysidal.GetWaterUserList(this.groupBox1.Controls);
        }

       

       
    }
}
