using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WATERFEEMANAGE
{
    public partial class frmSelectFeeType : Form
    {
        public frmSelectFeeType()
        {
            InitializeComponent();
        }

        private void btPrintWaterFee_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btPrintFJF_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
