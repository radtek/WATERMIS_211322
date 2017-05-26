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
    public partial class frmToMachineManage_ZhenZhong : Form
    {
        public frmToMachineManage_ZhenZhong()
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
        /// <returns>成功时为0，否则表示出错</returns>
        [DllImport("comdll.dll")]
        private static extern int thrdGetHcNum(int intPort,int intBaudrate,StringBuilder strHCNum);

        private struct tDateInfo
        {
           public int year;					// 年
           public int month;					// 月
           public int day;					// 日
        }

//TTIMEINFO结构用于存放时间的相关信息，包括24小时、分、秒：
       struct tTimeInfo
       {
           public int hour;					// 时
           public int min;					// 分
           public int sec;					// 秒
           public int reserved;				// 保留
       }

        /// <summary>
        /// 设置手持机日期和时间    
        /// </summary>
        /// <param name="intPort">手持机连接的端口</param>
        /// <returns>成功  返回0，否则详见GetErrorMes</returns>
        [DllImport("comdll.dll")]
       private static extern int SetHcDateTime(int intPort, int intBaudRate,ref tDateInfo dateinfo,ref tTimeInfo timeinfo);

        /// <summary>
        /// 从指定的端口上传一个名为[filename]的手持机文件到PC  
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strFileName">为一字符串变量，因为手持机没有目录信息，因此[filename]不能包含文件路径</param>
        /// <returns>成功  返回0,失败  返回参数见错误列表</returns>
        [DllImport("comdll.dll")]
        private static extern int SendFileToHc(int intPort,int intBaudRate,StringBuilder strFileName,StringBuilder strFileNameAndPath,int intAttrib,int intPrompt);

        /// <summary>
        /// 从指定的端口上传机器编号字符串到PC
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strMachineNO">为一字符串变量,为返回的机器编号</param>
        /// <returns></returns>
        [DllImport("comdll.dll")]
        private static extern int getmno(int intPort, StringBuilder strMachineNO);

        /// <summary>
        /// 删除指定的数据采集终端文件
        /// </summary>
        /// <param name="intPort">通讯端口号，合法值为0-4。0为USB端口，1-4分别为COM1-COM4</param>
        /// <param name="intBaudRate">通讯波特率，合法值为115200、57600、38400、9600。USB则忽略该项（取任意值）</param>
        /// <param name="strFileName">存放要删除的数据采集终端文件名</param>
        /// <param name="intPrompt">删除时是否提示确认。1表示不提示直接删除，2表示提示并由用户进行选择</param>
        /// <returns></returns>
        [DllImport("comdll.dll")]
        private static extern int DelHcFile(int intPort, int intBaudRate, StringBuilder strFileName,int intPrompt);

        /// <summary>
        /// 下传并改名
        /// </summary>
        /// <param name="intPort">手持机连接的端口</param>
        /// <param name="strPCFileName">PC端文件名</param>
        /// <param name="strHandSetFileName">下载到手持机的文件名</param>
        /// <returns>成功  返回0</returns>
        [DllImport("comdll.dll")]
        private static extern int GetHcFile(int intPort, int intBaudRate, StringBuilder strFileName, StringBuilder strFileNameAndPath, int intPrompt);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intMode">停止标志。设为1时只停止当前的通讯任务，设为2时停止所有的通讯任务。一般情况下请使用2。</param>
        /// <returns></returns>
        [DllImport("comdll.dll")]
        private static extern int thrdStop(int intMode);

        private string GetErrorMes(int intErrorNO)
        {
            string strErrorMes = "未知错误!";
            switch (intErrorNO)
            {
                case 0:
                    strErrorMes = "命令正常执行";
                    break;
                case 1:
                    strErrorMes = "命令被拒绝";
                    break;
                case 2:
                    strErrorMes = "命令错误";
                    break;
                case 3:
                    strErrorMes = "命令非法";
                    break;
                case 4:
                    strErrorMes = "当前通讯被对方终止";
                    break;
                case 5:
                    strErrorMes = "当前通讯被用户终止";
                    break;
                case 10:
                    strErrorMes = "不能够建立通讯进程";
                    break;
                case 11:
                    strErrorMes = "对方无应答";
                    break;
                case 12:
                    strErrorMes = "通讯时出现超时错误";
                    break;
                case 13:
                    strErrorMes = "数据包头丢失";
                    break;
                case 14:
                    strErrorMes = "数据包非法";
                    break;
                case 15:
                    strErrorMes = "数据包丢失";
                    break;
                case 16:
                    strErrorMes = "数据包未被正确响应";
                    break;
                case 17:
                    strErrorMes = "数据包校验错误";
                    break;
                case 18:
                    strErrorMes = "数据包结束请求未被响应";
                    break;
                case 19:
                    strErrorMes = "发送失败";
                    break;
                case 20:
                    strErrorMes = "未指定文件";
                    break;
                case 21:
                    strErrorMes = "文件不存在";
                    break;
                case 22:
                    strErrorMes = "不能创建文件";
                    break;
                case 23:
                    strErrorMes = "打不开文件";
                    break;
                case 24:
                    strErrorMes = "读文件失败";
                    break;
                case 25:
                    strErrorMes = "写文件失败";
                    break;
                case 26:
                    strErrorMes = "文件格式非法或已损坏";
                    break;
                case 27:
                    strErrorMes = "指定的文件名非法";
                    break;
                case 28:
                    strErrorMes = "文件大小非法";
                    break;
                case 30:
                    strErrorMes = "内存不足";
                    break;
                case 31:
                    strErrorMes = "磁盘空间不足";
                    break;
                case 32:
                    strErrorMes = "数据采集终端内存不足";
                    break;
                case 33:
                    strErrorMes = "数据采集终端Flash盘空间满";
                    break;
                case 34:
                    strErrorMes = "地址错误";
                    break;
                case 35:
                    strErrorMes = "数据采集终端电池电压低";
                    break;
                case 40:
                    strErrorMes = "传入参数错误";
                    break;
                case 256:
                    strErrorMes = "未连通数据采集终端";
                    break;
                case 512:
                    strErrorMes = "正在通讯过程中";
                    break;
                case 768:
                    strErrorMes = "正在通讯重试过程中";
                    break;
                case 4096:
                    strErrorMes = "程序模块调用失败";
                    break;
                default:
                    strErrorMes = "错误编号:" + intErrorNO+",未知错误";
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

            GenerateTree();
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
            }
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
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
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
            labTip.Text = "共" + dtUserList.Rows.Count+ "条数据";
            if (dtUserList.Rows.Count > 0)
                btImport.Enabled = true;
            else
                btImport.Enabled = false;
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
        private void btSetDateTime_Click(object sender, EventArgs e)
        {
            DateTime dtNow=mes.GetDatetimeNow();
            tDateInfo dateinfo=new tDateInfo();
            dateinfo.year=dtNow.Year;
            dateinfo.month=dtNow.Month;
            dateinfo.day=dtNow.Day;

            tTimeInfo timeInfo=new tTimeInfo();
            timeInfo.hour=dtNow.Hour;
            timeInfo.min=dtNow.Minute;
            timeInfo.sec=dtNow.Second;

            int intReturn = SetHcDateTime(0, 0,ref dateinfo,ref timeInfo);
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
            btImport.Enabled = false;
            btSetDateTime.Enabled = false;

            bgWork.RunWorkerAsync();
            //try
            //{
            //    if (dgList.Rows.Count == 0)
            //    {
            //        mes.Show("数据列表为空,无法导入数据!");
            //        return;
            //    }
            //    if (mes.ShowQ("执行此操作会将现有的抄表机数据覆盖，确定要执行此操作吗?") != DialogResult.OK)
            //        return;
            //    //if(File.Exists(strDBFPath+"INTERDB.DBF"))
            //    //{
            //    //    File.Delete(strDBFPath+"INTERDB.DBF");
            //    //}
            //    if (File.Exists(strDBFPath + @"Model\INTERDB.DBF"))
            //        File.Copy(strDBFPath + @"Model\INTERDB.DBF", strDBFPath + "INTERDB.DBF", true);

            //    //抄表机数据库连接字符串
            //    string connectString =
            //                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";

            //    btImport.Enabled = false;
            //    labExcute.Text = "正在执行....";
            //    DateTime dtNow = mes.GetDatetimeNow();
            //    if (dgList.Rows.Count == 0)
            //    {
            //        mes.Show("未检测到要导入的抄表数据，请先查询导入的抄表数据!");
            //        btImport.Enabled = true;
            //        labExcute.Text = "";
            //        return;
            //    }
            //    int intSuccessCount = 0;
            //    for (int i = 0; i < dgList.Rows.Count; i++)
            //    {
            //        MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

            //        object objRecordID = dgList.Rows[i].Cells["readMeterRecordId"].Value;
            //        if (objRecordID != null && objRecordID != DBNull.Value)
            //        {
            //            MODELreadMeterRecord.readMeterRecordId = objRecordID.ToString();

            //            object objRecordData = dgList.Rows[i].Cells["waterMeterNo"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterMeterNo = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["waterUserNO"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterUserNO = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["waterUserName"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterUserName = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["meterReadingNO"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.meterReadingNO = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["meterReadingPageNo"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.meterReadingPageNo = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["waterUserTypeId"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterUserTypeId = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["waterUserTypeName"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterUserTypeName = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["areaId"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.areaId = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["areaName"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.areaName = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["loginId"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.loginId = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["USERNAME"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.USERNAME = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["waterUserAddress"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterUserAddress = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["waterPhone"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterPhone = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["waterMeterTypeId"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterMeterTypeId = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["waterMeterTypeName"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterMeterTypeName = objRecordData.ToString();
            //            }

            //            object objBYDS = dgList.Rows[i].Cells["waterMeterLastNumber"].Value;
            //            if (Information.IsNumeric(objBYDS))
            //                MODELreadMeterRecord.waterMeterLastNumber = Convert.ToInt32(objBYDS);

            //            objRecordData = dgList.Rows[i].Cells["avePrice"].FormattedValue;
            //            if (Information.IsNumeric(objRecordData))
            //            {
            //                MODELreadMeterRecord.avePrice = Convert.ToDecimal(objRecordData);
            //            }

            //            objRecordData = dgList.Rows[i].Cells["extraChargePrice1"].FormattedValue;
            //            if (Information.IsNumeric(objRecordData))
            //            {
            //                MODELreadMeterRecord.extraChargePrice1 = Convert.ToDecimal(objRecordData);
            //            }

            //            objRecordData = dgList.Rows[i].Cells["waterMeterPositionName"].Value;
            //            if (objRecordData != null && objRecordData != DBNull.Value)
            //            {
            //                MODELreadMeterRecord.waterMeterPositionName = objRecordData.ToString();
            //            }

            //            objRecordData = dgList.Rows[i].Cells["WATERFIXVALUE"].FormattedValue;
            //            if (Information.IsNumeric(objRecordData))
            //            {
            //                MODELreadMeterRecord.WATERFIXVALUE =Convert.ToInt32(objRecordData);
            //            }

            //            objRecordData = dgList.Rows[i].Cells["totalNumber"].FormattedValue;
            //            if (Information.IsNumeric(objRecordData))
            //            {
            //                MODELreadMeterRecord.totalNumber = Convert.ToInt32(objRecordData);
            //            }

            //            objRecordData = dgList.Rows[i].Cells["ordernumber"].FormattedValue;
            //            if (Information.IsNumeric(objRecordData))
            //            {
            //                MODELreadMeterRecord.ordernumber = Convert.ToInt32(objRecordData);
            //            }
            //            //if (i == 1365)
            //            //{

            //            //}

            //            //intSuccessCount++;
            //            string strSQLInsert = "INSERT INTO INTERDB" +
            //                "(recordid,SBH,YHDM,yhm,sfye,cbh,yehao,yhlbdm,yhlb,qydm,qy,cbydm,cby,dz,dianhua,yslbdm,yslb,zhuangtai,ztdm,syds,szydj," +
            //                "fjfdj,cbbz,dybz,bwzm,sbbz3,fjfdj1,dlys,bysl,cbsx) " +
            //                "VALUES('" + MODELreadMeterRecord.readMeterRecordId + "','" + MODELreadMeterRecord.waterMeterNo + "','" + 
            //                MODELreadMeterRecord.waterUserNO + "','" + MODELreadMeterRecord.waterUserName + "','0','" +
            //                 MODELreadMeterRecord.meterReadingNO + "','" + MODELreadMeterRecord.meterReadingPageNo + "','" + MODELreadMeterRecord.waterUserTypeId + "','" +
            //                 MODELreadMeterRecord.waterUserTypeName + "','" + MODELreadMeterRecord.areaId + "','" + MODELreadMeterRecord.areaName + "','" +
            //                MODELreadMeterRecord.loginId + "','" + MODELreadMeterRecord.USERNAME + "','" + MODELreadMeterRecord.waterUserAddress + "','" +
            //                MODELreadMeterRecord.waterPhone + "','" + MODELreadMeterRecord.waterMeterTypeId + "','" + MODELreadMeterRecord.waterMeterTypeName + "','正常','0',"+
            //                MODELreadMeterRecord.waterMeterLastNumber + "," + MODELreadMeterRecord.avePrice + "," + MODELreadMeterRecord.extraChargePrice1 +
            //                ",0,0,'" +
            //                MODELreadMeterRecord.waterMeterPositionName + "',1," + MODELreadMeterRecord.extraChargePrice2 + "," + MODELreadMeterRecord.WATERFIXVALUE+
            //                "," + MODELreadMeterRecord.totalNumber+","+MODELreadMeterRecord.ordernumber+ ")";
            //            int intRow = ExcuteSQL(strSQLInsert, connectString);
            //            if (intRow == 1)
            //            {
            //                intSuccessCount++;
            //                labExcute.Text = "成功验证:" + intSuccessCount.ToString() + "条数据";
            //            }
            //        }

            //    }
            //    labExcute.Text = "正在清空原有抄表机数据...";
            //    StringBuilder strFileName = new StringBuilder();
            //    strFileName.Append("INTERDB.DBF");
            //    int intReturn = deletefile(intMachinePort, strFileName);
            //    if (intReturn == 0)
            //    {
            //        labExcute.Text = "正在写入抄表机数据...";

            //        StringBuilder strPCFileName = new StringBuilder();
            //        strPCFileName.Append(strDBFPath + "INTERDB.DBF");
            //        intReturn = downtofile(intMachinePort, strPCFileName, strFileName);
            //        if (intReturn == 0)
            //        {
            //            labExcute.Text = "共导入" + intSuccessCount.ToString() + "条抄表机数据，命令执行完毕";
            //        }
            //        else
            //        {
            //            btImport.Enabled = true;
            //            mes.Show(GetErrorMes(intReturn));
            //            labExcute.Text = "";
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        btImport.Enabled = true;
            //        mes.Show(GetErrorMes(intReturn));
            //        labExcute.Text = "";
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    labExcute.Text = "";
            //    mes.Show(ex.Message);
            //    log.Write(ex.ToString(), MsgType.Error);
            //    btImport.Enabled = true;
            //    return;
            //}
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


        private void frmToMachineManage_FormClosing(object sender, FormClosingEventArgs e)
        {
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

                labExcute.Text = "正在执行....";
                DateTime dtNow = mes.GetDatetimeNow();
                
                labExcute.Text = "正在备份原有抄表机数据...";
                StringBuilder strFileName = new StringBuilder();
                strFileName.Append("INTERDB.DBF");

                StringBuilder strFilePath = new StringBuilder();
                strFilePath.Append(strDBFPath + @"\Bak_ZZ\INTERDB" + dtNow.ToString("yyyyMMddHHmmss") + "_ZZ.DBF");
                int intReturn = GetHcFile(0, 0, strFileName, strFilePath, 2);
                if (intReturn != 0)
                {
                    strErrorMes = "备份数据失败:" + GetErrorMes(intReturn);
                    btImport.Enabled = true;
                    return;
                }

                if (File.Exists(strDBFPath + @"Model\INTERDB_ZZ.DBF"))
                    File.Copy(strDBFPath + @"Model\INTERDB_ZZ.DBF", strDBFPath + "INTERDB.DBF", true);
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
                                strPhone=strPhone+" "+MODELreadMeterRecord.waterPhone;

                        }
                        if(strPhone.Length>28)
                            strPhone = strPhone.Substring(0, 28);

                        MODELreadMeterRecord.ChannelNO = "";
                        objRecordData = dgList.Rows[i].Cells["ChannelNO"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.ChannelNO = objRecordData.ToString();
                        }

                        MODELreadMeterRecord.waterMeterSerialNumber = "";
                        objRecordData = dgList.Rows[i].Cells["waterMeterSerialNumber"].Value;
                        if (objRecordData != null && objRecordData != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterMeterSerialNumber = objRecordData.ToString();
                        }
                        //string[] strWaterMeterSerialNumber = MODELreadMeterRecord.waterMeterSerialNumber.Split('/');
                        //strWaterMeterSerialNumber[0] = strWaterMeterSerialNumber[0].Replace(" ","");
                        //if (strWaterMeterSerialNumber[0].Length>12)
                        //strWaterMeterSerialNumber[0] = strWaterMeterSerialNumber[0].Substring(0,12);
                        //if (strWaterMeterSerialNumber.Length > 1)
                        //{
                        //    strWaterMeterSerialNumber[1] = strWaterMeterSerialNumber[1].Replace(" ", "");
                        //    if (strWaterMeterSerialNumber[1].Length > 12)
                        //    strWaterMeterSerialNumber[1] = strWaterMeterSerialNumber[1].Substring(0, 12);
                        //}
                            
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
                                MODELreadMeterRecord.avePrice =Convert.ToDecimal(strPrice[0].Split(':')[1]);
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
                                MODELreadMeterRecord.avePrice =Convert.ToDecimal(MODELreadMeterRecord.TrapeZoidPrice1);
                            }
                        }


                        objRecordData = dgList.Rows[i].Cells["extraChargePrice1"].FormattedValue;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.extraChargePrice1 = Convert.ToDecimal(objRecordData);
                        }

                        objRecordData = dgList.Rows[i].Cells["extraChargePrice2"].FormattedValue;
                        if (Information.IsNumeric(objRecordData))
                        {
                            MODELreadMeterRecord.extraChargePrice2 = Convert.ToDecimal(objRecordData);
                        }

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
                            string strSQLGetInitialMonth = "SELECT  TOP 1  initialReadMeterMesDateTime FROM readMeterRecord WHERE waterMeterId='" + MODELreadMeterRecord.waterMeterNo + "' ORDER BY initialReadMeterMesDateTime";
                            DataTable dtInitialMonth = BLLreadMeterRecord.QueryBySQL(strSQLGetInitialMonth);
                            if (dtInitialMonth.Rows.Count > 0)
                            {
                                object objInitialMonth = dtInitialMonth.Rows[0]["initialReadMeterMesDateTime"];
                                if (Information.IsDate(objInitialMonth))
                                {
                                    DateTime dtLastYearAndMonth = Convert.ToDateTime(objInitialMonth);
                                    //MODELreadMeterRecord.readMeterRecordDate = dtLastYearAndMonth;
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

                        string strSQLInsert = "INSERT INTO INTERDB" +
                            "(yhbh,yhmc,yhdz,yhrk,yhdh,pqbm,zbh,cbsx,yslx,bjine,qtjine,wjine,zjine,jtsl1,jtsl2,jtsl3,jtsf1,jtsf2,jtsf3,byscjz," +
                            "bybcjz,cbbc,jtbz,cbbz,sb1xh,sb1syds,sb1byds,sb2xh,SB2sy,byyl,zsl,zsf,scye,bcss,bcye,dybz,sfy,kppd,ljqf,fbs,wcys,mccb,SB2SYDS,sb2byds) " +
                            "VALUES('" + MODELreadMeterRecord.waterUserNO + "','" + MODELreadMeterRecord.waterUserName + "','" +
                             MODELreadMeterRecord.waterUserAddress + "','" + MODELreadMeterRecord.waterUserPeopleCount+ "','" + strPhone + "','" + 
                             MODELreadMeterRecord.areaNO + "','" +MODELreadMeterRecord.duanNO + "','" + MODELreadMeterRecord.readMeterRecordId + "','" + MODELreadMeterRecord.waterMeterTypeId + "','" +
                            MODELreadMeterRecord.avePrice + "','" + MODELreadMeterRecord.extraChargePrice2 + "','" + MODELreadMeterRecord.extraChargePrice1 + "','0','" +
                            MODELreadMeterRecord.TrapeZoid1 + "','" + MODELreadMeterRecord.TrapeZoid2 + "','" + MODELreadMeterRecord.TrapeZoid3+"','" +
                            MODELreadMeterRecord.TrapeZoidPrice1 + "','" + MODELreadMeterRecord.TrapeZoidPrice2 + "','" + MODELreadMeterRecord.TrapeZoidPrice3 +
                            "','0','0','0','" + MODELreadMeterRecord.isTrapeZoid + "','0','" + MODELreadMeterRecord.waterMeterSerialNumber + "','" +
                            MODELreadMeterRecord.waterMeterLastNumber + "','" + MODELreadMeterRecord.waterMeterEndNumber + "','"+
                             MODELreadMeterRecord.ChannelNO + "','" + MODELreadMeterRecord.IsReverse + "','0','0','0','" +
                            MODELreadMeterRecord.WATERUSERJSYE.ToString("F2") + "','0','0','0','" + MODELreadMeterRecord.meterReaderName +
                            "','0','" + MODELreadMeterRecord.WATERUSERLJQF.ToString("F2") + "','0','" + MODELreadMeterRecord.WCYS + "','" + MODELreadMeterRecord.readMeterRecordDate.ToString("yyyy-MM-dd") + "','1','0')";

                        int intRow = ExcuteSQL(strSQLInsert, connectString);
                        if (intRow == 1)
                        {
                            intSuccessCount++;
                            labExcute.Text = "成功验证:" + intSuccessCount.ToString() + "条数据";
                        }
                    }
                }

                    labExcute.Text = "正在写入抄表机...";

                    StringBuilder strPCFileName = new StringBuilder();
                    strPCFileName.Append(strDBFPath + "INTERDB.DBF");

                    intReturn = SendFileToHc(0, 0, strFileName, strPCFileName, 65536, 1);
                    if (intReturn == 0)
                    {
                        labExcute.Text = "共导入" + intSuccessCount.ToString() + "条抄表机数据，命令执行完毕";
                        strErrorMes = "共导入" + intSuccessCount.ToString() + "条抄表机数据，命令执行完毕";
                        btImport.Enabled = true;
                    }
                    else
                    {
                        btImport.Enabled = true;
                        strErrorMes = "数据生成完毕但写入抄表机错误,可点击导入数据文件按钮重新导入抄表机\r\n原因:" + GetErrorMes(intReturn);
                        labExcute.Text = strErrorMes;
                        return;
                    }
            }
            catch (Exception ex)
            {
                //labExcute.Text = "";
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                btImport.Enabled = true;
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
            btImport.Enabled = true;
            btSetDateTime.Enabled = true;

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

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode != null)
            {
                TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
                trMeterReading_AfterSelect(null, ex);
            }
        }

        private void btImportFile_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder strFileName = new StringBuilder();
                strFileName.Append("INTERDB.DBF");

                labExcute.Text = "正在写入抄表机...";

                StringBuilder strPCFileName = new StringBuilder();
                strPCFileName.Append(strDBFPath + "INTERDB.DBF");
                   int intReturn = SendFileToHc(0, 0, strFileName, strPCFileName, 65536, 1);
                    if (intReturn == 0)
                    {
                        labExcute.Text = "导入抄表机数据，命令执行完毕";
                        btImport.Enabled = true;
                    }
                    else
                    {
                        btImport.Enabled = true;
                        strErrorMes = "写入抄表机错误,原因:" + GetErrorMes(intReturn);
                        labExcute.Text = strErrorMes;
                        return;
                    }
            }
            catch (Exception ex)
            {
                //labExcute.Text = "";
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                btImport.Enabled = true;
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
            labExcute.Text = "正在导入...";
            int intReturn = SendFileToHc(0, 0, strMemoFileName, strMemoPCFileName, 65536, 1);
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
