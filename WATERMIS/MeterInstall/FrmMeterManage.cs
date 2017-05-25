using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using Common.DotNetUI;
using Common.DotNetCode;
using FastReport;

namespace MeterInstall
{
    public partial class FrmMeterManage : DockContentEx
    {
        public FrmMeterManage()
        {
            InitializeComponent();
        }

        private void FrmMeterManage_Load(object sender, EventArgs e)
        {
            Binddata();
        }

        private void toolEntering_Click(object sender, EventArgs e)
        {
            FrmEntering frm = new FrmEntering();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                SeachData();
            }
        }

        /// <summary>
        /// 查询到的水表明细
        /// </summary>
        private DataTable dtList = new DataTable();

        private void toolSearch_Click(object sender, EventArgs e)
        {
            SeachData();
        }

        void SeachData()
        {
            dtList = new DataTable();
            StringBuilder sb = new StringBuilder();

            if (CHK_waterMeterProofreadingDate.Checked)
            {
                DateTime dt1;
                DateTime dt2;


                if (!DateTime.TryParse(DT_waterMeterProofreadingDate_1.Text, out dt1))
                {
                    MessageBox.Show("请重新选择鉴定日期！");
                    return;
                }
                if (!DateTime.TryParse(DT_waterMeterProofreadingDate_2.Text, out dt2))
                {
                    MessageBox.Show("请重新选择鉴定日期！");
                    return;
                }
                if (dt2 < dt1)
                {
                    MessageBox.Show("请重新选择鉴定日期！");
                    return;
                }
                else
                {
                    //if (dt2 == dt1)
                    //{
                    dt2 = dt2.AddDays(1);
                    // }
                    sb.AppendFormat(" AND waterMeterProofreadingDate >'{0}' and waterMeterProofreadingDate < '{1}'", dt1, dt2);

                }

            }

            if (!string.IsNullOrEmpty(CB_waterMeterProduct.Text) && !CB_waterMeterProduct.Text.Equals("全部"))
            {
                    sb.AppendFormat(" and waterMeterProduct= '{0}'", CB_waterMeterProduct.Text);
            }
            if (!string.IsNullOrEmpty(CB_MeterState.SelectedValue.ToString()))
            {
                    sb.AppendFormat(" and MeterState= '{0}'", CB_MeterState.SelectedValue);
            }

            if (!string.IsNullOrEmpty(CB_waterMeterSize.SelectedValue.ToString()))
            {
                    sb.AppendFormat(" and Meter.waterMeterSizeId= '{0}'", CB_waterMeterSize.SelectedValue);
            }

            if (!string.IsNullOrEmpty(TB_SearchKey.Text.Trim()))
            {
                sb.AppendFormat(" and (Meter.waterMeterNo LIKE '%{0}%' OR Meter.waterMeterSerialNumber LIKE '%{0}%' OR Meter.MEMO LIKE '%{0}%')", TB_SearchKey.Text.Trim());
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "waterMeterSerialNumber", "出厂编号" }, 
                                                           { "waterMeterProduct", "水表厂家" }, 
                                                           { "StateDescribe", "水表状态" }, 
                                                           { "waterMeterSizeValue", "口径" }, 
                                                           { "waterMeterStartNumber", "初始读数" },
                                                           { "waterUserId", "用户号" },
                                                           { "waterUserName", "用户名" },
                                                           { "waterMeterProofreadingDate", "鉴定日期" }, 
                                                           { "waterMeteProofreadingPeriod", "鉴定周期" } ,
                                                           { "STARTUSEDATETIME", "启用时间" } ,
                                                           { "Memo", "备注" }   
            };

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MeterID,waterMeterStartNumber,waterMeterProduct,waterUserId,(SELECT TOP 1 waterUserName FROM waterUser WHERE waterUserId=Meter.waterUserId) AS waterUserName,waterMeterSerialNumber,waterMeterMode,waterMeterProofreadingDate,waterMeteProofreadingPeriod,STARTUSEDATETIME,Meter.MEMO, waterMeterSize.waterMeterSizeValue, MeterState.StateDescribe,CreateDate FROM Meter LEFT OUTER JOIN MeterState ON Meter.MeterState = MeterState.ID LEFT OUTER JOIN waterMeterSize ON Meter.waterMeterSizeId = waterMeterSize.waterMeterSizeId");
            if (sb.ToString().Trim() != "")
            {
                strSql.Append(" where 1=1 " + sb.ToString());
            }
            uC_DataGridView_Page1.SqlString = strSql.ToString();
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.strCaption = "水表库存情况明细表";
            uC_DataGridView_Page1.Init();

            dtList = new SqlServerHelper().GetDateTableBySql(strSql.ToString());
            if (dtList.Rows.Count > 0)
            {
                toolPrint.Enabled = true;
                toolPrintPreview.Enabled = true;
                toolExcel.Enabled = true;
            }
            else
            {
                toolPrint.Enabled = false;
                toolPrintPreview.Enabled = false;
                toolExcel.Enabled = false;
            }
        }
        private void Binddata()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("MeterState", "", "ID");
            ControlBindHelper.BindComboBoxData(this.CB_MeterState, dt, "StateDescribe", "ID", true);


            DataTable dt2 = new SqlServerHelper().GetDataTable("waterMeterSize", "", "waterMeterSizeId");
            ControlBindHelper.BindComboBoxData(this.CB_waterMeterSize, dt2, "waterMeterSizeValue", "waterMeterSizeId", true);

            DataTable dt3 = new SqlServerHelper().GetDataTable("View_MeterProduct", "", "waterMeterProduct");
            ControlBindHelper.BindComboBoxData(this.CB_waterMeterProduct, dt3, "waterMeterProduct", "waterMeterStartNumber", true);

        }

        private void Btn_Scrap_Click(object sender, EventArgs e)
        {
            //if (dgList.CurrentRow != null)
            //{
            //    Hashtable ht = new Hashtable();
            //    ht["METERSTATE"] = "2";
            //    new SqlServerHelper().UpdateByHashtable("Meter", "METERID", dgList.CurrentRow.Cells["MeterID"].Value.ToString(), ht);
            //}
        }

        private void toolBatch_Click(object sender, EventArgs e)
        {
            FrmMeterImport frm = new FrmMeterImport();

            frm.ShowDialog();
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList != null)
            if (dgList.CurrentRow != null)
            {
                FrmEntering frm = new FrmEntering();
                frm.key = dgList.CurrentRow.Cells["MeterID"].Value.ToString();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    SeachData();
                }
            }
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dtPrint =dtList.Copy();
            dtPrint.TableName = "水表情况表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\业扩模板\水表库存模板.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("水表情况表").Enabled = true;
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
        }

        private void toolPrintPreview_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dtPrint = dtList.Copy();
            dtPrint.TableName = "水表情况表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\业扩模板\水表库存模板.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("水表情况表").Enabled = true;
                // run the report
                report1.Show();
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
        }

        private void toolExcel_Click(object sender, EventArgs e)
        {
            //string strCaption = "水表在库情况表";
            //ExportExcel ExportExcel = new ExportExcel();
            //ExcelHelper.ExportExcel(dtList,"1");
            //ExportExcel.ExportToExcel(strCaption, dgList);
        }

        private void TB_waterMeterSerialNumber_1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }
}
