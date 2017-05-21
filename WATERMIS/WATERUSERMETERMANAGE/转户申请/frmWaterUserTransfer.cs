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
    public partial class frmWaterUserTransfer : DockContentEx
    {
        public frmWaterUserTransfer()
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
            dgListUp.AutoGenerateColumns = false;

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

            for (int i = 0; i < dgListUp.Columns.Count; i++)
            {
                dgListUp.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            BindMeterReader(cmbMeterReader);
            BindWaterMeterType(cmbWaterMeterType);

            BindAreaNO(cmbAreaNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");

            cmbMeterReaderNew.Visible = false;
            cmbMeterReaderNew.DropDownStyle = ComboBoxStyle.DropDownList;
            dgListUp.Controls.Add(cmbMeterReaderNew);
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

            cmbMeterReaderNew.DataSource = dt;
            cmbMeterReaderNew.DisplayMember = "USERNAME";
            cmbMeterReaderNew.ValueMember = "LOGINID";

            cmbMeterReaderNew.SelectedValueChanged += new EventHandler(cmbMeterReaderNew_SelectedValueChanged);
        }

        void cmbMeterReaderNew_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dgListUp.CurrentCell == null)
                return;

            dgListUp.CurrentRow.Cells["meterReaderNameNew"].Value = cmbMeterReaderNew.Text;
            dgListUp.Rows[dgListUp.CurrentCell.RowIndex].Cells["meterReaderIDNew"].Value = cmbMeterReaderNew.SelectedValue;
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

            if (cmbMeterReader.SelectedValue != null && cmbMeterReader.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderID='" + cmbMeterReader.SelectedValue.ToString() + "'";

            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";

            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

            if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

            if (chkDateTime.Checked)
                strFilter += " AND waterUserCreateDate BETWEEN '" + dtpStart.Value.ToShortDateString() + " 00:00:00' AND '" + dtpEnd.Value.ToShortDateString() + " 23:59:59'";

            strFilter += " ORDER BY areaNO,duanNO,ordernumber";

            dtWaterUserList = BLLwaterUser.QueryInitialWaterUser(strFilter);

            if (dtWaterUserList.Rows.Count > 0)
            {

                //dtClone.Rows.Add(drLast);
                //ucPageSetUp1.InitialUC(this.dgList, dtWaterUserList, dtClone);
                dgList.DataSource = dtWaterUserList;

                toolSave.Enabled = true;
            }
            else
            {
                dgList.DataSource = null;
                toolSave.Enabled = false;
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
            string strCaption = "用水用户明细表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
        }

        /// <summary>
        /// 存储已经选择的列表
        /// </summary>
        DataTable dtSelected = new DataTable();
        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            object obj = dgList.Rows[e.RowIndex].Cells["waterUserId"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                if (dtSelected.Columns.Count == 0)
                    dtSelected = dtWaterUserList.Clone();

                bool isExist = false;
                for (int i = 0; i < dtSelected.Rows.Count; i++)
                {
                    object objWaterUserIDSelect = dtSelected.Rows[i]["waterUserId"];
                    if (objWaterUserIDSelect != null && objWaterUserIDSelect != DBNull.Value)
                        if (objWaterUserIDSelect.ToString() == obj.ToString())
                        {
                            isExist = true;
                            break;
                        }
                }
                if (!isExist)
                {
                    DataRow[] dr = dtWaterUserList.Select("waterUserId='" + obj.ToString() + "'");
                    dtSelected.ImportRow(dr[0]);
                    dgListUp.DataSource = dtSelected;
                }
            }
        }

        private void dgListUp_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgListUp.CurrentCell == null)
                return;

            try
            {
                if (dgListUp.Columns[dgListUp.CurrentCell.ColumnIndex].Name == "meterReaderNameNew")
                {
                    Rectangle rect = dgListUp.GetCellDisplayRectangle(dgListUp.CurrentCell.ColumnIndex, dgListUp.CurrentCell.RowIndex, false);
                    object objMeterReaderNewID = dgListUp.CurrentRow.Cells["meterReaderIDNew"].Value;
                    if (objMeterReaderNewID != null && objMeterReaderNewID != DBNull.Value)
                        cmbMeterReaderNew.SelectedValue = objMeterReaderNewID.ToString();
                    else
                        cmbMeterReaderNew.SelectedValue = DBNull.Value;
                    cmbMeterReaderNew.Left = rect.Left;
                    cmbMeterReaderNew.Top = rect.Top;
                    cmbMeterReaderNew.Width = rect.Width;
                    cmbMeterReaderNew.Height = rect.Height;
                    cmbMeterReaderNew.Visible = true;
                }
                else
                {
                    cmbMeterReaderNew.Visible = false;
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
            }
        }

        private void dgListUp_Scroll(object sender, ScrollEventArgs e)
        {
            this.cmbMeterReaderNew.Visible = false;
        }

        private void dgListUp_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.cmbMeterReaderNew.Visible = false;
        }

        private void toolADD_Click(object sender, EventArgs e)
        {
            dtSelected.Rows.Clear();
            dgListUp.DataSource = dtSelected;
            toolADD.Enabled = false;
            toolSave.Enabled = true;
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (dgListUp.Rows.Count == 0)
            {
                mes.Show("请从下方列表内双击要转户的用户信息添加转户明细");
                return;
            }
            dgListUp.EndEdit();

            string strWaterUserTransferID = GETTABLEID.GetTableID(strLogID, "WaterUserTransfer".ToUpper());
            string strWaterUserTransferDetailID = GETTABLEID.GetTableID(strLogID, "WaterUserTransferDetail".ToUpper());

            string strSQLInsert = "INSERT INTO WaterUserTransfer(WaterUserTransferID,ApplierName,ApplierID,ApplyDateTime) VALUES('{0}','{1}','{2}',GETDATE())";
            strSQLInsert = string.Format(strSQLInsert, strWaterUserTransferID, strLogName, strLogID);

            string strSQLDetail = "";
            for (int i = 0; i < dgListUp.Rows.Count; i++)
            {
                string strWaterUserID = "", strMeterReaderIDNew = "", strMeterReaderNameNew = "", strAreaNONew = "", strDuanNONew = "";

                object objWaterUserID = dgListUp.Rows[i].Cells["waterUserIdUp"].Value;
                if (objWaterUserID == null || objWaterUserID == DBNull.Value)
                {
                    mes.Show("检测到第 " + (i + 1).ToString() + " 行用户号为空,提交失败!");
                    return;
                }
                else
                    strWaterUserID = objWaterUserID.ToString();

                objWaterUserID = dgListUp.Rows[i].Cells["meterReaderIDNew"].Value;
                if (objWaterUserID == null || objWaterUserID == DBNull.Value)
                {
                    mes.Show("检测到第 " + (i + 1).ToString() + " 行转入抄表员为空,请选择后点击提交按钮!");
                    return;
                }
                else
                    strMeterReaderIDNew = objWaterUserID.ToString();

                objWaterUserID = dgListUp.Rows[i].Cells["meterReaderNameNew"].Value;
                if (objWaterUserID == null || objWaterUserID == DBNull.Value)
                {
                    mes.Show("检测到第 " + (i + 1).ToString() + " 行转入抄表员为空,请选择后点击提交按钮!");
                    return;
                }
                else
                    strMeterReaderNameNew = objWaterUserID.ToString();

                objWaterUserID = dgListUp.Rows[i].Cells["areaNONew"].Value;
                if (objWaterUserID == null || objWaterUserID == DBNull.Value)
                {
                    mes.Show("检测到第 " + (i + 1).ToString() + " 行转入区号为空,请选择后点击提交按钮!");
                    return;
                }
                else
                    strAreaNONew = objWaterUserID.ToString();

                objWaterUserID = dgListUp.Rows[i].Cells["duanNONew"].Value;
                if (objWaterUserID == null || objWaterUserID == DBNull.Value)
                {
                    mes.Show("检测到第 " + (i + 1).ToString() + " 行转入区号为空,请选择后点击提交按钮!");
                    return;
                }
                else
                    strDuanNONew = objWaterUserID.ToString();

                int intIndex = Convert.ToInt16(strWaterUserTransferDetailID.Substring(12, 3)) + i;
                string strWaterUserTransferDetailIDTemp = strWaterUserTransferDetailID.Substring(0, 12) + intIndex.ToString().PadLeft(3, '0');

                if (strSQLDetail == "")
                {
                    strSQLDetail = @"INSERT INTO WaterUserTransferDetail(WaterUserTransferDetailID,WaterUserTransferID,
waterUserNO,waterUserName,waterUserAddress,areaNO,pianNO,duanNO,ordernumber,meterReaderID,meterReaderName,
meterReaderIDNew,meterReaderNameNew,areaNONew,duanNONew,waterMeterTypeId,WaterMeterTypeValue,Operator,OperateDateTime)
SELECT '{0}','{1}',
waterUserNO,waterUserName,waterUserAddress,areaNO,pianNO,duanNO,ordernumber,meterReaderID,meterReaderName,
'{2}','{3}','{4}','{5}',waterMeterTypeId,WaterMeterTypeValue,'{6}',GETDATE() FROM V_WATERUSER_CONNECTWATERMETER WHERE WATERUSERID='{7}' ";
                }
                else
                {
                    strSQLDetail = strSQLDetail + "\r";
                    strSQLDetail += @"INSERT INTO WaterUserTransferDetail(WaterUserTransferDetailID,WaterUserTransferID,
waterUserNO,waterUserName,waterUserAddress,areaNO,pianNO,duanNO,ordernumber,meterReaderID,meterReaderName,
meterReaderIDNew,meterReaderNameNew,areaNONew,duanNONew,waterMeterTypeId,WaterMeterTypeValue,Operator,OperateDateTime)
SELECT '{0}','{1}',
waterUserNO,waterUserName,waterUserAddress,areaNO,pianNO,duanNO,ordernumber,meterReaderID,meterReaderName,
'{2}','{3}','{4}','{5}',waterMeterTypeId,WaterMeterTypeValue,'{6}',GETDATE() FROM V_WATERUSER_CONNECTWATERMETER WHERE WATERUSERID='{7}' ";
                }

                strSQLDetail = string.Format(strSQLDetail, strWaterUserTransferDetailIDTemp, strWaterUserTransferID, 
                    strMeterReaderIDNew, strMeterReaderNameNew, strLogID, strWaterUserID,strAreaNONew,strDuanNONew);
            }
            if (strSQLDetail != "")
            {
                strSQLInsert = "BEGIN TRAN \r" + strSQLInsert + "\r" + strSQLDetail + "\r IF @@ERROR=0 \r COMMIT TRAN ELSE ROLLBACK TRAN";
                int intCount = BLLwaterUser.ExcuteSQL(strSQLInsert);
                if (intCount > 0)
                {
                    toolADD.Enabled = true;
                    toolSave.Enabled = false;
                }
            }
            else
            {
                mes.Show("未检测到转户明细语句，请重新点击提交按钮");
                return;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            btSearch.Focus();
        }

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtWaterUserNOSearch.Text.Trim() != "")
                    toolSearch_Click(null, null);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgListUp.CurrentRow == null)
                return;
            object obj = dgListUp.CurrentRow.Cells["waterUserIdUp"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                for (int i = 0; i < dtSelected.Rows.Count; i++)
                {
                    object objIDSelected = dtSelected.Rows[i]["waterUserId"];
                    if (obj.ToString() == objIDSelected.ToString())
                    {
                        dtSelected.Rows.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void dgListUp_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                dgListUp.ClearSelection();
                dgListUp.CurrentCell =dgListUp.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if(toolSave.Enabled)
                contextMenuStrip2.Show(MousePosition.X,MousePosition.Y);
            }
        }
    }
}
