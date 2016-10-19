using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetData;
using SysControl;
using BASEFUNCTION;

namespace AppManage
{
    public partial class EquipmentManage : DockContentEx
    {
        public EquipmentManage()
        {
            InitializeComponent();
        }

        private EquipMent_IDAL sysidal = new EquipMent_DAL();



        private void EquipmentManage_Load(object sender, EventArgs e)
        {
            BindEquipmentList();
        }

        private void BindEquipmentList()
        {
            DataTable dt = sysidal.GetEquipment();
            if (DataTableHelper.IsExistRows(dt))
            {
                FP1.Controls.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    SysEquipment sq = new SysEquipment();
                    sq.MEID =int.Parse(dr["MEID"].ToString());
                    sq.MECode = dr["MECode"].ToString();
                    sq.UserName=dr["userName"].ToString();
                    sq.UserList = sysidal.GetLoginUser();
                    sq.SaveEvent += new EventHandler(sq_SaveEvent);
                    sq.DelEvent += new EventHandler(sq_DelEvent);
                    sq.Tag = 9999;
                    FP1.Controls.Add(sq);
                }
            }
        }

        void sq_DelEvent(object sender, EventArgs e)
        {
            SysEquipment sq = (SysEquipment)sender;
            int meid = sq.MEID;

            int result = sysidal.DeleteEquipment(meid);
            if (result>0)
            {
                MessageBox.Show("删除成功！");
                BindEquipmentList();
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }

        void sq_SaveEvent(object sender, EventArgs e)
        {
            SysEquipment sq = (SysEquipment)sender;
            int meid = sq.MEID;
            string LoginID = sq.SelectedID;

            int result = sysidal.UpdateEquipment(meid, LoginID);
            if (result>0)
            {
                MessageBox.Show("保存成功！");
                BindEquipmentList();
            }
            else
            {
                MessageBox.Show("保存失败！");
            }

        }

  
    }
}
