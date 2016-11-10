using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetData;
using SysControl;
using System.Reflection;

namespace FinanceOS
{
    public partial class FrmFinanceCenter : DockContentEx
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        public FrmFinanceCenter()
        {
            InitializeComponent();
        }

       

        private void FrmFinanceCenter_Load(object sender, EventArgs e)
        {
            GetMenus();
        }

        private void GetMenus()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("Meter_Finance");
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
                        menu.AssemblyName = dr["AssemblyName"].ToString();
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
            try
            {
                string path = menu.AssemblyName;//项目的Assembly选项名称  
                string name = menu.AssemblyName + "." + menu.SProcessName; //类的名字  
                Form Frm = (Form)Assembly.Load(path).CreateInstance(name);
                Frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
