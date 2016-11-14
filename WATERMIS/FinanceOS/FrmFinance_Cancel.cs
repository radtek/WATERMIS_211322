using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using Common.DotNetData;
using SysControl;
using DBinterface.IDAL;
using DBinterface.DAL;
using Microsoft.VisualBasic;
using BASEFUNCTION;

namespace FinanceOS
{
    public partial class FrmFinance_Cancel : Form
    {
        private string _ChargeID;

        public string ChargeID
        {
            get { return _ChargeID; }
            set { _ChargeID = value; }
        }

        public string TaskID;

        public string ChargerID=string.Empty;

        /// <summary>
        /// 预算费用明细列表，用于补打收据用
        /// </summary>
        DataTable dtFeeList = new DataTable();

        /// <summary>
        /// 预算总费用，用于补打收据用
        /// </summary>
        decimal decSum_IsFinal0 = 0;

        Messages mes = new Messages();
        RMBToCapMoney RMBToCapMoney = new RMBToCapMoney();

        private string strLogID="";

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        public FrmFinance_Cancel()
        {
            InitializeComponent();
        }

        private void FrmFinance_Cancel_Load(object sender, EventArgs e)
        {
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            {
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            }

            ShowData();

            GetMaxReceiptNO();
        }

        /// <summary>
        /// 获取当前收费员最大8位收据号
        /// </summary>
        private void GetMaxReceiptNO()
        {
            string strSQL = "SELECT TOP 1 RECEIPTNO FROM Meter_Charge WHERE RECEIPTNO<>N'' AND CHARGEWORKERID=@CHARGEWORKERID ORDER BY ReceiptPrintTime DESC";
            object objMax = new SqlServerHelper().GetFirsRowsValue(strSQL, new SqlParameter[] { new SqlParameter("@CHARGEWORKERID", strLogID) });
            if (Information.IsNumeric(objMax))
                TB_RECEIPTNO.Text = (Convert.ToInt32(objMax)+1).ToString().PadLeft(8, '0');
            else
                TB_RECEIPTNO.Text = "00000001";
        }

        private void ShowData()
        {
            string sqlstr = "SELECT MC.*,CT.CHARGETYPENAME,CC.CHARGEClASSNAME,CASE WHEN MC.MONTHCHECKSTATE=0 THEN '-' ELSE '已审核' END AS MONTHCHECKSTATENAME FROM Meter_Charge MC,CHARGETYPE CT,CHARGEClASS CC WHERE MC.CHARGETYPEID=CT.CHARGETYPEID AND MC.CHARGEClASS=CC.CHARGEClASS AND MC.CHARGEID=@CHARGEID";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@CHARGEID", _ChargeID) });

            Hashtable ht = DataTableHelper.DataTableToHashtable(dt);
            new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);

