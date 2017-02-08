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
    public partial class frmSalaryStatics : DockContentEx
    {
        public frmSalaryStatics()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLACCOUNTSRUNNING BLLACCOUNTSRUNNING = new BLLACCOUNTSRUNNING();

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

            BindAreaNO(cmbAreaNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
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
        private void BindCommunity(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
            {
                dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000' ORDER BY  COMMUNITYNAME");
                DataRow dr = dt.NewRow();
                dr["COMMUNITYNAME"] = "全部小区";
                dr["COMMUNITYID"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
            }
            else
                dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000' ORDER BY COMMUNITYNAME");
            cmb.DataSource = dt;
            cmb.DisplayMember = "COMMUNITYNAME";
            cmb.ValueMember = "COMMUNITYID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader(ComboBox cmb, string strType)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'  ORDER BY USERNAME");
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
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindCharger(ComboBox cmb)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1' ");
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
                log.Write("实收统计界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("实收统计界面:" + ex.ToString(), MsgType.Error);
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
        private void LoadData()
        {
            try
            {
                string strFilter = "";
                string strStatisticsContent = "", strStatisticsGroupBy = "";

                if (cmbAreaNOS.SelectedIndex > 0)
                    strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";

                if (cmbDuanNOS.SelectedIndex > 0)
                    strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

                if (cmbCommunityS.SelectedIndex > 0)
                    strFilter += " AND communityID='" + cmbCommunityS.SelectedValue.ToString() + "'";

                if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                    strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

                if (chkChargeDateTime.Checked)
                    strFilter += " AND readMeterRecordYearAndMonth BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

                if (chkAreaNO.Checked)
                {
                    strStatisticsContent = "areaNO AS 区号";
                    strStatisticsGroupBy = "areaNO";
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

                if (chkCommunity.Checked)
                {
                    if (strStatisticsContent != "")
                    {
                        strStatisticsContent += ",communityID AS 小区编号,COMMUNITYNAME AS 小区名称";
                        strStatisticsGroupBy += ",communityID,COMMUNITYNAME";
                    }
                    else
                    {
                        strStatisticsContent = "communityID AS 小区编号,COMMUNITYNAME AS 小区名称";
                        strStatisticsGroupBy = "communityID,COMMUNITYNAME";
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
                    //strStatisticsGroupBy = " GROUP BY " + strStatisticsGroupBy;
                    strStatisticsGroupBy = " GROUP BY " + strStatisticsGroupBy + " ORDER BY " + strStatisticsGroupBy;
                    strStatisticsContent = "SELECT " + strStatisticsContent +
                        ",2 AS 周期,COUNT(DISTINCT waterUserId) AS 户数,0 AS 零用水户数,0 AS 用水户数,0.0 AS 查表率," +
                        "SUM(totalNumber) AS 用水量,SUM(totalCharge) AS 金额,0.0 AS 完成系数,0.0 AS [完成系数/月]," +
                        "0.0 AS [用水/户/吨],0.0 AS [超阶梯/月],0.0 AS [0.85超阶梯/月],0.0 AS [0.90超阶梯/月],0 AS 挑出户,0 AS 计划件数,0.0 AS 应收金额 " +
                        "FROM (SELECT * FROM readMeterRecord WHERE WATERMETERNUMBERCHANGESTATE='0' " + strFilter + ") AS AA";
                    strStatisticsContent = strStatisticsContent + strStatisticsGroupBy;
                }
                else
                {
                    strStatisticsContent = "SELECT " + "2 AS 周期,COUNT(DISTINCT waterUserId) AS 户数,0 AS 零用水户数,0 AS 用水户数,0.0 AS 查表率," +
                        "SUM(totalNumber) AS 用水量,SUM(totalCharge) AS 金额,0.0 AS 完成系数,0.0 AS [完成系数/月]," +
                        "0.0 AS [用水/户/吨],0.0 AS [超阶梯/月],0.0 AS [0.85超阶梯/月],0.0 AS [0.90超阶梯/月],0 AS 挑出户,0 AS 计划件数,0.0 AS 应收金额 " +
                        "FROM (SELECT * FROM readMeterRecord WHERE WATERMETERNUMBERCHANGESTATE='0' " + strFilter + ") AS AA";
                }

                    dtWaterMeterList = BLLWATERFEECHARGE.QueryBySQL(strStatisticsContent);
                    #region 填充用户余额
                    for (int j = 0; j < dtWaterMeterList.Rows.Count; j++)
                {
                    string strFilterTJ = "";
                    for (int i = 0; i < dtWaterMeterList.Columns.Count; i++)
                    {
                        if (dtWaterMeterList.Columns[i].ColumnName == "区号")
                        {
                            object obj = dtWaterMeterList.Rows[j][i];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strFilterTJ += " AND areaNO='" + obj.ToString() + "' ";
                            }
                            continue;
                        }
                        if (dtWaterMeterList.Columns[i].ColumnName == "段号")
                        {
                            object obj = dtWaterMeterList.Rows[j][i];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strFilterTJ += " AND duanNO='" + obj.ToString() + "' ";
                            }
                            continue;
                        }
                        if (dtWaterMeterList.Columns[i].ColumnName == "水费月份")
                        {
                            object obj = dtWaterMeterList.Rows[j][i];
                            if (obj != null && obj != DBNull.Value)
                            {
                                if (Information.IsDate(obj.ToString() + "-01"))
                                {
                                    strFilterTJ += " AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + obj.ToString() + "')=0";
                                }
                            }
                            continue;
                        }
                        if (dtWaterMeterList.Columns[i].ColumnName == "小区编号")
                        {
                            object obj = dtWaterMeterList.Rows[j][i];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strFilterTJ += " AND communityID='" + obj.ToString() + "' ";
                            }
                            continue;
                        }
                        if (dtWaterMeterList.Columns[i].ColumnName == "抄表员编号")
                        {
                            object obj = dtWaterMeterList.Rows[j][i];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strFilterTJ += " AND meterReaderID='" + obj.ToString() + "' ";
                            }
                            continue;
                        }
                        if (dtWaterMeterList.Columns[i].ColumnName == "用户类别编号")
                        {
                            object obj = dtWaterMeterList.Rows[j][i];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strFilterTJ += " AND WATERUSERTYPEID='" + obj.ToString() + "' ";
                            }
                            continue;
                        }
                        if (dtWaterMeterList.Columns[i].ColumnName == "用水性质分类")
                        {
                            object obj = dtWaterMeterList.Rows[j][i];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strFilterTJ += " AND WATERMETERTYPECLASSNAME='" + obj.ToString() + "' ";
                            }
                            continue;
                        }
                        if (dtWaterMeterList.Columns[i].ColumnName == "用水性质编号")
                        {
                            object obj = dtWaterMeterList.Rows[j][i];
                            if (obj != null && obj != DBNull.Value)
                            {
                                strFilterTJ += " AND WATERMETERTYPEID='" + obj.ToString() + "' ";
                            }
                            continue;
                        }
                    }
                    int intYSHS = 0,intHSSum=0;
                        //获取用水户数
                    string strGetYSHS = "SELECT COUNT(DISTINCT WATERUSERID) AS 用水户数 FROM readMeterRecord WHERE totalNumber>0 " + strFilterTJ + strFilter;
                    DataTable dtYSHS = BLLWATERFEECHARGE.QueryBySQL(strGetYSHS);
                    if (dtYSHS.Rows.Count > 0)
                    {
                        object obj = dtYSHS.Rows[0]["用水户数"];
                        if (Information.IsNumeric(obj))
                            intYSHS = Convert.ToInt32(obj);

                        dtWaterMeterList.Rows[j]["用水户数"] = intYSHS;
                    }
                    object objHS = dtWaterMeterList.Rows[j]["户数"];
                    if (Information.IsNumeric(objHS))
                        intHSSum = Convert.ToInt32(objHS);

                    dtWaterMeterList.Rows[j]["零用水户数"] = intHSSum - intYSHS;
                    if (intHSSum == 0)
                        continue;
                    dtWaterMeterList.Rows[j]["查表率"] = (intYSHS /(intHSSum * 1.0)).ToString("F2");

                    decimal decJE = 0;
                    object objJE = dtWaterMeterList.Rows[j]["金额"];
                    if (Information.IsNumeric(objJE))
                        decJE = Convert.ToDecimal(objJE);

                    if (intYSHS == 0)
                        continue;

                    dtWaterMeterList.Rows[j]["完成系数"] = (decJE / intYSHS).ToString("F2");
                    dtWaterMeterList.Rows[j]["完成系数/月"] = (decJE / (intYSHS*2)).ToString("F2");

                    int intYSL = 0;
                    object objYSL = dtWaterMeterList.Rows[j]["用水量"];
                    if (Information.IsNumeric(objYSL))
                        intYSL = Convert.ToInt32(objYSL);

                    dtWaterMeterList.Rows[j]["用水/户/吨"] = (intYSL / (intYSHS * 2.0)).ToString("F2");
                    dtWaterMeterList.Rows[j]["超阶梯/月"] = (((double)decJE - intYSL * 2.25) / 2.0).ToString("F2");
                    dtWaterMeterList.Rows[j]["0.85超阶梯/月"] = (0.85*((double)decJE - intYSL * 2.25) / 2.0).ToString("F2");
                    dtWaterMeterList.Rows[j]["0.90超阶梯/月"] = (0.9 * ((double)decJE - intYSL * 2.25) / 2.0).ToString("F2");
                    dtWaterMeterList.Rows[j]["计划件数"] = dtWaterMeterList.Rows[j]["户数"];

                    int intJHJS = 0;
                    object objJHJS = dtWaterMeterList.Rows[j]["计划件数"];
                    if (Information.IsNumeric(objJHJS))
                        intJHJS = Convert.ToInt32(objJHJS);

                   decimal decYSPerUser = 0;
                    object objYSPerUser = dtWaterMeterList.Rows[j]["用水/户/吨"];
                    if (Information.IsNumeric(objYSPerUser))
                        decYSPerUser = Convert.ToDecimal(objYSPerUser);

                    dtWaterMeterList.Rows[j]["应收金额"] = ((intJHJS * (double)decYSPerUser * 2.25 + (0.9 * ((double)decJE - intYSL * 2.25) / 2.0)) * 2).ToString("F2");
                }
                    #endregion

                    dgList.DataSource = dtWaterMeterList;
                    for (int i = 0; i < dgList.Columns.Count;i++ )
                        dgList.Columns[i].ReadOnly=true;

                    dgList.Columns["周期"].ReadOnly = false;
                    dgList.Columns["周期"].DefaultCellStyle.BackColor = Color.Yellow;
                    dgList.Columns["挑出户"].ReadOnly = false;
                    dgList.Columns["挑出户"].DefaultCellStyle.BackColor = Color.Yellow;

                    dgList.Rows[dgList.Rows.Count - 1].Cells["周期"].ReadOnly = true;
                    dgList.Rows[dgList.Rows.Count - 1].Cells["挑出户"].ReadOnly = true;

                        if (chkRecordMonth.Checked)
                            dgList.Columns["水费月份"].DefaultCellStyle.Format = "yyyy-MM";

                if (dtWaterMeterList.Rows.Count > 0)
                {
                    toolExcel.Enabled = true;
                }
                else
                {
                    toolExcel.Enabled = false;
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

            if (dgList.Rows.Count > 1)
            {
                object obj = dtWaterMeterList.Compute("SUM(户数)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["户数"].Value = Convert.ToInt32(obj);

                obj = dtWaterMeterList.Compute("SUM(用水户数)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["用水户数"].Value = Convert.ToInt32(obj);

                obj = dtWaterMeterList.Compute("SUM(零用水户数)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["零用水户数"].Value = Convert.ToInt32(obj);

                obj = dtWaterMeterList.Compute("SUM(用水量)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["用水量"].Value = Convert.ToInt32(obj);

                obj = dtWaterMeterList.Compute("SUM(金额)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["金额"].Value = Convert.ToDecimal(obj);

                obj = dtWaterMeterList.Compute("SUM(完成系数)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["完成系数"].Value = (Convert.ToDecimal(obj) / (dgList.Rows.Count - 1)).ToString("F2");

                obj = dtWaterMeterList.Compute("SUM([完成系数/月])", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["完成系数/月"].Value =(Convert.ToDecimal(obj) / (dgList.Rows.Count - 1)).ToString("F2");

                obj = dtWaterMeterList.Compute("SUM([用水/户/吨])", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["用水/户/吨"].Value = (Convert.ToDecimal(obj) / (dgList.Rows.Count - 1)).ToString("F2");

                obj = dtWaterMeterList.Compute("SUM([超阶梯/月])", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["超阶梯/月"].Value = (Convert.ToDecimal(obj) / (dgList.Rows.Count - 1)).ToString("F2");

                obj = dtWaterMeterList.Compute("SUM([0.85超阶梯/月])", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["0.85超阶梯/月"].Value = (Convert.ToDecimal(obj) / (dgList.Rows.Count - 1)).ToString("F2");

                obj = dtWaterMeterList.Compute("SUM([0.90超阶梯/月])", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["0.90超阶梯/月"].Value = (Convert.ToDecimal(obj) / (dgList.Rows.Count - 1)).ToString("F2");

                obj = dtWaterMeterList.Compute("SUM(挑出户)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["挑出户"].Value = Convert.ToInt32(obj);

                obj = dtWaterMeterList.Compute("SUM(计划件数)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["计划件数"].Value = Convert.ToInt32(obj);

                obj = dtWaterMeterList.Compute("SUM(查表率)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["查表率"].Value = (Convert.ToDecimal(obj) / (dgList.Rows.Count - 1)).ToString("F2");

                obj = dtWaterMeterList.Compute("SUM(应收金额)", "");
                if (Information.IsNumeric(obj))
                    dgList.Rows[dgList.Rows.Count - 1].Cells["应收金额"].Value = Convert.ToDecimal(obj).ToString("F2");


                dgList.Rows[dgList.Rows.Count - 1].Cells["周期"].ReadOnly = true;
                dgList.Rows[dgList.Rows.Count - 1].Cells["挑出户"].ReadOnly = true;
            }
            #endregion
        }

        private void toolExcel_Click(object sender, EventArgs e)
        {
            string strCaption = "";
            if (GetMonth(dtpStartSearch.Value, dtpEndSearch.Value) > 1)
            {
                strCaption = dtpStartSearch.Value.Month + "-" + dtpEndSearch.Value.Month + "月份工资统计表";
            }
            else
                strCaption = dtpEndSearch.Value.Month + "月份工资统计表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
        }

        private void toolUpdateAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetMonth(dtpStartSearch.Value, dtpEndSearch.Value) > 1)
                {
                    mes.Show("预收账款的更新只能为某月份!");
                    return;
                }
                decimal decSum = 0;//本期应收账款
                //object objSum = dgList.Rows[dgList.Rows.Count - 1].Cells["应收总计"].Value;
                object objSum = dgList.Rows[dgList.Rows.Count - 1].Cells["应收小计"].Value;
                if (Information.IsNumeric(objSum))
                    decSum = Convert.ToDecimal(objSum);

                //上期营业应收账款用户余额,上期财务应收账款用户余额
                decimal decBusinessMoney = 0, decFinanceMoney = 0;
                DataTable dtAccount = BLLACCOUNTSRUNNING.Query(" AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpStartSearch.Value.AddMonths(-1) + "')=0");
                if (dtAccount.Rows.Count > 0)
                {
                    object objMoney = dtAccount.Rows[0]["BUSINESSMONEY"];
                    if (Information.IsNumeric(objMoney))
                    {
                        decBusinessMoney = Convert.ToDecimal(objMoney);
                    }
                    objMoney = dtAccount.Rows[0]["FINANCEMONEY"];
                    if (Information.IsNumeric(objMoney))
                    {
                        decFinanceMoney = Convert.ToDecimal(objMoney);
                    }
                }

                if (mes.ShowQ("确定要更新或生成 '" + dtpEndSearch.Value.ToString("yyyy-MM") + "' 月份的预收账款信息吗?\r\n点击确定将更新以下信息:\r\n" +
                    "上期("+dtpStartSearch.Value.AddMonths(-1).ToString("yyyy-MM")+")预收账款用户余额（营业）:"+decBusinessMoney.ToString("F2")+"\r\n"+
                    "上期(" + dtpStartSearch.Value.AddMonths(-1).ToString("yyyy-MM") + ")预收账款用户余额（财会）:" + decFinanceMoney.ToString("F2") + "\r\n" +
                     dtpStartSearch.Value.Month + "-" + dtpEndSearch.Value.Month + "月份实际应收金额:" + decSum.ToString("F2")) == DialogResult.OK)
                {
                    DataTable dt = BLLACCOUNTSRUNNING.Query(" AND DATEDIFF(MONTH,ACCOUNTSYEARANDMONTH,'" + dtpEndSearch.Value + "')=0");
                    if (dt.Rows.Count > 0)
                    {
                        object objID = dt.Rows[0]["ACCOUNTSID"];
                        if (objID != null && objID != DBNull.Value)
                        {
                            string strSQLUpdate = "UPDATE ACCOUNTSRUNNING SET BUSINESSMONEYLAST=" + decBusinessMoney + ",FINANCEMONEYLAST=" + decFinanceMoney +
                                ",YSMONEY=" + decSum + ",ACCOUNTSDATETIME='"+mes.GetDatetimeNow()+"',OPERATORID='"+strLogID+"',OPERATORNAME='"+strUserName+
                                "' WHERE ACCOUNTSID=" + objID.ToString();
                            if (BLLACCOUNTSRUNNING.ExcuteSQL(strSQLUpdate) > 0)
                            {
                                mes.Show("预收账款更新成功!");
                            }
                            else
                                mes.Show("预收账款更新失败,请重试!");
                        }
                    }
                    else
                    {
                        string strInsertSQL = "INSERT INTO ACCOUNTSRUNNING(ACCOUNTSYEARANDMONTH,BUSINESSMONEYLAST,FINANCEMONEYLAST,YSMONEY,ACCOUNTSDATETIME,OPERATORID,OPERATORNAME) "+
                            "VALUES('" + dtpEndSearch.Value.ToString("yyyy-MM-dd") + "'," + decBusinessMoney + "," + decFinanceMoney + "," + 
                            decSum + ",'" + mes.GetDatetimeNow() + "','" + strLogID + "','"+strUserName+"')";
                        if (BLLACCOUNTSRUNNING.ExcuteSQL(strInsertSQL) > 0)
                        {
                            mes.Show("预收账款生成成功!");
                        }
                        else
                            mes.Show("预收账款生成失败,请重试!");
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show("更新预收账款失败,原因:" + ex.Message);
                log.Write("更新预收账款失败,原因:"+ex.ToString(),MsgType.Error);
            }
        }
        public int GetMonth(DateTime dtSart,DateTime dtEnd)
        {
            int Month = 0;
            if ((dtEnd.Year - dtSart.Year) == 0)
            {
                Month = dtEnd.Month - dtSart.Month;
            }
            if ((dtEnd.Year - dtSart.Year) >= 1)
            {
                if (dtEnd.Month - dtSart.Month < 0)
                {
                    Month = (dtEnd.Year - dtSart.Year - 1) * 12 + (12 - dtSart.Month) + dtEnd.Month + 1;
                }
                else
                {
                    Month = (dtEnd.Year - dtSart.Year) * 12 + dtEnd.Month - dtSart.Month + 1;
                }
            }
            return Month;
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

        private void dgList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "周期")
            {
                object obj = dgList.Rows[e.RowIndex].Cells["周期"].Value;
                if (Information.IsNumeric(obj))
                {
                    decimal decWCXS = 0;
                    int intPeriod = Convert.ToInt32(obj);

                    obj = dgList.Rows[e.RowIndex].Cells["完成系数"].Value;
                    if (Information.IsNumeric(obj) && Convert.ToDecimal(obj) > 0)
                    {
                        decWCXS = Convert.ToDecimal(obj);
                        dgList.Rows[e.RowIndex].Cells["完成系数/月"].Value = (decWCXS / intPeriod).ToString("F2");
                    }

                    int intYSL = 0, intYSHS = 0;

                    obj = dgList.Rows[e.RowIndex].Cells["用水量"].Value;
                    if (Information.IsNumeric(obj) && Convert.ToInt32(obj) > 0)
                        intYSL = Convert.ToInt32(obj);

                    obj = dgList.Rows[e.RowIndex].Cells["用水户数"].Value;
                    if (Information.IsNumeric(obj) && Convert.ToInt32(obj) > 0)
                        intYSHS = Convert.ToInt32(obj);

                    if (intYSHS > 0 && intPeriod > 0)
                        dgList.Rows[e.RowIndex].Cells["用水/户/吨"].Value = (intYSL / (intYSHS * intPeriod * 1.0)).ToString("F2");

                    decimal decJE = 0;

                    obj = dgList.Rows[e.RowIndex].Cells["金额"].Value;
                    if (Information.IsNumeric(obj) && Convert.ToInt32(obj) > 0)
                        decJE = Convert.ToDecimal(obj);

                    if (intPeriod > 0)
                    {
                        dgList.Rows[e.RowIndex].Cells["超阶梯/月"].Value = (((double)decJE - intYSL * 2.25) / intPeriod).ToString("F2");
                        dgList.Rows[e.RowIndex].Cells["0.85超阶梯/月"].Value = (((double)decJE - intYSL * 2.25) * 0.85 / intPeriod).ToString("F2");
                        dgList.Rows[e.RowIndex].Cells["0.90超阶梯/月"].Value = (((double)decJE - intYSL * 2.25) * 0.9 / intPeriod).ToString("F2");
                    }
                    dgList_DataBindingComplete(null, null);
                }
            }
           else if (dgList.Columns[e.ColumnIndex].Name == "挑出户")
            {
                object obj = dgList.Rows[e.RowIndex].Cells["挑出户"].Value;
                if (Information.IsNumeric(obj))
                {
                    int intTCH = Convert.ToInt32(obj);
                    int intHS = 0;

                    obj = dgList.Rows[e.RowIndex].Cells["户数"].Value;
                    if (Information.IsNumeric(obj))
                    {
                        intHS = Convert.ToInt32(obj);
                        dgList.Rows[e.RowIndex].Cells["计划件数"].Value = intHS - intTCH;
                    }

                    decimal decYSLPerUser = 0;

                    obj = dgList.Rows[e.RowIndex].Cells["用水/户/吨"].Value;
                    if (Information.IsNumeric(obj))
                    {
                        decYSLPerUser = Convert.ToDecimal(obj);
                    }

                    decimal decCJT90 = 0;

                    obj = dgList.Rows[e.RowIndex].Cells["0.90超阶梯/月"].Value;
                    if (Information.IsNumeric(obj))
                    {
                        decCJT90 = Convert.ToDecimal(obj);
                    }

                    int intPeriod = 0;
                    obj = dgList.Rows[e.RowIndex].Cells["周期"].Value;
                    if (Information.IsNumeric(obj))
                    {
                        intPeriod = Convert.ToInt32(obj);
                    }
                    dgList.Rows[e.RowIndex].Cells["应收金额"].Value = (((intHS - intTCH) * (double)decYSLPerUser * 2.25 + (double)decCJT90) * intPeriod).ToString("F2");
                    dgList_DataBindingComplete(null, null);
                }
            }
        }
        
        public DataGridViewTextBoxEditingControl CellEdit = null;
        private void dgList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int intColumnIndex = this.dgList.CurrentCellAddress.X;
            if (dgList.Columns[intColumnIndex].Name == "周期" ||dgList.Columns[intColumnIndex].Name == "挑出户")
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress; //绑定事件
            }
        }

        private void Cells_KeyPress(object sender, KeyPressEventArgs e) //自定义事件
        {
            int intColumnIndex = this.dgList.CurrentCellAddress.X;
            if (dgList.Columns[intColumnIndex].Name == "周期" ||
                dgList.Columns[intColumnIndex].Name == "挑出户")
            {
                //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
