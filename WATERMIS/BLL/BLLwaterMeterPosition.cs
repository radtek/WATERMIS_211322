using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
   public class BLLwaterMeterPosition
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM waterMeterPosition WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM waterMeterPosition WHERE waterMeterPositionId=@waterMeterPositionId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterPositionId",SqlDbType.VarChar,30)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELwaterMeterPosition MODELwaterMeterPosition)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterMeterPosition SET waterMeterPositionName=@waterMeterPositionName,MEMO=@MEMO ");
           str.Append("WHERE waterMeterPositionId=@waterMeterPositionId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterPositionName",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterPositionId",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELwaterMeterPosition.waterMeterPositionName;
           para[1].Value = MODELwaterMeterPosition.MEMO;
           para[2].Value = MODELwaterMeterPosition.waterMeterPositionId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELwaterMeterPosition MODELwaterMeterPosition)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO waterMeterPosition(waterMeterPositionId,waterMeterPositionName,MEMO) ");
           str.Append("VALUES(@waterMeterPositionId,@waterMeterPositionName,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterPositionId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterPositionName",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELwaterMeterPosition.waterMeterPositionId;
           para[1].Value = MODELwaterMeterPosition.waterMeterPositionName;
           para[2].Value = MODELwaterMeterPosition.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
