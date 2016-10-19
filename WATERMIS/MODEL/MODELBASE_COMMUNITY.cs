using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELBASE_COMMUNITY
   {
       private string _COMMUNITYID;
       private string _COMMUNITYNAME;
       private string _PARENTID;
       private string _MEMO;

       public string COMMUNITYID
       {
           get
           {
               return _COMMUNITYID;
           }
           set
           {
               _COMMUNITYID = value;
           }
       }
       public string COMMUNITYNAME
       {
           get
           {
               return _COMMUNITYNAME;
           }
           set
           {
               _COMMUNITYNAME = value;
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
