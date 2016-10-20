using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using System.Collections;
using Common.DotNetCode;
using DBinterface.IDAL;
using DBinterface.DAL;
using DBinterface;


namespace MeterInstall
{
    public partial class FrmSingle : Form
    {
        public string key;
        public string state;
        public string taskid;
        private int pointSort = 0;

        private string strLogID;
        private string strName;
        private string strRealName;

        private IMeter_Install_Single sysdal = new Meter_Install_Single();

        public FrmSingle()
        {
            InitializeComponent();
        }
        private void FrmSingle_Load(object sender, EventArgs e)
        {
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            Binddata();
        }
        private void Binddata()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterUserType", "", "waterUserTypeId");
            ControlBindHelper.BindComboBoxData(this.waterUserTypeId, dt, "waterUserTypeName", "waterUserTypeId");

            DataTable dt2 = new SqlServerHelper().GetDataTable("waterUserHouseType", "", "waterUserHouseTypeID");
            ControlBindHelper.BindComboBoxData(this.waterUserHouseType, dt2, "waterUserHouseType", "waterUserHouseTypeID");

            if (string.IsNullOrEmpty(key))
            {
                userName.Text = strRealName;
            }
            else
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_Install_Single", "SingleID", key);
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox6.Controls);

                Btn_Submit.Enabled = FlowFunction.IsAllowEdit(taskid);
                waterUserNO.Enabled = false;
                waterUserNO.ReadOnly = true;
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

            string newKey = Guid.NewGuid().ToString();
            string SDNO = new SqlServerHelper().GetSDByTable("Meter_Install_Single");
            ht["ACCEPTID"] = SDNO;
            ht["LOGINID"] = strLogID;
            ht["SD"] = SDNO;

            AcceptID.Text = SDNO;

            if (string.IsNullOrEmpty(key))
            {
                ht["SingleID"] = newKey;
            }
            else
            {
                ht["SingleID"] = key;
            }

            if (new SqlServerHelper().Submit_AddOrEdit("Meter_Install_Single", "SingleID", key, ht))
            {
                AcceptID.Text = ht["ACCEPTID"].ToString();
                Btn_Submit.Enabled = true;

                if (string.IsNullOrEmpty(key) || state.Equals("0"))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["SingleID"].ToString(), SDNO, "Meter_Install_Single", "SingleID", "用户报装");
                    if (result)
                    {
                        MessageBox.Show("任务创建成功！");
                        new SqlServerHelper().ClearControls(groupBox6.Controls);
                    }
                    else
                    {
                        MessageBox.Show("任务创建失败！");
                    }
                }
                if (!string.IsNullOrEmpty(key))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
        }

        private void waterUserName_TextChanged(object sender, EventArgs e)
        {
            ApplyUser.Text = waterUserName.Text;
        }

        private void waterUserNO_TextChanged(object sender, EventArgs e)
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("waterUser", "waterUserNO", waterUserNO.Text.Trim());
            if (ht.Count > 0)
            {
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox6.Controls);
            }
            else
            {
                waterUserNO.Text = "";
            }

        }
    }
}
