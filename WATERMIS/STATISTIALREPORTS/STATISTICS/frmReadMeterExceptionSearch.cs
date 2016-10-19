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
    public partial class frmReadMeterExceptionSearch : DockContentEx
    {
        public frmReadMeterExceptionSearch()
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
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();


        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                //禁止列排序
                dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (dgList.Columns[i].Name == "cellSelect")
                {
                    //本月读数可编辑
                    dgList.Columns[i].ReadOnly = false;
                }
                else
                    dgList.Columns[i].ReadOnly = true;

                //隐藏附加费列
                if (dgList.Columns[i].Name == "extraChargePrice1" || dgList.Columns[i].Name == "extraCharge1" ||
                    dgList.Columns[i].Name == "extraChargePrice2" || dgList.Columns[i].Name == "extraCharge2" ||
                    dgList.Columns[i].Name == "extraChargePrice3" || dgList.Columns[i].Name == "extraCharge3" ||
                    dgList.Columns[i].Name == "extraChargePrice4" || dgList.Columns[i].Name == "extraCharge4" ||
                    dgList.Columns[i].Name == "extraChargePrice5" || dgList.Columns[i].Name == "extraCharge5" ||
                    dgList.Columns[i].Name == "extraChargePrice6" || dgList.Columns[i].Name == "extraCharge6" ||
                    dgList.Columns[i].Name == "extraChargePrice7" || dgList.Columns[i].Name == "extraCharge7" ||
                    dgList.Columns[i].Name == "extraChargePrice8" || dgList.Columns[i].Name == "extraCharge8")
                {
                    dgList.Columns[i].Visible = false;
                }
            }
            GetExtraFeeName();
            BindArea();
            BindMeterReader();
            BindWaterMeterType();
            cmbWaterFeeYear.SelectedIndex = 0;
            cmbWaterFeeMonth.Text = DateTime.Now.Month.ToString().PadLeft(2,'0');
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
                    dgList.Columns["extraCharge" + (i + 1).ToString()].HeaderText = objExtraFee.ToString();
                    dgList.Columns["extraChargePrice" + (i + 1).ToString()].HeaderText = objExtraFee.ToString() + "单价";

                    object objExtraChargeState = dt.Rows[i]["extraChargeState"];
                    if (objExtraChargeState != null && objExtraChargeState != DBNull.Value)
                    {
                        if (objExtraChargeState.ToString() == "启用")
                        {
                            dgList.Columns["extraCharge" + (i + 1).ToString()].Visible = true;
                            dgList.Columns["extraChargePrice" + (i + 1).ToString()].Visible = true;
                        }
                    }
                }
            }
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
        private void BindMeterReader()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbMeterReader.DataSource = dt;
            cmbMeterReader.DisplayMember = "USERNAME";
            cmbMeterReader.ValueMember = "LOGINID";
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
        /// 绑定区域
        /// </summary>
        private void BindArea()
        {
            DataTable dt = BLLAREA.Query(" AND areaId<>'0000'");
            DataRow dr = dt.NewRow();
            dr["areaName"] = "";
            dr["areaId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbArea.DataSource = dt;
            cmbArea.DisplayMember = "areaName";
            cmbArea.ValueMember = "areaId";
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
        private void toolSearch_Click(object sender, EventArgs e)
        {
            if (cmbWaterFeeYear.Text == "" || cmbWaterFeeMonth.Text == "")
            {
                mes.Show("请选择抄表年份及月份!");
                return;
            }
            if (!Information.IsNumeric(txtRangeValue.Text))
            {
                mes.Show("波动范围只能为数字!");
                txtRangeValue.Focus();
                return;
            }
            dgList.DataSource = null;
            waitfrm = new frmWaitSearch();
            bgWork.RunWorkerAsync();
            waitfrm.ShowDialog();
        }

        //Thread TD;
        //private void RefreshData()
        //{
        //    try
        //    {
        //        TD = new Thread(showwaitfrm);
        //        TD.Start();
        //        //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
        //        LoadData();
        //        TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Write("异常用水查询与分析界面:" + ex.ToString(), MsgType.Error);
        //        //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
        //    }
        //}
        ////传递给线程的方法.
        //private void showwaitfrm()
        //{
        //    try
        //    {
        //        frmWaitSearch waitfrm = new frmWaitSearch();
        //        waitfrm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Write("异常用水查询与分析界面:" + ex.ToString(), MsgType.Error);
        //    }
        //}

        frmWaitSearch waitfrm = new frmWaitSearch();

        /// <summary>
        /// 存储查询到的用户列表
        /// </summary>
        DataTable dtList = new DataTable();

        /// <summary>
        /// 存储统计行信息
        /// </summary>
        DataTable dtClone = new DataTable();
        private void LoadData()
        {
            try
            {
                string strFilter = " AND  WATERMETERNUMBERCHANGESTATE='0' "+ strSeniorFilterHidden;
                if (txtWaterUserNOSearch.Text.Trim() != "")
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim().PadLeft(8, '0') + "'";

                if (txtWaterUserNameSearch.Text.Trim() != "")
                    strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

                if (cmbWaterUserHouseType.Text != "")
                    strFilter += " AND waterUserHouseTypeS='" + cmbWaterUserHouseType.Text + "'";

                if (cmbArea.SelectedValue != null && cmbArea.SelectedValue != DBNull.Value)
                    strFilter += " AND areaId='" + cmbArea.SelectedValue.ToString() + "'";

                if (cmbMeterReader.SelectedValue != null && cmbMeterReader.SelectedValue != DBNull.Value)
                    strFilter += " AND loginId='" + cmbMeterReader.SelectedValue.ToString() + "'";

                if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (cmbWaterFeeYear.Text != "")
                    strFilter += " AND readMeterRecordYear='" + cmbWaterFeeYear.Text + "'";

                if (cmbWaterFeeMonth.Text != "")
                    strFilter += " AND readMeterRecordMonth='" + cmbWaterFeeMonth.Text + "'";

                if (cmbIsMeterRead.SelectedIndex > 0)
                    strFilter += " AND chargeState='" + cmbIsMeterRead.SelectedIndex.ToString() + "'";

                if (rbWaterMeterReading.Checked)
                    strFilter += " ORDER BY meterReadingNO,ordernumber";
                if (rbWaterUserName.Checked)
                    strFilter += " ORDER BY waterUserName";
                if (rbWaterUserNO.Checked)
                    strFilter += " ORDER BY waterUserNO";

                //获取要查询的月份
                DateTime dtYearAndMonth = new DateTime(Convert.ToInt16(cmbWaterFeeYear.Text),Convert.ToInt16(cmbWaterFeeMonth.Text),1);

                dtList = new DataTable();
                if (rbPeriodNumber.Checked)
                {
                    dtList = BLLreadMeterRecord.GetReadMeterException("P_EXCEPTIONMETERREAD", strFilter, dtYearAndMonth, Convert.ToInt16(txtPeriodNumber.Text), Convert.ToDecimal(Convert.ToInt16(txtRangeValue.Text) / 100.0));
                    dgList.Columns["AVGTOTALNUMBER"].HeaderText = "近" + txtPeriodNumber.Text + "期平均数";
                }
                else
                {
                    dtList = BLLreadMeterRecord.GetReadMeterException("P_EXCEPTIONMETERREAD_LASTYEAR", strFilter, dtYearAndMonth, Convert.ToInt16(txtPeriodNumber.Text), Convert.ToDecimal(Convert.ToInt16(txtRangeValue.Text) / 100.0));
                    dgList.Columns["AVGTOTALNUMBER"].HeaderText = "去年同期数";
                }

                if (dtList.Rows.Count == 0)
                {
                    dgList.DataSource = null;
                    toolPrint.Enabled = false;
                    toolPrintPreview.Enabled = false;
                }
                else
                {
                    dtClone = dtList.Clone();
                    DataRow drLast = dtClone.NewRow();
                    drLast["waterUserNO"] = "合计:";

                    int intTotalNumber = 0, intAvgTotalNumber = 0;
                    object objMeterCount = dtList.Compute("COUNT(waterMeterNo)", "");
                    if (Information.IsNumeric(objMeterCount))
                    {
                        drLast["waterMeterNo"] = Convert.ToInt32(objMeterCount);
                    }

                    object objTotalNumber= dtList.Compute("SUM(totalNumber)", "");
                    if (Information.IsNumeric(objTotalNumber))
                    {
                        drLast["totalNumber"] = Convert.ToInt32(objTotalNumber);
                        intTotalNumber = Convert.ToInt32(objTotalNumber);
                    }

                    object objAvgTotalNumber = dtList.Compute("SUM(AVGTOTALNUMBER)", "");
                    if (Information.IsNumeric(objAvgTotalNumber))
                    {
                        drLast["AVGTOTALNUMBER"] = Convert.ToInt32(objAvgTotalNumber);
                        intAvgTotalNumber = Convert.ToInt32(objAvgTotalNumber);
                    }

                    object objBILV = dtList.Compute("SUM(BILV)", "");
                    if (Information.IsNumeric(objBILV))
                        drLast["BILV"] = Math.Round((intTotalNumber - intAvgTotalNumber) / (intAvgTotalNumber*1.0),2);

                    dtClone.Rows.Add(drLast);
                    ucPageSetUp1.InitialUC(this.dgList, dtList, dtClone);

                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbWaterMeterReading_CheckedChanged(object sender, EventArgs e)
        {
            if (dgList.Rows.Count > 0)
            {
                DataTable dtList = (DataTable)dgList.DataSource;
                DataView dvList = dtList.DefaultView;

                string strSort = "";
                if (rbWaterMeterReading.Checked)
                    strSort += "meterReadingNO,meterReadingPageNo";
                if (rbWaterUserName.Checked)
                    strSort += "waterUserName";
                if (rbWaterUserNO.Checked)
                    strSort += "waterUserNO";
                dvList.Sort = strSort;
                dgList.DataSource = dvList.ToTable();
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
            DataTable dtPrint = dtList.Copy();
            if(dtClone.Rows.Count>0)
            dtList.ImportRow(dtClone.Rows[0]);
            dtPrint.TableName = "异常用水明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\异常用水明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("异常用水明细表").Enabled = true;
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
            if (dtList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }
            DataSet ds = new DataSet();
            DataTable dtPrint = dtList.Copy();
            if (dtClone.Rows.Count > 0)
                dtPrint.ImportRow(dtClone.Rows[0]);
            dtPrint.TableName = "异常用水明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\异常用水明细表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("异常用水明细表").Enabled = true;
                // run the report
                report1.Show();
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
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
                    if (obj != null && obj != DBNull.Value)
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

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "chargeState")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "已抄表";
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "已预收";
                    else if (e.Value.ToString() == "3")
                        e.Value = "已收费";
            }
        }

        private void txtRangeValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)22)
            {
                e.Handled = true;
            }
        }

        private void txtPeriodNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtPeriodNumber.Text == "0")
                txtPeriodNumber.Text = "1";
        }

        private void txtRangeValue_TextChanged(object sender, EventArgs e)
        {
            if (txtRangeValue.Text == "0")
                txtRangeValue.Text = "1";
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!waitfrm.IsDisposed)
                    waitfrm.Close();
            }
            catch (Exception ex)
            {
                log.Write(ex.ToString(), MsgType.Error);
            }
        }
        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "8";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }
    }
}
