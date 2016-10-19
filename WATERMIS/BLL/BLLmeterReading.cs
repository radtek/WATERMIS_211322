using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLmeterReading
    {
        //public DataTable Query(string strWhere)
        //{
        //    DataTable DT = new DataTable();
        //    StringBuilder str = new StringBuilder();
        //    str.Append("SELECT * FROM meterReading WHERE 1=1 ");
        //    DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
        //    return DT;
        //}
        public DataTable Query(string strWhere)
        {
            DataTable DT = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_METERREADING WHERE 1=1 ");
            DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
            return DT;
        }
        /// <summary>
        /// 查询抄表本中设置的抄表员
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable QueryCharger(string strWhere)
        {
            DataTable DT = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT meterReadingID,USERNAME,CHARGERID FROM meterReading LEFT JOIN BASE_LOGIN ON BASE_LOGIN.LOGINID=meterReading.CHARGERID");
            DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
            return DT;
        }
        public DataTable QueryMeterReaderNotNULL(string strWhere)
        {
            DataTable DT = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT DISTINCT LOGINID,USERNAME FROM V_METERREADING_METERREADERNOTNULL WHERE 1=1 ");
            DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
            return DT;
        }
        /// <summary>
        /// 根据自定义字符串查询语句
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataTable QuerySQL(string strSQL)
        {
            DataTable DT = new DataTable();
            DT = DBUtility.DbHelperSQL.Query(strSQL).Tables[0];
            return DT;
        }
        public bool Delete(string strDEPID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM meterReading WHERE meterReadingID=@meterReadingID");
            SqlParameter[] para =
           {
               new SqlParameter("@meterReadingID",SqlDbType.VarChar,30)
           };
            para[0].Value = strDEPID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 更新抄表本
        /// </summary>
        /// <param name="MODELmeterReading"></param>
        /// <returns></returns>
        public bool Update(MODELmeterReading MODELmeterReading)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE meterReading SET meterReadingNO=@meterReadingNO,loginId=@loginId,areaId=@areaId,CHARGERID=@CHARGERID,createDate=@createDate,MEMO=@MEMO ");
            str.Append("WHERE meterReadingID=@meterReadingID");
            SqlParameter[] para =
           {
               new SqlParameter("@meterReadingNO",SqlDbType.VarChar,50),
               new SqlParameter("@loginId",SqlDbType.VarChar,50),
               new SqlParameter("@areaId",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGERID",SqlDbType.VarChar,50),
               new SqlParameter("@createDate",SqlDbType.DateTime),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@meterReadingID",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELmeterReading.meterReadingNO;
            para[1].Value = MODELmeterReading.loginId;
            para[2].Value = MODELmeterReading.AREAID;
            para[3].Value = MODELmeterReading.CHARGERID;
            para[4].Value = MODELmeterReading.createDate;
            para[5].Value = MODELmeterReading.MEMO;
            para[6].Value = MODELmeterReading.meterReadingID;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 抄表员互换
        /// </summary>
        /// <param name="strIDSource"></param>
        /// <param name="strIDAIM"></param>
        /// <returns></returns>
        public bool UpdateMeterReader(string strIDSource,string strIDAIM)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE meterReading SET loginId=@loginId ");
            str.Append("WHERE loginId=@strIDSource");
            SqlParameter[] para =
           {
               new SqlParameter("@loginId",SqlDbType.VarChar,50),
               new SqlParameter("@strIDSource",SqlDbType.VarChar,50)
           };
            para[0].Value = strIDAIM;
            para[1].Value = strIDSource;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加新的抄表本
        /// </summary>
        /// <param name="MODELmeterReading"></param>
        /// <returns></returns>
        public bool Insert(MODELmeterReading MODELmeterReading)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO meterReading(meterReadingID,meterReadingNO,loginId,areaId,CHARGERID,createDate,MEMO) ");
            str.Append("VALUES(@meterReadingID,@meterReadingNO,@loginId,@areaId,@CHARGERID,@createDate,@MEMO)");
            SqlParameter[] para =
           {
               new SqlParameter("@meterReadingID",SqlDbType.VarChar,50),
               new SqlParameter("@meterReadingNO",SqlDbType.VarChar,50),
               new SqlParameter("@loginId",SqlDbType.VarChar,50),
               new SqlParameter("@areaId",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGERID",SqlDbType.VarChar,50),
               new SqlParameter("@createDate",SqlDbType.DateTime),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200)
           };
            para[0].Value = MODELmeterReading.meterReadingID;
            para[1].Value = MODELmeterReading.meterReadingNO;
            para[2].Value = MODELmeterReading.loginId;
            para[3].Value = MODELmeterReading.AREAID;
            para[4].Value = MODELmeterReading.CHARGERID;
            para[5].Value = MODELmeterReading.createDate;
            para[6].Value = MODELmeterReading.MEMO;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
    }
}
