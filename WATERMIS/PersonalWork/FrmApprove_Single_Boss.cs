using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Common.WinDevices;
using DBinterface.DAL;
using DBinterface.IDAL;
using Common.DotNetUI;
using Common.DotNetData;

namespace PersonalWork
{
    public partial class FrmApprove_Single_Boss : Form
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
        private decimal _Abate = 0m;
        private decimal _TotalFee = 0m;

        public FrmApprove_Single_Boss()
        {
            InitializeComponent();
        }

        private void FrmApprove_Single_Boss_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            #region //2017-2-22 RONG
            bool IsAllowEdit = false;
            if (ht.Contains("Edit"))
            {
                if (bool.TryParse(ht["Edit"].ToString(), out IsAllowEdit))
                {

                }
            }
            Btn_Submit.Enabled = IsAllowEdit;
            Btn_Voided.Enabled = IsAllowEdit;
            #endregion
            _TotalFee = sysidal.GetLastFeeTotal(TaskID,PointSort);
            
        }

        private void FrmApprove_Single_Boss_Shown(object sender, EventArgs e)
        {
            InitView();
        }

        private void InitView()
        {
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
            }

            if (_TotalFee>0m)
            {
                LB_Tip.Text = "最多可减免："+_TotalFee+"元";
            }
            else
            {
                Abate.Text = "0";
                Abate.Enabled = false;
            }

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            ComputerName = new Computer().ComputerName;
            ip = new Computer().IpAddress;
            int count = sysidal.UpdateApprove_Single_defalut(ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), ip, ComputerName, PointSort, TaskID, UserOpinion.Text);

            if (count > 0)
            {
                if (_Abate != 0m)
                {
                    Hashtable hs = new Hashtable();
                    hs["Abate"] = _Abate;
                    new SqlServerHelper().Submit_AddOrEdit("Meter_WorkResolve", "ResolveID", ResolveID, hs);
                }
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

        private void Btn_More_Click_1(object sender, EventArgs e)
        {
            FrmChargePoint frm = new FrmChargePoint();
            frm.TaskID = TaskID;
            frm.DepartementID = "0";
            frm.InitData();
            frm.ShowDialog();
        }

        private void Abate_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(Abate.Text.Trim(), out _Abate))
            {
                if (_Abate>_TotalFee)
                {
                    MessageBox.Show("减免费用不能大于总费用！");
                    Abate.Text = "0";
                }
            }
            else
            {
                Abate.Text = "0";
            }
        }
    }
}
