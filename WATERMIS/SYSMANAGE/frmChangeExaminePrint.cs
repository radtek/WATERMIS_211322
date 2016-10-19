using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport;
using BASEFUNCTION;

namespace SYSMANAGE
{
    public partial class frmChangeExaminePrint : Form
    {
        public frmChangeExaminePrint()
        {
            InitializeComponent();
        }

        
        Messages mes = new Messages();
        private void btPrint_Click(object sender, EventArgs e)
        {
            if(txtReason.Text=="")
            {
                if(mes.ShowQ("原因为空,确定要打印吗?")!=DialogResult.OK)
                    return;
            }
            #region
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\变更审批表模板.frx");
                (report1.FindObject("txtName") as FastReport.TextObject).Text = txtName.Text;
                (report1.FindObject("txtNO") as FastReport.TextObject).Text = txtNO.Text;
                (report1.FindObject("txtAddress") as FastReport.TextObject).Text = txtAddress.Text;
                (report1.FindObject("txtReason") as FastReport.TextObject).Text = "变更原因:"+txtReason.Text;
                //report1.Show();
                report1.PrintSettings.ShowDialog = false;
                report1.Prepare();
                report1.Print();
            }
            catch (Exception exx)
            {
                mes.Show(exx.Message);
                return;
            }
            finally
            {
                // free resources used by report
                report1.Dispose();
            }
            #endregion
        }
    }
}
