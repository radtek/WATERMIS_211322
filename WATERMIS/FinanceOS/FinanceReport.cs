using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BASEFUNCTION;

namespace FinanceOS
{
    public partial class FinanceReport : DockContentEx
    {
        public FinanceReport()
        {
            InitializeComponent();
        }

        private void FinanceReport_Load(object sender, EventArgs e)
        {
            string strFilePaht = ConfigurationSettings.AppSettings["FilesPath"];
            string _url = string.Format("{0}Receipted.html", strFilePaht);
            WB1.Navigate(new Uri(_url));

            _url = string.Format("{0}Receivable.html", strFilePaht);
            WB2.Navigate(new Uri(_url));

            _url = string.Format("{0}DepartmentFee.html", strFilePaht);
            WB3.Navigate(new Uri(_url));

            _url = string.Format("{0}FinanceMonth.html", strFilePaht);
            WB4.Navigate(new Uri(_url));
        }

        private void WB1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WB1.Refresh();
        }

        private void WB2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WB2.Refresh();
        }

        private void WB3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WB3.Refresh();
        }

        private void WB4_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WB4.Refresh();
        }
    }
}
