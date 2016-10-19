using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
   public class BLLBASE_BANK
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM BASE_BANK WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Delete(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM BASE_BANK WHERE BANKID=@BANKID");
           SqlParameter[] para =
           {
               new SqlParameter("@BANKID",SqlDbType.VarChar,30)
           };
           para[0].Value = strID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELBASE_BANK MODELBASE_BANK)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE BASE_BANK SET BANKNAME=@BANKNAME,MEMO=@MEMO ");
           str.Append("WHERE BANKID=@BANKID");
           SqlParameter[] para =
           {
               new SqlParameter("@BANKNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@BANKID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELBASE_BANK.BANKNAME;
           para[1].Value = MODELBASE_BANK.MEMO;
           para[2].Value = MODELBASE_BANK.BANKID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELBASE_BANK MODELBASE_BANK)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO BASE_BANK(BANKID,BANKNAME,MEMO) ");
           str.Append("VALUES(@BANKID,@BANKNAME,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@BANKID",SqlDbType.VarChar,30),
               new SqlParameter("@BANKNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELBASE_BANK.BANKID;
           para[1].Value = MODELBASE_BANK.BANKNAME;
           para[2].Value = MODELBASE_BANK.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
