using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELWATERMETERTYPECLASS
   {
       private string _WATERMETERTYPECLASSID;
       private string _WATERMETERTYPECLASSNAME;
       private string _MEMO;

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
       public string WATERMETERTYPECLASSNAME
       {
           get
           {
               return _WATERMETERTYPECLASSNAME;
           }
           set
           {
               _WATERMETERTYPECLASSNAME = value;
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
