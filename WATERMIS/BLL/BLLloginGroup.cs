using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLloginGroup
    {
        public DataTable Query(string strWhere)
        {
            DataTable DT = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM loginGroup WHERE 1=1 ");
            DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
            return DT;
        }
        public bool Delete(string strID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM loginGroup WHERE groupId=@groupId");
            SqlParameter[] para =
           {
               new SqlParameter("@groupId",SqlDbType.VarChar,30)
           };
            para[0].Value = strID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool Update(MODELloginGroup MODELloginGroup)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE loginGroup SET groupName=@groupName,MEMO=@MEMO ");
            str.Append("WHERE groupId=@groupId");
            SqlParameter[] para =
           {
               new SqlParameter("@groupName",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@groupId",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELloginGroup.groupName;
            para[1].Value = MODELloginGroup.MEMO;
            para[2].Value = MODELloginGroup.groupId;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }

        public bool Insert(MODELloginGroup MODELloginGroup)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO loginGroup(groupId,groupName,MEMO) ");
            str.Append("VALUES(@groupId,@groupName,@MEMO)");
            SqlParameter[] para =
           {
               new SqlParameter("@groupId",SqlDbType.VarChar,10),
               new SqlParameter("@groupName",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELloginGroup.groupId;
            para[1].Value = MODELloginGroup.groupName;
            para[2].Value = MODELloginGroup.MEMO;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public MODELloginGroup GetModelloginGroup(string strDepID)
        {
            DataTable dt = new DataTable();
            MODELloginGroup MODELloginGroup = new MODELloginGroup();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM loginGroup WHERE groupId=@groupId");
            SqlParameter[] para =
           {
               new SqlParameter("@groupId",SqlDbType.VarChar,30)
           };
            para[0].Value = strDepID;
            dt = DBUtility.DbHelperSQL.Query(str.ToString(), para).Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                MODELloginGroup.groupName = dt.Rows[0]["groupName"].ToString();
                if (dt.Rows[0]["MEMO"] != null)
                    MODELloginGroup.MEMO = dt.Rows[0]["MEMO"].ToString();
                return MODELloginGroup;
            }
        }
    }
}
