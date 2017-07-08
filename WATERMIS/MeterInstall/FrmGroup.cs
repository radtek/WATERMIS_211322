using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using System.Collections;
using SysControl;
using DBinterface.Model;
using DBinterface;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetData;

namespace MeterInstall
{
    public partial class FrmGroup : Form
    {
        public GroupPeople_Item GP = new GroupPeople_Item();

        private List<GroupPeople_Model> GPList = new List<GroupPeople_Model>();

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        public string key;
        public string state;
        public string taskid;
        private int pointSort = 0;
        private string strLogID;
        private string strName;
        private string strRealName;
        private string newKey;

        public FrmGroup()
        {
            InitializeComponent();
        }

        private void FrmGroup_Load(object sender, EventArgs e)
        {
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            if (!string.IsNullOrEmpty(key))
            {
                Btn_Submit.Text = "修改信息";
                GP.GroupID = new Guid(key);
                Binddata();
            }
            else
            {
                userName.Text = strRealName;

                Guid GroupID = Guid.NewGuid();
                newKey = GroupID.ToString();

                GP.GroupID = GroupID;
            }
        }

        private void Binddata()
        {
            if (string.IsNullOrEmpty(key))
            {
                userName.Text = strRealName;
            }
            else
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_Install_Group", "GroupID", key);
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox6.Controls);

                DataTable dt = sysidal.GetMeter_Group_People(key);
                if (DataTableHelper.IsExistRows(dt))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        GroupPeople_Model GM = new GroupPeople_Model();
                        GM.GroupPeopleID = (Guid)dr["GroupPeopleID"];
                        GM.waterMeterTypeId = dr["waterMeterTypeId"].ToString();
                        GM.waterMeterType = dr["waterMeterTypeValue"].ToString();
                        GM.waterUserTypeId = dr["waterUserTypeId"].ToString();
                        GM.waterUserType = dr["waterUserTypeName"].ToString();
                        GM.waterUserHouseTypeID = (int)dr["waterUserHouseTypeID"];
                        GM.waterUserHouseType = dr["waterUserHouseType"].ToString();
                        GM.UserCount_Apply = (int)dr["UserCount_Apply"];
                        GM.IsBoot = (bool)dr["IsBoot"];

                        GPList.Add(GM);
                    }

                    GP.GroupPeople_Items = GPList;
                    BindGroupUser();
                }

                Btn_Submit.Enabled = FlowFunction.IsAllowEdit(taskid);
                Btn_Submit.Visible = Btn_Submit.Enabled;
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();

            if (string.IsNullOrEmpty(waterUserName.Text) || string.IsNullOrEmpty(waterUserAddress.Text) || string.IsNullOrEmpty(waterPhone.Text))
            {
                MessageBox.Show("信息不完整！");
                return;
            }

            ht = new SqlServerHelper().GetHashTableByControl(this.groupBox6.Controls);
            string SDNO = "";

            if (string.IsNullOrEmpty(key))
            {
                SDNO = new SqlServerHelper().GetSDByTable("Meter_Install_Group");
                ht["GroupID"] = newKey;
                ht["ACCEPTID"] = SDNO;
                ht["LOGINID"] = strLogID;
                ht["SD"] = SDNO;
            }
            else
            {
                ht["GroupID"] = key;
            }
            ht["AcceptDate"] = DateTime.Now.ToString();
           
            if (new SqlServerHelper().Submit_AddOrEdit("Meter_Install_Group", "GroupID", key, ht))
            {
                if (GP.GroupPeople_Items.Count > 0)
                {
                    SaveGoupPeople();
                }
                Btn_Submit.Enabled = false;
                Btn_Submit.BackColor = Color.Gray;
                if (string.IsNullOrEmpty(key))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["GroupID"].ToString(), SDNO, "Meter_Install_Group", "GroupID", "单位报装");
                    if (result)
                    {
                        MessageBox.Show("任务创建成功！");
                    }
                    else
                    {
                        MessageBox.Show("任务创建失败！");
                    }
                }
                else
                {
                    MessageBox.Show("修改成功！");
                }

            }
        }

        private void SaveGoupPeople()
        {
            new SqlServerHelper().DeleteData("Meter_Group_People", "GroupID", key);
            foreach (GroupPeople_Model GM in GP.GroupPeople_Items)
            {
                Hashtable ht = new Hashtable();
                ht["GroupPeopleID"] = Guid.NewGuid();
                ht["GroupID"] = GP.GroupID;
                ht["waterMeterTypeId"] = GM.waterMeterTypeId;
                ht["waterUserTypeId"] = GM.waterUserTypeId;
                ht["waterUserHouseTypeID"] = GM.waterUserHouseTypeID;
                ht["UserCount_Apply"] = GM.UserCount_Apply;
                ht["IsBoot"] = GM.IsBoot;
                ht["CreateDate"] = DateTime.Now.ToString();
                ht["CreateUser"] = strRealName;
                ht["Step"] = 0;
                new SqlServerHelper().Submit_AddOrEdit("Meter_Group_People", "GroupPeopleID", "", ht);
            }
        }

        private void FP_Click(object sender, EventArgs e)
        {
            FrmGroupPeople frm = new FrmGroupPeople();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                GroupPeople_Model GM = frm.GM;
                //if (!GPList.Contains(GM))
                //{
                GPList.Add(GM);
                // }
                GP.GroupPeople_Items = GPList;

                BindGroupUser();
            }
        }

        void BindGroupUser()
        {
            FP.Controls.Clear();
            int PeopleNum = 0;
            foreach (GroupPeople_Model GM in GP.GroupPeople_Items)
            {
                UC_GroupUserList UG = new UC_GroupUserList();
                UG.UserCount_Apply = GM.UserCount_Apply;
                UG.WaterUserType = GM.waterUserType;
                UG.WaterMeterType = GM.waterMeterType;
                UG.IsBoot = GM.IsBoot;
                UG.WaterUserHouseType = GM.waterUserHouseType;
                UG.GroupPeopleID = GM.GroupPeopleID;
                UG.GM = GM;
                UG.DelEvent += new EventHandler(UG_DelEvent);
                UG.EditEvent += new EventHandler(UG_EditEvent);
                PeopleNum += GM.UserCount_Apply;
                FP.Controls.Add(UG);
            }
            waterUserPeopleCount.Text = PeopleNum.ToString();
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

                GPList.Add(GM);
                GP.GroupPeople_Items = GPList;

                BindGroupUser();
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
                    break;
                }
            }

            BindGroupUser();
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(taskid))
            {
                DataSet ds = new DataSet();

                DataTable dtPrint = new SqlServerHelper().GetDataTable("View_GroupInfo", "taskid='" + taskid + "'", "");

                dtPrint.TableName = "用户报装申请表";
                ds.Tables.Add(dtPrint.Copy());
                FastReport.Report report1 = new FastReport.Report();
                try
                {
                    // load the existing report
                    report1.Load(Application.StartupPath + @"\PRINTModel\业扩模板\多用户报装申请表.frx");
                    // register the dataset
                    report1.RegisterData(ds);
                    report1.GetDataSource("用户报装申请表").Enabled = true;
                    // run the report
                    report1.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // free resources used by report
                    report1.Dispose();
                }
            }
        }
    }
}
