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
    public partial class frmWaterMeterReadInitial : DockContentEx
    {
        public frmWaterMeterReadInitial()
        {
            InitializeComponent();
        }
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();

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
        private string strLoginID = "";

        private void frmWaterMeterReadInitial_Load(object sender, EventArgs e)
        {
            //this.labProgress.Parent = this.prb;
            CheckForIllegalCrossThreadCalls = false;
            dgList.AutoGenerateColumns = false;

            DateTime dtNow = mes.GetDatetimeNow();
            txtYearAndMonth.Text = dtNow.ToString("yyyyMM");
            //txtYear.Text = dtNow.Year.ToString();
            //txtMonth.Text = dtNow.Month.ToString();

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();

            BindWaterUserType(cmbWaterUserTypeSearch);
            BindWaterMeterType(cmbWaterMeterType,"0");

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
            //BindCharger(cmbChargerS, "0");

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
            if (strType == "0")
                dt = BLLBASE_COMMUNITY.Query("");
            else
                dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000'");
            cmb.DataSource = dt;
            cmb.DisplayMember = "COMMUNITYNAME";
            cmb.ValueMember = "COMMUNITYID";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType(ComboBox cmb, string strType)
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "全部";
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterMeterTypeValue";
            cmb.ValueMember = "waterMeterTypeId";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
        }
        private void BindWaterUserType(ComboBox cmb)
        {
            DataTable dt = BLLwaterUserType.Query("");
            DataRow dr = dt.NewRow();
            dr["waterUserTypeName"] = "全部";
            dr["waterUserTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "waterUserTypeName";
            cmb.ValueMember = "waterUserTypeId";
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
                    strID = "METERREADER|无关ID| AND meterReaderID='" + objID.ToString() + "'";
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
        /// 存储所有需要的用户及水表
        /// </summary>
        DataTable dtAllList = new DataTable();

        private void btInitial_Click(object sender, EventArgs e)
        {
            if (mes.ShowQ("确定要执行初始化操作吗?") != DialogResult.OK)
                return;
            trMeterReading.Enabled = false;
            panel1.Enabled = false;

            bgWork.RunWorkerAsync();
            //labProgress.Text = "进度:0/0";
            //    btInitial.Enabled = false;
            //if (dtAllList.Rows.Count == 0)
            //{
            //    return;
            //}
            //int intAllCount = dtAllList.Rows.Count;
            //prb.Minimum = 1;
            //prb.Maximum = intAllCount;
            //prb.Value = 1;

            //for (int i = 0; i < intAllCount; i++)
            //{
            //    #region 写入MODEL
            //    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

            //    object objWaterMeterID = dtAllList.Rows[i]["waterMeterId"];
            //    if (objWaterMeterID != null && objWaterMeterID != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterId = objWaterMeterID.ToString();

            //    object objWaterMeterRead = dtAllList.Rows[i]["waterMeterNo"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterNo = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterStartNumber"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterLastNumber = Convert.ToInt32(objWaterMeterRead);

            //    //从历史记录表里获取最后一次水表的读数
            //    string strLastNumberFilter = " AND waterMeterId='" + objWaterMeterID.ToString() + "' ORDER BY readMeterRecordDate DESC";
            //    object objLastNumber = BLLreadMeterRecord.GetLastNumber(strLastNumberFilter);
            //    if (objLastNumber != null && objLastNumber != DBNull.Value)
            //    {
            //        MODELreadMeterRecord.waterMeterLastNumber =  Convert.ToInt32(objLastNumber);
            //    }

            //        MODELreadMeterRecord.waterMeterEndNumber = 0;
            //        MODELreadMeterRecord.totalNumber =0;
            //        MODELreadMeterRecord.waterTotalCharge = 0;
            //        MODELreadMeterRecord.extraChargePrice1 = 0;
            //        MODELreadMeterRecord.extraChargePrice2 = 0;
            //        MODELreadMeterRecord.extraChargePrice3 = 0;
            //        MODELreadMeterRecord.extraChargePrice4 = 0;
            //        MODELreadMeterRecord.extraChargePrice5 = 0;
            //        MODELreadMeterRecord.extraChargePrice6 = 0;
            //        MODELreadMeterRecord.extraChargePrice7 = 0;
            //        MODELreadMeterRecord.extraChargePrice8 = 0;
            //        MODELreadMeterRecord.extraCharge1 = 0;
            //        MODELreadMeterRecord.extraCharge2 = 0;
            //        MODELreadMeterRecord.extraCharge3 = 0;
            //        MODELreadMeterRecord.extraCharge4 = 0;
            //        MODELreadMeterRecord.extraCharge5 = 0;
            //        MODELreadMeterRecord.extraCharge6 = 0;
            //        MODELreadMeterRecord.extraCharge7 = 0;
            //        MODELreadMeterRecord.extraCharge8 = 0;
            //        MODELreadMeterRecord.extraTotalCharge = 0;
            //        MODELreadMeterRecord.totalCharge = 0;

            //    objWaterMeterRead = dtAllList.Rows[i]["WATERFIXVALUE"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.WATERFIXVALUE = Convert.ToInt32(objWaterMeterRead);
            //    else
            //        MODELreadMeterRecord.WATERFIXVALUE = 0;

            //    string strWaterMeterYear = txtYear.Text;
            //    MODELreadMeterRecord.readMeterRecordYear = int.Parse(strWaterMeterYear);

            //    string strWaterMeterMonth = txtMonth.Text;
            //    MODELreadMeterRecord.readMeterRecordMonth = int.Parse(strWaterMeterMonth);

            //    MODELreadMeterRecord.readMeterRecordDate = mes.GetDatetimeNow();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterPositionName"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterPositionName = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterSizeId"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterSizeId = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterSizeValue"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterSizeValue = objWaterMeterRead.ToString();

            //   object objWaterMeterTypeID = dtAllList.Rows[i]["waterMeterTypeId"];
            //   if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
            //   {
            //       object objWaterMeterRecordTrapePrice = BLLWATERMETERTYPE.GetTrapePrice(" AND waterMeterTypeId='" + objWaterMeterTypeID.ToString() + "'");
            //       if (objWaterMeterRecordTrapePrice != null && objWaterMeterRecordTrapePrice != DBNull.Value)
            //       {
            //           MODELreadMeterRecord.trapezoidPrice = objWaterMeterRecordTrapePrice.ToString();
            //           MODELreadMeterRecord.waterMeterTypeId = objWaterMeterTypeID.ToString();
            //       }
            //   }

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterTypeValue"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterTypeName = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterProduct"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterProduct = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterSerialNumber"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterSerialNumber = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterMode"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterMode = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterMagnification"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterMagnification = Convert.ToInt16(objWaterMeterRead);

            //    objWaterMeterRead = dtAllList.Rows[i]["waterMeterMaxRange"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterMeterMaxRange = Convert.ToInt32(objWaterMeterRead);

            //    objWaterMeterRead = dtAllList.Rows[i]["areaId"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.areaId = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["areaName"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.areaName = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["loginId"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.loginId = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["USERNAME"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.USERNAME = objWaterMeterRead.ToString();

            //    MODELreadMeterRecord.checkState ="0";

            //    MODELreadMeterRecord.chargeState ="0";


            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserId"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserId = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserNO"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserNO = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserName"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserName = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterPhone"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterPhone = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserAddress"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserAddress = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserPeopleCount"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserPeopleCount = Convert.ToInt16(objWaterMeterRead);

            //    objWaterMeterRead = dtAllList.Rows[i]["meterReadingPageNo"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.meterReadingPageNo = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["meterReadingID"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.meterReadingID = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["meterReadingNO"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.meterReadingNO = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserTypeId"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserTypeId = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserTypeName"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserTypeName = objWaterMeterRead.ToString();

            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserCreateDate"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserCreateDate = Convert.ToDateTime(objWaterMeterRead);

            //    objWaterMeterRead = dtAllList.Rows[i]["agentsign"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.agentsign = objWaterMeterRead.ToString();
            //    else
            //        MODELreadMeterRecord.agentsign = "2";

            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserHouseType"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserHouseType = objWaterMeterRead.ToString();
            //        else 
            //            MODELreadMeterRecord.waterUserHouseType = "2";

            //    objWaterMeterRead = dtAllList.Rows[i]["waterUserState"];
            //    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
            //        MODELreadMeterRecord.waterUserState = objWaterMeterRead.ToString();
            //        else
            //            MODELreadMeterRecord.waterUserState = "2";
            //    #endregion
            //    MODELreadMeterRecord.readMeterRecordId = GETTABLEID.GetTableID(strLoginID, "READMETERRECORD");

            //    objWaterMeterRead = dtAllList.Rows[i]["ordernumber"];
            //    if (Information.IsNumeric(objWaterMeterRead))
            //        MODELreadMeterRecord.ordernumber = Convert.ToInt32(objWaterMeterRead);


            //        if (BLLreadMeterRecord.Insert(MODELreadMeterRecord))
            //        {
            //            prb.Value =i+1;
            //            labProgress.Text = "进度:" + (i + 1) + "/" + intAllCount;
            //        }
            //        else
            //        {
            //            mes.Show("第 " + (i + 1).ToString() + " 行抄表记录保存失败!");
            //            return;
            //        }
            //}
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
        
        private void btSearch_Click(object sender, EventArgs e)
        {
            TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
            trMeterReading_AfterSelect(null, ex);
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
                //mes.Show(ex.Message);
                log.Write("抄表初始界面:" + ex.ToString(), MsgType.Error);
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
                log.Write("抄表初始界面:" + ex.ToString(), MsgType.Error);
            }
        }
        private void LoadData(string[] strNodeID)
        {
            txtYearAndMonthSave.Text = txtYearAndMonth.Text;

            string strYear = txtYearAndMonth.Text.Substring(0, 4), strMonth = txtYearAndMonth.Text.Substring(4, 2);
            DateTime dtSearchDate = new DateTime(Convert.ToInt16(strYear),Convert.ToInt16(strMonth),1);
            //查询条件
            //string strFilter = strSeniorFilterHidden + " AND waterMeterId NOT IN (SELECT waterMeterId FROM readMeterRecord WHERE readMeterRecordYear=" + strYear + " AND readMeterRecordMonth=" + strMonth + ") ";
            string strFilter = strSeniorFilterHidden + " AND  waterMeterState<>'2' AND waterMeterId NOT IN (SELECT waterMeterId FROM readMeterRecord WHERE DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtSearchDate + "')=0) ";//20160113启用新的抄表月份

            if (txtWaterUserNOSearch.Text.Trim() != "")
                if (txtWaterUserNOSearch.Text.Length > 5)
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim() + "'";
                else
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.Trim().PadLeft(5, '0') + "'";

            if (cmbWaterUserTypeSearch.SelectedValue != DBNull.Value && cmbWaterUserTypeSearch.SelectedValue != null)
                strFilter += " AND waterUserTypeId='" + cmbWaterUserTypeSearch.SelectedValue.ToString() + "'";

            if (cmbWaterMeterType.SelectedValue != DBNull.Value && cmbWaterMeterType.SelectedValue != null)
                strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";

            if (cmbWaterMeterState.SelectedIndex>0)
                strFilter += " AND waterMeterState='" + cmbWaterMeterState.SelectedIndex + "'";

            //if (txtWaterMeterNO.Text.Trim() != "")
            //    strFilter += " AND waterMeterNo='" + txtWaterMeterNO.Text.Trim().PadLeft(10, '0') + "'";
            if (cmbAreaNOS.SelectedIndex > 0)
                strFilter += " AND areaNO='" + cmbAreaNOS.Text + "'";
            if (cmbPianNOS.SelectedIndex > 0)
                strFilter += " AND pianNO='" + cmbPianNOS.Text + "'";
            if (cmbDuanNOS.SelectedIndex > 0)
                strFilter += " AND duanNO='" + cmbDuanNOS.Text + "'";

            if (cmbCommunityS.SelectedIndex > 0)
                strFilter += " AND communityID='" + cmbCommunityS.SelectedValue.ToString() + "'";

            if (cmbMeterReaderS.SelectedValue != null && cmbMeterReaderS.SelectedValue != DBNull.Value)
                strFilter += " AND meterReaderID='" + cmbMeterReaderS.SelectedValue.ToString() + "'";

            //获取用户数量
            DataTable dtWaterUserDistinct = BLLwaterUser.QueryInitialWaterUserID(strFilter + strNodeID[2]);

            strFilter += strNodeID[2] + " ORDER BY areaNO,pianNO,duanNO,ordernumber";

            //检索本月度未在抄表记录里初始化的用户
            //dtAllList = BLLwaterUser.QueryInitialWaterUser("AND waterUserState='1' AND waterUserId NOT IN (SELECT waterUserId FROM readMeterRecord WHERE readMeterRecordYear=" + strYear + " AND readMeterRecordMonth=" + strMonth + ")  AND loginId='" + textBox1.Text + "'");
            dtAllList = BLLwaterUser.QueryInitialWaterUser(strFilter);
            //dgList.DataSource = dtAllList;

            ////存储有表用户、水表数及无表户数。
            //int intAllList_WaterMeterCount = 0, intAllList_WaterUser_WaterMeterUseCount = 0, intAllList_WaterUser_WaterMeterNoneCount = 0;


            DataTable dtAllListTemp = dtAllList.Copy();
            //显示所有需要初始化的用户
            DataView dvAllListTemp_AllMeterUser = dtAllListTemp.DefaultView;
            //DataTable dtWaterUserDistinct = dvAllListTemp_AllMeterUser.ToTable(true, "waterUserId");
            labCount.Text = "用户数量:" + dtWaterUserDistinct.Rows.Count+";水表数量:"+dtAllList.Rows.Count ;

            if (dtAllList.Rows.Count == 0)
            {
                dgList.DataSource = null;
                btInitial.Enabled = false;
            }
            else
            {
                //DataTable dtClone = dtAllList.Clone();
                //DataRow drLast = dtClone.NewRow();
                //drLast["waterUserNO"] = "合计:";
                //drLast["waterUserName"] = dtWaterUserDistinct.Rows.Count;
                //drLast["waterMeterNo"] = dtAllList.Rows.Count;
                //dtClone.Rows.Add(drLast);
                dgList.DataSource = dtAllList;
                //ucPageSetUp1.InitialUC(this.dgList, dtAllList, null);
                btInitial.Enabled = true;
            }

            prb.Minimum = 0;
            prb.Value = 0;
            labProgress.Text = "进度:0/0";
            

            // DataTable dtAllListTemp = dtAllList.Copy();

            // //显示所有需要初始化的用户
            //DataView dvAllListTemp_AllMeterUser = dtAllListTemp.DefaultView;
            //dgList.DataSource = dvAllListTemp_AllMeterUser.ToTable(true, "waterUserId", "waterUserNO", "waterUserName", "waterUserAddress", "waterUserStateS");
            // for (int i = 0; i < dgList.Rows.Count; i++)
            // {
            //     object objWaterUserID = dgList.Rows[i].Cells["waterUserId"].Value;
            //     if (objWaterUserID != null && objWaterUserID != DBNull.Value)
            //     {
            //         DataTable dtWaterUser_MeterCount = dtAllList.Copy();
            //         DataView dvWaterUser_MeterCount = dtWaterUser_MeterCount.DefaultView;
            //         dvWaterUser_MeterCount.RowFilter = " waterUserId='" + objWaterUserID.ToString() + "' AND waterUserState='1'";
            //         dgList.Rows[i].Cells["WATERMETERCOUNT"].Value = dvWaterUser_MeterCount.Count;
            //     }
            // }

            // //获取有表用户的水表数
            // DataView dvAllListTemp_WaterMeterCount = dtAllListTemp.DefaultView;
            // dvAllListTemp_WaterMeterCount.RowFilter = "waterUserState='1'";
            // intAllList_WaterMeterCount = dvAllListTemp_WaterMeterCount.Count;

            // //获取有水表用户表
            // DataTable dtAllList_WaterUser_WaterMeterUse_Temp = dvAllListTemp_WaterMeterCount.ToTable(true, "waterUserId");
            // intAllList_WaterUser_WaterMeterUseCount = dtAllList_WaterUser_WaterMeterUse_Temp.Rows.Count;

            // DataTable dtAllListTemp_WaterUser_WaterMeterNone = dtAllList.Copy();
            // //获取无表用户数
            // DataView dvAllListTemp_WaterUser_WaterMeterNone = dtAllListTemp_WaterUser_WaterMeterNone.DefaultView;
            //dvAllListTemp_WaterUser_WaterMeterNone.RowFilter = "waterUserState='2'";
            //intAllList_WaterUser_WaterMeterNoneCount = dvAllListTemp_WaterUser_WaterMeterNone.Count;

            // //显示本次检索到需要初始化的用户及水表数量
            // labTip.Text = "用户数:" + (intAllList_WaterUser_WaterMeterUseCount + intAllList_WaterUser_WaterMeterNoneCount) + "户(有表" + intAllList_WaterUser_WaterMeterUseCount + "户无表" + intAllList_WaterUser_WaterMeterNoneCount + "户)，水表数:" + intAllList_WaterMeterCount + "只";

            // //查询所有的抄表员
            // DataTable dtWaterMeterReader=BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
            // for (int i = 0; i < dtWaterMeterReader.Rows.Count; i++)
            // {
            //     //抄表员的ID和姓名
            //     string strLoginID = "", strUserName = "";

            //     object obj = dtWaterMeterReader.Rows[i]["LOGINID"];
            //     if (obj != null && obj != DBNull.Value)
            //     {
            //         strLoginID = obj.ToString();
            //         object objName = dtWaterMeterReader.Rows[i]["USERNAME"];
            //         if (objName != null && objName != DBNull.Value)
            //         {
            //             strUserName = objName.ToString();
            //         }

            //         DataTable dtAllListTemp_WaterMeterCount_ByReader = dtAllList.Copy();
            //         //获取有表用户的水表数
            //         DataView dvAllListTemp_WaterMeterCount_ByReader = dtAllListTemp_WaterMeterCount_ByReader.DefaultView;
            //         dvAllListTemp_WaterMeterCount_ByReader.RowFilter = "waterUserState='1' AND LOGINID='"+strLoginID+"'";

            //         //获取有水表用户表
            //         DataTable dtAllList_WaterUser_WaterMeterUse_ByReader_Temp = dvAllListTemp_WaterMeterCount_ByReader.ToTable(true, "waterUserId");

            //         DataTable dtAllListTemp_WaterUser_WaterMeterNone_ByReader = dtAllList.Copy();
            //         //获取无表用户数
            //         DataView dvAllListTemp_WaterUser_WaterMeterNone_ByReader = dtAllListTemp_WaterUser_WaterMeterNone_ByReader.DefaultView;
            //         dvAllListTemp_WaterUser_WaterMeterNone_ByReader.RowFilter = "waterUserState='2' AND LOGINID='" + strLoginID + "'";

            //         string strItemName = "抄表员:" + strUserName + "—" + (dtAllList_WaterUser_WaterMeterUse_ByReader_Temp.Rows.Count + dvAllListTemp_WaterUser_WaterMeterNone_ByReader.Count) + "户(有表" + dtAllList_WaterUser_WaterMeterUse_ByReader_Temp.Rows.Count + "户无表" + dvAllListTemp_WaterUser_WaterMeterNone_ByReader.Count + "户),水表" + dvAllListTemp_WaterMeterCount_ByReader.Count + "只";
            //         ListItem lst = new ListItem(strItemName, strLoginID);
            //         lsbMeterReader.Items.Add(lst);
            //     }
            // }
        }

        private void cmbWaterUserTypeSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (trMeterReading.SelectedNode == null)
            //    return;
            //TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode,TreeViewAction.ByMouse);
            //trMeterReading_AfterSelect(null,ex);
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                labProgress.Text = "进度:0/0";
                btInitial.Enabled = false;
                if (dtAllList.Rows.Count == 0)
                {
                    return;
                }
                DateTime dtNow=mes.GetDatetimeNow();

                int intAllCount = dtAllList.Rows.Count;
                prb.Minimum = 0;
                prb.Maximum = intAllCount;
                prb.Value = 0;

                for (int i = 0; i < intAllCount; i++)
                {
                    if (bgWork.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    #region 写入MODEL
                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                    object objWaterMeterID = dtAllList.Rows[i]["waterMeterId"];
                    if (objWaterMeterID != null && objWaterMeterID != DBNull.Value)
                        MODELreadMeterRecord.waterMeterId = objWaterMeterID.ToString();

                    object objWaterMeterRead = dtAllList.Rows[i]["waterMeterNo"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterNo = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterStartNumber"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterLastNumber = Convert.ToInt32(objWaterMeterRead);

                    string strWaterMeterYear = txtYearAndMonthSave.Text.Substring(0, 4);
                    MODELreadMeterRecord.readMeterRecordYear = int.Parse(strWaterMeterYear);

                    string strWaterMeterMonth = txtYearAndMonthSave.Text.Substring(4, 2);
                    MODELreadMeterRecord.readMeterRecordMonth = int.Parse(strWaterMeterMonth);

                    MODELreadMeterRecord.readMeterRecordYearAndMonth = new DateTime(int.Parse(strWaterMeterYear), int.Parse(strWaterMeterMonth), 1); //20160113启用新的抄表月份

                    MODELreadMeterRecord.NotReadMonthCount = 1;//未抄表月数

                    //从历史记录表里获取最后一次水表的读数，如果为变更记录readMeterRecordDate为空，取不到上次抄表日期字段数据
                    string strLastNumberFilter = " AND waterMeterId='" + objWaterMeterID.ToString() + "' ORDER BY checkDateTime DESC,readMeterRecordDate DESC";//已经审核完的才能作为下一个月水表的初始值
                    //string strLastNumberFilter = " AND waterMeterId='" + objWaterMeterID.ToString() + "' ORDER BY readMeterRecordDate DESC";//已经审核完的才能作为下一个月水表的初始值
                    DataTable dtLastNumber = BLLreadMeterRecord.GetLastNumber(strLastNumberFilter);
                    if (dtLastNumber.Rows.Count > 0)
                    {
                        string strRecordLastYearAndMonth = "";

                        object objLastNumber = dtLastNumber.Rows[0]["waterMeterEndNumber"];
                        if (objLastNumber != null && objLastNumber != DBNull.Value)
                        {
                            MODELreadMeterRecord.waterMeterLastNumber = Convert.ToInt32(objLastNumber);
                        }

                        object objectRecordIDLast = dtLastNumber.Rows[0]["readMeterRecordId"];
                        if (objectRecordIDLast != null && objectRecordIDLast != DBNull.Value)
                        {
                            MODELreadMeterRecord.readMeterRecordIdLast = objectRecordIDLast.ToString();
                        }

                        //object objectRecordLastYearAndMonth = dtLastNumber.Rows[0]["CHARGEDATETIME"];
                        //将上月读数日期修改为抄表日期
                        object objectRecordLastYearAndMonth = dtLastNumber.Rows[0]["readMeterRecordDate"];
                        if (Information.IsDate(objectRecordLastYearAndMonth))
                        {
                            strRecordLastYearAndMonth = Convert.ToDateTime(objectRecordLastYearAndMonth).ToString("yyyyMM");
                            MODELreadMeterRecord.lastNumberYearMonth = strRecordLastYearAndMonth;
                            MODELreadMeterRecord.NotReadMonthCount = MODELreadMeterRecord.readMeterRecordYearAndMonth.Year * 12 + MODELreadMeterRecord.readMeterRecordYearAndMonth.Month -
                                Convert.ToDateTime(objectRecordLastYearAndMonth).Year * 12 - Convert.ToDateTime(objectRecordLastYearAndMonth).Month;
                        }
                    }

                    //获取最后一次抄表日期
                    if (MODELreadMeterRecord.lastNumberYearMonth == ""||MODELreadMeterRecord.lastNumberYearMonth ==null)
                    {
                        string strGetLastNumberYearAndMonth = "SELECT TOP 1 readMeterRecordDate FROM readMeterRecord WHERE waterMeterId='"+
                           MODELreadMeterRecord.waterMeterNo + "' AND totalNumber>0 AND checkState='1' ORDER BY readMeterRecordDate DESC";
                        DataTable dtLastNumberYearAndMonth = BLLreadMeterRecord.QueryBySQL(strGetLastNumberYearAndMonth);
                        if (dtLastNumberYearAndMonth.Rows.Count > 0)
                        {
                            object objLastNumberYearAndMonth = dtLastNumberYearAndMonth.Rows[0]["readMeterRecordDate"];
                            if (Information.IsDate(objLastNumberYearAndMonth))
                            {
                                MODELreadMeterRecord.lastNumberYearMonth = Convert.ToDateTime(objLastNumberYearAndMonth).ToString("yyyyMM");
                                MODELreadMeterRecord.NotReadMonthCount = MODELreadMeterRecord.readMeterRecordYearAndMonth.Year * 12 + MODELreadMeterRecord.readMeterRecordYearAndMonth.Month -
                                    Convert.ToDateTime(objLastNumberYearAndMonth).Year * 12 - Convert.ToDateTime(objLastNumberYearAndMonth).Month;
                            }
                        }
                    }
                    //如果没有最后一次抄表日期，默认初始化日期作为最后一次抄表日期
                    if (MODELreadMeterRecord.lastNumberYearMonth == "" || MODELreadMeterRecord.lastNumberYearMonth == null)
                    {
                        string strSQLGetInitialMonth = "SELECT initialReadMeterMesDateTime FROM readMeterRecord WHERE waterMeterId='" + 
                            MODELreadMeterRecord.waterMeterNo + "' AND initialReadMeterMesDateTime IS NOT NULL ORDER BY initialReadMeterMesDateTime";
                        DataTable dtInitialMonth = BLLreadMeterRecord.QueryBySQL(strSQLGetInitialMonth);
                        if (dtInitialMonth.Rows.Count > 0)
                        {
                            object objInitialMonth = dtInitialMonth.Rows[0]["initialReadMeterMesDateTime"];
                            if (Information.IsDate(objInitialMonth))
                            {
                                DateTime dtLastYearAndMonth = Convert.ToDateTime(objInitialMonth).AddMonths(-1);
                                MODELreadMeterRecord.lastNumberYearMonth = dtLastYearAndMonth.ToString("yyyyMM");
                                MODELreadMeterRecord.NotReadMonthCount = MODELreadMeterRecord.readMeterRecordYearAndMonth.Year * 12 + MODELreadMeterRecord.readMeterRecordYearAndMonth.Month -
                                    Convert.ToDateTime(objInitialMonth).Year * 12 - Convert.ToDateTime(objInitialMonth).Month;
                            }
                        }
                    }

                    MODELreadMeterRecord.waterMeterEndNumber = 0;
                    MODELreadMeterRecord.totalNumber = 0;
                    MODELreadMeterRecord.waterTotalCharge = 0;
                    MODELreadMeterRecord.extraChargePrice1 = 0;
                    MODELreadMeterRecord.extraChargePrice2 = 0;
                    MODELreadMeterRecord.extraChargePrice3 = 0;
                    MODELreadMeterRecord.extraChargePrice4 = 0;
                    MODELreadMeterRecord.extraChargePrice5 = 0;
                    MODELreadMeterRecord.extraChargePrice6 = 0;
                    MODELreadMeterRecord.extraChargePrice7 = 0;
                    MODELreadMeterRecord.extraChargePrice8 = 0;
                    MODELreadMeterRecord.extraCharge1 = 0;
                    MODELreadMeterRecord.extraCharge2 = 0;
                    MODELreadMeterRecord.extraCharge3 = 0;
                    MODELreadMeterRecord.extraCharge4 = 0;
                    MODELreadMeterRecord.extraCharge5 = 0;
                    MODELreadMeterRecord.extraCharge6 = 0;
                    MODELreadMeterRecord.extraCharge7 = 0;
                    MODELreadMeterRecord.extraCharge8 = 0;
                    MODELreadMeterRecord.extraTotalCharge = 0;
                    MODELreadMeterRecord.totalCharge = 0;

                    objWaterMeterRead = dtAllList.Rows[i]["WATERFIXVALUE"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.WATERFIXVALUE = Convert.ToInt32(objWaterMeterRead);
                    else
                        MODELreadMeterRecord.WATERFIXVALUE = 0;

                    objWaterMeterRead = dtAllList.Rows[i]["IsReverse"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.IsReverse = objWaterMeterRead.ToString();
                    else
                        MODELreadMeterRecord.IsReverse = "0";

                    MODELreadMeterRecord.initialReadMeterMesDateTime = dtNow;

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterPositionName"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterPositionName = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterSizeId"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterSizeId = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterSizeValue"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterSizeValue = objWaterMeterRead.ToString();

                    #region 初始化用水性质，如果设置了自动变更用水性质，到达指定月份后，则启用新的用水性质
                    string strWaterMeterTypeID = "";

                    object objWaterMeterTypeID = dtAllList.Rows[i]["waterMeterTypeId"];
                    if (objWaterMeterTypeID != null && objWaterMeterTypeID != DBNull.Value)
                        MODELreadMeterRecord.waterMeterTypeId = objWaterMeterTypeID.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterTypeValue"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterTypeName = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["trapezoidPrice"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.trapezoidPrice = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["extraCharge"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.extraCharge = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterTypeClassID"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterTypeClassID = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterTypeClassName"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterTypeClassName = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["ISUSECHANGE"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    {
                        if (objWaterMeterRead.ToString() == "1")
                        {
                            objWaterMeterRead = dtAllList.Rows[i]["CHANGEMONTH"];
                            if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                            {
                                if (Convert.ToInt32(txtYearAndMonthSave.Text) >= Convert.ToInt32(objWaterMeterRead))
                                {
                                    object objWaterMeterTypeChange = dtAllList.Rows[i]["waterMeterTypeIdChange"];
                                    if (objWaterMeterTypeChange != null && objWaterMeterTypeChange != DBNull.Value)
                                    {
                                        strWaterMeterTypeID = objWaterMeterTypeChange.ToString();
                                        MODELreadMeterRecord.waterMeterTypeId = strWaterMeterTypeID;
                                        DataTable dtWaterMeterType = BLLWATERMETERTYPE.GetTrapePriceAndExtraCharge(" AND waterMeterTypeId='" + strWaterMeterTypeID + "'");
                                        if (dtWaterMeterType.Rows.Count > 0)
                                        {
                                            object objWaterMeterValue = dtWaterMeterType.Rows[0]["waterMeterTypeValue"];
                                            if (objWaterMeterValue != null && objWaterMeterValue != DBNull.Value)
                                            {
                                                MODELreadMeterRecord.waterMeterTypeName = objWaterMeterValue.ToString();
                                            }

                                            object objWaterMeterRecordTrapePrice = dtWaterMeterType.Rows[0]["trapezoidPrice"];
                                            if (objWaterMeterRecordTrapePrice != null && objWaterMeterRecordTrapePrice != DBNull.Value)
                                            {
                                                MODELreadMeterRecord.trapezoidPrice = objWaterMeterRecordTrapePrice.ToString();
                                                MODELreadMeterRecord.waterMeterTypeId = strWaterMeterTypeID;

                                                object objWaterMeterExtraCharge = dtWaterMeterType.Rows[0]["extraCharge"];
                                                if (objWaterMeterExtraCharge != null && objWaterMeterExtraCharge != DBNull.Value)
                                                {
                                                    MODELreadMeterRecord.extraCharge = objWaterMeterExtraCharge.ToString();
                                                }

                                            }
                                            else
                                            {
                                                mes.Show("请设置用水类别代码为'" + strWaterMeterTypeID + "'的阶梯水价!");
                                                return;
                                            }
                                            objWaterMeterValue = dtWaterMeterType.Rows[0]["WATERMETERTYPECLASSID"];
                                            if (objWaterMeterValue != null && objWaterMeterValue != DBNull.Value)
                                            {
                                                MODELreadMeterRecord.waterMeterTypeClassID = objWaterMeterValue.ToString();
                                            }
                                            objWaterMeterValue = dtWaterMeterType.Rows[0]["WATERMETERTYPECLASSNAME"];
                                            if (objWaterMeterValue != null && objWaterMeterValue != DBNull.Value)
                                            {
                                                MODELreadMeterRecord.waterMeterTypeClassName = objWaterMeterValue.ToString();
                                            }
                                        }
                                        else
                                        {
                                            mes.Show("未找到用水类别代码为'" + strWaterMeterTypeID + "'的水价设置信息!");
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    objWaterMeterRead = dtAllList.Rows[i]["prestore"];
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.WATERUSERQQYE = Convert.ToDecimal(objWaterMeterRead);

                    objWaterMeterRead = dtAllList.Rows[i]["TOTALFEE"];
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.WATERUSERLJQF = Convert.ToDecimal(objWaterMeterRead);

                    MODELreadMeterRecord.WATERUSERJSYE = MODELreadMeterRecord.WATERUSERQQYE - MODELreadMeterRecord.WATERUSERLJQF;

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterProduct"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterProduct = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterSerialNumber"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterSerialNumber = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterMode"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterMode = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterMagnification"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterMagnification = Convert.ToInt16(objWaterMeterRead);

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterMaxRange"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterMaxRange = Convert.ToInt32(objWaterMeterRead);

                    objWaterMeterRead = dtAllList.Rows[i]["areaNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.areaNO = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["pianNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.pianNO = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["meterReaderID"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.meterReaderID = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["meterReaderName"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.meterReaderName = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["chargerID"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.chargerID = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["chargerName"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.chargerName = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["createType"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    {
                        MODELreadMeterRecord.createType = objWaterMeterRead.ToString();
                        if (MODELreadMeterRecord.createType == "无表")
                            MODELreadMeterRecord.waterMeterLastNumber = 0;
                    }

                    MODELreadMeterRecord.checkState = "0";

                    MODELreadMeterRecord.chargeState = "0";


                    objWaterMeterRead = dtAllList.Rows[i]["waterUserId"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserId = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserNO = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserName"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserName = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserNameCode"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserNameCode = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserTelphoneNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserTelphoneNO = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterPhone"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterPhone = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserTelphoneNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserTelphoneNO = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserAddress"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserAddress = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserPeopleCount"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserPeopleCount = Convert.ToInt16(objWaterMeterRead);

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserTypeId"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserTypeId = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserTypeName"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserTypeName = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserCreateDate"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserCreateDate = Convert.ToDateTime(objWaterMeterRead);

                    objWaterMeterRead = dtAllList.Rows[i]["agentsign"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.agentsign = objWaterMeterRead.ToString();
                    else
                        MODELreadMeterRecord.agentsign = "2";

                    objWaterMeterRead = dtAllList.Rows[i]["waterUserHouseType"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserHouseType = objWaterMeterRead.ToString();
                    else
                        MODELreadMeterRecord.waterUserHouseType = "2";

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterStateS"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserState = objWaterMeterRead.ToString();
                    else
                        MODELreadMeterRecord.waterUserState = "0";

                    objWaterMeterRead = dtAllList.Rows[i]["chargeType"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterUserchargeType = objWaterMeterRead.ToString();
                    else
                        MODELreadMeterRecord.waterUserchargeType = "0";

                    objWaterMeterRead = dtAllList.Rows[i]["isSummaryMeter"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.isSummaryMeter = objWaterMeterRead.ToString();
                    else
                        MODELreadMeterRecord.isSummaryMeter = "1";//默认分表

                    objWaterMeterRead = dtAllList.Rows[i]["waterMeterParentId"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.waterMeterParentId = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["areaNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.areaNO = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["pianNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.pianNO = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["duanNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.duanNO = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["communityID"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.communityID = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["COMMUNITYNAME"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.COMMUNITYNAME = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["buildingNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.buildingNO = objWaterMeterRead.ToString();

                    objWaterMeterRead = dtAllList.Rows[i]["unitNO"];
                    if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                        MODELreadMeterRecord.unitNO = objWaterMeterRead.ToString();

                    #endregion
                    MODELreadMeterRecord.readMeterRecordId = GETTABLEID.GetTableID(strLoginID, "READMETERRECORD");

                    objWaterMeterRead = dtAllList.Rows[i]["ordernumber"];
                    if (Information.IsNumeric(objWaterMeterRead))
                        MODELreadMeterRecord.ordernumber = Convert.ToInt32(objWaterMeterRead);

                    //objWaterMeterRead = dtAllList.Rows[i]["memo"];
                    //if (objWaterMeterRead != null && objWaterMeterRead != DBNull.Value)
                    //    MODELreadMeterRecord.MEMO = objWaterMeterRead.ToString();//将特殊的用户（按面积均摊或者按月份确定开票名称）存储到memo字段里。备用

                    MODELreadMeterRecord.WATERMETERNUMBERCHANGESTATE = "0";


                    if (BLLreadMeterRecord.Insert(MODELreadMeterRecord))
                    {
                        prb.Value = i + 1;
                        labProgress.Text = "进度:" + (i + 1) + "/" + intAllCount;
                    }
                    else
                    {
                        mes.Show("第 " + (i + 1).ToString() + " 行抄表记录保存失败!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show("初始化过程中断:"+ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
            }
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            trMeterReading.Enabled = true;

            panel1.Enabled = true;
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            if(txtYearAndMonth.Text.Length!=6)
            {
                mes.Show("系统检测到月份格式不正确,请重新打开窗体!");
                return;
            }
            string strDate = txtYearAndMonth.Text.Substring(0, 4) + "-" + txtYearAndMonth.Text.Substring(4, 2) + "-" + "01";
            if (Information.IsDate(strDate))
            {
                txtYearAndMonth.Text= Convert.ToDateTime(strDate).AddMonths(1).ToString("yyyyMM");
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

        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
                trMeterReading_AfterSelect(null, ex);
            }
        }

        private void frmWaterMeterReadInitial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(bgWork.IsBusy)
            bgWork.CancelAsync();
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmWaterUserSeniorSearch frm = new frmWaterUserSeniorSearch();
            frm.Owner = this;
            frm.strSign = "1";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }
    }
}
