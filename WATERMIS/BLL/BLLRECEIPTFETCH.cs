using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLRECEIPTFETCH
    {
       public DataTable Query(string strFilter)
       {
           DataTable dt=new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM RECEIPTFETCH WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()+strFilter).Tables[0];
           return dt;
       }
       public bool Delete(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM RECEIPTFETCH WHERE RECEIPTFETCHID=@RECEIPTFETCHID");
           SqlParameter[] para =
           {
               new SqlParameter("@RECEIPTFETCHID",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELRECEIPTFETCH MODELRECEIPTFETCH)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE RECEIPTFETCH SET RECEIPTFETCHERID=@RECEIPTFETCHERID,RECEIPTFETCHERNAME=@RECEIPTFETCHERNAME,RECEIPTFETCHDEPID=@RECEIPTFETCHDEPID," +
               "RECEIPTFETCHDEPNAME=@RECEIPTFETCHDEPNAME,RECEIPTFETCHSTARTNO=@RECEIPTFETCHSTARTNO,"+
               "RECEIPTFETCHENDNO=@RECEIPTFETCHENDNO,MEMO=@MEMO");
           str.Append(" WHERE RECEIPTFETCHID=@RECEIPTFETCHID");
           SqlParameter[] para =
           {
               new SqlParameter("@RECEIPTFETCHERID",SqlDbType.VarChar,30),
               new SqlParameter("@RECEIPTFETCHERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@RECEIPTFETCHDEPID",SqlDbType.VarChar,50),
               new SqlParameter("@RECEIPTFETCHDEPNAME",SqlDbType.VarChar,50),
               new SqlParameter("@RECEIPTFETCHSTARTNO",SqlDbType.VarChar,30),
               new SqlParameter("@RECEIPTFETCHENDNO",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@RECEIPTFETCHID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELRECEIPTFETCH.RECEIPTFETCHERID;
           para[1].Value = MODELRECEIPTFETCH.RECEIPTFETCHERNAME;
           para[2].Value = MODELRECEIPTFETCH.RECEIPTFETCHDEPID;
           para[3].Value = MODELRECEIPTFETCH.RECEIPTFETCHDEPNAME;
           para[4].Value = MODELRECEIPTFETCH.RECEIPTFETCHSTARTNO;
           para[5].Value=MODELRECEIPTFETCH.RECEIPTFETCHENDNO;
           para[6].Value = MODELRECEIPTFETCH.MEMO;
           para[7].Value = MODELRECEIPTFETCH.RECEIPTFETCHID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
       public bool Insert(MODELRECEIPTFETCH MODELRECEIPTFETCH)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO RECEIPTFETCH(RECEIPTFETCHERID,RECEIPTFETCHERNAME,RECEIPTFETCHDEPID,RECEIPTFETCHDEPNAME,RECEIPTFETCHDATETIME,RECEIPTFETCHSTARTNO,RECEIPTFETCHENDNO,MEMO) ");
           str.Append("VALUES(@RECEIPTFETCHERID,@RECEIPTFETCHERNAME,@RECEIPTFETCHDEPID,@RECEIPTFETCHDEPNAME,@RECEIPTFETCHDATETIME,@RECEIPTFETCHSTARTNO,@RECEIPTFETCHENDNO,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@RECEIPTFETCHERID",SqlDbType.VarChar,50),
               new SqlParameter("@RECEIPTFETCHERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@RECEIPTFETCHDEPID",SqlDbType.VarChar,50),
               new SqlParameter("@RECEIPTFETCHDEPNAME",SqlDbType.VarChar,50),
               new SqlParameter("@RECEIPTFETCHDATETIME",SqlDbType.DateTime),
               new SqlParameter("@RECEIPTFETCHSTARTNO",SqlDbType.VarChar,10),
               new SqlParameter("@RECEIPTFETCHENDNO",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200)
           };
           para[0].Value = MODELRECEIPTFETCH.RECEIPTFETCHERID;
           para[1].Value = MODELRECEIPTFETCH.RECEIPTFETCHERNAME;
           para[2].Value = MODELRECEIPTFETCH.RECEIPTFETCHDEPID;
           para[3].Value = MODELRECEIPTFETCH.RECEIPTFETCHDEPNAME;
           para[4].Value = MODELRECEIPTFETCH.RECEIPTFETCHDATETIME;
           para[5].Value = MODELRECEIPTFETCH.RECEIPTFETCHSTARTNO;
           para[6].Value = MODELRECEIPTFETCH.RECEIPTFETCHENDNO;
           para[7].Value = MODELRECEIPTFETCH.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
