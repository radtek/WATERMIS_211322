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
using MODEL;

namespace WATERFEEMANAGE
{
    public partial class frmPrintInvoiceCancel : DockContentEx
    {
        public frmPrintInvoiceCancel()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLoginID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strLoginName = "";


        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                //禁止列排序
                dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strLoginName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            cmbInvoiceState.SelectedIndex = 1;
            BindWaterMeterType();
            BindChargerName(cmbCharger);
            //BindWaterUserType(cmbWaterUserTypeSearch);
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargerName(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser("");
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
        /// 绑定用户类别
        /// </summary>
        /// <param name="cmb"></param>
        private void BindWaterUserType(ComboBox cmb)
        {
            DataTable dt = BLLwaterUserType.Query("");
            DataRow dr = dt.NewRow();
            dr["waterUserTypeName"] = "全部";
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
        private void BindWaterMeterType()
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "全部";
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbWaterMeterType.DataSource = dt;
            cmbWaterMeterType.DisplayMember = "waterMeterTypeValue";
            cmbWaterMeterType.ValueMember = "waterMeterTypeId";
            cmbWaterMeterType.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmbWaterMeterType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilterS = "";
            string strStartInvoiceNO = "", strEndInvoiceNO = "";
            if (chkInvoiceRange.Checked)
            {
                if (!Information.IsNumeric(txtStartNO.Text))
                {
                    mes.Show("发票起始号码只能为数字!");
                    txtStartNO.Focus();
                    return;
                }
                else
                {
                    strStartInvoiceNO = Convert.ToInt32(txtStartNO.Text).ToString().PadLeft(8, '0');
                }
                if (Information.IsNumeric(txtEndNO.Text))
                {
                    if (Convert.ToInt32(txtStartNO.Text) > Convert.ToInt32(txtEndNO.Text))
                    {
                        mes.Show("发票起始号码不能大于终止号码!");
                        txtEndNO.Focus();
                        return;
                    }
                    strEndInvoiceNO = Convert.ToInt32(txtEndNO.Text).ToString().PadLeft(8, '0');
                }
                if (strStartInvoiceNO != "")
                {
                    if (strEndInvoiceNO != "")
                        strFilterS += " AND INVOICENO BETWEEN '" + strStartInvoiceNO + "' AND '" + strEndInvoiceNO + "'";
                    else
                        strFilterS += " AND INVOICENO>='" + strStartInvoiceNO + "'";
                }
            }
            RefreshData(strFilterS);
        }

        Thread TD;
        private void RefreshData(string strFilterS)
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
                LoadData(strFilterS);
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
                log.Write("发票使用明细查询界面:" + ex.ToString(), MsgType.Error);
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
        }
        //传递给线程的方法.
        frmWaitSearch waitfrm = new frmWaitSearch();
        private void showwaitfrm()
        {
            try
            {
                waitfrm = new frmWaitSearch();
                waitfrm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Write("发票使用明细查询界面:" + ex.ToString(), MsgType.Error);
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
        private void LoadData(string strFilterS)
        {
            try
            {
                string strFilter = strFilterS;

                if (chbInvoicePrintDateTime.Checked)
                    strFilter += " AND INVOICEPRINTDATETIME BETWEEN '" + dtpStartPrint.Text + "' AND '" + dtpEndPrint.Text + "'";

                if (cmbInvoiceState.SelectedIndex > 0)
                {
                    if (cmbInvoiceState.SelectedIndex == 1)
                    {
                        strFilter += " AND INVOICECANCEL='0'";
                    }
                    else if (cmbInvoiceState.SelectedIndex == 2)
                    {
                        strFilter += " AND INVOICECANCEL<>0";
                    }
                }

                //if (cmbWaterUserTypeSearch.SelectedValue != null && cmbWaterUserTypeSearch.SelectedValue != DBNull.Value)
                //    strFilter += " AND waterUserTypeId='" + cmbWaterUserTypeSearch.SelectedValue.ToString() + "'";

                if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                    strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

                if (cmbCharger.SelectedValue != null && cmbCharger.SelectedValue != DBNull.Value)
                    strFilter += " AND INVOICEPRINTWORKERID='" + cmbCharger.SelectedValue.ToString() + "'";

                //if (txtWaterUserNOSearch.Text != "")
                //    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim().PadLeft(8,'0') + "'";

                if (txtWaterUserNameSearch.Text != "")
                    strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

                strFilter += " ORDER BY INVOICEPRINTDATETIME";
                dtWaterMeterList = BLLCHARGEINVOICEPRINT.QueryInvoicePrint(strFilter);

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;
                    btInvoiceCancel.Enabled = true;
                    toolExportToExl.Enabled = true;

                    dtClone = dtWaterMeterList.Clone();
                    DataRow drLast = dtClone.NewRow();

                    drLast["INVOICEBATCHNAME"] = "合计:";

                    DataTable dtWaterMeterListOld = dtWaterMeterList.Copy();

                    drLast["INVOICENO"] = dtWaterMeterListOld.Rows.Count;

                    object objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(totalNumber)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        drLast["totalNumber"] = Convert.ToInt64(objSumWaterToltalChargeEnd);

                    objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(waterTotalCharge)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        drLast["waterTotalCharge"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");

                    objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(extraCharge1)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        drLast["extraCharge1"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");

                    objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(extraCharge2)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        drLast["extraCharge2"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");

                    objSumWaterToltalChargeEnd = dtWaterMeterListOld.Compute("SUM(totalCharge)", "");
                    if (Information.IsNumeric(objSumWaterToltalChargeEnd))
                        drLast["totalCharge"] = Convert.ToDecimal(objSumWaterToltalChargeEnd).ToString("F2");

                    dtClone.Rows.Add(drLast);
                    ucPageSetUp1.InitialUC(this.dgList, dtWaterMeterList, dtClone);
                }
                else
                {
                    toolPrint.Enabled = false;
                    toolPrintPreview.Enabled = false;
                    btInvoiceCancel.Enabled = false;
                    toolExportToExl.Enabled = false;
                    dgList.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
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
            dtPrint.TableName = "发票使用明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\发票使用明细表(自定额).frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("发票使用明细表").Enabled = true;
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
            dtPrint.TableName = "发票使用明细表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\发票使用明细表(自定额).frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("发票使用明细表").Enabled = true;
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

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "INVOICECANCEL")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "正常";
                    }
                    else if (e.Value.ToString() == "1")
                        e.Value = "损坏作废";
                    else if (e.Value.ToString() == "2")
                        e.Value = "未打作废";
            }
        }

        private void toolExportToExl_Click(object sender, EventArgs e)
        {

        }

        private void btInvoiceCancel_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
            {
                mes.Show("请选择要作废的发票!");
                return;
            }
            if (cmbInvoiceCancelReason.SelectedIndex < 1)
            {
                cmbInvoiceCancelReason.Focus();
                mes.Show("请选择发票作废原因!");
                return;
            }
            object objID = dgList.CurrentRow.Cells["CHARGEINVOICEPRINTID"].FormattedValue;
            if (objID == null || objID == DBNull.Value)
            {
                    mes.Show("获取发票单据ID失败,请重新查询后再执行此操作!");
                    return;
            }
            object objState=dgList.CurrentRow.Cells["INVOICECANCEL"].FormattedValue;
            if (objState != null && objState != DBNull.Value)
            {
                if (objState.ToString() != "正常")
                {
                    mes.Show("该发票已经作废，无需再次作废!");
                    return;
                }
            }
            string strInvoiceNO = "";
            object objInvoiceNO = dgList.CurrentRow.Cells["INVOICENO"].FormattedValue;
            if (objInvoiceNO != null && objInvoiceNO != DBNull.Value)
            {
                strInvoiceNO = objInvoiceNO.ToString();
            }
            if (mes.ShowQ("确定要作废发票号为'" + strInvoiceNO + "'的发票信息吗?") != DialogResult.OK)
                return;
            try
            {
                MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT = new MODELCHARGEINVOICEPRINT();
                MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID = objID.ToString();

                MODELCHARGEINVOICEPRINT.INVOICECANCEL = (cmbInvoiceCancelReason.SelectedIndex + 1).ToString();//冲减作废的状态为1，冲减功能将原因自动识别为1
                MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = strLoginID;
                MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = strLoginName;
                MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME = mes.GetDatetimeNow();
                MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = cmbInvoiceCancelReason.Text;
                if (BLLCHARGEINVOICEPRINT.UpdateCancelStateByID(MODELCHARGEINVOICEPRINT))
                {
                    dgList.CurrentRow.Cells["INVOICECANCEL"].Value = cmbInvoiceCancelReason.Text;
                    mes.Show("作废成功!");
                }
                else
                {
                    mes.Show("作废失败,请重试!");
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }

        private void toolExportToExl_Click_1(object sender, EventArgs e)
        {
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel("自定额发票使用明细表", dgList);
        }

    }
}
