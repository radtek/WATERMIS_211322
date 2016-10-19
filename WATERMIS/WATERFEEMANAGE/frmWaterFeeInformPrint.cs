using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BASEFUNCTION;
using MODEL;
using BLL;
using System.Threading;

namespace WATERFEEMANAGE
{
    public partial class frmWaterFeeInformPrint : DockContentEx
    {
        public frmWaterFeeInformPrint()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            tb2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb2, true, null);
        }

        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();


        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        string strFormText = "";
        private void frmWaterUserPrestoreInitial_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgWaterUser.AutoGenerateColumns = false;

            BindWaterUserType(cmbMeterReaderS);

            GenerateTree();
            strFormText = this.Text;

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }
                dgWaterUser.Columns["USERAREARAGE"].DefaultCellStyle.BackColor = Color.Coral;

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            //BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
            BindCharger(cmbChargerS, "0");
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }

        DataTable dtMeterReader = new DataTable();
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader(ComboBox cmb, string strType)
        {
            dtMeterReader= BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
            if (strType == "0")
            {
                DataRow dr = dtMeterReader.NewRow();
                dr["USERNAME"] = "全部";
                dr["LOGINID"] = DBNull.Value;
                dtMeterReader.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtMeterReader;
            }
            cmb.DataSource = dtMeterReader;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        /// <summary>
        /// 绑定收费员，如果strType为0，则添加‘全部’项
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="strType"></param>
        private void BindCharger(ComboBox cmb, string strType)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
            if (strType == "0")
            {
                DataRow dr = dt.NewRow();
                dr["USERNAME"] = "全部";
                dr["LOGINID"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
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
        /// 按抄表本、区域、抄表员动态生成抄表本树形结构
        /// </summary>
        private void GenerateTree()
        {
            trMeterReading.Nodes.Clear();

            #region 按抄表员生成抄表本树形结构
            TreeNode tnHeadMeterReader = trMeterReading.Nodes.Add("|无关ID|", "全部抄表员", 0, 1);
            DataTable dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是'");
            for (int i = 0; i < dtMeterReader.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object objID = dtMeterReader.Rows[i]["LOGINID"];
                if (objID != null && objID != DBNull.Value)
                {
                    strID = "METERREADER|无关ID| AND meterReaderID='" + objID.ToString() + "'";
                }
                object objName = dtMeterReader.Rows[i]["USERNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
            }
            tnHeadMeterReader.Expand();
            #endregion
            trMeterReading.SelectedNode = tnHeadMeterReader;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode != null)
            {
                txtStartRow.Text = "1";
                TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
                trMeterReading_AfterSelect(null, ex);
            }
        }
        /// <summary>
        /// 是否是第一次打开
        /// </summary>
        bool isFirst = false;

        /// <summary>
        /// 存储查询到的用户表
        /// </summary>
        DataTable dtUserList = new DataTable();

        private void trMeterReading_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!isFirst)
            {
                isFirst = true;
                return;
            }
            if (e.Node == null)
                return;
            //if()
            string strNodeID = e.Node.Name;
            string[] strNodeIDSpit = strNodeID.Split('|');
            LoadDebtsDate(strNodeIDSpit);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="strFilter"></param>
        private void LoadDebtsDate(string[] strNodeIDSpit)
        {
            prb.Visible = false;
            labProgress.Visible = false;
            #region 获取当前登录用户最大的通知单号
            string strGetMaxInformNO = " AND INFORMNO IS NOT NULL AND PRINTWORKERID='" + strLogID + "'";
            object objMaxInformNO = BLLreadMeterRecord.GetMaxInformNO(strGetMaxInformNO);
            if (Information.IsNumeric(objMaxInformNO))
                txtInformNO.Text = (Convert.ToInt32(objMaxInformNO) + 1).ToString().PadLeft(8, '0');
            else
                txtInformNO.Text = "00000001";
            #endregion

            string strFilter = strNodeIDSpit[2] + " AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,'"+dtpMonth.Value+"')=0 ";

            dtpMonthSearch.Value = dtpMonth.Value;

            if (txtWaterUserNOSearch.Text.Trim() != "")
            {
                if (txtWaterUserNOSearch.Text.Length < 6)
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                else
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
            }
            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
            if (cmbPianNOS.SelectedIndex > 0)
                strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

            if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";
            if (cmbChargerS.SelectedValue != null && cmbChargerS.SelectedValue != DBNull.Value)
                strFilter += " AND chargerID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";
            if (chkHSL.Checked)
                strFilter += " AND TOTALNUMBER>0 ";

            strFilter = " AND WATERUSERID IN (SELECT WATERUSERID FROM readMeterRecord WHERE waterUserState<>'未启用' " + strFilter + ")";
            //if (chkArearageGreater.Checked)
            //    if (Information.IsNumeric(txtArearageGreater.Text))
            //    {
            //        decimal decQFJE = 0 - Convert.ToDecimal(txtArearageGreater.Text);
            //        strFilter += " AND USERAREARAGE<=" + decQFJE;
            //    }
            if (Information.IsNumeric(txtArearageLess.Text))
            {
                labCondition.Text = txtArearageLess.Text;
            }
            if (chkArearageLess.Checked)
                if (Information.IsNumeric(txtArearageLess.Text))
                {
                    //decimal decQFJE = 0 - Convert.ToDecimal(txtArearageGreater.Text);
                    decimal decQFJE = Convert.ToDecimal(txtArearageLess.Text);
                    strFilter += " AND USERAREARAGE<" + decQFJE;
                }

            strFilter += " ORDER BY areaNO,pianNO,duanNO,ordernumber";

            dtUserList = BLLwaterUser.QueryUserPrestore(strFilter);

            //计算查询到的用户余额
            decimal decWaterUserPrestore = 0;
            object objWaterUserPrestore = dtUserList.Compute("SUM(prestore)", "");
            if (Information.IsNumeric(objWaterUserPrestore))
                decWaterUserPrestore = Convert.ToDecimal(objWaterUserPrestore);
            
            //计算查询到的用户欠费金额
            decimal decWaterFee = 0;
            object objWaterFee = dtUserList.Compute("SUM(TOTALFEE)", "");
            if (Information.IsNumeric(objWaterFee))
                decWaterFee = Convert.ToDecimal(objWaterFee);

            //结算余额
            decimal decUserArearage = 0;
            object objUserArearage = dtUserList.Compute("SUM(USERAREARAGE)", "");
            if (Information.IsNumeric(objUserArearage))
                decUserArearage = Convert.ToDecimal(objUserArearage);

            dgWaterUser.DataSource = dtUserList;
            //ucPageSetUp1.InitialUC(this.dgWaterUser, dtUserList,null);
            //计算水表数量
            this.Text = strFormText + "→用水用户共" + dtUserList.Rows.Count + "户";
            labTip.Text = "本次查询—用户共:" + dtUserList.Rows.Count + "户,账户余额:" + decWaterUserPrestore.ToString("F2") + 
                ",欠费总计:" + decWaterFee.ToString("F2") + ",结算余额:" + decUserArearage.ToString("F2");

            if (dtUserList.Rows.Count == 0)
                btCharge.Enabled = false;
            else
            {
                btCharge.Enabled = true;
            }
        }
        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (trMeterReading.SelectedNode == null)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                string strNodeID = trMeterReading.SelectedNode.Name;
                string[] strNodeIDSpit = strNodeID.Split('|');
                LoadDebtsDate(strNodeIDSpit);
            }
        }

        private void dgWaterUser_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void btCharge_Click(object sender, EventArgs e)
        {
            if (dtUserList.Rows.Count == 0)
            {
                mes.Show("请查询预存用户信息后再执行此操作!");
                return;
            }
            //if (Information.IsNumeric(txtStartRow.Text))
            //{
            //    if (Convert.ToInt32(txtStartRow.Text) < 1)
            //    {
            //        mes.Show("请输入正确的起始行号!");
            //        txtStartRow.Focus();
            //        return;
            //    }
            //    if (Convert.ToInt32(txtStartRow.Text) > dgWaterUser.Rows.Count)
            //    {
            //        mes.Show("起始行号不能大约当前查询的总行数!");
            //        txtStartRow.Focus();
            //        return;
            //    }
            //}
            //if (txtInformNO.Text.Trim() == "")
            //{
            //    mes.Show("请输入通知单起始编号!");
            //    return;
            //}
            //else
            //{
            //    if (!Information.IsNumeric(txtInformNO.Text))
            //    {
            //        mes.Show("通知单编号只能为数字!");
            //        return;
            //    }
            //    txtInformNO.Text = txtInformNO.Text.PadLeft(8, '0');
            //}
            prb.Visible = true;
            labProgress.Visible = true;

            trMeterReading.Enabled = false;
            grbSearch.Enabled = false;
            for (int i = 0; i < dgWaterUser.Columns.Count; i++)
            {
                dgWaterUser.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

                bgWork.RunWorkerAsync();
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                labProgress.Text = "进度:0/0";
                int intAllCount = dtUserList.Rows.Count;
                prb.Minimum = 0;
                prb.Maximum = intAllCount;
                prb.Value = 0;
                //btCharge.Enabled = false;

                //获取连打起始号及终止号
                int intStartRow = 0, intEndRow = dgWaterUser.Rows.Count;
                if (!Information.IsNumeric(txtStartRow.Text))
                {
                    mes.Show("请输入连打起始行号!");
                    txtStartRow.Focus();
                    return;
                }
                else
                {
                    if (Convert.ToInt32(txtStartRow.Text) < 1)
                    {
                        mes.Show("连打起始行号不能小于1!");
                        txtStartRow.Focus();
                        return;
                    }
                    intStartRow = Convert.ToInt32(txtStartRow.Text);
                }
                if (Information.IsNumeric(txtEndRow.Text))
                {
                    if (Convert.ToInt32(txtStartRow.Text) > Convert.ToInt32(txtEndRow.Text))
                    {
                        mes.Show("连打起始行号不能大于终止行号!");
                        txtEndRow.Focus();
                        return;
                    }
                    if (Convert.ToInt32(txtEndRow.Text) < dgWaterUser.Rows.Count)
                        intEndRow = Convert.ToInt32(txtEndRow.Text);
                }
                //int intRowNumber=1;
                //if(Information.IsNumeric(txtStartRow.Text))
                //    intRowNumber=Convert.ToInt32(txtStartRow.Text);

                string strMaxInformNO=txtInformNO.Text.PadLeft(8,'0');
                for (int i = intStartRow - 1; i < intEndRow; i++)
                {
                    if (bgWork.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    string strWaterUserName = "", strWaterUserID = "", strWaterUserAddress = "", strMeterReader = "", strMeterReaderTel = "";

                    object objWaterUserID = dgWaterUser.Rows[i].Cells["waterUserId"].Value;
                    if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                    {
                        strWaterUserID = objWaterUserID.ToString();
                        object objWaterUserName = dgWaterUser.Rows[i].Cells["waterUserName"].Value;
                        if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                        {
                            strWaterUserName = objWaterUserName.ToString();
                        }
                        object objWaterUserAddress = dgWaterUser.Rows[i].Cells["waterUserAddress"].Value;
                        if (objWaterUserAddress != null && objWaterUserAddress != DBNull.Value)
                        {
                            strWaterUserAddress = objWaterUserAddress.ToString();
                        }
                        object objMeterReader = dgWaterUser.Rows[i].Cells["meterReaderID"].Value;
                        if (objMeterReader != null && objMeterReader != DBNull.Value)
                        {
                            DataRow[] dr = dtMeterReader.Select("loginId='" + objMeterReader.ToString() + "'");
                            if (dr.Length > 0)
                            {
                                objMeterReader = dr[0]["userName"];
                                if (objMeterReader != null && objMeterReader != DBNull.Value)
                                {
                                    strMeterReader = objMeterReader.ToString();
                                }
                                objMeterReader = dr[0]["telePhoneNO"];
                                if (objMeterReader != null && objMeterReader != DBNull.Value)
                                {
                                    strMeterReaderTel = objMeterReader.ToString();
                                }
                            }
                        }

                        //获取用户余额
                        decimal decWaterUserPrestore = 0, decToltalFee = 0, decArearage = 0;
                        object objWaterUserPreStore = BLLwaterUser.GetPrestore(" AND WATERUSERID='" + strWaterUserID + "'");
                        if (Information.IsNumeric(objWaterUserPreStore))
                        {
                            decWaterUserPrestore = Convert.ToDecimal(objWaterUserPreStore);
                        }

                        //获取用户水表欠费信息
                        string strFilter = " AND totalChargeEND>0 AND waterUserId='" + objWaterUserID.ToString() + "' AND chargeState=1 ORDER BY readMeterRecordYear,readMeterRecordMonth";
                        DataTable dtYSDetail = BLLreadMeterRecord.QueryYSDetailByWaterMeter(strFilter);

                        object objSumArearage = dtYSDetail.Compute("SUM(totalCharge)", "");
                        if (Information.IsNumeric(objSumArearage))
                            decToltalFee = Convert.ToDecimal(objSumArearage);
                        decArearage = decWaterUserPrestore - decToltalFee;

                        DataTable dtReadMeterRecord = BLLreadMeterRecord.Query(" AND waterUserId='" + objWaterUserID.ToString() + "' AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtpMonthSearch.Value + "')=0");

                        decimal decJianXian = 0;
                        if (Information.IsNumeric(labCondition.Text))
                            decJianXian = Convert.ToDecimal(labCondition.Text);
                        #region 打印通知单
                        DataSet ds = new DataSet();
                        DataTable dtYSDetailTemp = dtReadMeterRecord.Copy();
                        dtYSDetailTemp.TableName = "水费通知单模板";
                        ds.Tables.Add(dtYSDetailTemp);
                        FastReport.Report report1 = new FastReport.Report();
                        try
                        {
                            // load the existing report
                            report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\水费通知单模板.frx");

                            (report1.FindObject("CellWaterUserName") as FastReport.Table.TableCell).Text = strWaterUserName;
                            (report1.FindObject("CellWaterUserNO") as FastReport.Table.TableCell).Text = strWaterUserID;
                            (report1.FindObject("CellWaterUserAddress") as FastReport.Table.TableCell).Text = strWaterUserAddress;
                            (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = 
                                "前期余额:"+decWaterUserPrestore.ToString("F2")+"     水费合计:"+decToltalFee.ToString("F2");

                            (report1.FindObject("txtQFHJ") as FastReport.TextObject).Text = "用户余额:      " + decArearage.ToString("F2");

                            (report1.FindObject("txtMeterReader") as FastReport.TextObject).Text = strMeterReader;
                            (report1.FindObject("txtMeterReaderTel") as FastReport.TextObject).Text = strMeterReaderTel;

                            if (decJianXian == 0)
                            {
                                if (decArearage < 0)
                                    (report1.FindObject("txtTip") as FastReport.TextObject).Text = "您已欠费,请及时交纳水费";
                            }
                            else
                                if (decArearage >= 0 && decArearage <= decJianXian)
                                    (report1.FindObject("txtTip") as FastReport.TextObject).Text = "您的余额已不足,请您及时交费";
                                else if (decArearage < 0)
                                    (report1.FindObject("txtTip") as FastReport.TextObject).Text = "您已欠费,请您及时交纳水费";

                            (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + strMaxInformNO;

                            // register the dataset
                            report1.RegisterData(ds);
                            report1.GetDataSource("水费通知单模板").Enabled = true;
                            //report1.Show();
                            report1.PrintSettings.ShowDialog = false;
                            report1.Prepare();
                            report1.Print();

                            try
                            {
                                for (int j = 0; j < dtReadMeterRecord.Rows.Count; j++)
                                {
                                    object objID = dtReadMeterRecord.Rows[j]["readMeterRecordId"];
                                    if (objID != null && objID != DBNull.Value)
                                    {
                                        MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                                        MODELreadMeterRecord.WATERUSERQQYEINFORM = decWaterUserPrestore;
                                        MODELreadMeterRecord.WATERUSERJSYEINFORM = decArearage;
                                        MODELreadMeterRecord.INFORMNO = strMaxInformNO;
                                        MODELreadMeterRecord.INFORMPRINTSIGN = "1";
                                        MODELreadMeterRecord.PRINTWORKERID = strLogID;
                                        MODELreadMeterRecord.PRINTWORKERNAME = strUserName;
                                        MODELreadMeterRecord.readMeterRecordId = objID.ToString();

                                        if (!BLLreadMeterRecord.UpdateInformPrintSign(MODELreadMeterRecord))
                                        {
                                            mes.Show("更新用户'" + strWaterUserID + "-" + strWaterUserName + "'的通知单失打印标志失败,请重打通知单!");
                                            return;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                mes.Show("更新用户'" + strWaterUserID + "-" + strWaterUserName + "'的通知单失打印标志失败,原因:"+ex.Message);
                                log.Write(ex.ToString(),MsgType.Error);
                                return;
                            }
                            strMaxInformNO = (Convert.ToInt32(strMaxInformNO) + 1).ToString().PadLeft(8, '0');
                        }
                        catch (Exception exx)
                        {
                            mes.Show(exx.Message);
                            log.Write(exx.ToString(), MsgType.Error);
                            return;
                        }
                        finally
                        {
                            // free resources used by report
                            report1.Dispose();
                        }
                        #endregion
                    }
                    else
                    {
                        mes.Show("第" + (i + 1).ToString() + "行用户ID为空，无法获取金额，请查询后重试!");
                        return;
                    }
                    prb.Value = i + 1;
                    labProgress.Text = "进度:" + (i + 1) + "/" + intAllCount;
                }
                txtInformNO.Text = strMaxInformNO;
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            trMeterReading.Enabled = true;
            grbSearch.Enabled = true;
            for (int i = 0; i < dgWaterUser.Columns.Count; i++)
            {
                dgWaterUser.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic ;
            }
        }

        private void frmPrestoreWaterUserManualCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgWork.IsBusy)
                bgWork.CancelAsync();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            //检测是否已经输入了小数点 
            bool IsContainsDot = txt.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
        }

        private void txtRowNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
