using System;
using System.Collections.Generic;
using System.Text;

namespace BASEFUNCTION
{
    public class GETTABLEID
    {
        public string GetTableID(string strLogID, string strTableName)
        {
            int intLogID=strLogID.Length;
            string strSQL;
            object objGetID;
            string strReturnID = null;
            string strDate;
            Messages mes = new Messages();
            try
            {
                strDate = mes.GetDatetimeNow().ToString("yyyyMMdd");
                switch (strTableName.ToUpper())
                {
                    case "BASE_LOGIN"://职员表 as 0001
                        strSQL = "SELECT MAX(CAST(LOGINID AS INT)) FROM BASE_LOGIN";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                        strReturnID = strReturnID.PadLeft(4, '0');
                        return strReturnID;
                    //break;
                    case "BASE_DEPARTMENT"://部门表 as 00010001 logid 四位+编号四位
                        intLogID=intLogID+1;
                        strSQL = "SELECT MAX(SUBSTRING(DEPARTMENTID,"+intLogID+",4)) FROM BASE_DEPARTMENT WHERE DEPARTMENTID LIKE '" + strLogID + "%'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "0001";
                        else
                        {
                            if (objGetID.ToString() == "")
                            {
                                strReturnID = strLogID + "0001";
                                return strReturnID;
                            }
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        return strReturnID;
                    case "LOGINGROUP"://用户组表 as 0000 编号四位
                        strSQL = "SELECT MAX(CAST(groupId AS INT)) FROM LOGINGROUP";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "BASE_AREA"://区域表 as 0000 编号四位base_Pian
                        strSQL = "SELECT MAX(CAST(AREAID AS INT)) FROM BASE_AREA";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "BASE_PIAN"://区域表 as 0000 编号四位base_Pian
                        strSQL = "SELECT MAX(CAST(PIANID AS INT)) FROM BASE_PIAN";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "BASE_DUAN"://区域表 as 0000 编号四位
                        strSQL = "SELECT MAX(CAST(DUANID AS INT)) FROM BASE_DUAN";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "BASE_COMMUNITY"://区域表 as 0000 编号四位
                        strSQL = "SELECT MAX(CAST(COMMUNITYID AS INT)) FROM BASE_COMMUNITY";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "BASE_BANK"://银行列表 as 0000 编号四位
                        strSQL = "SELECT MAX(CAST(BANKID AS INT)) FROM BASE_BANK";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "WATERMETERPOSITION"://水表位置表 as 0000 编号四位
                        strSQL = "SELECT MAX(CAST(waterMeterPositionId AS INT)) FROM WATERMETERPOSITION";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "WATERUSERTYPE"://用户类型表 as 0000 编号四位
                        strSQL = "SELECT MAX(CAST(waterUserTypeId AS INT)) FROM WATERUSERTYPE";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "WATERMETERSIZE"://水表口径表 as 0000 编号四位
                        strSQL = "SELECT MAX(CAST(waterMeterSizeId AS INT)) FROM WATERMETERSIZE";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "WATERMETERTYPE"://水表口径表 as 0000 编号四位
                        strSQL = "SELECT MAX(CAST(waterMeterTypeId AS INT)) FROM WATERMETERTYPE";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "METERREADING"://抄表本表 as 0000 编号四位
                        strSQL = "SELECT MAX(CAST(meterReadingID AS INT)) FROM METERREADING";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                        }
                        return strReturnID;
                    case "WATERUSER"://水表用户表 as 00000001 编号八位
                        strSQL = "SELECT MAX(RIGHT(waterUserId,5)) FROM WATERUSER";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = "U00001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = "U"+strReturnID.PadLeft(5, '0');
                        }
                        return strReturnID;
                    case "WATERMETER"://水表用户表 as 00000001 编号八位
                        strSQL = "SELECT MAX(RIGHT(waterMeterId,2)) FROM WATERMETER WHERE LEFT(waterMeterId," + intLogID + ")='" + strLogID + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID+"01";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID =strLogID+ strReturnID.PadLeft(2, '0');
                        }
                        return strReturnID;
                    case "READMETERRECORD"://抄表表 as 20150411000001 编号八位
                        strSQL = "SELECT MAX(RIGHT(readMeterRecordId,6)) FROM READMETERRECORD WHERE LEFT(readMeterRecordId,12)='" + strDate +strLogID+ "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strDate+strLogID + "000001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strDate + strLogID + strReturnID.PadLeft(6, '0');
                        }
                        return strReturnID;
                    case "READMETERRECORDCANCEL"://抄表表 as 20150411000001 编号八位
                        strSQL = "SELECT MAX(RIGHT(readMeterRecordCancelId,6)) FROM READMETERRECORDCANCEL WHERE LEFT(readMeterRecordCancelId,8)='" + strDate + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strDate + "CJ000001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strDate + "CJ" + strReturnID.PadLeft(6, '0');
                        }
                        return strReturnID;
                    case "INFORMCANCELRECORD"://抄表表 as 20150411000001 编号八位
                        strSQL = "SELECT MAX(RIGHT(INFORMCANCELID,6)) FROM INFORMCANCELRECORD WHERE LEFT(INFORMCANCELID,8)='" + strDate + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strDate + "000001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strDate + strReturnID.PadLeft(6, '0');
                        }
                        return strReturnID;
                    case "WATERFEECHARGE"://抄表表 as 20150411SF000001 16位
                        if (intLogID == 4)
                        {
                            strSQL = "SELECT MAX(RIGHT(CHARGEID,6)) FROM WATERFEECHARGE WHERE LEFT(CHARGEID,12)='" + strDate + strLogID + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate+strLogID + "000001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate+strLogID + strReturnID.PadLeft(6, '0');
                            }
                        }
                        else
                        {
                            strSQL = "SELECT MAX(RIGHT(CHARGEID,6)) FROM WATERFEECHARGE WHERE LEFT(CHARGEID,8)='" + strDate + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + "000001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strReturnID.PadLeft(6, '0');
                            }
                        }
                        return strReturnID;
                    case "DAYCHECKPERSONAL"://抄表表 as 20150411SF000001 16位
                        if (intLogID == 4)
                        {
                            strSQL = "SELECT MAX(RIGHT(DAYCHECKID,3)) FROM DAYCHECKPERSONAL WHERE LEFT(DAYCHECKID,12)='" + strDate + strLogID + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + strLogID + "001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strLogID + strReturnID.PadLeft(3, '0');
                            }
                        }
                        else
                        {
                            strSQL = "SELECT MAX(RIGHT(DAYCHECKID,3)) FROM DAYCHECKPERSONAL WHERE LEFT(DAYCHECKID,8)='" + strDate + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + "001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strReturnID.PadLeft(3, '0');
                            }
                        }
                        return strReturnID;
                    case "SETTLEACCOUNTYS":
                        strSQL = "SELECT MAX(RIGHT(SETTLEACCOUNTSYSID,3)) FROM SETTLEACCOUNTYS WHERE LEFT(SETTLEACCOUNTSYSID,8)='" + strDate + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + "001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strReturnID.PadLeft(3, '0');
                            }
                            return strReturnID;
                    case "SETTLEACCOUNTSS":
                            strSQL = "SELECT MAX(RIGHT(SETTLEACCOUNTSSSID,3)) FROM SETTLEACCOUNTSS WHERE LEFT(SETTLEACCOUNTSSSID,8)='" + strDate + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + "001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strReturnID.PadLeft(3, '0');
                            }
                            return strReturnID;
                    case "MESSAGESEND"://抄表表 as 20150411SF000001 16位
                        if (intLogID == 4)
                        {
                            strSQL = "SELECT MAX(RIGHT(MESSAGESENDID,3)) FROM MESSAGESEND WHERE LEFT(MESSAGESENDID,12)='" + strDate + strLogID + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + strLogID + "001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strLogID + strReturnID.PadLeft(3, '0');
                            }
                        }
                        else
                        {
                            strSQL = "SELECT MAX(RIGHT(MESSAGESENDID,3)) FROM MESSAGESEND WHERE LEFT(MESSAGESENDID,8)='" + strDate + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + "001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strReturnID.PadLeft(3, '0');
                            }
                        }
                        return strReturnID;
                    case "MESSAGERECEIVE"://抄表表 as 20150411SF000001 16位
                        if (intLogID == 4)
                        {
                            strSQL = "SELECT MAX(RIGHT(MESSAGERECEIVEID,3)) FROM MESSAGERECEIVE WHERE LEFT(MESSAGERECEIVEID,12)='" + strDate + strLogID + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + strLogID + "001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strLogID + strReturnID.PadLeft(3, '0');
                            }
                        }
                        else
                        {
                            strSQL = "SELECT MAX(RIGHT(MESSAGERECEIVEID,3)) FROM MESSAGERECEIVE WHERE LEFT(MESSAGERECEIVEID,8)='" + strDate + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + "001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strReturnID.PadLeft(3, '0');
                            }
                        }
                        return strReturnID;
                    case "PRESTORERUNNINGACCOUNT"://抄表表 as 201504110001000001 18位
                        if (intLogID == 4)
                        {
                            strSQL = "SELECT MAX(RIGHT(PRESTORERUNNINGACCOUNTID,6)) FROM PRESTORERUNNINGACCOUNT WHERE LEFT(PRESTORERUNNINGACCOUNTID,12)='" + strDate + strLogID + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + strLogID + "000001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strLogID + strReturnID.PadLeft(6, '0');
                            }
                        }
                        else
                        {
                            strSQL = "SELECT MAX(RIGHT(PRESTORERUNNINGACCOUNTID,6)) FROM PRESTORERUNNINGACCOUNT WHERE LEFT(PRESTORERUNNINGACCOUNTID,8)='" + strDate + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + "000001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strReturnID.PadLeft(6, '0');
                            }
                        }
                        return strReturnID;
                    //break;
                    case "CHARGEINVOICEPRINT"://发票表 as 201512290001000001 18位
                        if (intLogID == 4)
                        {
                            strSQL = "SELECT MAX(RIGHT(CHARGEINVOICEPRINTID,6)) FROM CHARGEINVOICEPRINT WHERE LEFT(CHARGEINVOICEPRINTID,12)='" + strDate + strLogID + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + strLogID + "000001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strLogID + strReturnID.PadLeft(6, '0');
                            }
                        }
                        else
                        {
                            strSQL = "SELECT MAX(RIGHT(CHARGEINVOICEPRINTID,6)) FROM CHARGEINVOICEPRINT WHERE LEFT(CHARGEINVOICEPRINTID,8)='" + strDate + "'";
                            objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                            if (objGetID == null)
                                strReturnID = strDate + "000001";
                            else
                            {
                                strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                                strReturnID = strDate + strReturnID.PadLeft(6, '0');
                            }
                        }
                        return strReturnID;
                    case "WATERFEEREMIT"://发票表 as 20150411JM000001 16位
                        strSQL = "SELECT MAX(RIGHT(WATERFEEREMITID,6)) FROM WATERFEEREMIT WHERE LEFT(WATERFEEREMITID,8)='" + strDate + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strDate + "JM000001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strDate + "JM" + strReturnID.PadLeft(6, '0');
                        }
                        return strReturnID;
                    case "BASE_MATERIAL"://工器具表 as 0001000001 logid 四位+编号六位
                        strSQL = "SELECT MAX(RIGHT(MATERIALID,6)) FROM BASE_MATERIAL WHERE LEFT(MATERIALID," + intLogID + ")='" + strLogID + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "000001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(6, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        return strReturnID;
                    //break;
                    case "BASE_MATERIALCLASS"://工器具类别表 as 00010001 logid 四位+编号四位
                        strSQL = "SELECT MAX(RIGHT(MATERIALCLASSID,8)) FROM BASE_MATERIALCLASS WHERE LEFT(MATERIALCLASSID," + intLogID + ")='" + strLogID + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "00000001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(8, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        return strReturnID;
                        //break;
                    case "_DEP_OFFIC_FEESCLASS"://费用类别表 as 00010001 logid 四位+编号四位
                        strSQL = "SELECT MAX(RIGHT(FEESCLASSID,4)) FROM _DEP_OFFIC_FEESCLASS WHERE LEFT(FEESCLASSID," + intLogID + ")='" + strLogID + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        return strReturnID;
                        //break;
                    case "EXPERIMENT"://费用表 as 00010001 logid 四位+编号四位
                        strSQL = "SELECT MAX(RIGHT(EXPERIMENTID,4)) FROM EXPERIMENT WHERE LEFT(EXPERIMENTID,8)='" + strDate + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        break;
                    case "BASE_SUPPLIER"://工器具类别表 as 00010001 logid 四位+编号四位
                        strSQL = "SELECT MAX(RIGHT(SUPPLIERID,4)) FROM BASE_SUPPLIER WHERE LEFT(SUPPLIERID," + intLogID + ")='" + strLogID + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        return strReturnID;
                        //break;
                    case "MATERIALS"://工器具表 as 0001000001 logid 四位+编号六位
                        strSQL = "SELECT MAX(RIGHT(PRODUCTID,6)) FROM MATERIALS WHERE LEFT(PRODUCTID," + intLogID + ")='" + strLogID + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "000001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(6, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        return strReturnID;
                        //break;
                    case "_DEP_OFFIC_STOCKSIN"://入库表 as 0001001 logid 四位+编号三位
                        strSQL = "SELECT MAX(RIGHT(STOCKSINID,3)) FROM _DEP_OFFIC_STOCKSIN WHERE LEFT(STOCKSINID,8)='" + strDate + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(3, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        break;
                    case "_DEP_OFFICE_STOCKSOUT"://出库表 as 0001001 logid 四位+编号三位
                        strSQL = "SELECT MAX(RIGHT(STOCKSOUTID,3)) FROM _DEP_OFFICE_STOCKSOUT WHERE LEFT(STOCKSOUTID,8)='" + strDate + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(3, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        break;
                    case "_DEP_OFFICE_STOCKSOPERATERECORD"://库存修改表 as 0001001 logid 四位+编号三位
                        strSQL = "SELECT MAX(RIGHT(RECORDID,3)) FROM _DEP_OFFICE_STOCKSOPERATERECORD WHERE LEFT(RECORDID,8)='" + strDate + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(3, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        break;
                    case "WASTE"://报废表 as 201212240001000001 logid 四位+编号六位
                        strSQL = "SELECT MAX(RIGHT(WASTEID,3)) FROM WASTE WHERE LEFT(WASTEID,8)='" + strDate + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID + "001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(3, '0');
                            strReturnID = strLogID + strReturnID;
                        }
                        break;
                    case "STOCKSOUT"://出库表 as 0001000001 logid 四位+编号六位
                        int intLen = intLogID + 8;
                        strSQL = "SELECT MAX(RIGHT(STOCKSOUTID,4)) FROM STOCKSOUT WHERE LEFT(STOCKSOUTID,+" + intLen + ")='" +(strLogID+strDate) + "'";
                        objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                        if (objGetID == null)
                            strReturnID = strLogID +strDate+ "0001";
                        else
                        {
                            strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                            strReturnID = strReturnID.PadLeft(4, '0');
                            strReturnID = strLogID + strDate + strReturnID;
                        }
                        return strReturnID;
                    default:
                        strReturnID = null;
                        break;
                }
                strReturnID = mes.GetDatetimeNow().ToString("yyyyMMdd") + strReturnID;
                return strReturnID;
            }
            catch (Exception ex)
            {
                mes.GetErrorMes(ex);
                return "1111111100000000";
            }
        }
    }
}
