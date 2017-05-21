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

namespace WATERUSERMETERMANAGE
{
    public partial class frmWaterUserTransferExamine : DockContentEx
    {
        public frmWaterUserTransferExamine()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();

        BLLAREA BLLAREA = new BLLAREA();
        GETTABLEID GETTABLEID = new GETTABLEID();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        BLLwaterUser BLLwaterUser = new BLLwaterUser();

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strLogName = "";

        private ComboBox cmbMeterReaderNew = new ComboBox();
        private void frmWaterUserSearch_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;
            dgList.AutoGenerateColumns = false;

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("操作员ID获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strLogName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            BindMeterReader(cmbMeterReader);
            BindWaterMeterType(cmbWaterMeterType);

            BindAreaNO(cmbAreaNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");

            cmbMeterReaderNew.Visible = false;
            cmbMeterReaderNew.DropDownStyle = ComboBoxStyle.DropDownList;
            dgList.Controls.Add(cmbMeterReaderNew);

            cmbExamineState.SelectedIndex = 1;
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
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1' ORDER BY USERNAME");
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
            RefreshData();
        }

        Thread TD;
        private void RefreshData()
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                LoadData();
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
            }
            catch (Exception ex)
            {
                log.Write("用户及水表明细界面:" + ex.ToString(), MsgType.Error);

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
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
                log.Write("用户及水表明细界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 存储查询到的用户表
        /// </summary>
        DataTable dtWaterUserList = new DataTable();
        private void LoadData()
        {
            string strFilter = "";

            string strSearch = txtWaterUserNOSearch.Text;
            if (strSearch != "")
                strFilter += " AND (waterUserNO LIKE '%" + strSearch + "%' OR waterUserName LIKE '%" + strSearch +
                    "%' OR waterUserAddress LIKE '%" + strSearch + "%') ";

            if (cmbExamineState.SelectedIndex > 0)
                strFilter += " AND ExamineState='"+(cmbExamineState.SelectedIndex-1).ToString()+"'";

            if (cmbMeterReader.SelectedValue != null && cmbMeterReader.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderID='" + cmbMeterReader.SelectedValue.ToString() + "'";

            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";

            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

            if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

            if (chkDateTime.Checked)
                strFilter += " AND ApplyDateTime BETWEEN '" + dtpStart.Value.ToShortDateString() + " 00:00:00' AND '" + dtpEnd.Value.ToShortDateString() + " 23:59:59'";

            strFilter += " ORDER BY ApplyDateTime DESC";

            string strSQL = "SELECT * FROM WaterUserTransfer A INNER JOIN WaterUserTransferDetail B ON A.WaterUserTransferID=B.WaterUserTransferID ";
            strSQL += strFilter;

            dtWaterUserList = BLLwaterUser.QuerySQL(strSQL);

            if (dtWaterUserList.Rows.Count > 0)
            {

                //dtClone.Rows.Add(drLast);
                //ucPageSetUp1.InitialUC(this.dgList, dtWaterUserList, dtClone);
                dgList.DataSource = dtWaterUserList;

                toolExamine.Enabled = true;
            }
            else
            {
                dgList.DataSource = null;
                toolExamine.Enabled = false;
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

                object obj=dgList.Rows[e.RowIndex].Cells["ExamineState"].Value;
                if(obj!=null&&obj!=DBNull.Value)
                if (obj.ToString() == "1")
                    dgList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                else if (obj.ToString() == "2")
                    dgList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
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

        private void toolExcel_Click(object sender, EventArgs e)
        {
            string strCaption = "转户申请表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
        }

        private void toolExamine_Click(object sender, EventArgs e)
        {
            if (dgList.SelectedRows.Count == 0)
            {
                mes.Show("请从下方列表内选择要审批的行");
                return;
            }

            string strWaterUserTransferIDS = "";

            for (int i = 0; i < dgList.SelectedRows.Count; i++)
            {
                object obj = dgList.SelectedRows[i].Cells["WaterUserTransferID"].Value;
                if (obj != null && obj != DBNull.Value)
                    if (strWaterUserTransferIDS.Contains(obj.ToString()))
                        continue;
                    else
                    {
                        if (strWaterUserTransferIDS != "")
                            strWaterUserTransferIDS += ",'" + obj.ToString() + "'";
                        else
                            strWaterUserTransferIDS = "'" + obj.ToString() + "'";
                    }
            }
            string strSQL = @"UPDATE WaterUserTransfer SET ExaminerID='{0}',ExaminerName='{1}',ExamineState='1',
ExamineDateTime=GETDATE() WHERE WaterUserTransferID IN (" + strWaterUserTransferIDS + ")";
            strSQL = string.Format(strSQL,strLogID,strLogName);
            int intCount = BLLwaterUser.ExcuteSQL(strSQL);
            if (intCount > 0)
                toolSearch_Click(null, null);
        }

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                if (txtWaterUserNOSearch.Text.Trim() != "")
                toolSearch_Click(null,null);
        }

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "ExamineState")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "未审批";
                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "同意";
                    }
                    else if (e.Value.ToString() == "2")
                    {
                        e.Value = "不同意";
                    }
            }
        }

        private void toolNot_Click(object sender, EventArgs e)
        {
            if (dgList.SelectedRows.Count == 0)
            {
                mes.Show("请从下方列表内选择要审批的行");
                return;
            }

            string strWaterUserTransferIDS = "";

            for (int i = 0; i < dgList.SelectedRows.Count; i++)
            {
                object obj = dgList.SelectedRows[i].Cells["WaterUserTransferID"].Value;
                if (obj != null && obj != DBNull.Value)
                    if (strWaterUserTransferIDS.Contains(obj.ToString()))
                        continue;
                    else
                    {
                        if (strWaterUserTransferIDS != "")
                            strWaterUserTransferIDS += ",'" + obj.ToString() + "'";
                        else
                            strWaterUserTransferIDS = "'" + obj.ToString() + "'";
                    }
            }
            string strSQL = @"UPDATE WaterUserTransfer SET ExaminerID='{0}',ExaminerName='{1}',ExamineState='2',
ExamineDateTime=GETDATE() WHERE WaterUserTransferID IN (" + strWaterUserTransferIDS + ")";
            strSQL = string.Format(strSQL, strLogID, strLogName);
            int intCount = BLLwaterUser.ExcuteSQL(strSQL);
            if (intCount > 0)
                toolSearch_Click(null, null);
        }
    }
}
