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
    public partial class frmToMachineManageCustomData : Form
    {
        public frmToMachineManageCustomData()
        {
            InitializeComponent();
        }

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLAREA BLLAREA = new BLLAREA();
        GETTABLEID GETTABLEID = new GETTABLEID();

        #region 抄表机动态库相关
        /// <summary>
        /// 打开指定端口，并检测手持机是否连接在此端口上
        /// </summary>
        /// <param name="intPort">intPort为当前手持机所连接的串口，如1为串口一，2为串口二</param>
        /// <returns>成功   返回端口号（与PORT值相同），否则详见GetErrorMes</returns>
        [DllImport("hspos.dll")]
        private static extern int openport(int intPort);

        /// <summary>
        /// 关闭已打开的端口
        /// </summary>
        [DllImport("hspos.dll")]
        private static extern void closeport();

        /// <summary>
        /// 设置手持机日期和时间    
        /// </summary>
        /// <param name="intPort">手持机连接的端口</param>
        /// <returns>成功  返回0，否则详见GetErrorMes</returns>
        [DllImport("hspos.dll")]
        private static extern int downsystime(int intPort);

        /// <summary>
        /// 从指定的端口上传一个名为[filename]的手持机文件到PC  
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strFileName">为一字符串变量，因为手持机没有目录信息，因此[filename]不能包含文件路径</param>
        /// <returns>成功  返回0,失败  返回参数见错误列表</returns>
        [DllImport("hspos.dll")]
        private static extern int upfile(int intPort, StringBuilder strFileName);

        /// <summary>
        /// 从指定的端口上传机器编号字符串到PC
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strMachineNO">为一字符串变量,为返回的机器编号</param>
        /// <returns></returns>
        [DllImport("hspos.dll")]
        private static extern int getmno(int intPort, StringBuilder strMachineNO);

        /// <summary>
        /// 删除一个名为[filename]的手持机文件
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strFileName">为一字符串变量，因为手持机没有目录信息，因此[filename]不能包含文件路径</param>
        /// <returns>成功  返回0</returns>
        [DllImport("hspos.dll")]
        private static extern int deletefile(int intPort, StringBuilder strFileName);

        /// <summary>
        /// 下传并改名
        /// </summary>
        /// <param name="intPort">手持机连接的端口</param>
        /// <param name="strPCFileName">PC端文件名</param>
        /// <param name="strHandSetFileName">下载到手持机的文件名</param>
        /// <returns>成功  返回0</returns>
        [DllImport("hspos.dll")]
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
                    strErrorMes = "端口打开错误";
                    break;
            }
            return strErrorMes;
        }
        #endregion

        private bool isConnect = false;

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        private void frmMeterReadingMachineManage_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            DateTime dtNow = mes.GetDatetimeNow();
            txtYearAndMonth.Text = dtNow.ToString("yyyyMM");

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

            string[] strPorts = SerialPort.GetPortNames();
            foreach (string strPortName in strPorts)
            {
                cmbPort.Items.Add(strPortName);
            }
            if (cmbPort.Items.Count > 0)
                cmbPort.SelectedIndex = 0;
            GenerateTree();

            //for (int i = 0; i < dgList.Rows.Count; i++)
            //{
            //    if (dgList.Columns[i].Name != "checkCell")
            //        dgList.Columns[i].ReadOnly = true;
            //}

            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                //if (dgList.Columns[i].Name != "checkCell")
                //    dgList.Columns[i].ReadOnly = true;
                dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
            cmbChargerWorkName.DataSource = dt;
            cmbChargerWorkName.DisplayMember = "USERNAME";
            cmbChargerWorkName.ValueMember = "LOGINID";
        }

        /// <summary>
        /// 按抄表本、区域、抄表员动态生成抄表本树形结构
        /// </summary>
        private void GenerateTree()
        {
            trMeterReading.Nodes.Clear();

            #region 按抄表员生成抄表本树形结构
            TreeNode tnHeadMeterReader = trMeterReading.Nodes.Add("|无关ID|", "全部抄表员", 0, 1);
            DataTable dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是'");
            for (int i = 0; i < dtMeterReader.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object objID = dtMeterReader.Rows[i]["LOGINID"];
                if (objID != null && objID != DBNull.Value)
                {
                    strID = "METERREADER|无关ID| AND loginId='" + objID.ToString() + "'|" + objID.ToString();
                }
                object objName = dtMeterReader.Rows[i]["USERNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
                if (strID != "")
                {
                    DataTable dtMeterReaderMeterReading = BLLmeterReading.Query(" AND loginId='" + objID.ToString() + "'");
                    for (int j = 0; j < dtMeterReaderMeterReading.Rows.Count; j++)
                    {
                        string strMeterReadingID = "", strMeterReadingName = "";
                        object objMeterReadingID = dtMeterReaderMeterReading.Rows[j]["meterReadingID"];
                        if (objMeterReadingID != null && objMeterReadingID != DBNull.Value)
                        {
                            strMeterReadingID = "METERREADING|" + objMeterReadingID.ToString() + "| AND meterReadingID='" + objMeterReadingID.ToString() + "'";
                        }
                        object objMeterReadingName = dtMeterReaderMeterReading.Rows[j]["meterReadingNO"];
                        if (objMeterReadingName != null && objMeterReadingName != DBNull.Value)
                        {
                            strMeterReadingName = objMeterReadingName.ToString();
                        }
                        tnMeterReaderMeterReading.Nodes.Add(strMeterReadingID, strMeterReadingName, 0, 1);
                    }
                }
            }
            TreeNode tnNullMeterReading = tnHeadMeterReader.Nodes.Add("|无关ID| AND meterReadingID=''", "抄表员为空", 0, 1);
            #endregion
            tnHeadMeterReader.Expand();
            trMeterReading.SelectedNode = tnHeadMeterReader;
        }
        /// <summary>
        /// 是否是第一次打开窗体标志，如果是第一次打开窗体，不检索数据库中的数据，否则开始检索。
        /// </summary>
        bool isFirstOpen = true;
        private void trMeterReading_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isFirstOpen)
            {
                isFirstOpen = false;
                return;
            }
            if (e.Node == null)
                return;
            if (txtYearAndMonth.Text.Length != 6)
            {
                mes.Show("应抄月份格式不正确，请重新打开窗体获取正确月份!");
                return;
            }
            string strNodeID = e.Node.Name;
            string[] strNodeIDSpit = strNodeID.Split('|');
            cmbChargerWorkName.SelectedValue=strNodeID[3];

            RefreshData(strNodeIDSpit);
        }
        Thread TD;
        private void RefreshData(string[] strNodeID)
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                LoadData(strNodeID);

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                //mes.Show(ex.Message);
                log.Write("向抄表机导入数据界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("向抄表机导入数据界面:" + ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 存储所有查询到的数据
        /// </summary>
        DataTable dtList = new DataTable();

        /// <summary>
        /// 存储统计行信息
        /// </summary>
        DataTable dtClone = new DataTable();

        private void LoadData(string[] strNodeID)
        {
            try
            {
                string strFilter = strNodeID[2] + " AND meterReadingID IS NOT NULL AND readMeterRecordYear=" + txtYearAndMonth.Text.Substring(0, 4) + " AND readMeterRecordMonth=" + txtYearAndMonth.Text.Substring(4, 2);

                if (txtWaterUserNOSearch.Text.Trim() != "")
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.PadLeft(8, '0') + "'";

                if (txtWaterUserNameSearch.Text.Trim() != "")
                    strFilter += " AND waterUserName LIKE '%" + txtWaterUserNameSearch.Text + "%'";

                if (txtWaterMeterNO.Text.Trim() != "")
                    strFilter += " AND waterMeterNo='" + txtWaterMeterNO.Text.PadLeft(10, '0') + "'";

                if (txtWaterUserAddressS.Text.Trim() != "")
                    strFilter += " AND waterUserAddress LIKE '%" + txtWaterUserAddressS.Text + "%'";

                if (cmbIsMeterRead.SelectedIndex > 0)
                    strFilter += " AND chargeState='" + cmbIsMeterRead.SelectedIndex.ToString() + "'";

                strFilter += " ORDER BY loginId,meterReadingID,ordernumber";

                dtList = BLLreadMeterRecord.Query(strSeniorFilterHidden + strFilter);

                if (dtList.Rows.Count == 0)
                {
                    dgList.DataSource = null;
                    btImportToDBFFile.Enabled = false;
                }
                else
                {
                    dtClone = dtList.Clone();
                    DataRow drLast = dtClone.NewRow();
                    drLast["waterUserNO"] = "合计:";

                    //DataView dv = dtList.DefaultView;
                    //DataTable dtWaterUser = dv.ToTable(true, "waterUserId");//查询到的用户数量
                    //drLast["waterUserName"] = dtWaterUser.Rows.Count;

                    drLast["waterMeterNo"] = dtList.Rows.Count;//查询到的总行数

                    dtClone.Rows.Add(drLast);
                    ucPageSetUp1.InitialUC(this.dgList, dtList, dtClone);
                    btImportToDBFFile.Enabled = true;
                }
                labExcute.Text = "";
                labToDBFFileState.Text = "";
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
            }
        }
        /// <summary>
        /// 抄表机端口号
        /// </summary>
        int intMachinePort = 0;
        private void btConnect_Click(object sender, EventArgs e)
        {
            btConnect.Enabled = false;
            string strPort = cmbPort.Text;
            if (!strPort.ToUpper().Contains("COM"))
            {
                btConnect.Enabled = true;
                mes.Show("请输入正确的串口号!");
                return;
            }
            else
            {
                if (strPort.Substring(0, 3).ToUpper() != "COM")
                {
                    btConnect.Enabled = true;
                    mes.Show("请输入正确的串口号!");
                    return;
                }
                else
                {
                    strPort = strPort.Replace("COM", "");
                    if (!Information.IsNumeric(strPort))
                    {
                        btConnect.Enabled = true;
                        mes.Show("请输入正确的串口号!");
                        return;
                    }
                    else
                    {
                        intMachinePort = Convert.ToInt16(strPort);
                        int intReturn = openport(intMachinePort);
                        if (intReturn != intMachinePort)
                        {
                            btConnect.Enabled = true;
                            mes.Show(GetErrorMes(intReturn));
                            return;
                        }
                        else
                        {
                            btConnect.Enabled = false;
                            btClose.Enabled = true;
                            btImport.Enabled = true;
                        }
                    }
                }
            }
            //btConnect.Enabled = true;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            closeport();
            intMachinePort = 0;
            btClose.Enabled = false;
            btConnect.Enabled = true;
            btImport.Enabled = false;
        }
        private void btSetDateTime_Click(object sender, EventArgs e)
        {
            if (intMachinePort == 0)
            {
                mes.Show("请先连接抄表机!");
                return;
            }
            int intReturn = downsystime(intMachinePort);
            if (intReturn == 0)
            {
                mes.Show("时间同步成功!");
            }
            else
            {
                mes.Show(GetErrorMes(intReturn));
                return;
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
            //string strInsertSQL = "INSERT INTO INTERDB(SBH,YHDM,YHM,SFYE,CBH,YEHAO,YHLBDM,YHLB,QYDM,QY,CBYDM,CBY,DZ,DIANHUA,YSLBDM,YSLB,ZHUANGTAI,ZTDM,SYDS,"+
            //    "SYSL,BYDS,BYSL,SZYDJ,FJFDJ,SZYJE,FJFJE,BYJE,CBBZ,DYBZ,FPH,DYRQ,CBRQ,BWZH,BWZM,YSLBJTSJ,SBBZ3,FPHCZ,MONO) "+            
            //"VALUES(1,'','','','','','','','','','','','','','','','','','','','','','','','',"+
            //    "'','','','','','','','','','','','','')";

            string strInsertSQL = "INSERT INTO openrowset('MICROSOFT.JET.OLEDB.4.0','dBase III;database=" + strDBFPath + "','select * from [INTERDB.dbf]') " +
            " SELECT * FROM INTERDBF";
            //BLLmeterReading.ExcuteSQL(strInsertSQL);

            //string connectString =
            //                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
            //using (OleDbConnection connection = new OleDbConnection(connectString))
            //{
            //    DataSet ds = new DataSet();
            //    try
            //    {
            //        connection.Open();
            //        OleDbCommand command = new OleDbCommand(strInsertSQL, connection);
            //       int intI=command.ExecuteNonQuery();
            //       MessageBox.Show(intI.ToString());
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(string.Format("error:{0}", ex.Message));
            //    }
            //}  
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
                    break;
                case 1:
                    btPrevious.Enabled = true;
                    btNext.Enabled = false;
                    break;
            }
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode == null)
                return;
            TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
            trMeterReading_AfterSelect(null, ex);
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

        private void btImport_Click(object sender, EventArgs e)
        {
            btImport.Enabled = false;
            bgToHandSet.RunWorkerAsync();
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
        /// <summary>
        /// 查询抄表机数据文件
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
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
                    log.Write(ex.ToString(), MsgType.Error);
                }
                return ds.Tables[0];
            }
        }

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (dgList.Columns[e.ColumnIndex].Name == "avePrice")
            {
                object objTrapePrice = dgList.Rows[e.RowIndex].Cells["trapezoidPrice"].Value;
                if (objTrapePrice != null && objTrapePrice != DBNull.Value)
                {
                    string[] strTrapePrice = objTrapePrice.ToString().Split('|');
                    if (strTrapePrice[0].Split(':').Length > 0)
                        e.Value = strTrapePrice[0].Split(':')[1];
                }
            }

            if (dgList.Columns[e.ColumnIndex].Name == "extraChargePrice1")
            {
                object objWaterMeterTypeID = dgList.Rows[e.RowIndex].Cells["waterMeterTypeId"].Value;
                if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
                {
                    object objExtraFee = BLLWATERMETERTYPE.GetExtraCharge(" AND waterMeterTypeId='" + objWaterMeterTypeID.ToString() + "'");
                    if (objExtraFee != null && objExtraFee != DBNull.Value)
                    {
                        string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                        for (int j = 0; j < strAllExtraFee.Length; j++)
                        {
                            string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                            if (strSingleExtraFee[0].Contains("F"))
                            {
                                string strNum = strSingleExtraFee[0].Substring(1, 1);
                                //dgList.Columns["extraCharge" + strNum].Visible = true;
                                //dgList.Columns["extraChargePrice" + strNum].Visible = true;
                                if (strNum == "1")
                                {
                                    e.Value = strSingleExtraFee[1];
                                    break; 
                                }
                                //dgList.Rows[i].Cells["extraChargetype" + strNum].Value = strSingleExtraFee[2];//附加费计算方式
                            }
                        }
                    }
                }
            }

            if (dgList.Columns[e.ColumnIndex].Name == "extraChargePrice2")
            {
                object objWaterMeterTypeID = dgList.Rows[e.RowIndex].Cells["waterMeterTypeId"].Value;
                if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
                {
                    object objExtraFee = BLLWATERMETERTYPE.GetExtraCharge(" AND waterMeterTypeId='" + objWaterMeterTypeID.ToString() + "'");
                    if (objExtraFee != null && objExtraFee != DBNull.Value)
                    {
                        string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                        for (int j = 0; j < strAllExtraFee.Length; j++)
                        {
                            string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                            if (strSingleExtraFee[0].Contains("F"))
                            {
                                string strNum = strSingleExtraFee[0].Substring(1, 1);
                                //dgList.Columns["extraCharge" + strNum].Visible = true;
                                //dgList.Columns["extraChargePrice" + strNum].Visible = true;
                                if (strNum == "2")
                                {
                                    e.Value = strSingleExtraFee[1];
                                    break;
                                }
                                //dgList.Rows[i].Cells["extraChargetype" + strNum].Value = strSingleExtraFee[2];//附加费计算方式
                            }
                        }
                    }
                }
            }

            if (dgList.Columns[e.ColumnIndex].Name == "totalNumber")
            {

                //定量用水情况，直接将用水量置为固定水量。
                object objWaterFixValue = dgList.Rows[e.RowIndex].Cells["WATERFIXVALUE"].Value;
                if (Information.IsNumeric(objWaterFixValue))
                {
                    if (Convert.ToInt32(objWaterFixValue) > 0)
                    {
                        e.Value = objWaterFixValue.ToString();
                    }
                }
            }

            if (dgList.Columns[e.ColumnIndex].Name == "isSummaryMeter")
            {
                if (e.Value != DBNull.Value && e.Value != null)
                {
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "分表";
                    }
                    else if (e.Value.ToString() == "2")
                    {
                        e.Value = "总表";
                    }
                }
                else
                    e.Value = "分表";
            }
            if (dgList.Columns[e.ColumnIndex].Name == "chargeState")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "已抄表";
                    }
                    else if (e.Value.ToString() == "0")
                        e.Value = "未抄表";
                    else if (e.Value.ToString() == "2")
                        e.Value = "已预收";
                    else if (e.Value.ToString() == "3")
                        e.Value = "已收费";
            }
        }

        private void btReFresh_Click(object sender, EventArgs e)
        {
            cmbPort.Items.Clear();
            string[] strPorts = SerialPort.GetPortNames();
            foreach (string strPortName in strPorts)
            {
                cmbPort.Items.Add(strPortName);
            }
            if (cmbPort.Items.Count > 0)
                cmbPort.SelectedIndex = 0;
        }

        private void frmToMachineManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeport();
            if (bgWork.IsBusy)
                bgWork.CancelAsync();
            if (bgToHandSet.IsBusy)
                bgToHandSet.CancelAsync();
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (dtList.Rows.Count == 0)
                {
                    mes.Show("数据列表为空,无法导入数据!");
                    return;
                }

                if (File.Exists(strDBFPath + @"Model\INTERDB.DBF"))
                {
                    DialogResult dresult = mes.ShowQuestion("系统检测到数据文件已存在，是否重新生成数据文件?");
                    if (dresult == DialogResult.Yes)
                    {
                        //用户选择’是‘按钮
                        File.Copy(strDBFPath + @"Model\INTERDB.DBF", strDBFPath + "INTERDB.DBF", true);
                    }
                    else if (dresult == DialogResult.No)
                    {
                        //用户选择’否‘按钮

                    }
                    else
                        return;   //用户选择’取消‘按钮
                }

                //抄表机数据库连接字符串
                string connectString =
                                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";

                btImport.Enabled = false;
                labExcute.Text = "正在执行....";
                DateTime dtNow = mes.GetDatetimeNow();
                if (dtList.Rows.Count == 0)
                {
                    mes.Show("未检测到要导入的抄表数据，请先查询导入的抄表数据!");
                    btImport.Enabled = true;
                    labExcute.Text = "";
                    return;
                }
                int intSuccessCount = 0;
                for (int i = 0; i < dtList.Rows.Count; i++)
                {
                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                    object objRecordID = dtList.Rows[i]["readMeterRecordId"];
                    if (objRecordID != null && objRecordID != DBNull.Value)
                    {
                        MODELreadMeterRecord.readMeterRecordId = objRecordID.ToString();

                        object objRecordData = dtList.Rows[i]["waterMeterNo"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterMeterNo = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["waterUserNO"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterUserNO = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["waterUserName"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterUserName = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["meterReadingID"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.meterReadingID = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["meterReadingNO"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.meterReadingNO = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["meterReadingPageNo"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.meterReadingPageNo = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["waterUserTypeId"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterUserTypeId = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["waterUserTypeName"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterUserTypeName = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["meterReaderID"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.meterReaderID = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["meterReaderName"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.meterReaderName = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["chargerID"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.chargerID = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["chargerName"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.chargerName = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["waterUserAddress"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterUserAddress = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["waterPhone"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterPhone = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["waterMeterTypeId"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterMeterTypeId = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["waterMeterTypeName"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterMeterTypeName = objRecordData.ToString();
                        }

                        object objSQDS = dtList.Rows[i]["waterMeterLastNumber"];
                        if (Information.IsNumeric(objSQDS))
                            MODELreadMeterRecord.waterMeterLastNumber = Convert.ToInt32(objSQDS);

                        object objBQDS = dtList.Rows[i]["waterMeterEndNumber"];
                        if (Information.IsNumeric(objBQDS))
                            MODELreadMeterRecord.waterMeterEndNumber = Convert.ToInt32(objBQDS);

                        objRecordData = dtList.Rows[i]["avePrice"];
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.avePrice = Convert.ToDecimal(objRecordData);
                        }

                        objRecordData = dtList.Rows[i]["extraChargePrice1"];
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.extraChargePrice1 = Convert.ToDecimal(objRecordData);
                        }

                        objRecordData = dtList.Rows[i]["extraChargePrice2"];
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.extraChargePrice2 = Convert.ToDecimal(objRecordData);
                        }

                        objRecordData = dtList.Rows[i]["waterMeterPositionName"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterMeterPositionName = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["WATERFIXVALUE"];
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.WATERFIXVALUE = Convert.ToInt32(objRecordData);
                        }

                        objRecordData = dtList.Rows[i]["totalNumber"];
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.totalNumber = Convert.ToInt32(objRecordData);
                        }

                        objRecordData = dtList.Rows[i]["ordernumber"];
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.ordernumber = Convert.ToInt32(objRecordData);
                        }

                        objRecordData = dtList.Rows[i]["isSummaryMeter"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            if (objRecordData.ToString() == "1")
                            {
                                MODELreadMeterRecord.isSummaryMeter = "1";
                            }
                            else
                                MODELreadMeterRecord.isSummaryMeter = "0";
                        }
                        object objParentId = dtList.Rows[i]["waterMeterParentId"];
                        if (objParentId != null && objParentId != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterMeterParentId = objParentId.ToString();
                        }

                        objRecordData = dtList.Rows[i]["lastNumberYearMonth"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.lastNumberYearMonth = objRecordData.ToString();
                        }

                        string strYCYear = "", strYCMonth = "";

                        objRecordData = dtList.Rows[i]["readMeterRecordYear"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            strYCYear = objRecordData.ToString();
                        }

                        objRecordData = dtList.Rows[i]["readMeterRecordMonth"];
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            strYCMonth = objRecordData.ToString().PadLeft(2, '0');
                        }
                        string strDYBZ = "0", strCBBZ = "0";
                        object objCheckState = dtList.Rows[i]["checkState"];
                        if (objCheckState != null && objCheckState != DBNull.Value)
                        {
                            if (objCheckState.ToString() == "1")
                                strCBBZ = "1";
                        }
                        object objChargeState = dtList.Rows[i]["chargeState"];
                        if (objChargeState != null && objChargeState != DBNull.Value)
                        {
                            if (objChargeState.ToString() == "3")
                                strDYBZ = "1";
                        }
                        //检测抄表流水号是否存在，如果存在提示
                        string strSQLQuery = "SELECT * FROM INTERDB WHERE recordid='" + MODELreadMeterRecord.readMeterRecordId + "'";
                        DataTable dt = GetHandSetData(strSQLQuery);
                        if (dt.Rows.Count > 0)
                        {
                            DialogResult drResult=mes.ShowQuestion("水表" + MODELreadMeterRecord.waterUserNO + "-" + MODELreadMeterRecord.waterMeterNo + "的抄表流水号在数据文件中已经存在,是否跳过?");
                            if (drResult == DialogResult.Yes)
                                continue;
                            else if (drResult == DialogResult.No)
                            {

                            }
                            else
                                return;
                        }

                        string strSQLInsert = "INSERT INTO INTERDB" +
                            "(recordid,SBH,YHDM,yhm,sfye,cbh,yehao,yhlbdm,yhlb,qydm,qy,cbydm,cby,dz,dianhua,yslbdm,yslb,zhuangtai,ztdm,syds,szydj," +
                            "fjfdj,cbbz,dybz,bwzm,sbbz3,fjfdj1,dlys,bysl,cbsx,sqdsyf,iszongbiao,zongbiaoid,ycyf,cbbdm,isdeal) " +
                            "VALUES('" + MODELreadMeterRecord.readMeterRecordId + "','" + MODELreadMeterRecord.waterMeterNo + "','" +
                            MODELreadMeterRecord.waterUserNO + "','" + MODELreadMeterRecord.waterUserName + "','0','" +
                             MODELreadMeterRecord.meterReadingNO + "','" + MODELreadMeterRecord.meterReadingPageNo + "','" + MODELreadMeterRecord.waterUserTypeId + "','" +
                             MODELreadMeterRecord.waterUserTypeName + "','" + MODELreadMeterRecord.meterReaderID + "','" + MODELreadMeterRecord.meterReaderName + "','" +
                            MODELreadMeterRecord.chargerID + "','" + MODELreadMeterRecord.chargerName + "','" + MODELreadMeterRecord.waterUserAddress + "','" +
                            MODELreadMeterRecord.waterPhone + "','" + MODELreadMeterRecord.waterMeterTypeId + "','" + MODELreadMeterRecord.waterMeterTypeName + "','正常','1'," +
                            MODELreadMeterRecord.waterMeterLastNumber + "," + MODELreadMeterRecord.avePrice + "," + MODELreadMeterRecord.extraChargePrice1 +
                            "," + strCBBZ + "," + strDYBZ + ",'" +
                            MODELreadMeterRecord.waterMeterPositionName + "',1," + MODELreadMeterRecord.extraChargePrice2 + "," + MODELreadMeterRecord.WATERFIXVALUE +
                            "," + MODELreadMeterRecord.totalNumber + "," + MODELreadMeterRecord.ordernumber + ",'" + MODELreadMeterRecord.lastNumberYearMonth +
                            "','" + MODELreadMeterRecord.isSummaryMeter + "','" + MODELreadMeterRecord.waterMeterParentId + "','" + strYCYear + strYCMonth + "','" + MODELreadMeterRecord.meterReadingID + "','0')";

                        int intRow = ExcuteSQL(strSQLInsert, connectString);
                        if (intRow == 1)
                        {
                            intSuccessCount++;
                            labToDBFFileState.Text = "导入文件:" + intSuccessCount.ToString() + "条数据";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //labExcute.Text = "";
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                //btImport.Enabled = true;
                return;
            }
        }
        private void btRight_Click(object sender, EventArgs e)
        {
            if (txtYearAndMonth.Text.Length != 6)
            {
                mes.Show("系统检测到月份格式不正确,请重新打开窗体!");
                return;
            }
            string strDate = txtYearAndMonth.Text.Substring(0, 4) + "-" + txtYearAndMonth.Text.Substring(4, 2) + "-" + "01";
            if (Information.IsDate(strDate))
            {
                txtYearAndMonth.Text = Convert.ToDateTime(strDate).AddMonths(1).ToString("yyyyMM");
            }
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            if (txtYearAndMonth.Text.Length != 6)
            {
                mes.Show("系统检测到月份格式不正确,请重新打开窗体!");
                return;
            }
            string strDate = txtYearAndMonth.Text.Substring(0, 4) + "-" + txtYearAndMonth.Text.Substring(4, 2) + "-" + "01";
            if (Information.IsDate(strDate))
            {
                txtYearAndMonth.Text = Convert.ToDateTime(strDate).AddMonths(-1).ToString("yyyyMM");
            }
        }

        private void txtYearAndMonth_TextChanged(object sender, EventArgs e)
        {

        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel2.Enabled = true;
            trMeterReading.Enabled = true;
            btImportToDBFFile.Enabled = true;
            labExcute.Text = "";
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "2";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode != null)
            {
                TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
                trMeterReading_AfterSelect(null, ex);
            }
        }

        private void btImportToDBFFile_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            trMeterReading.Enabled = false;
            btImportToDBFFile.Enabled = false;

            bgWork.RunWorkerAsync();
        }

        private void bgToHandSet_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                labExcute.Text = "正在清空原有抄表机数据...";
                StringBuilder strFileName = new StringBuilder();
                strFileName.Append("INTERDB.DBF");
                int intReturn = deletefile(intMachinePort, strFileName);
                if (intReturn == 0)
                {
                    labExcute.Text = "正在写入抄表机...";

                    StringBuilder strPCFileName = new StringBuilder();
                    strPCFileName.Append(strDBFPath + "INTERDB.DBF");
                    intReturn = downtofile(intMachinePort, strPCFileName, strFileName);
                    if (intReturn == 0)
                    {
                        labExcute.Text = "导入抄表机命令执行完毕";
                        btImport.Enabled = true;
                    }
                    else
                    {
                        btImport.Enabled = true;
                        mes.Show(GetErrorMes(intReturn));
                        labExcute.Text = "";
                        return;
                    }
                }
                else
                {
                    btImport.Enabled = true;
                    mes.Show(GetErrorMes(intReturn));
                    labExcute.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                //btImport.Enabled = true;
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
            }
        }

        private void bgToHandSet_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btImport.Enabled = true;
        }
    }
}
