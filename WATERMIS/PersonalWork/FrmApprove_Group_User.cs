using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BASEFUNCTION;
using Common.WinDevices;
using DBinterface.DAL;
using DBinterface.IDAL;

namespace PersonalWork
{
    public partial class FrmApprove_Group_User : Form
    {
        public FrmApprove_Group_User()
        {
            InitializeComponent();
        }
        Messages mes = new Messages();
        private Hashtable ht = new Hashtable();
        string strTaskID = "";
        string strGroupID = "";
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;

        private string ComputerName = "";
        private string ip = "";

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        private void btAddWaterUserBatch_Click(object sender, EventArgs e)
        {
            FrmApprove_Group_BatchAddUser frm = new FrmApprove_Group_BatchAddUser();
            frm.strGroupID = strGroupID;
            frm.Owner = this;
            frm.ShowDialog();
        }
        Hashtable htt = new Hashtable();
        private void FrmApprove_Group_User_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            strTaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            htt = new SqlServerHelper().GetHashtableById("Meter_Install_Group", "TaskID", strTaskID);
            if (htt.Contains("GROUPID"))
            {
                strGroupID = htt["GROUPID"].ToString();
            }
            else
            {
                mes.Show("获取任务ID失败,请重新打开窗体!");
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (strGroupID != "")
            {
                string strWhere = " GroupID='" + strGroupID + "' AND waterUserId IS NULL ";
                DataTable dt = new SqlServerHelper().GetDataTable("Meter_Groupeople_Detail", strWhere, "");
                if (dt.Rows.Count > 0)
                {
                    mes.Show("系统检测到有 " + dt.Rows.Count + "户 未增户成功,请增户完成后操作!");
                    return;
                }
                else
                {
                    //处理审批操作；
                    ComputerName = new Computer().ComputerName;
                    ip = new Computer().IpAddress;
                    int count = sysidal.UpdateApprove_defalut("Meter_Install_Group", ResolveID, true, "新增用户", PointSort, strTaskID);

                    if (count > 0)
                    {
                        Btn_Submit.Enabled = false;
                        MessageBox.Show("增户成功！");
                    }
                    else
                    {
                        Btn_Submit.Enabled = true;
                    }
                }
            }
            else
                mes.Show("获取任务ID失败,请重新打开窗体!");
        }
    }
}