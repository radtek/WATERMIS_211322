using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLNullReadReasonMemo
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM NullReadReasonMemo WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
        /// <summary>
        /// 获取最大号
        /// </summary>
        /// <returns></returns>
       public object GetMaxID()
       {
           int intMaxID = 0;
           string strGetMaxID = "SELECT MAX(NullReadReasonID) FROM NullReadReasonMemo";
           object obj = DBUtility.DbHelperSQL.GetSingle(strGetMaxID);
           return obj;
       }
       public bool Delete(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM NullReadReasonMemo WHERE NullReadReasonID=@NullReadReasonID");
           SqlParameter[] para =
           {
               new SqlParameter("@NullReadReasonID",SqlDbType.VarChar,30)
           };
           para[0].Value = strID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELNullReadReasonName MODELNullReadReasonName)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE NullReadReasonMemo SET NullReadReasonName=@NullReadReasonName,MEMO=@MEMO ");
           str.Append("WHERE NullReadReasonID=@NullReadReasonID");
           SqlParameter[] para =
           {
               new SqlParameter("@NullReadReasonName",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@NullReadReasonID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELNullReadReasonName.NullReadReasonName;
           para[1].Value = MODELNullReadReasonName.Memo;
           para[2].Value = MODELNullReadReasonName.NullReadReasonID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELNullReadReasonName MODELNullReadReasonName)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO NullReadReasonMemo(NullReadReasonID,NullReadReasonName,MEMO) ");
           str.Append("VALUES(@NullReadReasonID,@NullReadReasonName,@MEMO)");
           SqlParameter[] para =
           {
               new SqlParameter("@NullReadReasonID",SqlDbType.VarChar,30),
               new SqlParameter("@NullReadReasonName",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELNullReadReasonName.NullReadReasonID;
           para[1].Value = MODELNullReadReasonName.NullReadReasonName;
           para[2].Value = MODELNullReadReasonName.Memo;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
