using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BASEFUNCTION;
using DBinterface.DAL;
using DBinterface.IDAL;
using Common.DotNetData;
using SysControl;
using Common.DotNetUI;
using BLL;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using Common.DotNetCode;
using FastReport;

namespace FinanceOS
{
    public partial class FrmFinance_Receivable_OP : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public string ResolveID = string.Empty;
        public string TaskID;
        private string _LastPointSort;
        public string PointSort = string.Empty;
        public string TableName = string.Empty;

        private string _SelectResolveID = "";
        private string strLogID;
        private string strName;
        private string strRealName;

        #region
        public bool IsCharge = false;

        //private string ComputerName = "";
        //private string ip = "";


        private decimal TotalFee = 0m;
        private decimal _DepTotalFee = 0m;
        //private decimal _Abate = 0m;
        private decimal _BCSS = 0m;
        private decimal _BCYS = 0m;

        // private int _State = 0;
        private string _FeeItems = "";
        //打印数据--格式：{ID|收费项目名称|单价|单位|数量|总费用}
        private string[] _PrintFeeItems;
        private int _FeeType = 0;
        private Hashtable hc = new Hashtable();

        private decimal _prestore = 0m;

        #endregion


        private BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        private Messages mes = new Messages();
        RMBToCapMoney RMBToCapMoney = new RMBToCapMoney();

        /// <summary>
        /// 收费明细列表 
        /// </summary>
        private DataTable dtFeeItems = new DataTable();

        /// <summary>
        /// 申请信息表
        /// </summary>
        private Hashtable htBaseMes = new Hashtable();

        /// <summary>
        /// 当前费用所属部门
        /// </summary>
        private string strFeeDepartMent = "";

        public FrmFinance_Receivable_OP()
        {
            InitializeComponent();
        }

     

        private void FrmFinance_Receivable_OP_Load(object sender, EventArgs e)
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

