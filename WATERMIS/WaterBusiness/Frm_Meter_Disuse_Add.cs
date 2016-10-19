using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace WaterBusiness
{
    public partial class Frm_Meter_Disuse_Add : Form
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        private string waterUserId = "";
        public string key;
        private string strLogID;
        private string strName;
        private string strRealName;


        public Frm_Meter_Disuse_Add()
        {
            InitializeComponent();
        }

        private void Frm_Meter_Disuse_Add_Load(object sender, EventArgs e)
        {
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
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

        private void Btn_Submit_Click(object sender, EventArgs e)
        {

            Hashtable ht = new Hashtable();

            if (string.IsNullOrEmpty(WaterUserNO.Text) || string.IsNullOrEmpty(DisuseDescribe.Text) || string.IsNullOrEmpty(ApplyPhone.Text))
            {
                MessageBox.Show("信息不完整！");
                return;
            }

            ht = new SqlServerHelper().GetHashTableByControl(this.Controls);

            string newKey = Guid.NewGuid().ToString();
            string SDNO = new SqlServerHelper().GetSDByTable("Meter_Disuse");
            ht["ACCEPTID"] = SDNO;
            ht["LOGINID"] = strLogID;
            ht["SD"] = SDNO;

            if (string.IsNullOrEmpty(key))
            {
                ht["DisuseID"] = newKey;
            }
            else
            {
                ht["DisuseID"] = key;
            }

            if (new SqlServerHelper().Submit_AddOrEdit("Meter_Disuse", "DisuseID", key, ht))
            {

                Btn_Submit.Enabled = false;
                Btn_Submit.BackColor = Color.Gray;

                bool result = new SqlServerHelper().CreateWorkTask(ht["DisuseID"].ToString(), SDNO, "Meter_Disuse", "DisuseID", "用户报停");
                if (result)
                {
                    MessageBox.Show("任务创建成功！");
                }
                else
                {
                    MessageBox.Show("任务创建失败！");
                }

            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            dgWaterUser.DataSource = sysidal.GetWaterUserList(this.groupBox1.Controls);
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


    }
}
