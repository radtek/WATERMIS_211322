using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using System.Collections;
using Common.DotNetUI;
using Common.WinDevices;

namespace PersonalWork
{
    public partial class FrmDisuse_Over : Form
    {

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;

        private bool skip = false;
        private string DepartementID = "0";


        public FrmDisuse_Over()
        {
            InitializeComponent();
        }

        private void InitView()
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();
                object objIsPass = ht["ISPASS"];
                if (objIsPass != null && objIsPass != DBNull.Value && Convert.ToBoolean(objIsPass))
                    IsPass.Checked = true;
                else
                    IsPass.Checked = false;

                if (ht["MAKESKIP"] != null && ht["MAKEPOINTID"] != null)//是否显示跳转
                {
                    skip = (bool)ht["MAKESKIP"];
                    if (skip)
                    {
                        IsSkip.Visible = true;
                        LB_GoPointID.Visible = true;
                        CB_GoPointID.Visible = true;
                        string sqlstr = string.Format("SELECT PointName,PointSort  FROM Meter_WorkPoint WHERE WorkFlowID='{0}' AND PointSort IN ({1}) ORDER BY PointSort", ht["WORKFLOWID"].ToString(), ht["GOPOINTID"].ToString());
                        DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                        ControlBindHelper.BindComboBoxData(this.CB_GoPointID, dt, "PointName", "PointSort");
                    }
                }
                if (!string.IsNullOrEmpty(ht["ISVOIDED"].ToString()))//是否显示报废
                {
                    bool isvisable = false;
                    if (bool.TryParse(ht["ISVOIDED"].ToString(), out isvisable))
                        Btn_Voided.Visible = isvisable;
                }
            }

        }

        void Btn_More_Click(object sender, EventArgs e)
        {
            FrmChargePoint frm = new FrmChargePoint();
            frm.TaskID = TaskID;
            frm.DepartementID = DepartementID;
            frm.InitData();
            frm.ShowDialog();
        }

        private void Btn_Over_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你将结束并完成本审批，是否要继续！", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (sysidal.SetTaskOver("Meter_Disuse", TaskID))
                {
                    MessageBox.Show("结束并完成该审批！");
                }
            }

        }

        private void FrmDisuse_Over_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            InitView();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            int count = sysidal.UpdateApprove_defalut("Meter_Disuse", ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), PointSort, TaskID);

            if (count > 0)
            {
                MessageBox.Show("审批成功！");
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

        private void IsPass_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPass.Checked)
            {
                IsPass.Text = "同意";
                if (skip)
                {
                    IsSkip.Visible = false;
                    LB_GoPointID.Visible = false;
                    CB_GoPointID.Visible = false;
                    IsSkip.Checked = false;
                    CB_GoPointID.Text = "";
                }
            }
            else
            {
                IsPass.Text = "不同意";
                if (skip)
                {
                    IsSkip.Visible = true;
                    LB_GoPointID.Visible = true;
                    CB_GoPointID.Visible = true;
                }
            }
        }

        private void Btn_Voided_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            Btn_Voided.Enabled = false;
            string ComputerName = new Computer().ComputerName;
            string ip = new Computer().IpAddress;
            int count = sysidal.UpdateApprove_Voided_ByTableName("Meter_Disuse", ResolveID, UserOpinion.Text.Trim(), ip, ComputerName, TaskID);

            if (count > 0)
            {
                MessageBox.Show("作废完成！");
            }
            else
            {
                MessageBox.Show("作废失败！");
                Btn_Submit.Enabled = true;
                Btn_Voided.Enabled = true;
            }
        }
    }
}
