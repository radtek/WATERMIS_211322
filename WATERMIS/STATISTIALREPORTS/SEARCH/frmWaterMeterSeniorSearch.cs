using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using BLL;

namespace STATISTIALREPORTS
{
    public partial class frmWaterMeterSeniorSearch : Form
    {
        public frmWaterMeterSeniorSearch()
        {
            InitializeComponent();
        }

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        Messages mes = new Messages();

        /// <summary>
        /// 区分是哪个窗体打开的，1：水表明细查询窗体 2 水表统计窗体
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
        /// 绑定区域
        /// </summary>
        private void BindArea()
        {
            DataTable dt = BLLAREA.Query(" AND areaId<>'0000'");
            cmbValue.DataSource = dt;
            cmbValue.DisplayMember = "areaName";
            cmbValue.ValueMember = "areaId";
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
        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType()
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            cmbValue.DataSource = dt;
            cmbValue.DisplayMember = "waterMeterTypeValue";
            cmbValue.ValueMember = "waterMeterTypeId";
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            switch (strSign)
            {
                case "1":
                    frmWaterMeterSearch frmWaterMeterSearch = (frmWaterMeterSearch)this.Owner;
                    frmWaterMeterSearch.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterMeterSearch.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmWaterMeterSearch.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "2":
                    frmWaterMeterStatistics frmWaterMeterStatistics = (frmWaterMeterStatistics)this.Owner;
                    frmWaterMeterStatistics.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterMeterStatistics.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmWaterMeterStatistics.strSeniorFilterHidden = "";
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
                        strValue ="'"+ cmbValue.SelectedValue.ToString()+"'";
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
                        strValue = "'"+cmbValue.SelectedValue.ToString()+"'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "区域":
                    strItemValue = "areaId";
                    if (cmbValue.SelectedValue != null && cmbValue.SelectedValue != DBNull.Value)
                    {
                        strValue = "'" + cmbValue.SelectedValue.ToString() + "'";
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
                        strValue = "'"+cmbValue.SelectedValue.ToString()+"'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "用户号":
                    strItemValue = "waterUserId";
                    if (cmbValue.Text != "")
                    {
                        strValue = "'" + cmbValue.Text.PadLeft(8, '0') + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "水表编号":
                    strItemValue = "waterMeterNo";
                    if (cmbValue.Text != "")
                    {
                        strValue = "'" + cmbValue.Text.PadLeft(10, '0') + "'";
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
                        strValue = "'" + cmbValue.SelectedValue.ToString() + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "定量用水":
                    strItemValue = "WATERFIXVALUE";
                    if (cmbValue.Text != "")
                    {
                        strValue = cmbValue.Text;
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
                case "区域":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindArea();
                    break;
                case "用户类别":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindWaterUserType();
                    break;
                case "用户号":
                    cmbValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "水表编号":
                    cmbValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "用水性质":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindWaterMeterType();
                    break;
                case "定量用水":
                    cmbValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                default:
                    break;
            }
        }

        void cmbValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)22)
            {
                e.Handled = true;
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
