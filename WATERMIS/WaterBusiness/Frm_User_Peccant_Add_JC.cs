using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WaterBusiness
{
    public partial class Frm_User_Peccant_Add_JC : Form
    {
        public string key;
        private string strLogID;
        private string strName;
        private string strRealName;

        public Frm_User_Peccant_Add_JC()
        {
            InitializeComponent();
        }

        private void Frm_User_Peccant_Add_JC_Load(object sender, EventArgs e)
        {
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            userName.Text = strRealName;
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();

            if (string.IsNullOrEmpty(PeccantAdress.Text) || string.IsNullOrEmpty(ApplyPhone.Text))
            {
                MessageBox.Show("信息不完整！");
                return;
            }

            ht = new SqlServerHelper().GetHashTableByControl(this.Controls);

            string newKey = Guid.NewGuid().ToString();
            string SDNO = new SqlServerHelper().GetSDByTable("User_Peccant");
            ht["ACCEPTID"] = SDNO;
            ht["LOGINID"] = strLogID;
            ht["SD"] = SDNO;

            AcceptID.Text = SDNO;

            if (string.IsNullOrEmpty(key))
            {
                ht["PeccantID"] = newKey;
            }
            else
            {
                ht["PeccantID"] = key;
            }

            if (new SqlServerHelper().Submit_AddOrEdit("User_Peccant", "PeccantID", key, ht))
            {
                AcceptID.Text = ht["ACCEPTID"].ToString();
                Btn_Submit.Enabled = false;
                Btn_Submit.BackColor = Color.Gray;
                // MessageBox.Show("信息保存成功！");

                bool result = new SqlServerHelper().CreateWorkTask(ht["PeccantID"].ToString(), SDNO, "User_Peccant_JC", "PeccantID", "用户违章");
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
    }
}
