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
            GetCompanyName();
        }
        private void GetCompanyName()
        {
            DataTable dt = BLLBASE_DEPARTMENT.QueryDep(" AND departmentID='01'");
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
            if (txtName.Text.Trim() == "")
            {
                mes.Show("公司名称不能为空!");
                return;
            }
            MODELBASE_DEPARTMENT MODELBASE_DEPARTMENT = new MODELBASE_DEPARTMENT();
            MODELBASE_DEPARTMENT.DEPARTMENTID = "01";
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

    }
}
