using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BASEFUNCTION;
using BLL;
using MODEL;

namespace WATERFEEMANAGE
{
    public partial class frmChangeEndNumber : Form
    {
        public frmChangeEndNumber()
        {
            InitializeComponent();
        }
        BLLOPERATORLOG BLLOPERATORLOG = new BLLOPERATORLOG();
        Messages mes = new Messages();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        GETTABLEID GETTABLEID = new GETTABLEID();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        public string strWaterUserName = "", strWaterUserNO = "", strWaterUserAddress = "", strWaterMeterID = "",
            strWaterMeterLastNumber = "", strLastRecordID = "", strLastNumberYearMonth = "", strRecordYear = "", strRecordMonth = "", strMeterReadingID = "";

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        private void frmChangeEndNumber_Load(object sender, EventArgs e)
        {
            this.txtWaterUserName.Text = strWaterUserName;
            this.txtWaterUserNO.Text = strWaterUserNO;
            this.txtWaterUserAddress.Text = strWaterUserAddress;
            this.txtWaterMeterNO.Text = strWaterMeterID;
            this.txtWaterMeterLastNumber.Text = strWaterMeterLastNumber;

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("操作员ID获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            try
            {
                if(!Information.IsNumeric(txtWaterMeterEndNumber.Text.Trim()))
                {
                    mes.Show("变更后的读数只能为数字!");
                    txtWaterMeterEndNumber.Focus();
                    return;
                }
                if(txtMemo.Text.Trim()=="")
                {
                    mes.Show("请输入变更原因!");
                    txtMemo.Focus();
                    return;
                }
                if(mes.ShowQ("表底数变更前请将所有费用收取完毕!\n确定要变更'"+strWaterUserName+"-"+strWaterMeterID+"'的表底数吗？")!=DialogResult.OK)
                    return;

                DateTime dtNow=mes.GetDatetimeNow();

                MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();                

                    MODELreadMeterRecord.waterUserName =strWaterUserName;
                    MODELreadMeterRecord.waterUserNO = strWaterUserNO;
                    MODELreadMeterRecord.waterUserId = strWaterUserNO;
                    MODELreadMeterRecord.waterUserAddress =strWaterUserAddress;
                    MODELreadMeterRecord.readMeterRecordIdLast = strLastRecordID;
                    MODELreadMeterRecord.lastNumberYearMonth = dtNow.ToString("yyyyMM");
                    MODELreadMeterRecord.initialReadMeterMesDateTime = dtNow;

                    MODELreadMeterRecord.waterMeterId = strWaterMeterID;
                    MODELreadMeterRecord.waterMeterNo = strWaterMeterID;
                if(Information.IsNumeric(strWaterMeterLastNumber))
                    MODELreadMeterRecord.waterMeterLastNumber =Convert.ToInt32(strWaterMeterLastNumber);
                MODELreadMeterRecord.waterMeterEndNumber=Convert.ToInt32(txtWaterMeterEndNumber.Text.Trim());

                MODELreadMeterRecord.totalNumber = 0;
                MODELreadMeterRecord.waterTotalCharge = 0;
                MODELreadMeterRecord.extraChargePrice1 = 0;
                MODELreadMeterRecord.extraChargePrice2 = 0;
                MODELreadMeterRecord.extraChargePrice3 = 0;
                MODELreadMeterRecord.extraChargePrice4 = 0;
                MODELreadMeterRecord.extraChargePrice5 = 0;
                MODELreadMeterRecord.extraChargePrice6 = 0;
                MODELreadMeterRecord.extraChargePrice7 = 0;
                MODELreadMeterRecord.extraChargePrice8 = 0;
                MODELreadMeterRecord.extraCharge1 = 0;
                MODELreadMeterRecord.extraCharge2 = 0;
                MODELreadMeterRecord.extraCharge3 = 0;
                MODELreadMeterRecord.extraCharge4 = 0;
                MODELreadMeterRecord.extraCharge5 = 0;
                MODELreadMeterRecord.extraCharge6 = 0;
                MODELreadMeterRecord.extraCharge7 = 0;
                MODELreadMeterRecord.extraCharge8 = 0;
                MODELreadMeterRecord.extraTotalCharge = 0;
                MODELreadMeterRecord.totalCharge = 0;
                
                MODELreadMeterRecord.WATERFIXVALUE = 0;

                MODELreadMeterRecord.readMeterRecordYear = Convert.ToInt16(strRecordYear);

                MODELreadMeterRecord.readMeterRecordMonth = Convert.ToInt16(strRecordMonth);

                string strYearAndMonth = strRecordYear + "-" + strRecordMonth + "-01";
                if (Information.IsDate(strYearAndMonth))
                    MODELreadMeterRecord.readMeterRecordYearAndMonth = Convert.ToDateTime(strYearAndMonth);
                else
                    MODELreadMeterRecord.readMeterRecordYearAndMonth = dtNow;

                //变更记录将抄表时间置为空
                //MODELreadMeterRecord.readMeterRecordDate =null;

                MODELreadMeterRecord.chargeState="1";

                MODELreadMeterRecord.checkState="1";

                MODELreadMeterRecord.checkDateTime = dtNow;
                MODELreadMeterRecord.WATERMETERNUMBERCHANGESTATE = "1";

                    MODELreadMeterRecord.MEMO = txtMemo.Text;//将特殊的用户（按面积均摊或者按月份确定开票名称）存储到memo字段里。备用
                                
                MODELreadMeterRecord.readMeterRecordId = GETTABLEID.GetTableID(strLogID, "READMETERRECORD");
                if (BLLreadMeterRecord.Insert(MODELreadMeterRecord))
                {
                    try
                    {
                        if (BLLreadMeterRecord.UpdateCheckStateChangeNumber(MODELreadMeterRecord))
                        {
                            mes.Show("表底数变更成功!");
                            btChange.Enabled = false;
                            MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                            MODELOPERATORLOG.LOGCONTENT = "表底变更:" + MODELreadMeterRecord.waterUserNO + "-" + MODELreadMeterRecord.waterUserName + "-" + MODELreadMeterRecord.waterMeterNo + "," + MODELreadMeterRecord.waterMeterLastNumber + "→" + MODELreadMeterRecord.waterMeterEndNumber;
                            MODELOPERATORLOG.METERREADINGID = strMeterReadingID;
                            MODELOPERATORLOG.LOGTYPE = "2";  //1代表用户 2代表水表
                            MODELOPERATORLOG.OPERATORID = strLogID;
                            MODELOPERATORLOG.OPERATORNAME = strUserName;
                            BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                        }
                        else
                        {
                            //回滚抄表数据
                            BLLreadMeterRecord.Delete(MODELreadMeterRecord.readMeterRecordId);
                        }
                    }
                    catch(Exception )
                    {
                        //回滚抄表数据
                        BLLreadMeterRecord.Delete(MODELreadMeterRecord.readMeterRecordId);

                        mes.Show("表底数变更过程更新审核状态失败,请重试!");
                        return;
                    }
                }
                else
                {
                    mes.Show("表底数变更失败,请重试!");
                    return;
                }
            }
            catch(Exception ex)
            {
                mes.Show("表底数变更失败,原因:"+ex.ToString());
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
