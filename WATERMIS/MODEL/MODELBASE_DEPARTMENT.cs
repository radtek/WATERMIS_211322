using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELBASE_DEPARTMENT
    {
        private string _DEPARTMENTID;
        private string _DEPARTMENTIDOLD;
        private string _DEPARTMENT_NAME;
        private string _SIMPLECODE;
        private string _DEPARTMENT_TEL;
        private string _DEPARTMENT_MANAGER;
        private string _PARENTDEPARTMENTID;
        private string _MEMO;

        private string _FPTaxNO;
        private string _FPAddressAndTel;
        private string _FPBankNameAndAccountNO;
        private string _Payee;
        private string _Checker;

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
        public string DEPARTMENTIDOLD
        {
            get
            {
                return _DEPARTMENTIDOLD;
            }
            set
            {
                _DEPARTMENTIDOLD = value;
            }
        }
        public string DEPARTMENTNAME
        {
            get
            {
                return _DEPARTMENT_NAME;
            }
            set
            {
                _DEPARTMENT_NAME = value;
            }
        }
        public string SIMPLECODE
        {
            get
            {
                return _SIMPLECODE;
            }
            set
            {
                _SIMPLECODE = value;
            }
        }
        public string DEPARTMENTTEL
        {
            get
            {
                return _DEPARTMENT_TEL;
            }
            set
            {
                _DEPARTMENT_TEL = value;
            }
        }
        public string DEPARTMENTMANAGER
        {
            get
            {
                return _DEPARTMENT_MANAGER;
            }
            set
            {
                _DEPARTMENT_MANAGER = value;
            }
        }
        public string PARENTID
        {
            get
            {
                return _PARENTDEPARTMENTID;
            }
            set
            {
                _PARENTDEPARTMENTID = value;
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
        public string FPTaxNO
        {
            get
            {
                return _FPTaxNO;
            }
            set
            {
                _FPTaxNO = value;
            }
        }
        public string FPAddressAndTel
        {
            get
            {
                return _FPAddressAndTel;
            }
            set
            {
                _FPAddressAndTel = value;
            }
        }
        public string FPBankNameAndAccountNO
        {
            get
            {
                return _FPBankNameAndAccountNO;
            }
            set
            {
                _FPBankNameAndAccountNO = value;
            }
        }
        public string Payee
        {
            get
            {
                return _Payee;
            }
            set
            {
                _Payee = value;
            }
        }
        public string Checker
        {
            get
            {
                return _Checker;
            }
            set
            {
                _Checker = value;
            }
        }
    }
}
