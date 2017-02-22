using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.WinDevices;
using System.Data.SqlClient;
using Common.DotNetData;
using BASEFUNCTION;

namespace PersonalWork
{
    public partial class FrmDisUse_StopUser : Form
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

        public FrmDisUse_StopUser()
        {
            InitializeComponent();
        }

        private void FrmDisUse_StopUser_Load(object sender, EventArgs e)
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
            #endregion
        }

        private void FrmDisUse_StopUser_Shown(object sender, EventArgs e)
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();

                DataTable dt = sysidal.GetUserMeterInfoByTaskId(TaskID);
                if (DataTableHelper.IsExistRows(dt))
                {
                    _waterUserId=dt.Rows[0][0].ToString();
                    _waterMeterId= dt.Rows[0][1].ToString();
                    LB_Tip.Text = string.Format("用 户 号：{0}；水表编号：{1}", _waterUserId, _waterMeterId);
                }
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;

            Hashtable Htask = new Hashtable();
            Htask = new SqlServerHelper().GetHashtableById("Meter_Disuse", "TaskID", TaskID);
            if (Htask.Contains("DISUSERTYPE"))
            {
                _DisuserType = int.Parse(Htask["DISUSERTYPE"].ToString());

            }
            Hashtable Hm=new Hashtable();
            Hm["WATERMETERSTATE"] = _DisuserType == 0 ? 5 : 6; ;//5--欠费停水；6-违章停水
            if (new SqlServerHelper().Submit_AddOrEdit("waterMeter", "waterUserId", _waterUserId, Hm))
            {
                //_DisuserType //0-欠费；1-违章
                Hashtable HL = new Hashtable();
                HL["LOGTYPE"] = 2; //2-水表日志
                HL["LOGCONTENT"] = string.Format("{2}报停-水表入库-用户号：{0};水表编号：{1}", _waterUserId, _waterMeterId, _DisuserType == 0 ? "欠费" : _DisuserType == 1 ? "违章" : "其它");
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
