using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.DotNetData;

namespace SysControl
{
    public partial class UC_MeterSize : UserControl
    {
        public UC_MeterSize()
        {
            InitializeComponent();
        }

        private string _waterMeterSizeId;

        public string WaterMeterSizeId
        {
            get {  return _waterMeterSizeId; }
            set { _waterMeterSizeId = value; WaterMeterSize = FindSizeName(_waterMeterSizeId); }
        }

        private string _waterMeterSize;

        public string WaterMeterSize
        {
            get { _waterMeterSize = LB_Size.Text; return _waterMeterSize; }
            set { _waterMeterSize = value; LB_Size.Text = _waterMeterSize; }
        }

        private string FindSizeName(string _waterMeterSizeId)
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterMeterSize", "waterMeterSizeId='" + _waterMeterSizeId + "'", "waterMeterSizeId");
            if (DataTableHelper.IsExistRows(dt))
            {
                return dt.Rows[0]["waterMeterSizeValue"].ToString();
            }
            else
            {
                return "";
            }
        }
        private int _MeterCount;

        public int MeterCount
        {
            get { _MeterCount = int.Parse(LB_Count.Text); return _MeterCount; }
            set { _MeterCount = value; LB_Count.Text = _MeterCount.ToString(); }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler DelEvent;

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (DelEvent != null)
                DelEvent(this, e);
        }


    }
}
