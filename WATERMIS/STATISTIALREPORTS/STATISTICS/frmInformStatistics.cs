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
    public partial class frmInformStatistics : DockContentEx
    {
        public frmInformStatistics()
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
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";
        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            BindChargeWorkerName();

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员编号获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            object objGroup = AppDomain.CurrentDomain.GetData("GROUPID");
            if (objGroup != null && objGroup != DBNull.Value)
            {
                //如果非系统管理员，则只能统计自己的收费明细
                if (objGroup.ToString() != "0001")
                {
                    cmbChargerWorkName.SelectedValue = strLogID;
                    cmbChargerWorkName.Enabled = false;
                }
            }

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                //禁止列排序
                dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            cmbType.SelectedIndex = 0;

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);
            cmbType.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "全部";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbChargerWorkName.DataSource = dt;
            cmbChargerWorkName.DisplayMember = "USERNAME";
            cmbChargerWorkName.ValueMember = "LOGINID";
        }

        /// <summary>
        /// 绑定托收银行
        /// </summary>
        /// <param name="cmb"></param>
        private void BindBank(ComboBox cmb)
        {
            DataTable dt = BLLBASE_BANK.Query("");
            DataRow dr = dt.NewRow();
            dr["bankName"] = "全部";
            dr["bankId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "bankName";
            cmb.ValueMember = "bankId";
        }

        //存储统计类型
        string strStaticsName = "";
        private void toolSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string strFilter = "  ";
                if (txtWaterUserNOSearch.Text.Trim() != "")
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim().PadLeft(8, '0') + "'";

                if (txtWaterUserNameSearch.Text.Trim() != "")
                    strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND PRINTWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND INFORMPRINTDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                if (cmbQFState.SelectedIndex>0)
                    if(cmbQFState.SelectedIndex==1)
                        strFilter += " AND WATERUSERJSYE<0";
                    else if (cmbQFState.SelectedIndex == 2)
                        strFilter += " AND WATERUSERJSYE>=0";

                dgList.DataSource = null;

                DataTable dtStastics = BLLreadMeterRecord.StaticsInform(strFilter + strSeniorFilterHidden, cmbType.Text);
                DataTable dtTemp = dtStastics.Copy();
                switch (cmbType.Text)
                {
                    case "按抄表员":
                        #region 统计信息
                        DataRow dr = dtTemp.Rows.Add();
                        dr["抄表员"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["用水量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收水费"] = 0;                        

                        object objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收水费"] = Convert.ToDecimal(objSum);

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "通知单统计(按抄表员)";
                        break;
                    case "按结算员":
                        #region 统计信息
                         dr = dtTemp.Rows.Add();
                        dr["结算员"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["用水量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收水费"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收水费"] = Convert.ToDecimal(objSum);

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "通知单统计(按结算员)";
                        break;
                    case "按抄表本":
                        #region 统计信息
                        dr = dtTemp.Rows.Add();
                        dr["抄表本"] = "合计:";
                        dr["单据数量"] = 0;
                        dr["用水量"] = 0;
                        dr["水费"] = 0;
                        dr["污水处理费"] = 0;
                        dr["附加费"] = 0;
                        dr["应收水费"] = 0;


                        objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        objSum = dtTemp.Compute("SUM(用水量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["用水量"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["水费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(污水处理费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["污水处理费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(附加费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["附加费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(应收水费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["应收水费"] = Convert.ToDecimal(objSum);

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "通知单统计(按抄表本)";
                        break;
                }

                if (dgList.Rows.Count > 1)
                {
                    for (int i = 0; i < dgList.Columns.Count; i++)
                    {
                        //禁止列排序
                        dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dgList.Columns[i].DefaultCellStyle.Format = "0.##";
                    }
                    toolPrint.Enabled = true;
                    toolPrintPreview.Enabled = true;
                }
                else
                {
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
            if (dgList.Rows.Count == 0)
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            DataTable dt = GetDgvToTable(dgList);
            //(DataTable)dgList.DataSource;
            DataTable dtPrint = dt.Copy();
            dtPrint.TableName =strStaticsName;
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\" + strStaticsName + ".frx");
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

            //DataTable dt = (DataTable)dgList.DataSource;
            DataTable dt = GetDgvToTable(dgList);
            DataTable dtPrint = dt.Copy();
            dtPrint.TableName = strStaticsName;
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\" + strStaticsName + ".frx");
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
        }/// <summary>
        /// 方法实现把dgv里的数据完整的复制到一张内存表
        /// </summary>
        /// <param name="dgv">dgv控件作为参数</param>
        /// <returns>返回临时内存表</returns>
        public  DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            int intCount = dgv.Rows.Count;
            if (strStaticsName == "通知单统计(按抄表员)" || strStaticsName == "通知单统计(按结算员)")
                intCount = intCount - 1;
            for (int count = 0; count < intCount; count++)
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

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "14";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }
    }
}
