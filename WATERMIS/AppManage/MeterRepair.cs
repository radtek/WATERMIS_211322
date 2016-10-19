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
    public partial class MeterRepair : DockContentEx
    {
        public MeterRepair()
        {
            InitializeComponent();
        }

        private EquipMent_IDAL sysidal = new EquipMent_DAL();
        //private string[] yearlist = {"2014","2015","2016" };
        private string[] monthlist = { "所有","1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"};

        private void MeterRepair_Load(object sender, EventArgs e)
        {
            BindMeterUser();

            CB_RecordMeterYear.DataSource = sysidal.GetMeterRepairYear();
            CB_RecordMeterYear.DisplayMember = "MRYear";
            CB_RecordMeterYear.ValueMember = "MRYear";

            CB_RecordMeterMonth.DataSource = monthlist;

           // CB_RecordMeterYear.Text = DateTime.Now.Year.ToString();
            CB_RecordMeterMonth.Text = DateTime.Now.Month.ToString();

            //BindMeterData();
        }

       


        private void BindMeterUser()
        {
            CB_User.DataSource = sysidal.GetLoginUser();

            CB_User.DisplayMember = "USERNAME";
            CB_User.ValueMember = "LOGINNAME";
        }

        private void BindMeterData()
        {
            //GetMeterRepair
            Hashtable ht = new Hashtable();
            ht.Add("MONTH", string.IsNullOrEmpty(CB_RecordMeterMonth.Text) ? "所有" : CB_RecordMeterMonth.Text);
            ht.Add("YEAR", string.IsNullOrEmpty(CB_RecordMeterYear.Text)?DateTime.Now.Year.ToString():CB_RecordMeterYear.Text);
            ht.Add("LOGINID", CB_User.Text.Trim());

            DataTable dt = sysidal.GetMeterRepair(ht);
            if (DataTableHelper.IsExistRows(dt))
            {
                dataGridView1.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindMeterData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmShowPicture frm = new FrmShowPicture();
            frm.ImageFile = dataGridView1.CurrentRow.Cells["故障图片"].Value;
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int MRID = int.Parse(dataGridView1.CurrentRow.Cells["序号"].Value.ToString());
                if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sysidal.DeleteMeterRepair(MRID);
                    BindMeterData();
                    //dataGridView1.Refresh();
                }
            }
        }
    }
}
