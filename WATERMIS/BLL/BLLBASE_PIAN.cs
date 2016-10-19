using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLBASE_PIAN
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM BASE_PIAN WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM BASE_PIAN WHERE PIANID=@PIANID");
           SqlParameter[] para =
           {
               new SqlParameter("@PIANID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELBASE_PIAN MODELBASE_PIAN)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE BASE_PIAN SET PIANNAME=@PIANNAME,MEMO=@MEMO ");
           str.Append("WHERE PIANID=@PIANID");
           SqlParameter[] para =
           {
               new SqlParameter("@PIANNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@PIANID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELBASE_PIAN.PIANNAME;
           para[1].Value = MODELBASE_PIAN.MEMO;
           para[2].Value = MODELBASE_PIAN.PIANID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELBASE_PIAN MODELBASE_PIAN)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO BASE_PIAN(PIANID,PIANNAME,PARENTID,MEMO) ");
           str.Append("VALUES(@PIANID,@PIANNAME,@PARENTID,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@PIANID",SqlDbType.VarChar,30),
               new SqlParameter("@PIANNAME",SqlDbType.VarChar,50),
               new SqlParameter("@PARENTID",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELBASE_PIAN.PIANID;
           para[1].Value = MODELBASE_PIAN.PIANNAME;
           para[2].Value = MODELBASE_PIAN.PARENTID;
           para[3].Value = MODELBASE_PIAN.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public MODELBASE_PIAN GetMODELBASE_PIAN(string strDepID)
       {
           DataTable dt = new DataTable();
           MODELBASE_PIAN MODELBASE_PIAN = new MODELBASE_PIAN();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM BASE_PIAN WHERE PIANID=@PIANID");
           SqlParameter[] para =
           {
               new SqlParameter("@PIANID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDepID;
           dt = DBUtility.DbHelperSQL.Query(str.ToString(), para).Tables[0];
           if (dt.Rows.Count == 0)
               return null;
           else
           {
               MODELBASE_PIAN.PIANNAME = dt.Rows[0]["PIANNAME"].ToString();
               if (dt.Rows[0]["PARENTID"] != null)
                   MODELBASE_PIAN.PARENTID = dt.Rows[0]["PARENTID"].ToString();
               if (dt.Rows[0]["MEMO"] != null)
                   MODELBASE_PIAN.MEMO = dt.Rows[0]["MEMO"].ToString();
               return MODELBASE_PIAN;
           }
       }
    }
}
