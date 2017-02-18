using System;
using System.Collections.Generic;
using System.Text;
using DBinterface.IDAL;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using Common.DotNetData;

namespace DBinterface.DAL
{
    public class WaterBusiness_DAL : WaterBusiness_IDAL
    {
        public DataTable GetWaterUserList(Control.ControlCollection Controls)
        {
          //  string sqlstr = "SELECT top 200 waterUserId,waterUserStateS,waterUserNO,waterUserName,waterPhone,waterUserAddress,prestore,TOTALFEE,([prestore]-[TOTALFEE]) AS Balance FROM V_WATERUSERAREARAGE ";
            string sqlstr = "SELECT top 200 waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,prestore,TOTALFEE,([prestore]-[TOTALFEE]) AS Balance FROM V_WATERUSERAREARAGE ";
            
            string sqlwhere = "";
            if (new SqlServerHelper().GetSqlWhereByControl(Controls, ref sqlwhere))
            {
                sqlstr += " WHERE " + sqlwhere;
               return new SqlServerHelper().GetDateTableBySql(sqlstr);
            }
            else
            {
                return null;
            }
        }
        //2017年2月18日 RONG
        public DataTable GetWaterMeterByUserID(string waterUserId)
        {
          // string sqlstr = "SELECT waterMeterNo,waterMeterStartNumber,waterMeterStateS,waterMeterSizeValue,waterMeterTypeValue,waterMeterPositionName,waterMeterSerialNumber,WATERFIXVALUE,MEMO FROM V_WATERMETER WHERE waterUserId='" + waterUserId + "'";
            string sqlstr =string.Format(@"SELECT waterMeterNo,waterMeterStartNumber,waterMeterStateS,waterMeterSizeValue,waterMeterTypeValue,
waterMeterPositionName,waterMeterSerialNumber,WATERFIXVALUE,MEMO,
(select top 1 waterMeterLastNumber from readMeterRecord 
where waterMeterId=V.waterMeterId
order by readMeterRecordDate desc) AS waterMeterLastNumber,
(select top 1 waterMeterEndNumber from readMeterRecord 
where waterMeterId=V.waterMeterId
order by readMeterRecordDate desc) AS waterMeterEndNumber,
(select top 1 readMeterRecordYearAndMonth from readMeterRecord 
where waterMeterId=V.waterMeterId
order by readMeterRecordDate desc) AS readMeterRecordYearAndMonth
FROM V_WATERMETER V WHERE waterUserId='{0}'", waterUserId);
          
            
            return new SqlServerHelper().GetDateTableBySql(sqlstr);

        }

        public Hashtable GetWaterUserInfos(string waterUserId)
        {
           return new SqlServerHelper().GetHashtableById("V_WATERUSERAREARAGE", "waterUserId", waterUserId);
        }

        public bool IsDisabledUser(string TableName, string waterUserId)
        {
            string sqlstr =string.Format(@"DECLARE @IsExit int =0
SELECT @IsExit=COUNT(1) FROM V_WATERMETER where waterMeterState IN (2,5,6) AND waterUserId=@waterUserId
if(@IsExit=0)
begin
SELECT @IsExit=COUNT(1) FROM {0} WHERE [State] IN (0,1,2) AND WaterUserNO=@waterUserId
end
SELECT @IsExit", TableName);
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@waterUserId", waterUserId) });
            return int.Parse(dt.Rows[0][0].ToString()) > 0 ? true : false;
        }

        public bool IsDisabledUser(string waterUserId)
        {
//            string sqlstr = @"DECLARE @IsExit int =0
//SELECT @IsExit=COUNT(1) FROM V_WATERMETER where waterMeterState IN (2,5,6) AND waterUserId=@waterUserId
//if(@IsExit=0)
//begin
//SELECT @IsExit=COUNT(1) FROM Meter_Disuse WHERE [State] IN (0,1,2) AND WaterUserNO=@waterUserId
//end
//SELECT @IsExit";
//            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@waterUserId", waterUserId) });
//            return int.Parse(dt.Rows[0][0].ToString()) > 0 ? true : false;

            return IsDisabledUser("Meter_Disuse", waterUserId);
        }

        public float GetUserWaterPrice(string waterUserId)
        {
            float _Price = 0f;
            string sqlstr = "SELECT TOP 1 trapezoidPrice FROM V_WATERMETER WHERE waterUserId=@waterUserId";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@waterUserId", waterUserId) });
            if (DataTableHelper.IsExistRows(dt))
            {
                string _Step = dt.Rows[0][0].ToString();
                _Step = _Step.Split('|')[0].Split(':')[1];
                if (float.TryParse(_Step, out _Price))
                {

                }
            }

            return _Price;
        }

        public DataTable GetWaterUserFee(string waterUserId)
        {
            string sqlstr = "SELECT prestore-TOTALFEE AS FEE,TOTALNUMBER  FROM V_WATERUSERAREARAGE WHERE waterUserId=@waterUserId";
            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@waterUserId", waterUserId) });
        }

    }
}
