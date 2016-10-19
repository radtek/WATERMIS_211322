using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
   public class BLLAREA
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM base_area WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM base_area WHERE areaId=@areaId");
           SqlParameter[] para =
           {
               new SqlParameter("@areaId",SqlDbType.VarChar,30)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELbase_area MODELbase_area)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE base_area SET areaName=@areaName,MEMO=@MEMO ");
           str.Append("WHERE areaId=@areaId");
           SqlParameter[] para =
           {
               new SqlParameter("@areaName",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@areaId",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELbase_area.areaName;
           para[1].Value = MODELbase_area.MEMO;
           para[2].Value = MODELbase_area.areaId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELbase_area MODELbase_area)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO base_area(areaId,areaName,PARENTID,MEMO) ");
           str.Append("VALUES(@areaId,@areaName,@PARENTID,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@areaId",SqlDbType.VarChar,30),
               new SqlParameter("@areaName",SqlDbType.VarChar,50),
               new SqlParameter("@PARENTID",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELbase_area.areaId;
           para[1].Value = MODELbase_area.areaName;
           para[2].Value = MODELbase_area.PARENTID;
           para[3].Value = MODELbase_area.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public MODELbase_area GetModelbase_area(string strDepID)
       {
           DataTable dt = new DataTable();
           MODELbase_area MODELbase_area = new MODELbase_area();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM base_area WHERE areaId=@areaId");
           SqlParameter[] para =
           {
               new SqlParameter("@areaId",SqlDbType.VarChar,30)
           };
           para[0].Value = strDepID;
           dt = DBUtility.DbHelperSQL.Query(str.ToString(), para).Tables[0];
           if (dt.Rows.Count == 0)
               return null;
           else
           {
               MODELbase_area.areaName = dt.Rows[0]["areaName"].ToString();
               if (dt.Rows[0]["PARENTID"] != null)
                   MODELbase_area.PARENTID = dt.Rows[0]["PARENTID"].ToString();
               if (dt.Rows[0]["MEMO"] != null)
                   MODELbase_area.MEMO = dt.Rows[0]["MEMO"].ToString();
               return MODELbase_area;
           }
       }
    }
}
