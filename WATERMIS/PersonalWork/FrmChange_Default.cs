using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.DAL;
using DBinterface.IDAL;
using Common.DotNetUI;
using Common.WinDevices;

namespace PersonalWork
{
    public partial class FrmChange_Default : Form
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

        public FrmChange_Default()
        {
            InitializeComponent();
        }

        private void FrmChange_Default_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
        }

        private void FrmChange_Default_Shown(object sender, EventArgs e)
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

                if (!string.IsNullOrEmpty(ht["ISCHARGE"].ToString()))
                {
                    if (bool.TryParse(ht["ISCHARGE"].ToString(), out IsCharge))
                    {
                        FP_Fee.Visible = IsCharge;
                        //添加收费项目
                        if (IsCharge)
                        {
                            FP_Fee.Controls.Clear();
                            ApproveDispose.BindFeeItemTextBox(this.FP_Fee, ResolveID);

                            if (sysidal.IsHaveLastFeeItems(TaskID, PointSort))
                            {
                                Btn_More.Visible = true;
                                Btn_More.Left = FP_Fee.Left;
                                Btn_More.Top = FP_Fee.Top + FP_Fee.Height + 10;
                                DepartementID = ht["DEPARTEMENTID"].ToString();
                                Btn_More.Click += new EventHandler(Btn_More_Click);
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(ht["ISVIEWCHARGE"].ToString()))
                {
                    bool IsViewCharge = false;
                    if (bool.TryParse(ht["ISVIEWCHARGE"].ToString(), out IsViewCharge))
                    {
                        if (!FP_Fee.Visible)
                        {
                            FP_Items.Left = FP_Fee.Left;
                            FP_Items.Top = FP_Fee.Top;
                            FP_Items.Height += FP_Fee.Height;
                        }
                        FP_Items.Visible = IsViewCharge;

                        if (IsViewCharge)
                        {
                            FP_Items.Controls.Clear();
                            //查看所有收费项目
                            ApproveDispose.BindFeeItemLabel(this.FP_Items, TaskID, PointSort);
                        }
                    }

                }
                else
                {
                    if (FP_Fee.Visible)
                    {
                        FP_Fee.Height += FP_Items.Height;
                    }
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
            int count = sysidal.UpdateApprove_Voided_ByTableName("Meter_Change", ResolveID, UserOpinion.Text.Trim(), ip, ComputerName, TaskID);

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

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            ComputerName = new Computer().ComputerName;
            ip = new Computer().IpAddress;
            int count = sysidal.UpdateApprove_defalut("Meter_Change", ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), ip, ComputerName, PointSort, TaskID);

            if (count > 0)
            {
                if (IsCharge)
                {
                    MessageBox.Show("审批成功！");
                    ApproveDispose.UpdateFeeItem(this.FP_Fee, ResolveID);
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

    }
}
