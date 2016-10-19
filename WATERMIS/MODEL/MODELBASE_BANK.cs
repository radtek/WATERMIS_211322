using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
   public class MODELBASE_BANK
   {
       private string _BANKID;
       private string _BANKNAME;
       private string _MEMO;

       public string BANKID
       {
           get
           {
               return _BANKID;
           }
           set
           {
               _BANKID = value;
           }
       }
       public string BANKNAME
       {
           get
           {
               return _BANKNAME;
           }
           set
           {
               _BANKNAME = value;
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
