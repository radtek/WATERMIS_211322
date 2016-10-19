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

namespace STATISTIALREPORTS
{
    public partial class frmWaterFeeCheck : DockContentEx
    {
        public frmWaterFeeCheck()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLDAYCHECKPERSONAL BLLDAYCHECKPERSONAL = new BLLDAYCHECKPERSONAL();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();

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

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart=new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtpEnd.Value = dtMonthEnd;

            //GetExtraFeeName();
            BindChargeWorkerName(cmbChargerWorkName);
            cmbCheckedState.SelectedIndex = 0;

            dgList.AutoGenerateColumns = false;
            dgSSDetail.AutoGenerateColumns = false;
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND IsCashier='1'");
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
        private void toolSearch_Click(object sender, EventArgs e)
        {
            dgList.DataSource = null;
            dtpStartSearch.Value = dtpStart.Value;
            dtpEndSearch.Value = dtpEnd.Value;
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
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                LoadData();

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("实收审核界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("实收审核界面:" + ex.ToString(), MsgType.Error);
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

        /// <summary>
        /// 查询条件
        /// </summary>
        string strFilter = "";
        private void LoadData()
        {
            try
            {
                strFilter = "";

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND DAYCHECKWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND DAYCHECKDATEIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                if (cmbCheckedState.SelectedIndex > 0)
                    if (cmbCheckedState.SelectedIndex == 1)
                        strFilter += " AND CHECKERID IS NULL";
                    else if (cmbCheckedState.SelectedIndex == 2)
                        strFilter += " AND CHECKERID IS NOT NULL";

                dtWaterMeterList = BLLDAYCHECKPERSONAL.Query(strFilter);

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    object obj = dtWaterMeterList.Compute("SUM(DAYCHECKSUMMONEY)", "");
                    if (Information.IsNumeric(obj))
                        labSSMoney.Text = Convert.ToDecimal(obj).ToString("F2");

                    btCheck.Enabled = true;
                    btUnCheck.Enabled = true;
                    dgList.DataSource = dtWaterMeterList;
                }
                else
                {
                    labSSMoney.Text = "0";
                    btUnCheck.Enabled = false;
                    btCheck.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
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

        private void dgList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region 合计行
            //DataRow dr = dtWaterMeterList.NewRow();

            object obj = dtWaterMeterList.Compute("SUM(DAYCHECKSUMMONEY)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["DAYCHECKSUMMONEY"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(DAYCHECKMONEY)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["DAYCHECKMONEY"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(DAYCHECKPOS)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["DAYCHECKPOS"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(DAYCHECKZHUANZHANG)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["DAYCHECKZHUANZHANG"].Value = Convert.ToDecimal(obj);

            obj = dtWaterMeterList.Compute("SUM(RECEIPTNOCOUNT)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["RECEIPTNOCOUNT"].Value = Convert.ToInt32(obj);

            obj = dtWaterMeterList.Compute("SUM(INVOICENOCOUNT)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["INVOICENOCOUNT"].Value = Convert.ToInt32(obj);
            #endregion
        }

        private void dgList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //dgSSDetail.DataSource = null;
            //if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //    return;
            //if (e.RowIndex == dgList.Rows.Count - 1)
            //    return;
            //object objID = dgList.Rows[e.RowIndex].Cells["DAYCHECKID"].Value;
            //if (objID != null && objID != DBNull.Value)
            //{
            //    DataTable dtWaterFee = BLLWATERFEECHARGE.QueryWaterFeeAndPrestoreCharge(" AND DAYCHECKID='" + objID.ToString() + "' ORDER BY CHARGEDATETIME");
            //    dgSSDetail.DataSource = dtWaterFee;
            //}
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count <= 1)
            {
                mes.Show("没有可审核的日结数据!");
                return;
            }
            if (dgList.SelectedRows.Count == 0)
            {
                mes.Show("请选择要审核的日结数据!");
                return;
            }
            try
            {
                for (int i = 0; i < dgList.SelectedRows.Count; i++)
                {
                    object objID = dgList.SelectedRows[i].Cells["DAYCHECKID"].Value;
                    if (objID != null && objID != DBNull.Value)
                    {
                        MODELDAYCHECKPERSONAL MODELDAYCHECKPERSONAL = new MODELDAYCHECKPERSONAL();
                        MODELDAYCHECKPERSONAL.DAYCHECKID = objID.ToString();
                        MODELDAYCHECKPERSONAL.CHECKERID = strLogID;
                        MODELDAYCHECKPERSONAL.CHECKERNAME = strUserName;
                        MODELDAYCHECKPERSONAL.CHECKDATETIME = mes.GetDatetimeNow();
                        if (BLLDAYCHECKPERSONAL.UpdateCheckState(MODELDAYCHECKPERSONAL))
                        {
                            //dgList.SelectedRows[i].Cells["CHECKERID"].Value = strLogID;
                            dgList.SelectedRows[i].Cells["CHECKERNAME"].Value = strUserName;
                            dgList.SelectedRows[i].Cells["CHECKDATETIME"].Value = MODELDAYCHECKPERSONAL.CHECKDATETIME;
                        }
                        else
                        {
                            mes.Show("更新日结单据'" + MODELDAYCHECKPERSONAL.DAYCHECKID + "'的审核状态失败,请重新查询后重试!");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
            }
        }

        private void btUnCheck_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count <= 1)
            {
                mes.Show("没有可反审核的日结数据!");
                return;
            }
            if (dgList.SelectedRows.Count == 0)
            {
                mes.Show("请选择要反审核的日结数据!");
                return;
            }
            try
            {
                for (int i = 0; i < dgList.SelectedRows.Count; i++)
                {
                    object objID = dgList.SelectedRows[i].Cells["DAYCHECKID"].Value;
                    if (objID != null && objID != DBNull.Value)
                    {
                        MODELDAYCHECKPERSONAL MODELDAYCHECKPERSONAL = new MODELDAYCHECKPERSONAL();
                        MODELDAYCHECKPERSONAL.DAYCHECKID = objID.ToString();
                        MODELDAYCHECKPERSONAL.CHECKERID = null;
                        MODELDAYCHECKPERSONAL.CHECKERNAME = null;
                        MODELDAYCHECKPERSONAL.CHECKDATETIME = mes.GetDatetimeNow();
                        if (BLLDAYCHECKPERSONAL.UpdateCheckState(MODELDAYCHECKPERSONAL))
                        {
                            //dgList.SelectedRows[i].Cells["CHECKERID"].Value = strLogID;
                            dgList.SelectedRows[i].Cells["CHECKERNAME"].Value = null;
                            dgList.SelectedRows[i].Cells["CHECKDATETIME"].Value =DBNull.Value;
                        }
                        else
                        {
                            mes.Show("更新日结单据'" + MODELDAYCHECKPERSONAL.DAYCHECKID + "'的审核状态失败,请重新查询后重试!");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
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
