using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLSETTLEACCOUNTYS
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM SETTLEACCOUNTYS WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Insert(MODELSETTLEACCOUNTYS MODELSETTLEACCOUNTYS)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO SETTLEACCOUNTYS(SETTLEACCOUNTSYSID,ACCOUNTSYEARANDMONTH,ACCOUNTSDATETIME,ACCOUNTSWORKERID,ACCOUNTSWORKERNAME,"+
               "WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,waterMeterTypeId,waterMeterTypeName,WATERUSERCOUNT,YSHSCOUNT,TOTALNUMBER,"+
               "WATERTOTALCHARGE,EXTRACHARGE1,EXTRACHARGE2,TOTALCHARGE,OVERDUEMONEY,TOTALCHARGEEND,TOTALCHARGEUNGET,TOTALCHARGEGET,"+
               "WATERUSERPRESTORE,LJQF,JSYE) ");
           str.Append("VALUES(@SETTLEACCOUNTSYSID,@ACCOUNTSYEARANDMONTH,@ACCOUNTSDATETIME,@ACCOUNTSWORKERID,@ACCOUNTSWORKERNAME,"+
               "@WATERMETERTYPECLASSID,@WATERMETERTYPECLASSNAME,@waterMeterTypeId,@waterMeterTypeName,@WATERUSERCOUNT,@YSHSCOUNT,@TOTALNUMBER,"+
               "@WATERTOTALCHARGE,@EXTRACHARGE1,@EXTRACHARGE2,@TOTALCHARGE,@OVERDUEMONEY,@TOTALCHARGEEND,@TOTALCHARGEUNGET,@TOTALCHARGEGET,"+
               "@WATERUSERPRESTORE,@LJQF,@JSYE) ");
           SqlParameter[] para =
           {
               new SqlParameter("@SETTLEACCOUNTSYSID",SqlDbType.VarChar,30),
               new SqlParameter("@ACCOUNTSYEARANDMONTH",SqlDbType.Date),
               new SqlParameter("@ACCOUNTSDATETIME",SqlDbType.DateTime),
               new SqlParameter("@ACCOUNTSWORKERID",SqlDbType.VarChar,30),
               new SqlParameter("@ACCOUNTSWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@WATERMETERTYPECLASSID",SqlDbType.VarChar,30),
               new SqlParameter("@WATERMETERTYPECLASSNAME",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeName",SqlDbType.VarChar,30),
               new SqlParameter("@WATERUSERCOUNT",SqlDbType.Int),
               new SqlParameter("@YSHSCOUNT",SqlDbType.Int),
               new SqlParameter("@TOTALNUMBER",SqlDbType.Int),
               new SqlParameter("@WATERTOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@EXTRACHARGE1",SqlDbType.Decimal),
               new SqlParameter("@EXTRACHARGE2",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@OVERDUEMONEY",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGEEND",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGEUNGET",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGEGET",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERPRESTORE",SqlDbType.Decimal),
               new SqlParameter("@LJQF",SqlDbType.Decimal),
               new SqlParameter("@JSYE",SqlDbType.Decimal),
           };

           para[0].Value = MODELSETTLEACCOUNTYS.SETTLEACCOUNTSYSID;
           para[1].Value = MODELSETTLEACCOUNTYS.ACCOUNTSYEARANDMONTH;
           para[2].Value = MODELSETTLEACCOUNTYS.ACCOUNTSDATETIME;
           para[3].Value = MODELSETTLEACCOUNTYS.ACCOUNTSWORKERID;
           para[4].Value = MODELSETTLEACCOUNTYS.ACCOUNTSWORKERNAME;
           para[5].Value = MODELSETTLEACCOUNTYS.WATERMETERTYPECLASSID;
           para[6].Value = MODELSETTLEACCOUNTYS.WATERMETERTYPECLASSNAME;
           para[7].Value = MODELSETTLEACCOUNTYS.waterMeterTypeId;
           para[8].Value = MODELSETTLEACCOUNTYS.waterMeterTypeName;
           para[9].Value = MODELSETTLEACCOUNTYS.WATERUSERCOUNT;
           para[10].Value = MODELSETTLEACCOUNTYS.YSHSCOUNT;
           para[11].Value = MODELSETTLEACCOUNTYS.TOTALNUMBER;
           para[12].Value = MODELSETTLEACCOUNTYS.WATERTOTALCHARGE;
           para[13].Value = MODELSETTLEACCOUNTYS.EXTRACHARGE1;
           para[14].Value = MODELSETTLEACCOUNTYS.EXTRACHARGE2;
           para[15].Value = MODELSETTLEACCOUNTYS.TOTALCHARGE;
           para[16].Value = MODELSETTLEACCOUNTYS.OVERDUEMONEY;
           para[17].Value = MODELSETTLEACCOUNTYS.TOTALCHARGEEND;
           para[18].Value = MODELSETTLEACCOUNTYS.TOTALCHARGEUNGET;
           para[19].Value = MODELSETTLEACCOUNTYS.TOTALCHARGEGET;
           para[20].Value = MODELSETTLEACCOUNTYS.WATERUSERPRESTORE;
           para[21].Value = MODELSETTLEACCOUNTYS.LJQF;
           para[22].Value = MODELSETTLEACCOUNTYS.JSYE;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM SETTLEACCOUNTYS WHERE SETTLEACCOUNTSYSID=@SETTLEACCOUNTSYSID");
           SqlParameter[] para =
           {
               new SqlParameter("@SETTLEACCOUNTSYSID",SqlDbType.VarChar,30)
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
