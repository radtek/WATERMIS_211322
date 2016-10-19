using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;

namespace WaterBusiness
{
    public partial class Frm_User_Unsubscribe_Add : Form
    {

        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        private string waterUserId = "";

        private string strLogID;
        private string strName;
        private string strRealName;

        public Frm_User_Unsubscribe_Add()
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

        private void Frm_User_Unsubscribe_Add_Load(object sender, EventArgs e)
        {

            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            BindCertificateID();
        }

        private void BindCertificateID()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("User_CertificateType", "", "CertificateID");
            ControlBindHelper.BindComboBoxData(this.CertificateID, dt, "CertificateType", "CertificateID");
        }

        private void Btn_Submit_Click_1(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(waterUserId))
            {
                if (string.IsNullOrEmpty(Memo.Text))
                {
                    MessageBox.Show("信息不完整！");
                    return;
                }
                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashTableByControl(this.panel2.Controls);

                ht["UnsubscribeID"] = Guid.NewGuid().ToString();
                string SDNO = new SqlServerHelper().GetSDByTable("User_Unsubscribe");
                ht["ACCEPTID"] = SDNO;
                ht["LOGINID"] = strLogID;
                ht["SD"] = SDNO;
                ht["QueryKey"] = "123456";
                ht["userName"] = strRealName;
                ht["WaterUserNO"] = waterUserId;
                ht["waterUserName"] = uC_UserMeterDetails1.uC_UserDetails1.WaterUserName.Text;
                ht["waterUserAddress"] = uC_UserMeterDetails1.uC_UserDetails1.waterUserAddress.Text;

                if (new SqlServerHelper().Submit_AddOrEdit("User_Unsubscribe", "UnsubscribeID", "", ht))
                {
                    bool result =new SqlServerHelper().CreateWorkTask(ht["UnsubscribeID"].ToString(), SDNO, "User_Unsubscribe", "UnsubscribeID", "用户销户");
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

        private void LB_Tips_Click(object sender, EventArgs e)
        {
            this.Memo.Text = "拆迁";
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
