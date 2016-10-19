using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLOPERATORLOG
    {
       public DataTable Query(string strFilter)
       {
           DataTable dt=new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT LOGID,LOGTYPE,OPERATORLOG.METERREADINGID,meterReadingNO,LOGCONTENT,LOGDATETIME,OPERATORID,OPERATORNAME FROM OPERATORLOG LEFT JOIN meterReading ON meterReading.METERREADINGID=OPERATORLOG.METERREADINGID WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()+strFilter).Tables[0];
           return dt;
       }

       public int Delete(string strFilter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM OPERATORLOG WHERE 1=1");
           int intCount = DBUtility.DbHelperSQL.ExecuteSql(str.ToString() + strFilter);
           return intCount;
       }

       public bool Insert(MODELOPERATORLOG MODELOPERATORLOG)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO OPERATORLOG(LOGTYPE,METERREADINGID,LOGCONTENT,LOGDATETIME,OPERATORID,OPERATORNAME,MEMO) ");
           str.Append("VALUES(@LOGTYPE,@METERREADINGID,@LOGCONTENT,GETDATE(),@OPERATORID,@OPERATORNAME,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@LOGTYPE",SqlDbType.VarChar,10),
               new SqlParameter("@METERREADINGID",SqlDbType.VarChar,30),
               new SqlParameter("@LOGCONTENT",SqlDbType.VarChar,1000),
               new SqlParameter("@OPERATORID",SqlDbType.VarChar,30),
               new SqlParameter("@OPERATORNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELOPERATORLOG.LOGTYPE;
           para[1].Value = MODELOPERATORLOG.METERREADINGID;
           para[2].Value = MODELOPERATORLOG.LOGCONTENT;
           para[3].Value = MODELOPERATORLOG.OPERATORID;
           para[4].Value = MODELOPERATORLOG.OPERATORNAME;
           para[5].Value = MODELOPERATORLOG.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
