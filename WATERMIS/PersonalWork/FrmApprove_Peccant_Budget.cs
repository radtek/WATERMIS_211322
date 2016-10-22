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
using Common.DotNetData;
using SysControl;
using Common.DotNetUI;
using Microsoft.VisualBasic;
using BASEFUNCTION;
using BLL;

namespace PersonalWork
{
    public partial class FrmApprove_Peccant_Budget : Form
    {

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;

        private string ComputerName = "";
        private string ip = "";
        private string strLogID;
        private string strName;
        private string strRealName;

        private decimal TotalFee = 0m;
        private decimal _DepTotalFee = 0m;
        //private decimal _Abate = 0m;
        private decimal _BCSS = 0m;
        private decimal _BCYS = 0m;
        private decimal _prestore = 0m;
       // private bool _IsFinal = false;
        private string _SelectResolveID = "";

        private string _LastPointSort ;
       // private int _State = 0;
        private string _FeeItems = "";
        //打印数据--格式：{ID|收费项目名称|单价|单位|数量|总费用}
        private string[] _PrintFeeItems;
        private int _FeeType = 0;
        private Hashtable hc = new Hashtable();

        public FrmApprove_Peccant_Budget()
        {
            InitializeComponent();
        }
        #region
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void FrmApprove_Single_Budget_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            hc["TaskID"] = TaskID;

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

            BindDepartmentFee();

            GetReceiptNO();

            GetBaseMes();
        }
        private void BindDepartmentFee()
        {
            FP_Dep.Controls.Clear();

            DataTable dt = sysidal.GetDepartMentFee(TaskID, PointSort);
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_DepartmentFee UD = new UC_DepartmentFee();
                    UD.DataRowToProperty(dr);
                    UD.Button_Open_Click += new EventHandler(UD_Button_Open_Click);
                    FP_Dep.Controls.Add(UD);
                }

                _LastPointSort = dt.Rows[0]["FeePointSort"].ToString();
                TotalFee = sysidal.GetTotalFeeByPointSort(TaskID, _LastPointSort);
                
