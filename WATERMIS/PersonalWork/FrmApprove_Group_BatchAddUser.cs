using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BLL;
using BASEFUNCTION;
using System.Threading;

namespace PersonalWork
{
    public partial class FrmApprove_Group_BatchAddUser : DockContentEx
    {
        public FrmApprove_Group_BatchAddUser()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        //BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();

        BLLwaterMeterPosition BLLwaterMeterPosition = new BLLwaterMeterPosition();
        BLLwaterMeterSize BLLwaterMeterSize = new BLLwaterMeterSize();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();

        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        private void frmBatchModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            dgWaterListBatch.AutoGenerateColumns = false;
            this.dgWaterListBatch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            for (int i = 0; i < dgWaterListBatch.Columns.Count; i++)
            {
                //隐藏附加费列
                if (dgWaterListBatch.Columns[i].Name == "waterUserNameBatch" || dgWaterListBatch.Columns[i].Name == "waterUserTelphoneNO" ||
                    dgWaterListBatch.Columns[i].Name == "waterPhoneBatch" || dgWaterListBatch.Columns[i].Name == "waterUserAddressBatch" ||
                    dgWaterListBatch.Columns[i].Name == "buildingNO" || dgWaterListBatch.Columns[i].Name == "unitNO" ||
                    dgWaterListBatch.Columns[i].Name == "waterUserCerficateNO" || dgWaterListBatch.Columns[i].Name == "waterUserCerficateType" ||
                    dgWaterListBatch.Columns[i].Name == "waterMeterSerialNumberBatch" || dgWaterListBatch.Columns[i].Name == "waterMeterModeBatch" ||
                    dgWaterListBatch.Columns[i].Name == "WATERMETERLOCKNO" )
                {
                    dgWaterListBatch.Columns[i].ReadOnly = false;
                }
                else
                    dgWaterListBatch.Columns[i].ReadOnly = true;
            }
            cmbLeft.SelectedIndex = 0;
        }

