using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using BASEFUNCTION;
using Microsoft.VisualBasic;

namespace FinanceOS
{
    public partial class FrmFinance_Invoice_PrintShow : Form
    {

        public FrmFinance_Invoice_PrintShow()
        {
            InitializeComponent();
        }
        BLLINVOICEFETCH BLLINVOICEFETCH = new BLLINVOICEFETCH();
        Messages mes = new Messages();
        RMBToCapMoney RMBToCapMoney = new RMBToCapMoney();

        /// <summary>
        /// 收费ID
        /// </summary>
        public string ChargeID = string.Empty;

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        public string strLoginID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        public string strLoginName = "";

        /// <summary>
        /// 公司名称
        /// </summary>
        public string strCompanyName = "";

        /// <summary>
        /// 公司纳税人识别号
        /// </summary>
        public string strCompanyTaxNO = "";

        /// <summary>
        /// 公司地址和电话
        /// </summary>
        public string strCompanyAddressAndTel = "";

        /// <summary>
        /// 开户行及账号
        /// </summary>
        public string strCompanyBankNameAndAccountNO = "";

        /// <summary>
        /// 收款人
        /// </summary>
        public string strCompanyPayee = "";

        /// <summary>
        /// 复核人
        /// </summary>
        public string strCompanyChecker = "";

        /// <summary>
        /// 用户基础信息
        /// </summary>
        public string strWaterUserID = "", strWaterUserName = "", strWaterUserAddress = "",
             strWaterUserTel = "", strWaterUserFPTaxNO = "", strWaterUserFPBankNameAndAccountNO = "";

        /// <summary>
        /// 待打发票明细
        /// </summary>
        public DataTable dtFPDetail = new DataTable();

        private void FrmFinance_Invoice_PrintShow_Load(object sender, EventArgs e)
        {
            //收费记录表：Meter_Charge
            //收费项目表：Meter_WorkResolveFee
            //说明：从Meter_WorkResolveFee表中可以查出所有收费项目

            dgList.AutoGenerateColumns = false;
            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                if (dgList.Columns[i].Name == "InvoiceTitle" || dgList.Columns[i].Name == "Units" || dgList.Columns[i].Name == "Quantity" || dgList.Columns[i].Name == "Price")
                    dgList.Columns[i].ReadOnly = false;
                else
                    dgList.Columns[i].ReadOnly = true;
            }

            BindInvoiceBatch(cmbBatch);

            GetMaxInvoiceNO();

