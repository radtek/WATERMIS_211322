using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class ModelMeter_WorkResolveFee_Invoice
    {
        private string _InvoicePrintID;
        private string _ChargeID;
        private string _InvoiceBatchID;
        private string _InvoiceBatchName;
        private string _InvoiceNO;

        private string _WaterUserID;
        public string WaterUserID
        {
            get { return _WaterUserID; }
            set { _WaterUserID = value; }
        }
        private string _WaterUserName;
        private string _WaterUserAddress;
        private string _WaterUserFPTaxNO;
        private string _WaterUserFPBankNameAndAccountNO;
        private string _Table_Name_CH;
        private string _Table_Name;
        private string _InvoiceFeeDepID;
        private string _InvoiceFeeDepName;
        public string InvoiceFeeDepName
        {
            get { return _InvoiceFeeDepName; }
            set { _InvoiceFeeDepName = value; }
        }

        private decimal _InvoiceTotalFeeMoney;
        public decimal InvoiceTotalFeeMoney
        {
            get { return _InvoiceTotalFeeMoney; }
            set { _InvoiceTotalFeeMoney = value; }
        }


        private string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        private string _CompanyAddress;
        public string CompanyAddress
        {
            get { return _CompanyAddress; }
            set { _CompanyAddress = value; }
        }

        private string _CompanyFPTaxNO;
        public string CompanyFPTaxNO
        {
            get { return _CompanyFPTaxNO; }
            set { _CompanyFPTaxNO = value; }
        }

        private string _CompanyFPBankNameAndAccountNO;
        public string CompanyFPBankNameAndAccountNO
        {
            get { return _CompanyFPBankNameAndAccountNO; }
            set { _CompanyFPBankNameAndAccountNO = value; }
        }

        private string _Payee;
        public string Payee
        {
            get { return _Payee; }
            set { _Payee = value; }
        }
        private string _Checker;

        public string Checker
        {
            get { return _Checker; }
            set { _Checker = value; }
        }
        private string _InvoiceType;

        public string InvoiceType
        {
            get { return _InvoiceType; }
            set { _InvoiceType = value; }
        }

        public string InvoiceFeeDepID
        {
            get { return _InvoiceFeeDepID; }
            set { _InvoiceFeeDepID = value; }
        }

        private string _InvoiceCancel;
        private DateTime _InvoiceCancelDatetime;
        private string _InvoiceCancelWorkerID;
        private string _InvoiceCancelWorkerName;
        private string _InvoiceCancelMEMO;

        public string InvoicePrintID
        {
            get
            {
                return _InvoicePrintID;
            }
            set
            {
                _InvoicePrintID = value;
            }
        }
        public string ChargeID
        {
            get
            {
                return _ChargeID;
            }
            set
            {
                _ChargeID = value;
            }
        }
        /// <summary>
        /// 发票批次ID
        /// </summary>
        public string InvoiceBatchID
        {
            get
            {
                return _InvoiceBatchID;
            }
            set
            {
                _InvoiceBatchID = value;
            }
        }
        /// <summary>
        /// 发票批次名称
        /// </summary>
        public string InvoiceBatchName
        {
            get
            {
                return _InvoiceBatchName;
            }
            set
            {
                _InvoiceBatchName = value;
            }
        }
        public string InvoiceNO
        {
            get
            {
                return _InvoiceNO;
            }
            set
            {
                _InvoiceNO = value;
            }
        }

        public string WaterUserName
        {
            get
            {
                return _WaterUserName;
            }
            set
            {
                _WaterUserName = value;
            }
        }
        public string WaterUserAddress
        {
            get
            {
                return _WaterUserAddress;
            }
            set
            {
                _WaterUserAddress = value;
            }
        }
        public string WaterUserFPTaxNO
        {
            get
            {
                return _WaterUserFPTaxNO;
            }
            set
            {
                _WaterUserFPTaxNO = value;
            }
        }
        public string WaterUserFPBankNameAndAccountNO
        {
            get
            {
                return _WaterUserFPBankNameAndAccountNO;
            }
            set
            {
                _WaterUserFPBankNameAndAccountNO = value;
            }
        }
        public string Table_Name_CH
        {
            get
            {
                return _Table_Name_CH;
            }
            set
            {
                _Table_Name_CH = value;
            }
        }
        public string Table_Name
        {
            get
            {
                return _Table_Name;
            }
            set
            {
                _Table_Name = value;
            }
        }

        private DateTime _InvoicePrintDateTime;
        public DateTime InvoicePrintDateTime
        {
            get
            {
                return _InvoicePrintDateTime;
            }
            set
            {
                _InvoicePrintDateTime = value;
            }
        }

        private string _InvoicePrintWorkerID;
        public string InvoicePrintWorkerID
        {
            get
            {
                return _InvoicePrintWorkerID;
            }
            set
            {
                _InvoicePrintWorkerID = value;
            }
        }

        private string _InvoicePrintWorker;
        public string InvoicePrintWorker
        {
            get
            {
                return _InvoicePrintWorker;
            }
            set
            {
                _InvoicePrintWorker = value;
            }
        }

        private string _Memo;
        public string Memo
        {
            get
            {
                return _Memo;
            }
            set
            {
                _Memo = value;
            }
        }

        public string InvoiceCancel
        {
            get
            {
                return _InvoiceCancel;
            }
            set
            {
                _InvoiceCancel = value;
            }
        }
        public string InvoiceCancelWorkerID
        {
            get
            {
                return _InvoiceCancelWorkerID;
            }
            set
            {
                _InvoiceCancelWorkerID = value;
            }
        }
        public string InvoiceCancelWorkerName
        {
            get
            {
                return _InvoiceCancelWorkerName;
            }
            set
            {
                _InvoiceCancelWorkerName = value;
            }
        }
        public DateTime InvoiceCancelDatetime
        {
            get
            {
                return _InvoiceCancelDatetime;
            }
            set
            {
                _InvoiceCancelDatetime = value;
            }
        }
        public string InvoiceCancelMEMO
        {
            get
            {
                return _InvoiceCancelMEMO;
            }
            set
            {
                _InvoiceCancelMEMO = value;
            }
        }
    }
}
