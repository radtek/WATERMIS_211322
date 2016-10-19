using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class BLLBASE_AUTHORITY
    {
        public DataTable GetAllAuthority(string strID)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            str.Append("SELECT MENUID,LOGINGROUP.GROUPID,BASE_MENU.MEMO,LOGINGROUP.GROUPNAME,'0' AS VALUE,(CASE MENUCLASS WHEN '1' THEN '一级' WHEN '2' THEN '二级' WHEN '3' THEN '三级' WHEN '4' THEN '四级' END) AS MENUCLASS FROM BASE_MENU,LOGINGROUP WHERE LOGINGROUP.GROUPID=@GROUPID");

            SqlParameter[] para =
            {
                new SqlParameter("@GROUPID",SqlDbType.VarChar,30)
            };
            para[0].Value = strID;
            dt = DBUtility.DbHelperSQL.Query(str.ToString(), para).Tables[0];
            return dt;
        }
        public DataTable GetPersonAuthority(string strID)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            str.Append("SELECT LOGINGROUP.GROUPID,LOGINGROUP.GROUPNAME,BASE_AUTHORITY.MENUID,MENUNAME FROM BASE_AUTHORITY INNER JOIN LOGINGROUP ON LOGINGROUP.GROUPID=BASE_AUTHORITY.GROUPID INNER JOIN BASE_MENU ON BASE_AUTHORITY.MENUID=BASE_MENU.MENUID WHERE BASE_AUTHORITY.GROUPID=@GROUPID ");

            SqlParameter[] para =
            {
                new SqlParameter("@GROUPID",SqlDbType.VarChar,30)
            };
            para[0].Value = strID;
            dt = DBUtility.DbHelperSQL.Query(str.ToString(), para).Tables[0];
            return dt;
        }
        public int GetAutority(string strID,string strName)
        {
            StringBuilder str = new StringBuilder();
            object obj;
            DataTable dt = new DataTable();
            str.Append("SELECT COUNT(*) FROM BASE_AUTHORITY INNER JOIN BASE_MENU ON BASE_AUTHORITY.MENUID=BASE_MENU.MENUID WHERE GROUPID=@GROUPID AND MENUNAME=@MENUNAME");

            SqlParameter[] para =
            {
                new SqlParameter("@GROUPID",SqlDbType.VarChar,30),
                new SqlParameter("@MENUNAME",SqlDbType.VarChar,50)
            };
            para[0].Value = strID;
            para[1].Value = strName;
            obj = DBUtility.DbHelperSQL.GetSingle(str.ToString(),para);
            if (obj == null)
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public bool InsertAuthority(string strGroupID, string MENUID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO BASE_AUTHORITY(GROUPID,MENUID) VALUES(@GROUPID,@MENUID)");

            SqlParameter[] para =
            {
                new SqlParameter("@GROUPID",SqlDbType.VarChar,30),
                new SqlParameter("@MENUID",SqlDbType.VarChar,30)
            };
            para[0].Value = strGroupID;
            para[1].Value = MENUID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool DelAuthority(string strGroupID, string MENUID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM  BASE_AUTHORITY WHERE GROUPID=@GROUPID AND MENUID=@MENUID");

            SqlParameter[] para =
            {
                new SqlParameter("@GROUPID",SqlDbType.VarChar,30),
                new SqlParameter("@MENUID",SqlDbType.VarChar,30)
            };
            para[0].Value = strGroupID;
            para[1].Value = MENUID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
    }
}
