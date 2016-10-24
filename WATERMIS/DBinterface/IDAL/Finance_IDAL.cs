using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DBinterface.IDAL
{
   public interface Finance_IDAL 
    {
       DataTable GetTableList();

       DataTable GetChargeMonth();

       DataTable GetChargeDay();

       string ChargeSqlList();
    }
}
