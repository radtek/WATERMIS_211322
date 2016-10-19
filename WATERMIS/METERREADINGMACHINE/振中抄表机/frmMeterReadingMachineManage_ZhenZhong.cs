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
using System.Collections;

namespace METERREADINGMACHINE
{
    public partial class frmMeterReadingMachineManage_ZhenZhong : Form
    {
        public frmMeterReadingMachineManage_ZhenZhong()
        {
            InitializeComponent();
        }

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        //BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        //BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        //BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        //BLLAREA BLLAREA = new BLLAREA();
        //GETTABLEID GETTABLEID = new GETTABLEID();

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



        [DllImport("hspos.dll")]
        private static extern int downtofile(int intPort,StringBuilder strPCFileName, StringBuilder strFileName);

        /// <summary>
        /// 更改手持机的操作员编号和姓名
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strID">操作员编号</param>
        /// <param name="strName">操作员姓名</param>
        /// <returns></returns>
        [DllImport("hspos.dll")]
        private static extern int down_userinfo(int intPort, StringBuilder strID, StringBuilder strName);

        /// <summary>
        /// 从指定的端口上传机器编号字符串到PC
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strMachineNO">为一字符串变量,为返回的机器编号</param>
        /// <returns></returns>
        [DllImport("hspos.dll")]
        private static extern int getmno(int intPort, StringBuilder strMachineNO);

        /// <summary>
        /// 返回文件列表信息，调用getlist(port)函数之后，动态库会将手持机的文件分配表存储为当前目录中的filetmp.tmp临时文件中，文件名与文件大小放在此文件中，格式为文件长度[4]，文件名[11]
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <returns>返回文件个数(>0,小于128)</returns>
        [DllImport("hspos.dll")]
        private static extern int getlist(int intPort);

        /// <summary>
        /// 删除一个名为[filename]的手持机文件
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <param name="strFileName">为一字符串变量，因为手持机没有目录信息，因此[filename]不能包含文件路径</param>
        /// <returns>成功  返回0</returns>
        [DllImport("hspos.dll")]
        private static extern int deletefile(int intPort, StringBuilder strFileName);

        /// <summary>
        /// 使手持机退出通讯状态
        /// </summary>
        /// <param name="intPort">为手持机连接的端口</param>
        /// <returns>成功返回0</returns>
        [DllImport("hspos.dll")]
        private static extern int pos_exitcomm(int intPort);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="intErrorNO"></param>
        /// <returns></returns>
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

