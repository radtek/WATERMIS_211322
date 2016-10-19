using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELBASE_DUAN
   {
       private string _DUANID;
       private string _DUANNAME;
       private string _PARENTID;
       private string _MEMO;

       public string DUANID
       {
           get
           {
               return _DUANID;
           }
           set
           {
               _DUANID = value;
           }
       }
       public string DUANNAME
       {
           get
           {
               return _DUANNAME;
           }
           set
           {
               _DUANNAME = value;
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
