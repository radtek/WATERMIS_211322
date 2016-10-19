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
    public partial class frmSeniorSearch : Form
    {
        public frmSeniorSearch()
        {
            InitializeComponent();
        }

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        Messages mes = new Messages();

        /// <summary>
        /// 区分是哪个窗体打开的，1：收费统计窗体 2：收费发票统计窗体 3收费明细查询窗体 4 未抄明细查询窗体 5 已抄水表明细查询窗体 6水表应收明细查询窗体 7用户应收明细表
        /// 8 水表异常分析窗体  9 查抄率统计窗体 10 收费率统计窗体 11用户应收统计窗体 12 收费统计窗体（新）13水表欠费情况分析窗体 14通知单统计窗体
        /// </summary>
        public string strSign = "";

        private void frmSeniorSearch_Load(object sender, EventArgs e)
        {
            cmbItem.SelectedIndex = 0;
            cmbOperator.SelectedIndex = 0;

            if (strSign == "4")
            {
                cmbItem.Items.RemoveAt(8);
                cmbItem.Items.RemoveAt(7);
            }
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
        private void btOK_Click(object sender, EventArgs e)
        {
            switch (strSign)
            {
                case "1":
                    frmWaterChargeStatistics frmWaterChargeStatistics = (frmWaterChargeStatistics)this.Owner;
                    frmWaterChargeStatistics.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterChargeStatistics.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "")+")";
                    else
                        frmWaterChargeStatistics.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "2":
                    frmChargeInvoicePrintStatistisc frmChargeInvoicePrintStatistisc = (frmChargeInvoicePrintStatistisc)this.Owner;
                    frmChargeInvoicePrintStatistisc.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmChargeInvoicePrintStatistisc.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "")+")";
                    else
                        frmChargeInvoicePrintStatistisc.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "3":
                    frmWaterMeterChargeSearch frmWaterMeterChargeSearch = (frmWaterMeterChargeSearch)this.Owner;
                    frmWaterMeterChargeSearch.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterMeterChargeSearch.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmWaterMeterChargeSearch.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;

                case "5":
                    frmReadMeterRecordSearch frmReadMeterRecordSearch = (frmReadMeterRecordSearch)this.Owner;
                    frmReadMeterRecordSearch.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmReadMeterRecordSearch.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmReadMeterRecordSearch.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "6":
                    frmWaterMeterYSMXSearch frmWaterMeterYSMXSearch = (frmWaterMeterYSMXSearch)this.Owner;
                    frmWaterMeterYSMXSearch.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterMeterYSMXSearch.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmWaterMeterYSMXSearch.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "7":
                    frmWaterUserYSMXSearch frmWaterUserYSMXSearch = (frmWaterUserYSMXSearch)this.Owner;
                    frmWaterUserYSMXSearch.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterUserYSMXSearch.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmWaterUserYSMXSearch.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "8":
                    frmReadMeterExceptionSearch frmReadMeterExceptionSearch = (frmReadMeterExceptionSearch)this.Owner;
                    frmReadMeterExceptionSearch.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmReadMeterExceptionSearch.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmReadMeterExceptionSearch.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "9":
                    frmReadMeterRecordPecent frmReadMeterRecordPecent = (frmReadMeterRecordPecent)this.Owner;
                    frmReadMeterRecordPecent.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmReadMeterRecordPecent.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmReadMeterRecordPecent.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "10":
                    frmWaterMeterChargePercent frmWaterMeterChargePercent = (frmWaterMeterChargePercent)this.Owner;
                    frmWaterMeterChargePercent.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterMeterChargePercent.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmWaterMeterChargePercent.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "12":
                    frmWaterChargeStatisticsNew frmWaterChargeStatisticsNew = (frmWaterChargeStatisticsNew)this.Owner;
                    frmWaterChargeStatisticsNew.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterChargeStatisticsNew.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmWaterChargeStatisticsNew.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "13":
                    frmWaterMeterDebtSearch frmWaterMeterDebtSearch = (frmWaterMeterDebtSearch)this.Owner;
                    frmWaterMeterDebtSearch.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmWaterMeterDebtSearch.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmWaterMeterDebtSearch.strSeniorFilterHidden = "";
                    this.DialogResult = DialogResult.OK;
                    break;
                case "14":
                    frmInformStatistics frmInformStatistics = (frmInformStatistics)this.Owner;
                    frmInformStatistics.strSeniorFilter = labHaveSetUp.Text.Replace(",条件", "");
                    if (labHaveSetUpHidden.Text.Trim() != "")
                        frmInformStatistics.strSeniorFilterHidden = " AND (" + labHaveSetUpHidden.Text.Replace(",条件", "") + ")";
                    else
                        frmInformStatistics.strSeniorFilterHidden = "";
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
                        strValue = "'" + cmbValue.SelectedValue.ToString() + "'";
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
                        strValue = "'" + cmbValue.SelectedValue.ToString() + "'";
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
                case "用户类别":
                    strItemValue = "waterUserTypeId";
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
                case "区域":
                    strItemValue = "areaId";
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
                case "用户号":
                    strItemValue = "waterUserId";
                    if (cmbValue.Text!="")
                    {
                        strValue = "'"+cmbValue.Text.PadLeft(8,'0')+"'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "水表号":
                    strItemValue = "waterMeterId";
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
                case "用水量":
                    strItemValue = "totalNumber";
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
                case "水费":
                    strItemValue = "totalCharge";
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
                case "总表编号":
                    strItemValue = "waterMeterParentId";
                    if (cmbValue.Text != "")
                    {
                        strValue = "'" + cmbValue.Text+ "'";
                    }
                    else
                    {
                        mes.Show("值的Value为空，无法加入条件!");
                        return;
                    }
                    break;
                case "抄表年份":
                    strItemValue = "readMeterRecordYear";
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
                case "抄表月份":
                    strItemValue = "readMeterRecordMonth";
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
                case "用户交费方式":
                    strItemValue = "waterUserchargeType";
                    if (cmbValue.SelectedIndex>-1)
                    {
                        strValue = "'" + cmbValue.SelectedIndex.ToString() + "'";
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
                    toolTip.SetToolTip(cmbValue, "");
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindMeterReader();
                    break;
                case "抄表本":
                    toolTip.SetToolTip(cmbValue, "");
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindMeterReading();
                    break;
                case "用水性质":
                    toolTip.SetToolTip(cmbValue, "");
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindWaterMeterType();
                    break;
                case "用户类别":
                    toolTip.SetToolTip(cmbValue, "");
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindWaterUserType();
                    break;
                case "区域":
                    toolTip.SetToolTip(cmbValue, "");
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    BindArea();
                    break;
                case "用户号":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    toolTip.SetToolTip(cmbValue, "请输入8位用户编号");
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "水表号":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    toolTip.SetToolTip(cmbValue, "请输入10位水表编号");
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "用水量":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    toolTip.SetToolTip(cmbValue, "请输入数字");
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "水费":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    toolTip.SetToolTip(cmbValue, "请输入数字");
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "总表编号":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    toolTip.SetToolTip(cmbValue,"请输入10位水表编号或8位用户号");
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "抄表年份":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    toolTip.SetToolTip(cmbValue, "请输入4位年份,例如'2015'");
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "抄表月份":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    toolTip.SetToolTip(cmbValue, "请输入1位或2位月份,例如'9'或'11'");
                    cmbValue.Text = "";
                    cmbValue.KeyPress += new KeyPressEventHandler(cmbValue_KeyPress);
                    break;
                case "用户交费方式":
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbValue.DataSource = null;
                    cmbValue.Items.Clear();
                    toolTip.SetToolTip(cmbValue, "");
                    cmbValue.Items.Add("非预存");
                    cmbValue.Items.Add("预存");
                    cmbValue.SelectedIndex = 0;
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

        private void cmbValue_MouseEnter(object sender, EventArgs e)
        {
            //if (cmbValue.DropDownStyle == ComboBoxStyle.Simple)
            //{
            //    toolTip.SetToolTip(cmbValue,toolTip.Tag!=null?toolTip.Tag.ToString():"");
            //}
        }

        private void cmbValue_MouseUp(object sender, MouseEventArgs e)
        {
            //if (cmbValue.DropDownStyle == ComboBoxStyle.Simple)
            //{
            //    toolTip.SetToolTip(cmbValue, toolTip.Tag != null ? toolTip.Tag.ToString() : "");
            //}
        }

        private void cmbValue_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbValue.DropDownStyle == ComboBoxStyle.Simple)
            {
            }
        }
    }
}
