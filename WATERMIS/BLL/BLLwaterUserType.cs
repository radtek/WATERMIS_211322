using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLwaterUserType
    {
        public DataTable Query(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT waterUserTypeId,waterUserTypeName,overDuechargeEnable,(CASE overDuechargeEnable WHEN '1' THEN '是' ELSE '否' END) AS overDuechargeEnableS,overDuechargeStartMonth,overDuechargeStartDay,overDuechargePercent,invoiceBillName,memo FROM waterUserType WHERE 1=1");
            dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }
        public bool Delete(string strUserID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM waterUserType WHERE waterUserTypeId=@waterUserTypeId");
            SqlParameter[] para =
           {
               new SqlParameter("@waterUserTypeId",SqlDbType.VarChar,30)
           };
            para[0].Value = strUserID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool Update(MODELwaterUserType MODELwaterUserType)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE waterUserType SET waterUserTypeName=@waterUserTypeName,overDuechargeEnable=@overDuechargeEnable,overDuechargeStartMonth=@overDuechargeStartMonth,overDuechargeStartDay=@overDuechargeStartDay,overDuechargePercent=@overDuechargePercent,invoiceBillName=@invoiceBillName,MEMO=@MEMO ");
            str.Append("WHERE waterUserTypeId=@waterUserTypeId");
            SqlParameter[] para =
           {
               new SqlParameter("@waterUserTypeName",SqlDbType.VarChar,50),
               new SqlParameter("@overDuechargeEnable",SqlDbType.VarChar,10),
               new SqlParameter("@overDuechargeStartMonth",SqlDbType.Int),
               new SqlParameter("@overDuechargeStartDay",SqlDbType.Int),
               new SqlParameter("@overDuechargePercent",SqlDbType.Float),
               new SqlParameter("@invoiceBillName",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@waterUserTypeId",SqlDbType.VarChar,30)
           };
            para[0].Value = MODELwaterUserType.waterUserTypeName;
            para[1].Value = MODELwaterUserType.overDuechargeEnable;
            para[2].Value = MODELwaterUserType.overDuechargeStartMonth;
            para[3].Value = MODELwaterUserType.overDuechargeStartDay;
            para[4].Value = MODELwaterUserType.overDuechargePercent;
            para[5].Value = MODELwaterUserType.invoiceBillName;
            para[6].Value = MODELwaterUserType.MEMO;
            para[7].Value = MODELwaterUserType.waterUserTypeId;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool Insert(MODELwaterUserType MODELwaterUserType)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO waterUserType(waterUserTypeId,waterUserTypeName,overDuechargeEnable,overDuechargeStartMonth,overDuechargeStartDay,overDuechargePercent,invoiceBillName,MEMO) ");
            str.Append("VALUES(@waterUserTypeId,@waterUserTypeName,@overDuechargeEnable,@overDuechargeStartMonth,@overDuechargeStartDay,@overDuechargePercent,@invoiceBillName,@MEMO)");
            SqlParameter[] para =
           {
               new SqlParameter("@waterUserTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserTypeName",SqlDbType.VarChar,50),
               new SqlParameter("@overDuechargeEnable",SqlDbType.VarChar,10),
               new SqlParameter("@overDuechargeStartMonth",SqlDbType.Int),
               new SqlParameter("@overDuechargeStartDay",SqlDbType.Int),
               new SqlParameter("@overDuechargePercent",SqlDbType.Float),
               new SqlParameter("@invoiceBillName",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELwaterUserType.waterUserTypeId;
            para[1].Value = MODELwaterUserType.waterUserTypeName;
            para[2].Value = MODELwaterUserType.overDuechargeEnable;
            para[3].Value = MODELwaterUserType.overDuechargeStartMonth;
            para[4].Value = MODELwaterUserType.overDuechargeStartDay;
            para[5].Value = MODELwaterUserType.overDuechargePercent;
            para[6].Value = MODELwaterUserType.invoiceBillName;
            para[7].Value = MODELwaterUserType.MEMO;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
    }
}
