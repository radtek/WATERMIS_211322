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

namespace WATERFEEMANAGE
{
    public partial class frmWaterMeterReadBatchCharge : DockContentEx
    {
        public frmWaterMeterReadBatchCharge()
        {
            InitializeComponent();
            tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel1, true, null);
        }
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();
        BLLINVOICEFETCH BLLINVOICEFETCH = new BLLINVOICEFETCH();
        //BLLSYSTEMARGUMENTS BLLSYSTEMARGUMENTS = new BLLSYSTEMARGUMENTS();//获取发票号长度

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
        /// 抄表员表，为收费获取抄表员电话做准备
        /// </summary>
        DataTable dtMeterReader = new DataTable();

        private void frmModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgWaterUser.AutoGenerateColumns = false;

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

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindCommunity(cmbCommunityS, "0");

            BindChargeType();

            GenerateTree();
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
            dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000'");
            DataRow dr = dt.NewRow();
            dr["COMMUNITYNAME"] = "全部小区";
            dr["COMMUNITYID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "COMMUNITYNAME";
            cmb.ValueMember = "COMMUNITYID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
        /// 按抄表本、区域、抄表员动态生成抄表本树形结构
        /// </summary>
        private void GenerateTree()
        {
            trMeterReading.Nodes.Clear();

            #region 按小区生成抄表本树形结构
            TreeNode tnHeadArea = trMeterReading.Nodes.Add("|无关ID|", "全部区域", 0, 1);
            DataTable dtArea = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000' ORDER BY COMMUNITYNAME");
            for (int i = 0; i < dtArea.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object objID = dtArea.Rows[i]["COMMUNITYID"];
                if (objID != null && objID != DBNull.Value)
                {
                    strID = "COMMUNITYNAME|无关ID| AND COMMUNITYID='" + objID.ToString() + "'";
                }
                object objName = dtArea.Rows[i]["COMMUNITYNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnAreaMeterReading = tnHeadArea.Nodes.Add(strID, strName, 0, 1);
            }
            tnHeadArea.Nodes.Add("|无关ID| AND COMMUNITYID=''", "小区为空", 0, 1);
            tnHeadArea.Expand();
            #endregion

            #region 按抄表员生成抄表本树形结构
            TreeNode tnHeadMeterReader = trMeterReading.Nodes.Add("|无关ID|", "全部抄表员", 0, 1);
            dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReaderS='是'");
            for (int i = 0; i < dtMeterReader.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object objID = dtMeterReader.Rows[i]["LOGINID"];
                if (objID != null && objID != DBNull.Value)
                {
                    strID = "METERREADER|无关ID| AND loginId='" + objID.ToString() + "'";
                }
                object objName = dtMeterReader.Rows[i]["USERNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
            }
            tnHeadMeterReader.Nodes.Add("|无关ID| AND meterReadingID=''", "抄表员为空", 0, 1);
            #endregion
            trMeterReading.SelectedNode = tnHeadArea;
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
        /// 存储查询到的用户表
        /// </summary>
        DataTable dtUserList = new DataTable();

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
            //if()
            string strNodeID = e.Node.Name;
            string[] strNodeIDSpit = strNodeID.Split('|');
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

                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("批量收费界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("批量收费界面:" + ex.ToString(), MsgType.Error);
            }
        }
        private void LoadData(string[] strNodeID)
        {
            prbCharge.Visible = false;
            labProgress.Visible = false;

            //获取新的收据号码,8位收据号
            DataTable dtNewReceriptNO = BLLWATERFEECHARGE.GetMaxReceiptNO(strLoginID);
            if (dtNewReceriptNO.Rows.Count > 0)
            {
                object objReceiptNO = dtNewReceriptNO.Rows[0]["RECEIPTNO"];
                if (Information.IsNumeric(objReceiptNO))
                {
                    txtReceiptNO.Text = (Convert.ToInt64(objReceiptNO) + 1).ToString().PadLeft(8, '0');
                }
            }
            else
            {
                txtReceiptNO.Text="00000001";
            }

            //查询条件
            string strFilter = strSeniorFilterHidden + strNodeID[2];

            if (txtWaterUserNOSearch.Text.Trim() != "")
                strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";

            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
            if (cmbPianNOS.SelectedIndex > 0)
                strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

            if (cmbCommunityS.SelectedIndex > 0)
                strFilter += " AND communityID='" + cmbCommunityS.SelectedValue.ToString() + "'";

            if (txtBuildingNO.Text != "")
                strFilter += " AND buildingNO='" + txtBuildingNO.Text + "'";

            if (txtUnitNO.Text != "")
                strFilter += " AND unitNO LIKE '%" + txtUnitNO.Text + "%'";

            if (rbMeterReader.Checked)
                strFilter += " ORDER BY areaNO,pianNO,duanNO,ordernumber";
            if (rbWaterUserName.Checked)
                strFilter += " ORDER BY waterUserName";
            if (rbWaterUserNO.Checked)
                strFilter += " ORDER BY waterUserNO";


            dtUserList = BLLwaterUser.QueryInitialWaterUser(strFilter);
            dgWaterUser.DataSource = dtUserList;

            int intWaterUserCount = dtUserList.Rows.Count;

            if (intWaterUserCount == 0)
            {
                txtBCYC.Text = "0";
                btCharge.Enabled = false;
                return;
            }
            else
                btCharge.Enabled = true;

            txtBCYC.Focus();
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

        private void toolcmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode tn = trMeterReading.SelectedNode;
            if (tn != null)
            {
                TreeViewEventArgs ex = new TreeViewEventArgs(tn, TreeViewAction.ByMouse);
                trMeterReading_AfterSelect(null, ex);
            }
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
                if (dgWaterUser.Rows.Count == 0)
                {
                    mes.Show("未找到预交水费的用户信息!");
                    return;
                }

                if (cmbChargeType.SelectedValue == null || cmbChargeType.SelectedValue == DBNull.Value)
                {
                    mes.Show("收费方式不能为空!");
                    cmbChargeType.Focus();
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

                for (int i = 0; i < dgWaterUser.SelectedRows.Count; i++)
                {
                        try
                        {
                            string strWaterUserID = "", strWaterUserNO = "", strWaterUserName = "", strWaterUserNameCode = "", strTelNO = "", strWaterUserPhone = "", strWaterUserAddress = "",
                                strAreaNO = "", strPianNO = "", strDuanNO = "", strCommunityID = "", strCommunityName = "", strBuildingNO = "", strUnitNO = "", strMeterReaderID = "",
                                strMeterReaderName = "",strMeterReaderTel="", strChargeID = "", strChargerName = "", strWaterUserTypeID = "", strWaterUserTypeName = "", strWaterUserHouseType = "",
                                strCreateType = "",strWaterMeterTypeID="",strWaterMeterTypeName="",strWaterMeterTypeClassID="",strWaterMeterTypeClassName="";
                            int intPepleCount = 1, intOrderNumber = 0;

                            object objWaterUserID = dgWaterUser.SelectedRows[i].Cells["waterUserId"].Value;
                            if (objWaterUserID == null || objWaterUserID == DBNull.Value)
                            {
                                mes.Show("第'" + (i + 1).ToString() + "行用户ID获取失败,批量收费终止!");
                                return;
                            }

                            //计算结算余额
                            decimal decQQYE = 0, decJSYE = 0;
                            object objPrestore = dgWaterUser.SelectedRows[i].Cells["prestore"].Value;
                            if (Information.IsNumeric(objPrestore))
                                decQQYE = Convert.ToDecimal(objPrestore);

                            decJSYE = decQQYE + Convert.ToDecimal(txtBCYC.Text);

                            #region 生成用户信息
                            strWaterUserID = objWaterUserID.ToString();
                            object objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["waterUserNO"].Value; 
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterUserNO = objWaterUserMes.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["waterUserName"].Value; 
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterUserName = objWaterUserMes.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["waterUserTelphoneNO"].Value;
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strTelNO = objWaterUserMes.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["waterPhone"].Value;
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterUserPhone = objWaterUserMes.ToString();
                            }

                            object objWaterUser = dgWaterUser.SelectedRows[i].Cells["areaNO"].Value; 
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strAreaNO = objWaterUser.ToString();
                            }
                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["pianNO"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strPianNO = objWaterUser.ToString();
                            }
                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["DuanNO"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strDuanNO = objWaterUser.ToString();
                            }
                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["COMMUNITYID"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strCommunityID = objWaterUser.ToString();
                            }
                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["COMMUNITYNAME"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strCommunityName = objWaterUser.ToString();
                            }

                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["buildingNO"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strBuildingNO = objWaterUser.ToString();
                            }

                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["unitNO"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strUnitNO = objWaterUser.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["WATERUSERTYPEID"].Value;
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterUserTypeID = objWaterUserMes.ToString();
                            }
                            
                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["waterUserTypeName"].Value;
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterUserTypeName = objWaterUserMes.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["WATERMETERTYPEID"].Value;
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterMeterTypeID = objWaterUserMes.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["WATERMETERTYPEVALUE"].Value;
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterMeterTypeName = objWaterUserMes.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["WATERMETERTYPECLASSID"].Value;
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterMeterTypeClassID = objWaterUserMes.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["WATERMETERTYPECLASSNAME"].Value;
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterMeterTypeClassName = objWaterUserMes.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["waterUserAddress"].Value; 
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterUserAddress = objWaterUserMes.ToString();
                            }
                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["createType"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strCreateType = objWaterUser.ToString();
                            }

                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["METERREADERID"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strMeterReaderID = objWaterUser.ToString();

                               DataRow[] drMeterReader= dtMeterReader.Select("LOGINID='"+strMeterReaderID+"'");
                               object objMeterReaderTel = drMeterReader[0]["TELEPHONENO"];
                               if (objMeterReaderTel != null && objMeterReaderTel != DBNull.Value)
                                   strMeterReaderTel = objMeterReaderTel.ToString();
                            }

                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["meterReaderName"].Value; 
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strMeterReaderName = objWaterUser.ToString();
                            }

                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["chargerName"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strChargerName = objWaterUser.ToString();
                            }

                            objWaterUser = dgWaterUser.SelectedRows[i].Cells["CHARGERID"].Value;
                            if (objWaterUser != null && objWaterUser != DBNull.Value)
                            {
                                strChargeID = objWaterUser.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["waterUserHouseTypeS"].Value; 
                            if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                            {
                                strWaterUserHouseType = objWaterUserMes.ToString();
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["ordernumber"].Value;
                            if (Information.IsNumeric(objWaterUserMes))
                            {
                                intOrderNumber = Convert.ToInt16(objWaterUserMes);
                            }

                            objWaterUserMes = dgWaterUser.SelectedRows[i].Cells["WATERUSERPEOPLECOUNT"].Value; 
                            if (Information.IsNumeric(objWaterUserMes))
                            {
                                intPepleCount = Convert.ToInt16(objWaterUserMes);
                            }
                            #endregion

                            MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                            MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLoginID, "WATERFEECHARGE");
                            MODELWATERFEECHARGE.CHARGETYPEID = cmbChargeType.SelectedValue.ToString();
                            if (cmbChargeType.SelectedValue.ToString() == "2")
                            {
                                MODELWATERFEECHARGE.POSRUNNINGNO = txtJYLSH.Text;
                            }
                            MODELWATERFEECHARGE.CHARGEClASS = "2";//收费类型是水费预收
                            MODELWATERFEECHARGE.CHARGEBCSS = Convert.ToDecimal(txtBCYC.Text);
                            MODELWATERFEECHARGE.CHARGEYSQQYE = decQQYE;
                            MODELWATERFEECHARGE.CHARGEYSBCSZ = Convert.ToDecimal(txtBCYC.Text);
                            MODELWATERFEECHARGE.CHARGEYSJSYE = decJSYE;
                            MODELWATERFEECHARGE.CHARGEWORKERID = strLoginID;
                            MODELWATERFEECHARGE.CHARGEWORKERNAME = strLoginName;
                            MODELWATERFEECHARGE.CHARGEDATETIME = mes.GetDatetimeNow();
                            MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                            if (chkReceipt.Checked)
                            {
                                MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 1;
                                MODELWATERFEECHARGE.RECEIPTNO = txtReceiptNO.Text;
                            }
                            if (BLLWATERFEECHARGE.Insert(MODELWATERFEECHARGE))
                            {
                                try
                                {

                                    MODELPRESTORERUNNINGACCOUNT MODELPRESTORERUNNINGACCOUNT = new MODELPRESTORERUNNINGACCOUNT();
                                    MODELPRESTORERUNNINGACCOUNT.PRESTORERUNNINGACCOUNTID = GETTABLEID.GetTableID(strLoginID, "PRESTORERUNNINGACCOUNT");
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERID = strWaterUserID;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERNO = strWaterUserNO;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERNAME = strWaterUserName;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERNAMECODE = strWaterUserNameCode;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERPHONE = strTelNO;
                                    if (strWaterUserPhone != "")
                                        if (strTelNO != "")
                                            MODELPRESTORERUNNINGACCOUNT.WATERUSERPHONE = strTelNO + ";" + strWaterUserPhone;
                                        else
                                            MODELPRESTORERUNNINGACCOUNT.WATERUSERPHONE = strWaterUserPhone;

                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERADDRESS = strWaterUserAddress;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERPEOPLECOUNT = intPepleCount;
                                    MODELPRESTORERUNNINGACCOUNT.AREANO = strAreaNO;
                                    MODELPRESTORERUNNINGACCOUNT.PIANNO = strPianNO;
                                    MODELPRESTORERUNNINGACCOUNT.DUANNO = strDuanNO;
                                    MODELPRESTORERUNNINGACCOUNT.COMMUNITYID = strCommunityID;
                                    MODELPRESTORERUNNINGACCOUNT.COMMUNITYNAME = strCommunityName;

                                    MODELPRESTORERUNNINGACCOUNT.ORDERNUMBER = intOrderNumber;
                                    MODELPRESTORERUNNINGACCOUNT.BUILDINGNO = strBuildingNO;
                                    MODELPRESTORERUNNINGACCOUNT.UNITNO = strUnitNO;
                                    MODELPRESTORERUNNINGACCOUNT.METERREADERID = strMeterReaderID;
                                    MODELPRESTORERUNNINGACCOUNT.METERREADERNAME = strMeterReaderName;
                                    MODELPRESTORERUNNINGACCOUNT.CHARGERID = strLoginID;
                                    MODELPRESTORERUNNINGACCOUNT.CHARGERNAME = strLoginName;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPEID = strWaterUserTypeID;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPENAME = strWaterUserTypeName;
                                    MODELPRESTORERUNNINGACCOUNT.waterMeterTypeId = strWaterMeterTypeID;
                                    MODELPRESTORERUNNINGACCOUNT.waterMeterTypeValue = strWaterMeterTypeName;
                                    MODELPRESTORERUNNINGACCOUNT.WATERMETERTYPECLASSID = strWaterMeterTypeClassID;
                                    MODELPRESTORERUNNINGACCOUNT.WATERMETERTYPECLASSNAME = strWaterMeterTypeClassName;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPENAME = strWaterUserTypeName;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERTYPENAME = strWaterUserTypeName;
                                    MODELPRESTORERUNNINGACCOUNT.WATERUSERHOUSETYPE = strWaterUserHouseType;
                                    MODELPRESTORERUNNINGACCOUNT.CREATETYPE = strCreateType;
                                    MODELPRESTORERUNNINGACCOUNT.MEMO = txtMemo.Text;
                                    MODELPRESTORERUNNINGACCOUNT.CHARGEID = MODELWATERFEECHARGE.CHARGEID;
                                    if (BLLPRESTORERUNNINGACCOUNT.Insert(MODELPRESTORERUNNINGACCOUNT))
                                    {
                                        //txtYSQQYE.Text = txtJSYE.Text;
                                        //txtWaterFeeReal.Text =( Convert.ToDecimal(txtWaterFee.Text) - Convert.ToDecimal(txtYSQQYE.Text)).ToString();
                                        //txtBCYC.Text = "0";

                                        //更新余额
                                        string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CHARGEYSJSYE + " WHERE waterUserId='" + strWaterUserID + "'";
                                        if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                        {
                                            string strError = "更新用户编号为'" + strWaterUserNO + "'的余额失败,请重新收费!";
                                            mes.Show(strError);
                                            log.Write(strError, MsgType.Error);
                                            //回滚预存流水表
                                            BLLPRESTORERUNNINGACCOUNT.Delete(MODELPRESTORERUNNINGACCOUNT.PRESTORERUNNINGACCOUNTID);
                                            //回滚收费记录表
                                            BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                        }
                                        else
                                        {
                                            decimal decUserArearage=0,decWaterUserPrestore=0;
                                            object objUserArearage = dgWaterUser.SelectedRows[i].Cells["USERAREARAGE"].Value;
                                            if (Information.IsNumeric(objUserArearage))
                                                decUserArearage = Convert.ToDecimal(objUserArearage);
                                            object objUserPrestore = dgWaterUser.SelectedRows[i].Cells["prestore"].Value;
                                            if (Information.IsNumeric(objUserPrestore))
                                                decWaterUserPrestore = Convert.ToDecimal(objUserPrestore);
                                            decWaterUserPrestore = decWaterUserPrestore + MODELWATERFEECHARGE.CHARGEBCSS;
                                            decUserArearage = decUserArearage + MODELWATERFEECHARGE.CHARGEBCSS;
                                            dgWaterUser.SelectedRows[i].Cells["USERAREARAGE"].Value = decUserArearage.ToString("F2");
                                            dgWaterUser.SelectedRows[i].Cells["prestore"].Value = decWaterUserPrestore.ToString("F2");
                                        }
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

                                                (report1.FindObject("txtDateTime") as FastReport.TextObject).Text = MODELWATERFEECHARGE.CHARGEDATETIME.ToString("yyyy-MM-dd HH:mm:ss");
                                                //if (cmbChargeType.SelectedValue.ToString() == "2")
                                                //{
                                                //    (report1.FindObject("Cell45") as FastReport.Table.TableCell).Text = txtWaterUserNO.Text + "   交易流水号:" + txtJYLSH.Text;
                                                //}
                                                //else
                                                (report1.FindObject("CellWaterUserNO") as FastReport.Table.TableCell).Text = strWaterUserNO;
                                                (report1.FindObject("CellWaterUserName") as FastReport.Table.TableCell).Text = strWaterUserName;
                                                (report1.FindObject("CellWaterUserAddress") as FastReport.Table.TableCell).Text = strWaterUserAddress;

                                                (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额: " + MODELWATERFEECHARGE.CHARGEYSQQYE.ToString("F2");
                                                string strBCSS = MODELWATERFEECHARGE.CHARGEBCSS.ToString("F2");
                                                (report1.FindObject("txtBCJF") as FastReport.TextObject).Text = "本次预存:         " + strBCSS;
                                                (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额: " + MODELWATERFEECHARGE.CHARGEYSJSYE.ToString("F2");

                                                //if (cmbChargeType.SelectedValue.ToString() == "2")
                                                //{
                                                //    (report1.FindObject("txtPOSRUNNINGNO") as FastReport.TextObject).Text = "交易流水号: " + MODELWATERFEECHARGE.POSRUNNINGNO;
                                                //}
                                                (report1.FindObject("txtChargeWorkerName") as FastReport.TextObject).Text = strLoginName;
                                                (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + txtReceiptNO.Text;

                                                (report1.FindObject("txtMeterReader") as FastReport.TextObject).Text = strMeterReaderName;
                                                (report1.FindObject("txtMeterReaderTel") as FastReport.TextObject).Text = strMeterReaderTel;

                                                string strCapMoney = RMBToCapMoney.CmycurD(strBCSS);
                                                if (cmbChargeType.SelectedValue.ToString() == "2")
                                                {
                                                    (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney + Environment.NewLine + "交易流水号:" + txtJYLSH.Text;
                                                }
                                                else
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
                                catch (Exception exx)
                                {
                                    mes.Show("插入预收流水表失败!原因:" + exx.Message);
                                    log.Write(exx.ToString(), MsgType.Error);
                                    return;
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
                //dgWaterList.DataSource = null;
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
            if (dgWaterUser.Columns[e.ColumnIndex].Name == "waterUserHouseType")
            {
                object objWaterUserHouseType = dgWaterUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (objWaterUserHouseType != null && objWaterUserHouseType != DBNull.Value)
                {
                    if (objWaterUserHouseType.ToString() == "1")
                        dgWaterUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "楼房";
                    else if (objWaterUserHouseType.ToString() == "2")
                        dgWaterUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "平房";
                }
            }
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmWaterUserSeniorSearch frm = new frmWaterUserSeniorSearch();
            frm.Owner = this;
            frm.strSign = "7";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
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
            labTip.Text = "已选" + dgWaterUser.SelectedRows.Count + "户";
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
