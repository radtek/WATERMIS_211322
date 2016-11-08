using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SysControl
{
    public partial class FrmFileShowDel : Form
    {
        private string _UnsubscribeID = string.Empty;

        public string UnsubscribeID
        {
            get { return _UnsubscribeID; }
            set { _UnsubscribeID = value; }
        }

        private string _url = "";


        public FrmFileShowDel()
        {
            InitializeComponent();
        }

        private void FrmFileShowDel_Load(object sender, EventArgs e)
        {
            string strFilePaht = ConfigurationSettings.AppSettings["FilesPath"];
            _url = string.Format("{0}ShowEditFile.aspx?UnsubscribeID={1}", strFilePaht, _UnsubscribeID);

        }

        private void FrmFileShowDel_Shown(object sender, EventArgs e)
        {
            WB1.Visible = false;
            WB1.Navigate(new Uri(_url));
        }

        private void WB1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WB1.Refresh();
            WB1.Visible = true;
        }
    }
}
