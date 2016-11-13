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
using Microsoft.VisualBasic;

namespace PersonalWork
{
    public partial class FrmApprove_Group_UserPrestoreDeal : Form
    {
        public FrmApprove_Group_UserPrestoreDeal()
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
            FrmApprove_Group_DealPrestore frm = new FrmApprove_Group_DealPrestore();
            frm.strGroupID = strGroupID;
            frm.strPointSort = PointSort;
            frm.strTaskID = strTaskID;
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
                /// <summary>
                /// 业扩和营业的预存款
                /// </summary>
                decimal decSumYuCun_YK = 0, decSumYuCun_YY = 0;

                string strSQL = string.Format(@"SELECT * FROM V_WATERUSER_CONNECTWATERMETER WHERE waterUserId IN (SELECT waterUserId 
                FROM Meter_Groupeople_Detail WHERE GroupID='{0}')", strGroupID);
                object obj = new SqlServerHelper().GetFirsRowsValue(strSQL);
                if (Information.IsNumeric(obj))
                    decSumYuCun_YY = Convert.ToDecimal(obj);

                decSumYuCun_YK = sysidal.GetTotalFeeYuCun(strTaskID, PointSort);

                if (decSumYuCun_YK != decSumYuCun_YY)
                {
                    string strTip = "系统检测到营业预存余额与业扩预存款金额不一致\n营业预存余额:" + decSumYuCun_YY.ToString("F2") + "元\n业扩预存金额:" + decSumYuCun_YK.ToString("F2") + "元\n确定要继续吗?";
                    if (mes.ShowQ(strTip) != DialogResult.OK)
                        return;
                }
                //处理审批操作；
                ComputerName = new Computer().ComputerName;
                ip = new Computer().IpAddress;
                int count = sysidal.UpdateApprove_defalut("Meter_Install_Group", ResolveID, true, "预存款结转", PointSort, strTaskID);

                if (count > 0)
                {
                    Btn_Submit.Enabled = false;
                    mes.Show("预存款结转成功！");
                }
                else
                {
                    Btn_Submit.Enabled = true;
                }
            }
            else
                mes.Show("获取任务ID失败,请重新打开窗体!");
        }
    }
}