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
    public partial class frmWaterMeterRead : DockContentEx
    {
        public frmWaterMeterRead()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            //dgWaterList.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(dgWaterList, true, null);
        }

        BLLmeterReading BLLmeterReading = new BLLmeterReading();
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
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();

        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLoginID= "";

        /// <summary>
        /// 存储查询的时间获取上次抄表的月份，计算阶梯水价用
        /// </summary>
        private DateTime dtNow = DateTime.Now;

        //审核颜色、已收费颜色、已保存颜色，剩余待用：用户停用颜色、水表停用及报废颜色、默认的cell颜色、cell只读颜色。
        Color colorChecked = Color.Green, colorCharged = Color.Red, colorSave = Color.Blue, colorWaterUserStop = Color.Goldenrod, colorWaterMeterStop = Color.Yellow, colorCellDefault = SystemColors.Window, colorCellEdit = Color.Yellow;
        private void frmModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgWaterList.AutoGenerateColumns = false;
            dgWaterList.ShowCellToolTips = true;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            this.dgWaterList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgWaterList.Columns["readMeterRecordYearAndMonth"].DefaultCellStyle.Format = "yyyy-MM";

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();

            //保存默认的单元格颜色
            colorCellDefault = dgWaterList.DefaultCellStyle.BackColor;

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtNow = dtpStart.Value.AddMonths(1).AddDays(-1);
            dtpEnd.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);

            for (int i = 0; i < dgWaterList.Columns.Count; i++)
            {
                //禁止列排序
                //dgWaterList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (dgWaterList.Columns[i].Name == "waterMeterEndNumber" || dgWaterList.Columns[i].Name == "SUBMETERNUMBER")
                {
                    //本月读数可编辑
                    dgWaterList.Columns[i].ReadOnly = false;
                    dgWaterList.Columns[i].DefaultCellStyle.BackColor = colorCellEdit;
                }
                else
                    dgWaterList.Columns[i].ReadOnly = true;

                //隐藏附加费列
                if (dgWaterList.Columns[i].Name == "extraChargePrice1" || dgWaterList.Columns[i].Name == "extraCharge1" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice2" || dgWaterList.Columns[i].Name == "extraCharge2" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice3" || dgWaterList.Columns[i].Name == "extraCharge3" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice4" || dgWaterList.Columns[i].Name == "extraCharge4" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice5" || dgWaterList.Columns[i].Name == "extraCharge5" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice6" || dgWaterList.Columns[i].Name == "extraCharge6" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice7" || dgWaterList.Columns[i].Name == "extraCharge7" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice8" || dgWaterList.Columns[i].Name == "extraCharge8")
                {
                    dgWaterList.Columns[i].Visible = false;
                }
            }

            GetExtraFeeName();

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
            //BindCharger(cmbChargerS, "0");

            //BindWaterUserType(cmbWaterUserTypeSearch);
            //BindBank(cmbWaterUserAgentBankSearch);
            BindWaterMeterType(cmbWaterMeterType);
            //BindWaterMeterSize();
            //BindWaterMeterType();
            btFold.Parent = trMeterReading;
            //btFold.Dock = DockStyle.Right;

            GenerateTree();
            //trMeterReading.HideSelection = false;
        }

        /// <summary>
        /// 根据附加费表生成附加费列及单价
        /// </summary>
        private void GetExtraFeeName()
        {
            DataTable dt = BLLEXTRACHARGE.Query(" ORDER BY extraChargeID");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object objExtraFee = dt.Rows[i]["extraChargeName"];
                if (objExtraFee != null && objExtraFee != DBNull.Value)
                {
                    dgWaterList.Columns["extraCharge" + (i + 1).ToString()].HeaderText = objExtraFee.ToString();
                    dgWaterList.Columns["extraChargePrice" + (i + 1).ToString()].HeaderText = objExtraFee.ToString() + "单价";

                    object objExtraChargeState = dt.Rows[i]["extraChargeState"];
                    if (objExtraChargeState != null && objExtraChargeState != DBNull.Value)
                    {
                        if (objExtraChargeState.ToString() == "启用")
                        {
                            dgWaterList.Columns["extraCharge" + (i + 1).ToString()].Visible = true;
                            dgWaterList.Columns["extraChargePrice" + (i + 1).ToString()].Visible = true;
                        }
                    }
                }
            }
        }
        private void BindBank(ComboBox cmb)
        {
            DataTable dt = BLLBASE_BANK.Query("");
            DataRow dr = dt.NewRow();
            dr["bankName"] = "";
            dr["bankId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "bankName";
            cmb.ValueMember = "bankId";
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }

        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType(ComboBox cmb)
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "";
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterMeterTypeValue";
            cmb.ValueMember = "waterMeterTypeId";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader(ComboBox cmb, string strType)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
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
            #endregion
            tnHeadMeterReader.Expand();
            trMeterReading.SelectedNode = tnHeadMeterReader;
        }


        private void btSearch_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode != null)
            {
                TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
                trMeterReading_AfterSelect(null, ex);
            }
        }
        /// <summary>
        /// 是否是第一次打开窗体标志，如果是第一次打开窗体，不检索数据库中的数据，否则开始检索。
        /// </summary>
        bool isFirstOpen = true;
        private void trMeterReading_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isFirstOpen)
            {
                isFirstOpen = false;
                return;
            }
            if (e.Node == null)
                return;
            string strNodeID = e.Node.Name;
            string[] strNodeIDSpit = strNodeID.Split('|');
            RefreshData(strNodeIDSpit);
        }
        Thread TD;
        private void RefreshData(string[] strNodeID)
        {
            try
            {
                //获取当前日期，计算未抄表月份，计算阶梯水价
                dtNow = mes.GetDatetimeNow();

                TD = new Thread(showwaitfrm);
                TD.Start();
                LoadData(strNodeID);
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("手工抄表界面:" + ex.ToString(), MsgType.Error);
                //mes.Show(ex.Message);
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
        }
        //传递给线程的方法.
        frmWaitSearch waitfrm = null;
        private void showwaitfrm()
        {
            try
            {
                waitfrm = new frmWaitSearch();
                waitfrm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Write("手工抄表界面:" + ex.ToString(), MsgType.Error);
            }
        }
        /// <summary>
        /// 存储查询到的用户表
        /// </summary>
        DataTable dtUserList = new DataTable();
        private void LoadData(string[] strNodeID)
        {
            try
            {  
                //查询条件
                string strFilter = strSeniorFilterHidden + strNodeID[2] + " AND chargeState<'2' and CHECKSTATE='0' AND WATERMETERNUMBERCHANGESTATE='0' "; //查询未审核的已抄表及未抄表

                if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

                if (cmbWaterMeterType.SelectedValue != DBNull.Value && cmbWaterMeterType.SelectedValue != null)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                string strSearch = txtWaterUserNOSearch.Text;
                if (txtWaterUserNOSearch.Text.Trim() != "")
                {
                    strFilter += " AND (waterUserNO LIKE '%" + strSearch + "%' OR waterUserName LIKE '%" + strSearch +
                        "%' OR waterUserAddress LIKE '%" + strSearch + "%') ";
                }

                if (cmbAreaNOS.SelectedIndex > 0)
                    strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
                if (cmbPianNOS.SelectedIndex > 0)
                    strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
                if (cmbDuanNOS.SelectedIndex > 0)
                    strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

                if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

                if (cmbCommunityS.SelectedIndex > 0)
                    strFilter += " AND communityID='" + cmbCommunityS.SelectedValue.ToString() + "'";

                    strFilter += " AND readMeterRecordYearAndMonth BETWEEN '" + new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1) + "' AND '" + new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, 1).AddMonths(1).AddDays(-1) + "'";

                txtFilterSearch.Text = strFilter;//保存查询条件，全部删除用

                if (rbPQD.Checked)
                    strFilter += " ORDER BY areaNO,pianNO,duanNO,ordernumber";
                if (rbWaterUserName.Checked)
                    strFilter += " ORDER BY waterUserName";
                if (rbWaterUserNO.Checked)
                    strFilter += " ORDER BY waterUserNO";

                dtUserList = BLLreadMeterRecord.Query(strFilter);

                int intTotalNumberSum = 0,intWaterUserCountYS=0;//总水量、发生水量用户数量
                decimal decWaterTotalCharge = 0, decWSCLFeeSum = 0, decFJFeeSum = 0, decTotalFeeSum = 0;

                DataTable dtListTemp=dtUserList.Copy();
                DataView dv=dtListTemp.DefaultView;
                dv.RowFilter="totalNumber>0";
                intWaterUserCountYS=dv.ToTable().Rows.Count;

                object objTotalNumber = dtUserList.Compute("SUM(totalNumber)", "");
                if (Information.IsNumeric(objTotalNumber))
                    intTotalNumberSum = Convert.ToInt32(objTotalNumber);

                objTotalNumber = dtUserList.Compute("SUM(waterTotalCharge)", "");
                if (Information.IsNumeric(objTotalNumber))
                    decWaterTotalCharge = Convert.ToDecimal(objTotalNumber);

                objTotalNumber = dtUserList.Compute("SUM(extraCharge1)", "");
                if (Information.IsNumeric(objTotalNumber))
                    decWSCLFeeSum = Convert.ToDecimal(objTotalNumber);

                objTotalNumber = dtUserList.Compute("SUM(extraCharge2)", "");
                if (Information.IsNumeric(objTotalNumber))
                    decFJFeeSum = Convert.ToDecimal(objTotalNumber);

                objTotalNumber = dtUserList.Compute("SUM(totalCharge)", "");
                if (Information.IsNumeric(objTotalNumber))
                    decTotalFeeSum = Convert.ToDecimal(objTotalNumber);

                labRecordCount.Text = "共:" + dtUserList.Rows.Count + "条;发生水量:" + intWaterUserCountYS + "行,用水量:" + intTotalNumberSum.ToString() + ";水费:" + decWaterTotalCharge.ToString("F2") +
                    ";污水处理费:" + decWSCLFeeSum.ToString("F2") + ";附加费:" + decFJFeeSum.ToString("F2") + ";水费总计:" + decTotalFeeSum.ToString("F2");

                dgWaterList.DataSource = dtUserList;

                if (dtUserList.Rows.Count == 0)
                {
                    toolSave.Enabled = false;
                    toolNull.Enabled = false;
                    toolDelete.Enabled = false;
                    toolDeleteAll.Enabled = false;
                    toolModifyWaterUserName.Enabled = false;
                    foreach (Control con in gpbWaterUserMES.Controls)
                    {
                        if (con is TextBox)
                            ((TextBox)con).Clear();
                    }
                }
                else
                {
                    toolSave.Enabled = true;
                    toolNull.Enabled = true;
                    toolDelete.Enabled = true;
                    toolDeleteAll.Enabled = true;
                    toolModifyWaterUserName.Enabled = true;
                    DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(1, 0);
                    dgWaterList_RowEnter(null, ex);
                }

            }
            catch (Exception ex)
            {
                log.Write("抄表管理界面:" + ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
            }
            //for (int i = 0; i < dgWaterList.Rows.Count; i++)
            //{
            //    dgWaterList["waterMeterEndNumber", i].ReadOnly = true;
            //    dgWaterList["totalNumber", i].ReadOnly = true;

            //    object objWaterMeterTypeID = dgWaterList.Rows[i].Cells["waterMeterTypeId"].Value;
            //    if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
            //    {
            //        object objExtraFee = BLLWATERMETERTYPE.GetExtraCharge(" AND waterMeterTypeId='" + objWaterMeterTypeID.ToString() + "'");
            //        if (objExtraFee != null && objExtraFee != DBNull.Value)
            //        {
            //            string[] strAllExtraFee = objExtraFee.ToString().Split('|');
            //            for (int j = 0; j < strAllExtraFee.Length; j++)
            //            {
            //                string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
            //                if (strSingleExtraFee[0].Contains("F"))
            //                {
            //                    string strNum = strSingleExtraFee[0].Substring(1, 1);
            //                    dgWaterList.Columns["extraCharge" + strNum].Visible = true;
            //                    dgWaterList.Columns["extraChargePrice" + strNum].Visible = true;
            //                    dgWaterList.Rows[i].Cells["extraChargePrice" + strNum].Value = strSingleExtraFee[1];
            //                    dgWaterList.Rows[i].Cells["extraChargetype" + strNum].Value = strSingleExtraFee[2];//附加费计算方式
            //                }
            //            }
            //        }
            //    }

            //    //定量用水情况，直接将用水量置为固定水量。
            //    object objWaterFixValue = dgWaterList.Rows[i].Cells["WATERFIXVALUE"].Value;
            //    if (Information.IsNumeric(objWaterFixValue))
            //        if (Convert.ToInt32(objWaterFixValue) > 0)
            //        {
            //            dgWaterList.Rows[i].Cells["totalNumber"].Value = objWaterFixValue.ToString();
            //            dgWaterList["waterMeterEndNumber", i].ReadOnly = true;


            //            //将用水量描述保存到表格里备用
            //            dgWaterList.Rows[i].Cells["totalNumberDescribe"].Value = "固定水量:" + objWaterFixValue.ToString();

            //            //dgWaterList["waterMeterEndNumber", i].Style.BackColor = colorCellReadOnly;
            //        }
            //        else
            //        {
            //            object objWaterUserState = dgWaterList.Rows[i].Cells["waterUserState"].Value;
            //            if (objWaterUserState != null && objWaterUserState != DBNull.Value)
            //            {
            //                if (objWaterUserState.ToString() == "1")
            //                {
            //                    dgWaterList.Rows[i].Cells["waterUserState"].Value = "有表";

            //                    object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            //                    if (objChecked != null && objChecked != DBNull.Value)
            //                    {
            //                        if (objChecked.ToString() != "1")
            //                        {
            //                            dgWaterList["waterMeterEndNumber", i].ReadOnly = false;
            //                            dgWaterList["waterMeterEndNumber", i].Style.BackColor = colorCellEdit;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    dgWaterList.Rows[i].Cells["waterUserState"].Value = "无表";
            //                    //如果是无表用户

            //                    object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            //                    if (objChecked != null && objChecked != DBNull.Value)
            //                    {
            //                        if (objChecked.ToString() != "1")
            //                        {
            //                            dgWaterList["waterMeterEndNumber", i].ReadOnly = true;
            //                            dgWaterList["totalNumber", i].ReadOnly = false;
            //                            dgWaterList["totalNumber", i].Style.BackColor = colorCellEdit;
            //                        }
            //                    }
            //                }

            //            }
            //        }
            //    else
            //    {
            //        object objWaterUserState = dgWaterList.Rows[i].Cells["waterUserState"].Value;
            //        if (objWaterUserState != null && objWaterUserState != DBNull.Value)
            //        {
            //            if (objWaterUserState.ToString() == "1")
            //            {
            //                dgWaterList.Rows[i].Cells["waterUserState"].Value = "有表";

            //                object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            //                if (objChecked != null && objChecked != DBNull.Value)
            //                {
            //                    if (objChecked.ToString() != "1")
            //                    {
            //                        dgWaterList["waterMeterEndNumber", i].ReadOnly = false;
            //                        dgWaterList["waterMeterEndNumber", i].Style.BackColor = colorCellEdit;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                dgWaterList.Rows[i].Cells["waterUserState"].Value = "无表";
            //                //如果是无表用户

            //                object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            //                if (objChecked != null && objChecked != DBNull.Value)
            //                {
            //                    if (objChecked.ToString() != "1")
            //                    {
            //                        dgWaterList["waterMeterEndNumber", i].ReadOnly = true;
            //                        dgWaterList["totalNumber", i].ReadOnly = false;
            //                        dgWaterList["totalNumber", i].Style.BackColor = colorCellEdit;
            //                    }
            //                }
            //            }

            //        }
            //    }


            //    if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice1"].Value) > 0)
            //    {
            //        dgWaterList.Columns["extraChargePrice1"].Visible = true;
            //        dgWaterList.Columns["extraCharge1"].Visible = true;
            //    }

            //    if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice2"].Value) > 0)
            //    {
            //        dgWaterList.Columns["extraChargePrice2"].Visible = true;
            //        dgWaterList.Columns["extraCharge2"].Visible = true;
            //    }

            //    if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice3"].Value) > 0)
            //    {
            //        dgWaterList.Columns["extraChargePrice3"].Visible = true;
            //        dgWaterList.Columns["extraCharge3"].Visible = true;
            //    }

            //    if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice4"].Value) > 0)
            //    {
            //        dgWaterList.Columns["extraChargePrice4"].Visible = true;
            //        dgWaterList.Columns["extraCharge4"].Visible = true;
            //    }

            //    if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice5"].Value) > 0)
            //    {
            //        dgWaterList.Columns["extraChargePrice5"].Visible = true;
            //        dgWaterList.Columns["extraCharge5"].Visible = true;
            //    }

            //    if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice6"].Value) > 0)
            //    {
            //        dgWaterList.Columns["extraChargePrice6"].Visible = true;
            //        dgWaterList.Columns["extraCharge6"].Visible = true;
            //    }

            //    if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice7"].Value) > 0)
            //    {
            //        dgWaterList.Columns["extraChargePrice7"].Visible = true;
            //        dgWaterList.Columns["extraCharge7"].Visible = true;
            //    }

            //    if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice8"].Value) > 0)
            //    {
            //        dgWaterList.Columns["extraChargePrice8"].Visible = true;
            //        dgWaterList.Columns["extraCharge8"].Visible = true;
            //    }

            //    object objWaterMeterRecord = dgWaterList.Rows[i].Cells["waterUserHouseType"].Value;
            //    if (objWaterMeterRecord != null && objWaterMeterRecord != DBNull.Value)
            //    {
            //        if (objWaterMeterRecord.ToString() == "1")
            //            dgWaterList.Rows[i].Cells["waterUserHouseType"].Value = "楼房";
            //        else
            //            dgWaterList.Rows[i].Cells["waterUserHouseType"].Value = "平房";

            //    }


            //    //根据chargestate判断当前抄表的进度，0已初始化抄表记录，1已抄表，2已预打发票，3已收费
            //    objWaterMeterRecord = dgWaterList.Rows[i].Cells["chargeState"].Value;
            //    if (objWaterMeterRecord != null && objWaterMeterRecord != DBNull.Value)
            //    {
            //        if (objWaterMeterRecord.ToString() == "1")
            //        {
            //            dgWaterList.Rows[i].Cells["chargeState"].Value = "已抄表";
            //            dgWaterList.Rows[i].DefaultCellStyle.ForeColor = colorSave;

            //            object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            //            if (objChecked != null && objChecked != DBNull.Value)
            //            {
            //                if (objChecked.ToString() == "1")
            //                {
            //                    dgWaterList.Rows[i].Cells["checkState"].Value = "已审核";
            //                    dgWaterList["waterMeterEndNumber", i].ReadOnly = true;//禁止编辑本期读数
            //                    dgWaterList["totalNumber", i].ReadOnly = true;//禁止编辑本期读数
            //                    dgWaterList.Rows[i].DefaultCellStyle.ForeColor = colorChecked;

            //                    dgWaterList.Columns["checkDateTime"].Visible = true;
            //                    dgWaterList.Columns["checker"].Visible = true;
            //                }
            //                else
            //                {
            //                    dgWaterList.Rows[i].Cells["checkState"].Value = "未审核";
            //                }
            //            }
            //            else
            //            {
            //                dgWaterList.Rows[i].Cells["checkState"].Value = "未审核";
            //                //dgWaterList["waterMeterEndNumber", i].ReadOnly = false;//禁止编辑本期读数
            //            }
            //        }
            //        else if (objWaterMeterRecord.ToString() == "0")
            //        {
            //            dgWaterList.Rows[i].Cells["chargeState"].Value = "未抄表";

            //            object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            //            if (objChecked != null && objChecked != DBNull.Value)
            //            {
            //                if (objChecked.ToString() == "1")
            //                {
            //                    dgWaterList.Rows[i].Cells["checkState"].Value = "已审核";
            //                    dgWaterList["waterMeterEndNumber", i].ReadOnly = true;//禁止编辑本期读数
            //                    dgWaterList["totalNumber", i].ReadOnly = true;//禁止编辑本期读数
            //                    dgWaterList.Rows[i].DefaultCellStyle.ForeColor = colorChecked;

            //                    dgWaterList.Columns["checkDateTime"].Visible = true;
            //                    dgWaterList.Columns["checker"].Visible = true;
            //                }
            //                else
            //                {
            //                    dgWaterList.Rows[i].Cells["checkState"].Value = "未审核";
            //                }
            //            }
            //            else
            //            {
            //                dgWaterList.Rows[i].Cells["checkState"].Value = "未审核";
            //                //dgWaterList["waterMeterEndNumber", i].ReadOnly = false;//禁止编辑本期读数
            //            }
            //        }
            //        else if (objWaterMeterRecord.ToString() == "2")
            //        {
            //            object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            //            if (objChecked != null && objChecked != DBNull.Value)
            //            {
            //                if (objChecked.ToString() == "1")
            //                {
            //                    dgWaterList.Rows[i].Cells["checkState"].Value = "已审核";
            //                    dgWaterList.Columns["checkDateTime"].Visible = true;
            //                    dgWaterList.Columns["checker"].Visible = true;
            //                }
            //                else
            //                {
            //                    dgWaterList.Rows[i].Cells["checkState"].Value = "未审核";
            //                }
            //            }
            //            else
            //            {
            //                dgWaterList.Rows[i].Cells["checkState"].Value = "未审核";
            //                //dgWaterList["waterMeterEndNumber", i].ReadOnly = false;//禁止编辑本期读数
            //            }


            //            dgWaterList.Rows[i].Cells["chargeState"].Value = "已预收";
            //            dgWaterList["waterMeterEndNumber", i].ReadOnly = true;//禁止编辑本期读数
            //            dgWaterList["totalNumber", i].ReadOnly = true;//禁止编辑本期读数
            //            dgWaterList.Rows[i].DefaultCellStyle.ForeColor = colorCharged;
            //        }
            //        else if (objWaterMeterRecord.ToString() == "3")
            //        {
            //            object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            //            if (objChecked != null && objChecked != DBNull.Value)
            //            {
            //                if (objChecked.ToString() == "1")
            //                {
            //                    dgWaterList.Rows[i].Cells["checkState"].Value = "已审核";
            //                    dgWaterList.Columns["checkDateTime"].Visible = true;
            //                    dgWaterList.Columns["checker"].Visible = true;
            //                }
            //                else
            //                {
            //                    dgWaterList.Rows[i].Cells["checkState"].Value = "未审核";
            //                }
            //            }
            //            else
            //            {
            //                dgWaterList.Rows[i].Cells["checkState"].Value = "未审核";
            //                //dgWaterList["waterMeterEndNumber", i].ReadOnly = false;//禁止编辑本期读数
            //            }

            //            dgWaterList.Rows[i].Cells["chargeState"].Value = "已收费";
            //            dgWaterList["waterMeterEndNumber", i].ReadOnly = true;//禁止编辑本期读数
            //            dgWaterList["totalNumber", i].ReadOnly = true;//禁止编辑本期读数
            //            dgWaterList.Rows[i].DefaultCellStyle.ForeColor = colorCharged;
            //        }
            //    }


            //    ////根据chargestate判断当前抄表的进度，0已初始化抄表记录，1已抄表，2已预打发票，3已收费
            //    //objWaterMeterRecord = dgWaterList.Rows[i].Cells["chargeState"].Value;
            //    //if (objWaterMeterRecord != null && objWaterMeterRecord != DBNull.Value)
            //    //{
            //    //    if (objWaterMeterRecord.ToString() == "2")
            //    //    {
            //    //        dgWaterList.Rows[i].Cells["chargeState"].Value = "已预收";
            //    //        dgWaterList["waterMeterEndNumber", i].ReadOnly = true;//禁止编辑本期读数
            //    //        dgWaterList.Rows[i].DefaultCellStyle.ForeColor = colorCharged;
            //    //    }
            //    //    else if (objWaterMeterRecord.ToString() == "3")
            //    //    {
            //    //        dgWaterList.Rows[i].Cells["chargeState"].Value = "已收费";
            //    //        dgWaterList["waterMeterEndNumber", i].ReadOnly = true;//禁止编辑本期读数
            //    //        dgWaterList.Rows[i].DefaultCellStyle.ForeColor = colorCharged;
            //    //    }
            //    //}

            //    objWaterMeterRecord = dgWaterList.Rows[i].Cells["agentsign"].Value;
            //    if (objWaterMeterRecord != null && objWaterMeterRecord != DBNull.Value)
            //    {
            //        if (objWaterMeterRecord.ToString() == "2")
            //            dgWaterList.Rows[i].Cells["agentsign"].Value = "不托收";
            //        else if (objWaterMeterRecord.ToString() == "1")
            //            dgWaterList.Rows[i].Cells["agentsign"].Value = "托收";
            //        else
            //            dgWaterList.Rows[i].Cells["agentsign"].Value = objWaterMeterRecord.ToString();

            //    }
            //}
        }

        /// <summary>
        /// 根据用水类别的阶梯水价获取平均单价和计算过程
        /// </summary>
        /// <param name="decTotalNumber">总用水量</param>
        /// <param name="strTrapePriceString">阶梯水价说明</param>
        /// <param name="intNotReadMonths">未抄月份</param>
        /// <returns></returns>
        private string[] GetAvePrice(decimal decTotalNumber, string strTrapePriceString,int intNotReadMonths)
        {
            string[] strComputeTrape = new string[3];
            //string strTrapePriceString="0-32:1.52|32-50:2.3|50-80:3.5|80-100:4.5|100-120:6";
            string[] strTrapePrice = strTrapePriceString.Split('|');
            decimal decWaterSum = 0, decWaterTotalNumber = decTotalNumber;
            for (int i = strTrapePrice.Length - 1; i >= 0; i--)
            {
                string[] strJTAndPrice = strTrapePrice[i].Split(':');
                string[] strJT = strJTAndPrice[0].Split('-');
                if (Information.IsNumeric(strJT[0]) && Information.IsNumeric(strJT[1]))
                {
                    if (decTotalNumber > (Convert.ToDecimal(strJT[0])*intNotReadMonths) && decTotalNumber <= (Convert.ToDecimal(strJT[1])*intNotReadMonths))
                    {
                        decWaterSum += (decTotalNumber - (Convert.ToDecimal(strJT[0])*intNotReadMonths)) * (Convert.ToDecimal(strJTAndPrice[1]));

                        if (strComputeTrape[1] != null)
                            strComputeTrape[1] += "+(" + decTotalNumber.ToString() + "-" + (Convert.ToDecimal(strJT[0]) * intNotReadMonths) + ")*" + strJTAndPrice[1];
                        else
                            strComputeTrape[1] += "计算过程:(" + decTotalNumber.ToString() + "-" + (Convert.ToDecimal(strJT[0]) * intNotReadMonths) + ")*" + strJTAndPrice[1];

                        decTotalNumber = (Convert.ToDecimal(strJT[0]) * intNotReadMonths);
                        //decTotalNumber = decTotalNumber - Convert.ToDecimal(strJT[0]);
                    }
                    else
                        continue;
                }

            }
            if (decWaterTotalNumber > 0)
                strComputeTrape[0] = (decWaterSum / decWaterTotalNumber).ToString("f3");
            else
                strComputeTrape[0] = "0";
            strComputeTrape[1] += "=" + decWaterSum.ToString() + "÷" + decWaterTotalNumber.ToString() + "=" + strComputeTrape[0];
            strComputeTrape[2] = decWaterSum.ToString("F2") ;
            return strComputeTrape;
        }
        private void cmbWaterUserTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode tn = trMeterReading.SelectedNode;
            if (tn != null)
            {
                string[] strNodeID = tn.Name.Split('|');
                RefreshData(strNodeID);
            }
        }

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TreeNode tn = trMeterReading.SelectedNode;
                if (tn != null)
                {
                    string[] strNodeID = tn.Name.Split('|');
                    RefreshData(strNodeID);
                }
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

        #region 自定义方法
        /// <summary>
        /// 画单元格
        /// </summary>
        /// <param name="e"></param>
        private void DrawCell(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            Brush gridBrush = new SolidBrush(dgWaterList.GridColor);
            SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int cellwidth;
            //上面相同的行数
            int UpRows = 0;
            //下面相同的行数
            int DownRows = 0;
            //总行数
            int count = 0;
            cellwidth = e.CellBounds.Width;
            Pen gridLinePen = new Pen(gridBrush);
            string curValue = e.Value == null ? "" : e.Value.ToString().Trim();
            string curValueID = dgWaterList.Rows[e.RowIndex].Cells["waterUserId"].Value == null ? "" : dgWaterList.Rows[e.RowIndex].Cells["waterUserId"].Value.ToString().Trim();
            //if (!string.IsNullOrEmpty(curValue))
            //{
            #region 获取下面的行数
            for (int i = e.RowIndex; i < dgWaterList.Rows.Count; i++)
            {
                object objValue = dgWaterList.Rows[i].Cells[e.ColumnIndex].Value;
                string strValue = objValue == null ? "" : objValue.ToString();
                if (strValue.Equals(curValue) && dgWaterList.Rows[i].Cells["waterUserId"].Value.ToString().Equals(curValueID))
                //if (dgWaterList.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                {
                    //dgWaterList.Rows[i].Cells[e.ColumnIndex].Selected = dgWaterList.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;

                    DownRows++;
                    if (e.RowIndex != i)
                    {
                        cellwidth = cellwidth < dgWaterList.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgWaterList.Rows[i].Cells[e.ColumnIndex].Size.Width;
                    }
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region 获取上面的行数
            for (int i = e.RowIndex; i >= 0; i--)
            {
                object objValue = dgWaterList.Rows[i].Cells[e.ColumnIndex].Value;
                string strValue = objValue == null ? "" : objValue.ToString();
                if (strValue.Equals(curValue) && dgWaterList.Rows[i].Cells["waterUserId"].Value.ToString().Equals(curValueID))
                //if (dgWaterList.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                {
                    //dgWaterList.Rows[i].Cells[e.ColumnIndex].Selected = dgWaterList.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
                    UpRows++;
                    if (e.RowIndex != i)
                    {
                        cellwidth = cellwidth < dgWaterList.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgWaterList.Rows[i].Cells[e.ColumnIndex].Size.Width;
                    }
                }
                else
                {
                    break;
                }
            }
            #endregion
            count = DownRows + UpRows - 1;
            if (count < 2)
            {
                return;
            }
            //}
            if (dgWaterList.Rows[e.RowIndex].Selected)
            {
                backBrush.Color = e.CellStyle.SelectionBackColor;
                fontBrush.Color = e.CellStyle.SelectionForeColor;
            }
            //以背景色填充
            e.Graphics.FillRectangle(backBrush, e.CellBounds);
            //画字符串
            PaintingFont(e, cellwidth, UpRows, DownRows, count);
            if (DownRows == 1)
            {
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                count = 0;
            }
            // 画右边线
            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

            e.Handled = true;
        }
        /// <summary>
        /// 画字符串
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cellwidth"></param>
        /// <param name="UpRows"></param>
        /// <param name="DownRows"></param>
        /// <param name="count"></param>
        private void PaintingFont(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, int cellwidth, int UpRows, int DownRows, int count)
        {
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
            int fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
            int cellheight = e.CellBounds.Height;

            if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
            {
                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
        }
        #endregion

        void cmbModifyValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }


        private void btFold_Click(object sender, EventArgs e)
        {
            if (btFold.Text == "<<")
            {
                btFold.Dock = DockStyle.Right;
                trMeterReading.Margin = new Padding(0);
                trMeterReading.Width = 35;
                btFold.Text = ">>";

            }
            else
            {
                trMeterReading.Width = 132;
                btFold.Dock = DockStyle.None;
                btFold.Text = "<<";
            }

        }

        private void dgWaterList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Aquamarine;
            if (dgWaterList.CurrentCell.ColumnIndex > 0)
            {
                if (dgWaterList.Columns[dgWaterList.CurrentCell.ColumnIndex].Name == "waterMeterEndNumber")
                {
                    TextBox tx = e.Control as TextBox;

                    // Remove an existing event-handler, if present, to avoid   
                    // adding multiple handlers when the editing control is reused. 
                    tx.KeyPress -= new KeyPressEventHandler(tx_KeyPress);
                    //tx.TextChanged -= new EventHandler(tx_TextChanged);
                    tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
                    //tx.TextChanged += new EventHandler(tx_TextChanged);
                    tx.Validating -= new CancelEventHandler(tx_Validating);
                    tx.Validating += new CancelEventHandler(tx_Validating);
                }
                //if (dgWaterList.Columns[dgWaterList.CurrentCell.ColumnIndex].Name == "waterMeterLastNumber")
                //{
                //    TextBox txWaterMeterLastNumber = e.Control as TextBox;

                //    // Remove an existing event-handler, if present, to avoid   
                //    // adding multiple handlers when the editing control is reused. 
                //    txWaterMeterLastNumber.KeyPress -= new KeyPressEventHandler(tx_KeyPress);
                //    //tx.TextChanged -= new EventHandler(tx_TextChanged);
                //    txWaterMeterLastNumber.KeyPress += new KeyPressEventHandler(tx_KeyPress);
                //    //tx.TextChanged += new EventHandler(tx_TextChanged);
                //    txWaterMeterLastNumber.Validating -= new CancelEventHandler(tx_Validating);
                //    txWaterMeterLastNumber.Validating += new CancelEventHandler(txWaterMeterLastNumber_Validating);
                //}
            }
        }

        void txWaterMeterLastNumber_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt=(TextBox)sender;
            if (!Information.IsNumeric(txt.Text))
            {
                e.Cancel = true;
                mes.Show("请输入数字!");
            }
            int intRowIndex = dgWaterList.CurrentCell.RowIndex;
            object objReadMeterRecordID = dgWaterList.Rows[intRowIndex].Cells["readMeterRecordId"].Value;
            string strUpdateReadMeterRecord = "UPDATE readMeterRecord SET waterMeterLastNumber=" + txt.Text + " WHERE readMeterRecordId='"+objReadMeterRecordID.ToString()+"'";
            if (BLLreadMeterRecord.Excute(strUpdateReadMeterRecord)==0)
            {
                mes.Show("更新上月读数失败,请重新更改!");
            }
        }

        void tx_Validating(object sender, CancelEventArgs e)
        {
            //记录用水量计算过程
            string strTotalNumberDescripe = "计算过程:";

            TextBox txt = (TextBox)sender;
            if (txt.Text.Trim() == "")
                return;
            if (!Information.IsNumeric(txt.Text))
            {
                txt.Text = "0";
                dgWaterList.CurrentCell.Value = "0";
            }
            int intRowIndex = dgWaterList.CurrentCell.RowIndex;

            //object obEndNum = dgWaterList.CurrentCell.FormattedValue;
            object objLastNum = dgWaterList.Rows[intRowIndex].Cells["waterMeterLastNumber"].Value;

            int intEndNum = 0;
            object obEndNum = dgWaterList.Rows[intRowIndex].Cells["waterMeterEndNumber"].Value;
            if (Information.IsNumeric(obEndNum))
            {
                intEndNum = Convert.ToInt32(obEndNum);
            }
            else
                return;
            //分表读数
            int intSubMeterNum = 0;
            object objSubMeterNum = dgWaterList.Rows[intRowIndex].Cells["SUBMETERNUMBER"].FormattedValue;
            if(Information.IsNumeric(objSubMeterNum))
            {
                intSubMeterNum = Convert.ToInt32(objSubMeterNum);
            }


            if (dgWaterList.Columns[dgWaterList.CurrentCell.ColumnIndex].Name == "waterMeterEndNumber")
                intEndNum = Convert.ToInt32(txt.Text);
            else if(dgWaterList.Columns[dgWaterList.CurrentCell.ColumnIndex].Name == "SUBMETERNUMBER")
                intSubMeterNum = Convert.ToInt32(txt.Text);

            int intWaterTotalNumber = intEndNum - Convert.ToInt32(objLastNum) - intSubMeterNum;//计算表读数
            object objIsReverse = dgWaterList.Rows[intRowIndex].Cells["IsReverse"].Value;
            if (objIsReverse != null && objIsReverse != DBNull.Value)
                if (objIsReverse.ToString() == "1" && intWaterTotalNumber < 0)
                    intWaterTotalNumber = 0 - intWaterTotalNumber;

            strTotalNumberDescripe = strTotalNumberDescripe + intEndNum + "-" + objLastNum.ToString() +"-"+ intSubMeterNum+"=" + intWaterTotalNumber + "(本月用水量)";

            //根据倍率计算总用水量
            object objWaterMeterMagnification = dgWaterList.Rows[intRowIndex].Cells["waterMeterMagnification"].Value;
            if (Information.IsNumeric(objWaterMeterMagnification))
                if (Convert.ToInt32(objWaterMeterMagnification) > 0)
                {
                    intWaterTotalNumber = intWaterTotalNumber * Convert.ToInt32(objWaterMeterMagnification);
                    strTotalNumberDescripe = strTotalNumberDescripe + "×" + objWaterMeterMagnification.ToString() + "(倍率)=" + intWaterTotalNumber;
                }

            ////计算水损量
            //int intWaterLossNumber = 0;
            //object objWaterMeterSizeId = dgWaterList.Rows[intRowIndex].Cells["waterMeterSizeId"].Value;
            //if (objWaterMeterSizeId != null && objWaterMeterSizeId != DBNull.Value)
            //{
            //    DataTable dtWaterSize = BLLwaterMeterSize.Query(" AND waterMeterSizeId='" + objWaterMeterSizeId.ToString() + "'");
            //    if (dtWaterSize.Rows.Count > 0)
            //    {
            //        object objLossType = dtWaterSize.Rows[0]["waterLossComputeType"];
            //        object objLossValue = dtWaterSize.Rows[0]["waterLossValue"];
            //        if (objLossType != null && objLossType != DBNull.Value)
            //        {
            //            if (objLossType.ToString() == "1")
            //                intWaterLossNumber = (objLossValue == null || objLossValue == DBNull.Value) ? 0 : (int)Math.Floor(Convert.ToDecimal(objLossValue) * intWaterTotalNumber + (decimal)0.5);//四舍五入不准确的另一种实现方式
            //            else
            //                intWaterLossNumber = (objLossValue == null || objLossValue == DBNull.Value) ? 0 : (int)Math.Floor(Convert.ToDecimal(objLossValue) + (decimal)0.5);//四舍五入不准确的另一种实现方式
            //        }
            //    }
            //}

            //if (intWaterTotalNumber != 0)
            //{
            //    //如果用水量为负，默认水表倒装，应减去水损得出总用水量
            //    intWaterTotalNumber = intWaterTotalNumber < 0 ? (intWaterTotalNumber - intWaterLossNumber) : (intWaterTotalNumber + intWaterLossNumber);
            //    strTotalNumberDescripe = intWaterTotalNumber < 0 ? (strTotalNumberDescripe + "-" + intWaterLossNumber + "(水损)=" + intWaterTotalNumber) : (strTotalNumberDescripe + "+" + intWaterLossNumber + "(水损)=" + intWaterTotalNumber);
            //}
            //倒装检测
            if (intWaterTotalNumber < 0)
                if (mes.ShowQ("第'" + (intRowIndex + 1).ToString() + "'行本期读数小于上期读数,是否按照水表倒装方式计算?" + Environment.NewLine + "倒装计算会将水量及水费信息取绝对值计算") != DialogResult.OK)
                {
                    //e.Cancel = true;
                    return;
                }
                else
                {
                    intWaterTotalNumber = Math.Abs(intWaterTotalNumber);
                    dgWaterList.Rows[intRowIndex].Cells["totalNumber"].Value = intWaterTotalNumber.ToString();
                }

            dgWaterList.Rows[intRowIndex].Cells["totalNumber"].Value = intWaterTotalNumber.ToString();

            //将用水量描述保存到表格里备用
            dgWaterList.Rows[intRowIndex].Cells["totalNumberDescribe"].Value = strTotalNumberDescripe;

        }
        //第一种方法：
        //yournumber   =   System.Math   .Abs   (yournumber);
        //第二种方法：
        //int a=55; //a可正可负
        //int result=a>0 ? a:(-1*a);
        //输出结果是绝对值
        void tx_TextChanged(object sender, EventArgs e)
        {
            //记录用水量计算过程
            string strTotalNumberDescripe = "计算过程:";

            TextBox txt = (TextBox)sender;
            if (!Information.IsNumeric(txt.Text))
            {
                txt.Text = "0";
                dgWaterList.CurrentCell.Value = "0";
            }
            int intRowIndex = dgWaterList.CurrentCell.RowIndex;
            object obEndNum=dgWaterList.CurrentCell.FormattedValue;
            object objLastNum = dgWaterList.Rows[intRowIndex].Cells["waterMeterLastNumber"].Value;
            int intWaterTotalNumber = Convert.ToInt32(txt.Text) - Convert.ToInt32(objLastNum);//计算表读数
            strTotalNumberDescripe = strTotalNumberDescripe + txt.Text + "-" + objLastNum.ToString() + "=" + intWaterTotalNumber + "(本月用水量)";

            //根据倍率计算总用水量
            object objWaterMeterMagnification = dgWaterList.Rows[intRowIndex].Cells["waterMeterMagnification"].Value;
            if (Information.IsNumeric(objWaterMeterMagnification))
                if (Convert.ToInt32(objWaterMeterMagnification) > 0)
                {
                    intWaterTotalNumber = intWaterTotalNumber * Convert.ToInt32(objWaterMeterMagnification);
                    strTotalNumberDescripe = strTotalNumberDescripe + "×" + objWaterMeterMagnification.ToString() + "(倍率)=" + intWaterTotalNumber;
                }

            //计算水损量
            int intWaterLossNumber = 0;
            object objWaterMeterSizeId = dgWaterList.Rows[intRowIndex].Cells["waterMeterSizeId"].Value;
            if (objWaterMeterSizeId != null && objWaterMeterSizeId != DBNull.Value)
            {
                DataTable dtWaterSize = BLLwaterMeterSize.Query(" AND waterMeterSizeId='" + objWaterMeterSizeId.ToString() + "'");
                if (dtWaterSize.Rows.Count > 0)
                {
                    object objLossType = dtWaterSize.Rows[0]["waterLossComputeType"];
                    object objLossValue = dtWaterSize.Rows[0]["waterLossValue"];
                    if (objLossType != null && objLossType != DBNull.Value)
                    {
                        if (objLossType.ToString() == "1")
                            intWaterLossNumber = (objLossValue == null || objLossValue == DBNull.Value) ? 0 : (int)Math.Floor(Convert.ToDecimal(objLossValue) * intWaterTotalNumber + (decimal)0.5);//四舍五入不准确的另一种实现方式
                        else
                            intWaterLossNumber = (objLossValue == null || objLossValue == DBNull.Value) ? 0 : (int)Math.Floor(Convert.ToDecimal(objLossValue) + (decimal)0.5);//四舍五入不准确的另一种实现方式
                    }
                }
            }

            if (intWaterTotalNumber != 0)
            {
                //如果用水量为负，默认水表倒装，应减去水损得出总用水量
                intWaterTotalNumber = intWaterTotalNumber < 0 ? (intWaterTotalNumber - intWaterLossNumber) : (intWaterTotalNumber + intWaterLossNumber);
                strTotalNumberDescripe = intWaterTotalNumber < 0 ? (strTotalNumberDescripe + "-" + intWaterLossNumber + "(水损)=" + intWaterTotalNumber) : (strTotalNumberDescripe + "+" + intWaterLossNumber + "(水损)=" + intWaterTotalNumber);
            }

            dgWaterList.Rows[intRowIndex].Cells["totalNumber"].Value = intWaterTotalNumber.ToString();

            //将用水量描述保存到表格里备用
            dgWaterList.Rows[intRowIndex].Cells["totalNumberDescribe"].Value = strTotalNumberDescripe;

            #region 根据用水量计算各种费用
            dgWaterList.Rows[intRowIndex].Cells["avePrice"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["avePriceDescribe"].Value = "无";
            dgWaterList.Rows[intRowIndex].Cells["waterTotalCharge"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["extraCharge1"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["extraCharge2"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["extraCharge3"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["extraCharge4"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["extraCharge5"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["extraCharge6"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["extraCharge7"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["extraCharge8"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["extraTotalCharge"].Value = "0";
            dgWaterList.Rows[intRowIndex].Cells["totalCharge"].Value = "0";


            if (intWaterTotalNumber == 0)
                return;

            //object objWaterMeterRecordTrapePrice = BLLWATERMETERTYPE.GetTrapePrice(" AND waterMeterTypeId='" + objWaterMeterTypeID.ToString() + "'");
            object objWaterMeterRecordTrapePrice = dgWaterList.Rows[intRowIndex].Cells["trapezoidPrice"].Value;
            if (objWaterMeterRecordTrapePrice != null && objWaterMeterRecordTrapePrice != DBNull.Value)
            {

                int intNotReadMonth = 1;//获取未抄月份数量，计算滞纳金
                try
                {
                    object objLastReadMonths = dgWaterList.Rows[intRowIndex].Cells["lastNumberYearMonth"].Value;
                    if (objLastReadMonths != null && objLastReadMonths != DBNull.Value)
                    {
                        DateTime dtLastReadDate = Convert.ToDateTime(objLastReadMonths.ToString().Substring(0, 4) + "-" + objLastReadMonths.ToString().Substring(4, 2) + "-01");
                        intNotReadMonth = dtNow.Year * 12 + dtNow.Month - dtLastReadDate.Year * 12 + dtLastReadDate.Month;
                    }
                }
                catch (Exception ex)
                {
                    log.Write(ex.ToString(), MsgType.Error);
                }

                dgWaterList.Rows[intRowIndex].Cells["trapezoidPrice"].Value = objWaterMeterRecordTrapePrice;
                string[] strWaterMeterRecordTrapePrice = GetAvePrice(Convert.ToDecimal(intWaterTotalNumber), objWaterMeterRecordTrapePrice.ToString(), intNotReadMonth);
                dgWaterList.Rows[intRowIndex].Cells["avePrice"].Value = strWaterMeterRecordTrapePrice[0];
                dgWaterList.Rows[intRowIndex].Cells["avePriceDescribe"].Value = strWaterMeterRecordTrapePrice[1];

                //计算水费
                dgWaterList.Rows[intRowIndex].Cells["waterTotalCharge"].Value = strWaterMeterRecordTrapePrice[2];

            }

            object objWaterTotalCharge = dgWaterList.Rows[intRowIndex].Cells["waterTotalCharge"].Value;
            ////计算水费
            //dgWaterList.Rows[intRowIndex].Cells["waterTotalCharge"].Value = (Convert.ToDecimal(dgWaterList.Rows[intRowIndex].Cells["avePrice"].Value) * Convert.ToDecimal(objTotalNumber)).ToString("f2");

            //计算附加费
            object objExtraChargePrice1 = dgWaterList.Rows[intRowIndex].Cells["extraChargePrice1"].Value;
            object objExtralChargeType1 = dgWaterList.Rows[intRowIndex].Cells["extraChargetype1"].Value;
            if (objExtralChargeType1 != null && objExtralChargeType1 != DBNull.Value)
                if (objExtralChargeType1.ToString() == "2")//如果计算方式是按水费计算
                    dgWaterList.Rows[intRowIndex].Cells["extraCharge1"].Value = (objExtraChargePrice1 == null || objExtraChargePrice1 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice1) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                else
                    dgWaterList.Rows[intRowIndex].Cells["extraCharge1"].Value = (objExtraChargePrice1 == null || objExtraChargePrice1 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice1) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            else
                dgWaterList.Rows[intRowIndex].Cells["extraCharge1"].Value = (objExtraChargePrice1 == null || objExtraChargePrice1 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice1) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            object objExtraCharge1 = dgWaterList.Rows[intRowIndex].Cells["extraCharge1"].Value;

            object objExtraChargePrice2 = dgWaterList.Rows[intRowIndex].Cells["extraChargePrice2"].Value;
            object objExtralChargeType2 = dgWaterList.Rows[intRowIndex].Cells["extraChargetype2"].Value;
            if (objExtralChargeType2 != null && objExtralChargeType2 != DBNull.Value)
                if (objExtralChargeType2.ToString() == "2")//如果计算方式是按水费计算
                    dgWaterList.Rows[intRowIndex].Cells["extraCharge2"].Value = (objExtraChargePrice2 == null || objExtraChargePrice2 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice2) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                else
                    dgWaterList.Rows[intRowIndex].Cells["extraCharge2"].Value = (objExtraChargePrice2 == null || objExtraChargePrice2 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice2) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            else
                dgWaterList.Rows[intRowIndex].Cells["extraCharge2"].Value = (objExtraChargePrice2 == null || objExtraChargePrice2 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice2) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            object objExtraCharge2 = dgWaterList.Rows[intRowIndex].Cells["extraCharge2"].Value;

            object objExtraChargePrice3 = dgWaterList.Rows[intRowIndex].Cells["extraChargePrice3"].Value;
            object objExtralChargeType3 = dgWaterList.Rows[intRowIndex].Cells["extraChargetype3"].Value;
            if (objExtralChargeType3 != null && objExtralChargeType3 != DBNull.Value)
                if (objExtralChargeType3.ToString() == "2")//如果计算方式是按水费计算
                    dgWaterList.Rows[intRowIndex].Cells["extraCharge3"].Value = (objExtraChargePrice3 == null || objExtraChargePrice3 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice3) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                else
                    dgWaterList.Rows[intRowIndex].Cells["extraCharge3"].Value = (objExtraChargePrice3 == null || objExtraChargePrice3 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice3) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            else
                dgWaterList.Rows[intRowIndex].Cells["extraCharge3"].Value = (objExtraChargePrice3 == null || objExtraChargePrice3 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice3) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            object objExtraCharge3 = dgWaterList.Rows[intRowIndex].Cells["extraCharge3"].Value;

            //object objExtraChargePrice4 = dgWaterList.Rows[intRowIndex].Cells["extraChargePrice4"].Value;
            //object objExtralChargeType4 = dgWaterList.Rows[intRowIndex].Cells["extraChargetype4"].Value;
            //if (objExtralChargeType4 != null && objExtralChargeType4 != DBNull.Value)
            //    if (objExtralChargeType4.ToString() == "2")//如果计算方式是按水费计算
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge4"].Value = (objExtraChargePrice4 == null || objExtraChargePrice4 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice4) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
            //    else
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge4"].Value = (objExtraChargePrice4 == null || objExtraChargePrice4 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice4) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //else
            //    dgWaterList.Rows[intRowIndex].Cells["extraCharge4"].Value = (objExtraChargePrice4 == null || objExtraChargePrice4 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice4) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //object objExtraCharge4 = dgWaterList.Rows[intRowIndex].Cells["extraCharge4"].Value;

            //object objExtraChargePrice5 = dgWaterList.Rows[intRowIndex].Cells["extraChargePrice5"].Value;
            //object objExtralChargeType5 = dgWaterList.Rows[intRowIndex].Cells["extraChargetype5"].Value;
            //if (objExtralChargeType5 != null && objExtralChargeType5 != DBNull.Value)
            //    if (objExtralChargeType5.ToString() == "2")//如果计算方式是按水费计算
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge5"].Value = (objExtraChargePrice5 == null || objExtraChargePrice5 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice5) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
            //    else
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge5"].Value = (objExtraChargePrice5 == null || objExtraChargePrice5 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice5) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //else
            //    dgWaterList.Rows[intRowIndex].Cells["extraCharge5"].Value = (objExtraChargePrice5 == null || objExtraChargePrice5 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice5) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //object objExtraCharge5 = dgWaterList.Rows[intRowIndex].Cells["extraCharge5"].Value;

            //object objExtraChargePrice6 = dgWaterList.Rows[intRowIndex].Cells["extraChargePrice6"].Value;
            //object objExtralChargeType6 = dgWaterList.Rows[intRowIndex].Cells["extraChargetype6"].Value;
            //if (objExtralChargeType6 != null && objExtralChargeType6 != DBNull.Value)
            //    if (objExtralChargeType6.ToString() == "2")//如果计算方式是按水费计算
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge6"].Value = (objExtraChargePrice6 == null || objExtraChargePrice6 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice6) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
            //    else
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge6"].Value = (objExtraChargePrice6 == null || objExtraChargePrice6 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice6) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //else
            //    dgWaterList.Rows[intRowIndex].Cells["extraCharge6"].Value = (objExtraChargePrice6 == null || objExtraChargePrice6 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice6) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //object objExtraCharge6 = dgWaterList.Rows[intRowIndex].Cells["extraCharge6"].Value;

            //object objExtraChargePrice7 = dgWaterList.Rows[intRowIndex].Cells["extraChargePrice7"].Value;
            //object objExtralChargeType7 = dgWaterList.Rows[intRowIndex].Cells["extraChargetype7"].Value;
            //if (objExtralChargeType7 != null && objExtralChargeType7 != DBNull.Value)
            //    if (objExtralChargeType7.ToString() == "2")//如果计算方式是按水费计算
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge7"].Value = (objExtraChargePrice7 == null || objExtraChargePrice7 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice7) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
            //    else
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge7"].Value = (objExtraChargePrice7 == null || objExtraChargePrice7 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice7) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //else
            //    dgWaterList.Rows[intRowIndex].Cells["extraCharge7"].Value = (objExtraChargePrice7 == null || objExtraChargePrice7 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice7) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //object objExtraCharge7 = dgWaterList.Rows[intRowIndex].Cells["extraCharge7"].Value;

            //object objExtraChargePrice8 = dgWaterList.Rows[intRowIndex].Cells["extraChargePrice8"].Value;
            //object objExtralChargeType8 = dgWaterList.Rows[intRowIndex].Cells["extraChargetype8"].Value;
            //if (objExtralChargeType8 != null && objExtralChargeType8 != DBNull.Value)
            //    if (objExtralChargeType8.ToString() == "2")//如果计算方式是按水费计算
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge8"].Value = (objExtraChargePrice8 == null || objExtraChargePrice8 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice8) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
            //    else
            //        dgWaterList.Rows[intRowIndex].Cells["extraCharge8"].Value = (objExtraChargePrice8 == null || objExtraChargePrice8 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice8) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //else
            //    dgWaterList.Rows[intRowIndex].Cells["extraCharge8"].Value = (objExtraChargePrice8 == null || objExtraChargePrice8 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice8) * Convert.ToDecimal(intWaterTotalNumber)).ToString("f2");
            //object objExtraCharge8 = dgWaterList.Rows[intRowIndex].Cells["extraCharge8"].Value;

            dgWaterList.Rows[intRowIndex].Cells["extraTotalCharge"].Value =
                Convert.ToDecimal(objExtraCharge1) + Convert.ToDecimal(objExtraCharge2) +
                Convert.ToDecimal(objExtraCharge3);
                //+ Convert.ToDecimal(objExtraCharge4) +
                //Convert.ToDecimal(objExtraCharge5) + Convert.ToDecimal(objExtraCharge6) +
                //Convert.ToDecimal(objExtraCharge7) + Convert.ToDecimal(objExtraCharge8);

            dgWaterList.Rows[intRowIndex].Cells["totalCharge"].Value = Convert.ToDecimal(dgWaterList.Rows[intRowIndex].Cells["waterTotalCharge"].Value) + Convert.ToDecimal(dgWaterList.Rows[intRowIndex].Cells["extraTotalCharge"].Value);

            #endregion
        }
        private void tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 实现数据的四舍五入法
        /// </summary>
        /// <param name="v">要进行处理的数据</param>
        /// <param name="x">保留的小数位数</param>
        /// <returns>四舍五入后的结果</returns>
        private double Round(double v, int x)
        {
            bool isNegative = false;
            //如果是负数
            if (v < 0)
            {
                isNegative = true;
                v = -v;
            }

            int IValue = 1;
            for (int i = 1; i <= x; i++)
            {
                IValue = IValue * 10;
            }
            double Int = Math.Round(v * IValue + 0.5, 0);
            v = Int / IValue;

            if (isNegative)
            {
                v = -v;
            }

            return v;
        }
        private void dgWaterList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgWaterList.Columns[e.ColumnIndex].Name == "totalNumber")
                {
                    #region 根据用水量计算各种费用
                    object objTotalNumber=dgWaterList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!Information.IsNumeric(objTotalNumber))
                        return;

                    int intNotReadMonth = 1;//获取未抄月份数量，计算滞纳金
                    try
                    {
                        object objLastReadMonths = dgWaterList.Rows[e.RowIndex].Cells["lastNumberYearMonth"].Value;
                        if (objLastReadMonths != null && objLastReadMonths != DBNull.Value)
                        {
                           DateTime dtLastReadDate= Convert.ToDateTime(objLastReadMonths.ToString().Substring(0, 4) + "-" + objLastReadMonths.ToString().Substring(4, 2) + "-01");
                           intNotReadMonth = dtNow.Year * 12 + dtNow.Month - dtLastReadDate.Year * 12 - dtLastReadDate.Month;
                           if (intNotReadMonth < 1)
                               intNotReadMonth = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Write(ex.ToString(),MsgType.Error);
                    }

                    //object objWaterMeterRecordTrapePrice = BLLWATERMETERTYPE.GetTrapePrice(" AND waterMeterTypeId='" + objWaterMeterTypeID.ToString() + "'");
                    object objWaterMeterRecordTrapePrice = dgWaterList.Rows[e.RowIndex].Cells["trapezoidPrice"].Value;
                    if (objWaterMeterRecordTrapePrice != null && objWaterMeterRecordTrapePrice != DBNull.Value)
                    {
                        dgWaterList.Rows[e.RowIndex].Cells["trapezoidPrice"].Value = objWaterMeterRecordTrapePrice;
                        string[] strWaterMeterRecordTrapePrice = GetAvePrice(Convert.ToDecimal(objTotalNumber), objWaterMeterRecordTrapePrice.ToString(), intNotReadMonth);
                        dgWaterList.Rows[e.RowIndex].Cells["avePrice"].Value = strWaterMeterRecordTrapePrice[0];
                        dgWaterList.Rows[e.RowIndex].Cells["avePriceDescribe"].Value = strWaterMeterRecordTrapePrice[1];

                        //计算水费
                        dgWaterList.Rows[e.RowIndex].Cells["waterTotalCharge"].Value = strWaterMeterRecordTrapePrice[2];

                    }
                    else
                    {
                        dgWaterList.Rows[e.RowIndex].Cells["avePrice"].Value = "0";
                        dgWaterList.Rows[e.RowIndex].Cells["avePriceDescribe"].Value = "无";
                        dgWaterList.Rows[e.RowIndex].Cells["waterTotalCharge"].Value = "0";
                    }

                    object objWaterTotalCharge = dgWaterList.Rows[e.RowIndex].Cells["waterTotalCharge"].Value;
                    ////计算水费
                    //dgWaterList.Rows[e.RowIndex].Cells["waterTotalCharge"].Value = (Convert.ToDecimal(dgWaterList.Rows[intRowIndex].Cells["avePrice"].Value) * Convert.ToDecimal(objTotalNumber)).ToString("f2");

                    //计算附加费
                    object objExtraChargePrice1 = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice1"].FormattedValue;
                    object objExtralChargeType1 = dgWaterList.Rows[e.RowIndex].Cells["extraChargetype1"].FormattedValue;
                    if (objExtralChargeType1 != null && objExtralChargeType1 != DBNull.Value)
                        if (objExtralChargeType1.ToString() == "2")//如果计算方式是按水费计算
                            dgWaterList.Rows[e.RowIndex].Cells["extraCharge1"].Value = (objExtraChargePrice1 == null || objExtraChargePrice1 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice1) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                        else
                            dgWaterList.Rows[e.RowIndex].Cells["extraCharge1"].Value = (objExtraChargePrice1 == null || objExtraChargePrice1 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice1) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    else
                        dgWaterList.Rows[e.RowIndex].Cells["extraCharge1"].Value = (objExtraChargePrice1 == null || objExtraChargePrice1 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice1) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    object objExtraCharge1 = dgWaterList.Rows[e.RowIndex].Cells["extraCharge1"].Value;

                    object objExtraChargePrice2 = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice2"].FormattedValue;
                    object objExtralChargeType2 = dgWaterList.Rows[e.RowIndex].Cells["extraChargetype2"].FormattedValue;
                    if (objExtralChargeType2 != null && objExtralChargeType2 != DBNull.Value)
                        if (objExtralChargeType2.ToString() == "2")//如果计算方式是按水费计算
                            dgWaterList.Rows[e.RowIndex].Cells["extraCharge2"].Value = (objExtraChargePrice2 == null || objExtraChargePrice2 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice2) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                        else
                            dgWaterList.Rows[e.RowIndex].Cells["extraCharge2"].Value = (objExtraChargePrice2 == null || objExtraChargePrice2 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice2) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    else
                        dgWaterList.Rows[e.RowIndex].Cells["extraCharge2"].Value = (objExtraChargePrice2 == null || objExtraChargePrice2 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice2) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    object objExtraCharge2 = dgWaterList.Rows[e.RowIndex].Cells["extraCharge2"].Value;

                    //object objExtraChargePrice3 = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice3"].FormattedValue;
                    //object objExtralChargeType3 = dgWaterList.Rows[e.RowIndex].Cells["extraChargetype3"].FormattedValue;
                    //if (objExtralChargeType3 != null && objExtralChargeType3 != DBNull.Value)
                    //    if (objExtralChargeType3.ToString() == "2")//如果计算方式是按水费计算
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge3"].Value = (objExtraChargePrice3 == null || objExtraChargePrice3 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice3) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                    //    else
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge3"].Value = (objExtraChargePrice3 == null || objExtraChargePrice3 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice3) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //else
                    //    dgWaterList.Rows[e.RowIndex].Cells["extraCharge3"].Value = (objExtraChargePrice3 == null || objExtraChargePrice3 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice3) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //object objExtraCharge3 = dgWaterList.Rows[e.RowIndex].Cells["extraCharge3"].Value;

                    //object objExtraChargePrice4 = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice4"].FormattedValue;
                    //object objExtralChargeType4 = dgWaterList.Rows[e.RowIndex].Cells["extraChargetype4"].FormattedValue;
                    //if (objExtralChargeType4 != null && objExtralChargeType4 != DBNull.Value)
                    //    if (objExtralChargeType4.ToString() == "2")//如果计算方式是按水费计算
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge4"].Value = (objExtraChargePrice4 == null || objExtraChargePrice4 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice4) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                    //    else
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge4"].Value = (objExtraChargePrice4 == null || objExtraChargePrice4 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice4) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //else
                    //    dgWaterList.Rows[e.RowIndex].Cells["extraCharge4"].Value = (objExtraChargePrice4 == null || objExtraChargePrice4 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice4) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //object objExtraCharge4 = dgWaterList.Rows[e.RowIndex].Cells["extraCharge4"].Value;

                    //object objExtraChargePrice5 = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice5"].FormattedValue;
                    //object objExtralChargeType5 = dgWaterList.Rows[e.RowIndex].Cells["extraChargetype5"].FormattedValue;
                    //if (objExtralChargeType5 != null && objExtralChargeType5 != DBNull.Value)
                    //    if (objExtralChargeType5.ToString() == "2")//如果计算方式是按水费计算
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge5"].Value = (objExtraChargePrice5 == null || objExtraChargePrice5 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice5) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                    //    else
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge5"].Value = (objExtraChargePrice5 == null || objExtraChargePrice5 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice5) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //else
                    //    dgWaterList.Rows[e.RowIndex].Cells["extraCharge5"].Value = (objExtraChargePrice5 == null || objExtraChargePrice5 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice5) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //object objExtraCharge5 = dgWaterList.Rows[e.RowIndex].Cells["extraCharge5"].Value;

                    //object objExtraChargePrice6 = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice6"].FormattedValue;
                    //object objExtralChargeType6 = dgWaterList.Rows[e.RowIndex].Cells["extraChargetype6"].FormattedValue;
                    //if (objExtralChargeType6 != null && objExtralChargeType6 != DBNull.Value)
                    //    if (objExtralChargeType6.ToString() == "2")//如果计算方式是按水费计算
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge6"].Value = (objExtraChargePrice6 == null || objExtraChargePrice6 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice6) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                    //    else
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge6"].Value = (objExtraChargePrice6 == null || objExtraChargePrice6 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice6) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //else
                    //    dgWaterList.Rows[e.RowIndex].Cells["extraCharge6"].Value = (objExtraChargePrice6 == null || objExtraChargePrice6 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice6) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //object objExtraCharge6 = dgWaterList.Rows[e.RowIndex].Cells["extraCharge6"].Value;

                    //object objExtraChargePrice7 = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice7"].FormattedValue;
                    //object objExtralChargeType7 = dgWaterList.Rows[e.RowIndex].Cells["extraChargetype7"].FormattedValue;
                    //if (objExtralChargeType7 != null && objExtralChargeType7 != DBNull.Value)
                    //    if (objExtralChargeType7.ToString() == "2")//如果计算方式是按水费计算
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge7"].Value = (objExtraChargePrice7 == null || objExtraChargePrice7 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice7) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                    //    else
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge7"].Value = (objExtraChargePrice7 == null || objExtraChargePrice7 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice7) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //else
                    //    dgWaterList.Rows[e.RowIndex].Cells["extraCharge7"].Value = (objExtraChargePrice7 == null || objExtraChargePrice7 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice7) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //object objExtraCharge7 = dgWaterList.Rows[e.RowIndex].Cells["extraCharge7"].Value;

                    //object objExtraChargePrice8 = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice8"].FormattedValue;
                    //object objExtralChargeType8 = dgWaterList.Rows[e.RowIndex].Cells["extraChargetype8"].FormattedValue;
                    //if (objExtralChargeType8 != null && objExtralChargeType8 != DBNull.Value)
                    //    if (objExtralChargeType8.ToString() == "2")//如果计算方式是按水费计算
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge8"].Value = (objExtraChargePrice8 == null || objExtraChargePrice8 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice8) * Convert.ToDecimal(objWaterTotalCharge)).ToString("f2");
                    //    else
                    //        dgWaterList.Rows[e.RowIndex].Cells["extraCharge8"].Value = (objExtraChargePrice8 == null || objExtraChargePrice8 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice8) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //else
                    //    dgWaterList.Rows[e.RowIndex].Cells["extraCharge8"].Value = (objExtraChargePrice8 == null || objExtraChargePrice8 == DBNull.Value) ? "0" : (Convert.ToDecimal(objExtraChargePrice8) * Convert.ToDecimal(objTotalNumber)).ToString("f2");
                    //object objExtraCharge8 = dgWaterList.Rows[e.RowIndex].Cells["extraCharge8"].Value;

                    //dgWaterList.Rows[e.RowIndex].Cells["extraTotalCharge"].Value =
                    //    Convert.ToDecimal(objExtraCharge1) + Convert.ToDecimal(objExtraCharge2) +
                    //    Convert.ToDecimal(objExtraCharge3) + Convert.ToDecimal(objExtraCharge4) +
                    //    Convert.ToDecimal(objExtraCharge5) + Convert.ToDecimal(objExtraCharge6) +
                    //    Convert.ToDecimal(objExtraCharge7) + Convert.ToDecimal(objExtraCharge8);

                    dgWaterList.Rows[e.RowIndex].Cells["extraTotalCharge"].Value =
                        Convert.ToDecimal(objExtraCharge1) + Convert.ToDecimal(objExtraCharge2);
                    dgWaterList.Rows[e.RowIndex].Cells["totalCharge"].Value = Convert.ToDecimal(dgWaterList.Rows[e.RowIndex].Cells["waterTotalCharge"].Value) + Convert.ToDecimal(dgWaterList.Rows[e.RowIndex].Cells["extraTotalCharge"].Value);

                    if (objTotalNumber == null || objTotalNumber == DBNull.Value)
                        return;
                    int intTotalNumber = 0;
                    if (Information.IsNumeric(objTotalNumber))
                        intTotalNumber = Convert.ToInt32(objTotalNumber);

                    if (intTotalNumber == 0)
                    {
                        //if (mes.ShowQ("第 " + (i + 1).ToString() + " 行用水量 为'0'，确定要保存抄表信息吗?") != DialogResult.OK) 
                        //本期读数如果为0，约定不抄表
                        if (mes.ShowQ("用水量 为'0',确定要保存抄表信息吗?") != DialogResult.OK)
                            return;
                    }
                    else if (intTotalNumber < 0)
                    {
                        if (mes.ShowQ("用水量 为'负',系统默认为水表倒装,确定保存抄表信息吗?") != DialogResult.OK)
                            return;
                        dgWaterList.Rows[e.RowIndex].Cells["totalNumber"].Value = Math.Abs(intTotalNumber);
                    }

                    #region 写入MODEL
                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                    object objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["readMeterRecordId"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.readMeterRecordId = objWaterMeterRead.ToString();

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["waterMeterLastNumber"].EditedFormattedValue;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterLastNumber = Convert.ToInt32(objWaterMeterRead);

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["waterMeterEndNumber"].EditedFormattedValue;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterEndNumber = Convert.ToInt32(objWaterMeterRead);

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["SubMeterNumber"].EditedFormattedValue;
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.SubMeterNumber = Convert.ToInt32(objWaterMeterRead);
                    else
                        dgWaterList.Rows[e.RowIndex].Cells["SubMeterNumber"].Value = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["totalNumber"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.totalNumber = Convert.ToInt32(objWaterMeterRead);

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["totalNumberDescribe"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.totalNumberDescribe = objWaterMeterRead.ToString();

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["avePrice"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.avePrice = Convert.ToDecimal(objWaterMeterRead);

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["avePriceDescribe"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.avePriceDescribe = objWaterMeterRead.ToString();

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["waterTotalCharge"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterTotalCharge = Convert.ToDecimal(objWaterMeterRead);

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice1"].FormattedValue;
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.extraChargePrice1 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraChargePrice1 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice2"].FormattedValue;
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.extraChargePrice2 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraChargePrice2 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice3"].FormattedValue;
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.extraChargePrice3 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraChargePrice3 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice4"].FormattedValue;
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.extraChargePrice4 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraChargePrice4 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice5"].FormattedValue;
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.extraChargePrice5 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraChargePrice5 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice6"].FormattedValue;
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.extraChargePrice6 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraChargePrice6 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice7"].FormattedValue;
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.extraChargePrice7 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraChargePrice7 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice8"].FormattedValue;
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.extraChargePrice8 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraChargePrice8 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraCharge1"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraCharge1 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraCharge1 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraCharge2"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraCharge2 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraCharge2 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraCharge3"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraCharge3 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraCharge3 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraCharge4"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraCharge4 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraCharge4 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraCharge5"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraCharge5 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraCharge5 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraCharge6"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraCharge6 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraCharge6 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraCharge7"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraCharge7 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraCharge7 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraCharge8"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraCharge8 = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraCharge8 = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraTotalCharge"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraTotalCharge = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraTotalCharge = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["trapezoidPrice"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.trapezoidPrice = objWaterMeterRead.ToString();

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["extraTotalCharge"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraTotalCharge = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.extraTotalCharge = 0;

                    objWaterMeterRead = dgWaterList.Rows[e.RowIndex].Cells["totalCharge"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.totalCharge = Convert.ToDecimal(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.totalCharge = 0;

                    MODELreadMeterRecord.chargeState = "1";//已抄表标志
                    MODELreadMeterRecord.readMeterRecordDate = mes.GetDatetimeNow();
                    #endregion

                    if (BLLreadMeterRecord.Update(MODELreadMeterRecord))
                    {
                        dgWaterList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = colorSave;
                        //dgWaterList.Rows[i].Cells["chargeState"].Value = "已抄表";
                    }
                    else
                    {
                        mes.Show("抄表记录保存失败,请重新抄表!");
                        return;
                    }

                    #endregion
                }

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

        private void dgWaterList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //    return;

            //toolDelete.Enabled = true;
            //toolSave.Enabled = true;

            //object objWaterMeterReadRecordID = dgWaterList.CurrentRow.Cells["readMeterRecordId"].Value;
            //if (objWaterMeterReadRecordID == null || objWaterMeterReadRecordID == DBNull.Value)
            //    toolDelete.Enabled = false;

            //    object objChecked = dgWaterList.CurrentRow.Cells["checkState"].Value;
            //    if (objChecked != null && objChecked != DBNull.Value)
            //    {
            //        if (objChecked.ToString() == "已审核")
            //        {
            //            toolSave.Enabled = false;
            //            toolDelete.Enabled = false;
            //        }
            //    }

            //    object objCharged = dgWaterList.CurrentRow.Cells["chargeState"].Value;
            //    if (objCharged != null && objCharged != DBNull.Value)
            //        if (objCharged.ToString() == "已收费" || objCharged.ToString() == "已预打")
            //        {
            //            toolSave.Enabled = false;
            //            toolDelete.Enabled = false;
            //        }

            //object objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserNO"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserNO.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserNO.Clear();
            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserName"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserName.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserName.Clear();
            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserPeopleCount"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserCount.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserCount.Clear();
            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["meterReadingNO"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserMeterReadingNO.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserMeterReadingNO.Clear();
            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["meterReadingPageNo"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtMeterReadingPageNO.Text = objWaterUser.ToString();
            //}
            //else
            //    txtMeterReadingPageNO.Clear();
            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["UserName"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserMeterReader.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserMeterReader.Clear();
            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["areaName"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserArea.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserArea.Clear();
            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserTypeName"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserType.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserType.Clear();
            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserAddress"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserAddress.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserAddress.Clear();
            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserHouseType"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserHouseType.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserHouseType.Clear();

            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserState"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtWaterUserState.Text = objWaterUser.ToString();
            //}
            //else
            //    txtWaterUserState.Clear();

            //objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["isSummaryS"].Value;
            //if (objWaterUser != null && objWaterUser != DBNull.Value)
            //{
            //    txtIsSummary.Text = objWaterUser.ToString();
            //}
            //else
            //    txtIsSummary.Clear();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            dgWaterList.EndEdit();

            bool isNull = false;
            for (int i = 0; i < dgWaterList.Rows.Count; i++)
            {
                object objTotalNumber = dgWaterList.Rows[i].Cells["totalNumber"].Value;
                if (!Information.IsNumeric(objTotalNumber))
                {
                    isNull = true;
                    dgWaterList.CurrentCell = dgWaterList.Rows[i].Cells["waterMeterEndNumber"];
                    break;
                }
            }
            if (isNull)
            {
                if (mes.ShowQ("系统检测到存在本期读数为空的行,将自动跳过，是否继续?") != DialogResult.OK)
                {
                    return;
                }
            }

            for (int i = 0; i < dgWaterList.Rows.Count; i++)
            {


                //object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
                //if (objChecked != null && objChecked != DBNull.Value)
                //    if (objChecked.ToString() == "已审核")
                //    {
                //        mes.Show("第 " + (i + 1).ToString() + " 行抄表记录已审核，系统自动跳过!");
                //        continue;
                //    }

                //object objCharged = dgWaterList.Rows[i].Cells["chargeState"].Value;
                //if (objCharged != null && objCharged != DBNull.Value)
                //    if (objCharged.ToString() == "已收费" || objCharged.ToString() == "已预打")
                //    {
                //        mes.Show("第 " + (i + 1).ToString() + " 行抄表记录已收费，系统自动跳过!");
                //        continue;
                //    }


                int intTotalNumber = 0;
                object objTotalNumber = dgWaterList.Rows[i].Cells["totalNumber"].Value;
                //if (!Information.IsNumeric(objTotalNumber))
                //{
                //    mes.Show("第 " + (i + 1).ToString() + " 行本期读数为空,抄表未保存!");
                //    dgWaterList.CurrentCell = dgWaterList.Rows[i].Cells["waterMeterEndNumber"];
                //    continue;
                //}
                if (Information.IsNumeric(objTotalNumber))
                    intTotalNumber = Convert.ToInt32(objTotalNumber);
                else
                    continue;
                if (intTotalNumber == 0)
                {
                    //if (mes.ShowQ("第 " + (i + 1).ToString() + " 行用水量 为'0'，确定要保存抄表信息吗?") != DialogResult.OK) 
                    //本期读数如果为0，约定不抄表
                    if (mes.ShowQ("第 " + (i + 1).ToString() + " 行用水量 为'0',确定要保存抄表信息吗?") != DialogResult.OK)
                        continue;
                }
                else if (intTotalNumber < 0)
                {
                    if (mes.ShowQ("第 " + (i + 1).ToString() + " 行用水量 为'负',系统默认为水表倒装,确定保存抄表信息吗?") != DialogResult.OK)
                        continue;
                    dgWaterList.Rows[i].Cells["totalNumber"].Value = Math.Abs(intTotalNumber);
                }

                #region 写入MODEL
                MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                object objWaterMeterRead = dgWaterList.Rows[i].Cells["readMeterRecordId"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.readMeterRecordId = objWaterMeterRead.ToString();

                objWaterMeterRead = dgWaterList.Rows[i].Cells["waterMeterLastNumber"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.waterMeterLastNumber = Convert.ToInt32(objWaterMeterRead);

                objWaterMeterRead = dgWaterList.Rows[i].Cells["waterMeterEndNumber"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.waterMeterEndNumber = Convert.ToInt32(objWaterMeterRead);

                objWaterMeterRead = dgWaterList.Rows[i].Cells["totalNumber"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.totalNumber = Convert.ToInt32(objWaterMeterRead);

                objWaterMeterRead = dgWaterList.Rows[i].Cells["totalNumberDescribe"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.totalNumberDescribe = objWaterMeterRead.ToString();

                objWaterMeterRead = dgWaterList.Rows[i].Cells["avePrice"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.avePrice = Convert.ToDecimal(objWaterMeterRead);

                objWaterMeterRead = dgWaterList.Rows[i].Cells["avePriceDescribe"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.avePriceDescribe = objWaterMeterRead.ToString();

                objWaterMeterRead = dgWaterList.Rows[i].Cells["waterTotalCharge"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.waterTotalCharge = Convert.ToDecimal(objWaterMeterRead);

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraChargePrice1"].FormattedValue;
                if (Information.IsNumeric(objWaterMeterRead))
                    MODELreadMeterRecord.extraChargePrice1 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraChargePrice1 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraChargePrice2"].FormattedValue;
                if (Information.IsNumeric(objWaterMeterRead))
                    MODELreadMeterRecord.extraChargePrice2 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraChargePrice2 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraChargePrice3"].FormattedValue;
                if (Information.IsNumeric(objWaterMeterRead))
                    MODELreadMeterRecord.extraChargePrice3 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraChargePrice3 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraChargePrice4"].FormattedValue;
                if (Information.IsNumeric(objWaterMeterRead))
                    MODELreadMeterRecord.extraChargePrice4 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraChargePrice4 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraChargePrice5"].FormattedValue;
                if (Information.IsNumeric(objWaterMeterRead))
                    MODELreadMeterRecord.extraChargePrice5 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraChargePrice5 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraChargePrice6"].FormattedValue;
                if (Information.IsNumeric(objWaterMeterRead))
                    MODELreadMeterRecord.extraChargePrice6 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraChargePrice6 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraChargePrice7"].FormattedValue;
                if (Information.IsNumeric(objWaterMeterRead))
                    MODELreadMeterRecord.extraChargePrice7 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraChargePrice7 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraChargePrice8"].FormattedValue;
                if (Information.IsNumeric(objWaterMeterRead))
                    MODELreadMeterRecord.extraChargePrice8 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraChargePrice8 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraCharge1"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraCharge1 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraCharge1 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraCharge2"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraCharge2 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraCharge2 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraCharge3"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraCharge3 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraCharge3 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraCharge4"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraCharge4 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraCharge4 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraCharge5"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraCharge5 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraCharge5 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraCharge6"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraCharge6 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraCharge6 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraCharge7"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraCharge7 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraCharge7 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraCharge8"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraCharge8 = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraCharge8 = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraTotalCharge"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraTotalCharge = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraTotalCharge = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["trapezoidPrice"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.trapezoidPrice = objWaterMeterRead.ToString();

                objWaterMeterRead = dgWaterList.Rows[i].Cells["extraTotalCharge"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.extraTotalCharge = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.extraTotalCharge = 0;

                objWaterMeterRead = dgWaterList.Rows[i].Cells["totalCharge"].Value;
                if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    MODELreadMeterRecord.totalCharge = Convert.ToDecimal(objWaterMeterRead);
                else
                    MODELreadMeterRecord.totalCharge = 0;

                MODELreadMeterRecord.chargeState = "1";//已抄表标志
                MODELreadMeterRecord.readMeterRecordDate = mes.GetDatetimeNow();
                #endregion

                if (BLLreadMeterRecord.Update(MODELreadMeterRecord))
                {
                    dgWaterList.Rows[i].DefaultCellStyle.ForeColor = colorSave;
                    //dgWaterList.Rows[i].Cells["chargeState"].Value = "已抄表";
                }
                else
                {
                    mes.Show("第 " + (i + 1).ToString() + " 行抄表记录修改失败!");
                    return;
                }
            }
        }

        private void toolNull_Click(object sender, EventArgs e)
        {
            if (dgWaterList.SelectedRows.Count == 0)
                return;

            if (mes.ShowQ("确定要将列表内选择的" + dgWaterList.SelectedRows.Count + "行抄表信息置为未抄吗?") != DialogResult.OK)
                return;

            for (int i = 0; i < dgWaterList.SelectedRows.Count; i++)
            {
                object objWaterMeterReadRecordID = dgWaterList.SelectedRows[i].Cells["readMeterRecordId"].Value;
                if (objWaterMeterReadRecordID != null && objWaterMeterReadRecordID != DBNull.Value)
                {
                    string strWaterMeterNO = "";
                    object objWaterMeterNO = dgWaterList.SelectedRows[i].Cells["waterMeterNo"].Value;
                    if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                    {
                        strWaterMeterNO = objWaterMeterNO.ToString();
                    }
                    #region 重新加载Datagriew行
                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                    MODELreadMeterRecord.waterMeterEndNumber = 0;
                    MODELreadMeterRecord.totalNumber = 0;
                    MODELreadMeterRecord.SubMeterNumber = 0;
                    MODELreadMeterRecord.totalNumberDescribe = null;
                    MODELreadMeterRecord.avePrice = 0;
                    //MODELreadMeterRecord.avePriceDescribe = null;
                    MODELreadMeterRecord.waterTotalCharge = 0;
                    MODELreadMeterRecord.extraChargePrice1 = 0;
                    MODELreadMeterRecord.extraChargePrice2 = 0;
                    MODELreadMeterRecord.extraChargePrice3 = 0;
                    MODELreadMeterRecord.extraChargePrice4 = 0;
                    MODELreadMeterRecord.extraChargePrice5 = 0;
                    MODELreadMeterRecord.extraChargePrice6 = 0;
                    MODELreadMeterRecord.extraChargePrice7 = 0;
                    MODELreadMeterRecord.extraChargePrice8 = 0;
                    MODELreadMeterRecord.extraCharge1 = 0;
                    MODELreadMeterRecord.extraCharge2 = 0;
                    MODELreadMeterRecord.extraCharge3 = 0;
                    MODELreadMeterRecord.extraCharge4 = 0;
                    MODELreadMeterRecord.extraCharge5 = 0;
                    MODELreadMeterRecord.extraCharge6 = 0;
                    MODELreadMeterRecord.extraCharge7 = 0;
                    MODELreadMeterRecord.extraCharge8 = 0;
                    MODELreadMeterRecord.extraTotalCharge = 0;
                    MODELreadMeterRecord.totalCharge = 0;
                    MODELreadMeterRecord.readMeterRecordId = objWaterMeterReadRecordID.ToString();
                    MODELreadMeterRecord.chargeState = "0";
                    try
                    {
                        if (BLLreadMeterRecord.SetNotRead(MODELreadMeterRecord))
                        {
                            dgWaterList.SelectedRows[i].Cells["waterMeterEndNumber"].Value = DBNull.Value;
                            dgWaterList.SelectedRows[i].Cells["SUBMETERNUMBER"].Value = DBNull.Value;
                            dgWaterList.SelectedRows[i].Cells["totalNumberDescribe"].Value = DBNull.Value;
                            dgWaterList.SelectedRows[i].Cells["waterTotalCharge"].Value = DBNull.Value;
                            dgWaterList.SelectedRows[i].Cells["extraCharge1"].Value = DBNull.Value;
                            dgWaterList.SelectedRows[i].Cells["extraCharge2"].Value = DBNull.Value;
                            dgWaterList.SelectedRows[i].Cells["totalCharge"].Value = DBNull.Value;
                            dgWaterList.SelectedRows[i].Cells["totalNumber"].Value = DBNull.Value;

                            dgWaterList.SelectedRows[i].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                            //toolNull.Enabled = false;
                        }
                        else
                        {
                            mes.Show("将水表编号为 " + strWaterMeterNO + " 的抄表信息置为未抄失败,请重新检索抄表信息!");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Write(ex.ToString(), MsgType.Error);
                        mes.Show("将水表编号为 " + strWaterMeterNO + " 的抄表信息置为未抄失败!原因:" + ex.Message);
                    }
                    #endregion
                }
            }
        }

        private void toolSetColor_Click(object sender, EventArgs e)
        {
            if (dgWaterList.CurrentRow != null)
                dgWaterList.CurrentRow.DefaultCellStyle.ForeColor = Color.Red;
        }

        private void trMeterReading_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //e.DrawDefault = true; //我这里用默认颜色即可，只需要在TreeView失去焦点时选中节点仍然突显
            //return;

            //if ((e.State & TreeNodeStates.Selected) != 0)
            //{
            //    //演示为绿底白字
            //    e.Graphics.FillRectangle(Brushes.DarkBlue, e.Node.Bounds);

            //    Font nodeFont = e.Node.NodeFont;
            //    if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
            //    e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
            //}
            //else
            //{
            //    e.DrawDefault = true;
            //}

            //if ((e.State & TreeNodeStates.Focused) != 0)
            //{
            //    using (Pen focusPen = new Pen(Color.Black))
            //    {
            //        focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            //        Rectangle focusBounds = e.Node.Bounds;
            //        focusBounds.Size = new Size(focusBounds.Width - 1,
            //        focusBounds.Height - 1);
            //        e.Graphics.DrawRectangle(focusPen, focusBounds);
            //    }
            //}

        }

        private void dgWaterList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            //toolNull.Enabled = true;
            //toolSave.Enabled = true;

            object objWaterMeterReadRecordID = dgWaterList.Rows[e.RowIndex].Cells["readMeterRecordId"].Value;
            //if (objWaterMeterReadRecordID == null || objWaterMeterReadRecordID == DBNull.Value)
            //    toolDelete.Enabled = false;

            //object objChecked = dgWaterList.Rows[e.RowIndex].Cells["checkState"].Value;
            //if (objChecked != null && objChecked != DBNull.Value)
            //{
            //    if (objChecked.ToString() == "已审核")
            //    {
            //        toolSave.Enabled = false;
            //        toolNull.Enabled = false;
            //    }
            //}

            //object objCharged = dgWaterList.Rows[e.RowIndex].Cells["chargeState"].Value;
            //if (objCharged != null && objCharged != DBNull.Value)
            //    if (objCharged.ToString() == "已收费" || objCharged.ToString() == "已预打")
            //    {
            //        toolSave.Enabled = false;
            //        toolNull.Enabled = false;
            //    }

            object objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["areaNO"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtAreaNO.Text = objWaterUser.ToString();
            }
            else
                txtAreaNO.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["pianNO"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtPianNO.Text = objWaterUser.ToString();
            }
            else
                txtPianNO.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["duanNO"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtDuanNO.Text = objWaterUser.ToString();
            }
            else
                txtDuanNO.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["COMMUNITYNAME"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtCommunity.Text = objWaterUser.ToString();
            }
            else
                txtCommunity.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserPeopleCount"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtWaterUserCount.Text = objWaterUser.ToString();
            }
            else
                txtWaterUserCount.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserAddress"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtWaterUserAddress.Text = objWaterUser.ToString();
            }
            else
                txtWaterUserAddress.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["createType"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtCreateType.Text = objWaterUser.ToString();
            }
            else
                txtCreateType.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["meterReaderName"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtMeterReader.Text = objWaterUser.ToString();
            }
            else
                txtMeterReader.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["chargerName"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtCharger.Text = objWaterUser.ToString();
            }
            else
                txtCharger.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserTypeName"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtWaterUserType.Text = objWaterUser.ToString();
            }
            else
                txtWaterUserType.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserchargeType"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                if(objWaterUser.ToString()=="1")
                txtWaterUserChargetype.Text = "预存";
                else
                    txtWaterUserChargetype.Text = "非预存";
            }
            else
                txtWaterUserChargetype.Clear();
            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterUserHouseType"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                if (objWaterUser.ToString() == "1")
                    txtWaterUserHouseType.Text = "楼房";
                else
                    txtWaterUserHouseType.Text = "平房";
            }
            else
                txtWaterUserHouseType.Clear();

            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["readMeterRecordYearAndMonth"].Value;
            if (Information.IsDate(objWaterUser))
                txtYearAndMonth.Text = Convert.ToDateTime(objWaterUser).ToString("yyyy-MM");

            objWaterUser = dgWaterList.Rows[e.RowIndex].Cells["waterMeterTypeName"].Value;
            if (objWaterUser != null && objWaterUser != DBNull.Value)
            {
                txtWaterMeterType.Text = objWaterUser.ToString();
            }
            else
                txtWaterMeterType.Clear();
        }

        private void dgWaterList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "extraChargePrice1")
            {
                e.Value = 0;
                object objExtraFee = dgWaterList.Rows[e.RowIndex].Cells["extraCharge"].Value;
                if (objExtraFee != null && objExtraFee != DBNull.Value)
                {
                    string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                    for (int j = 0; j < strAllExtraFee.Length; j++)
                    {
                        string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                        if (strSingleExtraFee[0].Contains("F"))
                        {
                            string strNum = strSingleExtraFee[0].Substring(1, 1);
                            if (strNum == "1")
                            {
                                e.Value = strSingleExtraFee[1];
                            }
                            //dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice" + strNum].Value = strSingleExtraFee[1];
                            //dgWaterList.Rows[e.RowIndex].Cells["extraChargetype" + strNum].Value = strSingleExtraFee[2];//附加费计算方式
                            //dgWaterList.Columns["extraCharge" + strNum].Visible = true;
                            //dgWaterList.Columns["extraChargePrice" + strNum].Visible = true;
                        }
                    }
                }
                //}
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "extraChargetype1")
            {
                e.Value = 1;
                object objExtraFee = dgWaterList.Rows[e.RowIndex].Cells["extraCharge"].Value;
                if (objExtraFee != null && objExtraFee != DBNull.Value)
                {
                    string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                    for (int j = 0; j < strAllExtraFee.Length; j++)
                    {
                        string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                        if (strSingleExtraFee[0].Contains("F"))
                        {
                            string strNum = strSingleExtraFee[0].Substring(1, 1);
                            if (strNum == "1")
                            {
                                e.Value = strSingleExtraFee[2];
                            }
                        }
                    }
                }
                //}
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "extraChargePrice2")
            {
                e.Value = 0;
                object objExtraFee = dgWaterList.Rows[e.RowIndex].Cells["extraCharge"].Value;
                if (objExtraFee != null && objExtraFee != DBNull.Value)
                {
                    string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                    for (int j = 0; j < strAllExtraFee.Length; j++)
                    {
                        string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                        if (strSingleExtraFee[0].Contains("F"))
                        {
                            string strNum = strSingleExtraFee[0].Substring(1, 1);
                            if (strNum == "2")
                            {
                                e.Value = strSingleExtraFee[1];
                            }
                            //dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice" + strNum].Value = strSingleExtraFee[1];
                            //dgWaterList.Rows[e.RowIndex].Cells["extraChargetype" + strNum].Value = strSingleExtraFee[2];//附加费计算方式
                            //dgWaterList.Columns["extraCharge" + strNum].Visible = true;
                            //dgWaterList.Columns["extraChargePrice" + strNum].Visible = true;
                        }
                    }
                }
                //}
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "extraChargetype2")
            {
                e.Value = 1;
                object objExtraFee = dgWaterList.Rows[e.RowIndex].Cells["extraCharge"].Value;
                if (objExtraFee != null && objExtraFee != DBNull.Value)
                {
                    string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                    for (int j = 0; j < strAllExtraFee.Length; j++)
                    {
                        string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                        if (strSingleExtraFee[0].Contains("F"))
                        {
                            string strNum = strSingleExtraFee[0].Substring(1, 1);
                            if (strNum == "2")
                            {
                                e.Value = strSingleExtraFee[2];
                            }
                        }
                    }
                }
                //}
            }
            //if (dgWaterList.Columns[e.ColumnIndex].Name == "waterMeterTypeId")
            //{
            //    //object objWaterMeterTypeID = e.Value;
            //    //if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
            //    //{
            //    object objExtraFee = dgWaterList.Rows[e.RowIndex].Cells["extraCharge"].Value;
            //    if (objExtraFee != null && objExtraFee != DBNull.Value)
            //    {
            //        string[] strAllExtraFee = objExtraFee.ToString().Split('|');
            //        for (int j = 0; j < strAllExtraFee.Length; j++)
            //        {
            //            string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
            //            if (strSingleExtraFee[0].Contains("F"))
            //            {
            //                string strNum = strSingleExtraFee[0].Substring(1, 1);
            //                dgWaterList.Rows[e.RowIndex].Cells["extraChargePrice" + strNum].Value = strSingleExtraFee[1];
            //                dgWaterList.Rows[e.RowIndex].Cells["extraChargetype" + strNum].Value = strSingleExtraFee[2];//附加费计算方式
            //                dgWaterList.Columns["extraCharge" + strNum].Visible = true;
            //                dgWaterList.Columns["extraChargePrice" + strNum].Visible = true;
            //            }
            //        }
            //    }
            //    //}
            //}


            ////定量用水情况，直接将用水量置为固定水量。
            //if (dgWaterList.Columns[e.ColumnIndex].Name == "WATERFIXVALUE")
            //{
            //    object objWaterFixValue = e.Value;
            //    if (Information.IsNumeric(objWaterFixValue))
            //        if (Convert.ToInt32(objWaterFixValue) > 0)
            //        {
            //            dgWaterList.Rows[e.RowIndex].Cells["totalNumber"].Value = objWaterFixValue.ToString();
            //            dgWaterList["waterMeterEndNumber", e.RowIndex].ReadOnly = true;


            //            //将用水量描述保存到表格里备用
            //            dgWaterList.Rows[e.RowIndex].Cells["totalNumberDescribe"].Value = "固定水量:" + objWaterFixValue.ToString();

            //            //dgWaterList["waterMeterEndNumber", e.RowIndex].Style.BackColor = colorCellReadOnly;
            //        }
            //        else
            //        {
            //            //object objWaterUserState = dgWaterList.Rows[e.RowIndex].Cells["waterUserState"].Value;
            //            //if (objWaterUserState != null && objWaterUserState != DBNull.Value)
            //            //{
            //            //    if (objWaterUserState.ToString() == "1")
            //            //    {
            //            //        dgWaterList.Rows[e.RowIndex].Cells["waterUserState"].Value = "有表";

            //            //        object objChecked = dgWaterList.Rows[e.RowIndex].Cells["checkState"].Value;
            //            //        if (objChecked != null && objChecked != DBNull.Value)
            //            //        {
            //            //            if (objChecked.ToString() != "1")
            //            //            {
            //            //                dgWaterList["waterMeterEndNumber", e.RowIndex].ReadOnly = false;
            //            //                dgWaterList["waterMeterEndNumber", e.RowIndex].Style.BackColor = colorCellEdit;
            //            //            }
            //            //        }
            //            //    }
            //            //    else
            //            //    {
            //            //        dgWaterList.Rows[e.RowIndex].Cells["waterUserState"].Value = "无表";
            //            //        //如果是无表用户

            //            //        object objChecked = dgWaterList.Rows[e.RowIndex].Cells["checkState"].Value;
            //            //        if (objChecked != null && objChecked != DBNull.Value)
            //            //        {
            //            //            if (objChecked.ToString() != "1")
            //            //            {
            //            //                dgWaterList["waterMeterEndNumber", e.RowIndex].ReadOnly = true;
            //            //                dgWaterList["totalNumber", e.RowIndex].ReadOnly = false;
            //            //                dgWaterList["totalNumber", e.RowIndex].Style.BackColor = colorCellEdit;
            //            //            }
            //            //        }
            //            //    }

            //            //}
            //        }
            //}
            ////else
            ////{
            ////    //object objWaterUserState = dgWaterList.Rows[i].Cells["waterUserState"].Value;
            ////    //if (objWaterUserState != null && objWaterUserState != DBNull.Value)
            ////    //{
            ////    //    if (objWaterUserState.ToString() == "1")
            ////    //    {
            ////    //        dgWaterList.Rows[i].Cells["waterUserState"].Value = "有表";

            ////    //        object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            ////    //        if (objChecked != null && objChecked != DBNull.Value)
            ////    //        {
            ////    //            if (objChecked.ToString() != "1")
            ////    //            {
            ////    //                dgWaterList["waterMeterEndNumber", i].ReadOnly = false;
            ////    //                dgWaterList["waterMeterEndNumber", i].Style.BackColor = colorCellEdit;
            ////    //            }
            ////    //        }
            ////    //    }
            ////    //    else
            ////    //    {
            ////    //        dgWaterList.Rows[i].Cells["waterUserState"].Value = "无表";
            ////    //        //如果是无表用户

            ////    //        object objChecked = dgWaterList.Rows[i].Cells["checkState"].Value;
            ////    //        if (objChecked != null && objChecked != DBNull.Value)
            ////    //        {
            ////    //            if (objChecked.ToString() != "1")
            ////    //            {
            ////    //                dgWaterList["waterMeterEndNumber", i].ReadOnly = true;
            ////    //                dgWaterList["totalNumber", i].ReadOnly = false;
            ////    //                dgWaterList["totalNumber", i].Style.BackColor = colorCellEdit;
            ////    //            }
            ////    //        }
            ////    //    }

            ////    //}
            ////}


            ////if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice1"].Value) > 0)
            ////{
            ////    dgWaterList.Columns["extraChargePrice1"].Visible = true;
            ////    dgWaterList.Columns["extraCharge1"].Visible = true;
            ////}

            ////if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice2"].Value) > 0)
            ////{
            ////    dgWaterList.Columns["extraChargePrice2"].Visible = true;
            ////    dgWaterList.Columns["extraCharge2"].Visible = true;
            ////}

            ////if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice3"].Value) > 0)
            ////{
            ////    dgWaterList.Columns["extraChargePrice3"].Visible = true;
            ////    dgWaterList.Columns["extraCharge3"].Visible = true;
            ////}

            ////if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice4"].Value) > 0)
            ////{
            ////    dgWaterList.Columns["extraChargePrice4"].Visible = true;
            ////    dgWaterList.Columns["extraCharge4"].Visible = true;
            ////}

            ////if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice5"].Value) > 0)
            ////{
            ////    dgWaterList.Columns["extraChargePrice5"].Visible = true;
            ////    dgWaterList.Columns["extraCharge5"].Visible = true;
            ////}

            ////if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice6"].Value) > 0)
            ////{
            ////    dgWaterList.Columns["extraChargePrice6"].Visible = true;
            ////    dgWaterList.Columns["extraCharge6"].Visible = true;
            ////}

            ////if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice7"].Value) > 0)
            ////{
            ////    dgWaterList.Columns["extraChargePrice7"].Visible = true;
            ////    dgWaterList.Columns["extraCharge7"].Visible = true;
            ////}

            ////if (Convert.ToDecimal(dgWaterList.Rows[i].Cells["extraChargePrice8"].Value) > 0)
            ////{
            ////    dgWaterList.Columns["extraChargePrice8"].Visible = true;
            ////    dgWaterList.Columns["extraCharge8"].Visible = true;
            ////}

            //if (dgWaterList.Columns[e.ColumnIndex].Name == "waterUserHouseType")
            //{
            //    object objWaterMeterRecord = e.Value;
            //    if (objWaterMeterRecord != null && objWaterMeterRecord != DBNull.Value)
            //    {
            //        if (objWaterMeterRecord.ToString() == "1")
            //            e.Value = "楼房";
            //        else if (objWaterMeterRecord.ToString() == "2")
            //           e.Value = "平房";

            //    }
            //}
            //if (dgWaterList.Columns[e.ColumnIndex].Name == "chargeState")
            //{
            //    //根据chargestate判断当前抄表的进度，0已初始化抄表记录，1已抄表，2已预打发票，3已收费
            //   object objWaterMeterRecord =e.Value;
            //    if (objWaterMeterRecord != null && objWaterMeterRecord != DBNull.Value)
            //    {
            //        if(objWaterMeterRecord.ToString() == "0")
            //        {
            //           e.Value = "未抄表";
            //        }
            //       else if (objWaterMeterRecord.ToString() == "1")
            //        {
            //            e.Value = "已抄表";
            //            object objChecked = dgWaterList.Rows[e.RowIndex].Cells["checkState"].Value;
            //            if (objChecked != null && objChecked != DBNull.Value)
            //            {
            //                if (objChecked.ToString() == "1")
            //                {
            //                    dgWaterList.Rows[e.RowIndex].Cells["checkState"].Value = "已审核";
            //                    dgWaterList["waterMeterEndNumber", e.RowIndex].ReadOnly = true;//禁止编辑本期读数
            //                    dgWaterList["totalNumber", e.RowIndex].ReadOnly = true;//禁止编辑本期读数
            //                    dgWaterList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = colorChecked;

            //                    dgWaterList.Columns["checkDateTime"].Visible = true;
            //                    dgWaterList.Columns["checker"].Visible = true;
            //                }
            //                else if(objChecked.ToString() == "0")
            //                {
            //                    dgWaterList.Rows[e.RowIndex].Cells["checkState"].Value = "未审核";
            //            dgWaterList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = colorSave;
            //                }
            //            }
            //        }
            //        else if(objWaterMeterRecord.ToString() == "2")
            //        {
            //            e.Value = "已预收";
            //            dgWaterList["waterMeterEndNumber", e.RowIndex].ReadOnly = true;//禁止编辑本期读数
            //            dgWaterList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = colorCharged;
            //        }
            //        else if(objWaterMeterRecord.ToString() == "3")
            //        {
            //             e.Value = "已收费";
            //            dgWaterList["waterMeterEndNumber", e.RowIndex].ReadOnly = true;//禁止编辑本期读数
            //            dgWaterList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = colorCharged;
            //        }
            //    }
            //}

            //objWaterMeterRecord = dgWaterList.Rows[i].Cells["agentsign"].Value;
            //if (objWaterMeterRecord != null && objWaterMeterRecord != DBNull.Value)
            //{
            //    if (objWaterMeterRecord.ToString() == "2")
            //        dgWaterList.Rows[i].Cells["agentsign"].Value = "不托收";
            //    else if (objWaterMeterRecord.ToString() == "1")
            //        dgWaterList.Rows[i].Cells["agentsign"].Value = "托收";
            //    else
            //        dgWaterList.Rows[i].Cells["agentsign"].Value = objWaterMeterRecord.ToString();

            //}
        }

        private void toolModifyWaterUserName_Click(object sender, EventArgs e)
        {
            //if (dgWaterList.CurrentRow==null)
            //{
            //    toolModifyWaterUserName.Enabled = false;
            //    return;
            //}
            //string strRecordID = "", strWaterUserName = "", strWaterUserID = "", strMeterReadingID = "";
            //object obj = dgWaterList.CurrentRow.Cells["readMeterRecordId"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    strRecordID = obj.ToString();
            //}
            //obj = dgWaterList.CurrentRow.Cells["waterUserName"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    strWaterUserName = obj.ToString();
            //}
            //obj = dgWaterList.CurrentRow.Cells["waterUserId"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    strWaterUserID = obj.ToString();
            //}
            ////obj = dgWaterList.CurrentRow.Cells["meterReadingID"].Value;
            ////if (obj != null && obj != DBNull.Value)
            ////{
            ////    strMeterReadingID = obj.ToString();
            ////}
            //frmChangeWaterUserName frm = new frmChangeWaterUserName();
            //frm.strRecordID = strRecordID;
            //frm.strWaterUserName = strWaterUserName;
            //frm.strWaterUserID = strWaterUserID;
            //frm.strMeterReadingID = strMeterReadingID;
            //frm.frmWaterMeterRead = this;
            //frm.ShowDialog();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (dgWaterList.CurrentRow == null)
                return;
            object objWaterMeterReadRecordID = dgWaterList.CurrentRow.Cells["readMeterRecordId"].Value;
            if (objWaterMeterReadRecordID != null && objWaterMeterReadRecordID != DBNull.Value)
            {
                string strWaterMeterNO = "";
                object objWaterMeterNO = dgWaterList.CurrentRow.Cells["waterMeterNo"].Value;
                if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                {
                    strWaterMeterNO = objWaterMeterNO.ToString();
                }
                string strIsUserFilter = " AND readMeterRecordIdLast='" + objWaterMeterReadRecordID.ToString() + "'";
                DataTable dtIsUse = BLLreadMeterRecord.Query(strIsUserFilter);
                if (dtIsUse.Rows.Count > 0)
                {
                    mes.Show("水表编号为 " + strWaterMeterNO + " 的抄表信息不是最新的抄表数据!无法删除!");
                    return;
                }
                if (mes.ShowQ("确定要将水表编号为 " + strWaterMeterNO + " 的抄表信息删除并置为未初始化状态吗?") == DialogResult.OK)
                {
                    #region 重新加载Datagriew行
                    //MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                    //MODELreadMeterRecord.readMeterRecordId = objWaterMeterReadRecordID.ToString();
                    try
                    {
                        if (BLLreadMeterRecord.Delete(objWaterMeterReadRecordID.ToString()))
                        {
                            dgWaterList.Rows.Remove(dgWaterList.CurrentRow);
                        }
                        else
                        {
                            mes.Show("删除水表编号为 " + strWaterMeterNO + " 的抄表信息失败,请重新检索抄表信息!");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Write(ex.ToString(), MsgType.Error);
                        mes.Show("删除水表编号为 " + strWaterMeterNO + " 的抄表信息失败!原因:" + ex.Message);
                    }
                    #endregion
                }
            }
        }

        private void toolDeleteAll_Click(object sender, EventArgs e)
        {
            if (dgWaterList.Rows.Count == 0)
            {
                return;
            }
            int intSelectedCount = dgWaterList.SelectedRows.Count;
            if (intSelectedCount == 0)
            {
                mes.Show("请选择行后再执行操作!");
                return;
            }
            if (mes.ShowQ("确定要将列表中所有选择水表的初始化信息删除并置为未初始化状态吗?") != DialogResult.OK)
            {
                return;
            }
            string strReadMeterRecordIDS = "";
            for (int i = 0; i < intSelectedCount; i++)
            {
                string strWaterUserName = "";
                object objWaterUserName = dgWaterList.SelectedRows[i].Cells["waterUserName"].Value;
                if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                    strWaterUserName = objWaterUserName.ToString();

                object objReadMeterRecordID = dgWaterList.SelectedRows[i].Cells["readMeterRecordId"].Value;
                if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
                {
                    if (i == 0)
                    {
                        strReadMeterRecordIDS = "'" + objReadMeterRecordID.ToString() + "'";
                    }
                    else
                        strReadMeterRecordIDS = strReadMeterRecordIDS + ",'" + objReadMeterRecordID.ToString() + "'";
                }
                else
                {
                    mes.Show("用户'!" + strWaterUserName + "'的抄表流水号获取失败,请重新查询后再执行操作!");
                    return;
                }
            }

            string strUpdateZero = "DELETE FROM readMeterRecord WHERE readMeterRecordId in (" + strReadMeterRecordIDS + ")";
            int intSuccessCount = BLLreadMeterRecord.Excute(strUpdateZero);
            if (intSuccessCount > 0)
                for (int i = intSelectedCount - 1; i >= 0; i--)
                {
                    dgWaterList.Rows.Remove(dgWaterList.SelectedRows[i]);
                }
            mes.Show("共成功执行'" + intSuccessCount.ToString() + "'行!");
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmWaterUserSeniorSearch frm = new frmWaterUserSeniorSearch();
            frm.Owner = this;
            frm.strSign = "3";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }

        private void toolBackZero_Click(object sender, EventArgs e)
        {
            if (dgWaterList.Rows.Count == 0)
            {
                return;
            }
            int intSelectedCount = dgWaterList.SelectedRows.Count;
            if (intSelectedCount == 0)
            {
                mes.Show("请选择行后再执行操作!");
                return;
            }
            if (mes.ShowQ("确定要将列表中所有选择的水表读数置为'0'吗?") != DialogResult.OK)
            {
                return;
            }
            string strReadMeterRecordIDS="";
            for (int i = 0; i < intSelectedCount; i++)
            {
                string strWaterUserName = "";
                object objWaterUserName = dgWaterList.SelectedRows[i].Cells["waterUserName"].Value;
                if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                    strWaterUserName = objWaterUserName.ToString();
                
                object objReadMeterRecordID = dgWaterList.SelectedRows[i].Cells["readMeterRecordId"].Value;
                if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
                {
                    if (i == 0)
                    {
                        strReadMeterRecordIDS = "'"+objReadMeterRecordID.ToString()+"'";
                    }
                    else
                        strReadMeterRecordIDS = strReadMeterRecordIDS + ",'" + objReadMeterRecordID.ToString()+"'";
                }
                else
                {
                    mes.Show("用户'!"+strWaterUserName+"'的抄表流水号获取失败,请重新查询后再执行操作!");
                    return;
                }
            }

            string strUpdateZero = "UPDATE readMeterRecord SET waterMeterLastNumber=0,waterMeterEndNumber=0,totalNumber=0,chargeState='0' WHERE readMeterRecordId in (" + strReadMeterRecordIDS + ")";
            int intSuccessCount=BLLreadMeterRecord.Excute(strUpdateZero);
            if (intSuccessCount>0)
                for (int i = 0; i < intSelectedCount; i++)
            {
                dgWaterList.SelectedRows[i].Cells["waterMeterLastNumber"].Value = "0";
                dgWaterList.SelectedRows[i].Cells["waterMeterEndNumber"].Value = "0";
            }
            mes.Show("共成功执行'" + intSuccessCount.ToString() + "'行!");
        }

        private void btSetMonth_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btSetMonth, 0, btSetMonth.Width + 1);
        }
        private void 今天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();

            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 本月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 上月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            DateTime dtLastMonth = dtMonthStart.AddMonths(-1);
            dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtLastMonth.Day, 0, 0, 0);
            dtpStart.Value = dtLastMonth;

            DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 下月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            DateTime dtLastMonth = dtMonthStart.AddMonths(1);
            dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtMonthStart.Day, 0, 0, 0);
            dtpStart.Value = dtLastMonth;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(2).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 本年ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
            DateTime dtLastMonth = new DateTime(dtMonthStart.Year, 1, 1, 0, 0, 0);
            dtpStart.Value = dtLastMonth;

            DateTime dtMonthEnd = dtMonthStart.AddYears(1).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 上年ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
            DateTime dtLastYear = new DateTime(dtMonthStart.AddYears(-1).Year, 1, 1, 0, 0, 0);
            dtpStart.Value = dtLastYear;

            DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtLastYear = new DateTime(2000, 1, 1);
            dtpStart.Value = dtLastYear;

            DateTime dtMonthEnd = new DateTime(3000, 1, 1, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        } 
    }
}
