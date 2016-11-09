using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLWATERFEECHARGE
    {
        public DataTable Query(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM WATERFEECHARGE LEFT JOIN CHARGETYPE ON WATERFEECHARGE.CHARGETYPEID=CHARGETYPE.CHARGETYPEID  WHERE 1=1");
            dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }
        //收费员
        //收费方式
        //用户类型
        //抄表本
        //区域
        //抄表员UpdateChargeDateTime
        //银行托收
        //托收银行
        //用水性质
        /// <summary>
        /// 根据分组类型统计收费情况
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable WaterChargeStatisticsNew(string strFilter, string strGroupType)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            if (strGroupType == "收费员")
            {
                str.Append(
                    "SELECT CHARGEWORKERID AS 收费员编号,CHARGEWORKERNAME AS 收费员," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量,SUM(totalNumber) AS 用水量, SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY CHARGEWORKERID,CHARGEWORKERNAME,waterMeterTypeId,waterMeterTypeName ORDER BY CHARGEWORKERID,CHARGEWORKERNAME,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "收费方式")
            {
                //str.Append(
                //    "SELECT CHARGETYPEID AS 收费方式编号,CHARGETYPENAME AS 收费方式," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY CHARGETYPEID,CHARGETYPENAME"
                //    );
                str.Append(
                    "SELECT CHARGETYPEID AS 收费方式编号,CHARGETYPENAME AS 收费方式," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量,SUM(totalNumber) AS 用水量, SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY  CHARGETYPEID,CHARGETYPENAME,waterMeterTypeId,waterMeterTypeName  ORDER BY CHARGETYPEID,CHARGETYPENAME,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "用户类型")
            {
                //str.Append(
                //    "SELECT waterUserTypeId AS 用户类型编号,waterUserTypeName AS 用户类型," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY waterUserTypeId,waterUserTypeName"
                //    );
                str.Append(
                    "SELECT waterUserTypeId AS 用户类型编号,waterUserTypeName AS 用户类型," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量,SUM(totalNumber) AS 用水量, SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY waterUserTypeId,waterUserTypeName,waterMeterTypeId,waterMeterTypeName ORDER BY waterUserTypeId,waterUserTypeName,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "抄表本")
            {
                //str.Append(
                //    "SELECT meterReadingID AS 抄表本编号,meterReadingNO AS 抄表本," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY meterReadingID,meterReadingNO"
                //    );
                str.Append(
                    "SELECT meterReadingID AS 抄表本编号,meterReadingNO AS 抄表本," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY meterReadingID,meterReadingNO,waterMeterTypeId,waterMeterTypeName ORDER BY meterReadingID,meterReadingNO,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "区域")
            {
                //str.Append(
                //    "SELECT areaId AS 区域编号,areaName AS 区域名称," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY areaId,areaName"
                //    );
                str.Append(
                    "SELECT areaId AS 区域编号,areaName AS 区域名称," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY areaId,areaName,waterMeterTypeId,waterMeterTypeName ORDER BY areaId,areaName,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "抄表员")
            {
                //str.Append(
                //    "SELECT loginId AS 抄表员编号,USERNAME AS 抄表员," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY loginId,USERNAME"
                //    );
                str.Append(
                    "SELECT loginId AS 抄表员编号,USERNAME AS 抄表员," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY loginId,USERNAME,waterMeterTypeId,waterMeterTypeName ORDER BY loginId,USERNAME,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "银行托收")
            {
                //str.Append(
                //    "SELECT agentsignS AS 银行托收," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY agentsignS"
                //    );
                str.Append(
                    "SELECT agentsignS AS 银行托收," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY agentsignS,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "托收银行")
            {
                //str.Append(
                //    "SELECT ISNULL(bankId,'无') AS 银行编号,ISNULL(bankName,'无') AS 托收银行," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY bankId,bankName"
                //    );
                str.Append(
                    "SELECT ISNULL(bankId,'无') AS 银行编号,ISNULL(bankName,'无') AS 托收银行," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量,SUM(totalNumber) AS 用水量, SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY bankId,bankName,waterMeterTypeId,waterMeterTypeName ORDER BY bankId,bankName,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "用水性质")
            {
                //str.Append(
                //    "SELECT waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY waterMeterTypeId,waterMeterTypeName"
                //    );
                str.Append(
                    "SELECT waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY waterMeterTypeId,waterMeterTypeName ORDER BY waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "用户名")
            {
                //str.Append(
                //    "SELECT waterUserName AS 用户名," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                //    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                //    "SUM(TOTALCHARGECHARGE) AS 总金额 " +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY waterUserName"
                //    );
                str.Append(
                    "SELECT waterUserName AS 用户名," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 应收金额,SUM(CHARGEBCSS) AS 实收金额,SUM(CHARGEYSBCSZ) AS 余额增减" +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY waterUserName,waterMeterTypeId,waterMeterTypeName ORDER BY waterUserName,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
            return dt;
        }
        //收费员
        //收费方式
        //用户类型
        //抄表本
        //区域
        //抄表员
        //银行托收
        //托收银行
        //用水性质
        /// <summary>
        /// 根据分组类型统计收费情况
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable WaterChargeStatistics(string strFilter, string strGroupType)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            if (strGroupType == "收费员")
            {
                str.Append(
                    "SELECT CHARGEWORKERID AS 收费员编号,CHARGEWORKERNAME AS 收费员," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量,SUM(totalNumber) AS 用水量, SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY CHARGEWORKERID,CHARGEWORKERNAME,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "收费方式")
            {
                //str.Append(
                //    "SELECT CHARGETYPEID AS 收费方式编号,CHARGETYPENAME AS 收费方式," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY CHARGETYPEID,CHARGETYPENAME"
                //    );
                str.Append(
                    "SELECT CHARGETYPEID AS 收费方式编号,CHARGETYPENAME AS 收费方式," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量,SUM(totalNumber) AS 用水量, SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY  CHARGETYPEID,CHARGETYPENAME,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "用户类型")
            {
                //str.Append(
                //    "SELECT waterUserTypeId AS 用户类型编号,waterUserTypeName AS 用户类型," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY waterUserTypeId,waterUserTypeName"
                //    );
                str.Append(
                    "SELECT waterUserTypeId AS 用户类型编号,waterUserTypeName AS 用户类型," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量,SUM(totalNumber) AS 用水量, SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY waterUserTypeId,waterUserTypeName,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "抄表本")
            {
                //str.Append(
                //    "SELECT meterReadingID AS 抄表本编号,meterReadingNO AS 抄表本," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY meterReadingID,meterReadingNO"
                //    );
                str.Append(
                    "SELECT meterReadingID AS 抄表本编号,meterReadingNO AS 抄表本," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY meterReadingID,meterReadingNO,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "区域")
            {
                //str.Append(
                //    "SELECT areaId AS 区域编号,areaName AS 区域名称," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY areaId,areaName"
                //    );
                str.Append(
                    "SELECT areaId AS 区域编号,areaName AS 区域名称," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY areaId,areaName,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "抄表员")
            {
                //str.Append(
                //    "SELECT loginId AS 抄表员编号,USERNAME AS 抄表员," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY loginId,USERNAME"
                //    );
                str.Append(
                    "SELECT loginId AS 抄表员编号,USERNAME AS 抄表员," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY loginId,USERNAME,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "银行托收")
            {
                //str.Append(
                //    "SELECT agentsignS AS 银行托收," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY agentsignS"
                //    );
                str.Append(
                    "SELECT agentsignS AS 银行托收," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY agentsignS,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "托收银行")
            {
                //str.Append(
                //    "SELECT ISNULL(bankId,'无') AS 银行编号,ISNULL(bankName,'无') AS 托收银行," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY bankId,bankName"
                //    );
                str.Append(
                    "SELECT ISNULL(bankId,'无') AS 银行编号,ISNULL(bankName,'无') AS 托收银行," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量,SUM(totalNumber) AS 用水量, SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY bankId,bankName,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "用水性质")
            {
                //str.Append(
                //    "SELECT waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(waterTotalCharge) AS 水费," +
                //    "SUM(EXTRATOTALCHARGECHARGE) AS 附加费小计,SUM(TOTALCHARGECHARGE) AS 水费小计," +
                //    "SUM(OVERDUEMONEYCHARGE) AS 滞纳金,SUM(CHARGEBCYS) AS 应收金额," +
                //    "SUM(CHARGEYSBCSZ) AS 余额收支,SUM(CHARGEBCSS) AS 实收金额" +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY waterMeterTypeId,waterMeterTypeName"
                //    );
                str.Append(
                    "SELECT waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY waterMeterTypeId,waterMeterTypeName"
                    );
            }
            else if (strGroupType == "用户名")
            {
                //str.Append(
                //    "SELECT waterUserName AS 用户名," +
                //    "COUNT(DISTINCT CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                //    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                //    "SUM(TOTALCHARGECHARGE) AS 总金额 " +
                //    " FROM ( SELECT * FROM V_CHARGE WHERE 1=1 " + strFilter + ") AS A GROUP BY waterUserName"
                //    );
                str.Append(
                    "SELECT waterUserName AS 用户名," +
                    "waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质," +
                    "COUNT(CHARGEID) AS 单据数量, SUM(totalNumber) AS 用水量,SUM(waterTotalCharge) AS 水费," +
                    "SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费," +
                    "SUM(TOTALCHARGE) AS 总金额 " +
                    " FROM ( SELECT * FROM V_WATERFEECHARGE_READMETERRECORD WHERE 1=1 " + strFilter + ") AS A GROUP BY waterUserName,waterMeterTypeId,waterMeterTypeName"
                    );
            }
            dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
            return dt;
        }
        /// <summary>
        /// 查询收费表，含有发票号
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable QueryChargeView(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE 1=1");
            dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strLogID"></param>
        /// <param name="strInvoiceBatchID"></param>
        /// <returns></returns>
        public DataTable GetMaxInvoiceNO(string strLogID, string strInvoiceBatchID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT TOP 1 INVOICEBATCHID,INVOICENO FROM CHARGEINVOICEPRINT WHERE INVOICEPRINTWORKERID='" + strLogID + "' AND INVOICECANCEL<>'3' AND " +
                " INVOICEBATCHID='" + strInvoiceBatchID + "' ORDER BY INVOICEPRINTDATETIME DESC");
            //str.Append("SELECT TOP 1 INVOICEBATCHID,INVOICENO FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE INVOICENO IS NOT NULL  AND INVOICECANCEL<>'3' ORDER BY INVOICEPRINTDATETIME DESC,INVOICENO DESC");
            //str.Append("SELECT TOP 1 INVOICEBATCHID,INVOICENO FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE CHARGEWORKERID='" + strLogID + "' AND INVOICENO IS NOT NULL  AND INVOICECANCEL<>'3' ORDER BY INVOICEPRINTDATETIME DESC,INVOICENO DESC");
            //str.Append("SELECT MAX(CAST(INVOICENO AS INT)) FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE CHARGEWORKERID='" + strLogID + "' AND INVOICENO IS NOT NULL");
            DataTable dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];

            return dt;
        }
        /// <summary>
        /// 检测发票号是否已经存在
        /// </summary>
        /// <param name="strInvoiceNO">要检测的发票号</param>
        /// <param name="strInvoiceBatchID">发票批次ID</param>
        /// <returns></returns>
        public bool IsExistInvoiceNO(string strInvoiceNO, string strInvoiceBatchID)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("SELECT TOP 1 INVOICENO FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE CHARGEWORKERID='" + strLogID + "' AND INVOICENO IS NOT NULL  ORDER BY CHARGEDATETIME DESC,INVOICENO DESC");
            str.Append("SELECT INVOICENO FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE INVOICENO='" + strInvoiceNO + "' AND INVOICEBATCHID='" + strInvoiceBatchID + "'");
            object obj = DBUtility.DbHelperSQL.GetSingle(str.ToString());
            if (obj != null && obj != DBNull.Value)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 根据收费员及收费时间获取最新收据号
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable GetMaxReceiptNO(string strLogID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT TOP 1 RECEIPTNO FROM WATERFEECHARGE WHERE RECEIPTNO IS NOT NULL AND CHARGEWORKERID='" + strLogID + "' ORDER BY CHARGEDATETIME DESC,RECEIPTNO DESC");
            //str.Append("SELECT TOP 1 INVOICEBATCHID,INVOICENO FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE CHARGEWORKERID='" + strLogID + "' AND INVOICENO IS NOT NULL  AND INVOICECANCEL<>'3' ORDER BY INVOICEPRINTDATETIME DESC,INVOICENO DESC");
            //str.Append("SELECT MAX(CAST(INVOICENO AS INT)) FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE CHARGEWORKERID='" + strLogID + "' AND INVOICENO IS NOT NULL");
            DataTable dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];

            return dt;
        }
        /// <summary>
        /// 检测收据号是否已经存在
        /// </summary>
        /// <param name="strInvoiceNO">要检测的发票号</param>
        /// <param name="strInvoiceBatchID">发票批次ID</param>
        /// <returns></returns>
        public bool IsExistReceiptNO(string strReceiptNO)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("SELECT TOP 1 INVOICENO FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE CHARGEWORKERID='" + strLogID + "' AND INVOICENO IS NOT NULL  ORDER BY CHARGEDATETIME DESC,INVOICENO DESC");
            str.Append("SELECT RECEIPTNO FROM WATERFEECHARGE WHERE RECEIPTNO='" + strReceiptNO + "'");
            object obj = DBUtility.DbHelperSQL.GetSingle(str.ToString());
            if (obj != null && obj != DBNull.Value)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 历史收费明细含抄表记录
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable QueryLS(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_CHARGE WHERE 1=1");
            dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }

        /// <summary>
        /// 自定义语句查询
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
        /// 统计实收水费总金额、实收预收总金额、冲减收支总计、所有收费总金额
        /// </summary>
        /// <returns></returns>
        public DataTable SumWaterFeeCharge(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT SUM(CASE WHEN CHARGEClASS='1' OR CHARGEClASS='4' THEN CHARGEBCYS ELSE 0 END) AS BCYS,");
            str.Append("SUM(CASE WHEN CHARGEClASS='1' OR CHARGEClASS='4' THEN CHARGEBCSS ELSE 0 END) AS YSBCSS,");
            str.Append("SUM(CASE WHEN (CHARGEClASS='1' OR CHARGEClASS='4') AND CHARGETYPEID='1' THEN CHARGEBCSS ELSE 0 END) AS YSBCSSXJ,");
            str.Append("SUM(CASE WHEN (CHARGEClASS='1' OR CHARGEClASS='4') AND CHARGETYPEID='2' THEN CHARGEBCSS ELSE 0 END) AS YSBCSSPOS,");
            str.Append("SUM(CASE WHEN (CHARGEClASS='1' OR CHARGEClASS='4') AND CHARGETYPEID='3' THEN CHARGEBCSS ELSE 0 END) AS YSBCSSZHUANZHANG,");
            str.Append("SUM(CASE WHEN  CHARGEClASS='1' OR CHARGEClASS='4' THEN CHARGEYSBCSZ ELSE 0 END) AS YSBCSZ,");
            str.Append("SUM(CASE WHEN  INVOICEPRINTSIGN='1' THEN 1 ELSE 0 END) AS YSCOUNT,");
            str.Append("COUNT(DISTINCT RECEIPTNO) AS YSRECEIPTNOCOUNT,");
            //str.Append("SUM(CASE WHEN  CHARGEClASS='1' OR CHARGEClASS='4' THEN 1 ELSE 0 END) AS YSCOUNT,");
            str.Append("SUM(CASE WHEN CHARGEClASS='2' OR CHARGEClASS='5' THEN CHARGEYSQQYE ELSE 0 END) AS YCQQYE,");
            str.Append("SUM(CASE WHEN CHARGEClASS='2' OR CHARGEClASS='5' THEN CHARGEYSBCSZ ELSE 0 END) AS YCBCSZ,");
            str.Append("SUM(CASE WHEN (CHARGEClASS='2' OR CHARGEClASS='5') AND CHARGETYPEID='1' THEN CHARGEYSBCSZ ELSE 0 END) AS YCBCSZXJ,");
            str.Append("SUM(CASE WHEN (CHARGEClASS='2' OR CHARGEClASS='5') AND CHARGETYPEID='2' THEN CHARGEYSBCSZ ELSE 0 END) AS YCBCSZPOS,");
            str.Append("SUM(CASE WHEN (CHARGEClASS='2' OR CHARGEClASS='5') AND CHARGETYPEID='3' THEN CHARGEYSBCSZ ELSE 0 END) AS YCBCSSZHUANZHANG,");
            str.Append("SUM(CASE WHEN CHARGEClASS='2' OR CHARGEClASS='5' THEN CHARGEYSJSYE ELSE 0 END) AS YCJSYE,");
            str.Append("SUM(CASE WHEN CHARGEClASS='2' OR CHARGEClASS='5' THEN 1 ELSE 0 END) AS YCCOUNT,");
            str.Append("SUM(CHARGEBCSS) AS BCSS");
            str.Append(" FROM ");
            str.Append("(SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE 1=1 ");
            str.Append(strFilter);
            str.Append(") AS AA");
            dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
            return dt;
        }

        /// <summary>
        /// 查询收费及预存明细
        /// </summary>
        /// <returns></returns>
        public DataTable QueryWaterFeeAndPrestoreCharge(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_WATERFEEANDPRESTORECHARGE WHERE 1=1 ");
            str.Append(strFilter);
            dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
            return dt;
        }
        /// <summary>
        /// 查询收费冲减明细
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable QueryChargeCancel(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_CHARGE_CANCEL WHERE 1=1");
            dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }
        /// <summary>
        /// 冲减单据，将单据状态置为已冲减
        /// </summary>
        /// <param name="strUserID"></param>
        /// <returns></returns>
        public bool UpdateCancelState(MODELWATERFEECHARGE MODELWATERFEECHARGE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE WATERFEECHARGE SET CHARGECANCEL=@CHARGECANCEL,CANCELYSQQYE=@CANCELYSQQYE,CANCELYSBCSZ=@CANCELYSBCSZ," +
                "CANCELYSJSYE=@CANCELYSJSYE,CANCELWORKERID=@CANCELWORKERID,CANCELWORKERNAME=@CANCELWORKERNAME,CANCELDATETIME=@CANCELDATETIME,CANCELMEMO=@CANCELMEMO" +
                " WHERE CHARGEID=@CHARGEID");
            SqlParameter[] para =
           {
               new SqlParameter("@CHARGECANCEL",SqlDbType.VarChar,10),
               new SqlParameter("@CANCELYSQQYE",SqlDbType.Decimal),
               new SqlParameter("@CANCELYSBCSZ",SqlDbType.Decimal),
               new SqlParameter("@CANCELYSJSYE",SqlDbType.Decimal),
               new SqlParameter("@CANCELWORKERID",SqlDbType.VarChar,30),
               new SqlParameter("@CANCELWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@CANCELDATETIME",SqlDbType.DateTime),
               new SqlParameter("@CANCELMEMO",SqlDbType.VarChar,200),
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30)
           };
            para[0].Value = MODELWATERFEECHARGE.CHARGECANCEL;
            para[1].Value = MODELWATERFEECHARGE.CANCELYSQQYE;
            para[2].Value = MODELWATERFEECHARGE.CANCELYSBCSZ;
            para[3].Value = MODELWATERFEECHARGE.CANCELYSJSYE;
            para[4].Value = MODELWATERFEECHARGE.CANCELWORKERID;
            para[5].Value = MODELWATERFEECHARGE.CANCELWORKERNAME;

            if (MODELWATERFEECHARGE.CHARGECANCEL == "1")
                para[6].Value = MODELWATERFEECHARGE.CANCELDATETIME;
            else
                para[6].Value = null;

            para[7].Value = MODELWATERFEECHARGE.CANCELMEMO;
            para[8].Value = MODELWATERFEECHARGE.CHARGEID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 更新发票打印标志
        /// </summary>
        /// <param name="MODELWATERFEECHARGE"></param>
        /// <returns></returns>
        public bool UpdateInvoicePrintSign(MODELWATERFEECHARGE MODELWATERFEECHARGE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE WATERFEECHARGE SET INVOICEPRINTSIGN=@INVOICEPRINTSIGN WHERE CHARGEID=@CHARGEID");
            SqlParameter[] para =
           {
               new SqlParameter("@INVOICEPRINTSIGN",SqlDbType.VarChar,10),
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30)
           };
            para[0].Value = MODELWATERFEECHARGE.INVOICEPRINTSIGN;
            para[1].Value = MODELWATERFEECHARGE.CHARGEID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 更新收据打印次数
        /// </summary>
        /// <param name="MODELWATERFEECHARGE"></param>
        /// <returns></returns>
        public bool UpdateReceiptPrintCount(MODELWATERFEECHARGE MODELWATERFEECHARGE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE WATERFEECHARGE SET RECEIPTPRINTCOUNT=ISNULL(RECEIPTPRINTCOUNT,0)+1,RECEIPTNO=@RECEIPTNO WHERE CHARGEID=@CHARGEID");
            SqlParameter[] para =
           {
               new SqlParameter("@RECEIPTNO",SqlDbType.VarChar,30),
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30)
           };
            para[0].Value = MODELWATERFEECHARGE.RECEIPTNO;
            para[1].Value = MODELWATERFEECHARGE.CHARGEID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 日结账，根据查询条件执行结账语句
        /// </summary>
        /// <param name="strUserID"></param>
        /// <returns></returns>
        public int UpdateDayCheckState(MODELWATERFEECHARGE MODELWATERFEECHARGE, string strFilter)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE WATERFEECHARGE SET DAYCHECKWORKERNAME=@DAYCHECKWORKERNAME,DAYCHECKSTATE=@DAYCHECKSTATE,DAYCHECKDATETIME=@DAYCHECKDATETIME, " +
                "DAYCHECKID=@DAYCHECKID  WHERE 1=1" + strFilter);
            SqlParameter[] para =
           {
               new SqlParameter("@DAYCHECKWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@DAYCHECKSTATE",SqlDbType.VarChar,10),
               new SqlParameter("@DAYCHECKDATETIME",SqlDbType.DateTime),
               new SqlParameter("@DAYCHECKID",SqlDbType.VarChar,30)
           };
            para[0].Value = MODELWATERFEECHARGE.DAYCHECKWORKERNAME;
            para[1].Value = MODELWATERFEECHARGE.DAYCHECKSTATE;

            if (MODELWATERFEECHARGE.DAYCHECKSTATE == "1")
                para[2].Value = MODELWATERFEECHARGE.DAYCHECKDATETIME;
            else
                para[2].Value = null;
            para[3].Value = MODELWATERFEECHARGE.DAYCHECKID;
            int intCount = DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para);
            return intCount;
        }
        /// <summary>
        /// 月结账，根据查询条件执行结账语句
        /// </summary>
        /// <param name="strUserID"></param>
        /// <returns></returns>
        public int UpdateMonthCheckState(MODELWATERFEECHARGE MODELWATERFEECHARGE, string strFilter)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE WATERFEECHARGE SET SETTLEACCOUNTSSSID=NULL,MONTHCHECKSTATE=@MONTHCHECKSTATE,MONTHCHECKDATETIME=GETDATE() " +
                " WHERE 1=1" + strFilter);
            SqlParameter[] para =
           {
               new SqlParameter("@MONTHCHECKWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@MONTHCHECKSTATE",SqlDbType.VarChar,10),
           };
            para[0].Value = MODELWATERFEECHARGE.MONTHCHECKWORKERNAME;
            para[1].Value = MODELWATERFEECHARGE.MONTHCHECKSTATE;
            int intCount = DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para);
            return intCount;
        }
        /// <summary>
        /// 更新收款方式
        /// </summary>
        /// <param name="MODELWATERFEECHARGE"></param>
        /// <returns></returns>
        public bool UpdateChargeType(MODELWATERFEECHARGE MODELWATERFEECHARGE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE WATERFEECHARGE SET CHARGETYPEID=@CHARGETYPEID,POSRUNNINGNO=@POSRUNNINGNO WHERE CHARGEID=@CHARGEID");
            SqlParameter[] para =
           {
               new SqlParameter("@CHARGETYPEID",SqlDbType.VarChar,10),
               new SqlParameter("@POSRUNNINGNO",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30)
           };
            para[0].Value = MODELWATERFEECHARGE.CHARGETYPEID;
            para[1].Value = MODELWATERFEECHARGE.POSRUNNINGNO;
            para[2].Value = MODELWATERFEECHARGE.CHARGEID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 删除抄表记录
        /// </summary>
        /// <param name="strUserID"></param>
        /// <returns></returns>
        public bool Delete(string strUserID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM WATERFEECHARGE WHERE CHARGEID=@CHARGEID");
            SqlParameter[] para =
           {
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30)
           };
            para[0].Value = strUserID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool Update(MODELWATERFEECHARGE MODELWATERFEECHARGE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE WATERFEECHARGE SET WATERTOTALCHARGE=@WATERTOTALCHARGE,EXTRATOTALCHARGE=@EXTRATOTALCHARGE,TOTALCHARGE=@TOTALCHARGE," +
            "OVERDUEMONEY=@OVERDUEMONEY,CHARGETYPEID=@CHARGETYPEID,CHARGEBCYS=@CHARGEBCYS,CHARGEBCSS=@CHARGEBCSS,CHARGEYSBCSZ=@CHARGEYSBCSZ," +
                "CHARGEWORKERID=@CHARGEWORKERID,CHARGEWORKERNAME=@CHARGEWORKERNAME,CHARGEDATETIME=@CHARGEDATETIME,MEMO=@MEMO ");
            str.Append("WHERE CHARGEID=@CHARGEID");
            SqlParameter[] para =
           {
               new SqlParameter("@WATERTOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@EXTRATOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@OVERDUEMONEY",SqlDbType.Decimal),
               new SqlParameter("@CHARGETYPEID",SqlDbType.VarChar,10),
               new SqlParameter("@CHARGEBCYS",SqlDbType.Decimal),
               new SqlParameter("@CHARGEBCSS",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSBCSZ",SqlDbType.Decimal),
               new SqlParameter("@CHARGEWORKERID",SqlDbType.VarChar,30),
               new SqlParameter("@CHARGEWORKERNAME",SqlDbType.VarChar,30),
               new SqlParameter("@CHARGEDATETIME",SqlDbType.Decimal),
               new SqlParameter("@MEMO",SqlDbType.Decimal),
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30)
           };

            para[0].Value = MODELWATERFEECHARGE.WATERTOTALCHARGE;
            para[1].Value = MODELWATERFEECHARGE.EXTRATOTALCHARGE;
            para[2].Value = MODELWATERFEECHARGE.TOTALCHARGE;
            para[3].Value = MODELWATERFEECHARGE.OVERDUEMONEY;
            para[4].Value = MODELWATERFEECHARGE.CHARGETYPEID;
            para[5].Value = MODELWATERFEECHARGE.CHARGEBCYS;
            para[6].Value = MODELWATERFEECHARGE.CHARGEBCSS;
            para[7].Value = MODELWATERFEECHARGE.CHARGEYSBCSZ;
            para[8].Value = MODELWATERFEECHARGE.CHARGEWORKERID;
            para[9].Value = MODELWATERFEECHARGE.CHARGEWORKERNAME;
            para[10].Value = MODELWATERFEECHARGE.CHARGEDATETIME;
            para[11].Value = MODELWATERFEECHARGE.MEMO;
            para[12].Value = MODELWATERFEECHARGE.CHARGEID;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 更新解挂后的收费时间，解挂后收费时间取解挂时的时间
        /// </summary>
        /// <param name="MODELWATERFEECHARGE"></param>
        /// <returns></returns>
        public bool UpdateChargeDateTime(MODELWATERFEECHARGE MODELWATERFEECHARGE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE WATERFEECHARGE SET CHARGEDATETIME=@CHARGEDATETIME,CHARGEYSQQYE=@CHARGEYSQQYE,CHARGEYSJSYE=@CHARGEYSJSYE ");
            str.Append("WHERE CHARGEID=@CHARGEID");
            SqlParameter[] para =
           {
               new SqlParameter("@CHARGEDATETIME",SqlDbType.DateTime),
               new SqlParameter("@CHARGEYSQQYE",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSJSYE",SqlDbType.Decimal),
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30)
           };

            para[0].Value = MODELWATERFEECHARGE.CHARGEDATETIME;
            para[1].Value = MODELWATERFEECHARGE.CHARGEYSQQYE;
            para[2].Value = MODELWATERFEECHARGE.CHARGEYSJSYE;
            para[3].Value = MODELWATERFEECHARGE.CHARGEID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool Insert(MODELWATERFEECHARGE MODELWATERFEECHARGE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO WATERFEECHARGE(CHARGEID,WATERTOTALCHARGE,EXTRATOTALCHARGE,TOTALCHARGE,OVERDUEMONEY,CHARGETYPEID,CHARGEBCYS," +
                "CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME,INVOICEPRINTSIGN,RECEIPTPRINTCOUNT,MEMO,CHARGEClASS,TOTALNUMBERCHARGE,EXTRACHARGECHARGE1,EXTRACHARGECHARGE2,RECEIPTNO,POSRUNNINGNO) ");
            str.Append("VALUES(@CHARGEID,@WATERTOTALCHARGE,@EXTRATOTALCHARGE,@TOTALCHARGE,@OVERDUEMONEY,@CHARGETYPEID,@CHARGEBCYS," +
                "@CHARGEBCSS,@CHARGEYSQQYE,@CHARGEYSBCSZ,@CHARGEYSJSYE,@CHARGEWORKERID,@CHARGEWORKERNAME,@CHARGEDATETIME,@INVOICEPRINTSIGN,@RECEIPTPRINTCOUNT,@MEMO,@CHARGEClASS,@TOTALNUMBERCHARGE,@EXTRACHARGECHARGE1,@EXTRACHARGECHARGE2,@RECEIPTNO,@POSRUNNINGNO) ");
            SqlParameter[] para =
           {
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30),
               new SqlParameter("@WATERTOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@EXTRATOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@OVERDUEMONEY",SqlDbType.Decimal),
               new SqlParameter("@CHARGETYPEID",SqlDbType.Int),
               new SqlParameter("@CHARGEBCYS",SqlDbType.Decimal),
               new SqlParameter("@CHARGEBCSS",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSQQYE",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSBCSZ",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSJSYE",SqlDbType.Decimal),
               new SqlParameter("@CHARGEWORKERID",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGEWORKERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGEDATETIME",SqlDbType.DateTime),
               new SqlParameter("@INVOICEPRINTSIGN",SqlDbType.VarChar,10),
               new SqlParameter("@RECEIPTPRINTCOUNT",SqlDbType.Int),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@CHARGEClASS",SqlDbType.VarChar,10),
               new SqlParameter("@TOTALNUMBERCHARGE",SqlDbType.Int),
               new SqlParameter("@EXTRACHARGECHARGE1",SqlDbType.Decimal),
               new SqlParameter("@EXTRACHARGECHARGE2",SqlDbType.Decimal),
               new SqlParameter("@RECEIPTNO",SqlDbType.VarChar,50),
               new SqlParameter("@POSRUNNINGNO",SqlDbType.VarChar,50)
           };

            para[0].Value = MODELWATERFEECHARGE.CHARGEID;
            para[1].Value = MODELWATERFEECHARGE.WATERTOTALCHARGE;
            para[2].Value = MODELWATERFEECHARGE.EXTRATOTALCHARGE;
            para[3].Value = MODELWATERFEECHARGE.TOTALCHARGE;
            para[4].Value = MODELWATERFEECHARGE.OVERDUEMONEY;
            para[5].Value = MODELWATERFEECHARGE.CHARGETYPEID;
            para[6].Value = MODELWATERFEECHARGE.CHARGEBCYS;
            para[7].Value = MODELWATERFEECHARGE.CHARGEBCSS;
            para[8].Value = MODELWATERFEECHARGE.CHARGEYSQQYE;
            para[9].Value = MODELWATERFEECHARGE.CHARGEYSBCSZ;
            para[10].Value = MODELWATERFEECHARGE.CHARGEYSJSYE;
            para[11].Value = MODELWATERFEECHARGE.CHARGEWORKERID;
            para[12].Value = MODELWATERFEECHARGE.CHARGEWORKERNAME;
            para[13].Value = MODELWATERFEECHARGE.CHARGEDATETIME;
            para[14].Value = MODELWATERFEECHARGE.INVOICEPRINTSIGN;
            para[15].Value = MODELWATERFEECHARGE.RECEIPTPRINTCOUNT;
            para[16].Value = MODELWATERFEECHARGE.MEMO;
            para[17].Value = MODELWATERFEECHARGE.CHARGEClASS;
            para[18].Value = MODELWATERFEECHARGE.TOTALNUMBERCHARGE;
            para[19].Value = MODELWATERFEECHARGE.EXTRACHARGECHARGE1;
            para[20].Value = MODELWATERFEECHARGE.EXTRACHARGECHARGE2;
            para[21].Value = MODELWATERFEECHARGE.RECEIPTNO;
            para[22].Value = MODELWATERFEECHARGE.POSRUNNINGNO;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 收费打印收据
        /// </summary>
        /// <param name="MODELWATERFEECHARGE"></param>
        /// <returns></returns>
        public bool InsertSJ(MODELWATERFEECHARGE MODELWATERFEECHARGE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO WATERFEECHARGE(CHARGEID,WATERTOTALCHARGE,EXTRATOTALCHARGE,TOTALCHARGE,OVERDUEMONEY,CHARGETYPEID,CHARGEBCYS," +
                "CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME,RECEIPTPRINTCOUNT,MEMO,"+
                "CHARGEClASS,TOTALNUMBERCHARGE,EXTRACHARGECHARGE1,EXTRACHARGECHARGE2,RECEIPTNO,POSRUNNINGNO) ");
            str.Append("VALUES(@CHARGEID,@WATERTOTALCHARGE,@EXTRATOTALCHARGE,@TOTALCHARGE,@OVERDUEMONEY,@CHARGETYPEID,@CHARGEBCYS," +
                "@CHARGEBCSS,@CHARGEYSQQYE,@CHARGEYSBCSZ,@CHARGEYSJSYE,@CHARGEWORKERID,@CHARGEWORKERNAME,@CHARGEDATETIME,@RECEIPTPRINTCOUNT,@MEMO,"+
                "@CHARGEClASS,@TOTALNUMBERCHARGE,@EXTRACHARGECHARGE1,@EXTRACHARGECHARGE2,@RECEIPTNO,@POSRUNNINGNO) ");
            SqlParameter[] para =
           {
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30),
               new SqlParameter("@WATERTOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@EXTRATOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@OVERDUEMONEY",SqlDbType.Decimal),
               new SqlParameter("@CHARGETYPEID",SqlDbType.Int),
               new SqlParameter("@CHARGEBCYS",SqlDbType.Decimal),
               new SqlParameter("@CHARGEBCSS",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSQQYE",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSBCSZ",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSJSYE",SqlDbType.Decimal),
               new SqlParameter("@CHARGEWORKERID",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGEWORKERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGEDATETIME",SqlDbType.DateTime),
               new SqlParameter("@RECEIPTPRINTCOUNT",SqlDbType.Int),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@CHARGEClASS",SqlDbType.VarChar,10),
               new SqlParameter("@TOTALNUMBERCHARGE",SqlDbType.Int),
               new SqlParameter("@EXTRACHARGECHARGE1",SqlDbType.Decimal),
               new SqlParameter("@EXTRACHARGECHARGE2",SqlDbType.Decimal),
               new SqlParameter("@RECEIPTNO",SqlDbType.VarChar,50),
               new SqlParameter("@POSRUNNINGNO",SqlDbType.VarChar,50)
           };

            para[0].Value = MODELWATERFEECHARGE.CHARGEID;
            para[1].Value = MODELWATERFEECHARGE.WATERTOTALCHARGE;
            para[2].Value = MODELWATERFEECHARGE.EXTRATOTALCHARGE;
            para[3].Value = MODELWATERFEECHARGE.TOTALCHARGE;
            para[4].Value = MODELWATERFEECHARGE.OVERDUEMONEY;
            para[5].Value = MODELWATERFEECHARGE.CHARGETYPEID;
            para[6].Value = MODELWATERFEECHARGE.CHARGEBCYS;
            para[7].Value = MODELWATERFEECHARGE.CHARGEBCSS;
            para[8].Value = MODELWATERFEECHARGE.CHARGEYSQQYE;
            para[9].Value = MODELWATERFEECHARGE.CHARGEYSBCSZ;
            para[10].Value = MODELWATERFEECHARGE.CHARGEYSJSYE;
            para[11].Value = MODELWATERFEECHARGE.CHARGEWORKERID;
            para[12].Value = MODELWATERFEECHARGE.CHARGEWORKERNAME;
            para[13].Value = MODELWATERFEECHARGE.CHARGEDATETIME;
            para[14].Value = MODELWATERFEECHARGE.RECEIPTPRINTCOUNT;
            para[15].Value = MODELWATERFEECHARGE.MEMO;
            para[16].Value = MODELWATERFEECHARGE.CHARGEClASS;
            para[17].Value = MODELWATERFEECHARGE.TOTALNUMBERCHARGE;
            para[18].Value = MODELWATERFEECHARGE.EXTRACHARGECHARGE1;
            para[19].Value = MODELWATERFEECHARGE.EXTRACHARGECHARGE2;
            para[20].Value = MODELWATERFEECHARGE.RECEIPTNO;
            para[21].Value = MODELWATERFEECHARGE.POSRUNNINGNO;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 打印发票更新收费明细表
        /// </summary>
        /// <param name="MODELWATERFEECHARGE"></param>
        /// <returns></returns>
        public bool InsertFP(MODELWATERFEECHARGE MODELWATERFEECHARGE)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO WATERFEECHARGE(CHARGEID,WATERTOTALCHARGE,EXTRATOTALCHARGE,TOTALCHARGE,OVERDUEMONEY,CHARGETYPEID,CHARGEBCYS," +
                "CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME,INVOICEPRINTSIGN,MEMO," +
                "CHARGEClASS,TOTALNUMBERCHARGE,EXTRACHARGECHARGE1,EXTRACHARGECHARGE2,POSRUNNINGNO) ");
            str.Append("VALUES(@CHARGEID,@WATERTOTALCHARGE,@EXTRATOTALCHARGE,@TOTALCHARGE,@OVERDUEMONEY,@CHARGETYPEID,@CHARGEBCYS," +
                "@CHARGEBCSS,@CHARGEYSQQYE,@CHARGEYSBCSZ,@CHARGEYSJSYE,@CHARGEWORKERID,@CHARGEWORKERNAME,@CHARGEDATETIME,@INVOICEPRINTSIGN,@MEMO," +
                "@CHARGEClASS,@TOTALNUMBERCHARGE,@EXTRACHARGECHARGE1,@EXTRACHARGECHARGE2,@POSRUNNINGNO) ");
            SqlParameter[] para =
           {
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30),
               new SqlParameter("@WATERTOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@EXTRATOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@TOTALCHARGE",SqlDbType.Decimal),
               new SqlParameter("@OVERDUEMONEY",SqlDbType.Decimal),
               new SqlParameter("@CHARGETYPEID",SqlDbType.Int),
               new SqlParameter("@CHARGEBCYS",SqlDbType.Decimal),
               new SqlParameter("@CHARGEBCSS",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSQQYE",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSBCSZ",SqlDbType.Decimal),
               new SqlParameter("@CHARGEYSJSYE",SqlDbType.Decimal),
               new SqlParameter("@CHARGEWORKERID",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGEWORKERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGEDATETIME",SqlDbType.DateTime),
               new SqlParameter("@INVOICEPRINTSIGN",SqlDbType.VarChar,10),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@CHARGEClASS",SqlDbType.VarChar,10),
               new SqlParameter("@TOTALNUMBERCHARGE",SqlDbType.Int),
               new SqlParameter("@EXTRACHARGECHARGE1",SqlDbType.Decimal),
               new SqlParameter("@EXTRACHARGECHARGE2",SqlDbType.Decimal),
               new SqlParameter("@POSRUNNINGNO",SqlDbType.VarChar,50)
           };

            para[0].Value = MODELWATERFEECHARGE.CHARGEID;
            para[1].Value = MODELWATERFEECHARGE.WATERTOTALCHARGE;
            para[2].Value = MODELWATERFEECHARGE.EXTRATOTALCHARGE;
            para[3].Value = MODELWATERFEECHARGE.TOTALCHARGE;
            para[4].Value = MODELWATERFEECHARGE.OVERDUEMONEY;
            para[5].Value = MODELWATERFEECHARGE.CHARGETYPEID;
            para[6].Value = MODELWATERFEECHARGE.CHARGEBCYS;
            para[7].Value = MODELWATERFEECHARGE.CHARGEBCSS;
            para[8].Value = MODELWATERFEECHARGE.CHARGEYSQQYE;
            para[9].Value = MODELWATERFEECHARGE.CHARGEYSBCSZ;
            para[10].Value = MODELWATERFEECHARGE.CHARGEYSJSYE;
            para[11].Value = MODELWATERFEECHARGE.CHARGEWORKERID;
            para[12].Value = MODELWATERFEECHARGE.CHARGEWORKERNAME;
            para[13].Value = MODELWATERFEECHARGE.CHARGEDATETIME;
            para[14].Value = MODELWATERFEECHARGE.INVOICEPRINTSIGN;
            para[15].Value = MODELWATERFEECHARGE.MEMO;
            para[16].Value = MODELWATERFEECHARGE.CHARGEClASS;
            para[17].Value = MODELWATERFEECHARGE.TOTALNUMBERCHARGE;
            para[18].Value = MODELWATERFEECHARGE.EXTRACHARGECHARGE1;
            para[19].Value = MODELWATERFEECHARGE.EXTRACHARGECHARGE2;
            para[20].Value = MODELWATERFEECHARGE.POSRUNNINGNO;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
    }
}
