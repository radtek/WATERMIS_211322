using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using FastReport;
using BASEFUNCTION;
using MODEL;
using BLL;
using System.Threading;

namespace WATERUSERMETERMANAGE
{
    public partial class frmWaterUserPrestoreSearch : DockContentEx
    {
        public frmWaterUserPrestoreSearch()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            tb2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb2, true, null);
        }

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

        string strFormText = "";
        private void frmWaterUserPrestoreInitial_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgWaterUser.AutoGenerateColumns = false;

            strFormText = this.Text;

            for (int i = 0; i < dgWaterUser.Columns.Count; i++)
            {
                //if (dgWaterUser.Columns[i].Name != "prestore")
                //    dgWaterUser.Columns[i].ReadOnly = true;
                //else
                //{
                //    dgWaterUser.Columns[i].ReadOnly = false;
                //    dgWaterUser.Columns[i].DefaultCellStyle.BackColor = Color.LightGreen;
                //}

                if (dgWaterUser.Columns[i].Name == "USERAREARAGE")
                    dgWaterUser.Columns[i].DefaultCellStyle.BackColor = Color.Coral;
            }

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
            BindCharger(cmbCharger);
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindCharger(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1' ORDER BY USERNAME ");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "全部";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void BindCommunity(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            //if (strType == "0")
            //    dt = BLLBASE_COMMUNITY.Query("");
            //else
            dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000' ORDER BY COMMUNITYNAME");
            DataRow dr = dt.NewRow();
            dr["COMMUNITYNAME"] = "全部";
            dr["COMMUNITYID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DataSource = dt;
            cmb.DisplayMember = "COMMUNITYNAME";
            cmb.ValueMember = "COMMUNITYID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
        private void dgWaterUser_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Aquamarine;
            if (dgWaterUser.CurrentCell.ColumnIndex > 0)
            {
                TextBox tx = e.Control as TextBox;
                if (dgWaterUser.Columns[dgWaterUser.CurrentCell.ColumnIndex].Name == "prestore")
                {
                    // Remove an existing event-handler, if present, to avoid   
                    // adding multiple handlers when the editing control is reused. 
                    tx.KeyPress -= new KeyPressEventHandler(tx_KeyPress);
                    //tx.Validated -= new EventHandler(tx_Validated);
                    //tx.Validating -= new CancelEventHandler(tx_Validating);
                    tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
                }
            }
        }

        void tx_Validating(object sender, CancelEventArgs e)
        {
            //if (!Information.IsNumeric(((TextBox)sender).Text))
            //{
            //    e.Cancel = true;
            //}
            //else
            //{
            //    if (dgWaterUser.CurrentRow == null)
            //        return;

            //    if (isCancel)
            //        return;
            //    string strWaterUserName="";
            //    object objWaterUserName=dgWaterUser.CurrentRow.Cells["waterUserName"].Value;
            //    if (objWaterUserName != null && objWaterUserName != DBNull.Value)
            //    {
            //        strWaterUserName=objWaterUserName.ToString();
            //    }

            //    string strYE = Convert.ToDecimal(((TextBox)sender).Text).ToString("f2");
            //    dgWaterUser.CurrentRow.Cells["prestore"].Value = strYE;

            //    object objWaterMeterUserID = dgWaterUser.CurrentRow.Cells["waterUserId"].Value;
            //    if (objWaterMeterUserID != null && objWaterMeterUserID != DBNull.Value)
            //    {
            //        //更新余额
            //        string strUpdatePrestore = "UPDATE waterUser SET prestore=" + strYE + " WHERE waterUserId='" + objWaterMeterUserID.ToString() + "'";
            //        if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
            //        {
            //            mes.Show("更新用户'" + strWaterUserName + "'的余额失败,请重新查询用户进行修改!");
            //            return;
            //        }
            //        dgWaterUser.CurrentRow.Cells["prestoreLast"].Value = strYE;
            //    }
            //}
        }

        bool isCancel = false;
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
            //isCancel = false;
            //if (e.KeyChar == (char)13)
            //{
            //    dgWaterUser.CurrentCell = dgWaterUser.CurrentRow.Cells["areaName"];
            //}
            //if (e.KeyChar == (char)27)
            //{
            //    dgWaterUser.CurrentRow.Cells["prestore"].Value = dgWaterUser.CurrentRow.Cells["prestoreLast"].Value;
            //    isCancel = true;
            //}
        }

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(null,null);
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

        private void btSearch_Click(object sender, EventArgs e)
        {
            string strFilter = strSeniorFilterHidden, strFilterWaterMeter = strSeniorFilterHidden;
            if (txtWaterUserNOSearch.Text != "")
                strFilter += " AND waterUserNO LIKE '%" + txtWaterUserNOSearch.Text + "%'";
            if (txtWaterUserNameSearch.Text != "")
                strFilter += " AND waterUserName LIKE '%" + txtWaterUserNameSearch.Text + "%'";
            if (txtWaterUserAddressS.Text != "")
                strFilter += " AND waterUserAddress LIKE '%" + txtWaterUserAddressS.Text + "%'";
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

            if (cmbCharger.SelectedValue != null && cmbCharger.SelectedValue != DBNull.Value)
                strFilter += " AND chargerID='" + cmbCharger.SelectedValue.ToString() + "'";


            if (chkArearageGreater.Checked)
                if (Information.IsNumeric(txtArearageGreater.Text))
                {
                    decimal decQFJE = 0 - Convert.ToDecimal(txtArearageGreater.Text);
                    strFilter += " AND USERAREARAGE<=" + decQFJE;
                }

            if (chkArearageLess.Checked)
                if (Information.IsNumeric(txtArearageLess.Text))
                {
                    decimal decQFJE = 0 - Convert.ToDecimal(txtArearageLess.Text);
                    strFilter += " AND USERAREARAGE>=" + decQFJE;
                }

            if (chkYS.Checked)
                if (Information.IsNumeric(txtYS.Text))
                {
                    decimal decQFJE = Convert.ToDecimal(txtYS.Text);
                    strFilter += " AND TOTALFEE>=" + decQFJE;
                }

            strFilterWaterMeter = strFilter;

            if (rbMeterReader.Checked)
                strFilter += " ORDER BY pianNO,areaNO,duanNO,ordernumber";
            if (rbWaterUserName.Checked)
                strFilter += " ORDER BY waterUserName";
            if (rbWaterUserNO.Checked)
                strFilter += " ORDER BY waterUserNO";

            RefreshData(strFilter, strFilterWaterMeter);
        }

        Thread TD;
        private void RefreshData(string strFilter, string strFilterWaterMeter)
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
                LoadData(strFilter, strFilterWaterMeter);
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("用户及水表管理界面:" + ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
            }
            finally
            {
                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
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
                log.Write("用水用户明细表界面:" + ex.ToString(), MsgType.Error);
            }
        }
        /// <summary>
        /// 存储查询到的用户列表
        /// </summary>
        DataTable dtWaterUserList = new DataTable();
        private void LoadData(string strFilter, string strFilterWaterMeter)
        {
            dtWaterUserList = BLLwaterUser.QueryUserPrestore(strFilter);

            //DataRow drLast = dtWaterUserList.NewRow();
            //drLast["waterUserNO"] = "合计:";

            ////计算水表数量
            //drLast["waterUserName"] = "共" + dtWaterUserList.Rows.Count + "行";

            //object objSumPrestore = dtWaterUserList.Compute("SUM(prestore)", "");
            //if (Information.IsNumeric(objSumPrestore))
            //    drLast["prestore"] = Convert.ToDecimal(objSumPrestore).ToString("F2");


            dgWaterUser.DataSource = dtWaterUserList;

            if (dtWaterUserList.Rows.Count > 0)
            {
                toolExportToExl.Enabled = true;
                toolPrint.Enabled = true;
                toolPrintPreview.Enabled = true;                
            }
            else
            {
                toolExportToExl.Enabled = false;
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;     
            }
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

        private void dgWaterUser_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgWaterUser.Rows[dgWaterUser.Rows.Count - 1].Cells["waterUserNO"].Value = "合计:";

            object objSumPrestore = dtWaterUserList.Rows.Count;
            if (Information.IsNumeric(objSumPrestore))
                dgWaterUser.Rows[dgWaterUser.Rows.Count - 1].Cells["waterUserName"].Value = Convert.ToInt32(objSumPrestore)+"户";

            objSumPrestore = dtWaterUserList.Compute("SUM(prestore)", "");
            if (Information.IsNumeric(objSumPrestore))
                dgWaterUser.Rows[dgWaterUser.Rows.Count - 1].Cells["prestore"].Value = Convert.ToDecimal(objSumPrestore);

            objSumPrestore = dtWaterUserList.Compute("SUM(TOTALFEE)", "");
            if (Information.IsNumeric(objSumPrestore))
                dgWaterUser.Rows[dgWaterUser.Rows.Count - 1].Cells["TOTALFEE"].Value = Convert.ToDecimal(objSumPrestore);

            objSumPrestore = dtWaterUserList.Compute("SUM(USERAREARAGE)", "");
            if (Information.IsNumeric(objSumPrestore))
                dgWaterUser.Rows[dgWaterUser.Rows.Count - 1].Cells["USERAREARAGE"].Value = Convert.ToDecimal(objSumPrestore);
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

        private void BtExcel_Click(object sender, EventArgs e)
        {
            string strCaption = "用户余额明细表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgWaterUser);
        }

        private void toolPrintPreview_Click(object sender, EventArgs e)
        {
            if (dtWaterUserList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtPrint = GetDgvToTable(dgWaterUser);
            dtPrint.TableName = "用水用户明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\用户余额明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("用水用户明细表").Enabled = true;
                // run the report
                report1.Show();
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
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (dtWaterUserList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtPrint = GetDgvToTable(dgWaterUser);
            dtPrint.TableName = "用水用户明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\用户余额明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("用水用户明细表").Enabled = true;
                // run the report
                report1.PrintSettings.ShowDialog = false;
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

        }
        /// <summary>
        /// 方法实现把dgv里的数据完整的复制到一张内存表
        /// </summary>
        /// <param name="dgv">dgv控件作为参数</param>
        /// <returns>返回临时内存表</returns>
        public static DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    object obj = dgv.Rows[count].Cells[countsub].FormattedValue;
                    if (obj != null && obj != DBNull.Value)
                        dr[countsub] = dgv.Rows[count].Cells[countsub].FormattedValue.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
