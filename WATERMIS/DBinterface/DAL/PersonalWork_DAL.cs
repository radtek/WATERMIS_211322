using System;
using DBinterface.IDAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Common.DotNetData;
using DBUtility;
using Common.WinDevices;

namespace DBinterface.DAL
{
    public class PersonalWork_DAL : PersonalWork_IDAL
    {
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

        public int UpdateApprove_defalut(string tableName ,string ResolveID, bool IsPass, string UserOpinion, string ip, string ComputerName, string PointSort, string TaskID)
        {

            string sqlstr =string.Format(@"DECLARE @ISOVER INT=1
DECLARE @NEXTSORT INT=0
SELECT  TOP 1 @NEXTSORT=PointSort FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort>@PointSort ORDER BY PointSort
SET XACT_ABORT ON
BEGIN TRAN
UPDATE Meter_WorkResolve SET IsPass=@IsPass,UserOpinion=@UserOpinion,AcceptUserID=@AcceptUserID,AcceptUser=@AcceptUser,AcceptDate=GETDATE(),IP=@IP,ComputerName=@ComputerName WHERE ResolveID=@ResolveID
SELECT @ISOVER=COUNT(1) FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@PointSort AND (IsPass IS NULL OR IsPass<>1)
if(@ISOVER=0)
begin
if(@NEXTSORT=0)
BEGIN
UPDATE Meter_WorkTask SET [State]=5, PointSort=PointSort+1,PointTime=GETDATE() WHERE TaskID=@TaskID AND PointSort=@PointSort
UPDATE {0} SET [State]=5 WHERE TaskID=@TaskID
END
ELSE
BEGIN
UPDATE Meter_WorkTask SET PointSort=@NEXTSORT,PointTime=GETDATE() WHERE TaskID=@TaskID AND PointSort=@PointSort
END
end
COMMIT TRAN", tableName);

            SqlParameter[] cmdParms = new SqlParameter[]{
            new SqlParameter("@ResolveID",ResolveID),
            new SqlParameter("@IsPass",IsPass?1:0),
            new SqlParameter("@UserOpinion",UserOpinion),
            new SqlParameter("@AcceptUserID",AppDomain.CurrentDomain.GetData("LOGINID").ToString()),
            new SqlParameter("@AcceptUser",AppDomain.CurrentDomain.GetData("USERNAME").ToString()),
            new SqlParameter("@IP",ip),
            new SqlParameter("@ComputerName",ComputerName),
            new SqlParameter("@PointSort",PointSort),
            new SqlParameter("@TaskID",TaskID)
            };

            return DbHelperSQL.ExecuteSql(sqlstr, cmdParms);
        }
        public int UpdateApprove_defalut(string tableName, string ResolveID, bool IsPass, string UserOpinion, string PointSort, string TaskID)
        {
            string ComputerName = new Computer().ComputerName;
            string ip = new Computer().IpAddress;
            return UpdateApprove_defalut(tableName, ResolveID, IsPass, UserOpinion, ip, ComputerName, PointSort, TaskID);
         
        }
        public int UpdateApprove_Single_defalut(string ResolveID, bool IsPass, string UserOpinion, string ip, string ComputerName, string PointSort, string TaskID)
        {
            return UpdateApprove_defalut("Meter_Install_Single", ResolveID, IsPass, UserOpinion, ip, ComputerName, PointSort, TaskID);
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

        public int UpdateApprove_Voided_ByTableName(string tableName,string ResolveID, string UserOpinion, string ip, string ComputerName, string TaskID)
        {
            string sqlstr = string.Format(@" SET XACT_ABORT ON
BEGIN TRAN
UPDATE Meter_WorkTask SET State=4 WHERE TaskID=@TaskID
UPDATE {0} SET State=4 WHERE TaskID=@TaskID
UPDATE Meter_WorkResolve SET MakeVoided=1,IsPass=0,UserOpinion=@UserOpinion,AcceptUserID=@AcceptUserID,AcceptUser=@AcceptUser,IP=@IP,ComputerName=@ComputerName WHERE ResolveID=@ResolveID
COMMIT TRAN",tableName);

            SqlParameter[] cmdParms = new SqlParameter[]{
            new SqlParameter("@ResolveID",ResolveID),
            new SqlParameter("@UserOpinion",UserOpinion),
            new SqlParameter("@AcceptUserID",AppDomain.CurrentDomain.GetData("LOGINID").ToString()),
            new SqlParameter("@AcceptUser",AppDomain.CurrentDomain.GetData("USERNAME").ToString()),
            new SqlParameter("@IP",ip),
            new SqlParameter("@ComputerName",ComputerName),
            new SqlParameter("@TaskID",TaskID)
            };

            return DbHelperSQL.ExecuteSql(sqlstr, cmdParms);
        }

        public int UpdateApprove_Voided_ByTableName(string tableName, string ResolveID, string UserOpinion, string TaskID)
        {
            string ComputerName = new Computer().ComputerName;
            string ip = new Computer().IpAddress;
            return UpdateApprove_Voided_ByTableName(tableName, ResolveID, UserOpinion, ip, ComputerName, TaskID);
        }

        public int UpdateApprove_Voided(string ResolveID, string UserOpinion, string ip, string ComputerName, string TaskID)
        {
            return UpdateApprove_Voided_ByTableName("Meter_Install_Single",ResolveID, UserOpinion, ip, ComputerName, TaskID);

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

        public DataTable GetFeeItems(string ResolveID)
        {
            string sqlstr = "SELECT FeeID,FeeItem,Fee,DefaultValue,IsFinal  FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID ORDER BY Sort";

            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@ResolveID", ResolveID) });
        }

        public bool IsHaveLastFeeItems(string TaskID, string PointSort)
        {
            string strsql = "SELECT COUNT(1) FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<@PointSort";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort) });

            int Count = int.Parse(dt.Rows[0][0].ToString());
            return Count > 0 ? true : false;
        }
        //RONG 2016-10-13
        public string GetLastFeeItemsByDep(string ResolveID, int FeeID)
        {
            string FeeValue = string.Empty;
            string strsql = @"DECLARE @TaskID NVARCHAR(50)
DECLARE @PointSort INT
DECLARE @DepartementID NVARCHAR(50)
SELECT @TaskID=TaskID,@PointSort=PointSort,@DepartementID=DepartementID FROM Meter_WorkResolve MW WHERE ResolveID=@ResolveID
SELECT FEE FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.DepartementID=@DepartementID AND MWR.TaskID=@TaskID AND PointSort<@PointSort AND MWF.FeeID=@FeeID  ORDER BY PointSort DESC";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@ResolveID", ResolveID), new SqlParameter("@FeeID", FeeID) });
            if (DataTableHelper.IsExistRows(dt))
            {
                FeeValue = dt.Rows[0][0].ToString();
            }
            return FeeValue;
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

