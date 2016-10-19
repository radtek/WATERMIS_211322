using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SysControl
{
    public partial class UC_ChargeInput : UserControl
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

        private string _FeeID = "";

        public string FeeID
        {
            get { return _FeeID; }
            set { _FeeID = value; }
        }

        public string FeeItem
        {
            get { return LB_FeeName.Text; }
            set {  LB_FeeName.Text = value + "："; }
        }
        /// <summary>
        /// RONG 2016-10-10
        /// </summary>
        public string Fee
        {
            get { return TB_Fee.Text; }
            set
            {
                float _Fee = 0f;
                TB_Fee.Text = float.TryParse(value, out _Fee) ? value : "0";
                //TB_Fee.Text = value;
            }
        }


        public UC_ChargeInput()
        {
            InitializeComponent();
        }

        private void TB_Fee_TextChanged(object sender, EventArgs e)
        {
            float _Fee = 0f;
            string _value = TB_Fee.Text;
            TB_Fee.Text = float.TryParse(_value, out _Fee) ? _value : "0";
        }
    }
}
