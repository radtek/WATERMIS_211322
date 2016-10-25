using System;
using System.Collections.Generic;
using System.Text;
using DBinterface.IDAL;
using System.Data;
using System.Data.SqlClient;

namespace DBinterface.DAL
{
    public class Finance_Dal : Finance_IDAL
    {
        public DataTable GetTableList()
        {
            return new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT Meter_Table.TableID,Meter_Table.Table_Name_CH FROM View_WorkBase,Meter_Table WHERE View_WorkBase.TableID=Meter_Table.TableID AND View_WorkBase.[State] IN (1,2,5)");
        }

        public DataTable GetChargeMonth()
        {
            return new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT CreateMonth,CreateMonth AS CreateMonthVALUE FROM View_TaskFee");
        }

        public DataTable GetChargeDay()
        {
            return new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT CreateDay,CreateDay AS CreateDayVALUE FROM View_TaskFee");
        }

        public string ChargeSqlList()
        {
            return @"SELECT MT.Table_Name_CH,VW.SD,VW.waterUserId,VW.waterUserName,VW.ApplyUser,VT.FEE,VW.waterPhone,VT.CreateDate,VT.PointTime,VW.TableID,VT.TaskID,VT.STATES,VW.ID,VT.IsFinal
FROM View_TaskFee VT  LEFT JOIN View_WorkBase VW ON VT.TaskID=VW.TASKID,Meter_Table MT WHERE VW.TableID=MT.TableID AND VW.[State] IN (1,2,5)";
        }

    }
}