            FillFPMessage();
        }
        private void FillFPMessage()
        {
            txtWaterUserName.Text = strWaterUserName;
            txtWaterUserFPTaxNO.Text = strWaterUserFPTaxNO;
            txtWaterUserAddress.Text = strWaterUserAddress + " " + strWaterUserTel;
            txtWaterUserBankAccount.Text = strWaterUserFPBankNameAndAccountNO;

            txtCompanyName.Text = strCompanyName;
            txtCompanyFPTaxNO.Text = strCompanyTaxNO;
            txtCompanyAddress.Text = strCompanyAddressAndTel;
            txtCompanyBankNameAndAccountNO.Text = strCompanyBankNameAndAccountNO;
            txtPayee.Text = strCompanyPayee;
            txtChecker.Text = strCompanyChecker;

            dgList.DataSource = dtFPDetail;

            decimal decSumMoney = 0;
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                decimal decTaxPercent = 0.03m;
                decimal decTaxMoney = 0;
                decimal decMoney = 0;
                object obj = dgList.Rows[i].Cells["TaxPercent"].Value;
                if (Information.IsNumeric(obj))
                    decTaxPercent = Convert.ToDecimal(obj);
                else
                    dgList.Rows[i].Cells["TaxPercent"].Value = decTaxPercent;

                obj = dgList.Rows[i].Cells["Fee"].Value;
                if (Information.IsNumeric(obj))
                    decMoney = Convert.ToDecimal(obj);

                decTaxMoney = decTaxPercent * decMoney / (1 + decTaxPercent);
                dgList.Rows[i].Cells["TaxMoney"].Value = decTaxMoney.ToString("F4");

                decSumMoney += decMoney;
            }
            txtCapMoney.Text = RMBToCapMoney.CmycurD(decSumMoney);
            txtSumMoney.Text = decSumMoney.ToString("F2");
        }
        /// <summary>
        /// 绑定发票批次
        /// </summary>
        /// <param name="cmb"></param>
        private void BindInvoiceBatch(ComboBox cmb)
        {
            DataTable dt = BLLINVOICEFETCH.Query(" AND ISENABLE='1' ORDER BY INVOICEFETCHBATCHID DESC");
            DataView dvInvoiceBatch = dt.DefaultView;
            cmb.DataSource = dvInvoiceBatch.ToTable(true, "INVOICEFETCHBATCHID", "INVOICEBATCHNAME");
            cmb.DisplayMember = "INVOICEBATCHNAME";
            cmb.ValueMember = "INVOICEFETCHBATCHID";

            if (dvInvoiceBatch.Count == 0)
            {
                mes.Show("从发票领用记录表内未检测到可用的发票,新发票无法开具!");
            }
        }
        private void cmbBatch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetMaxInvoiceNO();
        }

        /// <summary>
        /// 获取最大发票号
        /// </summary>
        private void GetMaxInvoiceNO()
        {
            //获取新的发票号码
            if (cmbBatch.SelectedValue != null && cmbBatch.SelectedValue != DBNull.Value)
            {
                DataTable dtNewInvoiceNO = BLLINVOICEFETCH.GetMaxInvoiceNO_MeterWork(strLoginID, cmbBatch.SelectedValue.ToString());
                if (dtNewInvoiceNO.Rows.Count > 0)
                {
                    object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                    if (Information.IsNumeric(objInvoiceNO))
                    {
                        txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                    }
                }
            }
        }

        private void dgList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                dgList.ClearSelection();
                dgList.CurrentCell = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void dgList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //判断是不是列Header
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                //单元格描绘  
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                //决定行号码描绘的范围   
                //不管e.AdvancedBorderStyle和e.CellStyle.Padding  
                Rectangle indexRect = e.CellBounds; indexRect.Inflate(-2, -2);
                //行号码描绘  
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, indexRect, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                //描绘完后通知 
                e.Handled = true;
            }
        }

        private void dgList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "Quantity" || dgList.Columns[e.ColumnIndex].Name == "Price")
            {
                decimal decSumMoney = 0;
                decimal decTaxPercent = 0.03m;
                decimal decTaxMoney = 0;
                decimal decMoney = 0;
                decimal decQuantity = 0;
                decimal decPrice = 0;

                object obj = dgList.Rows[e.RowIndex].Cells["Quantity"].Value;
                if (Information.IsNumeric(obj))
                    decQuantity = Convert.ToDecimal(obj);

                obj = dgList.Rows[e.RowIndex].Cells["Price"].Value;
                if (Information.IsNumeric(obj))
                    decPrice = Convert.ToDecimal(obj);

                decMoney = decQuantity * decPrice;
                dgList.Rows[e.RowIndex].Cells["Fee"].Value = decMoney.ToString("F4");

                obj = dgList.Rows[e.RowIndex].Cells["TaxPercent"].Value;
                if (Information.IsNumeric(obj))
                    decTaxPercent = Convert.ToDecimal(obj);

                for (int i = 0; i < dgList.Rows.Count; i++)
                {
                    obj = dgList.Rows[i].Cells["TaxPercent"].Value;
                    if (Information.IsNumeric(obj))
                        decTaxPercent = Convert.ToDecimal(obj);

                    obj = dgList.Rows[i].Cells["Fee"].Value;
                    if (Information.IsNumeric(obj))
                        decMoney = Convert.ToDecimal(obj);

                    decTaxMoney = decTaxPercent * decMoney / (1 + decTaxPercent);
                    dgList.Rows[i].Cells["TaxMoney"].Value = decTaxMoney.ToString("F4");

                    decSumMoney += decMoney;
                }
                txtCapMoney.Text = RMBToCapMoney.CmycurD(decSumMoney);
                txtSumMoney.Text = decSumMoney.ToString("F2");
            }
        }
    }
}
