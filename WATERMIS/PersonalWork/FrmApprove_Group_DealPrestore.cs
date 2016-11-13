using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BLL;
using MODEL;
using BASEFUNCTION;
using System.Threading;
using DBinterface.IDAL;
using DBinterface.DAL;
using System.Data.SqlClient;

namespace PersonalWork
{
    public partial class FrmApprove_Group_DealPrestore : DockContentEx
    {
        public FrmApprove_Group_DealPrestore()
        {
            InitializeComponent();
            tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel1, true, null);
        }
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        SqlServerHelper SqlServerHelper = new SqlServerHelper();

        RMBToCapMoney RMBToCapMoney = new RMBToCapMoney();
        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLoginID = "";
        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strLoginName = "";

        /// <summary>
        /// 业扩审批流程唯一标识
        /// </summary>
        public string strTaskID = "";

        /// <summary>
        /// 业扩审批节点
        /// </summary>
        public string strPointSort = "";

        /// <summary>
        /// 单位用户唯一标识
        /// </summary>
        public string strGroupID = "";

        /// <summary>
        /// 抄表员表，为收费获取抄表员电话做准备
        /// </summary>
        DataTable dtMeterReader = new DataTable();

        /// <summary>
        /// 用户信息表
        /// </summary>
        DataTable dtWaterUserList = new DataTable();

        /// <summary>
        /// 业扩和营业的预存款
        /// </summary>
        decimal decSumYuCun_YK = 0, decSumYuCun_YY = 0;

        private void frmModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strLoginName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            BindMeterReader();
            BindChargeType();
            BindWaterUserAndMeter();
            GetYuCun_YK();

            cmbChargeType.SelectedValue = 6;

