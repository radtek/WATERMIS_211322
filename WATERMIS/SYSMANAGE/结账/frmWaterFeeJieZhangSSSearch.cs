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
using MODEL;
using BASEFUNCTION;
using FastReport;

namespace SYSMANAGE
{
    public partial class frmWaterFeeJieZhangSSSearch : DockContentEx
    {
        public frmWaterFeeJieZhangSSSearch()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLDAYCHECKPERSONAL BLLDAYCHECKPERSONAL = new BLLDAYCHECKPERSONAL();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLSETTLEACCOUNTYS BLLSETTLEACCOUNTYS = new BLLSETTLEACCOUNTYS();

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        public string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";        

        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart=new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;

            dgJieZhangYS.AutoGenerateColumns = false;
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

        private void dgJieZhangYS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region 合计行
            dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["WATERMETERTYPECLASSNAME"].Value = "合  计";
            object obj = dtWaterMeterListYingShou.Compute("SUM(BILLCOUNT)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["BILLCOUNT"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(INVOICECOUNT)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["INVOICECOUNT"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(RECEIPTNOCOUNT)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["RECEIPTNOCOUNT"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(TOTALNUMBER)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["TOTALNUMBER"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(WATERTOTALCHARGE)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["WATERTOTALCHARGE"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(EXTRACHARGE1)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["EXTRACHARGE1"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(EXTRACHARGE2)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["EXTRACHARGE2"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(TOTALCHARGE)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["TOTALCHARGE"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(OVERDUEMONEY)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["OVERDUEMONEY"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(TOTALCHARGEEND)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["TOTALCHARGEEND"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(YCZJ)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["YCZJ"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterListYingShou.Compute("SUM(SSJE)", "");
            if (Information.IsNumeric(obj))
                dgJieZhangYS.Rows[dgJieZhangYS.Rows.Count - 1].Cells["SSJE"].Value = Convert.ToDecimal(obj);
            #endregion
        }
        DataTable dtWaterMeterListYingShou = new DataTable();
        private void toolSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dtpStartSearch.Value = dtpStart.Value;
                string strFilter = " AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpStart.Value + "')=0 ";
                string strSQL = "SELECT WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,SUM(BILLCOUNT) AS BILLCOUNT," +
                                "SUM(INVOICECOUNT) AS INVOICECOUNT,SUM(RECEIPTNOCOUNT) AS RECEIPTNOCOUNT," +
                                "SUM(TOTALNUMBER) AS TOTALNUMBER,SUM(WATERTOTALCHARGE) AS WATERTOTALCHARGE," +
                                "SUM(EXTRACHARGE1) AS EXTRACHARGE1,SUM(EXTRACHARGE2) AS EXTRACHARGE2," +
                                "SUM(TOTALCHARGE) AS TOTALCHARGE,SUM(OVERDUEMONEY) AS OVERDUEMONEY," +
                                "SUM(OVERDUEMONEY) AS OVERDUEMONEY,SUM(TOTALCHARGEEND) AS TOTALCHARGEEND," +
                                "SUM(YCZJ) AS YCZJ,SUM(SSJE) AS SSJE " +
                                "FROM (SELECT * FROM SETTLEACCOUNTSS WHERE 1=1 " + strFilter + ") AS AA GROUP BY WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME";
                dtWaterMeterListYingShou = BLLWATERFEECHARGE.QueryBySQL(strSQL);
                dgJieZhangYS.DataSource = dtWaterMeterListYingShou;
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }
        
        private void toolPrintPreview_Click(object sender, EventArgs e)
        {
            if (dgJieZhangYS.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }
            decimal decSum = 0;
            DataSet ds = new DataSet();
            DataTable dtPrint = GetDgvToTable(dgJieZhangYS);
            dtPrint.TableName = "实收水费统计(按用水性质)";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\应收水费统计模板\实收水费统计(结账报表).frx");
                (report1.FindObject("txtMonth") as FastReport.TextObject).Text = "实收月份：" + dtpStartSearch.Value.ToString("yyyy-MM");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("实收水费统计(按用水性质)").Enabled = true;
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
            if (dgJieZhangYS.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }
            decimal decSum = 0;
            DataSet ds = new DataSet();
            DataTable dtPrint = GetDgvToTable(dgJieZhangYS);
            dtPrint.TableName = "实收水费统计(按用水性质)";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\应收水费统计模板\实收水费统计(结账报表).frx");
                (report1.FindObject("txtMonth") as FastReport.TextObject).Text = "实收月份：" + dtpStartSearch.Value.ToString("yyyy-MM");
                report1.RegisterData(ds);
                report1.GetDataSource("实收水费统计(按用水性质)").Enabled = true;
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
                    object obj = dgv.Rows[count].Cells[countsub].Value;
                    if (obj != null && obj != DBNull.Value)
                        dr[countsub] = dgv.Rows[count].Cells[countsub].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void dgJieZhangYS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (e.RowIndex == dgJieZhangYS.Rows.Count - 1)
                return;
            object obj = dgJieZhangYS.Rows[e.RowIndex].Cells["WATERMETERTYPECLASSID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                string strFilter = " AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpStart.Value + "')=0  AND WATERMETERTYPECLASSID='"+obj.ToString()+"'";
                frmWaterFeeJieZhangSSClassSearch frm = new frmWaterFeeJieZhangSSClassSearch();
                frm.strFilter = strFilter;
                frm.dtMonth = dtpStartSearch.Value;
                frm.ShowDialog();
            }
        }
    }
}
