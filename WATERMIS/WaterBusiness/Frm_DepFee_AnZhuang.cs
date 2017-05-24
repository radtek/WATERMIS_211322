using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using Common.DotNetUI;

namespace WaterBusiness
{
    public partial class Frm_DepFee_AnZhuang : DockContentEx
    {
        public Frm_DepFee_AnZhuang()
        {
            InitializeComponent();
        }

        private void Frm_DepFee_AnZhuang_Load(object sender, EventArgs e)
        {
            Init();
        }
        public void Init()
        {
            //DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT CreateMonth,CreateMonth AS CMonth FROM View_TaskStat ORDER BY CreateMonth DESC ");
            //ControlBindHelper.BindComboBoxData(this.CB_Month, dt, "CMonth", "CreateMonth");
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT CreateMonth,CreateMonth AS CMonth FROM View_Report_Invoice ORDER BY CreateMonth DESC ");
            ControlBindHelper.BindComboBoxData(this.CB_Month, dt, "CMonth", "CreateMonth");

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CB_Month.Text))
            {


                string sqlstr = string.Format(@"SELECT COUNT(1) AS '户数',SUM(TOTALmONEY) AS '金额',TABLE_nAME_ch AS '业扩类型',FEEITEM AS '收费项目'
  FROM [WATERMIS].[dbo].[View_Report_Invoice]
  WHERE FeeItemInvoiceTitle='工程款'
  AND CREATEmONTH='{0}'
  GROUP BY TABLE_nAME_ch,FEEITEM", CB_Month.Text.Trim());

                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);

                dataGridView1.DataSource = dt;

            }
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            DataToExcel.DataGridViewToExcel(this.dataGridView1, string.Format("安装处{0}月报表", CB_Month.Text.Trim()));
        }

    }
}
