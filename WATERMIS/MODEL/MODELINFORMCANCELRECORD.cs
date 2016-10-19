using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELINFORMCANCELRECORD
    {
        private string _INFORMCANCELID;
        private string _INFORMNO;
        private string _READMETERRECORDID;
        private string _OPERATORID;
        private string _OPERATORNAME;
        private DateTime _OPERATORDATETIME;
        private string _CANCELREASON;
        private string _MEMO;

        public string INFORMCANCELID
        {
            get
            {
                return _INFORMCANCELID;
            }
            set
            {
                _INFORMCANCELID = value;
            }
        }
        public string INFORMNO
        {
            get
            {
                return _INFORMNO;
            }
            set
            {
                _INFORMNO = value;
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
        public DateTime OPERATORDATETIME
        {
            get
            {
                return _OPERATORDATETIME;
            }
            set
            {
                _OPERATORDATETIME = value;
            }
        }
        public string CANCELREASON
        {
            get
            {
                return _CANCELREASON;
            }
            set
            {
                _CANCELREASON = value;
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
