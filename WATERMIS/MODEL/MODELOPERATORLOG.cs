using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELOPERATORLOG
    {
        private string _LOGID;
        private string _LOGTYPE;
        private string _METERREADINGID;
        private string _METERREADINGIDNO;
        private string _LOGCONTENT;
        private DateTime _LOGDATETIME;
        private string _OPERATORID;
        private string _OPERATORNAME;
        private string _MEMO;

        public string LOGID
        {
            get
            {
                return _LOGID;
            }
            set
            {
                _LOGID = value;
            }
        }
        public string LOGTYPE
        {
            get
            {
                return _LOGTYPE;
            }
            set
            {
                _LOGTYPE = value;
            }
        }
        public string METERREADINGID
        {
            get
            {
                return _METERREADINGID;
            }
            set
            {
                _METERREADINGID = value;
            }
        }
        public string METERREADINGIDNO
        {
            get
            {
                return _METERREADINGIDNO;
            }
            set
            {
                _METERREADINGIDNO = value;
            }
        }
        public string LOGCONTENT
        {
            get
            {
                return _LOGCONTENT;
            }
            set
            {
                _LOGCONTENT = value;
            }
        }
        public DateTime LOGDATETIME
        {
            get
            {
                return _LOGDATETIME;
            }
            set
            {
                _LOGDATETIME = value;
            }
        }
        public string OPERATORID
        {
            get
            {
                return _OPERATORID;
            }
            set
            {
                _OPERATORID = value;
            }
        }
        public string OPERATORNAME
        {
            get
            {
                return _OPERATORNAME;
            }
            set
            {
                _OPERATORNAME = value;
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