            return new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] {new SqlParameter("@TaskID",TaskID),new SqlParameter("@PointSort",PointSort) });
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
                if (decimal.TryParse(Abate,out Abates))
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
            string strSql = "SELECT TOP 1 right(chargeID,6) AS chargeID FROM Meter_Charge WHERE convert(char(10),LEFT(CHARGEID,8),120)=DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND SUBSTRING(CHARGEID,11,4)=@LOGINID ORDER BY right(chargeID,6) desc";

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
(@CHARGEID,@TaskID,@CHARGEBCSS,@CHARGEBCYS,@TOTALCHARGE,@Abate,@prestore,@FeeList,@CHARGETYPEID,@CHARGEClASS,@CHARGEWORKERID,@CHARGEWORKERNAME,@ReceiptPrintSign,1,GETDATE(),@RECEIPTNO,@POSRUNNINGNO,@Memo)
UPDATE Meter_WorkResolveFee SET State=1,CHARGEWORKERID=@CHARGEWORKERID,CHARGEWORKERNAME=@CHARGEWORKERNAME,ChargeDate=GETDATE(),ChargeID=@CHARGEID WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPointSort)
UPDATE {0} SET prestore=@Prestore WHERE TaskID=@TaskID
COMMIT TRAN", ht["TableName"].ToString());

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
(@CHARGEID,@TaskID,@CHARGEBCSS,@CHARGEBCYS,@TOTALCHARGE,@Abate,@prestore,@FeeList,@CHARGETYPEID,@CHARGEClASS,@CHARGEWORKERID,@CHARGEWORKERNAME,@INVOICEPRINTSIGN,GETDATE(),@InvoiceNO,@POSRUNNINGNO,@Memo)
UPDATE Meter_WorkResolveFee SET State=1,CHARGEWORKERID=@CHARGEWORKERID,CHARGEWORKERNAME=@CHARGEWORKERNAME,ChargeDate=GETDATE(),ChargeID=@CHARGEID WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPointSort)
UPDATE {0} SET prestore=@Prestore WHERE TaskID=@TaskID
COMMIT TRAN", ht["TableName"].ToString());

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
UPDATE Meter SET MeterState=1,ModifyDate=GETDATE(),ModifyUser=@ModifyUser WHERE waterMeterSerialNumber IN ({0})
COMMIT TRAN", ht["waterMeterSerialNumber"].ToString());

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

        public bool Approve_Single_Append(string TaskID)
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

            string strsql = @"DECLARE @waterUserId NVARCHAR(50)=''