            ht = new SqlServerHelper().GetHashtableById("View_WorkBase", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(ht, this.panel2.Controls);

            dt = new SqlServerHelper().GetDataTable("Meter_WorkResolveFee", "ChargeID='" + _ChargeID + "'", "ChargeDate");
            FP.Controls.Clear();
            if (DataTableHelper.IsExistRows(dt))
            {
                //显示结算类型
                object objIsFinal = dt.Rows[0]["IsFinal"];
                if (objIsFinal != null && objIsFinal != DBNull.Value)
                {
                    labIsFinal.Text = (Convert.ToBoolean(objIsFinal) == true ? "预算收费" : "决算收费");
                    if (Convert.ToBoolean(objIsFinal))
                    {
                        //获取预算收据打印表
                        string strSQL = string.Format(@"SELECT SUM(FEE) AS FEE,InvoiceType AS FEENAME,'0' AS SORT FROM 
                                (SELECT FEE,(SELECT InvoiceTitle FROM Meter_FeeItmes WHERE FeeID=MWF.FeeID) AS InvoiceType 
                                FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR 
                                WHERE MWF.ResolveID=MWR.ResolveID AND MWF.[STATE]=1 
                                AND MWR.TaskID='{0}' AND IsFinal='1'
                                ) T GROUP BY InvoiceType", TaskID);
                        dtFeeList = new SqlServerHelper().GetDateTableBySql(strSQL);

                        object objSum = dtFeeList.Compute("SUM(FEE)", "");
                        if (Information.IsNumeric(objSum))
                        {
                            DataRow dr = dtFeeList.NewRow();
                            dr["FEENAME"] = "合计";
                            decSum_IsFinal0= Convert.ToDecimal(objSum);
                            dr["FEE"] = decSum_IsFinal0.ToString("F2");
                            dtFeeList.Rows.Add(dr);
                        }
                    }
                }
                else
                    labIsFinal.Text = "";

                foreach (DataRow dr in dt.Rows)
                {
                    UC_ChargeItem UC = new UC_ChargeItem();
                    UC.FeeItem = string.Format("{0}:{1}", dr["FeeItem"].ToString(), dr["Fee"].ToString());

                    FP.Controls.Add(UC);
                }
            }

            string _Loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            bool _IsAllow = true;
            if (_Loginid.Equals(ChargerID))
            {
                _IsAllow = false;
                Btn_Print.Enabled = true;
            }
            else
            {
                Btn_Print.Enabled = false;
            }

            sqlstr = string.Format(@"SELECT COUNT(*) FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID
AND MW.[State]=1 AND MW.PointSort=MWR.PointSort AND MW.TaskID=@TaskID AND MWR.loginId LIKE '%{0}%'", _Loginid);
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                _IsAllow = false;
            }

            sqlstr = @"SELECT COUNT(0) FROM Meter_Charge WHERE CHARGEWORKERID='0092' AND ISNULL(MONTHCHECKSTATE,'')<>'1' AND ISNULL(CHARGECANCEL,'')<>'1' AND TaskID=@TaskID
AND CHARGEID=@CHARGEID";
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@CHARGEID", _ChargeID) });
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                _IsAllow = false;
            }

            Btn_Cancel.Visible = _IsAllow;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            if (sysidal.CancelCharge(TaskID, _ChargeID, CANCELMEMO.Text))
            {
                MessageBox.Show("取消收费成功！");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(TB_RECEIPTNO.Text))
            {
                MessageBox.Show("收据号只能由数字组成，请输入正确的收据号!");
                TB_RECEIPTNO.Focus();
                return;
            }
            TB_RECEIPTNO.Text = TB_RECEIPTNO.Text.PadLeft(8, '0');
            if (labIsFinal.Text == "预算收费")
            {
                #region 打印预算收据
                if (dtFeeList.Rows.Count == 0)
                {
                    mes.Show("预算费用明细表为空,请重新打开窗体!");
                    return;
                }
                //====================================打印
                DataSet ds = new DataSet();
                DataTable dtTemp = dtFeeList.Copy();
                dtTemp.TableName = "收据模板";
                ds.Tables.Add(dtTemp);
                FastReport.Report report1 = new FastReport.Report();

                try
                {
                    string strCapMoney = RMBToCapMoney.CmycurD(decSum_IsFinal0);//金额大写

                    // load the existing report
                    report1.Load(Application.StartupPath + @"\PRINTModel\业扩模板\业扩预算收据模板.frx");

                    (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + TB_RECEIPTNO.Text;
                    (report1.FindObject("txtWaterUserNO") as FastReport.TextObject).Text = "用 户 号:" + waterUserId.Text;
                    (report1.FindObject("txtSD") as FastReport.TextObject).Text = "受理编号:" + SD.Text;
                    (report1.FindObject("txtWaterUserName") as FastReport.TextObject).Text = "用户名称:" + waterUserName.Text;
                    (report1.FindObject("txtWaterUserAddress") as FastReport.TextObject).Text = "地    址:" + waterUserAddress.Text;

                    (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;
                    (report1.FindObject("txtCasher") as FastReport.TextObject).Text = "收 款 员:" + CHARGEWORKERNAME.Text;

                    (report1.FindObject("txtReceiptNO1") as FastReport.TextObject).Text = "NO." + TB_RECEIPTNO.Text;
                    (report1.FindObject("txtWaterUserNO1") as FastReport.TextObject).Text = "用 户 号:" + waterUserId.Text;
                    (report1.FindObject("txtSD1") as FastReport.TextObject).Text = "受理编号:" + SD.Text;
                    (report1.FindObject("txtWaterUserName1") as FastReport.TextObject).Text = "用户名称:" + waterUserName.Text;
                    (report1.FindObject("txtWaterUserAddress1") as FastReport.TextObject).Text = "地    址:" + waterUserAddress.Text;

                    (report1.FindObject("txtCapMoney1") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;
                    (report1.FindObject("txtCasher1") as FastReport.TextObject).Text = "收 款 员:" + CHARGEWORKERNAME.Text;

                    // register the dataset
                    report1.RegisterData(ds);
                    report1.GetDataSource("收据模板").Enabled = true;
                    //report1.Show();
                    report1.PrintSettings.ShowDialog = false;
                    report1.Prepare();
                    report1.Print();
                }
                catch (Exception ex)
                {
                    mes.Show("收据打印失败:" + ex.Message);
                }

                //更新预算收据号
                string strSQL = string.Format(@"UPDATE Meter_Charge SET RECEIPTPRINTCOUNT=1,ReceiptPrintSign='1',ReceiptPrintTime=GETDATE(),
RECEIPTNO='{1}' WHERE CHARGEID IN (SELECT CHARGEID FROM View_TaskFee WHERE TaskID='{0}' AND IsFinal='1')", TaskID, TB_RECEIPTNO.Text);
               int count = new SqlServerHelper().ExcuteSql(strSQL);
                if (count == 0)
                    mes.Show("更新收据单号失败!");
                #endregion
            }
            else
            {
                #region 打印决算收据
                try
                {
                    decimal decBCSS=0;
                    if (Information.IsNumeric(CHARGEBCSS.Text))
                        decBCSS = Convert.ToDecimal(CHARGEBCSS.Text);

                    string strCapMoney = RMBToCapMoney.CmycurD(decBCSS);//金额大写

                    FastReport.Report report1 = new FastReport.Report();
                    // load the existing report
                    report1.Load(Application.StartupPath + @"\PRINTModel\业扩模板\业扩决算收据模板.frx");

                    (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + TB_RECEIPTNO.Text;
                    (report1.FindObject("txtWaterUserNO") as FastReport.TextObject).Text = "用 户 号:" + waterUserId.Text;
                    (report1.FindObject("txtSD") as FastReport.TextObject).Text = "受理编号:" + SD.Text;
                    (report1.FindObject("txtWaterUserName") as FastReport.TextObject).Text = "用户名称:" + waterUserName.Text;
                    (report1.FindObject("txtWaterUserAddress") as FastReport.TextObject).Text = "地    址:" + waterUserAddress.Text;

                    if (!CHARGETYPENAME.Text.Equals("现金"))
                        (report1.FindObject("txtRunningNO") as FastReport.TextObject).Text = "交易流水号:" + POSRUNNINGNO.Text;
                    else
                        (report1.FindObject("txtRunningNO") as FastReport.TextObject).Text = "";

                    (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;
                    (report1.FindObject("txtCasher") as FastReport.TextObject).Text = "收 款 员:" + CHARGEWORKERNAME.Text;
                    if (decBCSS < 0)
                    {
                        (report1.FindObject("txtWaterUserSign") as FastReport.TextObject).Text = "用户签字:";
                        (report1.FindObject("txtBCSS") as FastReport.TextObject).Text = "本次退款:" + decBCSS.ToString("F2") + "元";
                    }
                    else
                    {
                        (report1.FindObject("txtWaterUserSign") as FastReport.TextObject).Text = "";
                        (report1.FindObject("txtBCSS") as FastReport.TextObject).Text = "本次实收:" + decBCSS.ToString("F2") + "元";
                    }

                    (report1.FindObject("txtReceiptNO1") as FastReport.TextObject).Text = "NO." + TB_RECEIPTNO.Text;
                    (report1.FindObject("txtWaterUserNO1") as FastReport.TextObject).Text = "用 户 号:" + waterUserId.Text;
                    (report1.FindObject("txtSD1") as FastReport.TextObject).Text = "受理编号:" + SD.Text;
                    (report1.FindObject("txtWaterUserName1") as FastReport.TextObject).Text = "用户名称:" + waterUserName.Text;
                    (report1.FindObject("txtWaterUserAddress1") as FastReport.TextObject).Text = "地    址:" + waterUserAddress.Text;

                    if (!CHARGETYPENAME.Text.Equals("现金"))
                        (report1.FindObject("txtRunningNO1") as FastReport.TextObject).Text = "交易流水号:" + POSRUNNINGNO.Text;
                    else
                        (report1.FindObject("txtRunningNO1") as FastReport.TextObject).Text = "";
                    (report1.FindObject("txtCapMoney1") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;
                    (report1.FindObject("txtCasher1") as FastReport.TextObject).Text = "收 款 员:" + CHARGEWORKERNAME.Text;
                    if (decBCSS < 0)
                    {
                        (report1.FindObject("txtWaterUserSign1") as FastReport.TextObject).Text = "用户签字:";
                        (report1.FindObject("txtBCSS1") as FastReport.TextObject).Text = "本次退款:" + decBCSS.ToString("F2") + "元";
                    }
                    else
                    {
                        (report1.FindObject("txtWaterUserSign1") as FastReport.TextObject).Text = "";
                        (report1.FindObject("txtBCSS1") as FastReport.TextObject).Text = "本次实收:" + decBCSS.ToString("F2") + "元";
                    }

                    //report1.Show();
                    report1.PrintSettings.ShowDialog = false;
                    report1.Prepare();
                    report1.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("收据打印失败:" + ex.Message);
                }
                #endregion

                //更新预算收据号
                string strSQL = string.Format(@"UPDATE Meter_Charge SET RECEIPTPRINTCOUNT=1,ReceiptPrintSign='1',ReceiptPrintTime=GETDATE(),
RECEIPTNO='{1}' WHERE CHARGEID='{0}'", _ChargeID,TB_RECEIPTNO.Text);
                int count = new SqlServerHelper().ExcuteSql(strSQL);
                if (count == 0)
                    mes.Show("更新收据单号失败!");
            }
            if (Information.IsNumeric(TB_RECEIPTNO.Text))
                TB_RECEIPTNO.Text = (Convert.ToInt32(TB_RECEIPTNO.Text) + 1).ToString().PadLeft(8, '0');
            else
                TB_RECEIPTNO.Text = "00000001";
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
