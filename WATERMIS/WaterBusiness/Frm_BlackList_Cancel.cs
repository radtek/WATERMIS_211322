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
    public partial class Frm_BlackList_Cancel : Form
    {
        public string BlackID;
        private string strLogID;
        public Frm_BlackList_Cancel()
        {
            InitializeComponent();
        }

        private void Frm_BlackList_Cancel_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            if (!string.IsNullOrEmpty(BlackID))
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("User_BlackList", "BlackID", BlackID);
                new SqlServerHelper().BindHashTableToForm(ht, this.panel2.Controls);
                if (ht.Contains("LOGINID"))
                {
                   strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                   this.panel1.Visible = strLogID.Equals(ht["LOGINID"].ToString());
                }
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (!CancelMemo.ValidateState)
            {
                CancelMemo.Focus();
                return;
            }
            Hashtable ht = new Hashtable();
            ht["CANCELMEMO"] = CancelMemo.Text;
            ht["CANCELDATE"] = DateTime.Now.ToString();
            ht["STATE"] = 0;

            if (new SqlServerHelper().Submit_AddOrEdit("User_BlackList","BlackID",BlackID,ht))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
