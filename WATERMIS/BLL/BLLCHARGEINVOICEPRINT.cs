using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLCHARGEINVOICEPRINT
    {
        /// <summary>
        /// 查询含有收费记录的发票使用明细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM V_CHARGEINVOICEPRINT WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
        /// <summary>
        /// 查询自定额发票使用明细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
       public DataTable QueryInvoicePrint(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM CHARGEINVOICEPRINT WHERE CHARGEID IS NULL ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
        /// <summary>
        /// 根据抄表员统计收费情况
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
       public DataTable StaticsInvoiceByChargeWorkID(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT CHARGEWORKERID AS 收费员编号,CHARGEWORKERNAME AS 收费员,waterMeterTypeId AS 用水性质编号,waterMeterTypeName AS 用水性质,COUNT(INVOICENO) AS 发票数量,SUM(totalNumber) AS  用水量, ");
           str.Append("SUM(waterTotalChargeInvoice) AS 水费,SUM(extraCharge1) AS 污水处理费,SUM(extraCharge2) AS 附加费, ");
           str.Append("SUM(totalChargeInvoice) AS 总金额 FROM (SELECT * FROM V_CHARGEINVOICEPRINT WHERE INVOICECANCEL='0'AND CHARGEID IN (SELECT CHARGEID FROM V_CHARGE WHERE 1=1 ");
           //str.Append("SUM(totalChargeInvoice) AS 总金额 FROM (SELECT * FROM V_CHARGEINVOICEPRINT WHERE 1=1 ");
           str.Append(strWhere);
           str.Append(")) AS AAA GROUP BY CHARGEWORKERID,CHARGEWORKERNAME,waterMeterTypeId,waterMeterTypeName");
           str.Append(" ORDER BY CHARGEWORKERID,waterMeterTypeId");
           DT = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
           return DT;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM CHARGEINVOICEPRINT WHERE CHARGEID=@CHARGEID");
           SqlParameter[] para =
           {
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool DeleteByID(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM CHARGEINVOICEPRINT WHERE CHARGEINVOICEPRINTID=@CHARGEINVOICEPRINTID");
           SqlParameter[] para =
           {
               new SqlParameter("@CHARGEINVOICEPRINTID",SqlDbType.VarChar,30)
           };
           para[0].Value = strID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 根据收费单据ID更新发票表作废状态
       /// </summary>
       /// <param name="MODELCHARGEINVOICEPRINT"></param>
       /// <returns></returns>
       public bool UpdateCancelState(MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE CHARGEINVOICEPRINT SET INVOICECANCEL=@INVOICECANCEL,INVOICECANCELWORKERID=@INVOICECANCELWORKERID," +
               "INVOICECANCELWORKERNAME=@INVOICECANCELWORKERNAME,INVOICECANCELDATETIME=@INVOICECANCELDATETIME,INVOICECANCELMEMO=@INVOICECANCELMEMO ");
           str.Append("WHERE CHARGEID=@CHARGEID");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICECANCEL",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICECANCELWORKERID",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICECANCELWORKERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICECANCELDATETIME",SqlDbType.DateTime),
               new SqlParameter("@INVOICECANCELMEMO",SqlDbType.VarChar,200),
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELCHARGEINVOICEPRINT.INVOICECANCEL;
           para[1].Value = MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID;
           para[2].Value = MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME;

           if (MODELCHARGEINVOICEPRINT.INVOICECANCEL == "0")
               para[3].Value = null;
           else
               para[3].Value = MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME;

           para[4].Value = MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO;
           para[5].Value = MODELCHARGEINVOICEPRINT.CHARGEID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 根据收费单据ID更新发票表作废状态
       /// </summary>
       /// <param name="MODELCHARGEINVOICEPRINT"></param>
       /// <returns></returns>
       public bool UpdateCancelStateByID(MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE CHARGEINVOICEPRINT SET INVOICECANCEL=@INVOICECANCEL,INVOICECANCELWORKERID=@INVOICECANCELWORKERID," +
               "INVOICECANCELWORKERNAME=@INVOICECANCELWORKERNAME,INVOICECANCELDATETIME=@INVOICECANCELDATETIME,INVOICECANCELMEMO=@INVOICECANCELMEMO ");
           str.Append("WHERE CHARGEINVOICEPRINTID=@CHARGEINVOICEPRINTID");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICECANCEL",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICECANCELWORKERID",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICECANCELWORKERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICECANCELDATETIME",SqlDbType.DateTime),
               new SqlParameter("@INVOICECANCELMEMO",SqlDbType.VarChar,200),
               new SqlParameter("@CHARGEINVOICEPRINTID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELCHARGEINVOICEPRINT.INVOICECANCEL;
           para[1].Value = MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID;
           para[2].Value = MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME;

           if (MODELCHARGEINVOICEPRINT.INVOICECANCEL == "0")
               para[3].Value = null;
           else
               para[3].Value = MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME;

           para[4].Value = MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO;
           para[5].Value = MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 发票号码变更,并将发票单号置为正常状态
       /// </summary>
       /// <param name="MODELCHARGEINVOICEPRINT"></param>
       /// <returns></returns>
       public bool ChangeInvoiceNO(MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE CHARGEINVOICEPRINT SET INVOICEBATCHID=@INVOICEBATCHID,INVOICEBATCHNAME=@INVOICEBATCHNAME,INVOICENO=@INVOICENO,");
           str.Append("INVOICECANCEL='0',INVOICECANCELWORKERID=null,INVOICECANCELWORKERNAME=null,INVOICECANCELDATETIME=null,INVOICECANCELMEMO=null ");
           str.Append("WHERE CHARGEINVOICEPRINTID=@CHARGEINVOICEPRINTID");
           SqlParameter[] para =
           {
               new SqlParameter("@INVOICEBATCHID",SqlDbType.VarChar,30),
               new SqlParameter("@INVOICEBATCHNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICENO",SqlDbType.VarChar,30),
               new SqlParameter("@CHARGEINVOICEPRINTID",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELCHARGEINVOICEPRINT.INVOICEBATCHID;
           para[1].Value = MODELCHARGEINVOICEPRINT.INVOICEBATCHNAME;
           para[2].Value = MODELCHARGEINVOICEPRINT.INVOICENO;
           para[3].Value = MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
        /// <summary>
        /// 插入发票使用记录
        /// </summary>
        /// <param name="MODELCHARGEINVOICEPRINT"></param>
        /// <returns></returns>
       public bool Insert(MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO CHARGEINVOICEPRINT(CHARGEINVOICEPRINTID,CHARGEID,INVOICEBATCHID,INVOICEBATCHNAME,INVOICENO,INVOICECANCEL,INVOICEPRINTDATETIME,");
           str.Append("readMeterRecordYear,readMeterRecordMonth,waterUserName,waterMeterNo,waterUserAddress,waterMeterTypeId,waterMeterTypeName,");
           str.Append("waterMeterLastNumber,waterMeterEndNumber,totalNumber,avePrice,waterTotalCharge,extraCharge1,extraCharge2,totalCharge,INVOICEPRINTWORKERID,INVOICEPRINTWORKERNAME)");
           str.Append("VALUES(@CHARGEINVOICEPRINTID,@CHARGEID,@INVOICEBATCHID,@INVOICEBATCHNAME,@INVOICENO,@INVOICECANCEL,@INVOICEPRINTDATETIME,");
           str.Append("@readMeterRecordYear,@readMeterRecordMonth,@waterUserName,@waterMeterNo,@waterUserAddress,@waterMeterTypeId,@waterMeterTypeName,");
           str.Append("@waterMeterLastNumber,@waterMeterEndNumber,@totalNumber,@avePrice,@waterTotalCharge,@extraCharge1,@extraCharge2,@totalCharge,@INVOICEPRINTWORKERID,@INVOICEPRINTWORKERNAME)");
           SqlParameter[] para =
           {
               new SqlParameter("@CHARGEINVOICEPRINTID",SqlDbType.VarChar,30),
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,30),
               new SqlParameter("@INVOICEBATCHID",SqlDbType.VarChar,30),
               new SqlParameter("@INVOICEBATCHNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICENO",SqlDbType.VarChar,30),
               new SqlParameter("@INVOICECANCEL",SqlDbType.VarChar,10),
               new SqlParameter("@INVOICEPRINTDATETIME",SqlDbType.DateTime),
               
               new SqlParameter("@readMeterRecordYear",SqlDbType.Int),
               new SqlParameter("@readMeterRecordMonth",SqlDbType.Int),
               new SqlParameter("@waterUserName",SqlDbType.VarChar,70),
               new SqlParameter("@waterMeterNo",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserAddress",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30),
               new SqlParameter("@waterMeterTypeName",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterLastNumber",SqlDbType.Int),
               new SqlParameter("@waterMeterEndNumber",SqlDbType.Int),
               new SqlParameter("@totalNumber",SqlDbType.Int),
               new SqlParameter("@avePrice",SqlDbType.Float),
               new SqlParameter("@waterTotalCharge",SqlDbType.Float),
               new SqlParameter("@extraCharge1",SqlDbType.Float),
               new SqlParameter("@extraCharge2",SqlDbType.Float),
               new SqlParameter("@totalCharge",SqlDbType.Float),
               new SqlParameter("@INVOICEPRINTWORKERID",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICEPRINTWORKERNAME",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID;
           para[1].Value = MODELCHARGEINVOICEPRINT.CHARGEID;
           para[2].Value = MODELCHARGEINVOICEPRINT.INVOICEBATCHID;
           para[3].Value = MODELCHARGEINVOICEPRINT.INVOICEBATCHNAME;
           para[4].Value = MODELCHARGEINVOICEPRINT.INVOICENO;
           para[5].Value = MODELCHARGEINVOICEPRINT.INVOICECANCEL;
           para[6].Value = MODELCHARGEINVOICEPRINT.INVOICEPRINTDATETIME;
           para[7].Value = MODELCHARGEINVOICEPRINT.readMeterRecordYear;
           para[8].Value = MODELCHARGEINVOICEPRINT.readMeterRecordMonth;
           para[9].Value = MODELCHARGEINVOICEPRINT.waterUserName;
           para[10].Value = MODELCHARGEINVOICEPRINT.waterMeterNo;
           para[11].Value = MODELCHARGEINVOICEPRINT.waterUserAddress;
           para[12].Value = MODELCHARGEINVOICEPRINT.waterMeterTypeId;
           para[13].Value = MODELCHARGEINVOICEPRINT.waterMeterTypeName;
           para[14].Value = MODELCHARGEINVOICEPRINT.waterMeterLastNumber;
           para[15].Value = MODELCHARGEINVOICEPRINT.waterMeterEndNumber;
           para[16].Value = MODELCHARGEINVOICEPRINT.totalNumber;
           para[17].Value = MODELCHARGEINVOICEPRINT.avePrice;
           para[18].Value = MODELCHARGEINVOICEPRINT.waterTotalCharge;
           para[19].Value = MODELCHARGEINVOICEPRINT.extraCharge1;
           para[20].Value = MODELCHARGEINVOICEPRINT.extraCharge2;
           para[21].Value = MODELCHARGEINVOICEPRINT.totalCharge;
           para[22].Value = MODELCHARGEINVOICEPRINT.INVOICEPRINTWORKERID;
           para[23].Value = MODELCHARGEINVOICEPRINT.INVOICEPRINTWORKERNAME;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}
