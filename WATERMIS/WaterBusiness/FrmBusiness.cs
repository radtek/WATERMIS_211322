using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using Common.DotNetData;
using SysControl;
using System.Reflection;
using MeterInstall;
using System.IO;
using System.Threading;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace WaterBusiness
{
    public partial class FrmBusiness : DockContentEx
    {
        public int MenuID=0;
        public string sTitle = "";
        public string PictureName = "";
        private Image img = null;
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        public FrmBusiness()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  
                return cp;
            }
        }
        private void FrmBusiness_Load(object sender, EventArgs e)
        {
            this.Text = sTitle;

            if (MenuID!=0)
            {
                GetMeter_WaterBusiness_Sub();

                ShowFlowPicture();
            }
        }

        private void ShowFlowPicture()
        {
            if (File.Exists(Application.StartupPath + "\\MeterInstallPages\\FlowImages\\" + PictureName + ".JPG"))
            {
                img = Image.FromFile(Application.StartupPath + "\\MeterInstallPages\\FlowImages\\" + PictureName + ".JPG");
            }
        }

        private void GetMeter_WaterBusiness_Sub()
        {
            DataTable dt = sysidal.GetWaterBusinessSub(MenuID);
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (sysidal.IsAuthority(dr["SubID"].ToString()))
                    {
                        UC_Menu menu = new UC_Menu();
                        menu.ID = int.Parse(dr["SubID"].ToString());
                        menu.SHeadImage = dr["ICO"].ToString();
                        menu.SLabelText = dr["MenuName"].ToString();
                        menu.SProcessName = dr["FrmName"].ToString();
                        menu.Button_Open_Click += new EventHandler(menu_Button_Open_Click);
                        menu.AssemblyName = dr["AssemblyName"].ToString();
                        FP.Controls.Add(menu);
                    }
                }
            }
        }

        void menu_Button_Open_Click(object sender, EventArgs e)
        {
            UC_Menu menu = (UC_Menu)sender;
            CreateForm.ShowPannel(menu.SProcessName, menu.AssemblyName, this.PL, null);
        }

        private void FrmBusiness_Shown(object sender, EventArgs e)
        {
            PL.BackgroundImage = img;
        }

    }
}
