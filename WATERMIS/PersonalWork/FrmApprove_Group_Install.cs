using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Common.DotNetData;
using DBinterface.DAL;
using DBinterface.IDAL;
using SysControl;
using DBinterface.Model;
using System.Data.SqlClient;

namespace PersonalWork
{
    public partial class FrmApprove_Group_Install : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public GroupPeople_Item GP = new GroupPeople_Item();
        private List<GroupPeople_Model> GPList = new List<GroupPeople_Model>();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;

        private bool skip = false;
        private string ComputerName = "";
        private string ip = "";
        private string DepartementID = "0";

        private string _GroupID = string.Empty;

        private string strLogID;
        private string strName;
        private string strRealName;
        private int _waterUserPeopleCount = 0;

        private string _GroupAddress;

        public int WaterUserPeopleCount
        {
            get { return _waterUserPeopleCount; }
            set { _waterUserPeopleCount = value; waterUserPeopleCount.Text = _waterUserPeopleCount.ToString(); }
        }

        public FrmApprove_Group_Install()
        {
            InitializeComponent();
        }

        private void FrmApprove_Group_Install_Load(object sender, EventArgs e)
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
                WaterUserPeopleCount = int.Parse(htt["WATERUSERPEOPLECOUNT"].ToString());
                _GroupAddress = htt["WATERUSERADDRESS"].ToString();
                FP.Controls.Clear();

