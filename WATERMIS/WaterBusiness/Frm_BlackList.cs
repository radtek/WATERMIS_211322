using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;

namespace WaterBusiness
{
    public partial class Frm_BlackList : Form
    {
        public Frm_BlackList()
        {
            InitializeComponent();
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                Frm_BlackList_Cancel frm = new Frm_BlackList_Cancel();
                frm.BlackID = dgList.CurrentRow.Cells["BlackID"].Value.ToString();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ShowData();
                }
            }
        }

        private void Frm_BlackList_Load(object sender, EventArgs e)
        {
            BindLoginid();

            ShowData();
        }

        private void ShowData()
        {
            string sqlstr = @"SELECT * FROM User_BlackList WHERE STATE =1";

            if (!string.IsNullOrEmpty(SearchKeys.Text))
            {
                sqlstr += string.Format(" AND (waterUserName LIKE '%{0}%' OR waterUserAddress LIKE '%{0}%' OR waterPhone LIKE '%{0}%')", SearchKeys.Text.Trim());
            }
            if (!string.IsNullOrEmpty(loginId.SelectedValue.ToString()))
            {
                sqlstr += " AND loginId='" + loginId.SelectedValue.ToString() + "'";
            }
           
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "waterUserId", "户号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "waterUserAddress", "地址" },
                                                           { "waterPhone", "联系电话" },
                                                           { "AddDate", "添加时间" }
            };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void BindLoginid()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("base_login");
            ControlBindHelper.BindComboBoxData(this.loginId, dt, "userName", "loginId",true);
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
