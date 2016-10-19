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
    public partial class frmExtraChargeManage : DockContentEx
    {
        public frmExtraChargeManage()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        private void frmWaterMeterSize_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            Query();
        }
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();

        private void Query()
        {
            DataTable dt = BLLEXTRACHARGE.Query("");
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
                txtFeePrice.Clear();
                txtMemo.Clear();
                return;
            }
            object obj = dgList.CurrentRow.Cells["extraChargeID"].Value;
            if (obj != null && obj != DBNull.Value)
                txtID.Text = obj.ToString();
            else
                txtID.Clear();

            obj = dgList.CurrentRow.Cells["extraChargeName"].Value;
            if (obj != null && obj != DBNull.Value)
                txtName.Text = obj.ToString();
            else
                txtName.Clear();

            obj = dgList.CurrentRow.Cells["extraChargeValue"].Value;
            if (obj != null && obj != DBNull.Value)
                txtFeePrice.Text = obj.ToString();
            else
                txtFeePrice.Clear();

            obj = dgList.CurrentRow.Cells["extraChargeState"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                if (obj.ToString() == "未启用")
                    chkIsUsed.Checked = false;
                else if(obj.ToString() == "启用")
                    chkIsUsed.Checked = true;
            }

            obj = dgList.CurrentRow.Cells["MEMO"].Value;
            if (obj != null && obj != DBNull.Value)
                txtMemo.Text = obj.ToString();
            else
                txtMemo.Clear();
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;

            string strID = "", strName = "";
            object obj = dgList.CurrentRow.Cells["extraChargeID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strID = obj.ToString();
                obj = dgList.CurrentRow.Cells["extraChargeName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strName = obj.ToString();
                }
                if (mes.ShowQ("确定要删除费用名称为 " + strName + " 的信息吗?") == DialogResult.OK)
                {
                    if (BLLEXTRACHARGE.Delete(strID))
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
                mes.Show("费用名称不能为空!");
                txtName.Focus();
                return;
            }
            if (txtFeePrice.Text.Trim() == "")
            {
                txtFeePrice.Text = "0";
            }
            else
            {
                if (!Information.IsNumeric(txtFeePrice.Text.Trim()))
                {
                    mes.Show("费用单价只能为数字!");
                    txtFeePrice.Focus();
                    return;
                }
            }

            MODELEXTRACHARGE MODELEXTRACHARGE = new MODELEXTRACHARGE();
            MODELEXTRACHARGE.extraChargeName = txtName.Text;
            MODELEXTRACHARGE.extraChargeValue = Convert.ToDecimal(txtFeePrice.Text);
            if (chkIsUsed.Checked)
                MODELEXTRACHARGE.extraChargeState = "1";
            else
                MODELEXTRACHARGE.extraChargeState = "0";
            MODELEXTRACHARGE.MEMO = txtMemo.Text;
                MODELEXTRACHARGE.extraChargeID = txtID.Text;
                if (BLLEXTRACHARGE.Update(MODELEXTRACHARGE))
                {
                    Query();
                    dgList.ClearSelection();
                    for (int i = 0; i < dgList.Rows.Count; i++)
                    {
                        if (dgList.Rows[i].Cells["extraChargeID"].Value != null && dgList.CurrentRow.Cells["extraChargeID"].Value != DBNull.Value)
                        {
                            string strID = dgList.Rows[i].Cells["extraChargeID"].Value.ToString();
                            if (MODELEXTRACHARGE.extraChargeID == strID)
                            {
                                dgList.CurrentCell = dgList.Rows[i].Cells["extraChargeName"];
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
            dgList.Enabled = true;
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //检测是否已经输入了小数点 
            bool IsContainsDot = this.txtFeePrice.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
        }

    }
}
