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
    public partial class frmInvoiceStocks : DockContentEx
    {
        public frmInvoiceStocks()
        {
            InitializeComponent();
        }

        BLLINVOICEBATCH BLLINVOICEBATCH = new BLLINVOICEBATCH();
        BLLINVOICESTOCKS BLLINVOICESTOCKS = new BLLINVOICESTOCKS();

        /// <summary>
        /// 记录发票批次界面是否更改批次数据
        /// </summary>
        public bool isModify = false;

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        private void frmInvoiceStocks_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;

            BindInvoiceBatch();
            toolSearch_Click(null,null);
        }

        /// <summary>
        /// 绑定发票批次
        /// </summary>
        /// <param name="cmb"></param>
        private void BindInvoiceBatch()
        {
            DataTable dt = BLLINVOICEBATCH.Query(" ORDER BY INVOICEBATCHID DESC");
            cmbBatch.DataSource = dt;
            cmbBatch.DisplayMember = "INVOICEBATCHNAME";
            cmbBatch.ValueMember = "INVOICEBATCHID";

            DataTable dtSearch = dt.Copy();
            DataRow dr = dtSearch.NewRow();
            dr["INVOICEBATCHNAME"] = "全部批次";
            dr["INVOICEBATCHID"] = DBNull.Value;
            dtSearch.Rows.InsertAt(dr, 0);
            cmbBatchSearch.DataSource = dtSearch;
            cmbBatchSearch.DisplayMember = "INVOICEBATCHNAME";
            cmbBatchSearch.ValueMember = "INVOICEBATCHID";
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
            //txtStartNO.Clear();
            //txtEndNO.Clear();
            //txtMemo.Clear();
            //cmbBatch.SelectedValue = DBNull.Value;

            //object objID = dgList.Rows[e.RowIndex].Cells["INVOICESTOCKSID"].Value;
            //if (objID != null && objID != DBNull.Value)
            //{
            //    txtID.Text = objID.ToString();
            //}

            //object obj = dgList.Rows[e.RowIndex].Cells["INVOICESTARTNO"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtStartNO.Text = obj.ToString();
            //}

            //obj = dgList.Rows[e.RowIndex].Cells["INVOICEENDNO"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtEndNO.Text = obj.ToString();
            //}

            //obj = dgList.Rows[e.RowIndex].Cells["INVOICEBATCHID"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    cmbBatch.SelectedValue = obj;
            //}

            //obj = dgList.Rows[e.RowIndex].Cells["INVOICEMEMO"].Value;
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
            DataTable dtList = BLLINVOICESTOCKS.Query(strFilter);
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
                if (cmbBatchSearch.Items.Count <2)
                {
                    mes.Show("系统检测到发票批次为空,请先新增发票批次!");
                    btBatch_Click(null,null);
                }

                txtID.Clear();
                txtStartNO.Clear();
                txtEndNO.Clear();
                txtMemo.Clear();
                cmbBatch.SelectedValue = DBNull.Value;

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
                    dgList_CellClick(null, new DataGridViewCellEventArgs(2, intRowIndex));
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
            if (mes.ShowQ("确定要删除发票批次为'" + cmbBatch.Text + "'的发票记录吗?") == DialogResult.OK)
            if (BLLINVOICESTOCKS.Delete(txtID.Text))
            {
                dgList.Rows.Remove(dgList.CurrentRow);
                if (dgList.Rows.Count == 0)
                {
                    txtID.Clear();
                    txtStartNO.Clear();
                    txtEndNO.Clear();
                    txtMemo.Clear();
                    cmbBatch.SelectedValue = DBNull.Value;
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
                mes.Show("删除失败!请从发票列表内重新选择要删除的行!");
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
                    mes.Show("请输入发票起始号，发票起始号只能为数字!");
                    txtStartNO.Focus();
                    return;
                }
                if (!Information.IsNumeric(txtEndNO.Text))
                {
                    mes.Show("请输入发票终止号，发票终止号只能为数字!");
                    txtEndNO.Focus();
                    return;
                }
                if (cmbBatch.SelectedValue == DBNull.Value || cmbBatch.SelectedValue == null)
                {
                    mes.Show("请选择发票批次!");
                    cmbBatch.Focus();
                    return;
                }
                if (Convert.ToInt64(txtStartNO.Text) > Convert.ToInt64(txtEndNO.Text))
                {
                    mes.Show("发票的起始号码不能大于发票终止号码!");
                    txtStartNO.Focus();
                    return;
                }

                MODELINVOICESTOCKS MODELINVOICESTOCKS = new MODELINVOICESTOCKS();
                MODELINVOICESTOCKS.INVOICEBATCHID = Convert.ToInt32(cmbBatch.SelectedValue);
                MODELINVOICESTOCKS.INVOICESTARTNO = txtStartNO.Text;
                MODELINVOICESTOCKS.INVOICEENDNO = txtEndNO.Text;
                MODELINVOICESTOCKS.INVOICEMEMO = txtMemo.Text;

                //查询发票批次中的发票号是否已存在
                DataTable dt =new DataTable();
                if(isADD)
                dt= BLLINVOICESTOCKS.Query(" AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                else
                    dt = BLLINVOICESTOCKS.Query(" AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICESTOCKSID<>"+txtID.Text);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    long intStartNO=0,intEndNO=0;
                    object obj = dt.Rows[i]["INVOICESTARTNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intStartNO = Convert.ToInt64(obj);
                    }
                    obj = dt.Rows[i]["INVOICEENDNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intEndNO = Convert.ToInt64(obj);
                    }

                    if (Convert.ToInt64(MODELINVOICESTOCKS.INVOICESTARTNO) >= intStartNO && Convert.ToInt64(MODELINVOICESTOCKS.INVOICESTARTNO) <= intEndNO)
                    {
                        mes.Show("批次为'" + cmbBatch .Text+ "'的发票起始号码在数据库中已存在!");
                        txtStartNO.Focus();
                        return;
                    }

                    if (Convert.ToInt64(MODELINVOICESTOCKS.INVOICEENDNO) >= intStartNO && Convert.ToInt64(MODELINVOICESTOCKS.INVOICEENDNO) <= intEndNO)
                    {
                        mes.Show("批次为'" + cmbBatch.Text + "'的发票终止号码在数据库中已存在!");
                        txtStartNO.Focus();
                        return;
                    }
                }



                    if (isADD)
                    {
                        //新增发票记录
                        if (BLLINVOICESTOCKS.Insert(MODELINVOICESTOCKS))
                        {
                            toolSearch_Click(null, null);
                            if (dgList.Rows.Count > 0)
                            {
                                dgList.ClearSelection();
                                dgList.CurrentCell = dgList.Rows[dgList.Rows.Count - 1].Cells["INVOICEBATCHNAME"];
                                dgList_CellClick(null, new DataGridViewCellEventArgs(2, dgList.Rows.Count - 1));
                            }
                            //for (int i = 0; i < dgList.Rows.Count; i++)
                            //{
                            //    object obj = dgList.Rows[i].Cells["INVOICEBATCHID"].Value;
                            //    if (obj != null && obj != DBNull.Value)
                            //    {
                            //        if (MODELINVOICESTOCKS.INVOICEBATCHID == Convert.ToInt32(obj))
                            //        {
                            //            dgList.ClearSelection();
                            //            dgList.CurrentCell = dgList.Rows[i].Cells["INVOICEBATCHNAME"];

                            //            dgList_CellClick(null, new DataGridViewCellEventArgs(2, i));
                            //            break;
                            //        }
                            //    }
                            //}
                        }
                        else
                        {
                            mes.Show("新增发票记录失败,请重新操作!");
                            return;
                        }
                    }
                    else
                    {
                        MODELINVOICESTOCKS.INVOICESTOCKSID = txtID.Text;
                        if (BLLINVOICESTOCKS.Update(MODELINVOICESTOCKS))
                        {
                            if (dgList.CurrentRow != null)
                            {
                                dgList.CurrentRow.Cells["INVOICEBATCHID"].Value = MODELINVOICESTOCKS.INVOICEBATCHID;
                                dgList.CurrentRow.Cells["INVOICEBATCHNAME"].Value = cmbBatch.Text;
                                dgList.CurrentRow.Cells["INVOICESTARTNO"].Value = MODELINVOICESTOCKS.INVOICESTARTNO;
                                dgList.CurrentRow.Cells["INVOICEENDNO"].Value = MODELINVOICESTOCKS.INVOICEENDNO;
                                dgList.CurrentRow.Cells["INVOICEMEMO"].Value = MODELINVOICESTOCKS.INVOICEMEMO;
                            }
                        }
                        else
                        {
                            mes.Show("修改发票记录失败,请重新查询发票列表后再修改!");
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
                log.Write(ex.ToString(),MsgType.Error);
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
        private void btBatch_Click(object sender, EventArgs e)
        {
            frmBatchManage frm = new frmBatchManage();
            frm.frm = this;
            frm.ShowDialog();
            if(this.isModify)
            {
                BindInvoiceBatch();
                isModify = false;
            }
        }

        private void txtStartNO_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "" && !isADD)
                if (txtStartNO.Text.Trim() != "")
                {
                    mes.Show("如果要录入新的发票，请点击'新增'按钮后再输入新的发票号!");
                    txtStartNO.Clear();
                }
        }

        private void txtStartNO_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt=(TextBox)sender;
            if (txt.Text != "" && !Information.IsNumeric(txt.Text))
            {
                e.Cancel = true;
                mes.Show("发票号只能为数字型!");
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
            cmbBatch.SelectedValue = DBNull.Value;

            object objID = dgList.Rows[e.RowIndex].Cells["INVOICESTOCKSID"].Value;
            if (objID != null && objID != DBNull.Value)
            {
                txtID.Text = objID.ToString();
            }

            object obj = dgList.Rows[e.RowIndex].Cells["INVOICESTARTNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtStartNO.Text = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["INVOICEENDNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtEndNO.Text = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["INVOICEBATCHID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbBatch.SelectedValue = obj;
            }

            obj = dgList.Rows[e.RowIndex].Cells["INVOICEMEMO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtMemo.Text = obj.ToString();
            }
        }
    }
}