                LB_TotalFee.Text = string.Format("总计：{0}元", TotalFee);
            }
        }

        //=============================ByRen201610170926=====================================

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

        /// <summary>
        /// 获取最大收据号
        /// </summary>
        private void GetReceiptNO()
        {
            //获取新的收据号码,8位收据号
            DataTable dtNewReceriptNO = BLLWATERFEECHARGE.GetMaxReceiptNO(strLogID);
            if (dtNewReceriptNO.Rows.Count > 0)
            {
                object objReceiptNO = dtNewReceriptNO.Rows[0]["RECEIPTNO"];
                if (Information.IsNumeric(objReceiptNO))
                {
                    RECEIPTNO.Text = (Convert.ToInt64(objReceiptNO) + 1).ToString().PadLeft(8, '0');
                }
            }
        }

        /// <summary>
        /// 获取用户基础信息
        /// </summary>
        private void GetBaseMes()
        {
            htBaseMes = sysidal.GetMeter_Install_PeccantInfos(TaskID);
        }
        //===================================================================================

        void UD_Button_Open_Click(object sender, EventArgs e)
        {
            UC_DepartmentFee UD = (UC_DepartmentFee)sender;
            FP_Items.Controls.Clear();
            _SelectResolveID = UD.ResolveID;

            strFeeDepartMent = UD.DepartmentName;  //获取当前费用所属部门

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

               // LB_TotalFee.Text = string.Format("{0}-费用总计：{1}元", UD.DepartmentName, dt.Rows[0]["DepartTotalFee"].ToString());
                _BCSS = string.IsNullOrEmpty(dtFeeItems.Rows[0]["FinalTotalFee"].ToString()) ? 0m : Convert.ToDecimal(dtFeeItems.Rows[0]["FinalTotalFee"].ToString());
                TOTALCHARGE.Text = _BCSS.ToString();
                CHARGEBCSS.Text = TOTALCHARGE.Text;
            }
        }

        private void BindChargeType()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT * FROM CHARGETYPE ");
            ControlBindHelper.BindComboBoxData(this.CHARGETYPEID, dt, "CHARGETYPENAME", "CHARGETYPEID");
        }
        #endregion

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            if (RECEIPTNO.Text.Trim() == "")
            {
                mes.Show("请输入收据号!");
                RECEIPTNO.Focus();
                return;
            }
            if (!Information.IsNumeric(RECEIPTNO.Text))
            {
                mes.Show("收据号只能由数字组成!");
                RECEIPTNO.SelectAll();
                return;
            }
            RECEIPTNO.Text = RECEIPTNO.Text.PadLeft(8, '0');
            if (BLLWATERFEECHARGE.IsExistReceiptNO(RECEIPTNO.Text))
            {
                if (mes.ShowQ("系统检测到号码为'" + RECEIPTNO.Text + "'的收据已使用,确定使用此号码吗?") != DialogResult.OK)
                {
                    RECEIPTNO.SelectAll();
                    return;
                }
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
                    //===================================ByRen201610170956===================================================打印收据
                    #region
                    FastReport.Report report1 = new FastReport.Report();
                    try
                    {
                        string strWaterUserName = "", strAddress = "", strFeeName = "";
                        DateTime dtNow = mes.GetDatetimeNow(); //获取收据打印时间
                        decimal decDepSum = 0;

                        object objMes = htBaseMes["WATERUSERNAME"];
                        if (objMes != null && objMes != DBNull.Value)
                            strWaterUserName = objMes.ToString();

                        objMes = htBaseMes["WATERUSERADDRESS"];
                        if (objMes != null && objMes != DBNull.Value)
                            strAddress = objMes.ToString();

                        for (int i = 0; i < dtFeeItems.Rows.Count; i++)
                        {
                            string strFeeNameSingle = "";
                            decimal decFeeSingle = 0;

                            object obj = dtFeeItems.Rows[i]["FeeItem"];
                            if (obj != null && obj != DBNull.Value)
                                strFeeNameSingle = obj.ToString();

                            obj = dtFeeItems.Rows[i]["Fee"];
                            if (Information.IsNumeric(obj))
                                decFeeSingle = Convert.ToDecimal(obj);

                            if (strFeeName == "")
                                strFeeName = strFeeNameSingle + ":" + decFeeSingle.ToString("F2");
                            else
                                strFeeName += "\r\n" + strFeeNameSingle + ":" + decFeeSingle.ToString("F2");

                            decDepSum += decFeeSingle;
                        }

                        report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\报装预算收据.frx");

                        (report1.FindObject("CellWaterUserName") as FastReport.Table.TableCell).Text = strWaterUserName;
                        (report1.FindObject("CellWaterUserAddress") as FastReport.Table.TableCell).Text = strAddress;

                        (report1.FindObject("txtBCSS") as FastReport.TextObject).Text = "本次实收: " + _BCSS.ToString("F2");
                        (report1.FindObject("txtYSZJ") as FastReport.TextObject).Text = "预算总计: " + _BCSS.ToString("F2");
                        (report1.FindObject("txtFeeDetailSummery") as FastReport.TextObject).Text = strFeeDepartMent + "预算明细: ";
                        (report1.FindObject("txtFeeDetail") as FastReport.TextObject).Text = strFeeName;

                        (report1.FindObject("txtChargeWorkerName") as FastReport.TextObject).Text = strRealName;
                        (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + RECEIPTNO.Text.PadLeft(8, '0');

                        string strCapMoney = RMBToCapMoney.CmycurD(_BCSS.ToString("F2"));
                        if (CHARGETYPEID.SelectedValue.ToString() == "2")
                        {
                            (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney + "   " + "交易流水号:" + POSRUNNINGNO.Text;
                        }
                        else
                            (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;

                        report1.PrintSettings.ShowDialog = false;
                        report1.Prepare();
                        report1.Print();

                        //获取新的收据号码,8位收据号
                        if (Information.IsNumeric(RECEIPTNO.Text))
                        {
                            RECEIPTNO.Text = (Convert.ToInt64(RECEIPTNO.Text) + 1).ToString().PadLeft(8, '0');
                        }
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show(exx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // free resources used by report
                        report1.Dispose();
                    }
                    #endregion
                    //=========================================================================

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

        private bool Approve_Finance()
        {
            string _chargeID = sysidal.GetNewChargeID(strLogID);
            hc["CHARGEClASS"] = 14;
            hc["TableName"] = "Meter_Install_Peccant";
            hc["Prestore"] =  _BCSS + _prestore;
            hc["CHARGEID"] = _chargeID;
            hc["TaskID"] = TaskID;
            hc["CHARGEBCSS"] = _BCSS;
            hc["CHARGEBCYS"] = _BCSS;
            hc["TOTALCHARGE"] = _BCSS;
            hc["FeeList"] = _FeeItems;
            hc["CHARGETYPEID"] = CHARGETYPEID.SelectedValue;
            hc["CHARGEWORKERID"] = strLogID;
            hc["CHARGEWORKERNAME"] = strRealName;
            hc["ReceiptPrintSign"] = ReceiptPrintSign.Checked;
            hc["RECEIPTNO"] = RECEIPTNO.Text.Trim().PadLeft(8, '0');  //保存8位收据号
            hc["POSRUNNINGNO"] = POSRUNNINGNO.Text;
            hc["Memo"] = Memo.Text;
            hc["LastPointSort"] = _LastPointSort;
            hc["ResolveID"] = _SelectResolveID;
            return sysidal.ApproveBudgetPrestore(hc);
        }


        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (sysidal.IsChargeOver(TaskID,_LastPointSort))
            {
                MessageBox.Show("收费完成！");
                Btn_Submit.Enabled = false;
                sysidal.UpdateApprove_Single_defalut(ResolveID, true, "已收费", ip, ComputerName, PointSort, TaskID);
            }
            else
            {
                MessageBox.Show("还有未收费项目！");
            }
        }

        private void CHARGETYPEID_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isshow = CHARGETYPEID.Text.Equals("POS机收费");
            LB_POSRUNNINGNO.Visible = isshow;
            POSRUNNINGNO.Visible = isshow;
        }


    }
}