            BindChargeType();
            UserDataInit();
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
                RECEIPTNO.Text = (Convert.ToInt32(objMax)+1).ToString().PadLeft(8, '0');
            else
                RECEIPTNO.Text = "00000001";
        }

        private void UserDataInit()
        {
            string sqlstr = @"SELECT *,(SELECT Table_Name_CH FROM Meter_Table 
                                            WHERE TableID=VW.TableID) AS Table_Name_CH,
                                            (SELECT Table_Name FROM Meter_Table 
                                            WHERE TableID=VW.TableID) AS Table_Name,
                                            (SELECT Value FROM Meter_WorkTaskState WHERE ID=VW.[State]) AS StateName 
                                            FROM View_WorkBase VW 
                                            WHERE TaskID=@TaskID";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            htBaseMes = DataTableHelper.DataTableToHashtable(dt);
            new SqlServerHelper().BindHashTableToForm(htBaseMes, this.panel1.Controls);

            BindDepartmentFee();
        }

        private string GetPrintFee(string FeeID, string Fee)
        {
            string result = string.Empty;
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT TOP 1 * FROM Meter_FeeItmes WHERE FeeID =FeeID", new SqlParameter[] { new SqlParameter("@FeeID", FeeID) });
            if (DataTableHelper.IsExistRows(dt))
            {
                //{ID|收费项目名称|单价|单位|数量|总费用}
                DataRow dr = dt.Rows[0];
                decimal _Price = 0m;

                if (decimal.TryParse(dr["Price"].ToString(), out _Price))
                {
                    decimal _fee = 0m;
                    if (decimal.TryParse(Fee, out _fee))
                    {
                        _Price = _Price == 0m ? _fee : _Price;
                        if (_fee == 0m)
                        {
                            result = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                                                                 dt.Rows[0]["FeeID"].ToString(),
                                                                  dt.Rows[0]["FeeItem"].ToString(),
                                                                  _Price,
                                                                  dt.Rows[0]["Units"].ToString(),
                                                                  0,
                                                                  0
                                                                 );
                        }
                        else
                        {
                            result = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                                     dt.Rows[0]["FeeID"].ToString(),
                                      dt.Rows[0]["FeeItem"].ToString(),
                                      _Price,
                                      dt.Rows[0]["Units"].ToString(),
                                      (int)(_fee / _Price),
                                      Fee
                                     );
                        }
                    }

                }
                else
                {
                    result = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                                      dt.Rows[0]["FeeID"].ToString(),
                                       dt.Rows[0]["FeeItem"].ToString(),
                                       Fee,
                                       dt.Rows[0]["Units"].ToString(),
                                      1,
                                       Fee
                                      );
                }


            }

            return result;
        }

        #region
        private void BindChargeType()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT * FROM CHARGETYPE ");
            ControlBindHelper.BindComboBoxData(this.CHARGETYPEID, dt, "CHARGETYPENAME", "CHARGETYPEID");
        }

        private void BindDepartmentFee()
        {
            FP_Dep.Controls.Clear();
            DataTable dt = null;
            dt = sysidal.GetDepartMentFee(TaskID, PointSort);
            _LastPointSort = dt.Rows[0]["FeePointSort"].ToString();

            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_DepartmentFee UD = new UC_DepartmentFee();
                    UD.DataRowToProperty(dr);
                    UD.Button_Open_Click += new EventHandler(UD_Button_Open_Click);
                    FP_Dep.Controls.Add(UD);
                }

                TotalFee = sysidal.GetTotalFeeByPointSort(TaskID, _LastPointSort);
                LB_TotalFee.Text = string.Format("总计：{0}元", TotalFee);
            }
        }

        void UD_Button_Open_Click(object sender, EventArgs e)
        {
            UC_DepartmentFee UD = (UC_DepartmentFee)sender;
            FP_Items.Controls.Clear();
            _SelectResolveID = UD.ResolveID;
            strFeeDepartMent = UD.DepartmentName;

            dtFeeItems = sysidal.GetDepartMentFeeItems(_SelectResolveID);
            if (DataTableHelper.IsExistRows(dtFeeItems))
            {
                _FeeItems = "";
                foreach (DataRow dr in dtFeeItems.Rows)
                {
                    UC_ChargeItem UC = new UC_ChargeItem();
                    UC.FeeItem = string.Format("{0}:{1}元;", dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString());
                    _FeeItems += string.Format("{0}:{1};", dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString());
                    FP_Items.Controls.Add(UC);
                }

                _BCSS = string.IsNullOrEmpty(dtFeeItems.Rows[0]["FinalTotalFee"].ToString()) ? 0m : Convert.ToDecimal(dtFeeItems.Rows[0]["FinalTotalFee"].ToString());
                TOTALCHARGE.Text = _BCSS.ToString();
                CHARGEBCSS.Text = TOTALCHARGE.Text;
            }
        }

        #endregion

        private void CHARGETYPEID_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isshow = CHARGETYPEID.Text.Equals("POS机收费");
            LB_POSRUNNINGNO.Visible = isshow;
            POSRUNNINGNO.Visible = isshow;
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            if (sysidal.IsChargeOver(TaskID, _LastPointSort))
            {
                if (!Information.IsNumeric(RECEIPTNO.Text))
                {
                    MessageBox.Show("收据号只能由数字组成，请输入正确的收据号!");
                    RECEIPTNO.Focus();
                    return;
                }
                RECEIPTNO.Text = RECEIPTNO.Text.PadLeft(8, '0');

                Btn_Print.Enabled = false;

                int count = sysidal.UpdateApprove_defalut(TableName, ResolveID, true, "收费完成", PointSort, TaskID,"收费完成");

                if (count > 0)
                {
                    PrintReceipt(TaskID,_LastPointSort);

                    //更新预算收据号
                    string strSQL = string.Format(@"UPDATE Meter_Charge SET RECEIPTPRINTCOUNT=1,ReceiptPrintSign='1',ReceiptPrintTime=GETDATE(),RECEIPTNO='{1}'
WHERE CHARGEID IN (SELECT CHARGEID FROM View_TaskFee WHERE TaskID='{0}')", TaskID, RECEIPTNO.Text);
                    count = new SqlServerHelper().ExcuteSql(strSQL);
                    if (count == 0)
                        mes.Show("更新收据单号失败!");

                    mes.Show("收费完成!");
                }
                else
                {
                    Btn_Print.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("还有未收费项目！");
            }

        }
        /// <summary>
        /// 打印收条
        /// </summary>
        /// <param name="TaskID"></param>
        /// <param name="_LastPointSort"></param>
        private void PrintReceipt(string TaskID, string _LastPointSort)
        {
            //获取用户基本信息
            Hashtable ht = new SqlServerHelper().GetHashtableById("View_WorkBase", "TaskID", TaskID);
            if (ht.Contains("SD"))
            {
                string _waterUserId = ht["WATERUSERID"].ToString();
                string _waterUserName = ht["WATERUSERNAME"].ToString();
                string _SD = ht["SD"].ToString();
                string _waterUserAddress = ht["WATERUSERADDRESS"].ToString();
                string _TotalFee_CH = "";//合计大写

                //获取费用合计
                string sqlstr = @"SELECT * FROM 
(SELECT SUM(FEE) AS FEE,InvoiceType AS FEENAME,'0' AS SORT FROM 
(SELECT FEE,(SELECT InvoiceTitle FROM Meter_FeeItmes WHERE FeeID=MWF.FeeID) AS InvoiceType FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR 
WHERE MWF.ResolveID=MWR.ResolveID AND MWF.[STATE]=1 
AND MWR.TaskID=@TaskID AND PointSort=@LastPoingSort
) T GROUP BY InvoiceType
UNION ALL
SELECT SUM(CONVERT(decimal,Fee)),'合计','1' FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR 
WHERE MWF.ResolveID=MWR.ResolveID AND MWF.[STATE]=1
AND MWR.TaskID=@TaskID AND PointSort=@LastPoingSort) M WHERE FEE<>0";
                //FEE--收费金额
                //FEENAME--收费名称
                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@LastPoingSort", _LastPointSort) });
                if (DataTableHelper.IsExistRows(dt))
                {
                    DataRow[] DR = dt.Select("SORT=1");
                    if (DR.Length.Equals(1))
                    {
                        _TotalFee_CH = RMBHelper.CmycurD(decimal.Parse(DR[0]["FEE"].ToString()));
                    }

                    //====================================打印
                    DataSet ds = new DataSet();
                    DataTable dtTemp = dt.Copy();
                    dtTemp.TableName = "收据模板";
                    ds.Tables.Add(dtTemp);
                    FastReport.Report report1 = new FastReport.Report();

                    try
                    {
                        // load the existing report
                        report1.Load(Application.StartupPath + @"\PRINTModel\业扩模板\业扩预算收据模板.frx");

                        (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + RECEIPTNO.Text;
                        (report1.FindObject("txtWaterUserNO") as FastReport.TextObject).Text = "用 户 号:" + _waterUserId;
                        (report1.FindObject("txtSD") as FastReport.TextObject).Text = "受理编号:" + _SD;
                        (report1.FindObject("txtWaterUserName") as FastReport.TextObject).Text = "用户名称:"+_waterUserName;
                        (report1.FindObject("txtWaterUserAddress") as FastReport.TextObject).Text ="地    址:"+ _waterUserAddress;

                        (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + _TotalFee_CH;
                        (report1.FindObject("txtCasher") as FastReport.TextObject).Text = "收 款 员:" + strRealName;

                        (report1.FindObject("txtReceiptNO1") as FastReport.TextObject).Text = "NO." + RECEIPTNO.Text;
                        (report1.FindObject("txtWaterUserNO1") as FastReport.TextObject).Text = "用 户 号:" + _waterUserId;
                        (report1.FindObject("txtSD1") as FastReport.TextObject).Text = "受理编号:" + _SD;
                        (report1.FindObject("txtWaterUserName1") as FastReport.TextObject).Text = "用户名称:" + _waterUserName;
                        (report1.FindObject("txtWaterUserAddress1") as FastReport.TextObject).Text = "地    址:" + _waterUserAddress;

                        (report1.FindObject("txtCapMoney1") as FastReport.TextObject).Text = "金额大写:" + _TotalFee_CH;
                        (report1.FindObject("txtCasher1") as FastReport.TextObject).Text = "收 款 员:" + strRealName;

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
                        mes.Show("收据打印失败:"+ex.Message);
                    }

                }
            }
        }

        private bool Approve_Finance()
        {
            _prestore = sysidal.GetUserPrestore(TableName, TaskID);
            string _chargeID = sysidal.GetNewChargeID(strLogID);
            hc["TaskID"] = TaskID;
            hc["CHARGEClASS"] = 14;
            hc["TableName"] = TableName;
            hc["Prestore"] = _BCSS + _prestore;
            hc["CHARGEID"] = _chargeID;
            hc["TaskID"] = TaskID;
            hc["CHARGEBCSS"] = _BCSS;
            hc["CHARGEBCYS"] = _BCSS;
            hc["TOTALCHARGE"] = _BCSS;
            hc["FeeList"] = _FeeItems;
            hc["CHARGETYPEID"] = CHARGETYPEID.SelectedValue;
            hc["CHARGEWORKERID"] = strLogID;
            hc["CHARGEWORKERNAME"] = strRealName;
            hc["ReceiptPrintSign"] = "";
            hc["RECEIPTNO"] = "";  
            hc["POSRUNNINGNO"] = POSRUNNINGNO.Text;
            hc["Memo"] = Memo.Text;
            hc["LastPointSort"] = _LastPointSort;
            hc["ResolveID"] = _SelectResolveID;
            return sysidal.ApproveBudgetPrestore(hc);
        }

        private void Btn_Charge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TOTALCHARGE.Text.Trim()))
            {
                mes.Show("请选择收费项目!");
                return;
            }

            if (CHARGETYPEID.SelectedValue == null || CHARGETYPEID.SelectedValue == DBNull.Value)
            {
                mes.Show("收款方式不能为空!");
                CHARGETYPEID.Focus();
                return;
            }
            else
            {
                if (CHARGETYPEID.SelectedValue.ToString() == "2")
                {
                    if (POSRUNNINGNO.Text.Trim() == "")
                    {
                        mes.Show("请输入POS机收费的交易流水号!");
                        POSRUNNINGNO.Focus();
                        return;
                    }
                }
            }

            if (_BCSS > 0m)
            {
                if (Approve_Finance())
                {
                    mes.Show("收费成功！");
                    BindDepartmentFee();
                    TOTALCHARGE.Text = "";
                    CHARGEBCSS.Text = "";
                }
            }
            else
            {
                mes.Show("未检测到收费信息!");
            }

        }

    }
}
