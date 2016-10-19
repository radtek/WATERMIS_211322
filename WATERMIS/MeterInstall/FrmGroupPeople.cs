using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using DBinterface.Model;
using System.Collections;

namespace MeterInstall
{
    public partial class FrmGroupPeople : Form
    {
        public GroupPeople_Model GM = new GroupPeople_Model();

        public FrmGroupPeople()
        {
            InitializeComponent();
        }

        private void FrmGroupPeople_Load(object sender, EventArgs e)
        {
            BindCombox();
        }

        private void BindCombox()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterUserType", "", "waterUserTypeId");
            ControlBindHelper.BindComboBoxData(this.waterUserTypeId, dt, "waterUserTypeName", "waterUserTypeId");

            DataTable dt2 = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterTypeId, dt2, "waterMeterTypeValue", "waterMeterTypeId");

            DataTable dt3 = new SqlServerHelper().GetDataTable("waterUserHouseType", "", "waterUserHouseTypeID");
            ControlBindHelper.BindComboBoxData(this.waterUserHouseTypeID, dt3, "waterUserHouseType", "waterUserHouseTypeID");

            if (GM.waterUserTypeId != null)
            {
                Hashtable ht = new Hashtable();
                ht["GROUPPEOPLEID"] = GM.GroupPeopleID;
                ht["WATERMETERTYPEID"] = GM.waterMeterTypeId;
                ht["WATERUSERTYPEID"] = GM.waterUserTypeId;
                ht["WATERUSERHOUSETYPEID"] = GM.waterUserHouseTypeID;
                ht["USERCOUNT_APPLY"] = GM.UserCount_Apply;
                ht["ISBOOT"] = GM.IsBoot;

                new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);

            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserCount_Apply.Text))
            {
                MessageBox.Show("用户数量不能为空！");
                return;
            }
            if (GM.waterUserTypeId == null)
            {
                GM.GroupPeopleID = Guid.NewGuid();
            }
            GM.waterMeterTypeId = waterMeterTypeId.SelectedValue.ToString();
            GM.waterMeterType = waterMeterTypeId.Text;
            GM.waterUserTypeId = waterUserTypeId.SelectedValue.ToString();
            GM.waterUserType = waterUserTypeId.Text;
            GM.waterUserHouseTypeID = int.Parse(waterUserHouseTypeID.SelectedValue.ToString());
            GM.waterUserHouseType = waterUserHouseTypeID.Text;
            GM.UserCount_Apply = int.Parse(UserCount_Apply.Text.Trim());
            GM.IsBoot = IsBoot.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
