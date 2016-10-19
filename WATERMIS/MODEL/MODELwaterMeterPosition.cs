using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
   public class MODELwaterMeterPosition
   {
       private string _waterMeterPositionId;
       private string _waterMeterPositionName;
       private string _MEMO;

       public string waterMeterPositionId
       {
           get
           {
               return _waterMeterPositionId;
           }
           set
           {
               _waterMeterPositionId = value;
           }
       }
       public string waterMeterPositionName
       {
           get
           {
               return _waterMeterPositionName;
           }
           set
           {
               _waterMeterPositionName = value;
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
