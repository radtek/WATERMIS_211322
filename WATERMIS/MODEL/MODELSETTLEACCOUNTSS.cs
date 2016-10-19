using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELSETTLEACCOUNTSS
   {
       private string _SETTLEACCOUNTSSSID;
       private DateTime _ACCOUNTSYEARANDMONTH;
       private DateTime _ACCOUNTSDATETIME;
       private string _ACCOUNTSWORKERID;
       private string _ACCOUNTSWORKERNAME;
       private string _WATERMETERTYPECLASSID;
       private string _WATERMETERTYPECLASSNAME;
       private string _waterMeterTypeId;
       private string _waterMeterTypeName;
       private int _BILLCOUNT;
       private int _INVOICECOUNT;
       private int _RECEIPTNOCOUNT;
       private int _TOTALNUMBER;
       private decimal _WATERTOTALCHARGE;
       private decimal _EXTRACHARGE1;
       private decimal _EXTRACHARGE2;
       private decimal _TOTALCHARGE;
       private decimal _OVERDUEMONEY;
       private decimal _TOTALCHARGEEND;
       private decimal _YCZJ;
       private decimal _SSJE;
       private string _SSTYPE;

       public string SETTLEACCOUNTSSSID
       {
           get
           {
               return _SETTLEACCOUNTSSSID;
           }
           set
           {
               _SETTLEACCOUNTSSSID = value;
           }
       }
       public DateTime ACCOUNTSYEARANDMONTH
       {
           get
           {
               return _ACCOUNTSYEARANDMONTH;
           }
           set
           {
               _ACCOUNTSYEARANDMONTH = value;
           }
       }
       public DateTime ACCOUNTSDATETIME
       {
           get
           {
               return _ACCOUNTSDATETIME;
           }
           set
           {
               _ACCOUNTSDATETIME = value;
           }
       }
       public string ACCOUNTSWORKERID
       {
           get
           {
               return _ACCOUNTSWORKERID;
           }
           set
           {
               _ACCOUNTSWORKERID = value;
           }
       }
       public string ACCOUNTSWORKERNAME
       {
           get
           {
               return _ACCOUNTSWORKERNAME;
           }
           set
           {
               _ACCOUNTSWORKERNAME = value;
           }
       }
       public string WATERMETERTYPECLASSID
       {
           get
           {
               return _WATERMETERTYPECLASSID;
           }
           set
           {
               _WATERMETERTYPECLASSID = value;
           }
       }
       public string WATERMETERTYPECLASSNAME
       {
           get
           {
               return _WATERMETERTYPECLASSNAME;
           }
           set
           {
               _WATERMETERTYPECLASSNAME = value;
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
       public int BILLCOUNT
       {
           get
           {
               return _BILLCOUNT;
           }
           set
           {
               _BILLCOUNT = value;
           }
       }
       public int INVOICECOUNT
       {
           get
           {
               return _INVOICECOUNT;
           }
           set
           {
               _INVOICECOUNT = value;
           }
       }
       public int RECEIPTNOCOUNT
       {
           get
           {
               return _RECEIPTNOCOUNT;
           }
           set
           {
               _RECEIPTNOCOUNT = value;
           }
       }
       public int TOTALNUMBER
       {
           get
           {
               return _TOTALNUMBER;
           }
           set
           {
               _TOTALNUMBER = value;
           }
       }
       public decimal WATERTOTALCHARGE
       {
           get
           {
               return _WATERTOTALCHARGE;
           }
           set
           {
               _WATERTOTALCHARGE = value;
           }
       }
       public decimal EXTRACHARGE1
       {
           get
           {
               return _EXTRACHARGE1;
           }
           set
           {
               _EXTRACHARGE1 = value;
           }
       }
       public decimal EXTRACHARGE2
       {
           get
           {
               return _EXTRACHARGE2;
           }
           set
           {
               _EXTRACHARGE2 = value;
           }
       }
       public decimal TOTALCHARGE
       {
           get
           {
               return _TOTALCHARGE;
           }
           set
           {
               _TOTALCHARGE = value;
           }
       }
       public decimal OVERDUEMONEY
       {
           get
           {
               return _OVERDUEMONEY;
           }
           set
           {
               _OVERDUEMONEY = value;
           }
       }
       public decimal TOTALCHARGEEND
       {
           get
           {
               return _TOTALCHARGEEND;
           }
           set
           {
               _TOTALCHARGEEND = value;
           }
       }
       public decimal YCZJ
       {
           get
           {
               return _YCZJ;
           }
           set
           {
               _YCZJ = value;
           }
       }
       public decimal SSJE
       {
           get
           {
               return _SSJE;
           }
           set
           {
               _SSJE = value;
           }
       }
        /// <summary>
        /// 实收当期:1,实收陈欠:2
        /// </summary>
       public string SSTYPE
       {
           get
           {
               return _SSTYPE;
           }
           set
           {
               _SSTYPE = value;
           }
       }
    }
}
