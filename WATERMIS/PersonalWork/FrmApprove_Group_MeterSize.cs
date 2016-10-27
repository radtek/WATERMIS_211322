using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using DBinterface.Model;

namespace PersonalWork
{
    public partial class FrmApprove_Group_MeterSize : Form
    {
        public Meter_GroupMeterSize SelectedMeter;

        public FrmApprove_Group_MeterSize()
        {
            InitializeComponent();
        }

        private void FrmApprove_Group_MeterSize_Load(object sender, EventArgs e)
        {
            string _SelectedSize = "'";
            DataTable dt = new DataTable();
            if (SelectedMeter.GroupMeterSize_Items != null)
            {
                if (SelectedMeter.GroupMeterSize_Items.Count > 0)
                {
                    foreach (GroupMeterSize ms in SelectedMeter.GroupMeterSize_Items)
                    {
                        _SelectedSize += ms.waterMeterSizeId + "','";
                    }
                }
                _SelectedSize = _SelectedSize.TrimEnd('\'');
                _SelectedSize = _SelectedSize.TrimEnd(',');
                if (string.IsNullOrEmpty(_SelectedSize))
                {
                    dt = new SqlServerHelper().GetDataTable("waterMeterSize", "", "waterMeterSizeId");
                }
                else
                {
                    dt = new SqlServerHelper().GetDataTable("waterMeterSize", " waterMeterSizeId NOT IN (" + _SelectedSize + ")", "waterMeterSizeId");
                }
            }
            else
            {
                dt = new SqlServerHelper().GetDataTable("waterMeterSize", "", "waterMeterSizeId");
            }

            ControlBindHelper.BindComboBoxData(this.waterMeterSizeId, dt, "waterMeterSizeValue", "waterMeterSizeId");
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (MeterCount.ValidateState)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
