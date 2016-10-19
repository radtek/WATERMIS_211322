using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLEXTRACHARGE
   {
       public DataTable Query(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT extraChargeID,extraChargeName,extraChargeValue,(CASE extraChargeState WHEN '1' THEN '启用' ELSE '未启用' END) AS extraChargeState,memo FROM extraCharge WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       public bool Delete(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM extraCharge WHERE extraChargeID=@extraChargeID");
           SqlParameter[] para =
           {
               new SqlParameter("@extraChargeID",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELEXTRACHARGE MODELEXTRACHARGE)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE extraCharge SET extraChargeName=@extraChargeName,extraChargeValue=@extraChargeValue,extraChargeState=@extraChargeState,MEMO=@MEMO ");
           str.Append("WHERE extraChargeID=@extraChargeID");
           SqlParameter[] para =
           {
               new SqlParameter("@extraChargeName",SqlDbType.VarChar,50),
               new SqlParameter("@extraChargeValue",SqlDbType.Float),
               new SqlParameter("@extraChargeState",SqlDbType.VarChar,10),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@extraChargeID",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELEXTRACHARGE.extraChargeName;
           para[1].Value = MODELEXTRACHARGE.extraChargeValue;
           para[2].Value = MODELEXTRACHARGE.extraChargeState;
           para[3].Value = MODELEXTRACHARGE.MEMO;
           para[4].Value = MODELEXTRACHARGE.extraChargeID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Insert(MODELEXTRACHARGE MODELEXTRACHARGE)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO dbo.extraCharge(extraChargeID,extraChargeName,extraChargeValue,extraChargeState,MEMO) ");
           str.Append("VALUES(@extraChargeID,@extraChargeName,@extraChargeValue,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@extraChargeID",SqlDbType.VarChar,30),
               new SqlParameter("@extraChargeName",SqlDbType.VarChar,50),
               new SqlParameter("@extraChargeValue",SqlDbType.Float),
               new SqlParameter("@extraChargeState",SqlDbType.VarChar,10),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200)
           };
           para[0].Value = MODELEXTRACHARGE.extraChargeID;
           para[1].Value = MODELEXTRACHARGE.extraChargeName;
           para[2].Value = MODELEXTRACHARGE.extraChargeValue;
           para[3].Value = MODELEXTRACHARGE.extraChargeState;
           para[4].Value = MODELEXTRACHARGE.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
