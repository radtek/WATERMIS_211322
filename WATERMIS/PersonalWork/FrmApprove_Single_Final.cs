using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Common.DotNetData;
using SysControl;
using Common.DotNetUI;
using DBinterface.DAL;
using DBinterface.IDAL;
using System.Data.SqlClient;

namespace PersonalWork
{
    public partial class FrmApprove_Single_Final : Form
    {
        #region
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        //public bool IsCharge = false;

        private string ComputerName = "";
        private string ip = "";
        private string strLogID;
        private string strName;
        private string strRealName;

        private decimal TotalFee = 0m;
        private decimal _DepTotalFee = 0m;

        private decimal _Abate = 0m;
        private decimal _BCSS = 0m;
        private decimal _BCYS = 0m;
        private string _SelectResolveID = "";

        //private bool _IsFinal = false;

        private string _LastPointSort;
        // private int _State = 0;
        private string _FeeItems = "";

        //打印数据--格式：{ID|收费项目名称|单价|单位|数量|总费用}
        private string[] _PrintFeeItems;
        //  private int _FeeType = 0;
        private Hashtable hc = new Hashtable();


        private decimal _prestore = 0m;

        public decimal Prestore
        {
            get { return _prestore; }
            set { _prestore = value; LB_Prestore.Text = string.Format("账户余额：{0}元", _prestore); }
        }

        private decimal _DepPrestore = 0m;

        #endregion

        #region
        public FrmApprove_Single_Final()
        {
            InitializeComponent();
        }
   

        private void FrmApprove_Single_Final_Load(object sender, EventArgs e)
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

        }
        private void BindDepartmentFee()
        {
            FP_Dep.Controls.Clear();

            DataTable dt = sysidal.GetDepartMentFeeFinal(TaskID, PointSort);
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_DepartmentFee UD = new UC_DepartmentFee();
                    UD.DataRowToProperty(dr);
                    UD.Button_Open_Click += new EventHandler(UD_Button_Open_Click);
                    FP_Dep.Controls.Add(UD);
                }

                _LastPointSort = dt.Rows[0]["LastPointSort"].ToString();
                TotalFee = sysidal.GetTotalFeeFinalByPointSort(TaskID, _LastPointSort);

