using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLPRESTORERUNNINGACCOUNT
    {
        /// <summary>
        /// 查询有效的预收费列表，即未作废的
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Query(string strWhere)
        {
            DataTable DT = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_PRESTORERUNNINGACCOUNT_VALID WHERE 1=1 ");
            DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
            return DT;
        }
        /// <summary>
        /// 查询冲减的预收费列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable QueryPrestoreCANCEL(string strWhere)
        {
            DataTable DT = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM V_PRESTORERUNNINGACCOUNT_CANCEL WHERE 1=1 ");
            DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
            return DT;
        }
        public bool Delete(string strDEPID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM PRESTORERUNNINGACCOUNT WHERE PRESTORERUNNINGACCOUNTID=@PRESTORERUNNINGACCOUNTID");
            SqlParameter[] para =
           {
               new SqlParameter("@PRESTORERUNNINGACCOUNTID",SqlDbType.VarChar,30)
           };
            para[0].Value = strDEPID;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        public bool Update(MODELPRESTORERUNNINGACCOUNT MODELPRESTORERUNNINGACCOUNT)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE PRESTORERUNNINGACCOUNT SET CHARGEID=@CHARGEID,WATERUSERID=@WATERUSERID,WATERUSERNO=@WATERUSERNO,WATERUSERNAME=@WATERUSERNAME,MEMO=@MEMO ");
            str.Append("WHERE PRESTORERUNNINGACCOUNTID=@PRESTORERUNNINGACCOUNTID");
            SqlParameter[] para =
           {
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERID",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERNO",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@PRESTORERUNNINGACCOUNTID",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELPRESTORERUNNINGACCOUNT.CHARGEID;
            para[1].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERID;
            para[2].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERNO;
            para[3].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERNAME;
            para[4].Value = MODELPRESTORERUNNINGACCOUNT.MEMO;
            para[5].Value = MODELPRESTORERUNNINGACCOUNT.PRESTORERUNNINGACCOUNTID;

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
            str.Append("UPDATE PRESTORERUNNINGACCOUNT SET WATERUSERID=@WATERUSERID ");
            str.Append("WHERE WATERUSERID=@strIDSource");
            SqlParameter[] para =
           {
               new SqlParameter("@WATERUSERID",SqlDbType.VarChar,50),
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
        /// 大厅统计预收和水费。
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable GetAllChargeSum(string strFilter,string strGroupType)
        {
            StringBuilder str = new StringBuilder();
            if (strGroupType == "收费员")
            {
                str.Append("SELECT CHARGEWORKERID AS 收费员编号,CHARGEWORKERNAME AS 收费员,COUNT(*) AS 单据数量,SUM(CHARGEBCSS) AS 实收金额,");
                str.Append("SUM(CASE CHARGETYPEID WHEN 1 THEN CHARGEBCSS ELSE 0 END) AS 现金收费,SUM(CASE CHARGETYPEID WHEN 2 THEN CHARGEBCSS ELSE 0 END) AS POS机收费, ");
                str.Append("SUM(CASE CHARGETYPEID WHEN 3 THEN CHARGEBCSS ELSE 0 END) AS 转账汇款,SUM(CHARGEYSBCSZ) AS 余额增减 FROM ");
                str.Append("(SELECT CHARGEWORKERID,CHARGEWORKERNAME,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEBCSS,CHARGETYPEID FROM ");
                str.Append(" V_PRESTORERUNNINGACCOUNT_VALID WHERE 1=1 ");
                str.Append(strFilter);
                str.Append(" UNION ALL SELECT CHARGEWORKERID,CHARGEWORKERNAME,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEBCSS,CHARGETYPEID FROM ");
                str.Append(" V_WATERFEECHARGE_READMETERRECORD WHERE waterUserchargeType='1' ");
                str.Append(strFilter);
                str.Append(") AS AA ");
                str.Append(" GROUP BY CHARGEWORKERID,CHARGEWORKERNAME ORDER BY CHARGEWORKERID");
            }
            else if (strGroupType == "按用户")
            {
                str.Append("SELECT WATERUSERID AS 用户号,WATERUSERNAME AS 用户名,COUNT(*) AS 单据数量,SUM(CHARGEBCSS) AS 实收金额,");
                str.Append("SUM(CASE CHARGETYPEID WHEN 1 THEN CHARGEBCSS ELSE 0 END) AS 现金收费,SUM(CASE CHARGETYPEID WHEN 2 THEN CHARGEBCSS ELSE 0 END) AS POS机收费, ");
                str.Append("SUM(CASE CHARGETYPEID WHEN 3 THEN CHARGEBCSS ELSE 0 END) AS 转账汇款,SUM(CHARGEYSBCSZ) AS 余额增减  FROM ");
                str.Append("(SELECT WATERUSERID,WATERUSERNAME,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEBCSS,CHARGETYPEID FROM  ");
                str.Append(" V_PRESTORERUNNINGACCOUNT_VALID WHERE 1=1 ");
                str.Append(strFilter);
                str.Append(" UNION ALL SELECT CHARGEWORKERID,CHARGEWORKERNAME,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEBCSS,CHARGETYPEID FROM ");
                str.Append(" V_WATERFEECHARGE_READMETERRECORD WHERE waterUserchargeType='1' ");
                str.Append(strFilter);
                str.Append(") AS AA ");
                str.Append(" GROUP BY WATERUSERID,WATERUSERNAME ORDER BY WATERUSERID");
            }

            DataTable dt=DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
            return dt;
        }
        /// <summary>
        /// 按收费员统计预收
        /// </summary>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public DataTable GetPrestoreSum(string strFilter, string strGroupType)
        {
            StringBuilder str = new StringBuilder();
            if (strGroupType == "收费员")
            {
                str.Append("SELECT CHARGEWORKERID AS 收费员编号,CHARGEWORKERNAME AS 收费员,COUNT(*) AS 单据数量,SUM(CHARGEYSQQYE) AS 前期余额,SUM(CHARGEBCSS) AS 实收金额,");
                str.Append("SUM(CASE CHARGETYPEID WHEN 1 THEN CHARGEBCSS ELSE 0 END) AS 现金收费,SUM(CASE CHARGETYPEID WHEN 2 THEN CHARGEBCSS ELSE 0 END) AS POS机收费, ");
                str.Append("SUM(CHARGEYSJSYE) AS 结算余额,SUM(CHARGEYSBCSZ) AS 余额增减 FROM ");
                str.Append("(SELECT CHARGEWORKERID,CHARGEWORKERNAME,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEBCSS,CHARGETYPEID FROM ");
                str.Append(" V_PRESTORERUNNINGACCOUNT_VALID WHERE 1=1 ");
                str.Append(strFilter);
                str.Append(") AS AA ");
                str.Append(" GROUP BY CHARGEWORKERID,CHARGEWORKERNAME ORDER BY CHARGEWORKERID");
            }
            else if (strGroupType == "按用户")
            {
                str.Append("SELECT WATERUSERID AS 用户号,WATERUSERNAME AS 用户名,COUNT(*) AS 单据数量,SUM(CHARGEYSQQYE) AS 前期余额,SUM(CHARGEBCSS) AS 实收金额,");
                str.Append("SUM(CASE CHARGETYPEID WHEN 1 THEN CHARGEBCSS ELSE 0 END) AS 现金收费,SUM(CASE CHARGETYPEID WHEN 2 THEN CHARGEBCSS ELSE 0 END) AS POS机收费, ");
                str.Append("SUM(CHARGEYSJSYE) AS 结算余额,SUM(CHARGEYSBCSZ) AS 余额增减  FROM ");
                str.Append("(SELECT WATERUSERID,WATERUSERNAME,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEBCSS,CHARGETYPEID FROM  ");
                str.Append(" V_PRESTORERUNNINGACCOUNT_VALID WHERE 1=1 ");
                str.Append(strFilter);
                str.Append(") AS AA ");
                str.Append(" GROUP BY WATERUSERID,WATERUSERNAME ORDER BY WATERUSERID");
            }

            DataTable dt = DBUtility.DbHelperSQL.Query(str.ToString()).Tables[0];
            return dt;
        }

        public bool Insert(MODELPRESTORERUNNINGACCOUNT MODELPRESTORERUNNINGACCOUNT)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO PRESTORERUNNINGACCOUNT(PRESTORERUNNINGACCOUNTID,CHARGEID,WATERUSERID,WATERUSERNO,WATERUSERNAME,WATERUSERNAMECODE,WATERUSERPHONE," +
                "WATERUSERADDRESS,WATERUSERPEOPLECOUNT,AREANO,PIANNO,DUANNO,ORDERNUMBER,COMMUNITYID,COMMUNITYNAME,BUILDINGNO,UNITNO,METERREADERID,METERREADERNAME,"+
                "CHARGERID,CHARGERNAME,WATERUSERTYPEID,WATERUSERTYPENAME,WATERUSERHOUSETYPE,CREATETYPE,MEMO,waterMeterTypeId,waterMeterTypeValue,"+
                "WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME) ");

            str.Append("VALUES(@PRESTORERUNNINGACCOUNTID,@CHARGEID,@WATERUSERID,@WATERUSERNO,@WATERUSERNAME,@WATERUSERNAMECODE,@WATERUSERPHONE," +
                "@WATERUSERADDRESS,@WATERUSERPEOPLECOUNT,@AREANO,@PIANNO,@DUANNO,@ORDERNUMBER,@COMMUNITYID,@COMMUNITYNAME,@BUILDINGNO,@UNITNO,@METERREADERID," +
                "@METERREADERNAME,@CHARGERID,@CHARGERNAME,@WATERUSERTYPEID,@WATERUSERTYPENAME,@WATERUSERHOUSETYPE,@CREATETYPE,@MEMO,@waterMeterTypeId,"+
                "@waterMeterTypeValue,@WATERMETERTYPECLASSID,@WATERMETERTYPECLASSNAME) ");
            SqlParameter[] para =
           {
               new SqlParameter("@PRESTORERUNNINGACCOUNTID",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGEID",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERID",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERNO",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERNAMECODE",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERPHONE",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERADDRESS",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERPEOPLECOUNT",SqlDbType.Int),
               new SqlParameter("@AREANO",SqlDbType.VarChar,50),
               new SqlParameter("@PIANNO",SqlDbType.VarChar,50),
               new SqlParameter("@DUANNO",SqlDbType.VarChar,50),
               new SqlParameter("@ORDERNUMBER",SqlDbType.Int),
               new SqlParameter("@COMMUNITYID",SqlDbType.VarChar,50),
               new SqlParameter("@COMMUNITYNAME",SqlDbType.VarChar,50),
               new SqlParameter("@BUILDINGNO",SqlDbType.VarChar,50),
               new SqlParameter("@UNITNO",SqlDbType.VarChar,50),
               new SqlParameter("@METERREADERID",SqlDbType.VarChar,50),
               new SqlParameter("@METERREADERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGERID",SqlDbType.VarChar,50),
               new SqlParameter("@CHARGERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERTYPEID",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERTYPENAME",SqlDbType.VarChar,50),
               new SqlParameter("@WATERUSERHOUSETYPE",SqlDbType.VarChar,50),
               new SqlParameter("@CREATETYPE",SqlDbType.VarChar,50),
               new SqlParameter("@MEMO",SqlDbType.VarChar,200),
               new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,50),
               new SqlParameter("@waterMeterTypeValue",SqlDbType.VarChar,50),
               new SqlParameter("@WATERMETERTYPECLASSID",SqlDbType.VarChar,50),
               new SqlParameter("@WATERMETERTYPECLASSNAME",SqlDbType.VarChar,50)
           };
            para[0].Value = MODELPRESTORERUNNINGACCOUNT.PRESTORERUNNINGACCOUNTID;
            para[1].Value = MODELPRESTORERUNNINGACCOUNT.CHARGEID;
            para[2].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERID;
            para[3].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERNO;
            para[4].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERNAME;
            para[5].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERNAMECODE;
            para[6].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERPHONE;
            para[7].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERADDRESS;
            para[8].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERPEOPLECOUNT;
            para[9].Value = MODELPRESTORERUNNINGACCOUNT.AREANO;
            para[10].Value = MODELPRESTORERUNNINGACCOUNT.PIANNO;
            para[11].Value = MODELPRESTORERUNNINGACCOUNT.DUANNO;
            para[12].Value = MODELPRESTORERUNNINGACCOUNT.ORDERNUMBER;
            para[13].Value = MODELPRESTORERUNNINGACCOUNT.COMMUNITYID;
            para[14].Value = MODELPRESTORERUNNINGACCOUNT.COMMUNITYNAME;
            para[15].Value = MODELPRESTORERUNNINGACCOUNT.BUILDINGNO;
            para[16].Value = MODELPRESTORERUNNINGACCOUNT.UNITNO;
            para[17].Value = MODELPRESTORERUNNINGACCOUNT.METERREADERID;
            para[18].Value = MODELPRESTORERUNNINGACCOUNT.METERREADERNAME;
            para[19].Value = MODELPRESTORERUNNINGACCOUNT.CHARGERID;
            para[20].Value = MODELPRESTORERUNNINGACCOUNT.CHARGERNAME;
            para[21].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPEID;
            para[22].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPENAME;
            para[23].Value = MODELPRESTORERUNNINGACCOUNT.WATERUSERHOUSETYPE;
            para[24].Value = MODELPRESTORERUNNINGACCOUNT.CREATETYPE;
            para[25].Value = MODELPRESTORERUNNINGACCOUNT.MEMO;
            para[26].Value = MODELPRESTORERUNNINGACCOUNT.waterMeterTypeId;
            para[27].Value = MODELPRESTORERUNNINGACCOUNT.waterMeterTypeValue;
            para[28].Value = MODELPRESTORERUNNINGACCOUNT.WATERMETERTYPECLASSID;
            para[29].Value = MODELPRESTORERUNNINGACCOUNT.WATERMETERTYPECLASSNAME;

            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
    }
}