DECLARE @ISEXIT INT=0
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
waterUserPeopleCount,meterReadingID,meterReadingPageNo,waterUserTypeId,GETDATE(),waterUserHouseType,agentsign,
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
,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,isSummaryMeter,waterMeterParentId,STARTUSEDATETIME,MEMO
,waterMeterState,IsReverse,WATERMETERLOCKNO) 
SELECT waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,
waterMeterSizeId,waterMeterTypeId,ISUSECHANGE,CHANGEMONTH,waterMeterTypeIdChange,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,
waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,isSummaryMeter,waterMeterParentId,
STARTUSEDATETIME,MEMO,waterMeterState,IsReverse,WATERMETERLOCKNO FROM Meter WHERE MeterID IN (SELECT MeterID FROM Meter_User WHERE TaskID=@TaskID)
INSERT INTO User_Append (TaskID,waterUserNO,waterUserName) SELECT TaskID,waterUserNO,waterUserName FROM Meter_Install_Single WHERE TaskID=@TaskID
COMMIT TRAN";
            int count = DbHelperSQL.ExecuteSql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            return count > 0 ? true : false;

        }

        //增加预存单号ID、地址、账户余额字段 ByRen
        public Hashtable GetUserAllowRefund(string CHARGEID)
        {
            string sqlstr = @"SELECT VV.CHARGEID,VV.CHARGEBCSS AS CHARGEBCSS_IN,VW.WATERUSERNO,VW.WATERUSERNAME AS ApplyUser,VW.waterPhone,
VV.PRESTORERUNNINGACCOUNTID,VW.waterUserAddress,VW.prestore 
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

        public int UpdateApprove_Refund_defalut(string ResolveID, bool IsPass, string UserOpinion, string PointSort, string TaskID)
        {
            string ComputerName = new Computer().ComputerName;
            string ip = new Computer().IpAddress;
            return UpdateApprove_defalut("User_Refund", ResolveID, IsPass, UserOpinion, ip, ComputerName, PointSort, TaskID);
        }

        public int UpdateApprove_Refund_Voided(string ResolveID, string UserOpinion,string TaskID)
        {
            string ComputerName = new Computer().ComputerName;
            string ip = new Computer().IpAddress;
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
(SELECT COUNT(1) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID) AS ItemsCount,
(SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID) AS TotalFee,
(SELECT SUM(State) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID) AS STATE,
(SELECT TOP 1 IsFinal FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID) AS IsFinal
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
            string strsql = @"SELECT *,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0) AS DepartTotalFee,(SELECT SUM (Fee) FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND State<>1) AS FinalTotalFee FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID AND FEE>0 AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)";

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
            
            return int.Parse(dt.Rows[0][0].ToString())>0?false:true;
        }

        public DataTable GetDepartMentFeeFinal(string TaskID, string PointSort)
        {
            string strsql = @"DECLARE @LastPoingSort INT=0
SELECT TOP 1 @LastPoingSort=PointSort FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<@PointSort ORDER BY PointSort DESC
SELECT * FROM 
(SELECT *,
(SELECT COUNT(1) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)) AS ItemsCount,
(SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)) AS TotalFee,
(SELECT SUM(State) FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)) AS STATE,
(SELECT TOP 1 IsFinal FROM Meter_WorkResolveFee WHERE ResolveID=T.ResolveID) AS IsFinal
FROM 
(SELECT DISTINCT MWR.DepartementID,BD.departmentName,MWR.ResolveID,MWR.PointSort AS LastPointSort FROM base_department BD,Meter_WorkResolve MWR WHERE BD.departmentID=MWR.DepartementID AND MWR.TaskID=@TaskID AND PointSort=@LastPoingSort) T) M
WHERE ItemsCount>0 AND TotalFee>0";

            return new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@PointSort", PointSort) });
        }

        public decimal GetTotalFeeFinalByPointSort(string TaskID, string LastPoingSort)
        {
            decimal totalfee = 0m;
            string strsql = "SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPoingSort) AND FEE>0 AND FeeID NOT IN  (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(strsql, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", LastPoingSort) });
            if (DataTableHelper.IsExistRows(dt))
            {
                totalfee = decimal.Parse(dt.Rows[0][0].ToString());
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

            if (Decimal.TryParse(dt.Rows[0][0].ToString(),out DepertmentPrestore))
            {
               
            }
            return DepertmentPrestore;
        }

        public decimal GetDepartmentPrestoreFinal(string TaskID, int LastPoingSort, string DepartementID)
        {
            decimal DepertmentPrestore = 0m;
            string sqlstr = @"SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE State=1 AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1) AND ResolveID IN (SELECT ResolveID FROM Meter_WorkResolve WHERE PointSort<@LastPoingSort AND TaskID=@TaskID AND DepartementID=@DepartementID)";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", LastPoingSort), new SqlParameter("@DepartementID", DepartementID) });

            if (Decimal.TryParse(dt.Rows[0][0].ToString(), out DepertmentPrestore))
            {

            }
            return DepertmentPrestore;
        }

        public bool IsChargeOverFinal(string TaskID, string LastPoingSort)
        {
            string strsql = @"SELECT COUNT(1) FROM Meter_WorkResolveFee WHERE ResolveID IN 
(SELECT ResolveID FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=@LastPoingSort) 
AND FEE>0 AND State<>1 AND ChargeID <>'' AND FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)";
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
(@CHARGEID,@TaskID,@CHARGEBCSS,@CHARGEBCYS,@TOTALCHARGE,@prestore,@FeeList,@CHARGETYPEID,@CHARGEClASS,@CHARGEWORKERID,@CHARGEWORKERNAME,@ReceiptPrintSign,1,GETDATE(),@RECEIPTNO,@POSRUNNINGNO,@Memo)
UPDATE Meter_WorkResolveFee SET State=1,CHARGEWORKERID=@CHARGEWORKERID,CHARGEWORKERNAME=@CHARGEWORKERNAME,ChargeDate=GETDATE(),ChargeID=@CHARGEID WHERE ResolveID =@ResolveID
UPDATE {0} SET prestore=@Prestore WHERE TaskID=@TaskID
COMMIT TRAN", ht["TableName"].ToString());

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
(@CHARGEID,@TaskID,@CHARGEBCSS,@CHARGEBCYS,@TOTALCHARGE,@Abate,@prestore,@FeeList,@CHARGETYPEID,@CHARGEClASS,@CHARGEWORKERID,@CHARGEWORKERNAME,@ReceiptPrintSign,1,GETDATE(),@RECEIPTNO,@POSRUNNINGNO,@Memo)
UPDATE Meter_WorkResolveFee SET State=1,CHARGEWORKERID=@CHARGEWORKERID,CHARGEWORKERNAME=@CHARGEWORKERNAME,ChargeDate=GETDATE(),ChargeID=@CHARGEID WHERE ResolveID =@ResolveID
UPDATE {0} SET prestore=@Prestore WHERE TaskID=@TaskID
COMMIT TRAN", ht["TableName"].ToString());

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
          return  new SqlServerHelper().GetDateTableBySql("SELECT MaintainType,MaintainTypeID FROM Meter_MaintainType ORDER BY MaintainTypeID");
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

        public DataTable GetMeter_Group_People(string GroupID)
        {
           // return new SqlServerHelper().GetDataTable("Meter_Group_People", "GroupID='"+GroupID+"'", "waterMeterTypeId");
            string sqlstr="SELECT * FROM Meter_Group_People MGP,waterMeterType MT,waterUserType UT,waterUserHouseType UHT	WHERE MGP.waterMeterTypeId=MT.waterMeterTypeId AND MGP.waterUserTypeId=UT.waterUserTypeId AND MGP.waterUserHouseTypeID=UHT.waterUserHouseTypeID AND GroupID=@GroupID";
            return new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@GroupID", GroupID) });
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
            if (int.Parse(dt.Rows[0][0].ToString())>0)
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
    }
}
