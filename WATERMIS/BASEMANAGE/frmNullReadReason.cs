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
    public partial class frmNullReadReason : DockContentEx
    {
        public frmNullReadReason()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        private void frmBankManage_Load(object sender, EventArgs e)
        {
            toolSearch_Click(null, null);
        }
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();
        BLLNullReadReasonMemo BLLNullReadReasonMemo = new BLLNullReadReasonMemo();
        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (txtNameS.Text.Trim() != "")
                strFilter = " AND NullReadReasonName LIKE '%" + txtNameS.Text.Trim() + "%'";
            DataTable dtList = BLLNullReadReasonMemo.Query(strFilter);
            dgList.DataSource = dtList;
        }

        private bool isAdd = false;
        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (toolAdd.Text == "添加")
            {
                toolSearch.Enabled = false;
                toolDelete.Enabled = false;
                dgList.Enabled = false;

                EnableControl(gbDetail);
                toolAdd.Text = "取消";
                txtName.Focus();
                object objMaxID = BLLNullReadReasonMemo.GetMaxID();
                if (Information.IsNumeric(objMaxID))
                {
                    txtID.Text = (Convert.ToInt32(objMaxID) + 1).ToString();
                }
                else
                    txtID.Text = "1";

                isAdd = true;
                txtID.ReadOnly = false;
            }
            else
            {
                toolSearch.Enabled = true;
                toolDelete.Enabled = true;
                dgList.Enabled = true;
                toolAdd.Text = "添加";
                isAdd = false;

                txtID.ReadOnly = true;
            }

        }

        private void toolSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    mes.Show("请输入未抄表情况说明!");
                    txtName.Focus();
                    return;
                }
                if (txtID.Text.Trim() == "")
                {
                    mes.Show("请输入代码!");
                    txtID.Focus();
                    return;
                }

                MODELNullReadReasonName MODELNullReadReasonName = new MODELNullReadReasonName();
                MODELNullReadReasonName.NullReadReasonName = txtName.Text;
                MODELNullReadReasonName.Memo = txtMemo.Text;
                if (isAdd)
                {
                    DataTable dtRows = BLLNullReadReasonMemo.Query(" AND NullReadReasonID='"+txtID.Text+"'");
                    if (dtRows.Rows.Count > 0)
                    {
                        mes.Show("输入的代码已经存在,请重新输入!");
                        txtID.Focus();
                        return;
                    }

                    MODELNullReadReasonName.NullReadReasonID = txtID.Text;
                    if (BLLNullReadReasonMemo.Insert(MODELNullReadReasonName))
                    {
                        toolSearch_Click(null, null);
                        dgList.ClearSelection();
                        dgList.CurrentCell = dgList.Rows[dgList.Rows.Count - 1].Cells[1];
                    }
                    else
                    {
                        mes.Show("添加失败,请重新点击保存按钮!");
                        return;
                    }
                }
                else
                {
                    //如果修改了代码，检测输入的新代码是否存在
                    MODELNullReadReasonName.NullReadReasonID = txtIDOld.Text;
                    if (BLLNullReadReasonMemo.Update(MODELNullReadReasonName))
                    {
                        dgList.CurrentRow.Cells["NullReadReasonName"].Value = MODELNullReadReasonName.NullReadReasonName;
                        dgList.CurrentRow.Cells["Memo"].Value = MODELNullReadReasonName.Memo;
                    }
                    else
                    {
                        mes.Show("修改失败,请重新点击保存按钮!");
                        return;
                    }
                }
                //DisEnableControl(gbDetail);

                dgList.Enabled = true;
                toolAdd.Text = "添加";
                toolDelete.Enabled = true;
                toolSearch.Enabled = true;
                isAdd = false;
                txtID.ReadOnly = true;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, MsgType.Error);
                mes.Show(ex.Message);
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
            {
                mes.Show("请从下方列表中选择要删除的行!");
                return;
            }
            if (txtIDOld.Text == "")
            {
                mes.Show("系统检测到ID为空，请从下方列表中选择要删除的行!");
                return;
            }
            object obj = dgList.CurrentRow.Cells["NullReadReasonName"].Value;
            if (obj != null && obj != DBNull.Value)
                if (mes.ShowQ("确定要删除" + obj.ToString() + "的信息吗?") == DialogResult.OK)
                {
                    if (!BLLNullReadReasonMemo.Delete(txtIDOld.Text))
                    {
                        mes.Show("删除失败,请从下方列表中重新选择要删除的行!");
                        return;
                    }
                    dgList.Rows.Remove(dgList.CurrentRow);
                }

            if (dgList.Rows.Count == 0)
            {
                txtIDOld.Clear();
                txtID.Clear();
                txtName.Clear();
                txtMemo.Clear();
            }
        }

        /// <summary>
        /// 使能父控件内的所有控件
        /// </summary>
        /// <param name="conParent">父控件</param>
        private void EnableControl(Control conParent)
        {
            foreach (Control con in conParent.Controls)
            {
                if (con is TextBox)
                {
                    ((TextBox)con).Enabled = true;
                    ((TextBox)con).Clear();
                }
            }
        }

        /// <summary>
        /// 禁能父控件内的所有控件
        /// </summary>
        /// <param name="conParent">父控件</param>
        private void DisEnableControl(Control conParent)
        {
            foreach (Control con in conParent.Controls)
            {
                if (con is TextBox)
                {
                    ((TextBox)con).ReadOnly = false;
                }
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

        private void dgList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object obj = dgList.Rows[e.RowIndex].Cells["NullReadReasonID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtID.Text = obj.ToString();
                txtIDOld.Text = obj.ToString();
            }
            else
            {
                txtID.Clear();
                txtIDOld.Clear();
            }
            obj = dgList.Rows[e.RowIndex].Cells["NullReadReasonName"].Value;
            if (obj != null && obj != DBNull.Value)
                txtName.Text = obj.ToString();
            else
                txtName.Clear();
            obj = dgList.Rows[e.RowIndex].Cells["Memo"].Value;
            if (obj != null && obj != DBNull.Value)
                txtMemo.Text = obj.ToString();
            else
                txtMemo.Clear();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)22)
            {
                e.Handled = true;
            }
        }
    }
}
