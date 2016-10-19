using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELMESSAGESEND
    {
        private string _MESSAGESENDID;
        private string _MESSAGESENDERID;
        private string _MESSAGESENDERNAME;
        private string _MESSAGERECEIVER;
        private string _MESSAGETITLE;
        private string _MESSAGECONTENT;
        private string _MESSAGECLASS;
        private DateTime _MESSAGESENDTIME;
        private string _ISDELETE;
        private DateTime _DELETEDATETIME;
        private string _MEMO;

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
        public string MESSAGERECEIVER
        {
            get
            {
                return _MESSAGERECEIVER;
            }
            set
            {
                _MESSAGERECEIVER = value;
            }
        }
        public string MESSAGESENDERID
        {
            get
            {
                return _MESSAGESENDERID;
            }
            set
            {
                _MESSAGESENDERID = value;
            }
        }
        public string MESSAGESENDERNAME
        {
            get
            {
                return _MESSAGESENDERNAME;
            }
            set
            {
                _MESSAGESENDERNAME = value;
            }
        }
        public string MESSAGETITLE
        {
            get
            {
                return _MESSAGETITLE;
            }
            set
            {
                _MESSAGETITLE = value;
            }
        }
        public string MESSAGECONTENT
        {
            get
            {
                return _MESSAGECONTENT;
            }
            set
            {
                _MESSAGECONTENT = value;
            }
        }
        public string MESSAGECLASS
        {
            get
            {
                return _MESSAGECLASS;
            }
            set
            {
                _MESSAGECLASS = value;
            }
        }
        public DateTime MESSAGESENDTIME
        {
            get
            {
                return _MESSAGESENDTIME;
            }
            set
            {
                _MESSAGESENDTIME = value;
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
