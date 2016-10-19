using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
   public class BLLINFORMCANCELRECORD
   {
       public DataTable Query(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM readMeterRecord INNER JOIN INFORMCANCELRECORD ON readMeterRecord.readMeterRecordId=INFORMCANCELRECORD.READMETERRECORDID WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 增加通知单作废记录
       /// </summary>
       /// <param name="MODELINFORMCANCELRECORD"></param>
       /// <returns></returns>
       public bool Insert(MODELINFORMCANCELRECORD MODELINFORMCANCELRECORD)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO INFORMCANCELRECORD(INFORMCANCELID,INFORMNO,READMETERRECORDID,OPERATORID,OPERATORNAME,OPERATORDATETIME,CANCELREASON,MEMO)" +
               " VALUES(@INFORMCANCELID,@INFORMNO,@READMETERRECORDID,@OPERATORID,@OPERATORNAME,@OPERATORDATETIME,@CANCELREASON,@MEMO)");

           SqlParameter[] para =
           {
               new SqlParameter("@INFORMCANCELID",SqlDbType.VarChar,50),
               new SqlParameter("@INFORMNO",SqlDbType.VarChar,50),
               new SqlParameter("@READMETERRECORDID",SqlDbType.VarChar,50),
               new SqlParameter("@OPERATORID",SqlDbType.VarChar,50),
               new SqlParameter("@OPERATORNAME",SqlDbType.VarChar,50),
               new SqlParameter("@OPERATORDATETIME",SqlDbType.DateTime),
               new SqlParameter("@CANCELREASON",SqlDbType.VarChar,200),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };

           para[0].Value = MODELINFORMCANCELRECORD.INFORMCANCELID;
           para[1].Value = MODELINFORMCANCELRECORD.INFORMNO;
           para[2].Value = MODELINFORMCANCELRECORD.READMETERRECORDID;
           para[3].Value = MODELINFORMCANCELRECORD.OPERATORID;
           para[4].Value = MODELINFORMCANCELRECORD.OPERATORNAME;
           para[5].Value = MODELINFORMCANCELRECORD.OPERATORDATETIME;
           para[6].Value = MODELINFORMCANCELRECORD.CANCELREASON;
           para[7].Value = MODELINFORMCANCELRECORD.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 删除通知单作废记录
       /// </summary>
       /// <param name="MODELINFORMCANCELRECORD"></param>
       /// <returns></returns>
       public bool Delete(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM INFORMCANCELRECORD WHERE INFORMCANCELID=@INFORMCANCELID)");

           SqlParameter[] para =
           {
               new SqlParameter("@INFORMCANCELID",SqlDbType.VarChar,50)
           };

           para[0].Value = strID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
