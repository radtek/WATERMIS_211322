using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLINVOICESTOCKS
    {
        public DataTable Query(string strWhere)
        {
            DataTable DT = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_INVOICE WHERE 1=1 ");
            DT = DBUtility.DbHelperSQL.Query(str.ToString()+strWhere).Tables[0];
            return DT;
        }
        public bool Delete(string strDEPID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM INVOICESTOCKS WHERE INVOICESTOCKSID=@INVOICESTOCKSID");
            SqlParameter[] para =
           {
               new SqlParameter("@INVOICESTOCKSID",SqlDbType.VarChar,30)
           };
            para[0].Value = strDEPID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool Update(MODELINVOICESTOCKS MODELINVOICESTOCKS)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE INVOICESTOCKS SET INVOICESTARTNO=@INVOICESTARTNO,INVOICEENDNO=@INVOICEENDNO,INVOICEBATCHID=@INVOICEBATCHID,INVOICEMEMO=@INVOICEMEMO ");
            str.Append("WHERE INVOICESTOCKSID=@INVOICESTOCKSID");
            SqlParameter[] para =
           {
               new SqlParameter("@INVOICESTARTNO",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEENDNO",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEBATCHID",SqlDbType.Int),
               new SqlParameter("@INVOICEMEMO",SqlDbType.VarChar,200),
               new SqlParameter("@INVOICESTOCKSID",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELINVOICESTOCKS.INVOICESTARTNO;
            para[1].Value = MODELINVOICESTOCKS.INVOICEENDNO;
            para[2].Value = MODELINVOICESTOCKS.INVOICEBATCHID;
            para[3].Value = MODELINVOICESTOCKS.INVOICEMEMO;
            para[4].Value = MODELINVOICESTOCKS.INVOICESTOCKSID;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }

        public bool Insert(MODELINVOICESTOCKS MODELINVOICESTOCKS)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO INVOICESTOCKS(INVOICESTARTNO,INVOICEENDNO,INVOICEBATCHID,INVOICEMEMO) ");
            str.Append("VALUES(@INVOICESTARTNO,@INVOICEENDNO,@INVOICEBATCHID,@INVOICEMEMO)");
            SqlParameter[] para =
           {
               new SqlParameter("@INVOICESTARTNO",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEENDNO",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEBATCHID",SqlDbType.Int),
               new SqlParameter("@INVOICEMEMO",SqlDbType.VarChar,200)
           };
            para[0].Value = MODELINVOICESTOCKS.INVOICESTARTNO;
            para[1].Value = MODELINVOICESTOCKS.INVOICEENDNO;
            para[2].Value = MODELINVOICESTOCKS.INVOICEBATCHID;
            para[3].Value = MODELINVOICESTOCKS.INVOICEMEMO;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
    }
}
