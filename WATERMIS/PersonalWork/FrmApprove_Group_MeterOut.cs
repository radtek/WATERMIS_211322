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

            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            InitView();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            //
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            //
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
                BindGroupMeter();
            }
        }

        private void BindGroupMeter()
        {
            //FP.Controls.Clear();
            //MeterCount1 = 0;
            //DataTable dt = new SqlServerHelper().GetDataTable("Meter_GroupMeter", "GroupID='" + _GroupID + "'", "waterMeterSerialNumber");
            //if (DataTableHelper.IsExistRows(dt))
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        GroupMeterSize GM = new GroupMeterSize();
            //        GM.GroupID = dr["GroupID"].ToString();
            //        GM.waterMeterSizeId = dr["waterMeterSizeId"].ToString();
            //        GM.MeterCount = int.Parse(dr["MeterCount"].ToString());
            //        MeterCount1 += GM.MeterCount;
            //        GM.Memo = dr["Memo"].ToString();

            //        MS.Add(GM);
            //        UC_MeterSize UM = new UC_MeterSize();
            //        UM.WaterMeterSizeId = dr["waterMeterSizeId"].ToString();
            //        UM.MeterCount = int.Parse(dr["MeterCount"].ToString());
            //        UM.DelEvent += new EventHandler(UM_DelEvent);
            //        FP.Controls.Add(UM);
            //    }
            //    MG.GroupMeterSize_Items = MS;
            //    MeterCount.Text = _MeterCount.ToString();
            //}
        }


    }
}
