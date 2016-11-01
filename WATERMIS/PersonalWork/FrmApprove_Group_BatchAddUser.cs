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
using System.Collections;
using System.Data.SqlClient;

namespace PersonalWork
{
    public partial class FrmApprove_Group_BatchAddUser : DockContentEx
    {
        public FrmApprove_Group_BatchAddUser()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);

            cmbWaterMeter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWaterMeter.Visible = false;
            cmbWaterMeter.SelectedIndexChanged += new EventHandler(cmbWaterMeter_SelectedIndexChanged);
            dgList.Controls.Add(cmbWaterMeter);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();

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

        SqlServerHelper SqlServerHelper = new SqlServerHelper();

        /// <summary>
        ///单位报装ID，传入参数，根据此参数获取用户及水表信息
        /// </summary>
        public string strGroupID = "";

        /// <summary>
        /// 水表选择下拉框
        /// </summary>
        private ComboBox cmbWaterMeter = new ComboBox();

        /// <summary>
        /// 可选择的水表列表
        /// </summary>
        DataTable dtMeterCanSelected = new DataTable();

        private string strLogID;
        private string strRealName;

        private void frmBatchModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            this.dgList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            CheckForIllegalCrossThreadCalls = false;

            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            {
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            }
            else
            {
                MessageBox.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                //隐藏附加费列
                if (dgList.Columns[i].Name == "waterUserName" || dgList.Columns[i].Name == "waterUserTelphoneNO" ||
                    dgList.Columns[i].Name == "waterUserAddress" || dgList.Columns[i].Name == "ordernumber" ||
                     dgList.Columns[i].Name == "waterUserPeopleCount" || dgList.Columns[i].Name == "WaterMeterStartNumber" ||
                    dgList.Columns[i].Name == "buildingNO" || dgList.Columns[i].Name == "unitNO" ||
                    dgList.Columns[i].Name == "waterMeterSerialNumber" || dgList.Columns[i].Name == "waterMeterMode" ||
                    dgList.Columns[i].Name == "WATERMETERLOCKNO")
                {
                    dgList.Columns[i].ReadOnly = false;
                }
                else
                    dgList.Columns[i].ReadOnly = true;
            }
            cmbLeft.SelectedIndex = 0;
            BindWaterUserAndMeter();
        }
        private void BindWaterUserAndMeter()
        {
            string strSQL = "SELECT * FROM Meter_Groupeople_Detail WHERE GroupID='" + strGroupID + "'";
            DataTable dt = SqlServerHelper.GetDateTableBySql(strSQL);
            dgList.DataSource = dt;

            strSQL = "SELECT * FROM Meter_GroupMeter WHERE GroupID='" + strGroupID + "'";
            dtMeterCanSelected = SqlServerHelper.GetDateTableBySql(strSQL);

            cmbWaterMeter.DataSource = dtMeterCanSelected;
            cmbWaterMeter.DisplayMember = "waterMeterSerialNumber";
            cmbWaterMeter.ValueMember = "waterMeterSerialNumber";
        }

        void cmbWaterMeter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intColumnIndex = dgList.CurrentCell.ColumnIndex;
            int intRowIndex = dgList.CurrentCell.RowIndex;
            if (cmbWaterMeter.SelectedValue != null && cmbWaterMeter.SelectedValue != DBNull.Value)
            {
                dgList.CurrentCell.Value = cmbWaterMeter.Text;
            }
            else
                dgList.CurrentCell.Value = null;
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
                    cmbModifyValue.Items.Add("车库");
                    cmbModifyValue.Text = "楼房";
                    break;
                case "交费方式":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbModifyValue.Items.Add("非预存");
                    cmbModifyValue.Items.Add("预存");
                    cmbModifyValue.Text = "非预存";
                    break;
                case "建档类型":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbModifyValue.Items.Add("正式");
                    cmbModifyValue.Items.Add("非正式");
                    cmbModifyValue.Items.Add("基建");
                    cmbModifyValue.Items.Add("无表");
                    cmbModifyValue.Text = "正式";
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
                case "通道号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "铅封号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "表锁号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "定量用水":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "0";
                    break;
                case "是否倒装":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbModifyValue.Items.Add("否");
                    cmbModifyValue.Items.Add("是");
                    cmbModifyValue.Text = "否";
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
                        for (int i = 0; i < dgList.SelectedRows.Count; i++)
                        {
                            dgList.SelectedRows[i].Cells["waterUserAddress"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "人口数":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgList.SelectedRows.Count; i++)
                        {
                            dgList.SelectedRows[i].Cells["waterUserPeopleCount"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "区号":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["areaNO"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("区号不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "段号":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["duanNO"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("段号不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "片号":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["pianNO"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("片号不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "用户类别":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["waterUserTypeId"].Value = cmbModifyValue.SelectedValue.ToString();
                                dgList.SelectedRows[i].Cells["waterUserTypeName"].Value = cmbModifyValue.Text;
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
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["communityID"].Value = cmbModifyValue.SelectedValue.ToString();
                                dgList.SelectedRows[i].Cells["COMMUNITYNAME"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("小区不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "楼号":
                        for (int i = 0; i < dgList.SelectedRows.Count; i++)
                        {
                            dgList.SelectedRows[i].Cells["buildingNO"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "单元":
                        for (int i = 0; i < dgList.SelectedRows.Count; i++)
                        {
                            dgList.SelectedRows[i].Cells["unitNO"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "抄表员":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["meterReaderID"].Value = cmbModifyValue.SelectedValue.ToString();
                                dgList.SelectedRows[i].Cells["meterReaderName"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("抄表员不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "收费员":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["chargerID"].Value = cmbModifyValue.SelectedValue.ToString();
                                dgList.SelectedRows[i].Cells["chargerName"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("收费员不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "户型":
                        if (cmbModifyValue.SelectedIndex > -1)
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["waterUserHouseType"].Value = cmbModifyValue.SelectedIndex + 1;
                            }
                        else
                        {
                            mes.Show("户型填充值不能空,无法完成填充!");
                            return;
                        }
                        break;
                    case "建档类型":
                        if (cmbModifyValue.SelectedIndex > -1)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["createType"].Value = cmbModifyValue.SelectedIndex;
                            }
                        }
                        else
                        {
                            mes.Show("建档类型填充值不能空,无法完成填充!");
                            return;
                        }
                        break;
                    case "水表位置":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["waterMeterPositionName"].Value = cmbModifyValue.Text;
                                dgList.SelectedRows[i].Cells["waterMeterPositionId"].Value = cmbModifyValue.SelectedValue.ToString();
                            }
                        }
                        else
                        {
                            mes.Show("水表位置填充值不能空,无法完成填充!");
                            return;
                        }
                        break;
                    case "口径":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["waterMeterSizeId"].Value = cmbModifyValue.SelectedValue;
                                dgList.SelectedRows[i].Cells["waterMeterSizeValue"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("水表位置不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "水表状态":
                        for (int i = 0; i < dgList.SelectedRows.Count; i++)
                        {
                            dgList.SelectedRows[i].Cells["waterMeterState"].Value = cmbModifyValue.SelectedIndex + 1;
                        }
                        break;
                    case "用水性质":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["waterMeterTypeId"].Value = cmbModifyValue.SelectedValue;
                                dgList.SelectedRows[i].Cells["waterMeterTypeValue"].Value = cmbModifyValue.Text;
                            }
                        }
                        else
                        {
                            mes.Show("水表位置不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "初始读数":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgList.SelectedRows.Count; i++)
                        {
                            dgList.SelectedRows[i].Cells["waterMeterStartNumber"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "通道号":
                        for (int i = 0; i < dgList.SelectedRows.Count; i++)
                        {
                            dgList.SelectedRows[i].Cells["ChannelNO"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "铅封号":
                        for (int i = 0; i < dgList.SelectedRows.Count; i++)
                        {
                            dgList.SelectedRows[i].Cells["waterMeterMode"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "表锁号":
                        for (int i = 0; i < dgList.SelectedRows.Count; i++)
                        {
                            dgList.SelectedRows[i].Cells["WATERMETERLOCKNO"].Value = cmbModifyValue.Text;
                        }
                        break;
                    case "是否倒装":
                        if (cmbModifyValue.SelectedIndex > -1)
                            for (int i = 0; i < dgList.SelectedRows.Count; i++)
                            {
                                dgList.SelectedRows[i].Cells["IsReverse"].Value = cmbModifyValue.SelectedIndex;
                            }
                        else
                        {
                            mes.Show("是否倒装填充值不能为空,无法完成修改!");
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }            //btSearch_Click(null,null);
        }

        private void dgWaterListBatch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "waterUserHouseType")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                        e.Value = "楼房";
                    else if (e.Value.ToString() == "2")
                        e.Value = "平房";
                    else if (e.Value.ToString() == "3")
                        e.Value = "车库";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "createType")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "正式";
                    }
                    else if (e.Value.ToString() == "1")
                        e.Value = "非正式";
                    else if (e.Value.ToString() == "2")
                        e.Value = "基建";
                    else if (e.Value.ToString() == "3")
                        e.Value = "无表";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "waterMeterState")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "正常";
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "注销";
                    else if (e.Value.ToString() == "3")
                        e.Value = "换表";
                    else if (e.Value.ToString() == "4")
                        e.Value = "未启用";
                    else if (e.Value.ToString() == "5")
                        e.Value = "欠费停水";
                    else if (e.Value.ToString() == "6")
                        e.Value = "违章停水";
                    else if (e.Value.ToString() == "7")
                        e.Value = "坏表";
                    else if (e.Value.ToString() == "8")
                        e.Value = "待审核";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "IsReverse")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "否";
                    }
                    else if (e.Value.ToString() == "1")
                        e.Value = "是";
            }
        }

        private void dgWaterListBatch_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgList.CurrentCell.IsInEditMode)
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
                int curntindex = dgList.CurrentRow.Cells.IndexOf(dgList.CurrentCell);
                //获取获取当前选中单元格所在的行序号
                int rowindex = dgList.CurrentRow.Index;
                //MessageBox.Show(curntindex.ToString ());
                for (int j = 0; j < (nnum + 1); j++)
                {
                    for (int colIndex = 0; colIndex < (tnum + 1); colIndex++)
                    {
                        if (!dgList.Columns[colIndex + curntindex].Visible)
                        {
                            continue;
                        }
                        if (!dgList.Rows[j + rowindex].Cells[colIndex + curntindex].ReadOnly)
                        {
                            dgList.Rows[j + rowindex].Cells[colIndex + curntindex].Value = data[j, colIndex];
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

        private void dgList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgList.CurrentCell == null)
                return;
            if (dgList.CurrentCell.RowIndex < 0 || dgList.CurrentCell.ColumnIndex < 0)
                return;
            try
            {
                if (dgList.Columns[dgList.CurrentCell.ColumnIndex].Name == "waterMeterSerialNumber")
                {
                    Rectangle rect = dgList.GetCellDisplayRectangle(dgList.CurrentCell.ColumnIndex, dgList.CurrentCell.RowIndex, false);
                    //string strValue = dgList.CurrentCell.Value.ToString();
                    //cmbWaterMeter.Text = strValue;
                    cmbWaterMeter.Visible = true;
                    cmbWaterMeter.Left = rect.Left;
                    cmbWaterMeter.Top = rect.Top;
                    cmbWaterMeter.Width = rect.Width;
                    cmbWaterMeter.Height = rect.Height;
                    object obj = dgList.CurrentCell.FormattedValue;
                    if (obj != null || obj != DBNull.Value)
                    {
                        DataRow[] dr = dtMeterCanSelected.Select("waterMeterSerialNumber='" + obj.ToString() + "'");
                        if (dr.Length > 0)
                            cmbWaterMeter.Text = obj.ToString();
                    }
                }
                else
                {
                    cmbWaterMeter.Visible = false;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
        }

        private void 续前行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentCell.ColumnIndex < 0 || dgList.CurrentCell.RowIndex < 1)
                return;
            int intRowIndex = dgList.CurrentCell.RowIndex;
            int intColumsIndex = dgList.CurrentCell.ColumnIndex;
            object obj = dgList.Rows[intRowIndex - 1].Cells["waterMeterSerialNumber"].Value;

            int intStartIndex = 0;
            if (Information.IsNumeric(obj))
            {
                for (int i = intRowIndex; i < dgList.Rows.Count; i++)
                {
                    intStartIndex++;
                    Int64 intWaterMeterSeialNumber = Convert.ToInt64(obj) + intStartIndex;
                    bool isExist = false;
                    DataRow[] dr = dtMeterCanSelected.Select("waterMeterSerialNumber='" + intWaterMeterSeialNumber.ToString() + "'");
                    if (dr.Length > 0)
                        isExist = true;
                    if (isExist)
                    {
                        dgList.Rows[i].Cells["waterMeterSerialNumber"].Value = intWaterMeterSeialNumber;
                    }
                    else
                    {
                        mes.Show("已自动增长填充到第 " + i.ToString() + "行");
                        break;
                    }
                }
            }
            else
            {
                mes.Show("检测到当前行水表编号非数字，无法使用自动增长填充功能!");
                return;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                object obj = dgList.Rows[i].Cells["waterUserAddress"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行地址不能为空");
                    return;
                }
                obj = dgList.Rows[i].Cells["AreaNO"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行区号不能为空");
                    return;
                }
                obj = dgList.Rows[i].Cells["PianNO"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行片号不能为空");
                    return;
                }
                obj = dgList.Rows[i].Cells["DuanNO"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行段号不能为空");
                    return;
                }
                obj = dgList.Rows[i].Cells["ordernumber"].Value;
                if (!Information.IsNumeric(obj))
                {
                    mes.Show("第 " + (i + 1) + " 行顺序号不正确");
                    return;
                }
                obj = dgList.Rows[i].Cells["meterReaderID"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行抄表员不能为空");
                    return;
                }
                obj = dgList.Rows[i].Cells["chargerID"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行收费员不能为空");
                    return;
                }
                obj = dgList.Rows[i].Cells["waterMeterPositionId"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行水表位置不能为空");
                    return;
                }
                obj = dgList.Rows[i].Cells["waterUserTypeId"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行用户类别不能为空");
                    return;
                }
                obj = dgList.Rows[i].Cells["waterMeterSerialNumber"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行水表出厂编号不能为空");
                    return;
                }
                obj = dgList.Rows[i].Cells["WaterMeterState"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行水表状态不能为空");
                    return;
                }

                string strWaterMeterStartNumber = "";
                obj = dgList.Rows[i].Cells["waterMeterSerialNumber"].FormattedValue;
                if (!Information.IsNumeric(obj))
                {
                    mes.Show("第 " + (i + 1) + " 行水表初始读数格式不正确");
                    return;
                }
                strWaterMeterStartNumber = obj.ToString();

                obj = dgList.Rows[i].Cells["waterMeterTypeId"].Value;
                if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                {
                    mes.Show("第 " + (i + 1) + " 行用水性质不能为空");
                    return;
                }

                DataRow[] dr = dtMeterCanSelected.Select("waterMeterSerialNumber='" + strWaterMeterStartNumber + "'");
                if (dr.Length == 0)
                {
                    mes.Show("第 " + (i + 1) + " 行水表编号'" + strWaterMeterStartNumber + "'不在表站出库列表中为空");
                    return;
                }
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void 顺序续前行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentCell.ColumnIndex < 0 || dgList.CurrentCell.RowIndex < 1)
                return;
            int intRowIndex = dgList.CurrentCell.RowIndex;
            object obj = dgList.Rows[intRowIndex - 1].Cells["ordernumber"].Value;

            int intStartIndex = 0;
            if (Information.IsNumeric(obj))
            {
                for (int i = intRowIndex; i < dgList.Rows.Count; i++)
                {
                    intStartIndex++;
                    Int64 intNumber = Convert.ToInt64(obj) + intStartIndex;
                    dgList.Rows[i].Cells["ordernumber"].Value = intNumber;
                }
            }
            else
            {
                mes.Show("检测到当前行水表编号非数字，无法使用自动增长填充功能!");
                return;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                string strWaterUserID = "";
                string strWaterMeterID = "";

                if (e.Cancel)
                    break;

                object objWaterUserID = dgList.Rows[i].Cells["waterUserId"].Value;
                if (objWaterUserID != null && objWaterUserID != DBNull.Value && objWaterUserID.ToString() != "")
                {
                    strWaterUserID = objWaterUserID.ToString();
                }
                else
                    strWaterUserID = GETTABLEID.GetTableID("", "WATERUSER");

                strWaterMeterID = strWaterUserID + "01";

                labState.Text = "正在写入第 " + (i + 1).ToString() + "行";

                try
                {
                    Hashtable hstb = new Hashtable();
                    for (int j = 0; j < dgList.Columns.Count; j++)
                    {
                        object objValue = dgList.Rows[i].Cells[j].Value;
                        hstb[dgList.Columns[j].Name.ToUpper()] = objValue;
                        hstb["createType".ToUpper()] = dgList.Rows[i].Cells["createType"].FormattedValue;
                    }
                    if (hstb.Count > 0)
                    {
                        StringBuilder strUpdateWaterUser = new StringBuilder();
                        strUpdateWaterUser.Append("BEGIN TRAN \n");
                        strUpdateWaterUser.Append("DECLARE @COUNT INT=0 \n");
                        strUpdateWaterUser.Append("SELECT @COUNT=COUNT(*) FROM WATERUSER WHERE WATERUSERID=@WATERUSERID \n");
                        strUpdateWaterUser.Append("IF @COUNT>0 \n");
                        strUpdateWaterUser.Append("BEGIN \n");
                        strUpdateWaterUser.Append("DELETE FROM WATERUSER WHERE WATERUSERID=@WATERUSERID \n");
                        strUpdateWaterUser.Append("DELETE FROM WATERMETER WHERE WATERUSERID=@WATERUSERID \n");
                        strUpdateWaterUser.Append("END \n");

                        strUpdateWaterUser.Append("UPDATE Meter SET waterMeterId=@waterMeterId,waterMeterStartNumber=@waterMeterStartNumber,waterMeterState=@waterMeterState,");
                        strUpdateWaterUser.Append("waterUserId=@waterUserId,waterMeterNo=@waterMeterNo,IsReverse=@IsReverse,STARTUSEDATETIME=GETDATE(),CreateDate=GETDATE() \n");
                        strUpdateWaterUser.Append(" WHERE waterMeterSerialNumber=@waterMeterSerialNumber \n");

                        strUpdateWaterUser.Append("UPDATE Meter_Groupeople_Detail SET waterUserId=@waterUserId,waterUserNO=@waterUserNO,waterUserName=@waterUserName,");
                        strUpdateWaterUser.Append("waterUserAddress=@waterUserAddress,waterMeterPositionName=@waterMeterPositionName,");
                        strUpdateWaterUser.Append("waterMeterPositionId=@waterMeterPositionId,waterUserTypeId=@waterUserTypeId,waterUserHouseTypeID=@waterUserHouseTypeID,");
                        strUpdateWaterUser.Append("waterMeterSizeId=@waterMeterSizeId,waterMeterTypeId=@waterMeterTypeId,waterMeterSerialNumber=@waterMeterSerialNumber,");
                        strUpdateWaterUser.Append("ordernumber=@ordernumber,COMMUNITYID=@COMMUNITYID,BuildingNO=@BuildingNO,UnitNO=@UnitNO,CreateType=@CreateType,");
                        strUpdateWaterUser.Append("meterReaderID=@meterReaderID,chargerID=@chargerID,PianNO=@PianNO,DuanNO=@DuanNO,AreaNO=@AreaNO,");
                        strUpdateWaterUser.Append("waterUserPeopleCount=@waterUserPeopleCount,WaterMeterState=@WaterMeterState,waterMeterMode=@waterMeterMode,");
                        strUpdateWaterUser.Append("WaterMeterLockNO=@WaterMeterLockNO,IsReverse=@IsReverse,WaterMeterStartNumber=@WaterMeterStartNumber,");
                        strUpdateWaterUser.Append("meterReaderName=@meterReaderName,chargerName=@chargerName,COMMUNITYNAME=@COMMUNITYNAME,");
                        strUpdateWaterUser.Append("waterUserTypeName=@waterUserTypeName,waterMeterSizeValue=@waterMeterSizeValue,waterMeterTypeValue=@waterMeterTypeValue,");
                        strUpdateWaterUser.Append("waterUserTelphoneNO=@waterUserTelphoneNO,CreateDate=GETDATE(),operatorID=@operatorID,operatorName=@operatorName,");
                        strUpdateWaterUser.Append("ChannelNO=@ChannelNO WHERE PeopleID=@PeopleID \n");

                        strUpdateWaterUser.Append("INSERT INTO waterMeter(waterMeterId,waterMeterNo,waterMeterStartNumber,waterMeterPositionName,waterMeterPositionId,waterMeterState,");
                        strUpdateWaterUser.Append("waterMeterSizeId,waterMeterTypeId,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,WATERMETERLOCKNO,");
                        strUpdateWaterUser.Append("waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,waterUserId,STARTUSEDATETIME,");
                        strUpdateWaterUser.Append("IsReverse,ChannelNO) \n");
                        strUpdateWaterUser.Append("SELECT waterMeterId,waterMeterNo,MGD.waterMeterStartNumber,MGD.waterMeterPositionName,MGD.waterMeterPositionId,MGD.waterMeterState,");
                        strUpdateWaterUser.Append("MT.waterMeterSizeId,MGD.waterMeterTypeId,waterMeterProduct,MGD.waterMeterSerialNumber,MGD.waterMeterMode,MGD.WATERMETERLOCKNO,");
                        strUpdateWaterUser.Append("waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,MGD.waterUserId,GETDATE(),");
                        strUpdateWaterUser.Append("MGD.IsReverse,ChannelNO FROM Meter_Groupeople_Detail MGD INNER JOIN Meter MT \n");
                        strUpdateWaterUser.Append("ON MGD.waterMeterSerialNumber=MT.waterMeterSerialNumber AND MGD.waterMeterSerialNumber=@waterMeterSerialNumber \n");

                        strUpdateWaterUser.Append("INSERT INTO waterUser(waterUserId,waterUserNO,waterUserName,waterUserTelphoneNO,waterUserAddress,waterUserPeopleCount,areaNO,");
                        strUpdateWaterUser.Append("pianNO,duanNO,communityID,buildingNO,unitNO,meterReaderID,meterReaderName,chargerID,chargerName,waterUserTypeId,");
                        strUpdateWaterUser.Append("operatorName,waterUserHouseType,createType,ordernumber,chargeType,waterUserCreateDate) \n");
                        strUpdateWaterUser.Append("VALUES(@waterUserId,@waterUserNO,@waterUserName,@waterUserTelphoneNO,@waterUserAddress,@waterUserPeopleCount,@areaNO,");
                        strUpdateWaterUser.Append("@pianNO,@duanNO,@communityID,@buildingNO,@unitNO,@meterReaderID,@meterReaderName,@chargerID,@chargerName,@waterUserTypeId,");
                        strUpdateWaterUser.Append("@operatorName,@waterUserHouseTypeID,@createType,@ordernumber,'1',GETDATE()) \n");

                        strUpdateWaterUser.Append(" IF (@@ERROR<>0) \n ");
                        strUpdateWaterUser.Append(" ROLLBACK TRAN \n");
                        strUpdateWaterUser.Append(" ELSE \n");
                        strUpdateWaterUser.Append(" COMMIT TRAN ");

                        SqlParameter[] strPare = new SqlParameter[]
                        {
                     new SqlParameter("@waterMeterId",SqlDbType.VarChar,30),
                     new SqlParameter("@waterMeterNo",SqlDbType.VarChar,30),
                     new SqlParameter("@waterUserId",SqlDbType.VarChar,30),
                     new SqlParameter("@waterUserNO",SqlDbType.VarChar,30),
                     new SqlParameter("@waterUserName",SqlDbType.VarChar,70),
                     new SqlParameter("@waterUserAddress",SqlDbType.VarChar,100),
                     new SqlParameter("@waterMeterPositionName",SqlDbType.VarChar,30),
                     new SqlParameter("@waterMeterPositionId",SqlDbType.VarChar,30),
                     new SqlParameter("@waterUserTypeId",SqlDbType.VarChar,30),
                     new SqlParameter("@waterUserHouseTypeID",SqlDbType.VarChar,30),
                     new SqlParameter("@waterMeterSizeId",SqlDbType.VarChar,30),
                     new SqlParameter("@waterMeterTypeId",SqlDbType.VarChar,30),
                     new SqlParameter("@waterMeterSerialNumber",SqlDbType.VarChar,30),
                     new SqlParameter("@ordernumber",SqlDbType.Int),
                     new SqlParameter("@COMMUNITYID",SqlDbType.VarChar,30),
                     new SqlParameter("@BuildingNO", SqlDbType.VarChar,30),
                     new SqlParameter("@UnitNO",SqlDbType.VarChar,30),
                     new SqlParameter("@CreateType",SqlDbType.VarChar,30),
                     new SqlParameter("@meterReaderID",SqlDbType.VarChar,30),
                     new SqlParameter("@chargerID",SqlDbType.VarChar,30),
                     new SqlParameter("@PianNO",SqlDbType.VarChar,30),
                     new SqlParameter("@DuanNO",SqlDbType.VarChar,30),
                     new SqlParameter("@AreaNO", SqlDbType.VarChar,30),
                     new SqlParameter("@waterUserPeopleCount",SqlDbType.Int),
                     new SqlParameter("@WaterMeterState",SqlDbType.Int),
                     new SqlParameter("@waterMeterMode",SqlDbType.VarChar,30),
                     new SqlParameter("@WaterMeterLockNO",SqlDbType.VarChar,30),
                     new SqlParameter("@IsReverse",SqlDbType.VarChar,30),
                     new SqlParameter("@WaterMeterStartNumber",SqlDbType.Int),
                     new SqlParameter("@meterReaderName",SqlDbType.VarChar,30),
                     new SqlParameter("@chargerName",SqlDbType.VarChar,30),
                     new SqlParameter("@COMMUNITYNAME",SqlDbType.VarChar,30),
                     new SqlParameter("@waterUserTypeName",SqlDbType.VarChar,30),
                     new SqlParameter("@waterMeterSizeValue",SqlDbType.VarChar,30),
                     new SqlParameter("@waterMeterTypeValue",SqlDbType.VarChar,30),
                     new SqlParameter("@waterUserTelphoneNO",SqlDbType.VarChar,30),
                     new SqlParameter("@waterMeterProduct",SqlDbType.VarChar,30),
                     new SqlParameter("@ChannelNO",SqlDbType.VarChar,30),
                     new SqlParameter("@operatorName",SqlDbType.VarChar,30),
                     new SqlParameter("@operatorID",SqlDbType.VarChar,30),
                     new SqlParameter("@PeopleID",SqlDbType.UniqueIdentifier)
                        };
                        strPare[0].Value = strWaterMeterID;
                        strPare[1].Value = strWaterMeterID;
                        strPare[2].Value = strWaterUserID;
                        strPare[3].Value = strWaterUserID;
                        strPare[4].Value = hstb["WATERUSERNAME"];
                        strPare[5].Value = hstb["WATERUSERADDRESS"];
                        strPare[6].Value = hstb["waterMeterPositionName".ToUpper()];
                        strPare[7].Value = hstb["waterMeterPositionId".ToUpper()];
                        strPare[8].Value = hstb["waterUserTypeId".ToUpper()];
                        strPare[9].Value = hstb["waterUserHouseType".ToUpper()];
                        strPare[10].Value = hstb["waterMeterSizeId".ToUpper()];
                        strPare[11].Value = hstb["waterMeterTypeId".ToUpper()];
                        strPare[12].Value = hstb["waterMeterSerialNumber".ToUpper()];
                        strPare[13].Value = hstb["ordernumber".ToUpper()];
                        strPare[14].Value = hstb["COMMUNITYID".ToUpper()];
                        strPare[15].Value = hstb["BuildingNO".ToUpper()];
                        strPare[16].Value = hstb["UnitNO".ToUpper()];
                        strPare[17].Value = hstb["CreateType".ToUpper()];
                        strPare[18].Value = hstb["meterReaderID".ToUpper()];
                        strPare[19].Value = hstb["chargerID".ToUpper()];
                        strPare[20].Value = hstb["PianNO".ToUpper()];
                        strPare[21].Value = hstb["DuanNO".ToUpper()];
                        strPare[22].Value = hstb["AreaNO".ToUpper()];
                        strPare[23].Value = hstb["waterUserPeopleCount".ToUpper()];
                        strPare[24].Value = hstb["WaterMeterState".ToUpper()];
                        strPare[25].Value = hstb["waterMeterMode".ToUpper()];
                        strPare[26].Value = hstb["WaterMeterLockNO".ToUpper()];
                        strPare[27].Value = hstb["IsReverse".ToUpper()];
                        strPare[28].Value = hstb["WaterMeterStartNumber".ToUpper()];
                        strPare[29].Value = hstb["meterReaderName".ToUpper()];
                        strPare[30].Value = hstb["chargerName".ToUpper()];
                        strPare[31].Value = hstb["COMMUNITYNAME".ToUpper()];
                        strPare[32].Value = hstb["waterUserTypeName".ToUpper()];
                        strPare[33].Value = hstb["waterMeterSizeValue".ToUpper()];
                        strPare[34].Value = hstb["waterMeterTypeValue".ToUpper()];
                        strPare[35].Value = hstb["waterUserTelphoneNO".ToUpper()];
                        strPare[36].Value = hstb["waterMeterProduct".ToUpper()];
                        strPare[37].Value = hstb["ChannelNO".ToUpper()];
                        strPare[38].Value = strRealName;
                        strPare[39].Value = strLogID;
                        strPare[40].Value = hstb["PeopleID".ToUpper()];

                        int intRows = new SqlServerHelper().UpdateByHashtable(strUpdateWaterUser.ToString(), strPare);

                        if (intRows == 0)
                        {
                            mes.Show("第 " + (i + 1).ToString() + " 行 保存失败,请重试!");
                            labState.Text = "第 " + (i + 1).ToString() + " 行 保存失败,请重试!";
                            return;
                        }
                        dgList.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                        dgList.Rows[i].Cells["waterUserNO"].Value = strWaterUserID;
                        dgList.Rows[i].Cells["waterUserId"].Value = strWaterUserID;
                    }
                }
                catch (Exception ex)
                {
                    labState.Text = "写入第 " + (i + 1).ToString() + " 行 保存失败:" + ex.Message;
                    mes.Show("写入第 " + (i + 1).ToString() + " 行 保存失败:" + ex.Message);
                    log.Write(ex.ToString(), MsgType.Error);
                    return;
                }
            }
            labState.Text = "增户完成!";
        }
    }
}
