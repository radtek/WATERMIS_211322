using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELINVOICESTOCKS
    {
        private string _INVOICESTOCKSID;
        private string _INVOICESTARTNO;
        private string _INVOICEENDNO;
        private int _INVOICEBATCHID;
        private string _INVOICEMEMO;

        public string INVOICESTOCKSID
        {
            get
            {
                return _INVOICESTOCKSID;
            }
            set
            {
                _INVOICESTOCKSID = value;
            }
        }
        public string INVOICESTARTNO
        {
            get
            {
                return _INVOICESTARTNO;
            }
            set
            {
                _INVOICESTARTNO = value;
            }
        }
        public string INVOICEENDNO
        {
            get
            {
                return _INVOICEENDNO;
            }
            set
            {
                _INVOICEENDNO = value;
            }
        }
        public int INVOICEBATCHID
        {
            get
            {
                return _INVOICEBATCHID;
            }
            set
            {
                _INVOICEBATCHID = value;
            }
        }
        public string INVOICEMEMO
        {
            get
            {
                return _INVOICEMEMO;
            }
            set
            {
                _INVOICEMEMO = value;
            }
        }
    }
}