        private void dgWaterListBatch_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //判断是不是列Header
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                //单元格描绘  
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                //决定行号码描绘的范围   
                //不管e.AdvancedBorderStyle和e.CellStyle.Padding  
                Rectangle indexRect = e.CellBounds; indexRect.Inflate(-2, -2);
                //行号码描绘  
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, indexRect, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                //描绘完后通知 
                e.Handled = true;
            }
        }
        /**
         * 地址
            人口数
            区号
            片号
            段号
            小区名称
            楼号
            单元
            抄表员
            收费员
            户型
            交费方式
            银行托收
            托收银行
            建档类型
            水表位置
            口径
            水表状态
            用水性质
            初始读数
            生产厂家
            铅封号
            倍率
            最大量程
            鉴定日期
            鉴定周期
            是否总表
            所属总表
            定量用水
            水表倒装
         * */
        private void cmbLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dtProofDate.Visible = false;
            cmbLeft.Visible = true;
            cmbModifyValue.DataSource = null;
            cmbModifyValue.Items.Clear();
            cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
            string strTxt = cmbLeft.Text;
            switch (strTxt)
            {
                case "地址":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "人口数":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "1";
                    break;
                case "区号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLAREA.Query(" AND areaId<>'0000'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "areaName";
                    cmbModifyValue.ValueMember = "areaId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "片号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_PIAN.Query(" AND PIANID<>'0000'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "PIANNAME";
                    cmbModifyValue.ValueMember = "PIANID";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "段号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_DUAN.Query(" AND DUANID<>'0000'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "DUANNAME";
                    cmbModifyValue.ValueMember = "DUANID";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "用户类别":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLwaterUserType.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterUserTypeName";
                    cmbModifyValue.ValueMember = "waterUserTypeId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "小区名称":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "COMMUNITYNAME";
                    cmbModifyValue.ValueMember = "COMMUNITYID";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "楼号":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "单元":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "抄表员":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "userName";
                    cmbModifyValue.ValueMember = "loginId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "收费员":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "userName";
                    cmbModifyValue.ValueMember = "loginId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "户型":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    
                    cmbModifyValue.Items.Add("楼房");
                    cmbModifyValue.Items.Add("平房");
                    cmbModifyValue.Text = "楼房";
                    break;
                case "交费方式":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbModifyValue.Items.Add("非预存");
                    cmbModifyValue.Items.Add("预存");
                    cmbModifyValue.Text = "非预存";
                    break;
                case "银行托收":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbModifyValue.Items.Add("托收");
                    cmbModifyValue.Items.Add("不托收");
                    cmbModifyValue.Text = "不托收";
                    break;
                case "托收银行":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_BANK.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "bankName";
                    cmbModifyValue.ValueMember = "bankId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    break;
                case "建档类型":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbModifyValue.Items.Add("正式");
                    cmbModifyValue.Items.Add("非正式");
                    cmbModifyValue.Items.Add("基建");
                    cmbModifyValue.Items.Add("无表");
                    cmbModifyValue.Text = "正式";
                    break;
                case "是否总表":                    
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbModifyValue.Items.Add("分表");
                    cmbModifyValue.Items.Add("总表");
                    cmbModifyValue.Text = "分表";
                    break;
                case "水表位置":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    dt = BLLwaterMeterPosition.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterMeterPositionName";
                    cmbModifyValue.ValueMember = "waterMeterPositionId";
                    break;
                case "口径":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    dt = BLLwaterMeterSize.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterMeterSizeValue";
                    cmbModifyValue.ValueMember = "waterMeterSizeId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    break;
                case "水表状态":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbModifyValue.Items.Add("正常");
                    cmbModifyValue.Items.Add("注销");
                    cmbModifyValue.Items.Add("换表");
                    cmbModifyValue.Items.Add("未启用");
                    cmbModifyValue.Items.Add("欠费停水");
                    cmbModifyValue.Items.Add("违章停水");
                    cmbModifyValue.Items.Add("坏表");
                    cmbModifyValue.Items.Add("待审核");
                    cmbModifyValue.Text = "正常";
                    break;
                case "用水性质":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLWATERMETERTYPE.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterMeterTypeValue";
                    cmbModifyValue.ValueMember = "waterMeterTypeId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    break;
                case "初始读数":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "0";
                    break;
                case "出厂编号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "生产厂家":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "铅封号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "倍率":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "1";
                    break;
                case "最大量程":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "99999";
                    break;
                case "鉴定周期":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "12";
                    break;
                case "鉴定日期":
                    dtProofDate.Visible = true;
                    break;
                case "所属总表":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLwaterMeter.QuerySummary("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterUserName";
                    cmbModifyValue.ValueMember = "waterMeterId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    break;
                case "定量用水":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "0";
                    break;
            }
        }

        void cmbModifyValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (mes.ShowQ("确定要将选择的行中的'" + cmbLeft.Text + "'的信息全部修改吗?") != DialogResult.OK)
                return;

            try
            {
                string strTxt = cmbLeft.Text;
                switch (strTxt)
                {
                    case "地址":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterUserAddressBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "人口数":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterUserPeopleCountBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "区号":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["areaNO"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的区号不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "段号":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["duanNO"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的段号不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "片号":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["pianNO"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的片号不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "用户类别":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["waterUserTypeId"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["waterUserTypeName"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改的用户类别不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "小区名称":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["communityID"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["COMMUNITYNAME"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的小区不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "楼号":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["buildingNO"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "单元":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["unitNO"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "抄表员":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["meterReaderID"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["meterReaderName"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的抄表员不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "收费员":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["chargerID"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["chargerName"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的收费员不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "户型":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterUserHouseTypeS"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "交费方式":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["chargeType"].Value = cmbModifyValue.SelectedIndex.ToString();
                        }
                        break;
                    case "银行托收":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["agentsignS"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "托收银行":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["bankIdBatch"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["bankNameBatch"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的托收银行不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "建档类型":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["createType"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "是否总表":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["isSummaryMeterSBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "水表位置":
                        //if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        //{
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterPositionNameBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "口径":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterSizeIdBatch"].Value = cmbModifyValue.SelectedValue;
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterSizeValueBatch"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的水表位置不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "水表状态":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterStateSBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "用水性质":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterTypeIdBatch"].Value = cmbModifyValue.SelectedValue;
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterTypeValueBatch"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的水表位置不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "初始读数":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterStartNumberBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "出厂编号":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterSerialNumberBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "生产厂家":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterProductBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "铅封号":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterModeBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "倍率":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterMagnificationBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "最大量程":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterMaxRangeBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "鉴定周期":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeteProofreadingPeriodBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "鉴定日期":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterProofreadingDateBatch"].Value = dtProofDate.Text;
                        }
                        break;
                    case "所属总表":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterParentId"].Value = cmbModifyValue.SelectedValue;
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterParentName"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("修改后的总表不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "定量用水":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                                    dgWaterListBatch.SelectedRows[i].Cells["WATERFIXVALUEBatch"].Value = cmbModifyValue.Text;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }            //btSearch_Click(null,null);
        }


        private void dgWaterListBatch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "chargeType")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "非预存";
                    }
                    else if (e.Value.ToString() == "1")
                        e.Value = "预存";
            }
        }

        private void dgWaterListBatch_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgWaterListBatch.CurrentCell.IsInEditMode)
                return;

                if (e.Button == MouseButtons.Right)
                {
                    string pasteText = "";
                    pasteText = Clipboard.GetText();

                    if (string.IsNullOrEmpty(pasteText))
                    {
                        粘贴复制内容ToolStripMenuItem.Enabled = false;
                    }
                    else
                        粘贴复制内容ToolStripMenuItem.Enabled = true;

                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
        }

        private void 粘贴复制内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取剪切板的内容，并按行分割 
                string pasteText = "";
                pasteText = Clipboard.GetText();

                if (string.IsNullOrEmpty(pasteText))
                {
                    mes.Show("没有复制任何内容!");
                    return;
                }
                if (pasteText == "pasteText")
                {
                    return;
                }
                int tnum = 0;
                int nnum = 0;
                //获得当前剪贴板内容的行、列数
                for (int i = 0; i < pasteText.Length; i++)
                {
                    if (pasteText.Substring(i, 1) == "\t")
                    {
                        tnum++;
                    }
                    if (pasteText.Substring(i, 1) == "\n")
                    {
                        nnum++;
                    }
                }
                Object[,] data;
                //粘贴板上的数据来自于EXCEL时，每行末都有\n，在DATAGRIDVIEW内复制时，最后一行末没有\n
                if (pasteText.Substring(pasteText.Length - 1, 1) == "\n")
                {
                    nnum = nnum - 1;
                }
                tnum = tnum / (nnum + 1);
                data = new object[nnum + 1, tnum + 1];//定义一个二维数组

                String rowstr;
                rowstr = "";
                //MessageBox.Show(pasteText.IndexOf("B").ToString());
                //对数组赋值
                for (int i = 0; i < (nnum + 1); i++)
                {
                    for (int colIndex = 0; colIndex < (tnum + 1); colIndex++)
                    {
                        //一行中的最后一列
                        if (colIndex == tnum && pasteText.IndexOf("\r") != -1)
                        {
                            rowstr = pasteText.Substring(0, pasteText.IndexOf("\r"));
                        }
                        //最后一行的最后一列
                        if (colIndex == tnum && pasteText.IndexOf("\r") == -1)
                        {
                            rowstr = pasteText.Substring(0);
                        }
                        //其他行列
                        if (colIndex != tnum)
                        {
                            rowstr = pasteText.Substring(0, pasteText.IndexOf("\t"));
                            pasteText = pasteText.Substring(pasteText.IndexOf("\t") + 1);
                        }
                        data[i, colIndex] = rowstr;
                    }
                    //截取下一行数据
                    pasteText = pasteText.Substring(pasteText.IndexOf("\n") + 1);
                }
                //获取当前选中单元格所在的列序号
                int curntindex = dgWaterListBatch.CurrentRow.Cells.IndexOf(dgWaterListBatch.CurrentCell);
                //获取获取当前选中单元格所在的行序号
                int rowindex = dgWaterListBatch.CurrentRow.Index;
                //MessageBox.Show(curntindex.ToString ());
                for (int j = 0; j < (nnum + 1); j++)
                {
                    for (int colIndex = 0; colIndex < (tnum + 1); colIndex++)
                    {
                        if (!dgWaterListBatch.Columns[colIndex + curntindex].Visible)
                        {
                            continue;
                        }
                        if (!dgWaterListBatch.Rows[j + rowindex].Cells[colIndex + curntindex].ReadOnly)
                        {
                            dgWaterListBatch.Rows[j + rowindex].Cells[colIndex + curntindex].Value = data[j, colIndex];
                        }
                    }
                }
                Clipboard.Clear();
            }
            catch
            {
                Clipboard.Clear();
                //MessageBox.Show("粘贴区域大小不一致");
                return;
            }
        }
    }
}