            toolStripPort.Items.Clear();
            string[] strPorts = SerialPort.GetPortNames();
            foreach (string strPortName in strPorts)
            {
                toolStripPort.Items.Add(strPortName);
            }
            if (toolStripPort.Items.Count > 0)
                toolStripPort.SelectedIndex = 0;
            GetMeterReader("");
        }
        private void GetMeterReader(string strFilter)
        {
            lstMeterReader.Items.Clear();
            DataTable dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是' "+strFilter);
            for (int i = 0; i < dtMeterReader.Rows.Count; i++)
            {
                //抄表员的ID和姓名
                string strID = "", strName = "";
                object objID = dtMeterReader.Rows[i]["LOGINID"];
                if (objID != null && objID != DBNull.Value)
                {
                    strID = objID.ToString();
                    object objName = dtMeterReader.Rows[i]["USERNAME"];
                    if (objName != null && objName != DBNull.Value)
                    {
                        strName = objName.ToString();
                    }

                    ListItem ListItem = new ListItem(strName, strID);
                    lstMeterReader.Items.Add(ListItem);
                }
            }
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
        private void toolStripConnectDBF_Click(object sender, EventArgs e)
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


        private void btDownLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripClose.Enabled = false;
                string strDateTimeNow = mes.GetDatetimeNow().ToString("yyyyMMdd");
                StringBuilder strFileName = new StringBuilder();
                strFileName.Append("INTERDB.DBF");
                int intReturn = upfile(intMachinePort, strFileName);
                if (intReturn == 0)
                {
                    string strDownLoadFileName = Application.StartupPath + @"\INTERDB.DBF";

                    //获取机器编号，根据机器编号及时间备份导出的抄表机数据
                    StringBuilder strMachineNO = new StringBuilder();
                    int intReturnMachineNO = getmno(intMachinePort, strMachineNO);
                    if (intReturnMachineNO != 0)
                    {
                        mes.Show("获取抄表机编号失败!错误信息:" + GetErrorMes(intReturnMachineNO));
                    }
                    string strNewFileNameBak = "";
                    if (strMachineNO.ToString() != "")
                        strNewFileNameBak = Application.StartupPath + @"\HndSet\Bak\INTERDB" + strDateTimeNow + "_" + strMachineNO + ".DBF";
                    else
                        strNewFileNameBak = Application.StartupPath + @"\HndSet\Bak\INTERDB" + strDateTimeNow + ".DBF";

                    string strNewFileName = Application.StartupPath + @"\HndSet\INTERDB.DBF";
                    if (File.Exists(strNewFileName))
                        File.Delete(strNewFileName);
                    if (File.Exists(strDownLoadFileName))
                    {
                        File.Copy(strDownLoadFileName, strNewFileNameBak, true);
                        File.Move(strDownLoadFileName, strNewFileName);
                        File.Delete(strDownLoadFileName);
                        mes.Show("抄表机数据下载成功!");
                    }
                    else
                    {
                        mes.Show("未找到抄表机数据文件!");
                    }
                }
                else
                {
                    string strError = GetErrorMes(intReturn);
                    mes.Show(strError);
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
            finally
            {
                toolStripClose.Enabled = true;
            }
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    btImport.Enabled = false;
            //    labExcute.Text = "正在执行....";
            //    DateTime dtNow = mes.GetDatetimeNow();
            //    if (dgList.Rows.Count == 0)
            //    {
            //        mes.Show("未检测到抄表数据，请先下载抄表数据!");
            //        btImport.Enabled = false;
            //        labExcute.Text = "";
            //        return;
            //    }
            //    for (int i = 0; i < dgList.Rows.Count; i++)
            //    {
            //        DataGridViewCheckBoxCell chkcell = (DataGridViewCheckBoxCell)dgList.Rows[i].Cells["checkCell"];
            //        bool isChecked = Convert.ToBoolean(chkcell.EditedFormattedValue);
            //        if (isChecked)
            //        {
            //            object objCBSTATE = dgList.Rows[i].Cells["CBBZ"].Value;
            //            if (objCBSTATE != null && objCBSTATE != DBNull.Value)
            //            {
            //                if (objCBSTATE.ToString() == "未抄表")
            //                {
            //                    mes.Show("检测到选择的数据里有未抄表的数据，无法导入系统");
            //                    labExcute.Text = "";
            //                    return;
            //                }
            //            }
            //        }
            //    }
            //    int intSuccessCount = 0;
            //    for (int i = 0; i < dgList.Rows.Count; i++)
            //    {
            //        DataGridViewCheckBoxCell chkcell = (DataGridViewCheckBoxCell)dgList.Rows[i].Cells["checkCell"];
            //        bool isChecked = Convert.ToBoolean(chkcell.EditedFormattedValue);
            //        if (isChecked)
            //        {
            //            //抄表记录ID，收费员ID，收费员名称
            //            string strRecordID = "", strChargeWorkerID = "", strChargeWorkerName = "";
            //            int intBYDS = 0, intBYSL = 0;
            //            decimal decPrice=0,decBYSF = 0, decFJF = 0, decSum = 0;
            //            DateTime dtRecordDate = dtNow;

            //            object objRecordID = dgList.Rows[i].Cells["RECORDID"].Value;
            //            if (objRecordID != null && objRecordID != DBNull.Value)
            //            {
            //                strRecordID = objRecordID.ToString();
            //                object objBYDS = dgList.Rows[i].Cells["BYDS"].Value;
            //                if (Information.IsNumeric(objBYDS))
            //                    intBYDS = Convert.ToInt32(objBYDS);

            //                object objBYSL = dgList.Rows[i].Cells["BYSL"].Value;
            //                if (Information.IsNumeric(objBYSL))
            //                    intBYSL = Convert.ToInt32(objBYSL);

            //                object objSZYDJ = dgList.Rows[i].Cells["SZYDJ"].Value;
            //                if (Information.IsNumeric(objSZYDJ))
            //                    decPrice = Convert.ToDecimal(objSZYDJ);

            //                object objSZYJE = dgList.Rows[i].Cells["SZYJE"].Value;
            //                if (Information.IsNumeric(objSZYJE))
            //                    decBYSF = Convert.ToDecimal(objSZYJE);

            //                object objFJFJE = dgList.Rows[i].Cells["FJFJE"].Value;
            //                if (Information.IsNumeric(objFJFJE))
            //                    decFJF = Convert.ToDecimal(objFJFJE);

            //                object objBYJE = dgList.Rows[i].Cells["BYJE"].Value;
            //                if (Information.IsNumeric(objBYJE))
            //                    decSum = Convert.ToDecimal(objBYJE);

            //                object objRecordDate = dgList.Rows[i].Cells["DYRQ"].Value;
            //                if (objRecordDate != null && objRecordDate != DBNull.Value)
            //                {
            //                    string strDate = objRecordDate.ToString().Substring(0, 4) + "-" + objRecordDate.ToString().Substring(4, 2) + "-" + objRecordDate.ToString().Substring(6, 2);
            //                    if (Information.IsDate(strDate))
            //                        dtRecordDate = Convert.ToDateTime(strDate);
            //                }

            //                object objCBYDM = dgList.Rows[i].Cells["CBYDM"].Value;
            //                if (objCBYDM != null && objCBYDM != DBNull.Value)
            //                    strChargeWorkerID = objCBYDM.ToString();

            //                object objCBY = dgList.Rows[i].Cells["CBY"].Value;
            //                if (objCBY != null && objCBY != DBNull.Value)
            //                    strChargeWorkerName = objCBY.ToString();


            //                MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
            //                MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID("", "WATERFEECHARGE");
            //                MODELWATERFEECHARGE.WATERTOTALCHARGE = decBYSF;
            //                MODELWATERFEECHARGE.EXTRATOTALCHARGE = decFJF;
            //                MODELWATERFEECHARGE.TOTALCHARGE = decSum;
            //                MODELWATERFEECHARGE.OVERDUEMONEY = 0;
            //                MODELWATERFEECHARGE.CHARGETYPEID = "1";
            //                MODELWATERFEECHARGE.CHARGEClASS = "1";//收费类型是正常收取
            //                MODELWATERFEECHARGE.CHARGEBCYS = decSum;
            //                MODELWATERFEECHARGE.CHARGEBCSS = decSum;
            //                MODELWATERFEECHARGE.CHARGEYSQQYE = 0;
            //                MODELWATERFEECHARGE.CHARGEYSBCSZ = 0;
            //                MODELWATERFEECHARGE.CHARGEYSJSYE = 0;
            //                MODELWATERFEECHARGE.CHARGEWORKERID = strChargeWorkerID;
            //                MODELWATERFEECHARGE.CHARGEWORKERNAME = strChargeWorkerName;
            //                MODELWATERFEECHARGE.CHARGEDATETIME = dtNow;
            //                MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
            //                MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 1;

            //                if (BLLWATERFEECHARGE.Insert(MODELWATERFEECHARGE))
            //                {
            //                    try
            //                    {
            //                        MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
            //                        MODELreadMeterRecord.readMeterRecordId = strRecordID;
            //                        MODELreadMeterRecord.avePrice = decPrice;
            //                        MODELreadMeterRecord.waterMeterEndNumber = intBYDS;
            //                        MODELreadMeterRecord.totalNumber = intBYSL;
            //                        MODELreadMeterRecord.waterTotalCharge = decBYSF;
            //                        MODELreadMeterRecord.extraCharge1 = decFJF;
            //                        MODELreadMeterRecord.extraTotalCharge = decFJF;
            //                        MODELreadMeterRecord.totalCharge = decSum;
            //                        MODELreadMeterRecord.readMeterRecordDate = dtRecordDate;
            //                        MODELreadMeterRecord.checker = strUserName;
            //                        MODELreadMeterRecord.checkDateTime = dtNow;
            //                        MODELreadMeterRecord.checkState = "1";
            //                        MODELreadMeterRecord.chargeState = "3";
            //                        MODELreadMeterRecord.chargeID = MODELWATERFEECHARGE.CHARGEID;

            //                        if (BLLreadMeterRecord.UpdateHandSetData(MODELreadMeterRecord))
            //                        {
            //                            try
            //                            {
            //                                intSuccessCount++;
            //                                string connectString =
            //                                                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
            //                                string strSQLDelete = "DELETE FROM INTERDB WHERE recordid='" + strRecordID + "'";
            //                               int intRow= ExcuteSQL(strSQLDelete, connectString);
            //                            }
            //                            catch (Exception exxx)
            //                            {
            //                                labExcute.Text = "";
            //                                mes.Show("删除ID为" + strRecordID + "的抄表记录失败，请手动删除!错误:" + exxx.Message);
            //                                log.Write("删除ID为" + strRecordID + "的抄表记录失败：" + exxx.ToString(), MsgType.Error);
            //                                return;
            //                            }
            //                        }
            //                        else
            //                        {
            //                            BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);//回滚收费表
            //                            mes.Show("第" + (i + 1).ToString() + "行更新抄表收费标志失败,请重新操作!");
            //                            return;
            //                        }
            //                    }
            //                    catch (Exception exx)
            //                    {
            //                        BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);//回滚收费表
            //                        labExcute.Text = "";
            //                        mes.Show(exx.Message);
            //                        log.Write(exx.ToString(), MsgType.Error);
            //                        return;
            //                    }
            //                }
            //                else
            //                {
            //                    labExcute.Text = "";
            //                    mes.Show("第" + (i + 1).ToString() + "行插入收费记录失败,请重新操作!");
            //                    return;
            //                }
            //            }
            //        }
            //    }
            //    labExcute.Text = "";
            //    labExcute.Text = "执行成功:" + intSuccessCount + "条";
            //}
            //catch (Exception ex)
            //{
            //    labExcute.Text = "";
            //    mes.Show(ex.Message);
            //    log.Write(ex.ToString(), MsgType.Error);
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

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            toolStripPort.Items.Clear();
            string[] strPorts = SerialPort.GetPortNames();
            foreach (string strPortName in strPorts)
            {
                toolStripPort.Items.Add(strPortName);
            }
            if (toolStripPort.Items.Count > 0)
                toolStripPort.SelectedIndex = 0;
        }


        /// <summary>
        /// 抄表机端口号
        /// </summary>
        int intMachinePort = 0;
        private void toolStripConnect_Click(object sender, EventArgs e)
        {
            toolStripConnect.Enabled = false;
            string strPort = toolStripPort.Text;
            if (!strPort.ToUpper().Contains("COM"))
            {
                mes.Show("串口号不正确，请点击'刷新'按钮刷新串口号!");
                return;
            }
            else
            {
                if (strPort.Substring(0, 3).ToUpper() != "COM")
                {
                    toolStripConnect.Enabled = true;
                    mes.Show("请输入正确的串口号!");
                    return;
                }
                else
                {
                    strPort = strPort.Replace("COM", "");
                    if (!Information.IsNumeric(strPort))
                    {
                        toolStripConnect.Enabled = true;
                        mes.Show("请输入正确的串口号!");
                        return;
                    }
                    else
                    {
                        intMachinePort = Convert.ToInt16(strPort);
                        int intReturn = openport(intMachinePort);
                        if (intReturn != intMachinePort)
                        {
                            toolStripConnect.Enabled = true;
                            mes.Show(GetErrorMes(intReturn));
                            return;
                        }
                        else
                        {
                            toolStripConnect.Enabled = false;
                            toolStripClose.Enabled = true;
                            string strFileTmp = Application.StartupPath + @"\filetmp.tmp";
                            if (File.Exists(strFileTmp))
                                File.Delete(strFileTmp);

                            int intReturnCount = getlist(intMachinePort);
                            if (File.Exists(strFileTmp))
                            {
                                lstMachineFileList.Items.Clear();
                                //把文件转换成二进制流
                                byte[] byteData = new byte[500];
                                FileStream fs = new FileStream(strFileTmp, FileMode.Open, FileAccess.Read);
                                BinaryReader read = new BinaryReader(fs);
                                read.Read(byteData, 0, byteData.Length);
                                for (int i = 0; i < intReturnCount; i++)
                                {
                                    string strFileName = System.Text.Encoding.Default.GetString(byteData, i * 32, 8);
                                    string strFileAttrib = System.Text.Encoding.Default.GetString(byteData, i * 32+8, 3);
                                //string str = System.Text.Encoding.Default.GetString(byteData,i*32,32);
                                //str = str.Replace(" ","");
                                    lstMachineFileList.Items.Add(strFileName.Replace(" ", "") + "." + strFileAttrib.Replace(" ", ""));
                                }
                                read.Close();
                                fs.Close();
                                ////读取文件内容
                                //StreamReader objReader = new StreamReader(strFileTmp);
                                //string sLine = "";
                                //ArrayList arrText = new ArrayList();
                                //while (sLine != null)
                                //{
                                //    sLine = objReader.ReadLine();
                                //    if (sLine != null)
                                //        arrText.Add(sLine);
                                //}
                                //objReader.Close();
                            }
                        }
                    }
                }
            }
            //toolStripConnect.Enabled = true;
        }

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            pos_exitcomm(intMachinePort);
            closeport();
            intMachinePort = 0;
            toolStripClose.Enabled = false;
            toolStripConnect.Enabled = true;
        }

