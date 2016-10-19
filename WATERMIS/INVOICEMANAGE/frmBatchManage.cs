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
    public partial class frmBatchManage : Form
    {
        public frmBatchManage()
        {
            InitializeComponent();
        }

        BLLINVOICEBATCH BLLINVOICEBATCH = new BLLINVOICEBATCH();
        public frmInvoiceStocks frm = null;

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        private void frmInvoiceStocks_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            BindInvoiceBatch(cmbBatchSearch);
            toolSearch_Click(null, null);
        }

        /// <summary>
        /// 绑定发票批次
        /// </summary>
        /// <param name="cmb"></param>
        private void BindInvoiceBatch(ComboBox cmb)
        {
            DataTable dt = BLLINVOICEBATCH.Query(" ORDER BY INVOICEBATCHID DESC");
            DataRow dr = dt.NewRow();
            dr["INVOICEBATCHNAME"] = "全部批次";
            dr["INVOICEBATCHID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "INVOICEBATCHNAME";
            cmb.ValueMember = "INVOICEBATCHID";
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

        private void dgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0)
            //    return;

            //txtID.Clear();
            //txtBatchName.Clear();
            //txtMemo.Clear();

            //object objID = dgList.Rows[e.RowIndex].Cells["INVOICEBATCHID"].Value;
            //if (objID != null && objID != DBNull.Value)
            //{
            //    txtID.Text = objID.ToString();
            //}

            //object obj = dgList.Rows[e.RowIndex].Cells["INVOICEBATCHNAME"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtBatchName.Text = obj.ToString();
            //}

            //obj = dgList.Rows[e.RowIndex].Cells["INVOICEBATCHMEMO"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtMemo.Text = obj.ToString();
            //}
        }

        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (cmbBatchSearch.SelectedValue != DBNull.Value && cmbBatchSearch.SelectedValue != null)
            {
                strFilter += " AND INVOICEBATCHID='" + cmbBatchSearch.SelectedValue.ToString() + "'";
            }
            DataTable dtList = BLLINVOICEBATCH.Query(strFilter);
            dgList.DataSource = dtList;
            if (dgList.Rows.Count > 0)
            {
                int intRowIndex = 0;
                if (dgList.CurrentRow != null)
                    intRowIndex = dgList.CurrentRow.Index;
                dgList_CellClick(null, new DataGridViewCellEventArgs(2, intRowIndex));
            }
        }

        bool isADD = false;
        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (toolAdd.Text == "新增")
            {
                txtID.Clear();
                txtBatchName.Clear();
                txtMemo.Clear();

                toolAdd.Text = "取消";
                toolDelete.Enabled = false;
                toolSearch.Enabled = false;

                dgList.Enabled = false;

                chkIsUsing.Checked = true;

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
                mes.Show("请从发票批次列表内选择要删除的行!");
                return;
            }
            if (mes.ShowQ("确定要删除发票批次为'" + txtBatchName.Text + "'的记录吗?") == DialogResult.OK)
                if (BLLINVOICEBATCH.Delete(txtID.Text))
                {
                    dgList.Rows.Remove(dgList.CurrentRow);
                    if (dgList.Rows.Count == 0)
                    {
                        txtID.Clear();
                        txtBatchName.Clear();
                        txtMemo.Clear();
                    }
                    else
                    {
                        int intRowIndex = 0;
                        if (dgList.CurrentRow != null)
                            intRowIndex = dgList.CurrentRow.Index;
                        dgList_CellClick(null, new DataGridViewCellEventArgs(2, intRowIndex));
                    }
                }
                else
                {
                    mes.Show("删除失败!请从发票批次列表内重新选择要删除的行!");
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
                if (txtBatchName.Text.Trim() == "")
                {
                    txtBatchName.Focus();
                    mes.Show("请输入发票批次!");
                    return;
                }

                MODELINVOICEBATCH MODELINVOICEBATCH = new MODELINVOICEBATCH();
                MODELINVOICEBATCH.INVOICEBATCHNAME = txtBatchName.Text;
                if (chkIsUsing.Checked)
                    MODELINVOICEBATCH.ISUSING = "1";
                else
                    MODELINVOICEBATCH.ISUSING = "0";
                MODELINVOICEBATCH.INVOICEBATCHMEMO = txtMemo.Text;
                if (txtID.Text == "")
                {
                    //新增发票记录
                    //查询发票批次是否已经存在
                    DataTable dt = BLLINVOICEBATCH.Query(" AND INVOICEBATCHNAME='" + txtBatchName.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        txtBatchName.Focus();
                        mes.Show("名称为'" + txtBatchName.Text + "'的发票批次已经存在!");
                        return;
                    }
                    if (BLLINVOICEBATCH.Insert(MODELINVOICEBATCH))
                    {
                        toolSearch_Click(null, null);
                        if (dgList.Rows.Count > 0)
                        {
                            dgList.ClearSelection();
                            dgList.CurrentCell = dgList.Rows[dgList.Rows.Count - 1].Cells["INVOICEBATCHNAME"];
                            dgList_CellClick(null, new DataGridViewCellEventArgs(2, dgList.Rows.Count - 1));
                        }
                    }
                    else
                    {
                        mes.Show("新增发票批次记录失败,请重新操作!");
                        return;
                    }
                }
                else
                {
                    MODELINVOICEBATCH.INVOICEBATCHID = txtID.Text;
                    if (BLLINVOICEBATCH.Update(MODELINVOICEBATCH))
                    {
                        if (dgList.CurrentRow != null)
                        {
                            dgList.CurrentRow.Cells["INVOICEBATCHNAME"].Value = MODELINVOICEBATCH.INVOICEBATCHNAME;
                            dgList.CurrentRow.Cells["ISUSING"].Value = MODELINVOICEBATCH.ISUSING;
                            dgList.CurrentRow.Cells["INVOICEBATCHMEMO"].Value = MODELINVOICEBATCH.INVOICEBATCHMEMO;
                        }
                    }
                    else
                    {
                        mes.Show("修改发票批次记录失败,请重新查询后再修改!");
                        return;
                    }
                }

                dgList.Enabled = true;
                toolAdd.Text = "新增";
                toolSearch.Enabled = true;
                toolDelete.Enabled = true;
                isADD = false;

                if(frm!=null)
                frm.isModify = true;
            }
            catch (Exception ex)
            {
                log.Write(ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
            }
        }

        private void txtStartNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtBatchName_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "" && !isADD)
                if (txtBatchName.Text.Trim() != "")
                {
                    mes.Show("如果要录入新的发票批次，请点击'新增'按钮后再输入新的发票批次!");
                    txtBatchName.Clear();
                }
        }

        private void dgList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            txtID.Clear();
            txtBatchName.Clear();
            txtMemo.Clear();

            object objID = dgList.Rows[e.RowIndex].Cells["INVOICEBATCHID"].Value;
            if (objID != null && objID != DBNull.Value)
            {
                txtID.Text = objID.ToString();
            }

            object obj = dgList.Rows[e.RowIndex].Cells["INVOICEBATCHNAME"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtBatchName.Text = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["INVOICEBATCHMEMO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtMemo.Text = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["ISUSING"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                if (obj.ToString() == "1")
                    chkIsUsing.Checked = true;
                else
                    chkIsUsing.Checked = false;
            }
        }

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            if (dgList.Columns[e.ColumnIndex].Name == "ISUSING")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if (e.Value.ToString() == "1")
                        e.Value = "是";
                    else if (e.Value.ToString() == "0")
                        e.Value = "否";
                }
            }
        }
    }
}
