using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLBASE_POST
    {
        public DataTable QueryPost(string strWhere)
        {
            DataTable DT = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM BASE_POST WHERE 1=1 ");
            DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
            return DT;
        }
        public bool DeletePOST(string strID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM BASE_POST WHERE POSTID=@POSTID");
            SqlParameter[] para =
           {
               new SqlParameter("@POSTID",SqlDbType.VarChar,30)
           };
            para[0].Value = strID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool UpdatePOST(MODELBASE_POST MODELBASE_POST)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE BASE_POST SET POSTNAME=@POSTNAME,MEMO=@MEMO ");
            str.Append("WHERE POSTID=@POSTID");
            SqlParameter[] para =
           {
               new SqlParameter("@POSTNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@POSTID",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELBASE_POST.POSTNAME;
            para[1].Value = MODELBASE_POST.MEMO;
            para[2].Value = MODELBASE_POST.POSTID;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }

        public bool InsertBASE_POST(MODELBASE_POST MODELBASE_POST)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO BASE_POST(POSTNAME,MEMO) ");
            str.Append("VALUES(@POSTNAME,@MEMO)");
            SqlParameter[] para =
           {
               new SqlParameter("@POSTNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELBASE_POST.POSTNAME;
            para[1].Value = MODELBASE_POST.MEMO;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public MODELBASE_POST GetModelBASE_POST(string strDepID)
        {
            DataTable dt = new DataTable();
            MODELBASE_POST MODELBASE_POST = new MODELBASE_POST();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM BASE_POST WHERE POSTID=@POSTID");
            SqlParameter[] para =
           {
               new SqlParameter("@POSTID",SqlDbType.VarChar,30)
           };
            para[0].Value = strDepID;
            dt = DBUtility.DbHelperSQL.Query(str.ToString(), para).Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                MODELBASE_POST.POSTNAME = dt.Rows[0]["POSTNAME"].ToString();
                if (dt.Rows[0]["MEMO"] != null)
                    MODELBASE_POST.MEMO = dt.Rows[0]["MEMO"].ToString();
                return MODELBASE_POST;
            }
        }
    }
}
