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

namespace MeterBusiness
{
    public partial class FrmEntering : DockContentEx
    {
       // private MeterInstall_IDAL sysidal = new MeterInstall_DAL();
        public string key;
        public FrmEntering()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //Meter_Model model = new Meter_Model();

            if (waterMeterSerialNumber.Text.Trim().Length<5)
            {
                MessageBox.Show("输入正确的【出厂编号】！");
                return;
            }

            Hashtable ht = new Hashtable();

            ht = new SqlServerHelper().GetHashTableByControl(this.Controls);

            if (string.IsNullOrEmpty(key))
            {
                ht["METERID"] = Guid.NewGuid().ToString();
            }
            else
            {
                ht["METERID"] = key;
            }

            //model = sysidal.GetModelByControl(this.Controls);

            //model.MeterID = Guid.NewGuid().ToString();


            // sysidal.Add(model);

           // new SqlServerHelper().InsertByHashtable("Meter", ht);
            if (new SqlServerHelper().Submit_AddOrEdit("Meter", "METERID", key, ht))
            {
                this.DialogResult = DialogResult.OK;
                this.Tag = waterMeterSerialNumber.Text;
                this.Close();
            }
            
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
        }


        private void Binddata()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterMeterSize", "", "waterMeterSizeId");

            ControlBindHelper.BindComboBoxData(this.waterMeterSizeId, dt, "waterMeterSizeValue", "waterMeterSizeId");

            DataTable dt2 = new SqlServerHelper().GetDataTable("MeterState", "", "ID");

            ControlBindHelper.BindComboBoxData(this.MeterState, dt2, "StateDescribe", "ID");

            initData();
        }

        private void waterMeterSerialNumber_TextChanged(object sender, EventArgs e)
        {
            IsAllowSubmit();
        }

        private void IsAllowSubmit()
        {
            if (waterMeterSerialNumber.Text.Equals("") || waterMeterSizeId.Text.Equals("") || waterMeterStartNumber.Text.Equals("") || MeterState.Text.Equals(""))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }




    }
}
