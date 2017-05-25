using System;
using DBinterface.IDAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Common.DotNetData;
using DBUtility;
using Common.WinDevices;
using Microsoft.VisualBasic;
using DBinterface.Model;

namespace DBinterface.DAL
{
    public class PersonalWork_DAL : PersonalWork_IDAL
    {
        public DateTime GetDatetimeNow()
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(DBUtility.DbHelperSQL.ExecuteScalar("SELECT TOP 1 GETDATE() FROM sysusers").ToString());
            return dt;
        }

        public DataTable GetDataTalbeWorkResolve()
        {
            string loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();

            //            string sqlstr = @"SELECT Row_Number() OVER (ORDER BY MW.AcceptDate desc) AS ROWNUM,MW.TaskName,MW.TaskCode,MWR.DoName,MW.PointTime,MWR.TimeLimit,MW.TaskID,MWR.ResolveID,MWR.PointSort,MWR.PointName,MW.SD
            //  FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort
            //  AND ','+loginId+',' like '%,'+@AcceptUserID+',%' AND MW.[State]=1  AND MWR.IsPass IS NULL ";
            string sqlstr = @"SELECT Row_Number() OVER (ORDER BY MW.AcceptDate desc) AS ROWNUM,MW.TaskName,MW.TaskCode,MWR.DoName,MW.PointTime,MWR.TimeLimit,MW.TaskID,MWR.ResolveID,MWR.PointSort,MWR.PointName,MW.SD
  FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort
  AND ','+loginId+',' like '%,'+@AcceptUserID+',%' AND MW.[State]=1 ";

            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@AcceptUserID", loginid) });
        }

        public DataTable GetDataTalbeWorkOver()
        {
            string loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();

            string sqlstr = @"SELECT Row_Number() OVER (ORDER BY MW.AcceptDate desc) AS ROWNUM,CASE MWR.IsPass WHEN '1' THEN '√' WHEN '0' THEN '×' ELSE '-' END AS IsPass,(SELECT VALUE FROM Meter_WorkTaskState WHERE ID=MW.STATE) AS STATE,MWR.UserOpinion,MW.TaskName,MW.TaskCode,MWR.DoName,MW.PointTime,MWR.TimeLimit,MW.TaskID,MWR.ResolveID,MWR.PointSort,MWR.PointName,MW.SD
  FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort>MWR.PointSort
  AND ','+loginId+',' like '%,'+@AcceptUserID+',%' AND MWR.IsPass IS NOT NULL";

            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@AcceptUserID", loginid) });
        }

        public DataTable GetDataTalbeWorkScrap()
        {
            string loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();

            string sqlstr = @"SELECT Row_Number() OVER (ORDER BY MW.AcceptDate desc) AS ROWNUM,MW.TaskName,MW.TaskCode,MWR.DoName,MW.PointTime,MW.TaskID,MWR.ResolveID,MWR.PointName,MW.SD
  FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MWR.MakeVoided=1  AND ','+loginId+',' like '%,'+@AcceptUserID+',%' AND MW.[State]=4";

            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@AcceptUserID", loginid) });
        }

        public DataTable GetDataTableApproveList(string TaskID)
        {
            string sqlstr = "SELECT ROW_NUMBER() OVER(ORDER BY MWR.POINTSORT) AS ROWNUM,MWR.PointSort,MWR.PointName,MWR.DoName,MWR.userName,MWR.AcceptDate,MWR.UserOpinion,CASE MWR.IsPass WHEN '1' THEN '√' WHEN '0' THEN '×' ELSE '-' END AS IsPass,CASE MWR.MAKESKIP WHEN '1' THEN '√' WHEN '0' THEN '×' ELSE '-' END AS GoPointID FROM Meter_WorkTask MW,Meter_WorkResolve MWR  WHERE MW.TaskID=MWR.TaskID AND MW.TaskID=@TaskID ORDER BY MWR.PointSort,MW.AcceptDate";

            SqlParameter[] cmdParms = new SqlParameter[]{
            new SqlParameter("@TaskID",TaskID)
            };

            return new SqlServerHelper().GetDateTableBySql(sqlstr, cmdParms);
        }

        public Hashtable GetMeter_Install_SingleInfos(string TaskID)
        {
            return new SqlServerHelper().GetHashtableById("Meter_Install_Single", "TaskID", TaskID);
        }

        /// <summary>
        /// 获取违章用户报装基础信息
        /// </summary>
        /// <param name="TaskID"></param>
        /// <returns></returns>
        public Hashtable GetMeter_Install_PeccantInfos(string TaskID)
        {
            return new SqlServerHelper().GetHashtableById("Meter_Install_Peccant", "TaskID", TaskID);
        }

