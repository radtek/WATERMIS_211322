using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;

namespace SysControl
{
    public partial class UC_Approve_GroupInfos : UserControl
    {
        private Hashtable ht = new Hashtable();
        public UC_Approve_GroupInfos()
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
            if (!string.IsNullOrEmpty(TaskID))
            {
                ht = sysidal.GetMeter_Install_GroupInfos(TaskID);
                new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);
            }
        }

        private void LB_More_Click(object sender, EventArgs e)
        {
            FrmGroupPeople_Show frm = new FrmGroupPeople_Show();
            frm.GroupID = (string)ht["GROUPID"];
            frm.ShowDialog();
        }

       

    }
}
