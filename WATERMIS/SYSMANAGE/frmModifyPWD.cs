using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using MODEL;
using BLL;


namespace SYSMANAGE
{
    public partial class frmModifyPWD : Form
    {
        public frmModifyPWD()
        {
            InitializeComponent();
        }

        Messages mes = new Messages();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        private void btOK_Click(object sender, EventArgs e)
        {
            if (txtOldPWD.Text.Trim() == "")
            {
                mes.Show("请输入原密码!");
                txtOldPWD.Focus();
                return;
            }
            if (txtPWD.Text.Trim() == "")
            {
                mes.Show("请输入新密码!");
                txtOldPWD.Focus();
                return;
            }
            if (txtPWD.Text != txtConfigPWD.Text)
            {
                mes.Show("新密码和确定密码不一致,请重新输入!");
                txtConfigPWD.Focus();
                return;
            }
            string strPWD = txtOldPWD.Text;
            //strPWD = DBUtility.DESEncrypt.Encrypt(strPWD);
            string strFliter = " AND LOGINID='" + AppDomain.CurrentDomain.GetData("LOGINID").ToString() + "' AND Password='" + strPWD + "'";
            DataTable dt = BLLBASE_LOGIN.QueryUser(strFliter);
            if (dt.Rows.Count > 0)
            {
                //strPWD = DBUtility.DESEncrypt.Encrypt(txtPWD.Text);
                strPWD = txtPWD.Text;
                MODELBASE_LOGIN MODELBASE_LOGIN = new MODELBASE_LOGIN();
                MODELBASE_LOGIN.LOGINID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                MODELBASE_LOGIN.Password = strPWD;
                if (BLLBASE_LOGIN.UpdateUserPWD(MODELBASE_LOGIN.LOGINID, MODELBASE_LOGIN.Password))
                {
                    mes.Show("密码修改成功!");
                    return;
                }
            }
            else
            {
                mes.Show("原密码不正确,请重新输入!");
                txtOldPWD.Focus();
                return;
            }
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
