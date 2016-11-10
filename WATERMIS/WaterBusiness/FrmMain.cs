using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetData;
using SysControl;
using BASEFUNCTION;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace WaterBusiness
{
    public partial class FrmMain : DockContentEx
    {
        public WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel2;
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            GetMenus();
        }

        

        private void GetMenus()
        {
            DataTable dt = sysidal.GetWaterBusiness("");
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (sysidal.IsAuthority(dr["MenuID"].ToString()))
                    {
                        UC_Menu menu = new UC_Menu();
                        menu.ID = int.Parse(dr["MenuID"].ToString());
                        menu.SHeadImage = dr["ICO"].ToString();
                        menu.SLabelText = dr["MenuName"].ToString();
                        menu.SProcessName = dr["FrmName"].ToString();
                        menu.Button_Open_Click += new EventHandler(menu_Button_Open_Click);

                        FP.Controls.Add(menu);
                    }
                }
            }
        }

        void menu_Button_Open_Click(object sender, EventArgs e)
        {
            UC_Menu menu = (UC_Menu)sender;
            FrmBusiness frm = new FrmBusiness();
            frm.MenuID = menu.ID;
            frm.sTitle = menu.SLabelText;
            frm.PictureName = menu.SProcessName;
            GoTo(this, frm, true);
        }

        private void GoTo(System.Windows.Forms.Form frmParent, DockContentEx frmChildren, bool OpenMax)
        {
            ((DockContentEx)frmChildren).Show(this.dockPanel2);
        }


       
    }
}
