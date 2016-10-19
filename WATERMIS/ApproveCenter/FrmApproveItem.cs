using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Common.DotNetData;
using SysControl;
using BASEFUNCTION;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace ApproveCenter
{
    public partial class FrmApproveItem : DockContentEx
    {
        public int MenuID = 0;
        public string sTitle = "";
        public string PictureName = "";
        private Image img = null;
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public FrmApproveItem()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }
        private void FrmApproveItem_Load(object sender, EventArgs e)
        {
            this.Text = sTitle;

            if (MenuID != 0)
            {
                GetMeter_WaterBusiness_Sub();

                ShowFlowPicture();
            }
        }

        private void GetMeter_WaterBusiness_Sub()
        {
            DataTable dt = sysidal.GetApproveCenterSub(MenuID);
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
                        if (bool.Parse(dr["IsDefault"].ToString()))
                        {
                            CreateForm(menu.AssemblyName + "." + menu.SProcessName, menu.AssemblyName);
                        }
                        FP.Controls.Add(menu);
                    }
                }
            }
        }

        private void ShowFlowPicture()
        {
            if (File.Exists(Application.StartupPath + "\\MeterInstallPages\\FlowImages\\" + PictureName + ".JPG"))
            {
                img = Image.FromFile(Application.StartupPath + "\\MeterInstallPages\\FlowImages\\" + PictureName + ".JPG");
            }
        }

        void menu_Button_Open_Click(object sender, EventArgs e)
        {
            UC_Menu menu = (UC_Menu)sender;
            string AssemblyName = menu.AssemblyName;

            string btnname = menu.SProcessName;
            CreateForm(AssemblyName + "." + btnname, AssemblyName);

           
        }

        /// <summary>  
        /// 打开新的子窗体  
        /// </summary>  
        /// <param name="strName">窗体的类名</param>  
        /// <param name="AssemblyName">窗体所在类库的名称</param>   
        public void CreateForm(string strName, string AssemblyName)
        {
            try
            {
                string path = AssemblyName;//项目的Assembly选项名称  
                string name = strName; //类的名字  
                Form Frm = (Form)Assembly.Load(path).CreateInstance(name);
                Frm.FormBorderStyle = FormBorderStyle.None;
                Frm.Size = new Size(PL.Width, PL.Height);
                Frm.Dock = DockStyle.Fill;
                Frm.TopLevel = false;
                this.PL.Controls.Clear();
                this.PL.Controls.Add(Frm);

                Frm.Show();
            }
            catch (Exception ex)
            {

            }

        }

        private void FrmApproveItem_Shown(object sender, EventArgs e)
        {
            PL.BackgroundImage = img;
        }

    }
}
