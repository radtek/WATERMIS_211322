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

namespace STATISTIALREPORTS
{
    public partial class frmWaterUserMoveStatic : DockContentEx
    {
        public frmWaterUserMoveStatic()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        

        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtpEnd.Value = dtMonthEnd;

            BindMeterReader(cmbMeterReader);
            BindMeterReader(cmbMeterReaderNew);

            BindAreaNO(cmbAreaNOS, "0");
            BindAreaNO(cmbAreaNOSNew, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindDuanNO(cmbDuanNOSNew, "0");
        }
        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType(ComboBox cmb)
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "全部"; ;
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr,0);
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

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
        }
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1' ORDER BY USERNAME");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }

        /// <summary>
        /// 保存统计条件,用作双击打开明细用
        /// </summary>
        string strFilterTJ = "";
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
                log.Write("用户及水表明细界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("用户及水表明细界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 存储查询到的用户列表
        /// </summary>
        DataTable dtWaterUserList = new DataTable();

        /// <summary>
        /// 存储统计行信息
        /// </summary>
        DataTable dtClone = new DataTable();

        private void LoadData()
        {
            string strFilter = "";
            if (txtWaterUserNOSearch.Text.Trim() != "")
                if(txtWaterUserNOSearch.Text.Length<6)
                    strFilter += " AND WaterUserID='U" + txtWaterUserNOSearch.Text.Trim().PadLeft(5, '0') + "'";
                else
                    strFilter += " AND WaterUserID='" + txtWaterUserNOSearch.Text + "'";

            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

            if (cmbMeterReader.SelectedValue != null && cmbMeterReader.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderID='" + cmbMeterReader.SelectedValue.ToString() + "'";

            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

            if (cmbMeterReaderNew.SelectedValue != null && cmbMeterReaderNew.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderIDNew='" + cmbMeterReaderNew.SelectedValue.ToString() + "'";

            if (cmbAreaNOSNew.SelectedIndex > 0)
                strFilter += " AND areaNONew='" + cmbAreaNOSNew.Text + "'";
            if (cmbDuanNOSNew.SelectedIndex > 0)
                strFilter += " AND duanNONew='" + cmbDuanNOSNew.Text + "'";

            if (chkDateTime.Checked)
                strFilter += " AND OperateDateTime BETWEEN '" + dtpStart.Value.ToShortDateString() + " 00:00:00' AND '" + dtpEnd.Value.ToShortDateString() + " 23:59:59'";

            strFilterTJ = strFilter;

            string strSQL = @"SELECT COUNT(*) AS UserCount,meterReaderID,meterReaderName,areaNO,duanNO,waterMeterTypeId,waterMeterTypeValue,
            waterMeterPositionName,areaNONew,duanNONew,meterReaderIDNew,meterReaderNameNew FROM (SELECT * FROM WaterUserMoveRecord 
            WHERE DeleteSign='0' " + strFilter + ") AS AA GROUP BY meterReaderID,meterReaderName,areaNO,duanNO,waterMeterTypeId,waterMeterTypeValue," +
            "waterMeterPositionName,areaNONew,duanNONew,meterReaderIDNew,meterReaderNameNew";
            dtWaterUserList = BLLwaterUser.QuerySQL(strSQL);

            if (dtWaterUserList.Rows.Count > 0)
            {
                dgList.DataSource = dtWaterUserList;

                toolPrint.Enabled = true;
                toolPrintPreview.Enabled = true;
                toolExcel.Enabled = true;
            }
            else
            {
                dgList.DataSource = null;
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                toolExcel.Enabled = false;
            }
        }

        //获取所有总表编号
        string strMeterParentID = "";

        /// <summary>
        /// 获取总表下的所有级联分表
        /// </summary>
        /// <param name="strID"></param>
        private string GetMeterParentID(string strID)
        {
            if (strMeterParentID != "")
                strMeterParentID += ",'" + strID + "'";
            else
                strMeterParentID = "'" + strID + "'";

            DataTable dtAll = BLLwaterMeter.QuerySummary(" AND waterMeterParentId='" + strID + "'");
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                object objID = dtAll.Rows[i]["waterMeterId"];
                if (objID != null && objID != DBNull.Value)
                {
                    string strChildID = objID.ToString();
                    GetMeterParentID(strChildID);
                }
            }
            return strMeterParentID;
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

            //DataTable dt = (DataTable)dgList.DataSource;
            DataTable dtPrint = GetDgvToTable(dgList);

            dtPrint.TableName = "用水用户明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\用水用户明细表.frx");
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
                    object obj = dgv.Rows[count].Cells[countsub].Value;
                    if (obj != null && obj != DBNull.Value)
                        dr[countsub] = dgv.Rows[count].Cells[countsub].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
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
            DataTable dtPrint = GetDgvToTable(dgList);
            dtPrint.TableName = "用水用户明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\用水用户明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("用水用户明细表").Enabled = true;
                report1.Prepare();
                report1.PrintSettings.ShowDialog = false;
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

        private void txtWaterMeterCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
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

        private void btSetMonth_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btSetMonth, 0, btSetMonth.Width + 1);
        }

        private void toolExcel_Click(object sender, EventArgs e)
        {
           string strCaption ="转户统计表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
        }

        private void dgList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int intWaterUserListCount = dtWaterUserList.Rows.Count;
            dgList.Rows[dgList.Rows.Count - 1].Cells["meterReaderName"].Value = "合计:";
            object obj = dtWaterUserList.Compute("SUM(UserCount)", "");
            if (Information.IsNumeric(obj))
            dgList.Rows[dgList.Rows.Count - 1].Cells["UserCount"].Value = Convert.ToInt32(obj);
        }

        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex == dgList.Rows.Count - 1)
                return;

            string strFilter = "";
            object obj = dgList.Rows[e.RowIndex].Cells["meterReaderID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strFilter += " AND meterReaderID='"+obj.ToString()+"'";
            }
            obj = dgList.Rows[e.RowIndex].Cells["areaNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strFilter += " AND areaNO='" + obj.ToString() + "'";
            }
            obj = dgList.Rows[e.RowIndex].Cells["duanNO"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strFilter += " AND duanNO='" + obj.ToString() + "'";
            }
            obj = dgList.Rows[e.RowIndex].Cells["waterMeterTypeId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strFilter += " AND waterMeterTypeId='" + obj.ToString() + "'";
            }
            obj = dgList.Rows[e.RowIndex].Cells["waterMeterPositionName"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strFilter += " AND waterMeterPositionName='" + obj.ToString() + "'";
            }
            obj = dgList.Rows[e.RowIndex].Cells["areaNONew"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strFilter += " AND areaNONew='" + obj.ToString() + "'";
            }
            obj = dgList.Rows[e.RowIndex].Cells["duanNONew"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strFilter += " AND duanNONew='" + obj.ToString() + "'";
            }
            obj = dgList.Rows[e.RowIndex].Cells["meterReaderNameNew"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strFilter += " AND meterReaderNameNew='" + obj.ToString() + "'";

            }
            string strSQLQuery = "SELECT * FROM WaterUserMoveRecord WHERE DeleteSign='0' "+strFilter+strFilterTJ;
            DataTable dtList = BLLwaterUser.QuerySQL(strSQLQuery);
            frmWaterUserMoveSearchDetail frm = new frmWaterUserMoveSearchDetail();
            frm.dtList = dtList;
            frm.ShowDialog();
        }      
    }
}
