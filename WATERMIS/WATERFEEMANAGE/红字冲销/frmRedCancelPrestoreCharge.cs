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
    public partial class frmRedCancelPrestoreCharge : Form
    {
        public frmRedCancelPrestoreCharge()
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

        BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        private void frmRedCancelCharge_Load(object sender, EventArgs e)
        {
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
                    objMes = dtList.Rows[0]["WATERUSERNO"];
                    if (objMes != null && objMes != DBNull.Value)
                    {
                        labWaterUserNO.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["WATERUSERNAME"];
                    if (objMes != null && objMes != DBNull.Value)
                    {
                        labWaterUserName.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["WATERUSERADDRESS"];
                    if (objMes != null && objMes != DBNull.Value)
                    {
                        labWaterUserAddress.Text = objMes.ToString();
                    }
                    objMes = dtList.Rows[0]["WATERUSERPHONE"];
                    if (objMes != null && objMes != DBNull.Value)
                    {
                        labWaterUserPhone.Text = objMes.ToString();
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
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (labID.Text != "")
                {
                    if (mes.ShowQ("确定要冲销单号为'" + labID.Text + "'的预存记录吗?")!= DialogResult.OK)
                    {
                        return;
                    }
                    
                    bool isReCharge = false;//是否将实收金额退还到用户余额标志
                    if (mes.ShowQ("是否将预存金额'" + labBCSZ.Text + "'从用户余额中扣除?") == DialogResult.OK)
                    {
                        isReCharge = true;
                    }
                    else
                        isReCharge = false;
                    #region 生成退费记录
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLogID, "WATERFEECHARGE");
                    MODELWATERFEECHARGE.CHARGEClASS = "5";//收费类型是冲销预存

                    if (Information.IsNumeric(labYE.Text))
                        MODELWATERFEECHARGE.CHARGEYSQQYE = Convert.ToDecimal(labYE.Text);

                    if (isReCharge)
                    {
                        if (Information.IsNumeric(labBCSZ.Text))
                            MODELWATERFEECHARGE.CHARGEYSBCSZ = 0-Convert.ToDecimal(labBCSZ.Text);

                            MODELWATERFEECHARGE.CHARGEYSJSYE = MODELWATERFEECHARGE.CHARGEYSQQYE + MODELWATERFEECHARGE.CHARGEYSBCSZ;
                            if (MODELWATERFEECHARGE.CHARGEYSJSYE < 0)
                            {
                                mes.Show("用户余额不足，无法冲销此单号，请先冲销生成的水费后重试!");
                                return;
                            }
                    }
                    else
                    {
                        MODELWATERFEECHARGE.CHARGEYSBCSZ = 0;
                        MODELWATERFEECHARGE.CHARGEYSJSYE = MODELWATERFEECHARGE.CHARGEYSQQYE;
                    }
                    MODELWATERFEECHARGE.CHARGEWORKERID = strLogID;
                    MODELWATERFEECHARGE.CHARGEWORKERNAME = strUserName;
                    MODELWATERFEECHARGE.CHARGEDATETIME = mes.GetDatetimeNow();
                    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                    MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 0;
                    MODELWATERFEECHARGE.MEMO = "红冲单号:" + labID.Text;
                    try
                    {
                        //插入收费记录
                        string strInserChargeSQL = "INSERT INTO WATERFEECHARGE(CHARGEID,TOTALNUMBERCHARGE,EXTRACHARGECHARGE1,EXTRACHARGECHARGE2," +
                            "WATERTOTALCHARGE,EXTRATOTALCHARGE,TOTALCHARGE,OVERDUEMONEY,CHARGETYPEID,CHARGEClASS,CHARGEBCYS,CHARGEBCSS,CHARGEYSQQYE," +
                            "CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME,INVOICEPRINTSIGN,RECEIPTPRINTCOUNT,MEMO) " +
                            "SELECT '" + MODELWATERFEECHARGE.CHARGEID + "',0-TOTALNUMBERCHARGE,0-EXTRACHARGECHARGE1,0-EXTRACHARGECHARGE2," +
                            "0-WATERTOTALCHARGE,0-EXTRATOTALCHARGE,0-TOTALCHARGE,0-OVERDUEMONEY,CHARGETYPEID,CHARGEClASS,0,0-CHARGEBCSS," +
                            MODELWATERFEECHARGE.CHARGEYSQQYE + "," + MODELWATERFEECHARGE.CHARGEYSBCSZ + "," +
                            MODELWATERFEECHARGE.CHARGEYSJSYE + ",CHARGEWORKERID,CHARGEWORKERNAME,'" + MODELWATERFEECHARGE.CHARGEDATETIME + "',0,0,'" +
                            MODELWATERFEECHARGE.MEMO + "' FROM WATERFEECHARGE WHERE CHARGEID='" + labID.Text+"'";

                        if (BLLreadMeterRecord.Excute(strInserChargeSQL)>0)
                        {

                            try
                            {
                                object objPrestoreID = dtList.Rows[0]["PRESTORERUNNINGACCOUNTID"];
                                if (objPrestoreID != null && objPrestoreID != DBNull.Value)
                                {
                                    string strPrestoreID = GETTABLEID.GetTableID("", "PRESTORERUNNINGACCOUNT");
                                    string strInserPrestore = "INSERT INTO [PRESTORERUNNINGACCOUNT]([PRESTORERUNNINGACCOUNTID],[CHARGEID],[WATERUSERID],[WATERUSERNO]" +
                                        ",[WATERUSERNAME],[WATERUSERPHONE],[WATERUSERADDRESS],[AREANO],[PIANNO],DUANNO,ORDERNUMBER,COMMUNITYID,COMMUNITYNAME,BUILDINGNO,UNITNO,"+
                                        "METERREADERID,METERREADERNAME,CHARGERID,CHARGERNAME,[WATERUSERTYPEID],[WATERUSERTYPENAME],WATERMETERTYPEID,"+
                                        "WATERMETERTYPEVALUE,WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,[WATERUSERHOUSETYPE],[MEMO]) " +
                                        "SELECT '" + strPrestoreID + "','" + MODELWATERFEECHARGE.CHARGEID + "'," + "[WATERUSERID],[WATERUSERNO]" +
                                        ",[WATERUSERNAME],[WATERUSERPHONE],[WATERUSERADDRESS],[AREANO],[PIANNO],DUANNO,ORDERNUMBER,COMMUNITYID,COMMUNITYNAME,BUILDINGNO,UNITNO,"+
                                        "METERREADERID,METERREADERNAME,CHARGERID,CHARGERNAME,[WATERUSERTYPEID],[WATERUSERTYPENAME],WATERMETERTYPEID,"+
                                        "WATERMETERTYPEVALUE,WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,[WATERUSERHOUSETYPE],'红冲单号:" + objPrestoreID.ToString() + "'" +
                                        " FROM PRESTORERUNNINGACCOUNT WHERE PRESTORERUNNINGACCOUNTID='" + objPrestoreID.ToString() + "'";
                                    if (BLLreadMeterRecord.Excute(strInserPrestore)>0)
                                    {
                                        if (isReCharge)
                                        {
                                            try
                                            {

                                                if (labWaterUserID.Text != "")
                                                {
                                                    //更新余额
                                                    string strUpdatePrestore = "UPDATE waterUser SET prestore+=" + MODELWATERFEECHARGE.CHARGEYSBCSZ + " WHERE waterUserId='" + labWaterUserID.Text + "'";
                                                    if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                                    {
                                                        string strError = "更新用户编号为'" + labWaterUserID.Text + "'的余额失败,请重新操作!";
                                                        mes.Show(strError);
                                                        log.Write(strError, MsgType.Error);
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    //如果余额无法更新，需要回滚已经插入成功的预存流水记录
                                                    BLLPRESTORERUNNINGACCOUNT.Delete(strPrestoreID);

                                                    //回滚收费记录
                                                    BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                                    return;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                //如果余额无法更新，需要回滚已经插入成功的预存流水记录
                                                BLLPRESTORERUNNINGACCOUNT.Delete(strPrestoreID);

                                                //回滚收费记录
                                                BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                                mes.Show(ex.Message);
                                                log.Write(ex.ToString(), MsgType.Error);
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //回滚收费记录
                                        BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                        mes.Show("插入预存流水记录失败,请重新操作!");
                                        return;
                                    }
                                }
                                else
                                {
                                    //回滚收费记录
                                    BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                    mes.Show("获取预存流水记录ID失败,请重新操作!");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                mes.Show(ex.Message);
                                log.Write(ex.ToString(), MsgType.Error);
                                //回滚收费记录
                                BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                return;
                            }
                            btCancel.Enabled = false;
                            labTip.Visible = true;
                        }
                        else
                        {
                            mes.Show("生成冲销单据失败,请重新操作!");
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
