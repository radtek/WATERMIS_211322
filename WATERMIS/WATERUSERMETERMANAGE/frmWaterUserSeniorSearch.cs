using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using BLL;

namespace WATERUSERMETERMANAGE
{
    public partial class frmWaterUserSeniorSearch : Form
    {
        public frmWaterUserSeniorSearch()
        {
            InitializeComponent();
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        Messages mes = new Messages();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();

        /// <summary>
        /// 区分是哪个窗体打开的，1：水表初始化界面 2批量修改用户界面
        /// </summary>
        public string strSign = "";

        private void frmSeniorSearch_Load(object sender, EventArgs e)
        {
            cmbItem.SelectedIndex = 0;
            cmbOperator.SelectedIndex = 0;
        }
        private void BindAreaNO(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
                dt = BLLAREA.Query("");
            else
                dt = BLLAREA.Query(" AND areaId<>'0000'");

            cmb.DataSource = dt;
            cmb.DisplayMember = "areaName";
            cmb.ValueMember = "areaId";
        }
        private void BindPianNO(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
                dt = BLLBASE_PIAN.Query("");
            else
                dt = BLLBASE_PIAN.Query(" AND PIANID<>'0000'");
            cmb.DataSource = dt;
            cmb.DisplayMember = "PIANNAME";
            cmb.ValueMember = "PIANID";
        }
        private void BindDuanNO(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
                dt = BLLBASE_DUAN.Query("");
            else
                dt = BLLBASE_DUAN.Query(" AND DUANID<>'0000'");
            cmb.DataSource = dt;
            cmb.DisplayMember = "DUANNAME";
            cmb.ValueMember = "DUANID";
        }
        private void BindCommunity(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
                dt = BLLBASE_COMMUNITY.Query("");
            else
                dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000'");
            cmb.DataSource = dt;
            cmb.DisplayMember = "COMMUNITYNAME";
            cmb.ValueMember = "COMMUNITYID";
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
        /// 绑定银行
        /// </summary>
        private void BindBank()
        {
            DataTable dt = BLLBASE_BANK.Query("");
            cmbValue.DataSource = dt;
            cmbValue.DisplayMember = "bankName";
            cmbValue.ValueMember = "bankId";
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindCharger()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
            cmbValue.DataSource = dt;
            cmbValue.DisplayMember = "USERNAME";
            cmbValue.ValueMember = "LOGINID";
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
                    frmWaterUserAndMeter frmWaterUserAndMeter = (frmWaterUserAndMeter)this.Owner;
                    frmWaterUserAndMeter.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterUserAndMeter.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmWaterUserAndMeter.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "2":
                    frmBatchModifyWaterUserMesAndWaterMeterMes frmBatchModifyWaterUserMesAndWaterMeterMes = (frmBatchModifyWaterUserMesAndWaterMeterMes)this.Owner;
                    frmBatchModifyWaterUserMesAndWaterMeterMes.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmBatchModifyWaterUserMesAndWaterMeterMes.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmBatchModifyWaterUserMesAndWaterMeterMes.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
            }
        }

        /*
         * 
         * 用户号
人口数
区号
片号
段号
小区名称
楼号
单元
抄表员
收费员
用户类别
交费方式
建档日期
建档类型
银行托收
托收银行
         * */
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
                case "区号":
                    strItemValue = "areaNO";
                    if (cmbValue.SelectedValue != null && cmbValue.SelectedValue != DBNull.Value)
                    {
                        strValue ="'"+ cmbValue.Text+"'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "片号":
                    strItemValue = "pianNO";
                    if (cmbValue.SelectedValue != null && cmbValue.SelectedValue != DBNull.Value)
                    {
                        strValue = "'" + cmbValue.Text + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "段号":
                    strItemValue = "duanNO";
                    if (cmbValue.SelectedValue != null && cmbValue.SelectedValue != DBNull.Value)
                    {
                        strValue = "'" + cmbValue.Text + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "小区名称":
                    strItemValue = "communityID";
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
                case "楼号":
                    strItemValue = "buildingNO";
                    if (cmbValue.Text != "")
                    {
                        strValue = "'" + cmbValue.Text + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "单元":
                    strItemValue = "unitNO";
                    if (cmbValue.Text != "")
                    {
                        strValue = "'" + cmbValue.Text + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "抄表员":
                    strItemValue = "meterReaderID";
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
                case "收费员":
                    strItemValue = "chargerID";
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
                    strItemValue = "waterUserNO";
                    if (cmbValue.Text != "")
                    {
                        strValue = "'" + cmbValue.Text + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "交费方式":
                    strItemValue = "chargeType";
                    if (cmbValue.SelectedIndex > -1)
                    {
                        strValue = "'" + cmbValue.SelectedIndex.ToString() + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "建档日期":
                    strItemValue = "waterUserCreateDate";
                    if (cmbValue.Text != "")
                    {
                        strValue = "'" + cmbValue.Text + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "建档类型":
                    strItemValue = "createType";
                    if (cmbValue.Text != "")
                    {
                        strValue = "'" + cmbValue.Text + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "银行托收":
                    strItemValue = "agentsign";
                    if (cmbValue.SelectedIndex > -1)
                    {
                        strValue = "'" + (cmbValue.SelectedIndex+1).ToString() + "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "托收银行":
                    strItemValue = "bankId";
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
                case "人口数":
                    strItemValue = "waterUserPeopleCount";
                    if (cmbValue.Text != "")
                    {
                        strValue = "'" + cmbValue.Text + "'";
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
                case "区号":
                    if (cmbValue.Text!="")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", "'"+cmbValue.Text + "',条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
                    break;
                case "片号":
                    if (cmbValue.Text != "")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.Text + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
                    break;
                case "段号":
                    if (cmbValue.Text != "")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.Text + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
                    break;
                case "楼号":
                    if (cmbValue.Text!="")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.Text + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
                    break;
                case "单元":
                    if (cmbValue.Text != "")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.Text + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
                    break;
                case "用户号":
                    if (cmbValue.Text != "")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.Text + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
                    break;
                case "建档日期":
                    if (cmbValue.Text != "")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.Text + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
                    break;
                case "建档类型":
                    if (cmbValue.Text != "")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.Text + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
                    break;
                case "银行托收":
                    if (cmbValue.Text != "")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.Text + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
                    break;
                case "人口数":
                    if (cmbValue.Text != "")
                    {
                        labHaveSetUp.Text = labHaveSetUp.Text.Replace("条件", cmbValue.Text + ",条件");
                        labHaveSetUpHidden.Text = labHaveSetUpHidden.Text.Replace("条件", cmbValue.Text + ",条件");
                    }
                    else
                    {
                        cmbValue.Focus();
                        mes.Show("值为空，无法插入!");
                        return;
                    }
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
                case "区号":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindAreaNO(cmbValue,"1");
                    break;
                case "片号":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindPianNO(cmbValue,"1");
                    break;
                case "段号":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindDuanNO(cmbValue,"1");
                    break;
                case "小区名称":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindCommunity(cmbValue,"1");
                    break;
                case "抄表员":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindMeterReader();
                    break;
                case "收费员":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindCharger();
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
                case "人口数":
                    cmbValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "楼号":
                    cmbValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbValue.Text = "";
                    cmbValue.KeyPress -= new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "单元":
                    cmbValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbValue.Text = "";
                    cmbValue.KeyPress -= new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "交费方式":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    cmbValue.Items.Add("非预存");
                    cmbValue.Items.Add("预存");
                    cmbValue.SelectedIndex = 0;
                    break;
                case "建档日期":
                    cmbValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbValue.Text = "";
                    cmbValue.KeyPress -= new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "建档类型":
                    cmbValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbValue.Text = "";
                    cmbValue.KeyPress -= new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "银行托收":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    cmbValue.Items.Add("托收");
                    cmbValue.Items.Add("不托收");
                    cmbValue.SelectedIndex = 0;
                    break;
                case "托收银行":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindBank();
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
