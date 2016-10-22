using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
   public class BLLreadMeterRecord
   {
       public DataTable Query(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM readMeterRecord WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 查询包含滞纳金的抄表记录
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryContainOverDue(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_YSDETAIL_READMETERRECORD_CONTAINOVERDUE WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 获取阶梯水价字符，抄表机导入数据计算阶梯水价用
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public object QueryTrapezoidPrice(string strFilter)
       {
           object obj = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT trapezoidPrice FROM readMeterRecord WHERE 1=1 ");
           obj = DBUtility.DbHelperSQL.GetSingle(str.ToString() + strFilter);
           return obj;
       }
       /// <summary>
       /// 判断是否已抄表
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public object QueryIsReadMeter(string strFilter)
       {
           object obj = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT chargeState FROM readMeterRecord WHERE 1=1 ");
           obj = DBUtility.DbHelperSQL.GetSingle(str.ToString() + strFilter);
           return obj;
       }
       /// <summary>
       /// 判断是否已收费
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public object QueryIsCharge(string strFilter)
       {
           object obj = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT chargerID FROM readMeterRecord WHERE 1=1 ");
           obj = DBUtility.DbHelperSQL.GetSingle(str.ToString() + strFilter);
           return obj;
       }
       ///// <summary>
       ///// 查询抄表明细表
       ///// </summary>
       ///// <param name="strFilter"></param>
       ///// <returns></returns>
       //public DataTable QueryReadDetail(string strFilter)
       //{
       //    DataTable dt = new DataTable();
       //    StringBuilder str = new StringBuilder();
       //    str.Append("SELECT * FROM readMeterRecord INNER JOIN waterMeterType ON readMeterRecord.waterMeterTypeId=waterMeterType.waterMeterTypeId WHERE 1=1 ");
       //    dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
       //    return dt;
       //}
       #region 计算查抄率
       /// <summary>
       /// 查询抄表员查抄率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryMeterReadPercentByMeterReader(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           //str.Append("SELECT loginId AS 编号ID,USERNAME as 抄表员,count(*) AS 总表数,SUM(CASE CHARGESTATE WHEN '0'  THEN 1 ELSE 0 END) AS 未抄数量," +
           str.Append("SELECT loginId AS 编号ID,USERNAME as 抄表员,count(*) AS 总表数,SUM(CASE  WHEN (CHARGESTATE='0'OR waterMeterEndNumber=waterMeterLastNumber)  THEN 1 ELSE 0 END) AS 未抄数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'0' AND   waterMeterEndNumber<>waterMeterLastNumber THEN 1 ELSE 0 END) AS 已抄数量,'' AS 抄表率 " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by loginId,USERNAME ORDER BY loginId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按用户类型查询查抄率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryMeterReadPercentByWaterUserType(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterUserTypeId AS 编号ID,waterUserTypeName AS 用户类型,count(*) AS 总表数,SUM(CASE  WHEN (CHARGESTATE='0'OR waterMeterEndNumber=waterMeterLastNumber)  THEN 1 ELSE 0 END) AS 未抄数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'0' AND   waterMeterEndNumber<>waterMeterLastNumber THEN 1 ELSE 0 END) AS 已抄数量,'' AS 抄表率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by waterUserTypeId,waterUserTypeName ORDER BY waterUserTypeId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按抄表本号查询查抄率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryMeterReadPercentByMeterReadingNO(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT  meterReadingID AS 编号ID, meterReadingNO AS 抄表本号,count(*) AS 总表数,SUM(CASE  WHEN (CHARGESTATE='0'OR waterMeterEndNumber=waterMeterLastNumber)  THEN 1 ELSE 0 END) AS 未抄数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'0' AND   waterMeterEndNumber<>waterMeterLastNumber THEN 1 ELSE 0 END) AS 已抄数量,'' AS 抄表率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by meterReadingID,meterReadingNO  ORDER BY meterReadingID");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按用户查询查抄率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryMeterReadPercentByWaterUser(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterUserId AS 编号ID, waterUserNO AS 用户号,waterUserName AS 用户名,count(*) AS 总表数,SUM(CASE  WHEN (CHARGESTATE='0'OR waterMeterEndNumber=waterMeterLastNumber)  THEN 1 ELSE 0 END) AS 未抄数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'0' AND   waterMeterEndNumber<>waterMeterLastNumber THEN 1 ELSE 0 END) AS 已抄数量,'' AS 抄表率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by waterUserId,waterUserNO,waterUserName ORDER BY waterUserId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按水表查询查抄率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryMeterReadPercentByWaterMeter(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterMeterId AS 编号ID, waterMeterNo AS 水表编号,count(*) AS 总表数,SUM(CASE  WHEN (CHARGESTATE='0'OR waterMeterEndNumber=waterMeterLastNumber)  THEN 1 ELSE 0 END) AS 未抄数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'0' AND   waterMeterEndNumber<>waterMeterLastNumber THEN 1 ELSE 0 END) AS 已抄数量,'' AS 抄表率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by waterMeterId,waterMeterNo  ORDER BY waterMeterId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按区域查询查抄率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryMeterReadPercentByArea(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT areaId AS 编号ID, areaName AS 区域,count(*) AS 总表数,SUM(CASE  WHEN (CHARGESTATE='0'OR waterMeterEndNumber=waterMeterLastNumber)  THEN 1 ELSE 0 END) AS 未抄数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'0' AND   waterMeterEndNumber<>waterMeterLastNumber THEN 1 ELSE 0 END) AS 已抄数量,'' AS 抄表率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by areaId,areaName  ORDER BY areaId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       #endregion
       #region 计算收费率
       /// <summary>
       /// 查询抄表员收费率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryChargePercentByMeterReader(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT loginId AS 编号ID,USERNAME as 抄表员,count(*) AS 总表数,SUM(CASE chargeState WHEN '3'  THEN 1 ELSE 0 END) AS 已收数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'3'  THEN 1 ELSE 0 END) AS 未收数量,'' AS 收费率 " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by loginId,USERNAME ORDER BY loginId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按用户类型查询收费率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryChargePercentByWaterUserType(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterUserTypeId AS 编号ID,waterUserTypeName AS 用户类型,COUNT(*) AS 总表数,SUM(CASE CHARGESTATE WHEN '3'  THEN 1 ELSE 0 END) AS 已收数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'3'  THEN 1 ELSE 0 END) AS 未收数量,'' AS 收费率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by waterUserTypeId,waterUserTypeName ORDER BY waterUserTypeId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按抄表本号查询收费率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryChargePercentByMeterReadingNO(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT  meterReadingID AS 编号ID, meterReadingNO AS 抄表本号,count(*) AS 总表数,SUM(CASE CHARGESTATE WHEN '3'  THEN 1 ELSE 0 END) AS 已收数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'3'  THEN 1 ELSE 0 END) AS 未收数量,'' AS 收费率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by meterReadingID,meterReadingNO  ORDER BY meterReadingID");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按用户查询收费率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryChargePercentByWaterUser(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterUserId AS 编号ID, waterUserNO AS 用户号,waterUserName AS 用户名,count(*) AS 总表数,SUM(CASE CHARGESTATE WHEN '3'  THEN 1 ELSE 0 END) AS 已收数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'3'  THEN 1 ELSE 0 END) AS 未收数量,'' AS 收费率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by waterUserId,waterUserNO,waterUserName ORDER BY waterUserId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按水表查询收费率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryChargePercentByWaterMeter(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterMeterId AS 编号ID, waterMeterNo AS 水表编号,count(*) AS 总表数,SUM(CASE CHARGESTATE WHEN '3'  THEN 1 ELSE 0 END) AS 已收数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'3'  THEN 1 ELSE 0 END) AS 未收数量,'' AS 收费率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by waterMeterId,waterMeterNo  ORDER BY waterMeterId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按区域查询收费率
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryChargePercentByArea(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT areaId AS 编号ID, areaName AS 区域,count(*) AS 总表数,SUM(CASE CHARGESTATE WHEN '3'  THEN 1 ELSE 0 END) AS 已收数量," +
            "SUM(CASE  WHEN  CHARGESTATE<>'3'  THEN 1 ELSE 0 END) AS 未收数量,'' AS 收费率  " +
            "FROM readMeterRecord WHERE 1=1 "
            + strFilter + " group by areaId,areaName  ORDER BY areaId");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       #endregion
       /// <summary>
       /// 按水表查询应收水费
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryYSDetailByWaterMeter(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_YSDETAIL_BYWATERMETER WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 查询近期未收费的水表
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryWaterMeterDebt(string strFilter,int intCountPeriod)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_WATERUSER_CONNECTWATERMETER AA INNER JOIN  ");
           str.Append("(SELECT waterMeterId,COUNT(*) AS 未收期数 FROM readMeterRecord WHERE  WATERMETERNUMBERCHANGESTATE='0'   AND chargeState<'2'  ");
           str.Append(strFilter + " GROUP BY waterMeterId HAVING COUNT(*)>" + intCountPeriod + ") AS BB ");
           str.Append(" ON AA.WATERMETERID=BB.WATERMETERID ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 统计近期未收费的抄表记录
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable StaticsWaterMeterDebt(string strFilter, int intCountPeriod,string strType)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           switch (strType)
           {
               case "按抄表员":
                   str.Append("SELECT loginId AS 编号ID,USERNAME AS 抄表员,未收期数,COUNT(DISTINCT waterMeterId) AS 水表数量 FROM ( ");
                   str.Append("SELECT waterMeterId,loginId,USERNAME,COUNT(*) AS 未收期数 FROM  ");
                   str.Append("(SELECT * FROM readMeterRecord WHERE  WATERMETERNUMBERCHANGESTATE='0'   AND chargeState<'2' ");
                   str.Append(strFilter + ") AS AA ");
                   str.Append("GROUP BY waterMeterId,loginId,USERNAME HAVING COUNT(*)>" + intCountPeriod);
                   str.Append(")AS BB GROUP BY loginId,USERNAME,未收期数 ");
                   str.Append("ORDER BY loginId,未收期数");
                   break;
               case "按区域":
                   str.Append("SELECT areaId AS 编号ID,areaName AS 区域,未收期数,COUNT(DISTINCT waterMeterId) AS 水表数量 FROM ( ");
                   str.Append("SELECT waterMeterId,areaId,areaName,COUNT(*) AS 未收期数 FROM  ");
                   str.Append("(SELECT * FROM readMeterRecord WHERE  WATERMETERNUMBERCHANGESTATE='0'   AND chargeState<'2' ");
                   str.Append(strFilter + ") AS AA ");
                   str.Append("GROUP BY waterMeterId,areaId,areaName HAVING COUNT(*)>" + intCountPeriod);
                   str.Append(")AS BB GROUP BY areaId,areaName,未收期数 ");
                   str.Append("ORDER BY areaId,未收期数");
                   break;
               case "按抄表本":
                   str.Append("SELECT meterReadingID AS 编号ID,meterReadingNO AS 抄表本,未收期数,COUNT(DISTINCT waterMeterId) AS 水表数量 FROM ( ");
                   str.Append("SELECT waterMeterId,meterReadingID,meterReadingNO,COUNT(*) AS 未收期数 FROM  ");
                   str.Append("(SELECT * FROM readMeterRecord WHERE  WATERMETERNUMBERCHANGESTATE='0'   AND chargeState<'2' ");
                   str.Append(strFilter + ") AS AA ");
                   str.Append("GROUP BY waterMeterId,meterReadingID,meterReadingNO HAVING COUNT(*)>" + intCountPeriod);
                   str.Append(")AS BB GROUP BY meterReadingID,meterReadingNO,未收期数 ");
                   str.Append("ORDER BY meterReadingID,未收期数");
                   break;
               case "按水表":
                   str.Append("SELECT waterUserName AS 用户名,waterMeterNo AS 水表编号,COUNT(*) AS 未收期数 FROM  ");
                   str.Append("(SELECT * FROM readMeterRecord WHERE  WATERMETERNUMBERCHANGESTATE='0'   AND chargeState<'2' ");
                   str.Append(strFilter + ") AS AA ");
                   str.Append("GROUP BY waterMeterNo,waterUserName HAVING COUNT(*)>" + intCountPeriod);
                   break;
           }
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 查询应收水费中的用户ID
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryYSDetailDistinctWaterUser(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT DISTINCT WATERUSERID FROM V_YSDETAIL_BYWATERMETER WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按户查询应收水费
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryYSDetailByWaterUser(string strFilter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("SELECT waterUserId,waterUserNO,waterUserName,waterUserAddress,");
           str.Append("SUM(waterTotalChargeEND) AS waterTotalChargeEND,");
           str.Append("SUM(extraTotalChargeEND) AS extraTotalChargeEND,");
           str.Append("SUM(OVERDUEEND) AS OVERDUEEND,");
           str.Append("SUM(totalChargeEND) AS totalChargeEND FROM ");
           str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
           str.Append(strFilter);
           str.Append(") AS AA GROUP BY waterUserId,waterUserNO,waterUserName,waterUserAddress");

           DataTable dt = new DataTable();
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           //dt = DBUtility.DbHelperSQL.ExecuteProOnePara(strProName, strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 查询用户欠费总金额
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public object QueryQFByWaterUser(string strWaterUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("SELECT SUM(totalChargeEND) FROM V_YSDETAIL_BYWATERMETER  WHERE chargeState='1' AND WATERUSERID='"+strWaterUserID+"'");

           object objSum = DBUtility.DbHelperSQL.GetSingle(str.ToString());
           //dt = DBUtility.DbHelperSQL.ExecuteProOnePara(strProName, strFilter).Tables[0];
           return objSum;
       }

       /// <summary>
       /// 根据统计类型统计应收水费
       /// </summary>
       /// <param name="strFilter">查询的条件</param>
       /// <param name="strType">统计类型</param>
       /// <returns></returns>
       public DataTable YSStatics(string strFilter, string strType)
       {
           StringBuilder str = new StringBuilder();
           switch (strType)
           {
               case "用户号":
                   str.Append("SELECT waterUserNO AS 用户号,waterUserName AS 用户名,waterUserAddress AS 用户地址,");
                   str.Append("COUNT(*) AS 应收单数量,SUM(totalNumber) AS 总用水量,");
                   str.Append("SUM(waterTotalChargeEND) AS 应收水费,");
                   str.Append("SUM(extraCharge1) AS 应收污水处理费,");
                   str.Append("SUM(extraCharge2) AS 应收附加费,");
                   str.Append("SUM(extraTotalChargeEND) AS 应收附加费合计,");
                   str.Append("SUM(OVERDUEEND) AS 应收滞纳金,");
                   str.Append("SUM(totalChargeEND) AS 应收合计 FROM ");
                   str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
                   str.Append(strFilter);
                   str.Append(") AS AA GROUP BY waterUserId,waterUserNO,waterUserName,waterUserAddress");
                   break;
               case "用户类型":
                   str.Append("SELECT waterUserTypeId AS 用户类型编号,waterUserTypeName AS 用户类型,");
                   str.Append("COUNT(*) AS 应收单数量,SUM(totalNumber) AS 总用水量,");
                   str.Append("SUM(waterTotalChargeEND)  AS 应收水费,");
                   str.Append("SUM(extraCharge1) AS 应收污水处理费,");
                   str.Append("SUM(extraCharge2) AS 应收附加费,");
                   str.Append("SUM(extraTotalChargeEND) AS 应收附加费合计,");
                   str.Append("SUM(OVERDUEEND) AS 应收滞纳金,");
                   str.Append("SUM(totalChargeEND) AS 应收合计 FROM ");
                   str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
                   str.Append(strFilter);
                   str.Append(") AS AA GROUP BY waterUserTypeId,waterUserTypeName");
                   break;
               case "抄表本":
                   str.Append("SELECT meterReadingID AS 抄表本编号,meterReadingNO AS 抄表本,");
                   str.Append("COUNT(*) AS 应收单数量,SUM(totalNumber) AS 总用水量,");
                   str.Append("SUM(waterTotalChargeEND)  AS 应收水费,");
                   str.Append("SUM(extraCharge1) AS 应收污水处理费,");
                   str.Append("SUM(extraCharge2) AS 应收附加费,");
                   str.Append("SUM(extraTotalChargeEND) AS 应收附加费合计,");
                   str.Append("SUM(OVERDUEEND) AS 应收滞纳金,");
                   str.Append("SUM(totalChargeEND) AS 应收合计 FROM ");
                   str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
                   str.Append(strFilter);
                   str.Append(") AS AA GROUP BY meterReadingID,meterReadingNO");
                   break;
               case "区域":
                   str.Append("SELECT areaId AS 区域编号,areaName AS 区域名称,");
                   str.Append("COUNT(*) AS 应收单数量,SUM(totalNumber) AS 总用水量,");
                   str.Append("SUM(waterTotalChargeEND)  AS 应收水费,");
                   str.Append("SUM(extraCharge1) AS 应收污水处理费,");
                   str.Append("SUM(extraCharge2) AS 应收附加费,");
                   str.Append("SUM(extraTotalChargeEND) AS 应收附加费合计,");
                   str.Append("SUM(OVERDUEEND) AS 应收滞纳金,");
                   str.Append("SUM(totalChargeEND) AS 应收合计 FROM ");
                   str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
                   str.Append(strFilter);
                   str.Append(") AS AA GROUP BY areaId,areaName");
                   break;
               case "抄表员":
                   str.Append("SELECT loginId AS 抄表员编号,USERNAME AS 抄表员,waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质,");
                   str.Append("COUNT(*) AS 应收单数量,SUM(totalNumber) AS 总用水量,");
                   str.Append("SUM(waterTotalChargeEND)  AS 应收水费,");
                   str.Append("SUM(extraCharge1) AS 应收污水处理费,");
                   str.Append("SUM(extraCharge2) AS 应收附加费,");
                   str.Append("SUM(extraTotalChargeEND) AS 应收附加费合计,");
                   str.Append("SUM(OVERDUEEND) AS 应收滞纳金,");
                   str.Append("SUM(totalChargeEND) AS 应收合计 FROM ");
                   str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
                   str.Append(strFilter);
                   str.Append(") AS AA GROUP BY loginId,USERNAME,waterMeterTypeId,waterMeterTypeName");
                   break;
               case "银行托收":
                   str.Append("SELECT agentsignS AS 银行托收,");
                   str.Append("COUNT(*) AS 应收单数量,SUM(totalNumber) AS 总用水量,");
                   str.Append("SUM(waterTotalChargeEND)  AS 应收水费,");
                   str.Append("SUM(extraCharge1) AS 应收污水处理费,");
                   str.Append("SUM(extraCharge2) AS 应收附加费,");
                   str.Append("SUM(extraTotalChargeEND) AS 应收附加费合计,");
                   str.Append("SUM(OVERDUEEND) AS 应收滞纳金,");
                   str.Append("SUM(totalChargeEND) AS 应收合计 FROM ");
                   str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
                   str.Append(strFilter);
                   str.Append(") AS AA GROUP BY agentsignS");
                   break;
               case "托收银行":
                   str.Append("SELECT ISNULL(bankId,'无') AS 银行编号,ISNULL(bankName,'无') AS 托收银行,");
                   str.Append("COUNT(*) AS 应收单数量,SUM(totalNumber) AS 总用水量,");
                   str.Append("SUM(waterTotalChargeEND)  AS 应收水费,");
                   str.Append("SUM(extraCharge1) AS 应收污水处理费,");
                   str.Append("SUM(extraCharge2) AS 应收附加费,");
                   str.Append("SUM(extraTotalChargeEND) AS 应收附加费合计,");
                   str.Append("SUM(OVERDUEEND) AS 应收滞纳金,");
                   str.Append("SUM(totalChargeEND) AS 应收合计 FROM ");
                   str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
                   str.Append(strFilter);
                   str.Append(") AS AA GROUP BY bankId,bankName");
                   break;
               case "用水性质":
                   str.Append("SELECT waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质,");
                   str.Append("COUNT(*) AS 应收单数量,SUM(totalNumber) AS 总用水量,");
                   str.Append("SUM(waterTotalChargeEND)  AS 应收水费,");
                   str.Append("SUM(extraCharge1) AS 应收污水处理费,");
                   str.Append("SUM(extraCharge2) AS 应收附加费,");
                   str.Append("SUM(extraTotalChargeEND) AS 应收附加费合计,");
                   str.Append("SUM(OVERDUEEND) AS 应收滞纳金,");
                   str.Append("SUM(totalChargeEND) AS 应收合计 FROM ");
                   str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
                   str.Append(strFilter);
                   str.Append(") AS AA GROUP BY waterMeterTypeId,waterMeterTypeName");
                   break;
               case "水表口径":
                   str.Append("SELECT CAST(waterMeterSizeValue AS VARCHAR) AS 水表口径,");
                   str.Append("COUNT(*) AS 应收单数量,SUM(totalNumber) AS 总用水量,");
                   str.Append("SUM(waterTotalChargeEND)  AS 应收水费,");
                   str.Append("SUM(extraCharge1) AS 应收污水处理费,");
                   str.Append("SUM(extraCharge2) AS 应收附加费,");
                   str.Append("SUM(extraTotalChargeEND) AS 应收附加费合计,");
                   str.Append("SUM(OVERDUEEND) AS 应收滞纳金,");
                   str.Append("SUM(totalChargeEND) AS 应收合计 FROM ");
                   str.Append("(SELECT * FROM V_YSDETAIL_BYWATERMETER  WHERE 1=1 ");
                   str.Append(strFilter);
                   str.Append(") AS AA GROUP BY waterMeterSizeValue");
                   break;
           }

           DataTable dt = new DataTable();
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           //dt = DBUtility.DbHelperSQL.ExecuteProOnePara(strProName, strFilter).Tables[0];
           return dt;
       }
       public DataTable WaterFeeStatisticsByWaterUser(string strProName, string strFilter,string strGroupType)
       {
           DataTable dt = new DataTable();
           dt = DBUtility.DbHelperSQL.ExecuteProTwoPara(strProName, strFilter, strGroupType).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按用户统计应收水费
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable GetReadMeterException(string strProName, string strFilter, DateTime dtYearAndMonth,int intMonthCount,decimal fRangeValue)
       {
           DataTable dt = new DataTable();
           dt = DBUtility.DbHelperSQL.ExecuteProFourthPara(strProName, strFilter, dtYearAndMonth, intMonthCount, fRangeValue).Tables[0];
           return dt;
       }
       /// <summary>
       /// 查询减免后的水费
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryReadMeterRecordRemit(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_readMeterRecord_WaterFeeRemit WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据用户汇总欠费总金额,不含年月份统计
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryDebts(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_DEBTSSUM_GROUPBYWATERUSER WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 根据用户汇总欠费总金额，含年月份统计
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryDebtsByYearMonth(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_DEBTSSUM_GROUPBYWATERUSER_YEARANDMONTH WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       public DataTable QueryWaterUser(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT DISTINCT waterUserId FROM readMeterRecord WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       public DataTable StaticsInform(string strFilter,string strType)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           switch (strType)
           {
               case "按抄表员":
                   str.Append("SELECT loginId AS 抄表员编号,USERNAME AS 抄表员,waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质,COUNT(*) AS 单据数量,");
                   str.Append("SUM(totalNumber) AS 用水量,SUM(waterTotalChargeEND) AS 水费, SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费,  ");
                   str.Append("SUM(totalChargeEND) AS 应收水费   FROM V_YSDETAIL_BYWATERMETER WHERE INFORMPRINTSIGN='1' ");
                   str.Append(strFilter + " GROUP BY loginId,USERNAME,waterMeterTypeId,waterMeterTypeName ORDER BY loginId");
                   break;
               case "按结算员":
                   str.Append("SELECT PRINTWORKERID AS 结算员编号,PRINTWORKERNAME AS 结算员,waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质,COUNT(*) AS 单据数量,");
                   str.Append("SUM(totalNumber) AS 用水量,SUM(waterTotalChargeEND) AS 水费,SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费,  ");
                   str.Append("SUM(totalChargeEND) AS 应收水费   FROM V_YSDETAIL_BYWATERMETER WHERE INFORMPRINTSIGN='1' ");
                   str.Append(strFilter + " GROUP BY PRINTWORKERID,PRINTWORKERNAME,waterMeterTypeId,waterMeterTypeName ORDER BY PRINTWORKERID");
                   break;
               case "按抄表本":
                   str.Append("SELECT meterReadingID AS 编号ID,meterReadingNO AS 抄表本,COUNT(*) AS 单据数量,");
                   str.Append("SUM(totalNumber) AS 用水量,SUM(waterTotalChargeEND) AS 水费,SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费,  ");
                   str.Append("SUM(totalChargeEND) AS 应收水费   FROM V_YSDETAIL_BYWATERMETER WHERE INFORMPRINTSIGN='1' ");
                   str.Append(strFilter + " GROUP BY meterReadingID,meterReadingNO ORDER BY meterReadingNO");
                   break;
           }
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 获取最大通知单号
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public object GetMaxInformNO(string strFilter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("SELECT MAX(INFORMNO) FROM readMeterRecord WHERE 1=1 ");
           object obj = DBUtility.DbHelperSQL.GetSingle(str.ToString() + strFilter);
           return obj;
       }
       /// <summary>
       /// 获取最后一次抄表的表数
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable GetLastNumber(string strFilter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("SELECT TOP 1 readMeterRecordId,waterMeterEndNumber,readMeterRecordYear,readMeterRecordMonth,CHARGEDATETIME,readMeterRecordDate FROM V_READMETERRECORD_LEFT_WATERFEECHARGE WHERE 1=1");
           DataTable dtLastNumber = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dtLastNumber;
       }
       /// <summary>
       /// 删除抄表记录
       /// </summary>
       /// <param name="strUserID"></param>
       /// <returns></returns>
       public bool Delete(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM readMeterRecord WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 根据语句删除抄表记录
       /// </summary>
       /// <param name="strUserID"></param>
       /// <returns></returns>
       public int DeleteBySQL(string strFilter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM readMeterRecord WHERE 1=1 ");
           int intCount=DBUtility.DbHelperSQL.ExecuteSql(str.ToString()+strFilter);
           return intCount;
       }
       /// <summary>
       /// 根据语句归零抄表记录
       /// </summary>
       /// <param name="strUserID"></param>
       /// <returns></returns>
       public int BackZeroBySQL(string strFilter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET waterMeterLastNumber=0,waterMeterEndNumber=0,totalNumber=0,chargeState='0' WHERE 1=1 ");
           int intCount = DBUtility.DbHelperSQL.ExecuteSql(str.ToString() + strFilter);
           return intCount;
       }
       /// <summary>
       /// 将抄表记录更新至抄表表
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool Update(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET waterMeterLastNumber=@waterMeterLastNumber,waterMeterEndNumber=@waterMeterEndNumber,"+
               "totalNumber=@totalNumber,totalNumberDescribe=@totalNumberDescribe,avePrice=@avePrice,avePriceDescribe=@avePriceDescribe,waterTotalCharge=@waterTotalCharge," +
               "extraChargePrice1=@extraChargePrice1,extraChargePrice2=@extraChargePrice2,extraChargePrice3=@extraChargePrice3,"+
               "extraChargePrice4=@extraChargePrice4,extraChargePrice5=@extraChargePrice5," +
               "extraChargePrice6=@extraChargePrice6,extraChargePrice7=@extraChargePrice7,extraChargePrice8=@extraChargePrice8," +
               "extraCharge1=@extraCharge1,extraCharge2=@extraCharge2,extraCharge3=@extraCharge3,extraCharge4=@extraCharge4,extraCharge5=@extraCharge5,"+
               "extraCharge6=@extraCharge6,extraCharge7=@extraCharge7,extraCharge8=@extraCharge8,extraTotalCharge=@extraTotalCharge,"+
               "trapezoidPrice=@trapezoidPrice,totalCharge=@totalCharge,readMeterRecordDate=@readMeterRecordDate,chargeState=@chargeState,SubMeterNumber=@SubMeterNumber ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterLastNumber",SqlDbType.Int),
               new SqlParameter("@waterMeterEndNumber",SqlDbType.Int),
               new SqlParameter("@totalNumber",SqlDbType.Int),
               new SqlParameter("@totalNumberDescribe",SqlDbType.VarChar,500),
               new SqlParameter("@avePrice",SqlDbType.Decimal),
               new SqlParameter("@avePriceDescribe",SqlDbType.VarChar,500),
               new SqlParameter("@waterTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice1",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice2",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice3",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice4",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice5",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice6",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice7",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice8",SqlDbType.Decimal),
               new SqlParameter("@extraCharge1",SqlDbType.Decimal),
               new SqlParameter("@extraCharge2",SqlDbType.Decimal),
               new SqlParameter("@extraCharge3",SqlDbType.Decimal),
               new SqlParameter("@extraCharge4",SqlDbType.Decimal),
               new SqlParameter("@extraCharge5",SqlDbType.Decimal),
               new SqlParameter("@extraCharge6",SqlDbType.Decimal),
               new SqlParameter("@extraCharge7",SqlDbType.Decimal),
               new SqlParameter("@extraCharge8",SqlDbType.Decimal),
               new SqlParameter("@extraTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@trapezoidPrice",SqlDbType.VarChar,1000),
               new SqlParameter("@totalCharge",SqlDbType.Decimal),
               new SqlParameter("@readMeterRecordDate",SqlDbType.DateTime),
               new SqlParameter("@chargeState",SqlDbType.VarChar,10),
               new SqlParameter("@SubMeterNumber",SqlDbType.Int),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.waterMeterLastNumber;
           para[1].Value = MODELreadMeterRecord.waterMeterEndNumber;
           para[2].Value = MODELreadMeterRecord.totalNumber;
           para[3].Value = MODELreadMeterRecord.totalNumberDescribe;
           para[4].Value = MODELreadMeterRecord.avePrice;
           para[5].Value = MODELreadMeterRecord.avePriceDescribe;
           para[6].Value = MODELreadMeterRecord.waterTotalCharge;
           para[7].Value = MODELreadMeterRecord.extraChargePrice1;
           para[8].Value = MODELreadMeterRecord.extraChargePrice2;
           para[9].Value = MODELreadMeterRecord.extraChargePrice3;
           para[10].Value = MODELreadMeterRecord.extraChargePrice4;
           para[11].Value = MODELreadMeterRecord.extraChargePrice5;
           para[12].Value = MODELreadMeterRecord.extraChargePrice6;
           para[13].Value = MODELreadMeterRecord.extraChargePrice7;
           para[14].Value = MODELreadMeterRecord.extraChargePrice8;
           para[15].Value = MODELreadMeterRecord.extraCharge1;
           para[16].Value = MODELreadMeterRecord.extraCharge2;
           para[17].Value = MODELreadMeterRecord.extraCharge3;
           para[18].Value = MODELreadMeterRecord.extraCharge4;
           para[19].Value = MODELreadMeterRecord.extraCharge5;
           para[20].Value = MODELreadMeterRecord.extraCharge6;
           para[21].Value = MODELreadMeterRecord.extraCharge7;
           para[22].Value = MODELreadMeterRecord.extraCharge8;
           para[23].Value = MODELreadMeterRecord.extraTotalCharge;
           para[24].Value = MODELreadMeterRecord.trapezoidPrice;
           para[25].Value = MODELreadMeterRecord.totalCharge;

           //如果是抄表则存储时间，如果为删除抄表则取消抄表时间
           if (MODELreadMeterRecord.chargeState == "1")
               para[26].Value = MODELreadMeterRecord.readMeterRecordDate;
           else
               para[26].Value = null;

           para[27].Value = MODELreadMeterRecord.chargeState;
           para[28].Value = MODELreadMeterRecord.SubMeterNumber;
           para[29].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 变更抄表记录中错误的用水性质
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateHandSetWaterMeterType(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET waterMeterTypeId=@waterMeterTypeId," +
               "waterMeterTypeName=@waterMeterTypeName,avePrice=@avePrice," +
               "extraChargePrice1=@extraChargePrice1,extraChargePrice2=@extraChargePrice2,trapezoidPrice=@trapezoidPrice,extraCharge=@extraCharge,MEMO=ISNULL(MEMO,'')+@MEMO ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeName",SqlDbType.VarChar,50),
               new SqlParameter("@avePrice",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice1",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice2",SqlDbType.Decimal),
               new SqlParameter("@trapezoidPrice",SqlDbType.VarChar,1000),
               new SqlParameter("@extraCharge",SqlDbType.VarChar,1000),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.waterMeterTypeId;
           para[1].Value = MODELreadMeterRecord.waterMeterTypeName;
           para[2].Value = MODELreadMeterRecord.avePrice;
           para[3].Value = MODELreadMeterRecord.extraChargePrice1;
           para[4].Value = MODELreadMeterRecord.extraChargePrice2;
           para[5].Value = MODELreadMeterRecord.trapezoidPrice;
           para[6].Value = MODELreadMeterRecord.extraCharge;
           para[7].Value = MODELreadMeterRecord.MEMO;
           para[8].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 变更抄表记录的水表初始读数
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateHandSetWaterMeterLastNumber(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET waterMeterLastNumber=@waterMeterLastNumber,MEMO=ISNULL(MEMO,'')+@MEMO ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterLastNumber",SqlDbType.Int),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.waterMeterLastNumber;
           para[1].Value = MODELreadMeterRecord.MEMO;
           para[2].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 变更抄表记录中用户名
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateHandSetWaterUserName(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET waterUserName=@waterUserName ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterUserName",SqlDbType.VarChar,30),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.waterUserName;
           para[1].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 将抄表记录置为未抄
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool SetNotRead(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET waterMeterEndNumber=@waterMeterEndNumber," +
               "totalNumber=@totalNumber,totalNumberDescribe=@totalNumberDescribe,avePrice=@avePrice,avePriceDescribe=@avePriceDescribe,waterTotalCharge=@waterTotalCharge," +
               "extraChargePrice1=@extraChargePrice1,extraChargePrice2=@extraChargePrice2,extraChargePrice3=@extraChargePrice3," +
               "extraChargePrice4=@extraChargePrice4,extraChargePrice5=@extraChargePrice5," +
               "extraChargePrice6=@extraChargePrice6,extraChargePrice7=@extraChargePrice7,extraChargePrice8=@extraChargePrice8," +
               "extraCharge1=@extraCharge1,extraCharge2=@extraCharge2,extraCharge3=@extraCharge3,extraCharge4=@extraCharge4,extraCharge5=@extraCharge5," +
               "extraCharge6=@extraCharge6,extraCharge7=@extraCharge7,extraCharge8=@extraCharge8,extraTotalCharge=@extraTotalCharge," +
               "totalCharge=@totalCharge,readMeterRecordDate=@readMeterRecordDate,chargeState=@chargeState,SUBMETERNUMBER=@SUBMETERNUMBER ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterEndNumber",SqlDbType.Int),
               new SqlParameter("@totalNumber",SqlDbType.Int),
               new SqlParameter("@totalNumberDescribe",SqlDbType.VarChar,500),
               new SqlParameter("@avePrice",SqlDbType.Decimal),
               new SqlParameter("@avePriceDescribe",SqlDbType.VarChar,500),
               new SqlParameter("@waterTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice1",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice2",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice3",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice4",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice5",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice6",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice7",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice8",SqlDbType.Decimal),
               new SqlParameter("@extraCharge1",SqlDbType.Decimal),
               new SqlParameter("@extraCharge2",SqlDbType.Decimal),
               new SqlParameter("@extraCharge3",SqlDbType.Decimal),
               new SqlParameter("@extraCharge4",SqlDbType.Decimal),
               new SqlParameter("@extraCharge5",SqlDbType.Decimal),
               new SqlParameter("@extraCharge6",SqlDbType.Decimal),
               new SqlParameter("@extraCharge7",SqlDbType.Decimal),
               new SqlParameter("@extraCharge8",SqlDbType.Decimal),
               new SqlParameter("@extraTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@totalCharge",SqlDbType.Decimal),
               new SqlParameter("@readMeterRecordDate",SqlDbType.DateTime),
               new SqlParameter("@chargeState",SqlDbType.VarChar,10),
               new SqlParameter("@SUBMETERNUMBER",SqlDbType.Int),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.waterMeterEndNumber;
           para[1].Value = MODELreadMeterRecord.totalNumber;
           para[2].Value = MODELreadMeterRecord.totalNumberDescribe;
           para[3].Value = MODELreadMeterRecord.avePrice;
           para[4].Value = MODELreadMeterRecord.avePriceDescribe;
           para[5].Value = MODELreadMeterRecord.waterTotalCharge;
           para[6].Value = MODELreadMeterRecord.extraChargePrice1;
           para[7].Value = MODELreadMeterRecord.extraChargePrice2;
           para[8].Value = MODELreadMeterRecord.extraChargePrice3;
           para[9].Value = MODELreadMeterRecord.extraChargePrice4;
           para[10].Value = MODELreadMeterRecord.extraChargePrice5;
           para[11].Value = MODELreadMeterRecord.extraChargePrice6;
           para[12].Value = MODELreadMeterRecord.extraChargePrice7;
           para[13].Value = MODELreadMeterRecord.extraChargePrice8;
           para[14].Value = MODELreadMeterRecord.extraCharge1;
           para[15].Value = MODELreadMeterRecord.extraCharge2;
           para[16].Value = MODELreadMeterRecord.extraCharge3;
           para[17].Value = MODELreadMeterRecord.extraCharge4;
           para[18].Value = MODELreadMeterRecord.extraCharge5;
           para[19].Value = MODELreadMeterRecord.extraCharge6;
           para[20].Value = MODELreadMeterRecord.extraCharge7;
           para[21].Value = MODELreadMeterRecord.extraCharge8;
           para[22].Value = MODELreadMeterRecord.extraTotalCharge;
           para[23].Value = MODELreadMeterRecord.totalCharge;

           //如果是抄表则存储时间，如果为删除抄表则取消抄表时间
           if (MODELreadMeterRecord.chargeState == "1")
               para[24].Value = MODELreadMeterRecord.readMeterRecordDate;
           else
               para[24].Value = null;

           para[25].Value = MODELreadMeterRecord.chargeState;
           para[26].Value = MODELreadMeterRecord.SubMeterNumber;
           para[27].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /*
       /// <summary>
       /// 将抄表记录置为未抄
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool SetNotRead(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET waterMeterEndNumber=@waterMeterEndNumber," +
               "totalNumber=@totalNumber,totalNumberDescribe=@totalNumberDescribe,avePrice=@avePrice,avePriceDescribe=@avePriceDescribe,waterTotalCharge=@waterTotalCharge," +
               "extraChargePrice1=@extraChargePrice1,extraChargePrice2=@extraChargePrice2,extraChargePrice3=@extraChargePrice3," +
               "extraChargePrice4=@extraChargePrice4,extraChargePrice5=@extraChargePrice5," +
               "extraChargePrice6=@extraChargePrice6,extraChargePrice7=@extraChargePrice7,extraChargePrice8=@extraChargePrice8," +
               "extraCharge1=@extraCharge1,extraCharge2=@extraCharge2,extraCharge3=@extraCharge3,extraCharge4=@extraCharge4,extraCharge5=@extraCharge5," +
               "extraCharge6=@extraCharge6,extraCharge7=@extraCharge7,extraCharge8=@extraCharge8,extraTotalCharge=@extraTotalCharge," +
               "trapezoidPrice=@trapezoidPrice,totalCharge=@totalCharge,readMeterRecordDate=@readMeterRecordDate,chargeState=@chargeState ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterEndNumber",SqlDbType.Int),
               new SqlParameter("@totalNumber",SqlDbType.Int),
               new SqlParameter("@totalNumberDescribe",SqlDbType.VarChar,500),
               new SqlParameter("@avePrice",SqlDbType.Decimal),
               new SqlParameter("@avePriceDescribe",SqlDbType.VarChar,500),
               new SqlParameter("@waterTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice1",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice2",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice3",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice4",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice5",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice6",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice7",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice8",SqlDbType.Decimal),
               new SqlParameter("@extraCharge1",SqlDbType.Decimal),
               new SqlParameter("@extraCharge2",SqlDbType.Decimal),
               new SqlParameter("@extraCharge3",SqlDbType.Decimal),
               new SqlParameter("@extraCharge4",SqlDbType.Decimal),
               new SqlParameter("@extraCharge5",SqlDbType.Decimal),
               new SqlParameter("@extraCharge6",SqlDbType.Decimal),
               new SqlParameter("@extraCharge7",SqlDbType.Decimal),
               new SqlParameter("@extraCharge8",SqlDbType.Decimal),
               new SqlParameter("@extraTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@trapezoidPrice",SqlDbType.VarChar,1000),
               new SqlParameter("@totalCharge",SqlDbType.Decimal),
               new SqlParameter("@readMeterRecordDate",SqlDbType.DateTime),
               new SqlParameter("@chargeState",SqlDbType.VarChar,10),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.waterMeterEndNumber;
           para[1].Value = MODELreadMeterRecord.totalNumber;
           para[2].Value = MODELreadMeterRecord.totalNumberDescribe;
           para[3].Value = MODELreadMeterRecord.avePrice;
           para[4].Value = MODELreadMeterRecord.avePriceDescribe;
           para[5].Value = MODELreadMeterRecord.waterTotalCharge;
           para[6].Value = MODELreadMeterRecord.extraChargePrice1;
           para[7].Value = MODELreadMeterRecord.extraChargePrice2;
           para[8].Value = MODELreadMeterRecord.extraChargePrice3;
           para[9].Value = MODELreadMeterRecord.extraChargePrice4;
           para[10].Value = MODELreadMeterRecord.extraChargePrice5;
           para[11].Value = MODELreadMeterRecord.extraChargePrice6;
           para[12].Value = MODELreadMeterRecord.extraChargePrice7;
           para[13].Value = MODELreadMeterRecord.extraChargePrice8;
           para[14].Value = MODELreadMeterRecord.extraCharge1;
           para[15].Value = MODELreadMeterRecord.extraCharge2;
           para[16].Value = MODELreadMeterRecord.extraCharge3;
           para[17].Value = MODELreadMeterRecord.extraCharge4;
           para[18].Value = MODELreadMeterRecord.extraCharge5;
           para[19].Value = MODELreadMeterRecord.extraCharge6;
           para[20].Value = MODELreadMeterRecord.extraCharge7;
           para[21].Value = MODELreadMeterRecord.extraCharge8;
           para[22].Value = MODELreadMeterRecord.extraTotalCharge;
           para[23].Value = MODELreadMeterRecord.trapezoidPrice;
           para[24].Value = MODELreadMeterRecord.totalCharge;

           //如果是抄表则存储时间，如果为删除抄表则取消抄表时间
           if (MODELreadMeterRecord.chargeState == "1")
               para[25].Value = MODELreadMeterRecord.readMeterRecordDate;
           else
               para[25].Value = null;

           para[26].Value = MODELreadMeterRecord.chargeState;
           para[27].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }*/
       /// <summary>
       /// 将从抄表机里的数据更新至抄表记录,同时更新用户余额及累计欠费信息
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateHandSetDataAndArrearage(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET waterMeterEndNumber=@waterMeterEndNumber," +
               "totalNumber=@totalNumber,waterTotalCharge=@waterTotalCharge," +
               "extraCharge1=@extraCharge1,extraTotalCharge=@extraTotalCharge," +
               "totalCharge=@totalCharge,readMeterRecordDate=@readMeterRecordDate,chargeState=@chargeState,"+
               "checkState=@checkState,checkDateTime=@checkDateTime,checker=@checker,chargeID=@chargeID,avePrice=@avePrice,"+
               "extraChargePrice1=@extraChargePrice1,extraChargePrice2=@extraChargePrice2,extraCharge2=@extraCharge2," +
               "WATERUSERQQYE=@WATERUSERQQYE,WATERUSERJSYE=@WATERUSERJSYE,WATERUSERLJQF=@WATERUSERLJQF,MEMO=@MEMO ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterMeterEndNumber",SqlDbType.Int),
               new SqlParameter("@totalNumber",SqlDbType.Int),
               new SqlParameter("@waterTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@extraCharge1",SqlDbType.Decimal),
               new SqlParameter("@extraTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@totalCharge",SqlDbType.Decimal),
               new SqlParameter("@readMeterRecordDate",SqlDbType.DateTime),
               new SqlParameter("@chargeState",SqlDbType.VarChar,10),
               new SqlParameter("@checkState",SqlDbType.VarChar,10),
               new SqlParameter("@checkDateTime",SqlDbType.DateTime),
               new SqlParameter("@checker",SqlDbType.VarChar,50),
               new SqlParameter("@chargeID",SqlDbType.VarChar,50),
               new SqlParameter("@avePrice",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice1",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice2",SqlDbType.Decimal),
               new SqlParameter("@extraCharge2",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERQQYE",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERJSYE",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERLJQF",SqlDbType.Decimal),
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.waterMeterEndNumber;
           para[1].Value = MODELreadMeterRecord.totalNumber;
           para[2].Value = MODELreadMeterRecord.waterTotalCharge;
           para[3].Value = MODELreadMeterRecord.extraCharge1;
           para[4].Value = MODELreadMeterRecord.extraTotalCharge;
           para[5].Value = MODELreadMeterRecord.totalCharge;
           para[6].Value = MODELreadMeterRecord.readMeterRecordDate;
           para[7].Value = MODELreadMeterRecord.chargeState;
           para[8].Value = MODELreadMeterRecord.checkState;
           if (MODELreadMeterRecord.checkState == "0")
               para[9].Value = null;
           else
           para[9].Value = MODELreadMeterRecord.checkDateTime;
           para[10].Value = MODELreadMeterRecord.checker;
           para[11].Value = MODELreadMeterRecord.chargeID;
           para[12].Value = MODELreadMeterRecord.avePrice;
           para[13].Value = MODELreadMeterRecord.extraChargePrice1;
           para[14].Value = MODELreadMeterRecord.extraChargePrice2;
           para[15].Value = MODELreadMeterRecord.extraCharge2;
           para[16].Value = MODELreadMeterRecord.WATERUSERQQYE;
           para[17].Value = MODELreadMeterRecord.WATERUSERJSYE;
           para[18].Value = MODELreadMeterRecord.WATERUSERLJQF;
           para[19].Value = MODELreadMeterRecord.MEMO;
           para[20].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 更细抄表机未抄原因
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateHandSetDataNullRecordMemo(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET MEMO=@MEMO ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@MEMO",SqlDbType.VarChar,50),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.MEMO;
           para[1].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 更新抄表记录审核状态
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateCheckState(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET checkState=@checkState,checkDateTime=@checkDateTime,checker=@checker ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@checkState",SqlDbType.VarChar,10),
               new SqlParameter("@checkDateTime",SqlDbType.DateTime),
               new SqlParameter("@checker",SqlDbType.VarChar,50),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.checkState;
           if (Convert.ToDateTime(MODELreadMeterRecord.checkDateTime)>Convert.ToDateTime("2015-04-14"))
           para[1].Value = MODELreadMeterRecord.checkDateTime;
           else
               para[1].Value = null;

           if (MODELreadMeterRecord.checker != "")
               para[2].Value = MODELreadMeterRecord.checker;
           else
               para[2].Value = null;

           para[3].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 手工审核更新抄表记录审核状态及前期余额、累计欠费、用户余额等字段
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateCheckStateAndArrearage(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET checkState=@checkState,checkDateTime=@checkDateTime,checker=@checker,"+
               "WATERUSERQQYE=@WATERUSERQQYE,WATERUSERJSYE=@WATERUSERJSYE,WATERUSERLJQF=@WATERUSERLJQF ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@checkState",SqlDbType.VarChar,10),
               new SqlParameter("@checkDateTime",SqlDbType.DateTime),
               new SqlParameter("@checker",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERQQYE",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERJSYE",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERLJQF",SqlDbType.Decimal),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.checkState;
           if (Convert.ToDateTime(MODELreadMeterRecord.checkDateTime) > Convert.ToDateTime("2015-04-14"))
               para[1].Value = MODELreadMeterRecord.checkDateTime;
           else
               para[1].Value = null;

           if (MODELreadMeterRecord.checker != "")
               para[2].Value = MODELreadMeterRecord.checker;
           else
               para[2].Value = null;

           para[3].Value = MODELreadMeterRecord.WATERUSERQQYE;
           para[4].Value = MODELreadMeterRecord.WATERUSERJSYE;
           para[5].Value = MODELreadMeterRecord.WATERUSERLJQF;
           para[6].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 表底变更更新抄表记录审核状态
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateCheckStateChangeNumber(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET checkState=@checkState,checkDateTime=@checkDateTime,checker=@checker ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@checkState",SqlDbType.VarChar,10),
               new SqlParameter("@checkDateTime",SqlDbType.DateTime),
               new SqlParameter("@checker",SqlDbType.VarChar,50),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.checkState;
           if (Convert.ToDateTime(MODELreadMeterRecord.checkDateTime) > Convert.ToDateTime("2015-04-14"))
               para[1].Value = MODELreadMeterRecord.checkDateTime;
           else
               para[1].Value = null;

           if (MODELreadMeterRecord.checker != "")
               para[2].Value = MODELreadMeterRecord.checker;
           else
               para[2].Value = null;
           para[3].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 更新抄表记录收费状态
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateChargeState(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET chargeState=@chargeState,chargeID=@chargeID,OVERDUEMONEY=@OVERDUEMONEY ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@chargeState",SqlDbType.VarChar,10),
               new SqlParameter("@chargeID",SqlDbType.VarChar,30),
               new SqlParameter("@OVERDUEMONEY",SqlDbType.Decimal),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.chargeState;
           para[1].Value = MODELreadMeterRecord.chargeID;
           para[2].Value = MODELreadMeterRecord.OVERDUEMONEY;
           para[3].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 通知单打印记录
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateInformPrintSign(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           //str.Append("UPDATE readMeterRecord SET chargeState=@chargeState,chargeID=@chargeID,OVERDUEMONEY=@OVERDUEMONEY,");
           str.Append("UPDATE readMeterRecord SET ");
           str.Append("WATERUSERQQYEINFORM=@WATERUSERQQYEINFORM,WATERUSERJSYEINFORM=@WATERUSERJSYEINFORM,INFORMNO=@INFORMNO,INFORMPRINTDATETIME=GETDATE()," +
               "INFORMPRINTSIGN=@INFORMPRINTSIGN,PRINTWORKERID=@PRINTWORKERID,PRINTWORKERNAME=@PRINTWORKERNAME ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               //new SqlParameter("@chargeState",SqlDbType.VarChar,10),
               //new SqlParameter("@chargeID",SqlDbType.VarChar,30),
               //new SqlParameter("@OVERDUEMONEY",SqlDbType.Decimal),
               new SqlParameter("@INFORMPRINTSIGN",SqlDbType.VarChar,30),
               new SqlParameter("@WATERUSERQQYEINFORM",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERJSYEINFORM",SqlDbType.Decimal),
               new SqlParameter("@INFORMNO",SqlDbType.VarChar,30),
               new SqlParameter("@PRINTWORKERID",SqlDbType.VarChar,30),
               new SqlParameter("@PRINTWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           //para[0].Value = MODELreadMeterRecord.chargeState;
           //para[1].Value = MODELreadMeterRecord.chargeID;
           //para[2].Value = MODELreadMeterRecord.OVERDUEMONEY;
           para[0].Value = MODELreadMeterRecord.INFORMPRINTSIGN;
           para[1].Value = MODELreadMeterRecord.WATERUSERQQYEINFORM;
           para[2].Value = MODELreadMeterRecord.WATERUSERJSYEINFORM;
           para[3].Value = MODELreadMeterRecord.INFORMNO;
           para[4].Value = MODELreadMeterRecord.PRINTWORKERID;
           para[5].Value = MODELreadMeterRecord.PRINTWORKERNAME;
           para[6].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 预收用户结算更新抄表记录收费状态
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateChargeStatePrestoreJS(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET chargeState=@chargeState,chargeID=@chargeID,OVERDUEMONEY=@OVERDUEMONEY ");
           //str.Append("WATERUSERQQYE=@WATERUSERQQYE,WATERUSERJSYE=@WATERUSERJSYE,INFORMNO=@INFORMNO,INFORMPRINTDATETIME=GETDATE()," +
           //    "INFORMPRINTSIGN=@INFORMPRINTSIGN,PRINTWORKERID=@PRINTWORKERID,PRINTWORKERNAME=@PRINTWORKERNAME ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@chargeState",SqlDbType.VarChar,10),
               new SqlParameter("@chargeID",SqlDbType.VarChar,30),
               new SqlParameter("@OVERDUEMONEY",SqlDbType.Decimal),
               //new SqlParameter("@INFORMPRINTSIGN",SqlDbType.VarChar,30),
               //new SqlParameter("@WATERUSERQQYE",SqlDbType.Decimal),
               //new SqlParameter("@WATERUSERJSYE",SqlDbType.Decimal),
               //new SqlParameter("@INFORMNO",SqlDbType.VarChar,30),
               //new SqlParameter("@PRINTWORKERID",SqlDbType.VarChar,30),
               //new SqlParameter("@PRINTWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.chargeState;
           para[1].Value = MODELreadMeterRecord.chargeID;
           para[2].Value = MODELreadMeterRecord.OVERDUEMONEY;
           //para[3].Value = MODELreadMeterRecord.INFORMPRINTSIGN;
           //para[4].Value = MODELreadMeterRecord.WATERUSERQQYE;
           //para[5].Value = MODELreadMeterRecord.WATERUSERJSYE;
           //para[6].Value = MODELreadMeterRecord.INFORMNO;
           //para[7].Value = MODELreadMeterRecord.PRINTWORKERID;
           //para[8].Value = MODELreadMeterRecord.PRINTWORKERNAME;
           para[3].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       /// <summary>
       /// 预收用户结算补打通知单
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateInformNO(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET INFORMNO=@INFORMNO,INFORMPRINTDATETIME=GETDATE(),"+
               "INFORMPRINTSIGN='1',PRINTWORKERID=@PRINTWORKERID,PRINTWORKERNAME=@PRINTWORKERNAME ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@INFORMNO",SqlDbType.VarChar,30),
               new SqlParameter("@PRINTWORKERID",SqlDbType.VarChar,30),
               new SqlParameter("@PRINTWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELreadMeterRecord.INFORMNO;
           para[1].Value = MODELreadMeterRecord.PRINTWORKERID;
           para[2].Value = MODELreadMeterRecord.PRINTWORKERNAME;
           para[3].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       /// <summary>
       /// 预收用户作废通知单
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateCancelInformNO(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET INFORMNO=NULL,INFORMPRINTDATETIME=NULL,INFORMPRINTSIGN='0',PRINTWORKERID=NULL,PRINTWORKERNAME=NULL ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };
           para[0].Value = strID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 预收用户结算更新抄表记录通知单打印记录
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdatePrestoreJS(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET ");
           str.Append("WATERUSERQQYE=@WATERUSERQQYE,WATERUSERJSYE=@WATERUSERJSYE,INFORMNO=@INFORMNO,INFORMPRINTDATETIME=GETDATE()," +
               "INFORMPRINTSIGN=@INFORMPRINTSIGN,PRINTWORKERID=@PRINTWORKERID,PRINTWORKERNAME=@PRINTWORKERNAME ");
           str.Append("WHERE readMeterRecordId=@readMeterRecordId");
           SqlParameter[] para =
           {
               new SqlParameter("@WATERUSERQQYE",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERJSYE",SqlDbType.Decimal),
               new SqlParameter("@INFORMNO",SqlDbType.VarChar,30),
               new SqlParameter("@INFORMPRINTSIGN",SqlDbType.VarChar,30),
               new SqlParameter("@PRINTWORKERID",SqlDbType.VarChar,30),
               new SqlParameter("@PRINTWORKERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30)
           };

           para[0].Value = MODELreadMeterRecord.WATERUSERQQYE;
           para[1].Value = MODELreadMeterRecord.WATERUSERJSYE;
           para[2].Value = MODELreadMeterRecord.INFORMNO;
           para[3].Value = MODELreadMeterRecord.INFORMPRINTSIGN;
           para[4].Value = MODELreadMeterRecord.PRINTWORKERID;
           para[5].Value = MODELreadMeterRecord.PRINTWORKERNAME;
           para[6].Value = MODELreadMeterRecord.readMeterRecordId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 根据收费单号将收费状态置为未收费
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public bool UpdateChargeStateByChargeID(string strchargeID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE readMeterRecord SET chargeState='1',chargeID=NULL,OVERDUEMONEY=0 ");
           str.Append("WHERE chargeID=@chargeID");
           SqlParameter[] para =
           {
               new SqlParameter("@chargeID",SqlDbType.VarChar,30)
           };

           para[0].Value = strchargeID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Insert(MODELreadMeterRecord MODELreadMeterRecord)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO readMeterRecord(readMeterRecordId,readMeterRecordIdLast,waterMeterId,waterMeterNo,waterMeterLastNumber,waterMeterEndNumber,"+
               "totalNumber,avePrice,waterTotalCharge,extraChargePrice1,extraChargePrice2,extraChargePrice3,extraChargePrice4,extraChargePrice5,"+
               "extraChargePrice6,extraChargePrice7,extraChargePrice8,extraCharge1,extraCharge2,extraCharge3,extraCharge4,extraCharge5,extraCharge6,extraCharge7," +
               "extraCharge8,extraTotalCharge,trapezoidPrice,totalCharge,WATERFIXVALUE,readMeterRecordYear,readMeterRecordMonth," +
               "waterMeterPositionName,waterMeterSizeValue," +
               "waterMeterTypeName,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,waterMeterMagnification,waterMeterMaxRange,"+
               "meterReaderID,meterReaderName,chargerID,chargerName,chargeID,waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress," +
               "waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,waterUserTypeName,waterUserCreateDate,agentsign,bankId,"+
               "bankName,BankAcountNumber,memo,initialReadMeterMesDateTime,avePriceDescribe,meterReadingNO,waterMeterParentId,totalNumberDescribe,"+
               "waterUserHouseType,waterMeterTypeId,waterUserState,waterMeterSizeId,ordernumber,extraCharge,lastNumberYearMonth,isSummaryMeter,waterUserchargeType,"+
               "IsReverse,areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,waterUserTelphoneNO,waterUserNameCode,"+
               "readMeterRecordYearAndMonth,waterMeterTypeClassID,waterMeterTypeClassName,WATERMETERNUMBERCHANGESTATE,WATERUSERQQYE,WATERUSERJSYE,WATERUSERLJQF,NotReadMonthCount) ");
           str.Append("VALUES(@readMeterRecordId,@readMeterRecordIdLast,@waterMeterId,@waterMeterNo,@waterMeterLastNumber,@waterMeterEndNumber," +
               "@totalNumber,@avePrice,@waterTotalCharge,@extraChargePrice1,@extraChargePrice2,@extraChargePrice3,@extraChargePrice4,@extraChargePrice5,"+
               "@extraChargePrice6,@extraChargePrice7,@extraChargePrice8,@extraCharge1,@extraCharge2,@extraCharge3,@extraCharge4,@extraCharge5,@extraCharge6,"+
               "@extraCharge7,@extraCharge8,@extraTotalCharge,@trapezoidPrice,@totalCharge,@WATERFIXVALUE,@readMeterRecordYear,@readMeterRecordMonth," +
               "@waterMeterPositionName,@waterMeterSizeValue," +
               "@waterMeterTypeName,@waterMeterProduct,@waterMeterSerialNumber,@waterMeterMode,@waterMeterMagnification,@waterMeterMaxRange," +
               "@meterReaderID,@meterReaderName,@chargerID,@chargerName,@chargeID,@waterUserId,@waterUserNO,@waterUserName,@waterPhone,@waterUserAddress," +
               "@waterUserPeopleCount,@meterReadingID,@meterReadingPageNo,@waterUserTypeId,@waterUserTypeName,@waterUserCreateDate,@agentsign,@bankId," +
               "@bankName,@BankAcountNumber,@memo,@initialReadMeterMesDateTime,@avePriceDescribe,@meterReadingNO,@waterMeterParentId,@totalNumberDescribe,"+
               "@waterUserHouseType,@waterMeterTypeId,@waterUserState,@waterMeterSizeId,@ordernumber,@extraCharge,@lastNumberYearMonth,@isSummaryMeter,@waterUserchargeType,"+
               "@IsReverse,@areaNO,@pianNO,@duanNO,@communityID,@COMMUNITYNAME,@buildingNO,@unitNO,@createType,@waterUserTelphoneNO,@waterUserNameCode,"+
               "@readMeterRecordYearAndMonth,@waterMeterTypeClassID,@waterMeterTypeClassName,@WATERMETERNUMBERCHANGESTATE,@WATERUSERQQYE,@WATERUSERJSYE,@WATERUSERLJQF,@NotReadMonthCount) ");
           SqlParameter[] para =
           {
               new SqlParameter("@readMeterRecordId",SqlDbType.VarChar,30),
               new SqlParameter("@readMeterRecordIdLast",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterNo",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterLastNumber",SqlDbType.Int),
               new SqlParameter("@waterMeterEndNumber",SqlDbType.Int),
               new SqlParameter("@totalNumber",SqlDbType.Int),
               new SqlParameter("@avePrice",SqlDbType.Decimal),
               new SqlParameter("@waterTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice1",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice2",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice3",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice4",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice5",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice6",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice7",SqlDbType.Decimal),
               new SqlParameter("@extraChargePrice8",SqlDbType.Decimal),
               new SqlParameter("@extraCharge1",SqlDbType.Decimal),
               new SqlParameter("@extraCharge2",SqlDbType.Decimal),
               new SqlParameter("@extraCharge3",SqlDbType.Decimal),
               new SqlParameter("@extraCharge4",SqlDbType.Decimal),
               new SqlParameter("@extraCharge5",SqlDbType.Decimal),
               new SqlParameter("@extraCharge6",SqlDbType.Decimal),
               new SqlParameter("@extraCharge7",SqlDbType.Decimal),
               new SqlParameter("@extraCharge8",SqlDbType.Decimal),
               new SqlParameter("@extraTotalCharge",SqlDbType.Decimal),
               new SqlParameter("@trapezoidPrice",SqlDbType.VarChar,1000),
               new SqlParameter("@totalCharge",SqlDbType.Decimal),
               new SqlParameter("@WATERFIXVALUE",SqlDbType.Int),
               new SqlParameter("@readMeterRecordYear",SqlDbType.Int),
               new SqlParameter("@readMeterRecordMonth",SqlDbType.Int),
               new SqlParameter("@waterMeterPositionName",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterSizeValue",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeName",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterProduct",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterSerialNumber",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterMode",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterMagnification",SqlDbType.Int),
               new SqlParameter("@waterMeterMaxRange",SqlDbType.Int),
               new SqlParameter("@meterReaderID",SqlDbType.VarChar,30),
               new SqlParameter("@meterReaderName",SqlDbType.VarChar,50),
               new SqlParameter("@chargerID",SqlDbType.VarChar,50),
               new SqlParameter("@chargerName",SqlDbType.VarChar,50),
               new SqlParameter("@chargeID",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserId",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserNO",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserName",SqlDbType.VarChar,30),
               new SqlParameter("@waterPhone",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserAddress",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserPeopleCount",SqlDbType.VarChar,30),
               new SqlParameter("@meterReadingID",SqlDbType.VarChar,30),
               new SqlParameter("@meterReadingPageNo",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserTypeId",SqlDbType.VarChar,30),   
               new SqlParameter("@waterUserTypeName",SqlDbType.VarChar,30),   
               new SqlParameter("@waterUserCreateDate",SqlDbType.DateTime),   
               new SqlParameter("@agentsign",SqlDbType.VarChar,30),   
               new SqlParameter("@bankId",SqlDbType.VarChar,30),    
               new SqlParameter("@bankName",SqlDbType.VarChar,30),    
               new SqlParameter("@BankAcountNumber",SqlDbType.VarChar,30),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@initialReadMeterMesDateTime",SqlDbType.DateTime),
               new SqlParameter("@avePriceDescribe",SqlDbType.VarChar,500),//04216816395
               new SqlParameter("@meterReadingNO",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterParentId",SqlDbType.VarChar,50),
               new SqlParameter("@totalNumberDescribe",SqlDbType.VarChar,500),
               new SqlParameter("@waterUserHouseType",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserState",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterSizeId",SqlDbType.VarChar,50),
               new SqlParameter("@ordernumber",SqlDbType.Int),
               new SqlParameter("@extraCharge",SqlDbType.VarChar,1000),
               new SqlParameter("@lastNumberYearMonth",SqlDbType.VarChar,20),
               new SqlParameter("@isSummaryMeter",SqlDbType.VarChar,10),
               new SqlParameter("@waterUserchargeType",SqlDbType.VarChar,10),
               new SqlParameter("@IsReverse",SqlDbType.VarChar,50),
               new SqlParameter("@areaNO",SqlDbType.VarChar,50),
               new SqlParameter("@pianNO",SqlDbType.VarChar,50),
               new SqlParameter("@duanNO",SqlDbType.VarChar,50),
               new SqlParameter("@communityID",SqlDbType.VarChar,50),
               new SqlParameter("@COMMUNITYNAME",SqlDbType.VarChar,50),
               new SqlParameter("@buildingNO",SqlDbType.VarChar,50),
               new SqlParameter("@unitNO",SqlDbType.VarChar,50),
               new SqlParameter("@createType",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserTelphoneNO",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserNameCode",SqlDbType.VarChar,50),
               new SqlParameter("@readMeterRecordYearAndMonth",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterTypeClassID",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterTypeClassName",SqlDbType.VarChar,50),
               new SqlParameter("@WATERMETERNUMBERCHANGESTATE",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERQQYE",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERJSYE",SqlDbType.Decimal),
               new SqlParameter("@WATERUSERLJQF",SqlDbType.Decimal),
               new SqlParameter("@NotReadMonthCount",SqlDbType.Int)
           };

           para[0].Value = MODELreadMeterRecord.readMeterRecordId;
           para[1].Value = MODELreadMeterRecord.readMeterRecordIdLast;
           para[2].Value = MODELreadMeterRecord.waterMeterId;
           para[3].Value = MODELreadMeterRecord.waterMeterNo;
           para[4].Value = MODELreadMeterRecord.waterMeterLastNumber;
           para[5].Value = MODELreadMeterRecord.waterMeterEndNumber;
           para[6].Value = MODELreadMeterRecord.totalNumber;
           para[7].Value = MODELreadMeterRecord.avePrice;
           para[8].Value = MODELreadMeterRecord.waterTotalCharge;
           para[9].Value = MODELreadMeterRecord.extraChargePrice1;
           para[10].Value = MODELreadMeterRecord.extraChargePrice2;
           para[11].Value = MODELreadMeterRecord.extraChargePrice3;
           para[12].Value = MODELreadMeterRecord.extraChargePrice4;
           para[13].Value = MODELreadMeterRecord.extraChargePrice5;
           para[14].Value = MODELreadMeterRecord.extraChargePrice6;
           para[15].Value = MODELreadMeterRecord.extraChargePrice7;
           para[16].Value = MODELreadMeterRecord.extraChargePrice8;
           para[17].Value = MODELreadMeterRecord.extraCharge1;
           para[18].Value = MODELreadMeterRecord.extraCharge2;
           para[19].Value = MODELreadMeterRecord.extraCharge3;
           para[20].Value = MODELreadMeterRecord.extraCharge4;
           para[21].Value = MODELreadMeterRecord.extraCharge5;
           para[22].Value = MODELreadMeterRecord.extraCharge6;
           para[23].Value = MODELreadMeterRecord.extraCharge7;
           para[24].Value = MODELreadMeterRecord.extraCharge8;
           para[25].Value = MODELreadMeterRecord.extraTotalCharge;
           para[26].Value = MODELreadMeterRecord.trapezoidPrice;
           para[27].Value = MODELreadMeterRecord.totalCharge;
           para[28].Value = MODELreadMeterRecord.WATERFIXVALUE;
           para[29].Value = MODELreadMeterRecord.readMeterRecordYear;
           para[30].Value = MODELreadMeterRecord.readMeterRecordMonth;
           para[31].Value = MODELreadMeterRecord.waterMeterPositionName;
           para[32].Value = MODELreadMeterRecord.waterMeterSizeValue;
           para[33].Value = MODELreadMeterRecord.waterMeterTypeName;
           para[34].Value = MODELreadMeterRecord.waterMeterProduct;
           para[35].Value = MODELreadMeterRecord.waterMeterSerialNumber;
           para[36].Value = MODELreadMeterRecord.waterMeterMode;
           para[37].Value = MODELreadMeterRecord.waterMeterMagnification;
           para[38].Value = MODELreadMeterRecord.waterMeterMaxRange;
           para[39].Value = MODELreadMeterRecord.meterReaderID;
           para[40].Value = MODELreadMeterRecord.meterReaderName;
           para[41].Value = MODELreadMeterRecord.chargerID;
           para[42].Value = MODELreadMeterRecord.chargerName;
           para[43].Value = MODELreadMeterRecord.chargeID;
           para[44].Value = MODELreadMeterRecord.waterUserId;
           para[45].Value = MODELreadMeterRecord.waterUserNO;
           para[46].Value = MODELreadMeterRecord.waterUserName;
           para[47].Value = MODELreadMeterRecord.waterPhone;
           para[48].Value = MODELreadMeterRecord.waterUserAddress;
           para[49].Value = MODELreadMeterRecord.waterUserPeopleCount;
           para[50].Value = MODELreadMeterRecord.meterReadingID;
           para[51].Value = MODELreadMeterRecord.meterReadingPageNo;
           para[52].Value = MODELreadMeterRecord.waterUserTypeId;
           para[53].Value = MODELreadMeterRecord.waterUserTypeName;
           if (MODELreadMeterRecord.waterUserCreateDate > Convert.ToDateTime("2015-04-11"))
               para[54].Value = MODELreadMeterRecord.waterUserCreateDate;
           para[55].Value = MODELreadMeterRecord.agentsign;
           para[56].Value = MODELreadMeterRecord.bankId;
           para[57].Value = MODELreadMeterRecord.bankName;
           para[58].Value = MODELreadMeterRecord.BankAcountNumber;
           para[59].Value = MODELreadMeterRecord.MEMO;
           if (MODELreadMeterRecord.initialReadMeterMesDateTime > Convert.ToDateTime("2015-04-11"))
               para[60].Value = MODELreadMeterRecord.initialReadMeterMesDateTime;
           para[61].Value = MODELreadMeterRecord.avePriceDescribe;
           para[62].Value = MODELreadMeterRecord.meterReadingNO;
           para[63].Value = MODELreadMeterRecord.waterMeterParentId;
           para[64].Value = MODELreadMeterRecord.totalNumberDescribe;
           para[65].Value = MODELreadMeterRecord.waterUserHouseType;
           para[66].Value = MODELreadMeterRecord.waterMeterTypeId;
           para[67].Value = MODELreadMeterRecord.waterUserState;
           para[68].Value = MODELreadMeterRecord.waterMeterSizeId;
           para[69].Value = MODELreadMeterRecord.ordernumber;
           para[70].Value = MODELreadMeterRecord.extraCharge;
           para[71].Value = MODELreadMeterRecord.lastNumberYearMonth;
           para[72].Value = MODELreadMeterRecord.isSummaryMeter;
           para[73].Value = MODELreadMeterRecord.waterUserchargeType;
           para[74].Value = MODELreadMeterRecord.IsReverse;
           para[75].Value = MODELreadMeterRecord.areaNO;
           para[76].Value = MODELreadMeterRecord.pianNO;
           para[77].Value = MODELreadMeterRecord.duanNO;
           para[78].Value = MODELreadMeterRecord.communityID;
           para[79].Value = MODELreadMeterRecord.COMMUNITYNAME;
           para[80].Value = MODELreadMeterRecord.buildingNO;
           para[81].Value = MODELreadMeterRecord.unitNO;
           para[82].Value = MODELreadMeterRecord.createType;
           para[83].Value = MODELreadMeterRecord.waterUserTelphoneNO;
           para[84].Value = MODELreadMeterRecord.waterUserNameCode;
           para[85].Value = MODELreadMeterRecord.readMeterRecordYearAndMonth;
           para[86].Value = MODELreadMeterRecord.waterMeterTypeClassID;
           para[87].Value = MODELreadMeterRecord.waterMeterTypeClassName;
           para[88].Value = MODELreadMeterRecord.WATERMETERNUMBERCHANGESTATE;
           para[89].Value = MODELreadMeterRecord.WATERUSERQQYE;
           para[90].Value = MODELreadMeterRecord.WATERUSERJSYE;
           para[91].Value = MODELreadMeterRecord.WATERUSERLJQF;
           para[92].Value = MODELreadMeterRecord.NotReadMonthCount;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       /// <summary>
       /// 执行自定义语句
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public int Excute(string strSQL)
       {
           int intCount = DBUtility.DbHelperSQL.ExecuteSql(strSQL);
           return intCount;
           //if (DBUtility.DbHelperSQL.ExecuteSql(strSQL) > 0)
           //    return true;
           //else
           //    return false;
       }

       /// <summary>
       /// 执行自定义查询语句
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public DataTable QueryBySQL(string strSQL)
       {
           DataTable dt = DBUtility.DbHelperSQL.Query(strSQL).Tables[0];
           return dt;
           //if (DBUtility.DbHelperSQL.ExecuteSql(strSQL) > 0)
           //    return true;
           //else
           //    return false;
       }

       /// <summary>
       /// 报装换表后执行变更水表底数函数
       /// </summary>
       /// <param name="strWaterMeterID">水表编号ID</param>
       /// <param name="strReadMeterRecordID">抄表台账ID</param>
       /// <param name="strCheckWorker">变更人即当前登录人员姓名</param>
       /// <returns>成功返回true；失败返回false</returns>
       public bool ChangeWaterMeter(string strWaterMeterID, string strReadMeterRecordID, string strCheckWorker)
       {
           string strSQL =string.Format(@"
                            DECLARE @WATERMETERID VARCHAR(30)={0}  --传入参数水表ID
                            DECLARE @readMeterRecordId VARCHAR(30)={1}  --传入参数水表抄表ID
                            DECLARE @LoginID VARCHAR(30)={2}  --传入参数 登陆用户ID
                            DECLARE @WATERMETERLASTNUMBER INT =0
                            DECLARE @WATERMETERENDNUMBER INT =0
                            DECLARE @INTREADMETERCOUNT INT =0
                            DECLARE @ISSUCCESS INT =0

                            BEGIN TRAN
                            SELECT @INTREADMETERCOUNT=COUNT(1) FROM readMeterRecord WHERE checkState='1' AND waterMeterId=@WATERMETERID 

                            IF(@INTREADMETERCOUNT=0)
                            BEGIN
                            UPDATE waterMeter SET waterMeterStartNumber=0 WHERE waterMeterId=@WATERMETERID
                            END
                            ELSE
                            BEGIN
                            INSERT INTO readMeterRecord(readMeterRecordId,readMeterRecordIdLast,waterMeterId,waterMeterNo,waterMeterLastNumber,waterMeterEndNumber,
                                           totalNumber,avePrice,waterTotalCharge,extraChargePrice1,extraChargePrice2,extraChargePrice3,extraChargePrice4,extraChargePrice5,
                                           extraChargePrice6,extraChargePrice7,extraChargePrice8,extraCharge1,extraCharge2,extraCharge3,extraCharge4,extraCharge5,extraCharge6,extraCharge7,
                                           extraCharge8,extraTotalCharge,trapezoidPrice,totalCharge,WATERFIXVALUE,readMeterRecordYear,readMeterRecordMonth,
                                           waterMeterPositionName,waterMeterSizeValue,
                                           waterMeterTypeName,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,waterMeterMagnification,waterMeterMaxRange,
                                           meterReaderID,meterReaderName,chargerID,chargerName,chargeID,waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,
                                           waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,waterUserTypeName,waterUserCreateDate,agentsign,bankId,
                                          bankName,BankAcountNumber,memo,initialReadMeterMesDateTime,avePriceDescribe,meterReadingNO,waterMeterParentId,totalNumberDescribe,
                                           waterUserHouseType,waterMeterTypeId,waterUserState,waterMeterSizeId,ordernumber,extraCharge,lastNumberYearMonth,isSummaryMeter,waterUserchargeType,
                                           IsReverse,areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,waterUserTelphoneNO,waterUserNameCode,
                                           readMeterRecordYearAndMonth,waterMeterTypeClassID,waterMeterTypeClassName,WATERMETERNUMBERCHANGESTATE,WATERUSERQQYE,WATERUSERJSYE,WATERUSERLJQF,
                                           NotReadMonthCount,checkState,checkDateTime,checker,memo)
                            SELECT TOP 1 @readMeterRecordId,readMeterRecordId,waterMeterId,waterMeterNo,waterMeterEndNumber,@WATERMETERENDNUMBER,
                                           0,0,0,0,0,0,0,0,
                                           0,0,0,0,0,0,0,0,0,0,
                                           0,0,trapezoidPrice,0,WATERFIXVALUE,YEAR(GETDATE()),MONTH(GETDATE()),
                                           waterMeterPositionName,waterMeterSizeValue,
                                           waterMeterTypeName,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,waterMeterMagnification,waterMeterMaxRange,
                                           meterReaderID,meterReaderName,chargerID,chargerName,chargeID,waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,
                                           waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,waterUserTypeName,waterUserCreateDate,agentsign,bankId,
                                          bankName,BankAcountNumber,memo,GETDATE(),NULL,meterReadingNO,waterMeterParentId,NULL,
                                           waterUserHouseType,waterMeterTypeId,waterUserState,waterMeterSizeId,ordernumber,extraCharge,NULL,isSummaryMeter,waterUserchargeType,
                                           IsReverse,areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,waterUserTelphoneNO,waterUserNameCode,
                                           GETDATE(),waterMeterTypeClassID,waterMeterTypeClassName,'1',0,0,0,0,'1',GETDATE(),@LoginID,'报装换表' 
                                           FROM readMeterRecord WHERE checkState='1' AND waterMeterId=@WATERMETERID ORDER BY checkDateTime DESC
                            END
                            IF(@@ERROR<>0)
                            BEGIN
                            SET @ISSUCCESS=0
                            ROLLBACK TRAN
                            END
                            ELSE
                            BEGIN
                            SET @ISSUCCESS=1
                            COMMIT TRAN
                            END
                            ",strWaterMeterID,strReadMeterRecordID,strCheckWorker);
           int intRet = DBUtility.DbHelperSQL.ExecuteSql(strSQL);
           return intRet == 0 ? false : true;
       }
    }
}
