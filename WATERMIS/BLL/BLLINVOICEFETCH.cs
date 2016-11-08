using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLINVOICEFETCH
    {
       public DataTable Query(string strFilter)
       {
           DataTable dt=new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_INVOICE_FETCH WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()+strFilter).Tables[0];
           return dt;
       }
       public bool Delete(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM INVOICEFETCH WHERE INVOICEFETCHID=@INVOICEFETCHID");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICEFETCHID",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELINVOICEFETCH MODELINVOICEFETCH)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE INVOICEFETCH SET INVOICEFETCHERID=@INVOICEFETCHERID,INVOICEFETCHERNAME=@INVOICEFETCHERNAME,INVOICEFETCHDEPID=@INVOICEFETCHDEPID," +
               "INVOICEFETCHDEPNAME=@INVOICEFETCHDEPNAME,INVOICEFETCHBATCHID=@INVOICEFETCHBATCHID,INVOICEFETCHSTARTNO=@INVOICEFETCHSTARTNO,"+
               "INVOICEFETCHENDNO=@INVOICEFETCHENDNO,ISENABLE=@ISENABLE,MEMO=@MEMO");
           str.Append(" WHERE INVOICEFETCHID=@INVOICEFETCHID");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICEFETCHERID",SqlDbType.VarChar,30),
               new SqlParameter("@INVOICEFETCHERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEFETCHDEPID",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEFETCHDEPNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEFETCHBATCHID",SqlDbType.Int),
               new SqlParameter("@INVOICEFETCHSTARTNO",SqlDbType.VarChar,30),
               new SqlParameter("@INVOICEFETCHENDNO",SqlDbType.VarChar,30),
               new SqlParameter("@ISENABLE",SqlDbType.VarChar,10),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@INVOICEFETCHID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELINVOICEFETCH.INVOICEFETCHERID;
           para[1].Value = MODELINVOICEFETCH.INVOICEFETCHERNAME;
           para[2].Value = MODELINVOICEFETCH.INVOICEFETCHDEPID;
           para[3].Value = MODELINVOICEFETCH.INVOICEFETCHDEPNAME;
           para[4].Value=MODELINVOICEFETCH.INVOICEFETCHBATCHID;
           para[5].Value = MODELINVOICEFETCH.INVOICEFETCHSTARTNO;
           para[6].Value=MODELINVOICEFETCH.INVOICEFETCHENDNO;
           para[7].Value = MODELINVOICEFETCH.ISENABLE;
           para[8].Value = MODELINVOICEFETCH.MEMO;
           para[9].Value = MODELINVOICEFETCH.INVOICEFETCHID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
       public bool Insert(MODELINVOICEFETCH MODELINVOICEFETCH)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO INVOICEFETCH(INVOICEFETCHERID,INVOICEFETCHERNAME,INVOICEFETCHDEPID,INVOICEFETCHDEPNAME,INVOICEFETCHDATETIME,INVOICEFETCHBATCHID,INVOICEFETCHSTARTNO,INVOICEFETCHENDNO,ISENABLE,MEMO) ");
           str.Append("VALUES(@INVOICEFETCHERID,@INVOICEFETCHERNAME,@INVOICEFETCHDEPID,@INVOICEFETCHDEPNAME,@INVOICEFETCHDATETIME,@INVOICEFETCHBATCHID,@INVOICEFETCHSTARTNO,@INVOICEFETCHENDNO,@ISENABLE,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICEFETCHERID",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEFETCHERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEFETCHDEPID",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEFETCHDEPNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEFETCHDATETIME",SqlDbType.DateTime),
               new SqlParameter("@INVOICEFETCHBATCHID",SqlDbType.Int),
               new SqlParameter("@INVOICEFETCHSTARTNO",SqlDbType.VarChar,10),
               new SqlParameter("@INVOICEFETCHENDNO",SqlDbType.VarChar,30),
               new SqlParameter("@ISENABLE",SqlDbType.VarChar,10),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200)
           };
           para[0].Value = MODELINVOICEFETCH.INVOICEFETCHERID;
           para[1].Value = MODELINVOICEFETCH.INVOICEFETCHERNAME;
           para[2].Value = MODELINVOICEFETCH.INVOICEFETCHDEPID;
           para[3].Value = MODELINVOICEFETCH.INVOICEFETCHDEPNAME;
           para[4].Value = MODELINVOICEFETCH.INVOICEFETCHDATETIME;
           para[5].Value = MODELINVOICEFETCH.INVOICEFETCHBATCHID;
           para[6].Value = MODELINVOICEFETCH.INVOICEFETCHSTARTNO;
           para[7].Value = MODELINVOICEFETCH.INVOICEFETCHENDNO;
           para[8].Value = MODELINVOICEFETCH.ISENABLE;
           para[9].Value = MODELINVOICEFETCH.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
        /// <summary>
        /// 获取有业扩最大发票号
        /// </summary>
        /// <param name="strLogID">登陆用户ID</param>
        /// <param name="strInvoiceBatchID">发票批次</param>
        /// <returns></returns>
       public DataTable GetMaxInvoiceNO_MeterWork(string strLogID, string strInvoiceBatchID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("SELECT TOP 1 INVOICEBATCHID,INVOICENO FROM Meter_WorkResolveFee_Invoice WHERE INVOICEPRINTWORKERID='" + strLogID + "' AND INVOICECANCEL<>'3' AND " +
               " INVOICEBATCHID='" + strInvoiceBatchID + "' ORDER BY INVOICEPRINTDATETIME DESC");
           DataTable dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];

           return dt;
       }
    }
}
