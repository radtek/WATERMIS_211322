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
//                string sqlstr = string.Format(@"DECLARE @LoginID NVARCHAR(50)='0092'
//DECLARE @ChargeMonth NVARCHAR(50)='{0}'
// DECLARE @FEE decimal(18, 2)
// DECLARE @DepartementID NVARCHAR(10)
// DECLARE @DepartementName NVARCHAR(50)
// 
// DECLARE @TableFee TABLE(DEPARTMENT NVARCHAR(50),FEEITEM NVARCHAR(50),FEE decimal(18, 2),COLORCODE INT,
// MONTHCHECKSTATE NVARCHAR(10),SORT INT)
//SELECT @DepartementID='02'
//SELECT @DepartementName='营业股'
//SELECT @ChargeMonth=ChargeMonth
//FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID
//INSERT INTO @TableFee SELECT @DepartementName,NULL,NULL,1,@ChargeMonth,1
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=1
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'设计费',@FEE,0,@ChargeMonth,2
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=2
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'工时费',@FEE,0,@ChargeMonth,3
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=3
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'首检费',@FEE,0,@ChargeMonth,4
// end 
//    SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=4
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'基建水费',@FEE,0,@ChargeMonth,5
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=5
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'水表费',@FEE,0,@ChargeMonth,6
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=6
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'维修费',@FEE,0,@ChargeMonth,7
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=7
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'预存款',@FEE,0,@ChargeMonth,8
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=8
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'材料费',@FEE,0,@ChargeMonth,9
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=9
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'二次加压费',@FEE,0,@ChargeMonth,10
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=10
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'补缴水费',@FEE,0,@ChargeMonth,11
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=11
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'安装费',@FEE,0,@ChargeMonth,12
// end 
//
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID
// if @FEE>0
// begin
//INSERT INTO @TableFee SELECT NULL,'[合计]',@FEE,2,@ChargeMonth,13
// end 
// SELECT @DepartementID='010001'
//SELECT @DepartementName='技术股'
//SELECT @ChargeMonth=ChargeMonth FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID
// INSERT INTO @TableFee SELECT @DepartementName,NULL,NULL,1,@ChargeMonth,14
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=1
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'设计费',@FEE,0,@ChargeMonth,15
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=2
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'工时费',@FEE,0,@ChargeMonth,16
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=3
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'首检费',@FEE,0,@ChargeMonth,17
// end 
//    SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=4
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'基建水费',@FEE,0,@ChargeMonth,18
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=5
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'水表费',@FEE,0,@ChargeMonth,19
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=6
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'维修费',@FEE,0,@ChargeMonth,20
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=7
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'预存款',@FEE,0,@ChargeMonth,21
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=8
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'材料费',@FEE,0,@ChargeMonth,22
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=9
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'二次加压费',@FEE,0,@ChargeMonth,23
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001' AND FeeID=10
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'补缴水费',@FEE,0,@ChargeMonth,24
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=11
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'安装费',@FEE,0,@ChargeMonth,125
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010001'
// if @FEE>0
// begin
//INSERT INTO @TableFee SELECT NULL,'[合计]',@FEE,2,@ChargeMonth,26
// end 
//  SELECT @DepartementID='010002'
//SELECT @DepartementName='监察股'
//SELECT @ChargeMonth=ChargeMonth FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID
// INSERT INTO @TableFee SELECT @DepartementName,NULL,NULL,1,@ChargeMonth,27
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=1
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'设计费',@FEE,0,@ChargeMonth,28
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=2
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'工时费',@FEE,0,@ChargeMonth,29
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=3
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'首检费',@FEE,0,@ChargeMonth,30
// end 
//    SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=4
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'基建水费',@FEE,0,@ChargeMonth,31
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=5
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'水表费',@FEE,0,@ChargeMonth,32
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=6
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'维修费',@FEE,0,@ChargeMonth,33
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=7
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'预存款',@FEE,0,@ChargeMonth,34
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=8
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'材料费',@FEE,0,@ChargeMonth,35
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=9
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'二次加压费',@FEE,0,@ChargeMonth,36
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002' AND FeeID=10
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'补缴水费',@FEE,0,@ChargeMonth,37
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=11
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'安装费',@FEE,0,@ChargeMonth,38
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010002'
// if @FEE>0
// begin
//INSERT INTO @TableFee SELECT NULL,'[合计]',@FEE,2,@ChargeMonth,39
// end 
//SELECT @DepartementID='010003'
//SELECT @DepartementName='管道安装处'
//SELECT @ChargeMonth=ChargeMonth FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID
// 
// INSERT INTO @TableFee SELECT @DepartementName,NULL,NULL,1,@ChargeMonth,40
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=1
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'设计费',@FEE,0,@ChargeMonth,41
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=2
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'工时费',@FEE,0,@ChargeMonth,42
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=3
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'首检费',@FEE,0,@ChargeMonth,43
// end 
//    SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=4
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'基建水费',@FEE,0,@ChargeMonth,44
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=5
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'水表费',@FEE,0,@ChargeMonth,45
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=6
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'维修费',@FEE,0,@ChargeMonth,46
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=7
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'预存款',@FEE,0,@ChargeMonth,47
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=8
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'材料费',@FEE,0,@ChargeMonth,48
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=9
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'二次加压费',@FEE,0,@ChargeMonth,49
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003' AND FeeID=10
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'补缴水费',@FEE,0,@ChargeMonth,50
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=11
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'安装费',@FEE,0,@ChargeMonth,51
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010003'
// if @FEE>0
// begin
//INSERT INTO @TableFee SELECT NULL,'[合计]',@FEE,2,@ChargeMonth,52
// end 
//SELECT @DepartementID='010004'
//SELECT @DepartementName='水表检定站'
//SELECT @ChargeMonth=ChargeMonth FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID
//
//INSERT INTO @TableFee SELECT @DepartementName,NULL,NULL,1,@ChargeMonth,53
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=1
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'设计费',@FEE,0,@ChargeMonth,54
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=2
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'工时费',@FEE,0,@ChargeMonth,55
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=3
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'首检费',@FEE,0,@ChargeMonth,56
// end 
//    SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=4
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'基建水费',@FEE,0,@ChargeMonth,57
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=5
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'水表费',@FEE,0,@ChargeMonth,58
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=6
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'维修费',@FEE,0,@ChargeMonth,59
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=7
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'预存款',@FEE,0,@ChargeMonth,60
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=8
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'材料费',@FEE,0,@ChargeMonth,61
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=9
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'二次加压费',@FEE,0,@ChargeMonth,62
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004' AND FeeID=10
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'补缴水费',@FEE,0,@ChargeMonth,63
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=11
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'安装费',@FEE,0,@ChargeMonth,64
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010004'
// if @FEE>0
// begin
//INSERT INTO @TableFee SELECT NULL,'[合计]',@FEE,2,@ChargeMonth,65
// end 
//SELECT @DepartementID='010005'
//SELECT @DepartementName='二次加压管理办'
//SELECT @ChargeMonth=ChargeMonth FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID
//
// INSERT INTO @TableFee SELECT @DepartementName,NULL,NULL,1,@ChargeMonth,66
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=1
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'设计费',@FEE,0,@ChargeMonth,67
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=2
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'工时费',@FEE,0,@ChargeMonth,68
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=3
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'首检费',@FEE,0,@ChargeMonth,69
// end 
//    SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=4
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'基建水费',@FEE,0,@ChargeMonth,70
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=5
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'水表费',@FEE,0,@ChargeMonth,71
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=6
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'维修费',@FEE,0,@ChargeMonth,72
// end 
//SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=7
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'预存款',@FEE,0,@ChargeMonth,73
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=8
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'材料费',@FEE,0,@ChargeMonth,74
// end 
//  SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=9
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'二次加压费',@FEE,0,@ChargeMonth,75
// end 
//   SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005' AND FeeID=10
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'补缴水费',@FEE,0,@ChargeMonth,76
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID=@DepartementID AND FeeID=11
// if @FEE>0
// begin
// INSERT INTO @TableFee SELECT NULL,'安装费',@FEE,0,@ChargeMonth,77
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth AND DepartementID='010005'
// if @FEE>0
// begin
//INSERT INTO @TableFee SELECT NULL,'[合计]',@FEE,2,@ChargeMonth,78
// end 
// SELECT @FEE=SUM(FEE) FROM View_ChargeFee WHERE CHARGEWORKERID =@LoginID AND CHARGEMONTH=@ChargeMonth
// if @FEE>0
// begin
//INSERT INTO @TableFee SELECT '[总计]',NULL,@FEE,2,@ChargeMonth,79
// end 
// SELECT * FROM @TableFee", CB_Month.Text.Trim());

                string sqlstr = string.Format(@"
DECLARE @CREATEmONTH NVARCHAR(50)='{0}'
SELECT '监察股' AS 部门,'违章用户报装-监察' AS 业扩类型,'补交水量' AS 收费项目,COUNT(1) AS 户数,SUM(InvoiceTotalFeeMoney) AS 发票金额 FROM 
View_Report_Invoice
WHERE 
TABLEID =13
AND FEEiTEM='补缴水费'
AND CREATEmONTH=@CREATEmONTH
UNION ALL
SELECT '水表检定站','单用户报装' ,'首检费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
TABLEID =01
AND FEEiTEM='首检费'
AND CREATEmONTH=@CREATEmONTH
UNION ALL
SELECT '水表检定站','多用户报装' ,'首检费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
TABLEID =02
AND 
FEEiTEM='首检费'
AND CREATEmONTH=@CREATEmONTH
UNION ALL
SELECT '水表检定站','用户换表' ,'水表费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
--TABLEID =09
--AND 
FEEiTEM='水表费'
AND CREATEmONTH=@CREATEmONTH
UNION ALL
SELECT '设计股','设计' ,'设计费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
FEEiTEM='设计费'
AND CREATEmONTH=@CREATEmONTH
UNION ALL
SELECT '营业股','基建' ,'基建水费',COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
FEEiTEM='基建水费'
AND CREATEmONTH=@CREATEmONTH
UNION ALL
SELECT '合计','','', COUNT(1),SUM(InvoiceTotalFeeMoney) FROM 
View_Report_Invoice
WHERE 
FEEiTEM IN('基建水费','设计费','水表费','首检费','补缴水费')
AND CREATEmONTH=@CREATEmONTH", CB_Month.Text.Trim());

                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);

                dataGridView1.DataSource = dt;
              
            }
        }

    }
}
