using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace SysControl
{
    public partial class UC_UserSearch : UserControl
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler BtnSearchEvent;

        public UC_UserSearch()
        {
            InitializeComponent();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            dgWaterUser.DataSource = sysidal.GetWaterUserList(this.groupBox1.Controls);
        }

        private void dgWaterUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BtnSearchEvent != null)
            {
                BtnSearchEvent(sender, e);
            }   
        }

        private void Clear()
        {
            new SqlServerHelper().ClearControls(groupBox1.Controls);
            dgWaterUser.DataSource = null;
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btSearch_Click(null,null);
        }
    }
}
