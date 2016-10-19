using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BASEFUNCTION;
using MODEL;
using BLL;

namespace INVOICEMANAGE
{
    public partial class frmReceiptFetch : DockContentEx
    {
        public frmReceiptFetch()
        {
            InitializeComponent();
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLRECEIPTFETCH BLLRECEIPTFETCH = new BLLRECEIPTFETCH();
        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENT = new BLLBASE_DEPARTMENT();

        /// <summary>
        /// 记录发票批次界面是否更改批次数据
        /// </summary>
        public bool isModify = false;

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 当前登录所属部门ID
        /// </summary>
        private string strDepID = "";

        /// <summary>
        /// 当前登录所属部门名称
        /// </summary>
        private string strDepName = "";

        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 当前登录用户姓名
        /// </summary>
        private string strLogName = "";

        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        private string strGroupID = "";

        /// <summary>
        /// 当前登录用户姓名
        /// </summary>
        private string strGroupName = "";

        private void frmInvoiceStocks_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;

            #region 获取登录相关信息
            object objLogin = AppDomain.CurrentDomain.GetData("LOGINID");
            if (objLogin != null && objLogin != DBNull.Value)
            {
                strLogID = objLogin.ToString();
            }
            objLogin = AppDomain.CurrentDomain.GetData("USERNAME");
            if (objLogin != null && objLogin != DBNull.Value)
            {
                strLogName = objLogin.ToString();
            }
            objLogin = AppDomain.CurrentDomain.GetData("DEPARTMENTID");
            if (objLogin != null && objLogin != DBNull.Value)
            {
                strDepID = objLogin.ToString();
            }
            objLogin = AppDomain.CurrentDomain.GetData("DEPARTMENTNAME");
            if (objLogin != null && objLogin != DBNull.Value)
            {
                strDepName = objLogin.ToString();
            }
            objLogin = AppDomain.CurrentDomain.GetData("GROUPID");
            if (objLogin != null && objLogin != DBNull.Value)
            {
                strGroupID = objLogin.ToString();
            }
            objLogin = AppDomain.CurrentDomain.GetData("GROUPNAME");
            if (objLogin != null && objLogin != DBNull.Value)
            {
                strGroupName = objLogin.ToString();
            }

            #endregion

            BindChargeWorkerName(cmbChargerWorkNameSearch, "0");
            BindChargeWorkerName(cmbChargerWorkName, "1");
            toolSearch_Click(null,null);
        }

        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName(ComboBox cmb,string strType)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND IsCashier='1'");
            if (strType == "0")
            {
                DataRow dr = dt.NewRow();
                dr["USERNAME"] = "";
                dr["LOGINID"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
            
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (chkFetch.Checked)
            {
                strFilter += " AND RECEIPTFETCHDATETIME BETWEEN '" + dtStartDate.Value.ToShortDateString() + " 00:00:00' AND '" + dtEndDate.Value.ToShortDateString() + " 23:59:59'";
            }
            if (cmbChargerWorkNameSearch.SelectedValue != null && cmbChargerWorkNameSearch.SelectedValue != DBNull.Value)
                strFilter += " AND RECEIPTFETCHERID='"+cmbChargerWorkNameSearch.SelectedValue.ToString()+"'";

            DataTable dtList = BLLRECEIPTFETCH.Query(strFilter);
            dgList.DataSource = dtList;
            if (dgList.Rows.Count > 0)
            {
                int intRowIndex = 0;
                if (dgList.CurrentRow != null)
                    intRowIndex = dgList.CurrentRow.Index;
                dgList_RowEnter(null, new DataGridViewCellEventArgs(2, intRowIndex));
            }
        }

        bool isADD = false;
        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (toolAdd.Text == "新增")
            {
                txtID.Clear();
                txtStartNO.Clear();
                txtEndNO.Clear();
                txtMemo.Clear();

                toolAdd.Text = "取消";
                toolDelete.Enabled = false;
                toolSearch.Enabled = false;

                dgList.Enabled = false;
                isADD = true;
            }
            else
            {
                toolAdd.Text = "新增";
                toolDelete.Enabled = true;
                toolSearch.Enabled = true;

                dgList.Enabled = true;

                if (dgList.Rows.Count > 0)
                {
                    int intRowIndex = 0;
                    if (dgList.CurrentRow != null)
                        intRowIndex = dgList.CurrentRow.Index;
                    dgList_RowEnter(null, new DataGridViewCellEventArgs(2, intRowIndex));
                }
                isADD = false;
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                mes.Show("请从发票列表内选择要删除的行!");
                return;
            }
            if (mes.ShowQ("确定要删除收据的领取记录吗?") == DialogResult.OK)
                if (BLLRECEIPTFETCH.Delete(txtID.Text))
            {
                dgList.Rows.Remove(dgList.CurrentRow);
                if (dgList.Rows.Count == 0)
                {
                    txtID.Clear();
                    txtStartNO.Clear();
                    txtEndNO.Clear();
                    txtMemo.Clear();
                }
                else
                {
                    int intRowIndex = 0;
                    if (dgList.CurrentRow != null)
                        intRowIndex = dgList.CurrentRow.Index;
                    dgList_RowEnter(null, new DataGridViewCellEventArgs(2, intRowIndex));
                }
            }
            else
            {
                mes.Show("删除失败!请从领取列表内重新选择要删除的行!");
                return;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "")
                toolDelete.Enabled = false;
            else
                toolDelete.Enabled = true;
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Information.IsNumeric(txtStartNO.Text))
                {
                    mes.Show("请输入起始号，起始号只能为数字!");
                    txtStartNO.Focus();
                    return;
                }
                if (!Information.IsNumeric(txtEndNO.Text))
                {
                    mes.Show("请输入终止号，终止号只能为数字!");
                    txtEndNO.Focus();
                    return;
                }
                if (Convert.ToInt64(txtStartNO.Text) > Convert.ToInt64(txtEndNO.Text))
                {
                    mes.Show("起始号码不能大于终止号码!");
                    txtStartNO.Focus();
                    return;
                }
                if (cmbChargerWorkName.SelectedValue == null || cmbChargerWorkName.SelectedValue == DBNull.Value)
                {
                    mes.Show("请选择领用人!");
                    cmbChargerWorkName.Focus();
                    return;
                }

