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


namespace MeterInstall
{
    public partial class FrmSingle0 : Form
    {
        public string key;
        private string strLogID;
        private string strName;
        private string strRealName;

        private IMeter_Install_Single sysdal = new Meter_Install_Single();

        public FrmSingle0()
        {
            InitializeComponent();
        }
        private void FrmSingle_Load(object sender, EventArgs e)
        {
            Binddata();

            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            userName.Text = strRealName;
        }
        private void Binddata()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterUserType", "", "waterUserTypeId");
            ControlBindHelper.BindComboBoxData(this.waterUserTypeId, dt, "waterUserTypeName", "waterUserTypeId");

            DataTable dt2 = new SqlServerHelper().GetDataTable("waterUserHouseType", "", "waterUserHouseTypeID");
            ControlBindHelper.BindComboBoxData(this.waterUserHouseType, dt2, "waterUserHouseType", "waterUserHouseTypeID");

            BindSearchData();
        }
        void initData()
        {
            if (!string.IsNullOrEmpty(key))
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_Install_Single", "SingleID", key);
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox6.Controls);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Btn_Save.Enabled = false;
            Btn_Save.BackColor = Color.Gray;
            Hashtable ht = new Hashtable();

            if (string.IsNullOrEmpty(waterUserName.Text) || string.IsNullOrEmpty(waterUserAddress.Text) || string.IsNullOrEmpty(waterPhone.Text))
            {
                MessageBox.Show("信息不完整！");
                Btn_Save.Enabled = true;
                Btn_Save.BackColor = Color.LimeGreen;
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
                Btn_Submit.BackColor = Color.LimeGreen;
                key = string.IsNullOrEmpty(key)?newKey:key;
                BindSearchData();
                MessageBox.Show("信息保存成功！");
            }

        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            BindSearchData();
        }

        void BindSearchData()
        {
            string sqlwhere = "";
            if (new SqlServerHelper().GetSqlWhereByControl(this.groupBox9.Controls, ref sqlwhere))
            {
                sqlwhere += " AND State=0";
            }
            else
            {
                sqlwhere = " State=0";
            }
            DataTable dtList = new SqlServerHelper().GetDataTable("Meter_Install_Single", sqlwhere, "AcceptDate");
            dgList.DataSource = dtList;
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(key))
            {
                bool GoToTask = false;
                GoToTask = sysdal.CreateWorkTask(key, AcceptID.Text);
                 
                if (GoToTask)
                {
                    new SqlServerHelper().ClearControls(this.groupBox6.Controls);
                    this.key = "";
                    QueryKey.Text = "123456";
                    userName.Text = strRealName;
                    Btn_Submit.Enabled = false;
                    Btn_Submit.BackColor = Color.Gray;
                    Btn_Save.Enabled = true;
                    Btn_Save.BackColor = Color.LimeGreen;

                    BindSearchData();
                    MessageBox.Show("提交成功！");
                }
                else
                {
                    MessageBox.Show("提交失败！");
                }
            }
        }

        private void waterUserName_TextChanged(object sender, EventArgs e)
        {
            ApplyUser.Text = waterUserName.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new SqlServerHelper().ClearControls(this.groupBox6.Controls);
            QueryKey.Text = "123456";
            userName.Text = strRealName;
            Btn_Save.Enabled = true;
            Btn_Save.BackColor = Color.LimeGreen;
            Btn_Submit.Enabled = false;
            Btn_Submit.BackColor = Color.Gray;
        }

        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgList.CurrentRow != null)
            {
                this.key = dgList.CurrentRow.Cells["SingleID"].Value.ToString();
                Btn_Save.Enabled = true;
                Btn_Save.BackColor = Color.LimeGreen;
                Btn_Submit.Enabled = true;
                Btn_Submit.BackColor = Color.LimeGreen;
                initData();
            }
        }


    }
}
