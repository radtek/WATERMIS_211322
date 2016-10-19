using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLWATERMETERTYPECLASS
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM WATERMETERTYPECLASS WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM WATERMETERTYPECLASS WHERE WATERMETERTYPECLASSID=@WATERMETERTYPECLASSID");
           SqlParameter[] para =
           {
               new SqlParameter("@WATERMETERTYPECLASSID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELWATERMETERTYPECLASS MODELWATERMETERTYPECLASS)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE WATERMETERTYPECLASS SET WATERMETERTYPECLASSNAME=@WATERMETERTYPECLASSNAME,MEMO=@MEMO ");
           str.Append("WHERE WATERMETERTYPECLASSID=@WATERMETERTYPECLASSID");
           SqlParameter[] para =
           {
               new SqlParameter("@WATERMETERTYPECLASSNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@WATERMETERTYPECLASSID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELWATERMETERTYPECLASS.WATERMETERTYPECLASSNAME;
           para[1].Value = MODELWATERMETERTYPECLASS.MEMO;
           para[2].Value = MODELWATERMETERTYPECLASS.WATERMETERTYPECLASSID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELWATERMETERTYPECLASS MODELWATERMETERTYPECLASS)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO WATERMETERTYPECLASS(WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,MEMO) ");
           str.Append("VALUES(@WATERMETERTYPECLASSID,@WATERMETERTYPECLASSNAME,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@WATERMETERTYPECLASSID",SqlDbType.VarChar,30),
               new SqlParameter("@WATERMETERTYPECLASSNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELWATERMETERTYPECLASS.WATERMETERTYPECLASSID;
           para[1].Value = MODELWATERMETERTYPECLASS.WATERMETERTYPECLASSNAME;
           para[2].Value = MODELWATERMETERTYPECLASS.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
