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
    public partial class frmInvoiceFetch : DockContentEx
    {
        public frmInvoiceFetch()
        {
            InitializeComponent();
        }

        BLLINVOICEBATCH BLLINVOICEBATCH = new BLLINVOICEBATCH();
        BLLINVOICESTOCKS BLLINVOICESTOCKS = new BLLINVOICESTOCKS();
        BLLINVOICEFETCH BLLINVOICEFETCH = new BLLINVOICEFETCH();
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

            BindDEP();

            //如果是系统管理员组，则显示所有部门
            if (strGroupID == "0001")
            {
                cmbDEP.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbDEP.Enabled = true;

                cmbDEPS.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbDEPS.Enabled = true;
            }
            else
            {
                cmbDEP.DropDownStyle = ComboBoxStyle.Simple;
                cmbDEP.Text = strDepName;
                cmbDEP.Enabled = false;

                cmbDEPS.DropDownStyle = ComboBoxStyle.Simple;
                cmbDEPS.Text = strDepName;
                cmbDEPS.Enabled = false;
            }
            #endregion

            BindInvoiceBatch();
            toolSearch_Click(null,null);
        }

        /// <summary>
        /// 存储部门表
        /// </summary>
        DataTable dtDEP = new DataTable();

        /// <summary>
        /// 绑定部门
        /// </summary>
        private void BindDEP()
        {
            dtDEP = BLLBASE_DEPARTMENT.QueryDep("");
            cmbDEP.DataSource = dtDEP;
            cmbDEP.DisplayMember = "departmentName";
            cmbDEP.ValueMember = "departmentID";

            DataTable dt = dtDEP.Copy();
            cmbDEPS.DataSource = dt;
            cmbDEPS.DisplayMember = "departmentName";
            cmbDEPS.ValueMember = "departmentID";
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

        string strDEPFilter = "";
        /// <summary>
        /// 获取包含该部门的所有子部门
        /// </summary>
        /// <param name="strDEPID"></param>
        /// <returns></returns>
        private string GetChildDEP(string strDEPParentID)
        {
            if (strDEPFilter == "")
                strDEPFilter = "'" + strDEPParentID + "'";
            else
                strDEPFilter += ",'" + strDEPParentID + "'";
            DataTable dtDEPTemp = dtDEP.Copy();
            DataView dvDep = dtDEPTemp.DefaultView;
            dvDep.RowFilter = "parentId='" + strDEPParentID + "'";
            for (int i = 0; i < dvDep.Count; i++)
            {
                object objDepID = dvDep[i]["departmentID"];
                if (objDepID != null && objDepID != DBNull.Value)
                {
                    GetChildDEP(objDepID.ToString());
                }
            }
            //strDEPFilter="("+strDEPFilter+")";
            return strDEPFilter;
        }
        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilter = "";

            strDEPFilter = "";

            if (cmbDEPS.SelectedValue != DBNull.Value && cmbDEPS.SelectedValue != null)
            {
                strFilter += " AND INVOICEFETCHDEPID IN (" + GetChildDEP(cmbDEPS.SelectedValue.ToString()) + ")";
            }
            if (chkFetch.Checked)
            {
                strFilter += " AND INVOICEFETCHDATETIME BETWEEN '"+dtStartDate.Value.ToShortDateString()+" 00:00:00' AND '"+dtEndDate.Value.ToShortDateString()+" 23:59:59'";
            }

            if (cmbBatchSearch.SelectedValue != DBNull.Value && cmbBatchSearch.SelectedValue != null)
            {
                strFilter += " AND INVOICEFETCHBATCHID='" + cmbBatchSearch.SelectedValue.ToString() + "'";
            }
            DataTable dtList = BLLINVOICEFETCH.Query(strFilter);
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
                if (cmbBatchSearch.Items.Count <2)
                {
                    mes.Show("系统检测到发票批次为空,请先新增发票批次!");
                    //btBatch_Click(null,null);
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
                if (BLLINVOICEFETCH.Delete(txtID.Text))
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
                    dgList_RowEnter(null, new DataGridViewCellEventArgs(2, intRowIndex));
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
                if (cmbDEP.SelectedValue == DBNull.Value || cmbDEP.SelectedValue == null)
                {
                    mes.Show("请选择领用部门!");
                    cmbDEP.Focus();
                    return;
                }

                MODELINVOICEFETCH MODELINVOICEFETCH = new MODELINVOICEFETCH();
                MODELINVOICEFETCH.INVOICEFETCHBATCHID = Convert.ToInt32(cmbBatch.SelectedValue);
                MODELINVOICEFETCH.INVOICEFETCHERID = strLogID;
                MODELINVOICEFETCH.INVOICEFETCHERNAME = strLogName;
                MODELINVOICEFETCH.INVOICEFETCHDEPID = cmbDEP.SelectedValue.ToString();
                MODELINVOICEFETCH.INVOICEFETCHDEPNAME = cmbDEP.Text;
                MODELINVOICEFETCH.INVOICEFETCHDATETIME = mes.GetDatetimeNow();
                MODELINVOICEFETCH.INVOICEFETCHSTARTNO = txtStartNO.Text;
                MODELINVOICEFETCH.INVOICEFETCHENDNO = txtEndNO.Text;

                if (chkIsEnable.Checked)
                    MODELINVOICEFETCH.ISENABLE = "1";
                else
                    MODELINVOICEFETCH.ISENABLE = "0";

                MODELINVOICEFETCH.MEMO = txtMemo.Text;

                //查询发票批次中的发票号是否已存在
                DataTable dt = new DataTable();
                if (isADD)
                {
                    dt = BLLINVOICEFETCH.Query(" AND INVOICEFETCHBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                }
                else
                    dt = BLLINVOICEFETCH.Query(" AND INVOICEFETCHBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICEFETCHID<>" + txtID.Text);

                #region 验证是否在库存的发票中
                long llStartNO = Convert.ToInt64(MODELINVOICEFETCH.INVOICEFETCHSTARTNO);
                long llEndNO = Convert.ToInt64(MODELINVOICEFETCH.INVOICEFETCHENDNO);
                DataTable dtInvoiceStocks = BLLINVOICESTOCKS.Query(" AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");

                for (long i = llStartNO; i <= llEndNO; i++)
                {
                    bool isOK = false;
                    for (int j = 0; j < dtInvoiceStocks.Rows.Count; j++)
                    {
                        long llStocksStartNO = 0;
                        long llStocksEndNO = 0;
                        if (Information.IsNumeric(dtInvoiceStocks.Rows[j]["INVOICESTARTNO"]))
                        {
                            llStocksStartNO = Convert.ToInt64(dtInvoiceStocks.Rows[j]["INVOICESTARTNO"]);
                        }
                        if (Information.IsNumeric(dtInvoiceStocks.Rows[j]["INVOICESTARTNO"]))
                        {
                            llStocksEndNO = Convert.ToInt64(dtInvoiceStocks.Rows[j]["INVOICEENDNO"]);
                        }

                        if (i < llStocksStartNO || i > llStocksEndNO)
                        {
                            continue;
                        }
                        else
                        {
                            isOK = true;
                            break;
                        }
                    }
                        if (!isOK)
                        {
                            mes.Show("批次为'" + cmbBatch.Text + "'号码为'" + i.ToString().PadLeft(8, '0') + "'的发票号不在发票库存中!");
                            return;
                        }
                }
                #endregion
                #region 验证发票领取记录是否重复
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    long intStartNO = 0, intEndNO = 0;
                    object obj = dt.Rows[i]["INVOICEFETCHSTARTNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intStartNO = Convert.ToInt64(obj);
                    }
                    obj = dt.Rows[i]["INVOICEFETCHENDNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intEndNO = Convert.ToInt64(obj);
                    }

                    if (Convert.ToInt64(MODELINVOICEFETCH.INVOICEFETCHSTARTNO) >= intStartNO && Convert.ToInt64(MODELINVOICEFETCH.INVOICEFETCHSTARTNO) <= intEndNO)
                    {
                        mes.Show("批次为'" + cmbBatch.Text + "'的发票起始号码在领取记录中已经存在!");
                        txtStartNO.Focus();
                        return;
                    }

                    if (Convert.ToInt64(MODELINVOICEFETCH.INVOICEFETCHENDNO) >= intStartNO && Convert.ToInt64(MODELINVOICEFETCH.INVOICEFETCHENDNO) <= intEndNO)
                    {
                        mes.Show("批次为'" + cmbBatch.Text + "'的发票终止号码在领取记录中已经存在!");
                        txtStartNO.Focus();
                        return;
                    }
                }
                #endregion
                if (isADD)
                {
                    //新增发票记录
                    if (BLLINVOICEFETCH.Insert(MODELINVOICEFETCH))
                    {
                        toolSearch_Click(null, null);
                        if (dgList.Rows.Count > 0)
                        {
                            dgList.ClearSelection();
                            dgList.CurrentCell = dgList.Rows[dgList.Rows.Count - 1].Cells["INVOICEBATCHNAME"];
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
                    MODELINVOICEFETCH.INVOICEFETCHID = txtID.Text;
                    if (BLLINVOICEFETCH.Update(MODELINVOICEFETCH))
                    {
                        if (dgList.CurrentRow != null)
                        {
                            dgList.CurrentRow.Cells["INVOICEFETCHBATCHID"].Value = MODELINVOICEFETCH.INVOICEFETCHBATCHID;
                            dgList.CurrentRow.Cells["INVOICEBATCHNAME"].Value = cmbBatch.Text;
                            dgList.CurrentRow.Cells["INVOICEFETCHDEPID"].Value = cmbDEP.SelectedValue;
                            dgList.CurrentRow.Cells["INVOICEFETCHDEPNAME"].Value = cmbDEP.Text;
                            dgList.CurrentRow.Cells["INVOICEFETCHSTARTNO"].Value = MODELINVOICEFETCH.INVOICEFETCHSTARTNO;
                            dgList.CurrentRow.Cells["INVOICEFETCHENDNO"].Value = MODELINVOICEFETCH.INVOICEFETCHENDNO;
                            dgList.CurrentRow.Cells["MEMO"].Value = MODELINVOICEFETCH.MEMO;
                            if (MODELINVOICEFETCH.ISENABLE == "1")
                            {
                                dgList.CurrentRow.Cells["ISENABLES"].Value = "启用";
                                dgList.CurrentRow.Cells["ISENABLE"].Value = "1";
                            }
                            else
                            {
                                dgList.CurrentRow.Cells["ISENABLES"].Value = "未启用";
                                dgList.CurrentRow.Cells["ISENABLE"].Value = "0";
                            }
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

            object objID = dgList.Rows[e.RowIndex].Cells["INVOICEFETCHID"].Value;
            if (objID != null && objID != DBNull.Value)
            {
                txtID.Text = objID.ToString();
            }

            object obj = dgList.Rows[e.RowIndex].Cells["INVOICEFETCHSTARTNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtStartNO.Text = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["INVOICEFETCHENDNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtEndNO.Text = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["INVOICEFETCHBATCHID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbBatch.SelectedValue = obj;
            }

            obj = dgList.Rows[e.RowIndex].Cells["MEMO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtMemo.Text = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["INVOICEFETCHDEPID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                cmbDEP.SelectedValue = obj.ToString();
            }

            obj = dgList.Rows[e.RowIndex].Cells["ISENABLE"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                if (obj.ToString() == "1")
                    chkIsEnable.Checked = true;
                else
                    chkIsEnable.Checked = false;
            }
        }
    }
}
