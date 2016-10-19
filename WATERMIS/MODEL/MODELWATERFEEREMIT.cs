using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELWATERFEEREMIT
    {
        private string _WATERFEEREMITID;
        private decimal _REMITWATERFEE;
        private decimal _REMITEXTRAFEE;
        private decimal _REMITOVERDUE;
        private string _READMETERRECORDID;
        private string _REMITWORKERID;
        private string _REMITWORKERNAME;
        private DateTime _REMITDATETIME;

        private string _REMITCANCEL;
        private string _CANCELWORKERID;
        private string _CANCELWORKERNAME;
        private DateTime _CANCELDATETIME;

        private string _MEMO;

        public string WATERFEEREMITID
        {
            get
            {
                return _WATERFEEREMITID;
            }
            set
            {
                _WATERFEEREMITID = value;
            }
        }
        public decimal REMITWATERFEE
        {
            get
            {
                return _REMITWATERFEE;
            }
            set
            {
                _REMITWATERFEE = value;
            }
        }
        public decimal REMITEXTRAFEE
        {
            get
            {
                return _REMITEXTRAFEE;
            }
            set
            {
                _REMITEXTRAFEE = value;
            }
        }
        public decimal REMITOVERDUE
        {
            get
            {
                return _REMITOVERDUE;
            }
            set
            {
                _REMITOVERDUE = value;
            }
        }
        public string READMETERRECORDID
        {
            get
            {
                return _READMETERRECORDID;
            }
            set
            {
                _READMETERRECORDID = value;
            }
        }
        public string REMITWORKERID
        {
            get
            {
                return _REMITWORKERID;
            }
            set
            {
                _REMITWORKERID = value;
            }
        }
        public string REMITWORKERNAME
        {
            get
            {
                return _REMITWORKERNAME;
            }
            set
            {
                _REMITWORKERNAME = value;
            }
        }
        public DateTime REMITDATETIME
        {
            get
            {
                return _REMITDATETIME;
            }
            set
            {
                _REMITDATETIME = value;
            }
        }

        public string REMITCANCEL
        {
            get
            {
                return _REMITCANCEL;
            }
            set
            {
                _REMITCANCEL = value;
            }
        }
        public string CANCELWORKERID
        {
            get
            {
                return _CANCELWORKERID;
            }
            set
            {
                _CANCELWORKERID = value;
            }
        }
        public string CANCELWORKERNAME
        {
            get
            {
                return _CANCELWORKERNAME;
            }
            set
            {
                _CANCELWORKERNAME = value;
            }
        }
        public DateTime CANCELDATETIME
        {
            get
            {
                return _CANCELDATETIME;
            }
            set
            {
                _CANCELDATETIME = value;
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
