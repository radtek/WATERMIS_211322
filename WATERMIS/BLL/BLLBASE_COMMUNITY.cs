using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLBASE_COMMUNITY
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM BASE_COMMUNITY WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM BASE_COMMUNITY WHERE COMMUNITYID=@COMMUNITYID");
           SqlParameter[] para =
           {
               new SqlParameter("@COMMUNITYID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELBASE_COMMUNITY MODELBASE_COMMUNITY)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE BASE_COMMUNITY SET COMMUNITYNAME=@COMMUNITYNAME,MEMO=@MEMO ");
           str.Append("WHERE COMMUNITYID=@COMMUNITYID");
           SqlParameter[] para =
           {
               new SqlParameter("@COMMUNITYNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@COMMUNITYID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELBASE_COMMUNITY.COMMUNITYNAME;
           para[1].Value = MODELBASE_COMMUNITY.MEMO;
           para[2].Value = MODELBASE_COMMUNITY.COMMUNITYID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELBASE_COMMUNITY MODELBASE_COMMUNITY)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO BASE_COMMUNITY(COMMUNITYID,COMMUNITYNAME,PARENTID,MEMO) ");
           str.Append("VALUES(@COMMUNITYID,@COMMUNITYNAME,@PARENTID,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@COMMUNITYID",SqlDbType.VarChar,30),
               new SqlParameter("@COMMUNITYNAME",SqlDbType.VarChar,50),
               new SqlParameter("@PARENTID",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELBASE_COMMUNITY.COMMUNITYID;
           para[1].Value = MODELBASE_COMMUNITY.COMMUNITYNAME;
           para[2].Value = MODELBASE_COMMUNITY.PARENTID;
           para[3].Value = MODELBASE_COMMUNITY.MEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public MODELBASE_COMMUNITY GetMODELBASE_COMMUNITY(string strDepID)
       {
           DataTable dt = new DataTable();
           MODELBASE_COMMUNITY MODELBASE_COMMUNITY = new MODELBASE_COMMUNITY();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM BASE_COMMUNITY WHERE COMMUNITYID=@COMMUNITYID");
           SqlParameter[] para =
           {
               new SqlParameter("@COMMUNITYID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDepID;
           dt = DBUtility.DbHelperSQL.Query(str.ToString(), para).Tables[0];
           if (dt.Rows.Count == 0)
               return null;
           else
           {
               MODELBASE_COMMUNITY.COMMUNITYNAME = dt.Rows[0]["COMMUNITYNAME"].ToString();
               if (dt.Rows[0]["PARENTID"] != null)
                   MODELBASE_COMMUNITY.PARENTID = dt.Rows[0]["PARENTID"].ToString();
               if (dt.Rows[0]["MEMO"] != null)
                   MODELBASE_COMMUNITY.MEMO = dt.Rows[0]["MEMO"].ToString();
               return MODELBASE_COMMUNITY;
           }
       }
    }
}