        public bool GetAssemblyName(string ResolveID, ref string FrmAssemblyName, ref string FormName)
        {
            bool result = false;
            string sqlstr = string.Format("SELECT TOP 1 FrmAssemblyName,FormName FROM Meter_WorkFlow MWF,Meter_WorkResolve MWR WHERE MWF.WorkFlowID=MWR.WorkFlowID AND MWR.ResolveID='{0}'", ResolveID);
            try
            {
                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                if (DataTableHelper.IsExistRows(dt))
                {
                    FrmAssemblyName = dt.Rows[0][0].ToString();
                    FormName = dt.Rows[0][1].ToString();
                    if (!string.IsNullOrEmpty(FrmAssemblyName) && !string.IsNullOrEmpty(FormName))
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool GetAssemblyNameDetail(string ResolveID, ref string FrmAssemblyName, ref string FormName)
        {
            bool result = false;
            string sqlstr = string.Format(" SELECT TOP 1 FrmAssemblyName,FormName FROM Meter_WorkDo MWD,Meter_WorkResolve MWR WHERE MWD.DoID=MWR.DoID AND MWR.ResolveID='{0}'", ResolveID);
            try
            {
                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                if (DataTableHelper.IsExistRows(dt))
                {
                    FrmAssemblyName = dt.Rows[0][0].ToString();
                    FormName = dt.Rows[0][1].ToString();
                    if (!string.IsNullOrEmpty(FrmAssemblyName) && !string.IsNullOrEmpty(FormName))
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public DataTable GetDataTableLastApproveFee(string TaskID, string PointSort)
        {
            string sqlstr = @"DECLARE @PrePointSort INT=0
SELECT TOP 1 @PrePointSort=PointSort FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<@PointSort ORDER BY PointSort DESC
SELECT ROW_NUMBER() OVER (ORDER BY FeeID) AS ROWNUM, FeeID,FeeItem,DefaultValue,Fee,AcceptUser,
(SELECT PointName FROM Meter_WorkResolve WHERE ResolveID=MWR.ResolveID ) AS PointName 
FROM Meter_WorkResolveFee MWR WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@PrePointSort) 
ORDER BY FeeItem, PointName";
            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort) });
        }

        public int UpdateApprove_defalut(string tableName, string ResolveID, bool IsPass, string UserOpinion, string ip, string ComputerName, string PointSort, string TaskID, string Matter)
        {
            string sqlstr = string.Format(@"DECLARE @ISOVER INT=1
DECLARE @NEXTSORT INT=0
SELECT  TOP 1 @NEXTSORT=PointSort FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort>@PointSort ORDER BY PointSort
SET XACT_ABORT ON
BEGIN TRAN
UPDATE Meter_WorkResolve SET IsPass=@IsPass,UserOpinion=@UserOpinion,AcceptUserID=@AcceptUserID,AcceptUser=@AcceptUser,AcceptDate='{1}',IP=@IP,ComputerName=@ComputerName WHERE ResolveID=@ResolveID
INSERT INTO ApproveLog (TaskID,PointSort,loginId,userName,State,UserOpinion,IsPass,IsGoBack,IP,ComputerName,Matter) VALUES (@TaskID,@PointSort,@AcceptUserID,@AcceptUser,1,@UserOpinion,1,0,@IP,@ComputerName,@Matter)

SELECT @ISOVER=COUNT(1) FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@PointSort AND (IsPass IS NULL OR IsPass<>1)
if(@ISOVER=0)
begin
if(@NEXTSORT=0)
BEGIN
UPDATE Meter_WorkTask SET [State]=5, PointSort=PointSort+1,PointTime='{1}' WHERE TaskID=@TaskID AND PointSort=@PointSort
UPDATE {0} SET [State]=5 WHERE TaskID=@TaskID
END
ELSE
BEGIN
UPDATE Meter_WorkTask SET PointSort=@NEXTSORT,PointTime='{1}' WHERE TaskID=@TaskID AND PointSort=@PointSort

END
end
COMMIT TRAN", tableName, GetDatetimeNow());

            SqlParameter[] cmdParms = new SqlParameter[]{
            new SqlParameter("@ResolveID",ResolveID),
            new SqlParameter("@IsPass",IsPass?1:0),
            new SqlParameter("@UserOpinion",UserOpinion),
            new SqlParameter("@AcceptUserID",AppDomain.CurrentDomain.GetData("LOGINID").ToString()),
            new SqlParameter("@AcceptUser",AppDomain.CurrentDomain.GetData("USERNAME").ToString()),
            new SqlParameter("@IP",ip),
            new SqlParameter("@ComputerName",ComputerName),
            new SqlParameter("@PointSort",PointSort),
            new SqlParameter("@TaskID",TaskID),
            new SqlParameter("@Matter",Matter)
            };

            return DbHelperSQL.ExecuteSql(sqlstr, cmdParms);
        }

        public int UpdateApprove_defalut(string tableName, string ResolveID, bool IsPass, string UserOpinion, string PointSort, string TaskID, string Matter)
        {
            string ComputerName = AppDomain.CurrentDomain.GetData("COMPUTERNAME").ToString();
            string ip = AppDomain.CurrentDomain.GetData("IP").ToString();

            return UpdateApprove_defalut(tableName, ResolveID, IsPass, UserOpinion, ip, ComputerName, PointSort, TaskID, Matter);

        }

        public int UpdateApprove_Single_defalut(string ResolveID, bool IsPass, string UserOpinion, string ip, string ComputerName, string PointSort, string TaskID, string Matter)
        {
            return UpdateApprove_defalut("Meter_Install_Single", ResolveID, IsPass, UserOpinion, ip, ComputerName, PointSort, TaskID, Matter);
            //            string sqlstr = @"DECLARE @ISOVER INT=1
            //DECLARE @NEXTSORT INT=0
            //SELECT  TOP 1 @NEXTSORT=PointSort FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort>@PointSort ORDER BY PointSort
            //SET XACT_ABORT ON
            //BEGIN TRAN
            //UPDATE Meter_WorkResolve SET IsPass=@IsPass,UserOpinion=@UserOpinion,AcceptUserID=@AcceptUserID,AcceptUser=@AcceptUser,AcceptDate=GETDATE(),IP=@IP,ComputerName=@ComputerName WHERE ResolveID=@ResolveID
            //SELECT @ISOVER=COUNT(1) FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@PointSort AND (IsPass IS NULL OR IsPass<>1)
            //if(@ISOVER=0)
            //begin
            //if(@NEXTSORT=0)
            //BEGIN
            //UPDATE Meter_WorkTask SET [State]=5, PointSort=PointSort+1,PointTime=GETDATE() WHERE TaskID=@TaskID AND PointSort=@PointSort
            //UPDATE Meter_Install_Single SET [State]=5 WHERE TaskID=@TaskID
            //END
            //ELSE
            //BEGIN
            //UPDATE Meter_WorkTask SET PointSort=@NEXTSORT,PointTime=GETDATE() WHERE TaskID=@TaskID AND PointSort=@PointSort
            //END
            //end
            //COMMIT TRAN";

            //            SqlParameter[] cmdParms = new SqlParameter[]{
            //            new SqlParameter("@ResolveID",ResolveID),
            //            new SqlParameter("@IsPass",IsPass?1:0),
            //            new SqlParameter("@UserOpinion",UserOpinion),
            //            new SqlParameter("@AcceptUserID",AppDomain.CurrentDomain.GetData("LOGINID").ToString()),
            //            new SqlParameter("@AcceptUser",AppDomain.CurrentDomain.GetData("USERNAME").ToString()),
            //            new SqlParameter("@IP",ip),
            //            new SqlParameter("@ComputerName",ComputerName),
            //            new SqlParameter("@PointSort",PointSort),
            //            new SqlParameter("@TaskID",TaskID)
            //            };

            //            return DbHelperSQL.ExecuteSql(sqlstr, cmdParms);
        }
        /// <summary>
        /// 违章报装提交审批
        /// </summary>
        /// <param name="ResolveID"></param>
        /// <param name="IsPass"></param>
        /// <param name="UserOpinion"></param>
        /// <param name="ip"></param>
        /// <param name="ComputerName"></param>
        /// <param name="PointSort"></param>
        /// <param name="TaskID"></param>
        /// <returns></returns>
        public int UpdateApprove_Peccant_defalut(string ResolveID, bool IsPass, string UserOpinion, string ip, string ComputerName, string PointSort, string TaskID, string Matter)
        {
            return UpdateApprove_defalut("Meter_Install_Peccant", ResolveID, IsPass, UserOpinion, ip, ComputerName, PointSort, TaskID, Matter);
        }

        public int UpdateApprove_Voided_ByTableName(string tableName, string ResolveID, string UserOpinion, string ip, string ComputerName, string TaskID)
        {
            string sqlstr = string.Format(@" SET XACT_ABORT ON
BEGIN TRAN
UPDATE Meter_WorkTask SET State=4 WHERE TaskID=@TaskID
UPDATE {0} SET State=4 WHERE TaskID=@TaskID
UPDATE Meter_WorkResolve SET MakeVoided=1,IsPass=0,UserOpinion=@UserOpinion,AcceptUserID=@AcceptUserID,AcceptUser=@AcceptUser,IP=@IP,ComputerName=@ComputerName WHERE ResolveID=@ResolveID
INSERT INTO ApproveLog (TaskID,ResolveID,loginId,userName,State,UserOpinion,IsPass,IsGoBack,IP,ComputerName,Matter) VALUES 
(@TaskID,@ResolveID,@AcceptUserID,@AcceptUser,4,@UserOpinion,0,0,@IP,@ComputerName,@Matter)
COMMIT TRAN", tableName);

            SqlParameter[] cmdParms = new SqlParameter[]{
            new SqlParameter("@ResolveID",ResolveID),
            new SqlParameter("@UserOpinion",UserOpinion),
            new SqlParameter("@AcceptUserID",AppDomain.CurrentDomain.GetData("LOGINID").ToString()),
            new SqlParameter("@AcceptUser",AppDomain.CurrentDomain.GetData("USERNAME").ToString()),
            new SqlParameter("@IP",ip),
            new SqlParameter("@ComputerName",ComputerName),
            new SqlParameter("@TaskID",TaskID),
            new SqlParameter("@Matter",UserOpinion)
            };

            return DbHelperSQL.ExecuteSql(sqlstr, cmdParms);
        }

        public int UpdateApprove_Voided_ByTableName(string tableName, string ResolveID, string UserOpinion, string TaskID)
        {
            string ComputerName = AppDomain.CurrentDomain.GetData("COMPUTERNAME").ToString();
            string ip = AppDomain.CurrentDomain.GetData("IP").ToString();
            return UpdateApprove_Voided_ByTableName(tableName, ResolveID, UserOpinion, ip, ComputerName, TaskID);
        }

        public int UpdateApprove_Voided(string ResolveID, string UserOpinion, string ip, string ComputerName, string TaskID)
        {
            return UpdateApprove_Voided_ByTableName("Meter_Install_Single", ResolveID, UserOpinion, ip, ComputerName, TaskID);

            //            string sqlstr = @" SET XACT_ABORT ON
            //BEGIN TRAN
            //UPDATE Meter_WorkTask SET State=4 WHERE TaskID=@TaskID
            //UPDATE Meter_Install_Single SET State=4 WHERE TaskID=@TaskID
            //UPDATE Meter_WorkResolve SET MakeVoided=1,IsPass=0,UserOpinion=@UserOpinion,AcceptUserID=@AcceptUserID,AcceptUser=@AcceptUser,IP=@IP,ComputerName=@ComputerName WHERE ResolveID=@ResolveID
            //COMMIT TRAN";

            //            SqlParameter[] cmdParms = new SqlParameter[]{
            //            new SqlParameter("@ResolveID",ResolveID),
            //            new SqlParameter("@UserOpinion",UserOpinion),
            //            new SqlParameter("@AcceptUserID",AppDomain.CurrentDomain.GetData("LOGINID").ToString()),
            //            new SqlParameter("@AcceptUser",AppDomain.CurrentDomain.GetData("USERNAME").ToString()),
            //            new SqlParameter("@IP",ip),
            //            new SqlParameter("@ComputerName",ComputerName),
            //            new SqlParameter("@TaskID",TaskID)
            //            };

            //            return DbHelperSQL.ExecuteSql(sqlstr, cmdParms);
        }

        /// <summary>
        /// 违章报装作废函数
        /// </summary>
        /// <param name="ResolveID"></param>
        /// <param name="UserOpinion"></param>
        /// <param name="ip"></param>
        /// <param name="ComputerName"></param>
        /// <param name="TaskID"></param>
        /// <returns></returns>
        public int UpdateApprove_Peccant_Voided(string ResolveID, string UserOpinion, string ip, string ComputerName, string TaskID)
        {
            return UpdateApprove_Voided_ByTableName("Meter_Install_Peccant", ResolveID, UserOpinion, ip, ComputerName, TaskID);
        }

        public DataTable GetFeeItems(string ResolveID)
        {
            string sqlstr = "SELECT FeeID,FeeItem,Fee,DefaultValue,IsFinal,Quantity,Price  FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID ORDER BY Sort";

            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@ResolveID", ResolveID) });
        }

        public bool IsHaveLastFeeItems(string TaskID, string PointSort)
        {
            string strsql = "SELECT COUNT(1) FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<@PointSort";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort) });

            int Count = int.Parse(dt.Rows[0][0].ToString());
            return Count > 0 ? true : false;
        }
        public DataTable GetLastFeeItemsByDep(string ResolveID, int FeeID)
        {
            //string FeeValue = string.Empty;
            string strsql = @"DECLARE @TaskID NVARCHAR(50)
DECLARE @PointSort INT
DECLARE @DepartementID NVARCHAR(50)
SELECT @TaskID=TaskID,@PointSort=PointSort,@DepartementID=DepartementID FROM Meter_WorkResolve MW WHERE ResolveID=@ResolveID
SELECT FEE,Price,Quantity FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.DepartementID=@DepartementID AND MWR.TaskID=@TaskID AND PointSort<@PointSort AND MWF.FeeID=@FeeID  ORDER BY PointSort DESC";
            return new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@ResolveID", ResolveID), new SqlParameter("@FeeID", FeeID) });
            //if (DataTableHelper.IsExistRows(dt))
            //{
            //    FeeValue = dt.Rows[0][0].ToString();
            //}
            // return FeeValue;
        }


        public DataTable GetAllChargePoint(string TaskID)
        {
            string sqlstr = "SELECT DISTINCT PointSort,PointName FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND TaskID=@TaskID ORDER BY PointSort";
            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
        }

        public DataTable GetChargePointItem(string TaskID, int PointSort, string DepartementID)
        {
            string sqlstr = @"IF(@DepartementID='0')
BEGIN
SELECT ROW_NUMBER() OVER (ORDER BY FeeID) AS ROWNUM,FeeItem,Fee
FROM Meter_WorkResolveFee MWR WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@PointSort) 
ORDER BY ROWNUM
END
ELSE
BEGIN
SELECT ROW_NUMBER() OVER (ORDER BY FeeID) AS ROWNUM, FeeItem,Fee
FROM Meter_WorkResolveFee MWR WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@PointSort AND DepartementID=@DepartementID) 
ORDER BY ROWNUM
END";
            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort), new SqlParameter("@DepartementID", DepartementID) });
        }

        public DataTable GetLastFeeItems(string TaskID, string PointSort)
        {
            string strsql = @"DECLARE @LastPoingSort INT=0
SELECT TOP 1 @LastPoingSort=PointSort FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<@PointSort ORDER BY PointSort DESC
SELECT DepartementID,FeeID,FeeItem,Fee,IsFinal,PointSort,State FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort=@LastPoingSort";

            return new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort) });
        }

        public Decimal GetLastFeeTotal(string TaskID, string PointSort)
        {
            decimal total = 0m;
            string strsql = @"DECLARE @LastPoingSort INT=0
SELECT TOP 1 @LastPoingSort=PointSort FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<@PointSort ORDER BY PointSort DESC
SELECT SUM(CONVERT(decimal,Fee)) FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort=@LastPoingSort";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort) });
            if (DataTableHelper.IsExistRows(dt))
            {
                total = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }

            return total;
        }

        public decimal GetTotalAbate(string TaskID, string PointSort)
        {
            string strsql = "SELECT SUM(Abate) AS Abate FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort<=@PointSort";
            decimal Abates = 0m;
            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort) });

            if (DataTableHelper.IsExistRows(dt))
            {
                string Abate = dt.Rows[0][0].ToString();
                if (decimal.TryParse(Abate, out Abates))
                {

                }
            }

            return Abates;
        }

        public decimal GetUserPrestore(string TableName, string TaskID)
        {
            string strsql = string.Format("SELECT prestore FROM {0} WHERE TaskID=@TaskID", TableName);
            decimal Abates = 0m;
            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });

            if (DataTableHelper.IsExistRows(dt))
            {
                string Abate = dt.Rows[0][0].ToString();
                if (decimal.TryParse(Abate, out Abates))
                {

                }
            }

            return Abates;
        }

        public string GetNewChargeID(string loginid)
        {
            int index = 1;
            string chargeID = string.Format("{0}01{1}SF{2}", DateTime.Now.ToString("yyyyMMdd"), loginid, String.Format("{0:000000}", index));
            string strSql = string.Format("SELECT TOP 1 right(chargeID,6) AS chargeID FROM Meter_Charge WHERE convert(char(10),LEFT(CHARGEID,8),120)=DATEADD(DAY, DATEDIFF(DAY, 0,'{0}'), 0) AND SUBSTRING(CHARGEID,11,4)=@LOGINID ORDER BY right(chargeID,6) desc", GetDatetimeNow());

            DataTable dt = new SqlServerHelper().GetDateTableBySql(strSql, new SqlParameter[] { new SqlParameter("@LOGINID", loginid) });
            if (DataTableHelper.IsExistRows(dt))
            {
                index = int.Parse(dt.Rows[0][0].ToString()) + 1;
                chargeID = string.Format("{0}01{1}SF{2}", DateTime.Now.ToString("yyyyMMdd"), loginid, String.Format("{0:000000}", index));
            }

            return chargeID;
        }

        public bool ApprovePrestore(Hashtable ht)
        {
            string strsql = string.Format(@"SET XACT_ABORT ON
BEGIN TRAN
INSERT INTO Meter_Charge 
(CHARGEID,TaskID,CHARGEBCSS,CHARGEBCYS,TOTALCHARGE,Abate,prestore,FeeList,CHARGETYPEID,CHARGEClASS,CHARGEWORKERID,CHARGEWORKERNAME,ReceiptPrintSign,RECEIPTPRINTCOUNT,ReceiptPrintTime,RECEIPTNO,POSRUNNINGNO,Memo) 
VALUES 
(@CHARGEID,@TaskID,@CHARGEBCSS,@CHARGEBCYS,@TOTALCHARGE,@Abate,@prestore,@FeeList,@CHARGETYPEID,@CHARGEClASS,@CHARGEWORKERID,@CHARGEWORKERNAME,@ReceiptPrintSign,1,'{1}',@RECEIPTNO,@POSRUNNINGNO,@Memo)
UPDATE Meter_WorkResolveFee SET State=1,CHARGEWORKERID=@CHARGEWORKERID,CHARGEWORKERNAME=@CHARGEWORKERNAME,ChargeDate='{1}',ChargeID=@CHARGEID WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPointSort)
UPDATE {0} SET prestore=@Prestore WHERE TaskID=@TaskID
COMMIT TRAN", ht["TableName"].ToString(), GetDatetimeNow());

            int count = DbHelperSQL.ExecuteSql(strsql,
                 new SqlParameter[] {
                new SqlParameter("@TaskID",ht["TaskID"].ToString()),
                new SqlParameter("@LastPointSort",ht["LastPointSort"].ToString()),
                new SqlParameter("@Prestore",ht["Prestore"].ToString()),
                new SqlParameter("@CHARGEID",ht["CHARGEID"].ToString()),
                new SqlParameter("@CHARGEBCSS",ht["CHARGEBCSS"].ToString()),
                new SqlParameter("@CHARGEBCYS",ht["CHARGEBCYS"].ToString()),
                new SqlParameter("@TOTALCHARGE",ht["TOTALCHARGE"].ToString()),
                new SqlParameter("@Abate",ht["Abate"].ToString()),
                new SqlParameter("@FeeList",ht["FeeList"].ToString()),
                new SqlParameter("@CHARGETYPEID",ht["CHARGETYPEID"].ToString()),
                new SqlParameter("@CHARGEClASS",ht["CHARGEClASS"].ToString()),
                new SqlParameter("@CHARGEWORKERID",ht["CHARGEWORKERID"].ToString()),
                new SqlParameter("@CHARGEWORKERNAME",ht["CHARGEWORKERNAME"].ToString()),
                new SqlParameter("@ReceiptPrintSign",ht["ReceiptPrintSign"].ToString()),
                new SqlParameter("@RECEIPTNO",ht["RECEIPTNO"].ToString()),
                new SqlParameter("@POSRUNNINGNO",ht["POSRUNNINGNO"].ToString()),
                new SqlParameter("@Memo",ht["Memo"].ToString())
                });
            return count > 0 ? true : false;
        }

        public bool ApprovePrestoreFinal(Hashtable ht)
        {
            string strsql = string.Format(@"SET XACT_ABORT ON
BEGIN TRAN
INSERT INTO Meter_Charge 
(CHARGEID,TaskID,CHARGEBCSS,CHARGEBCYS,TOTALCHARGE,Abate,prestore,FeeList,CHARGETYPEID,CHARGEClASS,CHARGEWORKERID,CHARGEWORKERNAME,INVOICEPRINTSIGN,InvoicePrintTime,InvoiceNO,POSRUNNINGNO,Memo) 
VALUES 
(@CHARGEID,@TaskID,@CHARGEBCSS,@CHARGEBCYS,@TOTALCHARGE,@Abate,@prestore,@FeeList,@CHARGETYPEID,@CHARGEClASS,@CHARGEWORKERID,@CHARGEWORKERNAME,@INVOICEPRINTSIGN,'{1}',@InvoiceNO,@POSRUNNINGNO,@Memo)
UPDATE Meter_WorkResolveFee SET State=1,CHARGEWORKERID=@CHARGEWORKERID,CHARGEWORKERNAME=@CHARGEWORKERNAME,ChargeDate='{1}',ChargeID=@CHARGEID WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPointSort)
UPDATE {0} SET prestore=@Prestore WHERE TaskID=@TaskID
COMMIT TRAN", ht["TableName"].ToString(), GetDatetimeNow());

            int count = DbHelperSQL.ExecuteSql(strsql,
                 new SqlParameter[] {
                new SqlParameter("@TaskID",ht["TaskID"].ToString()),
                new SqlParameter("@LastPointSort",ht["LastPointSort"].ToString()),
                new SqlParameter("@Prestore",ht["Prestore"].ToString()),
                new SqlParameter("@CHARGEID",ht["CHARGEID"].ToString()),
                new SqlParameter("@CHARGEBCSS",ht["CHARGEBCSS"].ToString()),
                new SqlParameter("@CHARGEBCYS",ht["CHARGEBCYS"].ToString()),
                new SqlParameter("@TOTALCHARGE",ht["TOTALCHARGE"].ToString()),
                new SqlParameter("@Abate",ht["Abate"].ToString()),
                new SqlParameter("@FeeList",ht["FeeList"].ToString()),
                new SqlParameter("@CHARGETYPEID",ht["CHARGETYPEID"].ToString()),
                new SqlParameter("@CHARGEClASS",ht["CHARGEClASS"].ToString()),
                new SqlParameter("@CHARGEWORKERID",ht["CHARGEWORKERID"].ToString()),
                new SqlParameter("@CHARGEWORKERNAME",ht["CHARGEWORKERNAME"].ToString()),
                new SqlParameter("@INVOICEPRINTSIGN",ht["INVOICEPRINTSIGN"].ToString()),
                new SqlParameter("@InvoiceNO",ht["InvoiceNO"].ToString()),
                new SqlParameter("@POSRUNNINGNO",ht["POSRUNNINGNO"].ToString()),
                new SqlParameter("@Memo",ht["Memo"].ToString())
                });
            return count > 0 ? true : false;
        }

        public bool ApproveMeterOut(Hashtable ht)
        {
            string strsql = string.Format(@"SET XACT_ABORT ON
BEGIN TRAN
INSERT INTO Meter_User(TaskID,MeterID,waterMeterSerialNumber,waterMeterEndNumber,Memo) SELECT @TaskID AS TaskID,MeterID,waterMeterSerialNumber,waterMeterStartNumber,@Memo AS Memo FROM Meter WHERE waterMeterSerialNumber IN ({0})
UPDATE Meter SET MeterState=1,ModifyDate='{1}',ModifyUser=@ModifyUser WHERE waterMeterSerialNumber IN ({0})
COMMIT TRAN", ht["waterMeterSerialNumber"].ToString(), GetDatetimeNow());

            int count = DbHelperSQL.ExecuteSql(strsql,
                new SqlParameter[] {
                new SqlParameter("@TaskID",ht["TaskID"].ToString()),
                new SqlParameter("@Memo",ht["Memo"].ToString()),
                new SqlParameter("@ModifyUser",ht["ModifyUser"].ToString())               
                });

            return count > 0 ? true : false;
        }

        public DataTable GetUserMaterByTaskID(string TaskID)
        {
            string sqlstr = string.Format("SELECT M.MeterID FROM METER M LEFT JOIN METER_USER MU ON M.MeterID=MU.MeterID WHERE MU.TaskID='{0}' ", TaskID);
            return new SqlServerHelper().GetDateTableBySql(sqlstr);
        }

        public bool Approve_Single_Append(string TaskID,string CHARGEID,string PRESTORERUNNINGACCOUNTID)
        {
            //            string strsql = @"DECLARE @waterUserId NVARCHAR(50)=''
            //DECLARE @ISEXIT INT=0
            //SET XACT_ABORT ON
            //BEGIN TRAN
            //SELECT @waterUserId=waterUserId FROM Meter_Install_Single WHERE TaskID=@TaskID
            //SELECT @ISEXIT=COUNT(1) FROM waterUser WHERE waterUserId=@waterUserId
            //IF(@ISEXIT=0)
            //BEGIN
            //INSERT INTO waterUser (waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,
            //waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,waterUserCreateDate,waterUserHouseType,agentsign,
            //bankId,BankAcountNumber,memo,prestore,ordernumber,chargeType) 
            //SELECT waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,
            //waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,GETDATE(),waterUserHouseType,agentsign,
            //bankId,BankAcountNumber,memo,prestore,ordernumber,chargeType FROM Meter_Install_Single WHERE TaskID=@TaskID
            //END
            //INSERT INTO waterMeter (waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,
            //waterMeterSizeId,waterMeterTypeId,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,isSummaryMeter,waterMeterParentId,STARTUSEDATETIME,MEMO) 
            //SELECT waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,
            //waterMeterSizeId,waterMeterTypeId,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,isSummaryMeter,waterMeterParentId,STARTUSEDATETIME,MEMO FROM Meter WHERE MeterID IN (SELECT MeterID FROM Meter_User WHERE TaskID=@TaskID)
            //INSERT INTO User_Append (TaskID,waterUserNO,waterUserName) SELECT TaskID,waterUserNO,waterUserName FROM Meter_Install_Single WHERE TaskID=@TaskID
            //UPDATE Meter_Install_Single SET prestore=0 WHERE TaskID=@TaskID
            //COMMIT TRAN";

            //2016-11-10
//            DECLARE @waterUserId NVARCHAR(50)=''
//DECLARE @ISEXIT INT=0
//SET XACT_ABORT ON
//BEGIN TRAN
//SELECT @waterUserId=waterUserId FROM Meter_Install_Single WHERE TaskID=@TaskID
//SELECT @ISEXIT=COUNT(1) FROM waterUser WHERE waterUserId=@waterUserId
//IF(@ISEXIT=0)
//BEGIN
//INSERT INTO waterUser (waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,
//waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,waterUserCreateDate,waterUserHouseType,agentsign,
//bankId,BankAcountNumber,memo,ordernumber,chargeType,pianNO,areaNO,duanNO,communityID,buildingNO,unitNO,createType
//,meterReaderID,meterReaderName,chargerID,chargerName,operatorName) 
//SELECT waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,
//waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,GETDATE(),waterUserHouseType,agentsign,
//bankId,BankAcountNumber,memo,ordernumber,chargeType,(SELECT PIANNAME FROM BASE_PIAN WHERE PIANID=MIS.PIANID) AS pianNO
//,(SELECT areaName FROM BASE_AREA WHERE areaId=MIS.areaId) AS areaNO
//,(SELECT DUANNAME FROM BASE_DUAN WHERE DUANID=MIS.DUANID) AS duanNO
//,communityID,BuildingNO,UnitNO,(SELECT CreateType FROM Base_Archives WHERE CreateTypeID=MIS.CreateTypeID) AS CreateType
//,meterReaderID,(SELECT userName FROM base_login WHERE loginId=MIS.meterReaderID) AS meterReaderName
//,chargerID,(SELECT userName FROM base_login WHERE loginId=MIS.chargerID) AS chargerName
//,operatorName FROM Meter_Install_Single MIS WHERE TaskID=@TaskID
//END
//INSERT INTO waterMeter (waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,
//waterMeterSizeId,waterMeterTypeId,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,
//waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,isSummaryMeter,waterMeterParentId,STARTUSEDATETIME,MEMO
//,waterMeterState,IsReverse,WATERMETERLOCKNO) 
//SELECT waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,
//waterMeterSizeId,waterMeterTypeId,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,
//waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,isSummaryMeter,waterMeterParentId,
//STARTUSEDATETIME,MEMO,waterMeterState,IsReverse,WATERMETERLOCKNO FROM Meter WHERE MeterID IN (SELECT MeterID FROM Meter_User WHERE TaskID=@TaskID)
//INSERT INTO User_Append (TaskID,waterUserNO,waterUserName) SELECT TaskID,waterUserNO,waterUserName FROM Meter_Install_Single WHERE TaskID=@TaskID
//COMMIT TRAN

            string Chargeid = GetNewChargeID("0092");


            string strsql = string.Format(@"DECLARE @waterUserId NVARCHAR(50)=''
DECLARE @ISEXIT INT=0
DECLARE @FEE DECIMAL(18,2)=0
SET XACT_ABORT ON
BEGIN TRAN
SELECT @waterUserId=waterUserId FROM Meter_Install_Single WHERE TaskID=@TaskID
SELECT @ISEXIT=COUNT(1) FROM waterUser WHERE waterUserId=@waterUserId
IF(@ISEXIT=0)
BEGIN
INSERT INTO waterUser (waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,
waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,waterUserCreateDate,waterUserHouseType,agentsign,
bankId,BankAcountNumber,memo,ordernumber,chargeType,pianNO,areaNO,duanNO,communityID,buildingNO,unitNO,createType
,meterReaderID,meterReaderName,chargerID,chargerName,operatorName) 
SELECT waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,
waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,'{3}',waterUserHouseType,agentsign,
bankId,BankAcountNumber,memo,ordernumber,chargeType,(SELECT PIANNAME FROM BASE_PIAN WHERE PIANID=MIS.PIANID) AS pianNO
,(SELECT areaName FROM BASE_AREA WHERE areaId=MIS.areaId) AS areaNO
,(SELECT DUANNAME FROM BASE_DUAN WHERE DUANID=MIS.DUANID) AS duanNO
,communityID,BuildingNO,UnitNO,(SELECT CreateType FROM Base_Archives WHERE CreateTypeID=MIS.CreateTypeID) AS CreateType
,meterReaderID,(SELECT userName FROM base_login WHERE loginId=MIS.meterReaderID) AS meterReaderName
,chargerID,(SELECT userName FROM base_login WHERE loginId=MIS.chargerID) AS chargerName
,operatorName FROM Meter_Install_Single MIS WHERE TaskID=@TaskID
END
INSERT INTO waterMeter (waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,
waterMeterSizeId,waterMeterTypeId,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,
waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,isSummaryMeter,waterMeterParentId,STARTUSEDATETIME,MEMO
,waterMeterState,IsReverse,WATERMETERLOCKNO) 
SELECT waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,
waterMeterSizeId,waterMeterTypeId,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,
waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,isSummaryMeter,waterMeterParentId,
STARTUSEDATETIME,MEMO,waterMeterState,IsReverse,WATERMETERLOCKNO FROM Meter WHERE MeterID IN (SELECT MeterID FROM Meter_User WHERE TaskID=@TaskID)
INSERT INTO User_Append (TaskID,waterUserNO,waterUserName) SELECT TaskID,waterUserNO,waterUserName FROM Meter_Install_Single WHERE TaskID=@TaskID

SELECT @FEE=prestore FROM Meter_Install_Single WHERE TaskID=@TaskID
UPDATE Meter_Install_Single SET prestore=0 WHERE TaskID=@TaskID
UPDATE waterUser SET prestore=prestore+@FEE WHERE waterUserId=@waterUserId
INSERT INTO Meter_Charge (CHARGEID,TaskID,CHARGEBCSS,CHARGEBCYS,TOTALCHARGE,prestore,FeeList,CHARGETYPEID,CHARGEClASS,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME) 
VALUES 
('{0}',@TaskID,0-@FEE,0,0,0,'余额转营业','6','17','0092','温国艳','{3}')
INSERT INTO WATERFEECHARGE (CHARGEID,CHARGETYPEID,CHARGEClASS,CHARGEBCYS,CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME) 
VALUES 
('{1}','6','17',0,@FEE,0,@FEE,@FEE,'0092','温国艳','{3}')
INSERT INTO PRESTORERUNNINGACCOUNT (PRESTORERUNNINGACCOUNTID,CHARGEID,WATERUSERID,WATERUSERNO,WATERUSERNAME,WATERUSERADDRESS,AREANO,PIANNO,DUANNO,ORDERNUMBER,COMMUNITYID,COMMUNITYNAME,
METERREADERID,METERREADERNAME,CHARGERID,CHARGERNAME,WATERUSERTYPEID,WATERUSERTYPENAME,WATERMETERTYPEID,WATERMETERTYPEVALUE,WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,WATERUSERHOUSETYPE,CREATETYPE)
SELECT '{2}','{1}', WATERUSERID,WATERUSERNO,WATERUSERNAME,WATERUSERADDRESS,AREANO,PIANNO,DUANNO,ORDERNUMBER,COMMUNITYID,COMMUNITYNAME,
METERREADERID,METERREADERNAME,CHARGERID,CHARGERNAME,WATERUSERTYPEID,WATERUSERTYPENAME,WATERMETERTYPEID,WATERMETERTYPEVALUE,WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,WATERUSERHOUSETYPE,CREATETYPE 
FROM V_WATERUSER_CONNECTWATERMETER
WHERE waterUserId=@waterUserId
COMMIT TRAN", Chargeid, CHARGEID, PRESTORERUNNINGACCOUNTID, GetDatetimeNow());
            int count = DbHelperSQL.ExecuteSql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            return count > 0 ? true : false;

        }

        /// <summary>
        /// 违章用户报装新增户和水表
        /// </summary>
        /// <param name="TaskID"></param>
        /// <returns></returns>
        public bool Approve_Peccant_Append(string TaskID)
        {
            string strsql =string.Format(@"DECLARE @waterUserId NVARCHAR(50)=''
                            DECLARE @ISEXIT INT=0
                            SET XACT_ABORT ON
                            BEGIN TRAN
                            SELECT @waterUserId=waterUserId FROM Meter_Install_Peccant WHERE TaskID=@TaskID
                            SELECT @ISEXIT=COUNT(1) FROM waterUser WHERE waterUserId=@waterUserId
                            IF(@ISEXIT=0)
                            BEGIN
                            INSERT INTO waterUser (waterUserId,waterUserNO,waterUserName,waterUserTelphoneNO,waterUserAddress,
                            waterUserPeopleCount,waterUserTypeId,waterUserCreateDate,waterUserHouseType,agentsign,
                            bankId,BankAcountNumber,memo,ordernumber,chargeType,pianNO,areaNO,duanNO,communityID,buildingNO,unitNO,createType
                            ,meterReaderID,meterReaderName,chargerID,chargerName,operatorName) 
                            SELECT waterUserId,waterUserNO,waterUserName,waterPhone,waterUserAddress,
                            waterUserPeopleCount,waterUserTypeId,'{0}',waterUserHouseType,agentsign,
                            bankId,BankAcountNumber,memo,ordernumber,chargeType,pianNO,areaNO,duanNO,communityID,BuildingNO,UnitNO,
                            (SELECT CreateType FROM Base_Archives WHERE CreateTypeID=MIS.CreateType) AS CreateType
                            ,meterReaderID,meterReaderName,chargerID,chargerName,operatorName FROM Meter_Install_Peccant MIS WHERE TaskID=@TaskID
                            END
                            INSERT INTO waterMeter (waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,
                            waterMeterSizeId,waterMeterTypeId,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode
                            ,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,isSummaryMeter,waterMeterParentId,STARTUSEDATETIME,MEMO
                            ,waterMeterState,IsReverse,WATERMETERLOCKNO) 
                            SELECT @waterUserId+'01',@waterUserId+'01',waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,
                            waterMeterSizeId,waterMeterTypeId,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,
                            waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,@waterUserId,isSummaryMeter,waterMeterParentId,
                            STARTUSEDATETIME,MEMO,waterMeterState,IsReverse,WATERMETERLOCKNO FROM Meter WHERE MeterID IN (SELECT MeterID FROM Meter_User WHERE TaskID=@TaskID)
                            INSERT INTO User_Append (TaskID,waterUserNO,waterUserName) SELECT TaskID,waterUserNO,waterUserName FROM Meter_Install_Peccant WHERE TaskID=@TaskID
                            COMMIT TRAN", GetDatetimeNow());
            int count = DbHelperSQL.ExecuteSql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            return count > 0 ? true : false;

        }

        //增加预存单号ID、地址、账户余额字段 ByRen 
        public Hashtable GetUserAllowRefund(string CHARGEID)
        {
            string sqlstr = @"SELECT VV.CHARGEID,VV.CHARGEBCSS AS CHARGEBCSS_IN,VW.WATERUSERNO,VW.WATERUSERNAME AS ApplyUser,VW.waterPhone,
VV.PRESTORERUNNINGACCOUNTID,VW.waterUserAddress,VW.prestore,VV.WATERMETERTYPECLASSID 
FROM V_PRESTORERUNNINGACCOUNT_VALID VV,V_WATERUSERAREARAGE VW WHERE 
VV.WATERUSERID=VW.waterUserId AND DATEDIFF(MONTH,CHARGEDATETIME,GETDATE())=0
AND VV.CHARGEBCSS<=VW.prestore AND CHARGEID=@CHARGEID";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@CHARGEID", CHARGEID) });
            return DataTableHelper.DataTableToHashtable(dt);
        }

        public bool GetUserExistRefund(string CHARGEID)
        {
            bool result = false;
            DataTable dt = new SqlServerHelper().GetDateTableBySql(string.Format("SELECT COUNT(*) FROM User_Refund WHERE State<>4 AND CHARGEID_IN='{0}'", CHARGEID));
            if (DataTableHelper.IsExistRows(dt))
            {
                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public int UpdateApprove_Refund_defalut(string ResolveID, bool IsPass, string UserOpinion, string PointSort, string TaskID, string Matter)
        {
            string ComputerName = AppDomain.CurrentDomain.GetData("COMPUTERNAME").ToString();
            string ip = AppDomain.CurrentDomain.GetData("IP").ToString();
            return UpdateApprove_defalut("User_Refund", ResolveID, IsPass, UserOpinion, ip, ComputerName, PointSort, TaskID, Matter);
        }

        public int UpdateApprove_Refund_Voided(string ResolveID, string UserOpinion, string TaskID)
        {
            string ComputerName = AppDomain.CurrentDomain.GetData("COMPUTERNAME").ToString();
            string ip = AppDomain.CurrentDomain.GetData("IP").ToString();
            return UpdateApprove_Voided_ByTableName("User_Refund", ResolveID, UserOpinion, ip, ComputerName, TaskID);

        }

        public bool IsExitWaterPriceNO(string waterUserNO)
        {
            string sqlstr = "SELECT COUNT(1) FROM User_WaterPrice WHERE State NOT IN (0,5) AND waterUserNO=@waterUserNO";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@waterUserNO", waterUserNO) });

            return int.Parse(dt.Rows[0][0].ToString()) > 0 ? true : false;
        }

        public bool IsWorkTaskOver(string TableName, string TaskID)
        {
            string sqlstr = string.Format("SELECT COUNT(1) FROM Meter_WorkTask MWT,{0} UW WHERE MWT.TaskID=UW.TaskID AND UW.State=5 AND MWT.State=5 AND MWT.TaskID=@TaskID", TableName);
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            return int.Parse(dt.Rows[0][0].ToString()) > 0 ? true : false;
        }

        public bool GetUserExistAbate(string readMeterRecordId)
        {
            string sqlstr = "SELECT COUNT(1) FROM User_ChargeAbate WHERE State NOT IN (0,5) AND readMeterRecordId=@readMeterRecordId";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@readMeterRecordId", readMeterRecordId) });

            return int.Parse(dt.Rows[0][0].ToString()) > 0 ? true : false;
        }

        public DataTable GetDepartMentFee(string TaskID, string PointSort)
        {
            string strsql = @"DECLARE @LastPoingSort INT=0
SELECT TOP 1 @LastPoingSort=PointSort FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<@PointSort ORDER BY PointSort DESC
SELECT * FROM 
(SELECT *,
(SELECT COUNT(1) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND Fee<>0) AS ItemsCount,
(SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND Fee<>0) AS TotalFee,
(SELECT SUM(State) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND Fee<>0) AS STATE,
(SELECT TOP 1 IsFinal FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND Fee<>0) AS IsFinal
FROM 
(SELECT DISTINCT MWR.DepartementID,BD.departmentName,MWR.ResolveID,MWR.PointSort AS FeePointSort FROM base_department BD,Meter_WorkResolve MWR WHERE BD.departmentID=MWR.DepartementID AND MWR.TaskID=@TaskID AND PointSort=@LastPoingSort) T) M
WHERE ItemsCount>0 AND TotalFee>0";

            return new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort) });
        }

        public DataTable GetDepartMentFeeItems(string ResolveID)
        {
            string strsql = @"SELECT *,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0) AS DepartTotalFee,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND State<>1) AS FinalTotalFee FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0";

            return new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@ResolveID", ResolveID) });
        }

        public DataTable GetDepartMentFinalFeeItems(string ResolveID)
        {
            //   string strsql = @"SELECT *,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0) AS DepartTotalFee,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND State<>1) AS FinalTotalFee FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)";
            //            string strsql = @"SELECT *,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0) AS DepartTotalFee,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND State<>1) AS FinalTotalFee FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0";
            string strsql = @"SELECT MWF.*,MF.IsPrestore,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0) AS DepartTotalFee,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND State<>1) AS FinalTotalFee FROM Meter_WorkResolveFee MWF,Meter_FeeItmes MF WHERE MWF.FeeID=MF.FeeID AND ResolveID=@ResolveID AND FEE>0";

            return new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@ResolveID", ResolveID) });
        }

        public decimal GetTotalFeeByPointSort(string TaskID, string LastPoingSort)
        {
            decimal totalfee = 0m;
            string strsql = "SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPoingSort) AND FEE>0";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", LastPoingSort) });
            if (DataTableHelper.IsExistRows(dt))
            {
                totalfee = decimal.Parse(dt.Rows[0][0].ToString());
            }
            return totalfee;
        }

        public bool IsChargeOver(string TaskID, string LastPoingSort)
        {
            string strsql = "SELECT COUNT(1) FROM Meter_WorkResolveFee WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPoingSort) AND FEE>0 AND State<>1";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", LastPoingSort) });

            return int.Parse(dt.Rows[0][0].ToString()) > 0 ? false : true;
        }

        public DataTable GetDepartMentFeeFinal(string TaskID, string PointSort)
        {
            //            string strsql = @"DECLARE @LastPoingSort INT=0
            //SELECT TOP 1 @LastPoingSort=PointSort FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<@PointSort ORDER BY PointSort DESC
            //SELECT * FROM 
            //(SELECT *,
            //(SELECT COUNT(1) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)) AS ItemsCount,
            //(SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)) AS TotalFee,
            //(SELECT SUM(State) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)) AS STATE,
            //(SELECT TOP 1 IsFinal FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID) AS IsFinal
            //FROM 
            //(SELECT DISTINCT MWR.DepartementID,BD.departmentName,MWR.ResolveID,MWR.PointSort AS LastPointSort FROM base_department BD,Meter_WorkResolve MWR WHERE BD.departmentID=MWR.DepartementID AND MWR.TaskID=@TaskID AND PointSort=@LastPoingSort) T) M
            //WHERE ItemsCount>0 AND TotalFee>0";
            string strsql = @"DECLARE @LastPoingSort INT=0
SELECT TOP 1 @LastPoingSort=PointSort FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<@PointSort ORDER BY PointSort DESC
SELECT * FROM 
(SELECT *,
(SELECT COUNT(1) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND Fee<>0) AS ItemsCount,
(SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND Fee<>0) AS TotalFee,
(SELECT SUM(State) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND Fee<>0) AS STATE,
(SELECT TOP 1 IsFinal FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND Fee<>0) AS IsFinal
FROM 
(SELECT DISTINCT MWR.DepartementID,BD.departmentName,MWR.ResolveID,MWR.PointSort AS LastPointSort FROM base_department BD,Meter_WorkResolve MWR WHERE BD.departmentID=MWR.DepartementID AND MWR.TaskID=@TaskID AND PointSort=@LastPoingSort) T) M
WHERE ItemsCount>0 AND TotalFee>0";

            return new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort) });
        }

        public decimal GetTotalFeeFinalByPointSort(string TaskID, string LastPoingSort)
        {
            decimal totalfee = 0m;
            //string strsql = "SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPoingSort) AND FEE>0 AND FeeID NOT IN  (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)";
            string strsql = "SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPoingSort) AND FEE>0 ";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", LastPoingSort) });
            if (DataTableHelper.IsExistRows(dt))
            {
                totalfee = decimal.Parse(dt.Rows[0][0].ToString());
            }
            return totalfee;
        }

        //预存水费2016-11-5
        public decimal GetTotalFeeYuCun(string TaskID, string LastPoingSort)
        {
            decimal totalfee = 0m;
            string strsql = "SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPoingSort) AND FEE>0 AND FeeID IN  (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", LastPoingSort) });
            if (DataTableHelper.IsExistRows(dt))
            {
                if (!string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                {
                    totalfee = decimal.Parse(dt.Rows[0][0].ToString());
                }
            }
            return totalfee;
        }

        public DataTable GetDepartMentFeeFinalItems(string ResolveID)
        {
            string strsql = @"SELECT *,
(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)) AS DepartTotalFee,
(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND State<>1AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)) AS FinalTotalFee 
FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)";

            return new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@ResolveID", ResolveID) });
        }

        public decimal GetDepartmentPrestore(string TaskID, int LastPoingSort, string DepartementID)
        {
            decimal DepertmentPrestore = 0m;
            string sqlstr = @"SELECT sum(CHARGEBCSS) FROM Meter_Charge WHERE CHARGEID IN 
(SELECT DISTINCT ChargeID FROM Meter_WorkResolveFee WHERE State=1 AND ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE PointSort<@LastPoingSort AND TaskID=@TaskID AND DepartementID=@DepartementID))";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", LastPoingSort), new SqlParameter("@DepartementID", DepartementID) });

            if (Decimal.TryParse(dt.Rows[0][0].ToString(), out DepertmentPrestore))
            {

            }
            return DepertmentPrestore;
        }

        public decimal GetDepartmentPrestoreFinal(string TaskID, int LastPoingSort, string DepartementID)
        {
            decimal DepertmentPrestore = 0m;
            // string sqlstr = @"SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE State=1 AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1) AND ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE PointSort<@LastPoingSort AND TaskID=@TaskID AND DepartementID=@DepartementID)";
            string sqlstr = @"SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE State=1 AND ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE PointSort<@LastPoingSort AND TaskID=@TaskID AND DepartementID=@DepartementID)";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", LastPoingSort), new SqlParameter("@DepartementID", DepartementID) });

            if (Decimal.TryParse(dt.Rows[0][0].ToString(), out DepertmentPrestore))
            {

            }
            return DepertmentPrestore;
        }

        public bool IsChargeOverFinal(string TaskID, string LastPoingSort)
        {
            //            string strsql = @"SELECT COUNT(1) FROM Meter_WorkResolveFee WHERE ResolveID IN 
            //(SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPoingSort) 
            //AND FEE>0 AND State<>1 AND ChargeID <>'' AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)";
            string strsql = @"SELECT COUNT(1) FROM Meter_WorkResolveFee WHERE ResolveID IN 
(SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPoingSort) 
AND FEE>0 AND State<>1 AND ISNULL(ChargeID,'')=N''";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", LastPoingSort) });

            return int.Parse(dt.Rows[0][0].ToString()) > 0 ? false : true;
        }

        public bool ApproveBudgetPrestore(Hashtable ht)
        {
            string strsql = string.Format(@"SET XACT_ABORT ON
BEGIN TRAN
INSERT INTO Meter_Charge 
(CHARGEID,TaskID,CHARGEBCSS,CHARGEBCYS,TOTALCHARGE,prestore,FeeList,CHARGETYPEID,CHARGEClASS,CHARGEWORKERID,CHARGEWORKERNAME,ReceiptPrintSign,RECEIPTPRINTCOUNT,ReceiptPrintTime,RECEIPTNO,POSRUNNINGNO,Memo) 
VALUES 
(@CHARGEID,@TaskID,@CHARGEBCSS,@CHARGEBCYS,@TOTALCHARGE,@prestore,@FeeList,@CHARGETYPEID,@CHARGEClASS,@CHARGEWORKERID,@CHARGEWORKERNAME,@ReceiptPrintSign,1,'{1}',@RECEIPTNO,@POSRUNNINGNO,@Memo)
UPDATE Meter_WorkResolveFee SET State=1,CHARGEWORKERID=@CHARGEWORKERID,CHARGEWORKERNAME=@CHARGEWORKERNAME,ChargeDate='{1}',ChargeID=@CHARGEID WHERE ResolveID =@ResolveID
UPDATE {0} SET prestore=@Prestore WHERE TaskID=@TaskID
COMMIT TRAN", ht["TableName"].ToString(), GetDatetimeNow());

            int count = DbHelperSQL.ExecuteSql(strsql,
                 new SqlParameter[] {
                new SqlParameter("@TaskID",ht["TaskID"].ToString()),
                new SqlParameter("@LastPointSort",ht["LastPointSort"].ToString()),
                new SqlParameter("@Prestore",ht["Prestore"].ToString()),
                new SqlParameter("@CHARGEID",ht["CHARGEID"].ToString()),
                new SqlParameter("@CHARGEBCSS",ht["CHARGEBCSS"].ToString()),
                new SqlParameter("@CHARGEBCYS",ht["CHARGEBCYS"].ToString()),
                new SqlParameter("@TOTALCHARGE",ht["TOTALCHARGE"].ToString()),
                new SqlParameter("@FeeList",ht["FeeList"].ToString()),
                new SqlParameter("@CHARGETYPEID",ht["CHARGETYPEID"].ToString()),
                new SqlParameter("@CHARGEClASS",ht["CHARGEClASS"].ToString()),
                new SqlParameter("@CHARGEWORKERID",ht["CHARGEWORKERID"].ToString()),
                new SqlParameter("@CHARGEWORKERNAME",ht["CHARGEWORKERNAME"].ToString()),
                new SqlParameter("@ReceiptPrintSign",ht["ReceiptPrintSign"].ToString()),
                new SqlParameter("@RECEIPTNO",ht["RECEIPTNO"].ToString()),
                new SqlParameter("@POSRUNNINGNO",ht["POSRUNNINGNO"].ToString()),
                new SqlParameter("@ResolveID",ht["ResolveID"].ToString()),
                new SqlParameter("@Memo",ht["Memo"].ToString())
                });
            return count > 0 ? true : false;
        }

        public bool ApproveFinalPrestore(Hashtable ht)
        {
            string strsql = string.Format(@"SET XACT_ABORT ON
BEGIN TRAN
INSERT INTO Meter_Charge 
(CHARGEID,TaskID,CHARGEBCSS,CHARGEBCYS,TOTALCHARGE,Abate,prestore,FeeList,CHARGETYPEID,CHARGEClASS,CHARGEWORKERID,CHARGEWORKERNAME,ReceiptPrintSign,RECEIPTPRINTCOUNT,ReceiptPrintTime,RECEIPTNO,POSRUNNINGNO,Memo) 
VALUES 
(@CHARGEID,@TaskID,@CHARGEBCSS,@CHARGEBCYS,@TOTALCHARGE,@Abate,@prestore,@FeeList,@CHARGETYPEID,@CHARGEClASS,@CHARGEWORKERID,@CHARGEWORKERNAME,@ReceiptPrintSign,1,'{1}',@RECEIPTNO,@POSRUNNINGNO,@Memo)
UPDATE Meter_WorkResolveFee SET State=1,CHARGEWORKERID=@CHARGEWORKERID,CHARGEWORKERNAME=@CHARGEWORKERNAME,ChargeDate='{1}',ChargeID=@CHARGEID WHERE ResolveID =@ResolveID
UPDATE {0} SET prestore=@Prestore WHERE TaskID=@TaskID
COMMIT TRAN", ht["TableName"].ToString(), GetDatetimeNow());

            int count = DbHelperSQL.ExecuteSql(strsql,
                 new SqlParameter[] {
                new SqlParameter("@TaskID",ht["TaskID"].ToString()),
                new SqlParameter("@ResolveID",ht["ResolveID"].ToString()),
                new SqlParameter("@Prestore",ht["Prestore"].ToString()),
                new SqlParameter("@CHARGEID",ht["CHARGEID"].ToString()),
                new SqlParameter("@CHARGEBCSS",ht["CHARGEBCSS"].ToString()),
                new SqlParameter("@CHARGEBCYS",ht["CHARGEBCYS"].ToString()),
                new SqlParameter("@TOTALCHARGE",ht["TOTALCHARGE"].ToString()),
                new SqlParameter("@Abate",ht["Abate"].ToString()),
                new SqlParameter("@FeeList",ht["FeeList"].ToString()),
                new SqlParameter("@CHARGETYPEID",ht["CHARGETYPEID"].ToString()),
                new SqlParameter("@CHARGEClASS",ht["CHARGEClASS"].ToString()),
                new SqlParameter("@CHARGEWORKERID",ht["CHARGEWORKERID"].ToString()),
                new SqlParameter("@CHARGEWORKERNAME",ht["CHARGEWORKERNAME"].ToString()),
                new SqlParameter("@ReceiptPrintSign",ht["ReceiptPrintSign"].ToString()),
                new SqlParameter("@RECEIPTNO",ht["RECEIPTNO"].ToString()),
                new SqlParameter("@POSRUNNINGNO",ht["POSRUNNINGNO"].ToString()),
                new SqlParameter("@Memo",ht["Memo"].ToString())
                });
            return count > 0 ? true : false;
        }

        //2016-10-03 RONG--Begin
        public DataTable GetMaintainType()
        {
            return new SqlServerHelper().GetDateTableBySql("SELECT MaintainType,MaintainTypeID FROM Meter_MaintainType ORDER BY MaintainTypeID");
        }

        public Hashtable GetMaintainByTaskID(string TaskID)
        {
            return new SqlServerHelper().GetHashtableById("Meter_Maintain", "TaskID", TaskID);
        }

        public Hashtable GetWaterUserInfoByWaterUserNO(string waterUserNO)
        {
            return new SqlServerHelper().GetHashtableById("V_WATERUSERAREARAGE", "waterUserNO", waterUserNO);
        }
        //2016-10-03 RONG--End

        public Hashtable GetMeter_Install_GroupInfos(string TaskID)
        {
            return new SqlServerHelper().GetHashtableById("Meter_Install_Group", "TaskID", TaskID);
        }

        public DataTable GetMeter_Group_People(string GroupID, int Step)
        {
            string sqlstr = "SELECT * FROM Meter_Group_People MGP,waterMeterType MT,waterUserType UT,waterUserHouseType UHT	WHERE MGP.waterMeterTypeId=MT.waterMeterTypeId AND MGP.waterUserTypeId=UT.waterUserTypeId AND MGP.waterUserHouseTypeID=UHT.waterUserHouseTypeID AND GroupID=@GroupID AND Step=@Step";
            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@GroupID", GroupID), new SqlParameter("@Step", Step) });
        }

        public DataTable GetMeter_Group_People(string GroupID)
        {
            //// return new SqlServerHelper().GetDataTable("Meter_Group_People", "GroupID='"+GroupID+"'", "waterMeterTypeId");
            //string sqlstr = "SELECT * FROM Meter_Group_People MGP,waterMeterType MT,waterUserType UT,waterUserHouseType UHT	WHERE MGP.waterMeterTypeId=MT.waterMeterTypeId AND MGP.waterUserTypeId=UT.waterUserTypeId AND MGP.waterUserHouseTypeID=UHT.waterUserHouseTypeID AND GroupID=@GroupID";
            //return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@GroupID", GroupID) });
            return GetMeter_Group_People(GroupID, 0);
        }

        public string GetWaterUserTypeByID(string waterUserTypeId)
        {

            Hashtable ht = new SqlServerHelper().GetHashtableById("waterUserType", "waterUserTypeId", waterUserTypeId);
            return ht.Contains("WATERUSERTYPENAME") ? (string)ht["WATERUSERTYPENAME"] : "";
        }

        public string GetwaterMeterTypeByID(string waterMeterTypeId)
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("waterMeterType", "waterMeterTypeId", waterMeterTypeId);
            return ht.Contains("WATERMETERTYPEVALUE") ? (string)ht["WATERMETERTYPEVALUE"] : "";
        }

        public bool IsAuthority(string loginId, string MenuID)
        {
            string sqlstr = "SELECT COUNT(1) FROM base_login WHERE  loginId=@loginId AND groupID='0001' AND userstate=1";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@loginId", loginId) });
            if (int.Parse(dt.Rows[0][0].ToString()) > 0)
            {
                return true;
            }
            else
            {
                //sqlstr = "SELECT COUNT(1) FROM base_login BL,BASE_MENU BM,BASE_AUTHORITY BA WHERE BL.groupID=BA.GROUPID AND BA.MENUID=BM.MENUID AND BM.MENUID=@MenuID and ','+BL.loginId+',' like '%,'+loginId+',%' ";
                sqlstr = "SELECT COUNT(1) FROM base_login BL,BASE_MENU BM,BASE_AUTHORITY BA WHERE BL.groupID=BA.GROUPID AND BA.MENUID=BM.MENUID AND BM.MENUID=@MenuID and BL.loginId=@loginId";
                dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@MenuID", MenuID), new SqlParameter("@loginId", loginId) });
                return DataTableHelper.IsExistRows(dt) ? int.Parse(dt.Rows[0][0].ToString()) > 0 ? true : false : false;
            }
        }
        public bool IsAuthority(string MenuID)
        {
            return IsAuthority(AppDomain.CurrentDomain.GetData("LOGINID").ToString(), MenuID);
        }

        public DataTable GetWaterBusiness(string strWhere)
        {
            return new SqlServerHelper().GetDataTable("Meter_WaterBusiness", strWhere, "Sort");
        }

        public DataTable GetWaterBusinessSub(int MenuID)
        {
            return new SqlServerHelper().GetDataTable("Meter_WaterBusiness_Sub", "MenuID=" + MenuID, "Sort");
        }

        public DataTable GetApproveCenter(string strWhere)
        {
            return new SqlServerHelper().GetDataTable("Meter_ApproveCenter", strWhere, "Sort");
        }

        public DataTable GetApproveCenterSub(int MenuID)
        {
            return new SqlServerHelper().GetDataTable("Meter_ApproveCenter_Sub", "MenuID=" + MenuID, "Sort");
        }

        public DataTable GetUserMeterInfoByTaskId(string TaskID)
        {
            string sqlstr = "SELECT MD.WaterUserNO,VM.waterMeterNo FROM V_WATERMETER VM,Meter_Disuse MD WHERE VM.waterUserId=MD.WaterUserNO AND MD.TaskID=@TaskID";
            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
        }

        public DataTable GetUserMeterInfoByTaskId(string tableName, string TaskID)
        {
            string sqlstr = string.Format("SELECT MD.WaterUserNO,VM.waterMeterNo FROM V_WATERMETER VM,{0} MD WHERE VM.waterUserId=MD.WaterUserNO AND MD.TaskID=@TaskID", tableName);
            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
        }

        public bool SetTaskOver(string TableName, string TaskID)
        {
            string sqlstr = string.Format(@"SET XACT_ABORT ON
BEGIN TRAN
UPDATE Meter_WorkTask SET [State]=5 WHERE TaskID=@TaskID
UPDATE Meter_Disuse SET [State]=5 WHERE TaskID=@TaskID
COMMIT TRAN", TableName);

            int count = new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            return count > 0 ? true : false;
        }

        //用户余额退款
        public bool UserPrestoreRefund(string TaskID, string Memo)
        {
            int count = 0;
            string sqlstr = "SELECT TableName FROM View_WorkBase WHERE TaskID=@TaskID";
            DataTable dt = DbHelperSQL.Query(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) }).Tables[0];
            if (DataTableHelper.IsExistRows(dt))
            {
                string Chargeid = GetNewChargeID("0092");
                string strsql = string.Format(@"DECLARE @FEE DECIMAL(18,2)=0
SELECT @FEE=prestore FROM View_WorkBase WHERE TaskID=@TaskID
SET XACT_ABORT ON
BEGIN TRAN
UPDATE {2} SET prestore=0 WHERE TaskID=@TaskID
INSERT INTO Meter_Charge (CHARGEID,TaskID,CHARGEBCSS,CHARGEBCYS,TOTALCHARGE,prestore,FeeList,CHARGETYPEID,CHARGEClASS,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME,Memo) 
VALUES 
('{0}',@TaskID,0-@FEE,0,0,0,'余额退款','1','17','0092','温国艳','{3}','{1}')
COMMIT TRAN", Chargeid, Memo, dt.Rows[0][0].ToString(), GetDatetimeNow());

                count = DbHelperSQL.ExecuteSql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            }
            return count > 0 ? true : false;

            
        }

        public string GetTableNameByTaskID(string TaskID)
        {
            string _tableName = "";
            string sqlstr = "SELECT TableName FROM View_WorkBase WHERE TaskID=@TaskID";
            DataTable dt = DbHelperSQL.Query(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) }).Tables[0];
            if (DataTableHelper.IsExistRows(dt))
            {
                _tableName = dt.Rows[0][0].ToString();
            }
            return _tableName;
        }

        public bool CancelCharge(string TaskID, string ChargeID, string CANCELMEMO)
        {
            string _tableNmae = GetTableNameByTaskID(TaskID);
            string loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            string userName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            string sqlstr =string.Format(@"
DECLARE @FEE DECIMAL(18,2)=0

--获取收取费用
SELECT @FEE=CHARGEBCSS FROM Meter_Charge WHERE TaskID=@TaskID AND CHARGEID=@CHARGEID AND ISNULL(DAYCHECKSTATE,'')='0'
SET XACT_ABORT ON
BEGIN TRAN
--取消收费
UPDATE Meter_Charge SET CHARGECANCEL=1,CANCELYSQQYE=0,CANCELYSBCSZ=@FEE,CANCELYSJSYE=@FEE,CANCELWORKERID
='{2}',CANCELWORKERNAME='{3}',CANCELDATETIME='{4}',CANCELMEMO='{1}' WHERE TaskID=@TaskID AND CHARGEID=@CHARGEID AND ISNULL(DAYCHECKSTATE,'')='0'
--更改收费项目状态
UPDATE Meter_WorkResolveFee SET [State]=0 WHERE ChargeID=@CHARGEID
--更改账户余额
UPDATE {0} SET prestore=prestore-@FEE WHERE TaskID=@TaskID
COMMIT TRAN", _tableNmae, CANCELMEMO, loginid, userName, GetDatetimeNow());
            int count = new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@CHARGEID", ChargeID) });
            return count > 0 ? true : false;
        }


        /// <summary>
        /// 根据用水类别的阶梯水价获取水费组成
        /// </summary>
        /// <param name="decTotalNumber">总用水量</param>
        /// <param name="strTrapePriceString">阶梯水价说明</param>
        /// <param name="extraCharge">附加费组成</param>
        /// <param name="intNotReadMonths">未抄月份</param>
        /// <param name="waterTotalCharge">用户水费</param>
        /// <param name="extraCharge1">污水处理费</param>
        /// <param name="extraCharge2">附加费</param>
        public void GetAvePrice(decimal decTotalNumber, string strTrapePriceString, string extraCharge, int intNotReadMonths, ref decimal waterTotalCharge, ref decimal extraCharge1, ref decimal extraCharge2)
        {
            string[] strTrapePrice = strTrapePriceString.Split('|');
            decimal decWaterSum = 0, decWaterTotalNumber = decTotalNumber;
            for (int i = strTrapePrice.Length - 1; i >= 0; i--)
            {
                string[] strJTAndPrice = strTrapePrice[i].Split(':');
                string[] strJT = strJTAndPrice[0].Split('-');
                if (Information.IsNumeric(strJT[0]) && Information.IsNumeric(strJT[1]))
                {
                    if (decTotalNumber > (Convert.ToDecimal(strJT[0]) * intNotReadMonths) && decTotalNumber <= (Convert.ToDecimal(strJT[1]) * intNotReadMonths))
                    {
                        decWaterSum += (decTotalNumber - (Convert.ToDecimal(strJT[0]) * intNotReadMonths)) * (Convert.ToDecimal(strJTAndPrice[1]));
                        decTotalNumber = (Convert.ToDecimal(strJT[0]) * intNotReadMonths);
                    }
                    else
                        continue;
                }

            }

            waterTotalCharge = decWaterSum;

            string[] strExtra = extraCharge.Split('|');
            for (int i = 0; i < 2; i++)
            {
                if (strExtra.Length > i)
                {
                    string _extra = strExtra[i];
                    string[] strExtraFee = _extra.Split(':');
                    decimal _extraChargeSingle = 0m;
                    if (i == 0)
                    {
                        if (decimal.TryParse(strExtraFee[1], out _extraChargeSingle))
                        {
                            extraCharge1 = _extraChargeSingle * decWaterTotalNumber;
                        }
                    }
                    else if (i == 1)
                    {
                        if (decimal.TryParse(strExtraFee[1], out _extraChargeSingle))
                        {
                            extraCharge2 = _extraChargeSingle * decWaterTotalNumber;
                        }
                    }
                }
            }

        }

        public void GetWaterFeeByMeterType(string waterMeterTypeId, decimal totalNumber, int intNotReadMonths, ref decimal waterTotalCharge, ref decimal extraCharge1, ref decimal extraCharge2)
        {
            if (!string.IsNullOrEmpty(waterMeterTypeId))
            {
                DataTable dt = new SqlServerHelper().GetDataTable("waterMeterType", "waterMeterTypeId='" + waterMeterTypeId + "'", "waterMeterTypeId");
                if (DataTableHelper.IsExistRows(dt))
                {
                    string _strTrapePriceString=dt.Rows[0]["trapezoidPrice"].ToString();
                    string _extraCharge=dt.Rows[0]["extraCharge"].ToString();

                    GetAvePrice(totalNumber, _strTrapePriceString, _extraCharge, intNotReadMonths, ref waterTotalCharge, ref extraCharge1, ref extraCharge2);
                }

            }
        }

        public bool LogWrite(string TaskID, string ResolveID, int PointSort, string loginId, string userName, int State, string UserOpinion, bool IsPass, bool IsGoBack, string IP, string ComputerName, string Matter)
        {
            string sqlstr = @"INSERT INTO ApproveLog (TaskID,ResolveID,PointSort,loginId,userName,State,UserOpinion,IsPass,IsGoBack,IP,ComputerName,Matter) VALUES 
(@TaskID,@ResolveID,@PointSort,@loginId,@userName,@State,@UserOpinion,@IsPass,@IsGoBack,@IP,@ComputerName,@Matter)";

               int count = DbHelperSQL.ExecuteSql(sqlstr,
                 new SqlParameter[] {
                new SqlParameter("@TaskID",TaskID),
              new SqlParameter("@ResolveID",ResolveID),
              new SqlParameter("@PointSort",PointSort),
              new SqlParameter("@loginId",loginId),
              new SqlParameter("@userName",userName),
              new SqlParameter("@State",State),
              new SqlParameter("@UserOpinion",UserOpinion),
              new SqlParameter("@IsPass",IsPass),
              new SqlParameter("@IsGoBack",IsGoBack),
              new SqlParameter("@IP",IP),
              new SqlParameter("@ComputerName",ComputerName),
                new SqlParameter("@Matter",Matter)
                });
            return count > 0 ? true : false;
        }

        public bool LogWrite(string TaskID, string ResolveID, int PointSort, int State, string UserOpinion, bool IsPass, bool IsGoBack, string Matter)
        {
            string loginId = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            string userName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            string IP = AppDomain.CurrentDomain.GetData("IP").ToString();
            string ComputerName = AppDomain.CurrentDomain.GetData("COMPUTERNAME").ToString();

            return LogWrite(TaskID, ResolveID, PointSort, loginId, userName, State, UserOpinion, IsPass, false, IP, ComputerName, Matter);
        }

        public bool LogWrite(Log_Model LM)
        {
            return LogWrite(LM.TaskID, LM.ResolveID, LM.PointSort, LM.State, LM.UserOpinion,LM.IsPass,LM.IsGoBack,LM.Matter);
        }

        public bool CheckIsAbate(string readMeterRecordId)
        {
            string sqlstr = @"SELECT SD FROM User_ChargeAbate WHERE readMeterRecordId=@readMeterRecordId AND State<>4";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr,
              new SqlParameter[] {
                new SqlParameter("@readMeterRecordId",readMeterRecordId)
                });

            return DataTableHelper.IsExistRows(dt) ? true : false;
        }

        public string GetWorkCodeByUserType(string TableID, string waterMeterTypeClassID)
        {
            string sqlstr = "SELECT WorkCode FROM WaterUserType_Approve WHERE TableID=@TableID AND waterMeterTypeClassID=@waterMeterTypeClassID AND State=1";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr,
              new SqlParameter[] {
                new SqlParameter("@TableID",TableID),
                 new SqlParameter("@waterMeterTypeClassID",waterMeterTypeClassID)
                });

            if (DataTableHelper.IsExistRows(dt))
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }

        }

        public bool CheckIsWaterPrice(string WATERUSERNO)
        {
            string sqlstr = @"SELECT SD FROM User_WaterPrice WHERE WATERUSERNO=@WATERUSERNO AND State IN (1,2)";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr,
              new SqlParameter[] {
                new SqlParameter("@WATERUSERNO",WATERUSERNO)
                });

            return DataTableHelper.IsExistRows(dt) ? true : false;
        }

        public bool IsExistWorkFlow(string TableID, string WaterMeterTypeClassID)
        {
            string sqlstr = @"SELECT WorkCode FROM WaterUserType_Approve WHERE TableID=@TableID AND WaterMeterTypeClassID=@WaterMeterTypeClassID";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr,
              new SqlParameter[] {
                new SqlParameter("@TableID",TableID),
                new SqlParameter("@WaterMeterTypeClassID",WaterMeterTypeClassID)
                });

            return DataTableHelper.IsExistRows(dt) ? true : false;
        }

        //public bool InsertWorkFlowSelect(Hashtable ht)
        //{
        //    string strsql = "INSERT INTO WaterUserType_Approve (TableID,WaterMeterTypeClassID,WorkCode) VALUES (@TableID,@WaterMeterTypeClassID,@WorkCode)";

        //    int count = DbHelperSQL.ExecuteSql(strsql,
        //        new SqlParameter[] {
        //        new SqlParameter("@TableID",ht["TableID"].ToString()),
        //        new SqlParameter("@WaterMeterTypeClassID",ht["WaterMeterTypeClassID"].ToString()),
        //        new SqlParameter("@WorkCode",ht["WorkCode"].ToString())               
        //        });

        //    return count > 0 ? true : false;
        //}

        //public bool UpdateWorkFlowSelect(Hashtable ht)
        //{
        //    string strsql = "UPDATE WaterUserType_Approve SET TableID=@TableID,WaterMeterTypeClassID=@WaterMeterTypeClassID,WorkCode=@WorkCode WHERE ApproveID=@ApproveID";

        //    int count = DbHelperSQL.ExecuteSql(strsql,
        //        new SqlParameter[] {
        //        new SqlParameter("@TableID",ht["TableID"].ToString()),
        //        new SqlParameter("@WaterMeterTypeClassID",ht["WaterMeterTypeClassID"].ToString()),
        //        new SqlParameter("@WorkCode",ht["WorkCode"].ToString()),
        //        new SqlParameter("@ApproveID",ht["ApproveID"].ToString())
        //        });

        //    return count > 0 ? true : false;
        //}


    }
}
