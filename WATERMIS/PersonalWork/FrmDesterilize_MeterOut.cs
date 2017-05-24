using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using DBinterface.IDAL;
using System.Collections;
using Common.DotNetData;
using System.Data.SqlClient;

namespace PersonalWork
{
    public partial class FrmDesterilize_MeterOut : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;

        private string ip = "";

        private string _waterUserId;
        private string _waterMeterId;

        private int _DesterilizeType = 0;

        public FrmDesterilize_MeterOut()
        {
            InitializeComponent();
        }

        private void FrmDesterilize_MeterOut_Load(object sender, EventArgs e)
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

        private void FrmDesterilize_MeterOut_Shown(object sender, EventArgs e)
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();

                DataTable dt = sysidal.GetUserMeterInfoByTaskId(TaskID);
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

            //水表入库：1、如果表中有记录，则更改状态；2、如果表中没有记录，则增加一条记录
            bool IsOk = false;
            string sqlstr  = "UPDATE Meter SET MeterState=1 WHERE waterMeterId =@waterMeterId";

            if (new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@waterMeterId", _waterMeterId) }) > 0)
            {
                IsOk = true;
            }

            if (IsOk)
            {
                Hashtable Hm = new Hashtable();

                Hm = new SqlServerHelper().GetHashtableById("Meter_Desterilize", "TaskID", TaskID);
                _DesterilizeType = int.Parse(Hm["DESTERILIZETYPE"].ToString());
                //_DisuserType //0-欠费；1-违章
                Hashtable HL = new Hashtable();
                HL["LOGTYPE"] = 2; //2-水表日志
                HL["LOGCONTENT"] = string.Format("{2}报停-水表入库-用户号：{0}；水表编号：{1}", _waterUserId, _waterMeterId, _DesterilizeType == 0 ? "欠费" : _DesterilizeType == 1 ? "违章" : "其它");
                HL["LOGDATETIME"] = DateTime.Now.ToString();
                HL["OPERATORID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                HL["OPERATORNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                HL["MEMO"] = TaskID;
                new SqlServerHelper().Submit_AddOrEdit("OPERATORLOG", "LOGID", "", HL);

                int count = sysidal.UpdateApprove_defalut("Meter_Desterilize", ResolveID, true, UserOpinion.Text.Trim(), PointSort, TaskID, "水表读数：" + WaterMeterNum.Text + "");

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
