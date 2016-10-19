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

namespace WATERUSERMETERMANAGE
{
    public partial class frmWaterUserFPMes : Form
    {
        public frmWaterUserFPMes()
        {
            InitializeComponent();
        }

        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (txtWaterUserNOSearch.Text.Trim() == "")
            {
                mes.Show("用户号不能为空!");
                return;
            }
            //string strWaterUserNO = txtWaterUserNOSearch.Text.PadLeft(8,'0');
            DataTable dtWaterUser = BLLwaterUser.QueryUser(" AND waterUserNO LIKE '%" + txtWaterUserNOSearch.Text + "%'");
            if (dtWaterUser.Rows.Count > 0)
            {
                object objMes = dtWaterUser.Rows[0]["waterUserName"];
                if (objMes != null && objMes != DBNull.Value)
                {
                    txtName.Text = objMes.ToString();
                }
                else
                    txtName.Clear();
                objMes = dtWaterUser.Rows[0]["waterUserNO"];
                if (objMes != null && objMes != DBNull.Value)
                {
                    txtWaterUserNO.Text = objMes.ToString();
                }
                else
                    txtWaterUserNO.Clear();
                objMes = dtWaterUser.Rows[0]["FPTaxNO"];
                if (objMes != null && objMes != DBNull.Value)
                {
                    txtTaxNO.Text = objMes.ToString();
                }
                else
                    txtTaxNO.Clear();
                objMes = dtWaterUser.Rows[0]["waterUserAddress"];
                if (objMes != null && objMes != DBNull.Value)
                {
                    txtAddress.Text = objMes.ToString();
                }
                else
                    txtAddress.Clear();
                objMes = dtWaterUser.Rows[0]["waterPhone"];
                if (objMes != null && objMes != DBNull.Value)
                {
                    txtTel.Text = objMes.ToString();
                }
                else
                    txtTel.Clear();
                objMes = dtWaterUser.Rows[0]["FPBankNameAndAccountNO"];
                if (objMes != null && objMes != DBNull.Value)
                {
                    txtBankNameAndAccountNO.Text = objMes.ToString();
                }
                else
                    txtBankNameAndAccountNO.Clear();
            }
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSetUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    mes.Show("用户名不能为空!");
                    txtName.Focus();
                    return;
                }
                MODELWaterUser MODELWaterUser = new MODELWaterUser();
                MODELWaterUser.waterUserNO = txtWaterUserNO.Text;
                MODELWaterUser.waterUserName = txtName.Text;
                MODELWaterUser.waterPhone = txtTel.Text;
                MODELWaterUser.waterUserAddress = txtAddress.Text;
                MODELWaterUser.FPTaxNO = txtTaxNO.Text;
                MODELWaterUser.FPBankNameAndAccountNO = txtBankNameAndAccountNO.Text;

                if (BLLwaterUser.UpdateUserByWaterUserNO(MODELWaterUser))
                {
                    mes.Show("设置成功!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }

    }
}
