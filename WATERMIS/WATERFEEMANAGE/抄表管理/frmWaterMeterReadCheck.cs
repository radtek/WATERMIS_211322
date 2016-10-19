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
    public partial class frmWaterMeterReadCheck : DockContentEx
    {
        public frmWaterMeterReadCheck()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
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
        private string strLoginID = "";

        //审核颜色、已收费颜色、已保存颜色，剩余待用：用户停用颜色、水表停用及报废颜色、默认的cell颜色、cell只读颜色。
        Color colorChecked = Color.Green, colorCharged = Color.Red,colorSave=Color.Blue, colorWaterUserStop = Color.Goldenrod, colorWaterMeterStop = Color.Yellow,colorCellDefault=SystemColors.Window,colorCellReadOnly=SystemColors.Control;
        private void frmModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            dgWaterList.AutoGenerateColumns = false;
            dgWaterList.ShowCellToolTips = true;
            toolStrip1.ImageScalingSize = new Size(20, 20);

            dgWaterList.Columns["readMeterRecordYearAndMonth"].DefaultCellStyle.Format = "yyyy-MM";

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtNow = dtpStart.Value.AddMonths(1).AddDays(-1);
            dtpEnd.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();

            //保存默认的单元格颜色
            colorCellDefault = dgWaterList.DefaultCellStyle.BackColor;

            ////获取当前时间的月份和年份
            //DateTime dtNow = mes.GetDatetimeNow();
            //toolcmbYear.Text = dtNow.Year.ToString();
            //toolcmbMonth.Text = dtNow.Month.ToString().PadLeft(2,'0');

            for (int i = 0; i < dgWaterList.Columns.Count; i++)
            {
                //禁止列排序
                //dgWaterList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (dgWaterList.Columns[i].Name == "select")
                {
                    //本月读数可编辑
                    dgWaterList.Columns[i].ReadOnly = false;
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
            BindWaterMeterType(cmbWaterMeterType);

            btFold.Parent = trMeterReading;
            //btFold.Dock = DockStyle.Right;

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS, "0");

            GetExtraFeeName();
            GenerateTree();
            //trMeterReading.HideSelection = false;
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
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1' ORDER BY USERNAME");
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

        /// <summary>
        /// 按抄表本、区域、抄表员动态生成抄表本树形结构
        /// </summary>
        private void GenerateTree()
        {
            trMeterReading.Nodes.Clear();

            #region 按抄表员生成抄表本树形结构
            TreeNode tnHeadMeterReader = trMeterReading.Nodes.Add("|无关ID|", "全部抄表员", 0, 1);
            DataTable dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是' ORDER BY USERNAME");
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
        /// <summary>
        /// 存储查询到的用户表
        /// </summary>
        DataTable dtUserList = new DataTable();

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
            //if()
            string strNodeID = e.Node.Name;
            string[] strNodeIDSpit = strNodeID.Split('|');
            RefreshData(strNodeIDSpit);
            //dtUserList = BLLreadMeterRecord.Query(strNodeIDSpit[2] + " AND checkState='0' AND chargeState='1'");
            //switch (strNodeIDSpit[1])
            //{
            //    case "无关ID":
            //        string strSQL = "";

            //        if (strNodeIDSpit[2] == "")
            //        {
            //            dtUserList = BLLreadMeterRecord.Query(" AND checkState='0'");
            //            //dgWaterList.DataSource = dtUserList;
            //        }
            //        else
            //        {
            //            dtUserList = BLLreadMeterRecord.Query(strNodeIDSpit[2] + " AND checkState='0'");
            //            //dgWaterList.DataSource = dtUserList;
            //        }
            //        break;
            //    default:
            //        dtUserList = BLLreadMeterRecord.Query(strNodeIDSpit[2] + " AND checkState='0'");
            //        //dgWaterList.DataSource = dtUserList;
            //        break;
            //}

        }
        Thread TD;
        private void RefreshData(string[] strNodeID)
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                LoadData(strNodeID);

                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("水费审核界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("水费审核界面:" + ex.ToString(), MsgType.Error);
            }
        }
        private void LoadData(string[] strNodeID)
        {
            try
            {
                //查询条件
                string strFilter = strSeniorFilterHidden + strNodeID[2] + " AND chargeState='1'  AND checkState='0'";

                if (cmbWaterMeterType.SelectedValue != DBNull.Value && cmbWaterMeterType.SelectedValue != null)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                string strSearch = txtWaterUserNOSearch.Text;
                if (txtWaterUserNOSearch.Text.Trim() != "")
                {
                    strFilter += " AND (waterUserNO LIKE '%" + strSearch + "%' OR waterUserName LIKE '%" + strSearch +
                        "%' OR waterUserAddress LIKE '%" + strSearch + "%') ";
                }

                if (chkTotalNumber.Checked)
                    strFilter += " AND totalNumber>0 ";

                if (cmbAreaNOS.SelectedIndex > 0)
                    strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
                if (cmbPianNOS.SelectedIndex > 0)
                    strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
                if (cmbDuanNOS.SelectedIndex > 0)
                    strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

                if (cmbCommunityS.SelectedIndex > 0)
                    strFilter += " AND communityID='" + cmbCommunityS.SelectedValue.ToString() + "'";

                if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

                strFilter += " AND readMeterRecordYearAndMonth BETWEEN '" + new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1) + "' AND '" +
                    new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, 1).AddMonths(1).AddDays(-1) + "' ORDER BY pianNO,areaNO,duanNO,ordernumber,readMeterRecordDate DESC";


                txtFilterSearch.Text = strFilter;//保存查询条件，全部删除用

                dtUserList = BLLreadMeterRecord.Query(strFilter);

                int intWaterTotalNumber = 0, intWaterUserCountYS = 0;//总水量、发生水量用户数量
                decimal decWaterTotalFee = 0, decWSCLFee = 0, decFJF = 0, decTotalFee = 0;

                DataTable dtListTemp = dtUserList.Copy();
                DataView dv = dtListTemp.DefaultView;
                dv.RowFilter = "totalNumber>0";
                intWaterUserCountYS = dv.ToTable().Rows.Count;

                object objWaterTotalNumber = dtUserList.Compute("SUM(totalNumber)", "");
                if (Information.IsNumeric(objWaterTotalNumber))
                    intWaterTotalNumber = Convert.ToInt32(objWaterTotalNumber);

                object objWaterTotalCharge = dtUserList.Compute("SUM(waterTotalCharge)", "");
                if (Information.IsNumeric(objWaterTotalCharge))
                    decWaterTotalFee = Convert.ToDecimal(objWaterTotalCharge);

                object objExtraCharge1 = dtUserList.Compute("SUM(extraCharge1)", "");
                if (Information.IsNumeric(objExtraCharge1))
                    decWSCLFee = Convert.ToDecimal(objExtraCharge1);

                object objExtraCharge2 = dtUserList.Compute("SUM(extraCharge2)", "");
                if (Information.IsNumeric(objExtraCharge2))
                    decFJF = Convert.ToDecimal(objExtraCharge2);

                object objTotalFee = dtUserList.Compute("SUM(totalCharge)", "");
                if (Information.IsNumeric(objTotalFee))
                    decTotalFee = Convert.ToDecimal(objTotalFee);

                dgWaterList.DataSource = dtUserList;
                labRecordCount.Text = "共:" + dtUserList.Rows.Count + "条;发生水量:" + intWaterUserCountYS + "行;用水量:" + intWaterTotalNumber +
                    ";水费:" + decWaterTotalFee.ToString("F2") + ";污水处理费:" + decWSCLFee.ToString("F2") +
                    ";附加费:" + decFJF.ToString("F2") + ";水费小计:" + decTotalFee.ToString("F2");

                toolSelectAll.Text = "全选";

                if (dgWaterList.Rows.Count == 0)
                {
                    toolCheck.Enabled = false;
                    toolSelectAll.Enabled = false;

                    foreach (Control con in gpbWaterUserMES.Controls)
                    {
                        if (con is TextBox)
                            ((TextBox)con).Clear();
                    }

                    //ckBox.Checked = false;
                }
                else
                {
                    toolCheck.Enabled = true;
                    toolSelectAll.Enabled = true;

                    DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(1, 0);
                    dgWaterList_CellClick(null, ex);
                    //AddFullSelect(dgWaterList, 1);

                    //toolCheck.Checked = true;
                    //toolCheck.Checked = true;
                    toolSelectAll_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write("水费审核界面:" + ex.ToString(), MsgType.Error);
            }
        }
        //之前是全选checkbox 
            //CheckBox ckBox = new CheckBox();

        Button btSelectAll = new Button();

        /// <summary>  
        /// DataGridView添加全选  
        /// </summary>  
        /// <param name="dgv">DataGridView控件ID</param>  
        /// <param name="columnIndex">全选所在列序号</param>  
        private void AddFullSelect(DataGridView dgv, int columnIndex)
        {
            if (dgv.Rows.Count < 1)
            {
                return;
            }
            btSelectAll.Text = "全选";
            btSelectAll.AutoSize = false;
            btSelectAll.Width = 57;
            btSelectAll.ForeColor =Color.DarkGreen;
            dgWaterList.Columns[columnIndex].Width =57;
            Rectangle rect = dgv.GetCellDisplayRectangle(1, -1, true);
            //ckBox.Size = new Size(dgv.Columns[columnIndex].Width, ckBox.Height+1); //大小                 
            Point point = new Point(rect.X, rect.Y+1);//位置  
            btSelectAll.Location = point;
            btSelectAll.Click += new EventHandler(ckBox_Click);
            //ckBox.CheckedChanged += delegate(object sender, EventArgs e)
            //{
            //    for (int i = 0; i < dgv.Rows.Count; i++)
            //    {
            //        dgv.Rows[i].Cells[columnIndex].Value = ((CheckBox)sender).Checked;
            //    }
            //    dgv.EndEdit();
            //};
            dgv.Controls.Add(btSelectAll);
        }

        void ckBox_Click(object sender, EventArgs e)
        {
            if (btSelectAll.Text == "全选")
            {
                for (int i = 0; i < dgWaterList.Rows.Count; i++)
                {
                    dgWaterList.Rows[i].Cells["select"].Value = true;
                }
                btSelectAll.Text = "反选";
            }
            else
            {
                for (int i = 0; i < dgWaterList.Rows.Count; i++)
                {
                    dgWaterList.Rows[i].Cells["select"].Value = !Convert.ToBoolean(dgWaterList.Rows[i].Cells["select"].Value);
                }
                btSelectAll.Text = "全选";
            }
            dgWaterList.EndEdit();
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

        private void rbWaterMeterReading_CheckedChanged(object sender, EventArgs e)
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "select")
            dgWaterList.Rows[e.RowIndex].Cells["select"].Value = !Convert.ToBoolean(dgWaterList.Rows[e.RowIndex].Cells["select"].Value);

            object objWaterMeterReadRecordID = dgWaterList.Rows[e.RowIndex].Cells["readMeterRecordId"].Value;
            if (objWaterMeterReadRecordID != null && objWaterMeterReadRecordID != DBNull.Value)
            {
                toolCheck.Enabled = true;
            }
            else
                toolCheck.Enabled = false;

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
                if (objWaterUser.ToString() == "1")
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

        private void toolSave_Click(object sender, EventArgs e)
        {
            dgWaterList.EndEdit();
            int intCheckedCount = 0;
            for (int i = 0; i < dgWaterList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chkcell = dgWaterList.Rows[i].Cells["select"] as DataGridViewCheckBoxCell;
                if (chkcell.FormattedValue.ToString() == "True")
                {
                    intCheckedCount = intCheckedCount + 1;
                }
            }
            if (intCheckedCount == 0)
                return;
            for (int i = dgWaterList.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewCheckBoxCell chkcell = dgWaterList.Rows[i].Cells["select"] as DataGridViewCheckBoxCell;
                if (chkcell.FormattedValue.ToString() == "True")
                {
                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                    MODELreadMeterRecord.checkState = "1";
                    MODELreadMeterRecord.checkDateTime = mes.GetDatetimeNow();
                    MODELreadMeterRecord.checker = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                    MODELreadMeterRecord.readMeterRecordId = dgWaterList.Rows[i].Cells["readMeterRecordId"].Value.ToString();

                  object  objWaterMeterRead = dgWaterList.Rows[i].Cells["waterUserId"].Value;
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserId = objWaterMeterRead.ToString();

                    #region 获取累计欠费及前期余额
                    decimal decLJQF = 0, decQQYE = 0, decBCYS = 0;

                    objWaterMeterRead = dgWaterList.Rows[i].Cells["totalCharge"].Value;
                    if (Information.IsNumeric(objWaterMeterRead))
                        decBCYS = Convert.ToDecimal(objWaterMeterRead);

                    if (MODELreadMeterRecord.waterUserId != "")
                    {
                        //获取累计欠费
                        string strLJQF = "SELECT * FROM V_WATERUSERAREARAGE WHERE waterUserId='" + MODELreadMeterRecord.waterUserId + "'";
                        DataTable dtLJQF = BLLreadMeterRecord.QueryBySQL(strLJQF);
                        if (dtLJQF.Rows.Count > 0)
                        {
                            if (Information.IsNumeric(dtLJQF.Rows[0]["TOTALFEE"]))
                                decLJQF = Convert.ToDecimal(dtLJQF.Rows[0]["TOTALFEE"]);

                            if (Information.IsNumeric(dtLJQF.Rows[0]["prestore"]))
                                decQQYE = Convert.ToDecimal(dtLJQF.Rows[0]["prestore"]);
                        }
                    }
                    MODELreadMeterRecord.WATERUSERJSYE = decQQYE - decLJQF - decBCYS;
                    MODELreadMeterRecord.WATERUSERQQYE = decQQYE;
                    MODELreadMeterRecord.WATERUSERLJQF = decLJQF + decBCYS;
                    #endregion

                    if (BLLreadMeterRecord.UpdateCheckStateAndArrearage(MODELreadMeterRecord))
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

            TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
            trMeterReading_AfterSelect(null, ex);
        }


        private void toolcmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode != null)
            {
                TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
                trMeterReading_AfterSelect(null, ex);
            }
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

        private void dgWaterList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgWaterList.IsCurrentCellDirty)
            {
                dgWaterList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgWaterList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //    return;
            //if (dgWaterList.Columns[e.ColumnIndex].Name == "select")
            //{
            //    dgWaterList.EndEdit();

            //    //判断行是否全部选中，如果全部选中，全选按钮选中；否则，全选按钮不选中
            //    int intCheckedCount=0;
            //    for (int i = 0; i < dgWaterList.Rows.Count; i++)
            //    {
            //        DataGridViewCheckBoxCell dgchkcell = (DataGridViewCheckBoxCell)dgWaterList.Rows[i].Cells[e.ColumnIndex];
            //        if (Convert.ToBoolean(dgchkcell.Value))
            //        //if (dgchkcell.Value.ToString()=="True")
            //        {
            //            intCheckedCount++;
            //        }
            //    }
            //    if (intCheckedCount == dgWaterList.Rows.Count)
            //        ckBox.Checked = true;
            //    else
            //        ckBox.Checked = false;
            //}
        }

        private void dgWaterList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "chargeState")
            {
                if(e.Value!=null&&e.Value!=DBNull.Value)
                if (e.Value.ToString() == "1")
                {
                   e.Value = "已抄表";
                }
                else if (e.Value.ToString() == "0")
                    e.Value = "未抄表";
                else if (e.Value.ToString() == "2")
                    e.Value = "已预收";
                else if (e.Value.ToString() == "3")
                    e.Value = "已收费";
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "checkState")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                {
                    e.Value = "已审核";
                }
                    else if (e.Value.ToString() == "0")
                    e.Value = "未审核";
            }
            //if (dgWaterList.Columns[e.ColumnIndex].Name == "waterUserchargeType")
            //{
            //    if (e.Value != null && e.Value != DBNull.Value)
            //        if (e.Value.ToString() == "0")
            //        {
            //            e.Value = "非预存";
            //        }
            //        else if (e.Value.ToString() == "2")
            //            e.Value = "预存";
            //}
            //if (dgWaterList.Columns[e.ColumnIndex].Name == "waterUserHouseType")
            //{
            //    if (e.Value != null && e.Value != DBNull.Value)
            //        if (e.Value.ToString() == "1")
            //        {
            //            e.Value = "楼房";
            //        }
            //        else if (e.Value.ToString() == "2")
            //            e.Value = "平房";
            //}
        }

        private void toolSelectAll_Click(object sender, EventArgs e)
        {
            if (toolSelectAll.Text == "全选")
            {
                for (int i = 0; i < dgWaterList.Rows.Count; i++)
                {
                    dgWaterList.Rows[i].Cells["select"].Value = true;
                }
                toolSelectAll.Text = "反选";
            }
            else
            {
                for (int i = 0; i < dgWaterList.Rows.Count; i++)
                {
                    dgWaterList.Rows[i].Cells["select"].Value = !Convert.ToBoolean(dgWaterList.Rows[i].Cells["select"].Value);
                }
                toolSelectAll.Text = "全选";
            }
            dgWaterList.EndEdit();
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmWaterUserSeniorSearch frm = new frmWaterUserSeniorSearch();
            frm.Owner = this;
            frm.strSign = "5";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
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
