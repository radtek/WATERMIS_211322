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
    public partial class frmToMachineManage : Form
    {
        public frmToMachineManage()
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
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        GETTABLEID GETTABLEID = new GETTABLEID();

        BLLNullReadReasonMemo BLLNullReadReasonMemo = new BLLNullReadReasonMemo();

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

        [DllImport("hspos.dll")]
        private static extern int up_userinfo(int intPort, StringBuilder strMeterReaderNO, StringBuilder strMeterReaderName);

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

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
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
            DataTable dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是' ORDER BY USERNAME");
            for (int i = 0; i < dtMeterReader.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object objID = dtMeterReader.Rows[i]["LOGINID"];
                if (objID != null && objID != DBNull.Value)
                {
                    strID = "METERREADER|无关ID| AND meterReaderID='" + objID.ToString() + "'|" + objID.ToString();
                }
                object objName = dtMeterReader.Rows[i]["USERNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
                //if (strID != "")
                //{
                //    DataTable dtMeterReaderMeterReading = BLLmeterReading.Query(" AND loginId='" + objID.ToString() + "'");
                //    for (int j = 0; j < dtMeterReaderMeterReading.Rows.Count; j++)
                //    {
                //        string strMeterReadingID = "", strMeterReadingName = "";
                //        object objMeterReadingID = dtMeterReaderMeterReading.Rows[j]["meterReadingID"];
                //        if (objMeterReadingID != null && objMeterReadingID != DBNull.Value)
                //        {
                //            strMeterReadingID = "METERREADING|" + objMeterReadingID.ToString() + "| AND meterReadingID='" + objMeterReadingID.ToString() + "'";
                //        }
                //        object objMeterReadingName = dtMeterReaderMeterReading.Rows[j]["meterReadingNO"];
                //        if (objMeterReadingName != null && objMeterReadingName != DBNull.Value)
                //        {
                //            strMeterReadingName = objMeterReadingName.ToString();
                //        }
                //        tnMeterReaderMeterReading.Nodes.Add(strMeterReadingID, strMeterReadingName, 0, 1);
                //    }
                //}
            }
            //TreeNode tnNullMeterReading = tnHeadMeterReader.Nodes.Add("|无关ID| AND meterReaderID=''", "抄表员为空", 0, 1);
            #endregion
            tnHeadMeterReader.Expand();
            trMeterReading.SelectedNode = tnHeadMeterReader;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode != null)
            {
                TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
                trMeterReading_AfterSelect(null, ex);
            }
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
            cmbChargerWorkName.SelectedValue = strNodeID[3];
            RefreshData(strNodeIDSpit);

            //try
            //{
            //    frmWaiting.Show(this,true);
            //    LoadData(strNodeIDSpit);
            //}
            //catch (Exception ex)
            //{
            //    mes.Show(ex.Message);
            //    log.Write("向抄表机导入数据界面:" + ex.ToString(), MsgType.Error);
            //}
            //finally
            //{
            //    frmWaiting.Hide(this);
            //}
        }
        Thread TD;
        private void RefreshData(string[] strNodeID)
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                LoadData(strNodeID);
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                //mes.Show(ex.Message);
                log.Write("向抄表机导入数据界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("向抄表机导入数据界面:" + ex.ToString(), MsgType.Error);
            }
        }

        private void LoadData(string[] strNodeID)
        {
            string strYear = txtYearAndMonth.Text.Substring(0, 4), strMonth = txtYearAndMonth.Text.Substring(4, 2);
            DateTime dtSearchDate =DateTime.Now;
            try
            {
                dtSearchDate = new DateTime(Convert.ToInt16(strYear), Convert.ToInt16(strMonth), 1);
            }
            catch (Exception ex)
            {
                log.Write(ex.ToString(),MsgType.Error);
            }
            string strFilter = " AND checkState='0' AND chargeState='0' AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtSearchDate + "')=0 ";

            if (txtWaterUserNOSearch.Text.Trim() != "")
                if (txtWaterUserNOSearch.Text.Length > 5)
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim() + "'";
                else
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.Trim().PadLeft(5, '0') + "'";

            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
            if (cmbPianNOS.SelectedIndex > 0)
                strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";
            DataTable dtUserList = BLLreadMeterRecord.Query(strNodeID[2] + strFilter                
                + strSeniorFilterHidden + " ORDER BY pianNO,areaNO,duanNO,ordernumber");

            dgList.DataSource = dtUserList;

            labTip.Text = "共" + dtUserList.Rows.Count + "条数据";
            labExcute.Text = "";

            ////if (dgList.Rows.Count == 0)
            ////{
            ////    btImport.Enabled = false;
            ////}
            ////else
            ////{
            ////    btImport.Enabled = true;
            ////}

            //for (int i = 0; i < dgList.Rows.Count; i++)
            //{
            //    object objWaterMeterTypeID = dgList.Rows[i].Cells["waterMeterTypeId"].Value;
            //    if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
            //    {
            //        object objExtraFee = BLLWATERMETERTYPE.GetExtraCharge(" AND waterMeterTypeId='" + objWaterMeterTypeID.ToString() + "'");
            //        if (objExtraFee != null && objExtraFee != DBNull.Value)
            //        {
            //            string[] strAllExtraFee = objExtraFee.ToString().Split('|');
            //            for (int j = 0; j < strAllExtraFee.Length; j++)
            //            {
            //                string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
            //                if (strSingleExtraFee[0].Contains("F"))
            //                {
            //                    string strNum = strSingleExtraFee[0].Substring(1, 1);
            //                    //dgList.Columns["extraCharge" + strNum].Visible = true;
            //                    //dgList.Columns["extraChargePrice" + strNum].Visible = true;
            //                    dgList.Rows[i].Cells["extraChargePrice" + strNum].Value = strSingleExtraFee[1];
            //                    //dgList.Rows[i].Cells["extraChargetype" + strNum].Value = strSingleExtraFee[2];//附加费计算方式
            //                }
            //            }
            //        }
            //    }

            //    //定量用水情况，直接将用水量置为固定水量。
            //    object objWaterFixValue = dgList.Rows[i].Cells["WATERFIXVALUE"].Value;
            //    if (Information.IsNumeric(objWaterFixValue))
            //    {
            //        if (Convert.ToInt32(objWaterFixValue) > 0)
            //        {
            //            dgList.Rows[i].Cells["totalNumber"].Value = objWaterFixValue.ToString();
            //        }
            //    }

            //    //if (Convert.ToDecimal(dgList.Rows[i].Cells["extraChargePrice1"].Value) > 0)
            //    //{
            //    //    dgList.Columns["extraChargePrice1"].Visible = true;
            //    //    //dgList.Columns["extraCharge1"].Visible = true;
            //    //}

            //    //if (Convert.ToDecimal(dgList.Rows[i].Cells["extraChargePrice2"].Value) > 0)
            //    //{
            //    //    dgList.Columns["extraChargePrice2"].Visible = true;
            //    //    //dgList.Columns["extraCharge2"].Visible = true;
            //    //}

            //    //if (Convert.ToDecimal(dgList.Rows[i].Cells["extraChargePrice3"].Value) > 0)
            //    //{
            //    //    dgList.Columns["extraChargePrice3"].Visible = true;
            //    //    dgList.Columns["extraCharge3"].Visible = true;
            //    //}

            //    //if (Convert.ToDecimal(dgList.Rows[i].Cells["extraChargePrice4"].Value) > 0)
            //    //{
            //    //    dgList.Columns["extraChargePrice4"].Visible = true;
            //    //    dgList.Columns["extraCharge4"].Visible = true;
            //    //}

            //    //if (Convert.ToDecimal(dgList.Rows[i].Cells["extraChargePrice5"].Value) > 0)
            //    //{
            //    //    dgList.Columns["extraChargePrice5"].Visible = true;
            //    //    dgList.Columns["extraCharge5"].Visible = true;
            //    //}

            //    //if (Convert.ToDecimal(dgList.Rows[i].Cells["extraChargePrice6"].Value) > 0)
            //    //{
            //    //    dgList.Columns["extraChargePrice6"].Visible = true;
            //    //    dgList.Columns["extraCharge6"].Visible = true;
            //    //}

            //    //if (Convert.ToDecimal(dgList.Rows[i].Cells["extraChargePrice7"].Value) > 0)
            //    //{
            //    //    dgList.Columns["extraChargePrice7"].Visible = true;
            //    //    dgList.Columns["extraCharge7"].Visible = true;
            //    //}

            //    //if (Convert.ToDecimal(dgList.Rows[i].Cells["extraChargePrice8"].Value) > 0)
            //    //{
            //    //    dgList.Columns["extraChargePrice8"].Visible = true;
            //    //    dgList.Columns["extraCharge8"].Visible = true;
            //    //}
            //}
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
                }
                return ds.Tables[0];
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
                            btImportReason.Enabled = true;
                            btImportFile.Enabled = true;
                            btSetDateTime.Enabled = true;
                        }
                    }
                }
            }
            //btConnect.Enabled = true;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            closeport();
            if (bgWork.IsBusy)
            {
                bgWork.CancelAsync();
            }
            intMachinePort = 0;
            btClose.Enabled = false;
            btConnect.Enabled = true;
            btImport.Enabled = false;
            btImportReason.Enabled = false;
            btImportFile.Enabled = false;
            btSetDateTime.Enabled = false;

            panel2.Enabled = true;
            trMeterReading.Enabled = true;
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
            if (bgWork.IsBusy)
            {
                bgWork.CancelAsync();
                mes.Show("上次导入任务未结束，请重新打开窗体再操作!");
                return;
            }
            if (dgList.Rows.Count == 0)
            {
                mes.Show("数据列表为空,无法导入数据!");
                return;
            }
            if (mes.ShowQ("执行此操作会将现有的抄表机数据覆盖，确定要执行此操作吗?") != DialogResult.OK)
                return;

            panel2.Enabled = false;
            trMeterReading.Enabled = false;

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
        }

        /// <summary>
        /// 导入过程中的错误信息
        /// </summary>
        string strErrorMes = "";

        ///// <summary>
        ///// 导入抄表机是否顺利完成标志
        ///// </summary>
        //bool isSucess = false;

        /// <summary>
        /// 成功导入的条数
        /// </summary>
        int intSuccessCount = 0;
        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                strErrorMes = "";
                //isSucess = false;
                intSuccessCount = 0;

                //抄表机数据库连接字符串
                string connectString =
                                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";

                btImport.Enabled = false;
                labExcute.Text = "正在执行....";
                DateTime dtNow = mes.GetDatetimeNow();

                labExcute.Text = "正在备份原有抄表机数据...";
                string strDateTimeNow = mes.GetDatetimeNow().ToString("yyyyMMddHHmmss");
                StringBuilder strFileName = new StringBuilder();
                strFileName.Append("INTERDB.DBF");

                int intReturn = upfile(intMachinePort, strFileName);
                if (intReturn == 0)
                {
                    string strDownLoadFileName = Application.StartupPath + @"\INTERDB.DBF";

                    //获取机器编号，根据机器编号及时间备份导出的抄表机数据 
                    StringBuilder strMeterReaderNO = new StringBuilder(), strMeterReaderName = new StringBuilder();
                    int intReturnMachineNO = up_userinfo(intMachinePort, strMeterReaderNO, strMeterReaderName);
                    if (intReturnMachineNO != 0)
                    {
                        strErrorMes = "获取抄表机编号失败!错误信息:" + GetErrorMes(intReturnMachineNO);
                    }
                    string strFileNameBak = "INTERDB" + strDateTimeNow + "_" + strMeterReaderNO + "_" + strMeterReaderName + ".DBF";
                    string strNewFileNameBak = Application.StartupPath + @"\HndSet\Bak\INTERDB" + strDateTimeNow + "_" + strMeterReaderNO + "_" + strMeterReaderName + ".DBF";
                    //if (strMeterReaderNO.ToString() != "")
                    //    strNewFileNameBak = Application.StartupPath + @"\HndSet\Bak\INTERDB" + strDateTimeNow + "_" + strMachineNO + ".DBF";
                    //else
                    //    strNewFileNameBak = Application.StartupPath + @"\HndSet\Bak\INTERDB" + strDateTimeNow + ".DBF";

                    if (File.Exists(strDownLoadFileName))
                    {
                        File.Copy(strDownLoadFileName, strNewFileNameBak, true);
                        File.Delete(strDownLoadFileName);
                        labExcute.Text = "文件备份名为'" + strFileNameBak + "'";
                    }
                    else
                    {
                        strErrorMes = "未找到需要备份的抄表机数据文件!";
                    }
                }

                if (File.Exists(strDBFPath + @"Model\INTERDB.DBF"))
                    File.Copy(strDBFPath + @"Model\INTERDB.DBF", strDBFPath + "INTERDB.DBF", true);
                else
                {
                    labExcute.Text = "模板文件不存在,无法生成抄表数据!";
                    strErrorMes = "模板文件不存在,无法生成抄表数据!";
                    btImport.Enabled = true;
                    return;
                }
                for (int i = 0; i < dgList.Rows.Count; i++)
                {
                    if (bgWork.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                    object objRecordID = dgList.Rows[i].Cells["readMeterRecordId"].Value;
                    if (objRecordID != null && objRecordID != DBNull.Value)
                    {
                        MODELreadMeterRecord.readMeterRecordId = objRecordID.ToString();

                        object objRecordData = dgList.Rows[i].Cells["waterMeterNo"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterMeterNo = objRecordData.ToString();
                        }

                        objRecordData = dgList.Rows[i].Cells["waterUserNO"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterUserNO = objRecordData.ToString();
                        }

                        objRecordData = dgList.Rows[i].Cells["waterUserName"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterUserName = objRecordData.ToString();
                        }

                        objRecordData = dgList.Rows[i].Cells["pianNO"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.pianNO = objRecordData.ToString();
                        }

                        objRecordData = dgList.Rows[i].Cells["areaNO"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.areaNO = objRecordData.ToString();
                        }

                        objRecordData = dgList.Rows[i].Cells["duanNO"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.duanNO = objRecordData.ToString();
                        }

                        objRecordData = dgList.Rows[i].Cells["meterReaderName"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.meterReaderName = objRecordData.ToString();
                        }

                        objRecordData = dgList.Rows[i].Cells["waterUserAddress"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterUserAddress = objRecordData.ToString();
                        }

                        objRecordData = dgList.Rows[i].Cells["waterUserPeopleCount"].Value;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.waterUserPeopleCount = Convert.ToInt16(objRecordData);
                        }

                        string strPhone = "";

                        objRecordData = dgList.Rows[i].Cells["waterUserTelphoneNO"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterPhone = objRecordData.ToString();
                            strPhone = MODELreadMeterRecord.waterPhone;
                        }
                        objRecordData = dgList.Rows[i].Cells["waterPhone"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterPhone = objRecordData.ToString();
                            if (strPhone == "")
                            {
                                strPhone = MODELreadMeterRecord.waterPhone;
                            }
                            else
                                strPhone = strPhone + " " + MODELreadMeterRecord.waterPhone;

                        }
                        if (strPhone.Length > 28)
                            strPhone = strPhone.Substring(0, 28);

                        MODELreadMeterRecord.waterMeterSerialNumber = "";
                        objRecordData = dgList.Rows[i].Cells["waterMeterSerialNumber"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterMeterSerialNumber = objRecordData.ToString();
                        }
                        string[] strWaterMeterSerialNumber = MODELreadMeterRecord.waterMeterSerialNumber.Split('/');
                        strWaterMeterSerialNumber[0] = strWaterMeterSerialNumber[0].Replace(" ", "");
                        if (strWaterMeterSerialNumber[0].Length > 12)
                            strWaterMeterSerialNumber[0] = strWaterMeterSerialNumber[0].Substring(0, 12);
                        if (strWaterMeterSerialNumber.Length > 1)
                        {
                            strWaterMeterSerialNumber[1] = strWaterMeterSerialNumber[1].Replace(" ", "");
                            if (strWaterMeterSerialNumber[1].Length > 12)
                                strWaterMeterSerialNumber[1] = strWaterMeterSerialNumber[1].Substring(0, 12);
                        }

                        MODELreadMeterRecord.IsReverse = "0";
                        objRecordData = dgList.Rows[i].Cells["IsReverse"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.IsReverse = objRecordData.ToString();
                        }
                        MODELreadMeterRecord.waterMeterLastNumber = 0;
                        object objBYDS = dgList.Rows[i].Cells["waterMeterLastNumber"].Value;
                        if (Information.IsNumeric(objBYDS))
                            MODELreadMeterRecord.waterMeterLastNumber = Convert.ToInt32(objBYDS);

                        //默认本期读数等于上月读数
                        MODELreadMeterRecord.waterMeterEndNumber = MODELreadMeterRecord.waterMeterLastNumber;

                        MODELreadMeterRecord.isTrapeZoid = 0;
                        MODELreadMeterRecord.avePrice = 0;
                        MODELreadMeterRecord.TrapeZoid1 = "6";
                        MODELreadMeterRecord.TrapeZoid2 = "8";
                        MODELreadMeterRecord.TrapeZoid3 = "8";
                        MODELreadMeterRecord.TrapeZoidPrice1 = "2";
                        MODELreadMeterRecord.TrapeZoidPrice2 = "4";
                        MODELreadMeterRecord.TrapeZoidPrice3 = "6";

                        objRecordData = dgList.Rows[i].Cells["trapezoidPrice"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            string strTrapezoidPrice = objRecordData.ToString();
                            string[] strPrice = strTrapezoidPrice.Split('|');
                            if (strPrice.Length <= 1)
                            {
                                MODELreadMeterRecord.isTrapeZoid = 0;
                                MODELreadMeterRecord.avePrice = Convert.ToDecimal(strPrice[0].Split(':')[1]);
                            }
                            else
                            {
                                MODELreadMeterRecord.isTrapeZoid = 1;
                                MODELreadMeterRecord.TrapeZoid1 = strPrice[0].Split(':')[0].Split('-')[1];
                                MODELreadMeterRecord.TrapeZoid2 = strPrice[1].Split(':')[0].Split('-')[1];
                                MODELreadMeterRecord.TrapeZoid3 = strPrice[2].Split(':')[0].Split('-')[0];
                                MODELreadMeterRecord.TrapeZoidPrice1 = strPrice[0].Split(':')[1];
                                MODELreadMeterRecord.TrapeZoidPrice2 = strPrice[1].Split(':')[1];
                                MODELreadMeterRecord.TrapeZoidPrice3 = strPrice[2].Split(':')[1];
                            }
                        }


                        MODELreadMeterRecord.extraChargePrice1 = 0;
                        objRecordData = dgList.Rows[i].Cells["extraChargePrice1"].FormattedValue;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.extraChargePrice1 = Convert.ToDecimal(objRecordData);
                        }

                        MODELreadMeterRecord.extraChargePrice2 = 0;
                        objRecordData = dgList.Rows[i].Cells["extraChargePrice2"].FormattedValue;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.extraChargePrice2 = Convert.ToDecimal(objRecordData);
                        }
                        MODELreadMeterRecord.totalNumber = 0;
                        objRecordData = dgList.Rows[i].Cells["totalNumber"].FormattedValue;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.totalNumber = Convert.ToInt32(objRecordData);
                        }

                        objRecordData = dgList.Rows[i].Cells["ordernumber"].FormattedValue;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.ordernumber = Convert.ToInt32(objRecordData);
                        }

                        //计算未抄月数，如果有上次抄表时间，相减即可，如果没有获取该用户第一次初始化的时间，作为首次抄表时间 
                        objRecordData = dgList.Rows[i].Cells["readMeterRecordYearAndMonth"].Value;
                        if (Information.IsDate(objRecordData))
                        {
                            MODELreadMeterRecord.readMeterRecordYearAndMonth = Convert.ToDateTime(objRecordData);
                            dtNow = MODELreadMeterRecord.readMeterRecordYearAndMonth;
                        }
                        MODELreadMeterRecord.WCYS = 1;
                        objRecordData = dgList.Rows[i].Cells["lastNumberYearMonth"].FormattedValue;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.lastNumberYearMonth = objRecordData.ToString();
                        }
                        if (MODELreadMeterRecord.lastNumberYearMonth.Length == 6)
                        {
                            string strLastYearAndMonth = MODELreadMeterRecord.lastNumberYearMonth.Substring(0, 4) + "-" + MODELreadMeterRecord.lastNumberYearMonth.Substring(4, 2) + "-" + "01";
                            DateTime dtLastYearAndMonth = Convert.ToDateTime(strLastYearAndMonth);
                            MODELreadMeterRecord.readMeterRecordDate = dtLastYearAndMonth;
                            MODELreadMeterRecord.WCYS = dtNow.Year * 12 + dtNow.Month - dtLastYearAndMonth.Year * 12 - dtLastYearAndMonth.Month;
                        }
                        else
                        {
                            string strSQLGetInitialMonth = "SELECT TOP 1  initialReadMeterMesDateTime FROM readMeterRecord WHERE waterMeterId='" + MODELreadMeterRecord.waterMeterNo + "' ORDER BY initialReadMeterMesDateTime";
                            DataTable dtInitialMonth = BLLreadMeterRecord.QueryBySQL(strSQLGetInitialMonth);
                            if (dtInitialMonth.Rows.Count > 0)
                            {
                                object objInitialMonth = dtInitialMonth.Rows[0]["initialReadMeterMesDateTime"];
                                if (Information.IsDate(objInitialMonth))
                                {
                                    DateTime dtLastYearAndMonth = Convert.ToDateTime(objInitialMonth);
                                    MODELreadMeterRecord.readMeterRecordDate = dtLastYearAndMonth.AddMonths(-1);
                                    MODELreadMeterRecord.WCYS = dtNow.Year * 12 + dtNow.Month - dtLastYearAndMonth.Year * 12 - dtLastYearAndMonth.Month + 1;
                                }
                            }
                        }
                        string strLastNumberFilter = " AND waterMeterId='" + MODELreadMeterRecord.waterMeterNo +
                            "' AND WATERMETERNUMBERCHANGESTATE='0' ORDER BY checkDateTime DESC,readMeterRecordDate DESC";//已经审核完的才能作为下一个月水表的初始值
                        //string strLastNumberFilter = " AND waterMeterId='" + objWaterMeterID.ToString() + "' ORDER BY readMeterRecordDate DESC";//已经审核完的才能作为下一个月水表的初始值
                        DataTable dtLastNumber = BLLreadMeterRecord.GetLastNumber(strLastNumberFilter);
                        if (dtLastNumber.Rows.Count > 0)
                        {
                            //object objectRecordLastYearAndMonth = dtLastNumber.Rows[0]["CHARGEDATETIME"];
                            //将上月读数日期修改为抄表日期
                            object objectRecordLastYearAndMonth = dtLastNumber.Rows[0]["readMeterRecordDate"];
                            if (Information.IsDate(objectRecordLastYearAndMonth))
                            {
                                MODELreadMeterRecord.readMeterRecordDate = Convert.ToDateTime(objectRecordLastYearAndMonth);//存储最后一次抄表日期
                            }
                        }

                        objRecordData = dgList.Rows[i].Cells["WATERUSERQQYE"].FormattedValue;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.WATERUSERQQYE = Convert.ToDecimal(objRecordData);
                        }

                        objRecordData = dgList.Rows[i].Cells["WATERUSERLJQF"].FormattedValue;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.WATERUSERLJQF = Convert.ToDecimal(objRecordData);
                        }

                        objRecordData = dgList.Rows[i].Cells["WATERUSERJSYE"].FormattedValue;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.WATERUSERJSYE = Convert.ToDecimal(objRecordData);
                        }

                        //与振中抄笔机的不同 
                        //振中      华蓝    字段
                        //附加费    保留    qtjine
                        //保留      附加费  zjine
                        //倒装标志  保留    sb2xh
                        //上月读数  没有    SB1SYDS
                        //没有      上月读数 SY1SYDS
                        //没用      倒装     CBBC


                        string strSQLInsert = "INSERT INTO INTERDB" +
                            "(yhbh,yhmc,yhdz,yhrk,yhdh,pqbm,zbh,cbsx,yslx,bjine,qtjine,wjine,zjine,jtsl1,jtsl2,jtsl3,jtsf1,jtsf2,jtsf3,byyl,byscjz," +
                            "bybcjz,jtbz,cbbz,sb1xh,sy1syds,sy1byds,sb1by,sb2xh,cbbc,zsl,zsf,scye,bcss,bcye,dybz,sfy,kppd,ljqf,fbs,wcys,mccb) " +
                            "VALUES('" + MODELreadMeterRecord.waterUserNO + "','" + MODELreadMeterRecord.waterUserName + "','" +
                             MODELreadMeterRecord.waterUserAddress + "','" + MODELreadMeterRecord.waterUserPeopleCount + "','" + strPhone + "','" +
                             MODELreadMeterRecord.areaNO + "','" + MODELreadMeterRecord.duanNO + "','" + MODELreadMeterRecord.readMeterRecordId + "','" + MODELreadMeterRecord.waterMeterTypeId + "','" +
                            MODELreadMeterRecord.avePrice + "','0','" + MODELreadMeterRecord.extraChargePrice1 + "','" + MODELreadMeterRecord.extraChargePrice2 + "','" +
                            MODELreadMeterRecord.TrapeZoid1 + "','" + MODELreadMeterRecord.TrapeZoid2 + "','" + MODELreadMeterRecord.TrapeZoid3 + "','" +
                            MODELreadMeterRecord.TrapeZoidPrice1 + "','" + MODELreadMeterRecord.TrapeZoidPrice2 + "','" + MODELreadMeterRecord.TrapeZoidPrice3 +
                            "',0,0,0,'" + MODELreadMeterRecord.isTrapeZoid + "','0','" + (strWaterMeterSerialNumber.Length > 0 ? strWaterMeterSerialNumber[0] : "") + "','" +
                            MODELreadMeterRecord.waterMeterLastNumber + "','" + MODELreadMeterRecord.waterMeterEndNumber + "','0','" + (strWaterMeterSerialNumber.Length > 1 ? strWaterMeterSerialNumber[1] : "") + "','" +
                           MODELreadMeterRecord.IsReverse + "','0',0,'" +
                           MODELreadMeterRecord.WATERUSERJSYE.ToString("F2") + "',0,0,0,'" + MODELreadMeterRecord.meterReaderName +
                            "',0,'" + MODELreadMeterRecord.WATERUSERLJQF.ToString("F2") + "',0,'" + MODELreadMeterRecord.WCYS + "','" + MODELreadMeterRecord.readMeterRecordDate.ToString("yyyy-MM-dd") + "')";
                        //string strSQLInsert = "INSERT INTO INTERDB" +
                        //    "(yhbh,yhmc,yhdz,yhrk,yhdh,pqbm,zbh,cbsx,yslx,bjine,qtjine,wjine,zjine,jtsl1,jtsl2,jtsl3,jtsf1,jtsf2,jtsf3,byyl,byscjz," +
                        //    "bybcjz,cbbc,jtbz,cbbz,sb1xh,sb1syds,zsl,zsf,scye,bcss,bcye,dybz,sfy,kppd,ljqf,fbs,wcys) " +
                        //    "VALUES('" + MODELreadMeterRecord.waterUserNO + "','" + MODELreadMeterRecord.waterUserName + "','" +
                        //     MODELreadMeterRecord.waterUserAddress + "','0','" + MODELreadMeterRecord.waterUserTelphoneNO + " " + MODELreadMeterRecord.waterPhone + "','" +
                        //     MODELreadMeterRecord.areaNO + "','" + MODELreadMeterRecord.duanNO + "','" + MODELreadMeterRecord.readMeterRecordId + "','" + MODELreadMeterRecord.waterMeterTypeId + "','" +
                        //    MODELreadMeterRecord.avePrice + "','" + MODELreadMeterRecord.extraChargePrice2 + "','" + MODELreadMeterRecord.extraChargePrice1 + "','0.01','" +
                        //    MODELreadMeterRecord.TrapeZoid1 + "','" + MODELreadMeterRecord.TrapeZoid2 + "','" + MODELreadMeterRecord.TrapeZoid3 + "','" +
                        //    MODELreadMeterRecord.TrapeZoidPrice1 + "','" + MODELreadMeterRecord.TrapeZoidPrice2 + "','" + MODELreadMeterRecord.TrapeZoidPrice3 +
                        //    "',0,0,0,0,'" + MODELreadMeterRecord.isTrapeZoid + "','0','0'," +
                        //    MODELreadMeterRecord.waterMeterLastNumber + ",0,0," + MODELreadMeterRecord.WATERUSERJSYE + ",0,0,0,'" + MODELreadMeterRecord.meterReaderName +
                        //    "',0,'" + MODELreadMeterRecord.WATERUSERJSYE + "',0,'" + MODELreadMeterRecord.WCYS + "')";

                        int intRow = ExcuteSQL(strSQLInsert, connectString);
                        if (intRow == 1)
                        {
                            intSuccessCount++;
                            labExcute.Text = "成功验证:" + intSuccessCount.ToString() + "条数据";
                        }
                    }
                }
                labExcute.Text = "正在清空原有抄表机数据...";

                intReturn = deletefile(intMachinePort, strFileName);
                //if (intReturn == 0)
                //{
                labExcute.Text = "正在写入抄表机...";

                StringBuilder strPCFileName = new StringBuilder();
                strPCFileName.Append(strDBFPath + "INTERDB.DBF");
                intReturn = downtofile(intMachinePort, strPCFileName, strFileName);
                if (intReturn == 0)
                {
                    btImport.Enabled = true;
                    strErrorMes = "共导入" + intSuccessCount.ToString() + "条抄表机数据，命令执行完毕";
                    //isSucess = true;
                }
                else
                {
                    btImport.Enabled = true;
                    strErrorMes = "数据生成完毕但写入抄表机错误,可点击导入数据文件按钮重新导入抄表机\r\n原因:" + GetErrorMes(intReturn);
                    labExcute.Text = strErrorMes;
                    return;
                }
                //}
                //else
                //{
                //    btImport.Enabled = true;
                //    mes.Show(GetErrorMes(intReturn));
                //    labExcute.Text = "";
                //    return;
                //}
            }
            catch (Exception ex)
            {
                strErrorMes = ex.Message;
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
            //if (trMeterReading.SelectedNode == null)
            //    return;
            //TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
            //trMeterReading_AfterSelect(null, ex);
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel2.Enabled = true;
            trMeterReading.Enabled = true;

            labExcute.Text = strErrorMes;
            if (strErrorMes == "")
                strErrorMes = "传输强制中断!";
            mes.Show(strErrorMes);
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmSeniorSearch frm = new frmSeniorSearch();
            frm.Owner = this;
            frm.strSign = "1";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }

        private void btImportFile_Click(object sender, EventArgs e)
        {
            try
            {
                btImportFile.Enabled = false;
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
                        btImportFile.Enabled = true;
                        labExcute.Text = "导入抄表机数据，命令执行完毕";
                    }
                    else
                    {
                        btImportFile.Enabled = true;
                        strErrorMes = "写入抄表机错误,原因:" + GetErrorMes(intReturn);
                        labExcute.Text = strErrorMes;
                        return;
                    }
                }
                else
                {
                    btImportFile.Enabled = true;
                    mes.Show(GetErrorMes(intReturn));
                    labExcute.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                strErrorMes = ex.Message;
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                btImportFile.Enabled = true;
                return;
            }
        }

        private void btImportReason_Click(object sender, EventArgs e)
        {
            string connectString =
                            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";

            //抄表机中未抄原因文件名
            StringBuilder strMemoFileName = new StringBuilder();
            strMemoFileName.Append("beizhu.dbf");

            //电脑上生成的待导入抄表机的文件名
            StringBuilder strMemoPCFileName = new StringBuilder();
            strMemoPCFileName.Append(strDBFPath + "beizhu.dbf");

            if (File.Exists(strDBFPath + @"Model\beizhu.dbf"))
                File.Copy(strDBFPath + @"Model\beizhu.dbf", strDBFPath + "beizhu.dbf", true);
            else
            {
                labExcute.Text = "模板文件不存在,无法生成未抄原因数据!";
                strErrorMes = "模板文件不存在,无法生成未抄原因数据!";
                btImport.Enabled = true;
                return;
            }
            int intMemoCount = 0;

            DataTable dtMemo = BLLNullReadReasonMemo.Query("");
            if (dtMemo.Rows.Count == 0)
            {
                mes.Show("未抄原因为空，请设置!");
                return;
            }

            for (int i = 0; i < dtMemo.Rows.Count; i++)
            {
                MODELNullReadReasonName MODELNullReadReasonName = new MODELNullReadReasonName();

                object objRecordID = dtMemo.Rows[i]["NullReadReasonID"];
                if (objRecordID != null && objRecordID != DBNull.Value)
                {
                    MODELNullReadReasonName.NullReadReasonID = objRecordID.ToString();

                    object objRecordData = dtMemo.Rows[i]["NullReadReasonName"];
                    if (objRecordData != null && objRecordData != DBNull.Value)
                    {
                        MODELNullReadReasonName.NullReadReasonName = objRecordData.ToString();
                    }

                    string strSQLInsert = "INSERT INTO beizhu" +
                        "(bh,Type) " +
                        "VALUES('" + MODELNullReadReasonName.NullReadReasonID + "','" + MODELNullReadReasonName.NullReadReasonName + "')";
                    int intRow = ExcuteSQL(strSQLInsert, connectString);
                    if (intRow == 1)
                    {
                        intMemoCount++;
                        labExcute.Text = "成功验证:" + intMemoCount.ToString() + "条数据";
                    }
                }
            }
            labExcute.Text = "正在清空原有数据...";

            int intReturn = deletefile(intMachinePort, strMemoFileName);
            labExcute.Text = "正在写入抄表机...";

            intReturn = downtofile(intMachinePort, strMemoPCFileName, strMemoFileName);
            if (intReturn == 0)
            {
                btImport.Enabled = true;
                strErrorMes = "共导入" + intMemoCount.ToString() + "条数据，命令执行完毕";
                labExcute.Text = strErrorMes;
                //isSucess = true;
            }
            else
            {
                btImport.Enabled = true;
                strErrorMes = "未抄原因写入抄表机错误,原因:" + GetErrorMes(intReturn);
                labExcute.Text = strErrorMes;
                return;
            }
        }
    }
}
