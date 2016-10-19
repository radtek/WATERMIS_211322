using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;
using DBUtility;

namespace BLL
{
   public class BLLFILEUPLOAD
    {
       public DataTable Query(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM FILEUPLOAD WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       public bool Insert(MODELFILEUPLOAD MODELFILEUPLOAD)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO FILEUPLOAD(FILENAME,VERSION,FILECONTENT,OPERATORTIME) ");
           str.Append("VALUES(@FILENAME,@VERSION,@FILECONTENT,@OPERATORTIME)");

           SqlParameter[] para =
           {
               new SqlParameter("@FILENAME",SqlDbType.VarChar,50),
               new SqlParameter("@VERSION",SqlDbType.VarChar,50),
               new SqlParameter("@FILECONTENT",SqlDbType.Image),
               new SqlParameter("@OPERATORTIME",SqlDbType.DateTime)
           };
           para[0].Value = MODELFILEUPLOAD.FILENAME;
           para[1].Value = MODELFILEUPLOAD.VERSION;
           para[2].Value = MODELFILEUPLOAD.FILECONTENT;
           para[3].Value = MODELFILEUPLOAD.OPERATORTIME;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 自定义查询语句
       /// </summary>
       /// <param name="strSQL"></param>
       /// <returns></returns>
       public object QueryCustom(string strSQL)
       {
           object obj = DBUtility.DbHelperSQL.GetSingle(strSQL);
           return obj;
       }
    }
}
