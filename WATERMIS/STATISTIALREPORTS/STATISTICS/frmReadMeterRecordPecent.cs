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
    public partial class frmReadMeterRecordPecent : DockContentEx
    {
        public frmReadMeterRecordPecent()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();
        BLLAREA BLLAREA = new BLLAREA();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();

        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);        

        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpMeterReadYearMonthStart.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtpMeterReadYearMonthEnd.Value = dtMonthEnd;

            BindMeterReader(cmbMeterReader);
            BindWaterMeterType(cmbWaterMeterType);
        }

        /// <summary>
        /// 绑定用户类别
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
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
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
        /// 绑定托收银行
        /// </summary>
        /// <param name="cmb"></param>
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

        //存储统计的名称
        private string strStaticsName = "";
        private void toolSearch_Click(object sender, EventArgs e)
        {
            dgList.DataSource = null;
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
                log.Write("水表查抄率统计界面:" + ex.ToString(), MsgType.Error);
                TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
                mes.Show(ex.Message);
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
                log.Write("水表查抄率统计界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 查询到的数据表
        /// </summary>
        DataTable dtStastics = new DataTable();
        private void LoadData()
        {
            string strStatisticsContent = "", strStatisticsGroupBy = "";
            string strFilter = " AND WATERMETERNUMBERCHANGESTATE='0' ";

            if (txtWaterUserNOSearch.Text.Trim() != "")
            {
                if (txtWaterUserNOSearch.Text.Length < 6)
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                else
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
            }

            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

            if (cmbWaterUserHouseType.Text != "")
                strFilter += " AND waterUserHouseTypeS='" + cmbWaterUserHouseType.Text + "'";

            if (cmbMeterReader.SelectedValue != null && cmbMeterReader.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderID='" + cmbMeterReader.SelectedValue.ToString() + "'";

            if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

            if (chkMeterReadYearMonth.Checked)
                strFilter += " AND readMeterRecordYearAndMonth " +
                    "BETWEEN  '" + dtpMeterReadYearMonthStart.Value + "' AND '" + dtpMeterReadYearMonthEnd.Value + "'";

            if (chkPianNO.Checked)
            {
                strStatisticsContent = "pianNO AS 片号";
                strStatisticsGroupBy = "pianNO";
            }

            if (chkAreaNO.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",areaNO AS 区号";
                    strStatisticsGroupBy += ",areaNO";
                }
                else
                {
                    strStatisticsContent = "areaNO AS 区号";
                    strStatisticsGroupBy = "areaNO";
                }
            }

            if (chkDuanNO.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",duanNO AS 段号";
                    strStatisticsGroupBy += ",duanNO";
                }
                else
                {
                    strStatisticsContent = "duanNO AS 段号";
                    strStatisticsGroupBy = "duanNO";
                }
            }

            if (chkRecordMonth.Checked)
            {
                if (strStatisticsContent != "")
                {
                    //strStatisticsContent += ",(YEAR(readMeterRecordYearAndMonth)+'-'+MONTH(readMeterRecordYearAndMonth)) AS 水费月份";
                    strStatisticsContent += ",readMeterRecordYearAndMonth AS 水费月份";
                    strStatisticsGroupBy += ",readMeterRecordYearAndMonth";
                }
                else
                {
                    strStatisticsContent = "readMeterRecordYearAndMonth AS 水费月份";
                    strStatisticsGroupBy = "readMeterRecordYearAndMonth";
                }
            }

            if (chkWaterUserType.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",waterUserTypeId AS 用户类别编号,waterUserTypeName AS 用户类别";
                    strStatisticsGroupBy += ",waterUserTypeId,waterUserTypeName";
                }
                else
                {
                    strStatisticsContent = "waterUserTypeId AS 用户类别编号,waterUserTypeName AS 用户类别";
                    strStatisticsGroupBy = "waterUserTypeId,waterUserTypeName";
                }
            }

            if (chkWaterMeterTypeClass.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",WATERMETERTYPECLASSNAME AS 用水性质分类";
                    strStatisticsGroupBy += ",WATERMETERTYPECLASSNAME";
                }
                else
                {
                    strStatisticsContent = "WATERMETERTYPECLASSNAME AS 用水性质分类";
                    strStatisticsGroupBy = "WATERMETERTYPECLASSNAME";
                }
            }

            if (chkWaterMeterType.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",WATERMETERTYPEID AS 用水性质编号,waterMeterTypeName AS 用水性质名称";
                    strStatisticsGroupBy += ",WATERMETERTYPEID,waterMeterTypeName";
                }
                else
                {
                    strStatisticsContent = "WATERMETERTYPEID AS 用水性质编号,waterMeterTypeName AS 用水性质名称";
                    strStatisticsGroupBy = "WATERMETERTYPEID,waterMeterTypeName";
                }
            }

            if (chkCharger.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",chargerID AS 收费员编号,chargerName AS 收费员姓名";
                    strStatisticsGroupBy += ",chargerID,chargerName";
                }
                else
                {
                    strStatisticsContent = "chargerID AS 收费员编号,chargerName AS 收费员姓名";
                    strStatisticsGroupBy = "chargerID,chargerName";
                }
            }

            if (chkMeterReader.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",meterReaderID AS 抄表员编号,meterReaderName AS 抄表员姓名";
                    strStatisticsGroupBy += ",meterReaderID,meterReaderName";
                }
                else
                {
                    strStatisticsContent = "meterReaderID AS 抄表员编号,meterReaderName AS 抄表员姓名";
                    strStatisticsGroupBy = "meterReaderID,meterReaderName";
                }
            }

            if (strStatisticsContent != "")
            {
                strStatisticsGroupBy = " GROUP BY " + strStatisticsGroupBy;
                strStatisticsContent = "SELECT " + strStatisticsContent +
                    ",COUNT(*) AS 应抄总数,SUM(CASE  WHEN (CHARGESTATE='0'OR waterMeterEndNumber=waterMeterLastNumber)  THEN 1 ELSE 0 END) AS 未抄数量," +
                    "SUM(CASE  WHEN  CHARGESTATE<>'0' AND   waterMeterEndNumber<>waterMeterLastNumber THEN 1 ELSE 0 END) AS 已抄数量,'' AS 抄表率 " +
                    "FROM (SELECT * FROM readMeterRecord WHERE 1=1 " + strFilter + ") AS AA";
                strStatisticsContent = strStatisticsContent + strStatisticsGroupBy;
            }
            else
            {
                strStatisticsContent = "SELECT " +
                    " COUNT(*) AS 应抄总数,SUM(CASE  WHEN (CHARGESTATE='0'OR waterMeterEndNumber=waterMeterLastNumber)  THEN 1 ELSE 0 END) AS 未抄数量," +
                    "SUM(CASE  WHEN  CHARGESTATE<>'0' AND   waterMeterEndNumber<>waterMeterLastNumber THEN 1 ELSE 0 END) AS 已抄数量,'' AS 抄表率 " +
                    "FROM (SELECT * FROM readMeterRecord WHERE 1=1 " + strFilter + ") AS AA";
            }

            dtStastics = new DataTable();
            dtStastics = BLLWATERFEECHARGE.QueryBySQL(strStatisticsContent);
            dgList.DataSource = dtStastics;

            //DataTable dtTemp = dtStastics.Copy();

            #region 计算每一行的抄表率
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                decimal decYCSL = 0, decZSL = 0;
                object objYCSL = dgList.Rows[i].Cells["已抄数量"].Value;
                if (Information.IsNumeric(objYCSL))
                {
                    decYCSL = Convert.ToDecimal(objYCSL);
                }
                object objZSL = dgList.Rows[i].Cells["应抄总数"].Value;
                if (Information.IsNumeric(objZSL))
                {
                    decZSL = Convert.ToDecimal(objZSL);
                }
                if (decZSL > 0)
                {
                    dgList.Rows[i].Cells["抄表率"].Value = (decYCSL * 100 / decZSL).ToString("F2") + "%";
                }
            }
            #endregion

            #region 统计信息
            //DataRow dr = dtTemp.Rows.Add();
            //dr["编号ID"] = "合计:";
            //dr["抄表员"] = dtStastics.Rows.Count;

            ////记录所有应抄数量以及已抄数量
            //decimal decAllMeterReadCount = 0, decYCSLMeterReadCount = 0;
            //object objSum = dtTemp.Compute("SUM(总表数)", "");
            //if (Information.IsNumeric(objSum))
            //{
            //    decAllMeterReadCount = Convert.ToInt64(objSum);
            //    dr["总表数"] = decAllMeterReadCount;
            //}

            //objSum = dtTemp.Compute("SUM(未抄数量)", "");
            //if (Information.IsNumeric(objSum))
            //    dr["未抄数量"] = Convert.ToInt64(objSum);

            //objSum = dtTemp.Compute("SUM(已抄数量)", "");
            //if (Information.IsNumeric(objSum))
            //{
            //    decYCSLMeterReadCount = Convert.ToInt64(objSum);
            //    dr["已抄数量"] = decYCSLMeterReadCount;
            //}
            //if (decAllMeterReadCount > 0)
            //    dr["抄表率"] = (decYCSLMeterReadCount * 100 / decAllMeterReadCount).ToString("F2") + "%";
            #endregion
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();

            DataTable dt = (DataTable)dgList.DataSource;
            DataTable dtPrint = dt.Copy();
            dtPrint.TableName = strStaticsName;
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\查抄率统计模板\" + strStaticsName + ".frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource(strStaticsName).Enabled = true;
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
            if (dgList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();

            DataTable dt = (DataTable)dgList.DataSource;
            DataTable dtPrint = dt.Copy();
            dtPrint.TableName = strStaticsName;
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\查抄率统计模板\" + strStaticsName + ".frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource(strStaticsName).Enabled = true;
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
        /// <param name="isContainColumns">是否包含列标题</param>
        /// <returns>返回临时内存表</returns>
        public static DataTable GetDgvToTable(DataGridView dgv,bool isContainColumns)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            if (isContainColumns)
            {
                DataRow dr = dt.NewRow();
                for (int count = 0; count < dgv.Columns.Count; count++)
                {
                    string strColumnText = dgv.Columns[count].HeaderText;
                    dr[count] = strColumnText;
                }
                dt.Rows.Add(dr);
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
            Brush gridBrush = new SolidBrush(dgList.GridColor);
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
            string curValueID = dgList.Rows[e.RowIndex].Cells["waterUserId"].Value == null ? "" : dgList.Rows[e.RowIndex].Cells["waterUserId"].Value.ToString().Trim();
            //if (!string.IsNullOrEmpty(curValue))
            //{
            #region 获取下面的行数
            for (int i = e.RowIndex; i < dgList.Rows.Count; i++)
            {
                object objValue = dgList.Rows[i].Cells[e.ColumnIndex].Value;
                string strValue = objValue == null ? "" : objValue.ToString();
                if (strValue.Equals(curValue) && dgList.Rows[i].Cells["waterUserId"].Value.ToString().Equals(curValueID))
                //if (dgList.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                {
                    //dgList.Rows[i].Cells[e.ColumnIndex].Selected = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;

                    DownRows++;
                    if (e.RowIndex != i)
                    {
                        cellwidth = cellwidth < dgList.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgList.Rows[i].Cells[e.ColumnIndex].Size.Width;
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
                object objValue = dgList.Rows[i].Cells[e.ColumnIndex].Value;
                string strValue = objValue == null ? "" : objValue.ToString();
                if (strValue.Equals(curValue) && dgList.Rows[i].Cells["waterUserId"].Value.ToString().Equals(curValueID))
                //if (dgList.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                {
                    //dgList.Rows[i].Cells[e.ColumnIndex].Selected = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
                    UpRows++;
                    if (e.RowIndex != i)
                    {
                        cellwidth = cellwidth < dgList.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgList.Rows[i].Cells[e.ColumnIndex].Size.Width;
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
            if (dgList.Rows[e.RowIndex].Selected)
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

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "9";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }

        private void dgList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            decimal decYCSLMeterReadCount =0, decAllMeterReadCount = 0;

            object objSum = dtStastics.Compute("SUM(应抄总数)", "");
            if (Information.IsNumeric(objSum))
            {
                dgList.Rows[dgList.Rows.Count - 1].Cells["应抄总数"].Value = Convert.ToDecimal(objSum);
                decAllMeterReadCount = Convert.ToDecimal(objSum);
            }

            objSum = dtStastics.Compute("SUM(未抄数量)", "");
            if (Information.IsNumeric(objSum))
                dgList.Rows[dgList.Rows.Count - 1].Cells["未抄数量"].Value = Convert.ToDecimal(objSum);

            objSum = dtStastics.Compute("SUM(已抄数量)", "");
            if (Information.IsNumeric(objSum))
            {
                dgList.Rows[dgList.Rows.Count - 1].Cells["已抄数量"].Value = Convert.ToDecimal(objSum);
                decYCSLMeterReadCount = Convert.ToDecimal(objSum);
            }
            if (decAllMeterReadCount == 0)
                dgList.Rows[dgList.Rows.Count - 1].Cells["抄表率"].Value = 0;
            else
                dgList.Rows[dgList.Rows.Count - 1].Cells["抄表率"].Value = (decYCSLMeterReadCount * 100 / decAllMeterReadCount).ToString("F2") + "%";
        }

        private void toolExcel_Click(object sender, EventArgs e)
        {
            string strCaption ="水表查抄率统计表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
        }
        
    }
}
