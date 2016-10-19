using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SysControl
{
    public partial class UC_ChargeItem : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
                return parms;
            }
        }

        //1 - 设计费：2000元
        public string FeeItem
        {
            set { LB_FeeItem.Text = value; }
        }
        public UC_ChargeItem()
        {
            InitializeComponent();
        }
    }
}
