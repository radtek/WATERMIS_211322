using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using MODEL;
using BASEFUNCTION;
using Microsoft.VisualBasic;

namespace SYSMANAGE
{
    public partial class frmOperateLog : DockContentEx
    {
        public frmOperateLog()
        {
            InitializeComponent();
        }

        BLLmeterReading BLLmeterReading = new BLLmeterReading();
        BLLOPERATORLOG BLLOPERATORLOG = new BLLOPERATORLOG();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        Messages mes = new Messages();

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        private void frmOperateLog_Load(object sender, EventArgs e)
        {
            dgLog.AutoGenerateColumns = false;

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
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            BindWorkerName();
            string strDate = mes.GetDatetimeNow().AddMonths(-1).ToString("yyyy-MM-dd") + " 00:00:00";
            if (Information.IsDate(strDate))
            {
                dtpStart.Value = Convert.ToDateTime(strDate);
            }
            BindMeterReading();
        }
        /// <summary>
        /// 绑定抄表本
        /// </summary>
        private void BindMeterReading()
        {
            DataTable dt = BLLmeterReading.Query("");
            DataRow dr = dt.NewRow();
            dr["meterReadingID"] = DBNull.Value;
            dr["meterReadingNO"] = "";
            dt.Rows.InsertAt(dr, 0);

            cmbWaterUserMeterReadingNO.DataSource = dt;
            cmbWaterUserMeterReadingNO.DisplayMember = "meterReadingNO";
            cmbWaterUserMeterReadingNO.ValueMember = "meterReadingID";
        }
        /// <summary>
        /// 绑定操作员
        /// </summary>
        private void BindWorkerName()
        {
            DataTable dt = BLLBASE_LOGIN.QueryUser("");
            DataRow dr = dt.NewRow();
            dr["USERNAME"] = "";
            dr["LOGINID"] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            cmbWorkName.DataSource = dt;
            cmbWorkName.DisplayMember = "USERNAME";
            cmbWorkName.ValueMember = "LOGINID";
        }

        /// <summary>
        /// 存储查询到的用户列表
        /// </summary>
        DataTable dtList = new DataTable();

        /// <summary>
        /// 存储统计行信息
        /// </summary>
        DataTable dtClone = new DataTable();

        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (cmbLogTypeS.SelectedIndex > 0)
            {
                strFilter += " AND LOGTYPE='" + cmbLogTypeS.SelectedIndex.ToString() + "'";
            }
            if (chkCancelDateTime.Checked)
            {
                strFilter += " AND LOGDATETIME BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";
            }
            if (cmbWorkName.SelectedValue != null && cmbWorkName.SelectedValue != DBNull.Value)
            {
                strFilter += " AND OPERATORID='" + cmbWorkName.SelectedValue.ToString() + "'";
            }
            if (cmbWaterUserMeterReadingNO.SelectedValue != null && cmbWaterUserMeterReadingNO.SelectedValue != DBNull.Value)
            {
                strFilter += " AND OPERATORLOG.METERREADINGID='" + cmbWaterUserMeterReadingNO.SelectedValue.ToString() + "'";
            }
            if (txtContent.Text.Trim() != "")
            {
                strFilter += " AND LOGCONTENT LIKE '%" + txtContent.Text + "%'";
            }
            strFilter += " ORDER BY LOGDATETIME DESC";

            //存储查询条件，用作日志清除条件
            txtFilter.Text = strFilter;

            dtList=BLLOPERATORLOG.Query(strFilter);

            dgLog.DataSource = null;

            if (dtList.Rows.Count > 0)
            {
                toolDelete.Enabled = true;

                int intWaterUserListCount = dtList.Rows.Count;//

                dtClone = dtList.Clone();

                DataRow drLast = dtClone.NewRow();
                drLast["meterReadingNO"] = "合计:";
                drLast["LOGCONTENT"] = "共" + intWaterUserListCount + "条";

                dtClone.Rows.Add(drLast);
                ucPageSetUp1.InitialUC(this.dgLog, dtList, dtClone);
            }
            else
            {
                toolDelete.Enabled = false;
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

        private void dgLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgLog.Columns[e.ColumnIndex].Name == "LOGTYPE")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if (e.Value.ToString() == "1")
                        e.Value = "用水用户日志";
                    else if (e.Value.ToString() == "2")
                        e.Value = "用户水表日志";
                    else if (e.Value.ToString() == "3")
                        e.Value = "抄表机日志";
                    else if (e.Value.ToString() == "4")
                        e.Value = "清除日志";
                    else if (e.Value.ToString() == "5")
                        e.Value = "登陆日志";
                    else if (e.Value.ToString() == "6")
                        e.Value = "台账日志";
                }
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (dgLog.Rows.Count == 0)
            {
                mes.Show("日志列表为空,请查询后再清空日志!");
                return;
            }
            if (mes.ShowQ("清除日志内容将不可恢复，确定要清除日志列表中的日志吗?") == DialogResult.OK)
            {
                int intCount = BLLOPERATORLOG.Delete(txtFilter.Text);
                if (intCount > 0)
                {

                    MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                    MODELOPERATORLOG.LOGCONTENT = "管理员:" + strLogID + "-" + strUserName + ",清空" + intCount + "条日志";

                    MODELOPERATORLOG.LOGTYPE = "4";  //1代表用户 2代表水表 3代表抄表机相关日志 4清除日志
                    MODELOPERATORLOG.OPERATORID = strLogID;
                    MODELOPERATORLOG.OPERATORNAME = strUserName;
                    BLLOPERATORLOG.Insert(MODELOPERATORLOG);

                    toolSearch_Click(null, null);
                    mes.Show("共清空'" + intCount.ToString() + "'条日志");
                }
            }
        }
    }
}
