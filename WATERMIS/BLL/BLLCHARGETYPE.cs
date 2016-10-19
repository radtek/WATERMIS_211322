using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
   public class BLLCHARGETYPE
   {
       public DataTable QUERY(string strFilter)
       {
           StringBuilder str = new StringBuilder();
           DataTable dt = new DataTable();
           str.Append("SELECT * FROM CHARGETYPE WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
    }
}
