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

namespace WATERFEEMANAGE
{
    public partial class frmWaterFeeDayCheck : DockContentEx
    {
        public frmWaterFeeDayCheck()
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
        public string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";        

        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            ////获取用户ID
            //if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            //    strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            //else
            //{
            //    mes.Show("收费员姓名获取失败!请重新打开该窗体!");
            //    this.Close();
            //}

            ////获取用户姓名
            //if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
            //    strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();


            //object objGroup = AppDomain.CurrentDomain.GetData("GROUPID");
            //if (objGroup != null && objGroup != DBNull.Value)
            //{
            //    //如果非系统管理员，则只能统计自己的收费明细
            //    if (objGroup.ToString() != "0001")
            //    {
            //        cmbChargerWorkName.SelectedValue = strLogID;
            //        cmbChargerWorkName.Enabled = false;
            //    }
            //}

            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart=new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtpEnd.Value = dtMonthEnd;

            //GetExtraFeeName();
            BindChargeWorkerName(cmbChargerWorkName);
            cmbCheckedState.SelectedIndex = 0;

            dgDayCheckList.AutoGenerateColumns = false;
            dgSSDetail.AutoGenerateColumns = false;
            dgUncheck.AutoGenerateColumns = false;

            cmbChargerWorkName.SelectedValue = strLogID;
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
            dgDayCheckList.DataSource = null;
            dgUncheck.DataSource = null;
            dgSSDetail.DataSource = null;
            tabControl1.SelectedIndex = 1;
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
                log.Write("日结界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("日结界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 存储查询已日结的数据
        /// </summary> 
        DataTable dtWaterFeeDayChecked = new DataTable();

        /// <summary>
        /// 存储查询已日结的明细数据
        /// </summary> 
        DataTable dtWaterFeeDayCheckedDetail = new DataTable();

        /// <summary>
        /// 存储查询未日结的数据
        /// </summary> 
        DataTable dtWaterFeeDayUnChecked = new DataTable();

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
                string strFilter = "";
                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                {
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";
                    cmbChargerWorkNameSearch.SelectedValue = cmbChargerWorkName.SelectedValue;
                }

                if (chkChargeDateTime.Checked)
                {
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "' ";
                }

                if (cmbCheckedState.SelectedIndex > 0)
                    if (cmbCheckedState.SelectedIndex == 1)
                        strFilter += " AND DAYCHECKSTATE='0'";
                    else if (cmbCheckedState.SelectedIndex == 2)
                        strFilter += " AND DAYCHECKSTATE='1'";

                dtWaterFeeDayChecked = BLLWATERFEECHARGE.QueryBySQL("SELECT * FROM DAYCHECKPERSONAL WHERE DAYCHECKID IN ("+
                    "SELECT DAYCHECKID FROM V_WATERFEECHARGE_CHARGEINVOICEPRINT WHERE DAYCHECKSTATE='1' "+strFilter+")");
                dgDayCheckList.DataSource = dtWaterFeeDayChecked;

                dtWaterFeeDayUnChecked = BLLWATERFEECHARGE.QueryWaterFeeAndPrestoreCharge(" AND DAYCHECKSTATE='0'"+strFilter);
                dgUncheck.DataSource = dtWaterFeeDayUnChecked;

                if (dtWaterFeeDayUnChecked.Rows.Count > 0)
                {
                    object obj = dtWaterFeeDayUnChecked.Compute("SUM(CHARGEBCSS)", "");
                    if (Information.IsNumeric(obj))
                        labDayUncheckSS.Text = Convert.ToDecimal(obj).ToString("F2");
                }
                else
                {
                    labDayUncheckSS.Text = "0";
                }

                if (dtWaterFeeDayChecked.Rows.Count > 0)
                {
                    btUnCheck.Enabled = true;
                    object obj = dtWaterFeeDayChecked.Compute("SUM(DAYCHECKSUMMONEY)", "");
                    if (Information.IsNumeric(obj))
                        labDaycheckSS.Text = Convert.ToDecimal(obj).ToString("F2");
                }
                else
                {
                    labDaycheckSS.Text = "0";
                    btUnCheck.Enabled = false;
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

            object obj = dtWaterFeeDayChecked.Compute("SUM(DAYCHECKSUMMONEY)", "");
            if (Information.IsNumeric(obj))
                dgDayCheckList.Rows[dgDayCheckList.Rows.Count - 1].Cells["DAYCHECKSUMMONEY"].Value = Convert.ToDecimal(obj);
            #endregion
        }

        private void dgDayCheckList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgSSDetail.DataSource = null;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex == dgDayCheckList.Rows.Count - 1)
                return;
            object objID = dgDayCheckList.Rows[e.RowIndex].Cells["DAYCHECKID"].Value;
            if (objID != null && objID != DBNull.Value)
            {
                dtWaterFeeDayCheckedDetail = BLLWATERFEECHARGE.QueryChargeView(" AND DAYCHECKID='" + objID.ToString() + "' AND CHARGECANCEL='0' AND isnull(INVOICECANCEL,'0')='0' ORDER BY CHARGEDATETIME");
                dgSSDetail.DataSource = dtWaterFeeDayCheckedDetail;
            }
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cmbChargerWorkName.SelectedValue == null || cmbChargerWorkName.SelectedValue == DBNull.Value)
                //{
                //    mes.Show("请选择收款员查询收款数据后再执行日结操作!");
                //    return;
                //}

