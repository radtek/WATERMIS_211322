using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SYSMANAGE
{
    public partial class frmNoticeShow : Form
    {
        public frmNoticeShow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 发送人
        /// </summary>
        public string strFromName = "";

        /// <summary>
        /// 消息标题
        /// </summary>
        public string strTitle = "";

        /// <summary>
        /// 消息内容
        /// </summary>
        public string strContent = "";

        /// <summary>
        /// 消息级别
        /// </summary>
        public string strClass = "0";

        private void frmNoticeShow_Load(object sender, EventArgs e)
        {
            this.labContent.Text = strContent;
            this.labFromName.Text = strFromName;
            this.labTitle.Text = strTitle;
            if (strClass == "1")
                labClass.Text = "次要";
            else if (strClass == "2")
            {
                labClass.Text = "一般";
                labClass.ForeColor = Color.Green;
            }
            else if (strClass == "3")
            {
                labClass.Text = "重要";
                labClass.ForeColor = Color.Orange;
            }
            else if (strClass == "4")
            {
                labClass.Text = "紧急";
                labClass.ForeColor = Color.Red;
            }
        }
    }
}
