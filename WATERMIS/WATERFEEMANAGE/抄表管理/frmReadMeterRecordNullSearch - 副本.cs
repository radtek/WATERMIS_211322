using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using BLL;
using BASEFUNCTION;
using FastReport;

namespace WATERFEEMANAGE
{
    public partial class frmReadMeterRecordNullSearch : DockContentEx
    {
        public frmReadMeterRecordNullSearch()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();

        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();

        BLLNullReadReasonMemo BLLNullReadReasonMemo = new BLLNullReadReasonMemo();

        /// <summary>
        /// 未抄表原因下拉列表
        /// </summary>
        ComboBox cmbReason = new ComboBox();
        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            dgList.Columns["readMeterRecordYearAndMonth"].DefaultCellStyle.Format = "yyyy-MM";

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                //禁止列排序
                //dgWaterList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (dgList.Columns[i].Name == "memo")
                {
                    //本月读数可编辑
                    dgList.Columns[i].ReadOnly = false;
                }
                else
                    dgList.Columns[i].ReadOnly = true;
            }

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtNow = dtpStart.Value.AddMonths(1).AddDays(-1);
            dtpEnd.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindMeterReader(cmbMeterReaderS,"0");
            BindWaterMeterType(cmbWaterMeterType);
            BindReason(cmbReason);
            cmbIsMeterRead.SelectedIndex = 1;
        }

        /// <summary>
        /// 绑定原因
        /// </summary>
        /// <param name="cmb"></param>
        private void BindReason(ComboBox cmb)
        {
            DataTable dtReason = BLLNullReadReasonMemo.Query("");
            cmb.DataSource = dtReason;
            cmb.DisplayMember = "NullReadReasonName";
            cmb.ValueMember = "NullReadReasonID";
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

        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader(ComboBox cmb, string strType)
        {
          DataTable  dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
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
        private void toolSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        Thread TD;
        private void RefreshData()
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
                LoadData();
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("未抄表明细查询界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("未抄表明细查询界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 存储查询到的水表列表
        /// </summary>
        DataTable dtWaterMeterList = new DataTable();

        /// <summary>
        /// 存储统计行信息
        /// </summary>
        DataTable dtClone = new DataTable();
        private void LoadData()
        {
            try
            {
                string strFilter = "  AND WATERMETERNUMBERCHANGESTATE='0' AND chargeState='0' ";
                if (txtWaterUserNOSearch.Text.Trim() != "")
                {
                    if (txtWaterUserNOSearch.Text.Length < 6)
                        strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                    else
                        strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
                }

                if (txtWaterUserNameSearch.Text.Trim() != "")
                    strFilter += " AND (waterUserName LIKE '%" + txtWaterUserNameSearch.Text + "%' OR waterUserNameCode LIKE '%" + txtWaterUserNameSearch.Text + "%') ";

                if (cmbAreaNOS.SelectedIndex > 0)
                    strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
                if (cmbPianNOS.SelectedIndex > 0)
                    strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
                if (cmbDuanNOS.SelectedIndex > 0)
                    strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

                if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

                if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (cmbIsMeterRead.SelectedIndex > 0)
                    if (cmbIsMeterRead.SelectedIndex == 2)
                        strFilter += " AND chargeState>'0'";
                    else if (cmbIsMeterRead.SelectedIndex == 1)
                        strFilter += " AND chargeState='0'";
                    else if (cmbIsMeterRead.SelectedIndex == 3)
                        strFilter += " AND chargeState='3'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND readMeterRecordYearAndMonth BETWEEN '" + new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1) + "' AND '" + new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, 1).AddMonths(1).AddDays(-1) + "'";

                strFilter += " ORDER BY readMeterRecordYear,readMeterRecordMonth,areaNO,duanNO,ordernumber";
                dtWaterMeterList = BLLreadMeterRecord.Query(strFilter);

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    dgList.DataSource = dtWaterMeterList;
                    //dtClone = dtWaterMeterList.Clone();
                    //DataRow drLast = dtClone.NewRow();
                    //drLast["waterUserNO"] = "合计:";

                    //计算水表数量
                    //    drLast["waterMeterNo"] ="共"+dtWaterMeterList.Rows.Count+"行";

                    //dtClone.Rows.Add(drLast);
                    //ucPageSetUp1.InitialUC(this.dgList, dtWaterMeterList, dtClone);

                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;
                }
                else
                {
                    dgList.DataSource = null;
                    toolPrint.Enabled = false;
                    toolPrintPreview.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
            }
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (dtWaterMeterList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtPrint = dtWaterMeterList.Copy();
            if (dtClone.Rows.Count > 0)
                dtPrint.ImportRow(dtClone.Rows[0]);
            dtPrint.TableName = "未抄水表明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\未抄水表明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("未抄水表明细表").Enabled = true;
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

        private void toolPrintPreview_Click(object sender, EventArgs e)
        {
            if (dtWaterMeterList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtPrint = dtWaterMeterList.Copy();
            if (dtClone.Rows.Count > 0)
                dtPrint.ImportRow(dtClone.Rows[0]);
            dtPrint.TableName = "未抄水表明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\未抄水表明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("未抄水表明细表").Enabled = true;
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
        }/// <summary>
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
                    object obj = dgv.Rows[count].Cells[countsub].Value;
                    if (obj != null && obj!=DBNull.Value)
                    dr[countsub] = dgv.Rows[count].Cells[countsub].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void dgList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "waterUserHouseType")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "楼房";
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "平房";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "agentsign")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "托收";
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "不托收";
            }
        }

        private void dgList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int intRowIndex = e.RowIndex;

            string strMemo="";
            object obj = dgList.Rows[intRowIndex].Cells["memo"].Value;
            if (obj != null && obj != DBNull.Value)
                strMemo = obj.ToString();

            object objReadMeterRecordID = dgList.Rows[intRowIndex].Cells["readMeterRecordId"].Value;
            if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
            {
                string strUpdateReadMeterRecord = "UPDATE readMeterRecord SET memo='" + strMemo + "' WHERE readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                if (BLLreadMeterRecord.Excute(strUpdateReadMeterRecord) == 0)
                {
                    mes.Show("添加备注信息失败，请重试!");
                }
            }
            else
                mes.Show("获取抄表流水号ID失败,请重新查询后再操作!");
        }

        private void dgList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        }

        void tx_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            int intRowIndex = dgList.CurrentCell.RowIndex;
            object objReadMeterRecordID = dgList.Rows[intRowIndex].Cells["readMeterRecordId"].Value;
            if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
            {
                string strUpdateReadMeterRecord = "UPDATE readMeterRecord SET memo='" + txt.Text + "' WHERE readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                if (BLLreadMeterRecord.Excute(strUpdateReadMeterRecord) == 0)
                {
                    mes.Show("添加备注信息失败，请重试!");
                }
            }
            else
                mes.Show("获取抄表流水号ID失败,请重新查询后再操作!");
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

        private void dgList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgList.CurrentCell.RowIndex < 0||dgList.CurrentCell.ColumnIndex<0)
                return;
            try
            {
                if (dgList.Columns[dgList.CurrentCell.ColumnIndex].Name == "memo")
                {
                    Rectangle rect = dgList.GetCellDisplayRectangle(dgList.CurrentCell.ColumnIndex, dgList.CurrentCell.RowIndex, false);
                    string strValue = dgList.CurrentCell.Value.ToString();
                    cmbReason.Text = strValue;
                    cmbReason.Visible = true;
                }
                else
                {
                    cmbReason.Visible = false;
                }
            }
            catch(Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }     
    }
}
