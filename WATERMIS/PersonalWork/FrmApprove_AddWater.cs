using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using System.Collections;
using BASEFUNCTION;
using Common.DotNetUI;

namespace PersonalWork
{
    public partial class FrmApprove_AddWater : Form
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

        public FrmApprove_AddWater()
        {
            InitializeComponent();
        }

        private void FrmApprove_AddWater_Load(object sender, EventArgs e)
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

            Hashtable ha = new SqlServerHelper().GetHashtableById("User_AddWater", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(ha, this.panel1.Controls);
            //object obj = ht["READMETERRECORDYEARANDMONTH"];
            //if (Information.IsDate(obj))
            //    readMeterRecordYearAndMonth.Text = Convert.ToDateTime(obj).ToString("yyyy-MM-01");
            InitView();
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            {
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            }
            else
            {
                MessageBox.Show("请重新登录!");
                this.Close();
            }
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

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            string Matter = string.Format("【补交水量】-审批意见：{0}", UserOpinion.Text.Trim());
            int count = sysidal.UpdateApprove_defalut("User_AddWater", ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), PointSort, TaskID, Matter);
            if (count > 0)
            {
                if (sysidal.IsWorkTaskOver("User_AddWater", TaskID))//获取审批状态，如果是Meter_WorkTask.state=5 和User_WaterPrice.state=5,说明审批流程走完
                {
                    bool IsChargeAbate = false;

                    //======================================生成一条抄表记录

                    #region 生成补交水量记录
                    string strChargeState = "1", strTrapePriceString = "", strExtraCharge = "", strChargeID = "";
                    decimal waterTotalCharge = 0, extraCharge1 = 0, extraCharge2 = 0;
                    
                    DateTime dtNow = mes.GetDatetimeNow();

                    int intTotalNum = Convert.ToInt32(totalNumber.Text);

                    string strSQL = string.Format(@"SELECT trapezoidPrice,extraCharge FROM V_WATERUSER_CONNECTWATERMETER
WHERE waterUserId='{0}'",WATERUSERNO.Text);
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
                    string strReadMeterRecordID = GETTABLEID.GetTableID(strLogID, "READMETERRECORD"); string strSQLExcute = string.Format(@"BEGIN TRAN
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
                                            ,{3}+{4}+{5},0,[WATERFIXVALUE],NULL,NULL,GETDATE(),GETDATE(),GETDATE(),[waterMeterPositionName]
                                            ,[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeValue],
                                            [waterMeterProduct],[waterMeterSerialNumber],[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName],
                                            1,GETDATE(),'{6}','1',NULL,[waterUserId],[waterUserNO],[waterUserName],waterUserNameCode,
                                            [waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,[waterPhone],[waterUserAddress],[waterUserPeopleCount]
                                            ,NULL,NULL,NULL,[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]
                                            ,[waterUserHouseType],[chargeType],[agentsign],NULL,[bankId],[bankName],[BankAcountNumber],
[isSummaryMeter],[waterMeterParentId],[ordernumber],@PRESTORE,@PRESTORE-@LJQF-{3}-{4}-{5},@LJQF+{3}+{4}+{5}  
                                            FROM V_WATERUSER_CONNECTWATERMETER WHERE waterUserId='{0}'
COMMIT TRAN", WATERUSERNO.Text, strReadMeterRecordID, intTotalNum,waterTotalCharge,extraCharge1,extraCharge2,strRealName);

                    IsChargeAbate = new SqlServerHelper().ExcuteSql(strSQLExcute)>0?true:false;
                    #endregion

                    if (IsChargeAbate)
                    {
                        Hashtable hu = new Hashtable();
                        hu["IsAdd"] = 1;
                        hu["CHARGEWORKERNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                        hu["CHARGEWORKERID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                        hu["CHARGEWORKERDate"] = DateTime.Now.ToString();
                        int upCount = new SqlServerHelper().UpdateByHashtable("User_AddWater", "TaskID", TaskID, hu);
                        if (upCount > 0)
                        {
                            this.DialogResult = DialogResult.OK;
                            MessageBox.Show("水量补交成功！");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("水量补交成功 ，记录保存失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("水量补交失败！");
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

        private void Btn_Voided_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            Btn_Voided.Enabled = false;
            int count = sysidal.UpdateApprove_Voided_ByTableName("User_AddWater", ResolveID, UserOpinion.Text.Trim(), TaskID);
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
    }
}
