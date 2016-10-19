using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
   public class MODELWATERMETERTYPE
   {
       private string _waterMeterTypeId;
       private string _waterMeterTypeValue;
       private string _WATERMETERTYPECLASSID;
       private string _trapezoidPrice;
       private string _extraCharge;
       private string _overDuechargeEnable;
       private int _overDuechargeStartMonth;
       private int _overDuechargeStartDay;
       private decimal _overDuechargePercent;
       private string _MEMO;

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
       public string waterMeterTypeValue
       {
           get
           {
               return _waterMeterTypeValue;
           }
           set
           {
               _waterMeterTypeValue = value;
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
       public string trapezoidPrice
       {
           get
           {
               return _trapezoidPrice;
           }
           set
           {
               _trapezoidPrice = value;
           }
       }
       public string extraCharge
       {
           get
           {
               return _extraCharge;
           }
           set
           {
               _extraCharge = value;
           }
       }
       public string overDuechargeEnable
       {
           get
           {
               return _overDuechargeEnable;
           }
           set
           {
               _overDuechargeEnable = value;
           }
       }
       public int overDuechargeStartMonth
       {
           get
           {
               return _overDuechargeStartMonth;
           }
           set
           {
               _overDuechargeStartMonth = value;
           }
       }
       public int overDuechargeStartDay
       {
           get
           {
               return _overDuechargeStartDay;
           }
           set
           {
               _overDuechargeStartDay = value;
           }
       }
       public decimal overDuechargePercent
       {
           get
           {
               return _overDuechargePercent;
           }
           set
           {
               _overDuechargePercent = value;
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
