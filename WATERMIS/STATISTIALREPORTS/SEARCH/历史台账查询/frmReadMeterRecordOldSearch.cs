using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using BLL;
using BASEFUNCTION;
using Microsoft.VisualBasic;

namespace STATISTIALREPORTS
{
    public partial class frmReadMeterRecordOldSearch : DockContentEx
    {
        public frmReadMeterRecordOldSearch()
        {
            InitializeComponent();
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();

        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 旧台账数据库连接字符串
        /// </summary>
        string strConnSQL = "";
        private void frmReadMeterRecordOldSearch_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            strConnSQL = ConfigurationSettings.AppSettings["connSQLOld"];

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);

            BindChargeWorkerName(cmbCharger);
            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindChargeWorkerName(cmbCharger);
            BindMeterReader(cmbMeterReaderS, "0");
            BindWaterMeterType(cmbWaterMeterType);
            BindCommunity(cmbCommunityS, "0");

            cmbMeterReadState.SelectedIndex = 0;
        }
        private void BindCommunity(ComboBox cmb, string strType)
        {
            string strCommunity = "SELECT * FROM 自来水_编号_小区编号 ORDER BY 小区名称";
            DataTable dt = GetReadMeterRecord(strCommunity).Tables[0];
            DataRow dr = dt.NewRow();
            dr["小区名称"] = "全部小区";
            dr["小区名称编号"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "小区名称";
            cmb.ValueMember = "小区名称编号";
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
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
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
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType(ComboBox cmb)
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "全部";
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterMeterTypeValue";
            cmb.ValueMember = "waterMeterTypeId";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        //明细表
        DataTable dtList = new DataTable();
        //合计行
        DataTable dtSum = new DataTable();
        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (txtWaterUserNameSearch.Text != "")
                strFilter += " AND (用户名称 LIKE '%" + txtWaterUserNameSearch.Text + "%' OR 用户编号 LIKE '%" +
                    txtWaterUserNameSearch.Text + "%' OR 地址 LIKE '%" + txtWaterUserNameSearch.Text + "%')";

            if (cmbMeterReaderS.SelectedValue!=null&&cmbMeterReaderS.SelectedValue!=DBNull.Value)
                strFilter += " AND 抄表人员姓名='" + cmbMeterReaderS.Text + "'";

            if (cmbCharger.SelectedValue != null && cmbCharger.SelectedValue != DBNull.Value)
                strFilter += " AND 收费人员姓名='" + cmbCharger.Text + "'";

            if (cmbMeterReadState.SelectedIndex>0)
                strFilter += " AND 台帐状态='" + cmbMeterReadState.Text + "'";

            if (cmbPianNOS.SelectedIndex > 0)
                strFilter += " AND 片号='" + cmbPianNOS.Text + "'";

            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND 区号='" + cmbAreaNOS.Text + "'";

            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND 段号='" + cmbDuanNOS.Text + "'";

            if (cmbCommunityS.SelectedIndex > 0)
                strFilter += " AND 小区名称='" + cmbCommunityS.Text + "'";

            if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                strFilter += " AND 用水性质名称='" + cmbWaterMeterType.Text + "'";

            if (chkYearAndMonth.Checked)
            {
                strFilter += " AND 收费月份 BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";
            }
            strFilter += " ORDER BY 收费月份";
            string strSQL = "SELECT  * FROM 自来水_抄表_抄表台帐 WHERE 1=1 " + strFilter;
            dtList = GetReadMeterRecord(strSQL).Tables[0];
            dgList.DataSource = dtList;
            if (dtList.Rows.Count > 0)
            {
                toolPrint.Enabled = true;
                toolPrintPreview.Enabled = true;
                toolExportToExl.Enabled = true;
            }
            else
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                toolExportToExl.Enabled = false;
            }

            #region 合计行
            int intWaterTotalNumber = 0, intYSHS = 0;
            decimal decWaterFee = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decTotalFee = 0, decTotalFeeEnd = 0, decOverDue = 0, decSJYS = 0,
                decLJQF = 0, decYCZJ = 0, decBCSS = 0, decYCYE = 0, decYHYE = 0;

            dtSum = dtList.Clone();
            dtSum.Columns["收费月份"].DataType = typeof(string);
            DataRow dr = dtSum.NewRow();

            dr["收费月份"] = "合计";
            object obj = dtList.Compute("SUM(用水量)", "");
            if (Information.IsNumeric(obj))
            {
                dr["用水量"] = Convert.ToInt32(obj);
                intWaterTotalNumber = Convert.ToInt32(obj);
            }
            obj = dtList.Compute("SUM(应收_水费)", "");
            if (Information.IsNumeric(obj))
            {
                dr["应收_水费"] = Convert.ToDecimal(obj);
                decWaterFee = Convert.ToDecimal(obj);
            }
            obj = dtList.Compute("SUM(应收_污水费)", "");
            if (Information.IsNumeric(obj))
            {
                dr["应收_污水费"] = Convert.ToDecimal(obj);
                decExtraCharge1 = Convert.ToDecimal(obj);
            }
            obj = dtList.Compute("SUM(应收_附加费)", "");
            if (Information.IsNumeric(obj))
            {
                dr["应收_附加费"] = Convert.ToDecimal(obj);
                decExtraCharge2 = Convert.ToDecimal(obj);
            }
            obj = dtList.Compute("SUM(应收_小计)", "");
            if (Information.IsNumeric(obj))
            {
                dr["应收_小计"] = Convert.ToDecimal(obj);
                decTotalFee = Convert.ToDecimal(obj);
            }
            obj = dtList.Compute("SUM(应收_合计)", "");
            if (Information.IsNumeric(obj))
            {
                dr["应收_合计"] = Convert.ToDecimal(obj);
                decTotalFeeEnd = Convert.ToDecimal(obj);
            }
            obj = dtList.Compute("SUM(应收_滞纳金)", "");
            if (Information.IsNumeric(obj))
            {
                dr["应收_滞纳金"] = Convert.ToDecimal(obj);
                decOverDue = Convert.ToDecimal(obj);
            }
            obj = dtList.Compute("SUM(实际已收)", "");
            if (Information.IsNumeric(obj))
            {
                dr["实际已收"] = Convert.ToDecimal(obj);
                decSJYS = Convert.ToDecimal(obj);
            }
            if (dtList.Rows.Count - 1 > 0)
            {
                obj = dtList.Rows[dtList.Rows.Count - 1]["累计欠费"];
                if (Information.IsNumeric(obj))
                {
                    dr["累计欠费"] = Convert.ToDecimal(obj);
                    decLJQF = Convert.ToDecimal(obj);
                }
                obj = dtList.Rows[dtList.Rows.Count - 1]["预存_预存余额"];
                if (Information.IsNumeric(obj))
                {
                    dr["预存_预存余额"] = Convert.ToDecimal(obj);
                    decYCYE = Convert.ToDecimal(obj);
                }
                obj = dtList.Rows[dtList.Rows.Count - 1]["用户余额"];
                if (Information.IsNumeric(obj))
                {
                    dr["用户余额"] = Convert.ToDecimal(obj);
                    decYHYE = Convert.ToDecimal(obj);
                }
            }
            obj = dtList.Compute("SUM(预存_本月预存)", "");
            if (Information.IsNumeric(obj))
            {
                dr["预存_本月预存"] = Convert.ToDecimal(obj);
                decYCZJ = Convert.ToDecimal(obj);
            }
            obj = dtList.Compute("SUM(预存_实缴金额)", "");
            if (Information.IsNumeric(obj))
            {
                dr["预存_实缴金额"] = Convert.ToDecimal(obj);
                decBCSS = Convert.ToDecimal(obj);
            }
            dtSum.Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 查询历史台账信息
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        private DataSet GetReadMeterRecord(string strSQL)
        {
            using (SqlConnection conn = new SqlConnection(strConnSQL))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter command = new SqlDataAdapter(strSQL, conn);
                try
                {
                    conn.Open();
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    command.Dispose();
                    conn.Close();
                }
                return ds;
            }
        }

        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            object objWaterUserID = dgList.Rows[e.RowIndex].Cells["用户编号"].Value;
            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
            {
                frmReadMeterRecordOldSearchSingleWaterUser frm = new frmReadMeterRecordOldSearchSingleWaterUser();
                frm.strWaterUserID = objWaterUserID.ToString();
                frm.ShowDialog();
            }
        }

        private void toolExportToExl_Click(object sender, EventArgs e)
        {
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel("台账明细查询", dgList);
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

        private void toolPrintPreview_Click(object sender, EventArgs e)
        {
            if (dtList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtRecordTemp = dtList.Clone();
            dtRecordTemp.Columns["收费月份"].DataType = typeof(string);
            foreach (DataRow dr in dtList.Rows)
            {
                dtRecordTemp.ImportRow(dr);
            }
            for (int i = 0; i < dtRecordTemp.Rows.Count; i++)
            {
                object obj = dtRecordTemp.Rows[i]["收费月份"];
                if (Information.IsDate(obj))
                    dtRecordTemp.Rows[i]["收费月份"] = Convert.ToDateTime(obj).ToString("yyyy-MM");
                //object objWaterMeterNO = dtRecord.Rows[i]["waterMeterNo"];
                //if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                //    if (objWaterMeterNO.ToString().Length > 7)
                //        dtRecord.Rows[i]["waterMeterNo"] = objWaterMeterNO.ToString().Substring(6, 2);
            }

            dtRecordTemp.ImportRow(dtSum.Rows[0]);
            DataTable dtPrint = dtRecordTemp.Copy();

            dtPrint.TableName = "历史抄表台账查询";

            string strWaterUserID = "", strWaterUserName = "";
            object objWaterUser = dtList.Rows[0]["用户编号"];
            if (objWaterUser != null && objWaterUser != DBNull.Value)
                strWaterUserID = objWaterUser.ToString();
            objWaterUser = dtList.Rows[0]["用户名称"];
            if (objWaterUser != null && objWaterUser != DBNull.Value)
                strWaterUserName = objWaterUser.ToString();

            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\历史抄表台账查询.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("历史抄表台账查询").Enabled = true;
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
            if (dtList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dtRecordTemp = dtList.Clone();
            dtRecordTemp.Columns["收费月份"].DataType = typeof(string);
            foreach (DataRow dr in dtList.Rows)
            {
                dtRecordTemp.ImportRow(dr);
            }
            for (int i = 0; i < dtRecordTemp.Rows.Count; i++)
            {
                object obj = dtRecordTemp.Rows[i]["收费月份"];
                if (Information.IsDate(obj))
                    dtRecordTemp.Rows[i]["收费月份"] = Convert.ToDateTime(obj).ToString("yyyy-MM");
                //object objWaterMeterNO = dtRecord.Rows[i]["waterMeterNo"];
                //if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                //    if (objWaterMeterNO.ToString().Length > 7)
                //        dtRecord.Rows[i]["waterMeterNo"] = objWaterMeterNO.ToString().Substring(6, 2);
            }

            dtRecordTemp.ImportRow(dtSum.Rows[0]);
            DataTable dtPrint = dtRecordTemp.Copy();

            dtPrint.TableName = "历史抄表台账查询";

            string strWaterUserID = "", strWaterUserName = "";
            object objWaterUser = dtList.Rows[0]["用户编号"];
            if (objWaterUser != null && objWaterUser != DBNull.Value)
                strWaterUserID = objWaterUser.ToString();
            objWaterUser = dtList.Rows[0]["用户名称"];
            if (objWaterUser != null && objWaterUser != DBNull.Value)
                strWaterUserName = objWaterUser.ToString();

            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\历史抄表台账查询.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("历史抄表台账查询").Enabled = true;
                // run the report
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
    }
}
