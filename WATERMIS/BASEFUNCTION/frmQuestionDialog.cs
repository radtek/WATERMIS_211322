using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BASEFUNCTION
{
    public partial class frmQuestionDialog : Form
    {
        public frmQuestionDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string strTip = "";

        private void frmQuestionDialog_Load(object sender, EventArgs e)
        {
            this.labTip.Text = strTip;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btNO_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
