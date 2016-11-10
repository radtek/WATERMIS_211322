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

        private void LB_Meter_Click(object sender, EventArgs e)
        {
            FrmGroupMeter_Show frm = new FrmGroupMeter_Show();
            frm.GroupID = (string)ht["GROUPID"];
            frm.ShowDialog();
        }

       

    }
}
