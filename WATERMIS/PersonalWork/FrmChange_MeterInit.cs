using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using System.Collections;
using DBinterface.IDAL;
using Common.DotNetData;
using System.Data.SqlClient;
using BASEFUNCTION;
using BLL;

namespace PersonalWork
{
    public partial class FrmChange_MeterInit : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;

        private string ComputerName = "";
        private string ip = "";
        private string _waterUserId;
        private string _waterMeterId;
        private int _DesterilizeType = 0;

        private string strLogID="";
        private string strName="";
        private string strRealName="";

        private int _Quantity = 0;

        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        Log log = new Log(Application.StartupPath+@"\Logs\",LogType.Daily);

        public FrmChange_MeterInit()
        {
            InitializeComponent();
        }

        private void FrmChange_MeterInit_Load(object sender, EventArgs e)
        {
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            {
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            }
            else
            {
                MessageBox.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

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
            #endregion
        }

        private void FrmChange_MeterInit_Shown(object sender, EventArgs e)
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();

                DataTable dt = sysidal.GetUserMeterInfoByTaskId("Meter_Change", TaskID);
                if (DataTableHelper.IsExistRows(dt))
                {
                    _waterUserId = dt.Rows[0][0].ToString();
                    _waterMeterId = dt.Rows[0][1].ToString();
                    LB_Tip.Text = string.Format("用 户 号：{0}；        水表编号：{1} ", _waterUserId, _waterMeterId);
                }
            }

            DataTable dtm = new SqlServerHelper().GetDateTableBySql(string.Format("SELECT waterMeterEndNumber FROM Meter_Change WHERE TaskID='{0}'", TaskID));
            if (DataTableHelper.IsExistRows(dtm))
            {
                LB_EndNumber.Text = dtm.Rows[0][0].ToString();
            }

            DataTable dts = new SqlServerHelper().GetDateTableBySql(string.Format("SELECT TOP 1 waterMeterEndNumber,readMeterRecordYearAndMonth,meterReaderName FROM readMeterRecord WHERE waterMeterId='{0}' ORDER BY readMeterRecordDate DESC", _waterMeterId));
            if (DataTableHelper.IsExistRows(dts))
            {
                LB_S.Text = string.Format("抄表员：{0}，抄表月份：{1}，上期表底数：{2}",dts.Rows[0][2].ToString(),dts.Rows[0][1].ToString(),dts.Rows[0][0].ToString());
            }

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;


            if (int.TryParse(TB_Quantity.Text.Trim(), out _Quantity))
            {
                Hashtable HM = new Hashtable();
                HM["QUANTITY"] = _Quantity;
                HM["ABATE"] = TB_Abate.Text.Trim();
                new SqlServerHelper().Submit_AddOrEdit("Meter_Change", "TaskID", TaskID, HM);
            }
            else
            {
                mes.Show("补交水量输入错误！");
                return;
            }
            try
            {
               
                //生成抄表记录
                #region 生成补交水量记录
                string strChargeState = "1", strTrapePriceString = "", strExtraCharge = "", strChargeID = "";
                decimal waterTotalCharge = 0, extraCharge1 = 0, extraCharge2 = 0;

                DateTime dtNow = mes.GetDatetimeNow();

                int intTotalNum = Convert.ToInt32(_Quantity);

                string strSQL = string.Format(@"SELECT trapezoidPrice,extraCharge FROM V_WATERUSER_CONNECTWATERMETER
WHERE waterUserId='{0}'", _waterUserId);
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
                }

                //获取水费等信息
                sysidal.GetAvePrice(intTotalNum, strTrapePriceString, strExtraCharge, 1, ref waterTotalCharge, ref extraCharge1, ref extraCharge2);
                string strReadMeterRecordID = GETTABLEID.GetTableID(strLogID, "READMETERRECORD"); 
                string strSQLExcute = string.Format(@"BEGIN TRAN
DECLARE @readMeterRecordIdLast varchar(30)
DECLARE @waterMeterEndNumber INT
SELECT TOP 1 @readMeterRecordIdLast=readMeterRecordId,@waterMeterEndNumber=waterMeterEndNumber FROM V_READMETERRECORD_LEFT_WATERFEECHARGE WHERE WATERUSERID='{0}' 
ORDER BY checkDateTime DESC,readMeterRecordDate DESC
IF @readMeterRecordIdLast IS NULL
BEGIN
SELECT @waterMeterEndNumber=waterMeterStartNumber FROM waterMeter WHERE WATERUSERID='{0}'
SET @readMeterRecordIdLast=NULL
END

DECLARE @PRESTORE DECIMAL(18,2)=0
DECLARE @LJQF DECIMAL(18,2)=0
SELECT @PRESTORE=PRESTORE, @LJQF=TOTALFEE FROM V_WATERUSERAREARAGE WHERE waterUserId='{0}'

INSERT INTO [readMeterRecord]([readMeterRecordId],[readMeterRecordIdLast],[waterMeterId],[waterMeterNo]
                                            ,[lastNumberYearMonth],[waterMeterLastNumber],[waterMeterEndNumber],SUBMETERNUMBER,[totalNumber],[totalNumberDescribe],[avePrice]
                                            ,[avePriceDescribe],[waterTotalCharge],[extraChargePrice1],[extraCharge1],[extraChargePrice2],[extraCharge2],
                                             [extraTotalCharge],[trapezoidPrice],[extraCharge]
                                            ,[totalCharge],[OVERDUEMONEY],[WATERFIXVALUE],[readMeterRecordYear],[readMeterRecordMonth],
                                            readMeterRecordYearAndMonth,initialReadMeterMesDateTime,[readMeterRecordDate],[waterMeterPositionName]
                                            ,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName],[waterMeterProduct],[waterMeterSerialNumber]
                                            ,[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName],[checkState],[checkDateTime]
                                            ,[checker],[chargeState],[chargeID],[waterUserId],[waterUserNO],[waterUserName],waterUserNameCode,[waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,waterPhone,[waterUserAddress],[waterUserPeopleCount]
                                            ,[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
                                            ,[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber],[WATERUSERQQYE],[WATERUSERJSYE],[WATERUSERLJQF])

                                            SELECT '{1}',@readMeterRecordIdLast,[waterMeterId],[waterMeterNo]
                                            ,NULL,@waterMeterEndNumber,@waterMeterEndNumber,0,{2},NULL,NULL
                                            ,NULL,{3},NULL,{4},NULL,{5},{4}+{5},[trapezoidPrice],[extraCharge]
                                            ,{3}+{4}+{5},0,[WATERFIXVALUE],NULL,NULL,DATEADD(SECOND,-2,GETDATE()),DATEADD(SECOND,-2,GETDATE()),DATEADD(SECOND,-2,GETDATE()),[waterMeterPositionName]
                                            ,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeValue],
                                            [waterMeterProduct],[waterMeterSerialNumber],[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName],
                                            1,DATEADD(SECOND,-2,GETDATE()),'{6}','1',NULL,[waterUserId],[waterUserNO],[waterUserName],waterUserNameCode,
                                            [waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,[waterPhone],[waterUserAddress],[waterUserPeopleCount]
                                            ,NULL,NULL,NULL,[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
                                            ,[waterUserHouseType],[chargeType],[agentsign],NULL,[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber],@PRESTORE,@PRESTORE-@LJQF-{3}-{4}-{5},@LJQF+{3}+{4}+{5}  
                                            FROM V_WATERUSER_CONNECTWATERMETER WHERE waterUserId='{0}'
COMMIT TRAN", _waterUserId, strReadMeterRecordID, intTotalNum, waterTotalCharge, extraCharge1, extraCharge2, strRealName);

                new SqlServerHelper().ExcuteSql(strSQLExcute);
                #endregion


                strReadMeterRecordID = GETTABLEID.GetTableID(strLogID, "READMETERRECORD");
                if (BLLreadMeterRecord.ChangeWaterMeter(_waterMeterId, strReadMeterRecordID, strRealName))
                {
                    Hashtable HL = new Hashtable();
                    HL["LOGTYPE"] = 6; //6-抄表台账相关日志
                    HL["LOGCONTENT"] = string.Format("用户换表-用户号：{0}；水表编号：{1}", _waterUserId, _waterMeterId);
                    HL["LOGDATETIME"] = DateTime.Now.ToString();
                    HL["OPERATORID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                    HL["OPERATORNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                    HL["MEMO"] = TaskID;
                    new SqlServerHelper().Submit_AddOrEdit("OPERATORLOG", "LOGID", "", HL);

                    int count = sysidal.UpdateApprove_defalut("Meter_Change", ResolveID, true, UserOpinion.Text.Trim(), PointSort, TaskID, "【换表确认】：用户号：" + _waterUserId + "；水表号：" + _waterMeterId + "；补交水量：" + TB_Quantity.Text.Trim());

                    if (count > 0)
                    {
                        mes.Show("审批成功！");
                    }
                    else
                    {
                        mes.Show("审批失败！");
                        Btn_Submit.Enabled = true;
                    }
                }
                else
                {
                    mes.Show("变更表底数失败！");
                    Btn_Submit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
            }
        }

        private void TB_Quantity_TextChanged(object sender, EventArgs e)
        {
            string waterMeterTypeid = sysidal.GetWaterMeterTypeIdByWaterMeterId(_waterMeterId);
            if (!string.IsNullOrEmpty(waterMeterTypeid))
            {
                decimal _totalNumber = 0m;
                if (decimal.TryParse(TB_Quantity.Text, out _totalNumber))
                {
                    decimal _waterTotalCharge = 0m;
                    decimal _extraCharge1 = 0m;
                    decimal _extraCharge2 = 0m;

                    sysidal.GetWaterFeeByMeterType(waterMeterTypeid, _totalNumber, 1, ref _waterTotalCharge, ref _extraCharge1, ref _extraCharge2);
                    TB_Abate.Text = (_waterTotalCharge+_extraCharge1+_extraCharge2).ToString();
                }
                else
                {
                    TB_Abate.Text = "--";
                }
            }
        }
    }
}