                MODELRECEIPTFETCH MODELRECEIPTFETCH = new MODELRECEIPTFETCH();
                MODELRECEIPTFETCH.RECEIPTFETCHERID = cmbChargerWorkName.SelectedValue.ToString();
                MODELRECEIPTFETCH.RECEIPTFETCHERNAME = cmbChargerWorkName.Text;
                MODELRECEIPTFETCH.RECEIPTFETCHDATETIME = mes.GetDatetimeNow();
                MODELRECEIPTFETCH.RECEIPTFETCHSTARTNO = txtStartNO.Text;
                MODELRECEIPTFETCH.RECEIPTFETCHENDNO = txtEndNO.Text;

                MODELRECEIPTFETCH.MEMO = txtMemo.Text;

                //查询发票批次中的发票号是否已存在
                DataTable dt = new DataTable();
                if (isADD)
                {
                    dt = BLLRECEIPTFETCH.Query("");
                }
                else
                    dt = BLLRECEIPTFETCH.Query(" AND RECEIPTFETCHID<>" + txtID.Text);

                #region 验证是否在库存的发票中
                //long llStartNO = Convert.ToInt64(MODELINVOICEFETCH.INVOICEFETCHSTARTNO);
                //long llEndNO = Convert.ToInt64(MODELINVOICEFETCH.INVOICEFETCHENDNO);
                //DataTable dtInvoiceStocks = BLLINVOICESTOCKS.Query(" AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");

                //for (long i = llStartNO; i <= llEndNO; i++)
                //{
                //    bool isOK = false;
                //    for (int j = 0; j < dtInvoiceStocks.Rows.Count; j++)
                //    {
                //        long llStocksStartNO = 0;
                //        long llStocksEndNO = 0;
                //        if (Information.IsNumeric(dtInvoiceStocks.Rows[j]["INVOICESTARTNO"]))
                //        {
                //            llStocksStartNO = Convert.ToInt64(dtInvoiceStocks.Rows[j]["INVOICESTARTNO"]);
                //        }
                //        if (Information.IsNumeric(dtInvoiceStocks.Rows[j]["INVOICESTARTNO"]))
                //        {
                //            llStocksEndNO = Convert.ToInt64(dtInvoiceStocks.Rows[j]["INVOICEENDNO"]);
                //        }

                //        if (i < llStocksStartNO || i > llStocksEndNO)
                //        {
                //            continue;
                //        }
                //        else
                //        {
                //            isOK = true;
                //            break;
                //        }
                //    }
                //        if (!isOK)
                //        {
                //            mes.Show("批次为'" + cmbBatch.Text + "'号码为'" + i.ToString().PadLeft(8, '0') + "'的发票号不在发票库存中!");
                //            return;
                //        }
                //}
                #endregion

                #region 验证发票领取记录是否重复
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    long intStartNO = 0, intEndNO = 0;
                    object obj = dt.Rows[i]["RECEIPTFETCHSTARTNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intStartNO = Convert.ToInt64(obj);
                    }
                    obj = dt.Rows[i]["RECEIPTFETCHENDNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intEndNO = Convert.ToInt64(obj);
                    }

