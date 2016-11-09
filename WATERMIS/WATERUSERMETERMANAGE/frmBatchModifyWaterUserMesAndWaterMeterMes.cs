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
    public partial class frmBatchModifyWaterUserMesAndWaterMeterMes : DockContentEx
    {
        public frmBatchModifyWaterUserMesAndWaterMeterMes()
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

        private void frmBatchModifyWaterUserMesAndWaterMeterMes_Load(object sender, EventArgs e)
        {
            dgWaterListBatch.AutoGenerateColumns = false;
            this.dgWaterListBatch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            BindWaterMeterType(cmbWaterMeterTypeBatch, "0");

            BindAreaNO(cmbAreaNOS, "0");
            BindPianNO(cmbPianNOS, "0");
            BindDuanNO(cmbDuanNOS, "0");
            BindCommunity(cmbCommunityS, "0");
            BindMeterReader(cmbMeterReaderS, "0");
            BindCharger(cmbChargerS, "0");
            BindParentID();

            for (int i = 0; i < dgWaterListBatch.Columns.Count; i++)
            {
                //隐藏附加费列
                if (dgWaterListBatch.Columns[i].Name == "waterUserNameBatch" || dgWaterListBatch.Columns[i].Name == "waterUserTelphoneNO" ||
                    dgWaterListBatch.Columns[i].Name == "waterPhoneBatch" || dgWaterListBatch.Columns[i].Name == "waterUserAddressBatch" ||
                    dgWaterListBatch.Columns[i].Name == "buildingNO" || dgWaterListBatch.Columns[i].Name == "unitNO" ||
                    dgWaterListBatch.Columns[i].Name == "waterUserCerficateNO" || dgWaterListBatch.Columns[i].Name == "waterUserCerficateType" ||
                    dgWaterListBatch.Columns[i].Name == "waterMeterSerialNumberBatch" || dgWaterListBatch.Columns[i].Name == "waterMeterModeBatch" ||
                    dgWaterListBatch.Columns[i].Name == "WATERMETERLOCKNO" )
                {
                    dgWaterListBatch.Columns[i].ReadOnly = false;
                }
                else
                    dgWaterListBatch.Columns[i].ReadOnly = true;
            }

            cmbWaterMeterStateBatch.SelectedIndex = 0;
            cmbLeft.SelectedIndex = 0;
        }
        /// <summary>
        /// 绑定总表
        /// </summary>
        private void BindParentID()
        {
           DataTable dtParent = BLLwaterMeter.QuerySummary("");
           DataRow dr = dtParent.NewRow();
           dr["waterUserName"] = "全部";
           dr["waterMeterId"] = DBNull.Value;
           dtParent.Rows.InsertAt(dr,0);
           cmbMeterParentName.DataSource = dtParent;

           cmbMeterParentName.DisplayMember = "waterUserName";
           cmbMeterParentName.ValueMember = "waterMeterId";
           cmbMeterParentName.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
           cmbMeterParentName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
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
            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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
            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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
            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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
            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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
            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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
            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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
            if (strType == "0")
            {
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
            }
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
            //if (e.ColumnIndex > 12)
            //    return;
            //DrawCell(e);
            /** 
             // 对第1列相同单元格进行合并
             if (e.ColumnIndex == 2 && e.RowIndex != -1)
             {
                 using(
                     Brush gridBrush = new SolidBrush(this.dgWaterListBatch.GridColor),
                     backColorBrush = new SolidBrush(e.CellStyle.BackColor)
                     )
                 {
                     using (Pen gridLinePen = new Pen(gridBrush))
                     {
                         // 清除单元格
                         e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                         // 画 Grid 边线（仅画单元格的底边线和右边线）
                         //   如果下一行和当前行的数据不同，则在当前的单元格画一条底边线
                         if (e.RowIndex < dgWaterListBatch.Rows.Count - 1 &&
                         dgWaterListBatch.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString())
                             e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                             e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                             e.CellBounds.Bottom - 1);
                         // 画右边线
                         e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                             e.CellBounds.Top, e.CellBounds.Right - 1,
                             e.CellBounds.Bottom);

                         // 画（填写）单元格内容，相同的内容的单元格只填写第一个
                         if (e.Value != null)
                         {
                             if (e.RowIndex > 0 && dgWaterListBatch.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == e.Value.ToString())
                             { 
                             }
                             else
                             {
                                 StringFormat sf = new StringFormat();
                                 sf.Alignment = StringAlignment.Center;
                                 sf.LineAlignment = StringAlignment.Center;
                                 //Graphics g = new Graphics();
                                 e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                     Brushes.Black, new Rectangle(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width, e.CellBounds.Height * 2), sf);
                             }
                         }
                         e.Handled = true;
                     }
                 }
             }**/
        }

        #region 自定义方法
        /// <summary>
        /// 画单元格
        /// </summary>
        /// <param name="e"></param>
        private void DrawCell(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            Brush gridBrush = new SolidBrush(dgWaterListBatch.GridColor);
            SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int cellwidth;
            //上面相同的行数
            int UpRows = 0;
            //下面相同的行数
            int DownRows = 0;
            //总行数
            int count = 0;
            cellwidth = e.CellBounds.Width;
            Pen gridLinePen = new Pen(gridBrush);
            string curValue = e.Value == null ? "" : e.Value.ToString().Trim();
            string curValueID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value == null ? "" : dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value.ToString().Trim();
            //if (!string.IsNullOrEmpty(curValue))
            //{
                #region 获取下面的行数
                for (int i = e.RowIndex; i < dgWaterListBatch.Rows.Count; i++)
                {
                    object objValue = dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Value;
                   string strValue= objValue== null ? "" : objValue.ToString();
                   if (strValue.Equals(curValue) && dgWaterListBatch.Rows[i].Cells["waterUserIdBatch"].Value.ToString().Equals(curValueID))
                    //if (dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                    {
                        //dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Selected = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;

                        DownRows++;
                        if (e.RowIndex != i)
                        {
                            cellwidth = cellwidth < dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Size.Width;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
                #region 获取上面的行数
                for (int i = e.RowIndex; i >= 0; i--)
                {
                    object objValue = dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Value;
                    string strValue = objValue == null ? "" : objValue.ToString();
                    if (strValue.Equals(curValue) && dgWaterListBatch.Rows[i].Cells["waterUserIdBatch"].Value.ToString().Equals(curValueID))
                    //if (dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                    {
                        //dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Selected = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
                        UpRows++;
                        if (e.RowIndex != i)
                        {
                            cellwidth = cellwidth < dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgWaterListBatch.Rows[i].Cells[e.ColumnIndex].Size.Width;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion
                count = DownRows + UpRows - 1;
                if (count < 2)
                {
                    return;
                }
            //}
            if (dgWaterListBatch.Rows[e.RowIndex].Selected)
            {
                backBrush.Color = e.CellStyle.SelectionBackColor;
                fontBrush.Color = e.CellStyle.SelectionForeColor;
            }
            //以背景色填充
            e.Graphics.FillRectangle(backBrush, e.CellBounds);
            //画字符串
            PaintingFont(e, cellwidth, UpRows, DownRows, count);
            if (DownRows == 1)
            {
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                count = 0;
            }
            // 画右边线
            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

            e.Handled = true;
        }
        /// <summary>
        /// 画字符串
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cellwidth"></param>
        /// <param name="UpRows"></param>
        /// <param name="DownRows"></param>
        /// <param name="count"></param>
        private void PaintingFont(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, int cellwidth, int UpRows, int DownRows, int count)
        {
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
            int fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
            int cellheight = e.CellBounds.Height;

            if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y + cellheight * DownRows - fontheight);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
            {
                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1));
            }
            else
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
            }
        }
        #endregion
        /**
         * 地址
人口数
区号
片号
段号
小区名称
楼号
单元
抄表员
收费员
户型
交费方式
银行托收
托收银行
建档类型
水表位置
口径
水表状态
用水性质
初始读数
生产厂家
铅封号
倍率
最大量程
鉴定日期
鉴定周期
是否总表
所属总表
定量用水
水表倒装
         * */
        private void cmbLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dtProofDate.Visible = false;
            cmbLeft.Visible = true;
            cmbModifyValue.DataSource = null;
            cmbModifyValue.Items.Clear();
            cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
            string strTxt = cmbLeft.Text;
            switch (strTxt)
            {
                case "地址":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "人口数":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "1";
                    break;
                case "区号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLAREA.Query(" AND areaId<>'0000'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "areaName";
                    cmbModifyValue.ValueMember = "areaId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "片号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_PIAN.Query(" AND PIANID<>'0000'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "PIANNAME";
                    cmbModifyValue.ValueMember = "PIANID";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "段号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_DUAN.Query(" AND DUANID<>'0000'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "DUANNAME";
                    cmbModifyValue.ValueMember = "DUANID";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "用户类别":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLwaterUserType.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterUserTypeName";
                    cmbModifyValue.ValueMember = "waterUserTypeId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "小区名称":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_COMMUNITY.Query(" AND COMMUNITYID<>'0000'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "COMMUNITYNAME";
                    cmbModifyValue.ValueMember = "COMMUNITYID";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "楼号":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "单元":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "抄表员":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_LOGIN.QueryUser(" AND isMeterReader='1'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "userName";
                    cmbModifyValue.ValueMember = "loginId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "收费员":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_LOGIN.QueryUser(" AND isCharger='1'");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "userName";
                    cmbModifyValue.ValueMember = "loginId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    cmbModifyValue.Text = "";
                    break;
                case "户型":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    
                    cmbModifyValue.Items.Add("楼房");
                    cmbModifyValue.Items.Add("平房");
                    cmbModifyValue.Text = "楼房";
                    break;
                case "交费方式":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbModifyValue.Items.Add("非预存");
                    cmbModifyValue.Items.Add("预存");
                    cmbModifyValue.Text = "非预存";
                    break;
                case "银行托收":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbModifyValue.Items.Add("托收");
                    cmbModifyValue.Items.Add("不托收");
                    cmbModifyValue.Text = "不托收";
                    break;
                case "托收银行":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLBASE_BANK.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "bankName";
                    cmbModifyValue.ValueMember = "bankId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    break;
                case "建档类型":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;

                    cmbModifyValue.Items.Add("正式");
                    cmbModifyValue.Items.Add("非正式");
                    cmbModifyValue.Items.Add("基建");
                    cmbModifyValue.Items.Add("无表");
                    cmbModifyValue.Text = "正式";
                    break;
                case "是否总表":                    
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbModifyValue.Items.Add("分表");
                    cmbModifyValue.Items.Add("总表");
                    cmbModifyValue.Text = "分表";
                    break;
                case "水表位置":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    dt = BLLwaterMeterPosition.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterMeterPositionName";
                    cmbModifyValue.ValueMember = "waterMeterPositionId";
                    break;
                case "口径":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    dt = BLLwaterMeterSize.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterMeterSizeValue";
                    cmbModifyValue.ValueMember = "waterMeterSizeId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    break;
                case "水表状态":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbModifyValue.Items.Add("正常");
                    cmbModifyValue.Items.Add("注销");
                    cmbModifyValue.Items.Add("换表");
                    cmbModifyValue.Items.Add("未启用");
                    cmbModifyValue.Items.Add("欠费停水");
                    cmbModifyValue.Items.Add("违章停水");
                    cmbModifyValue.Items.Add("坏表");
                    cmbModifyValue.Items.Add("待审核");
                    cmbModifyValue.Items.Add("待拆迁");
                    cmbModifyValue.Text = "正常";
                    break;
                case "用水性质":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLWATERMETERTYPE.Query("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterMeterTypeValue";
                    cmbModifyValue.ValueMember = "waterMeterTypeId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    break;
                case "初始读数":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "0";
                    break;
                case "出厂编号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "生产厂家":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "铅封号":
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "";
                    break;
                case "倍率":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "1";
                    break;
                case "最大量程":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "99999";
                    break;
                case "鉴定周期":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "12";
                    break;
                case "鉴定日期":
                    dtProofDate.Visible = true;
                    break;
                case "所属总表":
                    //cmbModifyValue.KeyPress -= new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.DropDown;
                    dt = BLLwaterMeter.QuerySummary("");
                    cmbModifyValue.DataSource = dt;
                    cmbModifyValue.DisplayMember = "waterUserName";
                    cmbModifyValue.ValueMember = "waterMeterId";
                    cmbModifyValue.AutoCompleteSource = AutoCompleteSource.ListItems;   //设置自动完成的源 
                    cmbModifyValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;    //设置自动完成的的形式 
                    break;
                case "定量用水":
                    cmbModifyValue.KeyPress += new KeyPressEventHandler(cmbModifyValue_KeyPress);
                    cmbModifyValue.DropDownStyle = ComboBoxStyle.Simple;
                    cmbModifyValue.Text = "0";
                    break;
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

        private void btOK_Click(object sender, EventArgs e)
        {
            if (mes.ShowQ("确定要将选择的行中的'" + cmbLeft.Text + "'的信息全部修改吗?") != DialogResult.OK)
                return;

            try
            {
                string strTxt = cmbLeft.Text;
                switch (strTxt)
                {
                    case "地址":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterUser SET waterUserAddress='" + cmbModifyValue.Text + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";
                                //BLLwaterUser.UpdateSQL(strSQL);
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                    dgWaterListBatch.SelectedRows[i].Cells["waterUserAddressBatch"].Value = cmbModifyValue.Text;
                                else
                                {
                                    mes.Show("第"+(i+1).ToString()+"行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "人口数":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterUser SET waterUserPeopleCount=" + cmbModifyValue.Text + " WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                if (BLLwaterUser.UpdateSQL(strSQL))
                                    dgWaterListBatch.SelectedRows[i].Cells["waterUserPeopleCountBatch"].Value = cmbModifyValue.Text;
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "区号":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterUser SET areaNO='" + cmbModifyValue.Text + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                        dgWaterListBatch.SelectedRows[i].Cells["areaNO"].Value = cmbModifyValue.Text;
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的区号不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "段号":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterUser SET duanNO='" + cmbModifyValue.Text + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                        dgWaterListBatch.SelectedRows[i].Cells["duanNO"].Value = cmbModifyValue.Text;
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的段号不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "片号":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterUser SET pianNO='" + cmbModifyValue.Text + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                        dgWaterListBatch.SelectedRows[i].Cells["pianNO"].Value = cmbModifyValue.Text;
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的片号不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "用户类别":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterUser SET waterUserTypeId='" + cmbModifyValue.SelectedValue.ToString() + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                    {
                                        dgWaterListBatch.SelectedRows[i].Cells["waterUserTypeId"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["waterUserTypeName"].Value = cmbModifyValue.Text;
                                    }
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改的用户类别不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "小区名称":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterUser SET communityID='" + cmbModifyValue.SelectedValue.ToString() + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                    {
                                        dgWaterListBatch.SelectedRows[i].Cells["communityID"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["COMMUNITYNAME"].Value = cmbModifyValue.Text;
                                    }
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的小区不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "楼号":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterUser SET buildingNO='" + cmbModifyValue.Text + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                if (BLLwaterUser.UpdateSQL(strSQL))
                                    dgWaterListBatch.SelectedRows[i].Cells["buildingNO"].Value = cmbModifyValue.Text;
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "单元":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterUser SET unitNO='" + cmbModifyValue.Text + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                if (BLLwaterUser.UpdateSQL(strSQL))
                                    dgWaterListBatch.SelectedRows[i].Cells["unitNO"].Value = cmbModifyValue.Text;
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "抄表员":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterUser SET meterReaderID='" + cmbModifyValue.SelectedValue.ToString() +
                                        "',meterReaderName='" + cmbModifyValue .Text+ "'" +
                                        " WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                    {
                                        dgWaterListBatch.SelectedRows[i].Cells["meterReaderID"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["meterReaderName"].Value = cmbModifyValue.Text;
                                    }
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的抄表员不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "收费员":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterUser SET chargerID='" + cmbModifyValue.SelectedValue.ToString() +
                                        "',chargerName='" + cmbModifyValue.Text + "'" +
                                        " WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                    {
                                        dgWaterListBatch.SelectedRows[i].Cells["chargerID"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["chargerName"].Value = cmbModifyValue.Text;
                                    }
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的收费员不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "户型":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterUser SET waterUserHouseType=" + (cmbModifyValue.SelectedIndex + 1).ToString() + " WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                if (BLLwaterUser.UpdateSQL(strSQL))
                                    dgWaterListBatch.SelectedRows[i].Cells["waterUserHouseTypeS"].Value = cmbModifyValue.Text;
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "交费方式":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterUser SET chargeType=" + cmbModifyValue.SelectedIndex.ToString() + " WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                if (BLLwaterUser.UpdateSQL(strSQL))
                                    dgWaterListBatch.SelectedRows[i].Cells["chargeType"].Value = cmbModifyValue.SelectedIndex.ToString();
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "银行托收":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterUser SET agentsign=" + (cmbModifyValue.SelectedIndex + 1).ToString() + " WHERE waterUserId='" + objWaterUserID.ToString() + "'";

                                if (BLLwaterUser.UpdateSQL(strSQL))
                                    dgWaterListBatch.SelectedRows[i].Cells["agentsignS"].Value = cmbModifyValue.Text;
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "托收银行":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterUser SET bankId='" + cmbModifyValue.SelectedValue.ToString() + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";
                                    //BLLwaterUser.UpdateSQL(strSQL);
                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                    {
                                        dgWaterListBatch.SelectedRows[i].Cells["bankIdBatch"].Value = cmbModifyValue.SelectedValue.ToString();
                                        dgWaterListBatch.SelectedRows[i].Cells["bankNameBatch"].Value = cmbModifyValue.Text;
                                    }
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的托收银行不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "建档类型":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterUserIdBatch"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterUser SET createType='" + cmbModifyValue.Text + "' WHERE waterUserId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["createType"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "是否总表":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET isSummaryMeter=" + (cmbModifyValue.SelectedIndex + 1).ToString() + " WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["isSummaryMeterSBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "水表位置":
                        //if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        //{
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeterPositionName='" + cmbModifyValue.Text + "' WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                BLLwaterUser.UpdateSQL(strSQL);
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterPositionNameBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        //}
                        //else
                        //{
                        //    mes.Show("修改后的水表位置不能空,无法完成修改!");
                        //    return;
                        //}
                        break;
                    case "口径":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterMeter SET waterMeterSizeId='" + cmbModifyValue.SelectedValue.ToString() + "' WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                    {
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterSizeIdBatch"].Value = cmbModifyValue.SelectedValue;
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterSizeValueBatch"].Value = cmbModifyValue.Text;
                                    }
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的水表位置不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "水表状态":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeterState=" + (cmbModifyValue.SelectedIndex + 1).ToString() + " WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterStateSBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "用水性质":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterMeter SET waterMeterTypeId='" + cmbModifyValue.SelectedValue.ToString() + "' WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                    {
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterTypeIdBatch"].Value = cmbModifyValue.SelectedValue;
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterTypeValueBatch"].Value = cmbModifyValue.Text;
                                    }
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的水表位置不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "初始读数":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeterStartNumber=" + cmbModifyValue.Text + " WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterStartNumberBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "出厂编号":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeterSerialNumber='" + cmbModifyValue.Text + "' WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterSerialNumberBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "生产厂家":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeterProduct='" + cmbModifyValue.Text + "' WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterProductBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "铅封号":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeterMode='" + cmbModifyValue.Text + "' WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterModeBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "倍率":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeterMagnification=" + cmbModifyValue.Text + " WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterMagnificationBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "最大量程":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeterMaxRange=" + cmbModifyValue.Text + " WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterMaxRangeBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "鉴定周期":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeteProofreadingPeriod=" + cmbModifyValue.Text + " WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeteProofreadingPeriodBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "鉴定日期":
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET waterMeterProofreadingDate='" + dtProofDate.Value.ToString() + "' WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["waterMeterProofreadingDateBatch"].Value = dtProofDate.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                    case "所属总表":
                        if (cmbModifyValue.SelectedValue != null && cmbModifyValue.SelectedValue != DBNull.Value)
                        {
                            for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                            {
                                object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                                if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                                {
                                    string strSQL = "UPDATE waterMeter SET waterMeterParentId='" + cmbModifyValue.SelectedValue.ToString() + "' WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                    BLLwaterUser.UpdateSQL(strSQL);
                                    if (BLLwaterUser.UpdateSQL(strSQL))
                                    {
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterParentId"].Value = cmbModifyValue.SelectedValue;
                                        dgWaterListBatch.SelectedRows[i].Cells["waterMeterParentName"].Value = cmbModifyValue.Text;
                                    }
                                    else
                                    {
                                        mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            mes.Show("修改后的总表不能空,无法完成修改!");
                            return;
                        }
                        break;
                    case "定量用水":
                        if (!Information.IsNumeric(cmbModifyValue.Text))
                            cmbModifyValue.Text = "0";
                        for (int i = 0; i < dgWaterListBatch.SelectedRows.Count; i++)
                        {
                            object objWaterUserID = dgWaterListBatch.SelectedRows[i].Cells["waterMeterIdBacth"].Value;
                            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                            {
                                string strSQL = "UPDATE waterMeter SET WATERFIXVALUE=" + cmbModifyValue.Text + " WHERE waterMeterId='" + objWaterUserID.ToString() + "'";
                                if (BLLwaterUser.UpdateSQL(strSQL))
                                {
                                    dgWaterListBatch.SelectedRows[i].Cells["WATERFIXVALUEBatch"].Value = cmbModifyValue.Text;
                                }
                                else
                                {
                                    mes.Show("第" + (i + 1).ToString() + "行信息修改失败,批量修改终止!");
                                    return;
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
            //btSearch_Click(null,null);
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

            if (cmbWaterMeterTypeBatch.SelectedValue != null && cmbWaterMeterTypeBatch.SelectedValue != DBNull.Value)
                strFilter += " AND waterMeterTypeId='" + cmbWaterMeterTypeBatch.SelectedValue.ToString() + "'"; ;
            if (cmbWaterMeterStateBatch.SelectedIndex>0)
                strFilter += " AND waterMeterStateS='" + cmbWaterMeterStateBatch.Text + "'";

            if (cmbMeterParentName.SelectedValue != null && cmbMeterParentName.SelectedValue != DBNull.Value)
            {
                if (chkManyClass.Checked)
                {
                    strMeterParentID = "";
                    strMeterParentID = GetMeterParentID(cmbMeterParentName.SelectedValue.ToString());
                    strFilter += " AND waterMeterParentId IN (" + strMeterParentID + ")";
                }
                else
                    strFilter += " AND waterMeterParentId='" + cmbMeterParentName.SelectedValue.ToString() + "'";
            }

            if (rbPQD.Checked)
                strFilter += " ORDER BY areaNO,pianNO,duanNO,ordernumber";
            if (rbWaterUserName.Checked)
                strFilter += " ORDER BY waterUserName";
            if (rbWaterUserNO.Checked)
                strFilter += " ORDER BY waterUserNO";

            RefreshData(strFilter);
        }

        //获取所有总表编号
        string strMeterParentID = "";

        /// <summary>
        /// 获取总表下的所有级联分表
        /// </summary>
        /// <param name="strID"></param>
        private string GetMeterParentID(string strID)
        {
            if (strMeterParentID != "")
                strMeterParentID += ",'" + strID+"'";
            else
                strMeterParentID ="'"+ strID+"'";

            DataTable dtAll = BLLwaterMeter.QuerySummary(" AND waterMeterParentId='" + strID + "'");
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                object objID = dtAll.Rows[i]["waterMeterId"];
                if (objID != null && objID != DBNull.Value)
                {
                    string strChildID = objID.ToString();
                    GetMeterParentID(strChildID);
                }
            }
            return strMeterParentID;
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
            if (dgWaterListBatch.CurrentCell.IsInEditMode)
                return;

                if (e.Button == MouseButtons.Right)
                {
                    if (dtSelectedRows.Rows.Count > 0)
                    {
                        粘贴到该行前ToolStripMenuItem.Enabled = true;
                        粘贴到该行后ToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        粘贴到该行前ToolStripMenuItem.Enabled = false;
                        粘贴到该行后ToolStripMenuItem.Enabled = false;
                    }

                    string pasteText = "";
                    pasteText = Clipboard.GetText();

                    if (string.IsNullOrEmpty(pasteText))
                    {
                        粘贴复制内容ToolStripMenuItem.Enabled = false;
                    }
                    else
                        粘贴复制内容ToolStripMenuItem.Enabled = true;

                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
        }
        DataTable dtSelectedRows = new DataTable();
        public bool isSuccess = false;
        private void 剪切选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSuccess = false;
            if (dgWaterListBatch.SelectedRows.Count == 0)
            {
                mes.Show("请选择要移动的行!");
                return;
            }
            dtSelectedRows = new DataTable();
            dtSelectedRows = dtWaterUserList.Clone() ;
            DataGridViewRow[] drSelectedRows = new DataGridViewRow[dgWaterListBatch.SelectedRows.Count];
            for (int i = dgWaterListBatch.SelectedRows.Count-1; i >=0 ; i--)
            {
                DataRow dr = (dgWaterListBatch.SelectedRows[i].DataBoundItem as DataRowView).Row;
                dtSelectedRows.ImportRow(dr);
            }
            if (dtSelectedRows.Rows.Count == 0)
            {
                mes.Show("获取剪切行失败,请重新操作!");
                return;
            }
            string strAreaNO = "", strPianNO = "", strDuanNO = "";

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
            frmWaterUserMesAndWaterMeterMesInsert frm = new frmWaterUserMesAndWaterMeterMesInsert();
            frm.dtCutRows = dtSelectedRows;
            frm.Owner = this;
            frm.strAreaNOOld = strAreaNO;
            frm.strPianNOOld = strPianNO;
            frm.strDuanNOOld = strDuanNO;
            frm.ShowDialog();
            if(isSuccess)
            {
                int intSelectedCount=dgWaterListBatch.SelectedRows.Count;
                for (int j = 0; j < intSelectedCount; j++)
                {
                    dgWaterListBatch.Rows.Remove(dgWaterListBatch.SelectedRows[0]);
                }
            }
            dtSelectedRows = new DataTable();
        }

        private void btBatchAdd_Click(object sender, EventArgs e)
        {
            frmBatchAddWaterUserAndMeter frm = new frmBatchAddWaterUserAndMeter();
            if (dgWaterListBatch.SelectedRows.Count > 0)
            {
                string strAreaNO = "", strPianNO = "", strDuanNO = "", strMeterReaderID = "", strChargerID = "", strCommunityID = "", strOrderNumber = "";

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
                object objMeterReaderID = dgWaterListBatch.SelectedRows[0].Cells["meterReaderID"].Value;
                if (objMeterReaderID != null && objMeterReaderID != DBNull.Value)
                {
                    strMeterReaderID = objMeterReaderID.ToString();
                }
                object objChargerID = dgWaterListBatch.SelectedRows[0].Cells["chargerID"].Value;
                if (objChargerID != null && objChargerID != DBNull.Value)
                {
                    strChargerID = objChargerID.ToString();
                }
                object objCommunityID = dgWaterListBatch.SelectedRows[0].Cells["communityID"].Value;
                if (objCommunityID != null && objCommunityID != DBNull.Value)
                {
                    strCommunityID = objCommunityID.ToString();
                }
                object objOrderNumber = dgWaterListBatch.SelectedRows[0].Cells["ordernumber"].Value;
                if (objOrderNumber != null && objOrderNumber != DBNull.Value)
                {
                    strOrderNumber = objOrderNumber.ToString();
                }
                frm.strType = "1";
                frm.strAreaNO = strAreaNO;
                frm.strPianNO = strPianNO;
                frm.strDuanNO = strDuanNO;
                frm.strChargerID = strChargerID;
                frm.strCommunityID = strCommunityID;
                frm.strOrderNumber = strOrderNumber;
                frm.strMeterReaderID = strMeterReaderID;
            }
            frm.Owner = this;
            frm.ShowDialog();
        }


        private void 移动选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSuccess = false;
            if (dgWaterListBatch.SelectedRows.Count == 0)
            {
                mes.Show("请选择要移动的行!");
                return;
            }
            dtSelectedRows = new DataTable();
            dtSelectedRows = dtWaterUserList.Clone();
            DataGridViewRow[] drSelectedRows = new DataGridViewRow[dgWaterListBatch.SelectedRows.Count];
            for (int i = dgWaterListBatch.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataRow dr = (dgWaterListBatch.SelectedRows[i].DataBoundItem as DataRowView).Row;
                dtSelectedRows.ImportRow(dr);
            }
            if (dtSelectedRows.Rows.Count == 0)
            {
                mes.Show("获取移动行失败,请重新操作!");
                return;
            }
            DataView dvSelectedRows = dtSelectedRows.DefaultView;
            DataTable dtDistinctDuanNO = dvSelectedRows.ToTable(true, "areaNO", "pianNO", "duanNO");
            if (dtDistinctDuanNO.Rows.Count > 1)
            {
                mes.Show("选择的行只能属于一个片区段,请重新操作!");
                dtSelectedRows = new DataTable();
                return;
            }
        }
        private void 粘贴到该行前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtSelectedRows.Rows.Count== 0)
            {
                mes.Show("未找到要移动的行,请选择行后选择'移动选中行'后操作!");
                return;
            }

            if (dgWaterListBatch.CurrentRow == null)
            {
                mes.Show("请选择一行后执行此操作!");
                return;
            }

            string strAreaNO = "", strPianNO = "", strDuanNO = "";

            object objAreaNO = dtSelectedRows.Rows[0]["areaNO"];
            if (objAreaNO != null && objAreaNO != DBNull.Value)
            {
                strAreaNO = objAreaNO.ToString();
            }
            object objPianNO = dtSelectedRows.Rows[0]["pianNO"];
            if (objPianNO != null && objPianNO != DBNull.Value)
            {
                strPianNO = objPianNO.ToString();
            }
            object objDuanNO = dtSelectedRows.Rows[0]["duanNO"];
            if (objDuanNO != null && objDuanNO != DBNull.Value)
            {
                strDuanNO = objDuanNO.ToString();
            }

            string strAreaNOCurrent = "", strPianNOCurrent = "", strDuanNOCurrent = "";

            object objAreaNOCurrent = dtSelectedRows.Rows[0]["areaNO"];
            if (objAreaNO != null && objAreaNO != DBNull.Value)
            {
                strAreaNOCurrent = objAreaNO.ToString();
            }
            object objPianNOCurrent = dtSelectedRows.Rows[0]["pianNO"];
            if (objPianNO != null && objPianNO != DBNull.Value)
            {
                strPianNOCurrent = objPianNO.ToString();
            }
            object objDuanNOCurrent = dtSelectedRows.Rows[0]["duanNO"];
            if (objDuanNO != null && objDuanNO != DBNull.Value)
            {
                strDuanNOCurrent = objDuanNO.ToString();
            }

            if (strAreaNO != strAreaNOCurrent || strPianNO != strPianNOCurrent || strDuanNO != strDuanNOCurrent)
            {
                mes.Show("要移动的行和当前位置行只能属于一个片区段!");
                return;
            }

            string strWaterUserName = "";
            int intSelectRowIndex = dgWaterListBatch.CurrentRow.Index, intOrderNumber = 0, intCutRowsCount = dtSelectedRows.Rows.Count;

            object objWaterUserName = dgWaterListBatch.SelectedRows[0].Cells["waterUserNameBatch"].Value;
            if (objWaterUserName != null && objWaterUserName != DBNull.Value)
            {
                strWaterUserName = objWaterUserName.ToString();
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
            if (mes.ShowQ("系统将对段号'" + strAreaNO + "-" + strPianNO + "-" + strDuanNO + "'重新排序,确定要将选择的行插入到用户'" + strWaterUserName + "'之前吗?") != DialogResult.OK)
                return;

            try
            {
                string strSQLUpdateOrder = "UPDATE waterUser SET ordernumber=ordernumber+" + intCutRowsCount + " WHERE ORDERNUMBER>=" + intOrderNumber + " AND areaNO='" +
                    strAreaNO + "' AND pianNO='" + strPianNO + "' AND duanNO='" + strDuanNO + "'";
                BLLwaterUser.ExcuteSQL(strSQLUpdateOrder);
                    for (int j = 0; j < dtSelectedRows.Rows.Count; j++)
                    {
                        object objWaterUserID = dtSelectedRows.Rows[j]["waterUserId"];
                        if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        {
                            strSQLUpdateOrder = "UPDATE WATERUSER SET ordernumber=" + (intOrderNumber + j).ToString() + " WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                            if (BLLwaterUser.ExcuteSQL(strSQLUpdateOrder) > 0)
                            {
                                dtWaterUserList.ImportRow(dtSelectedRows.Rows[j]);
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
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
            finally
            {
                dtSelectedRows = new DataTable();
            }
        }

        private void 粘贴到该行后ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtSelectedRows.Rows.Count == 0)
            {
                mes.Show("未找到要移动的行,请选择行后选择'移动选中行'后操作!");
                return;
            }

            if (dgWaterListBatch.CurrentRow == null)
            {
                mes.Show("请选择一行后执行此操作!");
                return;
            }

            string strAreaNO = "", strPianNO = "", strDuanNO = "";

            object objAreaNO = dtSelectedRows.Rows[0]["areaNO"];
            if (objAreaNO != null && objAreaNO != DBNull.Value)
            {
                strAreaNO = objAreaNO.ToString();
            }
            object objPianNO = dtSelectedRows.Rows[0]["pianNO"];
            if (objPianNO != null && objPianNO != DBNull.Value)
            {
                strPianNO = objPianNO.ToString();
            }
            object objDuanNO = dtSelectedRows.Rows[0]["duanNO"];
            if (objDuanNO != null && objDuanNO != DBNull.Value)
            {
                strDuanNO = objDuanNO.ToString();
            }

            string strAreaNOCurrent = "", strPianNOCurrent = "", strDuanNOCurrent = "";

            object objAreaNOCurrent = dtSelectedRows.Rows[0]["areaNO"];
            if (objAreaNO != null && objAreaNO != DBNull.Value)
            {
                strAreaNOCurrent = objAreaNO.ToString();
            }
            object objPianNOCurrent = dtSelectedRows.Rows[0]["pianNO"];
            if (objPianNO != null && objPianNO != DBNull.Value)
            {
                strPianNOCurrent = objPianNO.ToString();
            }
            object objDuanNOCurrent = dtSelectedRows.Rows[0]["duanNO"];
            if (objDuanNO != null && objDuanNO != DBNull.Value)
            {
                strDuanNOCurrent = objDuanNO.ToString();
            }

            if (strAreaNO != strAreaNOCurrent || strPianNO != strPianNOCurrent || strDuanNO != strDuanNOCurrent)
            {
                mes.Show("要移动的行和当前位置行只能属于一个片区段!");
                return;
            }

            string strWaterUserName = "";
            int intSelectRowIndex = dgWaterListBatch.CurrentRow.Index, intOrderNumber = 0, intCutRowsCount = dtSelectedRows.Rows.Count;

            object objWaterUserName = dgWaterListBatch.SelectedRows[0].Cells["waterUserNameBatch"].Value;
            if (objWaterUserName != null && objWaterUserName != DBNull.Value)
            {
                strWaterUserName = objWaterUserName.ToString();
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
            if (mes.ShowQ("系统将对段号'" + strAreaNO + "-" + strPianNO + "-" + strDuanNO + "'重新排序,确定要将选择的行插入到用户'" + strWaterUserName + "'之后吗?") != DialogResult.OK)
                return;

            try
            {
                string strSQLUpdateOrder = "UPDATE waterUser SET ordernumber=ordernumber+" + intCutRowsCount + " WHERE ORDERNUMBER>" + intOrderNumber + " AND areaNO='" +
                    strAreaNO + "' AND pianNO='" + strPianNO + "' AND duanNO='" + strDuanNO + "'";
                BLLwaterUser.ExcuteSQL(strSQLUpdateOrder);
                    for (int j = 0; j < dtSelectedRows.Rows.Count; j++)
                    {
                        object objWaterUserID = dtSelectedRows.Rows[j]["waterUserId"];
                        if (objWaterUserID != null && objWaterUserID != DBNull.Value)
                        {
                            strSQLUpdateOrder = "UPDATE WATERUSER SET ordernumber=" + (intOrderNumber+1 + j).ToString() + " WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                            if (BLLwaterUser.ExcuteSQL(strSQLUpdateOrder) > 0)
                            {
                                dtWaterUserList.ImportRow(dtSelectedRows.Rows[j]);
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
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
            finally
            {
                dtSelectedRows = new DataTable();
            }
        }

        private void dgWaterListBatch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "waterUserNameBatch")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj=dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERUSER SET waterUserName='" + str + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if ( dgWaterListBatch.Columns[e.ColumnIndex].Name == "waterUserTelphoneNO")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERUSER SET waterUserTelphoneNO='" + str + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "waterPhoneBatch")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERUSER SET waterPhone='" + str + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "waterUserAddressBatch")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERUSER SET waterUserAddress='" + str + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "buildingNO")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERUSER SET buildingNO='" + str + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "unitNO")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERUSER SET unitNO='" + str + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "waterUserCerficateNO")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERUSER SET waterUserCerficateNO='" + str + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "waterUserCerficateType")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterUserIdBatch"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERUSER SET waterUserCerficateType='" + str + "' WHERE WATERUSERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "waterMeterSerialNumberBatch")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterMeterIdBacth"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERMETER SET waterMeterSerialNumber='" + str + "' WHERE WATERMETERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "waterMeterModeBatch")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterMeterIdBacth"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERMETER SET waterMeterMode='" + str + "' WHERE WATERMETERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
            if (dgWaterListBatch.Columns[e.ColumnIndex].Name == "WATERMETERLOCKNO")
            {
                object objWaterUserID = dgWaterListBatch.Rows[e.RowIndex].Cells["waterMeterIdBacth"].Value;
                if (objWaterUserID != DBNull.Value && objWaterUserID != null)
                {
                    string str = "";
                    object obj = dgWaterListBatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null && obj != DBNull.Value)
                        str = obj.ToString();

                    string strSQL = "UPDATE WATERMETER SET WATERMETERLOCKNO='" + str + "' WHERE WATERMETERID='" + objWaterUserID.ToString() + "'";
                    if (BLLwaterUser.ExcuteSQL(strSQL) == 0)
                    {
                        mes.Show("保存失败，请重新修改!");
                        return;
                    }
                }
            }
        }

        private void cmbMeterParentName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbMeterParentName.SelectedValue != null && cmbMeterParentName.SelectedValue != DBNull.Value)
            {
                chkManyClass.Enabled = true;
            }
            else
            {
                chkManyClass.Enabled = false;
                chkManyClass.Checked = false;
            }
        }

        private void 粘贴复制内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取剪切板的内容，并按行分割 
                string pasteText = "";
                pasteText = Clipboard.GetText();

                if (string.IsNullOrEmpty(pasteText))
                {
                    mes.Show("没有复制任何内容!");
                    return;
                }
                if (pasteText == "pasteText")
                {
                    return;
                }
                int tnum = 0;
                int nnum = 0;
                //获得当前剪贴板内容的行、列数
                for (int i = 0; i < pasteText.Length; i++)
                {
                    if (pasteText.Substring(i, 1) == "\t")
                    {
                        tnum++;
                    }
                    if (pasteText.Substring(i, 1) == "\n")
                    {
                        nnum++;
                    }
                }
                Object[,] data;
                //粘贴板上的数据来自于EXCEL时，每行末都有\n，在DATAGRIDVIEW内复制时，最后一行末没有\n
                if (pasteText.Substring(pasteText.Length - 1, 1) == "\n")
                {
                    nnum = nnum - 1;
                }
                tnum = tnum / (nnum + 1);
                data = new object[nnum + 1, tnum + 1];//定义一个二维数组

                String rowstr;
                rowstr = "";
                //MessageBox.Show(pasteText.IndexOf("B").ToString());
                //对数组赋值
                for (int i = 0; i < (nnum + 1); i++)
                {
                    for (int colIndex = 0; colIndex < (tnum + 1); colIndex++)
                    {
                        //一行中的最后一列
                        if (colIndex == tnum && pasteText.IndexOf("\r") != -1)
                        {
                            rowstr = pasteText.Substring(0, pasteText.IndexOf("\r"));
                        }
                        //最后一行的最后一列
                        if (colIndex == tnum && pasteText.IndexOf("\r") == -1)
                        {
                            rowstr = pasteText.Substring(0);
                        }
                        //其他行列
                        if (colIndex != tnum)
                        {
                            rowstr = pasteText.Substring(0, pasteText.IndexOf("\t"));
                            pasteText = pasteText.Substring(pasteText.IndexOf("\t") + 1);
                        }
                        data[i, colIndex] = rowstr;
                    }
                    //截取下一行数据
                    pasteText = pasteText.Substring(pasteText.IndexOf("\n") + 1);
                }
                //获取当前选中单元格所在的列序号
                int curntindex = dgWaterListBatch.CurrentRow.Cells.IndexOf(dgWaterListBatch.CurrentCell);
                //获取获取当前选中单元格所在的行序号
                int rowindex = dgWaterListBatch.CurrentRow.Index;
                //MessageBox.Show(curntindex.ToString ());
                for (int j = 0; j < (nnum + 1); j++)
                {
                    for (int colIndex = 0; colIndex < (tnum + 1); colIndex++)
                    {
                        if (!dgWaterListBatch.Columns[colIndex + curntindex].Visible)
                        {
                            continue;
                        }
                        if (!dgWaterListBatch.Rows[j + rowindex].Cells[colIndex + curntindex].ReadOnly)
                        {
                            dgWaterListBatch.Rows[j + rowindex].Cells[colIndex + curntindex].Value = data[j, colIndex];
                            dgWaterListBatch_CellEndEdit(null, new DataGridViewCellEventArgs(colIndex + curntindex,j + rowindex));
                        }
                    }
                }
                Clipboard.Clear();
            }
            catch
            {
                Clipboard.Clear();
                //MessageBox.Show("粘贴区域大小不一致");
                return;
            }
        }
    }
}
