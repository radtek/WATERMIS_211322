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
    public partial class Frm_DepFee : DockContentEx
    {
        public Frm_DepFee()
        {
            InitializeComponent();
        }

        private void Frm_DepFee_Load(object sender, EventArgs e)
        {
        }

      
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            string sqlstr = string.Format(@"DECLARE @StartDate NVARCHAR(50)='{0}'
DECLARE @EndDate Nvarchar(50)='{1}'
SELECT '监察股' AS 部门,'违章用户报装-监察' AS 业扩类型,'补交水量' AS 收费项目,COUNT(1) AS 户数,SUM(InvoiceTotalFeeMoney) AS 发票金额 FROM 
View_Report_Invoice
WHERE 
TABLEID =13
AND FEEiTEM='补缴水费'
AND InvoicePrintDateTime  BETWEEN  @StartDate AND @EndDate
UNION ALL
SELECT '水表检定站','单用户报装' ,'首检费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
TABLEID =01
AND (FEEiTEM='首检费' OR FEEiTEM='水表检定')
AND InvoicePrintDateTime  BETWEEN  @StartDate AND @EndDate
UNION ALL
SELECT '水表检定站','多用户报装' ,'首检费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
TABLEID =02
AND (FEEiTEM='首检费' OR FEEiTEM='水表检定')
AND InvoicePrintDateTime  BETWEEN  @StartDate AND @EndDate
UNION ALL
SELECT '水表检定站','用户换表' ,'水表费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
--TABLEID =09
--AND 
FEEiTEM='水表费'
AND InvoicePrintDateTime  BETWEEN  @StartDate AND @EndDate
UNION ALL
SELECT '设计股','设计' ,'设计费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
FEEiTEM='设计费'
AND InvoicePrintDateTime  BETWEEN  @StartDate AND @EndDate
UNION ALL
SELECT '营业股','基建' ,'基建水费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
FEEiTEM='基建水费'
AND InvoicePrintDateTime  BETWEEN  @StartDate AND @EndDate
UNION ALL
SELECT '合计','','', COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
(FEEiTEM IN('基建水费','设计费','水表费') 
OR (TableID =13 AND FEEiTEM='补缴水费') 
OR (TABLEID =01 AND (FEEiTEM='首检费' OR FEEiTEM='水表检定')) 
OR (TABLEID =02 AND (FEEiTEM='首检费' OR FEEiTEM='水表检定')) )
AND InvoicePrintDateTime  BETWEEN  @StartDate AND @EndDate", uC_DateSelect1.DayStart, uC_DateSelect1.DayEnd);

                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);

                dataGridView1.DataSource = dt;
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            string strCaption = "部门费用统计";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dataGridView1);
        }
       

    }
}
