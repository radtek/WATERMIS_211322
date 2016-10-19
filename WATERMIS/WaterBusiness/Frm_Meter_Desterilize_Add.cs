using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using System.Collections;

namespace WaterBusiness
{
    public partial class Frm_Meter_Desterilize_Add : Form
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        private string waterUserId = "";
        private string strLogID;
        private string strName;
        private string strRealName;


        public Frm_Meter_Desterilize_Add()
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
                ht["DesterilizeID"] = Guid.NewGuid().ToString();
                string SDNO = new SqlServerHelper().GetSDByTable("Meter_Desterilize");
                ht["ACCEPTID"] = SDNO;
                ht["LOGINID"] = strLogID;
                ht["SD"] = SDNO;
                ht["QueryKey"] = "123456";
                ht["userName"] = strRealName;
                ht["WaterUserNO"] = waterUserId;
                ht["waterUserName"] = WaterUserName.Text;
                ht["waterUserAddress"] = waterUserAddress.Text;
                ht["waterPhone"] = waterPhone.Text;

                if (new SqlServerHelper().Submit_AddOrEdit("Meter_Desterilize", "DesterilizeID", "", ht))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["DesterilizeID"].ToString(), SDNO, "Meter_Desterilize", "DesterilizeID", "用户恢复");
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
