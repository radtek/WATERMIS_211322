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
    public partial class frmWaterUserType : DockContentEx
    {
        public frmWaterUserType()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        private void frmWaterUserType_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            Query();
        }

        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();

        private void Query()
        {
            DataTable dt = BLLwaterUserType.Query("");
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
                txtInvioceBillName.Clear();
                chkIsEnable.Checked = false;
                txtMemo.Clear();
                return;
            }
            object obj = dgList.CurrentRow.Cells["waterUserTypeId"].Value;
            if (obj != null && obj != DBNull.Value)
                txtID.Text = obj.ToString();
            else
                txtID.Clear();

            obj = dgList.CurrentRow.Cells["waterUserTypeName"].Value;
            if (obj != null && obj != DBNull.Value)
                txtName.Text = obj.ToString();
            else
                txtName.Clear();

            obj = dgList.CurrentRow.Cells["invoiceBillName"].Value;
            if (obj != null && obj != DBNull.Value)
                txtInvioceBillName.Text = obj.ToString();
            else
                txtInvioceBillName.Clear();

            obj = dgList.CurrentRow.Cells["overDuechargeEnable"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                if (obj.ToString() == "是")
                    chkIsEnable.Checked = true;
                else
                    chkIsEnable.Checked = false;
            }
            else
                chkIsEnable.Checked = false;

            obj = dgList.CurrentRow.Cells["overDuechargeStartMonth"].Value;
            if (obj != null && obj != DBNull.Value)
                txtStartMonth.Text = obj.ToString();
            else
                txtStartMonth.Clear();

            obj = dgList.CurrentRow.Cells["overDuechargeStartDay"].Value;
            if (obj != null && obj != DBNull.Value)
                txtStartDay.Text = obj.ToString();
            else
                txtStartDay.Clear();

            obj = dgList.CurrentRow.Cells["overDuechargePercent"].Value;
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

        private void chkIsEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsEnable.Checked)
            {
                tb1.RowStyles[1].Height=90;
            }
            else
            {
                tb1.RowStyles[1].Height = 0;
            }
        }
        bool isAdd = false;
        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (toolAdd.Text == "添加")
            {
                txtID.Clear();
                txtName.Clear();
                txtInvioceBillName.Clear();
                chkIsEnable.Checked = false;
                txtMemo.Clear();
                txtName.Focus();

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
            object obj = dgList.CurrentRow.Cells["waterUserTypeId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strID = obj.ToString();
                obj = dgList.CurrentRow.Cells["waterUserTypeName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strName = obj.ToString();
                }
                if (mes.ShowQ("确定要删除 " + strName + " 的信息吗?") == DialogResult.OK)
                {
                    if (BLLwaterUserType.Delete(strID))
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
            if (chkIsEnable.Checked)
            {
                if (txtStartMonth.Text.Trim() == "")
                {
                    mes.Show("请输入开始月份!");
                    txtStartMonth.Focus();
                    return;
                }
                else
                {
                    if (!Information.IsNumeric(txtStartMonth.Text.Trim()))
                    {
                        mes.Show("开始月份只能为整数!");
                        txtStartMonth.Focus();
                        return;
                    }
                }
                if (txtStartDay.Text.Trim() == "")
                {
                    mes.Show("请输入开始日期!");
                    txtStartDay.Focus();
                    return;
                }
                else
                {
                    if (!Information.IsNumeric(txtStartDay.Text.Trim()))
                    {
                        mes.Show("开始日期只能为整数!");
                        txtStartDay.Focus();
                        return;
                    }
                }
                if (txtPercent.Text.Trim() == "")
                {
                    mes.Show("请输入滞纳金比率!");
                    txtPercent.Focus();
                    return;
                }
                else
                {
                    if (!Information.IsNumeric(txtStartMonth.Text.Trim()))
                    {
                        mes.Show("滞纳金比率只能为数字!");
                        txtPercent.Focus();
                        return;
                    }
                }
            }

            MODELwaterUserType MODELwaterUserType = new MODELwaterUserType();
            MODELwaterUserType.waterUserTypeName = txtName.Text;
            MODELwaterUserType.invoiceBillName = txtInvioceBillName.Text;

            if (MODELwaterUserType.invoiceBillName != "")
            {
                string strFile = txtFilePath.Text;
                if (strFile != "")
                if (File.Exists(strFile))
                {
                    if (!File.Exists(Application.StartupPath + @"\InvoiceModel\" + txtInvioceBillName.Text))
                    {
                        File.Copy(strFile, Application.StartupPath + @"\InvoiceModel\" + txtInvioceBillName.Text, true);
                    }
                }
                else
                {
                    mes.Show("模板文件\"" + strFile + "\"不存在，请重新选择!");
                    return;
                }
            }

            if (chkIsEnable.Checked)
            {
                MODELwaterUserType.overDuechargeEnable = "1";
            MODELwaterUserType.overDuechargeStartMonth = Convert.ToInt32(txtStartMonth.Text);
            MODELwaterUserType.overDuechargeStartDay = Convert.ToInt32(txtStartDay.Text);
            MODELwaterUserType.overDuechargePercent = Convert.ToDecimal(txtPercent.Text);
            }
            else
                MODELwaterUserType.overDuechargeEnable = "0";
            MODELwaterUserType.MEMO = txtMemo.Text;

            if (isAdd)
            {
                MODELwaterUserType.waterUserTypeId = GETTABLEID.GetTableID("", "WATERUSERTYPE");
                if (BLLwaterUserType.Insert(MODELwaterUserType))
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
                MODELwaterUserType.waterUserTypeId = txtID.Text;
                if (BLLwaterUserType.Update(MODELwaterUserType))
                {
                    Query();
                    dgList.ClearSelection();
                    for (int i = 0; i < dgList.Rows.Count; i++)
                    {
                        if (dgList.Rows[i].Cells["waterUserTypeId"].Value != null && dgList.CurrentRow.Cells["waterUserTypeId"].Value != DBNull.Value)
                        {
                            string strID = dgList.Rows[i].Cells["waterUserTypeId"].Value.ToString();
                            if (MODELwaterUserType.waterUserTypeId == strID)
                            {
                                dgList.CurrentCell = dgList.Rows[i].Cells["waterUserTypeName"];
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
            txtFilePath.Clear();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        { 
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
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

        private void btModel_Click(object sender, EventArgs e)
        {
            string strFile="",strFileName = "",strInitialDirectory= Application.StartupPath + @"\InvoiceModel";
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "所有类型|*.*|word|*.doc";
            OpenFileDialog.InitialDirectory = strInitialDirectory;
            OpenFileDialog.FilterIndex = 0;
            //OpenFileDialog.RestoreDirectory = false;
            
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFile = OpenFileDialog.FileName;
                txtFilePath.Text = strFile;//记录文件的位置，保存的时候将此文件复制到程序目录

                strFileName=OpenFileDialog.SafeFileName;
                txtInvioceBillName.Text = strFileName;
            }
        }
    }
}
