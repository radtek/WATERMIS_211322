using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLWATERFEEREMIT
    {
       public DataTable Query(string strFilter)
       {
           DataTable dt=new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM WATERFEEREMIT WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()+strFilter).Tables[0];
           return dt;
       }
        /// <summary>
        /// 查询包含减免单号的抄表记录视图
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
       public DataTable QueryView(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_WATERFEEREMIT WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       public bool Delete(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM WATERFEEREMIT WHERE WATERFEEREMITID=@WATERFEEREMITID");
           SqlParameter[] para =
           {
               new SqlParameter("@WATERFEEREMITID",SqlDbType.VarChar,30)
           };
           para[0].Value = strID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELWATERFEEREMIT MODELWATERFEEREMIT)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE WATERFEEREMIT SET REMITWATERFEE=@REMITWATERFEE,REMITEXTRAFEE=@REMITEXTRAFEE,REMITOVERDUE=@REMITOVERDUE,"+
               "READMETERRECORDID=@READMETERRECORDID,REMITWORKERID=@REMITWORKERID,REMITWORKERNAME=@REMITWORKERNAME,REMITDATETIME=@REMITDATETIME,MEMO=@MEMO ");
           str.Append("WHERE WATERFEEREMITID=@WATERFEEREMITID");
           SqlParameter[] para =
           {
               new SqlParameter("@REMITWATERFEE",SqlDbType.Decimal),
               new SqlParameter("@REMITEXTRAFEE",SqlDbType.Decimal),
               new SqlParameter("@REMITOVERDUE",SqlDbType.Decimal),
               new SqlParameter("@READMETERRECORDID",SqlDbType.VarChar,30),
               new SqlParameter("@REMITWORKERID",SqlDbType.VarChar,30),
               new SqlParameter("@REMITWORKERNAME",SqlDbType.VarChar,10),
               new SqlParameter("@REMITDATETIME",SqlDbType.DateTime),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@WATERFEEREMITID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELWATERFEEREMIT.REMITWATERFEE;
           para[1].Value = MODELWATERFEEREMIT.REMITEXTRAFEE;
           para[2].Value=MODELWATERFEEREMIT.REMITOVERDUE;
           para[3].Value = MODELWATERFEEREMIT.READMETERRECORDID;
           para[4].Value = MODELWATERFEEREMIT.REMITWORKERID;
           para[5].Value = MODELWATERFEEREMIT.REMITWORKERNAME;
           para[6].Value = MODELWATERFEEREMIT.REMITDATETIME;
           para[7].Value = MODELWATERFEEREMIT.MEMO;
           para[8].Value = MODELWATERFEEREMIT.WATERFEEREMITID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
        /// <summary>
        /// 更新减免记录作废状态
        /// </summary>
        /// <param name="MODELWATERFEEREMIT"></param>
        /// <returns></returns>
       public bool UpdateCancel(MODELWATERFEEREMIT MODELWATERFEEREMIT)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE WATERFEEREMIT SET REMITCANCEL=@REMITCANCEL,CANCELWORKERID=@CANCELWORKERID,CANCELWORKERNAME=@CANCELWORKERNAME,CANCELDATETIME=@CANCELDATETIME ");
           str.Append("WHERE WATERFEEREMITID=@WATERFEEREMITID");
           SqlParameter[] para =
           {
               new SqlParameter("@REMITCANCEL",SqlDbType.VarChar,10),
               new SqlParameter("@CANCELWORKERID",SqlDbType.VarChar,50),
               new SqlParameter("@CANCELWORKERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@CANCELDATETIME",SqlDbType.DateTime),
               new SqlParameter("@WATERFEEREMITID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELWATERFEEREMIT.REMITCANCEL;
           para[1].Value = MODELWATERFEEREMIT.CANCELWORKERID;
           para[2].Value = MODELWATERFEEREMIT.CANCELWORKERNAME;
           para[3].Value = MODELWATERFEEREMIT.CANCELDATETIME;
           para[4].Value = MODELWATERFEEREMIT.WATERFEEREMITID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Insert(MODELWATERFEEREMIT MODELWATERFEEREMIT)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO WATERFEEREMIT(WATERFEEREMITID,REMITWATERFEE,REMITEXTRAFEE,REMITOVERDUE,READMETERRECORDID,REMITWORKERID,REMITWORKERNAME,REMITDATETIME,MEMO) ");
           str.Append("VALUES(@WATERFEEREMITID,@REMITWATERFEE,@REMITEXTRAFEE,@REMITOVERDUE,@READMETERRECORDID,@REMITWORKERID,@REMITWORKERNAME,@REMITDATETIME,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@WATERFEEREMITID",SqlDbType.VarChar,50),
               new SqlParameter("@REMITWATERFEE",SqlDbType.VarChar,50),
               new SqlParameter("@REMITEXTRAFEE",SqlDbType.VarChar,30),
               new SqlParameter("@REMITOVERDUE",SqlDbType.VarChar,50),
               new SqlParameter("@READMETERRECORDID",SqlDbType.VarChar,50),
               new SqlParameter("@REMITWORKERID",SqlDbType.VarChar,50),
               new SqlParameter("@REMITWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@REMITDATETIME",SqlDbType.DateTime),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200)
           };
           para[0].Value = MODELWATERFEEREMIT.WATERFEEREMITID;
           para[1].Value = MODELWATERFEEREMIT.REMITWATERFEE;
           para[2].Value = MODELWATERFEEREMIT.REMITEXTRAFEE;
           para[3].Value = MODELWATERFEEREMIT.REMITOVERDUE;
           para[4].Value = MODELWATERFEEREMIT.READMETERRECORDID;
           para[5].Value = MODELWATERFEEREMIT.REMITWORKERID;
           para[6].Value = MODELWATERFEEREMIT.REMITWORKERNAME;
           para[7].Value = MODELWATERFEEREMIT.REMITDATETIME;
           para[8].Value = MODELWATERFEEREMIT.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
