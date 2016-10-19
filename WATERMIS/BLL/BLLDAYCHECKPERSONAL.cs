using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLDAYCHECKPERSONAL
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM DAYCHECKPERSONAL WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Insert(MODELDAYCHECKPERSONAL MODELDAYCHECKPERSONAL)
       {
           StringBuilder str = new StringBuilder();
           str.Append(
               "INSERT INTO DAYCHECKPERSONAL(DAYCHECKID,DAYCHECKDATEIME,DAYCHECKWORKERID,DAYCHECKWORKERNAME," +
               "DAYCHECKSUMMONEY,DAYCHECKMONEY,DAYCHECKPOS,DAYCHECKZHUANZHANG,RECEIPTNOCOUNT,INVOICENOCOUNT,MEMO) " +
               "VALUES(@DAYCHECKID,@DAYCHECKDATEIME,@DAYCHECKWORKERID,@DAYCHECKWORKERNAME," +
               "@DAYCHECKSUMMONEY,@DAYCHECKMONEY,@DAYCHECKPOS,@DAYCHECKZHUANZHANG,@RECEIPTNOCOUNT,@INVOICENOCOUNT,@MEMO) "
               );
           SqlParameter[] para =
           {
               new SqlParameter("@DAYCHECKID",SqlDbType.VarChar,50),
               new SqlParameter("@DAYCHECKDATEIME",SqlDbType.DateTime),
               new SqlParameter("@DAYCHECKWORKERID",SqlDbType.VarChar,50),
               new SqlParameter("@DAYCHECKWORKERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@DAYCHECKSUMMONEY",SqlDbType.Decimal),
               new SqlParameter("@DAYCHECKMONEY",SqlDbType.Decimal),
               new SqlParameter("@DAYCHECKPOS",SqlDbType.Decimal),
               new SqlParameter("@DAYCHECKZHUANZHANG",SqlDbType.Decimal),
               new SqlParameter("@RECEIPTNOCOUNT",SqlDbType.Int),
               new SqlParameter("@INVOICENOCOUNT",SqlDbType.Int),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELDAYCHECKPERSONAL.DAYCHECKID;
           para[1].Value = MODELDAYCHECKPERSONAL.DAYCHECKDATEIME;
           para[2].Value = MODELDAYCHECKPERSONAL.DAYCHECKWORKERID;
           para[3].Value = MODELDAYCHECKPERSONAL.DAYCHECKWORKERNAME;
           para[4].Value = MODELDAYCHECKPERSONAL.DAYCHECKSUMMONEY;
           para[5].Value = MODELDAYCHECKPERSONAL.DAYCHECKMONEY;
           para[6].Value = MODELDAYCHECKPERSONAL.DAYCHECKPOS;
           para[7].Value = MODELDAYCHECKPERSONAL.DAYCHECKZHUANZHANG;
           para[8].Value = MODELDAYCHECKPERSONAL.RECEIPTNOCOUNT;
           para[9].Value = MODELDAYCHECKPERSONAL.INVOICENOCOUNT;
           para[10].Value = MODELDAYCHECKPERSONAL.MEMO;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
        /// <summary>
        /// 更新审核状态
        /// </summary>
        /// <param name="MODELDAYCHECKPERSONAL"></param>
        /// <returns></returns>
       public bool UpdateCheckState(MODELDAYCHECKPERSONAL MODELDAYCHECKPERSONAL)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE DAYCHECKPERSONAL SET CHECKERID=@CHECKERID,CHECKERNAME=@CHECKERNAME,CHECKDATETIME=@CHECKDATETIME WHERE DAYCHECKID=@DAYCHECKID");
           SqlParameter[] para =
           {
               new SqlParameter("@CHECKERID",SqlDbType.VarChar,30),
               new SqlParameter("@CHECKERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@CHECKDATETIME",SqlDbType.DateTime),
               new SqlParameter("@DAYCHECKID",SqlDbType.VarChar,30),
           };
           para[0].Value = MODELDAYCHECKPERSONAL.CHECKERID;
           para[1].Value = MODELDAYCHECKPERSONAL.CHECKERNAME;
           if (MODELDAYCHECKPERSONAL.CHECKERID == null)
               para[2].Value = null;
           else
           para[2].Value = MODELDAYCHECKPERSONAL.CHECKDATETIME;
           para[3].Value = MODELDAYCHECKPERSONAL.DAYCHECKID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM DAYCHECKPERSONAL WHERE DAYCHECKID=@DAYCHECKID");
           SqlParameter[] para =
           {
               new SqlParameter("@DAYCHECKID",SqlDbType.VarChar,30)
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
       public int Excute(string strSQL)
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
