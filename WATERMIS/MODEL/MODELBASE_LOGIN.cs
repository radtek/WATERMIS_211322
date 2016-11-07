using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELBASE_LOGIN
    {
        private string _LOGID;
        private string _LOGNAME;
        private string _workNO;
        private string _REALNAME;
        private string _LOGPWD;
        private string _POSTID;
        private string _groupID;
        private string _DEPARTMENTID;
        private string _TELEPHONENO;
        private string _isMeterReader;
        private string _isCharger;
        private string _IsCashier;
        private string _userstate;
        private DateTime _generateDateTime;
        private string _MEMO;

        public string LOGINID
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
        public string LOGINNAME
        {
            get
            {
                return _LOGNAME;
            }
            set
            {
                _LOGNAME = value;
            }
        }
        public string workNO
        {
            get
            {
                return _workNO;
            }
            set
            {
                _workNO = value;
            }
        }
        public string USERNAME
        {
            get
            {
                return _REALNAME;
            }
            set
            {
                _REALNAME = value;
            }
        }
        public string Password
        {
            get
            {
                return _LOGPWD;
            }
            set
            {
                _LOGPWD = value;
            }
        }
        public string POSTID
        {
            get
            {
                return _POSTID;
            }
            set
            {
                _POSTID = value;
            }
        }
        public string groupID
        {
            get
            {
                return _groupID;
            }
            set
            {
                _groupID = value;
            }
        }
        public string DEPARTMENTID
        {
            get
            {
                return _DEPARTMENTID;
            }
            set
            {
                _DEPARTMENTID = value;
            }
        }
        public string TELEPHONENO
        {
            get
            {
                return _TELEPHONENO;
            }
            set
            {
                _TELEPHONENO = value;
            }
        }
        public string isMeterReader
        {
            get
            {
                return _isMeterReader;
            }
            set
            {
                _isMeterReader = value;
            }
        }
        public string isCharger
        {
            get
            {
                return _isCharger;
            }
            set
            {
                _isCharger = value;
            }
        }
        public string IsCashier
        {
            get
            {
                return _IsCashier;
            }
            set
            {
                _IsCashier = value;
            }
        }
        public string userstate
        {
            get
            {
                return _userstate;
            }
            set
            {
                _userstate = value;
            }
        }

        public DateTime generateDateTime
        {
            get
            {
                return _generateDateTime;
            }
            set
            {
                _generateDateTime = value;
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
