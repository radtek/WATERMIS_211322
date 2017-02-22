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
using DBinterface.Model;
using System.Data.SqlClient;
using MeterBusiness;

namespace PersonalWork
{
    public partial class FrmApprove_Group_MeterOut : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();

        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;

        private string ComputerName = "";
        private string ip = "";

        private string _GroupID = string.Empty;

        private string strLogID;
        private string strName;
        private string strRealName;
        private int _meterCount = 0;
        public List<string> SMeters=new List<string>();

        public int MeterCount1
        {
            get { return _meterCount; }
            set { _meterCount = value; MeterCount.Text = _meterCount.ToString(); }
        }

        public FrmApprove_Group_MeterOut()
        {
            InitializeComponent();
        }

        private void FrmApprove_Group_MeterOut_Load(object sender, EventArgs e)
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
            Btn_Save.Enabled = IsAllowEdit;
            BTN_MeterIN.Enabled = IsAllowEdit;
            FP.Enabled = IsAllowEdit;
            #endregion
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            InitView();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            int count = sysidal.UpdateApprove_defalut("Meter_Install_Group", ResolveID, true, UserOpinion.Text.Trim(), PointSort, TaskID);

            if (count > 0)
            {
                if (SaveGroupMeter() > 0)
                {
                    MessageBox.Show("审批成功！");
                }
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (SaveGroupMeter() > 0)
            {
                Btn_Submit.Visible = true;
                MessageBox.Show("保存成功！");
            } 
        }

        private void InitView()
        {
            Hashtable htt = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (htt != null)
            {
                UserOpinion.Text = htt["USEROPINION"].ToString().Trim();
            }
            htt = new SqlServerHelper().GetHashtableById("Meter_Install_Group", "TaskID", TaskID);
            if (htt.Contains("TASKID"))
            {
                _GroupID = htt["GROUPID"].ToString();
                MeterCount1 = int.Parse(htt["METERCOUNT"].ToString());

                DataTable dt = new SqlServerHelper().GetDataTable("Meter_GroupMeter", "GroupID='" + _GroupID + "'", "waterMeterSerialNumber");
                if (DataTableHelper.IsExistRows(dt))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        SMeters.Add(dr["waterMeterSerialNumber"].ToString());
                    }
                }
                
                BindGroupMeter();

            }
        }

        private void BindGroupMeter()
        {
            FP.Controls.Clear();
            MeterCount1 = SMeters.Count;

            foreach (string item in SMeters)
            {
                Label lb = new Label();
                lb.AutoSize = true;
                lb.Width = 100;
                lb.Height = 23;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = item;
                lb.DoubleClick += new EventHandler(FP_Click);

                FP.Controls.Add(lb);
            }
        }

        private void FP_Click(object sender, EventArgs e)
        {
            FrmApprove_Group_MeterSelect frm = new FrmApprove_Group_MeterSelect();
            frm.GroupID = _GroupID;
            frm.SMeters = SMeters;
            if (frm.ShowDialog()==DialogResult.OK)
            {
                SMeters = frm.SMeters;
                BindGroupMeter();
            }
        }

        private int SaveGroupMeter()
        {
            new SqlServerHelper().DeleteData("Meter_GroupMeter", "GroupID", _GroupID);
            string sqlstr = "";
            foreach (string item in SMeters)
            {
                sqlstr +=string.Format(@"INSERT INTO Meter_GroupMeter (GroupID,waterMeterSerialNumber) VALUES ('{0}','{1}')",_GroupID,item);
            }
            new SqlServerHelper().UpdateByHashtable(sqlstr);
            sqlstr = "UPDATE Meter_Install_Group SET MeterCount=@MeterCount WHERE TaskID=@TaskID";
            return new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@MeterCount", _meterCount), new SqlParameter("@TaskID", TaskID) });

        }

        private void BTN_MeterIN_Click(object sender, EventArgs e)
        {
            FrmEntering frm = new FrmEntering();
            frm.ShowDialog();
           
        }


    }
}
