using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BLL;
using BASEFUNCTION;
using System.Threading;

namespace WATERUSERMETERMANAGE
{
    public partial class frmWaterUserMesAndWaterMeterMesInsert : Form
    {
        public frmWaterUserMesAndWaterMeterMesInsert()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        //BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();
        BLLwaterUserType BLLwaterUserType = new BLLwaterUserType();
        BLLBASE_BANK BLLBASE_BANK = new BLLBASE_BANK();

        BLLAREA BLLAREA = new BLLAREA();
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        BLLBASE_DUAN BLLBASE_DUAN = new BLLBASE_DUAN();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();

        BLLwaterMeterPosition BLLwaterMeterPosition = new BLLwaterMeterPosition();
        BLLwaterMeterSize BLLwaterMeterSize = new BLLwaterMeterSize();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();

        GETTABLEID GETTABLEID = new GETTABLEID();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 剪切的行
        /// </summary>
        public DataTable dtCutRows =new DataTable();

        public string strAreaNOOld = "", strPianNOOld = "", strDuanNOOld = "";

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strLogName = "";

        private void frmBatchModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            dgWaterListBatch.AutoGenerateColumns = false;

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("操作员ID获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strLogName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
            BindCharger(cmbChargerS, "0");

            //cmbAreaNOS.Text = strAreaNOOld;
            //cmbPianNOS.Text = strPianNOOld;
            //cmbDuanNOS.Text = strDuanNOOld;
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
        private void BindBank(ComboBox cmb)
        {
            DataTable dt = BLLBASE_BANK.Query("");
            DataRow dr = dt.NewRow();
            dr["bankName"] = "";
            dr["bankId"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "bankName";
            cmb.ValueMember = "bankId";
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

        private void dgWaterListBatch_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgWaterListBatch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "chargeType")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "非预存";
                    }
                    else if (e.Value.ToString() == "1")
                        e.Value = "预存";
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string strFilter = strSeniorFilterHidden;
            
            if (txtWaterUserNOSearch.Text.Trim() != "")
            {
                if (txtWaterUserNOSearch.Text.Length < 6)
                    strFilter += " AND waterUserNO='U" + txtWaterUserNOSearch.Text.PadLeft(5, '0') + "'";
                else
                    strFilter += " AND waterUserNO='" + txtWaterUserNOSearch.Text + "'";
            }
            if (txtWaterUserNameSearch.Text != "")
                strFilter += " AND waterUserName LIKE '%" + txtWaterUserNameSearch.Text + "%'";
            if (txtWaterUserAddressS.Text != "")
                strFilter += " AND waterUserAddress LIKE '%" + txtWaterUserAddressS.Text + "%'";
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
            if (cmbChargerS.SelectedValue != null && cmbChargerS.SelectedValue != DBNull.Value)
                strFilter += " AND chargerID='" + cmbChargerS.SelectedValue.ToString() + "'";

            strFilter += " ORDER BY pianNO,areaNO,duanNO,ordernumber";

            RefreshData(strFilter);
        }

        Thread TD;
        private void RefreshData(string strFilter)
        {
            try
            {
                TD = new Thread(showwaitfrm);
                TD.Start();
                //Thread.Sleep(2000);   //此行可以不需要，主要用于等待主窗体填充数据
                LoadData(strFilter);
                Thread.Sleep(1000);   //此行可以不需要，主要用于等待主窗体填充数据

                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
                //TD.Abort(); //主窗体加载完成数据后，线程结束，关闭等待窗体。
            }
            catch (Exception ex)
            {
                log.Write("用户及水表批量修改界面:" + ex.ToString(), MsgType.Error);
                mes.Show(ex.Message);
            }
            finally
            {
                if (!waitfrm.IsDisposed)
                {
                    waitfrm.Close();
                }
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
                log.Write("用户及水表批量修改界面:" + ex.ToString(), MsgType.Error);
            }
        }
        /// <summary>
        /// 存储查询到的用户列表
        /// </summary>
        DataTable dtWaterUserList = new DataTable();
        private void LoadData(string strFilter)
        {
            dtWaterUserList = BLLwaterMeter.QueryConnectWaterUser(strFilter);

            dgWaterListBatch.DataSource = dtWaterUserList;
        }

        public string strSeniorFilter = "";
        public string strSeniorFilterHidden = "";
        private void btSenior_Click(object sender, EventArgs e)
        {
            frmWaterUserSeniorSearch frm = new frmWaterUserSeniorSearch();
            frm.Owner = this;
            frm.strSign = "2";
            frm.ShowDialog();
            txtSenior.Text = strSeniorFilter;
        }

