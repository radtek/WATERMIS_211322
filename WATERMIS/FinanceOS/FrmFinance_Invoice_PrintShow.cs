using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinanceOS
{
    public partial class FrmFinance_Invoice_PrintShow : Form
    {
        public string ChargeID = string.Empty;

        public FrmFinance_Invoice_PrintShow()
        {
            InitializeComponent();
        }

        private void FrmFinance_Invoice_PrintShow_Load(object sender, EventArgs e)
        {
            //收费记录表：Meter_Charge
            //收费项目表：Meter_WorkResolveFee
            //说明：从Meter_WorkResolveFee表中可以查出所有收费项目
        }
    }
}
