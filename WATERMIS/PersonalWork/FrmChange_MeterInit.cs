using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using System.Collections;
using DBinterface.IDAL;
using Common.DotNetData;
using System.Data.SqlClient;

namespace PersonalWork
{
    public partial class FrmChange_MeterInit : Form
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
        private int _DesterilizeType = 0;


        public FrmChange_MeterInit()
        {
            InitializeComponent();
        }

        private void FrmChange_MeterInit_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
        }

        private void FrmChange_MeterInit_Shown(object sender, EventArgs e)
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();

                DataTable dt = sysidal.GetUserMeterInfoByTaskId("Meter_Change", TaskID);
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

            Hashtable HL = new Hashtable();
            HL["LOGTYPE"] = 6; //6-抄表台账相关日志
            HL["LOGCONTENT"] = string.Format("用户换表-用户号：{0}；水表编号：{1}", _waterUserId, _waterMeterId);
            HL["LOGDATETIME"] = DateTime.Now.ToString();
            HL["OPERATORID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            HL["OPERATORNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            HL["MEMO"] = TaskID;
            new SqlServerHelper().Submit_AddOrEdit("OPERATORLOG", "LOGID", "", HL);
            //======================================

            int count = sysidal.UpdateApprove_defalut("Meter_Change", ResolveID, true, UserOpinion.Text.Trim(), PointSort, TaskID);

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
