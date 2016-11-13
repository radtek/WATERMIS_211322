using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetFile;
using Common.DotNetData;
using System.Collections;
using DBinterface.Model;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace MeterInstall
{
    public partial class FrmMeterImport : Form
    {

        Meter_ModelList MM = new Meter_ModelList();
        List<Hashtable> Lht = new List<Hashtable>();

        public FrmMeterImport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            TB_File.Text = openFileDialog1.FileName;
            OpenExcel();
        }

        private void OpenExcel()
        {
            DataTable dt = ExcelToDataSet.Load(TB_File.Text).Tables[0];
            if (DataTableHelper.IsExistRows(dt))
            {
                dgList.DataSource = dt;
                LB_Count.Text = dt.Rows.Count.ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    Hashtable ht = new Hashtable();
                    //Meter_Model md = new Meter_Model();
                    int SerialNumber = 0;
                    if (int.TryParse(dr[0].ToString(), out SerialNumber))
                    {
                        // md.waterMeterSerialNumber = SerialNumber.ToString();
                        ht["waterMeterSerialNumber"] = SerialNumber;
                    }
                    else
                    {
                        MessageBox.Show("出厂编号格式不正确,请重新编辑Excel");
                        return;
                    }

                    DataTable dtSize = new SqlServerHelper().GetDataTable("waterMeterSize", " waterMeterSizeValue LIKE '%" + dr[1].ToString() + "%' ", " waterMeterSizeId ");
                    if (DataTableHelper.IsExistRows(dtSize))
                    {
                        //md.waterMeterSizeId = dtSize.Rows[0][0].ToString();
                        ht["waterMeterSizeId"] = dtSize.Rows[0][0].ToString();
                    }
                    else
                    {
                        MessageBox.Show("未检测到口径'" + dr[1].ToString() + "',请重新编辑Excel");
                        return;
                    }

                    int StartNumber = 0;
                    if (int.TryParse(dr[2].ToString(), out StartNumber))
                    {
                        // md.waterMeterStartNumber = StartNumber;
                        ht["waterMeterStartNumber"] = StartNumber;
                    }
                    else
                    {
                        MessageBox.Show("初始读数格式不正确,请重新编辑Excel");
                        return;
                    }

                    int MaxRange = 0;
                    if (int.TryParse(dr[3].ToString(), out MaxRange))
                    {
                        //md.waterMeterMaxRange = MaxRange;
                        ht["waterMeterMaxRange"] = MaxRange;
                    }
                    else
                    {
                        MessageBox.Show("最大量程格式不正确,请重新编辑Excel");
                        return;
                    }

                    //md.waterMeterProduct = dr[4].ToString();
                    //md.waterMeterMode = dr[5].ToString();
                    ht["waterMeterProduct"] = dr[4].ToString();
                    ht["waterMeterMode"] = dr[5].ToString();

                    DateTime dtime = DateTime.Now;
                    if (DateTime.TryParse(dr[6].ToString(), out dtime))
                    {
                        //md.waterMeterProofreadingDate = dtime;
                        ht["waterMeterProofreadingDate"] = dtime;
                    }
                    else
                    {
                        MessageBox.Show("鉴定日期格式不正确,请输入例如'2016-11-01'格式数据,请重新编辑Excel");
                        return;
                    }

                    //md.MEMO = dr[8].ToString();

                    //md.MeterID = Guid.NewGuid().ToString();
                    //md.CreateDate = DateTime.Now;
                    ht["waterMeteProofreadingPeriod"] = dr[7].ToString();
                    ht["MEMO"] = dr[8].ToString();

                    ht["MeterID"] = Guid.NewGuid().ToString();
                    ht["CreateDate"] = DateTime.Now.ToString();

                    //MM.MeterModelItem.Add(md);
                    Lht.Add(ht);
                }
                Btn_Import.Enabled = true;
            }
            // LB_Vaild.Text = MM.MeterModelItem.Count.ToString();
            LB_Vaild.Text = Lht.Count.ToString();
        }

        private void FrmMeterImport_Load(object sender, EventArgs e)
        {
            
        }

        private void Btn_Import_Click(object sender, EventArgs e)
        {
            Btn_Import.Enabled = false;
            Meter_IDAL sysidal = new Meter_DAL();

            int count = 0;

            //foreach (Meter_Model md in MM.MeterModelItem)
            //{
            //    if (sysidal.Add(md))
            //        count++;

            //}
            foreach (Hashtable ht in Lht)
            {
                if (new SqlServerHelper().Submit_AddOrEdit("Meter", "MeterID", "", ht))
                {
                    count++;
                }
            }

            if (count > 0)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("成功导入" + count.ToString() + "条数据！");
                this.Close();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe",System.AppDomain.CurrentDomain.BaseDirectory+ "TemPlates\\水表导入模板.xls");  
        }
    }
}
