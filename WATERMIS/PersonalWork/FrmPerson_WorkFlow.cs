using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface;
using DBinterface.IDAL;
using DBinterface.DAL;
using System.Collections;
using System.Reflection;
using System.IO;

namespace PersonalWork
{
    public partial class FrmPerson_WorkFlow : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public FrmPerson_WorkFlow()
        {
            InitializeComponent();
        }

        private void FrmPerson_WorkFlow_Load(object sender, EventArgs e)
        {
            FlowLib FL = new FlowLib();
            FL.GetFlowTree("0");
            dgList1.DataSource = FL.DtFlowTree;
        }

        private void dgList1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string workcode = dgList1.CurrentRow.Cells["WorkCode"].Value.ToString();
            if (File.Exists(Application.StartupPath + "\\MeterInstallPages\\FlowImages\\" + workcode + ".JPG"))
            {
                FrmShowFlowPicture frm = new FrmShowFlowPicture();
                frm.PictureName = Application.StartupPath + "\\MeterInstallPages\\FlowImages\\" + workcode + ".JPG";
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
      
    }
}
