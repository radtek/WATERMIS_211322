using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;
using Common.DotNetCode;
using System.Collections;
using FastReport;

namespace MeterBusiness
{
    public partial class FrmMeterManage : DockContentEx
    {
        private MeterInstall_IDAL sysidal = new MeterInstall_DAL();

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
        }

        private void toolSearch_Click(object sender, EventArgs e)
        {
            SeachData();
        }

        void SeachData()
        {
            StringBuilder sb = new StringBuilder();
            bool isfirst = true;

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
                    isfirst = false;
                    sb.AppendFormat(" waterMeterProofreadingDate >'{0}' and waterMeterProofreadingDate < '{1}'", dt1, dt2);

                }

            }
            if (CHK_waterMeterSerialNumber.Checked)
            {
                int No1 = 0;
                int No2 = 0;

                if (!ValidateUtil.IsValidInt(TB_waterMeterSerialNumber_1.Text))
                {
                    MessageBox.Show("请重新输入出厂编号！");
                    return;
                }
                No1 = int.Parse(TB_waterMeterSerialNumber_1.Text);

                if (!ValidateUtil.IsValidInt(TB_waterMeterSerialNumber_2.Text))
                {
                    //MessageBox.Show("请重新输入出厂编号！");
                    //return;
                    TB_waterMeterSerialNumber_2.Text = "";
                }
                else
                {
                    No2 = int.Parse(TB_waterMeterSerialNumber_2.Text);
                }

                if (No2 < No1)
                {
                    MessageBox.Show("请重新输入出厂编号！");
                    return;
                }
                else if (No2 == No1)
                {
                    if (isfirst)
                    {
                        sb.AppendFormat(" waterMeterSerialNumber={0}", No1, No2);
                    }
                    else
                    {
                        sb.AppendFormat(" and waterMeterSerialNumber={0}", No1, No2);
                    }
                    isfirst = false;
                }
                else
                {
                    if (isfirst)
                    {
                        sb.AppendFormat(" waterMeterSerialNumber<>'' and waterMeterSerialNumber >{0} and waterMeterSerialNumber < {1} ", No1, No2);
                    }
                    else
                    {
                        sb.AppendFormat(" and waterMeterSerialNumber<>'' and waterMeterSerialNumber >{0} and waterMeterSerialNumber < {1}", No1, No2);
                    }
                    isfirst = false;
                }

            }

            if (!string.IsNullOrEmpty(CB_waterMeterProduct.Text) && !CB_waterMeterProduct.Text.Equals("全部"))
            {
                if (isfirst)
                {
                    sb.AppendFormat(" waterMeterProduct= '{0}'", CB_waterMeterProduct.Text);
                }
                else
                {
                    sb.AppendFormat(" and waterMeterProduct= '{0}'", CB_waterMeterProduct.Text);
                }
                isfirst = false;
            }
            if (!string.IsNullOrEmpty(CB_MeterState.SelectedValue.ToString()))
            {
                if (isfirst)
                {
                    sb.AppendFormat(" MeterState= '{0}'", CB_MeterState.SelectedValue);
                }
                else
                {
                    sb.AppendFormat(" and MeterState= '{0}'", CB_MeterState.SelectedValue);
                }
                isfirst = false;
            }

            if (!string.IsNullOrEmpty(CB_waterMeterSize.SelectedValue.ToString()))
            {
                if (isfirst)
                {
                    sb.AppendFormat(" Meter.waterMeterSizeId= '{0}'", CB_waterMeterSize.SelectedValue);
                }
                else
                {
                    sb.AppendFormat(" and Meter.waterMeterSizeId= '{0}'", CB_waterMeterSize.SelectedValue);
                }
                isfirst = false;
            }

            DataTable dtList = sysidal.GetListTable(sb.ToString());
            dgList.DataSource = dtList;
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

        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void Binddata()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("MeterState", "", "ID");
            ControlBindHelper.BindComboBoxData(this.CB_MeterState, dt, "StateDescribe", "ID", true);


            DataTable dt2 = new SqlServerHelper().GetDataTable("waterMeterSize", "", "waterMeterSizeId");
            ControlBindHelper.BindComboBoxData(this.CB_waterMeterSize, dt2, "waterMeterSizeValue", "waterMeterSizeId", true);

            DataTable dt3 = new SqlServerHelper().GetDataTable("View_MeterProduct", "", "waterMeterProduct");
            ControlBindHelper.BindComboBoxData(this.CB_waterMeterProduct, dt3, "waterMeterProduct", "MeterID", true);

        }

        private void dgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgList.CurrentRow != null)
            {
                string selectedID = dgList.CurrentRow.Cells["MeterID"].Value.ToString();
                if (dgList.CurrentRow.Cells["StateDescribe"].Value.ToString().Equals("在库"))
                {
                    Btn_Scrap.Enabled = true;
                }
                else
                {
                    Btn_Scrap.Enabled = false;
                }
            }
        }

        private void Btn_Scrap_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow != null)
            {
                Hashtable ht = new Hashtable();
                ht["METERSTATE"] = "2";
                new SqlServerHelper().UpdateByHashtable("Meter", "METERID", dgList.CurrentRow.Cells["MeterID"].Value.ToString(), ht);
            }
        }

        private void toolBatch_Click(object sender, EventArgs e)
        {
            FrmMeterImport frm = new FrmMeterImport();

            frm.ShowDialog();
        }

        private void toolExcel_Click(object sender, EventArgs e)
        {
            string strCaption = "水表在库情况表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dtPrint = GetDgvToTable(dgList);
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

            //DataTable dt = (DataTable)dgList.DataSource;
            DataTable dtPrint = GetDgvToTable(dgList);

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
                    if (obj != null && obj != DBNull.Value)
                        dr[countsub] = dgv.Rows[count].Cells[countsub].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
