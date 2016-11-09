using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace WATERMIS
{
    public partial class FrmHelp : Form
    {
        private string _url = "";

        public FrmHelp()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width, 100); 
        }

        private void FrmHelp_Load(object sender, EventArgs e)
        {
            string strFilePaht = ConfigurationSettings.AppSettings["FilesPath"];
            _url = string.Format("{0}Help.aspx", strFilePaht);
        }

        private void WB1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void FrmHelp_Shown(object sender, EventArgs e)
        {
            WB1.Navigate(new Uri(_url));
        }
    }
}
