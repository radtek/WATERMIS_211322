using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELMESSAGERECEIVE
    {
        private string _MESSAGERECEIVEID;
        private string _MESSAGESENDID;
        private string _MESSAGERECEIVERID;
        private string _MESSAGERECEIVERNAME;
        private string _MESSAGEREADEDSIGN;
        private string _ISDELETE;
        private DateTime _DELETEDATETIME;
        private string _MEMO;

        public string MESSAGERECEIVEID
        {
            get
            {
                return _MESSAGERECEIVEID;
            }
            set
            {
                _MESSAGERECEIVEID = value;
            }
        }
        public string MESSAGESENDID
        {
            get
            {
                return _MESSAGESENDID;
            }
            set
            {
                _MESSAGESENDID = value;
            }
        }
        public string MESSAGERECEIVERID
        {
            get
            {
                return _MESSAGERECEIVERID;
            }
            set
            {
                _MESSAGERECEIVERID = value;
            }
        }
        public string MESSAGERECEIVERNAME
        {
            get
            {
                return _MESSAGERECEIVERNAME;
            }
            set
            {
                _MESSAGERECEIVERNAME = value;
            }
        }
        public string MESSAGEREADEDSIGN
        {
            get
            {
                return _MESSAGEREADEDSIGN;
            }
            set
            {
                _MESSAGEREADEDSIGN = value;
            }
        }
        public string ISDELETE
        {
            get
            {
                return _ISDELETE;
            }
            set
            {
                _ISDELETE = value;
            }
        }
        public DateTime DELETEDATETIME
        {
            get
            {
                return _DELETEDATETIME;
            }
            set
            {
                _DELETEDATETIME = value;
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
