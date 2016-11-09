using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BLL;
using MODEL;
using BASEFUNCTION;
using System.Threading;

namespace WATERFEEMANAGE
{
    public partial class frmWaterMeterReadRemitCharge : DockContentEx
    {
        public frmWaterMeterReadRemitCharge()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLAREA BLLAREA = new BLLAREA();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLWATERFEEREMIT BLLWATERFEEREMIT = new BLLWATERFEEREMIT();

        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLoginID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strLoginName = "";

        //审核颜色、已收费颜色、已保存颜色，剩余待用：用户停用颜色、水表停用及报废颜色、默认的cell颜色、cell只读颜色。
        Color colorChecked = Color.Green, colorCharged = Color.Red,colorSave=Color.Blue, colorWaterUserStop = Color.Goldenrod, colorWaterMeterStop = Color.Yellow,colorCellDefault=SystemColors.Window,colorCellReadOnly=SystemColors.Control;
        private void frmModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            dgWaterList.AutoGenerateColumns = false;
            dgWaterList.ShowCellToolTips = true;

            //dgWaterList.MouseWheel += new MouseEventHandler(dgWaterList_MouseWheel);//加入鼠标滚动事件

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strLoginName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            //保存默认的单元格颜色
            colorCellDefault = dgWaterList.DefaultCellStyle.BackColor;

            //获取当前时间的月份和年份
            DateTime dtNow = mes.GetDatetimeNow();
            cmbWaterFeeYear.SelectedIndex = 0;
            cmbWaterFeeMonth.SelectedIndex = 0;

            BindWaterUserArea(cmbWaterUserArea);
            BindWaterMeterReader(cmbWaterUserMeterReader);

            BindWaterUserType(cmbWaterUserType);
            BindWaterMeterType();

            for (int i = 0; i < dgWaterList.Columns.Count; i++)
            {
                if (dgWaterList.Columns[i].Name != "REMITWATERFEE" && dgWaterList.Columns[i].Name != "REMITEXTRAFEE" && dgWaterList.Columns[i].Name != "REMITOVERDUE")
                    dgWaterList.Columns[i].ReadOnly = true;
                else
                {
                    dgWaterList.Columns[i].ReadOnly = false;
                    dgWaterList.Columns[i].DefaultCellStyle.BackColor = Color.Coral;
                }
            }
        }

        void dgWaterList_MouseWheel(object sender, MouseEventArgs e)
        {
            int rowIndex = this.dgWaterList.CurrentRow.Index;
            this.dgWaterList.ClearSelection();

            if (e.Delta > 0)
            {
                if (rowIndex > 0)
                {
                    this.dgWaterList.CurrentCell = this.dgWaterList.Rows[rowIndex - 1].Cells["waterMeterNo"];
                    this.dgWaterList.Rows[rowIndex - 1].Selected = true;
                }
                else
                {
                    this.dgWaterList.CurrentCell = this.dgWaterList.Rows[rowIndex].Cells["waterMeterNo"];
                    this.dgWaterList.Rows[rowIndex].Selected = true;
                }
            }
            else
            {
                if (rowIndex < this.dgWaterList.Rows.Count - 1)
                {
                    this.dgWaterList.CurrentCell = this.dgWaterList.Rows[rowIndex + 1].Cells["waterMeterNo"];
                    this.dgWaterList.Rows[rowIndex + 1].Selected = true;
                }
                else
                {
                    this.dgWaterList.CurrentCell = this.dgWaterList.Rows[rowIndex].Cells["waterMeterNo"];
                    this.dgWaterList.Rows[rowIndex].Selected = true;
                }
            }
        }

