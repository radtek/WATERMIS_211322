using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BASEFUNCTION
{
    public partial class ucPageSetUp : UserControl
    {
        public ucPageSetUp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 总页数
        /// </summary>
        int intCount = 1;

        int intCountPerPage = 500;

        /// <summary>
        /// 需要分页的datagridview
        /// </summary>
        DataGridView dgParent = null;

        /// <summary>
        /// 数据库数据
        /// </summary>
        DataTable dtBind = null;

        /// <summary>
        /// 数据库数据中最后一行的统计行
        /// </summary>
        DataTable dtLastRow =null;

        /// <summary>
        /// 初始化自定义控件,500行一页
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="dtParent"></param>
        public void InitialUC(DataGridView dg,DataTable dtParent,DataTable drLast)
        {
            dgParent = dg;
            dtBind = dtParent;
            this.dtLastRow = drLast;

            intCount = dtBind.Rows.Count / intCountPerPage + 1;
            if (intCount <= 1)
            {
                btFirst.Enabled = false;
                btEndPage.Enabled = false;
                btLastPage.Enabled = false;
                btNextPage.Enabled = false;   
            }
            else
            {
                btFirst.Enabled = false;
                btEndPage.Enabled = true;
                btLastPage.Enabled = false;
                btNextPage.Enabled = true;               
            }
            this.txtPageNO.Text = "1";
            this.labSumPage.Text = "/" + intCount;
            txtPageNO_TextChanged(null, null);
        }
        private void ucPageSetUp_Load(object sender, EventArgs e)
        {

        }
        //18204212005耿

        private void txtPageNO_TextChanged(object sender, EventArgs e)
        {
            if (Information.IsNumeric(txtPageNO.Text))
            {
                if (Convert.ToInt32(txtPageNO.Text) < 1)
                {
                    txtPageNO.Text = "1";
                }
                else if (Convert.ToInt32(txtPageNO.Text) > intCount)
                {
                    txtPageNO.Text = intCount.ToString();
                }

                DataTable dtNew = dtBind.Clone();

                //计算终止的行索引
                int intEndRow=Convert.ToInt32(txtPageNO.Text)*intCountPerPage-1;
                if(intEndRow>dtBind.Rows.Count-1)
                    intEndRow = dtBind.Rows.Count-1;

                //计算起始的行索引
                int intStartRow=(Convert.ToInt32(txtPageNO.Text)-1)*intCountPerPage;

                for (; intStartRow<=intEndRow;intStartRow++)
                {
                    dtNew.ImportRow(dtBind.Rows[intStartRow]);
                }

                if (dtLastRow != null)
                {
                    dtNew.ImportRow(dtLastRow.Rows[0]);
                }
                dgParent.DataSource = dtNew;

                    if (Convert.ToInt32(txtPageNO.Text) == 1)
                    {
                        btFirst.Enabled = false;
                        btLastPage.Enabled = false;
                        if (intCount > 1)
                        {
                            btNextPage.Enabled = true;
                            btEndPage.Enabled = true;
                        }
                    }
                    else if (Convert.ToInt32(txtPageNO.Text) == intCount)
                    {
                        btFirst.Enabled = true;
                        btLastPage.Enabled = true;
                        if (intCount > 1)
                        {
                            btNextPage.Enabled = false;
                            btEndPage.Enabled = false;
                        }
                    }
                    else
                    {
                        btFirst.Enabled = true;
                        btEndPage.Enabled = true;
                        btLastPage.Enabled = true;
                        btNextPage.Enabled = true;
                    }
            }
            else
                txtPageNO.Text = "1";
        }  

        private void btFirst_Click(object sender, EventArgs e)
        {
            txtPageNO.Text = "1";
        }
        private void btEndPage_Click(object sender, EventArgs e)
        {
            txtPageNO.Text = intCount.ToString();
        }  

        private void btLastPage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtPageNO.Text) < 2)
            {
                btLastPage.Enabled = false;
            }
            else
                txtPageNO.Text = (Convert.ToInt32(txtPageNO.Text) - 1).ToString();
        } 

        private void btNextPage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtPageNO.Text) >=intCount)
            {
                btNextPage.Enabled = false;
            }
            else
                txtPageNO.Text = (Convert.ToInt32(txtPageNO.Text) + 1).ToString();
        }

        private void txtPageNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)22)
            {
                e.Handled = true;
            }
        }

        private void txtPageNO_MouseClick(object sender, MouseEventArgs e)
        {
            txtPageNO.SelectAll();
        }  
    }
}
