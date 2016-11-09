using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using MODEL;
using BASEFUNCTION;

namespace SYSMANAGE
{
    public partial class frmUserManage:DockContentEx
    {
        public frmUserManage()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENT = new BLLBASE_DEPARTMENT();
        BLLBASE_POST BLLBASE_POST = new BLLBASE_POST();
        BLLloginGroup BLLloginGroup = new BLLloginGroup();
        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();
        /// <summary>
        /// 用户ID
        /// </summary>
        private string strLoginID = "";
        /// <summary>
        /// 判断是修改还是添加
        /// </summary>
        private bool isAdd = false;
        /// <summary>
        /// 用户列表
        /// </summary>
        DataTable dtList = new DataTable();
        private void frmUserManage_Load(object sender, EventArgs e)
        {
            dgUser.AutoGenerateColumns = false;
            BindDEP(cmbDEP);
            BindDEP(cmbDEPS);
            BindPost();
            BindGroup(cmbGroupS);
            BindGroup(cmbGroup);
            cmbState.SelectedIndex = 0;
            cmbIsReader.SelectedIndex = 0;
            cmbIsCharger.SelectedIndex = 0;
            cmbIsCashierS.SelectedIndex = 0;

            DisEnableControls(grpDetail);
            strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            //string strPostID = AppDomain.CurrentDomain.GetData("POSTID").ToString();
            //if (strPostID != "3")
            //    toolResetPWD.Enabled = false;
            toolSearch_Click(null,null);
        }

        /// <summary>
        /// 绑定职务
        /// </summary>
        private void BindPost()
        {
            DataTable dt = BLLBASE_POST.QueryPost("");
            if (dt.Rows.Count > 0)
            {
                cmbPost.DisplayMember = "POSTNAME";
                cmbPost.ValueMember = "POSTID";
                cmbPost.DataSource = dt;
            }
        }
        /// <summary>
        /// 绑定分组
        /// </summary>
        private void BindGroup(ComboBox cmb)
        {
            DataTable dt = BLLloginGroup.Query("");
            if (cmb.Name == "cmbGroupS")
            {
                DataRow dr = dt.NewRow();
                dr["groupId"] = DBNull.Value;
                dr["groupName"] = "全部";
                dt.Rows.InsertAt(dr, 0);
            }
            if (dt.Rows.Count > 0)
            {
                cmb.DisplayMember = "groupName";
                cmb.ValueMember = "groupId";
                cmb.DataSource = dt;
            }
        }
        /// <summary>
        /// 将部门数据绑定到部门列表中
        /// </summary>
        /// <param name="cmb"></param>
        private void BindDEP(ComboBox cmb)
        {
            DataTable dt=BLLBASE_DEPARTMENT.QueryDep("");
            if (dt.Rows.Count > 0)
            {
                cmb.DisplayMember = "DEPARTMENTNAME";
                cmb.ValueMember = "DEPARTMENTID";
                cmb.DataSource = dt;
            }
        }
        /// <summary>
        /// 使能控件
        /// </summary>
        /// <param name="ConParent"></param>
        private void EnableControls(Control ConParent)
        {
            foreach(Control ConChild in ConParent.Controls)
            {
                if (ConChild is TextBox)
                {
                    ((TextBox)ConChild).ReadOnly = false;
                }
                if (ConChild is ComboBox)
                {
                    ((ComboBox)ConChild).Visible = true;
                }
                if (ConChild is CheckBox)
                {
                    ((CheckBox)ConChild).Enabled = true;
                }
            }
            txtDEP.Visible = false;
            txtPost.Visible = false;
            txtState.Visible = false;
            txtGroup.Visible = false;
        }
        /// <summary>
        /// 禁能控件
        /// </summary>
        /// <param name="ConParent"></param>
        private void DisEnableControls(Control ConParent)
        {
            foreach (Control ConChild in ConParent.Controls)
            {
                if (ConChild is TextBox)
                {
                    ((TextBox)ConChild).ReadOnly = true;
                    ((TextBox)ConChild).BackColor = SystemColors.Window;
                }
                if (ConChild is ComboBox)
                {
                    ((ComboBox)ConChild).Visible = false;
                }
                if (ConChild is CheckBox)
                {
                    ((CheckBox)ConChild).Enabled = false;
                }
            }
            txtDEP.Visible = true;
            txtPost.Visible = true;
            txtState.Visible = true;
            txtGroup.Visible = true;
        }
        private void dgUser_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
            string str = "";
            if(cmbDEPS.SelectedValue!=DBNull.Value&&cmbDEPS.SelectedValue!=null)
                if (cmbDEPS.SelectedValue.ToString() != "01")
                {
                    string strList = "0";
                    strList = GetDepList(strList, cmbDEPS.SelectedValue.ToString());
                }
                //strList = GetDepList(strList, cmbDEPS.SelectedValue.ToString());
                //str += " AND  DEPARTMENTID IN (" + strList + ")";
            if (txtNameS.Text.Trim() != "")
                str += " AND USERNAME LIKE '%" + txtNameS.Text.Trim() + "%'";
            if (cmbGroupS.SelectedValue != DBNull.Value && cmbGroupS.SelectedValue!=null)
                str += " AND groupID LIKE '" + cmbGroupS.SelectedValue.ToString() + "%'";

