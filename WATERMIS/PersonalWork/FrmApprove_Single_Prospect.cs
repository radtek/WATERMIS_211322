using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using Common.DotNetUI;
using Common.WinDevices;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace PersonalWork
{
    public partial class FrmApprove_Single_Prospect : Form
    {

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;

        private bool skip = false;
        private string ComputerName = "";
        private string ip = "";
        private string DepartementID = "0";

        public FrmApprove_Single_Prospect()
        {
            InitializeComponent();
        }

        private void FrmApprove_Single_Default_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();

           
        }
        private void InitView()
        {
            Hashtable hs = new SqlServerHelper().GetHashtableById("Meter_Install_Single", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(hs, this.panel2.Controls);

            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);
            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();

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

                if (!string.IsNullOrEmpty(ht["ISCHARGE"].ToString()))
                {
                    if (bool.TryParse(ht["ISCHARGE"].ToString(), out IsCharge))
                    {
                        FP_Fee.Visible = IsCharge;
                        //添加收费项目
                        if (IsCharge)
                        {
                            FP_Fee.Controls.Clear();
                            ApproveDispose.BindFeeItemTextBox(this.FP_Fee,ResolveID);
                        }
                    }
                }
               
            }

        }

        private void FrmApprove_Single_Default_Shown(object sender, EventArgs e)
        {
            InitView();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht = new SqlServerHelper().GetHashTableByControl(this.panel2.Controls);
            new SqlServerHelper().Submit_AddOrEdit("Meter_Install_Single", "TaskID", TaskID, ht);

            Btn_Submit.Enabled = false;
            ComputerName = new Computer().ComputerName;
            ip = new Computer().IpAddress;
            int count = sysidal.UpdateApprove_Single_defalut(ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), ip, ComputerName, PointSort, TaskID);

            if (count > 0)
            {
                if (IsCharge)
                {
                    MessageBox.Show("审批成功！");
                    ApproveDispose.UpdateFeeItem(this.FP_Fee,ResolveID);
                }
                else
                {
                    MessageBox.Show("审批成功！");
                }
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
            ComputerName = new Computer().ComputerName;
            ip = new Computer().IpAddress;
            int count = sysidal.UpdateApprove_Voided(ResolveID, UserOpinion.Text.Trim(), ip, ComputerName, TaskID);

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
