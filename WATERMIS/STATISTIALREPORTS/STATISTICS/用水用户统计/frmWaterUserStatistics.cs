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
    public partial class frmWaterUserStatistics : DockContentEx
    {
        public frmWaterUserStatistics()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();

        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\",LogType.Daily);        

        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            BindMeterReader(cmbMeterReader);
            BindWaterMeterType(cmbWaterMeterType);

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
        }
        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType(ComboBox cmb)
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "全部"; ;
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterMeterTypeValue";
            cmb.ValueMember = "waterMeterTypeId";
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

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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

            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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
                log.Write("用水用户统计界面:" + ex.ToString(), MsgType.Error);
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
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
                log.Write("用水用户统计界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 存储查询条件
        /// </summary>
        string strFilter = "";

        /// <summary>
        /// 存储查询到的用户列表
        /// </summary>
        DataTable dtList = new DataTable();
        private void LoadData()
        {
            string strStatisticsContent = "", strStatisticsGroupBy = "";
            strFilter = strSeniorFilterHidden;

            if (cmbMeterReader.SelectedValue != null && cmbMeterReader.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderID='" + cmbMeterReader.SelectedValue.ToString() + "'";

            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
            if (cmbPianNOS.SelectedIndex > 0)
                strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

            if (chkDateTime.Checked)
                strFilter += " AND waterUserCreateDate BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";

            if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

            if (cmbState.SelectedIndex > 0)
                strFilter += " AND waterMeterState='" + cmbState.SelectedIndex + "'";

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

            if (chkCreateDate.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",CONVERT(DATE,waterUserCreateDate,101) AS 建档日期";
                    strStatisticsGroupBy += ",CONVERT(DATE,waterUserCreateDate,101)";
                }
                else
                {
                    strStatisticsContent = "CONVERT(DATE,waterUserCreateDate,101) AS 建档日期";
                    strStatisticsGroupBy = "CONVERT(DATE,waterUserCreateDate,101)";
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
                    strStatisticsContent += ",WATERMETERTYPEID AS 用水性质编号,waterMeterTypeValue AS 用水性质名称";
                    strStatisticsGroupBy += ",WATERMETERTYPEID,waterMeterTypeValue";
                }
                else
                {
                    strStatisticsContent = "WATERMETERTYPEID AS 用水性质编号,waterMeterTypeValue AS 用水性质名称";
                    strStatisticsGroupBy = "WATERMETERTYPEID,waterMeterTypeValue";
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

            if (chkWaterMeterState.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",waterMeterStateS AS 水表状态";
                    strStatisticsGroupBy += ",waterMeterStateS";
                }
                else
                {
                    strStatisticsContent = "waterMeterStateS AS 水表状态";
                    strStatisticsGroupBy = "waterMeterStateS";
                }
            }

            if (chkWaterMeterPosition.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",waterMeterPositionName AS 水表位置";
                    strStatisticsGroupBy += ",waterMeterPositionName";
                }
                else
                {
                    strStatisticsContent = "waterMeterPositionName AS 水表位置";
                    strStatisticsGroupBy = "waterMeterPositionName";
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

            if (chkIsReserve.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",IsReverse AS 倒装标志";
                    strStatisticsGroupBy += ",IsReverse";
                }
                else
                {
                    strStatisticsContent = "IsReverse AS 倒装标志";
                    strStatisticsGroupBy = "IsReverse";
                }
            }

            if (chkSumAndSubMeterState.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",isSummaryMeterS AS 总分表";
                    strStatisticsGroupBy += ",isSummaryMeterS";
                }
                else
                {
                    strStatisticsContent = "isSummaryMeterS AS 总分表";
                    strStatisticsGroupBy = "isSummaryMeterS";
                }
            }

            if (chkSumAndSubMeter.Checked)
            {
                if (strStatisticsContent != "")
                {
                    strStatisticsContent += ",waterMeterParentId AS 总表编号,waterMeterParentName AS 总表名称";
                    strStatisticsGroupBy += ",waterMeterParentId,waterMeterParentName";
                }
                else
                {
                    strStatisticsContent += "waterMeterParentId AS 总表编号,waterMeterParentName AS 总表名称";
                    strStatisticsGroupBy += "waterMeterParentId,waterMeterParentName";
                }
            }

            if (strStatisticsContent != "")
            {
                string strOrderby = " ORDER BY " + strStatisticsGroupBy;
                strStatisticsGroupBy = " GROUP BY " + strStatisticsGroupBy;
                strStatisticsContent = "SELECT " + strStatisticsContent +
                    ",COUNT(*) AS 用户数 " +
                    "FROM (SELECT * FROM dbo.V_WATERUSER_CONNECTWATERMETER WHERE 1=1 " + strFilter + ") AS AA";
                strStatisticsContent = strStatisticsContent + strStatisticsGroupBy + strOrderby;
            }
            else
            {
                strStatisticsContent = "SELECT COUNT(*) AS 用户数 "+
                    "FROM (SELECT * FROM V_WATERUSER_CONNECTWATERMETER WHERE 1=1 " + strFilter + ") AS AA";
            }

            dtList = BLLwaterUser.QuerySQL(strStatisticsContent);
            dgList.DataSource = dtList;

            if (dgList.Rows.Count > 0)
            {
                toolExcel.Enabled = true;
            }
            else
            {
                toolExcel.Enabled = false;
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


        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmWaterUserSeniorSearch frm = new frmWaterUserSeniorSearch();
            frm.Owner = this;
            frm.strSign = "1";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }

        private void dgList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            object obj = dtList.Compute("SUM(用户数)", "");
            if (Information.IsNumeric(obj))
                dgList.Rows[dgList.Rows.Count - 1].Cells["用户数"].Value = Convert.ToInt32(obj); 
        }

        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex == dgList.Rows.Count - 1)
                return;
            string strFilterTJ = "";
            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                if (dgList.Columns[i].Name == "片号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND pianNO='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "区号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND areaNO='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "段号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND duanNO='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "建档日期")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (Information.IsDate(obj))
                    {
                        strFilterTJ += " AND DATEDIFF(DAY,waterUserCreateDate,'"+obj.ToString()+"')=0";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "收费员编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND chargerID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "抄表员编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND meterReaderID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "用户类别编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND WATERUSERTYPEID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "用水性质分类")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND WATERMETERTYPECLASSNAME='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "用水性质编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND WATERMETERTYPEID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "水表状态")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND waterMeterStateS='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "水表位置")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND waterMeterPositionName='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "小区编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND communityID='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "倒装标志")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND IsReverse='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "总分表")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND isSummaryMeterS='" + obj.ToString() + "' ";
                    }
                    continue;
                }
                if (dgList.Columns[i].Name == "总表编号")
                {
                    object obj = dgList.Rows[e.RowIndex].Cells[i].Value;
                    if (obj != null && obj != DBNull.Value)
                    {
                        strFilterTJ += " AND waterMeterParentId='" + obj.ToString() + "' ";
                    }
                    continue;
                }
            }
            frmWaterUserStatisticsSearch frm = new frmWaterUserStatisticsSearch();
            frm.strFilter = strFilterTJ + strFilter;
            frm.ShowDialog();
        }

        private void toolExcel_Click(object sender, EventArgs e)
        {
            string strCaption = "用水用户统计表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
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
