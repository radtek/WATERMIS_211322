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
    public partial class FrmUserPeccant_Approve : Form
    {
        public Hashtable ht = new Hashtable();
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        private string TaskID = string.Empty;
        private string _waterUserNO = string.Empty;

        public FrmUserPeccant_Approve()
        {
            InitializeComponent();
        }

       

        private void FrmUserPeccant_Approve_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
        }

        private void FrmUserPeccant_Approve_Shown(object sender, EventArgs e)
        {
            uC_ApproveList1.InitData(TaskID);
            Hashtable htt = new SqlServerHelper().GetHashtableById("User_Peccant", "TaskID", TaskID);

            if (htt.Contains("WATERUSERNO"))
            {
                _waterUserNO = htt["WATERUSERNO"].ToString();
                uC_UserInfos1.InitData(_waterUserNO);
                new SqlServerHelper().BindHashTableToForm(htt, this.panel1.Controls);
            }


            string FrmAssemblyName = string.Empty;
            string FormName = string.Empty;

            if (sysidal.GetAssemblyNameDetail(ht["ResolveID"].ToString(), ref FrmAssemblyName, ref FormName))
            {
                CreateForm.ShowPannel(FormName, FrmAssemblyName, PL_Proc, ht);
            }
        }

        private void FrmUserPeccant_Approve_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
