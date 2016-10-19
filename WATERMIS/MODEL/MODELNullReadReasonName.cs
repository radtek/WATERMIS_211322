using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELNullReadReasonName
   {
       private string _NullReadReasonID;
       private string _NullReadReasonName;
       private string _Memo;

       public string NullReadReasonID
       {
           get
           {
               return _NullReadReasonID;
           }
           set
           {
               _NullReadReasonID = value;
           }
       }
       public string NullReadReasonName
       {
           get
           {
               return _NullReadReasonName;
           }
           set
           {
               _NullReadReasonName = value;
           }
       }
       public string Memo
       {
           get
           {
               return _Memo;
           }
           set
           {
               _Memo = value;
           }
       }
    }
}
