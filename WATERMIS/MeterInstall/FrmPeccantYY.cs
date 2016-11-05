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
using BASEFUNCTION;

namespace MeterInstall
{
    public partial class FrmPeccantYY : Form
    {
        public string key;
        public string state;
        public string taskid;

        private string strLogID;
        private string strName;
        private string strRealName;

        private IMeter_Install_Peccant sysdal = new Meter_Install_Peccant();

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        public FrmPeccantYY()
        {
            InitializeComponent();
        }
        private void FrmPeccant_Load(object sender, EventArgs e)
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
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_Install_Peccant", "SingleID", key);
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox6.Controls);

                Btn_Submit.Enabled = FlowFunction.IsAllowEdit(taskid);
                waterUserNO.Enabled = false;
                waterUserNO.ReadOnly = true;
            }
        }
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();

            if (string.IsNullOrEmpty(waterUserName.Text.Trim()))
            {
                mes.Show("请输入用户名称");
                waterUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(waterUserAddress.Text.Trim()))
            {
                mes.Show("请输入用户地址");
                waterUserAddress.Focus();
                return;
            }
            if (!waterPhone.ValidateState)
            {
                mes.Show("手机号不符合规范，请输入11位有效手机号");
                waterPhone.SelectAll();
                waterPhone.Focus();
                return;
            }
            userName.Text = strRealName;
            //if (string.IsNullOrEmpty(userName.Text.Trim()))
            //{
            //    if (mes.ShowQ("发现人为空，是否使用当前登录用户?") != DialogResult.OK)
            //    {
            //        userName.Focus();
            //        return;
            //    }
            //    userName.Text = strRealName;
            //}
            if (PeccantMemo.Text.Trim() == "")
            {
                mes.Show("请简要说明违章情况!");
                PeccantMemo.Focus();
                return;
            }

            ht = new SqlServerHelper().GetHashTableByControl(this.groupBox6.Controls);

            string newKey = Guid.NewGuid().ToString();
            string SDNO = new SqlServerHelper().GetSDByTable("Meter_Install_Peccant");
            ht["ACCEPTID"] = SDNO;
            ht["LOGINID"] = strLogID;
            ht["SD"] = SDNO;

            ht["PeccantInstallType"] = "1";//入口类型 1营业  2监察

            string _FlowCode = "Meter_Install_Peccant_1";

            AcceptID.Text = SDNO;

            if (string.IsNullOrEmpty(key))
            {
                ht["SingleID"] = newKey;
            }
            else
            {
                ht["SingleID"] = key;
            }

            if (new SqlServerHelper().Submit_AddOrEdit("Meter_Install_Peccant", "SingleID", key, ht))
            {
                AcceptID.Text = ht["ACCEPTID"].ToString();
                Btn_Submit.Enabled = true;

                if (string.IsNullOrEmpty(key) || state.Equals("0"))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["SingleID"].ToString(), SDNO, "Meter_Install_Peccant", "SingleID", "违章用户报装-营业", _FlowCode);
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
    }
}
