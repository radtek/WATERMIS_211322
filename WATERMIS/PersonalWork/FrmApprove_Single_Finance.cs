using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Common.WinDevices;
using Common.DotNetUI;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace PersonalWork
{
    public partial class FrmApprove_Single_Finance : Form
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
        private decimal _Abate = 0m;
        private decimal _BCSS = 0m;
        private decimal _BCYS = 0m;
        private decimal _prestore = 0m;
        private bool _IsFinal = false;
        private int _LastPointSort = 0;
        private int _State = 0;
        private string _FeeItems = "";
        private int _FeeType = 0;
        private Hashtable hc = new Hashtable();

        public FrmApprove_Single_Finance()
        {
            InitializeComponent();
        }
       

        private void FrmApprove_Single_Finance_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            hc["TaskID"] = TaskID;
            #region //2017-2-22 RONG
            bool IsAllowEdit = false;
            if (ht.Contains("Edit"))
            {
                if (bool.TryParse(ht["Edit"].ToString(), out IsAllowEdit))
                {

                }
            }
            Btn_Submit.Enabled = IsAllowEdit;
            Btn_Settle.Enabled = IsAllowEdit;
            #endregion
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

            InitView();
        }

        private void InitView()
        {
            Hashtable htt = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (htt != null)
            {
                if (!string.IsNullOrEmpty(htt["ISCASHIER"].ToString()))
                {
                    bool IsViewCharge = false;
                    if (bool.TryParse(htt["ISCASHIER"].ToString(), out IsViewCharge))
                    {
                        FP_Items.Visible = IsViewCharge;

                        if (IsViewCharge)
                        {
                            FP_Items.Controls.Clear();

                            ApproveDispose.BindLastFeeItems(this.FP_Items, TaskID, PointSort, out TotalFee, out _IsFinal, out _LastPointSort, out _State, out _FeeItems);
                            hc["LastPointSort"] = _LastPointSort;

                            INVOICEPRINTSIGN.Visible = _IsFinal;
                            ReceiptPrintSign.Enabled = _IsFinal;
                            _prestore = sysidal.GetUserPrestore("Meter_Install_Single", TaskID);
                            prestore.Text = _prestore.ToString();//账户余额
                            if (_State == 1)
                            {
                                TotalFee = 0m;
                                _Abate = 0m;
                                _BCYS = -_prestore;
                                LB_Title.Text = _IsFinal ? "待收费用列表（决算）--已收费：" : "待收费用列表（预收）--已收费：";

                            }
                            else
                            {
                                _Abate = sysidal.GetTotalAbate(TaskID, PointSort);
                                //本次应收:合计-减免-账户余额
                                _BCYS = TotalFee - _Abate - _prestore;
                                LB_Title.Text = _IsFinal ? "待收费用列表（决算）--未收费：" : "待收费用列表（预收）-未收费：";
                                hc["CHARGEClASS"] = 14;
                                if (_IsFinal)
                                {
                                    hc["CHARGEClASS"] = 15;
                                    Btn_Settle.Visible = (TotalFee > 0 && _BCYS < 0) ? true : false;
                                }
                            }
                            TOTALCHARGE.Text = TotalFee.ToString();//费用合计
                            CHARGEBCYS.Text = _BCYS.ToString(); //本次应收
                            Abate.Text = _Abate.ToString();//减免
                            Btn_Submit.Text = "确  定";

                            BindChargeType();
                            BindInvoiceBatch();
                        }
                    }

                }
            }

        }

        #region
        private void chkReceipt_CheckedChanged(object sender, EventArgs e)
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

        private void chkInvoice_CheckedChanged(object sender, EventArgs e)
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

        private void BindChargeType()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT * FROM CHARGETYPE ");
            ControlBindHelper.BindComboBoxData(this.CHARGETYPEID, dt, "CHARGETYPENAME", "CHARGETYPEID");
        }

        private void BindInvoiceBatch()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT INVOICEBATCHNAME,INVOICEFETCHBATCHID FROM V_INVOICE_FETCH WHERE ISENABLE='1' ORDER BY INVOICEFETCHBATCHID DESC");
            ControlBindHelper.BindComboBoxData(this.cmbBatch, dt, "INVOICEBATCHNAME", "INVOICEFETCHBATCHID");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("从发票领用记录表内未检测到可用的发票,发票将无法打印!");
                chkReceipt_CheckedChanged(null, null);
            }
        }

        private void CHARGEBCSS_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(CHARGEBCSS.Text, out _BCSS))
            {
                if (_BCSS < _BCYS)
                {
                    Btn_Submit.Enabled = false;
                }
                else if (_BCSS == 0)
                {
                    Btn_Submit.Text = "确  定";
                    Btn_Submit.Enabled = true;
                }
                else
                {
                    Btn_Submit.Text = "收  费";
                    Btn_Submit.Enabled = true;
                }
            }
            else
            {
                Btn_Submit.Enabled = false;
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (Btn_Submit.Text.Equals("确  定"))
            {
                Approve_NoFinance();
            }
            else if (Btn_Submit.Text.Equals("收  费"))
            {
                CheckForm();
            }

        }

        private void CheckForm()
        {
            if (INVOICEPRINTSIGN.Checked)
            {
                if (cmbBatch.SelectedValue == null || cmbBatch.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("请选择发票批次!");
                    cmbBatch.Focus();
                    return;
                }
                if (InvoiceNO.Text.Trim() == "")
                {
                    MessageBox.Show("请输入发票号码!");
                    InvoiceNO.Focus();
                    return;
                }
                else
                {

                    InvoiceNO.Text = InvoiceNO.Text.Trim().PadLeft(8, '0');

                    DataTable dtInvoiceFetch = new SqlServerHelper().GetDateTableBySql("SELECT INVOICEFETCHSTARTNO,INVOICEFETCHENDNO FROM V_INVOICE_FETCH WHERE INVOICEFETCHBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                    #region 验证发票领取记录是否存在
                    bool isExist = false;
                    for (int i = 0; i < dtInvoiceFetch.Rows.Count; i++)
                    {
                        long intStartNO = 0, intEndNO = 0;
                        object obj = dtInvoiceFetch.Rows[i]["INVOICEFETCHSTARTNO"];

                        if (long.TryParse(obj.ToString(), out intStartNO))
                        {
                            intStartNO = Convert.ToInt64(obj);
                        }

                        obj = dtInvoiceFetch.Rows[i]["INVOICEFETCHENDNO"];
                        if (long.TryParse(obj.ToString(), out intEndNO))
                        {
                            intEndNO = Convert.ToInt64(obj);
                        }

                        if (Convert.ToInt64(InvoiceNO.Text) >= intStartNO && Convert.ToInt64(InvoiceNO.Text) <= intEndNO)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        MessageBox.Show("批次为'" + cmbBatch.Text + "'的发票起始号码不在领取记录中,请确认发票号码是否正确!");
                        InvoiceNO.Focus();
                        return;
                    }
                    #endregion
                }


            }
            if (ReceiptPrintSign.Checked)
            {
                if (RECEIPTNO.Text.Trim() == "")
                {
                    MessageBox.Show("请输入收据号!");
                    RECEIPTNO.Focus();
                    return;
                }

                RECEIPTNO.Text = RECEIPTNO.Text.PadLeft(8, '0');
            }


            if (Approve_Finance())
            {
                if (INVOICEPRINTSIGN.Checked)
                {
                    //打发票=================================================================
                }
                else if (ReceiptPrintSign.Checked)
                {
                    //打收据=================================================================
                }

                MessageBox.Show("收费成功！");
                Btn_Submit.Enabled = false;
                sysidal.UpdateApprove_Single_defalut(ResolveID, true, "已收费", ip, ComputerName, PointSort, TaskID,"收费成功");
            }
        }

        private void CHARGETYPEID_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isshow = CHARGETYPEID.Text.Equals("POS机收费");
            LB_POSRUNNINGNO.Visible = isshow;
            POSRUNNINGNO.Visible = isshow;
        }

        #endregion

        private void Approve_NoFinance()
        {
            Btn_Submit.Enabled = false;
            ComputerName = AppDomain.CurrentDomain.GetData("COMPUTERNAME").ToString();
            ip = AppDomain.CurrentDomain.GetData("IP").ToString();

            int count = sysidal.UpdateApprove_Single_defalut(ResolveID, true, "收费金额为0", ip, ComputerName, PointSort, TaskID,"收费金额为0");

            if (count > 0)
            {
                if (IsCharge)
                {
                    MessageBox.Show("审批成功！");
                }
                else
                {
                    MessageBox.Show("审批成功！");
                }
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

        private bool Approve_Finance()
        {
            string _chargeID = sysidal.GetNewChargeID(strLogID);
            hc["TableName"] = "Meter_Install_Single";
            hc["Prestore"] = _IsFinal ? _BCSS - _BCYS : _BCSS + _prestore;
            hc["CHARGEID"] = _chargeID;
            hc["TaskID"] = TaskID;
            hc["CHARGEBCSS"] = _BCSS;
            hc["CHARGEBCYS"] = _BCYS;
            hc["TOTALCHARGE"] = TotalFee;
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

            return ReceiptPrintSign.Checked ? sysidal.ApprovePrestore(hc) : INVOICEPRINTSIGN.Checked ? sysidal.ApprovePrestoreFinal(hc) : false;

        }

        private void Btn_Settle_Click(object sender, EventArgs e)
        {
            Memo.Text = "结算--" + Memo.Text;

            hc["CHARGEClASS"] = 16;
            if (Approve_Finance())
            {
                MessageBox.Show("结算成功！");
                Btn_Settle.Visible = false;
            }
            else
            {
                MessageBox.Show("结算失败！");
            }

            InitView();
        }

    }
}
