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

    }
}
