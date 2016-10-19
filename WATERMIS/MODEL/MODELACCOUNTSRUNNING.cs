using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELACCOUNTSRUNNING
   {
       private string _ACCOUNTSID;
       private DateTime _ACCOUNTSYEARANDMONTH;
       private decimal _BUSINESSMONEY;
       private decimal _FINANCEMONEY;
       private DateTime _ACCOUNTSDATETIME;
       private string _OPERATORID;
       private string _OPERATORNAME;
       private string _MEMO;

       public string ACCOUNTSID
       {
           get
           {
               return _ACCOUNTSID;
           }
           set
           {
               _ACCOUNTSID = value;
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
       public decimal BUSINESSMONEY
       {
           get
           {
               return _BUSINESSMONEY;
           }
           set
           {
               _BUSINESSMONEY = value;
           }
       }
       public decimal FINANCEMONEY
       {
           get
           {
               return _FINANCEMONEY;
           }
           set
           {
               _FINANCEMONEY = value;
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

       public string OPERATORID
       {
           get
           {
               return _OPERATORID;
           }
           set
           {
               _OPERATORID = value;
           }
       }

       public string OPERATORNAME
       {
           get
           {
               return _OPERATORNAME;
           }
           set
           {
               _OPERATORNAME = value;
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
