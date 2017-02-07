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
using MODEL;
using BASEFUNCTION;

namespace WATERFEEMANAGE
{
    public partial class frmWaterMeterChargeCancel : DockContentEx
    {
        public frmWaterMeterChargeCancel()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLreadMeterRecordCancel BLLreadMeterRecordCancel = new BLLreadMeterRecordCancel();
        //BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        BLLRECEIPTFETCH BLLRECEIPTFETCH = new BLLRECEIPTFETCH();
        BLLINVOICEFETCH BLLINVOICEFETCH = new BLLINVOICEFETCH();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();

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
        /// 登陆用户所属组ID
        /// </summary>
        private string strGroupID = "";

        //已退费颜色
        Color colorCharged = Color.Red;
        private void frmWaterMeterChargeCancel_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            BindChargeWorkerName();

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
            dtpEnd.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
            //dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);
            //dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1); 
            //dtpStart.Value = dtNow;
            //dtpEnd.Value = dtNow;

            dgHistoryWaterFee.AutoGenerateColumns = false;
            //dgHistoryWaterFee.MouseWheel += new MouseEventHandler(dgHistoryWaterFee_MouseWheel);//加入鼠标滚动事件

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

            //获取用户组ID
            object objGroup = AppDomain.CurrentDomain.GetData("GROUPID");
            if (objGroup != null && objGroup != DBNull.Value)
            {
                strGroupID=objGroup.ToString();
                ////如果非系统管理员，则只能统计自己的收费明细
                //if (strGroupID != "0001")
                //{
                //    cmbChargerWorkName.SelectedValue = strLoginID;
                //    cmbChargerWorkName.Enabled = false;
                //}
            }
            else
            {
                mes.Show("收费员所属组获取失败!请重新打开该窗体!");
                this.Close();
            }

            //this.Text = "大厅坐收——当前收费员:" + strLoginName;

            for (int i = 0; i < dgHistoryWaterFee.Columns.Count; i++)
            {
                //隐藏附加费列
                if (dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS1" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS1" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS2" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS2" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS3" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS3" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS4" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS4" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS5" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS5" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS6" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS6" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS7" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS7" ||
                    dgHistoryWaterFee.Columns[i].Name == "extraChargePriceLS8" || dgHistoryWaterFee.Columns[i].Name == "extraChargeLS8")
                {
                    dgHistoryWaterFee.Columns[i].Visible = false;
                }
            }
            //txtWaterUserNO.SelectAll();
            txtWaterUserNO.Focus();
            BindInvoiceBatch(cmbBatch);
            BindInvoiceBatch(cmbBatchNew);
            //BindWaterMeterType();
            GenerateTree();
            BindMeterReader();
            BindChargeType(cmbChargeTypeOld);
            BindChargeType(cmbChargeTypeNew);
        }

        /// <summary>
        /// 绑定收费类型
        /// </summary>
        private void BindChargeType(ComboBox cmb)
        {
            DataTable dt = BLLCHARGETYPE.QUERY("");
            DataRow dr = dt.NewRow();
            cmb.DataSource = dt;
            cmb.DisplayMember = "CHARGETYPENAME";
            cmb.ValueMember = "CHARGETYPEID";
        }

