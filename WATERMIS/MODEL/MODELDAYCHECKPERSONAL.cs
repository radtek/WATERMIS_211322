using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELDAYCHECKPERSONAL
   {
       private string _DAYCHECKID;
       private DateTime _DAYCHECKDATEIME;
       private string _DAYCHECKWORKERID;
       private string _DAYCHECKWORKERNAME;
       private string _CHECKERID;
       private string _CHECKERNAME;
       private DateTime _CHECKDATETIME;
       private decimal _DAYCHECKSUMMONEY;
       private decimal _DAYCHECKMONEY;
       private decimal _DAYCHECKPOS;
       private decimal _DAYCHECKZHUANZHANG;
       private int _RECEIPTNOCOUNT;
       private int _INVOICENOCOUNT;
       private string _MEMO;

       public string DAYCHECKID
       {
           get
           {
               return _DAYCHECKID;
           }
           set
           {
               _DAYCHECKID = value;
           }
       }
       public DateTime DAYCHECKDATEIME
       {
           get
           {
               return _DAYCHECKDATEIME;
           }
           set
           {
               _DAYCHECKDATEIME = value;
           }
       }
       public string DAYCHECKWORKERID
       {
           get
           {
               return _DAYCHECKWORKERID;
           }
           set
           {
               _DAYCHECKWORKERID = value;
           }
       }
       public string DAYCHECKWORKERNAME
       {
           get
           {
               return _DAYCHECKWORKERNAME;
           }
           set
           {
               _DAYCHECKWORKERNAME = value;
           }
       }
       public string CHECKERID
       {
           get
           {
               return _CHECKERID;
           }
           set
           {
               _CHECKERID = value;
           }
       }

       public string CHECKERNAME
       {
           get
           {
               return _CHECKERNAME;
           }
           set
           {
               _CHECKERNAME = value;
           }
       }
       public DateTime CHECKDATETIME
       {
           get
           {
               return _CHECKDATETIME;
           }
           set
           {
               _CHECKDATETIME = value;
           }
       }

       public decimal DAYCHECKSUMMONEY
       {
           get
           {
               return _DAYCHECKSUMMONEY;
           }
           set
           {
               _DAYCHECKSUMMONEY = value;
           }
       }

       public decimal DAYCHECKMONEY
       {
           get
           {
               return _DAYCHECKMONEY;
           }
           set
           {
               _DAYCHECKMONEY = value;
           }
       }

       public decimal DAYCHECKPOS
       {
           get
           {
               return _DAYCHECKPOS;
           }
           set
           {
               _DAYCHECKPOS = value;
           }
       }

       public decimal DAYCHECKZHUANZHANG
       {
           get
           {
               return _DAYCHECKZHUANZHANG;
           }
           set
           {
               _DAYCHECKZHUANZHANG = value;
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
       public int INVOICENOCOUNT
       {
           get
           {
               return _INVOICENOCOUNT;
           }
           set
           {
               _INVOICENOCOUNT = value;
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
