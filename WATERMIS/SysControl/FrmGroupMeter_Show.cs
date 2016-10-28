using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetData;

namespace SysControl
{
    public partial class FrmGroupMeter_Show : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public string GroupID = string.Empty;

        public FrmGroupMeter_Show()
        {
            InitializeComponent();
        }

        private void FrmGroupMeter_Show_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(GroupID))
            {
                BindMeterSize();
            }
        }
        private void BindMeterSize()
        {
            FP.Controls.Clear();
            DataTable dt = new SqlServerHelper().GetDataTable("Meter_Design", "GroupID='" + GroupID + "'", "CreateDate");
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_MeterSize UM = new UC_MeterSize();
                    UM.WaterMeterSizeId = dr["waterMeterSizeId"].ToString();
                    UM.MeterCount = int.Parse(dr["MeterCount"].ToString());
                    FP.Controls.Add(UM);
                }
            }
        }

    }
}