        private void btSetMeterReader_Click(object sender, EventArgs e)
        {
            if (lstMeterReader.SelectedItem != null && lstMeterReader.SelectedItem != DBNull.Value)
            {
                StringBuilder strID = new StringBuilder(), strName = new StringBuilder();
                ListItem ListItem = (ListItem)lstMeterReader.SelectedItem;
                strID.Append(ListItem.strID);
                if (strID.ToString() != "")
                {
                    strName.Append(ListItem.strName);
                    int intReturn = down_userinfo(intMachinePort, strID,strName);
                    if (intReturn == 0)
                    {
                        mes.Show("抄表员设置成功!");
                    }
                    else
                    {
                        mes.Show(GetErrorMes(intReturn));
                        return;
                    }
                }

            }
            else
            {
                mes.Show("未检测到选择的抄表员,设置失败!");
                return;
            }
        }

        private void txtNameS_TextChanged(object sender, EventArgs e)
        {
            GetMeterReader(" AND USERNAME LIKE '%"+txtNameS.Text+"%'");
        }

        private void frmMeterReadingMachineManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            pos_exitcomm(intMachinePort);
            closeport();
            if (bgWork.IsBusy)
                bgWork.CancelAsync();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lstMachineFileList.SelectedItem != null && lstMachineFileList.SelectedItem != DBNull.Value)
            {
                StringBuilder strFileName=new StringBuilder();
                strFileName.Append(lstMachineFileList.SelectedItem.ToString());
               int intReturn= deletefile(intMachinePort,strFileName);
               if (intReturn == 0)
               {
                   lstMachineFileList.Items.Remove(lstMachineFileList.SelectedItem);
                   mes.Show("删除成功!");
               }
               else
               {
                   mes.Show(GetErrorMes(intReturn));
                   return;
               }
            }
        }

        /// <summary>
        /// 打开的文件名，包含文件路径
        /// </summary>
        string strFileNamePath = "";

        /// <summary>
        /// 打开的文件名，只包含文件名及后缀
        /// </summary>
        string strFileName = "";

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            //bgWork.RunWorkerAsync();
            try
            {

                OpenFileDialog OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.Filter = "所有文件(*.*)|*.*|数据库文件(.dbf)|*.dbf|文本文件(.txt)|*.txt|程序文件(.bin)|*.bin";
                OpenFileDialog.InitialDirectory = strDBFPath;
                OpenFileDialog.FilterIndex = 0;
                OpenFileDialog.RestoreDirectory = true;
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    strFileNamePath = OpenFileDialog.FileName;
                    strFileName = OpenFileDialog.SafeFileName;

                    if (mes.ShowQ("文件下载后，抄表机中原有的文件将被覆盖掉," + Environment.NewLine + "确定要将文件'" + strFileName + "'下载到抄表机中吗？") == DialogResult.OK)
                    {
                        bgWork.RunWorkerAsync();

                        //labState.Text = "正在删除原文件......";
                        //StringBuilder strBFileName = new StringBuilder();
                        //strBFileName.Append(strFileName);
                        //int intReturnDelete = deletefile(intMachinePort, strBFileName);
                        //StringBuilder strPCFileName = new StringBuilder();
                        //strPCFileName.Append(strFileNamePath);

                        //StringBuilder strFileNameB = new StringBuilder();
                        //strFileNameB.Append(strFileName);

                        //labState.Text = "正在导入新文件......";
                        //int intReturn = downtofile(intMachinePort, strPCFileName, strFileNameB);
                        //if (intReturn == 0)
                        //{

                        //    int intReturnCount = getlist(intMachinePort);
                        //    string strFileTmp = Application.StartupPath + @"\filetmp.tmp";
                        //    if (File.Exists(strFileTmp))
                        //    {
                        //        lstMachineFileList.Items.Clear();
                        //        //把文件转换成二进制流
                        //        byte[] byteData = new byte[100];
                        //        FileStream fs = new FileStream(strFileTmp, FileMode.Open, FileAccess.Read);
                        //        BinaryReader read = new BinaryReader(fs);
                        //        read.Read(byteData, 0, byteData.Length);
                        //        for (int i = 0; i < intReturnCount; i++)
                        //        {
                        //            string strFileName1 = System.Text.Encoding.Default.GetString(byteData, i * 32, 8);
                        //            string strFileAttrib = System.Text.Encoding.Default.GetString(byteData, i * 32 + 8, 3);
                        //            lstMachineFileList.Items.Add(strFileName1.Replace(" ", "") + "." + strFileAttrib.Replace(" ", ""));
                        //        }
                        //    }
                        //    labState.Text = "文件导入成功!";
                        //}
                        //else
                        //{
                        //    mes.Show(GetErrorMes(intReturn));
                        //    return;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                log.Write(e.ToString(), MsgType.Error);
                labState.Text = "导入文件错误:" + ex.Message;
            }
        }

        private void btDownFile_Click(object sender, EventArgs e)
        {
            if (txtOpenFileName.Text.Trim() == "")
            {
                mes.Show("请先打开要下载的文件!");
                return;
            }
            StringBuilder strFileName = new StringBuilder();
            strFileName.Append(txtOpenFileName.Text);

        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                labState.Text = "正在删除原文件......";
                StringBuilder strBFileName = new StringBuilder();
                strBFileName.Append(strFileName);
                int intReturnDelete = deletefile(intMachinePort, strBFileName);
                StringBuilder strPCFileName = new StringBuilder();
                strPCFileName.Append(strFileNamePath);

                StringBuilder strFileNameB = new StringBuilder();
                strFileNameB.Append(strFileName);

                labState.Text = "正在导入新文件......";
                int intReturn = downtofile(intMachinePort, strPCFileName, strFileNameB);
                if (intReturn == 0)
                {
                    string strFileTmp = Application.StartupPath + @"\filetmp.tmp";
                    if (File.Exists(strFileTmp))
                        File.Delete(strFileTmp);

                    int intReturnCount = getlist(intMachinePort);

                    if (File.Exists(strFileTmp))
                    {
                        lstMachineFileList.Items.Clear();
                        //把文件转换成二进制流
                        byte[] byteData = new byte[500];
                        FileStream fs = new FileStream(strFileTmp, FileMode.Open, FileAccess.Read);
                        BinaryReader read = new BinaryReader(fs);
                        read.Read(byteData, 0, byteData.Length);
                        for (int i = 0; i < intReturnCount; i++)
                        {
                            string strFileName1 = System.Text.Encoding.Default.GetString(byteData, i * 32, 8);
                            string strFileAttrib = System.Text.Encoding.Default.GetString(byteData, i * 32 + 8, 3);
                            lstMachineFileList.Items.Add(strFileName1.Replace(" ", "") + "." + strFileAttrib.Replace(" ", ""));
                        }
                        read.Close();
                        fs.Close();
                    }
                    labState.Text = "文件导入成功!";
                }
                else
                {
                    mes.Show(GetErrorMes(intReturn));
                    labState.Text = GetErrorMes(intReturn);
                    return;
                }
            }
            catch (Exception ex)
            {
                log.Write(e.ToString(), MsgType.Error);
                mes.Show( "导入文件错误:" + ex.Message);
            }
        }
    }
}
