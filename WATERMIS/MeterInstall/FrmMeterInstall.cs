using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BASEFUNCTION;


namespace MeterInstall
{
    public partial class FrmMeterInstall : Form
    {
        public FrmMeterInstall()
        {
            InitializeComponent();
        }


        private void FrmMeterInstall_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\MeterInstallPages\\UserIntro.htm"))
            {
                webBrowser0.Navigate(Application.StartupPath + "\\MeterInstallPages\\UserIntro.htm");
            }
        }

        private void Btn_Single_Click(object sender, EventArgs e)
        {
            FrmSingle frm = new FrmSingle();
            frm.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                   
                    break;
                case 1:
                    if (File.Exists(Application.StartupPath + "\\MeterInstallPages\\FlowInstall.htm"))
                    {
                        webBrowser1.Navigate(Application.StartupPath + "\\MeterInstallPages\\FlowInstall.htm");
                    }
                    break;
                case 2:
                    if (File.Exists(Application.StartupPath + "\\MeterInstallPages\\FlowTransition.htm"))
                    {
                        webBrowser2.Navigate(Application.StartupPath + "\\MeterInstallPages\\FlowTransition.htm");
                    }
                    break;
                case 3:
                    if (File.Exists(Application.StartupPath + "\\MeterInstallPages\\FlowGroup.htm"))
                    {
                        webBrowser3.Navigate(Application.StartupPath + "\\MeterInstallPages\\FlowGroup.htm");
                    }
                    break;
               
                default:
                    break;
            }
        }

        private void Btn_Group_Click(object sender, EventArgs e)
        {
            FrmGroup frm = new FrmGroup();
            frm.ShowDialog();
        }

        

       
    }
}
