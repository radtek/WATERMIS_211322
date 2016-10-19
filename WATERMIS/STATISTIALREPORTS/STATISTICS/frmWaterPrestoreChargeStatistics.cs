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
    public partial class frmWaterPrestoreChargeStatistics : DockContentEx
    {
        public frmWaterPrestoreChargeStatistics()
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
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();

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
            BindChargeType();
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
        /// <summary>
        /// 绑定收款方式
        /// </summary>
        private void BindChargeType()
        {
            DataTable dt = BLLCHARGETYPE.QUERY(" ");
            DataRow dr = dt.NewRow();
            dr["CHARGETYPENAME"] = "";
            dr["CHARGETYPEID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbChargeType.DataSource = dt;
            cmbChargeType.DisplayMember = "CHARGETYPENAME";
            cmbChargeType.ValueMember = "CHARGETYPEID";
        }

        //存储统计类型
        string strStaticsName = "";
        private void toolSearch_Click(object sender, EventArgs e)
        {
            LoadData();
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
        //        log.Write("收费统计界面:" + ex.ToString(), MsgType.Error);
        //        TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
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
        //        log.Write("收费统计界面:" + ex.ToString(), MsgType.Error);
        //    }
        //}
        private void LoadData()
        {
            try
            {
                string strFilter = "  ";
                if (txtWaterUserNOSearch.Text.Trim() != "")
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim().PadLeft(8, '0') + "'";

                if (txtWaterUserNameSearch.Text.Trim() != "")
                    strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

                if (chkZSH.Checked)
                    strFilter += " AND waterUserTypeId<>'0004'";

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                if (cmbChargeType.SelectedValue != null && cmbChargeType.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGETYPEID='" + cmbChargeType.SelectedValue.ToString() + "'";

                dgList.DataSource = null;

                DataTable dtStastics = BLLPRESTORERUNNINGACCOUNT.GetPrestoreSum(strFilter + strSeniorFilterHidden, cmbType.Text);
                DataTable dtTemp = dtStastics.Copy();
                switch (cmbType.Text)
                {
                    case "收费员":
                        #region 统计信息
                        DataRow dr = dtTemp.Rows.Add();
                        dr["收费员"] = "合计:";
                        dr["单据数量"] = 0;
                        //dr["前期余额"] = 0;
                        dr["实收金额"] = 0;
                        dr["现金收费"] = 0;
                        dr["POS机收费"] = 0;
                        dr["余额增减"] = 0;


                        object objSum = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSum))
                            dr["单据数量"] = Convert.ToInt64(objSum);

                        //objSum = dtTemp.Compute("SUM(前期余额)", "");
                        //if (Information.IsNumeric(objSum))
                        //    dr["前期余额"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSum))
                            dr["实收金额"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(现金收费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["现金收费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(POS机收费)", "");
                        if (Information.IsNumeric(objSum))
                            dr["POS机收费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSum))
                            dr["余额增减"] = Convert.ToDecimal(objSum).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "预存统计(按收费员)";
                        break;
                    case "按用户":
                        #region 统计信息
                        DataRow drWaterUser = dtTemp.Rows.Add();
                        drWaterUser["用户名"] = "合计:";
                        drWaterUser["单据数量"] = 0;
                        //drWaterUser["前期余额"] = 0;
                        drWaterUser["实收金额"] = 0;
                        drWaterUser["现金收费"] = 0;
                        drWaterUser["POS机收费"] = 0;
                        drWaterUser["余额增减"] = 0;


                        object objSumWaterUser = dtTemp.Compute("SUM(单据数量)", "");
                        if (Information.IsNumeric(objSumWaterUser))
                            drWaterUser["单据数量"] = Convert.ToInt64(objSumWaterUser);

                        //objSumWaterUser = dtTemp.Compute("SUM(前期余额)", "");
                        //if (Information.IsNumeric(objSumWaterUser))
                        //    drWaterUser["前期余额"] = Convert.ToDecimal(objSumWaterUser);

                        objSumWaterUser = dtTemp.Compute("SUM(实收金额)", "");
                        if (Information.IsNumeric(objSumWaterUser))
                            drWaterUser["实收金额"] = Convert.ToDecimal(objSumWaterUser);

                        objSum = dtTemp.Compute("SUM(现金收费)", "");
                        if (Information.IsNumeric(objSum))
                            drWaterUser["现金收费"] = Convert.ToDecimal(objSum);

                        objSum = dtTemp.Compute("SUM(POS机收费)", "");
                        if (Information.IsNumeric(objSum))
                            drWaterUser["POS机收费"] = Convert.ToDecimal(objSum);

                        objSumWaterUser = dtTemp.Compute("SUM(余额增减)", "");
                        if (Information.IsNumeric(objSumWaterUser))
                            drWaterUser["余额增减"] = Convert.ToDecimal(objSumWaterUser).ToString("F2");

                        dgList.DataSource = dtTemp;
                        #endregion
                        strStaticsName = "预存统计(按用户)";
                        break;
                }

                if (dgList.Rows.Count > 1)
                {
                    for (int i = 0; i < dgList.Columns.Count; i++)
                    {
                        if (strStaticsName != "预存统计(按用户)")
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
                report1.Load(Application.StartupPath + @"\PRINTModel\预存统计模板\" + strStaticsName + ".frx");
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
                report1.Load(Application.StartupPath + @"\PRINTModel\预存统计模板\" + strStaticsName + ".frx");
           
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
            if (strStaticsName == "预存统计(按收费员)")
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
            frmWaterUserSeniorSearch frm = new frmWaterUserSeniorSearch();
            frm.Owner = this;
            frm.strSign = "2";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }
    }
}
