using System;
using System.Collections.Generic;
using System.Text;

namespace BASEFUNCTION
{
   public class ListItem
   {
       private string _strID;
       private string _strName;
       public string strID
       {
           get
           {
               return _strID;
           }
           set
           {
               _strID = value;
           }
       }
       public string strName
       {
           get
           {
               return _strName;
           }
           set
           {
               _strName = value;
           }
       }

       public ListItem(string strName, string strID)
       {
           this.strID = strID;
           this.strName = strName;
       }
       public override string ToString()
       {
           return this.strName;
       }
    }
}