            if (cmbIsReader.SelectedIndex > 0)
                str += " AND isMeterReader='" + (cmbIsReader.SelectedIndex - 1).ToString() + "'";

            if (cmbIsCharger.SelectedIndex > 0)
                str += " AND isCharger='" + (cmbIsCharger.SelectedIndex - 1).ToString() + "'";

            if (cmbIsCashierS.SelectedIndex > 0)
                str += " AND IsCashier='" + (cmbIsCashierS.SelectedIndex - 1).ToString() + "'";

            str += " ORDER BY loginId";
            dtList = BLLBASE_LOGIN.QueryUser(str);
            dgUser.DataSource = dtList;
        }

        /// <summary>
        /// 递归获取子部门ID
        /// </summary>
        /// <param name="strList">返回的部门ID字符串，可以直接用在数据库查询语句中</param>
        /// <param name="strDepID">第一级父部门ID</param>
        /// <returns></returns>
        private string GetDepList(string strList, string strDepID)
        {
            DataTable dt = new DataTable();
            string strDepChildID;
            strList += "," + strDepID;
            dt = BLLBASE_DEPARTMENT.QueryDep(" AND PARENTID='" + strDepID + "'");
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strDepChildID = dt.Rows[i]["DEPARTMENTID"].ToString();
                    strList = GetDepList(strList, strDepChildID);
                }
            }
            return strList;
        }
        private void dgUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgUser.CurrentRow != null)
            {
                if(dgUser.CurrentRow.Cells["LOGINID"].Value!=null&&dgUser.CurrentRow.Cells["LOGINID"].Value!=DBNull.Value)
                {
                    string strUserID = dgUser.CurrentRow.Cells["LOGINID"].Value.ToString();
                    string strFilter = " AND LOGINID='" + strUserID + "'";
                    DataTable dt = BLLBASE_LOGIN.QueryUser(strFilter);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["workNO"] != null && dt.Rows[0]["workNO"] != DBNull.Value)
                            txtWorkNO.Text = dt.Rows[0]["workNO"].ToString();
                        else
                            txtWorkNO.Clear();
                        if (dt.Rows[0]["LOGINNAME"] != null && dt.Rows[0]["LOGINNAME"] != DBNull.Value)
                            txtLogName.Text = dt.Rows[0]["LOGINNAME"].ToString();
                        else
                            txtLogName.Clear();
                        if (dt.Rows[0]["USERNAME"] != null && dt.Rows[0]["USERNAME"] != DBNull.Value)
                            txtName.Text = dt.Rows[0]["USERNAME"].ToString();
                        else
                            txtName.Clear();
                        if (dt.Rows[0]["POSTID"] != null && dt.Rows[0]["POSTID"] != DBNull.Value)
                            cmbPost.SelectedValue = dt.Rows[0]["POSTID"].ToString();
                        else
                            cmbPost.SelectedValue = DBNull.Value;

                        if (dt.Rows[0]["DEPARTMENTID"] != null && dt.Rows[0]["DEPARTMENTID"] != DBNull.Value)
                            cmbDEP.SelectedValue = dt.Rows[0]["DEPARTMENTID"].ToString();
                        else
                            cmbDEP.SelectedValue = DBNull.Value;

                        if (dt.Rows[0]["groupID"] != null && dt.Rows[0]["groupID"] != DBNull.Value)
                            cmbGroup.SelectedValue = dt.Rows[0]["groupID"].ToString();
                        else
                            cmbGroup.SelectedValue = DBNull.Value;

                        if (dt.Rows[0]["groupName"] != null && dt.Rows[0]["groupName"] != DBNull.Value)
                            txtGroup.Text = dt.Rows[0]["groupName"].ToString();
                        else
                            txtGroup.Clear();

                        if (dt.Rows[0]["MEMO"] != null && dt.Rows[0]["MEMO"] != DBNull.Value)
                            txtMemo.Text = dt.Rows[0]["MEMO"].ToString();
                        else
                            txtMemo.Clear();
                        if (dt.Rows[0]["DEPARTMENTNAME"] != null && dt.Rows[0]["DEPARTMENTNAME"] != DBNull.Value)
                            txtDEP.Text = dt.Rows[0]["DEPARTMENTNAME"].ToString();
                        else
                            txtDEP.Clear();

                        if (dt.Rows[0]["POSTNAME"] != null && dt.Rows[0]["POSTNAME"] != DBNull.Value)
                            txtPost.Text = dt.Rows[0]["POSTNAME"].ToString();
                        else
                            txtPost.Clear();
                        if (dt.Rows[0]["TELEPHONENO"] != null && dt.Rows[0]["TELEPHONENO"] != DBNull.Value)
                            txtTel.Text = dt.Rows[0]["TELEPHONENO"].ToString();
                        else
                            txtTel.Clear();
                        if (dt.Rows[0]["isMeterReader"] != null && dt.Rows[0]["isMeterReader"] != DBNull.Value)
                        {
                            if (dt.Rows[0]["isMeterReader"].ToString() == "0")
                                chkIsMeterReader.Checked=false;
                            else
                                chkIsMeterReader.Checked=true;
                        }
                        else
                            chkIsMeterReader.Checked = false;

                        if (dt.Rows[0]["isCharger"] != null && dt.Rows[0]["isCharger"] != DBNull.Value)
                        {
                            if (dt.Rows[0]["isCharger"].ToString() == "0")
                                chkIsCharger.Checked = false;
                            else
                                chkIsCharger.Checked = true;
                        }
                        else
                            chkIsCharger.Checked = false;

                        if (dt.Rows[0]["IsCashier"] != null && dt.Rows[0]["IsCashier"] != DBNull.Value)
                        {
                            if (dt.Rows[0]["IsCashier"].ToString() == "0")
                                chkIsCashierS.Checked = false;
                            else
                                chkIsCashierS.Checked = true;
                        }
                        else
                            chkIsCashierS.Checked = false;

                        if (dt.Rows[0]["userstateS"] != null && dt.Rows[0]["userstateS"] != DBNull.Value)
                        {
                            txtState.Text = dt.Rows[0]["userstateS"].ToString();
                            if (dt.Rows[0]["userstateS"].ToString() == "停用")
                                cmbState.SelectedIndex = 1;
                            else
                                cmbState.SelectedIndex = 0;
                        }
                        else
                        {
                            txtState.Clear();
                            cmbState.SelectedIndex = 0;
                        }
                        txtUserID.Text = strUserID;
                    }
                }
            }
        }

        private void toolModify_Click(object sender, EventArgs e)
        {
            if (toolModify.Text == "修改")
            {
                if (txtUserID.Text.Trim() == "")
                    return;
                if (txtUserID.Text.Trim() == "0000")
                {
                    mes.Show("系统管理员无法修改和删除!");
                    return;
                }
                isAdd = false;
                toolSave.Enabled = true;
                toolSearch.Enabled = false;
                //toolModify.Enabled = false;
                toolDel.Enabled = false;
                toolAdd.Enabled = false;
                toolResetPWD.Enabled = false;
                toolModify.Text = "取消";

                dgUser.Enabled = false;

                EnableControls(grpDetail);
            }
            else
            {
                toolSave.Enabled = false;
                toolSearch.Enabled = true;
                //toolModify.Enabled = true;
                toolDel.Enabled = true;
                toolAdd.Enabled = true;
                toolResetPWD.Enabled = true;
                toolModify.Text = "修改";

                dgUser.Enabled = true;

                DisEnableControls(grpDetail);
            }
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (toolAdd.Text == "添加")
            {
                if (strLoginID == "")
                {
                    mes.Show("获取用户ID失败,请重新登录系统!");
                    return;
                }
                isAdd = true;
                toolSave.Enabled = true;
                toolSearch.Enabled = false;
                toolModify.Enabled = false;
                toolDel.Enabled = false;
                toolResetPWD.Enabled = false;
                //toolAdd.Enabled = false;
                toolAdd.Text = "取消";
                EnableControls(grpDetail);
                txtUserID.Clear();
                txtPost.Clear();
                txtLogName.Clear();
                txtName.Clear();
                txtDEP.Clear();

                dgUser.Enabled = false;
            }
            else
            {
                toolSave.Enabled = false;
                toolSearch.Enabled = true;
                toolModify.Enabled = true;
                toolDel.Enabled = true;
                toolResetPWD.Enabled = true;
                //toolAdd.Enabled = true;
                toolAdd.Text = "添加";

                DisEnableControls(grpDetail);

                dgUser.Enabled = true;
                dgUser_SelectionChanged(null,null);
            }
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (dgUser.CurrentRow != null)
            {
                if (dgUser.CurrentRow.Cells["LOGINID"].Value != null && dgUser.CurrentRow.Cells["LOGINID"].Value != DBNull.Value)
                {
                    string strUserID = dgUser.CurrentRow.Cells["LOGINID"].Value.ToString();
                    if (strUserID == "0000")
                    {
                        mes.Show("系统管理员无法修改和删除!");
                        return;
                    }
                    string strName = "";
                    if (dgUser.CurrentRow.Cells["USERNAME"].Value != null && dgUser.CurrentRow.Cells["USERNAME"].Value != DBNull.Value)
                        strName = dgUser.CurrentRow.Cells["USERNAME"].Value.ToString();
                    if (mes.ShowQ("确定要删除用户 " + strName + " 的信息吗?") == DialogResult.OK)
                    {
                        if (BLLBASE_LOGIN.DeleteUser(strUserID))
                        {
                            for (int i = 0; i < dtList.Rows.Count; i++)
                            {
                                if (dtList.Rows[i]["LOGINID"].ToString() == strUserID)
                                    dtList.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                mes.Show("请输入用户姓名!");
                txtName.Focus();
                return;
            }
            if (txtLogName.Text.Trim() == "")
            {
                mes.Show("请输入登录名!");
                txtLogName.Focus();
                return;
            }
            if (cmbDEP.SelectedValue == DBNull.Value||cmbDEP.SelectedValue ==null)
            {
                mes.Show("请选择所属部门!");
                cmbDEP.Focus();
                return;
            }
            if (cmbPost.SelectedValue == DBNull.Value||cmbPost.SelectedValue ==null)
            {
                mes.Show("请选择职务!");
                cmbPost.Focus();
                return;
            }
            if (cmbGroup.SelectedValue == DBNull.Value || cmbGroup.SelectedValue == null)
            {
                mes.Show("请选择所属分组!");
                cmbGroup.Focus();
                return;
            }
            if (cmbState.SelectedIndex<0)
            {
                mes.Show("请选择用户状态!");
                cmbState.Focus();
                return;
            }

            MODELBASE_LOGIN MODELBASE_LOGIN = new MODELBASE_LOGIN();
            try
            {
                MODELBASE_LOGIN.LOGINNAME = txtLogName.Text.Trim();
                MODELBASE_LOGIN.workNO = txtWorkNO.Text.Trim();
                MODELBASE_LOGIN.USERNAME = txtName.Text.Trim();
                MODELBASE_LOGIN.DEPARTMENTID = cmbDEP.SelectedValue.ToString();
                MODELBASE_LOGIN.POSTID = cmbPost.SelectedValue.ToString(); ;
                MODELBASE_LOGIN.groupID = cmbGroup.SelectedValue.ToString();

                //用户状态选择第一个（正常）为“1”，否则为“0”
                if(cmbState.SelectedIndex==0)
                MODELBASE_LOGIN.userstate ="1";
                else
                    MODELBASE_LOGIN.userstate = "0";

                MODELBASE_LOGIN.TELEPHONENO = txtTel.Text.Trim();
                if(chkIsMeterReader.Checked)
                MODELBASE_LOGIN.isMeterReader ="1";
                else
                    MODELBASE_LOGIN.isMeterReader = "0";

                if (chkIsCharger.Checked)
                    MODELBASE_LOGIN.isCharger = "1";
                else
                    MODELBASE_LOGIN.isCharger = "0";

                if (chkIsCashierS.Checked)
                    MODELBASE_LOGIN.IsCashier = "1";
                else
                    MODELBASE_LOGIN.IsCashier = "0";

                MODELBASE_LOGIN.MEMO = txtMemo.Text;

                if (isAdd)
                {
                    MODELBASE_LOGIN.LOGINID = GETTABLEID.GetTableID(strLoginID, "BASE_LOGIN");
                    MODELBASE_LOGIN.LOGINPASSWORD = "123456";
                    MODELBASE_LOGIN.generateDateTime = mes.GetDatetimeNow();
                    if (BLLBASE_LOGIN.InsertBASE_LOGIN(MODELBASE_LOGIN))
                    {

                        toolSave.Enabled = false;
                        toolSearch.Enabled = true;
                        toolModify.Enabled = true;
                        toolDel.Enabled = true;
                        toolResetPWD.Enabled = true;
                        //toolAdd.Enabled = true;true
                        toolAdd.Text = "添加";
                        DisEnableControls(grpDetail);
                        toolSearch_Click(null,null);
                        dgUser.ClearSelection();
                        for (int i = 0; i < dgUser.Rows.Count; i++)
                        {
                            if (dgUser.Rows[i].Cells["LOGINID"].Value != null && dgUser.CurrentRow.Cells["LOGINID"].Value != DBNull.Value)
                            {
                                string strID = dgUser.Rows[i].Cells["LOGINID"].Value.ToString() ;
                                if (MODELBASE_LOGIN.LOGINID == strID)
                                {
                                    dgUser.CurrentCell = dgUser.Rows[i].Cells["USERNAME"];
                                    dgUser_SelectionChanged(null, null);
                                }
                            }
                        }
                        //mes.Show("添加成功!");
                        dgUser.Enabled = true ;
                            return;
                    }
                }
                else
                {
                    MODELBASE_LOGIN.LOGINID = txtUserID.Text.Trim();
                    if (BLLBASE_LOGIN.UpdateUser(MODELBASE_LOGIN))
                    {
                        toolSave.Enabled = false;
                        toolSearch.Enabled = true;
                        //toolModify.Enabled = true;
                        toolDel.Enabled = true;
                        toolAdd.Enabled = true;
                        toolResetPWD.Enabled = true;
                        toolModify.Text = "修改";
                        DisEnableControls(grpDetail);
                        toolSearch_Click(null, null);
                        dgUser.ClearSelection();
                        for (int i = 0; i < dgUser.Rows.Count; i++)
                        {
                            if (dgUser.Rows[i].Cells["LOGINID"].Value != null && dgUser.CurrentRow.Cells["LOGINID"].Value != DBNull.Value)
                            {
                                string strID = dgUser.Rows[i].Cells["LOGINID"].Value.ToString();
                                if (MODELBASE_LOGIN.LOGINID == strID)
                                {
                                    dgUser.CurrentCell = dgUser.Rows[i].Cells["USERNAME"];
                                    dgUser_SelectionChanged(null, null);
                                }
                            }
                        }
                        //mes.Show("修改成功!");
                        dgUser.Enabled = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.ToString());
            }
        }

        private void toolResetPWD_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Trim() != "")
            {
                string strID = txtUserID.Text.Trim();
                string strName = txtName.Text.Trim();
                if (mes.ShowQ("确定要重置用户 " + strName+" 的密码吗?") == DialogResult.OK)
                if (BLLBASE_LOGIN.UpdateUserPWD(strID, "123456"))
                {
                    mes.Show("密码重置为 123456 !");
                }
            }
        }
    }
}
