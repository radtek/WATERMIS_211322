using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DBinterface.Model;

namespace SysControl
{
    public partial class UC_GroupUserList : UserControl
    {
        private Guid _GroupPeopleID;

        public Guid GroupPeopleID
        {
            get { return _GroupPeopleID; }
            set { _GroupPeopleID = value; }
        }

        private int _UserCount_Apply = 0;

        public int UserCount_Apply
        {
            get { return _UserCount_Apply; }
            set { _UserCount_Apply = value; LB_UserCount_Apply.Text = string.Format("{0}户", _UserCount_Apply); }
        }

        private string waterUserType = "";

        public string WaterUserType
        {
            get { return waterUserType; }
            set { waterUserType = value; LB_waterUserType.Text = waterUserType; }
        }

        private string waterMeterType = "";

        public string WaterMeterType
        {
            get { return waterMeterType; }
            set { waterMeterType = value; LB_waterMeterType.Text = waterMeterType; }
        }

        private bool _IsBoot = false;

        public bool IsBoot
        {
            get { return _IsBoot; }
            set { _IsBoot = value; LB_IsBoot.Text = _IsBoot ? "加压" : "不加压"; }
        }

        private string waterUserHouseType;

        public string WaterUserHouseType
        {
            get { return waterUserHouseType; }
            set { waterUserHouseType = value; LB_waterUserHouseType.Text = waterUserHouseType; }
        }

        private bool _IsShowClose = true;

        public bool IsShowClose
        {
            get { return _IsShowClose; }
            set { _IsShowClose = value; LB_Close.Visible = _IsShowClose; }
        }

        private string waterMeterTypeId;

        public string WaterMeterTypeId
        {
            get { return waterMeterTypeId; }
            set { waterMeterTypeId = value; }
        }

        private string waterUserTypeId;

        public string WaterUserTypeId
        {
            get { return waterUserTypeId; }
            set { waterUserTypeId = value; }
        }

        private int waterUserHouseTypeID;

        public int WaterUserHouseTypeID
        {
            get { return waterUserHouseTypeID; }
            set { waterUserHouseTypeID = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler DelEvent;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler EditEvent;

        public UC_GroupUserList()
        {
            InitializeComponent();
        }
        
        

        private void UC_GroupUserList_Load(object sender, EventArgs e)
        {
        }

        private GroupPeople_Model _GM = new GroupPeople_Model();

        public GroupPeople_Model GM
        {
            get
            {
                _GM.GroupPeopleID = _GroupPeopleID;
                _GM.UserCount_Apply = _UserCount_Apply;
                _GM.waterUserType = waterUserType;
                _GM.waterUserTypeId = waterUserTypeId;
                _GM.waterMeterType = waterMeterType;
                _GM.waterMeterTypeId = waterMeterTypeId;
                _GM.IsBoot = _IsBoot;
                _GM.waterUserHouseType = waterUserHouseType;
                _GM.waterUserHouseTypeID = waterUserHouseTypeID;
                return _GM;
            }
            set
            {
                _GM = value;
                GroupPeopleID = _GM.GroupPeopleID;
                UserCount_Apply = _GM.UserCount_Apply;
                WaterUserType = _GM.waterUserType;
                WaterUserTypeId = _GM.waterUserTypeId;
                WaterMeterType = _GM.waterMeterType;
                WaterMeterTypeId = _GM.waterMeterTypeId;
                IsBoot = _GM.IsBoot;
                WaterUserHouseType = _GM.waterUserHouseType;
                WaterUserHouseTypeID = _GM.waterUserHouseTypeID;
            }
        }


        private void LB_Close_Click(object sender, EventArgs e)
        {
            if (DelEvent != null)
                DelEvent(this, e);
        }

        private void UC_GroupUserList_DoubleClick(object sender, EventArgs e)
        {
            if (EditEvent != null)
                EditEvent(this, e);
        }

        public void BindDataRow(DataRow dr)
        {
            //if (dr.Table.Columns.Contains("GroupPeopleID"))
            //{
            //    _GroupPeopleID = (Guid)dr["GroupPeopleID"];
            //    _UserCount_Apply = dr.Table.Columns.Contains("UserCount_Apply")?(int)dr["UserCount_Apply"]:0;
            //    waterUserType = dr.Table.Columns.Contains("waterUserTypeId") ? (string)dr["waterUserTypeId"] : "";
            //    waterMeterType = dr.Table.Columns.Contains("waterMeterTypeId") ? (string)dr["waterMeterTypeId"] : "";
            //    _IsBoot = dr.Table.Columns.Contains("IsBoot") ? (bool)dr["IsBoot"] : false;
            //}
           
        }

    }
}
