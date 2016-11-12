using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
   public class BLLBASE_LOGIN
    {
       public DataTable QueryUser(string strFilter)
       {
           DataTable dt=new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_LOGIN WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()+strFilter).Tables[0];
           return dt;
       }
       public object QueryUserPost(string strID)
       {
           object obj;
           StringBuilder str = new StringBuilder();
           str.Append("SELECT TOP 1 POSTID FROM BASE_LOGIN WHERE LOGINID='" + strID + "'");
           obj = DBUtility.DbHelperSQL.GetSingle(str.ToString());
           return obj;
       }
       public bool DeleteUser(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM BASE_LOGIN WHERE LOGINID=@LOGINID");
           SqlParameter[] para =
           {
               new SqlParameter("@LOGINID",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
       public bool UpdateUser(MODELBASE_LOGIN MODELBASE_LOGIN)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE BASE_LOGIN SET LOGINNAME=@LOGINNAME,workNO=@workNO,USERNAME=@USERNAME,POSTID=@POSTID,"+
               "DEPARTMENTID=@DEPARTMENTID,MEMO=@MEMO,TELEPHONENO=@TELEPHONENO,isMeterReader=@isMeterReader,isCharger=@isCharger,"+
               "groupID=@groupID,userstate=@userstate,IsCashier=@IsCashier ");
           str.Append("WHERE LOGINID=@LOGINID");
           SqlParameter[] para =
           {
               new SqlParameter("@LOGINNAME",SqlDbType.VarChar,30),
               new SqlParameter("@workNO",SqlDbType.VarChar,50),
               new SqlParameter("@USERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@POSTID",SqlDbType.Int),
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@TELEPHONENO",SqlDbType.VarChar,50),
               new SqlParameter("@isMeterReader",SqlDbType.VarChar,10),
               new SqlParameter("@isCharger",SqlDbType.VarChar,10),
               new SqlParameter("@groupID",SqlDbType.VarChar,10),
               new SqlParameter("@userstate",SqlDbType.VarChar,10),
               new SqlParameter("@IsCashier",SqlDbType.VarChar,10),
               new SqlParameter("@LOGINID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELBASE_LOGIN.LOGINNAME;
           para[1].Value = MODELBASE_LOGIN.workNO;
           para[2].Value=MODELBASE_LOGIN.USERNAME;
           para[3].Value=MODELBASE_LOGIN.POSTID;
           para[4].Value=MODELBASE_LOGIN.DEPARTMENTID;
           para[5].Value = MODELBASE_LOGIN.MEMO;
           para[6].Value = MODELBASE_LOGIN.TELEPHONENO;
           para[7].Value = MODELBASE_LOGIN.isMeterReader;
           para[8].Value = MODELBASE_LOGIN.isCharger;
           para[9].Value = MODELBASE_LOGIN.groupID;
           para[10].Value = MODELBASE_LOGIN.userstate;
           para[11].Value = MODELBASE_LOGIN.IsCashier;
           para[12].Value = MODELBASE_LOGIN.LOGINID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
       public bool UpdateUserPWD(string strLogID,string strPWD)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE BASE_LOGIN SET LOGINPASSWORD=@LOGINPASSWORD,Password=@LOGINPASSWORD ");
           str.Append("WHERE LOGINID=@LOGINID");
           SqlParameter[] para =
           {
               new SqlParameter("@LOGINPASSWORD",SqlDbType.VarChar,200),
               new SqlParameter("@LOGINID",SqlDbType.VarChar,50)
           };
           para[0].Value = strPWD;
           para[1].Value = strLogID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool InsertBASE_LOGIN(MODELBASE_LOGIN MODELBASE_LOGIN)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO BASE_LOGIN(LOGINID,LOGINNAME,workNO,USERNAME,LOGINPASSWORD,POSTID,DEPARTMENTID,"+
               "MEMO,TELEPHONENO,isMeterReader,isCharger,groupID,generateDateTime,userstate,IsCashier) ");
           str.Append("VALUES(@LOGINID,@LOGINNAME,@workNO,@USERNAME,@LOGINPASSWORD,@POSTID,@DEPARTMENTID,"+
               "@MEMO,@TELEPHONENO,@isMeterReader,@isCharger,@groupID,@generateDateTime,@userstate,@IsCashier)");
           SqlParameter[] para =
           {
               new SqlParameter("@LOGINID",SqlDbType.VarChar,50),
               new SqlParameter("@LOGINNAME",SqlDbType.VarChar,50),
               new SqlParameter("@workNO",SqlDbType.VarChar,30),
               new SqlParameter("@USERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@LOGINPASSWORD",SqlDbType.VarChar,200),
               new SqlParameter("@POSTID",SqlDbType.Int),
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@TELEPHONENO",SqlDbType.VarChar,50),
               new SqlParameter("@isMeterReader",SqlDbType.VarChar,10),
               new SqlParameter("@isCharger",SqlDbType.VarChar,10),
               new SqlParameter("@groupID",SqlDbType.VarChar,10),
               new SqlParameter("@generateDateTime",SqlDbType.DateTime),
               new SqlParameter("@userstate",SqlDbType.VarChar,10),
               new SqlParameter("@IsCashier",SqlDbType.VarChar,10)
           };
           para[0].Value = MODELBASE_LOGIN.LOGINID;
           para[1].Value = MODELBASE_LOGIN.LOGINNAME;
           para[2].Value = MODELBASE_LOGIN.workNO;
           para[3].Value = MODELBASE_LOGIN.USERNAME;
           para[4].Value = MODELBASE_LOGIN.LOGINPASSWORD;
           para[5].Value = MODELBASE_LOGIN.POSTID;
           para[6].Value = MODELBASE_LOGIN.DEPARTMENTID;
           para[7].Value = MODELBASE_LOGIN.MEMO;
           para[8].Value = MODELBASE_LOGIN.TELEPHONENO;
           para[9].Value = MODELBASE_LOGIN.isMeterReader;
           para[10].Value = MODELBASE_LOGIN.isCharger;
           para[11].Value = MODELBASE_LOGIN.groupID;
           para[12].Value = MODELBASE_LOGIN.generateDateTime;
           para[13].Value = MODELBASE_LOGIN.userstate;
           para[14].Value = MODELBASE_LOGIN.IsCashier;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public MODELBASE_LOGIN GetMODELBASE_LOGIN(string strUserID)
       {
           DataTable dt=new DataTable();
           MODELBASE_LOGIN MODELBASE_LOGIN = new MODELBASE_LOGIN();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM BASE_LOGIN INNER JOIN BASE_POST ON BASE_LOGIN.POSTID=BASE_POST.POSTID WHERE LOGINID=@LOGINID");
           SqlParameter[] para =
           {
               new SqlParameter("@LOGINID",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           dt=DBUtility.DbHelperSQL.Query(str.ToString(),para).Tables[0];
           if (dt.Rows.Count == 0)
               return null;
           else
           {
               MODELBASE_LOGIN.LOGINNAME = dt.Rows[0]["LOGINNAME"].ToString();
               if(dt.Rows[0]["USERNAME"]!=null)
               MODELBASE_LOGIN.USERNAME=dt.Rows[0]["USERNAME"].ToString();
               MODELBASE_LOGIN.LOGINPASSWORD=dt.Rows[0]["LOGINPASSWORD"].ToString();
               MODELBASE_LOGIN.POSTID=dt.Rows[0]["POSTID"].ToString();
               MODELBASE_LOGIN.DEPARTMENTID = dt.Rows[0]["DEPARTMENTID"].ToString();
               if (dt.Rows[0]["MEMO"] != null)
                   MODELBASE_LOGIN.MEMO = dt.Rows[0]["MEMO"].ToString();
               MODELBASE_LOGIN.isMeterReader = dt.Rows[0]["isMeterReader"].ToString();
               return MODELBASE_LOGIN;
           }
       }
    }
}
