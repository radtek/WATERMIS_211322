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
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            string sqlstr = string.Format(@"DECLARE @StartDate NVARCHAR(50)='{0}'
DECLARE @EndDate Nvarchar(50)='{1}'
SELECT COUNT(1) AS '户数',SUM(TOTALmONEY) AS '金额',TABLE_nAME_ch AS '业扩类型',FEEITEM AS '收费项目'
  FROM [WATERMIS].[dbo].[View_Report_Invoice]
  WHERE FeeItemInvoiceTitle='工程款'
  AND InvoicePrintDateTime BETWEEN  @StartDate AND @EndDate
  GROUP BY TABLE_nAME_ch,FEEITEM", uC_DateSelect1.DayStart, uC_DateSelect1.DayEnd);

                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                dgList.DataSource = dt;
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            string strCaption = "安装处费用统计表";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
        }
    }
}
