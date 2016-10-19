using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLSETTLEACCOUNTSS
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM SETTLEACCOUNTSS WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Insert(MODELSETTLEACCOUNTSS MODELSETTLEACCOUNTSS)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO SETTLEACCOUNTSS(SETTLEACCOUNTSSSID,ACCOUNTSYEARANDMONTH,ACCOUNTSDATETIME,ACCOUNTSWORKERID,ACCOUNTSWORKERNAME," +
               "WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,waterMeterTypeId,waterMeterTypeName,BILLCOUNT,INVOICECOUNT,RECEIPTNOCOUNT,TOTALNUMBER,"+
               "WATERTOTALCHARGE,EXTRACHARGE1,EXTRACHARGE2,TOTALCHARGE,OVERDUEMONEY,TOTALCHARGEEND,YCZJ,SSJE,SSTYPE) ");
           str.Append("VALUES(@SETTLEACCOUNTSSSID,@ACCOUNTSYEARANDMONTH,@ACCOUNTSDATETIME,@ACCOUNTSWORKERID,@ACCOUNTSWORKERNAME,"+
               "@WATERMETERTYPECLASSID,@WATERMETERTYPECLASSNAME,@waterMeterTypeId,@waterMeterTypeName,@BILLCOUNT,@INVOICECOUNT,@RECEIPTNOCOUNT,@TOTALNUMBER,"+
               "@WATERTOTALCHARGE,@EXTRACHARGE1,@EXTRACHARGE2,@TOTALCHARGE,@OVERDUEMONEY,@TOTALCHARGEEND,@YCZJ,@SSJE,@SSTYPE) ");
           SqlParameter[] para =
           {
               new SqlParameter("@SETTLEACCOUNTSSSID",SqlDbType.VarChar,30),
               new SqlParameter("@ACCOUNTSYEARANDMONTH",SqlDbType.Date),
               new SqlParameter("@ACCOUNTSDATETIME",SqlDbType.DateTime),
               new SqlParameter("@ACCOUNTSWORKERID",SqlDbType.VarChar,30),
               new SqlParameter("@ACCOUNTSWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@WATERMETERTYPECLASSID",SqlDbType.VarChar,30),
               new SqlParameter("@WATERMETERTYPECLASSNAME",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeName",SqlDbType.VarChar,30),
               new SqlParameter("@BILLCOUNT",SqlDbType.Int),
               new SqlParameter("@INVOICECOUNT",SqlDbType.Int),
               new SqlParameter("@RECEIPTNOCOUNT",SqlDbType.Int),
               new SqlParameter("@TOTALNUMBER",SqlDbType.Int),
               new SqlParameter("@WATERTOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@EXTRACHARGE1",SqlDbType.Decimal),
               new SqlParameter("@EXTRACHARGE2",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@OVERDUEMONEY",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGEEND",SqlDbType.Decimal),
               new SqlParameter("@YCZJ",SqlDbType.Decimal),
               new SqlParameter("@SSJE",SqlDbType.Decimal),
               new SqlParameter("@SSTYPE",SqlDbType.VarChar,30),
           };

           para[0].Value = MODELSETTLEACCOUNTSS.SETTLEACCOUNTSSSID;
           para[1].Value = MODELSETTLEACCOUNTSS.ACCOUNTSYEARANDMONTH;
           para[2].Value = MODELSETTLEACCOUNTSS.ACCOUNTSDATETIME;
           para[3].Value = MODELSETTLEACCOUNTSS.ACCOUNTSWORKERID;
           para[4].Value = MODELSETTLEACCOUNTSS.ACCOUNTSWORKERNAME;
           para[5].Value = MODELSETTLEACCOUNTSS.WATERMETERTYPECLASSID;
           para[6].Value = MODELSETTLEACCOUNTSS.WATERMETERTYPECLASSNAME;
           para[7].Value = MODELSETTLEACCOUNTSS.waterMeterTypeId;
           para[8].Value = MODELSETTLEACCOUNTSS.waterMeterTypeName;
           para[9].Value = MODELSETTLEACCOUNTSS.BILLCOUNT;
           para[10].Value = MODELSETTLEACCOUNTSS.INVOICECOUNT;
           para[11].Value = MODELSETTLEACCOUNTSS.RECEIPTNOCOUNT;
           para[12].Value = MODELSETTLEACCOUNTSS.TOTALNUMBER;
           para[13].Value = MODELSETTLEACCOUNTSS.WATERTOTALCHARGE;
           para[14].Value = MODELSETTLEACCOUNTSS.EXTRACHARGE1;
           para[15].Value = MODELSETTLEACCOUNTSS.EXTRACHARGE2;
           para[16].Value = MODELSETTLEACCOUNTSS.TOTALCHARGE;
           para[17].Value = MODELSETTLEACCOUNTSS.OVERDUEMONEY;
           para[18].Value = MODELSETTLEACCOUNTSS.TOTALCHARGEEND;
           para[19].Value = MODELSETTLEACCOUNTSS.YCZJ;
           para[20].Value = MODELSETTLEACCOUNTSS.SSJE;
           para[21].Value = MODELSETTLEACCOUNTSS.SSTYPE;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM SETTLEACCOUNTSS WHERE SETTLEACCOUNTSSSID=@SETTLEACCOUNTSSSID");
           SqlParameter[] para =
           {
               new SqlParameter("@SETTLEACCOUNTSSSID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       /// <summary>
       /// 执行自定义语句
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public int ExcuteSQL(string strSQL)
       {
           int intCount = DBUtility.DbHelperSQL.ExecuteSql(strSQL);
           return intCount;
           //if (DBUtility.DbHelperSQL.ExecuteSql(strSQL) > 0)
           //    return true;
           //else
           //    return false;
       }
    }
}
