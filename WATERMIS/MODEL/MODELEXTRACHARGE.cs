
using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELEXTRACHARGE
   {
       private string _extraChargeID;
       private string _extraChargeName;
       private decimal _extraChargeValue;
       private string _extraChargeState;
       private string _MEMO;

       public string extraChargeID
       {
           get
           {
               return _extraChargeID;
           }
           set
           {
               _extraChargeID = value;
           }
       }
       public string extraChargeName
       {
           get
           {
               return _extraChargeName;
           }
           set
           {
               _extraChargeName = value;
           }
       }
       public decimal extraChargeValue
       {
           get
           {
               return _extraChargeValue;
           }
           set
           {
               _extraChargeValue = value;
           }
       }
       public string extraChargeState
       {
           get
           {
               return _extraChargeState;
           }
           set
           {
               _extraChargeState = value;
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
