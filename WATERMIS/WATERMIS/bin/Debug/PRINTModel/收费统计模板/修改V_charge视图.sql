USE [WATERMANAGE]
GO

/****** Object:  View [dbo].[V_CHARGE]    Script Date: 09/25/2015 19:21:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
ALTER VIEW [dbo].[V_CHARGE]
AS
--历史收费视图，已用BLLWATERFEECHARGE.QueryLS
SELECT readMeterRecordId,waterUserId,waterUserNO,readMeterRecord.waterUserName,readMeterRecord.waterUserAddress,
meterReadingID,meterReadingNO,meterReadingPageNo,waterUserTypeId,waterUserTypeName,
waterUserHouseType,agentsign,waterUserState,bankId,bankName,waterMeterParentId,
(CASE waterUserHouseType WHEN '1' THEN '楼房' ELSE '平房' END) AS waterUserHouseTypeS,
(CASE agentsign WHEN '2' THEN '不托收' ELSE '托收' END) AS agentsignS,
(CASE waterUserState WHEN '1' THEN '正常' WHEN '0' THEN '报停' END) AS waterUserStateS,
readMeterRecord.waterMeterNo,readMeterRecord.waterMeterLastNumber,
readMeterRecord.waterMeterEndNumber,readMeterRecord.totalNumber,totalNumberDescribe,
readMeterRecord.avePrice,avePriceDescribe,readMeterRecord.waterTotalCharge,
extraChargePrice1,readMeterRecord.extraCharge1,
extraChargePrice2,readMeterRecord.extraCharge2,extraChargePrice3,extraCharge3,extraChargePrice4,
extraCharge4,extraChargePrice5,extraCharge5,extraChargePrice6,extraCharge6,
extraChargePrice7,extraCharge7,extraChargePrice8,extraCharge8,readMeterRecord.extraTotalCharge,
readMeterRecord.totalCharge,readMeterRecord.OVERDUEMONEY,WATERFIXVALUE,readMeterRecord.readMeterRecordYear,
readMeterRecord.readMeterRecordMonth,ordernumber,waterMeterPositionName,waterMeterSizeValue,readMeterRecord.waterMeterTypeId,
readMeterRecord.waterMeterTypeName,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,
waterMeterMagnification,waterMeterMaxRange,areaId,areaName,loginId,USERNAME,checkState,
checkDateTime,checker,readMeterRecord.memo,WATERFEECHARGE.CHARGEID,TOTALNUMBERCHARGE,
EXTRACHARGECHARGE1,EXTRACHARGECHARGE2,
WATERFEECHARGE.WATERTOTALCHARGE AS WATERTOTALCHARGECHARGE,
WATERFEECHARGE.EXTRATOTALCHARGE AS EXTRATOTALCHARGECHARGE,
WATERFEECHARGE.EXTRACHARGECHARGE1 as EXTRACHARGECHARGE1CHARGE,
WATERFEECHARGE.EXTRACHARGECHARGE2 as EXTRACHARGECHARGE2CHARGE,
WATERFEECHARGE.TOTALCHARGE AS TOTALCHARGECHARGE,
WATERFEECHARGE.OVERDUEMONEY AS OVERDUEMONEYCHARGE,
WATERFEECHARGE.CHARGETYPEID,CHARGETYPENAME,CHARGEBCYS,
CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,CHARGEWORKERNAME,
CHARGEDATETIME,chargeState,INVOICEPRINTSIGN,CHARGEINVOICEPRINTID,CHARGECANCEL,INVOICENO,INVOICEBATCHID,
INVOICEBATCHNAME,INVOICECANCEL

FROM readMeterRecord INNER JOIN WATERFEECHARGE ON readMeterRecord.chargeID=WATERFEECHARGE.CHARGEID
LEFT JOIN CHARGEINVOICEPRINT ON WATERFEECHARGE.CHARGEID=CHARGEINVOICEPRINT.CHARGEID AND isnull(INVOICECANCEL,'0')='0' 
LEFT JOIN CHARGETYPE ON WATERFEECHARGE.CHARGETYPEID=CHARGETYPE.CHARGETYPEID
WHERE checkState='1' AND chargeState='3'








GO


