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
                ht["ABATE"] = Abate.Text;
                ht["ABATEDESCRIBE"] = AbateDescribe.Text;                

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
            _WATERUSERNO = "";

            string strFilter = " WHERE chargeState<>'3' ";
            string strSearch = txtWaterUser.Text;
            if (txtWaterUser.Text.Trim() != "")
            {
                strFilter += " AND (waterUserNO LIKE '%" + strSearch + "%' OR waterUserName LIKE '%" + strSearch +
                    "%' OR waterUserAddress LIKE '%" + strSearch + "%') ";
            }
            if (chkMonth.Checked)
                strFilter += " AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,'" + dtpMonth.Value.ToString("yyyy-MM-dd") + "')=0 ";

            _WATERUSERNO = WATERUSERNO.Text.Trim();
            string sqlstr = "SELECT TOP 1 * FROM V_YSDETAIL_BYWATERMETER " + strFilter;
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            if (DataTableHelper.IsExistRows(dt))
            {
                dgWaterFeeList.DataSource = dt;
                //Hashtable ht = DataTableHelper.DataTableToHashtable(dt);
                //if (sysidal.GetUserExistAbate(ht["READMETERRECORDID"].ToString()))
                //{
                //    _WATERUSERNO = "";
                //    MessageBox.Show("该用户申请记录已存在，不要重复申请！");
                //    return;
                //}
                //else
                //{
                //    new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);
                //    LB_Tip.Text = string.Format("含滞纳金{0}元", ht["OVERDUEEND"].ToString());
                //}
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

            if (!Information.IsNumeric(Abate.Text.Trim()))
            {
                mes.Show("请输入正确的减免金额！");
                Abate.Focus();
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
                 mes.Show("减免金额不能大于费用合计！");
                 Abate.Text = "";
                 Abate.Focus();

                 return false;
            }

            return true;
        }

       private bool CkeckAbate()
        {
            bool result = false; 
            decimal _totalChargeEND = 0m;
            if (Decimal.TryParse(TotalChargeEND.Text.Trim(), out _totalChargeEND))
            {
                result = _totalChargeEND>0m?true:false;
            }
            else
            {
                return false;
            }

            decimal _Abage = 0m;
            if (Decimal.TryParse(Abate.Text.Trim(), out _Abage))
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
                Abate.Focus();
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
        }

        private void Abate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //检测是否已经输入了小数点 
            bool IsContainsDot = this.Abate.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }
        }        
    }
}
