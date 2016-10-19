using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.DAL;
using DBinterface.IDAL;

namespace PersonalWork
{
    public partial class FrmApprove_Group : Form
    {
        public Hashtable ht = new Hashtable();
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        private string TaskID = string.Empty;

        public FrmApprove_Group()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void FrmApprove_Group_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
        }

        private void FrmApprove_Group_Shown(object sender, EventArgs e)
        {
            uC_ApproveList1.InitData(TaskID);
            uC_Approve_GroupInfos1.InitData(TaskID);

            string FrmAssemblyName = string.Empty;
            string FormName = string.Empty;

            if (sysidal.GetAssemblyNameDetail(ht["ResolveID"].ToString(), ref FrmAssemblyName, ref FormName))
            {
                CreateForm.ShowPannel(FormName, FrmAssemblyName, PL_Proc, ht);
            }

        }

        private void FrmApprove_Group_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}
