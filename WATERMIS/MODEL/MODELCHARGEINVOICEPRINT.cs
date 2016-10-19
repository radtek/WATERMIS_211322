using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELCHARGEINVOICEPRINT
    {
        private string _CHARGEINVOICEPRINTID;
        private string _CHARGEID;
        private string _INVOICEBATCHID;
        private string _INVOICEBATCHNAME;
        private string _INVOICENO;
        private DateTime _INVOICEPRINTDATETIME;
        private string _INVOICEPRINTWORKERID;
        private string _INVOICEPRINTWORKERNAME;
        private string _INVOICECANCEL;
        private object _INVOICESTATE;
        private string _INVOICECANCELWORKERID;
        private string _INVOICECANCELWORKERNAME;
        private DateTime _INVOICECANCELDATETIME;
        private string _INVOICECANCELMEMO;

        private int _readMeterRecordYear;
        private int _readMeterRecordMonth;
        private string _waterUserName;
        private string _waterUserAddress;
        private string _waterMeterNo;
        private string _waterMeterTypeId;
        private string _waterMeterTypeName;
        private int _waterMeterLastNumber;
        private int _waterMeterEndNumber;
        private int _totalNumber;
        private decimal _avePrice;
        private decimal _waterTotalCharge;
        private decimal _extraChargePrice1;
        private decimal _extraCharge1;
        private decimal _extraChargePrice2;
        private decimal _extraCharge2;
        private decimal _totalCharge;
        private decimal _taxRate;


        public string CHARGEINVOICEPRINTID
        {
            get
            {
                return _CHARGEINVOICEPRINTID;
            }
            set
            {
                _CHARGEINVOICEPRINTID = value;
            }
        }
        public string CHARGEID
        {
            get
            {
                return _CHARGEID;
            }
            set
            {
                _CHARGEID = value;
            }
        }
        /// <summary>
        /// 发票批次ID
        /// </summary>
        public string INVOICEBATCHID
        {
            get
            {
                return _INVOICEBATCHID;
            }
            set
            {
                _INVOICEBATCHID = value;
            }
        }
        /// <summary>
        /// 发票批次名称
        /// </summary>
        public string INVOICEBATCHNAME
        {
            get
            {
                return _INVOICEBATCHNAME;
            }
            set
            {
                _INVOICEBATCHNAME = value;
            }
        }
        public string INVOICENO
        {
            get
            {
                return _INVOICENO;
            }
            set
            {
                _INVOICENO = value;
            }
        }
        public DateTime INVOICEPRINTDATETIME
        {
            get
            {
                return _INVOICEPRINTDATETIME;
            }
            set
            {
                _INVOICEPRINTDATETIME = value;
            }
        }
        public string INVOICEPRINTWORKERID
        {
            get
            {
                return _INVOICEPRINTWORKERID;
            }
            set
            {
                _INVOICEPRINTWORKERID = value;
            }
        }
        public string INVOICEPRINTWORKERNAME
        {
            get
            {
                return _INVOICEPRINTWORKERNAME;
            }
            set
            {
                _INVOICEPRINTWORKERNAME = value;
            }
        }
        public string INVOICECANCEL
        {
            get
            {
                return _INVOICECANCEL;
            }
            set
            {
                _INVOICECANCEL = value;
            }
        }
        public object INVOICESTATE
        {
            get
            {
                return _INVOICESTATE;
            }
            set
            {
                _INVOICESTATE = value;
            }
        }
        public string INVOICECANCELWORKERID
        {
            get
            {
                return _INVOICECANCELWORKERID;
            }
            set
            {
                _INVOICECANCELWORKERID = value;
            }
        }
        public string INVOICECANCELWORKERNAME
        {
            get
            {
                return _INVOICECANCELWORKERNAME;
            }
            set
            {
                _INVOICECANCELWORKERNAME = value;
            }
        }
        public DateTime INVOICECANCELDATETIME
        {
            get
            {
                return _INVOICECANCELDATETIME;
            }
            set
            {
                _INVOICECANCELDATETIME = value;
            }
        }
        public string INVOICECANCELMEMO
        {
            get
            {
                return _INVOICECANCELMEMO;
            }
            set
            {
                _INVOICECANCELMEMO = value;
            }
        }

        public int readMeterRecordYear
        {
            get
            {
                return _readMeterRecordYear;
            }
            set
            {
                _readMeterRecordYear = value;
            }
        }
        public int readMeterRecordMonth
        {
            get
            {
                return _readMeterRecordMonth;
            }
            set
            {
                _readMeterRecordMonth = value;
            }
        }
        public string waterUserName
        {
            get
            {
                return _waterUserName;
            }
            set
            {
                _waterUserName = value;
            }
        }
        public string waterUserAddress
        {
            get
            {
                return _waterUserAddress;
            }
            set
            {
                _waterUserAddress = value;
            }
        }
        public string waterMeterNo
        {
            get
            {
                return _waterMeterNo;
            }
            set
            {
                _waterMeterNo = value;
            }
        }
        public string waterMeterTypeId
        {
            get
            {
                return _waterMeterTypeId;
            }
            set
            {
                _waterMeterTypeId = value;
            }
        }
        public string waterMeterTypeName
        {
            get
            {
                return _waterMeterTypeName;
            }
            set
            {
                _waterMeterTypeName = value;
            }
        }
        public int waterMeterLastNumber
        {
            get
            {
                return _waterMeterLastNumber;
            }
            set
            {
                _waterMeterLastNumber = value;
            }
        }
        public int waterMeterEndNumber
        {
            get
            {
                return _waterMeterEndNumber;
            }
            set
            {
                _waterMeterEndNumber = value;
            }
        }
        public int totalNumber
        {
            get
            {
                return _totalNumber;
            }
            set
            {
                _totalNumber = value;
            }
        }
        /// <summary>
        /// 平均单价
        /// </summary>
        public decimal avePrice
        {
            get
            {
                return _avePrice;
            }
            set
            {
                _avePrice = value;
            }
        }
        /// <summary>
        /// 水费小计
        /// </summary>
        public decimal waterTotalCharge
        {
            get
            {
                return _waterTotalCharge;
            }
            set
            {
                _waterTotalCharge = value;
            }
        }
        public decimal extraChargePrice1
        {
            get
            {
                return _extraChargePrice1;
            }
            set
            {
                _extraChargePrice1 = value;
            }
        }
        public decimal extraCharge1
        {
            get
            {
                return _extraCharge1;
            }
            set
            {
                _extraCharge1 = value;
            }
        }
        public decimal extraChargePrice2
        {
            get
            {
                return _extraChargePrice2;
            }
            set
            {
                _extraChargePrice2 = value;
            }
        }
        public decimal extraCharge2
        {
            get
            {
                return _extraCharge2;
            }
            set
            {
                _extraCharge2 = value;
            }
        }
        /// <summary>
        /// 总应收费，含水费、附加费等费用
        /// </summary>
        public decimal totalCharge
        {
            get
            {
                return _totalCharge;
            }
            set
            {
                _totalCharge = value;
            }
        }
        public decimal taxRate
        {
            get
            {
                return _taxRate;
            }
            set
            {
                _taxRate = value;
            }
        }
    }
}
