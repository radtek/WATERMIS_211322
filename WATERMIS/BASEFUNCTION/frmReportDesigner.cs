using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport;

namespace BASEFUNCTION
{
    public partial class frmReportDesigner : DockContentEx
    {
        public frmReportDesigner()
        {
            InitializeComponent();
        }
        private void frmReportDesigner_Load(object sender, EventArgs e)
        {
            FastReport.Design.StandardDesigner.DesignerControl designerControl1 = new FastReport.Design.StandardDesigner.DesignerControl();
            designerControl1.Parent = this;
            designerControl1.Dock = DockStyle.Fill;
            designerControl1.Show();
            Report report = new Report();
            designerControl1.Report = report;
            designerControl1.RefreshLayout();
        }
    }
}
