using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLWATERMETERTYPE
    {
        public DataTable Query(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_WATERMTERTYPE WHERE 1=1 ");
            dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取附加费列表
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public object GetExtraCharge(string strFilter)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT extraCharge FROM waterMeterType WHERE 1=1 ");
           object obj= DBUtility.DbHelperSQL.GetSingle(str.ToString() + strFilter);
           return obj;
        }
        /// <summary>
        /// 获取阶梯水价列表
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable GetTrapePriceAndExtraCharge(string strFilter)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_WATERMTERTYPE WHERE 1=1 ");
            DataTable dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }
        public bool Delete(string strUserID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM dbo.waterMeterType WHERE waterMeterTypeId=@waterMeterTypeId");
            SqlParameter[] para =
           {
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30)
           };
            para[0].Value = strUserID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool Update(MODELWATERMETERTYPE MODELWATERMETERTYPE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE dbo.waterMeterType SET waterMeterTypeValue=@waterMeterTypeValue,trapezoidPrice=@trapezoidPrice,extraCharge=@extraCharge,MEMO=@MEMO,"+
                "overDuechargeEnable=@overDuechargeEnable,overDuechargeStartMonth=@overDuechargeStartMonth,"+
                "overDuechargeStartDay=@overDuechargeStartDay,overDuechargePercent=@overDuechargePercent,WATERMETERTYPECLASSID=@WATERMETERTYPECLASSID ");
            str.Append("WHERE waterMeterTypeId=@waterMeterTypeId");
            SqlParameter[] para =
           {
               new SqlParameter("@waterMeterTypeValue",SqlDbType.VarChar,50),
               new SqlParameter("@trapezoidPrice",SqlDbType.VarChar,300),
               new SqlParameter("@extraCharge",SqlDbType.VarChar,300),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@overDuechargeEnable",SqlDbType.VarChar,10),
               new SqlParameter("@overDuechargeStartMonth",SqlDbType.Int),
               new SqlParameter("@overDuechargeStartDay",SqlDbType.Int),
               new SqlParameter("@overDuechargePercent",SqlDbType.Float),
               new SqlParameter("@WATERMETERTYPECLASSID",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30)
           };
            para[0].Value = MODELWATERMETERTYPE.waterMeterTypeValue;
            para[1].Value = MODELWATERMETERTYPE.trapezoidPrice;
            para[2].Value = MODELWATERMETERTYPE.extraCharge;
            para[3].Value = MODELWATERMETERTYPE.MEMO;
            para[4].Value = MODELWATERMETERTYPE.overDuechargeEnable;
            para[5].Value = MODELWATERMETERTYPE.overDuechargeStartMonth;
            para[6].Value = MODELWATERMETERTYPE.overDuechargeStartDay;
            para[7].Value = MODELWATERMETERTYPE.overDuechargePercent;
            para[8].Value = MODELWATERMETERTYPE.WATERMETERTYPECLASSID;
            para[9].Value = MODELWATERMETERTYPE.waterMeterTypeId;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool Insert(MODELWATERMETERTYPE MODELWATERMETERTYPE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO dbo.waterMeterType(waterMeterTypeId,waterMeterTypeValue,trapezoidPrice,extraCharge,MEMO,"+
                "overDuechargeEnable,overDuechargeStartMonth,overDuechargeStartDay,overDuechargePercent,WATERMETERTYPECLASSID) ");
            str.Append("VALUES(@waterMeterTypeId,@waterMeterTypeValue,@trapezoidPrice,@extraCharge,@MEMO,"+
                "@overDuechargeEnable,@overDuechargeStartMonth,@overDuechargeStartDay,@overDuechargePercent,@WATERMETERTYPECLASSID)");
            SqlParameter[] para =
           {
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeValue",SqlDbType.VarChar,50),
               new SqlParameter("@trapezoidPrice",SqlDbType.VarChar,300),
               new SqlParameter("@extraCharge",SqlDbType.VarChar,300),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@overDuechargeEnable",SqlDbType.VarChar,10),
               new SqlParameter("@overDuechargeStartMonth",SqlDbType.Int),
               new SqlParameter("@overDuechargeStartDay",SqlDbType.Int),
               new SqlParameter("@overDuechargePercent",SqlDbType.Float),
               new SqlParameter("@WATERMETERTYPECLASSID",SqlDbType.VarChar,30)
           };
            para[0].Value = MODELWATERMETERTYPE.waterMeterTypeId;
            para[1].Value = MODELWATERMETERTYPE.waterMeterTypeValue;
            para[2].Value = MODELWATERMETERTYPE.trapezoidPrice;
            para[3].Value = MODELWATERMETERTYPE.extraCharge;
            para[4].Value = MODELWATERMETERTYPE.MEMO;
            para[5].Value = MODELWATERMETERTYPE.overDuechargeEnable;
            para[6].Value = MODELWATERMETERTYPE.overDuechargeStartMonth;
            para[7].Value = MODELWATERMETERTYPE.overDuechargeStartDay;
            para[8].Value = MODELWATERMETERTYPE.overDuechargePercent;
            para[9].Value = MODELWATERMETERTYPE.WATERMETERTYPECLASSID;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
    }
}
