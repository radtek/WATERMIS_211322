using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELmeterReading
    {
        private string _meterReadingID;
        private string _meterReadingNO;
        private string _loginId;
        private string _AREAID;
        private string _CHARGERID;
        private DateTime _createDate;
        private string _MEMO;

        public string meterReadingID
        {
            get
            {
                return _meterReadingID;
            }
            set
            {
                _meterReadingID = value;
            }
        }
        public string meterReadingNO
        {
            get
            {
                return _meterReadingNO;
            }
            set
            {
                _meterReadingNO = value;
            }
        }
        public string loginId
        {
            get
            {
                return _loginId;
            }
            set
            {
                _loginId = value;
            }
        }
        /// <summary>
        /// 区域ID
        /// </summary>
        public string AREAID
        {
            get
            {
                return _AREAID;
            }
            set
            {
                _AREAID = value;
            }
        }
        /// <summary>
        /// 收费员ID
        /// </summary>
        public string CHARGERID
        {
            get
            {
                return _CHARGERID;
            }
            set
            {
                _CHARGERID = value;
            }
        }
        public DateTime createDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
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
