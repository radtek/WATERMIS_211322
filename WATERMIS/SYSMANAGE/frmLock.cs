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
    public partial class frmLock : Form
    {
        public frmLock()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        public MenuStrip menuStrip = null;
        string strLogName = "";
        private void frmLock_Load(object sender, EventArgs e)
        {
            strLogName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            txtLogName.Text = strLogName;
            menuStrip.Enabled = false;
            txtLogPWD.Focus();
        }
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        Messages mes = new Messages();
        private void btLogin_Click(object sender, EventArgs e)
        {
            string strName;
            string strPWD;
            string strSQL;
            DataTable dt = new DataTable();
            if (txtLogName.Text.Trim() == "")
            {
                mes.Show("请输入用户名!");
                return;
            }
            else
                strName = txtLogName.Text.Trim();
            if (txtLogPWD.Text.Trim() == "")
            {
                mes.Show("请输入密码!");
                return;
            }
            else
                strPWD = txtLogPWD.Text.Trim();
            if (strName != strLogName)
            {
                mes.Show("该用户名不是当前已登录的用户名，请重新输入!");
                txtLogName.Focus();
                return;
            }
            //strPWD = DBUtility.DESEncrypt.Encrypt(strPWD);
            //strPWD = DBUtility.DESEncrypt.Encrypt(strPWD);
            strSQL = " AND LOGINNAME='" + strName + "' AND LOGINPASSWORD='" + strPWD + "'";
            btLogin.Enabled = false;
            try
            {
                    dt = BLLBASE_LOGIN.QueryUser(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        menuStrip.Enabled = true;
                        this.Close();
                    }
                    else
                    {
                        mes.Show("用户不存在或密码错误!");
                        btLogin.Enabled = true;
                        return;
                    }
            }
            catch (Exception ex)
            {
                mes.Show(ex.ToString());
            }
        }

        private void txtLogName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLogPWD.Focus();
            }
        }

        private void txtLogPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btLogin_Click(null, null);
            }
        }
    }
}
