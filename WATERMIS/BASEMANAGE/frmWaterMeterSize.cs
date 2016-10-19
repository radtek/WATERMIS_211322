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

namespace BASEMANAGE
{
    public partial class frmWaterMeterSize : DockContentEx
    {
        public frmWaterMeterSize()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        private void frmWaterMeterSize_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            Query();
        }
        BLLwaterMeterSize BLLwaterMeterSize = new BLLwaterMeterSize();
        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();

        private void Query()
        {
            DataTable dt = BLLwaterMeterSize.Query("");
            dgList.DataSource = dt;
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

        private void dgList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
            {
                txtID.Clear();
                txtName.Clear();
                txtCheckPeriod.Clear();
                txtFixed.Text = "0";
                txtPercent.Text = "0";
                rbFixed.Checked = true;
                txtMemo.Clear();
                return;
            }
            object obj = dgList.CurrentRow.Cells["waterMeterSizeId"].Value;
            if (obj != null && obj != DBNull.Value)
                txtID.Text = obj.ToString();
            else
                txtID.Clear();

            obj = dgList.CurrentRow.Cells["waterMeterSizeValue"].Value;
            if (obj != null && obj != DBNull.Value)
                txtName.Text = obj.ToString();
            else
                txtName.Clear();

            obj = dgList.CurrentRow.Cells["checkPeriod"].Value;
            if (obj != null && obj != DBNull.Value)
                txtCheckPeriod.Text = obj.ToString();
            else
                txtCheckPeriod.Clear();

            obj = dgList.CurrentRow.Cells["waterLossComputeType"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                if (obj.ToString() == "固定水量")
                {
                    rbFixed.Checked = true;
                    object objValue=dgList.CurrentRow.Cells["waterLossValue"].Value;
                    if(objValue!=null&&objValue!=DBNull.Value)
                    {
                        txtFixed.Text = objValue.ToString();
                    }
                }
                else
                {
                    rbPercent.Checked = true;
                    object objValue = dgList.CurrentRow.Cells["waterLossValue"].Value;
                    if (objValue != null && objValue != DBNull.Value)
                    {
                        txtPercent.Text = objValue.ToString();
                    }
                }
            }

            obj = dgList.CurrentRow.Cells["waterLossValue"].Value;
            if (obj != null && obj != DBNull.Value)
                txtPercent.Text = obj.ToString();
            else
                txtPercent.Clear();

            obj = dgList.CurrentRow.Cells["MEMO"].Value;
            if (obj != null && obj != DBNull.Value)
                txtMemo.Text = obj.ToString();
            else
                txtMemo.Clear();
        }

        bool isAdd = false;
        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (toolAdd.Text == "添加")
            {
                txtID.Clear();
                txtName.Clear();
                txtCheckPeriod.Clear();
                rbFixed.Checked = true;
                txtMemo.Clear();
                txtName.Focus();

                toolAdd.Text = "取消";
                toolDel.Enabled = false;

                dgList.Enabled = false;
                isAdd = true;
            }
            else
            {
                dgList_SelectionChanged(null, null);
                toolAdd.Text = "添加";
                toolDel.Enabled = true;
                dgList.Enabled = true;
                isAdd = false;
            }
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;

            string strID = "", strName = "";
            object obj = dgList.CurrentRow.Cells["waterMeterSizeId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strID = obj.ToString();
                obj = dgList.CurrentRow.Cells["waterMeterSizeValue"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strName = obj.ToString();
                }
                if (mes.ShowQ("确定要删除口径为 " + strName + " 的信息吗?") == DialogResult.OK)
                {
                    if (BLLwaterMeterSize.Delete(strID))
                    {
                        dgList.Rows.Remove(dgList.CurrentRow);
                    }
                    else
                    {
                        mes.Show("删除失败!请重新打开窗体后再执行删除操作!");
                        return;
                    }
                }
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                mes.Show("类别名称不能为空!");
                txtName.Focus();
                return;
            }
            if (rbFixed.Checked)
            {
                if (txtFixed.Text.Trim() == "")
                {
                    txtFixed.Text = "0";
                }
                else
                {
                    if (!Information.IsNumeric(txtFixed.Text.Trim()))
                    {
                        mes.Show("固定水量只能为整数!");
                        txtFixed.Focus();
                        return;
                    }
                }
            }
            if (rbPercent.Checked)
            {
                if (txtPercent.Text.Trim() == "")
                {
                    txtPercent.Text = "0";
                }
                else
                {
                    if (!Information.IsNumeric(txtPercent.Text.Trim()))
                    {
                        mes.Show("按比例只能为数字!");
                        txtPercent.Focus();
                        return;
                    }
                }
            }
            if (txtCheckPeriod.Text.Trim() == "")
            {
                txtCheckPeriod.Text = "0";
            }
            else
            {
                if (!Information.IsNumeric(txtCheckPeriod.Text.Trim()))
                {
                    mes.Show("鉴定周期只能为整数!");
                    txtCheckPeriod.Focus();
                    return;
                }
            }

            MODELwaterMeterSize MODELwaterMeterSize = new MODELwaterMeterSize();
            MODELwaterMeterSize.waterMeterSizeValue = txtName.Text;
            MODELwaterMeterSize.checkPeriod = Convert.ToInt32(txtCheckPeriod.Text);


            if (rbFixed.Checked)
            {
                MODELwaterMeterSize.waterLossComputeType = "0";
                MODELwaterMeterSize.waterLossValue = Convert.ToInt32(txtFixed.Text);
            }
            else
            {
                MODELwaterMeterSize.waterLossComputeType = "1";
                MODELwaterMeterSize.waterLossValue = Convert.ToDecimal(txtPercent.Text);
            }

            MODELwaterMeterSize.MEMO = txtMemo.Text;

            if (isAdd)
            {
                MODELwaterMeterSize.waterMeterSizeId = GETTABLEID.GetTableID("", "WATERMETERSIZE");
                if (BLLwaterMeterSize.Insert(MODELwaterMeterSize))
                {
                    Query();
                }
                else
                {
                    mes.Show("添加失败，请重新点击保存按钮!");
                    return;
                }
            }
            else
            {
                MODELwaterMeterSize.waterMeterSizeId = txtID.Text;
                if (BLLwaterMeterSize.Update(MODELwaterMeterSize))
                {
                    Query();
                    dgList.ClearSelection();
                    for (int i = 0; i < dgList.Rows.Count; i++)
                    {
                        if (dgList.Rows[i].Cells["waterMeterSizeId"].Value != null && dgList.CurrentRow.Cells["waterMeterSizeId"].Value != DBNull.Value)
                        {
                            string strID = dgList.Rows[i].Cells["waterMeterSizeId"].Value.ToString();
                            if (MODELwaterMeterSize.waterMeterSizeId == strID)
                            {
                                dgList.CurrentCell = dgList.Rows[i].Cells["waterMeterSizeValue"];
                                dgList_SelectionChanged(null, null);
                            }
                        }
                    }
                }
                else
                {
                    mes.Show("修改失败，请重新点击保存按钮!");
                    return;
                }
            }
            dgList.Enabled = true;
            toolDel.Enabled = true;
            toolAdd.Text = "添加";
            isAdd = false;
        }

        private void txtPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            //检测是否已经输入了小数点 
            bool IsContainsDot = this.txtPercent.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
        }

        private void txtFixed_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
