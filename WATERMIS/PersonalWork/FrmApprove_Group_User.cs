using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BASEFUNCTION;

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
                }
            }
            else
                mes.Show("获取任务ID失败,请重新打开窗体!");
        }
    }
}
