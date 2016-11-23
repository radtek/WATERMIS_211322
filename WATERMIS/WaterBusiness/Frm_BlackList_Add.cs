using System;
using System.Windows.Forms;
using System.Collections;

namespace WaterBusiness
{
    public partial class Frm_BlackList_Add : Form
    {

        private string waterUserId = "";
        private string strLogID;
        private string strName;
        private string strRealName;


        public Frm_BlackList_Add()
        {
            InitializeComponent();
        }

        private void Frm_BlackList_Add_Load(object sender, EventArgs e)
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


            bool FormCheck = MEMO.ValidateState;
            if (!FormCheck)
            {
                MessageBox.Show("信息不完整！");
                return;
            }

            if (!string.IsNullOrEmpty(waterUserId))
            {
                bool IsExist = new SqlServerHelper().IsExist("User_BlackList", "waterUserId", waterUserId, "STATE =1");
                if (IsExist)
                {
                    MessageBox.Show("用户已存在！");
                    return;
                }

                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashTableByControl(this.panel1.Controls);

                string _TableName = "User_BlackList";
               
                ht["WATERUSERID"] = waterUserId;
                ht["WATERUSERNAME"] = uC_UserDetails1.WaterUserName.Text;
                ht["WATERUSERADDRESS"] = uC_UserDetails1.waterUserAddress.Text;
                ht["LOGINID"] = strLogID;
                ht["USERNAME"] = strRealName;

                if (new SqlServerHelper().Submit_AddOrEdit(_TableName, "BlackID", "", ht))
                {
                    MessageBox.Show("保存成功！");
                    waterUserId = "";

                    new SqlServerHelper().ClearControls(panel1.Controls);
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
        }

        private void uC_UserSearch1_BtnSearchEvent(object sender, EventArgs e)
        {
            DataGridView dgWaterUser = (DataGridView)sender;

            if (dgWaterUser.CurrentRow != null)
            {
                this.setWaterUserId(dgWaterUser.CurrentRow.Cells["dgwaterUserId"].Value.ToString());

                uC_UserDetails1.initData(waterUserId);

            }
        }

    }
}
