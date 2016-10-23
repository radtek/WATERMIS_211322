using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Common.DotNetUI;

namespace SysControl
{
    public partial class UC_MeterInfo : UserControl
    {
        private string _MeterID = "";

        public string MeterID
        {
            get { return _MeterID; }
            set { _MeterID = value; }
        }
        public UC_MeterInfo()
        {
            InitializeComponent();
        }

        private void UC_MeterInfo_Load(object sender, EventArgs e)
        {

        }
        public void InitData()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterMeterSize", "", "waterMeterSizeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterSizeId, dt, "waterMeterSizeValue", "waterMeterSizeId");

            dt = new SqlServerHelper().GetDataTable("Meter_Summary", "", "ID");
            ControlBindHelper.BindComboBoxData(this.isSummaryMeter, dt, "Value", "ID");

            dt = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterTypeId, dt, "waterMeterTypeValue", "waterMeterTypeId");

            dt = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterTypeIdChange, dt, "waterMeterTypeValue", "waterMeterTypeId");

            dt = new SqlServerHelper().GetDataTable("Meter_waterMeterState", "", "waterMeterStateID");
            ControlBindHelper.BindComboBoxData(this.waterMeterState, dt, "waterMeterState", "waterMeterStateID");

            dt = new SqlServerHelper().GetDataTable("V_WATERUSER_CONNECTWATERMETER", " isSummaryMeter='2'", "waterUserName");
            ControlBindHelper.BindComboBoxData(this.waterMeterParentId, dt, "waterUserName", "waterMeterId", true);

            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter", "MeterID", _MeterID);
            new SqlServerHelper().BindHashTableToForm(ht, this.Controls);
        }


    }
}