                DataTable dt = sysidal.GetMeter_Group_People(_GroupID, 2);
                if (!DataTableHelper.IsExistRows(dt))
                {
                    dt = sysidal.GetMeter_Group_People(_GroupID, 0);
                }
                BindGroupUser(dt);
            }
        }

        void BindGroupUser(DataTable dt)
        {
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_GroupUserList UG = new UC_GroupUserList();
                    GroupPeople_Model GM = new GroupPeople_Model();
                    UG.GroupPeopleID = new Guid(dr["GroupPeopleID"].ToString());
                    UG.UserCount_Apply = (int)dr["UserCount_Apply"];
                    UG.WaterUserType = (string)dr["waterUserTypeName"];
                    UG.WaterMeterType = (string)dr["waterMeterTypeValue"];
                    UG.WaterUserHouseType = (string)dr["waterUserHouseType"];
                    UG.WaterUserTypeId = dr["waterUserTypeId"].ToString();
                    UG.WaterMeterTypeId = dr["waterMeterTypeId"].ToString();
                    UG.WaterUserHouseTypeID = int.Parse(dr["waterUserHouseTypeID"].ToString());
                    UG.IsBoot = (bool)dr["IsBoot"];
                    UG.DelEvent += new EventHandler(UG_DelEvent);
                    UG.EditEvent += new EventHandler(UG_EditEvent);
                    UG.IsShowClose = true;

                    GM.GroupPeopleID = UG.GroupPeopleID;
                    GM.waterMeterTypeId = UG.WaterMeterTypeId;
                    GM.waterMeterType = UG.WaterMeterType;
                    GM.waterUserTypeId = UG.WaterUserTypeId;
                    GM.waterUserType = UG.WaterUserType;
                    GM.waterUserHouseTypeID = UG.WaterUserHouseTypeID;
                    GM.waterUserHouseType = UG.WaterUserHouseType;
                    GM.UserCount_Apply = UG.UserCount_Apply;
                    GM.IsBoot = UG.IsBoot;

                    GPList.Add(GM);
                    FP.Controls.Add(UG);
                }
                GP.GroupID = new Guid(_GroupID);
                GP.GroupPeople_Items = GPList;
            }
        }

        void UG_EditEvent(object sender, EventArgs e)
        {
            UC_GroupUserList UG = (UC_GroupUserList)sender;
            FrmGroupPeople frm = new FrmGroupPeople();
            frm.GM = UG.GM;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                UG_DelEvent(sender, e);
                GroupPeople_Model GM = frm.GM;
                UG.GroupPeopleID = GM.GroupPeopleID;
                UG.UserCount_Apply = GM.UserCount_Apply;
                UG.WaterUserType = GM.waterUserType;
                UG.WaterMeterType = GM.waterMeterType;
                UG.WaterUserHouseType = GM.waterUserHouseType;
                UG.IsBoot = GM.IsBoot;
                UG.DelEvent += new EventHandler(UG_DelEvent);
                UG.EditEvent += new EventHandler(UG_EditEvent);
                UG.IsShowClose = true;
                WaterUserPeopleCount += GM.UserCount_Apply;
                GPList.Add(GM);
                GP.GroupPeople_Items = GPList;
                FP.Controls.Add(UG);

            }
        }

        void UG_DelEvent(object sender, EventArgs e)
        {
            UC_GroupUserList UG = (UC_GroupUserList)sender;

            for (int i = 0; i < GPList.Count; i++)
            {
                if (GPList[i].GroupPeopleID == UG.GroupPeopleID)
                {
                    GPList.RemoveAt(i);
                    GP.GroupPeople_Items = GPList;
                    WaterUserPeopleCount -= UG.UserCount_Apply;
                    FP.Controls.Remove(UG);
                    break;
                }
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            int count = sysidal.UpdateApprove_defalut("Meter_Install_Group", ResolveID, true, UserOpinion.Text.Trim(), PointSort, TaskID);

            if (count > 0)
            {
                if (SaveGoupPeople()>0)
                {
                    MessageBox.Show("审批成功！");
                } 
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

        private int SaveGoupPeople()
        {
            string sqlstr=string.Format(@"DELETE FROM Meter_Group_People WHERE GroupID='{0}' AND STEP=2
DELETE FROM  Meter_Groupeople_Detail  WHERE GroupID='{0}'",_GroupID);
            WaterUserPeopleCount = 0;
            new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@GroupID", _GroupID) });
            //new SqlServerHelper().DeleteData("Meter_Groupeople_Detail", "GroupID", _GroupID);
            foreach (GroupPeople_Model GM in GP.GroupPeople_Items)
            {
                Hashtable ht = new Hashtable();
                ht["GroupPeopleID"] = Guid.NewGuid();
                ht["GroupID"] = _GroupID;
                ht["waterMeterTypeId"] = GM.waterMeterTypeId;
                ht["waterUserTypeId"] = GM.waterUserTypeId;
                ht["waterUserHouseTypeID"] = GM.waterUserHouseTypeID;
                ht["UserCount_Apply"] = GM.UserCount_Apply;
                ht["IsBoot"] = GM.IsBoot;
                ht["CreateDate"] = DateTime.Now.ToString();
                ht["CreateUser"] = strRealName;
                ht["Step"] = 2;
                WaterUserPeopleCount += GM.UserCount_Apply;
                new SqlServerHelper().Submit_AddOrEdit("Meter_Group_People", "GroupPeopleID", "", ht);
                for (int i = 0; i < GM.UserCount_Apply; i++)
                {
                    Hashtable hp = new Hashtable();
                    hp["GroupID"] = _GroupID;
                    hp["waterUserAddress"] = _GroupAddress;
                    hp["IsBoost"] = GM.IsBoot;
                    hp["waterUserTypeId"] = GM.waterUserTypeId;
                    hp["waterUserHouseTypeID"] = GM.waterUserHouseTypeID;
                    hp["waterMeterTypeId"] = GM.waterMeterTypeId;
                    hp["waterMeterTypeValue"] = GM.waterMeterType;
                    hp["waterUserTypeName"] = GM.waterUserType;
                    hp["IsReverse"] = "0";
                    hp["createType"] = "正式";
                   
                    new SqlServerHelper().Submit_AddOrEdit("Meter_Groupeople_Detail", "PeopleID", "", hp);
                }
            }

            sqlstr = "UPDATE Meter_Install_Group SET waterUserPeopleCount=@waterUserPeopleCount WHERE TaskID=@TaskID";
            return new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@waterUserPeopleCount", _waterUserPeopleCount), new SqlParameter("@TaskID", TaskID) });

        }


        private void FP_Click(object sender, EventArgs e)
        {
            FrmGroupPeople frm = new FrmGroupPeople();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                GroupPeople_Model GM = frm.GM;
                UC_GroupUserList UG = new UC_GroupUserList();
                UG.GroupPeopleID = GM.GroupPeopleID;
                UG.UserCount_Apply = GM.UserCount_Apply;
                UG.WaterUserType = GM.waterUserType;
                UG.WaterMeterType = GM.waterMeterType;
                UG.WaterUserHouseType = GM.waterUserHouseType;
                UG.IsBoot = GM.IsBoot;
                UG.DelEvent += new EventHandler(UG_DelEvent);
                UG.EditEvent += new EventHandler(UG_EditEvent);
                UG.IsShowClose = true;
                WaterUserPeopleCount += GM.UserCount_Apply;
                GPList.Add(GM);
                GP.GroupPeople_Items = GPList;
                FP.Controls.Add(UG);

            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (SaveGoupPeople() > 0)
            {
                Btn_Submit.Visible = true;
                MessageBox.Show("保存成功！");
            } 
        }

    }
}
