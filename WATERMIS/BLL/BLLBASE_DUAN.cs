using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLBASE_DUAN
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM BASE_DUAN WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM BASE_DUAN WHERE DUANID=@DUANID");
           SqlParameter[] para =
           {
               new SqlParameter("@DUANID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELBASE_DUAN MODELBASE_DUAN)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE BASE_DUAN SET DUANNAME=@DUANNAME,MEMO=@MEMO ");
           str.Append("WHERE DUANID=@DUANID");
           SqlParameter[] para =
           {
               new SqlParameter("@DUANNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@DUANID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELBASE_DUAN.DUANNAME;
           para[1].Value = MODELBASE_DUAN.MEMO;
           para[2].Value = MODELBASE_DUAN.DUANID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELBASE_DUAN MODELBASE_DUAN)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO BASE_DUAN(DUANID,DUANNAME,PARENTID,MEMO) ");
           str.Append("VALUES(@DUANID,@DUANNAME,@PARENTID,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@DUANID",SqlDbType.VarChar,30),
               new SqlParameter("@DUANNAME",SqlDbType.VarChar,50),
               new SqlParameter("@PARENTID",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELBASE_DUAN.DUANID;
           para[1].Value = MODELBASE_DUAN.DUANNAME;
           para[2].Value = MODELBASE_DUAN.PARENTID;
           para[3].Value = MODELBASE_DUAN.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public MODELBASE_DUAN GetMODELBASE_DUAN(string strDepID)
       {
           DataTable dt = new DataTable();
           MODELBASE_DUAN MODELBASE_DUAN = new MODELBASE_DUAN();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM BASE_DUAN WHERE DUANID=@DUANID");
           SqlParameter[] para =
           {
               new SqlParameter("@DUANID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDepID;
           dt = DBUtility.DbHelperSQL.Query(str.ToString(), para).Tables[0];
           if (dt.Rows.Count == 0)
               return null;
           else
           {
               MODELBASE_DUAN.DUANNAME = dt.Rows[0]["DUANNAME"].ToString();
               if (dt.Rows[0]["PARENTID"] != null)
                   MODELBASE_DUAN.PARENTID = dt.Rows[0]["PARENTID"].ToString();
               if (dt.Rows[0]["MEMO"] != null)
                   MODELBASE_DUAN.MEMO = dt.Rows[0]["MEMO"].ToString();
               return MODELBASE_DUAN;
           }
       }
    }
}
