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
    public partial class frmInformRePrintAndCancel : DockContentEx
    {
        public frmInformRePrintAndCancel()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            tb2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb2, true, null);
        }

        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLEXTRACHARGE BLLEXTRACHARGE = new BLLEXTRACHARGE();
        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLAREA BLLAREA = new BLLAREA();
        BLLINFORMCANCELRECORD BLLINFORMCANCELRECORD = new BLLINFORMCANCELRECORD();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();

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
            dgList.AutoGenerateColumns = false;

            BindWaterUserType(cmbWaterUserTypeSearch);

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

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                //禁止列排序
                dgList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            BindWaterMeterType();
            BindChargeWorkerName();
            cmbJSZT.SelectedIndex = 0;
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
        /// 绑定收费员
        /// </summary>
        private void BindChargeWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "全部";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbChargerWorkName.DataSource = dt;
            cmbChargerWorkName.DisplayMember = "USERNAME";
            cmbChargerWorkName.ValueMember = "LOGINID";
        }
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
                    strID = "METERREADER|无关ID| AND LOGINID='" + objID.ToString() + "'";
                }
                object objName = dtMeterReader.Rows[i]["USERNAME"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnMeterReaderMeterReading = tnHeadMeterReader.Nodes.Add(strID, strName, 0, 1);
                if (strID != "")
                {
                    DataTable dtMeterReaderMeterReading = BLLmeterReading.Query(" AND LOGINID='" + objID.ToString() + "'");
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
            tnHeadMeterReader.Nodes.Add("|无关ID| AND meterReadingID=''", "抄表员为空", 0, 1);
            tnHeadMeterReader.Expand();
            #endregion

            #region 生成抄表本树形结构
            TreeNode tnHeadMeterReading = trMeterReading.Nodes.Add("|无关ID|", "全部表本", 0, 1);
            DataTable dtMeterReading = BLLmeterReading.Query("");
            for (int i = 0; i < dtMeterReading.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object objID = dtMeterReading.Rows[i]["meterReadingID"];
                if (objID != null && objID != DBNull.Value)
                {
                    strID = "METERREADING|" + objID.ToString() + "| AND meterReadingID='" + objID.ToString() + "'";
                }
                object objName = dtMeterReading.Rows[i]["meterReadingNO"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                tnHeadMeterReading.Nodes.Add(strID, strName, 0, 1);
            }
            tnHeadMeterReading.Nodes.Add("|无关ID| AND meterReadingID=''", "表本为空", 0, 1);
            //tnHeadMeterReading.Checked = true;
            #endregion

            #region 按区域生成抄表本树形结构
            TreeNode tnHeadArea = trMeterReading.Nodes.Add("|无关ID|", "全部区域", 0, 1);
            DataTable dtArea = BLLAREA.Query(" AND AREAID<>'0000'");
            for (int i = 0; i < dtArea.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object objID = dtArea.Rows[i]["areaId"];
                if (objID != null && objID != DBNull.Value)
                {
                    strID = "AREA|无关ID| AND areaId='" + objID.ToString() + "'";
                }
                object objName = dtArea.Rows[i]["areaName"];
                if (objName != null && objName != DBNull.Value)
                {
                    strName = objName.ToString();
                }
                TreeNode tnAreaMeterReading = tnHeadArea.Nodes.Add(strID, strName, 0, 1);
                if (strID != "")
                {
                    DataTable dtAreaMeterReading = BLLmeterReading.Query(" AND AREAID='" + objID.ToString() + "'");
                    for (int j = 0; j < dtAreaMeterReading.Rows.Count; j++)
                    {
                        string strMeterReadingID = "", strMeterReadingName = "";
                        object objMeterReadingID = dtAreaMeterReading.Rows[j]["meterReadingID"];
                        if (objMeterReadingID != null && objMeterReadingID != DBNull.Value)
                        {
                            strMeterReadingID = "METERREADING|" + objMeterReadingID.ToString() + "| AND meterReadingID='" + objMeterReadingID.ToString() + "'";
                        }
                        object objMeterReadingName = dtAreaMeterReading.Rows[j]["meterReadingNO"];
                        if (objMeterReadingName != null && objMeterReadingName != DBNull.Value)
                        {
                            strMeterReadingName = objMeterReadingName.ToString();
                        }
                        tnAreaMeterReading.Nodes.Add(strMeterReadingID, strMeterReadingName, 0, 1);
                    }
                }
            }
            tnHeadArea.Nodes.Add("|无关ID| AND meterReadingID=''", "区域为空", 0, 1);
            #endregion
            trMeterReading.SelectedNode = tnHeadMeterReader;
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
            //获取最大通知单号
            object objMaxInformNO = BLLreadMeterRecord.GetMaxInformNO("");
            if (Information.IsNumeric(objMaxInformNO))
            {
                txtInvoiceNO.Text = (Convert.ToInt32(objMaxInformNO) + 1).ToString().PadLeft(8, '0');
            }
            else
            {
                txtInvoiceNO.Text = "00000001";
            }

            string strFilter = " AND  waterUserchargeType='1' AND INFORMPRINTSIGN='1' ";//只查询预存用户且已打印通知单的抄表记录
            if (txtWaterUserNOSearch.Text.Trim() != "")
                strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text.Trim().PadLeft(8, '0') + "'";
            if (txtWaterUserNameSearch.Text.Trim() != "")
                strFilter += " AND waterUserName like '%" + txtWaterUserNameSearch.Text.Trim() + "%'";
            if (cmbWaterUserTypeSearch.SelectedValue != null && cmbWaterUserTypeSearch.SelectedValue != DBNull.Value)
                strFilter += " AND waterUserTypeId='" + cmbWaterUserTypeSearch.SelectedValue.ToString() + "'";
            if (cmbWaterMeterType.SelectedValue != null && cmbWaterMeterType.SelectedValue != DBNull.Value)
                strFilter += " AND waterMeterTypeId='" + cmbWaterMeterType.SelectedValue.ToString() + "'";
            if (cmbWaterFeeYear.Text != "")
                strFilter += " AND readMeterRecordYear='" + cmbWaterFeeYear.Text + "'";
            if (cmbWaterFeeMonth.Text != "")
                strFilter += " AND readMeterRecordMonth='" + cmbWaterFeeMonth.Text + "'";

            if (cmbChargerWorkName.SelectedValue != null && cmbChargerWorkName.SelectedValue != DBNull.Value)
                strFilter += " AND PRINTWORKERID='" + cmbChargerWorkName.SelectedValue.ToString() + "'";

            if (chkChargeDateTime.Checked)
            {
                strFilter += " AND INFORMPRINTDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";
            }

            if (cmbJSZT.SelectedIndex > 0)
            {
                if(cmbJSZT.SelectedIndex==1)
                strFilter += " AND WATERUSERJSYE<0";
                else
                    strFilter += " AND WATERUSERJSYE>=0";
            }
            
            if (rbWaterMeterReading.Checked)
                strFilter += " ORDER BY meterReadingNO,ordernumber";
            if (rbWaterUserName.Checked)
                strFilter += " ORDER BY waterUserName";
            if (rbWaterUserNO.Checked)
                strFilter += " ORDER BY waterUserNO";
            if (rbInformNO.Checked)
                strFilter += " ORDER BY INFORMNO";

            dtUserList = BLLreadMeterRecord.QueryYSDetailByWaterMeter(strNodeIDSpit[2] + strFilter);

            DataTable dtUserListTemp = dtUserList.Copy();
            decimal decQFSUM = 0, decWQFSUM = 0;
            DataView dvListQF = dtUserListTemp.DefaultView;
            dvListQF.RowFilter = "WATERUSERJSYE<0";
            DataTable dtQFSUM = dvListQF.ToTable();
            object objQFSUM = dtQFSUM.Compute("SUM(totalChargeEND)", "");
            if (Information.IsNumeric(objQFSUM))
                decQFSUM = Convert.ToDecimal(objQFSUM);

            DataView dvListWQF = dtUserListTemp.DefaultView;
            dvListWQF.RowFilter = "WATERUSERJSYE>=0";
            DataTable dtWQFSUM = dvListWQF.ToTable();
            object objWQFSUM = dtWQFSUM.Compute("SUM(totalChargeEND)", "");
            if (Information.IsNumeric(objWQFSUM))
                decWQFSUM = Convert.ToDecimal(objWQFSUM);

            labSum.Text = "本次查询—冲减用户余额:"+decWQFSUM.ToString("F2")+";欠费用户总金额:"+decQFSUM.ToString("F2");


            //计算查询到的用户欠费金额
            decimal decWaterTotalChargeEnd = 0;
            object objWaterFee = dtUserList.Compute("SUM(totalChargeEND)", "");
            if (Information.IsNumeric(objWaterFee))
                decWaterTotalChargeEnd = Convert.ToDecimal(objWaterFee);

            //计算查询到的用户欠费金额
            int intCount = 0;
            object objCount = dtUserList.Compute("COUNT(waterMeterNo)", "");
            if (Information.IsNumeric(objCount))
                intCount = Convert.ToInt32(objCount);

            dtUserList.Rows.Add(1);
            dtUserList.Rows[dtUserList.Rows.Count - 1]["waterUserName"] = "合计:";
            dtUserList.Rows[dtUserList.Rows.Count - 1]["totalChargeEND"] = decWaterTotalChargeEnd;
            dtUserList.Rows[dtUserList.Rows.Count - 1]["waterMeterNo"] = "共"+intCount+"张" ;

            dgList.DataSource = dtUserList;

            if (dtUserList.Rows.Count == 0)
            {
                btReceiptPrint.Enabled=false;
                btCancel.Enabled = false;
            }
            else
            {
                btReceiptPrint.Enabled = true;
                btCancel.Enabled = true;
            }
        }
        /// <summary>
        /// 获取排序规则
        /// </summary>
        /// <returns></returns>
        private string SortWaterUser()
        {
            string strSort = "";
            if (rbWaterMeterReading.Checked)
                strSort = "meterReadingNO,ordernumber";
            if (rbWaterUserName.Checked)
                strSort = "waterUserName";
            if (rbWaterUserNO.Checked)
                strSort = "waterUserNO";
            return strSort;
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

        private void rbWaterMeterReading_CheckedChanged(object sender, EventArgs e)
        {
            if (dtUserList.Rows.Count == 0)
                return;
            DataView dv = dtUserList.DefaultView;
            dv.Sort = SortWaterUser();

            dtUserList = dv.ToTable();
            dgList.DataSource = dtUserList;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (trMeterReading.SelectedNode != null)
            {
                TreeViewEventArgs ex = new TreeViewEventArgs(trMeterReading.SelectedNode, TreeViewAction.ByMouse);
                trMeterReading_AfterSelect(null, ex);
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

        private void btReceiptPrint_Click(object sender, EventArgs e)
        {
            //获取连打起始号及终止号
            int intStartRow = 0, intEndRow = dgList.Rows.Count - 1;
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
                if (Convert.ToInt32(txtEndRow.Text) < dgList.Rows.Count)
                    intEndRow = Convert.ToInt32(txtEndRow.Text);
            }
            if (mes.ShowQ("确定要打印第 " + intStartRow.ToString() + " 至第 " + intEndRow.ToString() + " 行的通知单信息吗?") != DialogResult.OK)
                return;

            for (int i = intStartRow - 1; i < intEndRow; i++)
            {
                //获取抄表记录ID
                string strreadMeterRecordId = "";

                //存储结算余额，如果结算余额大于0，打印模板则隐藏欠费提醒，否则显示欠费提醒。
                decimal decJSJE=0;

                string strWaterUserID="";
                object objWaterUserID=dtUserList.Rows[i]["waterUserId"];
                if(objWaterUserID!=null&&objWaterUserID!=DBNull.Value)
                    strWaterUserID=objWaterUserID.ToString();

                DataTable dtUserListTemp=dtUserList.Copy();
                DataView dvWaterUserID = dtUserListTemp.DefaultView;
               dvWaterUserID.RowFilter = "waterUserId='"+strWaterUserID+"'";
               DataTable dtWaterUserID = dvWaterUserID.ToTable();

               int intCurrentPage = 0, intSumPageNO = dtWaterUserID.Rows.Count;
               if (i == intStartRow - 1 && intSumPageNO > 1)
               {
                   //如果用户数量大约1，判断第一个readMeterRecordId的rowindex和当前选择的起始rowindex是否一致，不一致则不允许打印。否则会造成打印出问题
                   int intFirstStartRow = 0;
                   string strStartRowID = "", strFirstStartRowID = "";
                   object objreadMeterRecordId = dtUserList.Rows[i]["readMeterRecordId"];
                   if (objreadMeterRecordId != null && objreadMeterRecordId != DBNull.Value)
                   {
                       strStartRowID = objreadMeterRecordId.ToString();
                   }
                   for (int k = 0; k < dtUserList.Rows.Count; k++)
                   {
                       objreadMeterRecordId = dtUserList.Rows[k]["readMeterRecordId"];
                       if (objreadMeterRecordId != null && objreadMeterRecordId != DBNull.Value)
                       {
                           strFirstStartRowID = objreadMeterRecordId.ToString();
                           if (strStartRowID == strFirstStartRowID)
                           {
                               intFirstStartRow = k;
                               break;
                           }
                       }
                   }
                   if (i > intFirstStartRow)
                   {
                       mes.Show("请从该用户第一页通知单开始打印!");
                       return;
                   }
               }
               for (int j = 0; j < intSumPageNO; j++)
               {
                   object objreadMeterRecordId = dtWaterUserID.Rows[j]["readMeterRecordId"];
                   if (objreadMeterRecordId != null && objreadMeterRecordId != DBNull.Value)
                   {
                       strreadMeterRecordId = objreadMeterRecordId.ToString();
                       object objJSJE = dtWaterUserID.Rows[j]["WATERUSERJSYE"];
                       if (Information.IsNumeric(objJSJE))
                           decJSJE = Convert.ToDecimal(objJSJE);
                   }
                   else
                   {
                       mes.Show("第'" + (i + j+1).ToString() + "行抄表ID获取失败,无法执行打印操作!");
                       return;
                   }
                   try
                   {
                       //存储收费表,打印收据用
                       DataTable dtRecord = dtWaterUserID.Clone();
                       dtRecord.ImportRow(dtWaterUserID.Rows[j]);

                       MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                       MODELreadMeterRecord.INFORMNO = txtInvoiceNO.Text.PadLeft(8, '0');
                       MODELreadMeterRecord.PRINTWORKERID = strLogID;
                       MODELreadMeterRecord.PRINTWORKERNAME = strUserName;
                       MODELreadMeterRecord.readMeterRecordId = strreadMeterRecordId;
                       if (BLLreadMeterRecord.UpdateInformNO(MODELreadMeterRecord))
                       {
                           intCurrentPage = j + 1;

                           //如果是最后一张单据显示用户余额,否则不显示余额
                           if (intCurrentPage < intSumPageNO)
                               dtRecord.Rows[0]["WATERUSERJSYE"] = DBNull.Value;

                           dtUserList.Rows[i+j]["INFORMNO"] = MODELreadMeterRecord.INFORMNO;
                           //每张通知单添加页号，方便用户区分最终的用户余额
                           DataColumn dcPage = new DataColumn("PAGESUMMERY", typeof(string));
                           dtRecord.Columns.Add(dcPage);
                           dtRecord.Rows[0]["PAGESUMMERY"] = "第" + intCurrentPage + "/" + intSumPageNO + "页";

                           #region
                           DataSet ds = new DataSet();
                           dtRecord.TableName = "水费通知单模板";
                           ds.Tables.Add(dtRecord);
                           FastReport.Report report1 = new FastReport.Report();
                           try
                           {
                               // load the existing report
                               report1.Load(Application.StartupPath + @"\PRINTModel\收据模板\水费通知单模板.frx");
                               // register the dataset
                               report1.RegisterData(ds);
                               report1.GetDataSource("水费通知单模板").Enabled = true;

                               if (decJSJE < 0)
                                   (report1.FindObject("txtQFSM") as FastReport.TextObject).Visible = true;
                               //report1.Show();
                               report1.PrintSettings.ShowDialog = false;
                               report1.Prepare();
                               report1.Print();

                               txtInvoiceNO.Text = (Convert.ToInt32(txtInvoiceNO.Text) + 1).ToString().PadLeft(8, '0');
                           }
                           catch (Exception exx)
                           {
                               mes.Show(exx.Message);
                               log.Write(exx.ToString(), MsgType.Error);
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
                   catch (Exception ex)
                   {
                       mes.Show("第" + (i + 1).ToString() + "行更新通知单号失败,原因:" + ex.Message);
                       log.Write(ex.ToString(), MsgType.Error);
                       return;
                   }
               }
               i = i + intSumPageNO-1;//随着用户数量大约1的打印，计数器增加；
            }
        }

        private void dgList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            txtStartRow.Text = (e.RowIndex + 1).ToString();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            //获取连打起始号及终止号
            int intStartRow = 0, intEndRow = dgList.Rows.Count - 1;
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
                if (Convert.ToInt32(txtEndRow.Text) < dgList.Rows.Count)
                    intEndRow = Convert.ToInt32(txtEndRow.Text);
            }
            if (txtMemo.Text.Trim() == "")
            {
                mes.Show("请输入作废原因!");
                txtMemo.Focus();
                return;
            }
            if (mes.ShowQ("确定要作废第 " + intStartRow.ToString() + " 至第 " + intEndRow.ToString() + " 行的通知单信息吗?") != DialogResult.OK)
                return;
            for (int i = intEndRow-1; i >= intStartRow - 1; i--)
            {
                //获取抄表记录ID
                string strreadMeterRecordId = "";

                object objreadMeterRecordId = dtUserList.Rows[i]["readMeterRecordId"];
                if (objreadMeterRecordId != null && objreadMeterRecordId != DBNull.Value)
                {
                    strreadMeterRecordId = objreadMeterRecordId.ToString();
                    MODELINFORMCANCELRECORD MODELINFORMCANCELRECORD = new MODELINFORMCANCELRECORD();

                    MODELINFORMCANCELRECORD.INFORMCANCELID=GETTABLEID.GetTableID("","INFORMCANCELRECORD");
                    MODELINFORMCANCELRECORD.READMETERRECORDID = strreadMeterRecordId;

                    object objInformNO = dtUserList.Rows[i]["INFORMNO"];
                    if (objInformNO != null && objInformNO != DBNull.Value)
                        MODELINFORMCANCELRECORD.INFORMNO = objInformNO.ToString();

                    MODELINFORMCANCELRECORD.OPERATORID = strLogID;

                    MODELINFORMCANCELRECORD.OPERATORNAME = strUserName;

                    MODELINFORMCANCELRECORD.CANCELREASON = txtMemo.Text;
                    MODELINFORMCANCELRECORD.OPERATORDATETIME = mes.GetDatetimeNow();

                    if (BLLINFORMCANCELRECORD.Insert(MODELINFORMCANCELRECORD))
                    {
                        if (BLLreadMeterRecord.UpdateCancelInformNO(strreadMeterRecordId))
                        {
                            dtUserList.Rows.Remove(dtUserList.Rows[i]);
                        }
                        else
                        {
                            //回滚通知单作废记录表
                            BLLINFORMCANCELRECORD.Delete(MODELINFORMCANCELRECORD.INFORMCANCELID);
                        }
                    }
                    else
                    {
                        mes.Show("第'" + (i + 1).ToString() + "行通知单作废失败,请重试!");
                        return;
                    }
                }
                else
                {
                    mes.Show("第'" + (i + 1).ToString() + "行抄表ID获取失败,无法执行打印操作!");
                    return;
                }
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }
    }
}
