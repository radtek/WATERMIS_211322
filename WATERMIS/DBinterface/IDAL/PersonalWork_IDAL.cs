using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using DBinterface.Model;

namespace DBinterface.IDAL
{
   public interface PersonalWork_IDAL
    {
       DataTable GetDataTalbeWorkResolve();

       DataTable GetDataTalbeWorkOver();

       DataTable GetDataTalbeWorkScrap();

       DataTable GetDataTableApproveList(string TaskID);

       Hashtable GetMeter_Install_SingleInfos(string TaskID);

       Hashtable GetMeter_Install_PeccantInfos(string TaskID);

       bool GetAssemblyName(string ResolveID, ref string FrmAssemblyName, ref string FormName);

       bool GetAssemblyNameDetail(string ResolveID, ref string FrmAssemblyName, ref string FormName);

       DataTable GetDataTableLastApproveFee(string TaskID, string PointSort);

       int UpdateApprove_defalut(string tableName, string ResolveID, bool IsPass, string UserOpinion, string ip, string ComputerName, string PointSort, string TaskID, string Matter);

       int UpdateApprove_defalut(string tableName, string ResolveID, bool IsPass, string UserOpinion, string PointSort, string TaskID, string Matter);

       int UpdateApprove_Single_defalut(string ResolveID, bool IsPass, string UserOpinion, string ip, string ComputerName, string PointSort, string TaskID, string Matter);

       int UpdateApprove_Peccant_defalut(string ResolveID, bool IsPass, string UserOpinion, string ip, string ComputerName, string PointSort, string TaskID, string Matter);

       int UpdateApprove_Voided_ByTableName(string tableName, string ResolveID, string UserOpinion, string ip, string ComputerName, string TaskID);

       int UpdateApprove_Voided_ByTableName(string tableName, string ResolveID, string UserOpinion, string TaskID);

       int UpdateApprove_Voided(string ResolveID, string UserOpinion, string ip, string ComputerName, string TaskID);

       int UpdateApprove_Peccant_Voided(string ResolveID, string UserOpinion, string ip, string ComputerName, string TaskID);

       DataTable GetFeeItems(string ResolveID);

       bool IsHaveLastFeeItems(string TaskID, string PointSort);

       DataTable GetLastFeeItemsByDep(string ResolveID, int FeeID);

       DataTable GetAllChargePoint(string TaskID);

       DataTable GetChargePointItem(string TaskID, int PointSort, string DepartementID);

       DataTable GetLastFeeItems(string TaskID, string PointSort);

       Decimal GetLastFeeTotal(string TaskID, string PointSort);

       decimal GetTotalAbate(string TaskID, string PointSort);

       decimal GetUserPrestore(string TableName, string TaskID);

       string GetNewChargeID(string loginid);

       bool ApprovePrestore(Hashtable ht);

       bool ApprovePrestoreFinal(Hashtable ht);

       bool ApproveMeterOut(Hashtable ht);

       DataTable GetUserMaterByTaskID(string TaskID);

       bool Approve_Single_Append(string TaskID, string CHARGEID, string PRESTORERUNNINGACCOUNTID);

       Hashtable GetUserAllowRefund(string CHARGEID);

       bool GetUserExistRefund(string CHARGEID);

       int UpdateApprove_Refund_defalut(string ResolveID, bool IsPass, string UserOpinion, string PointSort, string TaskID, string Matter);

       int UpdateApprove_Refund_Voided(string ResolveID, string UserOpinion, string TaskID);

       bool IsExitWaterPriceNO(string waterUserNO);

       bool IsWorkTaskOver(string TableName, string TaskID);

       bool GetUserExistAbate(string readMeterRecordId);

       DataTable GetDepartMentFee(string TaskID, string PointSort);

       DataTable GetDepartMentFeeItems(string ResolveID);

       DataTable GetDepartMentFinalFeeItems(string ResolveID);

       decimal GetTotalFeeByPointSort(string TaskID, string PointSort);

       bool IsChargeOver(string TaskID, string LastPoingSort);

       DataTable GetDepartMentFeeFinal(string TaskID, string PointSort);

       decimal GetTotalFeeFinalByPointSort(string TaskID, string LastPoingSort);

       decimal GetTotalFeeYuCun(string TaskID, string LastPoingSort);

       DataTable GetDepartMentFeeFinalItems(string ResolveID);

       decimal GetDepartmentPrestore(string TaskID, int LastPoingSort, string DepartementID);

       decimal GetDepartmentPrestoreFinal(string TaskID, int LastPoingSort, string DepartementID);

       bool IsChargeOverFinal(string TaskID, string LastPoingSort);

       bool ApproveBudgetPrestore(Hashtable ht);

       bool ApproveFinalPrestore(Hashtable ht);

       DataTable GetMaintainType();

       Hashtable GetMaintainByTaskID(string TaskID);

       Hashtable GetWaterUserInfoByWaterUserNO(string waterUserNO);

       Hashtable GetMeter_Install_GroupInfos(string TaskID);

       DataTable GetMeter_Group_People(string GroupID, int Step);

       DataTable GetMeter_Group_People(string GroupID);

       string GetWaterUserTypeByID(string waterUserTypeId);

       string GetwaterMeterTypeByID(string waterMeterTypeId);

       bool IsAuthority(string loginId, string MenuID);

       bool IsAuthority(string MenuID);

       DataTable GetWaterBusiness(string strWhere);

       DataTable GetWaterBusinessSub(int MenuID);

       DataTable GetApproveCenter(string strWhere);

       DataTable GetApproveCenterSub(int MenuID);

       DataTable GetUserMeterInfoByTaskId(string TaskID);

       DataTable GetUserMeterInfoByTaskId(string tableName, string TaskID);

       bool SetTaskOver(string TableName, string TaskID);

       bool Approve_Peccant_Append(string TaskID);

       bool UserPrestoreRefund(string TaskID,string Memo);

       string GetTableNameByTaskID(string TaskID);

       bool CancelCharge(string TaskID, string ChargeID, string CANCELMEMO);

       void GetAvePrice(decimal decTotalNumber, string strTrapePriceString, string extraCharge, int intNotReadMonths, ref decimal waterTotalCharge, ref decimal extraCharge1, ref decimal extraCharge2);

       void GetWaterFeeByMeterType(string waterMeterTypeId, decimal totalNumber, int intNotReadMonths, ref decimal waterTotalCharge, ref decimal extraCharge1, ref decimal extraCharge2);

       bool LogWrite(string TaskID, string ResolveID, int PointSort, string loginId, string userName, int State, string UserOpinion, bool IsPass, bool IsGoBack, string IP, string ComputerName, string Matter);

       bool LogWrite(string TaskID, string ResolveID, int PointSort, int State, string UserOpinion, bool IsPass, bool IsGoBack, string Matter);

       bool LogWrite(Log_Model LM);

       bool CheckIsAbate(string readMeterRecordId);

       string GetWorkCodeByUserType(string TableID, string waterMeterTypeClassID);

       bool CheckIsWaterPrice(string WATERUSERNO);

       bool IsExistWorkFlow(string TableID, string WaterMeterTypeClassID);

       //bool InsertWorkFlowSelect(Hashtable ht);

       //bool UpdateWorkFlowSelect(Hashtable ht);

       string GetWaterMeterTypeIdByWaterMeterId(string waterMeterId);
    }
}
