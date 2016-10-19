using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BLL;
using MODEL;
using BASEFUNCTION;

namespace WATERFEEMANAGE
{
    public partial class frmRedCancelCharge : Form
    {
        public frmRedCancelCharge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 收费表
        /// </summary>
        public DataTable dtList = new DataTable();

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        private void frmRedCancelCharge_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                //隐藏附加费列
                if (dgList.Columns[i].Name == "extraChargePrice1" || dgList.Columns[i].Name == "extraCharge1" ||
                    dgList.Columns[i].Name == "extraChargePrice2" || dgList.Columns[i].Name == "extraCharge2" ||
                    dgList.Columns[i].Name == "extraChargePrice3" || dgList.Columns[i].Name == "extraCharge3" ||
                    dgList.Columns[i].Name == "extraChargePrice4" || dgList.Columns[i].Name == "extraCharge4" ||
                    dgList.Columns[i].Name == "extraChargePrice5" || dgList.Columns[i].Name == "extraCharge5" ||
                    dgList.Columns[i].Name == "extraChargePrice6" || dgList.Columns[i].Name == "extraCharge6" ||
                    dgList.Columns[i].Name == "extraChargePrice7" || dgList.Columns[i].Name == "extraCharge7" ||
                    dgList.Columns[i].Name == "extraChargePrice8" || dgList.Columns[i].Name == "extraCharge8")
                {
                    dgList.Columns[i].Visible = false;
                }
            }
            GetExtraFeeName();

