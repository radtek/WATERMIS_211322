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
                parms.Style &= ~0x02000000;
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

        private float _Price = 0f;

        public float Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                TB_Price.Text = _Price.ToString();
            }
        }

        private int _Quantity=0;

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; TB_Quantity.Text = _Quantity.ToString(); }
        }

        private float _Fee = 0f;

        public float Fee
        {
            get { return _Fee; }
            set
            {
                _Fee = value;
                TB_Fee.Text = _Fee.ToString();
            }
        }


        public UC_ChargeInput()
        {
            InitializeComponent();
        }

        private void TB_Fee_TextChanged(object sender, EventArgs e)
        {
            string _value = TB_Fee.Text;
            TB_Fee.Text = float.TryParse(_value, out _Fee) ? _value : "0";
        }

        private void TB_Quantity_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TB_Quantity.Text.Trim(),out _Quantity))
            {
                TB_Fee.Text = (_Price * _Quantity).ToString();
            }
        }

        private void TB_Price_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TB_Price.Text.Trim(),out _Price))
            {
                TB_Fee.Text = (_Price * _Quantity).ToString();
            }
        }

        private void TB_Fee_TextChanged_1(object sender, EventArgs e)
        {
            if (float.TryParse(TB_Fee.Text.Trim(), out _Fee))
            {
            }
        }
    }
}
