using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLBASE_DEPARTMENT
    {
        public DataTable QueryDep(string strWhere)
        {
            DataTable DT = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM BASE_DEPARTMENT WHERE 1=1 ");
            DT = DBUtility.DbHelperSQL.Query(str.ToString()+strWhere).Tables[0];
            return DT;
        }
        public bool DeleteDEP(string strDEPID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM BASE_DEPARTMENT WHERE DEPARTMENTID=@DEPARTMENTID");
            SqlParameter[] para =
           {
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar,30)
           };
            para[0].Value = strDEPID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool UpdateDEP(MODELBASE_DEPARTMENT MODELBASE_DEPARTMENT)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE BASE_DEPARTMENT SET DEPARTMENTNAME=@DEPARTMENTNAME,DEPARTMENTTEL=@DEPARTMENTTEL,DEPARTMENTMANAGER=@DEPARTMENTMANAGER,PARENTID=@PARENTID,MEMO=@MEMO,SIMPLECODE=@SIMPLECODE, ");
            str.Append(" FPTaxNO=@FPTaxNO,FPAddressAndTel=@FPAddressAndTel,FPBankNameAndAccountNO=@FPBankNameAndAccountNO,");
            str.Append(" Payee=@Payee,Checker=@Checker ");
            str.Append("WHERE DEPARTMENTID=@DEPARTMENTID");
            SqlParameter[] para =
           {
               new SqlParameter("@DEPARTMENTNAME",SqlDbType.VarChar,50),
               new SqlParameter("@DEPARTMENTTEL",SqlDbType.VarChar,50),
               new SqlParameter("@DEPARTMENTMANAGER",SqlDbType.VarChar,30),
               new SqlParameter("@PARENTID",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@SIMPLECODE",SqlDbType.VarChar,50),
               new SqlParameter("@FPTaxNO",SqlDbType.VarChar,50),
               new SqlParameter("@FPAddressAndTel",SqlDbType.VarChar,100),
               new SqlParameter("@FPBankNameAndAccountNO",SqlDbType.VarChar,100),
               new SqlParameter("@Payee",SqlDbType.VarChar,50),
               new SqlParameter("@Checker",SqlDbType.VarChar,50),
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELBASE_DEPARTMENT.DEPARTMENTNAME;
            para[1].Value = MODELBASE_DEPARTMENT.DEPARTMENTTEL;
            para[2].Value = MODELBASE_DEPARTMENT.DEPARTMENTMANAGER;
            para[3].Value = MODELBASE_DEPARTMENT.PARENTID;
            para[4].Value = MODELBASE_DEPARTMENT.MEMO;
            para[5].Value = MODELBASE_DEPARTMENT.SIMPLECODE;
            para[6].Value = MODELBASE_DEPARTMENT.FPTaxNO;
            para[7].Value = MODELBASE_DEPARTMENT.FPAddressAndTel;
            para[8].Value = MODELBASE_DEPARTMENT.FPBankNameAndAccountNO;
            para[9].Value = MODELBASE_DEPARTMENT.Payee;
            para[10].Value = MODELBASE_DEPARTMENT.Checker;
            para[11].Value = MODELBASE_DEPARTMENT.DEPARTMENTID;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }

        public bool InsertBASE_DEPARTMENT(MODELBASE_DEPARTMENT MODELBASE_DEPARTMENT)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO BASE_DEPARTMENT(DEPARTMENTID,DEPARTMENTNAME,DEPARTMENTTEL,DEPARTMENTMANAGER,PARENTID,MEMO,SIMPLECODE) ");
            str.Append("VALUES(@DEPARTMENTID,@DEPARTMENTNAME,@DEPARTMENTTEL,@DEPARTMENTMANAGER,@PARENTID,@MEMO,@SIMPLECODE)");
            SqlParameter[] para =
           {
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar,50),
               new SqlParameter("@DEPARTMENTNAME",SqlDbType.VarChar,50),
               new SqlParameter("@DEPARTMENTTEL",SqlDbType.VarChar,50),
               new SqlParameter("@DEPARTMENTMANAGER",SqlDbType.VarChar,30),
               new SqlParameter("@PARENTID",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@SIMPLECODE",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELBASE_DEPARTMENT.DEPARTMENTID;
            para[1].Value = MODELBASE_DEPARTMENT.DEPARTMENTNAME;
            para[2].Value = MODELBASE_DEPARTMENT.DEPARTMENTTEL;
            para[3].Value = MODELBASE_DEPARTMENT.DEPARTMENTMANAGER;
            para[4].Value = MODELBASE_DEPARTMENT.PARENTID;
            para[5].Value = MODELBASE_DEPARTMENT.MEMO;
            para[6].Value = MODELBASE_DEPARTMENT.SIMPLECODE;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public MODELBASE_DEPARTMENT GetModelBASE_DEPARTMENT(string strDepID)
        {
            DataTable dt = new DataTable();
            MODELBASE_DEPARTMENT MODELBASE_DEPARTMENT = new MODELBASE_DEPARTMENT();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM BASE_DEPARTMENT WHERE DEPARTMENTID=@DEPARTMENTID");
            SqlParameter[] para =
           {
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar,30)
           };
            para[0].Value = strDepID;
            dt = DBUtility.DbHelperSQL.Query(str.ToString(), para).Tables[0];
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                MODELBASE_DEPARTMENT.DEPARTMENTNAME = dt.Rows[0]["DEPARTMENTNAME"].ToString();
                if (dt.Rows[0]["DEPARTMENTTEL"] != null)
                    MODELBASE_DEPARTMENT.DEPARTMENTTEL = dt.Rows[0]["DEPARTMENTTEL"].ToString();
                if (dt.Rows[0]["DEPARTMENTMANAGER"] != null)
                    MODELBASE_DEPARTMENT.DEPARTMENTMANAGER = dt.Rows[0]["DEPARTMENTMANAGER"].ToString();
                if (dt.Rows[0]["PARENTID"] != null)
                MODELBASE_DEPARTMENT.PARENTID = dt.Rows[0]["PARENTID"].ToString();
                if (dt.Rows[0]["MEMO"] != null)
                    MODELBASE_DEPARTMENT.MEMO = dt.Rows[0]["MEMO"].ToString();
                if (dt.Rows[0]["SIMPLECODE"] != null)
                    MODELBASE_DEPARTMENT.SIMPLECODE = dt.Rows[0]["SIMPLECODE"].ToString();
                return MODELBASE_DEPARTMENT;
            }
        }
    }
}
