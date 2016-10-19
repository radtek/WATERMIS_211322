using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
   public class BLLreadMeterRecordCancel
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM readMeterRecordCancel WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool Delete(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM readMeterRecordCancel WHERE 1=1 ");
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString()) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 自定义执行语句
       /// </summary>
       /// <param name="strSQL"></param>
       /// <returns></returns>
       public bool ExcuteSQL(string strSQL)
       {
           if (DBUtility.DbHelperSQL.ExecuteSql(strSQL) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELreadMeterRecordCancel MODELreadMeterRecordCancel)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecordCancel SET readMeterRecordId=@readMeterRecordId,chargeID=@chargeID ");
           str.Append("WHERE readMeterRecordCancelId=@readMeterRecordCancelId");
           SqlParameter[] para =
           {
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,50),
               new SqlParameter("@chargeID",SqlDbType.VarChar,50),
               new SqlParameter("@readMeterRecordCancelId",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELreadMeterRecordCancel.readMeterRecordId;
           para[1].Value = MODELreadMeterRecordCancel.chargeID;
           para[2].Value = MODELreadMeterRecordCancel.readMeterRecordCancelId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       public bool Insert(MODELreadMeterRecordCancel MODELreadMeterRecordCancel)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO readMeterRecordCancel(readMeterRecordCancelId,readMeterRecordId,chargeID) ");
           str.Append("VALUES(@readMeterRecordCancelId,@readMeterRecordId,@chargeID)");
           SqlParameter[] para =
           {
               new SqlParameter("@readMeterRecordCancelId",SqlDbType.VarChar,30),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,50),
               new SqlParameter("@chargeID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELreadMeterRecordCancel.readMeterRecordCancelId;
           para[1].Value = MODELreadMeterRecordCancel.readMeterRecordId;
           para[2].Value = MODELreadMeterRecordCancel.chargeID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
