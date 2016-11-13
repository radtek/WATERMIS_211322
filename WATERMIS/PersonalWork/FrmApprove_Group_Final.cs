using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using DBinterface.IDAL;
using Common.DotNetData;
using System.Collections;

namespace PersonalWork
{
    public partial class FrmApprove_Group_Final : Form
    {
        public FrmApprove_Group_Final()
        {
            InitializeComponent();
        }
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public Hashtable ht = new Hashtable();

        private string ComputerName = "";
        private string ip = "";

        private string _LastPointSort;

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (sysidal.IsChargeOverFinal(TaskID, _LastPointSort))
            {
                MessageBox.Show("收费完成！");
                Btn_Submit.Enabled = false;
                sysidal.UpdateApprove_Single_defalut(ResolveID, true, "已收费", ip, ComputerName, PointSort, TaskID);
            }
            else
            {
                MessageBox.Show("存在未结算项目,请结算完成后再操作!");
            }
        }

        private void FrmApprove_Group_Final_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            BindDepartmentFee();
        }
        private void BindDepartmentFee()
        {
            DataTable dt = sysidal.GetDepartMentFeeFinal(TaskID, PointSort);
            if (DataTableHelper.IsExistRows(dt))
            {
                _LastPointSort = dt.Rows[0]["LastPointSort"].ToString();
            }
        }
    }
}
