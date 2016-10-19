using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace SysControl
{
    public partial class UC_ApproveList : UserControl
    {
        public UC_ApproveList()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        public void InitData(string TaskID)
        {
            dgPoint.DataSource = sysidal.GetDataTableApproveList(TaskID);
        }
    }
}
