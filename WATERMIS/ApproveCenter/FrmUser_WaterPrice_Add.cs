using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Common.DotNetUI;
using DBinterface.DAL;
using DBinterface.IDAL;
using System.Data.SqlClient;
using Common.DotNetData;
using BASEFUNCTION;

namespace ApproveCenter
{
    public partial class FrmUser_WaterPrice_Add : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        private string strLogID;
        private string strName;
        private string strRealName;

        private string _WATERUSERNO = "";
        Messages mes = new Messages();

        public FrmUser_WaterPrice_Add()
        {
            InitializeComponent();
        }

        private void FrmUser_WaterPrice_Add_Load(object sender, EventArgs e)
        {
            BindCombox();
        }
        private void BindCombox()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterTypeId, dt, "waterMeterTypeValue", "waterMeterTypeId");
            dt = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterType_New, dt, "waterMeterTypeValue", "waterMeterTypeId");
        }
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                Hashtable ht = new Hashtable();
                //READMETERRECORDID、WATERMETERTYPEID、WATERPRICEDESCRIBE、WATERUSERADDRESS、WATERUSERNO、WATERUSERNAME、
                //ISMONTH、WaterPriceID、METERREADERNAME、ISLONG、SD、ACCEPTID、LOGINID、WATERMETERTYPE_NEW、WATERPHONE、QueryKey

                //ht["READMETERRECORDID"] = readMeterRecordId.Text;
                //ht["WATERMETERTYPE_CURRENT"] = waterMeterTypeId.SelectedValue;
                //ht["WATERPRICEDESCRIBE"] = WaterPriceDescribe.Text;
                //ht["WATERUSERADDRESS"] = waterUserAddress.Text;
                //ht["WATERUSERNO"] = _WATERUSERNO;
                //ht["WATERUSERNAME"] = waterUserName.Text;
                //ht["ISMONTH"] = IsMonth.Checked?1:0;
                //ht["USERNAME"] = meterReaderName.Text;
                //ht["ISLONG"] = IsLong.Checked ? 1 : 0;
                //ht["WATERMETERTYPE_NEW"] = waterMeterType_New.SelectedValue;
                //ht["WATERPHONE"] = waterPhone.Text;

                ht = new SqlServerHelper().GetHashTableByControl(this.panel1.Controls);

                ht["waterMeterTypeIdChange"] = waterMeterTypeId.SelectedValue;

                string SDNO = new SqlServerHelper().GetSDByTable("User_WaterPrice");
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

                ht["ACCEPTID"] = SDNO;
                ht["LOGINID"] = strLogID;
                ht["SD"] = SDNO;
                ht["QueryKey"] = "123456";
                ht["WaterPriceID"] = Guid.NewGuid().ToString();
                ht["AcceptUser"] = strRealName;


                if (new SqlServerHelper().Submit_AddOrEdit("User_WaterPrice", "WaterPriceID", "", ht))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["WaterPriceID"].ToString(), SDNO, "User_WaterPrice", "WaterPriceID", "用水性质变更");
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
            _WATERUSERNO = WATERUSERNO.Text.Trim();
            new SqlServerHelper().ClearControls(this.panel1.Controls);
            if (!string.IsNullOrEmpty(_WATERUSERNO))
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("V_WATERUSER_CONNECTWATERMETER", "waterUserNO", _WATERUSERNO);

                if (ht.Count == 0)
                {
                    mes.Show("未查到用户信息,请输入完整的用户号!");
                    return;
                }
                if (sysidal.IsExitWaterPriceNO(_WATERUSERNO))
                    if (mes.ShowQ("该用户存在申请记录，确定要再次申请吗?") != DialogResult.OK)
                        return;

                    new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);
                    CheckMonthChange();
            }
        }

        private bool CheckForm()
        {

            if (!WaterPriceDescribe.ValidateState)
            {
                mes.Show("信息不完整！");
                return false;
            }

            if (ISUSECHANGE.Checked)
            {
                if (string.IsNullOrEmpty(CHANGEMONTH.Text.Trim()))
                {
                    return false;
                }
                else
                {
                    if (CHANGEMONTH.Text.Length!=6)
                    {
                        CHANGEMONTH.Text = "";
                        return false;
                    }
                    else
                    {
                        string _YearMonth=CHANGEMONTH.Text.Trim();
                        int _Year=int.Parse(_YearMonth.Substring(0,4));
                        int _Month = int.Parse(_YearMonth.Substring(4, 2));
                        if (_Year > 2015 && _Year < 2099 && _Month > 0 && _Month < 13)
                        {
                            return true;
                        }
                        else
                        {
                            CHANGEMONTH.Text = "";
                            return false;
                        }
                    }
                   
                }
            }

            if (!_WATERUSERNO.Equals(WATERUSERNO.Text))
            {
                WATERUSERNO.Focus();
                mes.Show("请点击【查询】按钮进行查询！");
                return false;
            }
            //if (string.IsNullOrEmpty(waterPhone.Text.Trim()))
            //{
            //    MessageBox.Show("联系电话不能为空！");
            //    return false;
            //}
            if (string.IsNullOrEmpty(WaterPriceDescribe.Text.Trim()))
            {
                mes.Show("请输入变更原因！");
                WaterPriceDescribe.Focus();
                return false;
            }

            if (waterMeterTypeId.Text.Equals(waterMeterType_New.Text))
            {
                mes.Show("用水性质没有变化！");
                return false;
            }
            //if (!IsMonth.Checked && !IsLong.Checked &&)
            //{
            //    mes.Show("勾选变更周期！");
            //    return false;
            //}

            return true;
        }

        private void IsMonth_CheckedChanged(object sender, EventArgs e)
        {
            CheckMonthChange();
           
        }
        private void CheckMonthChange()
        {
            if (!string.IsNullOrEmpty(WATERUSERNO.Text.Trim()) && IsMonth.Checked)
            {
                string sqlstr = "SELECT readMeterRecordId FROM V_YSDETAIL_BYWATERMETER WHERE waterUserNO=@waterUserNO AND chargeState<>3 AND DATEDIFF(MONTH,readMeterRecordYearAndMonth,GETDATE())=0";
                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@waterUserNO", WATERUSERNO.Text.Trim()) });
                if (DataTableHelper.IsExistRows(dt))
                {
                    readMeterRecordId.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    mes.Show("未查到该用户本月可变更的台账信息！");
                    IsMonth.Checked = false;
                }
            }
        }

        private void IsLong_CheckedChanged(object sender, EventArgs e)
        {
            if (IsLong.Checked)
            {
                ISUSECHANGE.Checked = !IsLong.Checked;
                CHANGEMONTH.Enabled = ISUSECHANGE.Checked;
            }
        }

        private void ISUSECHANGE_CheckedChanged(object sender, EventArgs e)
        {
            if (ISUSECHANGE.Checked)
            {
                IsLong.Checked = !ISUSECHANGE.Checked;
                CHANGEMONTH.Enabled = ISUSECHANGE.Checked;
            }
        }
    }
}
