using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace SYSMANAGE
{
    public partial class frmNotice : Form
    {
        public frmNotice()
        {
            InitializeComponent();
        }

        BLLMESSAGERECEIVE BLLMESSAGERECEIVE = new BLLMESSAGERECEIVE();

        /// <summary>
        /// 窗体标题
        /// </summary>
        public string strFormTitle = "";

        /// <summary>
        /// 消息ID
        /// </summary>
        public string strReceiveID = "";

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

        /// <summary>
        /// caozuo有两个值一个是 load表示要向不透明方向增加量，也就是说会慢慢看清楚，还有一个close 表示要向透明方向增加量，这样会慢慢的看不到窗体
        /// </summary>
        string strCaozuo = "";
        private void frmNotice_Load(object sender, EventArgs e)
        {
            this.Text = strFormTitle;

            object obj=
            this.labTitle.Text = strTitle;
            this.labFrom.Text = strFromName;
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

            try
            {
                //让窗体加载时显示到右下角
                int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - 259;
                int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - 200;
                this.SetDesktopLocation(x, y);

                //渐变显示这里表示加载
                strCaozuo = "load";
                //this.Opacity = 0;
            }
            catch (Exception)
            {

            }
            trClose.Enabled = true;
        }

        private void trClose_Tick(object sender, EventArgs e)
        {
            trShade.Enabled = true;
            strCaozuo = "close";//关闭窗体
        }

        private void trShade_Tick(object sender, EventArgs e)
        {
            if (strCaozuo == "load")
            {
                this.Opacity += 0.09;
            }
            else if (strCaozuo == "close")
            {
                this.Opacity = this.Opacity - 0.09;
                if (this.Opacity == 0)
                    this.Close();
            }
        }

        private void frmNotice_MouseEnter(object sender, EventArgs e)
        {
            //停止定时关闭
            trClose.Enabled = false;
            //开始渐变加载
            strCaozuo = "load";
        }

        private void frmNotice_MouseLeave(object sender, EventArgs e)
        {
            trClose.Enabled = true;
        }

        private void labContent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNoticeShow frm = new frmNoticeShow();
            frm.strTitle = this.strTitle;
            frm.strContent = this.strContent;
            frm.strFromName = this.strFromName;
            frm.strClass = strClass;
            frm.Show();
            try
            {
                BLLMESSAGERECEIVE.UpdateReadSign(strReceiveID);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
