using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;
using System.Collections;
using System.Data.SqlClient;
using Common.DotNetData;
using BASEFUNCTION;
using Microsoft.VisualBasic;

namespace ApproveCenter
{
    public partial class FrmUser_ChargeAbate_Add : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        private string strLogID;
        private string strName;
        private string strRealName;
        private string _WATERUSERNO = "";

        //引用basefunction及Microsoft.VisualBasic;
        //声明对话框类
        Messages mes = new Messages();

        public FrmUser_ChargeAbate_Add()
        {
            InitializeComponent();
        }

        private void FrmUser_ChargeAbate_Add_Load(object sender, EventArgs e)
        {
            dgWaterFeeList.AutoGenerateColumns = false;

            DateTime dtNow = mes.GetDatetimeNow();
            dtpStart.Value = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
            //BindCombox();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                Hashtable ht = new Hashtable();
                //ht = new SqlServerHelper().GetHashTableByControl(this.groupBox2.Controls);
                string SDNO = new SqlServerHelper().GetSDByTable("User_ChargeAbate");
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

                ht["READMETERRECORDID"] = readMeterRecordId.Text;
                ht["WATERUSERNO"] = WATERUSERNO.Text;
                ht["READMETERRECORDYEARANDMONTH"] = readMeterRecordYearAndMonth.Text+"-01";
                ht["WATERUSERNAME"] = waterUserName.Text;
                ht["WATERPHONE"] = waterPhone.Text;
                ht["USERNAME"] = UserName.Text;
                ht["WATERUSERADDRESS"] = waterUserAddress.Text;
                ht["TOTALCHARGEEND"] = TotalChargeEND.Text;
                ht["OldTotalNumber"] =(OldTotalNumber.Text);
                ht["NewTotalNumber"] = Convert.ToInt32(NewTotalNumber.Text);
                ht["ABATEDESCRIBE"] = AbateDescribe.Text;
                ht["waterMeterTypeid"] = waterMeterTypeid.Text;
                ht["waterUserTypeId"] = waterUserTypeId.Text;
                ht["WaterMeterTypeValue"] = WaterMeterTypeValue.Text;
                ht["WaterUserTypeName"] = WaterUserTypeName.Text;           

                ht["ACCEPTID"] = SDNO;
                ht["LOGINID"] = strLogID;
                ht["SD"] = SDNO;
                ht["QueryKey"] = "123456";
                ht["AcceptUser"] = strRealName;
                ht["ChargeAbateID"] = Guid.NewGuid().ToString();


                if (new SqlServerHelper().Submit_AddOrEdit("User_ChargeAbate", "ChargeAbateID", "", ht))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["ChargeAbateID"].ToString(), SDNO, "User_ChargeAbate", "ChargeAbateID", "费用减免");
                    if (result)
                    {
                        mes.Show("任务创建成功！");
                        new SqlServerHelper().ClearControls(panel1.Controls);
                    }
                    else
                    {
                        mes.Show("任务创建失败！");
                    }
                }
            }
        }


        private void Btn_Search_Click(object sender, EventArgs e)
        {
            new SqlServerHelper().ClearControls(this.groupBox2.Controls);
            if (txtWaterUser.Text.Trim() == "")
            {
                mes.Show("请输入用户编号");
                return;
            }
            if (!txtWaterUser.Text.Contains("U"))
                txtWaterUser.Text = "U" + txtWaterUser.Text.Trim();

            _WATERUSERNO = txtWaterUser.Text;

            string strFilter = " WHERE waterUserId='" + _WATERUSERNO + "'";

            if (chkYearAndMonth.Checked)
            {
                strFilter += " AND readMeterRecordYearAndMonth BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";
            }
            strFilter += " ORDER BY readMeterRecordYearAndMonth DESC";

            string sqlstr = "SELECT * FROM V_YSDETAIL_BYWATERMETER " + strFilter;
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            if (DataTableHelper.IsExistRows(dt))
            {
                dgWaterFeeList.DataSource = dt;
            }
            else
            {
                dgWaterFeeList.DataSource = null;
                mes.Show("该用户不存在欠费信息！");
            }
        }

        private bool CheckForm()
        {

            if (string.IsNullOrEmpty(WATERUSERNO.Text.Trim()))
            {
                mes.Show("获取用户号失败！");
                return false;
            }

            if (!Information.IsNumeric(NewTotalNumber.Text.Trim()))
            {
                mes.Show("请输入正确的减免后水量！");
                NewTotalNumber.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AbateDescribe.Text.Trim()))
            {
                mes.Show("请输入减免原因！");
                AbateDescribe.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(readMeterRecordId.Text.Trim()))
            {
                mes.Show("获取台账ID失败,请重新查询");
                return false;
            }
           
            if (!Information.IsNumeric(TotalChargeEND.Text.Trim()))
            {
                mes.Show("获取欠费金额失败,请重新查询");
                return false;
            }

            if (!CkeckAbate())
            {
                 mes.Show("减免后水量不能大于原用水量！");
                 NewTotalNumber.Text = "1";
                 NewTotalNumber.Focus();

                 return false;
            }

            return true;
        }

       private bool CkeckAbate()
        {
            bool result = false; 
            decimal _totalChargeEND = 0m;
            if (Decimal.TryParse(OldTotalNumber.Text.Trim(), out _totalChargeEND))
            {
                result = _totalChargeEND>0m?true:false;
            }
            else
            {
                return false;
            }

            decimal _Abage = 0m;
            if (Decimal.TryParse(NewTotalNumber.Text.Trim(), out _Abage))
            {
                result =_Abage>0m? true:false;
            }
            else
            {
                return false;
            }

            result = _Abage > _totalChargeEND ? false : true;

            return result;
        }

        private void Abate_TextChanged(object sender, EventArgs e)
        {
            if (!CkeckAbate())
            {
                NewTotalNumber.Focus();
            }
        }

        private void dgWaterFeeList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            object obj = dgWaterFeeList.Rows[e.RowIndex].Cells["waterUserNO1"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                WATERUSERNO.Text = obj.ToString();
                _WATERUSERNO = obj.ToString();
            }
            else
                _WATERUSERNO = "";

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["readMeterRecordId1"].Value;
            if (obj != null && obj != DBNull.Value)
                readMeterRecordId.Text = obj.ToString();

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["readMeterRecordYearAndMonth1"].Value;
            if (Information.IsDate(obj))
                readMeterRecordYearAndMonth.Text =Convert.ToDateTime(obj).ToString("yyyy-MM");

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["waterUserName1"].Value;
            if (obj != null && obj != DBNull.Value)
                waterUserName.Text = obj.ToString();

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["waterUserAddress1"].Value;
            if (obj != null && obj != DBNull.Value)
                waterUserAddress.Text = obj.ToString();

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["waterPhone1"].Value;
            if (obj != null && obj != DBNull.Value)
                waterPhone.Text = obj.ToString();

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["meterReaderName"].Value;
            if (obj != null && obj != DBNull.Value)
                UserName.Text = obj.ToString();

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["waterMeterTypeId1"].Value;
            if (obj != null && obj != DBNull.Value)
                waterMeterTypeid.Text = obj.ToString();

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["waterUserTypeId1"].Value;
            if (obj != null && obj != DBNull.Value)
                waterUserTypeId.Text = obj.ToString();

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["waterMeterTypeName1"].Value;
            if (obj != null && obj != DBNull.Value)
                WaterMeterTypeValue.Text = obj.ToString();

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["waterUserTypeName1"].Value;
            if (obj != null && obj != DBNull.Value)
                WaterUserTypeName.Text = obj.ToString();

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["OVERDUEEND1"].Value;
            if (Information.IsNumeric(obj))
                OverDue.Text = Convert.ToDecimal(obj).ToString("F2");

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["totalCharge"].Value;
            if (Information.IsNumeric(obj))
                TotalChargeEND.Text = Convert.ToDecimal(obj).ToString("F2");

            obj = dgWaterFeeList.Rows[e.RowIndex].Cells["totalNumber"].Value;
            if (Information.IsNumeric(obj))
                OldTotalNumber.Text = Convert.ToInt32(obj).ToString();
        }

        private void Abate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void btSetMonth_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btSetMonth, 0, btSetMonth.Width + 1);
        }
        private void 今天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();

            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 本月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtpStart.Value = dtMonthStart;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(1).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 上月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            DateTime dtLastMonth = dtMonthStart.AddMonths(-1);
            dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtLastMonth.Day, 0, 0, 0);
            dtpStart.Value = dtLastMonth;

            DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 下月ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, dtNow.Month, 1);
            DateTime dtLastMonth = dtMonthStart.AddMonths(1);
            dtLastMonth = new DateTime(dtLastMonth.Year, dtLastMonth.Month, dtMonthStart.Day, 0, 0, 0);
            dtpStart.Value = dtLastMonth;

            DateTime dtMonthEnd = dtMonthStart.AddMonths(2).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 本年ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
            DateTime dtLastMonth = new DateTime(dtMonthStart.Year, 1, 1, 0, 0, 0);
            dtpStart.Value = dtLastMonth;

            DateTime dtMonthEnd = dtMonthStart.AddYears(1).AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 上年ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtNow = mes.GetDatetimeNow();
            DateTime dtMonthStart = new DateTime(dtNow.Year, 1, 1);
            DateTime dtLastYear = new DateTime(dtMonthStart.AddYears(-1).Year, 1, 1, 0, 0, 0);
            dtpStart.Value = dtLastYear;

            DateTime dtMonthEnd = dtMonthStart.AddDays(-1);
            dtMonthEnd = new DateTime(dtMonthEnd.Year, dtMonthEnd.Month, dtMonthEnd.Day, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }

        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtLastYear = new DateTime(2000, 1, 1);
            dtpStart.Value = dtLastYear;

            DateTime dtMonthEnd = new DateTime(3000, 1, 1, 23, 59, 59);
            dtpEnd.Value = dtMonthEnd;
        }      
    }
}
