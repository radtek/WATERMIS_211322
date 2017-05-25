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
using DBinterface.Model;
using System.Collections;
using Common.DotNetCode;
using Common.DotNetUI;

namespace MeterInstall
{
    public partial class FrmEntering : Form
    {
        public string key;
        private  Meter_IDAL  mdal=new Meter_DAL();
        public FrmEntering()
        {
            InitializeComponent();
        }
        private void FrmEntering_Load(object sender, EventArgs e)
        {
            Binddata();
        }

        void initData()
        {
            if (!string.IsNullOrEmpty(key))
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter", "MeterID", key);

                new SqlServerHelper().BindHashTableToForm(ht, this.Controls);
            }

            Btn_Submit.Enabled = MeterState.SelectedValue.ToString().Equals("0");
        }

        private void Binddata()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterMeterSize", "", "waterMeterSizeId");

            ControlBindHelper.BindComboBoxData(this.waterMeterSizeId, dt, "waterMeterSizeValue", "waterMeterSizeId");

            DataTable dt2 = new SqlServerHelper().GetDataTable("MeterState", "", "ID");

            ControlBindHelper.BindComboBoxData(this.MeterState, dt2, "StateDescribe", "ID");

            initData();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (waterMeterSerialNumber.Text.Equals("") || waterMeterSizeId.Text.Equals("") || waterMeterStartNumber.Text.Equals("") || MeterState.Text.Equals(""))
            {
                MessageBox.Show("信息不完整！");
                return;
            }
            if (!waterMeterStartNumber.EmptyValidate(waterMeterStartNumber))
            {
                MessageBox.Show("请输入正确的初始读数!");
                return;
            }

            if (waterMeterSerialNumber.Text.Trim().Length < 5)
            {
                MessageBox.Show("输入正确的【出厂编号】！");
                return;
            }

            Btn_Submit.Enabled = false;
            Hashtable ht = new Hashtable();

            ht = new SqlServerHelper().GetHashTableByControl(this.Controls);

            if (string.IsNullOrEmpty(key))
            {
                if (new SqlServerHelper().IsExist("Meter", "waterMeterSerialNumber", waterMeterSerialNumber.Text.Trim(), "1=1"))
                {
                    MessageBox.Show("【出厂编号】已存在！");
                    return;
                }
                ht["METERID"] = Guid.NewGuid().ToString();
            }
            else
            {
                if (new SqlServerHelper().IsExist("Meter", "waterMeterSerialNumber", waterMeterSerialNumber.Text.Trim(), "METERID NOT IN ('"+key+"')"))
                {
                    MessageBox.Show("【出厂编号】已存在！");
                    return;
                }

                ht["METERID"] = key;
            }
            if (new SqlServerHelper().Submit_AddOrEdit("Meter", "METERID", key, ht))
            {
                mdal.MeterLogWrite(ht["METERID"].ToString(), "0", "【水表入库】-表号：" + waterMeterSerialNumber.Text.Trim() + "；口径：" + waterMeterSizeId.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void waterMeterStartNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
