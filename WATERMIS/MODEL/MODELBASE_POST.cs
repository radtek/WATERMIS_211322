using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
   public class MODELBASE_POST
   {
       private string _POSTID;
       private string _POSTNAME;
       private string _MEMO;

       public string POSTID
       {
           get
           {
               return _POSTID;
           }
           set
           {
               _POSTID = value;
           }
       }
       public string POSTNAME
       {
           get
           {
               return _POSTNAME;
           }
           set
           {
               _POSTNAME = value;
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
