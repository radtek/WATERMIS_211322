using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELwaterMeterSize
   {
       private string _waterMeterSizeId;
       private string _waterMeterSizeValue;
       private string _waterLossComputeType;
       private int _checkPeriod;
       private decimal _waterLossValue;
       private string _MEMO;

       public string waterMeterSizeId
       {
           get
           {
               return _waterMeterSizeId;
           }
           set
           {
               _waterMeterSizeId = value;
           }
       }
       public string waterMeterSizeValue
       {
           get
           {
               return _waterMeterSizeValue;
           }
           set
           {
               _waterMeterSizeValue = value;
           }
       }
       public string waterLossComputeType
       {
           get
           {
               return _waterLossComputeType;
           }
           set
           {
               _waterLossComputeType = value;
           }
       }
       public int checkPeriod
       {
           get
           {
               return _checkPeriod;
           }
           set
           {
               _checkPeriod = value;
           }
       }
       public decimal waterLossValue
       {
           get
           {
               return _waterLossValue;
           }
           set
           {
               _waterLossValue = value;
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
