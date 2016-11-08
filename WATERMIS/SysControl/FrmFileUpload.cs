using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Common.DotNetCode;

namespace SysControl
{
    public partial class FrmFileUpload : Form
    {
        private string _UnsubscribeID = "";

        public string UnsubscribeID
        {
            get { return _UnsubscribeID; }
            set { _UnsubscribeID = value; }
        }

        private string _ShowName = "";

        public string ShowName
        {
            get { return _ShowName; }
            set { _ShowName = value; }
        }

        private string _TableNames = "";

        public string TableNames
        {
            get { return _TableNames; }
            set { _TableNames = value; }
        }

        private string _url = "";

        public FrmFileUpload()
        {
            InitializeComponent();
        }

        private void FrmFileUpload_Load(object sender, EventArgs e)
        {
            string strFilePaht = ConfigurationSettings.AppSettings["FilesPath"];
            _url = string.Format("{0}Default.aspx?UnsubscribeID={1}&ShowName={2}&TableNames={3}", strFilePaht, System.Web.HttpUtility.UrlEncode(_UnsubscribeID, System.Text.Encoding.Unicode), System.Web.HttpUtility.UrlEncode(GB2312UnicodeConverter.ToUnicode(_ShowName), System.Text.Encoding.GetEncoding("GB2312")), System.Web.HttpUtility.UrlEncode(_TableNames, System.Text.Encoding.Unicode));

        }

        private void FrmFileUpload_Shown(object sender, EventArgs e)
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
