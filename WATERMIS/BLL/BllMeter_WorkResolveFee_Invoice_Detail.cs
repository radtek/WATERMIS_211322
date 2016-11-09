using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BllMeter_WorkResolveFee_Invoice_Detail
    {
        /// <summary>
        /// 查询业扩发票使用情况
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable QueryMeterWorkInvoice(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM Meter_WorkResolveFee_Invoice WHERE 1=1");
            dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取有业扩最大发票号
        /// </summary>
        /// <param name="strLogID">登陆用户ID</param>
        /// <param name="strInvoiceBatchID">发票批次</param>
        /// <returns></returns>
        public DataTable GetMaxInvoiceNO_MeterWork(string strLogID, string strInvoiceBatchID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT TOP 1 INVOICEBATCHID,INVOICENO FROM Meter_WorkResolveFee_Invoice WHERE INVOICEPRINTWORKERID='" + strLogID + "' AND INVOICECANCEL<>'3' AND " +
                " INVOICEBATCHID='" + strInvoiceBatchID + "' ORDER BY INVOICEPRINTDATETIME DESC");
            DataTable dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];

            return dt;
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
       public bool Insert(ModelMeter_WorkResolveFee_Invoice ModelMeter_WorkResolveFee_Invoice)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO Meter_WorkResolveFee_Invoice(InvoicePrintID,ChargeID,INVOICEBATCHID,INVOICEBATCHNAME,INVOICENO,");
           str.Append("WaterUserName,WaterUserAddress,WaterUserFPTaxNO,WaterUserFPBankNameAndAccountNO,Table_Name_CH,InvoiceFeeDepID,InvoiceFeeDepName,");
           str.Append("InvoiceTotalFeeMoney,CompanyName,CompanyAddress,CompanyFPTaxNO,CompanyFPBankNameAndAccountNO,Payee,Checker,InvoicePrintWorkerID,InvoicePrintWorker,");
           str.Append("InvoicePrintDateTime,InvoiceType,InvoiceCancel,Memo,WaterUserID) ");

           str.Append("VALUES(@InvoicePrintID,@ChargeID,@INVOICEBATCHID,@INVOICEBATCHNAME,@INVOICENO,");
           str.Append("@WaterUserName,@WaterUserAddress,@WaterUserFPTaxNO,@WaterUserFPBankNameAndAccountNO,@Table_Name_CH,@InvoiceFeeDepID,@InvoiceFeeDepName,");
           str.Append("@InvoiceTotalFeeMoney,@CompanyName,@CompanyAddress,@CompanyFPTaxNO,@CompanyFPBankNameAndAccountNO,@Payee,@Checker,@InvoicePrintWorkerID,@InvoicePrintWorker,");
           str.Append("GETDATE(),@InvoiceType,'0',@Memo,@WaterUserID)");
           SqlParameter[] para =
           {
               new SqlParameter("@InvoicePrintID",SqlDbType.VarChar,30),
               new SqlParameter("@ChargeID",SqlDbType.VarChar,30),
               new SqlParameter("@INVOICEBATCHID",SqlDbType.VarChar,30),
               new SqlParameter("@INVOICEBATCHNAME",SqlDbType.VarChar,50),
               new SqlParameter("@INVOICENO",SqlDbType.VarChar,30),
               new SqlParameter("@waterUserName",SqlDbType.VarChar,70),
               new SqlParameter("@waterUserAddress",SqlDbType.VarChar,100),               
               new SqlParameter("@WaterUserFPTaxNO",SqlDbType.VarChar,50),
               new SqlParameter("@WaterUserFPBankNameAndAccountNO",SqlDbType.VarChar,100),
               new SqlParameter("@Table_Name_CH",SqlDbType.VarChar,30),
               new SqlParameter("@InvoiceFeeDepID",SqlDbType.VarChar,30),
               new SqlParameter("@InvoiceFeeDepName",SqlDbType.VarChar,50),
               new SqlParameter("@InvoiceTotalFeeMoney",SqlDbType.Decimal),
               new SqlParameter("@CompanyName",SqlDbType.VarChar,50),
               new SqlParameter("@CompanyAddress",SqlDbType.VarChar,50),
               new SqlParameter("@CompanyFPTaxNO",SqlDbType.VarChar,50),
               new SqlParameter("@CompanyFPBankNameAndAccountNO",SqlDbType.VarChar,100),
               new SqlParameter("@Payee",SqlDbType.VarChar,20),
               new SqlParameter("@Checker",SqlDbType.VarChar,20),
               new SqlParameter("@InvoicePrintWorkerID",SqlDbType.VarChar,10),
               new SqlParameter("@InvoicePrintWorker",SqlDbType.VarChar,20),
               new SqlParameter("@InvoiceType",SqlDbType.VarChar,10),
               new SqlParameter("@Memo",SqlDbType.VarChar,100),
               new SqlParameter("@WaterUserID",SqlDbType.VarChar,100)

           };
           para[0].Value = ModelMeter_WorkResolveFee_Invoice.InvoicePrintID;
           para[1].Value = ModelMeter_WorkResolveFee_Invoice.ChargeID;
           para[2].Value = ModelMeter_WorkResolveFee_Invoice.InvoiceBatchID;
           para[3].Value = ModelMeter_WorkResolveFee_Invoice.InvoiceBatchName;
           para[4].Value = ModelMeter_WorkResolveFee_Invoice.InvoiceNO;
           para[5].Value = ModelMeter_WorkResolveFee_Invoice.WaterUserName;
           para[6].Value = ModelMeter_WorkResolveFee_Invoice.WaterUserAddress;
           para[7].Value = ModelMeter_WorkResolveFee_Invoice.WaterUserFPTaxNO;
           para[8].Value = ModelMeter_WorkResolveFee_Invoice.WaterUserFPBankNameAndAccountNO;
           para[9].Value = ModelMeter_WorkResolveFee_Invoice.Table_Name_CH;
           para[10].Value = ModelMeter_WorkResolveFee_Invoice.InvoiceFeeDepID;
           para[11].Value = ModelMeter_WorkResolveFee_Invoice.InvoiceFeeDepName;
           para[12].Value = ModelMeter_WorkResolveFee_Invoice.InvoiceTotalFeeMoney;
           para[13].Value = ModelMeter_WorkResolveFee_Invoice.CompanyName;
           para[14].Value = ModelMeter_WorkResolveFee_Invoice.CompanyAddress;
           para[15].Value = ModelMeter_WorkResolveFee_Invoice.CompanyFPTaxNO;
           para[16].Value = ModelMeter_WorkResolveFee_Invoice.CompanyFPBankNameAndAccountNO;
           para[17].Value = ModelMeter_WorkResolveFee_Invoice.Payee;
           para[18].Value = ModelMeter_WorkResolveFee_Invoice.Checker;
           para[19].Value = ModelMeter_WorkResolveFee_Invoice.InvoicePrintWorkerID;
           para[20].Value = ModelMeter_WorkResolveFee_Invoice.InvoicePrintWorker;
           para[21].Value = ModelMeter_WorkResolveFee_Invoice.InvoiceType;
           para[22].Value = ModelMeter_WorkResolveFee_Invoice.Memo;
           para[23].Value = ModelMeter_WorkResolveFee_Invoice.WaterUserID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       /// <summary>
       /// 插入发票项目记录
       /// </summary>
       /// <param name="MODELCHARGEINVOICEPRINT"></param>
       /// <returns></returns>
       public bool InsertDetail(ModelMeter_WorkResolveFee_Invoice_Detail ModelMeter_WorkResolveFee_Invoice_Detail)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO Meter_WorkResolveFee_Invoice_Detail(InvoicePrintID,DetailIndex,FeeItem,FeeItemInvoiceTitle,");
           str.Append("Quantity,TaxPercent,TaxMoney,TotalMoney,Units,Price) ");

           str.Append("VALUES(@InvoicePrintID,@DetailIndex,@FeeItem,@FeeItemInvoiceTitle,");
           str.Append("@Quantity,@TaxPercent,@TaxMoney,@TotalMoney,@Units,@Price) ");
           SqlParameter[] para =
           {
               new SqlParameter("@InvoicePrintID",SqlDbType.VarChar,30),
               new SqlParameter("@DetailIndex",SqlDbType.Int),
               new SqlParameter("@FeeItem",SqlDbType.VarChar,30),
               new SqlParameter("@FeeItemInvoiceTitle",SqlDbType.VarChar,30),
               new SqlParameter("@Quantity",SqlDbType.Decimal),
               new SqlParameter("@TaxPercent",SqlDbType.Decimal),
               new SqlParameter("@TaxMoney",SqlDbType.Decimal),               
               new SqlParameter("@TotalMoney",SqlDbType.Decimal),
               new SqlParameter("@Units",SqlDbType.VarChar,30),
               new SqlParameter("@Price",SqlDbType.Decimal)
           };
           para[0].Value = ModelMeter_WorkResolveFee_Invoice_Detail.InvoicePrintID;
           para[1].Value = ModelMeter_WorkResolveFee_Invoice_Detail.DetailIndex;
           para[2].Value = ModelMeter_WorkResolveFee_Invoice_Detail.FeeItem;
           para[3].Value = ModelMeter_WorkResolveFee_Invoice_Detail.FeeItemInvoiceTitle;
           para[4].Value = ModelMeter_WorkResolveFee_Invoice_Detail.Quantity;
           para[5].Value = ModelMeter_WorkResolveFee_Invoice_Detail.TaxPercent;
           para[6].Value = ModelMeter_WorkResolveFee_Invoice_Detail.TaxMoney;
           para[7].Value = ModelMeter_WorkResolveFee_Invoice_Detail.TotalMoney;
           para[8].Value = ModelMeter_WorkResolveFee_Invoice_Detail.Units;
           para[9].Value = ModelMeter_WorkResolveFee_Invoice_Detail.Price;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

        /// <summary>
        /// 根据发票ID删除发票及发票明细记录
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
       public bool Delete(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM Meter_WorkResolveFee_Invoice WHERE InvoicePrintID='" + strID + "' \n");
           str.Append("DELETE FROM Meter_WorkResolveFee_Invoice_Detail WHERE InvoicePrintID='" + strID + "'");

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
       public object GetSingle(string strSQL)
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
           int intRows = DBUtility.DbHelperSQL.ExecuteSql(strSQL);
           return intRows;
       }
       /// <summary>
       /// 自定义查询语句
       /// </summary>
       /// <param name="strSQL"></param>
       /// <returns></returns>
       public DataTable Query(string strSQL)
       {
           DataTable dt = DBUtility.DbHelperSQL.Query(strSQL).Tables[0];
           return dt;
       }
    }
}
