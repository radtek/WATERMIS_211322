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
using System.IO;

namespace BASEMANAGE
{
    public partial class frmWaterMeterTypeClass : DockContentEx
    {
        public frmWaterMeterTypeClass()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLWATERMETERTYPECLASS BLLWATERMETERTYPECLASS = new BLLWATERMETERTYPECLASS();
        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();

        private void frmWaterUserType_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            Query();
        }

        private void Query()
        {
            DataTable dt = BLLWATERMETERTYPECLASS.Query("");
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
                return;
            }
                txtID.Clear();
                txtName.Clear();
                txtMemo.Clear();
                object obj = dgList.CurrentRow.Cells["WATERMETERTYPECLASSID"].Value;
            if (obj != null && obj != DBNull.Value)
                txtID.Text = obj.ToString();
            else
                txtID.Clear();

            obj = dgList.CurrentRow.Cells["WATERMETERTYPECLASSNAME"].Value;
            if (obj != null && obj != DBNull.Value)
                txtName.Text = obj.ToString();
            else
                txtName.Clear();

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
                txtMemo.Clear();

                toolAdd.Text = "取消";
                toolDel.Enabled = false;
                
                dgList.Enabled = false;
                isAdd = true;
            }
            else
            {
                dgList_SelectionChanged(null,null);
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
            object obj = dgList.CurrentRow.Cells["WATERMETERTYPECLASSID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strID = obj.ToString();
                obj = dgList.CurrentRow.Cells["WATERMETERTYPECLASSNAME"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strName = obj.ToString();
                }
                if (mes.ShowQ("确定要删除分类名称为 " + strName + " 的信息吗?") == DialogResult.OK)
                {
                    if (BLLWATERMETERTYPECLASS.Delete(strID))
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
                mes.Show("性质名称不能为空!");
                txtName.Focus();
                return;
            }

            MODELWATERMETERTYPECLASS MODELWATERMETERTYPECLASS = new MODELWATERMETERTYPECLASS();
            MODELWATERMETERTYPECLASS.WATERMETERTYPECLASSNAME = txtName.Text;
            MODELWATERMETERTYPECLASS.MEMO = txtMemo.Text;
            if (isAdd)
            {
                MODELWATERMETERTYPECLASS.WATERMETERTYPECLASSID= GETTABLEID.GetTableID("", "WATERMETERTYPECLASS");
                bool isSuccess = BLLWATERMETERTYPECLASS.Insert(MODELWATERMETERTYPECLASS);
                if (isSuccess)
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
                if (txtID.Text.Trim() == "")
                {
                    mes.Show("如果要执行添加操作，请先点击添加按钮后再保存!");
                    return;
                }
                MODELWATERMETERTYPECLASS.WATERMETERTYPECLASSID = txtID.Text;
                if (BLLWATERMETERTYPECLASS.Update(MODELWATERMETERTYPECLASS))
                {
                    if(dgList.CurrentRow!=null)
                    {
                        dgList.CurrentRow.Cells["WATERMETERTYPECLASSNAME"].Value = txtName.Text;
                        dgList.CurrentRow.Cells["MEMO"].Value = txtMemo.Text;
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


        private void chkExtraCharge_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk=(CheckBox)sender;
            string strNum=chk.Name.Substring(14,1);
            if (chk.Checked)
            {
                foreach (Control con in grpDetail.Controls)
                {
                    if (con is TextBox)
                    {
                        TextBox txt = (TextBox)con;
                        if (txt.Name == "txtExtraCharge" + strNum)
                        {
                            txt.Enabled = true;
                            txt.BackColor = SystemColors.Window;
                            break;
                        }
                    }
                }
                foreach (Control conChk in grpDetail.Controls)
                {
                    if (conChk is CheckBox)
                    {
                        CheckBox chkByCharge = (CheckBox)conChk;
                        if (chkByCharge.Name == "chkByMoney" + strNum)
                        {
                            chkByCharge.Enabled = true;
                        }
                    }
                }
            }
            else
                foreach (Control con in grpDetail.Controls)
                {
                    if (con is TextBox)
                    {
                        TextBox txt = (TextBox)con;
                        if (txt.Name == "txtExtraCharge" + strNum)
                        {
                            txt.Text = "0";
                            txt.Enabled = false;
                            txt.BackColor = SystemColors.Control;
                        }
                    }
                    foreach (Control conChk in grpDetail.Controls)
                    {
                        if (conChk is CheckBox)
                        {
                            CheckBox chkByCharge = (CheckBox)conChk;
                            if (chkByCharge.Name == "chkByMoney" + strNum)
                            {
                                chkByCharge.Enabled = false;
                                chkByCharge.Checked = false;
                            }
                        }
                    }
                }
        }
        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "overDuechargeEnable")
            {
                if(e.Value!=null&&e.Value!=DBNull.Value)
                if (e.Value.ToString() == "1")
                    e.Value = "是";
                else
                    e.Value = "否";
            }
        }
    }
}
