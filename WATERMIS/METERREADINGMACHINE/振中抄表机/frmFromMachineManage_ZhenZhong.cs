using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Ports;
using Microsoft.VisualBasic;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using BLL;
using BASEFUNCTION;
using MODEL;

namespace METERREADINGMACHINE
{
    public partial class frmFromMachineManage_ZhenZhong : Form
    {
        public frmFromMachineManage_ZhenZhong()
        {
            InitializeComponent();
        }

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        GETTABLEID GETTABLEID = new GETTABLEID();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLNullReadReasonMemo BLLNullReadReasonMemo = new BLLNullReadReasonMemo();

        #region 抄表机动态库相关
        /// <summary>
        /// 打开指定端口，并检测手持机是否连接在此端口上
        /// </summary>
        /// <param name="intPort">intPort为当前手持机所连接的串口，如1为串口一，2为串口二</param>
        /// <returns>成功   返回端口号（与PORT值相同），否则详见GetErrorMes</returns>
        [DllImport("comdll.dll")]
        private static extern int openport(int intPort);

        /// <summary>
        /// 关闭已打开的端口
        /// </summary>
        [DllImport("comdll.dll")]
        private static extern void closeport();

        /// <summary>
        /// 设置手持机日期和时间    
        /// </summary>
        /// <param name="intPort">手持机连接的端口</param>
        /// <returns>成功  返回0，否则详见GetErrorMes</returns>
        [DllImport("comdll.dll")]
        private static extern int downsystime(int intPort);

        /// <summary>
        /// 从指定的端口上传一个名为[filename]的手持机文件到PC  
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strFileName">为一字符串变量，因为手持机没有目录信息，因此[filename]不能包含文件路径</param>
        /// <returns>成功  返回0,失败  返回参数见错误列表</returns>
        [DllImport("comdll.dll")]
        private static extern int GetHcFile(int intPort,int intBaudRate, StringBuilder strFileName,StringBuilder strFileSaveAs,int intPromt);

        /// <summary>
        /// 从指定的端口上传机器编号字符串到PC
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strMachineNO">为一字符串变量,为返回的机器编号</param>
        /// <returns></returns>
        [DllImport("comdll.dll")]
        private static extern int getmno(int intPort, StringBuilder strMachineNO);
        [DllImport("comdll.dll")]
        private static extern int up_userinfo(int intPort, StringBuilder strMeterReaderNO, StringBuilder strMeterReaderName);

        /// <summary>
        /// 删除一个名为[filename]的手持机文件
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strFileName">为一字符串变量，因为手持机没有目录信息，因此[filename]不能包含文件路径</param>
        /// <returns>成功  返回0</returns>
        [DllImport("comdll.dll")]
        private static extern int deletefile(int intPort, StringBuilder strFileName);

        /// <summary>
        /// 下传并改名
        /// </summary>
        /// <param name="intPort">手持机连接的端口</param>
        /// <param name="strPCFileName">PC端文件名</param>
        /// <param name="strHandSetFileName">下载到手持机的文件名</param>
        /// <returns>成功  返回0</returns>
        [DllImport("comdll.dll")]
        private static extern int downtofile(int intPort, StringBuilder strPCFileName, StringBuilder strHandSetFileName);

        private string GetErrorMes(int intErrorNO)
        {
            string strErrorMes = "未知错误!";
            switch (intErrorNO)
            {
                case 0:
                    strErrorMes = "命令正常执行";
                    break;
                case 101:
                    strErrorMes = "无效数据";
                    break;
                case 106:
                    strErrorMes = "上装数据库成功";
                    break;
                case 107:
                    strErrorMes = "下装数据库成功";
                    break;
                case 108:
                    strErrorMes = "文件打开错误";
                    break;
                case 109:
                    strErrorMes = "内存错误";
                    break;
                case 110:
                    strErrorMes = "通信传输错误";
                    break;
                case 111:
                    strErrorMes = "通讯正常终止";
                    break;
                case 112:
                    strErrorMes = "通信接收错误";
                    break;
                case 113:
                    strErrorMes = "传输文件大于64K";
                    break;
                case 114:
                    strErrorMes = "无效的文件尺寸";
                    break;
                case 115:
                    strErrorMes = "无效参数";
                    break;
                case 116:
                    strErrorMes = "下传程序完毕";
                    break;
                case 117:
                    strErrorMes = "删除完毕";
                    break;
                case 118:
                    strErrorMes = "串口设置完毕";
                    break;
                case 119:
                    strErrorMes = "手持机无响应";
                    break;
                case 120:
                    strErrorMes = "通信超时";
                    break;
                case 123:
                    strErrorMes = "文件格式错误";
                    break;
                case 200:
                    strErrorMes = "命令操作失败";
                    break;
                case 201:
                    strErrorMes = "文件未找到";
                    break;
                case 202:
                    strErrorMes = "文件删除失败";
                    break;
                case 203:
                    strErrorMes = "端口打开错误,请确认是否连接抄表机";
                    break;
            }
            return strErrorMes;
        }
        #endregion


        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        /// <summary>
        /// 单元格默认的背景色
        /// </summary>
        Color colorDGDefault = new Color();

        /// <summary>
        /// 存储未抄原因
        /// </summary>
        DataTable dtNullRecordReason = new DataTable();

        private void frmMeterReadingMachineManage_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;
            dgExceptionData.AutoGenerateColumns = false;
            cmbMeterReadState.SelectedIndex = 0;

            BindAreaNO(cmbAreaNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");

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

            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                //if (dgList.Columns[i].Name != "checkCell")
                //    dgList.Columns[i].ReadOnly = true;
                dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            colorDGDefault = dgList.DefaultCellStyle.BackColor;
            BindNullRecordReason();
        }
        /// <summary>
        /// 将未抄原因取到表里存储
        /// </summary>
        private void BindNullRecordReason()
        {
            dtNullRecordReason = BLLNullReadReasonMemo.Query("");
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
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
                //TD.Join();
            }
            catch (Exception ex)
            {
                //mes.Show(ex.Message);
                log.Write("从抄表机导出数据界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("从抄表机导出数据界面:" + ex.ToString(), MsgType.Error);
            }
        }