            GetMaxReceiptNO();
        }

        /// <summary>
        /// 获取当前收费员最大8位收据号
        /// </summary>
        private void GetMaxReceiptNO()
        {
            string strSQL = "SELECT TOP 1 RECEIPTNO FROM Meter_Charge WHERE RECEIPTNO<>N'' AND CHARGEWORKERID=@CHARGEWORKERID ORDER BY ReceiptPrintTime DESC";
            object objMax = SqlServerHelper.GetFirsRowsValue(strSQL, new SqlParameter[] { new SqlParameter("@CHARGEWORKERID", strLoginID) });
            if (Information.IsNumeric(objMax))
                txtReceiptNO.Text = Convert.ToInt32(objMax).ToString().PadLeft(8, '0');
            else
                txtReceiptNO.Text = "00000001";
        }

        /// <summary>
        /// 获取需要批量处理预存余额的用户信息
        /// </summary>
        private void BindWaterUserAndMeter()
        {
            string strSQL =string.Format(@"SELECT * FROM V_WATERUSER_CONNECTWATERMETER WHERE waterUserId IN (SELECT waterUserId 
                FROM Meter_Groupeople_Detail WHERE GroupID='{0}')",strGroupID);
            DataTable dt = SqlServerHelper.GetDateTableBySql(strSQL);
            dgList.DataSource = dt;

            object obj = dt.Compute("SUM(prestore)", "");
            if (Information.IsNumeric(obj))
                decSumYuCun_YY = Convert.ToDecimal(obj);

            if (dt.Rows.Count > 0 || decSumYuCun_YY>0)
                btCharge.Enabled = true;

            labYuCunSum_YY.Text = decSumYuCun_YY.ToString("F2") + "元";
        }
        /// <summary>
        /// 获取业扩总预存款
        /// </summary>
        private void GetYuCun_YK()
        {
            string strGetYC = string.Format(@"DECLARE @TaskID NVARCHAR(50)='{0}'
        DECLARE @LastPoingSort INT=0
        SELECT TOP 1 @LastPoingSort=PointSort FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR 
        WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<14 AND MWR.YS=1 ORDER BY PointSort DESC
        SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID IN 
        (SELECT ResolveID FROM Meter_WorkResolve WHERE 
        TaskID=@TaskID AND PointSort=@LastPoingSort) AND FEE>0 AND FeeID IN  (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)",strTaskID);
        object obj=SqlServerHelper.GetFirsRowsValue(strGetYC);
        if (Information.IsNumeric(obj))
            decSumYuCun_YK = Convert.ToDecimal(obj);
            labYuCunSum_YK.Text = decSumYuCun_YK.ToString("F2") + "元";
        }

        /// <summary>
        /// 绑定收费类型
        /// </summary>
        private void BindChargeType()
        {
            DataTable dt = BLLCHARGETYPE.QUERY("");
            DataRow dr = dt.NewRow();
            cmbChargeType.DataSource = dt;
            cmbChargeType.DisplayMember = "CHARGETYPENAME";
            cmbChargeType.ValueMember = "CHARGETYPEID";
        }
        /// <summary>
        /// 获取抄表员
        /// </summary>
        private void BindMeterReader()
        {
            dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是' ORDER BY USERNAME");
        }
        private void dgWaterList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        void cmbModifyValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 实现数据的四舍五入法
        /// </summary>
        /// <param name="v">要进行处理的数据</param>
        /// <param name="x">保留的小数位数</param>
        /// <returns>四舍五入后的结果</returns>
        private double Round(double v, int x)
        {
            bool isNegative = false;
            //如果是负数
            if (v < 0)
            {
                isNegative = true;
                v = -v;
            }

            int IValue = 1;
            for (int i = 1; i <= x; i++)
            {
                IValue = IValue * 10;
            }
            double Int = Math.Round(v * IValue + 0.5, 0);
            v = Int / IValue;

            if (isNegative)
            {
                v = -v;
            }

            return v;
        }

#region 进度条
        private delegate void SetPos(int ipos);
        private void SetTextMessage(int ipos)
        {
            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(SetTextMessage);
                this.Invoke(setpos, new object[] { ipos });
            }
            else
            {
                this.prbCharge.Value = Convert.ToInt32(ipos);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程
            fThread.Start();
        }
        private void SleepT()
        {
            for (int i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(100);//没什么意思，单纯的执行延时
                SetTextMessage(100 * i / 500);
            }
        }
#endregion
        private void btCharge_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgList.Rows.Count == 0)
                {
                    mes.Show("未找到预交水费的用户信息!");
                    return;
                }
                if (!Information.IsNumeric(txtBCYC.Text))
                    return;
                else
                    if (Convert.ToDecimal(txtBCYC.Text) <= 0)
                    {
                        mes.Show("预存金额不能为'0'");
                        txtBCYC.Focus();
                        return;
                    }

                if (chkReceipt.Checked)
                {
                    if (txtReceiptNO.Text.Trim() == "")
                    {
                        mes.Show("收据号不能为空!");
                        return;
                    }
                }
                txtReceiptNO.Text = txtReceiptNO.Text.Trim().PadLeft(8,'0');

                //预存金额
                decimal decYCMoney = Convert.ToDecimal(txtBCYC.Text);

                for (int i = 0; i < dgList.SelectedRows.Count; i++)
                {
                    try
                    {
                        string strWaterUserID = "", strWaterUserNO = "", strWaterUserName = "", strWaterUserAddress = "",
                            strMeterReaderID = "", strMeterReaderName = "", strMeterReaderTel = "";

                        object objWaterUserID = dgList.SelectedRows[i].Cells["waterUserId"].Value;
                        if (objWaterUserID == null || objWaterUserID == DBNull.Value)
                        {
                            mes.Show("第'" + (i + 1).ToString() + "行用户ID获取失败,批量收费终止!");
                            return;
                        }
                        if ((decSumYuCun_YY + decYCMoney) > decSumYuCun_YK)
                            if (mes.ShowQ("检测到当前营业用户预存余额>业扩预存款，确定要继续吗？") != DialogResult.OK)
                                return;

                        #region 生成用户信息
                        strWaterUserID = objWaterUserID.ToString();
                        object objWaterUserMes = dgList.SelectedRows[i].Cells["waterUserNO"].Value;
                        if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                        {
                            strWaterUserNO = objWaterUserMes.ToString();
                        }

                        objWaterUserMes = dgList.SelectedRows[i].Cells["waterUserName"].Value;
                        if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                        {
                            strWaterUserName = objWaterUserMes.ToString();
                        }

                        objWaterUserMes = dgList.SelectedRows[i].Cells["waterUserAddress"].Value;
                        if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                        {
                            strWaterUserAddress = objWaterUserMes.ToString();
                        }

                        object objWaterUser = dgList.SelectedRows[i].Cells["METERREADERID"].Value;
                        if (objWaterUser != null && objWaterUser != DBNull.Value)
                        {
                            strMeterReaderID = objWaterUser.ToString();

                            DataRow[] drMeterReader = dtMeterReader.Select("LOGINID='" + strMeterReaderID + "'");
                            object objMeterReaderTel = drMeterReader[0]["TELEPHONENO"];
                            if (objMeterReaderTel != null && objMeterReaderTel != DBNull.Value)
                                strMeterReaderTel = objMeterReaderTel.ToString();
                        }

                        objWaterUser = dgList.SelectedRows[i].Cells["meterReaderName"].Value;
                        if (objWaterUser != null && objWaterUser != DBNull.Value)
                        {
                            strMeterReaderName = objWaterUser.ToString();
                        }
                        #endregion

                        //计算结算余额
                        decimal decQQYE = 0, decJSYE = 0;
                        object objPrestore = dgList.SelectedRows[i].Cells["prestore"].Value;
                        if (Information.IsNumeric(objPrestore))
                            decQQYE = Convert.ToDecimal(objPrestore);

                        decJSYE = decQQYE + Convert.ToDecimal(txtBCYC.Text);

                        string CHARGEID = GETTABLEID.GetTableID(strLoginID, "WATERFEECHARGE");
                        string PRESTORERUNNINGACCOUNTID = GETTABLEID.GetTableID(strLoginID, "PRESTORERUNNINGACCOUNT");
                        string _chargeID = sysidal.GetNewChargeID(strLoginID);

                        string strSQL = string.Format(@"BEGIN TRAN
DECLARE @prestore DECIMAL(18,0)=0
SELECT @prestore=prestore FROM Meter_Install_Group WHERE GROUPID='{0}'

INSERT INTO Meter_Charge (CHARGEID,TaskID,CHARGEBCSS,CHARGEBCYS,TOTALCHARGE,prestore,FeeList,
CHARGETYPEID,CHARGEClASS,CHARGEWORKERID,CHARGEWORKERNAME,CHARGEDATETIME)  
VALUES('{1}','{2}',0-{3},0,0,@prestore-{3},'余额转营业','6','17','{4}','{5}',GETDATE())

UPDATE Meter_Install_Group SET prestore=@prestore-{3} WHERE GROUPID='{0}'

SELECT @prestore=prestore FROM waterUser WHERE waterUserId='{6}'

INSERT INTO WATERFEECHARGE (CHARGEID,CHARGETYPEID,CHARGEClASS,CHARGEBCYS,CHARGEBCSS,CHARGEYSQQYE,CHARGEYSBCSZ,CHARGEYSJSYE,CHARGEWORKERID,
CHARGEWORKERNAME,CHARGEDATETIME,RECEIPTPRINTCOUNT,RECEIPTNO) 
VALUES('{9}','6','17',0,{3},@prestore,{3},@prestore+{3},'{4}','{5}',GETDATE(),'1','{7}')

INSERT INTO PRESTORERUNNINGACCOUNT (PRESTORERUNNINGACCOUNTID,CHARGEID,WATERUSERID,WATERUSERNO,WATERUSERNAME,WATERUSERADDRESS,AREANO,PIANNO,DUANNO,ORDERNUMBER,COMMUNITYID,COMMUNITYNAME,
METERREADERID,METERREADERNAME,CHARGERID,CHARGERNAME,WATERUSERTYPEID,WATERUSERTYPENAME,WATERMETERTYPEID,WATERMETERTYPEVALUE,WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME,WATERUSERHOUSETYPE,CREATETYPE)
SELECT '{8}','{9}', WATERUSERID,WATERUSERNO,WATERUSERNAME,WATERUSERADDRESS,AREANO,PIANNO,DUANNO,ORDERNUMBER,COMMUNITYID,COMMUNITYNAME,
METERREADERID,METERREADERNAME,CHARGERID,CHARGERNAME,WATERUSERTYPEID,WATERUSERTYPENAME,WATERMETERTYPEID,WATERMETERTYPEVALUE,WATERMETERTYPECLASSID,
WATERMETERTYPECLASSNAME,WATERUSERHOUSETYPE,CREATETYPE FROM V_WATERUSER_CONNECTWATERMETER WHERE waterUserId='{6}'

UPDATE waterUser SET prestore=@prestore-{3} WHERE GROUPID='{0}'

COMMIT TRAN", strGroupID, _chargeID, strTaskID, decYCMoney, strLoginID, strLoginName, strWaterUserID, txtReceiptNO.Text, PRESTORERUNNINGACCOUNTID, CHARGEID);
                        int intRows = SqlServerHelper.ExcuteSql(strSQL);
                        if (intRows > 0)
                        {
                            decSumYuCun_YY = decSumYuCun_YY + decYCMoney;
                            labYuCunSum_YY.Text = decSumYuCun_YY.ToString() + "元";

                            decimal decUserArearage = 0, decWaterUserPrestore = 0;
                            object objUserArearage = dgList.SelectedRows[i].Cells["USERAREARAGE"].Value;
                            if (Information.IsNumeric(objUserArearage))
                                decUserArearage = Convert.ToDecimal(objUserArearage);
                            object objUserPrestore = dgList.SelectedRows[i].Cells["prestore"].Value;
                            if (Information.IsNumeric(objUserPrestore))
                                decWaterUserPrestore = Convert.ToDecimal(objUserPrestore);
                            decWaterUserPrestore = decWaterUserPrestore + decYCMoney;
                            decUserArearage = decUserArearage + decYCMoney;
                            dgList.SelectedRows[i].Cells["USERAREARAGE"].Value = decUserArearage.ToString("F2");
                            dgList.SelectedRows[i].Cells["prestore"].Value = decWaterUserPrestore.ToString("F2");

                            //如果勾选了打收据，打印收据
                            if (chkReceipt.Checked)
                            {
                                //--打印收据
                                #region
                                FastReport.Report report1 = new FastReport.Report();
                                try
                                {
                                    DataTable dtLastRecord = BLLwaterUser.QuerySQL("SELECT TOP 1 readMeterRecordId,readMeterRecordYearAndMonth,waterMeterLastNumber," +
                                        "(CASE chargeState WHEN 0  THEN waterMeterLastNumber " +
                                        "ELSE waterMeterEndNumber END) AS waterMeterEndNumber " +
                                        "FROM readMeterRecord " +
                                        "WHERE WATERUSERID='" +
                                        strWaterUserID + "' ORDER BY readMeterRecordYearAndMonth DESC,readMeterRecordDate DESC");
                                    DataTable dtTemp = dtLastRecord.Clone();
                                    dtTemp.Columns["readMeterRecordYearAndMonth"].DataType = typeof(string);
                                    if (dtLastRecord.Rows.Count > 0)
                                    {
                                        dtTemp.ImportRow(dtLastRecord.Rows[0]);
                                        object objReadMeterRecordYearAndMonth = dtTemp.Rows[0]["readMeterRecordYearAndMonth"];
                                        if (Information.IsDate(objReadMeterRecordYearAndMonth))
                                            dtTemp.Rows[0]["readMeterRecordYearAndMonth"] = Convert.ToDateTime(objReadMeterRecordYearAndMonth).ToString("yyyy-MM");
                                    }
                                    //DataTable dtTemp = dtLastRecord.Copy();
                                    DataSet ds = new DataSet();
                                    dtTemp.TableName = "营业坐收收据模板";
                                    ds.Tables.Add(dtTemp);
                                    // load the existing report
                                    report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\预存收费收据模板.frx");

                                    (report1.FindObject("txtDateTime") as FastReport.TextObject).Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    (report1.FindObject("CellWaterUserNO") as FastReport.Table.TableCell).Text = strWaterUserNO;
                                    (report1.FindObject("CellWaterUserName") as FastReport.Table.TableCell).Text = strWaterUserName;
                                    (report1.FindObject("CellWaterUserAddress") as FastReport.Table.TableCell).Text = strWaterUserAddress;

                                    (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额: " + decQQYE.ToString("F2");
                                    string strBCSS = decYCMoney.ToString("F2");
                                    (report1.FindObject("txtBCJF") as FastReport.TextObject).Text = "本次预存:         " + strBCSS;
                                    (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额: " + decJSYE.ToString("F2");
                                    (report1.FindObject("txtChargeWorkerName") as FastReport.TextObject).Text = strLoginName;
                                    (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + txtReceiptNO.Text;

                                    (report1.FindObject("txtMeterReader") as FastReport.TextObject).Text = strMeterReaderName;
                                    (report1.FindObject("txtMeterReaderTel") as FastReport.TextObject).Text = strMeterReaderTel;

                                    string strCapMoney = RMBToCapMoney.CmycurD(strBCSS);
                                    (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;

                                    // register the dataset
                                    report1.RegisterData(ds);
                                    report1.GetDataSource("营业坐收收据模板").Enabled = true;
                                    report1.PrintSettings.ShowDialog = false;
                                    report1.Prepare();
                                    report1.Print();

                                    //获取新的收据号码,8位收据号
                                    if (Information.IsNumeric(txtReceiptNO.Text))
                                    {
                                        txtReceiptNO.Text = (Convert.ToInt64(txtReceiptNO.Text) + 1).ToString().PadLeft(8, '0');
                                    }
                                }
                                catch (Exception exx)
                                {
                                    MessageBox.Show(exx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                finally
                                {
                                    // free resources used by report
                                    report1.Dispose();
                                }
                                #endregion
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show("预收失败!原因:" + ex.Message);
                        log.Write(ex.ToString(), MsgType.Error);
                        return;
                    }
                }
                btCharge.Enabled = false;
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
        }
        /// <summary>
        /// 将一位数字转换成中文大写数字
        /// </summary>
        private string ConvertChinese(string str)
        {
            string cstr = "";
            switch (str)
            {
                case "0": cstr = "零"; break;
                case "1": cstr = "壹"; break;
                case "2": cstr = "贰"; break;
                case "3": cstr = "叁"; break;
                case "4": cstr = "肆"; break;
                case "5": cstr = "伍"; break;
                case "6": cstr = "陆"; break;
                case "7": cstr = "柒"; break;
                case "8": cstr = "捌"; break;
                case "9": cstr = "玖"; break;
            }
            return (cstr);
        }

        private void txtInvoiceNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void dgWaterUserDebts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgList.Columns[e.ColumnIndex].Name == "waterUserHouseType")
            {
                object objWaterUserHouseType = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (objWaterUserHouseType != null && objWaterUserHouseType != DBNull.Value)
                {
                    if (objWaterUserHouseType.ToString() == "1")
                        dgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "楼房";
                    else if (objWaterUserHouseType.ToString() == "2")
                        dgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "平房";
                }
            }
        }

        private void txtBCYC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btCharge_Click(null,null);
            }
        }

        private void dgWaterUser_SelectionChanged(object sender, EventArgs e)
        {
            labTip.Text = "已选" + dgList.SelectedRows.Count + "户";
        }

        private void txtBCYC_MouseClick(object sender, MouseEventArgs e)
        {
            txtBCYC.SelectAll();
        }

        private void txtBCYC_TextChanged(object sender, EventArgs e)
        {
            if (txtBCYC.Text.Trim() == "")
            {
                txtBCYC.Text = "0";
                txtBCYC.SelectAll();
            }
        }
    }
}
