using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BASEFUNCTION;
using MODEL;
using BLL;
using System.Threading;

namespace WATERFEEMANAGE
{
    public partial class frmPrestoreWaterUserManualCharge : DockContentEx
    {
        public frmPrestoreWaterUserManualCharge()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            tb2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb2, true, null);
        }

        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();


        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        string strFormText = "";
        private void frmWaterUserPrestoreInitial_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dgWaterUser.AutoGenerateColumns = false;

            BindWaterUserType(cmbMeterReaderS);

            GenerateTree();
            strFormText = this.Text;

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

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            //BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
            BindCharger(cmbChargerS, "0");

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
        private void BindCommunity(ComboBox cmb, string strType)
        {
            DataTable dt = new DataTable();
            if (strType == "0")
                dt = BLLBASE_COMMUNITY.Query("");
            else
                dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000'");
            cmb.DataSource = dt;
            cmb.DisplayMember = "COMMUNITYNAME";
            cmb.ValueMember = "COMMUNITYID";
        }
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader(ComboBox cmb, string strType)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
            if (strType == "0")
            {
                DataRow dr = dt.NewRow();
                dr["USERNAME"] = "全部";
                dr["LOGINID"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
        }
        /// <summary>
        /// 绑定收费员，如果strType为0，则添加‘全部’项
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="strType"></param>
        private void BindCharger(ComboBox cmb, string strType)
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
            if (strType == "0")
            {
                DataRow dr = dt.NewRow();
                dr["USERNAME"] = "全部";
                dr["LOGINID"] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "USERNAME";
            cmb.ValueMember = "LOGINID";
        }
        private void BindWaterUserType(ComboBox cmb)
        {
            DataTable dt = BLLwaterUserType.Query("");
            DataRow dr = dt.NewRow();
            dr["waterUserTypeName"] = "";
            dr["waterUserTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterUserTypeName";
            cmb.ValueMember = "waterUserTypeId";
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
                    strID = "METERREADER|无关ID| AND meterReaderID='" + objID.ToString() + "'";
                }
                object objName = dtMeterReader.Rows[i]["USERNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
            }
            tnHeadMeterReader.Expand();
            #endregion
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
        /// 是否是第一次打开
        /// </summary>
        bool isFirst = false;

        /// <summary>
        /// 存储查询到的用户表
        /// </summary>
        DataTable dtUserList = new DataTable();

        private void trMeterReading_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!isFirst)
            {
                isFirst = true;
                return;
            }
            if (e.Node == null)
                return;
            //if()
            string strNodeID = e.Node.Name;
            string[] strNodeIDSpit = strNodeID.Split('|');
            LoadDebtsDate(strNodeIDSpit);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="strFilter"></param>
        private void LoadDebtsDate(string[] strNodeIDSpit)
        {
            prb.Visible = false;
            labProgress.Visible = false;

            string strFilter = strNodeIDSpit[2];

            if (txtWaterUserNOSearch.Text.Trim() != "")
            {
                if (txtWaterUserNOSearch.Text.Length < 6)
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                else
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
            }

            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND (waterUserName LIKE '%" + txtWaterUserNameSearch.Text + "%' OR waterUserNameCode LIKE '%" + txtWaterUserNameSearch.Text + "%') ";


            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
            if (cmbPianNOS.SelectedIndex > 0)
                strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

            if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";
            if (cmbChargerS.SelectedValue != null && cmbChargerS.SelectedValue != DBNull.Value)
                strFilter += " AND chargerID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

            if (chkArearageGreater.Checked)
                if (Information.IsNumeric(txtArearageGreater.Text))
                {
                    decimal decQFJE = 0 - Convert.ToDecimal(txtArearageGreater.Text);
                    strFilter += " AND USERAREARAGE<=" + decQFJE;
                }

            if (chkArearageLess.Checked)
                if (Information.IsNumeric(txtArearageLess.Text))
                {
                    decimal decQFJE = 0 - Convert.ToDecimal(txtArearageLess.Text);
                    strFilter += " AND USERAREARAGE>=" + decQFJE;
                }

            if (chkYS.Checked)
                if (Information.IsNumeric(txtYS.Text))
                {
                    decimal decQFJE =Convert.ToDecimal(txtYS.Text);
                    strFilter += " AND TOTALFEE>=" + decQFJE;
                }

                strFilter += " ORDER BY areaNO,pianNO,duanNO,ordernumber";

            dtUserList = BLLwaterUser.QueryUserPrestore(strFilter);

            //计算查询到的用户余额
            decimal decWaterUserPrestore = 0;
            object objWaterUserPrestore = dtUserList.Compute("SUM(prestore)", "");
            if (Information.IsNumeric(objWaterUserPrestore))
                decWaterUserPrestore = Convert.ToDecimal(objWaterUserPrestore);

            //计算查询到的用户欠费金额
            decimal decWaterFee = 0;
            object objWaterFee = dtUserList.Compute("SUM(TOTALFEE)", "");
            if (Information.IsNumeric(objWaterFee))
                decWaterFee = Convert.ToDecimal(objWaterFee);

            dgWaterUser.DataSource = dtUserList;

            //ucPageSetUp1.InitialUC(this.dgWaterUser, dtUserList,null);
            //计算水表数量
            this.Text = strFormText + "→用水用户共" + dtUserList.Rows.Count + "户";
            labTip.Text = "本次查询—用户共:" + dtUserList.Rows.Count + "户,账户余额:" + decWaterUserPrestore.ToString("F2") + ",欠费总计:" + decWaterFee.ToString("F2");

            if (dtUserList.Rows.Count == 0)
                btCharge.Enabled = false;
            else
            {
                btCharge.Enabled = true;
            }
        }
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        private string QueryWaterUser()
        {
            string strFilter = "1=1 ";
            if (txtWaterUserNOSearch.Text.Trim() != "")
                strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim().PadLeft(8, '0') + "'";
            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";
            if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                strFilter += " AND waterUserTypeId='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

            if (chkArearageGreater.Checked)
                strFilter += " AND TOTALFEE>0";
            return strFilter;
        }
        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (trMeterReading.SelectedNode == null)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                string strNodeID = trMeterReading.SelectedNode.Name;
                string[] strNodeIDSpit = strNodeID.Split('|');
                LoadDebtsDate(strNodeIDSpit);
            }
        }

        private void dgWaterUser_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void btCharge_Click(object sender, EventArgs e)
        {
            if (dtUserList.Rows.Count == 0)
            {
                mes.Show("请查询预存用户信息后再执行此操作!");
                return;
            }
            if (chkPrintInform.Checked)
            {
                if (txtInformNO.Text.Trim() == "")
                {
                    mes.Show("请输入通知单起始编号!");
                    return;
                }
                else
                {
                    if (!Information.IsNumeric(txtInformNO.Text))
                    {
                        mes.Show("通知单编号只能为数字!");
                        return;
                    }
                    txtInformNO.Text = txtInformNO.Text.PadLeft(8, '0');
                }
            }
            prb.Visible = true;
            labProgress.Visible = true;

            trMeterReading.Enabled = false;
            grbSearch.Enabled = false;            

            bgWork.RunWorkerAsync();
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                labProgress.Text = "进度:0/0";
                int intAllCount = dtUserList.Rows.Count;
                prb.Minimum = 0;
                prb.Maximum = intAllCount;
                prb.Value = 0;
                btCharge.Enabled = false;
                for (int i = 0; i < dtUserList.Rows.Count; i++)
                {
                    if (bgWork.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    string strWaterUserName = "", strWaterUserID = "", strMeterReaderID = "0093", strMeterReaderName = "自动扣款";
                    object objWaterUserName = dtUserList.Rows[i]["waterUserName"];
                    if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                    {
                        strWaterUserName = objWaterUserName.ToString();
                    }
                    //objWaterUserName = dtUserList.Rows[i]["meterReaderID"];
                    //if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                    //{
                    //    strMeterReaderID = objWaterUserName.ToString();
                    //}
                    //objWaterUserName = dtUserList.Rows[i]["meterReaderName"];
                    //if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                    //{
                    //    strMeterReaderName = objWaterUserName.ToString();
                    //}

                    object objWaterUserID = dtUserList.Rows[i]["waterUserId"];
                    if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                    {
                        strWaterUserID = objWaterUserID.ToString();
                        //获取用户余额
                        decimal decWaterUserPrestore = 0;
                        object objWaterUserPreStore = dtUserList.Rows[i]["prestore"];
                        if (Information.IsNumeric(objWaterUserPreStore))
                        {
                            decWaterUserPrestore = Convert.ToDecimal(objWaterUserPreStore);
                        }

                        //获取用户水表欠费信息
                        string strFilter = " AND totalChargeEND>0 AND waterUserId='" + objWaterUserID.ToString() + "' AND chargeState=1 ORDER BY readMeterRecordYearAndMonth";
                        DataTable dtYSDetail = BLLreadMeterRecord.QueryYSDetailByWaterMeter(strFilter);

                        //总的页数
                        //DataTable dtYSDetailTemp = dtYSDetail;
                        //DataView dvYSDetailNoInform = dtYSDetailTemp.DefaultView;
                        //    dvYSDetailNoInform.RowFilter = "INFORMPRINTSIGN='1'";
                        //    DataTable dtYSDetailNoInform = dvYSDetailNoInform.ToTable();
                        //int intSumPageNO =dtYSDetailTemp.Rows.Count-dtYSDetailNoInform.Rows.Count;
                        //int intSumPageNO = dtYSDetail.Rows.Count;

                        //当前正在打印的页号
                            int intCurrentPage = 0;

                        for (int j = 0; j < dtYSDetail.Rows.Count; j++)
                        {
                            if (bgWork.CancellationPending)
                            {
                                e.Cancel = true;
                                break;
                            }

                            //获取抄表记录ID
                            string strreadMeterRecordId = "";
                            object objreadMeterRecordId = dtYSDetail.Rows[j]["readMeterRecordId"];
                            if (objreadMeterRecordId != null && objreadMeterRecordId != DBNull.Value)
                            {
                                strreadMeterRecordId = objreadMeterRecordId.ToString();
                            }
                            else
                            {
                                mes.Show("用户'" + strWaterUserID + "-" + strWaterUserName + "抄表ID获取失败,无法执行结算操作!");
                                return;
                            }
                            //获取减免后的水费总金额
                            decimal decWaterFeeEnd = 0;
                            object objWaterFeeEnd = dtYSDetail.Rows[j]["totalChargeEND"];
                            if (Information.IsNumeric(objWaterFeeEnd))
                            {
                                decWaterFeeEnd = Convert.ToDecimal(objWaterFeeEnd);
                            }

                            //如果用户余额充足，则收费，如果不充足跳过
                            if (decWaterUserPrestore >= decWaterFeeEnd)
                            {
                                #region 余额充足收费处理
                                //用水量
                                int intWaterTotalNumber = 0;
                                //水费小计，污水处理费，附加费，污水处理费总计，滞纳金，水费合计
                                decimal decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decExtraTotalCharge = 0, decOverDueMoney = 0, decTotalCharge = 0;

                                object objWaterTotalNumber = dtYSDetail.Rows[j]["totalNumber"];
                                if (Information.IsNumeric(objWaterTotalNumber))
                                {
                                    intWaterTotalNumber = Convert.ToInt32(objWaterTotalNumber);
                                }

                                object objWaterTotalCharge = dtYSDetail.Rows[j]["waterTotalChargeEND"];
                                if (Information.IsNumeric(objWaterTotalCharge))
                                {
                                    decWaterTotalCharge = Convert.ToDecimal(objWaterTotalCharge);
                                }

                                object objExtraCharge1 = dtYSDetail.Rows[j]["extraCharge1"];
                                if (Information.IsNumeric(objExtraCharge1))
                                {
                                    decExtraCharge1 = Convert.ToDecimal(objExtraCharge1);
                                }

                                object objExtraCharge2 = dtYSDetail.Rows[j]["extraCharge2"];
                                if (Information.IsNumeric(objExtraCharge2))
                                {
                                    decExtraCharge2 = Convert.ToDecimal(objExtraCharge2);
                                }

                                object objExtraTotalCharge = dtYSDetail.Rows[j]["extraTotalChargeEND"];
                                if (Information.IsNumeric(objExtraTotalCharge))
                                {
                                    decExtraTotalCharge = Convert.ToDecimal(objExtraTotalCharge);
                                }

                                object objOverDue = dtYSDetail.Rows[j]["OVERDUEEND"];
                                if (Information.IsNumeric(objOverDue))
                                {
                                    decOverDueMoney = Convert.ToDecimal(objOverDue);
                                }

                                object objTotalCharge = dtYSDetail.Rows[j]["totalChargeEND"];
                                if (Information.IsNumeric(objTotalCharge))
                                {
                                    decTotalCharge = Convert.ToDecimal(objTotalCharge);
                                }

                                MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                                MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLogID, "WATERFEECHARGE");
                                MODELWATERFEECHARGE.TOTALNUMBERCHARGE = intWaterTotalNumber;
                                MODELWATERFEECHARGE.WATERTOTALCHARGE = decWaterTotalCharge;
                                MODELWATERFEECHARGE.EXTRACHARGECHARGE1 = decExtraCharge1;
                                MODELWATERFEECHARGE.EXTRACHARGECHARGE2 = decExtraCharge2;
                                MODELWATERFEECHARGE.EXTRATOTALCHARGE = decExtraTotalCharge;
                                MODELWATERFEECHARGE.TOTALCHARGE = decTotalCharge;
                                MODELWATERFEECHARGE.OVERDUEMONEY = decOverDueMoney;
                                MODELWATERFEECHARGE.CHARGETYPEID = "5";//收费方式是自动扣款
                                MODELWATERFEECHARGE.CHARGEClASS = "1";//收费类型是收取水费
                                MODELWATERFEECHARGE.CHARGEBCYS = decTotalCharge;
                                MODELWATERFEECHARGE.CHARGEBCSS = 0;
                                MODELWATERFEECHARGE.CHARGEYSQQYE = decWaterUserPrestore;
                                MODELWATERFEECHARGE.CHARGEYSBCSZ = (0 - decTotalCharge);
                                MODELWATERFEECHARGE.CHARGEYSJSYE = MODELWATERFEECHARGE.CHARGEYSQQYE + MODELWATERFEECHARGE.CHARGEYSBCSZ;
                                MODELWATERFEECHARGE.CHARGEWORKERID = strMeterReaderID;
                                MODELWATERFEECHARGE.CHARGEWORKERNAME = strMeterReaderName;
                                MODELWATERFEECHARGE.CHARGEDATETIME = mes.GetDatetimeNow();
                                MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                                if (chkPrintInform.Checked)
                                {
                                    MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 0;//收据打印次数
                                    //MODELWATERFEECHARGE.RECEIPTNO = txtInformNO.Text;//收据编号
                                }

                                //存储收费表,打印收据用
                                DataTable dtRecord = dtYSDetail.Clone();

                                MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                                try
                                {
                                    if (BLLWATERFEECHARGE.Insert(MODELWATERFEECHARGE))
                                    {
                                        try
                                        {
                                            MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                                            MODELreadMeterRecord.chargeState = "3";
                                            MODELreadMeterRecord.chargeID = MODELWATERFEECHARGE.CHARGEID;
                                            MODELreadMeterRecord.OVERDUEMONEY = decOverDueMoney;

                                            //if (chkPrintInform.Checked)
                                            //{
                                            //    MODELreadMeterRecord.INFORMNO = txtInformNO.Text;
                                            //}

                                            //MODELreadMeterRecord.WATERUSERQQYE = decWaterUserPrestore;
                                            //MODELreadMeterRecord.WATERUSERJSYE = MODELWATERFEECHARGE.CHARGEYSJSYE;
                                            //MODELreadMeterRecord.INFORMPRINTSIGN = "1";
                                            //MODELreadMeterRecord.PRINTWORKERID = strLogID;
                                            //MODELreadMeterRecord.PRINTWORKERNAME = strUserName;
                                            MODELreadMeterRecord.readMeterRecordId = strreadMeterRecordId;

                                            //bool isUpdateSuccess = false;

                                            ////判断是否打印过通知单，如果打印过，无论打印的是否是欠费的通知单都不再打印也不更新通知单号
                                            //object objPrintInformNO = dtYSDetail.Rows[j]["INFORMNO"];
                                            //if (objPrintInformNO != null && objPrintInformNO != DBNull.Value)
                                            //{
                                            //    isUpdateSuccess = BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);
                                            //}
                                            //else
                                            //    isUpdateSuccess = BLLreadMeterRecord.UpdateChargeStatePrestoreJS(MODELreadMeterRecord);
                                           bool isUpdateSuccess = BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);

                                            if (isUpdateSuccess)
                                            {
                                                //如果总水费为0，跳过打印及更新余额
                                                if (decTotalCharge == 0)
                                                    continue;

                                                string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CHARGEYSJSYE + " WHERE waterUserId='" + strWaterUserID + "'";
                                                bool isSuccess = false;
                                                try
                                                {
                                                    isSuccess = BLLwaterUser.UpdateSQL(strUpdatePrestore);
                                                }
                                                catch (Exception exUpdateWaterUserPrestore)
                                                {
                                                    string strError = "更新用户编号为'" + strWaterUserID + "'的余额失败,原因:" + exUpdateWaterUserPrestore.Message;
                                                    mes.Show(strError);
                                                    log.Write(exUpdateWaterUserPrestore.ToString(), MsgType.Error);

                                                    //回滚收费记录
                                                    BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);

                                                    //回滚收费标志记录
                                                    MODELreadMeterRecord.chargeState = "1";
                                                    MODELreadMeterRecord.chargeID = null;
                                                    MODELreadMeterRecord.OVERDUEMONEY = 0;
                                                    //MODELreadMeterRecord.INFORMNO = null;
                                                    //MODELreadMeterRecord.WATERUSERQQYE = 0;
                                                    //MODELreadMeterRecord.WATERUSERJSYE = 0;
                                                    //MODELreadMeterRecord.INFORMPRINTSIGN = "0";
                                                    //MODELreadMeterRecord.PRINTWORKERID = null;
                                                    //MODELreadMeterRecord.PRINTWORKERNAME = null;
                                                    MODELreadMeterRecord.readMeterRecordId = strreadMeterRecordId;
                                                    BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);
                                                    return;

                                                    ////判断是否打印过通知单，如果打印过，只更新收费标志
                                                    //if (objPrintInformNO != null && objPrintInformNO != DBNull.Value)
                                                    //{
                                                    //    BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);
                                                    //}
                                                    //else
                                                    //{
                                                    //    BLLreadMeterRecord.UpdateChargeStatePrestoreJS(MODELreadMeterRecord);
                                                    //}
                                                }
                                                if (!isSuccess)
                                                {
                                                    string strError = "更新用户编号为'" + strWaterUserID + "'的用户余额失败!";
                                                    mes.Show(strError);
                                                    log.Write(strError, MsgType.Error);
                                                    //回滚收费记录
                                                    BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);

                                                    //回滚收费标志记录
                                                    MODELreadMeterRecord.chargeState = "1";
                                                    MODELreadMeterRecord.chargeID = null;
                                                    MODELreadMeterRecord.OVERDUEMONEY = 0;
                                                    //MODELreadMeterRecord.INFORMNO = null;
                                                    //MODELreadMeterRecord.WATERUSERQQYE = 0;
                                                    //MODELreadMeterRecord.WATERUSERJSYE = 0;
                                                    //MODELreadMeterRecord.INFORMPRINTSIGN = "0";
                                                    //MODELreadMeterRecord.PRINTWORKERID = null;
                                                    //MODELreadMeterRecord.PRINTWORKERNAME = null;
                                                    MODELreadMeterRecord.readMeterRecordId = strreadMeterRecordId;
                                                    BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);

                                                    ////判断是否打印过通知单，如果打印过，只更新收费标志
                                                    //if (objPrintInformNO != null && objPrintInformNO != DBNull.Value)
                                                    //{
                                                    //    BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);
                                                    //}
                                                    //else
                                                    //{
                                                    //    BLLreadMeterRecord.UpdateChargeStatePrestoreJS(MODELreadMeterRecord);
                                                    //}
                                                    return;
                                                }
                                                else
                                                {
                                                    decWaterUserPrestore = MODELWATERFEECHARGE.CHARGEYSJSYE;
                                                    dtUserList.Rows[i]["PRESTORE"] = MODELWATERFEECHARGE.CHARGEYSJSYE;
                                                    ////判断是否打印过通知单，如果打印过，只更新收费标志
                                                    //if (objPrintInformNO != null && objPrintInformNO != DBNull.Value)
                                                    //{
                                                    //    continue;
                                                    //}
                                                    //intCurrentPage++;
                                                    //try
                                                    //{
                                                    //    if (chkPrintInform.Checked)
                                                    //    {
                                                    //        dtRecord.ImportRow(dtYSDetail.Rows[j]);

                                                    //        dtRecord.Rows[0]["waterTotalCharge"] = decWaterTotalCharge;
                                                    //        dtRecord.Rows[0]["extraCharge1"] = decExtraCharge1;
                                                    //        dtRecord.Rows[0]["extraCharge2"] = decExtraCharge2;
                                                    //        dtRecord.Rows[0]["totalCharge"] = decTotalCharge;


                                                    //        //如果是最后一张单据显示用户余额,否则不显示余额
                                                    //        if (dtYSDetail.Rows.Count - 1 == j)
                                                    //            dtRecord.Rows[0]["WATERUSERJSYE"] = MODELWATERFEECHARGE.CHARGEYSJSYE;
                                                    //        else
                                                    //            dtRecord.Rows[0]["WATERUSERJSYE"] = DBNull.Value;

                                                    //        //每张通知单添加页号，方便用户区分最终的用户余额
                                                    //        DataColumn dcPage = new DataColumn("PAGESUMMERY",typeof(string));
                                                    //        dtRecord.Columns.Add(dcPage);
                                                    //        dtRecord.Rows[0]["PAGESUMMERY"] = "第" +intCurrentPage+ "/"+intSumPageNO+"页";

                                                    //        #region
                                                    //        DataSet ds = new DataSet();
                                                    //        dtRecord.TableName = "水费通知单模板";
                                                    //        ds.Tables.Add(dtRecord);
                                                    //        FastReport.Report report1 = new FastReport.Report();
                                                    //        try
                                                    //        {
                                                    //            // load the existing report
                                                    //            report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\水费通知单模板.frx");
                                                    //            // register the dataset
                                                    //            report1.RegisterData(ds);
                                                    //            report1.GetDataSource("水费通知单模板").Enabled = true;
                                                    //            //report1.Show();
                                                    //            report1.PrintSettings.ShowDialog = false;
                                                    //            report1.Prepare();
                                                    //            report1.Print();

                                                    //            txtInformNO.Text = (Convert.ToInt32(txtInformNO.Text) + 1).ToString().PadLeft(8, '0');
                                                    //        }
                                                    //        catch (Exception exx)
                                                    //        {
                                                    //            mes.Show(exx.Message);
                                                    //            log.Write(exx.ToString(), MsgType.Error);
                                                    //            return;
                                                    //        }
                                                    //        finally
                                                    //        {
                                                    //            // free resources used by report
                                                    //            report1.Dispose();
                                                    //        }
                                                    //        #endregion
                                                    //    }
                                                    //}
                                                    //catch (Exception exx)
                                                    //{
                                                    //    string strError = exx.Message;
                                                    //    mes.Show(strError);
                                                    //    log.Write(strError, MsgType.Error);
                                                    //    return;
                                                    //}
                                                }
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
                                #region 余额不足的收费处理
                                break;//如果用户余额不足，停止结算收费，因为只能按照月份收费，即使下个月的水费够扣也不能收费
                                /*
                                //用水量
                                int intWaterTotalNumber = 0;
                                //水费小计，污水处理费，附加费，污水处理费总计，滞纳金，水费合计
                                decimal decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decExtraTotalCharge = 0, decOverDueMoney = 0, decTotalCharge = 0;

                                object objWaterTotalNumber = dtYSDetail.Rows[j]["totalNumber"];
                                if (Information.IsNumeric(objWaterTotalNumber))
                                {
                                    intWaterTotalNumber = Convert.ToInt32(objWaterTotalNumber);
                                }

                                object objWaterTotalCharge = dtYSDetail.Rows[j]["waterTotalChargeEND"];
                                if (Information.IsNumeric(objWaterTotalCharge))
                                {
                                    decWaterTotalCharge = Convert.ToDecimal(objWaterTotalCharge);
                                }

                                object objExtraCharge1 = dtYSDetail.Rows[j]["extraCharge1"];
                                if (Information.IsNumeric(objExtraCharge1))
                                {
                                    decExtraCharge1 = Convert.ToDecimal(objExtraCharge1);
                                }

                                object objExtraCharge2 = dtYSDetail.Rows[j]["extraCharge2"];
                                if (Information.IsNumeric(objExtraCharge2))
                                {
                                    decExtraCharge2 = Convert.ToDecimal(objExtraCharge2);
                                }

                                object objExtraTotalCharge = dtYSDetail.Rows[j]["extraTotalChargeEND"];
                                if (Information.IsNumeric(objExtraTotalCharge))
                                {
                                    decExtraTotalCharge = Convert.ToDecimal(objExtraTotalCharge);
                                }

                                object objTotalCharge = dtYSDetail.Rows[j]["totalChargeEND"];
                                if (Information.IsNumeric(objTotalCharge))
                                {
                                    decTotalCharge = Convert.ToDecimal(objTotalCharge);
                                }

                                MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                                MODELWATERFEECHARGE.CHARGEYSJSYE = decWaterUserPrestore - decTotalCharge;

                                //存储收费表,打印收据用
                                DataTable dtRecord = dtYSDetail.Clone();
                                MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                                try
                                {
                                    //dtRecord.ImportRow(dtYSDetail.Rows[j]);

                                    //dtRecord.Rows[0]["waterTotalCharge"] = decWaterTotalCharge;
                                    //dtRecord.Rows[0]["extraCharge1"] = decExtraCharge1;
                                    //dtRecord.Rows[0]["extraCharge2"] = decExtraCharge2;
                                    //dtRecord.Rows[0]["totalCharge"] = decTotalCharge;

                                    ////如果是最后一张单据显示用户余额,否则不显示余额
                                    //if (dtYSDetail.Rows.Count - 1 == j)
                                    //    dtRecord.Rows[0]["WATERUSERJSYE"] = MODELWATERFEECHARGE.CHARGEYSJSYE;
                                    //else
                                    //    dtRecord.Rows[0]["WATERUSERJSYE"] = DBNull.Value;

                                    dtUserList.Rows[i]["PRESTORE"] = MODELWATERFEECHARGE.CHARGEYSJSYE;

                                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                                    //MODELreadMeterRecord.INFORMNO = txtInformNO.Text;
                                    //MODELreadMeterRecord.WATERUSERQQYE = decWaterUserPrestore;

                                    //存储用户当前余额
                                    decWaterUserPrestore = MODELWATERFEECHARGE.CHARGEYSJSYE;

                                    //object objPrintInformNO = dtYSDetail.Rows[j]["INFORMNO"];
                                    //if (objPrintInformNO != null && objPrintInformNO != DBNull.Value)
                                    //{
                                    //    continue;
                                    //}

                                    //intCurrentPage++;
                                    //DataColumn dcPage = new DataColumn("PAGESUMMERY", typeof(string));
                                    //dtRecord.Columns.Add(dcPage);
                                    //dtRecord.Rows[0]["PAGESUMMERY"] = "第" + intCurrentPage + "/" + intSumPageNO + "页";

                                    //MODELreadMeterRecord.WATERUSERJSYE = MODELWATERFEECHARGE.CHARGEYSJSYE;
                                    //MODELreadMeterRecord.INFORMPRINTSIGN = "1";
                                    //MODELreadMeterRecord.PRINTWORKERID = strLogID;
                                    //MODELreadMeterRecord.PRINTWORKERNAME = strUserName;
                                    MODELreadMeterRecord.readMeterRecordId = strreadMeterRecordId;
                                    if (BLLreadMeterRecord.UpdatePrestoreJS(MODELreadMeterRecord))
                                    {
                                            #region
                                        ////如果勾选了打印按钮，则打印
                                        //if (chkPrintInform.Checked)
                                        //{
                                        //    DataSet ds = new DataSet();
                                        //    dtRecord.TableName = "水费通知单模板";
                                        //    ds.Tables.Add(dtRecord);
                                        //    FastReport.Report report1 = new FastReport.Report();
                                        //    try
                                        //    {
                                        //        // load the existing report
                                        //        report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\水费通知单模板.frx");
                                        //        // register the dataset
                                        //        report1.RegisterData(ds);
                                        //        report1.GetDataSource("水费通知单模板").Enabled = true;
                                        //        (report1.FindObject("txtQFSM") as FastReport.TextObject).Visible = true;
                                        //        //report1.Show();
                                        //        report1.PrintSettings.ShowDialog = false;
                                        //        report1.Prepare();
                                        //        report1.Print();

                                        //        txtInformNO.Text = (Convert.ToInt32(txtInformNO.Text) + 1).ToString().PadLeft(8, '0');
                                        //    }
                                        //    catch (Exception exx)
                                        //    {
                                        //        mes.Show(exx.Message);
                                        //        log.Write(exx.ToString(), MsgType.Error);
                                        //        return;
                                        //    }
                                        //    finally
                                        //    {
                                        //        // free resources used by report
                                        //        report1.Dispose();
                                        //    }
                                        //}
                                            #endregion
                                    }
                                    else
                                    {
                                        mes.Show("更新通知单结算打印标志失败,请查询后重新结算!");
                                        log.Write("更新通知单结算打印标志失败，抄表流水号:" + MODELreadMeterRecord.readMeterRecordId, MsgType.Error);
                                        return;
                                    }
                                }
                                catch (Exception exx)
                                {
                                    string strError = exx.Message;
                                    mes.Show(strError);
                                    log.Write(strError, MsgType.Error);
                                    return;
                                }
                                 * */
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        mes.Show("第" + (i + 1).ToString() + "行用户ID为空，无法获取金额，请查询后重试!");
                        return;
                    }
                    prb.Value = i + 1;
                    labProgress.Text = "进度:" + (i + 1) + "/" + intAllCount;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            trMeterReading.Enabled = true;
            grbSearch.Enabled = true;
        }

        private void frmPrestoreWaterUserManualCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgWork.IsBusy)
                bgWork.CancelAsync();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            //检测是否已经输入了小数点 
            bool IsContainsDot = txt.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
        }
    }
}
