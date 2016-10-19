using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BASEFUNCTION
{
    public partial class frmWaitSearchCanCancel : Form
    {
        public frmWaitSearchCanCancel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 文字提示信息
        /// </summary>
        public string strTip = "";
        private void frmWaitSearch_Load(object sender, EventArgs e)
        {
            this.labTip.Text = strTip;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmWaitSearchCanCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.Alt) 
            { e.Handled = true; }
        }
    }
}