                    if (Convert.ToInt64(MODELRECEIPTFETCH.RECEIPTFETCHSTARTNO) >= intStartNO && Convert.ToInt64(MODELRECEIPTFETCH.RECEIPTFETCHSTARTNO) <= intEndNO)
                    {
                        mes.Show("设定的领取起始号在领取记录中已经存在,无法再次领取!");
                        txtStartNO.Focus();
                        return;
                    }

                    if (Convert.ToInt64(MODELRECEIPTFETCH.RECEIPTFETCHENDNO) >= intStartNO && Convert.ToInt64(MODELRECEIPTFETCH.RECEIPTFETCHENDNO) <= intEndNO)
                    {
                        mes.Show("设定的领取终止号在领取记录中已经存在,无法再次领取!");
                        txtEndNO.Focus();
                        return;
                    }
                }
                #endregion
                if (isADD)
                {
                    //新增发票记录
                    if (BLLRECEIPTFETCH.Insert(MODELRECEIPTFETCH))
                    {
                        toolSearch_Click(null, null);
                        if (dgList.Rows.Count > 0)
                        {
                            dgList.ClearSelection();
                            dgList.CurrentCell = dgList.Rows[dgList.Rows.Count - 1].Cells["RECEIPTFETCHERNAME"];
                            dgList_RowEnter(null, new DataGridViewCellEventArgs(2, dgList.Rows.Count - 1));
                        }
                    }
                    else
                    {
                        mes.Show("新增发票记录失败,请重新操作!");
                        return;
                    }
                }
                else
                {
                    MODELRECEIPTFETCH.RECEIPTFETCHID = txtID.Text;
                    if (BLLRECEIPTFETCH.Update(MODELRECEIPTFETCH))
                    {
                        if (dgList.CurrentRow != null)
                        {
                            dgList.CurrentRow.Cells["RECEIPTFETCHERNAME"].Value =MODELRECEIPTFETCH.RECEIPTFETCHERNAME;
                            //dgList.CurrentRow.Cells["INVOICEFETCHDEPID"].Value = cmbDEP.SelectedValue;
                            //dgList.CurrentRow.Cells["INVOICEFETCHDEPNAME"].Value = cmbDEP.Text;
                            dgList.CurrentRow.Cells["RECEIPTFETCHDATETIME"].Value = MODELRECEIPTFETCH.RECEIPTFETCHDATETIME;
                            dgList.CurrentRow.Cells["RECEIPTFETCHSTARTNO"].Value = MODELRECEIPTFETCH.RECEIPTFETCHSTARTNO;
                            dgList.CurrentRow.Cells["RECEIPTFETCHENDNO"].Value = MODELRECEIPTFETCH.RECEIPTFETCHENDNO;
                            dgList.CurrentRow.Cells["MEMO"].Value = MODELRECEIPTFETCH.MEMO;
                        }
                    }
                    else
                    {
                        mes.Show("修改领取记录失败,请重新查询理领取列表后再修改!");
                        return;
                    }
                }

                dgList.Enabled = true;
                toolAdd.Text = "新增";
                toolSearch.Enabled = true;
                toolDelete.Enabled = true;
                isADD = false;

            }
            catch (Exception ex)
            {
                log.Write(ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
            }
        }

        private void txtStartNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            //if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            //{
            //    e.Handled = true;
            //}
        }

        private void txtStartNO_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "" && !isADD)
                if (txtStartNO.Text.Trim() != "")
                {
                    mes.Show("如果要领取新的收据，请点击'新增'按钮后再输入起始号!");
                    txtStartNO.Clear();
                }
        }

        private void txtStartNO_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt=(TextBox)sender;
            if (txt.Text != "" && !Information.IsNumeric(txt.Text))
            {
                e.Cancel = true;
                mes.Show("收据号只能为数字型!");
            }
        }

        private void dgList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            txtID.Clear();
            txtStartNO.Clear();
            txtEndNO.Clear();
            txtMemo.Clear();

            object objID = dgList.Rows[e.RowIndex].Cells["RECEIPTFETCHID"].Value;
            if (objID != null && objID != DBNull.Value)
            {
                txtID.Text = objID.ToString();
            }

            object obj = dgList.Rows[e.RowIndex].Cells["RECEIPTFETCHSTARTNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtStartNO.Text = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["RECEIPTFETCHENDNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtEndNO.Text = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["RECEIPTFETCHERID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbChargerWorkName.SelectedValue= obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["MEMO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtMemo.Text = obj.ToString();
            }
        }
    }
}