                LB_TotalFee.Text = string.Format("总计：{0}元（不含预存水费）", TotalFee);
                Prestore = sysidal.GetUserPrestore("Meter_Install_Single", TaskID);
            }
        }

        void UD_Button_Open_Click(object sender, EventArgs e)
        {
            UC_DepartmentFee UD = (UC_DepartmentFee)sender;
           
            FP_Items.Controls.Clear();

            _SelectResolveID = UD.ResolveID;
            DataTable dt = sysidal.GetDepartMentFinalFeeItems(_SelectResolveID);
            if (DataTableHelper.IsExistRows(dt))
            {
                _PrintFeeItems = new string[dt.Rows.Count];
                _FeeItems = "";
                int _index = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    UC_ChargeItem UC = new UC_ChargeItem();
                    UC.FeeItem = string.Format("{0}:{1}元;", dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString());
                    _FeeItems += string.Format("{0}:{1};", dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString());

                    string _FeeItemDetail = GetPrintFee(dr["FeeID"].ToString(), dr["Fee"].ToString());
                    if (!string.IsNullOrEmpty(_FeeItemDetail))
                    {
                        _PrintFeeItems[_index] = _FeeItemDetail;
                        _index++;
                    }
                    
                    FP_Items.Controls.Add(UC);
                }

                //_DepTotalFee = string.IsNullOrEmpty(dt.Rows[0]["FinalTotalFee"].ToString()) ? 0m : Convert.ToDecimal(dt.Rows[0]["FinalTotalFee"].ToString());
                _DepTotalFee = UD.STATE != 0 ? 0 : UD.TotalFee;
                TOTALCHARGE.Text = _DepTotalFee.ToString();

                _DepPrestore = sysidal.GetDepartmentPrestoreFinal(TaskID, int.Parse(_LastPointSort), UD.DepartementID);
                prestore.Text = _DepPrestore.ToString();
                _BCYS = UD.STATE != 0 ? 0m : _DepTotalFee - _DepPrestore;
                CHARGEBCYS.Text = _BCYS.ToString();

               
                if (_DepTotalFee>0m)
                {
                    Btn_Settle.Enabled = true;
                    Btn_Print.Enabled = true;
                  
                }
                else
                {
                    Btn_Settle.Enabled = false;
                    Btn_Print.Enabled = false;
                }
                if (_BCYS<=0m)
                {
                    CHARGEBCSS.Text = "0";

                }
                else
                {
                    Btn_Settle.Enabled = false;
                    CHARGEBCSS.Text = _BCYS.ToString();
                    CHARGEBCSS.Enabled = false;
                }

            }
        }

        private string GetPrintFee(string FeeID, string Fee)
        {
            string result = string.Empty;
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT TOP 1 * FROM Meter_FeeItmes WHERE FeeID =FeeID", new SqlParameter[] { new SqlParameter("@FeeID", FeeID) });
            if (DataTableHelper.IsExistRows(dt))
            {
                //{ID|收费项目名称|单价|单位|数量|总费用}
                DataRow dr=dt.Rows[0];
                decimal _Price=0m;

                if (decimal.TryParse(dr["Price"].ToString(), out _Price))
                {
                    decimal _fee = 0m;
                    if (decimal.TryParse(Fee,out _fee))
                    {
                        _Price = _Price == 0m ? _fee : _Price;
                        if ( _fee == 0m)
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

        private void BindChargeType()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT * FROM CHARGETYPE ");
            ControlBindHelper.BindComboBoxData(this.CHARGETYPEID, dt, "CHARGETYPENAME", "CHARGETYPEID");
        }

        private bool Approve_Finance()
        {
            _prestore = sysidal.GetUserPrestore("Meter_Install_Single", TaskID);
            string _chargeID = sysidal.GetNewChargeID(strLogID);
            hc["TableName"] = "Meter_Install_Single";
            hc["Prestore"] = _prestore - _DepTotalFee + _BCSS;
            hc["CHARGEID"] = _chargeID;
            hc["TaskID"] = TaskID;
            hc["CHARGEBCSS"] = CHARGEBCSS.Text;
            hc["CHARGEBCYS"] = CHARGEBCYS.Text;
            hc["TOTALCHARGE"] = TOTALCHARGE.Text;
            hc["Abate"] = _Abate;
            hc["FeeList"] = _FeeItems;
            hc["CHARGETYPEID"] = CHARGETYPEID.SelectedValue;
            hc["CHARGEWORKERID"] = strLogID;
            hc["CHARGEWORKERNAME"] = strRealName;
            hc["INVOICEPRINTSIGN"] = INVOICEPRINTSIGN.Checked;
            hc["InvoiceNO"] = InvoiceNO.Text;
            hc["ReceiptPrintSign"] = ReceiptPrintSign.Checked;
            hc["RECEIPTNO"] = RECEIPTNO.Text;
            hc["POSRUNNINGNO"] = POSRUNNINGNO.Text;
            hc["Memo"] = Memo.Text;
            hc["ResolveID"] = _SelectResolveID;
            return sysidal.ApproveFinalPrestore(hc);
        }
        #endregion

        #region
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (sysidal.IsChargeOverFinal(TaskID, _LastPointSort))
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

        private void ReceiptPrintSign_CheckedChanged(object sender, EventArgs e)
        {
            if (ReceiptPrintSign.Checked)
            {
                labInvoiceBatch.Visible = false;
                cmbBatch.Visible = false;
                labInvoiceNO.Visible = false;
                InvoiceNO.Visible = false;
                INVOICEPRINTSIGN.Checked = false;

                labReceiptNO.Visible = true;
                RECEIPTNO.Visible = true;
            }
        }

        private void INVOICEPRINTSIGN_CheckedChanged(object sender, EventArgs e)
        {
            if (INVOICEPRINTSIGN.Checked)
            {
                labInvoiceBatch.Visible = true;
                cmbBatch.Visible = true;
                labInvoiceNO.Visible = true;
                InvoiceNO.Visible = true;

                labReceiptNO.Visible = false;
                RECEIPTNO.Visible = false;

                ReceiptPrintSign.Checked = false;
            }
            else
            {
                labInvoiceBatch.Visible = false;
                cmbBatch.Visible = false;
                labInvoiceNO.Visible = false;
                InvoiceNO.Visible = false;
            }
        }

        private void CHARGETYPEID_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isshow = CHARGETYPEID.Text.Equals("POS机收费");
            LB_POSRUNNINGNO.Visible = isshow;
            POSRUNNINGNO.Visible = isshow;
        }
        #endregion

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            if (!CheckBCSS())
            {
                return;
            }
            hc["CHARGEClASS"] = 15;


            //说明：1、发票或收据 显示的费用是实际发生的费用：合计金额-TOTALCHARGE.text
            //      2、发票明细：


            if (ReceiptPrintSign.Checked)
            {
                //==============================================================================获取收据编号

                RECEIPTNO.Text = "";
            }
            else if (INVOICEPRINTSIGN.Checked)
            {
                //==============================================================================获取发票编号
                InvoiceNO.Text = "";
            }
            else
            {
                return;
            }

           
            if (Approve_Finance())
            {
                MessageBox.Show("结算成功！");
                TOTALCHARGE.Text = "0";
                CHARGEBCYS.Text = "0";
                BindDepartmentFee();
                Btn_Print.Enabled = false;
                Btn_Settle.Enabled = false;
            }
            else
            {
                MessageBox.Show("结算失败！");
            }

        }

        private void Btn_Settle_Click(object sender, EventArgs e)
        {
            if (!CheckBCSS())
            {
                return;
            }
            Memo.Text = "结算--" + Memo.Text;
            CHARGEBCSS.Text = "0";
            hc["CHARGEClASS"] = 16;
            if (Approve_Finance())
            {
                MessageBox.Show("结算成功！");
                TOTALCHARGE.Text = "0";
                CHARGEBCYS.Text = "0";
                BindDepartmentFee();
                Btn_Settle.Enabled = false;
                Btn_Print.Enabled = false;
            }
            else
            {
                MessageBox.Show("结算失败！");
            }

        }

        private void CHARGEBCSS_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CHARGEBCSS_MouseLeave(object sender, EventArgs e)
        {
           
        }
        private bool CheckBCSS()
        {
            bool result = false;
            if (decimal.TryParse(CHARGEBCSS.Text.Trim(), out _BCSS))
            {
                if (_DepTotalFee == 0)
                {
                    result = false;
                }
                else if (_BCSS >= _BCYS)
                {
                    result = true;
                }
                else
                {
                    CHARGEBCSS.Text = "0";
                    MessageBox.Show("请输入正确的收费金额！");
                }
            }
            else
            {
                CHARGEBCSS.Text = "0";
                MessageBox.Show("请输入正确的收费金额！");
            }
            return result;
        }

        
    }
}
