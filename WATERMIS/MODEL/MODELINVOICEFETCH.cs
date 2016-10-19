using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELINVOICEFETCH
    {
        private string _INVOICEFETCHID;
        private string _INVOICEFETCHERID;
        private string _INVOICEFETCHERNAME;
        private string _INVOICEFETCHDEPID;
        private string _INVOICEFETCHDEPNAME;
        private int _INVOICEFETCHBATCHID;
        private string _INVOICEFETCHSTARTNO;
        private string _INVOICEFETCHENDNO;
        private string _ISENABLE;
        private DateTime _INVOICEFETCHDATETIME;
        private string _MEMO;

        public string INVOICEFETCHID
        {
            get
            {
                return _INVOICEFETCHID;
            }
            set
            {
                _INVOICEFETCHID = value;
            }
        }
        public string INVOICEFETCHERID
        {
            get
            {
                return _INVOICEFETCHERID;
            }
            set
            {
                _INVOICEFETCHERID = value;
            }
        }
        public string INVOICEFETCHERNAME
        {
            get
            {
                return _INVOICEFETCHERNAME;
            }
            set
            {
                _INVOICEFETCHERNAME = value;
            }
        }
        public string INVOICEFETCHDEPID
        {
            get
            {
                return _INVOICEFETCHDEPID;
            }
            set
            {
                _INVOICEFETCHDEPID = value;
            }
        }
        public string INVOICEFETCHDEPNAME
        {
            get
            {
                return _INVOICEFETCHDEPNAME;
            }
            set
            {
                _INVOICEFETCHDEPNAME = value;
            }
        }
        public int INVOICEFETCHBATCHID
        {
            get
            {
                return _INVOICEFETCHBATCHID;
            }
            set
            {
                _INVOICEFETCHBATCHID = value;
            }
        }
        public string INVOICEFETCHSTARTNO
        {
            get
            {
                return _INVOICEFETCHSTARTNO;
            }
            set
            {
                _INVOICEFETCHSTARTNO = value;
            }
        }
        public string INVOICEFETCHENDNO
        {
            get
            {
                return _INVOICEFETCHENDNO;
            }
            set
            {
                _INVOICEFETCHENDNO = value;
            }
        }
        public string ISENABLE
        {
            get
            {
                return _ISENABLE;
            }
            set
            {
                _ISENABLE = value;
            }
        }

        public DateTime INVOICEFETCHDATETIME
        {
            get
            {
                return _INVOICEFETCHDATETIME;
            }
            set
            {
                _INVOICEFETCHDATETIME = value;
            }
        }

        public string MEMO
        {
            get
            {
                return _MEMO;
            }
            set
            {
                _MEMO = value;
            }
        }
    }
}
