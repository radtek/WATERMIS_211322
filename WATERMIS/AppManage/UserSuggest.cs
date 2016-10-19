using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using System.Collections;
using Common.DotNetData;
using BASEFUNCTION;


namespace AppManage
{
    public partial class UserSuggest : DockContentEx
    {
        public UserSuggest()
        {
            InitializeComponent();
        }

        private EquipMent_IDAL sysidal = new EquipMent_DAL();
        private string[] yearlist = { "2014", "2015", "2016" };
        private string[] monthlist = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

        private void UserSuggest_Load(object sender, EventArgs e)
        {
            BindMeterUser();
            CB_RecordMeterYear.DataSource = yearlist;
            CB_RecordMeterMonth.DataSource = monthlist;

            CB_RecordMeterYear.Text = DateTime.Now.Year.ToString();
            CB_RecordMeterMonth.Text = DateTime.Now.Month.ToString();
        }

        private void BindMeterUser()
        {
            CB_User.DataSource = sysidal.GetLoginUserInID();

            CB_User.DisplayMember = "USERNAME";
            CB_User.ValueMember = "LOGINID";
        }

        private void BindMeterData()
        {
            //GetMeterRepair
            Hashtable ht = new Hashtable();
            ht.Add("MONTH", CB_RecordMeterMonth.Text);
            ht.Add("YEAR", CB_RecordMeterYear.Text);
            ht.Add("LOGINID", CB_User.SelectedValue);

            DataTable dt = sysidal.GetUserSuggest(ht);
            if (DataTableHelper.IsExistRows(dt))
            {
                dataGridView1.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindMeterData();
        }

    }
}
