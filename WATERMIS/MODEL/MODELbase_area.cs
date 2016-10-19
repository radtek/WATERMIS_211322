using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
   public class MODELbase_area
   {
       private string _areaId;
       private string _areaName;
       private string _parentid;
       private string _MEMO;

       public string areaId
       {
           get
           {
               return _areaId;
           }
           set
           {
               _areaId = value;
           }
       }
       public string areaName
       {
           get
           {
               return _areaName;
           }
           set
           {
               _areaName = value;
           }
       }
       public string PARENTID
       {
           get
           {
               return _parentid;
           }
           set
           {
               _parentid = value;
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
