using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Common.DotNetUI;
using Common.DotNetData;

namespace PersonalWork
{
    public partial class FrmApprove_Group_MeterSelect : Form
    {
        public string GroupID;
        //public string MeterSizeId;
        //public string MeterSize;
        public List<string> SMeters=new List<string>();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public FrmApprove_Group_MeterSelect()
        {
            InitializeComponent();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FrmApprove_Group_MeterSelect_Load(object sender, EventArgs e)
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterMeterSize", "", "waterMeterSizeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterSizeId, dt, "waterMeterSizeValue", "waterMeterSizeId");

            //if (!string.IsNullOrEmpty(MeterSizeId))
            //{
            //    this.waterMeterSizeId.Text = MeterSize;
            //    this.waterMeterSizeId.Enabled = false;
            //}

            if (!string.IsNullOrEmpty(GroupID))
            {
                BindMeterSize();
            }
        }

        private void BindMeterSize()
        {
            FP.Controls.Clear();
            DataTable dt = new SqlServerHelper().GetDataTable("Meter", "waterMeterSizeId='" + waterMeterSizeId.SelectedValue + "' AND MeterState=0", "CreateDate");
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = dr["waterMeterSerialNumber"].ToString();
                    cb.Tag = dr["waterMeterSerialNumber"].ToString();
                    cb.Checked = SMeters == null ? false : SMeters.Contains(dr["waterMeterSerialNumber"].ToString());
                    cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
                    cb.AutoSize=false;
                    cb.Width = 90;

                    FP.Controls.Add(cb);
                }
            }
        }

        void cb_CheckedChanged(object sender, EventArgs e)
        {
             CheckBox cb=(CheckBox)sender;
             if (cb.Checked)
             {
                 SMeters.Add(cb.Tag.ToString());
             }
             else
             {
                 SMeters.Remove(cb.Tag.ToString());
             }
        }

        private void waterMeterSizeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMeterSize();
        }

        private void Btn_Selected_Click(object sender, EventArgs e)
        {
            foreach (Control CB in FP.Controls)
            {
                if (CB is CheckBox)
                {
                    CheckBox _cb=(CheckBox)CB;
                    if (!_cb.Checked)
                    {
                        _cb.Checked = true;
                    }
                }
            }
        }

        private void Btn_SelectedCancel_Click(object sender, EventArgs e)
        {
            foreach (Control CB in FP.Controls)
            {
                if (CB is CheckBox)
                {
                    CheckBox _cb = (CheckBox)CB;
                    if (_cb.Checked)
                    {
                        _cb.Checked = false;
                    }
                }
            }
        }

        
    }
}
