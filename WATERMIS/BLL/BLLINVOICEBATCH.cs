using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLINVOICEBATCH
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM INVOICEBATCH WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM INVOICEBATCH WHERE INVOICEBATCHID=@INVOICEBATCHID");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICEBATCHID",SqlDbType.Int)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELINVOICEBATCH MODELINVOICEBATCH)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE INVOICEBATCH SET INVOICEBATCHNAME=@INVOICEBATCHNAME,ISUSING=@ISUSING,INVOICEBATCHMEMO=@INVOICEBATCHMEMO ");
           str.Append("WHERE INVOICEBATCHID=@INVOICEBATCHID");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICEBATCHNAME",SqlDbType.VarChar,50),
               new SqlParameter("@ISUSING",SqlDbType.VarChar,10),
               new SqlParameter("@INVOICEBATCHMEMO",SqlDbType.VarChar,200),
               new SqlParameter("@INVOICEBATCHID",SqlDbType.Int)
           };
           para[0].Value = MODELINVOICEBATCH.INVOICEBATCHNAME;
           para[1].Value = MODELINVOICEBATCH.ISUSING;
           para[2].Value = MODELINVOICEBATCH.INVOICEBATCHMEMO;
           para[3].Value = MODELINVOICEBATCH.INVOICEBATCHID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELINVOICEBATCH MODELINVOICEBATCH)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO INVOICEBATCH(INVOICEBATCHNAME,INVOICEBATCHMEMO) ");
           str.Append("VALUES(@INVOICEBATCHNAME,@INVOICEBATCHMEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICEBATCHNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEBATCHMEMO",SqlDbType.VarChar,200)
           };
           para[0].Value = MODELINVOICEBATCH.INVOICEBATCHNAME;
           para[1].Value = MODELINVOICEBATCH.INVOICEBATCHMEMO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
