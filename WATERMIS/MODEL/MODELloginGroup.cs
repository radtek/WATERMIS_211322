using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELloginGroup
   {
       private string _groupId;
       private string _groupName;
       private string _MEMO;

       public string groupId
       {
           get
           {
               return _groupId;
           }
           set
           {
               _groupId = value;
           }
       }
       public string groupName
       {
           get
           {
               return _groupName;
           }
           set
           {
               _groupName = value;
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
