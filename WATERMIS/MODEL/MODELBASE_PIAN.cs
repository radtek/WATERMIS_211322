using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELBASE_PIAN
   {
       private string _PIANID;
       private string _PIANNAME;
       private string _PARENTID;
       private string _MEMO;

       public string PIANID
       {
           get
           {
               return _PIANID;
           }
           set
           {
               _PIANID = value;
           }
       }
       public string PIANNAME
       {
           get
           {
               return _PIANNAME;
           }
           set
           {
               _PIANNAME = value;
           }
       }
       public string PARENTID
       {
           get
           {
               return _PARENTID;
           }
           set
           {
               _PARENTID = value;
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
