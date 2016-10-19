using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELRECEIPTFETCH
    {
        private string _RECEIPTFETCHID;
        private string _RECEIPTFETCHERID;
        private string _RECEIPTFETCHERNAME;
        private string _RECEIPTFETCHDEPID;
        private string _RECEIPTFETCHDEPNAME;
        private string _RECEIPTFETCHSTARTNO;
        private string _RECEIPTFETCHENDNO;
        private DateTime _RECEIPTFETCHDATETIME;
        private string _MEMO;

        public string RECEIPTFETCHID
        {
            get
            {
                return _RECEIPTFETCHID;
            }
            set
            {
                _RECEIPTFETCHID = value;
            }
        }
        public string RECEIPTFETCHERID
        {
            get
            {
                return _RECEIPTFETCHERID;
            }
            set
            {
                _RECEIPTFETCHERID = value;
            }
        }
        public string RECEIPTFETCHERNAME
        {
            get
            {
                return _RECEIPTFETCHERNAME;
            }
            set
            {
                _RECEIPTFETCHERNAME = value;
            }
        }
        public string RECEIPTFETCHDEPID
        {
            get
            {
                return _RECEIPTFETCHDEPID;
            }
            set
            {
                _RECEIPTFETCHDEPID = value;
            }
        }
        public string RECEIPTFETCHDEPNAME
        {
            get
            {
                return _RECEIPTFETCHDEPNAME;
            }
            set
            {
                _RECEIPTFETCHDEPNAME = value;
            }
        }
        public string RECEIPTFETCHSTARTNO
        {
            get
            {
                return _RECEIPTFETCHSTARTNO;
            }
            set
            {
                _RECEIPTFETCHSTARTNO = value;
            }
        }
        public string RECEIPTFETCHENDNO
        {
            get
            {
                return _RECEIPTFETCHENDNO;
            }
            set
            {
                _RECEIPTFETCHENDNO = value;
            }
        }

        public DateTime RECEIPTFETCHDATETIME
        {
            get
            {
                return _RECEIPTFETCHDATETIME;
            }
            set
            {
                _RECEIPTFETCHDATETIME = value;
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
