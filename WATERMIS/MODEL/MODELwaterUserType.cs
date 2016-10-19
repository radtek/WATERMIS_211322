using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
   public class MODELwaterUserType
   {
       private string _waterUserTypeId;
       private string _waterUserTypeName;
       private string _overDuechargeEnable;
       private int _overDuechargeStartMonth;
       private int _overDuechargeStartDay;
       private decimal _overDuechargePercent;
       private string _invoiceBillName;
       private string _MEMO;

       public string waterUserTypeId
       {
           get
           {
               return _waterUserTypeId;
           }
           set
           {
               _waterUserTypeId = value;
           }
       }
       public string waterUserTypeName
       {
           get
           {
               return _waterUserTypeName;
           }
           set
           {
               _waterUserTypeName = value;
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
       public string invoiceBillName
       {
           get
           {
               return _invoiceBillName;
           }
           set
           {
               _invoiceBillName = value;
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