        /// <summary>
        /// 绑定用户区域
        /// </summary>
        /// <param name="cmb"></param>
        private void BindWaterUserArea(ComboBox cmb)
        {
            DataTable dt = BLLAREA.Query(" AND areaId<>'0000'");
            DataRow dr = dt.NewRow();
            dr["areaName"] = "";
            dr["areaId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "areaName";
            cmb.ValueMember = "areaId";
        }
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        /// <param name="cmb"></param>
        private void BindWaterMeterReader(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是'");
            DataRow dr = dt.NewRow();
            dr["userName"] = "";
            dr["loginId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "userName";
            cmb.ValueMember = "loginId";
        }
        /// <summary>
        /// 绑定用户类型
        /// </summary>
        /// <param name="cmb"></param>
        private void BindWaterUserType(ComboBox cmb)
        {
            DataTable dt = BLLwaterUserType.Query("");
            DataRow dr = dt.NewRow();
            dr["waterUserTypeName"] = "";
            dr["waterUserTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterUserTypeName";
            cmb.ValueMember = "waterUserTypeId";
        }

        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType()
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "";
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbWaterMeterType.DataSource = dt;
            cmbWaterMeterType.DisplayMember = "waterMeterTypeValue";
            cmbWaterMeterType.ValueMember = "waterMeterTypeId";
        }

        /// <summary>
        /// 存储查询到的用户表
        /// </summary>
        DataTable dtUserList = new DataTable();
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        private string QueryWaterUser()
        {
            string strFilter = "";

            if (txtWaterUserNOSearch.Text.Trim() != "")
            {
                if (txtWaterUserNOSearch.Text.Length < 6)
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                else
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
            }

            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

            if (txtAddress.Text.Trim() != "")
                strFilter += " AND waterUserNO='" + txtAddress.Text + "'";

            if (cmbWaterUserArea.SelectedValue != null && cmbWaterUserArea.SelectedValue != DBNull.Value)
                strFilter += " AND areaId='" + cmbWaterUserArea.SelectedValue.ToString() + "'";

            if (cmbWaterUserMeterReader.SelectedValue != null && cmbWaterUserMeterReader.SelectedValue != DBNull.Value)
                strFilter += " AND loginId='" + cmbWaterUserMeterReader.SelectedValue.ToString() + "'";

            if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

            if (cmbWaterUserType.SelectedValue != null && cmbWaterUserType.SelectedValue != DBNull.Value)
                strFilter += " AND waterUserTypeId='" + cmbWaterUserType.SelectedValue.ToString() + "'";

            return strFilter;
        }
        private void LoadData()
        {
            txtMemo.Clear();
            dtUserList = BLLwaterUser.QueryUser(QueryWaterUser());
            if (dtUserList.Rows.Count > 0)
            {
                object objWaterUserID = dtUserList.Rows[0]["waterUserId"];
                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                {
                    txtWaterUserID.Text = objWaterUserID.ToString();


                    #region 生成用户信息
                    object objWaterUserMes = dtUserList.Rows[0]["waterUserNO"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserNO.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserName"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserName.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterUserTelphoneNO"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserPhone.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["waterPhone"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        if (txtWaterUserPhone.Text != "")
                            txtWaterUserPhone.Text += ";" + objWaterUserMes.ToString();
                        else
                            txtWaterUserPhone.Text = objWaterUserMes.ToString();
                    }

                    object objWaterUser = dtUserList.Rows[0]["areaNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtAreaNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtAreaNO.Clear();
                    objWaterUser = dtUserList.Rows[0]["pianNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtPianNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtPianNO.Clear();
                    objWaterUser = dtUserList.Rows[0]["duanNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtDuanNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtDuanNO.Clear();
                    objWaterUser = dtUserList.Rows[0]["COMMUNITYNAME"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtCommunity.Text = objWaterUser.ToString();
                    }
                    else
                        txtCommunity.Clear();
                    objWaterUser = dtUserList.Rows[0]["buildingNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtBuildingNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtBuildingNO.Clear();
                    objWaterUser = dtUserList.Rows[0]["unitNO"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtUnitNO.Text = objWaterUser.ToString();
                    }
                    else
                        txtUnitNO.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["waterUserAddress"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserAddress.Text = objWaterUserMes.ToString();
                    }
                    objWaterUser = dtUserList.Rows[0]["createType"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtCreateType.Text = objWaterUser.ToString();
                    }
                    else
                        txtCreateType.Clear();

                    objWaterUser = dtUserList.Rows[0]["meterReaderName"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtMeterReader.Text = objWaterUser.ToString();
                    }
                    else
                        txtMeterReader.Clear();
                    objWaterUser = dtUserList.Rows[0]["chargerName"];
                    if (objWaterUser != null && objWaterUser != DBNull.Value)
                    {
                        txtCharger.Text = objWaterUser.ToString();
                    }
                    else
                        txtCharger.Clear();

                    objWaterUserMes = dtUserList.Rows[0]["waterUserHouseTypeS"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserHouseType.Text = objWaterUserMes.ToString();
                    }

                    objWaterUserMes = dtUserList.Rows[0]["chargeType"];
                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                    {
                        txtWaterUserChargetype.Text = objWaterUserMes.ToString();
                    }
                    #endregion

                    btCharge.Enabled = false;
                    btCancel.Enabled = false;

                    #region 生成欠费信息
                    string strFilter = "";

                    if (cmbWaterFeeYear.Text != "")
                        strFilter += " AND readMeterRecordYear='" + cmbWaterFeeYear.Text + "'";

                    if (cmbWaterFeeMonth.Text != "")
                        strFilter += " AND readMeterRecordMonth='" + cmbWaterFeeMonth.Text + "'";

                    //只查询未收费的包含滞纳金的抄表记录
                    DataTable dtWaterMeterReadNotCharge = BLLreadMeterRecord.QueryContainOverDue(strFilter + " AND waterUserId='" + objWaterUserID.ToString() + "' AND chargeState='1'  ORDER BY readMeterRecordYear,readMeterRecordMonth");
                    dgWaterList.DataSource = dtWaterMeterReadNotCharge;
                    #endregion

                    if (dgWaterList.Rows.Count == 0)
                    {
                        mes.Show("未找到欠费信息!");
                        txtWaterUserNOSearch.SelectAll();
                        txtWaterUserNOSearch.Focus();
                    }
                    else
                    {
                        btCharge.Enabled = true;

                        #region 获取减免记录
                        for (int i = 0; i < dgWaterList.Rows.Count; i++)
                        {
                            dgWaterList.Rows[i].Cells["REMITWATERFEEEND"].Value = dgWaterList.Rows[i].Cells["waterTotalCharge"].Value;
                            dgWaterList.Rows[i].Cells["REMITOVERDUEEND"].Value = dgWaterList.Rows[i].Cells["OVERDUEMONEY"].Value;
                            dgWaterList.Rows[i].Cells["REMITEXTRAFEEEND"].Value = dgWaterList.Rows[i].Cells["extraTotalCharge"].Value;

                            #region 生成减免信息
                            object objreadMeterRecordId = dgWaterList.Rows[i].Cells["readMeterRecordId"].Value;
                            if (objreadMeterRecordId != null && objreadMeterRecordId != DBNull.Value)
                            {
                                string strChargeRemitFilter = " AND REMITCANCEL='0' AND READMETERRECORDID='" + objreadMeterRecordId.ToString() + "'";//查询未作废的减免记录
                                DataTable dtChargeRemit = BLLWATERFEEREMIT.QueryView(strChargeRemitFilter);
                                if (dtChargeRemit.Rows.Count > 0)
                                {
                                    btCancel.Enabled = true;

                                    //不能直接绑定，如果绑定了就查询不到未减免的其他水表信息了
                                    //dgWaterList.DataSource = dtChargeRemit;

                                    dgWaterList.Rows[i].Cells["WATERFEEREMITID"].Value = dtChargeRemit.Rows[0]["WATERFEEREMITID"];

                                    dgWaterList.Rows[i].Cells["REMITWATERFEE"].Value = dtChargeRemit.Rows[0]["REMITWATERFEE"];
                                    dgWaterList.Rows[i].Cells["REMITWATERFEEEND"].Value = dtChargeRemit.Rows[0]["REMITWATERFEEEND"];

                                    dgWaterList.Rows[i].Cells["REMITEXTRAFEE"].Value = dtChargeRemit.Rows[0]["REMITEXTRAFEE"];
                                    dgWaterList.Rows[i].Cells["REMITEXTRAFEEEND"].Value = dtChargeRemit.Rows[0]["REMITEXTRAFEEEND"];

                                    dgWaterList.Rows[i].Cells["REMITOVERDUE"].Value = dtChargeRemit.Rows[0]["REMITOVERDUE"];
                                    dgWaterList.Rows[i].Cells["REMITOVERDUEEND"].Value = dtChargeRemit.Rows[0]["REMITOVERDUEEND"];

                                    //减免原因
                                    object objREMITWATERFEE = dtChargeRemit.Rows[0]["MEMO"];
                                    txtMemo.Text = objREMITWATERFEE.ToString();
                                }
                            }
                            #endregion
                            //}
                        }
                        #endregion
                    }
                }
            }
            else
            {
                dgWaterList.DataSource = null;
                mes.Show("未找到用户信息!");
                txtWaterUserNOSearch.Focus();
                return;
            }
        }
        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(null, null);
            }
        }

        private void dgWaterList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgWaterList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgWaterList.Rows.Count <= 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "avePrice")
            {
                object objToolTipAvePrice = dgWaterList.Rows[e.RowIndex].Cells["avePriceDescribe"].Value;
                if (objToolTipAvePrice != null && objToolTipAvePrice != DBNull.Value)
                    dgWaterList.Rows[e.RowIndex].Cells["avePrice"].ToolTipText = objToolTipAvePrice.ToString();
            }

            if (dgWaterList.Columns[e.ColumnIndex].Name == "totalNumber")
            {
                object objToolTip = dgWaterList.Rows[e.RowIndex].Cells["totalNumberDescribe"].Value;
                if (objToolTip != null && objToolTip != DBNull.Value)
                    dgWaterList.Rows[e.RowIndex].Cells["totalNumber"].ToolTipText = objToolTip.ToString();
            }
        }


        private void toolSave_Click(object sender, EventArgs e)
        {
            dgWaterList.EndEdit();
            int intCheckedCount = 0;
            for (int i = 0; i < dgWaterList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chkcell = dgWaterList.Rows[i].Cells["checkState"] as DataGridViewCheckBoxCell;
                if (chkcell.Value.ToString() == "True")
                {
                    intCheckedCount = intCheckedCount + 1;
                }
            }
            if (intCheckedCount == 0)
                return;
            for (int i = dgWaterList.Rows.Count-1; i >=0; i--)
            {
                DataGridViewCheckBoxCell chkcell = dgWaterList.Rows[i].Cells["checkState"] as DataGridViewCheckBoxCell;
                if (chkcell.Value.ToString() == "True")
                {
                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                    MODELreadMeterRecord.checkState = "1";
                    MODELreadMeterRecord.readMeterRecordId = dgWaterList.Rows[i].Cells["readMeterRecordId"].Value.ToString();
                    if (BLLreadMeterRecord.UpdateCheckState(MODELreadMeterRecord))
                    {
                        dgWaterList.Rows.Remove(dgWaterList.Rows[i]);
                    }
                    else
                    {
                        mes.Show("第 " + (i + 1).ToString() + " 行抄表审核状态修改失败!");
                        return;
                    }
                }
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgWaterList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "readMeterRecordMonth")
            {
                if (e.Value != null || e.Value != DBNull.Value)
                    e.Value = e.Value.ToString().PadLeft(2,'0');
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "checkState")
            {
                if (e.Value != null || e.Value != DBNull.Value)
                {
                    if (e.Value.ToString() == "0")
                        e.Value = "未审核";
                    else if (e.Value.ToString() == "1")
                        e.Value = "已审核";

                }
                else
                    e.Value = "未审核";
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "waterUserHouseType")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "楼房";
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "平房";
            }
        }

        private void btCharge_Click(object sender, EventArgs e)
        {
            if (dgWaterList.Rows.Count == 0)
            {
                mes.Show("未找到要减免的水表信息!");
                btCharge.Enabled = false;
                return;
            }
            if (txtMemo.Text.Trim() == "")
            {
                mes.Show("请输入减免原因!");
                txtMemo.Focus();
                return;
            }
            dgWaterList.EndEdit();
            try
            {
                for (int i = 0; i < dgWaterList.Rows.Count; i++)
                {
                    //获取每一行的 减免水费ID 用来判断是修改还是添加。
                    string strRemitID = "";
                    object objRemitID = dgWaterList.Rows[i].Cells["WATERFEEREMITID"].Value;
                    if (objRemitID != null && objRemitID != DBNull.Value)
                    {
                        strRemitID = objRemitID.ToString();
                    }

                    //水表编号
                    string strWaterMeterNO = "";
                    object objWaterMeterNO = dgWaterList.Rows[i].Cells["waterMeterNo"].Value;
                    if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                    {
                        strWaterMeterNO = objWaterMeterNO.ToString();
                    }

                    object objRemit = dgWaterList.Rows[i].Cells["REMITWATERFEE"].Value;
                    if (!Information.IsNumeric(objRemit))
                        dgWaterList.Rows[i].Cells["REMITWATERFEE"].Value = 0;

                    objRemit = dgWaterList.Rows[i].Cells["REMITEXTRAFEE"].Value;
                    if (!Information.IsNumeric(objRemit))
                        dgWaterList.Rows[i].Cells["REMITEXTRAFEE"].Value = 0;

                    objRemit = dgWaterList.Rows[i].Cells["REMITOVERDUE"].Value;
                    if (!Information.IsNumeric(objRemit))
                        dgWaterList.Rows[i].Cells["REMITOVERDUE"].Value = 0;

                    object objOldwaterTotalFee = dgWaterList.Rows[i].Cells["waterTotalCharge"].Value;
                    object objOldExtraTotalCharge = dgWaterList.Rows[i].Cells["extraTotalCharge"].Value;
                    object objOldOVERDUEMONEY = dgWaterList.Rows[i].Cells["OVERDUEMONEY"].Value;

                    object objNewwaterTotalFee = dgWaterList.Rows[i].Cells["REMITWATERFEEEND"].Value;
                    object objNewExtraTotalCharge = dgWaterList.Rows[i].Cells["REMITEXTRAFEEEND"].Value;
                    object objNewOVERDUEMONEY = dgWaterList.Rows[i].Cells["REMITOVERDUEEND"].Value;

                    decimal decOld = (Information.IsNumeric(objOldwaterTotalFee) ? Convert.ToDecimal(objOldwaterTotalFee) : 0)
                    + (Information.IsNumeric(objOldExtraTotalCharge) ? Convert.ToDecimal(objOldExtraTotalCharge) : 0)
                    + (Information.IsNumeric(objOldOVERDUEMONEY) ? Convert.ToDecimal(objOldOVERDUEMONEY) : 0);

                    decimal decNew = (Information.IsNumeric(objNewwaterTotalFee) ? Convert.ToDecimal(objNewwaterTotalFee) : 0)
                    + (Information.IsNumeric(objNewExtraTotalCharge) ? Convert.ToDecimal(objNewExtraTotalCharge) : 0)
                    + (Information.IsNumeric(objNewOVERDUEMONEY) ? Convert.ToDecimal(objNewOVERDUEMONEY) : 0);

                    if (decOld != decNew)
                    {
                        object objReadMeterRecordID = dgWaterList.Rows[i].Cells["READMETERRECORDID"].Value;
                        if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
                        {
                            MODELWATERFEEREMIT MODELWATERFEEREMIT = new MODELWATERFEEREMIT();
                            MODELWATERFEEREMIT.READMETERRECORDID = objReadMeterRecordID.ToString();
                            MODELWATERFEEREMIT.REMITWATERFEE = Convert.ToDecimal(dgWaterList.Rows[i].Cells["REMITWATERFEE"].Value);
                            MODELWATERFEEREMIT.REMITEXTRAFEE = Convert.ToDecimal(dgWaterList.Rows[i].Cells["REMITEXTRAFEE"].Value);
                            MODELWATERFEEREMIT.REMITOVERDUE = Convert.ToDecimal(dgWaterList.Rows[i].Cells["REMITOVERDUE"].Value);
                            MODELWATERFEEREMIT.REMITWORKERID = strLoginID;
                            MODELWATERFEEREMIT.REMITWORKERNAME = strLoginName;
                            MODELWATERFEEREMIT.REMITDATETIME = mes.GetDatetimeNow();
                            MODELWATERFEEREMIT.MEMO = txtMemo.Text;

                            if (strRemitID == "")
                            {
                                MODELWATERFEEREMIT.WATERFEEREMITID = GETTABLEID.GetTableID("", "WATERFEEREMIT");
                                if (BLLWATERFEEREMIT.Insert(MODELWATERFEEREMIT))
                                {
                                    dgWaterList.Rows[i].Cells["WATERFEEREMITID"].Value = MODELWATERFEEREMIT.WATERFEEREMITID;//将新的ID填充到表格里，已被再次被点击保存自动转为修改模式。

                                    if (chkReceipt.Checked)
                                    {
                                        //打印收据
                                        #region 打印收据
                                        DataTable dtWaterFeeRemit = ((DataTable)dgWaterList.DataSource).Clone();
                                        DataRow dr = (dgWaterList.Rows[i].DataBoundItem as DataRowView).Row;
                                        dtWaterFeeRemit.ImportRow(dr);

                                        DataColumn dc = new DataColumn("REMITWATERFEEEND", typeof(decimal));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        object objWaterRemitFee = dgWaterList.Rows[i].Cells["REMITWATERFEEEND"].Value;
                                        if (Information.IsNumeric(objWaterRemitFee))
                                            dtWaterFeeRemit.Rows[0]["REMITWATERFEEEND"] = Convert.ToDecimal(objWaterRemitFee).ToString("F2");

                                        dc = new DataColumn("REMITEXTRAFEEEND", typeof(decimal));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        objWaterRemitFee = dgWaterList.Rows[i].Cells["REMITEXTRAFEEEND"].Value;
                                        if (Information.IsNumeric(objWaterRemitFee))
                                            dtWaterFeeRemit.Rows[0]["REMITEXTRAFEEEND"] = Convert.ToDecimal(objWaterRemitFee).ToString("F2");

                                        dc = new DataColumn("REMITOVERDUEEND", typeof(decimal));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        objWaterRemitFee = dgWaterList.Rows[i].Cells["REMITOVERDUEEND"].Value;
                                        if (Information.IsNumeric(objWaterRemitFee))
                                            dtWaterFeeRemit.Rows[0]["REMITOVERDUEEND"] = Convert.ToDecimal(objWaterRemitFee).ToString("F2");

                                        //减免后水费总金额
                                        dc = new DataColumn("totalChargeRemit", typeof(decimal));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        dtWaterFeeRemit.Rows[0]["totalChargeRemit"] = decNew.ToString("F2");

                                        //减免原因
                                        dc = new DataColumn("RemitMemo", typeof(string));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        dtWaterFeeRemit.Rows[0]["RemitMemo"] =txtMemo.Text;

                                        //水费总金额
                                        dtWaterFeeRemit.Rows[0]["totalCharge"] = decOld.ToString("F2");

                                        DataSet ds = new DataSet();
                                        DataTable dtPrint = dtWaterFeeRemit.Copy();
                                        dtPrint.TableName = "水费减免收据模板";
                                        ds.Tables.Add(dtPrint);

                                        FastReport.Report report1 = new FastReport.Report();
                                        try
                                        {
                                            // load the existing report
                                            report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\水费减免收据模板.frx");
                                            // register the dataset
                                            report1.RegisterData(ds);
                                            report1.GetDataSource("水费减免收据模板").Enabled = true;
                                            report1.Prepare();
                                            report1.Print();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        finally
                                        {
                                            // free resources used by report
                                            report1.Dispose();
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    mes.Show("水表编号为'" + strWaterMeterNO + "'的减免记录保存失败,请重新点击保存按钮!");
                                    return;
                                }
                            }
                            else
                            {
                                MODELWATERFEEREMIT.WATERFEEREMITID = strRemitID;
                                if (BLLWATERFEEREMIT.Update(MODELWATERFEEREMIT))
                                {
                                    if (chkReceipt.Checked)
                                    {
                                        //打印收据
                                        #region 打印收据
                                        DataTable dtWaterFeeRemit = ((DataTable)dgWaterList.DataSource).Clone();
                                        DataRow dr = (dgWaterList.Rows[i].DataBoundItem as DataRowView).Row;
                                        dtWaterFeeRemit.ImportRow(dr);

                                        DataColumn dc = new DataColumn("REMITWATERFEEEND", typeof(decimal));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        object objWaterRemitFee = dgWaterList.Rows[i].Cells["REMITWATERFEEEND"].Value;
                                        if (Information.IsNumeric(objWaterRemitFee))
                                            dtWaterFeeRemit.Rows[0]["REMITWATERFEEEND"] = Convert.ToDecimal(objWaterRemitFee).ToString("F2");

                                        dc = new DataColumn("REMITEXTRAFEEEND", typeof(decimal));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        objWaterRemitFee = dgWaterList.Rows[i].Cells["REMITEXTRAFEEEND"].Value;
                                        if (Information.IsNumeric(objWaterRemitFee))
                                            dtWaterFeeRemit.Rows[0]["REMITEXTRAFEEEND"] = Convert.ToDecimal(objWaterRemitFee).ToString("F2");

                                        dc = new DataColumn("REMITOVERDUEEND", typeof(decimal));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        objWaterRemitFee = dgWaterList.Rows[i].Cells["REMITOVERDUEEND"].Value;
                                        if (Information.IsNumeric(objWaterRemitFee))
                                            dtWaterFeeRemit.Rows[0]["REMITOVERDUEEND"] = Convert.ToDecimal(objWaterRemitFee).ToString("F2");

                                        //减免后水费总金额
                                        dc = new DataColumn("totalChargeRemit", typeof(decimal));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        dtWaterFeeRemit.Rows[0]["totalChargeRemit"] = decNew.ToString("F2");

                                        //减免原因
                                        dc = new DataColumn("RemitMemo", typeof(string));
                                        dtWaterFeeRemit.Columns.Add(dc);
                                        dtWaterFeeRemit.Rows[0]["RemitMemo"] = txtMemo.Text;

                                        //水费总金额
                                        dtWaterFeeRemit.Rows[0]["totalCharge"] = decOld.ToString("F2");

                                        DataSet ds = new DataSet();
                                        DataTable dtPrint = dtWaterFeeRemit.Copy();
                                        dtPrint.TableName = "水费减免收据模板";
                                        ds.Tables.Add(dtPrint);

                                        FastReport.Report report1 = new FastReport.Report();
                                        try
                                        {
                                            // load the existing report
                                            report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\水费减免收据模板.frx");
                                            // register the dataset
                                            report1.RegisterData(ds);
                                            report1.GetDataSource("水费减免收据模板").Enabled = true;
                                            report1.Prepare();
                                            report1.Print();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        finally
                                        {
                                            // free resources used by report
                                            report1.Dispose();
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    mes.Show("水表编号为'" + strWaterMeterNO + "'的减免记录保存失败,请重新点击保存按钮!");
                                    return;
                                }
                            }
                            //mes.Show("水表编号为'" + strWaterMeterNO + "'的减免记录保存成功!");
                        }
                        else
                        {
                            mes.Show("获取水费记录表ID失败,请重新加载用户欠费信息!");
                            return;
                        }
                    }
                    else
                    {
                        mes.Show("未检测到水表编号为'" + strWaterMeterNO + "'的减免金额!");
                    }
                }
                            btCharge.Enabled = false;
            }
            catch (Exception eex)
            {
                mes.Show(eex.Message);
                log.Write(eex.ToString(), MsgType.Error);
                return;
            }
        }


        private void dgWaterList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "REMITWATERFEE")
            {
                dgWaterList.EndEdit();
                btCharge.Enabled = true;

                decimal decTotalCharge=0,decRemitWaterFee=0,decRemitWaterFeeEnd=0;
                object obj = dgWaterList.Rows[e.RowIndex].Cells["waterTotalCharge"].Value;
                if (!Information.IsNumeric(obj))
                {
                    decTotalCharge = 0;
                    dgWaterList.Rows[e.RowIndex].Cells["waterTotalCharge"].Value = decTotalCharge;
                }
                else
                    decTotalCharge = Convert.ToDecimal(obj);

                obj = dgWaterList.Rows[e.RowIndex].Cells["REMITWATERFEE"].Value;
                if (!Information.IsNumeric(obj))
                {
                    decRemitWaterFee = 0;
                    dgWaterList.Rows[e.RowIndex].Cells["REMITWATERFEE"].Value = decRemitWaterFee;
                }
                else
                    decRemitWaterFee = Convert.ToDecimal(obj);

                decRemitWaterFeeEnd = (decTotalCharge-decRemitWaterFee)>=0?(decTotalCharge-decRemitWaterFee):0;
                    dgWaterList.Rows[e.RowIndex].Cells["REMITWATERFEEEND"].Value = decRemitWaterFeeEnd;
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "REMITEXTRAFEE")
            {
                dgWaterList.EndEdit();
                btCharge.Enabled = true;

                decimal decTotalCharge = 0, decRemitWaterFee = 0, decRemitWaterFeeEnd = 0;
                object obj = dgWaterList.Rows[e.RowIndex].Cells["extraTotalCharge"].Value;
                if (!Information.IsNumeric(obj))
                {
                    decTotalCharge = 0;
                    dgWaterList.Rows[e.RowIndex].Cells["extraTotalCharge"].Value = decTotalCharge;
                }
                else
                    decTotalCharge = Convert.ToDecimal(obj);

                obj = dgWaterList.Rows[e.RowIndex].Cells["REMITEXTRAFEE"].Value;
                if (!Information.IsNumeric(obj))
                {
                    decRemitWaterFee = 0;
                    dgWaterList.Rows[e.RowIndex].Cells["REMITEXTRAFEE"].Value = decRemitWaterFee;
                }
                else
                    decRemitWaterFee = Convert.ToDecimal(obj);

                decRemitWaterFeeEnd = (decTotalCharge - decRemitWaterFee) >= 0 ? (decTotalCharge - decRemitWaterFee) : 0;
                dgWaterList.Rows[e.RowIndex].Cells["REMITEXTRAFEEEND"].Value = decRemitWaterFeeEnd;
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "REMITOVERDUE")
            {
                dgWaterList.EndEdit();
                btCharge.Enabled = true;

                decimal decTotalCharge = 0, decRemitWaterFee = 0, decRemitWaterFeeEnd = 0;
                object obj = dgWaterList.Rows[e.RowIndex].Cells["OVERDUEMONEY"].Value;
                if (!Information.IsNumeric(obj))
                {
                    decTotalCharge = 0;
                    dgWaterList.Rows[e.RowIndex].Cells["OVERDUEMONEY"].Value = decTotalCharge;
                }
                else
                    decTotalCharge = Convert.ToDecimal(obj);

                obj = dgWaterList.Rows[e.RowIndex].Cells["REMITOVERDUE"].Value;
                if (!Information.IsNumeric(obj))
                {
                    decRemitWaterFee = 0;
                    dgWaterList.Rows[e.RowIndex].Cells["REMITOVERDUE"].Value = decRemitWaterFee;
                }
                else
                    decRemitWaterFee = Convert.ToDecimal(obj);

                decRemitWaterFeeEnd = (decTotalCharge - decRemitWaterFee) >= 0 ? (decTotalCharge - decRemitWaterFee) : 0;
                dgWaterList.Rows[e.RowIndex].Cells["REMITOVERDUEEND"].Value = decRemitWaterFeeEnd;
            }
        }

        private void dgWaterList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Aquamarine;
            if (dgWaterList.CurrentCell.ColumnIndex > 0)
            {
                TextBox tx = e.Control as TextBox;
                if (dgWaterList.Columns[dgWaterList.CurrentCell.ColumnIndex].Name == "REMITWATERFEE" || dgWaterList.Columns[dgWaterList.CurrentCell.ColumnIndex].Name == "REMITEXTRAFEE" || dgWaterList.Columns[dgWaterList.CurrentCell.ColumnIndex].Name == "REMITOVERDUE")
                {
                    // Remove an existing event-handler, if present, to avoid   
                    // adding multiple handlers when the editing control is reused. 
                    tx.Name = dgWaterList.Columns[dgWaterList.CurrentCell.ColumnIndex].Name;
                    tx.KeyPress -= new KeyPressEventHandler(tx_KeyPress);
                    tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
                }
            }
        }
        private void tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //检测是否已经输入了小数点 
            bool IsContainsDot = ((TextBox)sender).Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {
                dgWaterList.CurrentCell = dgWaterList.CurrentRow.Cells["areaName"];
            }
        }

        private void dgWaterList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "REMITWATERFEE")
            {
                object obj = dgWaterList.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
                if (Information.IsNumeric(obj))
                {
                    if (Convert.ToDecimal(dgWaterList.Rows[e.RowIndex].Cells["waterTotalCharge"].FormattedValue) < Convert.ToDecimal(obj))
                    {
                        e.Cancel = true;
                        mes.Show("减免水费不能大于总水费!");
                    }
                }
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "REMITEXTRAFEE")
            {
                object obj = dgWaterList.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
                if (Information.IsNumeric(obj))
                {
                    if (Convert.ToDecimal(dgWaterList.Rows[e.RowIndex].Cells["extraTotalCharge"].FormattedValue) < Convert.ToDecimal(obj))
                    {
                        e.Cancel = true;
                        mes.Show("减免附加费不能大于总附加费!");
                    }
                }
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "REMITOVERDUE")
            {
                object obj = dgWaterList.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
                if (Information.IsNumeric(obj))
                {
                    if (Convert.ToDecimal(dgWaterList.Rows[e.RowIndex].Cells["OVERDUEMONEY"].FormattedValue) < Convert.ToDecimal(obj))
                    {
                        e.Cancel = true;
                        mes.Show("减免滞纳金不能大于总滞纳金!");
                    }
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (dgWaterList.Rows.Count == 0)
            {
                mes.Show("未找到可作废的减免信息!");
                return;
            }
            if (dgWaterList.CurrentRow == null)
            {
                mes.Show("请从'水费信息'列表内点击选择要作废减免的水表!");
                return;
            }

            //水表编号
            string strWaterMeterNO = "";
            object objWaterMeterNO = dgWaterList.CurrentRow.Cells["waterMeterNo"].Value;
            if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
            {
                strWaterMeterNO = objWaterMeterNO.ToString();
            }

            string strRemitID = "";
            object objRemitID = dgWaterList.CurrentRow.Cells["WATERFEEREMITID"].Value;
            if (objRemitID != null && objRemitID != DBNull.Value)
            {
                if (mes.ShowQ("确定要作废水表编号为'" + strWaterMeterNO + "'的减免记录吗?") != DialogResult.OK)
                    return;

                try
                {
                    strRemitID = objRemitID.ToString();
                    MODELWATERFEEREMIT MODELWATERFEEREMIT = new MODELWATERFEEREMIT();
                    MODELWATERFEEREMIT.WATERFEEREMITID = strRemitID;
                    MODELWATERFEEREMIT.REMITCANCEL = "1";
                    MODELWATERFEEREMIT.CANCELWORKERID = strLoginID;
                    MODELWATERFEEREMIT.CANCELWORKERNAME = strLoginName;
                    MODELWATERFEEREMIT.CANCELDATETIME = mes.GetDatetimeNow();
                    if (BLLWATERFEEREMIT.UpdateCancel(MODELWATERFEEREMIT))
                    {
                        dgWaterList.CurrentRow.Cells["WATERFEEREMITID"].Value = null;
                        dgWaterList.CurrentRow.Cells["REMITWATERFEE"].Value = 0;
                        dgWaterList.CurrentRow.Cells["REMITEXTRAFEE"].Value = 0;
                        dgWaterList.CurrentRow.Cells["REMITOVERDUE"].Value = 0;

                        btCancel.Enabled = false;
                        btCharge.Enabled = true;
                    }
                    else
                    {
                        mes.Show("水表编号为'" + strWaterMeterNO + "'的减免记录作废失败,请重新查询用户欠费信息!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    mes.Show("水表编号为'" + strWaterMeterNO + "'的减免记录作废失败!原因:"+ex.Message);
                    log.Write(ex.ToString(),MsgType.Error);
                    return;
                }
            }
            else
            {
                mes.Show("未找到水表编号为'" + strWaterMeterNO + "'的减免记录!");
                return;
            }
        }

        private void dgWaterList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            object objRemitID = dgWaterList.Rows[e.RowIndex].Cells["WATERFEEREMITID"].Value;
            if (objRemitID != null && objRemitID != DBNull.Value)
            {
                btCancel.Enabled = true;
            }
            else
                btCancel.Enabled = false;
        }

        private void dgWaterList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;


            if (e.Button == MouseButtons.Right)
            {
                dgWaterList.ClearSelection();
                dgWaterList.CurrentCell = dgWaterList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgWaterList.CurrentRow == null)
            {
                mes.Show("请选择要移除的水表所在的行!");
                return;
            }
            object objWaterMeterNO = dgWaterList.CurrentRow.Cells["waterMeterNo"].Value;
            if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
            {
                if (mes.ShowQ("确定要移除编号为'" + objWaterMeterNO.ToString() + "'的水表吗?") == DialogResult.OK)
                {
                    dgWaterList.Rows.Remove(dgWaterList.CurrentRow);
                }
            }
        }

    }
}
