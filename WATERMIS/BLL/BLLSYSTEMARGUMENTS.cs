using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
   public class BLLSYSTEMARGUMENTS
    {
       public DataTable Query(string strFilter)
       {
           string strSQL = "SELECT * FROM SYSTEMARGUMENTS WHERE 1=1 ";
           DataTable dtArguments = DBUtility.DbHelperSQL.Query(strSQL+strFilter).Tables[0];
           return dtArguments;
       }
       public bool Update(MODELSYSTEMARGUMENTS MODELSYSTEMARGUMENTS)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE SYSTEMARGUMENTS SET INVOICENOLENTH=@INVOICENOLENTH");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICENOLENTH",SqlDbType.Int)
           };
           int intExcute = DBUtility.DbHelperSQL.ExecuteSql(str.ToString());
           if (intExcute > 0)
               return true;
           else
               return false;
       }
    }
}