        DataTable dtMeterReader = new DataTable();
        /// <summary>
        /// 绑定抄表员
        /// </summary>
        private void BindMeterReader()
        {
            dtMeterReader = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
        }
        /// <summary>
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND IsCashier='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
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
                    strID = "METERREADER|无关ID| AND meterReaderID='" + objID.ToString() + "'";
                }
                object objName = dtMeterReader.Rows[i]["USERNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
            }
            tnHeadMeterReader.Expand() ;
            #endregion
            trMeterReading.SelectedNode = tnHeadMeterReader;
        }
        /// <summary>
        /// 绑定发票批次
        /// </summary>
        /// <param name="cmb"></param>
        private void BindInvoiceBatch(ComboBox cmb)
        {
            DataTable dt = BLLINVOICEFETCH.Query(" AND ISENABLE='1' ORDER BY INVOICEFETCHBATCHID DESC");
            DataView dvInvoiceBatch = dt.DefaultView;
            cmb.DataSource = dvInvoiceBatch.ToTable(true, "INVOICEFETCHBATCHID", "INVOICEBATCHNAME");
            cmb.DisplayMember = "INVOICEBATCHNAME";
            cmb.ValueMember = "INVOICEFETCHBATCHID";

            if (dvInvoiceBatch.Count == 0)
            {
                mes.Show("从发票领用记录表内未检测到可用的发票,发票将无法打印!");
            }
        }
        void dgHistoryWaterFee_MouseWheel(object sender, MouseEventArgs e)
        {
            int rowIndex = this.dgHistoryWaterFee.CurrentRow.Index;
            this.dgHistoryWaterFee.ClearSelection();

            if (e.Delta > 0)
            {
                if (rowIndex > 0)
                {
                    this.dgHistoryWaterFee.CurrentCell = this.dgHistoryWaterFee.Rows[rowIndex - 1].Cells["waterUserName"];
                    this.dgHistoryWaterFee.Rows[rowIndex - 1].Selected = true;
                }
                else
                {
                    this.dgHistoryWaterFee.CurrentCell = this.dgHistoryWaterFee.Rows[rowIndex].Cells["waterUserName"];
                    this.dgHistoryWaterFee.Rows[rowIndex].Selected = true;
                }
            }
            else
            {
                if (rowIndex < this.dgHistoryWaterFee.Rows.Count - 1)
                {
                    this.dgHistoryWaterFee.CurrentCell = this.dgHistoryWaterFee.Rows[rowIndex + 1].Cells["waterUserName"];
                    this.dgHistoryWaterFee.Rows[rowIndex + 1].Selected = true;
                }
                else
                {
                    this.dgHistoryWaterFee.CurrentCell = this.dgHistoryWaterFee.Rows[rowIndex].Cells["waterUserName"];
                    this.dgHistoryWaterFee.Rows[rowIndex].Selected = true;
                }
            }
        }

        private void btCancelCharge_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
                object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
                if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
                {
                    mes.Show("该单据已月结，无法执行此操作!");
                    return;
                }
            if (strGroupID != "0001")
            {
                object objJZRJ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZRJ != null && objJZRJ != DBNull.Value)
                {
                    if (objJZRJ.ToString() == "是")
                    {
                        mes.Show("该单据已日结，无法执行此操作!");
                        return;
                    }
                }
            }
            try
            {
                if (txtChargeID.Text.Trim() != "")
                {
                    object objChargeCancel = dgHistoryWaterFee.CurrentRow.Cells["CHARGECANCEL"].Value;
                    if (objChargeCancel != null && objChargeCancel != DBNull.Value)
                        if (objChargeCancel.ToString() == "作废")
                        {
                            mes.Show("该收费单已经冲减,无需再次冲减!");
                            return;
                        }

                    if (!Information.IsNumeric(txtBCYS.Text))
                        txtBCYS.Text = "0";

                    if (!Information.IsNumeric(txtBCSS.Text))
                        txtBCSS.Text = "0";

                    if (!Information.IsNumeric(txtYSQQYE.Text))
                        txtYSQQYE.Text = "0";

                    if ((Convert.ToDecimal(txtBCYS.Text) + Convert.ToDecimal(txtYSQQYE.Text)) < Convert.ToDecimal(txtBCSS.Text))
                    {
                        mes.Show("用户余额不足，无法完成冲减!");
                        return;
                    }
                    if (txtMemo.Text.Trim() == "")
                    {
                        mes.Show("请填写冲减原因!");
                        txtMemo.Focus();
                        return;
                    }
                    string strWaterUserName = "", strWaterUserNO = "", strWaterUserID = "";

                    object objWaterUserID = dgHistoryWaterFee.CurrentRow.Cells["waterUserNO"].Value;
                    if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        strWaterUserID = objWaterUserID.ToString();
                    else
                    {
                        mes.Show("获取用户ID失败,请重新选择冲减单据!");
                        return;
                    }

                    object objWaterUserName = dgHistoryWaterFee.CurrentRow.Cells["waterUserName"].Value;
                    if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                        strWaterUserName = objWaterUserName.ToString();

                    object objWaterUserNO = dgHistoryWaterFee.CurrentRow.Cells["waterUserNO"].Value;
                    if (objWaterUserNO != null && objWaterUserNO != DBNull.Value)
                        strWaterUserNO = objWaterUserNO.ToString();

                    if (mes.ShowQ("确定要将用户'" + strWaterUserNO + "-" + strWaterUserName + "'的收费单据'" + txtChargeID.Text + "'冲减吗?") != DialogResult.OK)
                        return;

                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = txtChargeID.Text;
                    MODELWATERFEECHARGE.CHARGECANCEL = "1";
                    MODELWATERFEECHARGE.CANCELYSQQYE = Convert.ToDecimal(txtYSQQYE.Text);
                    MODELWATERFEECHARGE.CANCELYSBCSZ = Convert.ToDecimal(txtBCJY.Text);
                    MODELWATERFEECHARGE.CANCELYSJSYE = Convert.ToDecimal(txtYSJSYE.Text);
                    MODELWATERFEECHARGE.CANCELWORKERID = strLoginID;
                    MODELWATERFEECHARGE.CANCELWORKERNAME = strLoginName;
                    MODELWATERFEECHARGE.CANCELDATETIME = mes.GetDatetimeNow();
                    MODELWATERFEECHARGE.CANCELMEMO = txtMemo.Text;

                    if (BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE))
                    {
                        try
                        {
                            #region 把将要更新的抄表记录复制出来，生成退费记录
                            DataTable dtAllRecord = dtHistoryWaterFee.Copy();
                            DataView dvSelectedUserRecord = dtAllRecord.DefaultView;
                            dvSelectedUserRecord.RowFilter = "CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'";
                            DataTable dtSelectedUserRecord = dvSelectedUserRecord.ToTable();

                            string strReadMeterRecordIDS = "";
                            for (int i = 0; i < dtSelectedUserRecord.Rows.Count; i++)
                            {
                                object objReadMeterRecordID = dtSelectedUserRecord.Rows[i]["readMeterRecordId"];
                                if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
                                {
                                    if (i == 0)
                                        strReadMeterRecordIDS = "'" + objReadMeterRecordID.ToString() + "'";
                                    else
                                        strReadMeterRecordIDS += ",'" + objReadMeterRecordID.ToString() + "'";
                                }
                            }
                            string strInserRecordCancelSQL = "INSERT INTO readMeterRecordCancel SELECT * FROM readMeterRecord WHERE readMeterRecordId IN(" + strReadMeterRecordIDS + ")";
                            BLLreadMeterRecordCancel.ExcuteSQL(strInserRecordCancelSQL);
                            #endregion

                            //存储是否为红冲单据,不保存的话记录会被删除，就无法获取了
                            bool isRedCharge = false;
                                    object objChargeClass = dgHistoryWaterFee.CurrentRow.Cells["CHARGEClASS"].Value;
                                    if (objChargeClass != null && objChargeClass != DBNull.Value)
                                    {
                                        if (objChargeClass.ToString() == "4")
                                        isRedCharge = true;
                                    }

                            try
                            {
                                if (txtChargeInvoicePrintID.Text.Trim() != "")
                                {
                                    object objInvoiceCancel = dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].FormattedValue;
                                    if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                                        if (objInvoiceCancel.ToString() == "正常")
                                        {

                                            MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT = new MODELCHARGEINVOICEPRINT();
                                            MODELCHARGEINVOICEPRINT.CHARGEID = MODELWATERFEECHARGE.CHARGEID;
                                            MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID = txtChargeInvoicePrintID.Text;
                                            MODELCHARGEINVOICEPRINT.INVOICECANCEL = "1";
                                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = strLoginID;
                                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = strLoginName;
                                            MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME = mes.GetDatetimeNow();
                                            MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = txtMemo.Text;
                                            if (BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT))
                                            {
                                                try
                                                {
                                                    //object objTotalNumber=dgHistoryWaterFee.//如果水量小于0，走红冲
                                                    if (BLLreadMeterRecord.UpdateChargeStateByChargeID(MODELWATERFEECHARGE.CHARGEID))
                                                    {
                                                        //更新余额
                                                        string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CANCELYSJSYE + " WHERE waterUserId='" + strWaterUserID + "'";
                                                        if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                                        {

                                                            //删除退费记录
                                                            BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                                            //回滚发票表
                                                            MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";
                                                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = null;
                                                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = null;
                                                            MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = null;
                                                            BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT);

                                                            //回滚收费表
                                                            MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                                            MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                                            MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                                            MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                                            MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                                            MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                                            MODELWATERFEECHARGE.CANCELMEMO = null;
                                                            BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                                            string strError = "更新用户编号为'" + strWaterUserNO + "'的余额失败,冲减单据失败!";
                                                            mes.Show(strError);
                                                            log.Write(strError, MsgType.Error);
                                                            return;
                                                        }

                                                        for (int i = dgHistoryWaterFee.Rows.Count - 1; i > -1; i--)
                                                        {
                                                            object objChargeID = dgHistoryWaterFee.Rows[i].Cells["CHARGEID"].Value;
                                                            if (objChargeID != null && objChargeID != DBNull.Value)
                                                            {
                                                                if (objChargeID.ToString() == MODELWATERFEECHARGE.CHARGEID)
                                                                    dgHistoryWaterFee.Rows.Remove(dgHistoryWaterFee.Rows[i]);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {

                                                        //删除退费记录
                                                        BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                                        //回滚发票表
                                                        MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";
                                                        MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = null;
                                                        MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = null;
                                                        MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = null;
                                                        BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT);

                                                        //回滚收费表
                                                        MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                                        MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                                        MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                                        MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                                        MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                                        MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                                        MODELWATERFEECHARGE.CANCELMEMO = null;
                                                        BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                                        mes.Show("更新抄表记录收费状态失败,冲减单据失败!");
                                                        return;
                                                    }
                                                }
                                                catch (Exception exRecordCancel)
                                                {
                                                    //删除退费记录
                                                    BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                                    //回滚发票表
                                                    MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";
                                                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = null;
                                                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = null;
                                                    MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = null;
                                                    BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT);

                                                    //回滚收费表
                                                    MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                                    MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                                    MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                                    MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                                    MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                                    MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                                    MODELWATERFEECHARGE.CANCELMEMO = null;
                                                    BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                                    mes.Show("更新抄表记录收费状态失败,冲减失败!错误信息:" + exRecordCancel.Message);
                                                    log.Write(exRecordCancel.ToString(), MsgType.Error);
                                                    return;
                                                }
                                            }
                                            else
                                            {

                                                //删除退费记录
                                                BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                                //回滚收费表
                                                MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                                MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                                MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                                MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                                MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                                MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                                MODELWATERFEECHARGE.CANCELMEMO = null;
                                                BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                                mes.Show("冲减失败!请重新选择要冲减的单据!");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (BLLreadMeterRecord.UpdateChargeStateByChargeID(MODELWATERFEECHARGE.CHARGEID))
                                                {
                                                    //更新余额
                                                    string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CANCELYSJSYE + " WHERE waterUserId='" + strWaterUserID + "'";
                                                    if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                                    {
                                                        //删除退费记录
                                                        BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                                        //回滚收费表
                                                        MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                                        MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                                        MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                                        MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                                        MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                                        MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                                        MODELWATERFEECHARGE.CANCELMEMO = null;
                                                        BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                                        string strError = "更新用户编号为'" + strWaterUserNO + "'的余额失败,冲减单据失败!";
                                                        mes.Show(strError);
                                                        log.Write(strError, MsgType.Error);
                                                        return;
                                                    }

                                                    for (int i = dgHistoryWaterFee.Rows.Count - 1; i > -1; i--)
                                                    {
                                                        object objChargeID = dgHistoryWaterFee.Rows[i].Cells["CHARGEID"].Value;
                                                        if (objChargeID != null && objChargeID != DBNull.Value)
                                                        {
                                                            if (objChargeID.ToString() == MODELWATERFEECHARGE.CHARGEID)
                                                                dgHistoryWaterFee.Rows.Remove(dgHistoryWaterFee.Rows[i]);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //删除退费记录
                                                    BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                                    //回滚收费表
                                                    MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                                    MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                                    MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                                    MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                                    MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                                    MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                                    MODELWATERFEECHARGE.CANCELMEMO = null;
                                                    BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                                    mes.Show("更新抄表记录收费状态失败,冲减单据失败!");
                                                    return;
                                                }
                                            }
                                            catch (Exception exRecordCancel)
                                            {
                                                //删除退费记录
                                                BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                                //回滚收费表
                                                MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                                MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                                MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                                MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                                MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                                MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                                MODELWATERFEECHARGE.CANCELMEMO = null;
                                                BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                                mes.Show("更新抄表记录收费状态失败!错误信息:" + exRecordCancel.Message);
                                                log.Write(exRecordCancel.ToString(), MsgType.Error);
                                                return;
                                            }
                                        }
                                }
                                else
                                {
                                    try
                                    {
                                        //将抄表记录置为未收费状态
                                        if (BLLreadMeterRecord.UpdateChargeStateByChargeID(MODELWATERFEECHARGE.CHARGEID))
                                        {
                                            //更新余额
                                            string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CANCELYSJSYE + " WHERE waterUserId='" + strWaterUserID + "'";
                                            if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                            {
                                                //删除退费记录
                                                BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                                //回滚收费表
                                                MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                                MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                                MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                                MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                                MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                                MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                                MODELWATERFEECHARGE.CANCELMEMO = null;
                                                BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                                string strError = "更新用户编号为'" + strWaterUserID + "'的余额失败,冲减单据失败!";
                                                mes.Show(strError);
                                                log.Write(strError, MsgType.Error);
                                                return;
                                            }
                                            for (int i = dgHistoryWaterFee.Rows.Count - 1; i > -1; i--)
                                            {
                                                object objChargeID = dgHistoryWaterFee.Rows[i].Cells["CHARGEID"].Value;
                                                if (objChargeID != null && objChargeID != DBNull.Value)
                                                {
                                                    if (objChargeID.ToString() == MODELWATERFEECHARGE.CHARGEID)
                                                        dgHistoryWaterFee.Rows.Remove(dgHistoryWaterFee.Rows[i]);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //删除退费记录
                                            BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                            //回滚收费表
                                            MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                            MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                            MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                            MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                            MODELWATERFEECHARGE.CHARGEWORKERID = null;
                                            MODELWATERFEECHARGE.CHARGEWORKERNAME = null;
                                            MODELWATERFEECHARGE.CANCELMEMO = null;
                                            BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                            mes.Show("更新抄表记录收费状态失败!请重新选择要冲减的单据!");
                                            return;
                                        }
                                    }
                                    catch (Exception exx)
                                    {
                                        //删除退费记录
                                        BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                        //回滚收费表
                                        MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                        MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                        MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                        MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                        MODELWATERFEECHARGE.CANCELWORKERID = null;
                                        MODELWATERFEECHARGE.CANCELWORKERNAME = null;
                                        MODELWATERFEECHARGE.CANCELMEMO = null;
                                        BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                        mes.Show("更新抄表记录收费状态失败!错误信息:" + exx.Message);
                                        log.Write(exx.ToString(), MsgType.Error);
                                        return;
                                    }
                                }

                                #region 如果是红冲水费直接删除台账记录
                                try
                                {
                                        if (isRedCharge)
                                        {
                                            string strSQLDeleteRecord = "DELETE FROM readMeterRecord WHERE readMeterRecordId IN (" + strReadMeterRecordIDS + ")";
                                            int intDeleteCount = BLLreadMeterRecord.Excute(strSQLDeleteRecord);
                                            if (intDeleteCount == 0)
                                            {
                                                mes.Show("冲减红冲单据成功，但删除台账失败，请手动删除台账!");
                                                return;
                                            }
                                        }
                                }
                                catch(Exception ex)
                                {
                                    log.Write(ex.Message,MsgType.Error);
                                    return;
                                }
                                #endregion
                            }
                            catch (Exception ex)
                            {
                                //删除退费记录
                                BLLreadMeterRecordCancel.Delete(" AND CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");

                                //回滚收费状态
                                MODELWATERFEECHARGE.CHARGECANCEL = "0";
                                MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                                MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                                MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                                MODELWATERFEECHARGE.CANCELWORKERID = null;
                                MODELWATERFEECHARGE.CANCELWORKERNAME = null;
                                MODELWATERFEECHARGE.CANCELMEMO = null;
                                BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                                mes.Show("冲减失败!原因:" + ex.Message + "请重新选择要冲减的单据!");
                                log.Write(ex.ToString(), MsgType.Error);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            //回滚收费状态
                            MODELWATERFEECHARGE.CHARGECANCEL = "0";
                            MODELWATERFEECHARGE.CANCELYSQQYE = 0;
                            MODELWATERFEECHARGE.CANCELYSBCSZ = 0;
                            MODELWATERFEECHARGE.CANCELYSJSYE = 0;
                            MODELWATERFEECHARGE.CANCELWORKERID = null;
                            MODELWATERFEECHARGE.CANCELWORKERNAME = null;
                            MODELWATERFEECHARGE.CANCELMEMO = null;
                            BLLWATERFEECHARGE.UpdateCancelState(MODELWATERFEECHARGE);

                            mes.Show("冲减失败!原因:" + ex.Message + "请重新选择要冲减的单据!");
                            log.Write(ex.ToString(), MsgType.Error);
                            return;
                        }
                    }
                    else
                    {

                        mes.Show("更新收费状态失败，冲减失败!");
                        return;
                    }
                }
                else
                {
                    mes.Show("冲减单据为空，请选择要冲减的行!");
                    return;
                }
            }
            catch (Exception exx)
            {
                mes.Show(exx.Message + "冲减失败!请重新选择要冲减的单据!");
                log.Write(exx.ToString(), MsgType.Error);
                return;
            }
        }

        private void btInvoicePrint_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月结，无法执行此操作!");
                return;
            }
            if (strGroupID != "0001")
            {
                objJZ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZ != null && objJZ != DBNull.Value)
                {
                    if (objJZ.ToString() == "是")
                    {
                        mes.Show("该单据已经结账，无法执行此操作!");
                        return;
                    }
                }
            }
            #region 发票连打将收费列表内的收费记录打印发票，系统将自动跳过已开票的收费记录

            if (dgHistoryWaterFee.Rows.Count == 0)
            {
                btInvoicePrint.Enabled = false;
                return;
            }

            if (cmbBatch.SelectedValue == null || cmbBatch.SelectedValue == DBNull.Value)
            {
                mes.Show("请选择发票批次!");
                cmbBatch.Focus();
                return;
            }
            if (txtInvoiceNO.Text.Trim() == "")
            {
                mes.Show("请输入起始发票号码!");
                txtInvoiceNO.Focus();
                return;
            }
            else
            {
                if (!Information.IsNumeric(txtInvoiceNO.Text))
                {
                    mes.Show("发票号码只能由数字组成!");
                    txtInvoiceNO.Focus();
                    return;
                }
            }

            //获取连打起始号及终止号
            int intStartRow = 0, intEndRow = dtHistoryWaterFee.Rows.Count;
            if (!Information.IsNumeric(txtStartRow.Text))
            {
                mes.Show("请输入连打起始行号!");
                txtStartRow.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtStartRow.Text) < 1)
                {
                    mes.Show("连打起始行号不能小于1!");
                    txtStartRow.Focus();
                    return;
                }
                intStartRow = Convert.ToInt32(txtStartRow.Text);
            }
            if (Information.IsNumeric(txtEndRow.Text))
            {
                if (Convert.ToInt32(txtStartRow.Text) > Convert.ToInt32(txtEndRow.Text))
                {
                    mes.Show("连打起始行号不能大于终止行号!");
                    txtEndRow.Focus();
                    return;
                }
                if (Convert.ToInt32(txtEndRow.Text) < dtHistoryWaterFee.Rows.Count)
                    intEndRow = Convert.ToInt32(txtEndRow.Text);
            }

            txtInvoiceNO.Text = txtInvoiceNO.Text.PadLeft(8, '0');  //8位发票号

            int intEndInoviceNO = Convert.ToInt32(txtInvoiceNO.Text) + intEndRow - intStartRow + 1;  //得到发票终止最大号

            string strStartInvoiceNO = txtInvoiceNO.Text;
            string strEndInvoiceNO = intEndInoviceNO.ToString().PadLeft(8, '0');

            #region 检查起始发票号是否可用
            DataTable dtCheckInvoiceExists = BLLWATERFEECHARGE.QueryChargeView(" AND INVOICENO='" + txtInvoiceNO.Text + "' AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICECANCEL<>'3'");
            if (dtCheckInvoiceExists.Rows.Count > 0)
            {
                if (mes.ShowQ("发票批次为'" + cmbBatch.Text + "'票号为'" + txtInvoiceNO.Text + "'的发票已使用，确定使用此发票号打印吗?") != DialogResult.OK)
                {
                    txtInvoiceNO.Focus();
                    return;
                }
            }
            else
            {
                DataTable dtInvoiceFetch = BLLINVOICEFETCH.Query(" AND  INVOICEFETCHBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                #region 验证发票领取记录是否重复
                bool isExist = false;
                for (int i = 0; i < dtInvoiceFetch.Rows.Count; i++)
                {
                    long intStartNO = 0, intEndNO = 0;
                    object obj = dtInvoiceFetch.Rows[i]["INVOICEFETCHSTARTNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intStartNO = Convert.ToInt64(obj);
                    }
                    obj = dtInvoiceFetch.Rows[i]["INVOICEFETCHENDNO"];
                    if (Information.IsNumeric(obj))
                    {
                        intEndNO = Convert.ToInt64(obj);
                    }
                    if (Convert.ToInt64(txtInvoiceNO.Text) >= intStartNO && Convert.ToInt64(txtInvoiceNO.Text) <= intEndNO)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    mes.Show("批次为'" + cmbBatch.Text + "'的发票起始号'" + txtInvoiceNO.Text + "'不在领取记录中,请确认发票号码是否正确!");
                    txtInvoiceNO.Focus();
                    return;
                }
                #endregion
            }
            #endregion

            if (mes.ShowQ("发票连打将跳过已存在发票号的收费单据。\n确定要打印第'" + intStartRow.ToString() + "'行至第'" + intEndRow.ToString() + "'行收费明细的发票吗？") != DialogResult.OK)
                return;

            DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Clone();

            for (int i = intStartRow - 1; i < intEndRow; i++)
            {
                object objChargeID = dtHistoryWaterFee.Rows[i]["CHARGEID"];
                if (objChargeID == null || objChargeID == DBNull.Value)
                    continue;

                object objInvoiceState = dtHistoryWaterFee.Rows[i]["INVOICEPRINTSIGN"];
                if (objInvoiceState != null && objInvoiceState != DBNull.Value)
                    if (objInvoiceState.ToString() == "1")
                        continue;

                object objReadMeterRecordId = dtHistoryWaterFee.Rows[i]["readMeterRecordId"];
                if (objReadMeterRecordId == null || objReadMeterRecordId == DBNull.Value)
                    continue;

                //DataRow drHistoryWaterFee = dtHistoryWaterFee.Rows[i];
                dtHistoryWaterFeeTemp.Rows.Clear();
                dtHistoryWaterFeeTemp.ImportRow(dtHistoryWaterFee.Rows[i]);
                //DataRow drHistoryWaterFeeTemp = dtHistoryWaterFeeTemp.Rows[0];

                object objTotalNumber = dtHistoryWaterFee.Rows[i]["totalNumber"];
                if (Information.IsNumeric(objTotalNumber))
                    if (Convert.ToInt32(objTotalNumber) == 0)
                        continue;

                #region 发票明细字段
                int intReadMeterRecordYear = 0, intReadMeterRecordMonth = 0, intWaterMeterLastNumber = 0, intWaterMeterEndNumber = 0, intTotalNumber = 0;
                //string strWaterUserNO="",strWaterUserTypeID="",strWaterUserTypeName="",strwaterUserName = "", strWaterMeterNo = "", strWaterUserAddress = "", strWaterMeterTypeId = "", strWaterMeterTypeName = "";
                string strwaterUserName = "", strWaterMeterNo = "", strWaterUserAddress = "", strWaterMeterTypeId = "", strWaterMeterTypeName = "";
                decimal decAvePrice = 0, decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decTotalCharge = 0, decExtraChargePrice1 = 0, decExtraChargePrice2 = 0;

                object obj = dtHistoryWaterFeeTemp.Rows[0]["readMeterRecordYear"];
                if (Information.IsNumeric(obj))
                {
                    intReadMeterRecordYear = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["readMeterRecordMonth"];
                if (Information.IsNumeric(obj))
                {
                    intReadMeterRecordMonth = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterLastNumber"];
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterLastNumber = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterEndNumber"];
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterEndNumber = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["TOTALNUMBERCHARGE"];
                if (Information.IsNumeric(obj))
                {
                    intTotalNumber = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterUserName"];
                if (obj != null && obj != DBNull.Value)
                {
                    strwaterUserName = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterNo"];
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterNo = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterUserAddress"];
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterUserAddress = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterTypeId"];
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeId = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterTypeName"];
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeName = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["avePrice"];
                if (Information.IsNumeric(obj))
                {
                    decAvePrice = Convert.ToDecimal(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["WATERTOTALCHARGECHARGE"];
                if (Information.IsNumeric(obj))
                {
                    decWaterTotalCharge = Convert.ToDecimal(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"];
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge1 = Convert.ToDecimal(obj);
                    if (decExtraCharge1 == 0)
                        dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = DBNull.Value;
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["extraChargePrice1"];
                if (Information.IsNumeric(obj))
                {
                    decExtraChargePrice1 = Convert.ToDecimal(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"];
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge2 = Convert.ToDecimal(obj);
                    if (decExtraCharge2 == 0)
                        dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = DBNull.Value;
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["extraChargePrice2"];
                if (Information.IsNumeric(obj))
                {
                    decExtraChargePrice2 = Convert.ToDecimal(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["TOTALCHARGECHARGE"];
                if (Information.IsNumeric(obj))
                {
                    decTotalCharge = Convert.ToDecimal(obj);
                }

                DataRow[] drCount = dtHistoryWaterFee.Select("CHARGEID='" + objChargeID.ToString() + "'");
                if (drCount.Length > 1)
                {
                    dtHistoryWaterFeeTemp.Rows[0]["waterMeterLastNumber"] = DBNull.Value;
                    dtHistoryWaterFeeTemp.Rows[0]["waterMeterEndNumber"] = DBNull.Value;
                }
                #endregion

                #region 根据此字段判断面积均摊和按月份开票的水表
                object objReadMeterRecordMemo = dtHistoryWaterFeeTemp.Rows[0]["memo"];
                if (objReadMeterRecordMemo != null && objReadMeterRecordMemo != DBNull.Value)
                {
                    if (objReadMeterRecordMemo.ToString().Contains("@"))
                    {
                        string[] strReadMeterRecordMemo = objReadMeterRecordMemo.ToString().Split('@');
                        switch (strReadMeterRecordMemo[0])
                        {
                            case "AYKP"://名称根据月份开票
                                DateTime dtNow = mes.GetDatetimeNow();
                                int intMonthNow = dtNow.Month;
                                if (strReadMeterRecordMemo[1].Contains("|"))
                                {
                                    string[] strUserSet = strReadMeterRecordMemo[1].Split('|');
                                    for (int intAYKP = 0; intAYKP < strUserSet.Length; intAYKP++)
                                    {
                                        if (strUserSet[intAYKP].Contains(":"))
                                        {
                                            string[] strUserAndYF = strUserSet[intAYKP].Split(':');
                                            int intStartMonth = 0, intEndMonth = 0;
                                            if (strUserAndYF[1].Contains("-"))
                                            {
                                                if (Information.IsNumeric(strUserAndYF[1].Split('-')[0]))
                                                    intStartMonth = Convert.ToInt32(strUserAndYF[1].Split('-')[0]);
                                                if (Information.IsNumeric(strUserAndYF[1].Split('-')[1]))
                                                    intEndMonth = Convert.ToInt32(strUserAndYF[1].Split('-')[1]);
                                                if (intMonthNow >= intStartMonth && intMonthNow <= intEndMonth)
                                                {
                                                    strwaterUserName = strUserAndYF[0];
                                                    dtHistoryWaterFeeTemp.Rows[0]["waterUserName"] = strwaterUserName;
                                                    break;
                                                }

                                                //25311277   21-1060-2
                                            }
                                        }
                                    }
                                }
                                break;
                            case "MFYH"://免费不开票的
                                continue;
                            //break;
                            case "MJJT"://按面积均摊开票
                                if (strReadMeterRecordMemo[1].Contains("|"))
                                {
                                    DataTable dtMJJT = dtHistoryWaterFeeTemp.Copy();

                                    string[] strMJJTWaterNameS = strReadMeterRecordMemo[1].Split('|');
                                    for (int intMJFT = 0; intMJFT < strMJJTWaterNameS.Length; intMJFT++)
                                    {
                                        if (strMJJTWaterNameS[intMJFT].Contains(":"))
                                        {
                                            int intMJJTTotalNumber = 0;

                                            string[] strMJJTS = strMJJTWaterNameS[intMJFT].Split(':');
                                            if (Information.IsNumeric(strMJJTS[1]))
                                            {
                                                intMJJTTotalNumber = (int)Math.Floor(Convert.ToDecimal(strMJJTS[1]) * intTotalNumber + (decimal)0.5);
                                            }
                                            //DataRow drTemp = dtHistoryWaterFeeTemp.Rows[0];
                                            DataRow dr = dtMJJT.Rows[0];
                                            dr["TOTALNUMBERCHARGE"] = intMJJTTotalNumber;

                                            decWaterTotalCharge = intMJJTTotalNumber * decAvePrice;
                                            dr["WATERTOTALCHARGECHARGE"] = decWaterTotalCharge.ToString("F2");

                                            decExtraCharge1 = intMJJTTotalNumber * decExtraChargePrice1;
                                            if (decExtraCharge1 == 0)
                                                dr["EXTRACHARGECHARGE1"] = DBNull.Value;
                                            else
                                                dr["EXTRACHARGECHARGE1"] = decExtraCharge1.ToString("F2");

                                            decExtraCharge2 = decWaterTotalCharge * decExtraChargePrice2;
                                            if (decExtraCharge2 == 0)
                                                dr["EXTRACHARGECHARGE2"] = DBNull.Value;
                                            else
                                                dr["EXTRACHARGECHARGE2"] = decExtraCharge2.ToString("F2");

                                            decTotalCharge = decWaterTotalCharge + decExtraCharge1 + decExtraCharge2;
                                            dr["TOTALCHARGECHARGE"] = decTotalCharge.ToString("F2");

                                            dr["waterUserName"] = strMJJTS[0];

                                            //dtMJJT.Rows.Add(dr);

                                            MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                                            MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID("", "CHARGEINVOICEPRINT");
                                            MODELCHARGEINVOICEPRINTNEW.CHARGEID = objChargeID.ToString();
                                            MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                                            MODELCHARGEINVOICEPRINTNEW.INVOICENO = strStartInvoiceNO;
                                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatch.Text;
                                            MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTDATETIME = mes.GetDatetimeNow();

                                            MODELCHARGEINVOICEPRINTNEW.waterMeterNo = strWaterMeterNo;
                                            MODELCHARGEINVOICEPRINTNEW.waterUserName = strMJJTS[0];
                                            MODELCHARGEINVOICEPRINTNEW.waterUserAddress = strWaterUserAddress;
                                            MODELCHARGEINVOICEPRINTNEW.readMeterRecordYear = intReadMeterRecordYear;
                                            MODELCHARGEINVOICEPRINTNEW.readMeterRecordMonth = intReadMeterRecordMonth;
                                            MODELCHARGEINVOICEPRINTNEW.waterMeterLastNumber = intWaterMeterLastNumber;
                                            MODELCHARGEINVOICEPRINTNEW.waterMeterEndNumber = intWaterMeterEndNumber;
                                            MODELCHARGEINVOICEPRINTNEW.totalNumber = intMJJTTotalNumber;
                                            MODELCHARGEINVOICEPRINTNEW.avePrice = decAvePrice;
                                            MODELCHARGEINVOICEPRINTNEW.waterTotalCharge = decWaterTotalCharge;
                                            MODELCHARGEINVOICEPRINTNEW.extraCharge1 = decExtraCharge1;
                                            MODELCHARGEINVOICEPRINTNEW.extraCharge2 = decExtraCharge2;
                                            MODELCHARGEINVOICEPRINTNEW.totalCharge = decTotalCharge;
                                            MODELCHARGEINVOICEPRINTNEW.waterMeterTypeId = strWaterMeterTypeId;
                                            MODELCHARGEINVOICEPRINTNEW.waterMeterTypeName = strWaterMeterTypeName;

                                            if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW))
                                            {
                                                try
                                                {
                                                    //更新收费表已打发票标志
                                                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                                                    MODELWATERFEECHARGE.CHARGEID = MODELCHARGEINVOICEPRINTNEW.CHARGEID;
                                                    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";
                                                    if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                                                    {
                                                        foreach (DataRow drCharge in drCount)
                                                        {
                                                            drCharge["CHARGEINVOICEPRINTID"] = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                                                            drCharge["INVOICEBATCHNAME"] = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                                                            drCharge["INVOICENO"] = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                                                            drCharge["INVOICECANCEL"] = "正常";
                                                            drCharge["INVOICEPRINTSIGN"] = "1";
                                                        }

                                                        //btInvoicePrint.Enabled = false;
                                                        //mes.Show("发票补打成功!新的发票号为'" + MODELCHARGEINVOICEPRINTNEW.INVOICENO + "'");

                                                        #region 打印发票
                                                        DataSet ds = new DataSet();
                                                        //DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                                                        //DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                                                        //dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                                                        DataTable dtInvoice = dtMJJT;
                                                        dtInvoice.TableName = "普通发票模板";
                                                        ds.Tables.Add(dtInvoice.Copy());
                                                        FastReport.Report report1 = new FastReport.Report();
                                                        try
                                                        {
                                                            // load the existing report
                                                            report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                                                            // register the dataset
                                                            report1.RegisterData(ds);
                                                            report1.GetDataSource("普通发票模板").Enabled = true;
                                                            // run the report
                                                            //report1.Show();
                                                            //report1.Prepare();
                                                            report1.PrintSettings.ShowDialog = false;
                                                            report1.Print();
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                        finally
                                                        {
                                                            // free resources used by report
                                                            report1.Dispose();
                                                        }
                                                        #endregion

                                                        //获取新的发票号码
                                                        strStartInvoiceNO = (Convert.ToInt32(strStartInvoiceNO) + 1).ToString().PadLeft(8, '0');
                                                    }
                                                    else
                                                    {
                                                        BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                        mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，请重新设置发票起始号后继续打印!");
                                                        return;
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                    mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，请重新设置发票起始号后继续打印!");
                                                    log.Write(ex.ToString(), MsgType.Error);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                mes.Show("收费单据ID为空，请选择要打印发票的单据!");
                                                return;
                                            }

                                        }
                                    }
                                }
                                continue;
                        }
                    }
                }
                #endregion
                try
                {
                    #region 发票票额超过9999的
                   // /*
                    if (decTotalCharge >= 10000)
                    {
                        int intPerTotalNumber = 0;

                        //根据各个水价设置最大吨数
                        object objWaterMeterTypeID = dtHistoryWaterFee.Rows[i]["waterMeterTypeId"];
                        if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
                            switch (objWaterMeterTypeID.ToString())
                            {
                                //case "0001":
                                //    intPerTotalNumber = 5555;
                                //    break;
                                //case "0002":
                                //    intPerTotalNumber = 4700;//4760
                                //    break;
                                //case "0003":
                                //    intPerTotalNumber = 2000;
                                //    break;
                                //case "0004":
                                //    intPerTotalNumber = 2300;
                                //    break;
                                //case "0005":
                                //    intPerTotalNumber = 2300;
                                //    break;
                                //case "0007":
                                //    intPerTotalNumber = 2300;
                                //    break;                                 
                                case "0001":
                                    intPerTotalNumber = 4545;//2.2元
                                    break;
                                case "0002":
                                    intPerTotalNumber = 3998;//4760
                                    break;
                                case "0003":
                                    intPerTotalNumber = 1800;
                                    break;
                                case "0004":
                                    intPerTotalNumber = 1960;
                                    break;
                                case "0005":
                                    intPerTotalNumber = 1960;
                                    break;
                                case "0007":
                                    intPerTotalNumber = 1960;
                                    break;
                            }

                        int intPrintCount = (int)Math.Ceiling(intTotalNumber / (decimal)intPerTotalNumber);
                        for (int intInvoiceCount = intPrintCount - 1; intInvoiceCount >= 0; intInvoiceCount--)
                        {
                            decimal decWaterTotalChargeInvoice = 0, decExtraCharge1Invoice = 0, decExtraCharge2Invoice = 0, decTotalChargeInvoice;
                            int intPerTotalNumberInvoice = 0;
                            if (intInvoiceCount == intPrintCount - 1)
                            {
                                intPerTotalNumberInvoice = intTotalNumber - (intPrintCount - 1) * intPerTotalNumber;

                                dtHistoryWaterFeeTemp.Rows[0]["TOTALNUMBERCHARGE"] = intPerTotalNumberInvoice;

                                decWaterTotalChargeInvoice = intPerTotalNumberInvoice * decAvePrice;
                                dtHistoryWaterFeeTemp.Rows[0]["WATERTOTALCHARGECHARGE"] = decWaterTotalChargeInvoice.ToString("F2");

                                decExtraCharge1Invoice = intPerTotalNumberInvoice * decExtraChargePrice1;
                                if (decExtraCharge1Invoice == 0)
                                    dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = DBNull.Value;
                                else
                                    dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = decExtraCharge1Invoice.ToString("F2");

                                decExtraCharge2Invoice = decWaterTotalChargeInvoice * decExtraChargePrice2;
                                if (decExtraCharge2Invoice == 0)
                                    dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = DBNull.Value;
                                else
                                    dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = decExtraCharge2Invoice.ToString("F2");

                                decTotalChargeInvoice = decWaterTotalChargeInvoice + decExtraCharge1Invoice + decExtraCharge2Invoice;
                                dtHistoryWaterFeeTemp.Rows[0]["TOTALCHARGECHARGE"] = decTotalChargeInvoice.ToString("F2");
                            }
                            else
                            {
                                intPerTotalNumberInvoice = intPerTotalNumber;
                                dtHistoryWaterFeeTemp.Rows[0]["waterMeterLastNumber"] = DBNull.Value;

                                dtHistoryWaterFeeTemp.Rows[0]["waterMeterEndNumber"] = DBNull.Value;

                                dtHistoryWaterFeeTemp.Rows[0]["TOTALNUMBERCHARGE"] = intPerTotalNumber;

                                decWaterTotalChargeInvoice = intPerTotalNumber * decAvePrice;
                                dtHistoryWaterFeeTemp.Rows[0]["WATERTOTALCHARGECHARGE"] = decWaterTotalChargeInvoice.ToString("F2");

                                decExtraCharge1Invoice = intPerTotalNumber * decExtraChargePrice1;
                                if (decExtraCharge1Invoice == 0)
                                    dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = DBNull.Value;
                                else
                                    dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = decExtraCharge1Invoice.ToString("F2");

                                decExtraCharge2Invoice = decWaterTotalChargeInvoice * decExtraChargePrice2;
                                if (decExtraCharge2Invoice == 0)
                                    dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = DBNull.Value;
                                else
                                    dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = decExtraCharge2Invoice.ToString("F2");

                                decTotalChargeInvoice = decWaterTotalChargeInvoice + decExtraCharge1Invoice + decExtraCharge2Invoice;
                                dtHistoryWaterFeeTemp.Rows[0]["TOTALCHARGECHARGE"] = decTotalChargeInvoice.ToString("F2");
                            }

                            MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW1 = new MODELCHARGEINVOICEPRINT();
                            MODELCHARGEINVOICEPRINTNEW1.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID("", "CHARGEINVOICEPRINT");
                            MODELCHARGEINVOICEPRINTNEW1.CHARGEID = objChargeID.ToString();
                            MODELCHARGEINVOICEPRINTNEW1.INVOICECANCEL = "0";
                            MODELCHARGEINVOICEPRINTNEW1.INVOICENO = strStartInvoiceNO;
                            MODELCHARGEINVOICEPRINTNEW1.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                            MODELCHARGEINVOICEPRINTNEW1.INVOICEBATCHNAME = cmbBatch.Text;
                            MODELCHARGEINVOICEPRINTNEW1.INVOICEPRINTDATETIME = mes.GetDatetimeNow();

                            MODELCHARGEINVOICEPRINTNEW1.waterMeterNo = strWaterMeterNo;
                            MODELCHARGEINVOICEPRINTNEW1.waterUserName = strwaterUserName;
                            MODELCHARGEINVOICEPRINTNEW1.waterUserAddress = strWaterUserAddress;
                            MODELCHARGEINVOICEPRINTNEW1.readMeterRecordYear = intReadMeterRecordYear;
                            MODELCHARGEINVOICEPRINTNEW1.readMeterRecordMonth = intReadMeterRecordMonth;
                            MODELCHARGEINVOICEPRINTNEW1.waterMeterLastNumber = intWaterMeterLastNumber;
                            MODELCHARGEINVOICEPRINTNEW1.waterMeterEndNumber = intWaterMeterEndNumber;
                            MODELCHARGEINVOICEPRINTNEW1.totalNumber = intPerTotalNumberInvoice;
                            MODELCHARGEINVOICEPRINTNEW1.avePrice = decAvePrice;
                            MODELCHARGEINVOICEPRINTNEW1.waterTotalCharge = decWaterTotalChargeInvoice;
                            MODELCHARGEINVOICEPRINTNEW1.extraCharge1 = decExtraCharge1Invoice;
                            MODELCHARGEINVOICEPRINTNEW1.extraCharge2 = decExtraCharge2Invoice;
                            MODELCHARGEINVOICEPRINTNEW1.totalCharge = decTotalChargeInvoice;
                            MODELCHARGEINVOICEPRINTNEW1.waterMeterTypeId = strWaterMeterTypeId;
                            MODELCHARGEINVOICEPRINTNEW1.waterMeterTypeName = strWaterMeterTypeName;

                            if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW1))
                            {
                                try
                                {
                                    //更新收费表已打发票标志
                                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                                    MODELWATERFEECHARGE.CHARGEID = MODELCHARGEINVOICEPRINTNEW1.CHARGEID;
                                    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";
                                    if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                                    {
                                        //dtHistoryWaterFee.Rows[i]["CHARGEINVOICEPRINTID"] = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                                        //dtHistoryWaterFee.Rows[i]["INVOICEBATCHNAME"] = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                                        //dtHistoryWaterFee.Rows[i]["INVOICENO"] = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                                        //dtHistoryWaterFee.Rows[i]["INVOICECANCEL"] = "正常";
                                        foreach (DataRow drCharge in drCount)
                                        {
                                            drCharge["CHARGEINVOICEPRINTID"] = MODELCHARGEINVOICEPRINTNEW1.CHARGEINVOICEPRINTID;
                                            drCharge["INVOICEBATCHNAME"] = MODELCHARGEINVOICEPRINTNEW1.INVOICEBATCHNAME;
                                            drCharge["INVOICENO"] = MODELCHARGEINVOICEPRINTNEW1.INVOICENO;
                                            drCharge["INVOICECANCEL"] = "正常";
                                            drCharge["INVOICEPRINTSIGN"] = "1";
                                        }

                                        //btInvoicePrint.Enabled = false;
                                        //mes.Show("发票补打成功!新的发票号为'" + MODELCHARGEINVOICEPRINTNEW.INVOICENO + "'");

                                        #region 打印发票
                                        DataSet ds = new DataSet();
                                        //DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                                        //DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                                        //dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                                        DataTable dtInvoice = dtHistoryWaterFeeTemp;
                                        dtInvoice.TableName = "普通发票模板";
                                        ds.Tables.Add(dtInvoice.Copy());
                                        FastReport.Report report1 = new FastReport.Report();
                                        try
                                        {
                                            // load the existing report
                                            report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                                            // register the dataset
                                            report1.RegisterData(ds);
                                            report1.GetDataSource("普通发票模板").Enabled = true;
                                            // run the report
                                            //report1.Show();
                                            //report1.Prepare();
                                            report1.PrintSettings.ShowDialog = false;
                                            report1.Print();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        finally
                                        {
                                            // free resources used by report
                                            report1.Dispose();
                                        }
                                        #endregion

                                        //获取新的发票号码
                                        strStartInvoiceNO = (Convert.ToInt32(strStartInvoiceNO) + 1).ToString().PadLeft(8, '0');
                                    }
                                    else
                                    {
                                        BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW1.CHARGEID);
                                        mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，请重新设置发票起始号后继续打印!");
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW1.CHARGEID);
                                    mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，原因:" + ex.ToString());
                                    log.Write(ex.ToString(), MsgType.Error);
                                    return;
                                }
                            }
                            else
                            {
                                //BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID);
                                mes.Show("大额发票第'" + (intPrintCount + 1).ToString() + "行'插入发票表失败!");
                                return;
                            }
                        }
                        continue;
                    }
                    // * */
                    #endregion
                    MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                    MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID("", "CHARGEINVOICEPRINT");
                    MODELCHARGEINVOICEPRINTNEW.CHARGEID = objChargeID.ToString();
                    MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                    MODELCHARGEINVOICEPRINTNEW.INVOICENO = strStartInvoiceNO;
                    MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                    MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatch.Text;
                    MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTDATETIME = mes.GetDatetimeNow();

                    MODELCHARGEINVOICEPRINTNEW.waterMeterNo = strWaterMeterNo;
                    MODELCHARGEINVOICEPRINTNEW.waterUserName = strwaterUserName;
                    MODELCHARGEINVOICEPRINTNEW.waterUserAddress = strWaterUserAddress;
                    MODELCHARGEINVOICEPRINTNEW.readMeterRecordYear = intReadMeterRecordYear;
                    MODELCHARGEINVOICEPRINTNEW.readMeterRecordMonth = intReadMeterRecordMonth;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterLastNumber = intWaterMeterLastNumber;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterEndNumber = intWaterMeterEndNumber;
                    MODELCHARGEINVOICEPRINTNEW.totalNumber = intTotalNumber;
                    MODELCHARGEINVOICEPRINTNEW.avePrice = decAvePrice;
                    MODELCHARGEINVOICEPRINTNEW.waterTotalCharge = decWaterTotalCharge;
                    MODELCHARGEINVOICEPRINTNEW.extraCharge1 = decExtraCharge1;
                    MODELCHARGEINVOICEPRINTNEW.extraCharge2 = decExtraCharge2;
                    MODELCHARGEINVOICEPRINTNEW.totalCharge = decTotalCharge;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterTypeId = strWaterMeterTypeId;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterTypeName = strWaterMeterTypeName;

                    if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW))
                    {
                        try
                        {
                            //更新收费表已打发票标志
                            MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                            MODELWATERFEECHARGE.CHARGEID = MODELCHARGEINVOICEPRINTNEW.CHARGEID;
                            MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";
                            if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                            {
                                //dtHistoryWaterFee.Rows[i]["CHARGEINVOICEPRINTID"] = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                                //dtHistoryWaterFee.Rows[i]["INVOICEBATCHNAME"] = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                                //dtHistoryWaterFee.Rows[i]["INVOICENO"] = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                                //dtHistoryWaterFee.Rows[i]["INVOICECANCEL"] = "正常";
                                foreach (DataRow drCharge in drCount)
                                {
                                    drCharge["CHARGEINVOICEPRINTID"] = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                                    drCharge["INVOICEBATCHNAME"] = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                                    drCharge["INVOICENO"] = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                                    drCharge["INVOICECANCEL"] = "正常";
                                    drCharge["INVOICEPRINTSIGN"] = "1";
                                }

                                //btInvoicePrint.Enabled = false;
                                //mes.Show("发票补打成功!新的发票号为'" + MODELCHARGEINVOICEPRINTNEW.INVOICENO + "'");

                                #region 打印发票
                                DataSet ds = new DataSet();
                                //DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                                //DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                                //dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                                DataTable dtInvoice = dtHistoryWaterFeeTemp;
                                dtInvoice.TableName = "普通发票模板";
                                ds.Tables.Add(dtInvoice.Copy());
                                FastReport.Report report1 = new FastReport.Report();
                                try
                                {
                                    // load the existing report
                                    report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                                    // register the dataset
                                    report1.RegisterData(ds);
                                    report1.GetDataSource("普通发票模板").Enabled = true;
                                    // run the report
                                    //report1.Show();
                                    //report1.Prepare();
                                    report1.PrintSettings.ShowDialog = false;
                                    report1.Print();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    // free resources used by report
                                    report1.Dispose();
                                }
                                #endregion

                                //获取新的发票号码
                                strStartInvoiceNO = (Convert.ToInt32(strStartInvoiceNO) + 1).ToString().PadLeft(8, '0');
                            }
                            else
                            {
                                BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，请重新设置发票起始号后继续打印!");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                            mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，原因:" + ex.ToString());
                            log.Write(ex.ToString(), MsgType.Error);
                            return;
                        }
                        //05308488317
                    }
                    else
                    {
                        //BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID);
                        mes.Show("收费单据ID为空，请选择要打印发票的单据!");
                        return;
                    }
                }

                catch (Exception ex)
                {
                    mes.Show("打印第'" + (i + 1).ToString() + "'行时失败!原因:" + ex.Message);
                    log.Write("打印发票失败!原因:" + ex.ToString(), MsgType.Error);
                    return;
                }
            }


            //获取新的发票号码
            DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLoginID,"");
            if (dtNewInvoiceNO.Rows.Count > 0)
            {
                object objInvoiceBatch = dtNewInvoiceNO.Rows[0]["INVOICEBATCHID"];
                if (objInvoiceBatch != null && objInvoiceBatch != DBNull.Value)
                {
                    cmbBatch.SelectedValue = objInvoiceBatch.ToString();
                }
                object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                if (Information.IsNumeric(objInvoiceNO))
                {
                    txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                }
            }
            #endregion

            #region 之前发票单打功能
            /*
                if (dgHistoryWaterFee.CurrentRow == null)
                    return;
                if (txtChargeID.Text.Trim() == "")
                {
                    mes.Show("未找到要打印发票的收费单ID!请重新查询后再打印!");
                    return;
                }

                object objInvoiceCancel = dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                    if (objInvoiceCancel.ToString() == "正常")
                    {
                        mes.Show("该收费单已打印发票，如需更换发票请先点击'发票作废'后再补打发票!");
                        return;
                    }
                // 补打发票
                if (cmbBatch.SelectedValue == null || cmbBatch.SelectedValue == DBNull.Value)
                {
                    mes.Show("请选择发票批次!");
                    cmbBatch.Focus();
                    return;
                }
                if (txtInvoiceNO.Text.Trim() == "")
                {
                    mes.Show("请输入发票号码!");
                    txtInvoiceNO.Focus();
                    return;
                }
                else
                {
                    if (!Information.IsNumeric(txtInvoiceNO.Text))
                    {
                        mes.Show("发票号码只能由数字组成!");
                        txtInvoiceNO.Focus();
                        return;
                    }
                }
                txtInvoiceNO.Text = txtInvoiceNO.Text.PadLeft(8, '0');
                DataTable dtCheckInvoiceExists = BLLWATERFEECHARGE.QueryChargeView(" AND INVOICENO='" + txtInvoiceNO.Text + "' AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICECANCEL<>'3'");
                if (dtCheckInvoiceExists.Rows.Count > 0)
                {
                    mes.Show("发票批次为'" + cmbBatch.Text + "'票号为'" + txtInvoiceNO.Text + "'的发票已使用，请重新输入发票号码!");
                    txtInvoiceNO.Focus();
                    return;
                }
                else
                {
                    DataTable dtInvoiceFetch = BLLINVOICEFETCH.Query(" AND  INVOICEFETCHBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                    #region 验证发票领取记录是否重复
                    bool isExist = false;
                    for (int i = 0; i < dtInvoiceFetch.Rows.Count; i++)
                    {
                        long intStartNO = 0, intEndNO = 0;
                        object objNO = dtInvoiceFetch.Rows[i]["INVOICEFETCHSTARTNO"];
                        if (Information.IsNumeric(objNO))
                        {
                            intStartNO = Convert.ToInt64(objNO);
                        }
                        objNO = dtInvoiceFetch.Rows[i]["INVOICEFETCHENDNO"];
                        if (Information.IsNumeric(objNO))
                        {
                            intEndNO = Convert.ToInt64(objNO);
                        }
                        if (Convert.ToInt64(txtInvoiceNO.Text) >= intStartNO && Convert.ToInt64(txtInvoiceNO.Text) <= intEndNO)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        mes.Show("批次为'" + cmbBatch.Text + "'的发票起始号'" + txtInvoiceNO.Text + "'不在领取记录中,请确认发票号码是否正确!");
                        txtInvoiceNO.Focus();
                        return;
                    }
                    #endregion
                }

                DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Clone();

                #region 发票明细字段
                int intReadMeterRecordYear = 0, intReadMeterRecordMonth = 0, intWaterMeterLastNumber = 0, intWaterMeterEndNumber = 0, intTotalNumber = 0;
                string strwaterUserName = "", strWaterMeterNo = "", strWaterUserAddress = "", strWaterMeterTypeId = "", strWaterMeterTypeName = "";
                decimal decAvePrice = 0, decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decTotalCharge = 0;

                object obj = dgHistoryWaterFee.CurrentRow.Cells["readMeterRecordYear"].Value;
                if (Information.IsNumeric(obj))
                {
                    intReadMeterRecordYear = Convert.ToInt16(obj);
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["readMeterRecordMonth"].Value;
                if (Information.IsNumeric(obj))
                {
                    intReadMeterRecordMonth = Convert.ToInt16(obj);
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["waterMeterLastNumber"].Value;
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterLastNumber = Convert.ToInt16(obj);
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["waterMeterEndNumber"].Value;
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterEndNumber = Convert.ToInt16(obj);
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["totalNumber"].Value;
                if (Information.IsNumeric(obj))
                {
                    intTotalNumber = Convert.ToInt16(obj);
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["waterUserName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strwaterUserName = obj.ToString();
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["waterMeterNo"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterNo = obj.ToString();
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["waterUserAddress"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterUserAddress = obj.ToString();
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["waterMeterTypeId"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeId = obj.ToString();
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["waterMeterTypeName"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeName = obj.ToString();
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["avePrice"].Value;
                if (Information.IsNumeric(obj))
                {
                    decAvePrice = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["waterTotalCharge"].Value;
                if (Information.IsNumeric(obj))
                {
                    decWaterTotalCharge = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["extraCharge1"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge1 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["extraCharge2"].Value;
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge2 = Convert.ToDecimal(obj);
                }
                obj = dgHistoryWaterFee.CurrentRow.Cells["totalCharge"].Value;
                if (Information.IsNumeric(obj))
                {
                    decTotalCharge = Convert.ToDecimal(obj);
                }
                DataTable dtt = (DataTable)dgHistoryWaterFee.CurrentRow.DataBoundItem;


                if (mes.ShowQ("确定要将用户'" + strwaterUserName + "'的收费单据'" + txtChargeID.Text + "'补打批次为'" + cmbBatch.Text + "'票号为'" + txtInvoiceNO.Text + "'的发票吗?") != DialogResult.OK)
                    return;
                #endregion
                try
                {
                    MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                    MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID("", "CHARGEINVOICEPRINT");
                    MODELCHARGEINVOICEPRINTNEW.CHARGEID = txtChargeID.Text;
                    MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                    MODELCHARGEINVOICEPRINTNEW.INVOICENO = txtInvoiceNO.Text;
                    MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                    MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatch.Text;
                    MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTDATETIME = mes.GetDatetimeNow();

                    MODELCHARGEINVOICEPRINTNEW.waterUserName = strwaterUserName;
                    MODELCHARGEINVOICEPRINTNEW.waterUserAddress = strWaterUserAddress;
                    MODELCHARGEINVOICEPRINTNEW.readMeterRecordYear = intReadMeterRecordYear;
                    MODELCHARGEINVOICEPRINTNEW.readMeterRecordMonth = intReadMeterRecordMonth;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterLastNumber = intWaterMeterLastNumber;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterEndNumber = intWaterMeterEndNumber;
                    MODELCHARGEINVOICEPRINTNEW.totalNumber = intTotalNumber;
                    MODELCHARGEINVOICEPRINTNEW.avePrice = decAvePrice;
                    MODELCHARGEINVOICEPRINTNEW.waterTotalCharge = decWaterTotalCharge;
                    MODELCHARGEINVOICEPRINTNEW.extraCharge1 = decExtraCharge1;
                    MODELCHARGEINVOICEPRINTNEW.extraCharge2 = decExtraCharge2;
                    MODELCHARGEINVOICEPRINTNEW.totalCharge = decTotalCharge;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterTypeId = strWaterMeterTypeId;
                    MODELCHARGEINVOICEPRINTNEW.waterMeterTypeName = strWaterMeterTypeName;

                    if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW))
                    {
                        //更新收费表已打发票标志
                        if (txtChargeID.Text.Trim() != "")
                        {
                            MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                            MODELWATERFEECHARGE.CHARGEID = txtChargeID.Text;
                            MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";
                            if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                            {
                                for (int i = 0; i < dgHistoryWaterFee.Rows.Count; i++)
                                {
                                    object objChargeID = dgHistoryWaterFee.Rows[i].Cells["CHARGEID"].Value;
                                    if (objChargeID != null && objChargeID != DBNull.Value)
                                    {
                                        if (objChargeID.ToString() == MODELCHARGEINVOICEPRINTNEW.CHARGEID)
                                        {
                                            dgHistoryWaterFee.Rows[i].Cells["CHARGEINVOICEPRINTID"].Value = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                                            dgHistoryWaterFee.Rows[i].Cells["INVOICEBATCHNAME"].Value = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                                            dgHistoryWaterFee.Rows[i].Cells["INVOICENO"].Value = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                                            dgHistoryWaterFee.Rows[i].Cells["INVOICECANCEL"].Value = "正常";
                                        }
                                    }
                                }

                                btInvoicePrint.Enabled = false;
                                //mes.Show("发票补打成功!新的发票号为'" + MODELCHARGEINVOICEPRINTNEW.INVOICENO + "'");

                                #region 打印发票
                                DataSet ds = new DataSet();
                                DataTable dtInvoice = dtHistoryWaterFee.Copy();
                                dtInvoice.Select("CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'");
                                dtInvoice.TableName = "普通发票模板";
                                ds.Tables.Add(dtInvoice);
                                FastReport.Report report1 = new FastReport.Report();
                                try
                                {
                                    // load the existing report
                                    report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                                    // register the dataset
                                    report1.RegisterData(ds);
                                    report1.GetDataSource("普通发票模板").Enabled = true;
                                    // run the report
                                    //report1.Show();
                                    report1.Prepare();
                                    report1.PrintSettings.ShowDialog = false;
                                    report1.Print();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    // free resources used by report
                                    report1.Dispose();
                                }
                                #endregion

                                //获取新的发票号码
                                DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLoginID);
                                if (dtNewInvoiceNO.Rows.Count > 0)
                                {
                                    object objInvoiceBatch = dtNewInvoiceNO.Rows[0]["INVOICEBATCHID"];
                                    if (objInvoiceBatch != null && objInvoiceBatch != DBNull.Value)
                                    {
                                        cmbBatch.SelectedValue = objInvoiceBatch.ToString();
                                    }
                                    object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                                    if (Information.IsNumeric(objInvoiceNO))
                                    {
                                        txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                                    }
                                }
                            }
                            else
                            {
                                BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID);
                                mes.Show("更新发票打印标志失败，请重新点击打印发票按钮!");
                                return;
                            }
                        }
                        else
                        {
                            BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID);
                            mes.Show("收费单据ID为空，请选择要打印发票的单据!");
                            return;
                        }
                    }
                    else
                    {
                        mes.Show("打印发票失败!请重新选择要打印发票的单据!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    mes.Show("打印发票失败!原因:" + ex.Message);
                    log.Write("打印发票失败!原因:" + ex.ToString(), MsgType.Error);
                    return;
                }
                */
            #endregion
        }

        private void txtChargeID_TextChanged(object sender, EventArgs e)
        {
            //当收费单据变化时清空原因框
            txtMemo.Clear();
        }

        private void btReceiptPrint_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月结，无法执行此操作!");
                return;
            }
            if (strGroupID != "0001")
            {
                objJZ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZ != null && objJZ != DBNull.Value)
                {
                    if (objJZ.ToString() == "是")
                    {
                        mes.Show("该单据已经结账，无法执行此操作!");
                        return;
                    }
                }
            }
                if (txtReceiptNO.Text.Trim() == "")
                {
                    mes.Show("请输入收据号!");
                    txtReceiptNO.Focus();
                    return;
                }
                if (!Information.IsNumeric(txtReceiptNO.Text))
                {
                    mes.Show("收据号只能由数字组成!");
                    txtReceiptNO.SelectAll();
                    return;
                }
                txtReceiptNO.Text = txtReceiptNO.Text.PadLeft(8, '0');

                if (strGroupID != "0001")
                {

                    #region 验证是否在领取记录中
                    DataTable dtReceiptNO = new DataTable();
                    bool isExists = false;
                    dtReceiptNO = BLLRECEIPTFETCH.Query(" AND RECEIPTFETCHERID='" + strLoginID + "'");
                    if (dtReceiptNO.Rows.Count == 0)
                    {
                        mes.Show("收据号'" + txtReceiptNO.Text + "'不在领取记录中,请领取收据!");
                        return;
                    }
                    for (int i = 0; i < dtReceiptNO.Rows.Count; i++)
                    {
                        long intStartNO = 0, intEndNO = 0;
                        object obj = dtReceiptNO.Rows[i]["RECEIPTFETCHSTARTNO"];
                        if (Information.IsNumeric(obj))
                        {
                            intStartNO = Convert.ToInt64(obj);
                        }
                        obj = dtReceiptNO.Rows[i]["RECEIPTFETCHENDNO"];
                        if (Information.IsNumeric(obj))
                        {
                            intEndNO = Convert.ToInt64(obj);
                        }
                        if (Convert.ToInt64(txtReceiptNO.Text) >= intStartNO && Convert.ToInt64(txtReceiptNO.Text) <= intEndNO)
                        {
                            isExists = true;
                            break;
                        }
                    }
                    #endregion

                    if (!isExists)
                    {
                        mes.Show("收据号'" + txtReceiptNO.Text + "'不在领取记录中,请领取收据!");
                        return;
                    }
                }
                if (BLLWATERFEECHARGE.IsExistReceiptNO(txtReceiptNO.Text))
                {
                    if (mes.ShowQ("系统检测到号码为'" + txtReceiptNO.Text + "'的收据已使用,确定使用此号码吗?") != DialogResult.OK)
                    {
                        txtReceiptNO.SelectAll();
                        return;
                    }
                }
                string strWaterUserName = "", strWaterUserNO = "", strWaterUserAddress = "", strQQYE = "",
                    strBCYS = "", strBCSS = "", strJSYE = "", strSFSJ = "", strWorkerName = "",
                    strMeterReaderID = "", strMeterReaderName = "", strMeterReaderTel = "";

            object objWaterUserName = dgHistoryWaterFee.CurrentRow.Cells["waterUserName"].Value;
            if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                strWaterUserName = objWaterUserName.ToString();

            object objWaterUserNO = dgHistoryWaterFee.CurrentRow.Cells["waterUserNO"].Value;
            if (objWaterUserNO != null && objWaterUserNO != DBNull.Value)
                strWaterUserNO = objWaterUserNO.ToString();

            object objWaterUserAddress = dgHistoryWaterFee.CurrentRow.Cells["waterUserAddress"].Value;
            if (objWaterUserAddress != null && objWaterUserAddress != DBNull.Value)
                strWaterUserAddress = objWaterUserAddress.ToString();

            object objJSYE = dgHistoryWaterFee.CurrentRow.Cells["CHARGEYSJSYE"].Value;
            if (Information.IsNumeric(objJSYE))
                strJSYE = Convert.ToDecimal(objJSYE).ToString("F2");

            object objBCSS = dgHistoryWaterFee.CurrentRow.Cells["CHARGEBCSS"].Value;
            if (Information.IsNumeric(objBCSS))
                strBCSS = Convert.ToDecimal(objBCSS).ToString("F2");

            object objBCYS = dgHistoryWaterFee.CurrentRow.Cells["CHARGEBCYS"].Value;
            if (Information.IsNumeric(objBCYS))
                strBCYS = Convert.ToDecimal(objBCYS).ToString("F2");

            object objQQYE = dgHistoryWaterFee.CurrentRow.Cells["CHARGEYSQQYE"].Value;
            if (Information.IsNumeric(objQQYE))
                strQQYE =Convert.ToDecimal(objQQYE).ToString("F2");

            object objSFSJ = dgHistoryWaterFee.CurrentRow.Cells["CHARGEDATETIME"].Value;
            if (Information.IsDate(objSFSJ))
                strSFSJ = Convert.ToDateTime(objSFSJ).ToString("yyyy-MM-dd HH:mm:ss");
            else
            {
                strSFSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            object objWorkerName = dgHistoryWaterFee.CurrentRow.Cells["CHARGEWORKERNAME"].Value;
            if (objWorkerName != null && objWorkerName != DBNull.Value)
                strWorkerName = objWorkerName.ToString();

            object objmeterReaderID = dgHistoryWaterFee.CurrentRow.Cells["meterReaderID"].Value;
            if (objmeterReaderID != null && objmeterReaderID != DBNull.Value)
            {
                strMeterReaderID = objmeterReaderID.ToString();
                DataRow[] dr = dtMeterReader.Select("loginId='"+strMeterReaderID+"'");
                if (dr.Length>0)
                {
                    object objmeterReaderName = dr[0]["loginName"];
                    if (objmeterReaderName != null && objmeterReaderName != DBNull.Value)
                    {
                        strMeterReaderName = objmeterReaderName.ToString();
                    }
                    objmeterReaderName = dr[0]["telePhoneNO"];
                    if (objmeterReaderName != null && objmeterReaderName != DBNull.Value)
                    {
                        strMeterReaderTel = objmeterReaderName.ToString();
                    }
                }

            }
            
            try
            {
                //更新收费表已打发票标志
                if (txtChargeID.Text.Trim() != "")
                {
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = txtChargeID.Text;
                    MODELWATERFEECHARGE.RECEIPTNO = txtReceiptNO.Text;
                    if (BLLWATERFEECHARGE.UpdateReceiptPrintCount(MODELWATERFEECHARGE))
                    {
                        #region 打印收据
                        decimal decOverDuePrint = 0;
                        DataSet ds = new DataSet();
                        DataTable dtInvoice = dtHistoryWaterFee.Copy();
                        DataView dv = dtInvoice.DefaultView;
                        dv.RowFilter = "CHARGEID='" + MODELWATERFEECHARGE.CHARGEID + "'";
                        dtInvoice = dv.ToTable();
                        DataTable dtRecordTemp = dtInvoice.Clone();
                        dtRecordTemp.Columns["readMeterRecordYearAndMonth"].DataType = typeof(string);
                        foreach (DataRow dr in dtInvoice.Rows)
                        {
                            dtRecordTemp.ImportRow(dr);
                        }
                        for (int i = 0; i < dtRecordTemp.Rows.Count; i++)
                        {
                            object obj = dtRecordTemp.Rows[i]["readMeterRecordYearAndMonth"];
                            if (Information.IsDate(obj))
                                dtRecordTemp.Rows[i]["readMeterRecordYearAndMonth"] = Convert.ToDateTime(obj).ToString("yyyy-MM");

                            obj = dtRecordTemp.Rows[i]["OVERDUEEND"];
                            if (Information.IsNumeric(obj))
                                decOverDuePrint += Convert.ToDecimal(obj);
                            //object objWaterMeterNO = dtRecord.Rows[i]["waterMeterNo"];
                            //if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                            //    if (objWaterMeterNO.ToString().Length > 7)
                            //        dtRecord.Rows[i]["waterMeterNo"] = objWaterMeterNO.ToString().Substring(6, 2);
                        }
                        dtRecordTemp.TableName = "营业坐收收据模板";
                        ds.Tables.Add(dtRecordTemp);
                        FastReport.Report report1 = new FastReport.Report();
                        try
                        {
                            // load the existing report
                            report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\营业坐收收据模板.frx");
                            // register the dataset
                            report1.RegisterData(ds);
                            report1.GetDataSource("营业坐收收据模板").Enabled = true;

                            (report1.FindObject("txtDateTime") as FastReport.TextObject).Text = strSFSJ;
                            (report1.FindObject("CellWaterUserNO") as FastReport.Table.TableCell).Text = strWaterUserNO;
                            (report1.FindObject("CellWaterUserName") as FastReport.Table.TableCell).Text = strWaterUserName;
                            (report1.FindObject("CellWaterUserAddress") as FastReport.Table.TableCell).Text = strWaterUserAddress;
                            (report1.FindObject("txtOverDue") as FastReport.TextObject).Text = "滞纳金:" + decOverDuePrint.ToString("F2");
                            (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额: " + strQQYE;
                            (report1.FindObject("txtBCSF") as FastReport.TextObject).Text = "水费合计: " + strBCYS;
                            (report1.FindObject("txtBCJF") as FastReport.TextObject).Text = "本次交费: " + strBCSS;
                            (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额: " + strJSYE;
                            (report1.FindObject("txtChargeWorkerName") as FastReport.TextObject).Text = strWorkerName;
                            (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO." + txtReceiptNO.Text;

                            (report1.FindObject("txtMeterReader") as FastReport.TextObject).Text = strMeterReaderName;
                            (report1.FindObject("txtMeterReaderTel") as FastReport.TextObject).Text = strMeterReaderTel;

                            string strCapMoney = RMBToCapMoney.CmycurD(strBCSS);
                            (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;
                            report1.Prepare();
                            report1.PrintSettings.ShowDialog = false;
                            report1.Print();
                            // run the report
                            //report1.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            // free resources used by report
                            report1.Dispose();
                        }
                        #endregion
                    }
                    else
                    {
                        mes.Show("更新收据打印标志失败!");
                        return;
                    }
                }
                else
                {
                    mes.Show("更新收据打印标志失败!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show("收据打印失败!原因:" + ex.Message);
                log.Write("收据打印失败!原因:" + ex.ToString(), MsgType.Error);
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

        private void btChangeInvoice_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月结，无法执行此操作!");
                return;
            }
            if (strGroupID != "0001")
            {
                objJZ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZ != null && objJZ != DBNull.Value)
                {
                    if (objJZ.ToString() == "是")
                    {
                        mes.Show("该单据已经结账，无法执行此操作!");
                        return;
                    }
                }
            }
            try
            {
                if (txtChargeInvoicePrintID.Text.Trim() == "")
                {
                    mes.Show("单据'"+txtChargeID.Text+"'未有发票打印信息,无法变更发票号!");
                    btInvoicePrint.Focus();
                    return;
                }
                if (txtNewInvoiceNO.Text.Trim() == "")
                {
                    mes.Show("请输入新的发票号码!");
                    txtNewInvoiceNO.Focus();
                    return;
                }
                else
                {
                    if (cmbBatchNew.SelectedValue != null && cmbBatchNew.SelectedValue != DBNull.Value)
                    {
                        if (BLLWATERFEECHARGE.IsExistInvoiceNO(txtNewInvoiceNO.Text, cmbBatchNew.SelectedValue.ToString()))
                        {
                            if (mes.ShowQ("批次为'" + cmbBatchNew.Text + "'的发票号码'" + txtNewInvoiceNO.Text + "'已经使用过，是否继续变更?") != DialogResult.OK)
                            {
                                txtNewInvoiceNO.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        mes.Show("请选择发票批次!");
                        cmbBatchNew.Focus();
                        return;
                    }
                }
                if (txtChargeInvoicePrintID.Text.Trim() != "" && txtChargeID.Text.Trim() != "")
                {
                    string strInvoiceNO = "";
                    object objInvoiceNO = dgHistoryWaterFee.CurrentRow.Cells["INVOICENO"].Value;
                    if (objInvoiceNO != null && objInvoiceNO != DBNull.Value)
                    {
                        strInvoiceNO = objInvoiceNO.ToString();
                    }

                    if (mes.ShowQ("确定要将单据'"+txtChargeID.Text+"'的发票号'" + strInvoiceNO + "'变更为为'" + txtNewInvoiceNO.Text + "'?") != DialogResult.OK)
                        return;
                        try
                        {
                            MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                            MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = txtChargeInvoicePrintID.Text;
                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID =cmbBatchNew.SelectedValue.ToString();
                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatchNew.Text;
                            MODELCHARGEINVOICEPRINTNEW.INVOICENO = txtNewInvoiceNO.Text;
                            //MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL="0";
                            if (BLLCHARGEINVOICEPRINT.ChangeInvoiceNO(MODELCHARGEINVOICEPRINTNEW))
                            {
                                dgHistoryWaterFee.CurrentRow.Cells["INVOICEBATCHNAME"].Value = MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME;
                                dgHistoryWaterFee.CurrentRow.Cells["INVOICENO"].Value = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                                dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value = "正常";
                                mes.Show("发票变更成功!新的发票号为'" + MODELCHARGEINVOICEPRINTNEW.INVOICENO + "'");
                            }
                            else
                            {
                                mes.Show("变更发票号失败!请重新选择要变更的单据!");
                                return;
                            }
                        }
                        catch (Exception exx)
                        {
                            mes.Show(exx.Message + "\n变更发票号失败!请重新选择要变更的单据!");
                            log.Write(exx.ToString(), MsgType.Error);
                            return;
                        }
                }
                else
                {
                    mes.Show("发票单据号为空,无法变更发票号!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message + "变更发票号失败!请重新选择要变更的单据!");
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }

            #region 之前发票变更程序
            /*
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            try
            {
                if (txtChargeInvoicePrintID.Text.Trim() == "")
                {
                    mes.Show("当前所选单据未有发票打印信息,无法变更发票号!");
                    btInvoicePrint.Focus();
                    return;
                }
                if (txtNewInvoiceNO.Text.Trim() == "")
                {
                    mes.Show("请输入新的发票号码!");
                    txtNewInvoiceNO.Focus();
                    return;
                }
                else
                {
                    if (cmbBatchNew.SelectedValue != null && cmbBatchNew.SelectedValue != DBNull.Value)
                    {
                        if (BLLWATERFEECHARGE.IsExistInvoiceNO(txtNewInvoiceNO.Text, cmbBatchNew.SelectedValue.ToString()))
                        {
                            if (mes.ShowQ("批次为'" + cmbBatchNew.Text + "'的发票号码'" + txtNewInvoiceNO.Text + "'已经使用过，是否继续变更?") != DialogResult.OK)
                            {
                                txtNewInvoiceNO.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        mes.Show("请选择发票批次!");
                        cmbBatchNew.Focus();
                        return;
                    }
                }
                if (txtChargeInvoicePrintID.Text.Trim() != "" && txtChargeID.Text.Trim() != "")
                {
                    string strInvoiceNO = "";
                    object objInvoiceNO = dgHistoryWaterFee.CurrentRow.Cells["INVOICENO"].Value;
                    if (objInvoiceNO != null && objInvoiceNO != DBNull.Value)
                    {
                        strInvoiceNO = objInvoiceNO.ToString();
                    }

                    if (mes.ShowQ("确定要将票号为'" + strInvoiceNO + "'的发票作废后变更为票号为'" + txtNewInvoiceNO.Text + "'的发票吗?") != DialogResult.OK)
                        return;
                    MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT = new MODELCHARGEINVOICEPRINT();
                    MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID = txtChargeInvoicePrintID.Text;

                    MODELCHARGEINVOICEPRINT.INVOICESTATE = dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value;//记录未变更前的发票状态

                    MODELCHARGEINVOICEPRINT.INVOICECANCEL = "1";
                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = strLoginID;
                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = strLoginName;
                    MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME = mes.GetDatetimeNow();
                    MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = txtMemo.Text;
                    if (BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT))
                    {
                        try
                        {
                            MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                            MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID("", "CHARGEINVOICEPRINT");
                            MODELCHARGEINVOICEPRINTNEW.CHARGEID = txtChargeID.Text;
                            MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                            MODELCHARGEINVOICEPRINTNEW.INVOICENO = txtNewInvoiceNO.Text;
                            if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW))
                            {
                                dgHistoryWaterFee.CurrentRow.Cells["CHARGEINVOICEPRINTID"].Value = MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID;
                                dgHistoryWaterFee.CurrentRow.Cells["INVOICENO"].Value = MODELCHARGEINVOICEPRINTNEW.INVOICENO;
                                dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value = "正常";
                                mes.Show("发票变更成功!新的发票号为'" + MODELCHARGEINVOICEPRINTNEW.INVOICENO + "'");


                                //获取新的发票号码
                                object objNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLoginID);
                                if (Information.IsNumeric(objNewInvoiceNO))
                                {
                                    txtNewInvoiceNO.Text = (Convert.ToInt64(objNewInvoiceNO) + 1).ToString();
                                    txtInvoiceNO.Text = (Convert.ToInt64(objNewInvoiceNO) + 1).ToString();
                                }
                            }
                            else
                            {
                                dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value = MODELCHARGEINVOICEPRINT.INVOICESTATE;
                                MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";
                                MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = null;
                                MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = null;
                                MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = null;
                                BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT);
                                mes.Show("变更发票号失败!请重新选择要变更的单据!");
                                return;
                            }
                        }
                        catch (Exception exx)
                        {
                            dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value = MODELCHARGEINVOICEPRINT.INVOICESTATE;
                            MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";
                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = null;
                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = null;
                            MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = null;
                            BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT);
                            mes.Show(exx.Message + "变更发票号失败!请重新选择要变更的单据!");
                            log.Write(exx.ToString(), MsgType.Error);
                            return;
                        }
                    }
                    else
                    {
                        mes.Show("变更发票号失败!请重新选择要变更的单据!");
                        return;
                    }
                }
                else
                {
                    mes.Show("收费单号或发票单据号为空,变更发票号失败!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message + "变更发票号失败!请重新选择要变更的单据!");
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
             * */
            #endregion
        }

        private void btInvoiceCancel_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;

            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月结，无法执行此操作!");
                return;
            }
            if (strGroupID != "0001")
            {
                objJZ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZ != null && objJZ != DBNull.Value)
                {
                    if (objJZ.ToString() == "是")
                    {
                        mes.Show("该单据已经结账，无法执行此操作!");
                        return;
                    }
                }
            }
                if (cmbInvoiceCancelReason.SelectedIndex < 1)
                {
                    cmbInvoiceCancelReason.Focus();
                    mes.Show("请选择发票作废原因!");
                    return;
                }
                //获取连打起始号及终止号
                int intStartRow = 0, intEndRow = dtHistoryWaterFee.Rows.Count;
                if (!Information.IsNumeric(txtStartRow.Text))
                {
                    mes.Show("请输入连打起始行号!");
                    txtStartRow.Focus();
                    return;
                }
                else
                {
                    if (Convert.ToInt32(txtStartRow.Text) < 1)
                    {
                        mes.Show("连打起始行号不能小于1!");
                        txtStartRow.Focus();
                        return;
                    }
                    intStartRow = Convert.ToInt32(txtStartRow.Text);
                }
                if (Information.IsNumeric(txtEndRow.Text))
                {
                    if (Convert.ToInt32(txtStartRow.Text) > Convert.ToInt32(txtEndRow.Text))
                    {
                        mes.Show("连打起始行号不能大于终止行号!");
                        txtEndRow.Focus();
                        return;
                    }
                    if (Convert.ToInt32(txtEndRow.Text) < dtHistoryWaterFee.Rows.Count)
                        intEndRow = Convert.ToInt32(txtEndRow.Text);
                }

                if (mes.ShowQ("发票作废将跳过没有打印发票的行及发票已经作废的行。\n确定要将第'" + intStartRow.ToString() + "'行至第'" + intEndRow.ToString() + "'行的单据发票作废吗?") != DialogResult.OK)
                    return;
                for (int i = intStartRow - 1; i < intEndRow; i++)
                {
                    try
                    {
                        object objInvoiceCancel = dgHistoryWaterFee.Rows[i].Cells["INVOICECANCEL"].FormattedValue;
                        if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                            if (objInvoiceCancel.ToString().Contains("作废"))
                            {
                                continue;
                            }

                        object objChargeID = dgHistoryWaterFee.Rows[i].Cells["CHARGEID"].Value;
                        if (objChargeID == null && objChargeID == DBNull.Value)
                            continue;

                            string strInvoiceNO = "";
                            object objInvoiceNO = dgHistoryWaterFee.Rows[i].Cells["INVOICENO"].Value;
                            if (objInvoiceNO != null && objInvoiceNO != DBNull.Value)
                            {
                                strInvoiceNO = objInvoiceNO.ToString();
                            }

                            MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT = new MODELCHARGEINVOICEPRINT();
                            MODELCHARGEINVOICEPRINT.INVOICECANCEL = (cmbInvoiceCancelReason.SelectedIndex + 1).ToString();//冲减作废的状态为1，冲减功能将原因自动识别为1
                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = strLoginID;
                            MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = strLoginName;
                            MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME = mes.GetDatetimeNow();

                            MODELCHARGEINVOICEPRINT.CHARGEID = objChargeID.ToString();

                            //MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = txtMemo.Text;
                            if (BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT))
                            {
                                try
                                {
                                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                                    MODELWATERFEECHARGE.CHARGEID = objChargeID.ToString();
                                    MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                                    if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                                    {
                                        for (int j = 0; j < dgHistoryWaterFee.Rows.Count; j++)
                                        {
                                            object objChargeIDS = dgHistoryWaterFee.Rows[j].Cells["CHARGEID"].Value;
                                            if (objChargeIDS != null && objChargeIDS != DBNull.Value)
                                            {
                                                if (objChargeIDS.ToString() == objChargeID.ToString())
                                                {
                                                    dgHistoryWaterFee.Rows[j].Cells["INVOICECANCEL"].Value = cmbInvoiceCancelReason.Text;
                                                    dgHistoryWaterFee.Rows[j].Cells["INVOICEPRINTSIGN"].Value = "0";
                                                    dgHistoryWaterFee.Rows[j].Cells["INVOICEBATCHNAME"].Value = null;
                                                    dgHistoryWaterFee.Rows[j].Cells["INVOICENO"].Value = null;
                                                    dgHistoryWaterFee.Rows[j].Cells["CHARGEINVOICEPRINTID"].Value = null;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";//冲减作废的状态为1，冲减功能将原因自动识别为1
                                        MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = null;
                                        MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = null;
                                        MODELCHARGEINVOICEPRINT.CHARGEID = objChargeID.ToString();
                                        BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MODELCHARGEINVOICEPRINT.INVOICECANCEL = "0";//冲减作废的状态为1，冲减功能将原因自动识别为1
                                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = null;
                                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = null;
                                    MODELCHARGEINVOICEPRINT.CHARGEID = objChargeID.ToString();
                                    BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT);

                                    mes.Show("第'" + (i + 1).ToString() + "行'更新收费单据发票状态失!,原因:\n" + ex.Message);
                                    log.Write(ex.ToString(), MsgType.Error);
                                    return;
                                }
                            }
                    }
                    catch (Exception ex)
                    {
                        mes.Show("第'" + (i + 1).ToString() + "行'发票作废失败,原因:\n" + ex.Message);
                        log.Write(ex.ToString(), MsgType.Error);
                        return;
                    }
                }
            #region 之前发票作废程序
            /*
            try
            {
                object objInvoiceCancel = dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].FormattedValue;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                    if (objInvoiceCancel.ToString().Contains("作废"))
                    {
                        mes.Show("该发票已经作废,无需再次作废!");
                        return;
                    }
                if (txtChargeInvoicePrintID.Text.Trim() != "" && txtChargeID.Text.Trim() != "")
                {
                    string strInvoiceNO = "";
                    object objInvoiceNO = dgHistoryWaterFee.CurrentRow.Cells["INVOICENO"].Value;
                    if (objInvoiceNO != null && objInvoiceNO != DBNull.Value)
                    {
                        strInvoiceNO = objInvoiceNO.ToString();
                    }

                    if (cmbInvoiceCancelReason.SelectedIndex < 1)
                    {
                        cmbInvoiceCancelReason.Focus();
                        mes.Show("请选择发票作废原因!");
                        return;
                    }

                    if (mes.ShowQ("确定要将票号为'" + strInvoiceNO + "'的发票作废吗?") != DialogResult.OK)
                        return;
                    MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINT = new MODELCHARGEINVOICEPRINT();
                    MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID = txtChargeInvoicePrintID.Text;
                    MODELCHARGEINVOICEPRINT.INVOICECANCEL = (cmbInvoiceCancelReason.SelectedIndex+1).ToString();//冲减作废的状态为1，冲减功能将原因自动识别为1
                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERID = strLoginID;
                    MODELCHARGEINVOICEPRINT.INVOICECANCELWORKERNAME = strLoginName;
                    MODELCHARGEINVOICEPRINT.INVOICECANCELDATETIME = mes.GetDatetimeNow();
                    //MODELCHARGEINVOICEPRINT.INVOICECANCELMEMO = txtMemo.Text;
                    if (BLLCHARGEINVOICEPRINT.UpdateCancelState(MODELCHARGEINVOICEPRINT))
                    {
                        //更新收费表已打发票标志
                        if (txtChargeID.Text.Trim() != "")
                        {
                            MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                            MODELWATERFEECHARGE.CHARGEID = txtChargeID.Text;
                            MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                            if (BLLWATERFEECHARGE.UpdateInvoicePrintSign(MODELWATERFEECHARGE))
                            {
                            }
                        }
                        for (int i = 0; i < dgHistoryWaterFee.Rows.Count; i++)
                        {
                            object objChargeInvoicePrintID = dgHistoryWaterFee.Rows[i].Cells["CHARGEINVOICEPRINTID"].Value;
                            if (objChargeInvoicePrintID != null && objChargeInvoicePrintID != DBNull.Value)
                            {
                                if (objChargeInvoicePrintID.ToString() == MODELCHARGEINVOICEPRINT.CHARGEINVOICEPRINTID)
                                    dgHistoryWaterFee.Rows[i].Cells["INVOICECANCEL"].Value = "作废";
                            }
                        }
                        dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value = "作废";
                        btInvoiceCancel.Enabled = false;
                        btInvoicePrint.Enabled = true;
                        mes.Show("票号为'" + strInvoiceNO + "'的发票作废成功!");
                    }
                }
                else
                {
                    mes.Show("收费单号或发票单据号为空,发票作废失败!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message + "发票作废失败!请重新选择要变更的单据!");
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
             * */
            #endregion
        }

        private void dgHistoryWaterFee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgHistoryWaterFee.Columns[e.ColumnIndex].Name == "INVOICECANCEL")
            {
                object objInvoiceCancel = e.Value;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                {
                    if (objInvoiceCancel.ToString() == "0")
                        e.Value = "正常";//如果有正常状态的发票就不能打印第二次  只能先作废再打印
                    else if (objInvoiceCancel.ToString() == "1")
                        e.Value = "冲减作废";
                    else if (objInvoiceCancel.ToString() == "2")
                        e.Value = "损坏作废";
                    else if (objInvoiceCancel.ToString() == "3")
                        e.Value = "未打作废";
                }
                else
                    e.Value = "未打发票";

            }
            if (dgHistoryWaterFee.Columns[e.ColumnIndex].Name == "CHARGECANCEL")
            {
                object objInvoiceCancel = e.Value;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                    if (objInvoiceCancel.ToString() == "0")
                        e.Value = "正常";//如果有正常状态的发票就不能打印第二次  只能先作废再打印
                    else if (objInvoiceCancel.ToString() == "1")
                        e.Value = "作废";
            }
            if (dgHistoryWaterFee.Columns[e.ColumnIndex].Name == "CHARGEClASS")
            {
                object obj = e.Value;
                if (obj != null && obj != DBNull.Value)
                {
                    if (obj.ToString() == "1")
                        e.Value = "收取水费";
                    else if (obj.ToString() == "2")
                        e.Value = "预存水费";
                    if (obj.ToString() == "3")
                        e.Value = "收取水费";
                    else if (obj.ToString() == "4")
                        e.Value = "红冲水费";
                    else if (obj.ToString() == "5")
                        e.Value = "红冲预存";
                    else if (obj.ToString() == "6")
                        e.Value = "余额退费";
                    else if (obj.ToString() == "7")
                        e.Value = "余额转户";
                }
            }
        }

        private void txtChargeNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(null, null);
            }
        }

        private void dgHistoryWaterFee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtChargeID.Clear();
            txtChargeInvoicePrintID.Clear();
            txtMemo.Clear();
            cmbInvoiceCancelReason.Text = "";

            txtStartRow.Text = (e.RowIndex+1).ToString();

            object objChargeInvoicePrintID = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGEINVOICEPRINTID"].Value;
            if (objChargeInvoicePrintID != null && objChargeInvoicePrintID != DBNull.Value)
            {
                txtChargeInvoicePrintID.Text = objChargeInvoicePrintID.ToString();
                btInvoiceCancel.Enabled = true;
                btInvoiceMakeUp.Enabled = true;

                object objInvoiceCancel = dgHistoryWaterFee.Rows[e.RowIndex].Cells["INVOICECANCEL"].FormattedValue;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                    if (objInvoiceCancel.ToString() == "正常")
                    {
                        btInvoiceCancel.Enabled = true;
                        btInvoicePrint.Enabled = false;//如果有正常状态的发票就不能打印第二次  只能先作废再打印
                        btChangeInvoice.Enabled = true;//可以变更
                        btInvoiceMakeUp.Enabled = true;
                    }
                    else
                    {
                        btInvoiceCancel.Enabled = false;
                        btInvoicePrint.Enabled = true;
                    }
                else
                {
                    btInvoicePrint.Enabled = true;
                    btChangeInvoice.Enabled = false;
                }
            }
            else
            {
                btInvoiceCancel.Enabled = false;
                btInvoiceMakeUp.Enabled = false;

                btInvoicePrint.Enabled = true;
                btChangeInvoice.Enabled = false;
            }

            object objReceiptNO = dgHistoryWaterFee.Rows[e.RowIndex].Cells["RECEIPTNO"].Value;
                if (objReceiptNO != null && objReceiptNO != DBNull.Value)
                {
                    btCancel.Enabled = true;
                }
                else
                    btCancel.Enabled = false;

            object objChargeID = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGEID"].Value;
            if (objChargeID != null && objChargeID != DBNull.Value)
            {
                txtChargeID.Text = objChargeID.ToString();

                object objTotalCharge = dgHistoryWaterFee.Rows[e.RowIndex].Cells["totalChargeEND"].Value;
                if (Information.IsNumeric(objTotalCharge))
                    txtWaterFee.Text = objTotalCharge.ToString();
                else
                    txtWaterFee.Text = "0";
                object objOverDue = dgHistoryWaterFee.Rows[e.RowIndex].Cells["OVERDUEEND"].Value;
                if (Information.IsNumeric(objOverDue))
                    txtOverDueSum.Text = objOverDue.ToString();
                else
                    txtOverDueSum.Text = "0";
                object objChargeBCYS = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGEBCYS"].Value;
                if (Information.IsNumeric(objChargeBCYS))
                    txtBCYS.Text = objChargeBCYS.ToString();
                else
                    txtBCYS.Text = "0";
                object objChargeBCSS = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGEBCSS"].Value;
                if (Information.IsNumeric(objChargeBCSS))
                    txtBCSS.Text = objChargeBCSS.ToString();
                else
                    txtBCSS.Text = "0";

                txtYSQQYE.Text = "0";
                //查询用户余额
                object objWaterUserID = dgHistoryWaterFee.Rows[e.RowIndex].Cells["waterUserId"].Value;
                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                {
                    object objWaterUserPreStore = BLLwaterUser.GetPrestore(" AND waterUserId='" + objWaterUserID.ToString() + "'");
                    if (Information.IsNumeric(objWaterUserPreStore))
                        txtYSQQYE.Text = objWaterUserPreStore.ToString();
                }
                txtBCJY.Text = (Convert.ToDecimal(txtBCYS.Text) - Convert.ToDecimal(txtBCSS.Text)).ToString();
                txtYSJSYE.Text = (Convert.ToDecimal(txtBCYS.Text) + Convert.ToDecimal(txtYSQQYE.Text) - Convert.ToDecimal(txtBCSS.Text)).ToString();

                    object objChargeTypeID = dgHistoryWaterFee.Rows[e.RowIndex].Cells["CHARGETYPEID"].Value;
                    if (objChargeTypeID != null && objChargeTypeID != DBNull.Value)
                        cmbChargeTypeOld.SelectedValue = objChargeTypeID.ToString();

                btCancelCharge.Enabled = true;
                btReceiptPrint.Enabled = true;
            }
            else
            {
                btCancelCharge.Enabled = false;
                btReceiptPrint.Enabled = false;
                btInvoicePrint.Enabled = false;
                btInvoiceMakeUp.Enabled = false;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode == null)
                return;

            TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
            trMeterReading_AfterSelect(null, ex);
        }

        /// <summary>
        /// 存储所有查询到的收费记录
        /// </summary>
        DataTable dtHistoryWaterFee = new DataTable();
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
                //Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("收费冲减与发票补打界面:" + ex.ToString(), MsgType.Error);
                //mes.Show(ex.Message);
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
                log.Write("收费冲减与发票补打界面:" + ex.ToString(), MsgType.Error);
            }
        }
        private void LoadData(string[] strNodeID)
        {
            try
            {
                txtChargeID.Clear();
                txtNewInvoiceNO.Clear();
                txtInvoiceNO.Clear();
                txtWaterFee.Text = "0";
                txtOverDueSum.Text = "0";
                txtBCYS.Text = "0";
                txtBCSS.Text = "0";

                txtYSQQYE.Text = "0";
                txtBCJY.Text = "0";
                txtYSJSYE.Text = "0";

                string strFilter = strNodeID[2] + strSeniorFilterHidden + " AND chargeState='3' ";
                if (chkChargeDateTime.Checked)
                {
                    strFilter += " AND CHARGEDATETIME BETWEEN '" + dtpStart.Text.ToString() + "' AND '" + dtpEnd.Text + "'";
                }
                //DateTime dtNow = mes.GetDatetimeNow();
                if (txtChargeNO.Text.Trim() != "")
                {
                    strFilter += " AND CHARGEID LIKE '%" + txtChargeNO.Text + "%'";
                }
                if (txtWaterUserNO.Text.Trim() != "")
                {
                    if (txtWaterUserNO.Text.Length < 6)
                        strFilter += " AND waterUserNO='U" + txtWaterUserNO.Text.PadLeft(5, '0') + "'";
                    else
                        strFilter += " AND waterUserNO='" + txtWaterUserNO.Text + "'";
                }
                if (txtWaterUserName.Text.Trim() != "")
                {
                    strFilter += " AND waterUserName LIKE '%" + txtWaterUserName.Text+ "%'";
                }


                if (chkZZS.Checked)
                    strFilter += " AND waterUserTypeId<>'0004' ";

                if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                    strFilter += " AND CHARGECANCEL ='0' AND CHARGEWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

                if (txtYearAndMonth.Text.Length == 6)
                {
                    string strYear = txtYearAndMonth.Text.Substring(0, 4), strMonth = txtYearAndMonth.Text.Substring(4, 2);
                    //查询条件
                    strFilter += " AND  readMeterRecordYear=" + strYear + " AND readMeterRecordMonth=" + strMonth;
                }

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

                ////获取新的发票号码
                //DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLoginID,"");
                //if (dtNewInvoiceNO.Rows.Count > 0)
                //{
                //    object objInvoiceBatch = dtNewInvoiceNO.Rows[0]["INVOICEBATCHID"];
                //    if (objInvoiceBatch != null && objInvoiceBatch != DBNull.Value)
                //    {
                //        cmbBatch.SelectedValue = objInvoiceBatch.ToString();
                //    }
                //    object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                //    if (Information.IsNumeric(objInvoiceNO))
                //    {
                //        txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                //    }
                //}

                dtHistoryWaterFee = BLLWATERFEECHARGE.QueryLS(strFilter + " ORDER BY CHARGEWORKERID,CHARGEDATETIME");
                dgHistoryWaterFee.DataSource = dtHistoryWaterFee;
                if (dtHistoryWaterFee.Rows.Count == 0)
                {
                    btCancelCharge.Enabled = false;
                    btInvoiceCancel.Enabled = false;
                    btInvoicePrint.Enabled = false;
                    btReceiptPrint.Enabled = false;
                    btChangeInvoice.Enabled = false;
                    btInvoiceMakeUp.Enabled = false;
                }
                else
                {
                    btCancelCharge.Enabled = true;
                    btInvoiceCancel.Enabled = true;
                    btInvoicePrint.Enabled = true;
                    btReceiptPrint.Enabled = true;
                    btChangeInvoice.Enabled = true;

                    DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(2, 0);
                    dgHistoryWaterFee_RowEnter(null, ex);
                }
            }
            catch (Exception ex)
            {
                log.Write("收费冲减与发票补打界面:" + ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
            }
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            if (txtYearAndMonth.Text.Trim() == "")
            {
                DateTime dtNow = mes.GetDatetimeNow();
                txtYearAndMonth.Text = dtNow.ToString("yyyyMM");
                return;
            }
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
            if (txtYearAndMonth.Text.Trim() == "")
            {
                DateTime dtNow = mes.GetDatetimeNow();
                txtYearAndMonth.Text = dtNow.ToString("yyyyMM");
                return;
            }
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

        private void btInvoiceMakeUp_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月结，无法执行此操作!");
                return;
            }
            if (strGroupID != "0001")
            {
                objJZ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZ != null && objJZ != DBNull.Value)
                {
                    if (objJZ.ToString() == "是")
                    {
                        mes.Show("该单据已经结账，无法执行此操作!");
                        return;
                    }
                }
            }
            //补打发票的目的是将打印机没打出来但发票号已经保存到库里的单据再次打印
            #region 发票连打将收费列表内的收费记录打印发票，系统将自动跳过已开票的收费记录

            if (dgHistoryWaterFee.Rows.Count == 0)
            {
                btInvoiceMakeUp.Enabled = false;
                return;
            }
            string strChargeIDS = "";

            //获取连打起始号及终止号
            int intStartRow = 0, intEndRow = dtHistoryWaterFee.Rows.Count;
            if (!Information.IsNumeric(txtStartRow.Text))
            {
                mes.Show("请输入补打起始行号!");
                txtStartRow.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtStartRow.Text) < 1)
                {
                    mes.Show("起始行号不能小于1!");
                    txtStartRow.Focus();
                    return;
                }
                intStartRow = Convert.ToInt32(txtStartRow.Text);
            }
            if (Information.IsNumeric(txtEndRow.Text))
            {
                if (Convert.ToInt32(txtStartRow.Text) > Convert.ToInt32(txtEndRow.Text))
                {
                    mes.Show("起始行号不能大于终止行号!");
                    txtEndRow.Focus();
                    return;
                }
                if (Convert.ToInt32(txtEndRow.Text) < dtHistoryWaterFee.Rows.Count)
                    intEndRow = Convert.ToInt32(txtEndRow.Text);
            }

            if (mes.ShowQ("提示:连续补打发票只能补打已经存在发票号的收费单。\n系统将补打第'" + intStartRow.ToString() + "'行至第'" + intEndRow.ToString() + "'收费单发票,确定继续吗?") != DialogResult.OK)
                return;

            DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Clone();

            for (int i = intStartRow - 1; i < intEndRow; i++)
            {
                object objChargeID = dtHistoryWaterFee.Rows[i]["CHARGEID"];
                if (objChargeID == null || objChargeID == DBNull.Value)
                    continue;

                if (strChargeIDS.Contains(objChargeID.ToString()))
                    continue;

                if (i == intStartRow - 1)
                    strChargeIDS += objChargeID.ToString();
                else
                    strChargeIDS += "," + objChargeID.ToString();

                object objInvoiceState = dtHistoryWaterFee.Rows[i]["INVOICEPRINTSIGN"];
                if (objInvoiceState != null && objInvoiceState != DBNull.Value)
                    if (objInvoiceState.ToString() != "1")
                        continue;

                //DataRow drHistoryWaterFee = dtHistoryWaterFee.Rows[i];
                dtHistoryWaterFeeTemp.Rows.Clear();
                dtHistoryWaterFeeTemp.ImportRow(dtHistoryWaterFee.Rows[i]);
                //DataRow drHistoryWaterFeeTemp = dtHistoryWaterFeeTemp.Rows[0];

                object objTotalNumber = dtHistoryWaterFee.Rows[i]["totalNumber"];
                if (Information.IsNumeric(objTotalNumber))
                    if (Convert.ToInt32(objTotalNumber) == 0)
                        continue;

                #region 发票明细字段
                int intReadMeterRecordYear = 0, intReadMeterRecordMonth = 0, intWaterMeterLastNumber = 0, intWaterMeterEndNumber = 0, intTotalNumber = 0;
                string strwaterUserName = "", strWaterMeterNo = "", strWaterUserAddress = "", strWaterMeterTypeId = "", strWaterMeterTypeName = "";
                decimal decAvePrice = 0, decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decTotalCharge = 0, decExtraChargePrice1 = 0, decExtraChargePrice2 = 0;

                object obj = dtHistoryWaterFeeTemp.Rows[0]["readMeterRecordYear"];
                if (Information.IsNumeric(obj))
                {
                    intReadMeterRecordYear = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["readMeterRecordMonth"];
                if (Information.IsNumeric(obj))
                {
                    intReadMeterRecordMonth = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterLastNumber"];
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterLastNumber = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterEndNumber"];
                if (Information.IsNumeric(obj))
                {
                    intWaterMeterEndNumber = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["TOTALNUMBERCHARGE"];
                if (Information.IsNumeric(obj))
                {
                    intTotalNumber = Convert.ToInt32(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterUserName"];
                if (obj != null && obj != DBNull.Value)
                {
                    strwaterUserName = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterNo"];
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterNo = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterUserAddress"];
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterUserAddress = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterTypeId"];
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeId = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["waterMeterTypeName"];
                if (obj != null && obj != DBNull.Value)
                {
                    strWaterMeterTypeName = obj.ToString();
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["avePrice"];
                if (Information.IsNumeric(obj))
                {
                    decAvePrice = Convert.ToDecimal(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["WATERTOTALCHARGECHARGE"];
                if (Information.IsNumeric(obj))
                {
                    decWaterTotalCharge = Convert.ToDecimal(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"];
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge1 = Convert.ToDecimal(obj);
                    if (decExtraCharge1 == 0)
                        dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = DBNull.Value;
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["extraChargePrice1"];
                if (Information.IsNumeric(obj))
                {
                    decExtraChargePrice1 = Convert.ToDecimal(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"];
                if (Information.IsNumeric(obj))
                {
                    decExtraCharge2 = Convert.ToDecimal(obj);
                    if (decExtraCharge2 == 0)
                        dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = DBNull.Value;
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["extraChargePrice2"];
                if (Information.IsNumeric(obj))
                {
                    decExtraChargePrice2 = Convert.ToDecimal(obj);
                }
                obj = dtHistoryWaterFeeTemp.Rows[0]["TOTALCHARGECHARGE"];
                if (Information.IsNumeric(obj))
                {
                    decTotalCharge = Convert.ToDecimal(obj);
                }

                DataRow[] drCount = dtHistoryWaterFee.Select("CHARGEID='" + objChargeID.ToString() + "'");
                if (drCount.Length > 1)
                {
                    dtHistoryWaterFeeTemp.Rows[0]["waterMeterLastNumber"] = DBNull.Value;
                    dtHistoryWaterFeeTemp.Rows[0]["waterMeterEndNumber"] = DBNull.Value;
                }
                #endregion

                #region 根据此字段判断面积均摊和按月份开票的水表
                object objReadMeterRecordMemo = dtHistoryWaterFeeTemp.Rows[0]["memo"];
                if (objReadMeterRecordMemo != null && objReadMeterRecordMemo != DBNull.Value)
                {
                    if (objReadMeterRecordMemo.ToString().Contains("@"))
                    {
                        string[] strReadMeterRecordMemo = objReadMeterRecordMemo.ToString().Split('@');
                        switch (strReadMeterRecordMemo[0])
                        {
                            case "AYKP"://名称根据月份开票
                                DateTime dtNow = mes.GetDatetimeNow();
                                int intMonthNow = dtNow.Month;
                                if (strReadMeterRecordMemo[1].Contains("|"))
                                {
                                    string[] strUserSet = strReadMeterRecordMemo[1].Split('|');
                                    for (int intAYKP = 0; intAYKP < strUserSet.Length; intAYKP++)
                                    {
                                        if (strUserSet[intAYKP].Contains(":"))
                                        {
                                            string[] strUserAndYF = strUserSet[intAYKP].Split(':');
                                            int intStartMonth = 0, intEndMonth = 0;
                                            if (strUserAndYF[1].Contains("-"))
                                            {
                                                if (Information.IsNumeric(strUserAndYF[1].Split('-')[0]))
                                                    intStartMonth = Convert.ToInt32(strUserAndYF[1].Split('-')[0]);
                                                if (Information.IsNumeric(strUserAndYF[1].Split('-')[1]))
                                                    intEndMonth = Convert.ToInt32(strUserAndYF[1].Split('-')[1]);
                                                if (intMonthNow >= intStartMonth && intMonthNow <= intEndMonth)
                                                {
                                                    strwaterUserName = strUserAndYF[0];
                                                    dtHistoryWaterFeeTemp.Rows[0]["waterUserName"] = strwaterUserName;
                                                    break;
                                                }

                                                //25311277   21-1060-2
                                            }
                                        }
                                    }
                                }
                                break;
                            case "MFYH"://免费不开票的
                                continue;
                            //break;
                            case "MJJT"://按面积均摊开票
                                if (strReadMeterRecordMemo[1].Contains("|"))
                                {
                                    DataTable dtMJJT = dtHistoryWaterFeeTemp.Copy();

                                    string[] strMJJTWaterNameS = strReadMeterRecordMemo[1].Split('|');
                                    for (int intMJFT = 0; intMJFT < strMJJTWaterNameS.Length; intMJFT++)
                                    {
                                        if (strMJJTWaterNameS[intMJFT].Contains(":"))
                                        {
                                            int intMJJTTotalNumber = 0;

                                            string[] strMJJTS = strMJJTWaterNameS[intMJFT].Split(':');
                                            if (Information.IsNumeric(strMJJTS[1]))
                                            {
                                                intMJJTTotalNumber = (int)Math.Ceiling(Convert.ToDecimal(strMJJTS[1]) * intTotalNumber);
                                            }
                                            //DataRow drTemp = dtHistoryWaterFeeTemp.Rows[0];
                                            DataRow dr = dtMJJT.Rows[0];
                                            dr["TOTALNUMBERCHARGE"] = intMJJTTotalNumber;

                                            decWaterTotalCharge = intMJJTTotalNumber * decAvePrice;
                                            dr["WATERTOTALCHARGECHARGE"] = decWaterTotalCharge.ToString("F2");

                                            decExtraCharge1 = intMJJTTotalNumber * decExtraChargePrice1;
                                            if (decExtraCharge1 == 0)
                                                dr["EXTRACHARGECHARGE1"] = DBNull.Value;
                                            else
                                                dr["EXTRACHARGECHARGE1"] = decExtraCharge1.ToString("F2");

                                            decExtraCharge2 = decWaterTotalCharge * decExtraChargePrice2;
                                            if (decExtraCharge2 == 0)
                                                dr["EXTRACHARGECHARGE2"] = DBNull.Value;
                                            else
                                                dr["EXTRACHARGECHARGE2"] = decExtraCharge2.ToString("F2");

                                            decTotalCharge = decWaterTotalCharge + decExtraCharge1 + decExtraCharge2;
                                            if (decTotalCharge == 0)
                                                dr["TOTALCHARGECHARGE"] = DBNull.Value;
                                            else
                                                dr["TOTALCHARGECHARGE"] = decTotalCharge.ToString("F2");

                                            dr["waterUserName"] = strMJJTS[0];

                                            #region 打印发票
                                            DataSet ds = new DataSet();
                                            //DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                                            //DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                                            //dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                                            DataTable dtInvoice = dtMJJT;
                                            dtInvoice.TableName = "普通发票模板";
                                            ds.Tables.Add(dtInvoice.Copy());
                                            FastReport.Report report1 = new FastReport.Report();
                                            try
                                            {
                                                // load the existing report
                                                report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                                                // register the dataset
                                                report1.RegisterData(ds);
                                                report1.GetDataSource("普通发票模板").Enabled = true;
                                                // run the report
                                                //report1.Show();
                                                //report1.Prepare();
                                                report1.PrintSettings.ShowDialog = false;
                                                report1.Print();
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                continue;
                        }
                    }
                }
                #endregion

                #region 发票票额超过9999的
                // /*
                if (decTotalCharge >= 10000)
                {
                    int intPerTotalNumber = 0;

                    //根据各个水价设置最大吨数
                    object objWaterMeterTypeID = dtHistoryWaterFee.Rows[i]["waterMeterTypeId"];
                    if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
                        switch (objWaterMeterTypeID.ToString())
                        {
                            //case "0001":
                            //    intPerTotalNumber = 5555;
                            //    break;
                            //case "0002":
                            //    intPerTotalNumber = 4700;//4760
                            //    break;
                            //case "0003":
                            //    intPerTotalNumber = 2000;
                            //    break;
                            //case "0004":
                            //    intPerTotalNumber = 2300;
                            //    break;
                            //case "0005":
                            //    intPerTotalNumber = 2300;
                            //    break;
                            //case "0007":
                            //    intPerTotalNumber = 2300;
                            //    break;
                            case "0001":
                                intPerTotalNumber = 4545;//2.2元
                                break;
                            case "0002":
                                intPerTotalNumber = 3998;//4760
                                break;
                            case "0003":
                                intPerTotalNumber = 1800;
                                break;
                            case "0004":
                                intPerTotalNumber = 1960;
                                break;
                            case "0005":
                                intPerTotalNumber = 1960;
                                break;
                            case "0007":
                                intPerTotalNumber = 1960;
                                break;
                        }

                    int intPrintCount = (int)Math.Ceiling(intTotalNumber / (decimal)intPerTotalNumber);
                    for (int intInvoiceCount = intPrintCount - 1; intInvoiceCount >= 0; intInvoiceCount--)
                    {
                        decimal decWaterTotalChargeInvoice = 0, decExtraCharge1Invoice = 0, decExtraCharge2Invoice = 0, decTotalChargeInvoice;

                        int intPerTotalNumberInvoice = intTotalNumber - (intPrintCount - 1) * intPerTotalNumber;
                        if (intInvoiceCount == intPrintCount - 1)
                        {
                            dtHistoryWaterFeeTemp.Rows[0]["TOTALNUMBERCHARGE"] = intPerTotalNumberInvoice;

                            decWaterTotalChargeInvoice = intPerTotalNumberInvoice * decAvePrice;
                            dtHistoryWaterFeeTemp.Rows[0]["WATERTOTALCHARGECHARGE"] = decWaterTotalChargeInvoice.ToString("F2");

                            decExtraCharge1Invoice = intPerTotalNumberInvoice * decExtraChargePrice1;
                            if (decExtraCharge1Invoice == 0)
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = DBNull.Value;
                            else
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = decExtraCharge1Invoice.ToString("F2");

                            decExtraCharge2Invoice = decWaterTotalCharge * decExtraChargePrice2;
                            if (decExtraCharge2Invoice == 0)
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = DBNull.Value;
                            else
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = decExtraCharge2Invoice.ToString("F2");

                            decTotalChargeInvoice = decWaterTotalChargeInvoice + decExtraCharge1Invoice + decExtraCharge2Invoice;
                            dtHistoryWaterFeeTemp.Rows[0]["TOTALCHARGECHARGE"] = decTotalChargeInvoice.ToString("F2");
                        }
                        else
                        {
                            dtHistoryWaterFeeTemp.Rows[0]["waterMeterLastNumber"] = DBNull.Value;

                            dtHistoryWaterFeeTemp.Rows[0]["waterMeterEndNumber"] = DBNull.Value;

                            dtHistoryWaterFeeTemp.Rows[0]["TOTALNUMBERCHARGE"] = intPerTotalNumber;

                            decWaterTotalChargeInvoice = intPerTotalNumber * decAvePrice;
                            dtHistoryWaterFeeTemp.Rows[0]["WATERTOTALCHARGECHARGE"] = decWaterTotalChargeInvoice.ToString("F2");

                            decExtraCharge1Invoice = intPerTotalNumber * decExtraChargePrice1;
                            if (decExtraCharge1Invoice == 0)
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = DBNull.Value;
                            else
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE1"] = decExtraCharge1Invoice.ToString("F2");

                            decExtraCharge2Invoice = intPerTotalNumber * decExtraChargePrice2;
                            if (decExtraCharge2Invoice == 0)
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = DBNull.Value;
                            else
                                dtHistoryWaterFeeTemp.Rows[0]["EXTRACHARGECHARGE2"] = decExtraCharge2Invoice.ToString("F2");

                            decTotalChargeInvoice = decWaterTotalChargeInvoice + decExtraCharge1Invoice + decExtraCharge2Invoice;
                            dtHistoryWaterFeeTemp.Rows[0]["TOTALCHARGECHARGE"] = decTotalChargeInvoice.ToString("F2");
                        }
                        try
                        {
                            #region 打印发票
                            DataSet ds = new DataSet();
                            //DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                            //DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                            //dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                            DataTable dtInvoice = dtHistoryWaterFeeTemp;
                            dtInvoice.TableName = "普通发票模板";
                            ds.Tables.Add(dtInvoice.Copy());
                            FastReport.Report report1 = new FastReport.Report();
                            try
                            {
                                // load the existing report
                                report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                                // register the dataset
                                report1.RegisterData(ds);
                                report1.GetDataSource("普通发票模板").Enabled = true;
                                // run the report
                                //report1.Show();
                                //report1.Prepare();
                                report1.PrintSettings.ShowDialog = false;
                                report1.Print();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                // free resources used by report
                                report1.Dispose();
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            mes.Show("打印第'" + (i + 1).ToString() + "'行时更新发票打印标志失败，原因:" + ex.ToString());
                            log.Write(ex.ToString(), MsgType.Error);
                            return;
                        }
                    }
                    continue;
                }
                // * */
                #endregion
                #region 打印发票
                DataSet dss = new DataSet();
                //DataTable dtHistoryWaterFeeTemp = dtHistoryWaterFee.Copy();
                //DataView dvInvoice = dtHistoryWaterFeeTemp.DefaultView;
                //dvInvoice.RowFilter = "readMeterRecordId='" + objReadMeterRecordId.ToString() + "'";
                DataTable dtInvoices = dtHistoryWaterFeeTemp;
                dtInvoices.TableName = "普通发票模板";
                dss.Tables.Add(dtInvoices.Copy());
                FastReport.Report report2 = new FastReport.Report();
                try
                {
                    // load the existing report
                    report2.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                    // register the dataset
                    report2.RegisterData(dss);
                    report2.GetDataSource("普通发票模板").Enabled = true;
                    // run the report
                    //report1.Show();
                    //report1.Prepare();
                    report2.PrintSettings.ShowDialog = false;
                    report2.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // free resources used by report
                    report2.Dispose();
                }
                #endregion
            }


            //获取新的发票号码
            if (cmbBatch.SelectedValue != null && cmbBatch.SelectedValue != DBNull.Value)
            {
                DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLoginID, cmbBatch.SelectedValue.ToString());
                if (dtNewInvoiceNO.Rows.Count > 0)
                {
                    object objInvoiceBatch = dtNewInvoiceNO.Rows[0]["INVOICEBATCHID"];
                    if (objInvoiceBatch != null && objInvoiceBatch != DBNull.Value)
                    {
                        cmbBatch.SelectedValue = objInvoiceBatch.ToString();
                    }
                    object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                    if (Information.IsNumeric(objInvoiceNO))
                    {
                        txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                    }
                }
            }
            #endregion


            #region 之前的连打功能
            /*
            if (dgHistoryWaterFee.Rows.Count == 0)
                {
                    btInvoiceMakeUp.Enabled = false;
                    return;
                }

                //获取连打起始号及终止号
                int intStartRow = 0, intEndRow = dtHistoryWaterFee.Rows.Count;
                if (!Information.IsNumeric(txtStartRow.Text))
                {
                    mes.Show("请输入补打起始行号!");
                    txtStartRow.Focus();
                    return;
                }
                else
                {
                    if (Convert.ToInt32(txtStartRow.Text) < 1)
                    {
                        mes.Show("起始行号不能小于1!");
                        txtStartRow.Focus();
                        return;
                    }
                    intStartRow = Convert.ToInt32(txtStartRow.Text);
                }
                if (Information.IsNumeric(txtEndRow.Text))
                {
                    if (Convert.ToInt32(txtStartRow.Text) > Convert.ToInt32(txtEndRow.Text))
                    {
                        mes.Show("起始行号不能大于终止行号!");
                        txtEndRow.Focus();
                        return;
                    }
                    if (Convert.ToInt32(txtEndRow.Text) < dtHistoryWaterFee.Rows.Count)
                        intEndRow = Convert.ToInt32(txtEndRow.Text);
                }

                txtInvoiceNO.Text = txtInvoiceNO.Text.PadLeft(8, '0');  //8位发票号

                int intEndInoviceNO = Convert.ToInt32(txtInvoiceNO.Text) + intEndRow - intStartRow + 1;  //得到发票终止最大号

                string strStartInvoiceNO = txtInvoiceNO.Text;
                string strEndInvoiceNO = intEndInoviceNO.ToString().PadLeft(8, '0');

                if (mes.ShowQ("提示:连续补打发票只能补打已经存在发票号的收费单。\n系统将补打第'" + intStartRow.ToString() + "'行至第'" + intEndRow.ToString() + "'收费单发票,确定继续吗?") != DialogResult.OK)
                    return;
                for (int i = intStartRow; i < intEndRow; i++)
                {
                    //只有发票号正常的才能补打发票
                    object objInvoiceCancel = dtHistoryWaterFee.Rows[i]["INVOICECANCEL"];
                    if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                        if (objInvoiceCancel.ToString() != "正常")
                        {
                            continue;
                        }

                    object objReadMeterRecordId = dtHistoryWaterFee.Rows[i]["readMeterRecordId"];
                    if (objReadMeterRecordId == null || objReadMeterRecordId == DBNull.Value)
                        continue;
                    try
                    {

                        #region 打印发票
                        DataSet ds = new DataSet();
                        DataTable dtInvoice = dtHistoryWaterFee.Copy();
                        dtInvoice.Select("CHARGEID='" + objReadMeterRecordId.ToString() + "'");
                        dtInvoice.TableName = "普通发票模板";
                        ds.Tables.Add(dtInvoice);
                        FastReport.Report report1 = new FastReport.Report();
                        try
                        {
                            // load the existing report
                            report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                            // register the dataset
                            report1.RegisterData(ds);
                            report1.GetDataSource("普通发票模板").Enabled = true;
                            // run the report
                            //report1.Show();
                            report1.Prepare();
                            report1.PrintSettings.ShowDialog = false;
                            report1.Print();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            // free resources used by report
                            report1.Dispose();
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        mes.Show("打印发票失败!原因:" + ex.Message);
                        log.Write("打印发票失败!原因:" + ex.ToString(), MsgType.Error);
                        return;
                    }
                }
             * */
            #endregion
            #region 发票补打之前的单行功能
            /*
                if (dgHistoryWaterFee.CurrentRow == null)
                    return;
                if (txtChargeID.Text.Trim() == "")
                {
                    mes.Show("未找到要打印发票的收费单ID!请重新查询后再打印!");
                    return;
                }

                //只有发票号正常的才能补打发票
                object objInvoiceCancel = dgHistoryWaterFee.CurrentRow.Cells["INVOICECANCEL"].Value;
                if (objInvoiceCancel != null && objInvoiceCancel != DBNull.Value)
                    if (objInvoiceCancel.ToString() != "正常")
                    {
                        mes.Show("未检测到该收费单的发票号,无法补打发票!");
                        return;
                    }

                string strWaterUserName = "", strWaterUserNO = "";
                object objWaterUserName = dgHistoryWaterFee.CurrentRow.Cells["waterUserName"].Value;
                if (objWaterUserName != null && objWaterUserName != DBNull.Value)
                    strWaterUserName = objWaterUserName.ToString();

                object objWaterUserNO = dgHistoryWaterFee.CurrentRow.Cells["waterUserNO"].Value;
                if (objWaterUserNO != null && objWaterUserNO != DBNull.Value)
                    strWaterUserNO = objWaterUserNO.ToString();

                if (mes.ShowQ("确定要将用户'" + strWaterUserNO + "-" + strWaterUserName + "'的收费单据'" + txtChargeID.Text + "'补打批次为'" + cmbBatch.Text + "'票号为'" + txtInvoiceNO.Text + "'的发票吗?") != DialogResult.OK)
                    return;
                try
                {
                    #region 打印发票
                    DataSet ds = new DataSet();
                    DataTable dtInvoice = dtHistoryWaterFee.Copy();
                    dtInvoice.Select("CHARGEID='" + txtChargeID.Text + "'");
                    dtInvoice.TableName = "普通发票模板";
                    ds.Tables.Add(dtInvoice);
                    FastReport.Report report1 = new FastReport.Report();
                    try
                    {
                        // load the existing report
                        report1.Load(Application.StartupPath + @"\PRINTModel\普通发票模板.frx");
                        // register the dataset
                        report1.RegisterData(ds);
                        report1.GetDataSource("普通发票模板").Enabled = true;
                        // run the report
                        //report1.Show();
                        report1.Prepare();
                        report1.PrintSettings.ShowDialog = false;
                        report1.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // free resources used by report
                        report1.Dispose();
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    mes.Show("打印发票失败!原因:" + ex.Message);
                    log.Write("打印发票失败!原因:" + ex.ToString(), MsgType.Error);
                    return;
                }
             * */
            #endregion
        }

        private void dgHistoryWaterFee_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void txtStartRow_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void 反月结ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;

            if (strGroupID != "0001")
                return;
            object objChargeID = dgHistoryWaterFee.CurrentRow.Cells["CHARGEID"].Value;
            if (objChargeID != null && objChargeID != DBNull.Value)
            {
                if (mes.ShowQ("确定要将单号为'" + objChargeID.ToString() + "'的收费单据反结账吗?") == DialogResult.OK)
                {
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = objChargeID.ToString();
                    //MODELWATERFEECHARGE.SETTLEACCOUNTSSSID = null;
                    MODELWATERFEECHARGE.MONTHCHECKSTATE = "0";
                    if (BLLWATERFEECHARGE.UpdateMonthCheckState(MODELWATERFEECHARGE, " AND CHARGEID='" + objChargeID.ToString() + "'") > 0)
                    {
                        dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value =DBNull.Value;
                        mes.Show("反月结成功!");
                    }
                    else
                    {
                        mes.Show("反月结失败,请重新选择单据后重试!");
                    }
                }
            }
            else
            {
                mes.Show("获取单号失败,请重新选择要操作的单号!");
                return;
            }
        }

        private void 反日结ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;

            if (strGroupID != "0001")
                return;
            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月账，无法执行此操作!");
                return;
            }
            object objChargeID = dgHistoryWaterFee.CurrentRow.Cells["CHARGEID"].Value;
            if (objChargeID != null && objChargeID != DBNull.Value)
            {
                if (mes.ShowQ("确定要将单号为'" + objChargeID.ToString() + "'的收费单据反日结吗?") == DialogResult.OK)
                {
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = objChargeID.ToString();
                    MODELWATERFEECHARGE.DAYCHECKSTATE = "0";
                    if (BLLWATERFEECHARGE.UpdateDayCheckState(MODELWATERFEECHARGE, " AND CHARGEID='" + objChargeID.ToString() + "'") > 0)
                    {
                        dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value = "否";
                        mes.Show("反日结成功!");
                    }
                    else
                    {
                        mes.Show("反日结失败,请重新选择单据后重试!");
                    }
                }
            }
            else
            {
                mes.Show("获取单号失败,请重新选择要操作的单号!");
                return;
            }
        }

        private void dgHistoryWaterFee_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (strGroupID == "0001")
                {
                    dgHistoryWaterFee.CurrentCell = dgHistoryWaterFee.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
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

        private void txtYearAndMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                txtYearAndMonth.Clear();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (dgHistoryWaterFee.CurrentRow == null)
                return;
            object objJZ = dgHistoryWaterFee.CurrentRow.Cells["SETTLEACCOUNTSSSID"].Value;
            if (objJZ != null && objJZ != DBNull.Value && objJZ.ToString() != "")
            {
                mes.Show("该单据已月结，无法执行此操作!");
                return;
            }
            if (strGroupID != "0001")
            {
                objJZ = dgHistoryWaterFee.CurrentRow.Cells["DAYCHECKSTATES"].Value;
                if (objJZ != null && objJZ != DBNull.Value)
                {
                    if (objJZ.ToString() == "是")
                    {
                        mes.Show("该单据已经结账，无法执行此操作!");
                        return;
                    }
                }
            }
            object objChargeID = dgHistoryWaterFee.CurrentRow.Cells["CHARGEID"].Value;
            if (objChargeID != null && objChargeID != DBNull.Value)
            {
                object obj = dgHistoryWaterFee.CurrentRow.Cells["RECEIPTNO"].Value;
                if (objChargeID != null && objChargeID != DBNull.Value)
                {
                    try
                    {
                        if (mes.ShowQ("确定要作废票号为'"+obj.ToString()+"'的收据号吗?") != DialogResult.OK)
                            return;
                        string strSQL = "UPDATE WATERFEECHARGE SET RECEIPTNO=NULL,RECEIPTPRINTCOUNT=RECEIPTPRINTCOUNT-1 WHERE CHARGEID='" + objChargeID.ToString() + "'";
                        if (BLLreadMeterRecord.Excute(strSQL)>0)
                        {
                            dgHistoryWaterFee.CurrentRow.Cells["RECEIPTNO"].Value = null;
                            mes.Show("收据作废成功!");
                            return;
                        }
                        else
                        {
                            mes.Show("收据作废失败,请查询后重新作废!");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show("收据作废失败,原因:"+ex.Message);
                        log.Write(ex.ToString(),MsgType.Error);
                        return;
                    }
                }
                else
                {
                    mes.Show("未找到该单据的收据信息,请查询后重试!");
                    return;
                }
            }
            else
            {
                mes.Show("获取收费单号失败,请查询后重试!");
                return;
            }
        }

        /// <summary>
        /// 获取当前鼠标位置处的节点
        /// </summary>
        /// <param name="onlySuite">只在节点是用例集节点时返回（包括根节点）</param>
        /// <returns></returns>
        public static TreeNode GetMousePositionNode(TreeView tv)
        {
            Point point = tv.PointToClient(Control.MousePosition);
            TreeNode node = tv.GetNodeAt(point);

            return node;
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
            contextMenuStrip2.Show(btSetMonth, 0, btSetMonth.Width + 1);
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            if (cmbChargeTypeNew.SelectedValue == null || cmbChargeTypeNew.SelectedValue == DBNull.Value)
            {
                mes.Show("新的收款方式不能为空!");
                return;
            }
            if (dgHistoryWaterFee.CurrentRow == null)
                return;

            string strID = cmbChargeTypeNew.SelectedValue.ToString();
            if (strID == "2" || strID == "3")
            {
                if (txtJYLSH.Text.Trim() == "")
                {
                    mes.Show("请输入交易凭证号!");
                    return;
                }
            }
            try
            {
                object objChargeID = dgHistoryWaterFee.CurrentRow.Cells["CHARGEID"].Value;
                if (objChargeID != null && objChargeID != DBNull.Value)
                {
                    MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                    MODELWATERFEECHARGE.CHARGEID = objChargeID.ToString();
                    MODELWATERFEECHARGE.CHARGETYPEID = strID;
                    if (strID == "2" || strID == "3")
                        MODELWATERFEECHARGE.POSRUNNINGNO = txtJYLSH.Text;

                    if (BLLWATERFEECHARGE.UpdateChargeType(MODELWATERFEECHARGE))
                    {
                        dgHistoryWaterFee.CurrentRow.Cells["CHARGETYPEID"].Value = MODELWATERFEECHARGE.CHARGETYPEID;
                        dgHistoryWaterFee.CurrentRow.Cells["CHARGETYPENAME"].Value = cmbChargeTypeNew.Text;
                        dgHistoryWaterFee.CurrentRow.Cells["POSRUNNINGNO"].Value = MODELWATERFEECHARGE.POSRUNNINGNO;
                        mes.Show("修改成功!");
                    }
                    else
                    {
                        mes.Show("修改失败!");
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show("修改收款方式失败,原因:" + ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
        }
    }
}
