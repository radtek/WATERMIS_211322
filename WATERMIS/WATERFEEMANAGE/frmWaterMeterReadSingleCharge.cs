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
using System.Runtime.InteropServices;

namespace WATERFEEMANAGE
{
    public partial class frmWaterMeterReadSingleCharge : DockContentEx
    {
        public frmWaterMeterReadSingleCharge()
        {
            InitializeComponent();
            tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel1, true, null);
            tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
            //tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel3, true, null);
            tableLayoutPanel4.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel4, true, null);
            tableLayoutPanel5.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel5, true, null);            
        }

        #region 发票打印接口相关函数
        /// <summary>
        /// 功能：发票开具初始化
        /// </summary>
        /// <param name="hCurWnd">传入参数：为ERP当前的窗口句柄</param>
        /// <returns></returns>
        [DllImport("InvKey.dll")]
        private static extern bool FPInfoInit(IntPtr hCurWnd);

        /// <summary>
        /// 功能：发票添加
        /// </summary>
        /// <param name="FPClientName">购方名称</param>
        /// <param name="FPClientTaxCode">购方税号</param>
        /// <param name="FPClientBankAccount">购方开户行及账号</param>
        /// <param name="FPClientAddressTel">购方地址电话</param>
        /// <param name="FPSellerBankAccount">销方开户行及账号</param>
        /// <param name="FPSellerAddressTel">销方地址电话</param>
        /// <param name="FPNotes">备注</param>
        /// <param name="FPInvoicer">开票人</param>
        /// <param name="FPChecker">复核人 可以为空</param>
        /// <param name="FPCashier">收款人 可以为空</param>
        /// <param name="FPListName">如不为空，则开具销货清单，应为“（详见销货清单）”</param>
        /// <param name="FPState">0:只导入不开票 1：开票不打印 2：开票并打印</param>
        /// <param name="InvQDState">0：正常开具清单 1：不足8条开具清单</param>
        /// <returns></returns>
        [DllImport("InvKey.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool AddFPData(string FPClientName, string FPClientTaxCode, string FPClientBankAccount, string FPClientAddressTel,
            string FPSellerBankAccount, string FPSellerAddressTel, string FPNotes, string FPInvoicer, string FPChecker, string FPCashier,
            string FPListName, int FPState, int InvQDState);

        /// <summary>
        /// 初始化明细信息
        /// </summary>
        /// <returns></returns>
        [DllImport("InvKey.dll")]
        private static extern bool MXInfoInit();

        /// <summary>
        /// 添加明细
        /// </summary>
        /// <param name="MXGoodsName">商品或劳务名称</param>
        /// <param name="MXStandard">规格型号</param>
        /// <param name="MXUnit">计量单位 如果为空，忽略数量和单价</param>
        /// <param name="MXNumber">数量</param>
        /// <param name="MXPrice">单价</param>
        /// <param name="MXAmount">金额 可以不传，由开票软件计算，如传入应符合计算关系</param>
        /// <param name="MXTaxRate">税率 17、13、4、0等  0.17对应17 0.13对应13 4对应0.04</param>
        /// <param name="MXPriceKind">含税价标志 单价和金额的种类，0为不含税价，1为含税价</param>
        /// <param name="MXTaxAmount">税额 可以不传，由开票软件计算，如传入应符合计算关系</param>
        /// <returns></returns>
        [DllImport("InvKey.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool AddMXData(byte[] MXGoodsName, byte[] MXStandard, byte[] MXUnit, double MXNumber,
            double MXPrice, double MXAmount, int MXTaxRate, int MXPriceKind, double MXTaxAmount);

        /// <summary>
        /// 发票开具
        /// </summary>
        /// <param name="outInvTypeCode">出参:发票代码</param>
        /// <param name="outInvNumber">出参:发票号码</param>
        /// <returns></returns>
        [DllImport("InvKey.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool FPInvoice(StringBuilder outInvTypeCode, StringBuilder outInvNumber);

        /// <summary>
        /// 获取发票数据
        /// </summary>
        /// <param name="outInvTypeCode">出参:发票代码</param>
        /// <param name="outInvNumber">出参:发票号码</param>
        /// <returns></returns>
        [DllImport("InvKey.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool GetFPInfo(StringBuilder outInvTypeCode, StringBuilder outInvNumber);

        /// <summary>
        /// 关闭接口
        /// </summary>
        /// <returns></returns>
        [DllImport("InvKey.dll")]
        private static extern bool CloseInvKey();

        //接口调用规范：
        //1、	将带有注册信息的login.ini配置文件放置到接口软件的根目录下；
        //2、	启动“开票软件”，将界面打开到开票界面；
        //3、	调用FPInfoInit，初始化发票；
        //4、	调用AddFPData，添加发票；
        //5、	调用MXInfoInit，初始化明细，多条明细只调用一次；
        //6、	调用AddMXData，添加明细，添加一条明细调用一次。
        //7、	调用FPInvoice，填开发票。
        //8、	退出程序时，调用CloseInvKey。
        #endregion

        //BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        //BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        //BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();

        //BLLAREA BLLAREA = new BLLAREA();
        //BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        //BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();

        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENT = new BLLBASE_DEPARTMENT();

        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLCHARGETYPE BLLCHARGETYPE = new BLLCHARGETYPE();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLCHARGEINVOICEPRINT BLLCHARGEINVOICEPRINT = new BLLCHARGEINVOICEPRINT();
        //BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();
        BLLINVOICEBATCH BLLINVOICEBATCH = new BLLINVOICEBATCH();

        BLLRECEIPTFETCH BLLRECEIPTFETCH = new BLLRECEIPTFETCH();

        RMBToCapMoney RMBToCapMoney = new RMBToCapMoney();
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

        /// <summary>
        /// 所属组
        /// </summary>
        private string strGroupID = "";

        /// <summary>
        /// 公司开票信息
        /// </summary>
        string strCompanyName = "", strCompanyTaxNO = "", strCompanyAddressAndTel = "", strAccountNO = "";

        /// <summary>
        /// 收款人
        /// </summary>
        private string strCompanyPayee = "";

        /// <summary>
        /// 复核人
        /// </summary>
        private string strCompanyChecker = "";

        DataTable dtCompanyName = new DataTable();

        //审核颜色、已收费颜色、已保存颜色，剩余待用：用户停用颜色、水表停用及报废颜色、默认的cell颜色、cell只读颜色。
        Color colorChecked = Color.Green, colorCharged = Color.Red,colorSave=Color.Blue, colorWaterUserStop = Color.Goldenrod, colorWaterMeterStop = Color.Yellow,colorCellDefault=SystemColors.Window,colorCellReadOnly=SystemColors.Control;
        private void frmModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            dgWaterList.AutoGenerateColumns = false;
            //dgHistoryWaterFee.AutoGenerateColumns = false;
            dgWaterList.ShowCellToolTips = true;
            dgHistoryYC.AutoGenerateColumns = false;

            dgWaterList.Columns["readMeterRecordYearAndMonth"].DefaultCellStyle.Format = "yyyy-MM";
            dgHistoryYC.Columns["readMeterRecordYearAndMonthS"].DefaultCellStyle.Format = "yyyy-MM";

            //dgWaterList.MouseWheel += new MouseEventHandler(dgWaterList_MouseWheel);//加入鼠标滚动事件
            //dgHistoryWaterFee.MouseWheel += new MouseEventHandler(dgHistoryWaterFee_MouseWheel);//加入鼠标滚动事件

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

            object objGroup = AppDomain.CurrentDomain.GetData("GROUPID");
            if (objGroup != null && objGroup != DBNull.Value)
            {
                strGroupID = objGroup.ToString();
            }

            //this.Text = "营业厅坐收——当前收费员:" + strUserName;

            //保存默认的单元格颜色
            colorCellDefault = dgWaterList.DefaultCellStyle.BackColor;

            //获取当前时间的月份和年份
            DateTime dtNow = mes.GetDatetimeNow();
            cmbWaterFeeYear.SelectedIndex = 0;
            cmbWaterFeeMonth.SelectedIndex = 0;

            for (int i = 0; i < dgWaterList.Columns.Count; i++)
            {
                //禁止列排序
                dgWaterList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (dgWaterList.Columns[i].Name == "cellSelect")
                {
                    //本月读数可编辑
                    dgWaterList.Columns[i].ReadOnly = false;
                }
                else
                    dgWaterList.Columns[i].ReadOnly = true;

                //隐藏附加费列
                if (dgWaterList.Columns[i].Name == "extraChargePrice1" || dgWaterList.Columns[i].Name == "extraCharge1" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice2" || dgWaterList.Columns[i].Name == "extraCharge2" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice3" || dgWaterList.Columns[i].Name == "extraCharge3" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice4" || dgWaterList.Columns[i].Name == "extraCharge4" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice5" || dgWaterList.Columns[i].Name == "extraCharge5" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice6" || dgWaterList.Columns[i].Name == "extraCharge6" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice7" || dgWaterList.Columns[i].Name == "extraCharge7" ||
                    dgWaterList.Columns[i].Name == "extraChargePrice8" || dgWaterList.Columns[i].Name == "extraCharge8")
                {
                    dgWaterList.Columns[i].Visible = false;
                }
            }

            GetExtraFeeName();

            //BindWaterUserType(cmbWaterUserType);
            BindWaterMeterType();
            BindChargeType();
            BindInvoiceBatch(cmbBatch);
            GenerateTree();
            GetCompanyName();
        }
        /// <summary>
        /// 获取开票信息
        /// </summary>
        private void GetCompanyName()
        {
            dtCompanyName = BLLBASE_DEPARTMENT.QueryDep(" AND departmentID='01'");
            if (dtCompanyName.Rows.Count > 0)
            {
                object objCompany=dtCompanyName.Rows[0]["departmentName"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyName = objCompany.ToString();

                objCompany = dtCompanyName.Rows[0]["FPTaxNO"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyTaxNO = objCompany.ToString();

                objCompany = dtCompanyName.Rows[0]["FPAddressAndTel"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyAddressAndTel = objCompany.ToString();

                objCompany = dtCompanyName.Rows[0]["FPBankNameAndAccountNO"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strAccountNO = objCompany.ToString();

                objCompany = dtCompanyName.Rows[0]["Payee"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyPayee = objCompany.ToString();

                objCompany = dtCompanyName.Rows[0]["Checker"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyChecker = objCompany.ToString();
            }
        }

        /// <summary>
        /// 绑定发票批次
        /// </summary>
        /// <param name="cmb"></param>
        private void BindInvoiceBatch(ComboBox cmb)
        {
            DataTable dt = BLLINVOICEBATCH.Query(" AND ISUSING='1' ORDER BY INVOICEBATCHID DESC");
            cmb.DataSource = dt;
            cmb.DisplayMember = "INVOICEBATCHNAME";
            cmb.ValueMember = "INVOICEBATCHID";

            if (dt.Rows.Count == 0)
            {
                mes.Show("请设置发票批次,否则发票将无法打印!");
            }
        }

        /// <summary>
        /// 获取抄表员表
        /// </summary>
        DataTable dtMeterReader = new DataTable();

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
                    strID = "METERREADER|无关ID| AND meterReaderID='" + objID.ToString() + "'";
                }
                object objName = dtMeterReader.Rows[i]["USERNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
            }
            tnHeadMeterReader.Nodes.Add("|无关ID| AND meterReaderID=''", "抄表员为空", 0, 1);
            #endregion
            trMeterReading.SelectedNode = tnHeadArea;
        }
        void dgWaterList_MouseWheel(object sender, MouseEventArgs e)
        {
            int rowIndex = this.dgWaterList.CurrentRow.Index;
            this.dgWaterList.ClearSelection();

            if (e.Delta > 0)
            {
                if (rowIndex > 0)
                {
                    this.dgWaterList.CurrentCell = this.dgWaterList.Rows[rowIndex - 1].Cells["waterUserName"];
                    this.dgWaterList.Rows[rowIndex - 1].Selected = true;
                }
                else
                {
                    this.dgWaterList.CurrentCell = this.dgWaterList.Rows[rowIndex].Cells["waterUserName"];
                    this.dgWaterList.Rows[rowIndex].Selected = true;
                }
            }
            else
            {
                if (rowIndex < this.dgWaterList.Rows.Count - 1)
                {
                    this.dgWaterList.CurrentCell = this.dgWaterList.Rows[rowIndex + 1].Cells["waterUserName"];
                    this.dgWaterList.Rows[rowIndex + 1].Selected = true;
                }
                else
                {
                    this.dgWaterList.CurrentCell = this.dgWaterList.Rows[rowIndex].Cells["waterUserName"];
                    this.dgWaterList.Rows[rowIndex].Selected = true;
                }
            }
        }

        ///// <summary>
        ///// 绑定用户类型
        ///// </summary>
        ///// <param name="cmb"></param>
        //private void BindWaterUserType(ComboBox cmb)
        //{
        //    DataTable dt = BLLwaterUserType.Query("");
        //    DataRow dr = dt.NewRow();
        //    dr["waterUserTypeName"] = "";
        //    dr["waterUserTypeId"] = DBNull.Value;
        //    dt.Rows.InsertAt(dr, 0);
        //    cmb.DataSource = dt;
        //    cmb.DisplayMember = "waterUserTypeName";
        //    cmb.ValueMember = "waterUserTypeId";
        //}

        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType()
        {
            DataTable dt = BLLWATERMETERTYPE.Query("");
            DataRow dr = dt.NewRow();
            dr["waterMeterTypeValue"] = "";
            dr["waterMeterTypeId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbWaterMeterType.DataSource = dt;
            cmbWaterMeterType.DisplayMember = "waterMeterTypeValue";
            cmbWaterMeterType.ValueMember = "waterMeterTypeId";
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
        /// 根据附加费表生成附加费列及单价
        /// </summary>
        private void GetExtraFeeName()
        {
            DataTable dt = BLLEXTRACHARGE.Query(" ORDER BY extraChargeID");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object objExtraFee = dt.Rows[i]["extraChargeName"];
                if (objExtraFee != null && objExtraFee != DBNull.Value)
                {
                    dgWaterList.Columns["extraCharge" + (i + 1).ToString()].HeaderText = objExtraFee.ToString();
                    dgWaterList.Columns["extraChargePrice" + (i + 1).ToString()].HeaderText = objExtraFee.ToString() + "单价";

                    object objExtraChargeState = dt.Rows[i]["extraChargeState"];
                    if (objExtraChargeState != null && objExtraChargeState != DBNull.Value)
                    {
                        if (objExtraChargeState.ToString() == "启用")
                        {
                            dgWaterList.Columns["extraCharge" + (i + 1).ToString()].Visible = true;
                            //dgWaterList.Columns["extraChargePrice" + (i + 1).ToString()].Visible = true;
                        }
                    }
                }
            }
        }
        /// <summary>  
        /// DataGridView添加全选  
        /// </summary>  
        /// <param name="dgv">DataGridView控件ID</param>  
        /// <param name="columnIndex">全选所在列序号</param>  
        private void AddFullSelect(DataGridView dgv, int columnIndex,bool isChecked)
        {
            if (dgv.Rows.Count < 1)
            {
                return;
            }
            CheckBox ckBox = new CheckBox();
            ckBox.Text = "全选";
            ckBox.AutoSize = true;
            ckBox.BackColor = dgWaterList.Columns[columnIndex].DefaultCellStyle.BackColor ;
            dgWaterList.Columns[columnIndex].Width =57;
            Rectangle rect = dgv.GetCellDisplayRectangle(1, -1, true);
            ckBox.Size = new Size(dgv.Columns[columnIndex].Width, ckBox.Height+1); //大小                 
            Point point = new Point(rect.X, rect.Y+1);//位置  
            ckBox.Location = point;
            ckBox.CheckedChanged += delegate(object sender, EventArgs e)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[columnIndex].Value = ((CheckBox)sender).Checked;
                }
                dgv.EndEdit();
            DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(1,0);
            dgWaterList_CellValueChanged(null,ex);
            };
            dgv.Controls.Add(ckBox);
            ckBox.Checked = isChecked;
        }  
        private void txtWaterUserNOSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(null, null);
            }
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

        private void dgWaterList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgWaterList.Rows.Count <= 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "avePrice")
            {
                object objToolTipAvePrice = dgWaterList.Rows[e.RowIndex].Cells["avePriceDescribe"].Value;
                if (objToolTipAvePrice != null && objToolTipAvePrice != DBNull.Value)
                    dgWaterList.Rows[e.RowIndex].Cells["avePrice"].ToolTipText = objToolTipAvePrice.ToString();
            }

            if (dgWaterList.Columns[e.ColumnIndex].Name == "totalNumber")
            {
                object objToolTip = dgWaterList.Rows[e.RowIndex].Cells["totalNumberDescribe"].Value;
                if (objToolTip != null && objToolTip != DBNull.Value)
                    dgWaterList.Rows[e.RowIndex].Cells["totalNumber"].ToolTipText = objToolTip.ToString();
            }
        }


        private void toolSave_Click(object sender, EventArgs e)
        {
            dgWaterList.EndEdit();
            int intCheckedCount = 0;
            for (int i = 0; i < dgWaterList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chkcell = dgWaterList.Rows[i].Cells["checkState"] as DataGridViewCheckBoxCell;
                if (chkcell.Value.ToString() == "True")
                {
                    intCheckedCount = intCheckedCount + 1;
                }
            }
            if (intCheckedCount == 0)
                return;
            for (int i = dgWaterList.Rows.Count-1; i >=0; i--)
            {
                DataGridViewCheckBoxCell chkcell = dgWaterList.Rows[i].Cells["checkState"] as DataGridViewCheckBoxCell;
                if (chkcell.Value.ToString() == "True")
                {
                    MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                    MODELreadMeterRecord.checkState = "1";
                    MODELreadMeterRecord.readMeterRecordId = dgWaterList.Rows[i].Cells["readMeterRecordId"].Value.ToString();
                    if (BLLreadMeterRecord.UpdateCheckState(MODELreadMeterRecord))
                    {
                        dgWaterList.Rows.Remove(dgWaterList.Rows[i]);
                    }
                    else
                    {
                        mes.Show("第 " + (i + 1).ToString() + " 行抄表审核状态修改失败!");
                        return;
                    }
                }
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode != null)
            {
                //MouseEventArgs ex = new MouseEventArgs(MouseButtons.Left,1,0,0,0);
                //trMeterReading_MouseDown(null, ex);
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
            txtWaterTotalCharge.Text = "0";
            txtExtraTotalCharge.Text = "0";
            txtWaterFee.Text = "0";
            txtOverDueSum.Text = "0";
            txtBCYS.Text = "0";
            txtBCSS.Text = "0";

            txtYSJSYE.Text = "0";
            txtYSQQYE.Text = "0";
            txtBCJY.Text = "0";
            labTip.Text = "";

            txtJYLSH.Clear();
            cmbChargeType.SelectedIndex = 0;

            txtMemo.Clear();

            dgWaterList.DataSource = null;
            dgHistoryYC.DataSource = null;

            btCharge.Enabled = false;
            btSearchYCLS.Enabled = false;

            tabControl1.SelectedIndex = 0;

            //清空选择的用户ID
            strSelectWaterUser = "";

            foreach (Control con in gpbWaterUserMES.Controls)
            {
                if (con is TextBox)
                    con.Text = "";
            }

            txtInvoiceNO.Clear();//清空发票号

            if (e.Node == null)
                return;
            trMeterReading.SelectedNode = e.Node;
            string strNodeID = e.Node.Name;
            string[] strNodeIDSpit = strNodeID.Split('|');
            LoadData(strNodeIDSpit);
        }
        /// <summary>
        /// 存储查询到的用户表
        /// </summary>
        DataTable dtUserList = new DataTable();
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        private string QueryWaterUser()
        {
            string strFilter = "";
            if (txtWaterUserNOSearch.Text.Trim() != "")
                if (txtWaterUserNOSearch.Text.Length > 5)
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim() + "'";
                else
                strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.Trim().PadLeft(5,'0') + "'";

            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";

            if (txtNameCode.Text.Trim() != "")
                strFilter += " AND waterUserNameCode like '%" + txtNameCode.Text.Trim() + "%'";

            if (txtAddress.Text.Trim() != "")
                strFilter += " AND waterUserAddress LIKE '%" + txtAddress.Text + "%'";

            return strFilter;
        }

        /// <summary>
        /// 选择的用户编号
        /// </summary>
       public string strSelectWaterUser = "";
       private void LoadData(string[] strNodeID)
       {
           //获取新的发票号码
           cmbBatch_SelectionChangeCommitted(null,null);

           //获取新的收据号码,8位收据号
           DataTable dtNewReceriptNO = BLLWATERFEECHARGE.GetMaxReceiptNO(strLogID);
           if (dtNewReceriptNO.Rows.Count > 0)
           {
               object objReceiptNO = dtNewReceriptNO.Rows[0]["RECEIPTNO"];
               if (Information.IsNumeric(objReceiptNO))
               {
                   txtReceiptNO.Text = (Convert.ToInt64(objReceiptNO) + 1).ToString().PadLeft(8, '0');
               }
           }
           dtUserList = BLLwaterUser.QueryInitialWaterUser(strNodeID[2] + QueryWaterUser() + " ORDER BY pianNO,areaNO,duanNO,ordernumber");
           //DataTable dtWaterUserSearch = dtUserList.DefaultView.ToTable(true, "waterUserId", "waterUserNO", "waterUserName", "waterUserAddress", "waterPhone", "areaId", "areaName", "meterReadingID", "meterReadingNO", "meterReadingPageNo", "waterUserTypeId", "waterUserTypeName", "waterUserCreateDate");
           if (dtUserList.Rows.Count > 0)
           {
               //if (dtUserList.Rows.Count > 500)
               //{
               //    mes.Show("符合条件的用户大约500户,请设置更多查询条件!");
               //    return;
               //}
               if (dtUserList.Rows.Count > 1)
               {
                   frmSingleChargeSelectWaterUser frm = new frmSingleChargeSelectWaterUser();
                   frm.dtWaterUserList = dtUserList;
                   frm.Owner = this;
                   frm.strFormType = "1";

                   if (frm.ShowDialog() == DialogResult.OK)
                   {

                   }
                   else
                   {
                       txtWaterUserNOSearch.Focus();
                       return;
                   }
               }
               else
               {
                   object objWaterUserIDSingle = dtUserList.Rows[0]["WATERUSERID"];
                   if (objWaterUserIDSingle != null && objWaterUserIDSingle != DBNull.Value)
                   {
                       strSelectWaterUser = objWaterUserIDSingle.ToString();
                   }
               }
               if (strSelectWaterUser == "")
               {
                   mes.Show("获取用户号失败,请重新查询!");
                   return;
               }
               DataView dvUserList = dtUserList.DefaultView;
               dvUserList.RowFilter = "WATERUSERID='" + strSelectWaterUser + "'";
               dtUserList = dvUserList.ToTable();

               object objWaterUserID = dtUserList.Rows[0]["waterUserId"];
               if (objWaterUserID != null && objWaterUserID != DBNull.Value)
               {
                   txtWaterUserID.Text = objWaterUserID.ToString();

                   btSearchYCLS.Enabled = true;

                   #region 生成用户信息
                   object objWaterUserMes = dtUserList.Rows[0]["waterUserNO"];
                   if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                   {
                       txtWaterUserNO.Text = objWaterUserMes.ToString();
                   }

                   objWaterUserMes = dtUserList.Rows[0]["waterUserName"];
                   if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                   {
                       txtWaterUserName.Text = objWaterUserMes.ToString();
                   }

                   objWaterUserMes = dtUserList.Rows[0]["waterUserTelphoneNO"];
                   if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                   {
                       txtWaterUserPhone.Text = objWaterUserMes.ToString();
                   }

                   //object objWaterUser =dtUserList.Rows[0]["areaNO"];
                   //if (objWaterUser != null && objWaterUser != DBNull.Value)
                   //{
                   //    txtAreaNO.Text = objWaterUser.ToString();
                   //}
                   //else
                   //    txtAreaNO.Clear();
                   //objWaterUser =dtUserList.Rows[0]["duanNO"];
                   //if (objWaterUser != null && objWaterUser != DBNull.Value)
                   //{
                   //    txtDuanNO.Text = objWaterUser.ToString();
                   //}
                   //else
                   //    txtDuanNO.Clear();
                   //objWaterUser =dtUserList.Rows[0]["createType"];
                   //if (objWaterUser != null && objWaterUser != DBNull.Value)
                   //{
                   //    txtCreateType.Text = objWaterUser.ToString();
                   //}
                   //else
                   //    txtCreateType.Clear();

                   objWaterUserMes = dtUserList.Rows[0]["waterUserAddress"];
                   if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                   {
                       txtWaterUserAddress.Text = objWaterUserMes.ToString();
                   }

                  object objWaterUser = dtUserList.Rows[0]["meterReaderID"];
                   if (objWaterUser != null && objWaterUser != DBNull.Value)
                   {
                       DataRow[] dr = dtMeterReader.Select("LOGINID='" + objWaterUser.ToString() + "'");
                       if (dr.Length > 0)
                       {
                           objWaterUser = dr[0]["TELEPHONENO"];
                           if (objWaterUser != null && objWaterUser != DBNull.Value)
                           {
                               txtMeterReaderTel.Text = objWaterUser.ToString();
                           }
                       }
                   }
                   else
                       txtMeterReaderTel.Clear();

                   objWaterUser = dtUserList.Rows[0]["pianNO"];
                   if (objWaterUser != null && objWaterUser != DBNull.Value)
                   {
                       txtPianNO.Text = objWaterUser.ToString();
                   }
                   else
                       txtPianNO.Clear();

                   objWaterUser =dtUserList.Rows[0]["meterReaderName"];
                   if (objWaterUser != null && objWaterUser != DBNull.Value)
                   {
                       txtMeterReader.Text = objWaterUser.ToString();
                   }
                   else
                       txtMeterReader.Clear();

                   objWaterUserMes = dtUserList.Rows[0]["waterMeterTypeValue"];
                   if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                   {
                       txtWaterMeterType.Text = objWaterUserMes.ToString();
                   }

                   //查询用户余额
                   objWaterUserMes = dtUserList.Rows[0]["prestore"];
                   if (Information.IsNumeric(objWaterUserMes))
                   {
                       txtYSQQYE.Text = Convert.ToDecimal(objWaterUserMes).ToString("F2");
                   }

                   objWaterUserMes = dtUserList.Rows[0]["waterPhone"];
                   if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                   {
                       if (txtWaterUserPhone.Text != "")
                           txtWaterUserPhone.Text += ";" + objWaterUserMes.ToString();
                       else
                           txtWaterUserPhone.Text = objWaterUserMes.ToString();
                   }
                   if (txtWaterUserPhone.Text.Trim() == "")
                   {
                       mes.Show("该用户电话为空,请补充电话信息!");
                       txtWaterUserPhone.SelectAll();
                   }

                   objWaterUser = dtUserList.Rows[0]["waterMeterStateS"];
                   if (objWaterUser != null && objWaterUser != DBNull.Value)
                   {
                       txtWaterUserState.Text = objWaterUser.ToString();
                       if (objWaterUser.ToString() == "欠费停水" || objWaterUser.ToString() == "违章停水")
                       {
                           mes.Show("该用户已欠费(或违章)停水,请核对用户电话!");
                           txtWaterUserPhone.SelectAll();
                       }
                   }
                   else
                       txtWaterUserState.Clear();

                  // int intWaterMeterCount = 0, intWaterMeterValidCount = 0, intWaterMeterUnvalidCount = 0;
                  //DataTable dtWaterMeter= BLLwaterMeter.Query(" AND WATERUSERID='"+strSelectWaterUser+"'");
                  //if (dtWaterMeter.Rows.Count > 0)
                  //{
                  //    intWaterMeterCount=dtWaterMeter.Rows.Count;
                  //    DataRow[] drValid = dtWaterMeter.Select("waterMeterState='1'");
                  //    intWaterMeterValidCount = drValid.Length;
                  //    if (intWaterMeterCount - intWaterMeterValidCount > 0)
                  //    {
                  //        mes.Show("该用户共 "+intWaterMeterCount+" 块水表,其中报停 "+(intWaterMeterCount-intWaterMeterValidCount)+" 块");
                  //    }
                  //}
                  //else
                  //{
                  //    mes.Show("未检测到该用户的水表信息!");
                  //}
                   #endregion

                   ////如果用户是非预存交费用户，则不允许收费
                   //object objWaterUserChargeType = dtUserList.Rows[0]["chargeType"];
                   //if (objWaterUserChargeType != null && objWaterUserChargeType != DBNull.Value)
                   //{
                   //    if (objWaterUserChargeType.ToString() == "0")
                   //    {
                   //        mes.Show("用户'" + txtWaterUserName.Text + "'为非预存用户,无法执行收费操作!");
                   //        return;
                   //    }
                   //}

                   #region 生成缴费信息
                   string strFilter = "";

                   if (cmbWaterFeeYear.Text != "")
                       strFilter += " AND readMeterRecordYear='" + cmbWaterFeeYear.Text + "'";

                   if (cmbWaterFeeMonth.Text != "")
                       strFilter += " AND readMeterRecordMonth='" + cmbWaterFeeMonth.Text + "'";
                   DataTable dtWaterMeterReadNotCharge = BLLreadMeterRecord.QueryYSDetailByWaterMeter(strFilter + " AND waterUserId='" + objWaterUserID.ToString() + "' AND checkState='1' AND chargeState='1' AND totalChargeEND>0  ORDER BY readMeterRecordYear DESC,readMeterRecordMonth DESC");
                   dgWaterList.DataSource = dtWaterMeterReadNotCharge;

                   if (dgWaterList.Rows.Count == 0)
                   {
                       btCharge.Enabled = false;
                       labTip.Text = "未找到该用户欠费信息";
                       txtNameCode.Clear();
                       txtWaterUserNameSearch.Clear();
                       txtAddress.Clear();

                       //txtWaterUserNOSearch.SelectAll();
                       //txtWaterUserNOSearch.Focus();
                       txtWaterUserNOSearch.Clear();

                       if (mes.ShowQ("未找到该用户欠费信息，是否预存水费?") == DialogResult.OK)
                       {
                           frmPrestoreCharge frmPrestoreCharge = new frmPrestoreCharge();
                           frmPrestoreCharge.strWaterUserID = strSelectWaterUser;
                           frmPrestoreCharge.strMeterReaderTel = txtMeterReaderTel.Text;
                           frmPrestoreCharge.ShowDialog();
                       }
                   }
                   else
                   {
                       txtNameCode.Clear();
                       txtWaterUserNameSearch.Clear();
                       txtAddress.Clear();
                       txtWaterUserNOSearch.Clear();

                       btCharge.Enabled = true;
                       for (int i = 0; i < dgWaterList.Rows.Count; i++)
                       {
                           //将checkbox列置为可用
                           dgWaterList.Rows[i].Cells["cellSelect"].Value = true;

                           //将用到的附加费列显示出来
                           object objWaterMeterTypeID = dgWaterList.Rows[i].Cells["waterMeterTypeId"].Value;
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
                                           dgWaterList.Columns["extraCharge" + strNum].Visible = true;
                                           dgWaterList.Columns["extraChargePrice" + strNum].Visible = true;
                                           dgWaterList.Rows[i].Cells["extraChargePrice" + strNum].Value = strSingleExtraFee[1];
                                       }
                                   }
                               }
                           }
                       }
                       txtBCSS.Focus();
                       DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(1, 0);
                       dgWaterList_CellValueChanged(null, ex);
                   }
                   #endregion
               }
           }
           else
           {
               labTip.Text = "未找到符合条件的用户";
           }
       }

        private void dgWaterList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "readMeterRecordMonth")
            {
                if (e.Value != null || e.Value != DBNull.Value)
                    e.Value = e.Value.ToString().PadLeft(2,'0');
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "checkState")
            {
                if (e.Value != null || e.Value != DBNull.Value)
                {
                    if (e.Value.ToString() == "0")
                        e.Value = "未审核";
                    else if (e.Value.ToString() == "1")
                        e.Value = "已审核";

                }
                else
                    e.Value = "未审核";
            }
            if (dgWaterList.Columns[e.ColumnIndex].Name == "chargeState")
            {
                if (e.Value != null || e.Value != DBNull.Value)
                {
                    if (e.Value.ToString() == "0")
                        e.Value = "未抄表";
                    else if (e.Value.ToString() == "1")
                        e.Value = "未收费";
                    else if (e.Value.ToString() == "2")
                        e.Value = "已预收";
                    else if (e.Value.ToString() == "3")
                        e.Value = "已收费";

                }
                else
                    e.Value = "未收费";
            }
            //if (dgWaterList.Columns[e.ColumnIndex].Name == "waterUserState")
            //{
            //    if (e.Value != null && e.Value != DBNull.Value)
            //        if (e.Value.ToString() == "1")
            //        {
            //            e.Value = "有表";
            //        }
            //        else if (e.Value.ToString() == "2")
            //            e.Value = "无表";
            //}
            if (dgWaterList.Columns[e.ColumnIndex].Name == "waterUserHouseType")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "楼房";
                    }
                    else if (e.Value.ToString() == "2")
                        e.Value = "平房";
            }
        }

        private void gpbWaterFeeMes_Paint(object sender, PaintEventArgs e)
        {
            //GroupBox box = (GroupBox)sender;
            //e.Graphics.Clear(SystemColors.Control);
            //e.Graphics.DrawString(box.Text, box.Font, Brushes.Red, 0, 0);
        }

        private void txtBCYS_TextChanged(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtBCYS.Text))
                txtBCYS.Text = "0";

            if (!Information.IsNumeric(txtBCSS.Text))
                txtBCSS.Text = "0";

            if (!Information.IsNumeric(txtBCJY.Text))
                txtBCJY.Text = "0";

            if (!Information.IsNumeric(txtYSQQYE.Text))
                txtYSQQYE.Text = "0";

            if (!Information.IsNumeric(txtYSJSYE.Text))
                txtYSJSYE.Text = "0";

                txtBCJY.Text = (Convert.ToDecimal(txtBCSS.Text) - Convert.ToDecimal(txtBCYS.Text)).ToString("f2");
                txtYSJSYE.Text = (Convert.ToDecimal(txtYSQQYE.Text) + Convert.ToDecimal(txtBCJY.Text)).ToString("f2");
            if (Convert.ToDecimal(txtBCSS.Text) + Convert.ToDecimal(txtYSQQYE.Text) - Convert.ToDecimal(txtBCYS.Text) >= 0)
            {
                btCharge.Enabled = true;
            }
            else
            {
                btCharge.Enabled = false;
                //txtYSJSYE.Text = "0";
                //txtBCJY.Text = "0";
            }
            //if(Convert.ToDecimal(txtBCYS.Text)==0)
            //btCharge.Enabled=false;
            //else
            //btCharge.Enabled=true;
        }

        private void txtBCSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //检测是否已经输入了小数点 
            bool IsContainsDot = this.txtBCSS.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
            if (e.KeyChar ==(char)13)
            {
                btCharge.Focus();
            }
        }
        /// <summary>
        /// 发票打印时的等待窗体
        /// </summary>
        frmWaitSearchCanCancel frmWaitSearchCanCancel = new frmWaitSearchCanCancel();
        private void btCharge_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgWaterList.Rows.Count == 0)
                {
                    mes.Show("未找到水费信息!");
                    return;
                }
                object objPrestore = BLLwaterUser.GetPrestore(" AND WATERUSERID='" + txtWaterUserID.Text + "'");
                if (Information.IsNumeric(objPrestore))
                {
                    txtYSQQYE.Text = Convert.ToDecimal(objPrestore).ToString("F2");
                }
                else
                    txtYSQQYE.Text = "0";

                if (Convert.ToDecimal(txtBCSS.Text) + Convert.ToDecimal(txtYSQQYE.Text) - Convert.ToDecimal(txtBCYS.Text) < 0)
                {
                    mes.Show("金额不足，无法完成缴费!");
                    return;
                }
                if (cmbChargeType.SelectedValue == null || cmbChargeType.SelectedValue == DBNull.Value)
                {
                    mes.Show("收款方式不能为空!");
                    cmbChargeType.Focus();
                    return;
                }
                else
                {
                    if (cmbChargeType.SelectedValue.ToString() == "2")
                    {
                        if (txtJYLSH.Text.Trim() == "")
                        {
                            mes.Show("请输入POS机收费的交易流水号!");
                            txtJYLSH.Focus();
                            return;
                        }
                    }
                }
                if (!Information.IsNumeric(txtBCSS.Text))
                {
                    txtBCSS.Text = "0";
                }
                if (rbInvoiceSinglePrint.Checked||rbInvoiceBatchPrint.Checked)
                {
                    if (txtWaterUserName.Text.Trim() == "")
                    {
                        mes.Show("发票开具用户名不能为空!");
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
                        mes.Show("请输入发票号码!");
                        txtInvoiceNO.Focus();
                        return;
                    }
                    else
                    {
                        if (txtInvoiceNO.Text.Length > 8)
                        {
                            mes.Show("发票号码长度应小于9位，请确定发票号是否正确!");
                            txtInvoiceNO.Focus();
                            return;
                        }

                        if (!Information.IsNumeric(txtInvoiceNO.Text))
                        {
                            mes.Show("发票号码只能由数字组成!");
                            txtInvoiceNO.Focus();
                            return;
                        }
                        txtInvoiceNO.Text = txtInvoiceNO.Text.PadLeft(8, '0');

                        #region 发票验证
                        DataTable dtCheckInvoiceExists = BLLWATERFEECHARGE.QueryChargeView(" AND INVOICENO='" + txtInvoiceNO.Text + "' AND INVOICEBATCHID='" + cmbBatch.SelectedValue.ToString() + "' AND INVOICECANCEL='0'");
                        if (dtCheckInvoiceExists.Rows.Count > 0)
                        {
                            mes.Show("发票批次为'" + cmbBatch.Text + "'票号为'" + txtInvoiceNO.Text + "'的发票已使用，请重新输入发票号码!");
                            txtInvoiceNO.Focus();
                            return;
                        }
                        /*
                        else
                        {
                            DataTable dtInvoiceFetch = BLLINVOICEFETCH.Query(" AND  INVOICEFETCHBATCHID='" + cmbBatch.SelectedValue.ToString() + "'");
                            #region 验证发票领取记录是否存在
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
                                mes.Show("批次为'" + cmbBatch.Text + "'的发票起始号码不在领取记录中,请确认发票号码是否正确!");
                                txtInvoiceNO.Focus();
                                return;
                            }
                            #endregion
                        }
                         * */
                        #endregion
                    }
                }
                if (rbPrintReceipt.Checked)
                {
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
                        dtReceiptNO = BLLRECEIPTFETCH.Query(" AND RECEIPTFETCHERID='" + strLogID + "'");
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
                            mes.Show("收据号'" + txtReceiptNO.Text + "'不在领取记录中,无法打印!");
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
                }

                decimal decBCYSTemp = Convert.ToDecimal(txtBCYS.Text);
                decimal decBCSSTemp = Convert.ToDecimal(txtBCSS.Text);
                //重新计算水费
                DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(1, 0);
                dgWaterList_CellValueChanged(null, ex);
                txtBCSS.Text = decBCSSTemp.ToString();

                decimal decBCYS = Convert.ToDecimal(txtBCYS.Text);
                if (decBCYS != decBCYSTemp)
                {
                    mes.Show("水费已重新计算，请按新的水费收费!");
                    return;
                }

                if (Convert.ToDecimal(txtYSJSYE.Text) < 0)
                {
                    mes.Show("金额不足,无法缴费!");
                    return;
                }
                //存储收费选择的行数
                int intCount = 0;
                for (int i = 0; i < dgWaterList.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chkcell = (DataGridViewCheckBoxCell)dgWaterList.Rows[i].Cells["cellSelect"];
                    bool isChecked = Convert.ToBoolean(chkcell.EditedFormattedValue);
                    if (isChecked)
                    {
                        object objChargeState = dgWaterList.Rows[i].Cells["chargeState"].Value;
                        if (objChargeState != null && objChargeState != DBNull.Value)
                        {
                            if (objChargeState.ToString() != "已收费" && objChargeState.ToString() != "已预收")
                                intCount++;
                        }
                    }
                }
                if (intCount == 0)
                {
                    mes.Show("未选择需要收费的水费信息!");
                    dgWaterList.CurrentCell = dgWaterList.Rows[0].Cells["cellSelect"];
                    return;
                }

                if (rbInvoiceBatchPrint.Checked)
                {
                    //发票开具初始化
                    bool isSuccess = FPInfoInit(this.Handle);
                    if (!isSuccess)
                    {
                        mes.Show("发票开具初始化失败,请重试!");
                        return;
                    }
                    #region 收费合并打印发票
                    //合并打印发票，把实收减去除第一条外的其他的应收
                    //decimal decFirstTotalChargeEnd = 0;
                    //for (int i = dgWaterList.Rows.Count - 1; i >= 0; i--)
                    //{
                    //    DataGridViewCheckBoxCell chkcell = (DataGridViewCheckBoxCell)dgWaterList.Rows[i].Cells["cellSelect"];
                    //    bool isChecked = Convert.ToBoolean(chkcell.EditedFormattedValue);
                    //    if (isChecked)
                    //    {
                    //        object objTotalChargeEnd = dgWaterList.Rows[i].Cells["totalChargeEND"].FormattedValue;
                    //        if (Information.IsNumeric(objTotalChargeEnd))
                    //        {
                    //            decFirstTotalChargeEnd = Convert.ToDecimal(objTotalChargeEnd);
                    //        }
                    //        break;
                    //    }
                    //}
                    ////将本次收支和本次结余存到第一条收费记录里
                    //decimal decFirstBCSS = Convert.ToDecimal(txtBCSS.Text);
                    //decimal decFirstJSYE = Convert.ToDecimal(txtYSJSYE.Text);
                    //decimal decFirstBCSZ = Convert.ToDecimal(txtBCJY.Text);

                    string strMeterType = "";
                    for (int i = dgWaterList.Rows.Count-1; i>=0; i--)
                    {
                        DataGridViewCheckBoxCell chkcell = (DataGridViewCheckBoxCell)dgWaterList.Rows[i].Cells["cellSelect"];
                        bool isChecked = Convert.ToBoolean(chkcell.EditedFormattedValue);
                        if (isChecked)
                        {
                            object objMeterType = dgWaterList.Rows[i].Cells["waterMeterTypeId"].Value;
                            if (objMeterType != null && objMeterType != DBNull.Value)
                            {
                                if (strMeterType == "")
                                    strMeterType = objMeterType.ToString();
                                else
                                {
                                    if (strMeterType != objMeterType.ToString())
                                    {
                                        mes.Show("所选收费明细中存在多种用水性质,无法合并打印发票!");
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    DateTime dtChargeDateTime = mes.GetDatetimeNow();

                    //本次实收
                    decimal decBCSS = Convert.ToDecimal(txtBCSS.Text);
                    //前期余额
                    decimal decQQYE = Convert.ToDecimal(txtYSQQYE.Text);

                    int  intChargeIndex=0;//如果收费是第一条，则更新预存余额及打印发票
                    //更新抄表表收费状态
                    int intChargeCount = dgWaterList.Rows.Count - 1;//将总行数保存下来，打印发票时判断是不是第一次打印，如果是提示发票号不一致
                    for (int i = intChargeCount; i >= 0; i--)
                    {
                        DataGridViewCheckBoxCell chkcell = (DataGridViewCheckBoxCell)dgWaterList.Rows[i].Cells["cellSelect"];
                        bool isChecked = Convert.ToBoolean(chkcell.EditedFormattedValue);
                        if (isChecked)
                        {
                            intChargeIndex++;
                            object objReadMeterRecordID = dgWaterList.Rows[i].Cells["readMeterRecordId"].Value;
                            if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
                            {
                                string strIsCharge = " AND readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                                DataTable dtCharge = BLLWATERFEECHARGE.QueryLS(strIsCharge);
                                if (dtCharge.Rows.Count > 0)
                                {
                                    mes.Show("第'" + (i + 1).ToString() + "行'抄表记录已经收费，请重新查询后再收费!");
                                    return;
                                }

                                //水表编号
                                string strWaterMeterNO = "";
                                //用水量
                                int intWaterTotalNumber = 0, intLastNumber = 0, intEndNumber = 0;
                                //水费小计，污水处理费，附加费，污水处理费总计，滞纳金，水费合计
                                decimal decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decExtraTotalCharge = 0, decOverDueMoney = 0, decTotalCharge = 0, decTotalChargeEnd = 0,
                                    decAvgPrcie = 0, decExtraChargePrice1 = 0, decExtraChargePrice2 = 0;

                                object objWaterMeterNO = dgWaterList.Rows[i].Cells["waterMeterNo"].FormattedValue;
                                if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                                {
                                    strWaterMeterNO = objWaterMeterNO.ToString();
                                }

                                object objWaterLastNumber = dgWaterList.Rows[i].Cells["waterMeterLastNumber"].FormattedValue;
                                if (Information.IsNumeric(objWaterLastNumber))
                                {
                                    intLastNumber = Convert.ToInt32(objWaterLastNumber);
                                }

                                object objWaterEndNumber = dgWaterList.Rows[i].Cells["waterMeterEndNumber"].FormattedValue;
                                if (Information.IsNumeric(objWaterEndNumber))
                                {
                                    intEndNumber = Convert.ToInt32(objWaterEndNumber);
                                }

                                object objWaterTotalNumber = dgWaterList.Rows[i].Cells["totalNumber"].FormattedValue;
                                if (Information.IsNumeric(objWaterTotalNumber))
                                {
                                    intWaterTotalNumber = Convert.ToInt32(objWaterTotalNumber);
                                }

                                object objWaterTotalCharge = dgWaterList.Rows[i].Cells["waterTotalChargeEND"].FormattedValue;
                                if (Information.IsNumeric(objWaterTotalCharge))
                                {
                                    decWaterTotalCharge = Convert.ToDecimal(objWaterTotalCharge);
                                }

                                object objExtraCharge1 = dgWaterList.Rows[i].Cells["extraCharge1"].FormattedValue;
                                if (Information.IsNumeric(objExtraCharge1))
                                {
                                    decExtraCharge1 = Convert.ToDecimal(objExtraCharge1);
                                }

                                object objExtraCharge2 = dgWaterList.Rows[i].Cells["extraCharge2"].FormattedValue;
                                if (Information.IsNumeric(objExtraCharge2))
                                {
                                    decExtraCharge2 = Convert.ToDecimal(objExtraCharge2);
                                }

                                object objExtraTotalCharge = dgWaterList.Rows[i].Cells["extraTotalChargeEND"].FormattedValue;
                                if (Information.IsNumeric(objExtraTotalCharge))
                                {
                                    decExtraTotalCharge = Convert.ToDecimal(objExtraTotalCharge);
                                }

                                object objOverDueMoney = dgWaterList.Rows[i].Cells["OVERDUEEND"].FormattedValue;
                                if (Information.IsNumeric(objOverDueMoney))
                                {
                                    decOverDueMoney = Convert.ToDecimal(objOverDueMoney);
                                }

                                object objTotalCharge = dgWaterList.Rows[i].Cells["totalCharge"].FormattedValue;
                                if (Information.IsNumeric(objTotalCharge))
                                {
                                    decTotalCharge = Convert.ToDecimal(objTotalCharge);
                                }

                                object objTotalChargeEnd = dgWaterList.Rows[i].Cells["totalChargeEND"].FormattedValue;
                                if (Information.IsNumeric(objTotalChargeEnd))
                                {
                                    decTotalChargeEnd = Convert.ToDecimal(objTotalChargeEnd);
                                }

                                object objAvgPrice = dgWaterList.Rows[i].Cells["avePrice"].FormattedValue;
                                if (Information.IsNumeric(objAvgPrice))
                                {
                                    decAvgPrcie = Convert.ToDecimal(objAvgPrice);
                                }

                                object objExtraChargePrice1 = dgWaterList.Rows[i].Cells["extraChargePrice1"].FormattedValue;
                                if (Information.IsNumeric(objExtraChargePrice1))
                                {
                                    decExtraChargePrice1 = Convert.ToDecimal(objExtraChargePrice1);
                                }

                                object objExtraChargePrice2 = dgWaterList.Rows[i].Cells["extraChargePrice2"].FormattedValue;
                                if (Information.IsNumeric(objExtraChargePrice2))
                                {
                                    decExtraChargePrice2 = Convert.ToDecimal(objExtraChargePrice2);
                                    if (decExtraChargePrice2 > 0)
                                        decExtraChargePrice2 = decAvgPrcie * (decimal)0.1;
                                }

                                MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                                MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLogID, "WATERFEECHARGE");
                                MODELWATERFEECHARGE.TOTALNUMBERCHARGE = intWaterTotalNumber;
                                MODELWATERFEECHARGE.WATERTOTALCHARGE = decWaterTotalCharge;
                                MODELWATERFEECHARGE.EXTRACHARGECHARGE1 = decExtraCharge1;
                                MODELWATERFEECHARGE.EXTRACHARGECHARGE2 = decExtraCharge2;
                                MODELWATERFEECHARGE.EXTRATOTALCHARGE = decExtraTotalCharge;
                                MODELWATERFEECHARGE.OVERDUEMONEY = decOverDueMoney;
                                MODELWATERFEECHARGE.TOTALCHARGE = decTotalChargeEnd;
                                MODELWATERFEECHARGE.CHARGETYPEID = cmbChargeType.SelectedValue.ToString();
                                if (cmbChargeType.SelectedValue.ToString() == "2")
                                {
                                    MODELWATERFEECHARGE.POSRUNNINGNO = txtJYLSH.Text;
                                }
                                MODELWATERFEECHARGE.CHARGEClASS = "1";//收费类型是正常收取
                                MODELWATERFEECHARGE.CHARGEBCYS = decTotalChargeEnd;

                                MODELWATERFEECHARGE.CHARGEBCSS = decBCSS;
                                MODELWATERFEECHARGE.CHARGEYSQQYE = decQQYE;
                                MODELWATERFEECHARGE.CHARGEYSBCSZ = MODELWATERFEECHARGE.CHARGEBCSS - MODELWATERFEECHARGE.CHARGEBCYS;
                                MODELWATERFEECHARGE.CHARGEYSJSYE = decBCSS + decQQYE - MODELWATERFEECHARGE.CHARGEBCYS;

                                MODELWATERFEECHARGE.CHARGEWORKERID = strLogID;
                                MODELWATERFEECHARGE.CHARGEWORKERNAME = strUserName;
                                MODELWATERFEECHARGE.CHARGEDATETIME = dtChargeDateTime;

                                MODELWATERFEECHARGE.MEMO = txtMemo.Text;
                                MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";
                                try
                                {
                                    if (BLLWATERFEECHARGE.InsertFP(MODELWATERFEECHARGE))
                                    {
                                        try
                                        {
                                            MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                                            MODELreadMeterRecord.chargeState = "3";
                                            MODELreadMeterRecord.chargeID = MODELWATERFEECHARGE.CHARGEID;

                                            //把未减免前的滞纳金保存到抄表记录表里
                                            object objOVERDUEGET = dgWaterList.Rows[i].Cells["OVERDUEGET"].FormattedValue;
                                            if (Information.IsNumeric(objOVERDUEGET))
                                                MODELreadMeterRecord.OVERDUEMONEY = Convert.ToDecimal(objOVERDUEGET);

                                            MODELreadMeterRecord.readMeterRecordId = objReadMeterRecordID.ToString();
                                            if (BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord))
                                            {
                                                bool isSuccessUpdatePrestore = false;
                                                string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CHARGEYSJSYE + " WHERE waterUserId='" + txtWaterUserID.Text + "'";
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
                                                    MODELreadMeterRecord.readMeterRecordId = objReadMeterRecordID.ToString();
                                                    BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);

                                                    string strError = "更新用户编号为'" + txtWaterUserID.Text + "'的余额失败,原因:" + exUpdateWaterUserPrestore.Message;
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
                                                    MODELreadMeterRecord.readMeterRecordId = objReadMeterRecordID.ToString();
                                                    BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);

                                                    string strError = "更新用户编号为'" + txtWaterUserID.Text + "'的余额失败!/n请查询用户余额是否正确后重新收费!";
                                                    mes.Show(strError);
                                                    log.Write(strError, MsgType.Error);
                                                    return;
                                                }
                                                else
                                                {
                                                    decBCSS = 0;//将实收置为0，下块表再收费按用户余额收费。
                                                    decQQYE = MODELWATERFEECHARGE.CHARGEYSJSYE;
                                                    dgWaterList.Rows.Remove(dgWaterList.Rows[i]);//收费成功后移除成功的行
                                                    if (intChargeIndex == 1)
                                                    {
                                                        #region 合并打印发票
                                                        try
                                                        {
                                                            ////发票开具初始化
                                                            //bool isSuccess = FPInfoInit(this.Handle);
                                                            //if (!isSuccess)
                                                            //{
                                                            //    mes.Show("发票开具初始化失败,请重试!");
                                                            //    return;
                                                            //}
                                                            //else
                                                            //{
                                                                StringBuilder strInvTypeCodeGet = new StringBuilder();
                                                                StringBuilder strInvNumberGet = new StringBuilder();
                                                                bool ret = GetFPInfo(strInvTypeCodeGet, strInvNumberGet);
                                                                if (ret)
                                                                {
                                                                    if (strInvNumberGet.ToString() != txtInvoiceNO.Text)
                                                                    {
                                                                        if (i == intChargeCount)
                                                                        {
                                                                            mes.Show("当前发票号与税控系统发票号不一致，请设置新的发票号!" + Environment.NewLine + "设置发票号:" + txtInvoiceNO.Text + Environment.NewLine + "系统发票号:" + strInvNumberGet);
                                                                            txtInvoiceNO.SelectAll();
                                                                            return;
                                                                        }
                                                                        else
                                                                        {
                                                                            bgGetFPNO.RunWorkerAsync();
                                                                            frmWaitSearchCanCancel = new frmWaitSearchCanCancel();
                                                                            frmWaitSearchCanCancel.strTip = "准备打印第" + (i + 1).ToString() + "行，发票号为'" + txtInvoiceNO.Text + "'";
                                                                            if (frmWaitSearchCanCancel.ShowDialog() == DialogResult.Cancel)
                                                                                return;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    mes.Show("获取税控系统发票号失败,请重试!");
                                                                    return;
                                                                }
                                                            //}
                                                            MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                                                            MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID(strLogID, "CHARGEINVOICEPRINT");
                                                            MODELCHARGEINVOICEPRINTNEW.CHARGEID = MODELWATERFEECHARGE.CHARGEID;
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICENO = txtInvoiceNO.Text;
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatch.Text;
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTDATETIME = mes.GetDatetimeNow();

                                                            MODELCHARGEINVOICEPRINTNEW.waterMeterNo = strWaterMeterNO;
                                                            MODELCHARGEINVOICEPRINTNEW.waterUserName = txtWaterUserName.Text;
                                                            MODELCHARGEINVOICEPRINTNEW.waterUserAddress = txtWaterUserAddress.Text;
                                                            //MODELCHARGEINVOICEPRINTNEW.readMeterRecordYear = intReadMeterRecordYear;
                                                            //MODELCHARGEINVOICEPRINTNEW.readMeterRecordMonth = intReadMeterRecordMonth;
                                                            MODELCHARGEINVOICEPRINTNEW.waterMeterLastNumber = 0;
                                                            MODELCHARGEINVOICEPRINTNEW.waterMeterEndNumber = 0;
                                                            MODELCHARGEINVOICEPRINTNEW.totalNumber = Convert.ToInt32(txtWaterTotalNumber.Text);
                                                            MODELCHARGEINVOICEPRINTNEW.avePrice = decAvgPrcie;
                                                            MODELCHARGEINVOICEPRINTNEW.extraChargePrice1 = decExtraChargePrice1;
                                                            MODELCHARGEINVOICEPRINTNEW.extraChargePrice2 = decExtraChargePrice2;
                                                            MODELCHARGEINVOICEPRINTNEW.taxRate = 3;
                                                            MODELCHARGEINVOICEPRINTNEW.waterTotalCharge = Convert.ToDecimal(txtWaterTotalCharge.Text);
                                                            MODELCHARGEINVOICEPRINTNEW.extraCharge1 = Convert.ToDecimal(txtExtraCharge1.Text);
                                                            MODELCHARGEINVOICEPRINTNEW.extraCharge2 = Convert.ToDecimal(txtExtraCharge2.Text);
                                                            MODELCHARGEINVOICEPRINTNEW.totalCharge = Convert.ToDecimal(txtBCYS.Text) - Convert.ToDecimal(txtOverDueSum.Text);
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTWORKERID = strLogID;
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTWORKERNAME = strUserName;

                                                            if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW))
                                                            {
                                                                byte[] byNull = Encoding.Unicode.GetBytes("");
                                                                string strMemo = "本次实收:" + txtBCSS.Text + ";前期余额:" + txtYSQQYE.Text +
                                                                    ";结算余额:" + txtYSJSYE.Text + ";滞纳金:" + txtOverDueSum.Text + Environment.NewLine + "用户编号:" + txtWaterUserNO.Text +
                                                                     (txtMeterReaderTel.Text == "" ? "" : Environment.NewLine + "抄表员电话:" + txtMeterReaderTel.Text);

                                                                if (AddFPData(txtWaterUserName.Text, "", "", txtWaterUserAddress.Text + txtWaterUserPhone.Text,
                                                                    strAccountNO, strCompanyAddressAndTel, strMemo, strUserName, strCompanyChecker, strCompanyPayee, null, 2, 0))
                                                                {
                                                                    if (MXInfoInit())
                                                                    {
                                                                        byte[] byShuiFei = Encoding.Unicode.GetBytes("水费");
                                                                        byte[] byUnit = Encoding.Unicode.GetBytes("吨");
                                                                        //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decAvePrice) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decAvePrice) / 1.03, 3, 0, Convert.ToDouble(decAvePrice) * Convert.ToDouble(intTotalNumber)))
                                                                        if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(txtWaterTotalNumber.Text), 0, Convert.ToDouble(txtWaterTotalCharge.Text), 3, 1, 0))
                                                                        {

                                                                        }
                                                                        else
                                                                        {
                                                                            mes.Show("添加发票明细'水费'错误,请重试!");
                                                                            //回滚发票记录
                                                                            BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                            return;
                                                                        }
                                                                        if (Convert.ToDecimal(txtExtraCharge2.Text) > 0)
                                                                        {
                                                                            byte[] byFujiaFei = Encoding.Unicode.GetBytes("附加费");
                                                                            if (AddMXData(byFujiaFei, byNull, byUnit, Convert.ToDouble(txtWaterTotalNumber.Text), 0, Convert.ToDouble(txtExtraCharge2.Text), 3, 1, 0))
                                                                            //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice2) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice2) * Convert.ToDouble(intTotalNumber)))
                                                                            //if (AddMXData(byFujiaFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, 0, 3, 0, 0))
                                                                            {

                                                                            }
                                                                            else
                                                                            {
                                                                                mes.Show("添加发票明细'附加费'错误,请重试!");
                                                                                //回滚发票记录
                                                                                BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                                return;
                                                                            }
                                                                        }
                                                                        if (Convert.ToDecimal(txtExtraCharge1.Text) > 0)
                                                                        {
                                                                            byte[] byWuShuiChuLiFei = Encoding.Unicode.GetBytes("污水处理费");
                                                                            if (AddMXData(byWuShuiChuLiFei, byNull, byUnit, Convert.ToDouble(txtWaterTotalNumber.Text), 0, Convert.ToDouble(txtExtraCharge1.Text), 3, 1, 0))
                                                                            //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice1) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice1) * Convert.ToDouble(intTotalNumber)))
                                                                            //if (AddMXData(byWuShuiChuLiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, 0, 3, 0, 0))
                                                                            {
                                                                            }
                                                                            else
                                                                            {
                                                                                mes.Show("添加发票明细'污水处理费'错误,请重试!");
                                                                                //回滚发票记录
                                                                                BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                                return;
                                                                            }
                                                                        }
                                                                        StringBuilder strInvTypeCode = new StringBuilder();
                                                                        StringBuilder strInvNumber = new StringBuilder();
                                                                        if (!FPInvoice(strInvTypeCode, strInvNumber))
                                                                        {
                                                                            mes.Show("发票填开错误,请从税控软件里手动打印号码为'" + txtInvoiceNO + "'的发票!");
                                                                            //回滚发票记录
                                                                            BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                            return;
                                                                        }
                                                                        CloseInvKey();
                                                                    }
                                                                    else
                                                                    {
                                                                        mes.Show("发票明细初始化错误,请重试!");
                                                                        //回滚发票记录
                                                                        BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    mes.Show("发票添加错误,请重试!");
                                                                    //回滚发票记录
                                                                    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                    return;
                                                                }
                                                                //txtInvoiceNO.Text = (Convert.ToInt64(txtInvoiceNO.Text) + 1).ToString().PadLeft(8, '0');
                                                            }
                                                            else
                                                            {
                                                                mes.Show("发票打印记录添加失败!请补打发票!");
                                                                return;
                                                            }
                                                        }
                                                        catch (Exception exx)
                                                        {
                                                            mes.Show("打印第'" + (i + 1).ToString() + "'行发票时失败,请使用'补打发票'功能打印此行发票。\n原因:" + exx.ToString());
                                                            log.Write(exx.ToString(), MsgType.Error);
                                                            return;
                                                        }

                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                                                            MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID(strLogID, "CHARGEINVOICEPRINT");
                                                            MODELCHARGEINVOICEPRINTNEW.CHARGEID = MODELWATERFEECHARGE.CHARGEID;
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICENO = txtInvoiceNO.Text;
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatch.Text;
                                                            MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTDATETIME = mes.GetDatetimeNow();

                                                            MODELCHARGEINVOICEPRINTNEW.waterMeterNo = strWaterMeterNO;
                                                            MODELCHARGEINVOICEPRINTNEW.waterUserName = txtWaterUserName.Text;
                                                            MODELCHARGEINVOICEPRINTNEW.waterUserAddress = txtWaterUserAddress.Text;
                                                            //MODELCHARGEINVOICEPRINTNEW.readMeterRecordYear = intReadMeterRecordYear;
                                                            //MODELCHARGEINVOICEPRINTNEW.readMeterRecordMonth = intReadMeterRecordMonth;
                                                            MODELCHARGEINVOICEPRINTNEW.waterMeterLastNumber = 0;
                                                            MODELCHARGEINVOICEPRINTNEW.waterMeterEndNumber = 0;
                                                            MODELCHARGEINVOICEPRINTNEW.totalNumber = Convert.ToInt32(txtWaterTotalNumber.Text);
                                                            MODELCHARGEINVOICEPRINTNEW.avePrice = decAvgPrcie;
                                                            MODELCHARGEINVOICEPRINTNEW.extraChargePrice1 = decExtraChargePrice1;
                                                            MODELCHARGEINVOICEPRINTNEW.extraChargePrice2 = decExtraChargePrice2;
                                                            MODELCHARGEINVOICEPRINTNEW.taxRate = 3;
                                                            MODELCHARGEINVOICEPRINTNEW.waterTotalCharge = Convert.ToDecimal(txtWaterTotalCharge.Text);
                                                            MODELCHARGEINVOICEPRINTNEW.extraCharge1 = Convert.ToDecimal(txtExtraCharge1.Text);
                                                            MODELCHARGEINVOICEPRINTNEW.extraCharge2 = Convert.ToDecimal(txtExtraCharge2.Text);
                                                            MODELCHARGEINVOICEPRINTNEW.totalCharge = Convert.ToDecimal(txtBCYS.Text) - Convert.ToDecimal(txtOverDueSum.Text);

                                                            if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW))
                                                            {

                                                            }
                                                        }
                                                        catch (Exception exInsertChargeInvoice)
                                                        {
                                                            mes.Show("记录发票号失败,请补登发票号!");
                                                        }
                                                    }
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
                            }
                            else
                            {
                                mes.Show("第" + (i + 1).ToString() + "行抄表记录编号为空，请重新查询欠费信息后重试!");
                                dgWaterList.CurrentCell = dgWaterList.Rows[i].Cells["waterUserName"];
                                return;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 按水表收费

                    //存储收费表,打印收据用
                    DataTable dtRecord = ((DataTable)(dgWaterList.DataSource)).Clone();
                    DateTime dtChargeDateTime = mes.GetDatetimeNow();

                    //本次实收
                    decimal decBCSS = Convert.ToDecimal(txtBCSS.Text);
                    //前期余额
                    decimal decQQYE = Convert.ToDecimal(txtYSQQYE.Text);
                    //本次收支,结算余额
                    decimal decBCSZ = 0, decJSYE = 0;

                    //更新抄表表收费状态
                    int intChargeCount = dgWaterList.Rows.Count - 1;//将总行数保存下来，打印发票时判断是不是第一次打印，如果是提示发票号不一致
                    for (int i = intChargeCount; i >= 0; i--)
                    {
                        DataGridViewCheckBoxCell chkcell = (DataGridViewCheckBoxCell)dgWaterList.Rows[i].Cells["cellSelect"];
                        bool isChecked = Convert.ToBoolean(chkcell.EditedFormattedValue);
                        if (isChecked)
                        {
                            object objReadMeterRecordID = dgWaterList.Rows[i].Cells["readMeterRecordId"].Value;
                            if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
                            {
                                string strIsCharge = " AND readMeterRecordId='" + objReadMeterRecordID.ToString() + "'";
                                DataTable dtCharge = BLLWATERFEECHARGE.QueryLS(strIsCharge);
                                if (dtCharge.Rows.Count > 0)
                                {
                                    mes.Show("第'" + (i + 1).ToString() + "行'抄表记录已经收费，请重新查询后再收费!");
                                    return;
                                }

                                //水表编号
                                string strWaterMeterNO = "", strPianNO = "", strWaterUserTel = "", strWaterUserTaxNO = "", strWaterUserBankAccountNO = "";
                                //用水量
                                int intWaterTotalNumber = 0, intLastNumber = 0, intEndNumber = 0;
                                //水费小计，污水处理费，附加费，污水处理费总计，滞纳金，水费合计
                                decimal decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decExtraTotalCharge = 0, decOverDueMoney = 0, decTotalCharge = 0, decTotalChargeEnd = 0,
                                    decAvgPrcie = 0, decExtraChargePrice1 = 0, decExtraChargePrice2 = 0;

                                object objWaterMeterNO = dgWaterList.Rows[i].Cells["waterMeterNo"].FormattedValue;
                                if (objWaterMeterNO != null && objWaterMeterNO != DBNull.Value)
                                {
                                    strWaterMeterNO = objWaterMeterNO.ToString();
                                }

                                object objWaterLastNumber = dgWaterList.Rows[i].Cells["waterMeterLastNumber"].FormattedValue;
                                if (Information.IsNumeric(objWaterLastNumber))
                                {
                                    intLastNumber = Convert.ToInt32(objWaterLastNumber);
                                }

                                object objWaterEndNumber = dgWaterList.Rows[i].Cells["waterMeterEndNumber"].FormattedValue;
                                if (Information.IsNumeric(objWaterEndNumber))
                                {
                                    intEndNumber = Convert.ToInt32(objWaterEndNumber);
                                }

                                object objWaterTotalNumber = dgWaterList.Rows[i].Cells["totalNumber"].FormattedValue;
                                if (Information.IsNumeric(objWaterTotalNumber))
                                {
                                    intWaterTotalNumber = Convert.ToInt32(objWaterTotalNumber);
                                }

                                object objWaterTotalCharge = dgWaterList.Rows[i].Cells["waterTotalChargeEND"].FormattedValue;
                                if (Information.IsNumeric(objWaterTotalCharge))
                                {
                                    decWaterTotalCharge = Convert.ToDecimal(objWaterTotalCharge);
                                }

                                object objExtraCharge1 = dgWaterList.Rows[i].Cells["extraCharge1"].FormattedValue;
                                if (Information.IsNumeric(objExtraCharge1))
                                {
                                    decExtraCharge1 = Convert.ToDecimal(objExtraCharge1);
                                }

                                object objExtraCharge2 = dgWaterList.Rows[i].Cells["extraCharge2"].FormattedValue;
                                if (Information.IsNumeric(objExtraCharge2))
                                {
                                    decExtraCharge2 = Convert.ToDecimal(objExtraCharge2);
                                }

                                object objExtraTotalCharge = dgWaterList.Rows[i].Cells["extraTotalChargeEND"].FormattedValue;
                                if (Information.IsNumeric(objExtraTotalCharge))
                                {
                                    decExtraTotalCharge = Convert.ToDecimal(objExtraTotalCharge);
                                }

                                object objOverDueMoney = dgWaterList.Rows[i].Cells["OVERDUEEND"].FormattedValue;
                                if (Information.IsNumeric(objOverDueMoney))
                                {
                                    decOverDueMoney = Convert.ToDecimal(objOverDueMoney);
                                }

                                object objTotalCharge = dgWaterList.Rows[i].Cells["totalCharge"].FormattedValue;
                                if (Information.IsNumeric(objTotalCharge))
                                {
                                    decTotalCharge = Convert.ToDecimal(objTotalCharge);
                                }

                                object objTotalChargeEnd = dgWaterList.Rows[i].Cells["totalChargeEND"].FormattedValue;
                                if (Information.IsNumeric(objTotalChargeEnd))
                                {
                                    decTotalChargeEnd = Convert.ToDecimal(objTotalChargeEnd);
                                }

                                object objAvgPrice = dgWaterList.Rows[i].Cells["avePrice"].FormattedValue;
                                if (Information.IsNumeric(objAvgPrice))
                                {
                                    decAvgPrcie = Convert.ToDecimal(objAvgPrice);
                                }

                                object objExtraChargePrice1 = dgWaterList.Rows[i].Cells["extraChargePrice1"].FormattedValue;
                                if (Information.IsNumeric(objExtraChargePrice1))
                                {
                                    decExtraChargePrice1 = Convert.ToDecimal(objExtraChargePrice1);
                                }

                                object objExtraChargePrice2 = dgWaterList.Rows[i].Cells["extraChargePrice2"].FormattedValue;
                                if (Information.IsNumeric(objExtraChargePrice2))
                                {
                                    decExtraChargePrice2 = Convert.ToDecimal(objExtraChargePrice2);
                                    if (decExtraChargePrice2 > 0)
                                        decExtraChargePrice2 = decAvgPrcie * (decimal)0.1;
                                }

                                object objPianNO = dgWaterList.Rows[i].Cells["pianNO"].FormattedValue;
                                if (objPianNO!=null&&objPianNO!=DBNull.Value)
                                {
                                    strPianNO = objPianNO.ToString();
                                }

                                MODELWATERFEECHARGE MODELWATERFEECHARGE = new MODELWATERFEECHARGE();
                                MODELWATERFEECHARGE.CHARGEID = GETTABLEID.GetTableID(strLogID, "WATERFEECHARGE");
                                MODELWATERFEECHARGE.TOTALNUMBERCHARGE = intWaterTotalNumber;
                                MODELWATERFEECHARGE.WATERTOTALCHARGE = decWaterTotalCharge;
                                MODELWATERFEECHARGE.EXTRACHARGECHARGE1 = decExtraCharge1;
                                MODELWATERFEECHARGE.EXTRACHARGECHARGE2 = decExtraCharge2;
                                MODELWATERFEECHARGE.EXTRATOTALCHARGE = decExtraTotalCharge;
                                MODELWATERFEECHARGE.OVERDUEMONEY = decOverDueMoney;
                                MODELWATERFEECHARGE.TOTALCHARGE = decTotalChargeEnd;
                                MODELWATERFEECHARGE.CHARGETYPEID = cmbChargeType.SelectedValue.ToString();
                                if (cmbChargeType.SelectedValue.ToString() == "2")
                                {
                                    MODELWATERFEECHARGE.POSRUNNINGNO = txtJYLSH.Text;
                                }
                                MODELWATERFEECHARGE.CHARGEClASS = "1";//收费类型是正常收取
                                MODELWATERFEECHARGE.CHARGEBCYS = decTotalChargeEnd;
                                MODELWATERFEECHARGE.CHARGEBCSS = decBCSS;
                                MODELWATERFEECHARGE.CHARGEYSQQYE = decQQYE;
                                MODELWATERFEECHARGE.CHARGEYSBCSZ = MODELWATERFEECHARGE.CHARGEBCSS - MODELWATERFEECHARGE.CHARGEBCYS;
                                MODELWATERFEECHARGE.CHARGEYSJSYE = decBCSS + decQQYE - MODELWATERFEECHARGE.CHARGEBCYS;
                                MODELWATERFEECHARGE.CHARGEWORKERID = strLogID;
                                MODELWATERFEECHARGE.CHARGEWORKERNAME = strUserName;
                                MODELWATERFEECHARGE.CHARGEDATETIME = dtChargeDateTime;
                                MODELWATERFEECHARGE.INVOICEPRINTSIGN = "0";
                                MODELWATERFEECHARGE.MEMO = txtMemo.Text;
                                try
                                {
                                    bool isInsertWaterFeeChargeSuccess = false;
                                    if (rbPrintReceipt.Checked)
                                    {
                                        MODELWATERFEECHARGE.RECEIPTPRINTCOUNT = 1;
                                        MODELWATERFEECHARGE.RECEIPTNO = txtReceiptNO.Text;
                                        isInsertWaterFeeChargeSuccess = BLLWATERFEECHARGE.InsertSJ(MODELWATERFEECHARGE);
                                    }
                                    else if (rbInvoiceSinglePrint.Checked)
                                    {
                                        MODELWATERFEECHARGE.INVOICEPRINTSIGN = "1";
                                        isInsertWaterFeeChargeSuccess = BLLWATERFEECHARGE.InsertFP(MODELWATERFEECHARGE);
                                    }
                                    if (isInsertWaterFeeChargeSuccess)
                                    {
                                        try
                                        {
                                            MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                                            MODELreadMeterRecord.chargeState = "3";
                                            MODELreadMeterRecord.chargeID = MODELWATERFEECHARGE.CHARGEID;

                                            //把未减免前的滞纳金保存到抄表记录表里
                                            object objOVERDUEGET = dgWaterList.Rows[i].Cells["OVERDUEGET"].FormattedValue;
                                            if (Information.IsNumeric(objOVERDUEGET))
                                                MODELreadMeterRecord.OVERDUEMONEY = Convert.ToDecimal(objOVERDUEGET);

                                            MODELreadMeterRecord.readMeterRecordId = objReadMeterRecordID.ToString();
                                            if (BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord))
                                            {
                                                try
                                                {
                                                    string strUpdatePrestore = "UPDATE waterUser SET prestore=" + MODELWATERFEECHARGE.CHARGEYSJSYE + " WHERE waterUserId='" + txtWaterUserID.Text + "'";
                                                    if (!BLLwaterUser.UpdateSQL(strUpdatePrestore))
                                                    {
                                                        //回滚收费记录
                                                        BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                                        //回滚收费标志记录
                                                        MODELreadMeterRecord.chargeState = "1";
                                                        MODELreadMeterRecord.chargeID = null;
                                                        MODELreadMeterRecord.OVERDUEMONEY = 0;
                                                        MODELreadMeterRecord.readMeterRecordId = objReadMeterRecordID.ToString();
                                                        BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);

                                                        string strError = "更新用户编号为'" + txtWaterUserID.Text + "'的余额失败!/n请查询用户余额是否正确后重新收费!";
                                                        mes.Show(strError);
                                                        log.Write(strError, MsgType.Error);
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            decBCSS = 0;//将实收置为0，下块表再收费按用户余额收费。
                                                            decQQYE = MODELWATERFEECHARGE.CHARGEYSJSYE;
                                                            dtRecord.ImportRow((dgWaterList.Rows[i].DataBoundItem as DataRowView).Row);

                                                            dgWaterList.Rows.Remove(dgWaterList.Rows[i]);//收费成功后移除成功的行
                                                        }
                                                        catch (Exception exx)
                                                        {
                                                            string strError = exx.Message;
                                                            mes.Show(strError);
                                                            log.Write(strError, MsgType.Error);
                                                            return;
                                                        }

                                                        if (rbInvoiceSinglePrint.Checked)
                                                        {
                                                            #region 单打发票
                                                            try
                                                            {
                                                                //发票开具初始化
                                                                bool isSuccess = FPInfoInit(this.Handle);
                                                                if (!isSuccess)
                                                                {
                                                                    mes.Show("发票开具初始化失败,请重试!");
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    StringBuilder strInvTypeCode = new StringBuilder();
                                                                    StringBuilder strInvNumber = new StringBuilder();
                                                                    bool ret = GetFPInfo(strInvTypeCode, strInvNumber);
                                                                    if (ret)
                                                                    {
                                                                        if (strInvNumber.ToString() != txtInvoiceNO.Text)
                                                                        {
                                                                            if (i == intChargeCount)
                                                                            {
                                                                                mes.Show("当前发票号与税控系统发票号不一致，请设置新的发票号!" + Environment.NewLine + "设置发票号:" + txtInvoiceNO.Text + Environment.NewLine + "系统发票号:" + strInvNumber);
                                                                                txtInvoiceNO.SelectAll();
                                                                                return;
                                                                            }
                                                                            else
                                                                            {
                                                                                bgGetFPNO.RunWorkerAsync();
                                                                                frmWaitSearchCanCancel = new frmWaitSearchCanCancel();
                                                                                frmWaitSearchCanCancel.strTip = "准备打印第" + (i + 1).ToString() + "行，发票号为'" + txtInvoiceNO.Text + "'";
                                                                                if (frmWaitSearchCanCancel.ShowDialog() == DialogResult.Cancel)
                                                                                    return;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        mes.Show("获取税控系统发票号失败,请重试!");
                                                                        return;
                                                                    }
                                                                } 
                                                                
                                                                DataTable dtWaterUserMes = BLLwaterUser.QueryUser(" AND WATERUSERID='" + txtWaterUserID.Text + "'");
                                                                if (dtWaterUserMes.Rows.Count > 0)
                                                                {
                                                                    object objWaterUserMes = dtWaterUserMes.Rows[0]["waterPhone"];
                                                                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                                                                    {
                                                                        strWaterUserTel = objWaterUserMes.ToString();
                                                                    }
                                                                    objWaterUserMes = dtWaterUserMes.Rows[0]["FPTaxNO"];
                                                                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                                                                    {
                                                                        strWaterUserTaxNO = objWaterUserMes.ToString();
                                                                    }
                                                                    objWaterUserMes = dtWaterUserMes.Rows[0]["FPBankNameAndAccountNO"];
                                                                    if (objWaterUserMes != null && objWaterUserMes != DBNull.Value)
                                                                    {
                                                                        strWaterUserBankAccountNO = objWaterUserMes.ToString();
                                                                    }
                                                                    objWaterUserMes = dtWaterUserMes.Rows[0]["prestore"];
                                                                    if (Information.IsNumeric(objWaterUserMes))
                                                                    {
                                                                        decQQYE = Convert.ToDecimal(objWaterUserMes);
                                                                    }
                                                                }
                                                                MODELCHARGEINVOICEPRINT MODELCHARGEINVOICEPRINTNEW = new MODELCHARGEINVOICEPRINT();
                                                                MODELCHARGEINVOICEPRINTNEW.CHARGEINVOICEPRINTID = GETTABLEID.GetTableID(strLogID, "CHARGEINVOICEPRINT");
                                                                MODELCHARGEINVOICEPRINTNEW.CHARGEID = MODELWATERFEECHARGE.CHARGEID;
                                                                MODELCHARGEINVOICEPRINTNEW.INVOICECANCEL = "0";
                                                                MODELCHARGEINVOICEPRINTNEW.INVOICENO = txtInvoiceNO.Text;
                                                                MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHID = cmbBatch.SelectedValue.ToString();
                                                                MODELCHARGEINVOICEPRINTNEW.INVOICEBATCHNAME = cmbBatch.Text;
                                                                MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTDATETIME = mes.GetDatetimeNow();

                                                                MODELCHARGEINVOICEPRINTNEW.waterMeterNo = strWaterMeterNO;
                                                                MODELCHARGEINVOICEPRINTNEW.waterUserName = txtWaterUserName.Text;
                                                                MODELCHARGEINVOICEPRINTNEW.waterUserAddress = txtWaterUserAddress.Text;
                                                                //MODELCHARGEINVOICEPRINTNEW.readMeterRecordYear = intReadMeterRecordYear;
                                                                //MODELCHARGEINVOICEPRINTNEW.readMeterRecordMonth = intReadMeterRecordMonth;
                                                                MODELCHARGEINVOICEPRINTNEW.waterMeterLastNumber = intLastNumber;
                                                                MODELCHARGEINVOICEPRINTNEW.waterMeterEndNumber = intEndNumber;
                                                                MODELCHARGEINVOICEPRINTNEW.totalNumber = intWaterTotalNumber;
                                                                MODELCHARGEINVOICEPRINTNEW.avePrice = decAvgPrcie;
                                                                MODELCHARGEINVOICEPRINTNEW.extraChargePrice1 = decExtraChargePrice1;
                                                                MODELCHARGEINVOICEPRINTNEW.extraChargePrice2 = decExtraChargePrice2;
                                                                MODELCHARGEINVOICEPRINTNEW.taxRate = 3;
                                                                MODELCHARGEINVOICEPRINTNEW.waterTotalCharge = decWaterTotalCharge;
                                                                MODELCHARGEINVOICEPRINTNEW.extraCharge1 = decExtraCharge1;
                                                                MODELCHARGEINVOICEPRINTNEW.extraCharge2 = decExtraCharge2;
                                                                MODELCHARGEINVOICEPRINTNEW.totalCharge = decTotalCharge;
                                                                MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTWORKERID = strLogID;
                                                                MODELCHARGEINVOICEPRINTNEW.INVOICEPRINTWORKERNAME = strUserName;

                                                                if (BLLCHARGEINVOICEPRINT.Insert(MODELCHARGEINVOICEPRINTNEW))
                                                                {
                                                                    byte[] byNull = Encoding.Unicode.GetBytes("");
                                                                    string strMemo="";
                                                                    if (strPianNO.Contains("企事业"))
                                                                        strMemo = "本次实收:" + MODELWATERFEECHARGE.CHARGEBCSS + ";前期余额:" + MODELWATERFEECHARGE.CHARGEYSQQYE +
                                                                            ";结算余额:" + MODELWATERFEECHARGE.CHARGEYSJSYE + ";滞纳金:" + decOverDueMoney + Environment.NewLine + "用户编号:" + txtWaterUserNO.Text +
                                                                            ";" +
                                                                             (txtMeterReaderTel.Text == "" ? "" : Environment.NewLine + "抄表员电话:" + txtMeterReaderTel.Text);

                                                                    else
                                                                    strMemo = "本次实收:" + MODELWATERFEECHARGE.CHARGEBCSS + ";前期余额:" + MODELWATERFEECHARGE.CHARGEYSQQYE +
                                                                        ";结算余额:" + MODELWATERFEECHARGE.CHARGEYSJSYE + ";滞纳金:" + decOverDueMoney + Environment.NewLine + "用户编号:" + txtWaterUserNO.Text +
                                                                        ";上期读数:" + intLastNumber + ";本期读数:" + intEndNumber +
                                                                         (txtMeterReaderTel.Text == "" ? "" : Environment.NewLine + "抄表员电话:" + txtMeterReaderTel.Text);

                                                                    if (AddFPData(txtWaterUserName.Text, strWaterUserTaxNO, strWaterUserBankAccountNO, txtWaterUserAddress.Text + strWaterUserTel, strAccountNO, strCompanyAddressAndTel, strMemo, strUserName, null, null, null, 2, 0))
                                                                    {
                                                                        if (MXInfoInit())
                                                                        {
                                                                            byte[] byShuiFei = Encoding.Unicode.GetBytes("水费");
                                                                            byte[] byUnit = Encoding.Unicode.GetBytes("吨");
                                                                            //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decAvePrice) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decAvePrice) / 1.03, 3, 0, Convert.ToDouble(decAvePrice) * Convert.ToDouble(intTotalNumber)))
                                                                            if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intWaterTotalNumber), 0, (double)decWaterTotalCharge, 3, 1, 0))
                                                                            {

                                                                            }
                                                                            else
                                                                            {
                                                                                mes.Show("添加发票明细'水费'错误,请重试!");
                                                                                //回滚发票记录
                                                                                BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                                return;
                                                                            }
                                                                            if (decExtraCharge2 > 0)
                                                                            {
                                                                                byte[] byFujiaFei = Encoding.Unicode.GetBytes("附加费");
                                                                                if (AddMXData(byFujiaFei, byNull, byUnit, Convert.ToDouble(intWaterTotalNumber), 0, (double)decExtraCharge2, 3, 1, 0))
                                                                                //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice2) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice2) * Convert.ToDouble(intTotalNumber)))
                                                                                //if (AddMXData(byFujiaFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice2) / 1.03, 0, 3, 0, 0))
                                                                                {

                                                                                }
                                                                                else
                                                                                {
                                                                                    mes.Show("添加发票明细'附加费'错误,请重试!");
                                                                                    //回滚发票记录
                                                                                    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                                    return;
                                                                                }
                                                                            }
                                                                            if (decExtraCharge1 > 0)
                                                                            {
                                                                                byte[] byWuShuiChuLiFei = Encoding.Unicode.GetBytes("污水处理费");
                                                                                if (AddMXData(byWuShuiChuLiFei, byNull, byUnit, Convert.ToDouble(intWaterTotalNumber), 0, (double)decExtraCharge1, 3, 1, 0))
                                                                                //if (AddMXData(byShuiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, Convert.ToDouble(intTotalNumber) * Convert.ToDouble(decExtraChargePrice1) / 1.03, 3, 0, Convert.ToDouble(decExtraChargePrice1) * Convert.ToDouble(intTotalNumber)))
                                                                                //if (AddMXData(byWuShuiChuLiFei, byNull, byUnit, Convert.ToDouble(intTotalNumber), Convert.ToDouble(decExtraChargePrice1) / 1.03, 0, 3, 0, 0))
                                                                                {
                                                                                }
                                                                                else
                                                                                {
                                                                                    mes.Show("添加发票明细'污水处理费'错误,请重试!");
                                                                                    //回滚发票记录
                                                                                    BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                                    return;
                                                                                }
                                                                            }
                                                                            StringBuilder strInvTypeCode = new StringBuilder();
                                                                            StringBuilder strInvNumber = new StringBuilder();
                                                                            if (!FPInvoice(strInvTypeCode, strInvNumber))
                                                                            {
                                                                                mes.Show("发票填开错误,请从税控软件里手动打印号码为'" + txtInvoiceNO + "'的发票!");
                                                                                //回滚发票记录
                                                                                BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                                return;
                                                                            }
                                                                            CloseInvKey();
                                                                        }
                                                                        else
                                                                        {
                                                                            mes.Show("发票明细初始化错误,请重试!");
                                                                            //回滚发票记录
                                                                            BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                            return;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        mes.Show("发票添加错误,请重试!");
                                                                        //回滚发票记录
                                                                        BLLCHARGEINVOICEPRINT.Delete(MODELCHARGEINVOICEPRINTNEW.CHARGEID);
                                                                        return;
                                                                    }
                                                                    txtInvoiceNO.Text = (Convert.ToInt64(txtInvoiceNO.Text) + 1).ToString().PadLeft(8, '0');
                                                                }
                                                                else
                                                                {
                                                                    mes.Show("发票打印记录添加失败!请补打发票!");
                                                                    return;
                                                                }
                                                            }
                                                            catch (Exception exx)
                                                            {
                                                                mes.Show("打印第'" + (i + 1).ToString() + "'行发票时失败,请补打发票。\n原因:" + exx.ToString());
                                                                log.Write(exx.ToString(), MsgType.Error);
                                                                return;
                                                            }

                                                            #endregion
                                                        }
                                                    }
                                                }
                                                catch (Exception exUpdateWaterUserPrestore)
                                                {
                                                    //回滚收费记录
                                                    BLLWATERFEECHARGE.Delete(MODELWATERFEECHARGE.CHARGEID);
                                                    //回滚收费标志记录
                                                    MODELreadMeterRecord.chargeState = "1";
                                                    MODELreadMeterRecord.chargeID = null;
                                                    MODELreadMeterRecord.OVERDUEMONEY = 0;
                                                    MODELreadMeterRecord.readMeterRecordId = objReadMeterRecordID.ToString();
                                                    BLLreadMeterRecord.UpdateChargeState(MODELreadMeterRecord);

                                                    string strError = "更新用户编号为'" + txtWaterUserID.Text + "'的余额失败,原因:" + exUpdateWaterUserPrestore.Message;
                                                    mes.Show(strError);
                                                    log.Write(exUpdateWaterUserPrestore.ToString(), MsgType.Error);
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
                            }
                            else
                            {
                                mes.Show("第" + (i + 1).ToString() + "行抄表记录编号为空，请重新查询欠费信息后重试!");
                                dgWaterList.CurrentCell = dgWaterList.Rows[i].Cells["waterUserName"];
                                return;
                            }
                        }
                    }
                    #endregion
                    if (rbPrintReceipt.Checked)
                    {
                        #region 打印收据
                        DataSet ds = new DataSet();
                        DataTable dtRecordTemp = dtRecord.Clone();
                        dtRecordTemp.Columns["readMeterRecordYearAndMonth"].DataType = typeof(string);
                        int intPrintCount = dtRecord.Rows.Count;
                        if (intPrintCount > 6)
                            intPrintCount = 6;
                        for (int i = 0; i < intPrintCount;i++ )
                            {
                                dtRecordTemp.ImportRow(dtRecord.Rows[i]);
                            }
                        for (int i = 0; i < dtRecordTemp.Rows.Count; i++)
                        {
                            object obj = dtRecordTemp.Rows[i]["readMeterRecordYearAndMonth"];
                            if (Information.IsDate(obj))
                                dtRecordTemp.Rows[i]["readMeterRecordYearAndMonth"] = Convert.ToDateTime(obj).ToString("yyyy-MM");
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

                            (report1.FindObject("txtDateTime") as FastReport.TextObject).Text = dtChargeDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            (report1.FindObject("CellWaterUserNO") as FastReport.Table.TableCell).Text = txtWaterUserNO.Text;
                            (report1.FindObject("CellWaterUserName") as FastReport.Table.TableCell).Text = txtWaterUserName.Text;
                            (report1.FindObject("CellWaterUserAddress") as FastReport.Table.TableCell).Text = txtWaterUserAddress.Text;
                            (report1.FindObject("txtOverDue") as FastReport.TextObject).Text = "滞纳金:" + Convert.ToDecimal(txtOverDueSum.Text).ToString("F2");
                            (report1.FindObject("txtQQYE") as FastReport.TextObject).Text = "前期余额:" + Convert.ToDecimal(txtYSQQYE.Text).ToString("F2");
                            (report1.FindObject("txtBCSF") as FastReport.TextObject).Text = "水费合计:" + Convert.ToDecimal(txtBCYS.Text).ToString("F2");
                            string strBCSS = Convert.ToDecimal(txtBCSS.Text).ToString("F2");
                            (report1.FindObject("txtBCJF") as FastReport.TextObject).Text = "本次实收:    " + strBCSS;
                            (report1.FindObject("txtJSYE") as FastReport.TextObject).Text = "结算余额:" + Convert.ToDecimal(txtYSJSYE.Text).ToString("F2");
                            if (dtRecord.Rows.Count>intPrintCount)
                                (report1.FindObject("txtTip") as FastReport.TextObject).Text = "如需更多明细,请与客服人员联系索要";

                            (report1.FindObject("txtReceiptNO") as FastReport.TextObject).Text = "NO."+txtReceiptNO.Text;
                            (report1.FindObject("txtMeterReader") as FastReport.TextObject).Text = txtMeterReader.Text;
                            (report1.FindObject("txtMeterReaderTel") as FastReport.TextObject).Text = txtMeterReaderTel.Text;
                            (report1.FindObject("txtChargeWorkerName") as FastReport.TextObject).Text = strUserName;

                            string strCapMoney = RMBToCapMoney.CmycurD(strBCSS);
                            if (cmbChargeType.SelectedValue.ToString() == "2")
                            {
                                (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:"+strCapMoney + Environment.NewLine + "交易流水号:" + txtJYLSH.Text;
                            }
                            else
                                (report1.FindObject("txtCapMoney") as FastReport.TextObject).Text = "金额大写:" + strCapMoney;
                            // register the dataset
                            report1.RegisterData(ds);
                            report1.GetDataSource("营业坐收收据模板").Enabled = true;
                            //report1.Show();
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
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
        }
        /// <summary>
        /// 方法实现把dgv里的数据完整的复制到一张内存表
        /// </summary>
        /// <param name="dgv">dgv控件作为参数</param>
        /// <returns>返回临时内存表</returns>
        public static DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    object obj = dgv.Rows[count].Cells[countsub].Value;
                    if (obj != null && obj!=DBNull.Value)
                    dr[countsub] = dgv.Rows[count].Cells[countsub].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void dgWaterList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgWaterList.IsCurrentCellDirty)
            {
                dgWaterList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgWaterList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgWaterList.Columns[e.ColumnIndex].Name == "cellSelect")
            {
                dgWaterList.EndEdit();
                //txtWaterUserNO.Focus();

                txtWaterFee.Text = "0";
                txtOverDueSum.Text = "0";


                decimal decWaterFee = 0, decOverDueSum = 0, decTotalCharge = 0, decExtraTotalCharge = 0, decWaterTotalCharge = 0, decExtraCharge1 = 0, decExtraCharge2 = 0;
                int intWaterTotalNumber = 0;

                for (int i = 0; i < dgWaterList.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chkcell = (DataGridViewCheckBoxCell)dgWaterList.Rows[i].Cells["cellSelect"];
                    bool isChecked = Convert.ToBoolean(chkcell.EditedFormattedValue);
                    if (isChecked)
                    {
                        #region 计算用水量小计
                        object objWaterTotalNumber = dgWaterList.Rows[i].Cells["totalNumber"].Value;//减免后的水费小计
                        if (Information.IsNumeric(objWaterTotalNumber))
                            intWaterTotalNumber += Convert.ToInt32(objWaterTotalNumber);
                        #endregion

                        #region 计算污水处理费小计
                        object objExtraCharge1 = dgWaterList.Rows[i].Cells["extraCharge1"].Value;//减免后的水费小计
                        if (Information.IsNumeric(objExtraCharge1))
                            decExtraCharge1 += Convert.ToDecimal(objExtraCharge1);
                        #endregion

                        #region 计算附加费小计
                        object objExtraCharge2 = dgWaterList.Rows[i].Cells["extraCharge2"].Value;//减免后的水费小计
                        if (Information.IsNumeric(objExtraCharge2))
                            decExtraCharge2 += Convert.ToDecimal(objExtraCharge2);
                        #endregion

                        #region 计算滞纳金,目前只做了滞纳金从指定日期开始收取功能，未做从多少天后开始收取功能。
                        /*
                        object objWaterUserType = dgWaterList.Rows[i].Cells["waterUserTypeId"].Value;
                        if (objWaterUserType != null && objWaterUserType != DBNull.Value)
                        {
                            DataTable dtOverDueCharge = BLLwaterUserType.Query(" AND waterUserTypeId='" + objWaterUserType.ToString() + "'");
                            if (dtOverDueCharge.Rows.Count > 0)
                            {
                                DateTime dtNow = mes.GetDatetimeNow();
                                DateTime dtOverDueStartDate = dtNow;//滞纳金计算开始的日期
                                DateTime dtWaterCheckDate = dtNow;//水费审核日期
                                object objWaterCheckDate = dgWaterList.Rows[i].Cells["checkDateTime"].Value;
                                if (objWaterCheckDate != null && objWaterCheckDate != DBNull.Value)
                                {
                                    dtWaterCheckDate = Convert.ToDateTime(objWaterCheckDate);
                                }

                                object objOverDue = dtOverDueCharge.Rows[0]["overDuechargeEnable"];
                                if (objWaterUserType != null && objWaterUserType != DBNull.Value)
                                {
                                    if (objOverDue.ToString() == "1")
                                    {
                                        string strOverDueChargeStartMonth = "", strOverDueChargeStartDay = "";
                                        objOverDue = dtOverDueCharge.Rows[0]["overDuechargeStartMonth"];
                                        if (objOverDue != null && objOverDue != DBNull.Value)
                                        {
                                            strOverDueChargeStartMonth = objOverDue.ToString();
                                        }
                                        objOverDue = dtOverDueCharge.Rows[0]["overDuechargeStartDay"];
                                        if (objOverDue != null && objOverDue != DBNull.Value)
                                        {
                                            strOverDueChargeStartDay = objOverDue.ToString();
                                        }
                                        if (strOverDueChargeStartMonth != "" && strOverDueChargeStartDay != "")
                                        {
                                            dtOverDueStartDate = dtWaterCheckDate.AddMonths(int.Parse(strOverDueChargeStartMonth));
                                            dtOverDueStartDate = new DateTime(dtOverDueStartDate.Year, dtOverDueStartDate.Month, int.Parse(strOverDueChargeStartDay)).AddDays(-1);
                                        }
                                    }
                                }
                                TimeSpan tsOverDueDays = dtNow - dtOverDueStartDate;
                                int intOverDueDays = tsOverDueDays.Days;//计算超期的天数


                                object objOverDueValue = dtOverDueCharge.Rows[0]["overDuechargePercent"];
                                if (Information.IsNumeric(objOverDueValue) && intOverDueDays>0)
                                {
                                    decimal decOverDueMoneyOld = 0, decRemitOverDueMoney = 0, decRemitOverDueMoneyEnd = 0;
                                    decOverDueMoneyOld = intOverDueDays * Convert.ToDecimal(objOverDueValue);
                                    dgWaterList.Rows[i].Cells["OVERDUEMONEY"].Value = decOverDueMoneyOld;

                                   object objOverDueRemit = dgWaterList.Rows[i].Cells["REMITOVERDUE"].Value;
                                   if (!Information.IsNumeric(objOverDueRemit))
                                    {
                                        decRemitOverDueMoney = 0;
                                        dgWaterList.Rows[i].Cells["REMITOVERDUE"].Value = decRemitOverDueMoney;
                                    }
                                    else
                                       decRemitOverDueMoney = Convert.ToDecimal(objOverDueRemit);

                                   string strOverDueMoneyDescribe = "";
                                    decRemitOverDueMoneyEnd = (decOverDueMoneyOld - decRemitOverDueMoney) >= 0 ? (decOverDueMoneyOld - decRemitOverDueMoney) : 0;
                                    strOverDueMoneyDescribe = (decOverDueMoneyOld - decRemitOverDueMoney) >= 0 ? ("滞纳金:"+decOverDueMoneyOld.ToString()+" - 减免"+decRemitOverDueMoney.ToString()) : "0";
                                    dgWaterList.Rows[i].Cells["REMITOVERDUEEND"].Value = decRemitOverDueMoneyEnd;
                                    dgWaterList.Rows[i].Cells["REMITOVERDUEENDDESCRIBE"].Value = strOverDueMoneyDescribe;

                                    decOverDueSum += decRemitOverDueMoneyEnd;
                                }
                            }
                        }
                         * */
                        #endregion

                        #region 计算水费小计
                        object objWaterTotalCharge = dgWaterList.Rows[i].Cells["waterTotalChargeEND"].Value;//减免后的水费小计
                        if (Information.IsNumeric(objWaterTotalCharge))
                            decWaterTotalCharge += Convert.ToDecimal(objWaterTotalCharge);
                        #endregion
                        #region 计算附加费
                        object objExtraTotalCharge = dgWaterList.Rows[i].Cells["extraTotalChargeEND"].Value;//减免后的附加费
                        if (Information.IsNumeric(objExtraTotalCharge))
                            decExtraTotalCharge += Convert.ToDecimal(objExtraTotalCharge);
                        #endregion
                        #region 计算水费总计
                        object objTotalCharge = dgWaterList.Rows[i].Cells["totalCharge"].Value;//减免后的附加费
                        if (Information.IsNumeric(objTotalCharge))
                            decTotalCharge += Convert.ToDecimal(objTotalCharge);
                        #endregion
                        #region 计算滞纳金
                        object objOverDueMoney = dgWaterList.Rows[i].Cells["OVERDUEEND"].Value;//减免后的附加费
                        if (Information.IsNumeric(objOverDueMoney))
                            decOverDueSum += Convert.ToDecimal(objOverDueMoney);
                        #endregion
                        #region 计算本次应收
                        object objWaterFee = dgWaterList.Rows[i].Cells["totalChargeEND"].Value;
                        if (Information.IsNumeric(objWaterFee))
                            decWaterFee += Convert.ToDecimal(objWaterFee);
                        #endregion
                    }
                }

                txtWaterTotalNumber.Text = intWaterTotalNumber.ToString();

                txtExtraCharge1.Text = decExtraCharge1.ToString("F2");

                txtExtraCharge2.Text = decExtraCharge2.ToString("F2");

                txtWaterTotalCharge.Text = decWaterTotalCharge.ToString("F2");//水费小计

                txtExtraTotalCharge.Text = decExtraTotalCharge.ToString("F2");//附加费

                txtOverDueSum.Text = decOverDueSum.ToString("F2");//滞纳金

                txtWaterFee.Text = decTotalCharge.ToString();//水费总计

                txtBCYS.Text = decWaterFee.ToString("f2");//本次应收
                txtBCSS.Text ="0";//本次实收
                //Thread.Sleep(500);
            }
        }
        private void cmbWaterFeeYearLS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text !="")
            {
                rbLastSixMonth.Checked = false;
                rbLastThreeMonth.Checked = false;
            }
        }

        private void txtInvoiceNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)22)
            {
                e.Handled = true;
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

        private void cmbBatch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtInvoiceNO.Clear();
            //获取新的发票号码
            if (cmbBatch.SelectedValue != null && cmbBatch.SelectedValue != DBNull.Value)
            {
                DataTable dtNewInvoiceNO = BLLWATERFEECHARGE.GetMaxInvoiceNO(strLogID, cmbBatch.SelectedValue.ToString());
                if (dtNewInvoiceNO.Rows.Count > 0)
                {
                    object objInvoiceNO = dtNewInvoiceNO.Rows[0]["INVOICENO"];
                    if (Information.IsNumeric(objInvoiceNO))
                    {
                        txtInvoiceNO.Text = (Convert.ToInt64(objInvoiceNO) + 1).ToString().PadLeft(8, '0');
                    }
                }
            }
        }

        private void bgGetFPNO_DoWork(object sender, DoWorkEventArgs e)
        {
            StringBuilder strInvTypeCode = new StringBuilder();
            StringBuilder strInvNumber = new StringBuilder();
            while (strInvNumber.ToString() != txtInvoiceNO.Text)
            {
                bool ret = GetFPInfo(strInvTypeCode, strInvNumber);
            }
        }

        private void bgGetFPNO_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!frmWaitSearchCanCancel.IsDisposed)
                frmWaitSearchCanCancel.DialogResult = DialogResult.OK;
        }

        private void btSearchYCLS_Click(object sender, EventArgs e)
        {
            if (txtWaterUserID.Text == "")
            {
                mes.Show("当前用户为空,请查询用户后重试!");
                return;
            }
            string strFilter = " AND WATERUSERID='" + txtWaterUserID.Text + "'";
            if (rbLastThreeMonth.Checked)
            {
                strFilter += " AND DATEDIFF(MONTH,CHARGEDATETIME,GETDATE())<4";
            }
            else if (rbLastSixMonth.Checked)
            {
                strFilter += " AND DATEDIFF(MONTH,CHARGEDATETIME,GETDATE())<7";
            }
            else if (rbDateTime.Checked)
            {
                strFilter += " AND  CHARGEDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";
            }
            strFilter += " ORDER BY CHARGEDATETIME";
            DataTable dt = BLLWATERFEECHARGE.QueryWaterFeeAndPrestoreCharge(strFilter);
            dgHistoryYC.DataSource = dt;
        }

        private void btBatchCharge_Click(object sender, EventArgs e)
        {
            frmWaterMeterReadBatchCharge frm = new frmWaterMeterReadBatchCharge();
            //frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void btChangeUserApply_Click(object sender, EventArgs e)
        {
            if (txtWaterUserID.Text != "")
            {
                frmChangeWaterUserMesApply frm = new frmChangeWaterUserMesApply();
                frm.strWaterUserID = txtWaterUserID.Text;
                frm.strWaterUserName = txtWaterUserName.Text;
                frm.strWaterUserTel = txtWaterUserPhone.Text;
                frm.strWaterUserAddress = txtWaterUserAddress.Text;
                frm.strLogID = strLogID;
                frm.strUserName = strUserName;
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void rbPrintReceipt_CheckedChanged(object sender, EventArgs e)
        {
            labInvoiceBatch.Visible = false;
            cmbBatch.Visible = false;
            labInvoiceNO.Visible = false;
            txtInvoiceNO.Visible = false;
            //chkInvoiceBatch.Checked = false;

            labReceiptNO.Visible = true;
            txtReceiptNO.Visible = true;
        }

        private void rbInvoiceSinglePrint_CheckedChanged(object sender, EventArgs e)
        {
            labInvoiceBatch.Visible = true;
            cmbBatch.Visible = true;
            labInvoiceNO.Visible = true;
            txtInvoiceNO.Visible = true;

            labReceiptNO.Visible = false;
            txtReceiptNO.Visible = false;
        }

        private void rbInvoiceBatchPrint_CheckedChanged(object sender, EventArgs e)
        {
            labInvoiceBatch.Visible = true;
            cmbBatch.Visible = true;
            labInvoiceNO.Visible = true;
            txtInvoiceNO.Visible = true;

            labReceiptNO.Visible = false;
            txtReceiptNO.Visible = false;
        }

        private void txtWaterUserPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtWaterUserID.Text != "")
                {
                    string strUpdateSQL = "UPDATE WATERUSER SET waterUserTelphoneNO='" + txtWaterUserPhone.Text + "' WHERE WATERUSERID='" + txtWaterUserID.Text + "'";
                    if (BLLwaterUser.ExcuteSQL(strUpdateSQL) == 0)
                    {
                        mes.Show("更新用户电话信息失败，请重试!");
                    }
                    else
                        labTip.Text = "用户电话信息已更新";
                }
            }
        }

        private void frmWaterMeterReadSingleCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseInvKey();
        }

        private void dgHistoryYC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgHistoryYC.Columns[e.ColumnIndex].Name == "CHARGEClASSS")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if (e.Value.ToString() == "1")
                        e.Value = "水费";
                    else if (e.Value.ToString() == "2")
                        e.Value = "预存";
                    else if (e.Value.ToString() == "3")
                        e.Value = "结算水费";
                    else if (e.Value.ToString() == "4")
                        e.Value = "红冲水费";
                    else if (e.Value.ToString() == "5")
                        e.Value = "红冲预存";
                    else if (e.Value.ToString() == "6")
                        e.Value = "退费";
                }
            }
        }

        private void txtBCSS_Click(object sender, EventArgs e)
        {
            txtBCSS.SelectAll();
        }
        #region 鼠标点击事件 暂时没用
        private void trMeterReading_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeNode trNode = GetMousePositionNode(trMeterReading);

                txtWaterTotalCharge.Text = "0";
                txtExtraTotalCharge.Text = "0";
                txtWaterFee.Text = "0";
                txtOverDueSum.Text = "0";
                txtBCYS.Text = "0";
                txtBCSS.Text = "0";

                txtYSJSYE.Text = "0";
                txtYSQQYE.Text = "0";
                txtBCJY.Text = "0";
                labTip.Text = "";

                txtJYLSH.Clear();
                cmbChargeType.SelectedIndex = 0;

                txtMemo.Clear();

                dgWaterList.DataSource = null;
                dgHistoryYC.DataSource = null;

                btCharge.Enabled = false;
                btSearchYCLS.Enabled = false;

                tabControl1.SelectedIndex = 0;

                //清空选择的用户ID
                strSelectWaterUser = "";

                foreach (Control con in gpbWaterUserMES.Controls)
                {
                    if (con is TextBox)
                        con.Text = "";
                }

                txtInvoiceNO.Clear();//清空发票号

                if (trNode == null)
                    return;
                trMeterReading.SelectedNode = trNode;
                string strNodeID = trNode.Name;
                string[] strNodeIDSpit = strNodeID.Split('|');
                LoadData(strNodeIDSpit);
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
        #endregion
    }
}
