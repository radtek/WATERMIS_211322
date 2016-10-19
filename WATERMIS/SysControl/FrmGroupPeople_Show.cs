using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.Model;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetData;

namespace SysControl
{
    public partial class FrmGroupPeople_Show : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public string GroupID = string.Empty;

        public FrmGroupPeople_Show()
        {
            InitializeComponent();
        }

        private void FrmGroupPeople_Show_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(GroupID))
            {
                BindGroupUser();
            }
        }

        void BindGroupUser()
        {
            FP.Controls.Clear();

            DataTable dt = sysidal.GetMeter_Group_People(GroupID);
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_GroupUserList UG = new UC_GroupUserList();
                    UG.UserCount_Apply = (int)dr["UserCount_Apply"];
                    //UG.WaterUserType = sysidal.GetWaterUserTypeByID((string)dr["waterUserTypeId"]);
                    //UG.WaterMeterType = sysidal.GetwaterMeterTypeByID((string)dr["waterMeterTypeId"]);
                    UG.WaterUserType = (string)dr["waterUserTypeName"];
                    UG.WaterMeterType = (string)dr["waterMeterTypeValue"];
                    UG.WaterUserHouseType = (string)dr["waterUserHouseType"];
                    UG.IsBoot = (bool)dr["IsBoot"];
                    UG.GroupPeopleID = (Guid)dr["GroupPeopleID"];
                    UG.IsShowClose = false;
                    FP.Controls.Add(UG);
                }
            }
        }  
    }
}
