using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using System.Data.SqlClient;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetData;
using System.IO;
using DBinterface;
using DBinterface.Model;
using System.Reflection;
using System.Collections;
using SysControl;

namespace PersonalWork
{
    public partial class FrmPersonalCenter : DockContentEx
    {
        public FrmPersonalCenter()
        {
            InitializeComponent();
        }

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        private object _UM = null;
        int _ShowSort = 10;

        private void FrmPersonalCenter_Load(object sender, EventArgs e)
        {
            GetMenus();
        }

        private void GetMenus()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("User_Approve", "", "Sort");
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
                        menu.AssemblyName = dr["AssemblyName"].ToString();
                        if (int.Parse(dr["Sort"].ToString())<_ShowSort)
                        {

                            _ShowSort = int.Parse(dr["Sort"].ToString());
                            _UM = menu;
                        }
                        FP.Controls.Add(menu);
                    }
                }
            }
            if (_UM!=null)
            {
                menu_Button_Open_Click(_UM, null);
            }

        }

        void menu_Button_Open_Click(object sender, EventArgs e)
        {
            UC_Menu UM = (UC_Menu)sender;
            CreateForm.ShowPannel(UM.SProcessName, UM.AssemblyName,this.PL,null);
        }

    }
}
