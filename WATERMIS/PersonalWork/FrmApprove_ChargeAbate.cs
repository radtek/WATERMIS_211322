using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;
using Microsoft.VisualBasic;
using BASEFUNCTION;

namespace PersonalWork
{
    public partial class FrmApprove_ChargeAbate : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;
        private bool skip = false;

        private string strLogID;
        private string strRealName;
        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        public FrmApprove_ChargeAbate()
        {
            InitializeComponent();
        }

        private void FrmApprove_ChargeAbate_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            #region //2017-2-22 RONG
            bool IsAllowEdit = false;
            if (ht.Contains("Edit"))
            {
                if (bool.TryParse(ht["Edit"].ToString(), out IsAllowEdit))
                {

                }
            }
            Btn_Submit.Enabled = IsAllowEdit;
            Btn_Voided.Enabled = IsAllowEdit;
            #endregion
            BindCombox();
            InitData();
            InitView();

            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            {
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            }
            else
            {
                MessageBox.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }
        }

        private void BindCombox()
        {
           DataTable dt = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterTypeid, dt, "waterMeterTypeValue", "waterMeterTypeId");

            dt = new SqlServerHelper().GetDataTable("waterUserType", "", "waterUserTypeId");
            ControlBindHelper.BindComboBoxData(this.waterUserTypeId, dt, "waterUserTypeName", "waterUserTypeId");
        }

        private void InitData()
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("User_ChargeAbate", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);
            object obj = ht["READMETERRECORDYEARANDMONTH"];
            if (Information.IsDate(obj))
                readMeterRecordYearAndMonth.Text = Convert.ToDateTime(obj).ToString("yyyy-MM-01");
        }

        private void InitView()
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();

                if (ht["MAKESKIP"] != null && ht["MAKEPOINTID"] != null)//是否显示跳转
                {
                    skip = (bool)ht["MAKESKIP"];
                    if (skip)
                    {
                        IsSkip.Visible = true;
                        LB_GoPointID.Visible = true;
                        CB_GoPointID.Visible = true;
                        string sqlstr = string.Format("SELECT PointName,PointSort  FROM Meter_WorkPoint WHERE WorkFlowID='{0}' AND PointSort IN ({1}) ORDER BY PointSort", ht["WORKFLOWID"].ToString(), ht["GOPOINTID"].ToString());
                        DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                        ControlBindHelper.BindComboBoxData(this.CB_GoPointID, dt, "PointName", "PointSort");
                    }
                }
                if (!string.IsNullOrEmpty(ht["ISVOIDED"].ToString()))//是否显示报废
                {
                    bool isvisable = false;
                    if (bool.TryParse(ht["ISVOIDED"].ToString(), out isvisable))
                        Btn_Voided.Visible = isvisable;
                }
            }

        }

        private void Btn_Voided_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            Btn_Voided.Enabled = false;
            int count = sysidal.UpdateApprove_Voided_ByTableName("User_ChargeAbate", ResolveID, UserOpinion.Text.Trim(), TaskID);
            if (count > 0)
            {
                MessageBox.Show("作废完成！");
            }
            else
            {
                MessageBox.Show("作废失败！");
                Btn_Submit.Enabled = true;
                Btn_Voided.Enabled = true;
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;

            string Matter = string.Format("【费用减免】-用户名：{0}；用户号：{1}；地址：{2}；减免月份：{3}；原水量：{6}；新水量：{7}；减免金额：{4}；减免原因：{5}", waterUserName.Text, WATERUSERNO.Text, waterUserAddress.Text, readMeterRecordYearAndMonth.Text, AbateDescribe.Text, LB_Abate.Text, OldTotalNumber.Text, NewTotalNumber.Text);
            int count = sysidal.UpdateApprove_defalut("User_ChargeAbate", ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), PointSort, TaskID, Matter);
            if (count > 0)
            {

                if (sysidal.IsWorkTaskOver("User_ChargeAbate", TaskID))//获取审批状态，如果是Meter_WorkTask.state=5 和User_WaterPrice.state=5,说明审批流程走完
                {
                    try
                    {
                        bool IsChargeAbate = false;

                        //===================================================================================减免水费
                        //返回bool类型

                        #region 20160909 ByRen

                        //增加台账及冲减明细表字段AbateMoney(减免金额)
                        //ALTER TABLE readMeterRecord ADD AbateMoney decimal(18,2) default 0
                        //ALTER TABLE readMeterRecordCancel ADD AbateMoney decimal(18,2) default 0

                        string strChargeState = "1", strTrapePriceString = "", strExtraCharge = "", strChargeID = "";
                        decimal waterTotalCharge = 0, extraCharge1 = 0, extraCharge2 = 0, decPrestore = 0, decQFSum = 0, decTotalChargeEnd = Convert.ToDecimal(totalChargeEND.Text);
                        int intNotReadMonths = 1, intTotalNumber = Convert.ToInt32(NewTotalNumber.Text);
                        DateTime dtNow = mes.GetDatetimeNow();

                        int intRows = 0;//水表变更语句执行影响的行数；

                        string strSQL = string.Format(@"SELECT * FROM V_WATERUSERAREARAGE WHERE waterUserId='{0}'", WATERUSERNO.Text);
                        DataTable dtWaterUser = new SqlServerHelper().GetDateTableBySql(strSQL);
                        if (dtWaterUser.Rows.Count > 0)
                        {
                            object obj = dtWaterUser.Rows[0]["prestore"];
                            if (Information.IsNumeric(obj))
                                decPrestore = Convert.ToDecimal(obj);

                            obj = dtWaterUser.Rows[0]["TOTALFEE"];
                            if (Information.IsNumeric(obj))
                                decQFSum = Convert.ToDecimal(obj);
                        }

                        strSQL = string.Format(@"SELECT chargeState,trapezoidPrice,extraCharge,NotReadMonthCount,CHARGEID FROM readMeterRecord WHERE readMeterRecordId='{0}'", readMeterRecordId.Text);
                        DataTable dtReadMeterRecord = new SqlServerHelper().GetDateTableBySql(strSQL);
                        if (dtReadMeterRecord.Rows.Count > 0)
                        {
                            object obj = dtReadMeterRecord.Rows[0]["trapezoidPrice"];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strTrapePriceString = obj.ToString();
                            }
                            obj = dtReadMeterRecord.Rows[0]["extraCharge"];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strExtraCharge = obj.ToString();
                            }
                            obj = dtReadMeterRecord.Rows[0]["NotReadMonthCount"];
                            if (Information.IsNumeric(obj))
                            {
                                intNotReadMonths = Convert.ToInt16(obj);
                            }
                            obj = dtReadMeterRecord.Rows[0]["CHARGEID"];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strChargeID = obj.ToString();
                            }

                            //获取水费等信息
                            sysidal.GetAvePrice(intTotalNumber, strTrapePriceString, strExtraCharge, intNotReadMonths, ref waterTotalCharge, ref extraCharge1, ref extraCharge2);

                            obj = dtReadMeterRecord.Rows[0]["chargeState"];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strChargeState = obj.ToString();
                            }
                            if (strChargeState == "3")
                            {
                                #region 已收费的抄表记录，需要先红冲此收费记录，然后生成一条新的抄表记录
                                string strReadMeterRecordID = GETTABLEID.GetTableID(strLogID, "READMETERRECORD");
                                string strReadMeterRecordIDNew = (Convert.ToInt64(strReadMeterRecordID) + 1).ToString();

                                string ChargeID = GETTABLEID.GetTableID(strLogID, "WATERFEECHARGE");
                                string ChargeIDNew = (Convert.ToInt64(ChargeID) + 1).ToString();

                                string strSQLExcute = string.Format(@"BEGIN TRAN
INSERT INTO [readMeterRecord]([readMeterRecordId],[readMeterRecordIdLast],[waterMeterId],[waterMeterNo]
                                            ,[lastNumberYearMonth],[waterMeterLastNumber],[waterMeterEndNumber],SUBMETERNUMBER,[totalNumber],[totalNumberDescribe],[avePrice]
                                            ,[avePriceDescribe],[waterTotalCharge],[extraChargePrice1],[extraCharge1],[extraChargePrice2],[extraCharge2],[extraChargePrice3]
                                            ,[extraCharge3],[extraChargePrice4],[extraCharge4],[extraChargePrice5],[extraCharge5],[extraChargePrice6],[extraCharge6]
                                            ,[extraChargePrice7],[extraCharge7],[extraChargePrice8],[extraCharge8],[extraTotalCharge],[trapezoidPrice],[extraCharge]
                                            ,[totalCharge],[OVERDUEMONEY],[WATERFIXVALUE],[readMeterRecordYear],[readMeterRecordMonth],
                                            readMeterRecordYearAndMonth,initialReadMeterMesDateTime,[readMeterRecordDate],[waterMeterPositionName]
                                            ,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName],[waterMeterProduct],[waterMeterSerialNumber]
                                            ,[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName],[checkState],[checkDateTime]
                                            ,[checker],[chargeState],[chargeID],[waterUserId],[waterUserNO],[waterUserName],waterUserNameCode,[waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,waterPhone,[waterUserAddress],[waterUserPeopleCount]
                                            ,[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
                                            ,[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber] ,[memo],[WATERUSERQQYE],[WATERUSERJSYE])

                                            SELECT '{0}','{1}',[waterMeterId],[waterMeterNo]
                                            ,[lastNumberYearMonth],[waterMeterEndNumber],[waterMeterLastNumber],0-SUBMETERNUMBER,0-[totalNumber],[totalNumberDescribe],[avePrice]
                                            ,[avePriceDescribe],0-[waterTotalCharge],[extraChargePrice1],0-[extraCharge1],[extraChargePrice2],0-[extraCharge2],[extraChargePrice3]
                                            ,0-[extraCharge3],[extraChargePrice4],0-[extraCharge4],[extraChargePrice5],0-[extraCharge5],[extraChargePrice6],0-[extraCharge6]
                                            ,[extraChargePrice7],0-[extraCharge7],[extraChargePrice8],0-[extraCharge8],0-[extraTotalCharge],[trapezoidPrice],[extraCharge]
                                            ,0-[totalCharge],0-[OVERDUEMONEY],[WATERFIXVALUE],NULL,NULL,'{2}',NULL,'{2}',[waterMeterPositionName]
                                            ,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName],
                                            [waterMeterProduct],[waterMeterSerialNumber],[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName],
                                            [checkState],'{2}','{3}','3','{4}',[waterUserId],[waterUserNO],[waterUserName],waterUserNameCode,
                                            [waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,[waterPhone],[waterUserAddress],[waterUserPeopleCount]
                                            ,[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
                                            ,[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber] ,'红冲台账:{1}',{5}-{15},{5}-{15}+[totalCharge] 
                                            FROM readMeterRecord WHERE readMeterRecordId='{1}'

                                            INSERT INTO WATERFEECHARGE(CHARGEID,TOTALNUMBERCHARGE,EXTRACHARGECHARGE1,EXTRACHARGECHARGE2,
                            WATERTOTALCHARGE,EXTRATOTALCHARGE,TOTALCHARGE,OVERDUEMONEY,CHARGETYPEID,CHARGEClASS,CHARGEBCYS,CHARGEBCSS,CHARGEYSQQYE,
                            CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME,INVOICEPRINTSIGN,RECEIPTPRINTCOUNT,MEMO)
                            SELECT '{4}',0-TOTALNUMBERCHARGE,0-EXTRACHARGECHARGE1,0-EXTRACHARGECHARGE2,
                            0-WATERTOTALCHARGE,0-EXTRATOTALCHARGE,0-TOTALCHARGE,0-OVERDUEMONEY,CHARGETYPEID,'4',0-CHARGEBCYS,0,{5},CHARGEBCYS,{5}+CHARGEBCYS,
                       CHARGEWORKERID,CHARGEWORKERNAME,'{2}',0,0,NULL FROM WATERFEECHARGE WHERE CHARGEID='{7}'

UPDATE WATERUSER SET prestore={5}+{8} WHERE WATERUSERID='{9}' 

                            INSERT INTO [readMeterRecord]([readMeterRecordId],[readMeterRecordIdLast],[waterMeterId],[waterMeterNo]
                                            ,[lastNumberYearMonth],[waterMeterLastNumber],[waterMeterEndNumber],SUBMETERNUMBER,[totalNumber],[totalNumberDescribe],[avePrice]
                                            ,[avePriceDescribe],[waterTotalCharge],[extraChargePrice1],[extraCharge1],[extraChargePrice2],[extraCharge2],[extraChargePrice3]
                                            ,[extraCharge3],[extraChargePrice4],[extraCharge4],[extraChargePrice5],[extraCharge5],[extraChargePrice6],[extraCharge6]
                                            ,[extraChargePrice7],[extraCharge7],[extraChargePrice8],[extraCharge8],[extraTotalCharge],[trapezoidPrice],[extraCharge]
                                            ,[totalCharge],[OVERDUEMONEY],[WATERFIXVALUE],readMeterRecordYearAndMonth,initialReadMeterMesDateTime,[readMeterRecordDate],[waterMeterPositionName]
                                            ,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName],[waterMeterProduct],[waterMeterSerialNumber]
                                            ,[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName],[checkState],[checkDateTime]
                                            ,[checker],[chargeState],[chargeID],[waterUserId],[waterUserNO],[waterUserName],waterUserNameCode,[waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,waterPhone,[waterUserAddress],[waterUserPeopleCount]
                                            ,[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
                                            ,[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber] ,[memo],[WATERUSERQQYE],[WATERUSERJSYE]) 

                                            SELECT '{10}','',[waterMeterId],[waterMeterNo]
                                            ,[lastNumberYearMonth],[waterMeterEndNumber] - {11},[waterMeterEndNumber],0,{11},NULL,NULL
                                            ,NULL,{12},[extraChargePrice1],{13},[extraChargePrice2],{14},[extraChargePrice3]
                                            ,[extraCharge3],[extraChargePrice4],[extraCharge4],[extraChargePrice5],[extraCharge5],[extraChargePrice6],[extraCharge6]
                                            ,[extraChargePrice7],[extraCharge7],[extraChargePrice8],[extraCharge8],{13}+{14},[trapezoidPrice],[extraCharge]
                                            ,{12}+{13}+{14},0,[WATERFIXVALUE],'{2}',NULL,'{2}',[waterMeterPositionName]
                                            ,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName],
                                            [waterMeterProduct],[waterMeterSerialNumber],[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName],
                                            '1',GETDATE(),'{3}','1',NULL,[waterUserId],[waterUserNO],[waterUserName],waterUserNameCode,
                                            [waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,[waterPhone],[waterUserAddress],[waterUserPeopleCount]
                                            ,[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
                                            ,[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber] ,NULL,{5}+{8}-{15},{5}+{8}-{15}-{12}-{13}-{14} 
 FROM readMeterRecord WHERE readMeterRecordId='{1}'
COMMIT TRAN",
                                strReadMeterRecordID, readMeterRecordId.Text, dtNow, strRealName, ChargeID, decPrestore, strLogID, strChargeID, decTotalChargeEnd, WATERUSERNO.Text,
                                strReadMeterRecordIDNew, intTotalNumber, waterTotalCharge, extraCharge1, extraCharge2,decQFSum);

                                intRows = new SqlServerHelper().ExcuteSql(strSQLExcute);
                                #endregion
                            }
                            else if (strChargeState == "2")
                            {
                                mes.Show("该抄表记录为挂账单据，无法执行减免操作!");
                            }
                            else if (strChargeState == "1")
                            {
                                DateTime dtReadMeterMonth = Convert.ToDateTime(readMeterRecordYearAndMonth.Text);
                                int intMonth = dtNow.Year * 12 + dtNow.Month - dtReadMeterMonth.Year * 12 - dtReadMeterMonth.Month;
                                if (intMonth > 0)
                                {
                                    #region 未收费并且抄表月份不是当月的,需要先将历史抄表记录收费并且红冲，然后再生成一条新的抄表记录
                                    string strReadMeterRecordID = GETTABLEID.GetTableID(strLogID, "READMETERRECORD");
                                    string strReadMeterRecordIDNew = (Convert.ToInt64(strReadMeterRecordID) + 1).ToString();

                                    string ChargeID = GETTABLEID.GetTableID(strLogID, "WATERFEECHARGE");
                                    string ChargeIDNew = (Convert.ToInt64(ChargeID) + 1).ToString();

                                    string strSQLExcute = string.Format(@"

BEGIN TRAN
DECLARE @TotalNumber INT=0
DECLARE @waterTotalCharge DECIMAL(18,2)=0
DECLARE @extraCharge1 DECIMAL(18,2)=0
DECLARE @extraCharge2 DECIMAL(18,2)=0
DECLARE @extraTotalCharge DECIMAL(18,2)=0
DECLARE @totalCharge DECIMAL(18,2)=0
DECLARE @Prestore DECIMAL(18,2)=0
DECLARE @QFZJ DECIMAL(18,2)=0

SELECT @Prestore=Prestore FROM waterUser WHERE waterUserId='{0}'

SELECT @waterTotalCharge=waterTotalCharge,@extraCharge1=extraCharge1,
@extraCharge2=extraCharge2,@extraTotalCharge=extraTotalCharge,
@totalCharge=totalCharge FROM readMeterRecord where readMeterRecordId='{1}'

INSERT INTO WATERFEECHARGE(CHARGEID,TOTALNUMBERCHARGE,EXTRACHARGECHARGE1,
EXTRACHARGECHARGE2,WATERTOTALCHARGE,EXTRATOTALCHARGE,TOTALCHARGE,CHARGETYPEID,
CHARGEClASS,CHARGEBCYS,CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,
CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME)
SELECT '{2}',@TotalNumber,@waterTotalCharge,@extraCharge1,@extraCharge2,
@extraTotalCharge,@totalCharge,'1','1',@totalCharge,0,@Prestore,0,@Prestore,
'{3}','{4}',GETDATE()

UPDATE readMeterRecord SET chargeState='3',chargeID='{2}' WHERE readMeterRecordId='{1}'

INSERT INTO [readMeterRecord]([readMeterRecordId],[readMeterRecordIdLast],[waterMeterId],[waterMeterNo]
,[lastNumberYearMonth],[waterMeterLastNumber],[waterMeterEndNumber],SUBMETERNUMBER,[totalNumber],[totalNumberDescribe],[avePrice]
,[avePriceDescribe],[waterTotalCharge],[extraChargePrice1],[extraCharge1],[extraChargePrice2],[extraCharge2]
,[extraTotalCharge],[trapezoidPrice],[extraCharge]
,[totalCharge],[OVERDUEMONEY],[WATERFIXVALUE],readMeterRecordYearAndMonth,initialReadMeterMesDateTime,[readMeterRecordDate],[waterMeterPositionName]
,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName]
,[waterMeterProduct],[waterMeterSerialNumber]
,[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName]
,[checkState],[checkDateTime],[checker],[chargeState],[chargeID],[waterUserId],[waterUserNO],[waterUserName]
,waterUserNameCode,[waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO
,unitNO,createType,waterPhone,[waterUserAddress],[waterUserPeopleCount]
,[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
,[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber] ,[memo]) 

SELECT '{5}','',[waterMeterId],[waterMeterNo]
,[lastNumberYearMonth],[waterMeterEndNumber],[waterMeterLastNumber],0,0-[totalNumber],NULL,[avePrice]
,NULL,0-[waterTotalCharge],[extraChargePrice1],0-[extraCharge1],[extraChargePrice2],0-[extraCharge2]
,0-[extraTotalCharge],[trapezoidPrice],[extraCharge]
,0-[totalCharge],0,[WATERFIXVALUE],GETDATE(),GETDATE(),GETDATE(),[waterMeterPositionName]
,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName]
,[waterMeterProduct],[waterMeterSerialNumber]
,[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName]
,'1',GETDATE(),'{4}','3','{6}',[waterUserId],[waterUserNO],[waterUserName]
,waterUserNameCode,[waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO
,unitNO,createType,[waterPhone],[waterUserAddress],[waterUserPeopleCount]
,[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
,[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber] ,NULL
 FROM readMeterRecord WHERE readMeterRecordId='{1}'
 
 INSERT INTO  WATERFEECHARGE(CHARGEID,TOTALNUMBERCHARGE,EXTRACHARGECHARGE1,
EXTRACHARGECHARGE2,WATERTOTALCHARGE,EXTRATOTALCHARGE,TOTALCHARGE,CHARGETYPEID,
CHARGEClASS,CHARGEBCYS,CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,
CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME)
SELECT '{6}',0-@TotalNumber,0-@waterTotalCharge,0-@extraCharge1,0-@extraCharge2,
0-@extraTotalCharge,0-@totalCharge,'1','4',0-@totalCharge,0,@Prestore,0,@Prestore,
'{3}','{4}',GETDATE()

SELECT @QFZJ=TOTALFEE FROM V_WATERUSERAREARAGE WHERE WATERUSERID='{0}'

INSERT INTO [readMeterRecord]([readMeterRecordId],[readMeterRecordIdLast],[waterMeterId],[waterMeterNo]
,[lastNumberYearMonth],[waterMeterLastNumber],[waterMeterEndNumber],SUBMETERNUMBER,[totalNumber],[totalNumberDescribe],[avePrice]
,[avePriceDescribe],[waterTotalCharge],[extraChargePrice1],[extraCharge1],[extraChargePrice2],[extraCharge2]
,[extraTotalCharge],[trapezoidPrice],[extraCharge]
,[totalCharge],[OVERDUEMONEY],[WATERFIXVALUE],readMeterRecordYearAndMonth,initialReadMeterMesDateTime,[readMeterRecordDate],[waterMeterPositionName]
,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName]
,[waterMeterProduct],[waterMeterSerialNumber]
,[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName]
,[checkState],[checkDateTime],[checker],[chargeState],[chargeID],[waterUserId],[waterUserNO],[waterUserName]
,waterUserNameCode,[waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO
,unitNO,createType,waterPhone,[waterUserAddress],[waterUserPeopleCount]
,[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
,[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber] ,[memo],[NotReadMonthCount],WATERUSERQQYE,WATERUSERJSYE,WATERUSERLJQF) 

SELECT '{7}','',[waterMeterId],[waterMeterNo]
,[lastNumberYearMonth],[waterMeterEndNumber]-{11},[waterMeterEndNumber],0,{11},NULL,[avePrice]
,NULL,{8},[extraChargePrice1],{9},[extraChargePrice2],{10}
,{9}+{10},[trapezoidPrice],[extraCharge]
,{8}+{9}+{10},0,[WATERFIXVALUE],GETDATE(),GETDATE()+0.0001,GETDATE(),[waterMeterPositionName]
,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName]
,[waterMeterProduct],[waterMeterSerialNumber]
,[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName]
,'1',GETDATE()+0.0001,'{4}','1',NULL,[waterUserId],[waterUserNO],[waterUserName]
,waterUserNameCode,[waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO
,unitNO,createType,[waterPhone],[waterUserAddress],[waterUserPeopleCount]
,[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
,[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber] ,NULL,[NotReadMonthCount],@Prestore,@Prestore-@QFZJ-{8}-{9}-{10},@QFZJ+{8}+{9}+{10} 
 FROM readMeterRecord WHERE readMeterRecordId='{1}'
 
 --0  用户ID
 --1  待处理的抄表记录ID
 --2  待处理的抄表记录的收费ID
 --3  当前登录员ID
 --4  当前登录员姓名
 --5  红冲待处理抄表记录新的ID
 --6  红冲待处理抄表的收费ID
 --7  正确的抄表记录新的ID
 --8  减免后的水费
 --9  减免后的污水处理费
 --10 减免后的附加费
 --11 减免后的水量
COMMIT TRAN
", WATERUSERNO.Text, readMeterRecordId.Text, ChargeID, strLogID, strRealName, strReadMeterRecordID, ChargeIDNew,strReadMeterRecordIDNew,
 waterTotalCharge,extraCharge1,extraCharge2,intTotalNumber);
                                    intRows = new SqlServerHelper().ExcuteSql(strSQLExcute);
                                    #endregion
                                }
                                else if (intMonth == 0)
                                {
                                    #region 未收费并且抄表月份是当月的,直接修改抄表记录即可
                                    string strSQLExcute = string.Format(@"BEGIN TRAN 
UPDATE [readMeterRecord] SET waterMeterLastNumber=waterMeterEndNumber-{0},
totalNumber={0},waterTotalCharge={1},extraCharge1={2},extraCharge2={3},extraTotalCharge={4},totalCharge={5} WHERE readMeterRecordId='{6}'
DECLARE @PRESTORE DECIMAL(18,2)=0
DECLARE @LJQF DECIMAL(18,2)=0
SELECT @PRESTORE=PRESTORE, @LJQF=TOTALFEE FROM V_WATERUSERAREARAGE WHERE waterUserId='{7}'
UPDATE readMeterRecord SET WATERUSERQQYE=@PRESTORE,WATERUSERJSYE=@PRESTORE-@LJQF,WATERUSERLJQF=@LJQF WHERE readMeterRecordId='{6}'
COMMIT TRAN
",
intTotalNumber, waterTotalCharge, extraCharge1, extraCharge2, extraCharge1 + extraCharge2, waterTotalCharge + extraCharge1 + extraCharge2, readMeterRecordId.Text,WATERUSERNO.Text);
                                    intRows = new SqlServerHelper().ExcuteSql(strSQLExcute);
                                    #endregion
                                }
                            }
                        }

                        #endregion

                        if (intRows > 0)
                        {
                            IsChargeAbate = true;
                        }
                        else
                        {
                            MessageBox.Show("水表减免变更过程失败!请联系管理员跳回本流程再次重试!");
                            return;
                        }
                            if (IsChargeAbate)
                            {
                                Hashtable hu = new Hashtable();
                                hu["IsAbate"] = 1;
                                hu["CHARGEWORKERNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                                hu["CHARGEWORKERID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                                hu["CHARGEWORKERDate"] = DateTime.Now.ToString();
                                int upCount = new SqlServerHelper().UpdateByHashtable("User_ChargeAbate", "TaskID", TaskID, hu);
                                if (upCount > 0)
                                {
                                    //==========================================================================================如果金额小于指定金额，不需要总经理审批
                                    this.DialogResult = DialogResult.OK;
                                    MessageBox.Show("水费减免成功！");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("水费减免成功 ，记录保存失败！");
                                }
                            }
                            else
                            {
                                MessageBox.Show("水费减免失败！");
                            }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("水表减免变更过程失败!原因:"+ex.Message+"\n请联系管理员跳回本流程再次重试!");
                        return;

                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("审批成功！");
                    this.Close();
                }
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

    }
}
