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

        //private string ComputerName = "";
        //private string ip = "";

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
            #region //2017-2-22 RONG
            bool IsAllowEdit = false;
            if (ht.Contains("Edit"))
            {
                if (bool.TryParse(ht["Edit"].ToString(), out IsAllowEdit))
                {

                }
            }
            Btn_Submit.Enabled = IsAllowEdit;
            btAddWaterUserBatch.Enabled = IsAllowEdit;
            #endregion
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

                string strSQL = string.Format(@"SELECT SUM(PRESTORE) FROM WATERUSER WHERE waterUserId IN (SELECT waterUserId 
                FROM Meter_Groupeople_Detail WHERE GroupID='{0}')", strGroupID);
                object obj = new SqlServerHelper().GetFirsRowsValue(strSQL);
                if (Information.IsNumeric(obj))
                    decSumYuCun_YY = Convert.ToDecimal(obj);

                string strGetYC = string.Format(@"DECLARE @TaskID NVARCHAR(50)='{0}'
        DECLARE @LastPoingSort INT=0
        SELECT TOP 1 @LastPoingSort=PointSort FROM Meter_WorkResolveFee MWF,Meter_WorkResolve MWR 
        WHERE MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=@TaskID AND PointSort<14 AND MWR.YS=1 ORDER BY PointSort DESC
        SELECT SUM(Fee) FROM Meter_WorkResolveFee WHERE ResolveID IN 
        (SELECT ResolveID FROM Meter_WorkResolve WHERE 
        TaskID=@TaskID AND PointSort=@LastPoingSort) AND FEE>0 AND FeeID IN  (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1)", strTaskID);
                obj =new SqlServerHelper().GetFirsRowsValue(strGetYC);
                if (Information.IsNumeric(obj))
                    decSumYuCun_YK = Convert.ToDecimal(obj);

                if (decSumYuCun_YK != decSumYuCun_YY)
                {
                    string strTip = "系统检测到营业预存余额与业扩预存款金额不一致\n营业预存余额:" + decSumYuCun_YY.ToString("F2") + "元\n业扩预存金额:" + decSumYuCun_YK.ToString("F2") + "元\n确定要继续吗?";
                    if (mes.ShowQ(strTip) != DialogResult.OK)
                        return;
                }
                //处理审批操作；
                //ComputerName = new Computer().ComputerName;
                //ip = new Computer().IpAddress;
                int count = sysidal.UpdateApprove_defalut("Meter_Install_Group", ResolveID, true, "预存款结转", PointSort, strTaskID, "预存款结转-》批量预存");

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