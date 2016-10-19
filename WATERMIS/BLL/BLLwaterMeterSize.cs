using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
   public class BLLwaterMeterSize
   {
       public DataTable Query(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterMeterSizeId,waterMeterSizeValue,waterLossComputeType,(CASE waterLossComputeType WHEN '1' THEN '按比例' WHEN '0' THEN '固定水量' END) AS waterLossComputeTypeS,checkPeriod,waterLossValue,memo FROM dbo.waterMeterSize WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       public bool Delete(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM dbo.waterMeterSize WHERE waterMeterSizeId=@waterMeterSizeId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterSizeId",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELwaterMeterSize MODELwaterMeterSize)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE dbo.waterMeterSize SET waterMeterSizeValue=@waterMeterSizeValue,waterLossComputeType=@waterLossComputeType,checkPeriod=@checkPeriod,waterLossValue=@waterLossValue,MEMO=@MEMO ");
           str.Append("WHERE waterMeterSizeId=@waterMeterSizeId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterSizeValue",SqlDbType.VarChar,50),
               new SqlParameter("@waterLossComputeType",SqlDbType.VarChar,10),
               new SqlParameter("@checkPeriod",SqlDbType.Int),
               new SqlParameter("@waterLossValue",SqlDbType.Float),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@waterMeterSizeId",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELwaterMeterSize.waterMeterSizeValue;
           para[1].Value = MODELwaterMeterSize.waterLossComputeType;
           para[2].Value = MODELwaterMeterSize.checkPeriod;
           para[3].Value = MODELwaterMeterSize.waterLossValue;
           para[4].Value = MODELwaterMeterSize.MEMO;
           para[5].Value = MODELwaterMeterSize.waterMeterSizeId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Insert(MODELwaterMeterSize MODELwaterMeterSize)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO dbo.waterMeterSize(waterMeterSizeId,waterMeterSizeValue,waterLossComputeType,checkPeriod,waterLossValue,MEMO) ");
           str.Append("VALUES(@waterMeterSizeId,@waterMeterSizeValue,@waterLossComputeType,@checkPeriod,@waterLossValue,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterSizeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterSizeValue",SqlDbType.VarChar,50),
               new SqlParameter("@waterLossComputeType",SqlDbType.VarChar,10),
               new SqlParameter("@checkPeriod",SqlDbType.Int),
               new SqlParameter("@waterLossValue",SqlDbType.Float),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200)
           };
           para[0].Value = MODELwaterMeterSize.waterMeterSizeId;
           para[1].Value = MODELwaterMeterSize.waterMeterSizeValue;
           para[2].Value = MODELwaterMeterSize.waterLossComputeType;
           para[3].Value = MODELwaterMeterSize.checkPeriod;
           para[4].Value = MODELwaterMeterSize.waterLossValue;
           para[5].Value = MODELwaterMeterSize.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
