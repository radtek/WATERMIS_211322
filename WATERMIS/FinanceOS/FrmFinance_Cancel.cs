using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FinanceOS
{
    public partial class FrmFinance_Cancel : Form
    {
        private string _ChargeID;

        public string ChargeID
        {
            get { return _ChargeID; }
            set { _ChargeID = value; }
        }

        public FrmFinance_Cancel()
        {
            InitializeComponent();
        }

        private void FrmFinance_Cancel_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            Hashtable ht = new Hashtable();
            ht = new SqlServerHelper().GetHashtableById("Meter_Charge", "CHARGEID", _ChargeID);
            new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);


            //string _Loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            //string _ChargerID = dgList.CurrentRow.Cells["CHARGEWORKERID"].Value.ToString();
            //if (_Loginid.Equals(_ChargerID))
            //{

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {

        }
    }
}
