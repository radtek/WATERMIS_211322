using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SysControl
{
    public partial class FrmFileShow : Form
    {
        private string _UnsubscribeID = string.Empty;

        public string UnsubscribeID
        {
            get { return _UnsubscribeID; }
            set { _UnsubscribeID = value; }
        }

        public FrmFileShow()
        {
            InitializeComponent();
        }
    }
}