            try
            {
                if (dtList.Rows.Count > 0)
                {
                    object objID = dtList.Rows[0]["CHARGEID"];
                    if (objID != null && objID != DBNull.Value)
                    {
                        labID.Text = objID.ToString();
                    }
                    object objMes = dtList.Rows[0]["CHARGEWORKERNAME"];
                    if (objMes != null && objMes != DBNull.Value)
                    {
                        labWorkName.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["CHARGEDATETIME"];
                    if (Information.IsDate(objMes))
                    {
                        labChargeDateTime.Text = Convert.ToDateTime(objMes).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    objMes = dtList.Rows[0]["INVOICENO"];
                    if (objMes != null && objMes != DBNull.Value)
                    {
                        labInvoiceNO.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["CHARGEBCYS"];
                    if (Information.IsNumeric(objMes))
                    {
                        labBCYS.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["CHARGEBCSS"];
                    if (Information.IsNumeric(objMes))
                    {
                        labBCSS.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["CHARGEYSQQYE"];
                    if (Information.IsNumeric(objMes))
                    {
                        labQQYE.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["CHARGEYSBCSZ"];
                    if (Information.IsNumeric(objMes))
                    {
                        labBCSZ.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["CHARGEYSJSYE"];
                    if (Information.IsNumeric(objMes))
                    {
                        labJSYE.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["waterUserId"];
                    if (objMes != null && objMes != DBNull.Value)
                    {
                        labWaterUserID.Text = objMes.ToString();
                      object objYHYE=  BLLwaterUser.GetPrestore(" AND waterUserId='"+labWaterUserID.Text+"'");
                      if (Information.IsNumeric(objYHYE))
                      {
                          labYE.Text = objYHYE.ToString();
                      }
                    }
                    dgList.DataSource = dtList;
                }
                else
                    dgList.DataSource = null;
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }
        /// <summary>
        /// 根据附加费表生成附加费列及单价
        /// </summary>
        private void GetExtraFeeName()
        {
            DataTable dt = BLLEXTRACHARGE.Query(" ORDER BY extraChargeID");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object objExtraFee = dt.Rows[i]["extraChargeName"];
                if (objExtraFee != null && objExtraFee != DBNull.Value)
                {
                    dgList.Columns["extraCharge" + (i + 1).ToString()].HeaderText = objExtraFee.ToString();
                    dgList.Columns["extraChargePrice" + (i + 1).ToString()].HeaderText = objExtraFee.ToString() + "单价";

                    object objExtraChargeState = dt.Rows[i]["extraChargeState"];
                    if (objExtraChargeState != null && objExtraChargeState != DBNull.Value)
                    {
                        if (objExtraChargeState.ToString() == "启用")
                        {
                            dgList.Columns["extraCharge" + (i + 1).ToString()].Visible = true;
                            dgList.Columns["extraChargePrice" + (i + 1).ToString()].Visible = true;
                        }
                    }
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (labID.Text != "")
                {
                    if (!(rbWaterFee.Checked || rbMoney.Checked))
                    {
                        mes.Show("请选择红冲类型!");
                        //rbWaterFee.Focus();
                        return;
                    }
                    if (mes.ShowQ("确定要红冲单号为'" + labID.Text + "'的收费记录吗?") != DialogResult.OK)
                    {
                        return;
                    }
                    #region 生成退费记录
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLogID, "WATERFEECHARGE");
                    MODELWATERFEECHARGE.CHARGEClASS = "4";//收费类型是水费冲减
                    if (Information.IsNumeric(labYE.Text))
                        MODELWATERFEECHARGE.CHARGEYSQQYE = Convert.ToDecimal(labYE.Text);

                    //存储本次应收和本次实收
                    decimal decBCYS = 0, decBCSS = 0;
                    if (Information.IsNumeric(labBCYS.Text))
                        decBCYS = Convert.ToDecimal(labBCYS.Text);

                    if (Information.IsNumeric(labBCSS.Text))
                        decBCSS = Convert.ToDecimal(labBCSS.Text);

                    if (rbWaterFee.Checked)
                    {
                        MODELWATERFEECHARGE.CHARGEBCSS = 0;
                        MODELWATERFEECHARGE.CHARGEYSBCSZ = decBCYS;
                        MODELWATERFEECHARGE.CHARGEYSJSYE = MODELWATERFEECHARGE.CHARGEYSQQYE + MODELWATERFEECHARGE.CHARGEYSBCSZ;
                    }
                    else
                    {
                        MODELWATERFEECHARGE.CHARGEBCSS = 0 - decBCSS;
                        MODELWATERFEECHARGE.CHARGEYSBCSZ = 0 - Convert.ToDecimal(labBCSZ.Text);
                        if ((MODELWATERFEECHARGE.CHARGEYSQQYE + MODELWATERFEECHARGE.CHARGEYSBCSZ) < 0)
                        {
                            mes.Show("用户余额不足,无法红冲!用户余额:" + MODELWATERFEECHARGE.CHARGEYSQQYE + "元,本次收支:" + MODELWATERFEECHARGE.CHARGEYSBCSZ + "元");
                            return;
                        }

                        MODELWATERFEECHARGE.CHARGEYSJSYE = MODELWATERFEECHARGE.CHARGEYSQQYE + MODELWATERFEECHARGE.CHARGEYSBCSZ;
                    }

                    MODELWATERFEECHARGE.CHARGEWORKERID = strLogID;
                    MODELWATERFEECHARGE.CHARGEWORKERNAME = strUserName;
                    MODELWATERFEECHARGE.CHARGEDATETIME = mes.GetDatetimeNow();
                    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                    MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 0;
                    MODELWATERFEECHARGE.MEMO = "红冲收费单号:" + labID.Text;
                    try
                    {
                        //插入收费记录,本次实收=0-本次应收，本次实收包含实际收到的现金和前期余额之和
                        string strInserChargeSQL = "INSERT INTO WATERFEECHARGE(CHARGEID,TOTALNUMBERCHARGE,EXTRACHARGECHARGE1,EXTRACHARGECHARGE2," +
                            "WATERTOTALCHARGE,EXTRATOTALCHARGE,TOTALCHARGE,OVERDUEMONEY,CHARGETYPEID,CHARGEClASS,CHARGEBCYS,CHARGEBCSS,CHARGEYSQQYE," +
                            "CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME,INVOICEPRINTSIGN,RECEIPTPRINTCOUNT,MEMO) " +
                            "SELECT '" + MODELWATERFEECHARGE.CHARGEID + "',0-TOTALNUMBERCHARGE,0-EXTRACHARGECHARGE1,0-EXTRACHARGECHARGE2," +
                            "0-WATERTOTALCHARGE,0-EXTRATOTALCHARGE,0-TOTALCHARGE,0-OVERDUEMONEY,CHARGETYPEID,'" + MODELWATERFEECHARGE.CHARGEClASS +
                            "',0-CHARGEBCYS," + MODELWATERFEECHARGE.CHARGEBCSS + "," + MODELWATERFEECHARGE.CHARGEYSQQYE + "," + MODELWATERFEECHARGE.CHARGEYSBCSZ + "," +
                            MODELWATERFEECHARGE.CHARGEYSJSYE + ",CHARGEWORKERID,CHARGEWORKERNAME,'" + MODELWATERFEECHARGE.CHARGEDATETIME + "',0,0,'" +
                            MODELWATERFEECHARGE.MEMO + "' FROM WATERFEECHARGE WHERE CHARGEID='" + labID.Text + "'";

                        if (BLLreadMeterRecord.Excute(strInserChargeSQL)>0)
                        {
                            string strIDS = "";
                            try
                            {
                                for (int i = 0; i < dtList.Rows.Count; i++)
                                {
                                    object objRecordID = dtList.Rows[0]["readMeterRecordId"];
                                    if (objRecordID != null && objRecordID != DBNull.Value)
                                    {
                                        //插入抄表记录 chargeState=4代表红冲 readMeterRecordDate设置为空，否则影响抄表初始化
                                        string strRecordID = GETTABLEID.GetTableID(strLogID, "READMETERRECORD");
                                        string strInsertRecordSQL = "INSERT INTO [readMeterRecord]([readMeterRecordId],[readMeterRecordIdLast],[waterMeterId],[waterMeterNo]" +
                                            ",[lastNumberYearMonth],[waterMeterLastNumber],[waterMeterEndNumber],SUBMETERNUMBER,[totalNumber],[totalNumberDescribe],[avePrice]" +
                                            ",[avePriceDescribe],[waterTotalCharge],[extraChargePrice1],[extraCharge1],[extraChargePrice2],[extraCharge2],[extraChargePrice3]" +
                                            ",[extraCharge3],[extraChargePrice4],[extraCharge4],[extraChargePrice5],[extraCharge5],[extraChargePrice6],[extraCharge6]" +
                                            ",[extraChargePrice7],[extraCharge7],[extraChargePrice8],[extraCharge8],[extraTotalCharge],[trapezoidPrice],[extraCharge]" +
                                            ",[totalCharge],[OVERDUEMONEY],[WATERFIXVALUE],[readMeterRecordYear],[readMeterRecordMonth],"+
                                            "readMeterRecordYearAndMonth,initialReadMeterMesDateTime,[readMeterRecordDate],[waterMeterPositionName]" +
                                            ",[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName],[waterMeterProduct],[waterMeterSerialNumber]" +
                                            ",[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName],[checkState],[checkDateTime]" +
                                            ",[checker],[chargeState],[chargeID],[waterUserId],[waterUserNO],[waterUserName],waterUserNameCode,[waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,waterPhone,[waterUserAddress],[waterUserPeopleCount]" +
                                            ",[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]" +
                                            ",[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],[isSummaryMeter],[waterMeterParentId],[ordernumber] ,[memo]) " +

                                            "SELECT '" + strRecordID + "','" + objRecordID.ToString() + "',[waterMeterId],[waterMeterNo]" +
                                            ",[lastNumberYearMonth],[waterMeterEndNumber],[waterMeterLastNumber],0-SUBMETERNUMBER,0-[totalNumber],[totalNumberDescribe],[avePrice]" +
                                            ",[avePriceDescribe],0-[waterTotalCharge],[extraChargePrice1],0-[extraCharge1],[extraChargePrice2],0-[extraCharge2],[extraChargePrice3]" +
                                            ",0-[extraCharge3],[extraChargePrice4],0-[extraCharge4],[extraChargePrice5],0-[extraCharge5],[extraChargePrice6],0-[extraCharge6]" +
                                            ",[extraChargePrice7],0-[extraCharge7],[extraChargePrice8],0-[extraCharge8],0-[extraTotalCharge],[trapezoidPrice],[extraCharge]" +
                                            ",0-[totalCharge],0-[OVERDUEMONEY],[WATERFIXVALUE]," + MODELWATERFEECHARGE.CHARGEDATETIME.Year + "," + MODELWATERFEECHARGE.CHARGEDATETIME.Month + ",'" +
                                            MODELWATERFEECHARGE.CHARGEDATETIME+"',NULL,'"+MODELWATERFEECHARGE.CHARGEDATETIME + "',[waterMeterPositionName]" +
                                            ",[waterMeterSizeId],[waterMeterSizeValue],waterMeterTypeClassID,waterMeterTypeClassName,[waterMeterTypeId],[waterMeterTypeName]," +
                                            "[waterMeterProduct],[waterMeterSerialNumber]" + ",[waterMeterMode],[waterMeterMagnification],[waterMeterMaxRange],IsReverse,[chargerID],[chargerName],[meterReaderID],[meterReaderName]," +
                                            "[checkState],'" + MODELWATERFEECHARGE.CHARGEDATETIME + "','" + strUserName + "','3','" + MODELWATERFEECHARGE.CHARGEID + "',[waterUserId],[waterUserNO],[waterUserName],waterUserNameCode," +
                                            "[waterUserTelphoneNO],areaNO,pianNO,duanNO,communityID,COMMUNITYNAME,buildingNO,unitNO,createType,[waterPhone],[waterUserAddress],[waterUserPeopleCount]" +
                                            ",[meterReadingID],[meterReadingNO],[meterReadingPageNo],[waterUserTypeId],[waterUserTypeName],[waterUserCreateDate]" +
                                            ",[waterUserHouseType],[waterUserchargeType],[agentsign],[waterUserState],[bankId],[bankName],[BankAcountNumber],[isSummaryMeter],[waterMeterParentId],[ordernumber] ,'红冲台账:" + objRecordID.ToString() +
                                            "' FROM readMeterRecord WHERE readMeterRecordId='" + objRecordID.ToString() + "'";
                                        if (BLLreadMeterRecord.Excute(strInsertRecordSQL)>0)
                                        {
                                            if (strIDS == "")
                                                strIDS = strRecordID;
                                            else
                                            {
                                                strIDS = "," + strRecordID;
                                            }
                                        }
                                        else
                                        {
                                            //如果有一条未插入成功，需要回滚已经插入成功的抄表记录
                                            string strSQLDelete = "DELETE FROM readMeterRecord WHERE readMeterRecordId IN (" + strIDS + ")";
                                            BLLreadMeterRecord.Excute(strSQLDelete);

                                            //回滚收费记录
                                            BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                            mes.Show("插入抄表记录表失败,请重新操作!");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        //如果有一条未插入成功，需要回滚已经插入成功的抄表记录
                                        string strSQLDelete = "DELETE FROM readMeterRecord WHERE readMeterRecordId IN (" + strIDS + ")";
                                        BLLreadMeterRecord.Excute(strSQLDelete);

                                        //回滚收费记录
                                        BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                        mes.Show("获取抄表记录ID失败,请重新操作!");
                                        return;
                                    }

                                    //if (isReCharge)
                                    //{
                                    try
                                    {

                                        if (labWaterUserID.Text != "")
                                        {
                                            //更新余额
                                            string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CHARGEYSJSYE + " WHERE waterUserId='" + labWaterUserID.Text + "'";
                                            if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                            {
                                                string strError = "更新用户编号为'" + labWaterUserID.Text + "'的余额失败,请重新操作!";
                                                mes.Show(strError);
                                                log.Write(strError, MsgType.Error);

                                                //如果有一条未插入成功，需要回滚已经插入成功的抄表记录
                                                string strSQLDelete = "DELETE FROM readMeterRecord WHERE readMeterRecordId='" + objRecordID.ToString()+ "'";
                                                BLLreadMeterRecord.Excute(strSQLDelete);

                                                //回滚收费记录
                                                BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                                return;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            //如果有一条未插入成功，需要回滚已经插入成功的抄表记录
                                            string strSQLDelete = "DELETE FROM readMeterRecord WHERE readMeterRecordId IN (" + strIDS + ")";
                                            BLLreadMeterRecord.Excute(strSQLDelete);

                                            //回滚收费记录
                                            BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                            return;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //如果有一条未插入成功，需要回滚已经插入成功的抄表记录
                                        string strSQLDelete = "DELETE FROM readMeterRecord WHERE readMeterRecordId IN (" + strIDS + ")";
                                        BLLreadMeterRecord.Excute(strSQLDelete);

                                        //回滚收费记录
                                        BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                        return;
                                    }
                                }
                                //}
                                btCancel.Enabled = false;
                                labTip.Visible = true;
                            }
                            catch (Exception ex)
                            {
                                //回滚收费记录
                                BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                mes.Show(ex.Message);
                                log.Write(ex.ToString(), MsgType.Error);
                                return;
                            }

                        }
                        else
                        {
                            mes.Show("生成红冲单据失败,请重新操作!");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show(ex.Message);
                        log.Write(ex.ToString(), MsgType.Error);
                        return;
                    }
                    #endregion
                }
                else
                {
                    mes.Show("系统检测到单据ID为空,请重新打开此窗体!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
