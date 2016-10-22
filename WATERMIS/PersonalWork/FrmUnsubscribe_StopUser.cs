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
using Common.DotNetData;
using System.Data.SqlClient;

namespace PersonalWork
{
    public partial class FrmUnsubscribe_StopUser : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;

        private string ComputerName = "";
        private string ip = "";
        private string _waterUserId;
        private string _waterMeterId;
        private int _DisuserType = 0;

        public FrmUnsubscribe_StopUser()
        {
            InitializeComponent();
        }

        private void FrmUnsubscribe_StopUser_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
        }

        private void FrmUnsubscribe_StopUser_Shown(object sender, EventArgs e)
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();
                string sqlstr = "SELECT MD.WaterUserNO,VM.waterMeterNo FROM V_WATERMETER VM,User_Unsubscribe MD WHERE VM.waterUserId=MD.WaterUserNO AND MD.TaskID=@TaskID";
                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
                if (DataTableHelper.IsExistRows(dt))
                {
                    _waterUserId = dt.Rows[0][0].ToString();
                    _waterMeterId = dt.Rows[0][1].ToString();
                    LB_Tip.Text = string.Format("用 户 号：{0}；水表编号：{1}", _waterUserId, _waterMeterId);
                }
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;

            Hashtable Hm = new Hashtable();
            Hm["WATERMETERSTATE"] = 2;//2-注销
            if (new SqlServerHelper().Submit_AddOrEdit("waterMeter", "waterUserId", _waterUserId, Hm))
            {
                Hashtable HL = new Hashtable();
                HL["LOGTYPE"] = 2; //2-水表日志
                HL["LOGCONTENT"] = string.Format("用户注销-水表入库-用户号：{0};水表编号：{1}", _waterUserId, _waterMeterId);
                HL["LOGDATETIME"] = DateTime.Now.ToString();
                HL["OPERATORID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                HL["OPERATORNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                HL["MEMO"] = TaskID;
                new SqlServerHelper().Submit_AddOrEdit("OPERATORLOG", "LOGID", "", HL);

                int count = sysidal.UpdateApprove_defalut("Meter_Disuse", ResolveID, true, UserOpinion.Text.Trim(), PointSort, TaskID);

                if (count > 0)
                {
                    MessageBox.Show("审批成功！");
                }
                else
                {
                    MessageBox.Show("审批失败！");
                    Btn_Submit.Enabled = true;
                }
            }
        }
    }
}