        DataTable dtHandSetData = new DataTable();
        private void LoadData()
        {
            try
            {
                string strDBFPath = Application.StartupPath + @"\HndSet\";


                string strFilter ="";
                if (txtWaterUserNO.Text.Trim() != "")
                    strFilter += " AND YHBH='" + txtWaterUserNO.Text.Trim().PadLeft(8, '0') + "'";
                if (txtWaterUserName.Text.Trim() != "")
                    strFilter += " AND YHMC LIKE '%" + txtWaterUserName.Text.Trim() + "%'";

                if (cmbMeterReadState.SelectedIndex > 0)
                    strFilter += " AND CBBZ='" + (cmbMeterReadState.SelectedIndex - 1).ToString() + "'";

                string strSort = "";
                if (rbWaterMeterReading.Checked)
                    strSort = " ORDER BY CBSX";
                if (rbWaterUserNO.Checked)
                    strSort = " ORDER BY YHBH";

                string strQuerySQL =
                    "select * from INTERDB WHERE 1=1 " + strFilter + strSort;
                dtHandSetData = GetHandSetData(strQuerySQL);
                if (dtHandSetData.Rows.Count == 0)
                {
                    dgList.DataSource = null;
                    return;
                }

                ////是否导入系统标志
                //DataColumn dc = new DataColumn("ISDEAL",typeof(string));
                //dtHandSetData.Columns.Add(dc);

                dgList.DataSource = dtHandSetData;

                DataTable dtHandSetDataTemp = dtHandSetData.Copy();
                DataView dv = dtHandSetDataTemp.DefaultView;
                //dv.RowFilter = QueryWaterUser();
                //dv.Sort = SortWaterUser();
                //DataTable dtFilter = dv.ToTable();
                //dgList.DataSource = dtFilter;

                #region 统计数据显示
                //应抄总数、已抄数量、未抄数量、已收数量、未收数量。
                int intSumCount = 0, intReadCount = 0, intUnReadCount = 0, intTotalNumber = 0;
                decimal decUnChargeMoney = 0;
                DataTable dtStatistial = dv.ToTable().Copy();

                intSumCount = dtStatistial.Rows.Count;

                DataView dvStatistialRead = dtStatistial.DefaultView;//2101   6  2095
                dvStatistialRead.RowFilter = "CBBZ='1'";
                intReadCount = dvStatistialRead.Count;

                DataView dvStatistialUnRead = dtStatistial.DefaultView;
                dvStatistialUnRead.RowFilter = "CBBZ='0'";
                intUnReadCount = dvStatistialUnRead.Count;

                for (int i = 0; i < dgList.Rows.Count; i++)
                {
                    object objMoney = dgList.Rows[i].Cells["ZSF"].Value;
                    if (Information.IsNumeric(objMoney))
                        decUnChargeMoney += Convert.ToDecimal(objMoney);
                    object objZSL = dgList.Rows[i].Cells["ZSL"].Value;
                    if (Information.IsNumeric(objZSL))
                        intTotalNumber += Convert.ToInt32(objZSL);
                }
                //DataTable dtYCSJ = (DataTable)dgList.DataSource;
                //object objUnChargeMoney = dtYCSJ.Compute("SUM(ZSF)", "");
                //if (Information.IsNumeric(objUnChargeMoney))
                //    decUnChargeMoney = Convert.ToDecimal(objUnChargeMoney);

                labTip.Text = "本次查询—总数:" + intSumCount.ToString() + ";已抄:" + intReadCount.ToString() +
                             ";未抄:" + intUnReadCount.ToString() + ";总水量:"+intTotalNumber+";应收总计:" + decUnChargeMoney.ToString("F2") + "元";
                #endregion
                chkSelectAll.Checked = false;
                labExcute.Text = "";

                if (dgList.Rows.Count == 0)
                {
                    btImport.Enabled = false;
                }
                else
                {
                    btImport.Enabled = true;

                    string strQuerySQLIsReverse =
                        "select * from interdb where val(sb1byds)- val(sb1syds)<0 AND CBBZ='1' and SB2sy='0'";//非倒装已抄表本月读数小于上月读书的
                    DataTable dtIsReverse = GetHandSetData(strQuerySQLIsReverse);
                    if (dtIsReverse.Rows.Count > 0)
                    {
                        dgExceptionData.DataSource = dtIsReverse;
                        labTip.Text = "※含异常数据※" + labTip.Text;
                    }
                    else
                        dgExceptionData.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write("从抄表机导出数据管理界面:" + ex.ToString(), MsgType.Error);
            }
        }
        private DataTable GetHandSetData(string strSQL)
        {
            string connectString =
                            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(strSQL, connection);
                    command.Fill(ds, "ds");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("error:{0}", ex.Message));
                    log.Write(ex.ToString(),MsgType.Error);
                }
                return ds.Tables[0];
            }
        }

        string strDBFPath = Application.StartupPath + @"\HndSet\";
        private void btConnectDBF_Click(object sender, EventArgs e)
        {

            string connectString =
                            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter("select * from INTERDB", connection);
                    command.Fill(ds, "ds");
                    MessageBox.Show(ds.Tables[0].Rows.Count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("error:{0}", ex.Message));
                }
            }
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            string strInsertSQL = "INSERT INTO openrowset('MICROSOFT.JET.OLEDB.4.0','dBase III;database=" + strDBFPath + "','select * from [INTERDB.dbf]') " +
            " SELECT * FROM INTERDBF";
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (tabCHandSet.SelectedIndex < 1)
                tabCHandSet.SelectedIndex = tabCHandSet.SelectedIndex + 1;
            else
                btNext.Enabled = false;
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            if (tabCHandSet.SelectedIndex > 0)
                tabCHandSet.SelectedIndex = tabCHandSet.SelectedIndex - 1;
            else
                btPrevious.Enabled = false;
        }

        private void tabCHandSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabCHandSet.SelectedIndex)
            {
                case 0:
                    btPrevious.Enabled = false;
                    btNext.Enabled = true;
                    btImport.Visible = false;
                    //chkSelectAll.Visible = false;
                    break;
                case 1:
                    btPrevious.Enabled = true;
                    btNext.Enabled = false;
                    btImport.Visible = true;
                    //chkSelectAll.Visible = true;
                    break;
            }
        }

        private void btDownLoadData_Click(object sender, EventArgs e)
        {
            bgWorkDownData.RunWorkerAsync();
        }

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "CBBZ")
            {
                if (e.Value != DBNull.Value && e.Value != null)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "未抄";
                        //dgList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    }
                    else if (e.Value.ToString() == "1")
                        e.Value = "已抄";
                }
                else
                    e.Value = "未抄";
            }

            if (dgList.Columns[e.ColumnIndex].Name == "dybz")
            {
                if (e.Value != DBNull.Value && e.Value != null)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "未收";
                        dgList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "已收";
                        dgList.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorDGDefault;
                    }
                }
                else
                    e.Value = "未收";
            }

            if (dgList.Columns[e.ColumnIndex].Name == "iszongbiao")
            {
                if (e.Value != DBNull.Value && e.Value != null)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "分表";
                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "总表";
                    }
                }
                else
                    e.Value = "分表";
            }
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            RefreshData();
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

        private void dgList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgList.IsCurrentCellDirty)
            {
                dgList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "checkCell")
            {
                //dgList.EndEdit();

                int intCount = 0;
                for (int i = 0; i < dgList.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chkcell = (DataGridViewCheckBoxCell)dgList.Rows[i].Cells["checkCell"];
                    bool isChecked = Convert.ToBoolean(chkcell.EditedFormattedValue);
                    if (isChecked)
                    {
                        intCount++;
                    }
                }

                if (intCount == dgList.Rows.Count)
                    chkSelectAll.Checked = true;
                else
                    chkSelectAll.Checked = false;
            }
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                for (int i = 0; i < dgList.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell dgChkCell = (DataGridViewCheckBoxCell)(dgList.Rows[i].Cells["checkCell"]);
                    dgChkCell.Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dgList.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell dgChkCell = (DataGridViewCheckBoxCell)(dgList.Rows[i].Cells["checkCell"]);
                    dgChkCell.Value = false;
                }
            }
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            btImport.Enabled = false;
            labExcute.Text = "正在执行....";
            if (dgList.Rows.Count == 0)
            {
                //mes.Show("没有可导入的抄表数据!");
                btImport.Enabled = false;
                labExcute.Text = "没有可导入的抄表数据!";
                return;
            }
            bgWork.RunWorkerAsync();
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        private int ExcuteSQL(string SQLString, string strConn)
        {
            using (OleDbConnection connection = new OleDbConnection(strConn))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime dtNow = mes.GetDatetimeNow();
                ////获取用水性质
                //DataTable dtWaterMeterType = BLLWATERMETERTYPE.Query("");

                int intChargeCount = 0, intReadCount = 0;
                for (int i = 0; i < dtHandSetData.Rows.Count; i++)
                {
                    if (bgWork.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    labExcute.Text = "共" + dtHandSetData.Rows.Count + "行，正在检测第" + (i + 1).ToString() + "行";

                    ////如果已经导入系统则跳过
                    //object objIsDeal=dtHandSetData.Rows[i]["ISDEAL"];
                    //if (objIsDeal != null && objIsDeal != DBNull.Value)
                    //    if (objIsDeal.ToString() == "1")
                    //        continue;

                    //如果表未抄，则跳过
                    object objCBSTATE = dtHandSetData.Rows[i]["CBBZ"];
                    if (objCBSTATE != null && objCBSTATE != DBNull.Value)
                    {
                        object objRecordLSID = dtHandSetData.Rows[i]["CBSX"];
                        if (objRecordLSID != null && objRecordLSID != DBNull.Value)
                        {
                            object objNullRecordReason = dtHandSetData.Rows[i]["SB2BYDS"];
                            if (objNullRecordReason != null && objNullRecordReason != DBNull.Value)
                            {
                                try
                                {
                                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                                    DataRow[] drNullReason = dtNullRecordReason.Select("NullReadReasonID='" + objNullRecordReason.ToString() + "'");
                                    if (drNullReason.Length > 0)
                                    {
                                        objNullRecordReason = drNullReason[0]["NullReadReasonName"];
                                        if (objNullRecordReason != null && objNullRecordReason != DBNull.Value)
                                            MODELreadMeterRecord.MEMO = objNullRecordReason.ToString();
                                    }
                                    MODELreadMeterRecord.readMeterRecordId = objRecordLSID.ToString();
                                    BLLreadMeterRecord.UpdateHandSetDataNullRecordMemo(MODELreadMeterRecord);
                                }
                                catch (Exception ex)
                                {
                                    log.Write(ex.ToString(), MsgType.Error);
                                    mes.Show("写入未抄原因失败,原因:" + ex.Message);
                                }
                            }
                        }
                        if (objCBSTATE.ToString() == "0")
                        {
                            //labExcute.Text = "第" + (i + 1).ToString() + "行未抄略过";
                            continue;
                        }
                    }

                    //抄表记录ID，收费员ID，收费员名称
                    string strRecordID = "", strWaterUserID = "", strMeterReaderID = "0093", strMeterReaderName = "自动扣款", strNullRecordReason = "";
                    int intBYDS = 0, intBYSL = 0, intWCYS = 1;
                    decimal decPrice = 0, decBYSF = 0, decWSPrice = 0, decWSCLF = 0, decFJFPrice = 0, decFJF = 0, decSum = 0, decWaterUserPrestore = 0,
                            decQQYE = 0, decLJQF = 0;//累计欠费

                    DateTime dtRecordDate = dtNow, dtChargeDate = dtNow;

                    object objRecordID = dtHandSetData.Rows[i]["CBSX"];
                    if (objRecordID != null && objRecordID != DBNull.Value)
                    {
                        strRecordID = objRecordID.ToString();

                        //检测是否已经抄表,如果已导入跳过此条记录的导入
                        object objExistCharge = BLLreadMeterRecord.QueryIsReadMeter(" AND readMeterRecordId='" + strRecordID + "'");
                        if (objExistCharge != null && objExistCharge != DBNull.Value)
                            if (objExistCharge.ToString() != "0")
                                continue;

                        //object objBYDS = dtHandSetData.Rows[i]["SY1BYDS"];
                        object objBYDS = dtHandSetData.Rows[i]["SB1BYDS"];
                        if (Information.IsNumeric(objBYDS))
                            intBYDS = Convert.ToInt32(objBYDS);

                        object objBYSL = dtHandSetData.Rows[i]["ZSL"];
                        if (Information.IsNumeric(objBYSL))
                            intBYSL = Convert.ToInt32(objBYSL);

                        object objWCYS = dtHandSetData.Rows[i]["WCYS"];
                        if (Information.IsNumeric(objWCYS))
                            intWCYS = Convert.ToInt32(objWCYS);

                        //获取阶梯水价
                        DataTable dtRecord = BLLreadMeterRecord.Query(" AND readMeterRecordId='" + strRecordID + "'");
                        if (dtRecord.Rows.Count > 0)
                        {
                            object objTrapezoidPrice = dtRecord.Rows[0]["trapezoidPrice"];
                            if (objTrapezoidPrice != null && objTrapezoidPrice != DBNull.Value)
                            {
                                string[] strWaterMeterRecordTrapePrice = GetAvePrice(Convert.ToDecimal(intBYSL), objTrapezoidPrice.ToString(), intWCYS);
                                decBYSF = Convert.ToDecimal(strWaterMeterRecordTrapePrice[2]);
                                decPrice = Convert.ToDecimal(strWaterMeterRecordTrapePrice[0]);
                            }
                            ////获取抄表员
                            //object objMeterReaderID = dtRecord.Rows[0]["meterReaderID"];
                            //if (objMeterReaderID != null && objMeterReaderID != DBNull.Value)
                            //{
                            //    strMeterReaderID = objMeterReaderID.ToString();
                            //}
                            ////获取抄表员
                            //object objMeterReaderName = dtRecord.Rows[0]["meterReaderName"];
                            //if (objMeterReaderName != null && objMeterReaderName != DBNull.Value)
                            //{
                            //    strMeterReaderName = objMeterReaderName.ToString();
                            //}
                        }

                        object objWSPrice = dtHandSetData.Rows[i]["WJINE"];
                        if (Information.IsNumeric(objWSPrice))
                            decWSPrice = Convert.ToDecimal(objWSPrice);

                        decWSCLF = intBYSL * decWSPrice;

                        object objFJFPrice = dtHandSetData.Rows[i]["qtjine"];
                        if (Information.IsNumeric(objFJFPrice))
                            decFJFPrice = Convert.ToDecimal(objFJFPrice);

                        decFJF = intBYSL * decFJFPrice;

                        object objBYJE = dtHandSetData.Rows[i]["ZSF"];
                        if (Information.IsNumeric(objBYJE))
                            decSum = Convert.ToDecimal(objBYJE);

                        object objRecordDate = dtHandSetData.Rows[i]["CBRQ"];
                        if (Information.IsDate(objRecordDate))
                        {
                            dtRecordDate = Convert.ToDateTime(objRecordDate);
                        }

                        //如果月份不是当前月份，说明抄表机时间有误，抄表取当前时间
                        int Year = dtNow.Year - dtRecordDate.Year;

                        int Month = (dtNow.Year - dtRecordDate.Year) * 12 + (dtNow.Month - dtRecordDate.Month);

                        if (Month != 0)
                            dtRecordDate = dtNow;

                        object objNullRecordReason = dtHandSetData.Rows[i]["SB2BYDS"];
                        if (objNullRecordReason != null && objNullRecordReason != DBNull.Value)
                        {
                            DataRow[] drNullReason = dtNullRecordReason.Select("NullReadReasonID='" + objNullRecordReason.ToString()+ "'");
                            if (drNullReason.Length > 0)
                            {
                                objNullRecordReason = drNullReason[0]["NullReadReasonName"];
                                if (objNullRecordReason != null && objNullRecordReason != DBNull.Value)
                                    strNullRecordReason = objNullRecordReason.ToString();
                            }
                        }

                        #region 处理收费

                        //获取用户余额
                        object objWaterUserID = dtHandSetData.Rows[i]["YHBH"];
                        if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        {
                            strWaterUserID = objWaterUserID.ToString();
                        }
                        DataTable dtWaterUserPrestore=BLLwaterUser.QueryUserPrestore(" AND WATERUSERID='" + strWaterUserID + "'");
                        if (dtWaterUserPrestore.Rows.Count > 0)
                        {
                            object objWaterUserPrestore = dtWaterUserPrestore.Rows[0]["USERAREARAGE"];
                            if (Information.IsNumeric(objWaterUserPrestore))
                            {
                                decWaterUserPrestore = Convert.ToDecimal(objWaterUserPrestore);
                            }

                            if (Information.IsNumeric(dtWaterUserPrestore.Rows[0]["prestore"]))
                                decQQYE = Convert.ToDecimal(dtWaterUserPrestore.Rows[0]["prestore"]);

                            if (Information.IsNumeric(dtWaterUserPrestore.Rows[0]["TOTALFEE"]))
                                decLJQF = Convert.ToDecimal(dtWaterUserPrestore.Rows[0]["TOTALFEE"]);
                        }

                        #region 如果抄表读数与上期读数一样，只记录抄表，不作为应收数据
                        try
                        {
                            if (intBYSL == 0)
                            {
                                MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                                MODELreadMeterRecord.readMeterRecordId = strRecordID;
                                MODELreadMeterRecord.avePrice = decPrice;
                                MODELreadMeterRecord.waterMeterEndNumber = intBYDS;
                                MODELreadMeterRecord.totalNumber = intBYSL;
                                MODELreadMeterRecord.waterTotalCharge = decBYSF;
                                MODELreadMeterRecord.extraChargePrice1 = decWSPrice;//污水处理费
                                MODELreadMeterRecord.extraCharge1 = decWSCLF;
                                MODELreadMeterRecord.extraChargePrice2 = decFJFPrice;
                                MODELreadMeterRecord.extraCharge2 = decFJF;       //附加费
                                MODELreadMeterRecord.extraTotalCharge = decFJF + decWSCLF; //附加费总计包含除水费之外的所有额外附加的费用
                                MODELreadMeterRecord.totalCharge = decSum;
                                MODELreadMeterRecord.readMeterRecordDate = dtRecordDate;
                                MODELreadMeterRecord.checker = strUserName;
                                MODELreadMeterRecord.checkDateTime = dtNow;
                                MODELreadMeterRecord.checkState = "0";
                                MODELreadMeterRecord.chargeState = "1";//只显示已抄表，但不审核
                                MODELreadMeterRecord.chargeID = null;
                                MODELreadMeterRecord.MEMO = strNullRecordReason;

                                #region 获取累计欠费及前期余额
                                MODELreadMeterRecord.WATERUSERJSYE = decQQYE - decLJQF - decSum;
                                MODELreadMeterRecord.WATERUSERQQYE = decQQYE;
                                MODELreadMeterRecord.WATERUSERLJQF = decLJQF + decSum;
                                #endregion

                                if (BLLreadMeterRecord.UpdateHandSetDataAndArrearage(MODELreadMeterRecord))
                                {
                                    intReadCount++;
                                    continue;
                                }
                                else
                                {
                                    mes.Show("将用户编号为'" + strWaterUserID + "'的抄表数据导入失败,请重新导入抄表数据!");
                                }
                            }
                        }
                        catch (Exception exx)
                        {
                            mes.Show("将用户编号为'" + strWaterUserID + "'的抄表数据导入失败,请重新导入抄表数据!\n原因:" + exx.Message);
                        }
                        #endregion 

                        //如果用户充足则收费
                        if (decWaterUserPrestore >= decSum)
                        {
                            #region 如果用户充足则收费
                            MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                            MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLogID, "WATERFEECHARGE");
                            MODELWATERFEECHARGE.TOTALNUMBERCHARGE = intBYSL;
                            MODELWATERFEECHARGE.WATERTOTALCHARGE = decBYSF;
                            MODELWATERFEECHARGE.EXTRACHARGECHARGE1 = decWSCLF;
                            MODELWATERFEECHARGE.EXTRACHARGECHARGE2 = decFJF;
                            MODELWATERFEECHARGE.EXTRATOTALCHARGE = decWSCLF + decFJF;
                            MODELWATERFEECHARGE.OVERDUEMONEY = 0;
                            MODELWATERFEECHARGE.TOTALCHARGE = decSum;
                            MODELWATERFEECHARGE.CHARGETYPEID = "5";
                            MODELWATERFEECHARGE.CHARGEClASS = "1";//收费类型是正常收取

                            MODELWATERFEECHARGE.CHARGEBCYS = decSum;
                            MODELWATERFEECHARGE.CHARGEBCSS = 0;
                            MODELWATERFEECHARGE.CHARGEYSQQYE = decWaterUserPrestore;
                            MODELWATERFEECHARGE.CHARGEYSBCSZ = MODELWATERFEECHARGE.CHARGEBCSS - MODELWATERFEECHARGE.CHARGEBCYS;
                            MODELWATERFEECHARGE.CHARGEYSJSYE = decWaterUserPrestore - decSum;

                            MODELWATERFEECHARGE.CHARGEWORKERID = strMeterReaderID;
                            MODELWATERFEECHARGE.CHARGEWORKERNAME = strMeterReaderName;
                            MODELWATERFEECHARGE.CHARGEDATETIME = dtChargeDate;
                            MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                            try
                            {
                                if (BLLWATERFEECHARGE.InsertFP(MODELWATERFEECHARGE))
                                {
                                    try
                                    {
                                        MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                                        MODELreadMeterRecord.readMeterRecordId = strRecordID;
                                        MODELreadMeterRecord.avePrice = decPrice;
                                        MODELreadMeterRecord.waterMeterEndNumber = intBYDS;
                                        MODELreadMeterRecord.totalNumber = intBYSL;
                                        MODELreadMeterRecord.waterTotalCharge = decBYSF;
                                        MODELreadMeterRecord.extraChargePrice1 = decWSPrice;//污水处理费
                                        MODELreadMeterRecord.extraCharge1 = decWSCLF;
                                        MODELreadMeterRecord.extraChargePrice2 = decFJFPrice;
                                        MODELreadMeterRecord.extraCharge2 = decFJF;       //附加费
                                        MODELreadMeterRecord.extraTotalCharge = decFJF + decWSCLF; //附加费总计包含除水费之外的所有额外附加的费用
                                        MODELreadMeterRecord.totalCharge = decSum;
                                        MODELreadMeterRecord.readMeterRecordDate = dtRecordDate;
                                        MODELreadMeterRecord.checker = strUserName;
                                        MODELreadMeterRecord.checkDateTime = dtNow;
                                        MODELreadMeterRecord.checkState = "1";
                                        MODELreadMeterRecord.chargeState = "3";
                                        MODELreadMeterRecord.chargeID = MODELWATERFEECHARGE.CHARGEID;
                                        MODELreadMeterRecord.MEMO = strNullRecordReason;

                                        #region 获取累计欠费及前期余额
                                        MODELreadMeterRecord.WATERUSERJSYE = MODELWATERFEECHARGE.CHARGEYSJSYE;
                                        MODELreadMeterRecord.WATERUSERQQYE = decQQYE;
                                        MODELreadMeterRecord.WATERUSERLJQF = decLJQF;
                                        #endregion

                                        if (BLLreadMeterRecord.UpdateHandSetDataAndArrearage(MODELreadMeterRecord))
                                        {
                                            bool isSuccessUpdatePrestore = false;
                                            string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CHARGEYSJSYE + " WHERE waterUserId='" + strWaterUserID + "'";
                                            try
                                            {
                                                isSuccessUpdatePrestore = BLLwaterUser.UpdateSQL(strUpdatePrestore);
                                            }
                                            catch (Exception exUpdateWaterUserPrestore)
                                            {
                                                //回滚收费记录
                                                BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                                //回滚收费标志记录
                                                MODELreadMeterRecord.chargeState = "1";
                                                MODELreadMeterRecord.chargeID = null;
                                                MODELreadMeterRecord.OVERDUEMONEY = 0;
                                                MODELreadMeterRecord.readMeterRecordId = strRecordID;
                                                BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);

                                                string strError = "更新用户编号为'" + strWaterUserID + "'的余额失败,原因:" + exUpdateWaterUserPrestore.Message;
                                                mes.Show(strError);
                                                log.Write(exUpdateWaterUserPrestore.ToString(), MsgType.Error);
                                            }
                                            if (!isSuccessUpdatePrestore)
                                            {
                                                //回滚收费记录
                                                BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                                //回滚收费标志记录
                                                MODELreadMeterRecord.chargeState = "1";
                                                MODELreadMeterRecord.chargeID = null;
                                                MODELreadMeterRecord.OVERDUEMONEY = 0;
                                                MODELreadMeterRecord.readMeterRecordId = strRecordID;
                                                BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);

                                                string strError = "更新用户编号为'" + strWaterUserID + "'的余额失败!/n请查询用户余额是否正确后重新收费!";
                                                mes.Show(strError);
                                                log.Write(strError, MsgType.Error);
                                                return;
                                            }
                                            else
                                            {
                                                intReadCount++;
                                                intChargeCount++;
                                            }
                                        }
                                        else
                                        {
                                            mes.Show("将用户编号为'" + strWaterUserID + "'的抄表数据导入失败,请重新导入抄表数据!");
                                        }
                                    }
                                    catch (Exception exReadMeterRecord)
                                    {
                                        //回滚收费记录
                                        BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);

                                        mes.Show("第" + (i + 1).ToString() + "行更新收费标志失败,原因:" + exReadMeterRecord.Message);
                                        log.Write(exReadMeterRecord.ToString(), MsgType.Error);
                                        return;
                                    }
                                }
                            }
                            catch (Exception exWaterFee)
                            {
                                mes.Show("第" + (i + 1).ToString() + "行收费失败,原因:" + exWaterFee.Message);
                                log.Write(exWaterFee.ToString(), MsgType.Error);
                                return;
                            }
                            #endregion
                        }
                        else
                        {
                            try
                            {
                                MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                                MODELreadMeterRecord.readMeterRecordId = strRecordID;
                                MODELreadMeterRecord.avePrice = decPrice;
                                MODELreadMeterRecord.waterMeterEndNumber = intBYDS;
                                MODELreadMeterRecord.totalNumber = intBYSL;
                                MODELreadMeterRecord.waterTotalCharge = decBYSF;
                                MODELreadMeterRecord.extraChargePrice1 = decWSPrice;//污水处理费
                                MODELreadMeterRecord.extraCharge1 = decWSCLF;
                                MODELreadMeterRecord.extraChargePrice2 = decFJFPrice;
                                MODELreadMeterRecord.extraCharge2 = decFJF;       //附加费
                                MODELreadMeterRecord.extraTotalCharge = decFJF + decWSCLF; //附加费总计包含除水费之外的所有额外附加的费用
                                MODELreadMeterRecord.totalCharge = decSum;
                                MODELreadMeterRecord.readMeterRecordDate = dtRecordDate;
                                MODELreadMeterRecord.checker = strUserName;
                                MODELreadMeterRecord.checkDateTime = dtNow;
                                MODELreadMeterRecord.checkState = "1";
                                MODELreadMeterRecord.chargeState = "1";
                                MODELreadMeterRecord.chargeID = null;
                                MODELreadMeterRecord.MEMO = strNullRecordReason;

                                #region 获取累计欠费及前期余额
                                MODELreadMeterRecord.WATERUSERJSYE = decQQYE - decLJQF - decSum;
                                MODELreadMeterRecord.WATERUSERQQYE = decQQYE;
                                MODELreadMeterRecord.WATERUSERLJQF = decLJQF + decSum;
                                #endregion

                                if (BLLreadMeterRecord.UpdateHandSetDataAndArrearage(MODELreadMeterRecord))
                                {
                                    intReadCount++;
                                }
                                else
                                {
                                    mes.Show("将用户编号为'" + strWaterUserID + "'的抄表数据导入失败,请重新导入抄表数据!");
                                }
                            }
                            catch (Exception exx)
                            {
                                mes.Show("将用户编号为'" + strWaterUserID + "'的抄表数据导入失败,请重新导入抄表数据!\n原因:" + exx.Message);
                            }
                        }
                        #endregion
                    }
                }
                labExcute.Text = "本次导入抄表数据:" + intReadCount + "条,收费数据:" + intChargeCount + "条";
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
        }

        /// <summary>
        /// 根据用水类别的阶梯水价获取平均单价和计算过程
        /// </summary>
        /// <param name="decTotalNumber">总用水量</param>
        /// <param name="strTrapePriceString">阶梯水价说明</param>
        /// <param name="intNotReadMonths">未抄月份</param>
        /// <returns></returns>
        private string[] GetAvePrice(decimal decTotalNumber, string strTrapePriceString, int intNotReadMonths)
        {
            string[] strComputeTrape = new string[3];
            //string strTrapePriceString="0-32:1.52|32-50:2.3|50-80:3.5|80-100:4.5|100-120:6";
            string[] strTrapePrice = strTrapePriceString.Split('|');
            decimal decWaterSum = 0, decWaterTotalNumber = decTotalNumber;
            for (int i = strTrapePrice.Length - 1; i >= 0; i--)
            {
                string[] strJTAndPrice = strTrapePrice[i].Split(':');
                string[] strJT = strJTAndPrice[0].Split('-');
                if (Information.IsNumeric(strJT[0]) && Information.IsNumeric(strJT[1]))
                {
                    if (decTotalNumber > (Convert.ToDecimal(strJT[0]) * intNotReadMonths) && decTotalNumber <= (Convert.ToDecimal(strJT[1]) * intNotReadMonths))
                    {
                        decWaterSum += (decTotalNumber - (Convert.ToDecimal(strJT[0]) * intNotReadMonths)) * (Convert.ToDecimal(strJTAndPrice[1]));

                        if (strComputeTrape[1] != null)
                            strComputeTrape[1] += "+(" + decTotalNumber.ToString() + "-" + (Convert.ToDecimal(strJT[0]) * intNotReadMonths) + ")*" + strJTAndPrice[1];
                        else
                            strComputeTrape[1] += "计算过程:(" + decTotalNumber.ToString() + "-" + (Convert.ToDecimal(strJT[0]) * intNotReadMonths) + ")*" + strJTAndPrice[1];

                        decTotalNumber = (Convert.ToDecimal(strJT[0]) * intNotReadMonths);
                        //decTotalNumber = decTotalNumber - Convert.ToDecimal(strJT[0]);
                    }
                    else
                        continue;
                }

            }
            if (decWaterTotalNumber > 0)
                strComputeTrape[0] = (decWaterSum / decWaterTotalNumber).ToString("f3");
            else
                strComputeTrape[0] = "0";
            strComputeTrape[1] += "=" + decWaterSum.ToString() + "÷" + decWaterTotalNumber.ToString() + "=" + strComputeTrape[0];
            strComputeTrape[2] = decWaterSum.ToString("F2");
            return strComputeTrape;
        }
        private void dgList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //    return;
            
            //if (e.Button == MouseButtons.Right)
            //{
            //    dgList.CurrentCell=dgList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    contextMenuStrip1.Show(MousePosition.X,MousePosition.Y);
            //}
        }

        private void 置为未抄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;

            object objRecordID = dgList.CurrentRow.Cells["RECORDID"].Value;
            if (objRecordID != null && objRecordID != DBNull.Value)
            {
                if (mes.ShowQ("确定要将抄表流水号'" + objRecordID.ToString() + "'的抄表信息置为未抄吗?") == DialogResult.OK)
                {
                    try
                    {
                        string connectString =
                                        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
                        string strSQLDelete = "UPDATE INTERDB SET CBBZ='0',DYBZ='0' WHERE recordid='" + objRecordID.ToString() + "'";
                        int intRow = ExcuteSQL(strSQLDelete, connectString);
                        if (intRow > 0)
                        {
                            mes.Show("置为未抄成功!" + Environment.NewLine + "如果要重新抄表请通过'导入抄表机'功能将更改的数据导入抄表机");
                            dgList.CurrentRow.Cells["CBBZ"].Value = "0";
                            dgList.CurrentRow.Cells["DYBZ"].Value = "0";
                        }
                        else
                        {
                            mes.Show("置为未抄失败,请确认数据文件是否存在");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show("置为未抄失败,原因:"+ex.Message);
                        log.Write(ex.ToString(),MsgType.Error);
                        return;
                    }
                }
            }
        }

        private void 置为未收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;

            object objRecordID = dgList.CurrentRow.Cells["RECORDID"].Value;
            if (objRecordID != null && objRecordID != DBNull.Value)
            {
                if (mes.ShowQ("确定要将抄表流水号'" + objRecordID.ToString() + "'的抄表信息置为未收吗?") == DialogResult.OK)
                {
                    try
                    {
                        string connectString =
                                        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
                        string strSQLDelete = "UPDATE INTERDB SET DYBZ='0' WHERE recordid='" + objRecordID.ToString() + "'";
                        int intRow = ExcuteSQL(strSQLDelete, connectString);
                        if (intRow > 0)
                        {
                            mes.ShowQ("置为未收成功!" + Environment.NewLine + "如果要重新收费请通过'导入抄表机'功能将更改的数据导入抄表机");
                            dgList.CurrentRow.Cells["DYBZ"].Value = "0";
                        }
                        else
                        {
                            mes.Show("置为未收失败,请确认数据文件是否存在");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show("置为未收失败,原因:" + ex.Message);
                        log.Write(ex.ToString(), MsgType.Error);
                        return;
                    }
                }
            }
        }

        private void 导入抄表机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btImport.Enabled = false;
            bgWorkImportToMachine.RunWorkerAsync();
        }

        private void bgWorkDownData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgList.DataSource = null;
                labDownState.Text = "正在下载,请稍后......";
                btDownLoadData.Enabled = false;

                string strDateTimeNow = mes.GetDatetimeNow().ToString("yyyyMMddHHmmss");
                StringBuilder strFileName = new StringBuilder();
                strFileName.Append("INTERDB.DBF");

                StringBuilder strDownLoadFileName = new StringBuilder();
                strDownLoadFileName.Append(Application.StartupPath + @"\INTERDB.DBF");

                string strFileNameBak = "INTERDB" + strDateTimeNow + "_ZZ.DBF";
                string strNewFileNameBak = strDBFPath + @"\Bak_ZZ\" + strFileNameBak;

                int intReturn = GetHcFile(0, 0, strFileName, strDownLoadFileName, 2);
                if (intReturn != 0)
                {
                    labExcute.Text = "备份数据失败:" + GetErrorMes(intReturn);
                    mes.Show(labExcute.Text);
                    btImport.Enabled = true;
                    return;
                }
                string strNewFileName = Application.StartupPath + @"\HndSet\INTERDB.DBF";
                if (File.Exists(strNewFileName))
                    File.Delete(strNewFileName);
                if (File.Exists(strDownLoadFileName.ToString()))
                {
                    File.Copy(strDownLoadFileName.ToString(), strNewFileNameBak, true);
                    File.Move(strDownLoadFileName.ToString(), strNewFileName);
                    File.Delete(strDownLoadFileName.ToString());
                    labDownState.Text = "抄表数据下载成功,文件备份名为'" + strFileNameBak + "'";
                    mes.Show("抄表机数据下载成功!");
                }
                else
                {
                    mes.Show("未找到抄表机数据文件!");
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        private void bgWorkImportToMachine_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                labExcute.Text = "正在清空原有抄表机数据...";
                StringBuilder strFileName = new StringBuilder();
                strFileName.Append("INTERDB.DBF");
                int intReturn = deletefile(0, strFileName);
                if (intReturn == 0)
                {
                    labExcute.Text = "正在写入抄表机...";

                    StringBuilder strPCFileName = new StringBuilder();
                    strPCFileName.Append(strDBFPath + "INTERDB.DBF");
                    intReturn = downtofile(0, strPCFileName, strFileName);
                    if (intReturn == 0)
                    {
                        labExcute.Text = "命令执行完毕!";
                    }
                    else
                    {
                        mes.Show(GetErrorMes(intReturn));
                        labExcute.Text = "";
                        return;
                    }
                }
                else
                {
                    mes.Show(GetErrorMes(intReturn));
                    labExcute.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                return;
            }
        }

        private void frmFromMachineManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //closeport();
            if (bgWork.IsBusy)
                bgWork.CancelAsync();
            if (bgWorkDownData.IsBusy)
                bgWorkDownData.CancelAsync();
            if (bgWorkImportToMachine.IsBusy)
                bgWorkImportToMachine.CancelAsync();
        }

        private void 置为已导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;

            object objRecordID = dgList.CurrentRow.Cells["RECORDID"].Value;
            if (objRecordID != null && objRecordID != DBNull.Value)
            {
                if (mes.ShowQ("确定要将抄表流水号'" + objRecordID.ToString() + "'的抄表数据置为已导入吗?") == DialogResult.OK)
                {
                    try
                    {
                        string connectString =
                                        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
                        //string strSQLDelete = "DELETE FROM INTERDB WHERE recordid='" + objRecordID.ToString() + "'";
                        //int intRow = ExcuteSQL(strSQLDelete, connectString);
                        string strSQLUpdate = "UPDATE INTERDB SET ISDEAL='1' WHERE recordid='" + objRecordID.ToString() + "'";
                        int intRow = ExcuteSQL(strSQLUpdate, connectString);
                        if (intRow > 0)
                        {
                            dgList.CurrentRow.Cells["ISDEAL"].Value = "1";
                        }
                        else
                        {
                            mes.Show("置为已导入失败,请确认数据文件是否存在");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show("置为已导入失败,原因:" + ex.Message);
                        log.Write(ex.ToString(), MsgType.Error);
                        return;
                    }
                }
            }
        }

        private void 置为未导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;

            object objRecordID = dgList.CurrentRow.Cells["RECORDID"].Value;
            if (objRecordID != null && objRecordID != DBNull.Value)
            {
                if (mes.ShowQ("确定要将抄表流水号'" + objRecordID.ToString() + "'的抄表数据置为未导入吗?") == DialogResult.OK)
                {
                    try
                    {
                        string connectString =
                                        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
                                        //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
                        //string strSQLDelete = "DELETE FROM INTERDB WHERE recordid='" + objRecordID.ToString() + "'";
                        //int intRow = ExcuteSQL(strSQLDelete, connectString);
                        string strSQLUpdate = "UPDATE INTERDB SET ISDEAL='0' WHERE recordid='" + objRecordID.ToString() + "'";
                        int intRow = ExcuteSQL(strSQLUpdate, connectString);
                        if (intRow > 0)
                        {
                            dgList.CurrentRow.Cells["ISDEAL"].Value = "0";
                        }
                        else
                        {
                            mes.Show("置为未导入失败,请重新过滤后再执行操作!");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show("置为未导入失败,原因:" + ex.Message);
                        log.Write(ex.ToString(), MsgType.Error);
                        return;
                    }
                }
            }
        }

        private void bgWorkImportToMachine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btImport.Enabled = true;
        }

        private void 修改水表信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;
            string strWaterMeterTypeName = "", strWaterMeterTypeID = "", strWaterUserName = "", strSBH = "", strSYDS = "", strRecordID = "", strMeterReadingID = "";
            object obj = dgList.CurrentRow.Cells["RECORDID"].Value;
            if (obj != DBNull.Value && obj != null)
            {
                strRecordID = obj.ToString();
                obj = dgList.CurrentRow.Cells["yslbdm"].Value;
                if (obj != DBNull.Value && obj != null)
                {
                    strWaterMeterTypeID = obj.ToString();
                }
                obj = dgList.CurrentRow.Cells["YSLB"].Value;
                if (obj != DBNull.Value && obj != null)
                {
                    strWaterMeterTypeName = obj.ToString();
                }
                obj = dgList.CurrentRow.Cells["YHM"].Value;
                if (obj != DBNull.Value && obj != null)
                {
                    strWaterUserName = obj.ToString();
                }
                obj = dgList.CurrentRow.Cells["SBH"].Value;
                if (obj != DBNull.Value && obj != null)
                {
                    strSBH = obj.ToString();
                }
                obj = dgList.CurrentRow.Cells["SYDS"].Value;
                if (obj != DBNull.Value && obj != null)
                {
                    strSYDS = obj.ToString();
                }
                obj = dgList.CurrentRow.Cells["CBH"].Value;
                if (obj != DBNull.Value && obj != null)
                {
                    strMeterReadingID = obj.ToString();
                }
                frmWaterMeterCharge frm = new frmWaterMeterCharge();
                frm.strWaterMeterTypeID = strWaterMeterTypeID;
                frm.strWaterMeterTypeName = strWaterMeterTypeName;
                frm.strWaterUserName = strWaterUserName;
                frm.strSBH = strSBH;
                frm.strSYDS = strSYDS;
                frm.strRecordID = strRecordID;
                frm.strMeterReadingID = strMeterReadingID;
                //frm.frm = this;
                frm.ShowDialog();
            }
        }

        private void 修改用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;
            string strWaterUserNO = "", strWaterUserName = "", strRecordID = "",strMeterReadingID="";
            object obj = dgList.CurrentRow.Cells["RECORDID"].Value;
            if (obj != DBNull.Value && obj != null)
            {
                strRecordID = obj.ToString();
                obj = dgList.CurrentRow.Cells["YHM"].Value;
                if (obj != DBNull.Value && obj != null)
                {
                    strWaterUserName = obj.ToString();
                }
                obj = dgList.CurrentRow.Cells["YHDM"].Value;
                if (obj != DBNull.Value && obj != null)
                {
                    strWaterUserNO = obj.ToString();
                }
                obj = dgList.CurrentRow.Cells["CBH"].Value;
                if (obj != DBNull.Value && obj != null)
                {
                    strMeterReadingID = obj.ToString();
                }

                frmWaterUserCharge frm = new frmWaterUserCharge();
                frm.strWaterUserName = strWaterUserName;
                frm.strWaterUserNO = strWaterUserNO;
                frm.strRecordID = strRecordID;
                frm.strMeterReadingID = strMeterReadingID;
                //frm.frm = this;
                frm.ShowDialog();
            }
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //labExcute.Text = "";
        }

        private void bgWorkDownData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                btDownLoadData.Enabled = true;
        }

        private void dgExceptionData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "CBBZ")
            {
                if (e.Value != DBNull.Value && e.Value != null)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "未抄";
                        //dgList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    }
                    else if (e.Value.ToString() == "1")
                        e.Value = "已抄";
                }
                else
                    e.Value = "未抄";
            }

            if (dgList.Columns[e.ColumnIndex].Name == "dybz")
            {
                if (e.Value != DBNull.Value && e.Value != null)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "未收";
                        dgList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "已收";
                        dgList.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorDGDefault;
                    }
                }
                else
                    e.Value = "未收";
            }
        }

        private void dgExceptionData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
