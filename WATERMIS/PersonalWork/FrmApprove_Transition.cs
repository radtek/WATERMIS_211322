using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;
using SysControl;

namespace PersonalWork
{
    public partial class FrmApprove_Transition : Form
    {
        public Hashtable ht = new Hashtable();
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        private string TaskID = string.Empty;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public FrmApprove_Transition()
        {
            InitializeComponent();
        }

        private void FrmApprove_Transition_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
        }

        private void FrmApprove_Transition_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FrmApprove_Transition_Shown(object sender, EventArgs e)
        {
            uC_ApproveList1.InitData(TaskID);

            Hashtable htm = new SqlServerHelper().GetHashtableById("Meter_Install_Transition", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(htm, this.panel1.Controls);

            string FrmAssemblyName = string.Empty;
            string FormName = string.Empty;

            if (sysidal.GetAssemblyNameDetail(ht["ResolveID"].ToString(), ref FrmAssemblyName, ref FormName))
            {
                CreateForm.ShowPannel(FormName, FrmAssemblyName, PL_Proc, ht);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmFileShow frm = new FrmFileShow();
            if (!string.IsNullOrEmpty(FileAgree.Text))
            {
                frm.UnsubscribeID = FileAgree.Text;
                frm.ShowDialog();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmFileShow frm = new FrmFileShow();
            if (!string.IsNullOrEmpty(FileReply.Text))
            {
                frm.UnsubscribeID = FileReply.Text;
                frm.ShowDialog();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmFileShow frm = new FrmFileShow();
            if (!string.IsNullOrEmpty(FileApply.Text))
            {
                frm.UnsubscribeID = FileApply.Text;
                frm.ShowDialog();
            }
        }
    }
}