                //string strFilter = " AND DAYCHECKSTATE<>'1' ";
                //if (txtFilter.Text == "")
                //    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";
                //else
                //    strFilter += txtFilter.Text;

                //DataTable dtDayUnchecked = BLLWATERFEECHARGE.QueryWaterFeeAndPrestoreCharge(strFilter);
                //if (dtDayUnchecked.Rows.Count == 0)
                //{
                //    mes.Show("未找到未日结的收费数据!");
                //    return;
                //}
                //DateTime dtNow = mes.GetDatetimeNow();
                //MODELDAYCHECKPERSONAL MODELDAYCHECKPERSONAL = new MODELDAYCHECKPERSONAL();
                //MODELDAYCHECKPERSONAL.DAYCHECKID = GETTABLEID.GetTableID(strLogID, "DAYCHECKPERSONAL");
                //MODELDAYCHECKPERSONAL.DAYCHECKWORKERID = cmbChargerWorkName.SelectedValue.ToString();
                //MODELDAYCHECKPERSONAL.DAYCHECKWORKERNAME = cmbChargerWorkName.Text;
                //MODELDAYCHECKPERSONAL.DAYCHECKDATEIME = dtNow;
                //MODELDAYCHECKPERSONAL.DAYCHECKSUMMONEY = decBCSS;
                //MODELDAYCHECKPERSONAL.DAYCHECKMONEY = decYSBCSSXJ + decYCBCSZXJ;
                //MODELDAYCHECKPERSONAL.DAYCHECKPOS = decYSBCSSPOS + decYCBCSZPOS;
                //MODELDAYCHECKPERSONAL.DAYCHECKZHUANZHANG = decYSBCSSZHUANZHANG + decYCBCSZZHUANZHANG;
                //MODELDAYCHECKPERSONAL.RECEIPTNOCOUNT = intYSRECEIPRNOCOUNT + intYCCount;
                //MODELDAYCHECKPERSONAL.INVOICENOCOUNT = intYSCount;
                //MODELDAYCHECKPERSONAL.MEMO = null;
                //if (BLLDAYCHECKPERSONAL.Insert(MODELDAYCHECKPERSONAL))
                //{
                //    try
                //    {
                //        MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                //        MODELWATERFEECHARGE.DAYCHECKSTATE = "1";
                //        MODELWATERFEECHARGE.DAYCHECKWORKERNAME = MODELDAYCHECKPERSONAL.DAYCHECKWORKERNAME;
                //        MODELWATERFEECHARGE.DAYCHECKDATETIME = dtNow;
                //        MODELWATERFEECHARGE.DAYCHECKID = MODELDAYCHECKPERSONAL.DAYCHECKID;
                //        int intCount = BLLWATERFEECHARGE.UpdateDayCheckState(MODELWATERFEECHARGE, strFilter);
                //        mes.Show("生成日结报表成功!");
                //    }
                //    catch (Exception ex)
                //    {
                //        mes.Show("更新日结标志失败,原因:" + ex.Message);
                //        log.Write(ex.ToString(), MsgType.Error);
                //        BLLDAYCHECKPERSONAL.Delete(MODELDAYCHECKPERSONAL.DAYCHECKID);
                //    }
                //}
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }

            if (dgDayCheckList.Rows.Count <= 1)
            {
                mes.Show("没有可审核的日结数据!");
                return;
            }
            if (dgDayCheckList.SelectedRows.Count == 0)
            {
                mes.Show("请选择要审核的日结数据!");
                return;
            }
            try
            {
                for (int i = 0; i < dgDayCheckList.SelectedRows.Count; i++)
                {
                    object objID = dgDayCheckList.SelectedRows[i].Cells["DAYCHECKID"].Value;
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
                            dgDayCheckList.SelectedRows[i].Cells["CHECKERNAME"].Value = strUserName;
                            dgDayCheckList.SelectedRows[i].Cells["CHECKDATETIME"].Value = MODELDAYCHECKPERSONAL.CHECKDATETIME;
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
            if (dgDayCheckList.Rows.Count <= 1)
            {
                mes.Show("没有可反日结的日结数据!");
                return;
            }
            if (dgDayCheckList.SelectedRows.Count == 0)
            {
                mes.Show("请选择要反日结的日结数据!");
                return;
            }

            for (int i = 0; i < dgDayCheckList.SelectedRows.Count; i++)
            {
                string strDayCheckID = "";
                object objDayCheckID = dgDayCheckList.SelectedRows[i].Cells["DAYCHECKID"].Value;
                if (objDayCheckID != null && objDayCheckID != DBNull.Value)
                {
                    strDayCheckID = objDayCheckID.ToString();
                }
                object objID = dgDayCheckList.SelectedRows[i].Cells["CHECKERNAME"].Value;

                if (objID != null && objID != DBNull.Value)
                {
                    mes.Show("日结流水号'" + strDayCheckID + "'对应的收费单据已由核算员审核，无法反日结!");
                    return;
                }
            }
            try
            {
                for (int i = dgDayCheckList.SelectedRows.Count-1; i>=0; i--)
                {
                    object objID = dgDayCheckList.SelectedRows[i].Cells["DAYCHECKID"].Value;
                    if (objID != null && objID != DBNull.Value)
                    {
                        MODELDAYCHECKPERSONAL MODELDAYCHECKPERSONAL = new MODELDAYCHECKPERSONAL();
                        MODELDAYCHECKPERSONAL.DAYCHECKID = objID.ToString();
                        if (BLLDAYCHECKPERSONAL.Delete(MODELDAYCHECKPERSONAL.DAYCHECKID))
                        {
                            string strSQLUncheckWaterFee = "UPDATE WATERFEECHARGE SET DAYCHECKWORKERNAME=NULL,DAYCHECKSTATE='0',DAYCHECKDATETIME=NULL,"+
                                "DAYCHECKID=NULL WHERE DAYCHECKID='"+objID.ToString()+"'";
                            try
                            {
                               int intCount= BLLDAYCHECKPERSONAL.Excute(strSQLUncheckWaterFee);
                               if (intCount == 0)
                               {
                                   mes.Show("日结流水号'"+objID.ToString()+"'对应的收费单据反日结失败,请重试!");
                                   return;
                               }
                               dgDayCheckList.Rows.Remove(dgDayCheckList.SelectedRows[i]);
                            }
                            catch (Exception ex)
                            {
                                mes.Show("日结流水号'" + objID.ToString() +"'对应的收费单据反日结失败,原因:\r\n"+ ex.Message);
                                log.Write(ex.ToString(), MsgType.Error);
                            }
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

        private void dgUncheck_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region 合计行
            //DataRow dr = dtWaterMeterList.NewRow();

            object obj = dtWaterFeeDayUnChecked.Compute("SUM(CHARGEBCSS)", "");
            if (Information.IsNumeric(obj))
                dgUncheck.Rows[dgUncheck.Rows.Count - 1].Cells["CHARGEBCSSUNCHECKED"].Value = Convert.ToDecimal(obj);
            #endregion
        }

        private void dgSSDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region 合计行
            //DataRow dr = dtWaterMeterList.NewRow();

            object obj = dtWaterFeeDayCheckedDetail.Compute("SUM(CHARGEBCSS)", "");
            if (Information.IsNumeric(obj))
                dgSSDetail.Rows[dgSSDetail.Rows.Count - 1].Cells["CHARGEBCSS"].Value = Convert.ToDecimal(obj);
            #endregion
        }

        private void dgSSDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if(dgSSDetail.Columns[e.ColumnIndex].Name=="DAYCHECKSTATE")
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if (e.Value.ToString() == "1")
                        e.Value = "已日结";
                    else if (e.Value.ToString() == "0")
                        e.Value = "未日结";
                }
        }
    }
}
