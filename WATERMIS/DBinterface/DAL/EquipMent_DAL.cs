
using DBinterface.IDAL;
using System.Data;
using DBUtility;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
namespace DBinterface.DAL
{
    public class EquipMent_DAL : EquipMent_IDAL
    {
        #region 手机设备管理
        public DataTable GetEquipment()
        {
            string strsql = "SELECT M.MEID,M.MECode,(SELECT USERNAME FROM V_LOGIN VL WHERE VL.LOGINNAME=M.LoginID) AS userName FROM MeterEquipment M";
            DataSet ds = DbHelperSQL.Query(strsql);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public int UpdateEquipment(int meid, string LoginID)
        {
            string strsql = "UPDATE MeterEquipment SET LoginID=@LOGINID WHERE MEID=@MEID";

            SqlParameter[] parm = new SqlParameter[]{
             new SqlParameter("LOGINID",LoginID),
             new SqlParameter("MEID",meid)
             };

            return DbHelperSQL.ExecuteSql(strsql, parm);
        }

        public int DeleteEquipment(int meid)
        {
            string strsql = "DELETE MeterEquipment WHERE MEID=@MEID";

            SqlParameter[] parm = new SqlParameter[]{
             new SqlParameter("MEID",meid)
             };

            return DbHelperSQL.ExecuteSql(strsql, parm);
        }


        //SELECT LOGINNAME,USERNAME FROM V_LOGIN WHERE userstate=1
        public DataTable GetLoginUser()
        {
            string strsql = "SELECT LOGINNAME,USERNAME FROM V_LOGIN WHERE userstate=1 AND isMeterReader='1'";
            DataSet ds = DbHelperSQL.Query(strsql);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["LOGINNAME"] = "0";
                dr["USERNAME"] = "所有";
                dt.Rows.InsertAt(dr, 0);
                return dt;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetLoginUserInID()
        {
            string strsql = "SELECT LOGINID,USERNAME FROM V_LOGIN WHERE userstate=1 AND isMeterReader='1'";
            DataSet ds = DbHelperSQL.Query(strsql);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["LOGINID"] = "0";
                dr["USERNAME"] = "所有";
                dt.Rows.InsertAt(dr, 0);
                return dt;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 故障报修

        public DataTable GetMeterRepairYear()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("SELECT Year(CreateDateTime) AS MRYear FROM MeterRepair group by Year(CreateDateTime) order by Year(CreateDateTime) Desc");

            DataSet ds = DbHelperSQL.Query(sbsql.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public DataTable GetMeterRepair(Hashtable ht)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("SELECT MR.MRID AS 序号,(SELECT TOP 1 waterUserName FROM WATERUSER WHERE waterUserId=MR.waterUserId) AS 用水户名,MR.Describe AS 故障描述,MR.Images AS 故障图片,MR.LoginId AS 抄表员,MR.CreateDateTime AS 拍摄时间 FROM MeterRepair MR ");

            if (!ht["LOGINID"].Equals("所有"))
            {
                sbsql.AppendFormat("WHERE  LoginId='{0}'", ht["LOGINID"]);
            }
            else
            {
                sbsql.Append("WHERE  1=1");
            }

            if (!ht["MONTH"].Equals("所有"))
            {
                sbsql.AppendFormat(" AND MONTH(CreateDateTime)={0}", ht["MONTH"]);
            }

            if (!ht["YEAR"].Equals(""))
            {
                sbsql.AppendFormat(" AND YEAR(CreateDateTime)={0}", ht["YEAR"]);
            }


            //if (htwhere != null && htwhere.Count > 0)
            //{
            //    sbsql.Append("WHERE ");
            //    foreach (DictionaryEntry de in htwhere) //ht为一个Hashtable实例
            //    {
            //        sbsql.AppendFormat("{0}='{1}'", de.Key, de.Value);
            //        sbsql.Append(" AND ");
            //    }
            //}

            //string sql = sbsql.ToString().Trim();
            //sql = sql.Substring(0, sql.Length - 1);

            DataSet ds = DbHelperSQL.Query(sbsql.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public int DeleteMeterRepair(int MRID)
        {
            string strsql = "DELETE MeterRepair WHERE MRID=@MRID";

            SqlParameter[] parm = new SqlParameter[]{
             new SqlParameter("MRID",MRID)
             };

            return DbHelperSQL.ExecuteSql(strsql, parm);
        }
        #endregion

        #region 用户建议
        public DataTable GetUserSuggest(Hashtable ht)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("SELECT US.USID AS 序号,waterUserId AS 用户号,(SELECT waterUserName FROM waterUser WHERE waterUserId=US.waterUserId) AS 用水用户,US.USContent AS 客户建议,(SELECT userName FROM base_login WHERE LoginId=US.LoginId) AS 抄表员,US.CreateDateTime AS 提交时间 FROM UserSuggest US ");

            if (!ht["LOGINID"].Equals("0"))
            {
                sbsql.AppendFormat("WHERE  LoginId='{0}'", ht["LOGINID"]);
            }
            else
            {
                sbsql.Append("WHERE  1=1");
            }
            sbsql.AppendFormat(" AND MONTH(CreateDateTime)={0}", ht["MONTH"]);
            sbsql.AppendFormat(" AND YEAR(CreateDateTime)={0}", ht["YEAR"]);

            DataSet ds = DbHelperSQL.Query(sbsql.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 地图显示
        public DataTable GetWaterUserGPS()
        {
            string strsql = "SELECT Latitude,Longitude  FROM waterMeter  where Latitude <>''";
            DataSet ds = DbHelperSQL.Query(strsql);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 抄表轨迹
        public DataTable GetMeterTrack(string LoginID, string datetime)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("SELECT Latitude,Longitude  FROM readMeterRecord  where Latitude <>'' ");

            if (LoginID == "" || datetime == "")
            {
                return null;
            }
            else
            {
                sbsql.AppendFormat(" AND loginId='{0}' ",LoginID);
                sbsql.AppendFormat(" AND readMeterRecordDate BETWEEN '{0} 00:00:00' AND '{0} 23:59:00'", datetime);

                DataSet ds = DbHelperSQL.Query(sbsql.ToString());

                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
    }
}
