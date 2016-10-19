using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLwaterUser
    {
       public DataTable QueryUser(string strFilter)
       {
           DataTable dt=new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_WATERUSER_BYCOMMUNITY WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()+strFilter).Tables[0];
           return dt;
       }
        /// <summary>
        /// 查询用户，包含水表数量
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
       public DataTable QueryUserContainWaterMeterCount(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
        /// <summary>
        /// 查询预存用户总欠费及余额
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
       public DataTable QueryUserPrestore(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM (SELECT *,(PRESTORE-TOTALFEE) AS USERAREARAGE FROM V_WATERUSERAREARAGE) AS AA WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       #region 统计相关函数
       /// <summary>
        /// 按用户类型统计用水用户
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
       public DataTable WaterUserStatisticsByWaterUserType(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("select waterUserTypeId AS 类型编号, waterUserTypeName AS 用户类型,COUNT(*) AS 用户数 ");
           str.Append(" FROM (SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1 ");
           str.Append(strFilter+") AS A");
           str.Append(" GROUP BY waterUserTypeId,waterUserTypeName");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按抄表本统计用水用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterUserStatisticsByMeterReadingNO(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("select meterReadingID AS 抄表本编号,meterReadingNO AS 抄表本,COUNT(*) AS 用户数 ");
           str.Append(" FROM (SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1 ");
           str.Append(strFilter + ") AS A");
           str.Append(" GROUP BY meterReadingID,meterReadingNO ORDER BY meterReadingID");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按区域统计用水用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterUserStatisticsByArea(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("select areaId AS 区域编号,areaName AS 区域,COUNT(*) AS 用户数");
           str.Append(" FROM (SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1 ");
           str.Append(strFilter + ") AS A");
           str.Append(" GROUP BY areaId,areaName");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按抄表员统计用水用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterUserStatisticsByMeterReader(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("select loginId AS 抄表员编号,USERNAME AS 抄表员,COUNT(*) AS 用户数 ");
           str.Append(" FROM (SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1 ");
           str.Append(strFilter + ") AS A");
           str.Append(" GROUP BY loginId,USERNAME");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按银行托收统计用水用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterUserStatisticsByIsAgent(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("select agentsignS AS 银行托收,COUNT(*) AS 用户数 ");
           str.Append(" FROM (SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1 ");
           str.Append(strFilter + ") AS A");
           str.Append(" GROUP BY agentsignS");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按托收银行统计用水用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterUserStatisticsByAgentBank(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("select ISNULL(bankId,'无') AS 银行编号,ISNULL(bankName,'无') AS 托收银行,COUNT(*) AS 用户数 ");
           str.Append(" FROM (SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1 ");
           str.Append(strFilter + ") AS A");
           str.Append(" GROUP BY bankId,bankName");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按建户年份统计用水用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterUserStatisticsByCreateYear(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("select CAST(DATEPART(YEAR,waterUserCreateDate) AS VARCHAR) AS 建户年份,COUNT(*) AS 用户数 ");
           str.Append(" FROM (SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1 ");
           str.Append(strFilter + ") AS A");
           str.Append(" GROUP BY DATEPART(YEAR,waterUserCreateDate)");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按建户月份统计用水用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterUserStatisticsByCreateMonth(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("select (CAST(DATEPART(YEAR,waterUserCreateDate) AS VARCHAR)+'-'+RIGHT(REPLICATE('0',2)+CAST(DATEPART(MONTH,waterUserCreateDate) AS VARCHAR),2)) AS 建户月份,COUNT(*) AS 用户数 ");
           str.Append(" FROM (SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1 ");
           str.Append(strFilter + ") AS A");
           str.Append(" GROUP BY (CAST(DATEPART(YEAR,waterUserCreateDate) AS VARCHAR)+'-'+RIGHT(REPLICATE('0',2)+CAST(DATEPART(MONTH,waterUserCreateDate) AS VARCHAR),2))");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       /// <summary>
       /// 按建户日期统计用水用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable WaterUserStatisticsByCreateDate(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("select CONVERT(varchar(100),waterUserCreateDate, 23) AS 建户日期,COUNT(*) AS 用户数 ");
           str.Append(" FROM (SELECT * FROM V_WATERUSER_BYMETERREADING_CONTAINMETERCOUNT WHERE 1=1 ");
           str.Append(strFilter + ") AS A");
           str.Append(" GROUP BY CONVERT(varchar(100),waterUserCreateDate, 23)");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return dt;
       }
       #endregion

        /// <summary>
        /// 自定义查询语句
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
       public DataTable QuerySQL(string strSQL)
       {
           DataTable dt = new DataTable();
           dt = DBUtility.DbHelperSQL.Query(strSQL).Tables[0];
           return dt;
       }

       /// <summary>
       /// 自定义查询语句
       /// </summary>
       /// <param name="strSQL"></param>
       /// <returns></returns>
       public object QuerySQLReturnOBJ(string strSQL)
       {
           object obj = DBUtility.DbHelperSQL.GetSingle(strSQL);
           return obj;
       }

       /// <summary>
       /// 自定义执行语句
       /// </summary>
       /// <param name="strSQL"></param>
       /// <returns></returns>
       public int ExcuteSQL(string strSQL)
       {
           int intRows = 0;
           intRows = DBUtility.DbHelperSQL.ExecuteSql(strSQL);
           return intRows;
       }
       /// <summary>
       /// 查询用户及水表数量，包含无表用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryInitialWaterUserMeterCount(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT DISTINCT waterUserId,waterUserNO,waterUserName,waterUserAddress,areaName,(SELECT COUNT(*) FROM waterMeter ");
           str.Append(" WHERE  [V_WATERUSER_CONNECTWATERMETER].waterUserId=waterMeter.waterUserId) AS WATERMETERCOUNT,ordernumber,");
           str.Append("meterReadingNO,meterReadingPageNo");
           str.Append(" FROM [V_WATERUSER_CONNECTWATERMETER] WHERE 1=1 ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 查询所有可抄表用户及水表信息，包含无表用户
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryInitialWaterUser(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_WATERUSER_CONNECTWATERMETER WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
       /// <summary>
       /// 查询所有可抄表用户ID信息
       /// </summary>
       /// <param name="strFilter"></param>
       /// <returns></returns>
       public DataTable QueryInitialWaterUserID(string strFilter)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT DISTINCT WATERUSERID FROM V_WATERUSER_CONNECTWATERMETER WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
           return dt;
       }
        /// <summary>
        /// 获取用户余额
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
       public object GetPrestore(string strFilter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("SELECT prestore FROM waterUser WHERE 1=1 ");
           object obj = DBUtility.DbHelperSQL.GetSingle(str.ToString() + strFilter);
           return obj;
       }
        /// <summary>
        /// 自定义更新语句
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
       public bool UpdateSQL(string strSQL)
       {
           if (DBUtility.DbHelperSQL.ExecuteSql(strSQL) > 0)
               return true;
           else
               return false;
       }
       public bool UpdateUserByMeterReading(string strMeterReadingID)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterUser SET meterReadingID='' WHERE meterReadingID=@meterReadingID");
           SqlParameter[] para =
           {
               new SqlParameter("@meterReadingID",SqlDbType.VarChar,30)
           };
           para[0].Value = strMeterReadingID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
        /// <summary>
       ///  抄表员互换更改用户表中的抄表员
        /// </summary>
        /// <param name="strOldID">原来的抄表员ID</param>
        /// <param name="strID">新的抄表员ID</param>
       /// <param name="strName">新的抄表员姓名</param>
        /// <returns></returns>
       public bool UpdateMeterReader(string strOldID,string strID,string strName)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterUser SET meterReaderID=@meterReaderNewID,meterReaderName=@meterReaderName WHERE meterReaderID=@meterReaderID");
           SqlParameter[] para =
           {
               new SqlParameter("@meterReaderNewID",SqlDbType.VarChar,30),
               new SqlParameter("@meterReaderName",SqlDbType.VarChar,30),
               new SqlParameter("@meterReaderID",SqlDbType.VarChar,30)
           };
           para[0].Value = strID;
           para[1].Value = strName;
           para[2].Value = strOldID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       ///  收费员互换更改用户表中的收费员
       /// </summary>
       /// <param name="strOldID">原来的收费员ID</param>
       /// <param name="strID">新的收费员ID</param>
       /// <param name="strName">新的收费员姓名</param>
       /// <returns></returns>
       public bool UpdateCharger(string strOldID, string strID, string strName)
       {
           DataTable dt = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterUser SET chargerID=@chargerNewID,chargerName=@chargerName WHERE chargerID=@chargerID");
           SqlParameter[] para =
           {
               new SqlParameter("@chargerNewID",SqlDbType.VarChar,30),
               new SqlParameter("@chargerName",SqlDbType.VarChar,30),
               new SqlParameter("@chargerID",SqlDbType.VarChar,30)
           };
           para[0].Value = strID;
           para[1].Value = strName;
           para[2].Value = strOldID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool DeleteUser(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM waterUser WHERE waterUserId=@waterUserId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterUserId",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }
       public bool UpdateUser(MODELWaterUser MODELWaterUser)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterUser SET waterUserName=@waterUserName,waterUserNameCode=@waterUserNameCode,waterUserCerficateType=@waterUserCerficateType,"+
               "waterUserCerficateNO=@waterUserCerficateNO,waterUserTelphoneNO=@waterUserTelphoneNO,waterPhone=@waterPhone,waterUserAddress=@waterUserAddress,"+
               "waterUserPeopleCount=@waterUserPeopleCount,areaNO=@areaNO,pianNO=@pianNO,duanNO=@duanNO,communityID=@communityID,buildingNO=@buildingNO," +
               "unitNO=@unitNO,meterReaderID=@meterReaderID,meterReaderName=@meterReaderName,chargerID=@chargerID,chargerName=@chargerName," +
               "meterReadingID=@meterReadingID,meterReadingPageNo=@meterReadingPageNo,waterUserTypeId=@waterUserTypeId,waterUserUpdateDate=@waterUserUpdateDate," +
               "operatorName=@operatorName,waterUserHouseType=@waterUserHouseType,agentsign=@agentsign,bankId=@bankId," +
               "BankAcountNumber=@BankAcountNumber,createType=@createType,memo=@memo,ordernumber=@ordernumber,chargeType=@chargeType ");
           str.Append("WHERE waterUserId=@waterUserId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterUserName",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserNameCode",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserCerficateType",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserCerficateNO",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserTelphoneNO",SqlDbType.VarChar,50),
               new SqlParameter("@waterPhone",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserAddress",SqlDbType.VarChar,100),
               new SqlParameter("@waterUserPeopleCount",SqlDbType.Int),
               new SqlParameter("@areaNO",SqlDbType.VarChar,50),
               new SqlParameter("@pianNO",SqlDbType.VarChar,50),
               new SqlParameter("@duanNO",SqlDbType.VarChar,50),
               new SqlParameter("@communityID",SqlDbType.VarChar,50),
               new SqlParameter("@buildingNO",SqlDbType.VarChar,50),
               new SqlParameter("@unitNO",SqlDbType.VarChar,50),
               new SqlParameter("@meterReaderID",SqlDbType.VarChar,50),
               new SqlParameter("@meterReaderName",SqlDbType.VarChar,50),
               new SqlParameter("@chargerID",SqlDbType.VarChar,50),
               new SqlParameter("@chargerName",SqlDbType.VarChar,50),
               new SqlParameter("@meterReadingID",SqlDbType.VarChar,30),
               new SqlParameter("@meterReadingPageNo",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserUpdateDate",SqlDbType.DateTime),
               new SqlParameter("@operatorName",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserHouseType",SqlDbType.VarChar,10),
               new SqlParameter("@agentsign",SqlDbType.VarChar,10),
               new SqlParameter("@bankId",SqlDbType.VarChar,30),
               new SqlParameter("@BankAcountNumber",SqlDbType.VarChar,50),
               new SqlParameter("@createType",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@ordernumber",SqlDbType.Int),
               new SqlParameter("@chargeType",SqlDbType.VarChar,10),
               new SqlParameter("@waterUserId",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELWaterUser.waterUserName;
           para[1].Value = MODELWaterUser.waterUserNameCode;
           para[2].Value = MODELWaterUser.waterUserCerficateType;
           para[3].Value = MODELWaterUser.waterUserCerficateNO;
           para[4].Value = MODELWaterUser.waterUserTelphoneNO;
           para[5].Value = MODELWaterUser.waterPhone;
           para[6].Value = MODELWaterUser.waterUserAddress;
           para[7].Value = MODELWaterUser.waterUserPeopleCount;
           para[8].Value = MODELWaterUser.areaNO;
           para[9].Value = MODELWaterUser.pianNO;
           para[10].Value = MODELWaterUser.duanNO;
           para[11].Value = MODELWaterUser.communityID;
           para[12].Value = MODELWaterUser.buildingNO;
           para[13].Value = MODELWaterUser.unitNO;
           para[14].Value = MODELWaterUser.meterReaderID;
           para[15].Value = MODELWaterUser.meterReaderName;
           para[16].Value = MODELWaterUser.chargerID;
           para[17].Value = MODELWaterUser.chargerName;
           para[18].Value = MODELWaterUser.meterReadingID;
           para[19].Value = MODELWaterUser.meterReadingPageNo;
           para[20].Value = MODELWaterUser.waterUserTypeId;
           para[21].Value = MODELWaterUser.waterUserUpdateDate;
           para[22].Value = MODELWaterUser.operatorName;
           para[23].Value = MODELWaterUser.waterUserHouseType;
           para[24].Value = MODELWaterUser.agentsign;
           para[25].Value = MODELWaterUser.bankId;
           para[26].Value = MODELWaterUser.BankAcountNumber;
           para[27].Value = MODELWaterUser.createType;
           para[28].Value = MODELWaterUser.MEMO;
           para[29].Value = MODELWaterUser.ordernumber;
           para[30].Value = MODELWaterUser.chargeType;
           para[31].Value = MODELWaterUser.waterUserId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
               return true;
           else
               return false;
       }

        /// <summary>
        /// 根据用户号更新开票相关基础信息
        /// </summary>
        /// <param name="MODELWaterUser"></param>
        /// <returns></returns>
       public bool UpdateUserByWaterUserNO(MODELWaterUser MODELWaterUser)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterUser SET waterUserName=@waterUserName,waterPhone=@waterPhone," +
               "waterUserAddress=@waterUserAddress,FPTaxNO=@FPTaxNO,FPBankNameAndAccountNO=@FPBankNameAndAccountNO ");
           str.Append("WHERE waterUserNO=@waterUserNO");
           SqlParameter[] para =
           {
               new SqlParameter("@waterUserName",SqlDbType.VarChar,70),
               new SqlParameter("@waterPhone",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserAddress",SqlDbType.VarChar,100),
               new SqlParameter("@FPTaxNO",SqlDbType.VarChar,50),
               new SqlParameter("@FPBankNameAndAccountNO",SqlDbType.VarChar,100),
               new SqlParameter("@waterUserNO",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELWaterUser.waterUserName;
           para[1].Value = MODELWaterUser.waterPhone;
           para[2].Value = MODELWaterUser.waterUserAddress;
           para[3].Value = MODELWaterUser.FPTaxNO;
           para[4].Value = MODELWaterUser.FPBankNameAndAccountNO;
           para[5].Value = MODELWaterUser.waterUserNO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

        /// <summary>
        /// 变更抄表机用户名时变更用户基础信息
        /// </summary>
        /// <param name="MODELWaterUser"></param>
        /// <returns></returns>
       public bool UpdateHandSetUser(MODELWaterUser MODELWaterUser)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterUser SET waterUserName=@waterUserName ");
           str.Append("WHERE waterUserNO=@waterUserNO");
           SqlParameter[] para =
           {
               new SqlParameter("@waterUserName",SqlDbType.VarChar,70),
               new SqlParameter("@waterUserNO",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELWaterUser.waterUserName;
           para[1].Value = MODELWaterUser.waterUserNO;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

        /// <summary>
        /// 修改新的用户名
        /// </summary>
        /// <param name="MODELWaterUser"></param>
        /// <returns></returns>
       public bool UpdateUserName(MODELWaterUser MODELWaterUser)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE waterUser SET waterUserName=@waterUserName ");
           str.Append("WHERE waterUserId=@waterUserId");
           SqlParameter[] para =
           {
               new SqlParameter("@waterUserName",SqlDbType.VarChar,70),
               new SqlParameter("@waterUserId",SqlDbType.VarChar,30)
           };
           para[0].Value = MODELWaterUser.waterUserName;
           para[1].Value = MODELWaterUser.waterUserId;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool InsertwaterUser(MODELWaterUser MODELWaterUser)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO waterUser(waterUserId,waterUserNO,waterUserName,waterUserNameCode,waterUserCerficateType,waterUserCerficateNO,"+
               "waterUserTelphoneNO,waterPhone,waterUserAddress,waterUserPeopleCount,areaNO,pianNO,duanNO,communityID,buildingNO,unitNO,meterReaderID,"+
               "meterReaderName,chargerID,chargerName," +
               "meterReadingID,meterReadingPageNo,waterUserTypeId,waterUserCreateDate,operatorName,waterUserHouseType,agentsign,bankId," +
               "BankAcountNumber,createType,memo,ordernumber,chargeType) ");
           str.Append("VALUES(@waterUserId,@waterUserNO,@waterUserName,@waterUserNameCode,@waterUserCerficateType,@waterUserCerficateNO,@waterUserTelphoneNO,"+
               "@waterPhone,@waterUserAddress,@waterUserPeopleCount,@areaNO,@pianNO,@duanNO,@communityID,@buildingNO,@unitNO,@meterReaderID,"+
               "@meterReaderName,@chargerID,@chargerName," +
               "@meterReadingID,@meterReadingPageNo,@waterUserTypeId,@waterUserCreateDate,@operatorName,@waterUserHouseType,@agentsign,@bankId," +
               "@BankAcountNumber,@createType,@memo,@ordernumber,@chargeType)");
           SqlParameter[] para =
           {
               new SqlParameter("@waterUserId",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserNO",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserName",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserNameCode",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserCerficateType",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserCerficateNO",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserTelphoneNO",SqlDbType.VarChar,50),
               new SqlParameter("@waterPhone",SqlDbType.VarChar,50),
               new SqlParameter("@waterUserAddress",SqlDbType.VarChar,100),
               new SqlParameter("@waterUserPeopleCount",SqlDbType.Int),
               new SqlParameter("@areaNO",SqlDbType.VarChar,50),
               new SqlParameter("@pianNO",SqlDbType.VarChar,50),
               new SqlParameter("@duanNO",SqlDbType.VarChar,50),
               new SqlParameter("@communityID",SqlDbType.VarChar,50),
               new SqlParameter("@buildingNO",SqlDbType.VarChar,50),
               new SqlParameter("@unitNO",SqlDbType.VarChar,50),
               new SqlParameter("@meterReaderID",SqlDbType.VarChar,50),
               new SqlParameter("@meterReaderName",SqlDbType.VarChar,50),
               new SqlParameter("@chargerID",SqlDbType.VarChar,50),
               new SqlParameter("@chargerName",SqlDbType.VarChar,50),
               new SqlParameter("@meterReadingID",SqlDbType.VarChar,30),
               new SqlParameter("@meterReadingPageNo",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserCreateDate",SqlDbType.DateTime),
               new SqlParameter("@operatorName",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserHouseType",SqlDbType.VarChar,10),
               new SqlParameter("@agentsign",SqlDbType.VarChar,10),
               new SqlParameter("@bankId",SqlDbType.VarChar,30),
               new SqlParameter("@BankAcountNumber",SqlDbType.VarChar,50),
               new SqlParameter("@createType",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@ordernumber",SqlDbType.Int),
               new SqlParameter("@chargeType",SqlDbType.VarChar,10)
           };
           para[0].Value = MODELWaterUser.waterUserId;
           para[1].Value = MODELWaterUser.waterUserNO;
           para[2].Value = MODELWaterUser.waterUserName;
           para[3].Value = MODELWaterUser.waterUserNameCode;
           para[4].Value = MODELWaterUser.waterUserCerficateType;
           para[5].Value = MODELWaterUser.waterUserCerficateNO;
           para[6].Value = MODELWaterUser.waterUserTelphoneNO;
           para[7].Value = MODELWaterUser.waterPhone;
           para[8].Value = MODELWaterUser.waterUserAddress;
           para[9].Value = MODELWaterUser.waterUserPeopleCount;
           para[10].Value = MODELWaterUser.areaNO;
           para[11].Value = MODELWaterUser.pianNO;
           para[12].Value = MODELWaterUser.duanNO;
           para[13].Value = MODELWaterUser.communityID;
           para[14].Value = MODELWaterUser.buildingNO;
           para[15].Value = MODELWaterUser.unitNO;
           para[16].Value = MODELWaterUser.meterReaderID;
           para[17].Value = MODELWaterUser.meterReaderName;
           para[18].Value = MODELWaterUser.chargerID;
           para[19].Value = MODELWaterUser.chargerName;
           para[20].Value = MODELWaterUser.meterReadingID;
           para[21].Value = MODELWaterUser.meterReadingPageNo;
           para[22].Value = MODELWaterUser.waterUserTypeId;
           para[23].Value = MODELWaterUser.waterUserCreateDate;
           para[24].Value = MODELWaterUser.operatorName;
           para[25].Value = MODELWaterUser.waterUserHouseType;
           para[26].Value = MODELWaterUser.agentsign;
           para[27].Value = MODELWaterUser.bankId;
           para[28].Value = MODELWaterUser.BankAcountNumber;
           para[29].Value = MODELWaterUser.createType;
           para[30].Value = MODELWaterUser.MEMO;
           para[31].Value = MODELWaterUser.ordernumber;
           para[32].Value = MODELWaterUser.chargeType;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
