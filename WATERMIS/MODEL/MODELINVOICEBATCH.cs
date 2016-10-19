using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELINVOICEBATCH
   {
       private string _INVOICEBATCHID;
       private string _INVOICEBATCHNAME;
       private string _ISUSING;
       private string _INVOICEBATCHMEMO;

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
       public string ISUSING
       {
           get
           {
               return _ISUSING;
           }
           set
           {
               _ISUSING = value;
           }
       }
       public string INVOICEBATCHMEMO
       {
           get
           {
               return _INVOICEBATCHMEMO;
           }
           set
           {
               _INVOICEBATCHMEMO = value;
           }
       }
    }
}
