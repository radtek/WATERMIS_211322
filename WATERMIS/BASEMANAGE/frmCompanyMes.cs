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

namespace BASEMANAGE
{
    public partial class frmCompanyMes : DockContentEx
    {
        public frmCompanyMes()
        {
            InitializeComponent();
        }

        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENT = new BLLBASE_DEPARTMENT();
        private void frmCompanyMes_Load(object sender, EventArgs e)
        {

        }
        private void GetCompanyName(string strID)
        {
            DataTable dt = BLLBASE_DEPARTMENT.QueryDep(" AND departmentID='" + strID + "'");
            if (dt.Rows.Count > 0)
            {
                object obj = dt.Rows[0]["departmentName"];
                if (obj != null && obj != DBNull.Value)
                    txtName.Text = obj.ToString();
                else
                    txtName.Clear();

                obj = dt.Rows[0]["FPTaxNO"];
                if (obj != null && obj != DBNull.Value)
                    txtTaxNO.Text = obj.ToString();
                else
                    txtTaxNO.Clear();

                obj = dt.Rows[0]["FPAddressAndTel"];
                if (obj != null && obj != DBNull.Value)
                    txtAddressAndTel.Text = obj.ToString();
                else
                    txtAddressAndTel.Clear();

                obj = dt.Rows[0]["FPBankNameAndAccountNO"];
                if (obj != null && obj != DBNull.Value)
                    txtBankNameAndAccountNO.Text = obj.ToString();
                else
                    txtBankNameAndAccountNO.Clear();

                obj = dt.Rows[0]["Payee"];
                if (obj != null && obj != DBNull.Value)
                    txtPayee.Text = obj.ToString();
                else
                    txtPayee.Clear();

                obj = dt.Rows[0]["Checker"];
                if (obj != null && obj != DBNull.Value)
                    txtChecker.Text = obj.ToString();
                else
                    txtChecker.Clear();
            }
            else
            {
                txtName.Clear();
                txtTaxNO.Clear();
                txtAddressAndTel.Clear();
                txtBankNameAndAccountNO.Clear();
            }
        }

        PinYinConvert PinYinConvert = new PinYinConvert();
        Messages mes = new Messages();
        private void btSetUp_Click(object sender, EventArgs e)
        {
            string strCompany="";
            if (rb01.Checked)
                strCompany = "01";
            else if(rb010003.Checked)
                strCompany = "010003";
            if (strCompany == "")
            {
                mes.Show("请选择公司后操作!");
                return;
            }
            if (txtName.Text.Trim() == "")
            {
                mes.Show("公司名称不能为空!");
                return;
            }

            MODELBASE_DEPARTMENT MODELBASE_DEPARTMENT = new MODELBASE_DEPARTMENT();
            MODELBASE_DEPARTMENT.DEPARTMENTID = strCompany;
            MODELBASE_DEPARTMENT.DEPARTMENTNAME = txtName.Text.Trim();
            MODELBASE_DEPARTMENT.PARENTID = "0";
            MODELBASE_DEPARTMENT.SIMPLECODE = PinYinConvert.GetHeadOfChs(MODELBASE_DEPARTMENT.DEPARTMENTNAME);
            MODELBASE_DEPARTMENT.FPAddressAndTel = txtAddressAndTel.Text;
            MODELBASE_DEPARTMENT.FPBankNameAndAccountNO = txtBankNameAndAccountNO.Text;
            MODELBASE_DEPARTMENT.FPTaxNO = txtTaxNO.Text;
            MODELBASE_DEPARTMENT.Payee = txtPayee.Text;
            MODELBASE_DEPARTMENT.Checker = txtChecker.Text;

            if (!BLLBASE_DEPARTMENT.UpdateDEP(MODELBASE_DEPARTMENT))
            {
                mes.Show("更新数据库失败，请重新打开窗体设置!");
                return;
            }
            else
                mes.Show("设置成功!");
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb01_CheckedChanged(object sender, EventArgs e)
        {
            if (rb01.Checked)
            {
                GetCompanyName("01");
            }
            else
                GetCompanyName("010003");
        }

    }
}
