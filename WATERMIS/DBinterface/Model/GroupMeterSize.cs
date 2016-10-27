using System;
using System.Collections.Generic;
using System.Text;

namespace DBinterface.Model
{
   public class GroupMeterSize
    {
       public string GroupID {get;set; }
       public string waterMeterSizeId { get; set; }
       public int MeterCount { get; set; }
       public string Memo { get; set; }
    }
}
