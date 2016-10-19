using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELreadMeterRecordCancel
   {
       private string _readMeterRecordCancelId;
       private string _readMeterRecordId;
       private string _chargeID;

       public string readMeterRecordCancelId
       {
           get
           {
               return _readMeterRecordCancelId;
           }
           set
           {
               _readMeterRecordCancelId = value;
           }
       }
       public string readMeterRecordId
       {
           get
           {
               return _readMeterRecordId;
           }
           set
           {
               _readMeterRecordId = value;
           }
       }
       public string chargeID
       {
           get
           {
               return _chargeID;
           }
           set
           {
               _chargeID = value;
           }
       }
    }
}
