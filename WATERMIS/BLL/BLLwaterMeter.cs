using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLwaterMeter
    {
       public DataTable Query(string strFilter)
       {
           DataTable dt=new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_WATERMETER WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()+strFilter).Tables[0];
           return dt;
       }

        /// <summary>
        /// 自定义SQL语句查询
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
       public DataTable QueryBySQL(string strSQL)
       {
           DataTable dt = new DataTable();
           dt = DBUtility.DbHelperSQL.Query(strSQL).Tables[0];
           return dt;
       }
        /// <summary>
        /// 查询关联用户的所有水表信息
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
       public DataTable QueryConnectWaterUser(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       #region 统计函数
        //用户类别
        //抄表本
        //区域
        //抄表员
        //银行托收
        //托收银行
        //建户年份
        //建户月份
        //建户日期
        //用水性质
        //水表位置
        //水表口径
        //水表状态
        /// <summary>
        /// 根据用户类别统计水表信息
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
       public DataTable WaterMeterStatisticsByWaterUserType(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterUserTypeId AS 用户类型编号,waterUserTypeName AS 用户类型,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY waterUserTypeId,waterUserTypeName");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据抄表本统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByMeterReading(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT meterReadingID AS 抄表本编号,meterReadingNO AS 抄表本,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY meterReadingID,meterReadingNO");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据区域名称统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByArea(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT areaId AS 区域编号,areaName AS 区域名称,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY areaId,areaName");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据抄表员统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByMeterReader(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT loginId AS 抄表员编号,USERNAME AS 抄表员,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY loginId,USERNAME");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据银行托收统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByIsAgent(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT agentsignS AS 银行托收,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY agentsignS");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据托收银行统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByAgentBank(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT ISNULL(bankId,'无') AS 银行编号,ISNULL(bankName,'无') AS 托收银行,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY bankId,bankName");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据建户年份统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByCreateYear(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT CAST(DATEPART(YEAR,waterUserCreateDate) AS VARCHAR) AS 建户年份,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY CAST(DATEPART(YEAR,waterUserCreateDate) AS VARCHAR)");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据建户月份统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByCreateMonth(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT(CAST(DATEPART(YEAR,waterUserCreateDate) AS VARCHAR)+'-'+RIGHT(REPLICATE('0',2)+CAST(DATEPART(MONTH,waterUserCreateDate) AS VARCHAR),2)) AS 建户月份,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY (CAST(DATEPART(YEAR,waterUserCreateDate) AS VARCHAR)+'-'+RIGHT(REPLICATE('0',2)+CAST(DATEPART(MONTH,waterUserCreateDate) AS VARCHAR),2))");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据建户日期统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByCreateDate(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT CONVERT(varchar(100),waterUserCreateDate, 23) AS 建户日期,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY CONVERT(varchar(100),waterUserCreateDate, 23)");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据用水性质统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByWaterMeterType(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterMeterTypeId AS 用水性质编号,waterMeterTypeValue AS 用水性质,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY waterMeterTypeId,waterMeterTypeValue");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据水表位置统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByWaterMeterPosition(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterMeterPositionId AS 水表位置编号,waterMeterPositionName AS 水表位置,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY waterMeterPositionId,waterMeterPositionName");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据水表口径统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByWaterMeterSize(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterMeterSizeId AS 水表口径编号,waterMeterSizeValue AS 水表口径,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY waterMeterSizeId,waterMeterSizeValue");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据水表状态统计水表信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterMeterStatisticsByWaterMeterState(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterMeterStateS AS 水表状态,");
           str.Append(" COUNT(DISTINCT waterUserId) AS 用户数,COUNT(*) AS 水表数,");
           str.Append(" SUM(CASE WHEN WATERFIXVALUE>0 THEN 1 ELSE 0 END) AS 定量水表数,");
           str.Append(" SUM(CASE waterMeterState WHEN '1' THEN 1 ELSE 0 END) AS 正常数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '2' THEN 1 ELSE 0 END) AS 报停数量,");
           str.Append(" SUM(CASE waterMeterState WHEN '3' THEN 1 ELSE 0 END) AS 报废数量");
           str.Append(" FROM ( SELECT * FROM V_WATERMETER_CONNECTWATERUSERVIEW WHERE 1=1");
           str.Append(strFilter + " ) AS A");
           str.Append(" GROUP BY waterMeterStateS");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       #endregion
       /// <summary>
        /// 查询总表
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
       public DataTable QuerySummary(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterMeterId,waterMeterNo,waterUserName FROM V_WATERUSER_CONNECTWATERMETER WHERE isSummaryMeter='2'");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
        /// <summary>
        /// 根据水表ID删除一块水表
        /// </summary>
        /// <param name="strUserID"></param>
        /// <returns></returns>
       public bool Delete(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM waterMeter WHERE waterMeterId=@waterMeterId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterId",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
        /// <summary>
        /// 删除整个用户下的水表
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        /// <returns></returns>
       public bool DeleteByUser(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM waterMeter WHERE waterUserId=@waterUserId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterUserId",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Update(MODELwaterMeter MODELwaterMeter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterMeter SET waterMeterNo=@waterMeterNo,waterMeterStartNumber=@waterMeterStartNumber,waterMeterPositionName=@waterMeterPositionName," +
               "waterMeterState=@waterMeterState,waterMeterSizeId=@waterMeterSizeId,waterMeterTypeId=@waterMeterTypeId,WATERFIXVALUE=@WATERFIXVALUE," +
               "waterMeterProduct=@waterMeterProduct,waterMeterSerialNumber=@waterMeterSerialNumber,waterMeterMode=@waterMeterMode," +
               "waterMeterMagnification=@waterMeterMagnification,waterMeterMaxRange=@waterMeterMaxRange,waterMeterProofreadingDate=@waterMeterProofreadingDate," +
               "waterMeteProofreadingPeriod=@waterMeteProofreadingPeriod,waterUserId=@waterUserId,waterMeterParentId=@waterMeterParentId,MEMO=@MEMO,isSummaryMeter=@isSummaryMeter,"+
               "ISUSECHANGE=@ISUSECHANGE,CHANGEMONTH=@CHANGEMONTH,waterMeterTypeIdChange=@waterMeterTypeIdChange,IsReverse=@IsReverse,WATERMETERLOCKNO=@WATERMETERLOCKNO,"+
               "ChannelNO=@ChannelNO,SummaryMeterClass=@SummaryMeterClass ");
           str.Append("WHERE waterMeterId=@waterMeterId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterNo",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterStartNumber",SqlDbType.Int),
               new SqlParameter("@waterMeterPositionName",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterState",SqlDbType.VarChar,10),
               new SqlParameter("@waterMeterSizeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@WATERFIXVALUE",SqlDbType.Int),
               new SqlParameter("@waterMeterProduct",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterSerialNumber",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterMode",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterMagnification",SqlDbType.Int),
               new SqlParameter("@waterMeterMaxRange",SqlDbType.Int),
               new SqlParameter("@waterMeterProofreadingDate",SqlDbType.DateTime),
               new SqlParameter("@waterMeteProofreadingPeriod",SqlDbType.Int),
               new SqlParameter("@waterUserId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterParentId",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@isSummaryMeter",SqlDbType.VarChar,10),
               new SqlParameter("@ISUSECHANGE",SqlDbType.VarChar,10),
               new SqlParameter("@CHANGEMONTH",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeIdChange",SqlDbType.VarChar,30),
               new SqlParameter("@IsReverse",SqlDbType.VarChar,30),
               new SqlParameter("@WATERMETERLOCKNO",SqlDbType.VarChar,50),
               new SqlParameter("@ChannelNO",SqlDbType.VarChar,30),
               new SqlParameter("@SummaryMeterClass",SqlDbType.VarChar,10),
               new SqlParameter("@waterMeterId",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELwaterMeter.waterMeterNo;
           para[1].Value = MODELwaterMeter.waterMeterStartNumber;
           para[2].Value = MODELwaterMeter.waterMeterPositionName;
           para[3].Value = MODELwaterMeter.waterMeterState;
           para[4].Value = MODELwaterMeter.waterMeterSizeId;
           para[5].Value = MODELwaterMeter.waterMeterTypeId;
           para[6].Value = MODELwaterMeter.WATERFIXVALUE;
           para[7].Value = MODELwaterMeter.waterMeterProduct;
           para[8].Value = MODELwaterMeter.waterMeterSerialNumber;
           para[9].Value = MODELwaterMeter.waterMeterMode;
           para[10].Value = MODELwaterMeter.waterMeterMagnification;
           para[11].Value = MODELwaterMeter.waterMeterMaxRange;
           para[12].Value = MODELwaterMeter.waterMeterProofreadingDate;
           para[13].Value = MODELwaterMeter.waterMeteProofreadingPeriod;
           para[14].Value = MODELwaterMeter.waterUserId;
           para[15].Value = MODELwaterMeter.waterMeterParentId;
           para[16].Value = MODELwaterMeter.MEMO;
           para[17].Value = MODELwaterMeter.isSummaryMeter;
           para[18].Value = MODELwaterMeter.ISUSECHANGE;


           //如果启用了自动变更新水价，则更新变更的月份和用水性质，如果没启用则不更新
           if (MODELwaterMeter.ISUSECHANGE == "1")
           {
               para[19].Value = MODELwaterMeter.CHANGEMONTH;
               para[20].Value = MODELwaterMeter.waterMeterTypeIdChange;
           }
           else
           {
               para[19].Value = null;
               para[20].Value = null;
           }
           para[21].Value = MODELwaterMeter.IsReverse;
           para[22].Value = MODELwaterMeter.WATERMETERLOCKNO;
           para[23].Value = MODELwaterMeter.ChannelNO;
           para[24].Value = MODELwaterMeter.SummaryMeterClass;
           para[25].Value = MODELwaterMeter.waterMeterId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
        /// <summary>
        /// 变更用水性质
        /// </summary>
        /// <param name="MODELwaterMeter"></param>
        /// <returns></returns>
       public bool UpdateWaterMeterType(MODELwaterMeter MODELwaterMeter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterMeter SET waterMeterTypeId=@waterMeterTypeId");
           str.Append(" WHERE waterMeterId=@waterMeterId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterId",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELwaterMeter.waterMeterTypeId;
           para[1].Value = MODELwaterMeter.waterMeterId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Insert(MODELwaterMeter MODELwaterMeter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO waterMeter(waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterState,"+
               "waterMeterSizeId,waterMeterTypeId,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,"+
               "waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,"+
               "waterMeterParentId,memo,STARTUSEDATETIME,isSummaryMeter,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,IsReverse,WATERMETERLOCKNO,SummaryMeterClass,ChannelNO) ");

           str.Append("VALUES(@waterMeterId,@waterMeterNo,@waterMeterStartNumber,@waterMeterPositionName,@waterMeterState,"+
               "@waterMeterSizeId,@waterMeterTypeId,@WATERFIXVALUE,@waterMeterProduct,@waterMeterSerialNumber,@waterMeterMode,"+
               "@waterMeterMagnification,@waterMeterMaxRange,@waterMeterProofreadingDate,"+
               "@waterMeteProofreadingPeriod,@waterUserId,@waterMeterParentId,@memo,@STARTUSEDATETIME,@isSummaryMeter,"+
               "@ISUSECHANGE,@CHANGEMONTH,@waterMeterTypeIdChange,@IsReverse,@WATERMETERLOCKNO,@SummaryMeterClass,@ChannelNO)");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterNo",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterStartNumber",SqlDbType.Int),
               new SqlParameter("@waterMeterPositionName",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterState",SqlDbType.VarChar,10),
               new SqlParameter("@waterMeterSizeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@WATERFIXVALUE",SqlDbType.Int),
               new SqlParameter("@waterMeterProduct",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterSerialNumber",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterMode",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterMagnification",SqlDbType.Int),
               new SqlParameter("@waterMeterMaxRange",SqlDbType.Int),
               new SqlParameter("@waterMeterProofreadingDate",SqlDbType.DateTime),
               new SqlParameter("@waterMeteProofreadingPeriod",SqlDbType.Int),
               new SqlParameter("@waterUserId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterParentId",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),//04216816395
               new SqlParameter("@STARTUSEDATETIME",SqlDbType.DateTime),
               new SqlParameter("@isSummaryMeter",SqlDbType.VarChar,10),
               new SqlParameter("@ISUSECHANGE",SqlDbType.VarChar,10),
               new SqlParameter("@CHANGEMONTH",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeIdChange",SqlDbType.VarChar,30),
               new SqlParameter("@IsReverse",SqlDbType.VarChar,30),
               new SqlParameter("@WATERMETERLOCKNO",SqlDbType.VarChar,50),
               new SqlParameter("@SummaryMeterClass",SqlDbType.VarChar,10),
               new SqlParameter("@ChannelNO",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELwaterMeter.waterMeterId;
           para[1].Value = MODELwaterMeter.waterMeterNo;
           para[2].Value = MODELwaterMeter.waterMeterStartNumber;
           para[3].Value = MODELwaterMeter.waterMeterPositionName;
           para[4].Value = MODELwaterMeter.waterMeterState;
           para[5].Value = MODELwaterMeter.waterMeterSizeId;
           para[6].Value = MODELwaterMeter.waterMeterTypeId;
           para[7].Value = MODELwaterMeter.WATERFIXVALUE;
           para[8].Value = MODELwaterMeter.waterMeterProduct;
           para[9].Value = MODELwaterMeter.waterMeterSerialNumber;
           para[10].Value = MODELwaterMeter.waterMeterMode;
           para[11].Value = MODELwaterMeter.waterMeterMagnification;
           para[12].Value = MODELwaterMeter.waterMeterMaxRange;
           para[13].Value = MODELwaterMeter.waterMeterProofreadingDate;
           para[14].Value = MODELwaterMeter.waterMeteProofreadingPeriod;
           para[15].Value = MODELwaterMeter.waterUserId;
           para[16].Value = MODELwaterMeter.waterMeterParentId;
           para[17].Value = MODELwaterMeter.MEMO;
           if (MODELwaterMeter.waterMeterState == "1")
               para[18].Value = MODELwaterMeter.STARTUSEDATETIME;
           else
               para[18].Value = null;
           para[19].Value = MODELwaterMeter.isSummaryMeter;
           para[20].Value = MODELwaterMeter.ISUSECHANGE;


           //如果启用了自动变更新水价，则插入变更的月份和用水性质，如果没启用则不插入
           if (MODELwaterMeter.ISUSECHANGE == "1")
           {
               para[21].Value = MODELwaterMeter.CHANGEMONTH;
               para[22].Value = MODELwaterMeter.waterMeterTypeIdChange;
           }
           else
           {
               para[21].Value = null;
               para[22].Value = null;
           }
           para[23].Value = MODELwaterMeter.IsReverse;
           para[24].Value = MODELwaterMeter.WATERMETERLOCKNO;
           para[25].Value = MODELwaterMeter.SummaryMeterClass;
           para[26].Value = MODELwaterMeter.ChannelNO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
