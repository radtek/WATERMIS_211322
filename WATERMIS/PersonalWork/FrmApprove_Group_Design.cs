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
using Common.DotNetData;
using DBinterface.Model;
using SysControl;
using System.Data.SqlClient;

namespace PersonalWork
{
    public partial class FrmApprove_Group_Design : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;

        private string _GroupID;
        private Meter_GroupMeterSize MG = new Meter_GroupMeterSize();
        private List<GroupMeterSize> MS = new List<GroupMeterSize>();

        private bool skip = false;
        private string ComputerName = "";
        private string ip = "";
        private string DepartementID = "0";

        private int _MeterCount = 0;

        public FrmApprove_Group_Design()
        {
            InitializeComponent();
        }

        private void FrmApprove_Group_Design_Load(object sender, EventArgs e)
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
            InitView();
        }
        private void InitView()
        {
            Hashtable hu = new SqlServerHelper().GetHashtableById("Meter_Install_Group", "TaskID", TaskID);
            if (hu.Contains("METERCOUNT"))
            {
                _GroupID = hu["GROUPID"].ToString();
                if (!string.IsNullOrEmpty(hu["METERCOUNT"].ToString()))
                {
                    _MeterCount = int.Parse(hu["METERCOUNT"].ToString());
                    MeterCount.Text = hu["METERCOUNT"].ToString();
                    BindMeterSize();
                    
                }
            }

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
                        }
                    }
                }
            }
        }

        private void BindMeterSize()
        {
            FP.Controls.Clear();
            _MeterCount = 0;
            DataTable dt = new SqlServerHelper().GetDataTable("Meter_Design", "GroupID='" + _GroupID + "'", "CreateDate");
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GroupMeterSize GM = new GroupMeterSize();
                    GM.GroupID = dr["GroupID"].ToString();
                    GM.waterMeterSizeId = dr["waterMeterSizeId"].ToString();
                    GM.MeterCount = int.Parse(dr["MeterCount"].ToString());
                    _MeterCount += GM.MeterCount;
                    GM.Memo = dr["Memo"].ToString();

                    MS.Add(GM);
                    UC_MeterSize UM = new UC_MeterSize();
                    UM.WaterMeterSizeId = dr["waterMeterSizeId"].ToString();
                    UM.MeterCount = int.Parse(dr["MeterCount"].ToString());
                    UM.DelEvent += new EventHandler(UM_DelEvent);
                    FP.Controls.Add(UM);
                }
                MG.GroupMeterSize_Items = MS;
                MeterCount.Text = _MeterCount.ToString();
            }
        }

        void UM_DelEvent(object sender, EventArgs e)
        {
            UC_MeterSize UM = (UC_MeterSize)sender;

            for (int i = 0; i < MS.Count; i++)
            {
                if (MS[i].waterMeterSizeId == UM.WaterMeterSizeId)
                {
                    MS.RemoveAt(i);
                    _MeterCount -= UM.MeterCount;
                    MeterCount.Text = _MeterCount.ToString();
                    FP.Controls.Remove(UM);
                    MG.GroupMeterSize_Items = MS;
                    break;
                }
            }

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            int count = sysidal.UpdateApprove_defalut("Meter_Install_Group", ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), PointSort, TaskID);

            if (count > 0)
            {
                if (IsCharge)
                {
                    ApproveDispose.UpdateFeeItem(this.FP_Fee, ResolveID);
                    SaveGroupMeter();
                    MessageBox.Show("审批成功！");
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

        private void SaveGroupMeter()
        {
            new SqlServerHelper().DeleteData("Meter_Design", "GroupID", _GroupID);
            foreach (GroupMeterSize GM in MG.GroupMeterSize_Items)
            {
                Hashtable ht = new Hashtable();
                ht["GroupID"] = _GroupID;
                ht["waterMeterSizeId"] = GM.waterMeterSizeId;
                ht["MeterCount"] = GM.MeterCount.ToString();
                ht["Memo"] = GM.Memo;

                new SqlServerHelper().Submit_AddOrEdit("Meter_Design", "GroupID", "", ht);
            }
            string sqlstr="UPDATE Meter_Install_Group SET MeterCount=@MeterCount WHERE GroupID=@GroupID";
            new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] {new SqlParameter("@MeterCount",MeterCount.Text),new SqlParameter("@GroupID",_GroupID) });
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

        private void FP_Click(object sender, EventArgs e)
        {
            FrmApprove_Group_MeterSize frm = new FrmApprove_Group_MeterSize();
            frm.SelectedMeter = MG;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                GroupMeterSize GM = new GroupMeterSize();
                UC_MeterSize UM = new UC_MeterSize();
                GM.waterMeterSizeId = frm.waterMeterSizeId.SelectedValue.ToString();
                UM.WaterMeterSizeId = frm.waterMeterSizeId.SelectedValue.ToString();
                GM.MeterCount = int.Parse(frm.MeterCount.Text);
                UM.MeterCount =int.Parse(frm.MeterCount.Text);
                UM.DelEvent += new EventHandler(UM_DelEvent);
                GM.Memo = frm.Memo.Text;
                _MeterCount += GM.MeterCount;
                MeterCount.Text = _MeterCount.ToString();
                FP.Controls.Add(UM);
                MS.Add(GM);
                MG.GroupMeterSize_Items = MS;
            }
           
        }

    }
}
