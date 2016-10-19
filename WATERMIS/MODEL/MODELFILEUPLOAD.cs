using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
   public class MODELFILEUPLOAD
    {
        private string _FILENAME;
        private string _VERSION;
        private Byte[] _FILECONTENT;
        private DateTime _OPERATORTIME;

        public string FILENAME
        {
            get
            {
                return _FILENAME;
            }
            set
            {
                _FILENAME = value;
            }
        }
        public string VERSION
        {
            get
            {
                return _VERSION;
            }
            set
            {
                _VERSION = value;
            }
        }
        public Byte[] FILECONTENT
        {
            get
            {
                return _FILECONTENT;
            }
            set
            {
                _FILECONTENT = value;
            }
        }
        public DateTime OPERATORTIME
        {
            get
            {
                return _OPERATORTIME;
            }
            set
            {
                _OPERATORTIME = value;
            }
        }
    }
}
