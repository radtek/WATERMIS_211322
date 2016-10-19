using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using BLL;

namespace METERREADINGMACHINE
{
    public partial class frmSeniorSearch : Form
    {
        public frmSeniorSearch()
        {
            InitializeComponent();
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        Messages mes = new Messages();

        /// <summary>
        /// 区分是哪个窗体打开的，1：向抄表机导入数据窗体 2:向抄表机自定义导入数据窗体
        /// </summary>
        public string strSign = "";

        private void frmSeniorSearch_Load(object sender, EventArgs e)
        {
            cmbItem.SelectedIndex = 0;
            cmbOperator.SelectedIndex = 0;           
        }
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
            cmbValue.DataSource = dt;
            cmbValue.DisplayMember = "USERNAME";
            cmbValue.ValueMember = "LOGINID";
        }
        /// <summary>
        /// 绑定抄表本
        /// </summary>
        private void BindMeterReading()
        {
            DataTable dt = BLLmeterReading.Query("");
            cmbValue.DataSource = dt;
            cmbValue.DisplayMember = "meterReadingNO";
            cmbValue.ValueMember = "meterReadingID";
        }
        /// <summary>
        /// 绑定用水性质
        /// </summary>
        private void BindWaterMeterType()
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            cmbValue.DataSource = dt;
            cmbValue.DisplayMember = "waterMeterTypeValue";
            cmbValue.ValueMember = "waterMeterTypeId";
        }
        /// <summary>
        /// 绑定用户类别
        /// </summary>
        private void BindWaterUserType()
        {
            DataTable dt = BLLwaterUserType.Query("");
            cmbValue.DataSource = dt;
            cmbValue.DisplayMember = "waterUserTypeName";
            cmbValue.ValueMember = "waterUserTypeId";
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            switch (strSign)
            {
                case "1":
                    frmToMachineManage frmToMachineManage = (frmToMachineManage)this.Owner;
                    frmToMachineManage.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmToMachineManage.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmToMachineManage.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "2":
                    frmToMachineManageCustomData frmToMachineManageCustomData = (frmToMachineManageCustomData)this.Owner;
                    frmToMachineManageCustomData.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmToMachineManageCustomData.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmToMachineManageCustomData.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
            }
        }

        private void btInsertContition_Click(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex < 0)
            {
                cmbItem.Focus();
                mes.Show("请选择项目!");
                return;
            }
            string strItemValue = "", strValue = "";
            switch (cmbItem.Text)
            {
                case "抄表员":
                    strItemValue = "loginId";
                    if (cmbValue.SelectedValue != null && cmbValue.SelectedValue != DBNull.Value)
                    {
                        strValue = cmbValue.SelectedValue.ToString();
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "抄表本":
                    strItemValue = "meterReadingID";
                    if (cmbValue.SelectedValue != null && cmbValue.SelectedValue != DBNull.Value)
                    {
                        strValue = cmbValue.SelectedValue.ToString();
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "用水性质":
                    strItemValue = "waterMeterTypeId";
                    if (cmbValue.SelectedValue != null && cmbValue.SelectedValue != DBNull.Value)
                    {
                        strValue = cmbValue.SelectedValue.ToString();
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "用户类别":
                    strItemValue = "waterUserTypeId";
                    if (cmbValue.SelectedValue != null && cmbValue.SelectedValue != DBNull.Value)
                    {
                        strValue = cmbValue.SelectedValue.ToString();
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                default:
                    break;
            }
            switch (cmbOperator.Text)
            {
                case "包含":
                    if (labHaveSetUp.Text.Trim() != "")
                    {
                        labHaveSetUp.Text += " " + cmbItem.Text + cmbOperator.Text + " (条件)";
                        labHaveSetUpHidden.Text += " " + strItemValue + " IN (条件)";
                    }
                    else
                    {
                        labHaveSetUp.Text = cmbOperator.Text + " (条件)";
                        labHaveSetUpHidden.Text = strItemValue + " IN (条件)";
                    }

                    cmbValue.Enabled = true;
                    btInsert.Enabled = true;

                    btAnd.Enabled = false;
                    btOr.Enabled = false;
                    btBraketsLeft.Enabled = false;
                    //btBraketsRight.Enabled = false;
                    btInsertContition.Enabled = false;
                    break;
                default:
                    if (labHaveSetUp.Text.Trim() != "")
                    {
                        labHaveSetUp.Text += " " + cmbItem.Text + cmbOperator.Text + cmbValue.Text ;
                        labHaveSetUpHidden.Text += " " + strItemValue + cmbOperator.Text + strValue;
                    }
                    else
                    {
                        labHaveSetUp.Text = " " + cmbItem.Text + cmbOperator.Text + cmbValue.Text;
                        labHaveSetUpHidden.Text = " " + strItemValue + cmbOperator.Text + strValue;
                    }

                    btAnd.Enabled = true;
                    btOr.Enabled = true;
                    btBraketsLeft.Enabled = false;
                    //btBraketsRight.Enabled = false;
                    btInsertContition.Enabled = false;
                    break;
            }
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            switch(cmbItem.Text)
            {
                case "":

                    break;
                default :
                    if (cmbValue.SelectedValue != null && cmbValue.SelectedValue != DBNull.Value)
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.SelectedValue.ToString() + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("插入值的Value为空，无法插入!");
                        return;
                    }
                    break;
            }

            btAnd.Enabled = true;
            btOr.Enabled = true;
            btBraketsLeft.Enabled = false;
            //btInsertContition.Enabled = true;
        }

        private void btAnd_Click(object sender, EventArgs e)
        {
                labHaveSetUp.Text += " 并且 ";
                labHaveSetUpHidden.Text += " AND ";

                btInsert.Enabled = false;
                btBraketsLeft.Enabled = true;

                btAnd.Enabled = false;
                btOr.Enabled = false;

                btInsertContition.Enabled = true;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            labHaveSetUp.Text = "";
            labHaveSetUp.Text = "";

            btInsert.Enabled = false;
            btAnd.Enabled = false;
            btOr.Enabled = false;
            btBraketsLeft.Enabled = true;
            btInsertContition.Enabled = true;
        }

        private void btOr_Click(object sender, EventArgs e)
        {
            labHaveSetUp.Text += " 或者 ";
            labHaveSetUpHidden.Text += " OR ";

            btInsert.Enabled = false;
            btBraketsLeft.Enabled = true;

            btAnd.Enabled = false;
            btOr.Enabled = false;

            btInsertContition.Enabled = true;
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbItem.Text)
            {
                case "抄表员":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindMeterReader();
                    break;
                case "抄表本":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindMeterReading();
                    break;
                case "用水性质":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindWaterMeterType();
                    break;
                case "用户类别":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindWaterUserType();
                    break;
                default:
                    break;
            }
        }

        private void btBraketsLeft_Click(object sender, EventArgs e)
        {
            btAnd.Enabled = false;
            btOr.Enabled = false;

            btBraketsLeft.Enabled = false;
            btBraketsRight.Enabled = true;

            btInsertContition.Enabled = true;

            labHaveSetUp.Text +="(";
            labHaveSetUpHidden.Text += "(";
        }

        private void btBraketsRight_Click(object sender, EventArgs e)
        {
            btAnd.Enabled = true;
            btOr.Enabled = true;

            //btBraketsLeft.Enabled = true;
            btBraketsRight.Enabled = false;

            btInsertContition.Enabled = false;

            labHaveSetUp.Text += ")";
            labHaveSetUpHidden.Text += ")";
        }
    }
}
