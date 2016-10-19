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
using Common.WinDevices;
using Common.DotNetUI;
using BASEFUNCTION;

namespace PersonalWork
{
    public partial class FrmApprove_Refund : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;

        private bool skip = false;

        //增加收费员ID和收费员姓名===
        private string strLoginID = "";
        private string strUserName = "";
        //============================

        public FrmApprove_Refund()
        {
            InitializeComponent();
        }

        private void FrmApprove_Refund_Load(object sender, EventArgs e)
        {
            //判断能否获取到收费员ID和收费员姓名============
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            {
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            }
            else
            {
                MessageBox.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }
            //==========================
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            BindCombox();
            InitData();
            InitView();
        }
        private void BindCombox()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("CHARGETYPE", "", "CHARGETYPEID");

            ControlBindHelper.BindComboBoxData(this.CHARGETYPEID, dt, "CHARGETYPENAME", "CHARGETYPEID");
        }
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            int count = sysidal.UpdateApprove_Refund_defalut(ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), PointSort, TaskID);
            if (count > 0)
            {
                if (sysidal.IsWorkTaskOver("User_Refund", TaskID))//获取审批状态，如果是Meter_WorkTask.state=5 和User_Refund.state=5,说明审批流程走完
                {
                    bool IsUserRefund = false;
                    //======================================================================================================

                    #region 20160909 ByRen
                    //修改PersonalWork_DAL类函数GetUserAllowRefund，增加预存单号ID、地址、账户余额字段,修改查询条件VV.CHARGEBCSS<=VW.prestore
                    //using BASEFUNCTION;//引用基本函数类，获取收费ID
                    //增加收费员ID和收费员姓名 
                    //private string strLoginID = "";
                    //private string strUserName = "";
                    //在窗体加载时判断能否获取到收费员ID和姓名
                    //在类SqlServerHelper内添加自定义执行函数ExcuteSql
                    //新建@"\PRINTModel\收据模板\审批_退费模板.frx"打印模板
                    //-----增加了打印收据，应增加加打印收据勾选框及收据号
                    //引用fastreport类
                    //添加了退款单号的更新

                    string strWaterUserID = "", strWaterUserName = "", strWaterUserAddress = "", strChargeIDOld = "", strPrestoreRunningAccountIDOld = "",
                        strChargeIDNew = "", strPrestoreRunningAccountIDNew = "";
                    decimal decPrestore = 0, decRefund = 0;

                    DateTime dtNow = new DateTime();
                    Messages mes = new Messages();
                    dtNow = mes.GetDatetimeNow();

                    Hashtable ht = sysidal.GetUserAllowRefund(CHARGEID_IN.Text);
                    object objWaterUser = ht["WATERUSERNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        strWaterUserID = objWaterUser.ToString();

                        objWaterUser = ht["APPLYUSER"];
                        if (objWaterUser != null && objWaterUser != DBNull.Value)
                            strWaterUserName = objWaterUser.ToString();

                        objWaterUser = ht["WATERUSERADDRESS"];
                        if (objWaterUser != null && objWaterUser != DBNull.Value)
                            strWaterUserAddress = objWaterUser.ToString();

                        objWaterUser = ht["CHARGEID"];
                        if (objWaterUser != null && objWaterUser != DBNull.Value)
                            strChargeIDOld = objWaterUser.ToString();

                        objWaterUser = ht["PRESTORERUNNINGACCOUNTID"];
                        if (objWaterUser != null && objWaterUser != DBNull.Value)
                            strPrestoreRunningAccountIDOld = objWaterUser.ToString();

                        try
                        {
                            objWaterUser = ht["PRESTORE"];
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                                decPrestore = Convert.ToDecimal(objWaterUser);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            decRefund = Convert.ToDecimal(CHARGEBCSS_IN.Text);
                        }
                        catch (Exception ex)
                        {

                        }

                        GETTABLEID GETTABLEID = new GETTABLEID();
                        strChargeIDNew = GETTABLEID.GetTableID(strLoginID, "WATERFEECHARGE");
                        strPrestoreRunningAccountIDNew = GETTABLEID.GetTableID(strLoginID, "PRESTORERUNNINGACCOUNT");

                        string strSQL = string.Format(@"
BEGIN TRAN
BEGIN
INSERT INTO PRESTORERUNNINGACCOUNT(PRESTORERUNNINGACCOUNTID,CHARGEID,WATERUSERID,WATERUSERNO,WATERUSERNAME,WATERUSERNAMECODE,WATERUSERPHONE,WATERUSERADDRESS,WATERUSERPEOPLECOUNT,AREANO,PIANNO,DUANNO,
ORDERNUMBER,COMMUNITYID,COMMUNITYNAME,BUILDINGNO,UNITNO,METERREADERID,METERREADERNAME,CHARGERID,CHARGERNAME,WATERUSERTYPEID,WATERUSERTYPENAME,WATERMETERTYPEID,
WATERMETERTYPEVALUE,WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,WATERUSERHOUSETYPE,CREATETYPE)  
SELECT '{0}','{1}',WATERUSERID,WATERUSERNO,WATERUSERNAME,WATERUSERNAMECODE,WATERUSERPHONE,WATERUSERADDRESS,WATERUSERPEOPLECOUNT,AREANO,PIANNO,DUANNO,
ORDERNUMBER,COMMUNITYID,COMMUNITYNAME,BUILDINGNO,UNITNO,METERREADERID,METERREADERNAME,CHARGERID,CHARGERNAME,WATERUSERTYPEID,WATERUSERTYPENAME,WATERMETERTYPEID,
WATERMETERTYPEVALUE,WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,WATERUSERHOUSETYPE,CREATETYPE FROM PRESTORERUNNINGACCOUNT 
WHERE PRESTORERUNNINGACCOUNTID='{2}'", strPrestoreRunningAccountIDNew, strChargeIDNew, strPrestoreRunningAccountIDOld);

                        strSQL += string.Format(@"
INSERT INTO WATERFEECHARGE(CHARGEID,CHARGETYPEID,CHARGEClASS,CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME,RECEIPTNO)
SELECT '{0}','1','6',-{1},{2},-{3},{4},'{5}','{6}',GETDATE(),RECEIPTNO FROM WATERFEECHARGE WHERE CHARGEID='{7}'",
    strChargeIDNew, decRefund, decPrestore, decRefund, decPrestore - decRefund, strLoginID, strUserName, strChargeIDOld);

                        strSQL += string.Format(@"
UPDATE WATERUSER SET PRESTORE={0} WHERE WATERUSERID='{1}'", decPrestore - decRefund, strWaterUserID);

                        strSQL += @"END
IF(@@ERROR>0)
BEGIN
ROLLBACK TRAN
RETURN
END
COMMIT TRAN
";

                        int intRows = 0;
                        try
                        {
                            intRows = new SqlServerHelper().ExcuteSql(strSQL);
                        }
                        catch (Exception ex)
                        {
                            mes.Show("执行退款语句失败,原因:" + ex.Message);
                            return;
                        }
                        if (intRows > 0)
                        {
                            IsUserRefund = true;
                            //打印收据
                            FastReport.Report report1 = new FastReport.Report();
                            try
                            {
                                // load the existing report
                                report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\审批_退费模板.frx");
                                (report1.FindObject("CellWaterUserNO") as FastReport.Table.TableCell).Text = strWaterUserID;
                                (report1.FindObject("CellWaterUserName") as FastReport.Table.TableCell).Text = strWaterUserName;
                                (report1.FindObject("CellWaterUserAddress") as FastReport.Table.TableCell).Text = strWaterUserAddress;
                                (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额:            " + decPrestore.ToString("F2");
                                (report1.FindObject("txtBCJF") as FastReport.TextObject).Text = "本次退费: " + (0 - decRefund).ToString();
                                (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额:            " + (decPrestore - decRefund).ToString("F2");
                                (report1.FindObject("txtChargeWorkerName") as FastReport.TextObject).Text = strUserName;
                                (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO.";

                                (report1.FindObject("txtMeterReader") as FastReport.TextObject).Text = "抄表员";
                                report1.Prepare();
                                report1.PrintSettings.ShowDialog = false;
                                report1.Print();
                            }
                            catch (Exception ex)
                            {
                                mes.Show("打印收据错误,原因:" + ex.Message);
                            }
                            finally
                            {
                                // free resources used by report
                                report1.Dispose();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("账户余额不足或收款单号不存在,无法退款!");
                        return;
                    }
                    #endregion
                    if (IsUserRefund)
                    {
                        Hashtable hu = new Hashtable();

                        //退款时间：CHARGEID_OutTime
                        //退款金额： CHARGEBCSS_Out
                        //退款人ID：CHARGEWORKERID
                        //退款人：CHARGEWORKERNAME
                        //退款状态：IsRefund;0-未退款，1-已退款

                        hu["IsRefund"] = 1;
                        hu["CHARGEWORKERNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                        hu["CHARGEWORKERID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                        hu["CHARGEID_OutTime"] = DateTime.Now.ToString();
                        hu["CHARGEBCSS_Out"] = 0;//=====================================================

                        //添加退款单号 ByRen
                        hu["CHARGEID_Out"] = strChargeIDNew;

                        int upCount = new SqlServerHelper().UpdateByHashtable("User_Refund", "TaskID", TaskID, hu);

                        if (upCount > 0)
                        {
                            this.DialogResult = DialogResult.OK;
                            MessageBox.Show("退款成功！");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("退款成功 ，记录保存失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("退款失败！");
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

        private void IsPass_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPass.Checked)
            {
                IsPass.Text = "同意";
                if (skip)
                {
                    IsSkip.Visible = false;
                    LB_GoPointID.Visible = false;
                    CB_GoPointID.Visible = false;
                    IsSkip.Checked = false;
                    CB_GoPointID.Text = "";
                }
            }
            else
            {
                IsPass.Text = "不同意";
                if (skip)
                {
                    IsSkip.Visible = true;
                    LB_GoPointID.Visible = true;
                    CB_GoPointID.Visible = true;
                }
            }
        }

        private void Btn_Voided_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            Btn_Voided.Enabled = false;
            int count = sysidal.UpdateApprove_Refund_Voided(ResolveID, UserOpinion.Text.Trim(), TaskID);

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

        private void InitData()
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("User_Refund", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);
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

    }
}
