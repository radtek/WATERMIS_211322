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
    public partial class frmWaterMeterType : DockContentEx
    {
        public frmWaterMeterType()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLWATERMETERTYPECLASS BLLWATERMETERTYPECLASS = new BLLWATERMETERTYPECLASS();
        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();

        private void frmWaterUserType_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            BindWaterMeterTypeClass();
            Query();
            GetExtraFeeName();
        }

        private void Query()
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            dgList.DataSource = dt;
        }

        /// <summary>
        /// 生成用水性质大类列表
        /// </summary>
        private void BindWaterMeterTypeClass()
        {
            DataTable dt = BLLWATERMETERTYPECLASS.Query("");
            cmbWaterMeterTypeClass.DataSource = dt;
            cmbWaterMeterTypeClass.DisplayMember = "WATERMETERTYPECLASSNAME";
            cmbWaterMeterTypeClass.ValueMember="WATERMETERTYPECLASSID";
        }

        /// <summary>
        /// 根据附加费表生成附加费列及单价
        /// </summary>
        private void GetExtraFeeName()
        {
            DataTable dt = BLLEXTRACHARGE.Query(" ORDER BY extraChargeID");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object objExtraFee = dt.Rows[i]["extraChargeName"];
                if (objExtraFee != null && objExtraFee != DBNull.Value)
                {
                    foreach (Control con in grpDetail.Controls)
                    {
                        if (con is CheckBox)
                        {
                            if (con.Name == "chkExtraCharge" + (i+1).ToString())
                            {
                                con.Text = objExtraFee.ToString();
                                break;
                            }
                        }
                    }
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

        private void dgList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
            {
                return;
            }
                txtID.Clear();
                txtName.Clear();
                txtMemo.Clear();

                chkExtraCharge1.Checked = false;
                chkExtraCharge2.Checked = false;
                chkExtraCharge3.Checked = false;
                chkExtraCharge4.Checked = false;
                chkExtraCharge5.Checked = false;
                chkExtraCharge6.Checked = false;
                chkExtraCharge7.Checked = false;
                chkExtraCharge8.Checked = false;

                chkByMoney1.Checked = false;
                chkByMoney2.Checked = false;
                chkByMoney3.Checked = false;
                chkByMoney4.Checked = false;
                chkByMoney5.Checked = false;
                chkByMoney6.Checked = false;
                chkByMoney7.Checked = false;
                chkByMoney8.Checked = false;

            dgTrapezoidPrice.Rows.Clear();
            object obj = dgList.CurrentRow.Cells["waterMeterTypeId"].Value;
            if (obj != null && obj != DBNull.Value)
                txtID.Text = obj.ToString();
            else
                txtID.Clear();

            obj = dgList.CurrentRow.Cells["waterMeterTypeValue"].Value;
            if (obj != null && obj != DBNull.Value)
                txtName.Text = obj.ToString();
            else
                txtName.Clear();

            obj = dgList.CurrentRow.Cells["WATERMETERTYPECLASSID"].Value;
            if (obj != null && obj != DBNull.Value)
                cmbWaterMeterTypeClass.SelectedValue = obj.ToString();
            else
                cmbWaterMeterTypeClass.SelectedValue = null;

            obj = dgList.CurrentRow.Cells["trapezoidPrice"].Value;//0-10:1|10-20:2|20-30:3|30-无:4
            if (obj != null && obj != DBNull.Value)
            {
                if (obj.ToString() != "")
                {
                    string[] strEveryString = obj.ToString().Split('|');
                    int intCount = strEveryString.Length;
                    dgTrapezoidPrice.Rows.Add(intCount);
                    for (int i = 0; i < intCount; i++)
                    {
                        string[] strEveryStringPriceAndTrapezoid = strEveryString[i].Split(':');
                        dgTrapezoidPrice.Rows[i].Cells["lowNumber"].Value = strEveryStringPriceAndTrapezoid[0].Split('-')[0];
                        dgTrapezoidPrice.Rows[i].Cells["highNumber"].Value = strEveryStringPriceAndTrapezoid[0].Split('-')[1];
                        dgTrapezoidPrice.Rows[i].Cells["trapezoidPriceS"].Value = strEveryStringPriceAndTrapezoid[1];
                    }
                }
            }

            obj = dgList.CurrentRow.Cells["extraCharge"].Value;//F1:0|F2:0|F3:0
            if (obj != null && obj != DBNull.Value)
            {
                if (obj.ToString() != "")
                {
                    string[] strEvertyString = obj.ToString().Split('|');
                    for (int i = 0; i < strEvertyString.Length; i++)
                    {
                        string[] strEvertyStringExtraAndPrice = strEvertyString[i].Split(':');
                        string strNum = strEvertyStringExtraAndPrice[0].Substring(1, 1);

                        foreach (Control con in grpDetail.Controls)
                        {
                            if (con is CheckBox)
                            {
                                if (con.Name == "chkExtraCharge" + strNum)
                                {
                                    ((CheckBox)con).Checked = true;

                                    foreach (Control conT in grpDetail.Controls)
                                    {
                                        if (conT is TextBox)
                                        {
                                            TextBox txt=(TextBox)conT;
                                            if (txt.Name == "txtExtraCharge" + strNum)
                                            {
                                                txt.Text=strEvertyStringExtraAndPrice[1];
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
                                                if (strEvertyStringExtraAndPrice[2] == "2")
                                                    chkByCharge.Checked = true;
                                                else
                                                    chkByCharge.Checked = false;
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            obj = dgList.CurrentRow.Cells["overDuechargeEnable"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                if (obj.ToString() == "1")
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

        bool isAdd = false;
        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (toolAdd.Text == "添加")
            {
                txtID.Clear();
                txtName.Clear();
                txtMemo.Clear();

                chkExtraCharge1.Checked = false;
                chkExtraCharge2.Checked = false;
                chkExtraCharge3.Checked = false;
                chkExtraCharge4.Checked = false;
                chkExtraCharge5.Checked = false;
                chkExtraCharge6.Checked = false;
                chkExtraCharge7.Checked = false;
                chkExtraCharge8.Checked = false;

                dgTrapezoidPrice.Rows.Clear();
                dgTrapezoidPrice.Rows.Add(1);
                dgTrapezoidPrice.Rows[0].Cells["lowNumber"].Value = 0;
                dgTrapezoidPrice.Rows[0].Cells["lowNumber"].ReadOnly = true;

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
            object obj = dgList.CurrentRow.Cells["waterMeterTypeId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strID = obj.ToString();
                obj = dgList.CurrentRow.Cells["waterMeterTypeValue"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strName = obj.ToString();
                }
                if (mes.ShowQ("确定要删除用水性质为 " + strName + " 的信息吗?") == DialogResult.OK)
                {
                    if (BLLWATERMETERTYPE.Delete(strID))
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
            if (dgTrapezoidPrice.Rows.Count == 0)
            {
                mes.Show("请添加阶梯水价!");
                dgTrapezoidPrice.Focus();
                return;
            }
            if (cmbWaterMeterTypeClass.SelectedValue == null || cmbWaterMeterTypeClass.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择用水性质分类!");
                cmbWaterMeterTypeClass.Focus();
                return;
            }

            #region 阶梯水价验证
            dgTrapezoidPrice.EndEdit();
            for (int i = 0; i < dgTrapezoidPrice.Rows.Count; i++)
            {
                object objL = dgTrapezoidPrice.Rows[i].Cells["lowNumber"].Value;
                if (objL == null || objL == DBNull.Value)
                {
                    mes.Show("请输入第 " + (i + 1).ToString() + " 行的阶梯下限!");
                    dgTrapezoidPrice.CurrentCell = dgTrapezoidPrice.Rows[i].Cells["lowNumber"];
                    return;
                }
                object objT = dgTrapezoidPrice.Rows[i].Cells["trapezoidPriceS"].Value;
                if (objT == null || objT == DBNull.Value)
                {
                    mes.Show("请输入第 " + (i + 1).ToString() + " 行的阶梯单价!");
                    dgTrapezoidPrice.CurrentCell = dgTrapezoidPrice.Rows[i].Cells["trapezoidPriceS"];
                    return;
                }
                else
                {
                    dgTrapezoidPrice.Rows[i].Cells["trapezoidPriceS"].Value = Convert.ToDecimal(objT);
                    if (Convert.ToDecimal(objT) <= 0)
                    {
                        if (mes.ShowQ("请第 " + (i + 1).ToString() + " 行的阶梯单价为0,确定保存吗?") != DialogResult.OK)
                        {
                            dgTrapezoidPrice.CurrentCell = dgTrapezoidPrice.Rows[i].Cells["trapezoidPriceS"];
                            return;
                        }
                    }
                }
                
                if (!Information.IsNumeric(objL))
                {
                    mes.Show("第 " + (i + 1).ToString() + " 行的阶梯下限只能为整数!");
                    dgTrapezoidPrice.CurrentCell = dgTrapezoidPrice.Rows[i].Cells["lowNumber"];
                    return;
                }

                object objH = dgTrapezoidPrice.Rows[i].Cells["highNumber"].Value;
                if (objH == null || objH == DBNull.Value)
                {
                        mes.Show("请输入第 " + (i + 1).ToString() + " 行的阶梯下限!");
                        dgTrapezoidPrice.CurrentCell = dgTrapezoidPrice.Rows[i].Cells["highNumber"];
                        return;                    
                }
                if (!Information.IsNumeric(objH))
                {
                    mes.Show("第 " + (i + 1).ToString() + " 行的阶梯上限只能为整数!");
                    dgTrapezoidPrice.CurrentCell = dgTrapezoidPrice.Rows[i].Cells["highNumber"];
                    return;
                }
                    if (Convert.ToDecimal(objL) >= Convert.ToDecimal(objH))
                    {
                        mes.Show("第 " + (i + 1).ToString() + " 行的阶梯上限应大于阶梯下限!");
                        dgTrapezoidPrice.CurrentCell = dgTrapezoidPrice.Rows[i].Cells["highNumber"];
                        return;
                    }
                if (i > 0)
                {
                    object objH1 = dgTrapezoidPrice.Rows[i - 1].Cells["highNumber"].Value;
                    object objL2 = dgTrapezoidPrice.Rows[i].Cells["lowNumber"].Value;
                    if (Convert.ToDecimal(objL2) != Convert.ToDecimal(objH1))
                    {
                        mes.Show("第 " + (i + 1).ToString() + " 行的阶梯下限应等于上一行的阶梯上限!");
                        dgTrapezoidPrice.CurrentCell = dgTrapezoidPrice.Rows[i].Cells["lowNumber"];
                        return;
                    }
                }
            }
#endregion

            #region 附加费验证
            foreach (Control conE in grpDetail.Controls)
            {
                if (conE is CheckBox && conE.Name.Contains("chkExtraCharge"))
                {
                    CheckBox chkE = (CheckBox)conE;
                    if (chkE.Checked)
                    {
                        foreach (Control con in grpDetail.Controls)
                        {
                            if (con is TextBox)
                            {
                                TextBox txt = (TextBox)con;
                                if (txt.Name == "txtExtraCharge" + chkE.Name.Substring(14, 1))//chkExtraCharge1
                                {
                                    if (txt.Text.Trim() == "")
                                    {
                                        mes.Show("请填写附加费单价!");
                                        txt.Focus();
                                        return;
                                    }
                                    if (txt.Text.Trim() == "0")
                                    {
                                        mes.Show("附加费单价只能大于0!");
                                        txt.Focus();
                                        return;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region 滞纳金验证
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
                    if (!Information.IsNumeric(txtPercent.Text.Trim()))
                    {
                        mes.Show("滞纳金比率只能为数字!");
                        txtPercent.Focus();
                        return;
                    }
                    if (Convert.ToDecimal(txtPercent.Text) <= 0)
                    {
                        mes.Show("滞纳金比率只能大于0!");
                        txtPercent.Focus();
                        return;
                    }
                }
            }
            #endregion

            MODELWATERMETERTYPE MODELWATERMETERTYPE = new MODELWATERMETERTYPE();
            MODELWATERMETERTYPE.waterMeterTypeValue = txtName.Text;
            MODELWATERMETERTYPE.WATERMETERTYPECLASSID = cmbWaterMeterTypeClass.SelectedValue.ToString();
            string strTrapezoid =string.Empty;
            for (int i = 0; i < dgTrapezoidPrice.Rows.Count; i++)
            {
                if(i>0)
                    strTrapezoid+="|";
                object objL = dgTrapezoidPrice.Rows[i].Cells["lowNumber"].Value;
                object objH = dgTrapezoidPrice.Rows[i].Cells["highNumber"].Value;
                object objT = dgTrapezoidPrice.Rows[i].Cells["trapezoidPriceS"].Value;
                strTrapezoid+=objL.ToString()+"-"+objH.ToString()+":"+objT.ToString();
            }
            MODELWATERMETERTYPE.trapezoidPrice = strTrapezoid;

            string strExtraCharge = string.Empty;
            int intSelectedExtraChargeCount = 0;//存储选择的附加费数量，判断是否加‘|’。
            for (int i = 1; i <= 8; i++)
            {
                foreach (Control con in grpDetail.Controls)
                {
                    if (con is CheckBox)
                    {
                        CheckBox chk = (CheckBox)con;
                        if (chk.Name == "chkExtraCharge" + i.ToString())
                        {
                            if (chk.Checked)
                            {
                                if (intSelectedExtraChargeCount > 0)
                                    strExtraCharge += "|";
                                foreach (Control conT in grpDetail.Controls)
                                {
                                    if (conT is TextBox)
                                    {
                                        TextBox txt = (TextBox)conT;
                                        if (txt.Name == "txtExtraCharge" + i.ToString())
                                        {
                                            intSelectedExtraChargeCount++;
                                            strExtraCharge += "F" + i.ToString() + ":" + Convert.ToDecimal(txt.Text);
                                            break;
                                        }
                                    }
                                }
                                foreach (Control conChk in grpDetail.Controls)
                                {
                                    if (conChk is CheckBox)
                                    {
                                        CheckBox chkByCharge = (CheckBox)conChk;
                                        if (chkByCharge.Name == "chkByMoney" + i.ToString())
                                        {
                                            if (!chkByCharge.Checked)
                                                strExtraCharge += ":1";
                                            else
                                                strExtraCharge += ":2";
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }

            MODELWATERMETERTYPE.extraCharge = strExtraCharge;

            if (chkIsEnable.Checked)
            {
                MODELWATERMETERTYPE.overDuechargeEnable = "1";
                MODELWATERMETERTYPE.overDuechargeStartMonth = Convert.ToInt32(txtStartMonth.Text);
                MODELWATERMETERTYPE.overDuechargeStartDay = Convert.ToInt32(txtStartDay.Text);
                MODELWATERMETERTYPE.overDuechargePercent = Convert.ToDecimal(txtPercent.Text);
            }
            else
                MODELWATERMETERTYPE.overDuechargeEnable = "0";

            MODELWATERMETERTYPE.MEMO = txtMemo.Text;

            if (isAdd)
            {
                MODELWATERMETERTYPE.waterMeterTypeId = GETTABLEID.GetTableID("", "WATERMETERTYPE");
                if (BLLWATERMETERTYPE.Insert(MODELWATERMETERTYPE))
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
                MODELWATERMETERTYPE.waterMeterTypeId = txtID.Text;
                if (BLLWATERMETERTYPE.Update(MODELWATERMETERTYPE))
                {
                    Query();
                    dgList.ClearSelection();
                    for (int i = 0; i < dgList.Rows.Count; i++)
                    {
                        if (dgList.Rows[i].Cells["waterMeterTypeId"].Value != null && dgList.CurrentRow.Cells["waterMeterTypeId"].Value != DBNull.Value)
                        {
                            string strID = dgList.Rows[i].Cells["waterMeterTypeId"].Value.ToString();
                            if (MODELWATERMETERTYPE.waterMeterTypeId == strID)
                            {
                                dgList.CurrentCell = dgList.Rows[i].Cells["waterMeterTypeValue"];
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

        private void txtExtraCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //检测是否已经输入了小数点 
            bool IsContainsDot = ((TextBox)sender).Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            } 
        }

        private void dgTrapezoidPrice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgTrapezoidPrice.CurrentCell.ColumnIndex > 0)
            {
                TextBox tx = e.Control as TextBox;
                tx.KeyPress -= new KeyPressEventHandler(tx_KeyPress);
                tx.KeyPress -= new KeyPressEventHandler(txPrice_KeyPress);
                if (dgTrapezoidPrice.Columns[dgTrapezoidPrice.CurrentCell.ColumnIndex].Name != "trapezoidPriceS")
                {
                    // Remove an existing event-handler, if present, to avoid   
                    // adding multiple handlers when the editing control is reused. 
                    tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
                }
                else
                {
                    TextBox txPrice = e.Control as TextBox;
                    // Remove an existing event-handler, if present, to avoid   
                    // adding multiple handlers when the editing control is reused. 
                    txPrice.KeyPress += new KeyPressEventHandler(txPrice_KeyPress);
                }
            }
        }
        private void tx_KeyPress(object sender, KeyPressEventArgs e)  
        {  
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void txPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //检测是否已经输入了小数点 
            TextBox txt = (TextBox)sender;
            bool IsContainsDot = txt.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
        }

        private void 增加一行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgTrapezoidPrice.EndEdit();
            dgTrapezoidPrice.Rows.Add(1);
            if (dgTrapezoidPrice.Rows.Count == 1)
            {
                dgTrapezoidPrice.Rows[0].Cells["lowNumber"].Value = "0";
                dgTrapezoidPrice.Rows[0].Cells["lowNumber"].ReadOnly = true;
            }
            else
            {
                dgTrapezoidPrice.Rows[dgTrapezoidPrice.Rows.Count - 1].Cells["lowNumber"].Value = dgTrapezoidPrice.Rows[dgTrapezoidPrice.Rows.Count - 2].Cells["highNumber"].Value;
            }
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgTrapezoidPrice.CurrentRow!=null)
            dgTrapezoidPrice.Rows.Remove(dgTrapezoidPrice.CurrentRow);
        }


        private void dgTrapezoidPrice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Information.IsNumeric(dgTrapezoidPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
            {
                dgTrapezoidPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                //e.Cancel = true;
            }
            if (e.RowIndex < dgTrapezoidPrice.Rows.Count - 1)
                if (dgTrapezoidPrice.Columns[e.ColumnIndex].Name == "highNumber")
                    dgTrapezoidPrice.Rows[e.RowIndex + 1].Cells["lowNumber"].Value = dgTrapezoidPrice.Rows[e.RowIndex].Cells["highNumber"].Value;
        }

        private void dgTrapezoidPrice_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsTrapezoidPrice.Show();
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