        private void dgWaterListBatch_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            dgWaterListBatch.ClearSelection();
            dgWaterListBatch.Rows[e.RowIndex].Selected=true;
            //dgWaterListBatch.CurrentCell = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserNameBatch"];
                if(e.Button==MouseButtons.Right)
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
        }

        private void 插入该行前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtCutRows.Rows.Count == 0)
            {
                mes.Show("请选择要移动的行后操作!");
                return;
            }

            if (dgWaterListBatch.SelectedRows.Count == 0)
            {
                mes.Show("请选择要插入的行位置!");
                return;
            }
            
            //当前选择行的用户名、区号、片号、段号
            string strWaterUserName = "", strAreaNO = "", strPianNO = "", strDuanNO = "",
                strMeterReaderID = "", strMeterReaderName = "", strChargerID = "", strChargerName = "";

            //当前选择行的用户顺序号、行索引、要移动的行数
            int intOrderNumber = 0, intSelectRowIndex = dgWaterListBatch.SelectedRows[0].Index, intCutRowsCount = dtCutRows.Rows.Count;

            object objMeterReaderID = dgWaterListBatch.SelectedRows[0].Cells["meterReaderID"].Value;
            if (objMeterReaderID != null && objMeterReaderID != DBNull.Value)
            {
                strMeterReaderID = objMeterReaderID.ToString();
            }

            object objMeterReaderName = dgWaterListBatch.SelectedRows[0].Cells["meterReaderName"].Value;
            if (objMeterReaderName != null && objMeterReaderName != DBNull.Value)
            {
                strMeterReaderName = objMeterReaderName.ToString();
            }
            object objChargerID = dgWaterListBatch.SelectedRows[0].Cells["chargerID"].Value;
            if (objChargerID != null && objChargerID != DBNull.Value)
                strChargerID = objChargerID.ToString();
            object objChargerName = dgWaterListBatch.SelectedRows[0].Cells["chargerName"].Value;
            if (objChargerName != null && objChargerName != DBNull.Value)
                strChargerName = objChargerName.ToString();
            object objWaterUserName = dgWaterListBatch.SelectedRows[0].Cells["waterUserNameBatch"].Value;
            if (objWaterUserName != null && objWaterUserName != DBNull.Value)
            {
                strWaterUserName = objWaterUserName.ToString();
            }
            object objAreaNO = dgWaterListBatch.SelectedRows[0].Cells["areaNO"].Value;
            if (objAreaNO != null && objAreaNO != DBNull.Value)
            {
                strAreaNO = objAreaNO.ToString();
            }
            object objPianNO = dgWaterListBatch.SelectedRows[0].Cells["pianNO"].Value;
            if (objPianNO != null && objPianNO != DBNull.Value)
            {
                strPianNO = objPianNO.ToString();
            }
            object objDuanNO = dgWaterListBatch.SelectedRows[0].Cells["duanNO"].Value;
            if (objDuanNO != null && objDuanNO != DBNull.Value)
            {
                strDuanNO = objDuanNO.ToString();
            }
            object objOrderNumber = dgWaterListBatch.SelectedRows[0].Cells["ordernumber"].Value;
            if (Information.IsNumeric(objOrderNumber))
            {
                intOrderNumber = Convert.ToInt32(objOrderNumber);
            }
            else
            {
                mes.Show("检测到用户'" + strWaterUserName+"'的顺序号为空!插入失败!");
                return;
            }

            if (mes.ShowQ("系统将对段号'" + strAreaNO + "-" + strPianNO + "-" + strDuanNO + "'重新排序,确定要将选择的行插入到该行之前吗?") != DialogResult.OK)
                return;
            try
            {
                string strSQLUpdateOrder = "UPDATE waterUser SET ordernumber=ordernumber+" + intCutRowsCount + " WHERE ORDERNUMBER>=" + intOrderNumber + " AND areaNO='" +
                    strAreaNO + "' AND pianNO='" + strPianNO + "' AND duanNO='" + strDuanNO + "'";
                if (BLLwaterUser.ExcuteSQL(strSQLUpdateOrder) > 0)
                {
                    for (int j = 0; j < dtCutRows.Rows.Count; j++)
                    {
                        object objWaterUserID = dtCutRows.Rows[j]["waterUserId"];
                        if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        {
                            string strWaterUserIDCut = objWaterUserID.ToString(), strWaterUserNameCut = "", strWaterUserAddressCut = "", strAreaNOCut = "", strPianNOCut = "", strDuanNOCut = "",
                                strWaterMeterPositionIDCut = "", strWaterMeterPositionNameCut = "", strWaterMeterTypeIDCut = "", strWaterMeterTypeNameCut = "",
                                strMeterReaderIDCut = "", strMeterReaderNameCut = "";

                            object obj = dtCutRows.Rows[j]["waterUserName"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterUserNameCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["waterUserAddress"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterUserAddressCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["areaNO"];
                            if (obj != null && obj != DBNull.Value)
                                strAreaNOCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["pianNO"];
                            if (obj != null && obj != DBNull.Value)
                                strPianNOCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["duanNO"];
                            if (obj != null && obj != DBNull.Value)
                                strDuanNOCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["waterMeterPositionName"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterMeterPositionNameCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["waterMeterTypeId"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterMeterTypeIDCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["waterMeterTypeValue"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterMeterTypeNameCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["meterReaderID"];
                            if (obj != null && obj != DBNull.Value)
                                strMeterReaderIDCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["meterReaderName"];
                            if (obj != null && obj != DBNull.Value)
                                strMeterReaderNameCut = obj.ToString();

                            strSQLUpdateOrder = "BEGIN TRAN \r" +
                            "UPDATE WATERUSER SET ordernumber=" + (intOrderNumber + j).ToString() + ",areaNO='" + strAreaNO
                                + "',pianNO='" + strPianNO + "',duanNO='" + strDuanNO + "',meterReaderID='" + strMeterReaderID +
                                "',meterReaderName='" + strMeterReaderName + "',chargerID='" + strChargerID + "',chargerName='" + 
                                strChargerName + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "' \r" +
                                "INSERT INTO WaterUserMoveRecord(WaterUserID,waterUserName,waterUserAddress,areaNO,pianNO,duanNO,meterReaderID," +
                                "meterReaderName,waterMeterTypeId,waterMeterTypeValue,waterMeterPositionName,areaNONew,pianNONew,duanNONew," +
                                "meterReaderIDNew,meterReaderNameNew,Operator,OperateDateTime) VALUES(" +
                                "'" + strWaterUserIDCut + "','" + strWaterUserNameCut + "','" + strWaterUserAddressCut + "','" + strAreaNOCut + "','"
                                + strPianNOCut + "','" + strDuanNOCut + "','" + strMeterReaderIDCut + "','" + strMeterReaderNameCut + "','"
                                + strWaterMeterTypeIDCut + "','" + strWaterMeterTypeNameCut + "','" + strWaterMeterPositionNameCut + "','"+ strAreaNO + "','"
                                +  strPianNO + "','" + strDuanNO + "','"+ strMeterReaderID + "','" +  strMeterReaderName + "','" +strLogName+"',GETDATE()"+
                                ") \r" +
                                "COMMIT TRAN";
                            if (BLLwaterUser.ExcuteSQL(strSQLUpdateOrder) > 0)
                            {
                                dtWaterUserList.ImportRow(dtCutRows.Rows[j]);
                            }
                            else
                            {
                                mes.Show("用户ID为'" + objWaterUserID.ToString() + "'的用户移动失败，请手动更新!");
                            }
                        }
                    }
                    string strSQLOldWaterUserList = "SELECT * FROM WATERUSER WHERE areaNO='" + strAreaNOOld
                                + "' AND pianNO='" + strPianNOOld + "' AND duanNO='" + strDuanNOOld + "' ORDER BY ordernumber";
                    DataTable dtOldWaterUser = BLLwaterUser.QuerySQL(strSQLOldWaterUserList);
                    for (int j = 0; j < dtOldWaterUser.Rows.Count; j++)
                    {
                        object objWaterUserID = dtOldWaterUser.Rows[j]["waterUserId"];
                        if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        {
                          string  strSQLUpdateOldOrder = "UPDATE WATERUSER SET ordernumber=" + (1 + j).ToString() + " WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                            //strSQLUpdateOrder = "UPDATE WATERUSER SET ordernumber=" + (intOrderNumber + j).ToString() + " WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                            if (BLLwaterUser.ExcuteSQL(strSQLUpdateOldOrder) > 0)
                            {

                            }
                            else
                            {
                                mes.Show("用户ID为'" + objWaterUserID.ToString() + "'的顺序号更新失败，请手动更新!");
                            }
                        }
                    }
                    btSearch_Click(null,null);
                    dgWaterListBatch.Rows[intSelectRowIndex].Selected=true;
                    dgWaterListBatch.CurrentCell = dgWaterListBatch.Rows[intSelectRowIndex].Cells["waterUserNameBatch"];

                    ((frmBatchModifyWaterUserMesAndWaterMeterMes)this.Owner).isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }

        private void 插入该行后ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtCutRows.Rows.Count == 0)
            {
                mes.Show("请选择要移动的行后操作!");
                return;
            }

            if (dgWaterListBatch.SelectedRows.Count == 0)
            {
                mes.Show("请选择要插入的行位置!");
                return;
            }

            //当前选择行的用户名、区号、片号、段号
            string strWaterUserName = "", strAreaNO = "", strPianNO = "", strDuanNO = "",
                strMeterReaderID = "", strMeterReaderName = "", strChargerID = "", strChargerName = "";
            //当前选择行的用户顺序号、行索引、要移动的行数
            int intOrderNumber = 0, intSelectRowIndex = dgWaterListBatch.SelectedRows[0].Index, intCutRowsCount = dtCutRows.Rows.Count;


            object objMeterReaderID = dgWaterListBatch.SelectedRows[0].Cells["meterReaderID"].Value;
            if (objMeterReaderID != null && objMeterReaderID != DBNull.Value)
            {
                strMeterReaderID = objMeterReaderID.ToString();
            }

            object objMeterReaderName = dgWaterListBatch.SelectedRows[0].Cells["meterReaderName"].Value;
            if (objMeterReaderName != null && objMeterReaderName != DBNull.Value)
            {
                strMeterReaderName = objMeterReaderName.ToString();
            }
            object objChargerID = dgWaterListBatch.SelectedRows[0].Cells["chargerID"].Value;
            if (objChargerID != null && objChargerID != DBNull.Value)
                strChargerID = objChargerID.ToString();
            object objChargerName = dgWaterListBatch.SelectedRows[0].Cells["chargerName"].Value;
            if (objChargerName != null && objChargerName != DBNull.Value)
                strChargerName = objChargerName.ToString();
            object objWaterUserName = dgWaterListBatch.SelectedRows[0].Cells["waterUserNameBatch"].Value;
            if (objWaterUserName != null && objWaterUserName != DBNull.Value)
            {
                strWaterUserName = objWaterUserName.ToString();
            }
            object objAreaNO = dgWaterListBatch.SelectedRows[0].Cells["areaNO"].Value;
            if (objAreaNO != null && objAreaNO != DBNull.Value)
            {
                strAreaNO = objAreaNO.ToString();
            }
            object objPianNO = dgWaterListBatch.SelectedRows[0].Cells["pianNO"].Value;
            if (objPianNO != null && objPianNO != DBNull.Value)
            {
                strPianNO = objPianNO.ToString();
            }
            object objDuanNO = dgWaterListBatch.SelectedRows[0].Cells["duanNO"].Value;
            if (objDuanNO != null && objDuanNO != DBNull.Value)
            {
                strDuanNO = objDuanNO.ToString();
            }
            object objOrderNumber = dgWaterListBatch.SelectedRows[0].Cells["ordernumber"].Value;
            if (Information.IsNumeric(objOrderNumber))
            {
                intOrderNumber = Convert.ToInt32(objOrderNumber);
            }
            else
            {
                mes.Show("检测到用户'" + strWaterUserName + "'的顺序号为空!插入失败!");
                return;
            }

            if (mes.ShowQ("系统将对段号'" + strAreaNO + "-" + strPianNO + "-" + strDuanNO + "'重新排序,确定要将选择的行插入到该行之后吗?") != DialogResult.OK)
                return;
            try
            {
                string strSQLUpdateOrder = "UPDATE waterUser SET ordernumber=ordernumber+" + intCutRowsCount + " WHERE ORDERNUMBER>" + intOrderNumber + " AND areaNO='" +
                    strAreaNO + "' AND pianNO='" + strPianNO + "' AND duanNO='" + strDuanNO + "'";
                BLLwaterUser.ExcuteSQL(strSQLUpdateOrder);
                    for (int j = 0; j < dtCutRows.Rows.Count; j++)
                    {
                        object objWaterUserID = dtCutRows.Rows[j]["waterUserId"];
                        if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        {
                            string strWaterUserIDCut = objWaterUserID.ToString(), strWaterUserNameCut = "", strWaterUserAddressCut = "", strAreaNOCut = "", strPianNOCut = "", strDuanNOCut = "",
                                strWaterMeterPositionIDCut = "", strWaterMeterPositionNameCut = "", strWaterMeterTypeIDCut = "", strWaterMeterTypeNameCut = "",
                                strMeterReaderIDCut = "", strMeterReaderNameCut = "";

                            object obj = dtCutRows.Rows[j]["waterUserName"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterUserNameCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["waterUserAddress"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterUserAddressCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["areaNO"];
                            if (obj != null && obj != DBNull.Value)
                                strAreaNOCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["pianNO"];
                            if (obj != null && obj != DBNull.Value)
                                strPianNOCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["duanNO"];
                            if (obj != null && obj != DBNull.Value)
                                strDuanNOCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["waterMeterPositionName"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterMeterPositionNameCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["waterMeterTypeId"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterMeterTypeIDCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["waterMeterTypeValue"];
                            if (obj != null && obj != DBNull.Value)
                                strWaterMeterTypeNameCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["meterReaderID"];
                            if (obj != null && obj != DBNull.Value)
                                strMeterReaderIDCut = obj.ToString();
                            obj = dtCutRows.Rows[j]["meterReaderName"];
                            if (obj != null && obj != DBNull.Value)
                                strMeterReaderNameCut = obj.ToString();

                            strSQLUpdateOrder = "BEGIN TRAN \r" +
                            "UPDATE WATERUSER SET ordernumber=" + (intOrderNumber + j+1).ToString() + ",areaNO='" + strAreaNO
                                + "',pianNO='" + strPianNO + "',duanNO='" + strDuanNO + "',meterReaderID='" + strMeterReaderID +
                                "',meterReaderName='" + strMeterReaderName + "',chargerID='" + strChargerID + "',chargerName='" +
                                strChargerName + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "' \r" +
                                "INSERT INTO WaterUserMoveRecord(WaterUserID,waterUserName,waterUserAddress,areaNO,pianNO,duanNO,meterReaderID," +
                                "meterReaderName,waterMeterTypeId,waterMeterTypeValue,waterMeterPositionName,areaNONew,pianNONew,duanNONew," +
                                "meterReaderIDNew,meterReaderNameNew,Operator,OperateDateTime) VALUES(" +
                                "'" + strWaterUserIDCut + "','" + strWaterUserNameCut + "','" + strWaterUserAddressCut + "','" + strAreaNOCut + "','"
                                + strPianNOCut + "','" + strDuanNOCut + "','" + strMeterReaderIDCut + "','" + strMeterReaderNameCut + "','"
                                + strWaterMeterTypeIDCut + "','" + strWaterMeterTypeNameCut + "','" + strWaterMeterPositionNameCut + "','" + strAreaNO + "','"
                                + strPianNO + "','" + strDuanNO + "','" + strMeterReaderID + "','" + strMeterReaderName + "','" + strLogName + "',GETDATE()" +
                                ") \r" +
                                "COMMIT TRAN";

                            if (BLLwaterUser.ExcuteSQL(strSQLUpdateOrder) > 0)
                            {
                                dtWaterUserList.ImportRow(dtCutRows.Rows[j]);
                            }
                            else
                            {
                                mes.Show("用户ID为'" + objWaterUserID.ToString() + "'的用户移动失败，请手动更新!");
                            }
                        }
                    }
                    string strSQLOldWaterUserList = "SELECT * FROM WATERUSER WHERE areaNO='" + strAreaNOOld
                                + "' AND pianNO='" + strPianNOOld + "' AND duanNO='" + strDuanNOOld + "' ORDER BY ordernumber";
                    DataTable dtOldWaterUser = BLLwaterUser.QuerySQL(strSQLOldWaterUserList);
                    for (int j = 0; j < dtOldWaterUser.Rows.Count; j++)
                    {
                        object objWaterUserID = dtOldWaterUser.Rows[j]["waterUserId"];
                        if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        {
                            string strSQLUpdateOldOrder = "UPDATE WATERUSER SET ordernumber=" + (1 + j).ToString() + " WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                            //strSQLUpdateOrder = "UPDATE WATERUSER SET ordernumber=" + (intOrderNumber + j).ToString() + " WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                            if (BLLwaterUser.ExcuteSQL(strSQLUpdateOldOrder) > 0)
                            {

                            }
                            else
                            {
                                mes.Show("用户ID为'" + objWaterUserID.ToString() + "'的顺序号更新失败，请手动更新!");
                            }
                        }
                    }
                    btSearch_Click(null, null);
                    dgWaterListBatch.Rows[intSelectRowIndex].Selected = true;
                    dgWaterListBatch.CurrentCell = dgWaterListBatch.Rows[intSelectRowIndex].Cells["waterUserNameBatch"];

                    ((frmBatchModifyWaterUserMesAndWaterMeterMes)this.Owner).isSuccess = true;
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
        }
    }
}
