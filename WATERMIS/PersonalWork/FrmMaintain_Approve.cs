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

namespace PersonalWork
{
    public partial class FrmMaintain_Approve : Form
    {
        public Hashtable ht = new Hashtable();
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        private string TaskID = string.Empty;
        private string _waterUserNO = string.Empty;

        public FrmMaintain_Approve()
        {
            InitializeComponent();
        }
      
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BindMaintainType()
        {
            MaintainTypeID.DataSource = sysidal.GetMaintainType();
            MaintainTypeID.DisplayMember = "MaintainType";
            MaintainTypeID.ValueMember = "MaintainTypeID";
        }


        private void FrmMaintain_Approve_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            BindMaintainType();
        }

        private void FrmMaintain_Approve_Shown(object sender, EventArgs e)
        {
            uC_ApproveList1.InitData(TaskID);
            Hashtable htt = sysidal.GetMaintainByTaskID(TaskID);

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

        private void FrmMaintain_Approve_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
