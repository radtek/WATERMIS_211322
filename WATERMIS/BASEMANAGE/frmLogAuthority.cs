using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MODEL;
using BLL;
using BASEFUNCTION;

namespace BASEMANAGE
{
    public partial class frmLogAuthority : DockContentEx
    {
        public frmLogAuthority()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            tb2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb2, true, null);
            tb3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb3, true, null);
        }

        BLLloginGroup BLLloginGroup = new BLLloginGroup();
        BLLBASE_AUTHORITY BLLBASE_AUTHORITY = new BLLBASE_AUTHORITY();
        private void frmLogAuthority_Load(object sender, EventArgs e)
        {
            dgAuthority.AutoGenerateColumns = false;
            dgGroup.AutoGenerateColumns = false;
            BindGroup();
        }
        /// <summary>
        /// 绑定组
        /// </summary>
        private void BindGroup()
        {
            DataTable dt = BLLloginGroup.Query(" AND groupId<>'0001'");

            DataRow dr = dt.NewRow();
            dr["groupName"] = "";
            dr["groupId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);

            cmbGroup.DataSource = dt;
            cmbGroup.DisplayMember = "groupName";
            cmbGroup.ValueMember = "groupId";
        }

        private void toolUserSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strFilter = "";
                if (cmbGroup.SelectedValue != null&&cmbGroup.SelectedValue!=DBNull.Value)
                {
                    strFilter += " AND  groupId='" + cmbGroup.SelectedValue.ToString()+ "'";
                }
            strFilter += " AND groupId<>'0001' ";
            dt = BLLloginGroup.Query(strFilter);
            dgGroup.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                dgAuthority.DataSource = null;
            }
        }
        private void dgPerson_SelectionChanged(object sender, EventArgs e)
        {
            if (dgGroup.CurrentRow == null)
                return;
            if (dgGroup.CurrentRow.Cells["GROUPID"].Value == null)
                return;
            string strID = dgGroup.CurrentRow.Cells["GROUPID"].Value.ToString();
            dgAuthority.DataSource = BLLBASE_AUTHORITY.GetAllAuthority(strID);

            if(dgAuthority.Rows.Count>0)
            {
            DataTable dt = new DataTable();
            dt = BLLBASE_AUTHORITY.GetPersonAuthority(strID);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dgAuthority.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["MENUID"].ToString() == dgAuthority.Rows[j].Cells["MENUID"].Value.ToString() && dt.Rows[i]["GROUPID"].ToString() == dgAuthority.Rows[j].Cells["GROUPIDS"].Value.ToString())
                        {
                            ((DataGridViewCheckBoxCell)dgAuthority.Rows[j].Cells["VALUE"]).Value = true;
                        }
                    }
                }
            }
            }
        }
        Messages mes = new Messages();

        private void dgAuthority_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            try
            {
                if (e.ColumnIndex == 5)
                {
                    DataGridViewCheckBoxCell CHKBOX = (DataGridViewCheckBoxCell)dgAuthority.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    bool isChecked = Convert.ToBoolean(CHKBOX.EditedFormattedValue);
                    string strPersonID = dgAuthority.Rows[e.RowIndex].Cells["GROUPIDS"].Value.ToString();
                    string strMenuID = dgAuthority.Rows[e.RowIndex].Cells["MENUID"].Value.ToString();
                    //if (((DataGridViewCheckBoxCell)dgAuthority.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value.ToString() == "0")
                    if (!isChecked)
                    {
                        if (!BLLBASE_AUTHORITY.DelAuthority(strPersonID, strMenuID))
                        {
                            mes.Show("取消权限失败!请联系系统管理员!");
                            return;
                        }
                    }
                    else
                        if (!BLLBASE_AUTHORITY.InsertAuthority(strPersonID, strMenuID))
                        {
                            mes.Show("分配权限失败!请联系系统管理员!");
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                mes.GetErrorMes(ex);
            }
        }

        private void dgAuthority_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object obj = dgAuthority.Rows[e.RowIndex].Cells["MENUCLASS"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    if (obj.ToString() == "一级")
                        dgAuthority.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                    if (obj.ToString() == "二级")
                        dgAuthority.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
                }
            }
        }

        private void dgGroup_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
