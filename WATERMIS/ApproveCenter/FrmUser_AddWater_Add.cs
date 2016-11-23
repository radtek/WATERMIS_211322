using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using BASEFUNCTION;
using System.Collections;
using Common.DotNetData;
using Common.DotNetUI;
using Microsoft.VisualBasic;

namespace ApproveCenter
{
    public partial class FrmUser_AddWater_Add : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        private string strLogID;
        private string strName;
        private string strRealName;
        private string _WATERUSERNO = "";

        //引用basefunction及Microsoft.VisualBasic;
        //声明对话框类
        Messages mes = new Messages();

        public FrmUser_AddWater_Add()
        {
            InitializeComponent();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashTableByControl(this.groupBox2.Controls);
                string SDNO = new SqlServerHelper().GetSDByTable("User_AddWater");
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

                ht["ACCEPTID"] = SDNO;
                ht["LOGINID"] = strLogID;
                ht["SD"] = SDNO;
                ht["QueryKey"] = "123456";
                ht["AcceptUser"] = strRealName;
                ht["AddID"] = Guid.NewGuid().ToString();

                if (new SqlServerHelper().Submit_AddOrEdit("User_AddWater", "AddID", "", ht))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["AddID"].ToString(), SDNO, "User_AddWater", "User_AddWater", "补交水量");
                    if (result)
                    {
                        Btn_Submit.Enabled = false;
                        mes.Show("任务创建成功！");
                        new SqlServerHelper().ClearControls(groupBox2.Controls);
                    }
                    else
                    {
                        mes.Show("任务创建失败！");
                    }
                }
            }
        }

        private void FrmUser_AddWater_Add_Load(object sender, EventArgs e)
        {
            //BindReadMonth();
        }

//        private void BindReadMonth()
//        {
//            string sqlstr = @"SELECT TOP 10 * FROM 
//(SELECT DISTINCT CAST(YEAR(readMeterRecordYearAndMonth) AS VARCHAR(10))+'年'+CAST(MONTH(readMeterRecordYearAndMonth) AS VARCHAR(10))+'月' AS READYEARMONTH,
//CAST(YEAR(readMeterRecordYearAndMonth) AS VARCHAR(10))+CASE WHEN MONTH(readMeterRecordYearAndMonth)<10 THEN '0' ELSE '' END+CAST(MONTH(readMeterRecordYearAndMonth) AS VARCHAR(10)) AS READYEARMONTHVALUE
//FROM readMeterRecord) Y ORDER BY READYEARMONTHVALUE DESC";
//            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
//            ControlBindHelper.BindComboBoxData(this.CB_ReadMonth, dt, "READYEARMONTH", "READYEARMONTHVALUE");
//        }

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

            strFilter += "AND datadiff";

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
                mes.Show("该用户不存在抄表记录！");
            }
        }

        private bool CheckForm()
        {
            if (string.IsNullOrEmpty(WATERUSERNO.Text.Trim()))
            {
                mes.Show("获取用户号失败！");
                return false;
            }

            if (!Information.IsNumeric(totalNumber.Text.Trim()))
            {
                mes.Show("请输入正确的补交水量！");
                totalNumber.Focus();
                return false;
            }

            return true;
        }

        private void dgWaterFeeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgWaterFeeList.CurrentRow != null)
            {
                string _readMeterRecordId = dgWaterFeeList.CurrentRow.Cells["readMeterRecordId"].Value.ToString();

                Hashtable ht = new SqlServerHelper().GetHashtableById("V_YSDETAIL_BYWATERMETER", "readMeterRecordId", _readMeterRecordId);
                ht.Remove("TOTALNUMBER");
                ht.Remove("TOTALCHARGEEND");
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox2.Controls);
                UserName.Text = ht["METERREADERNAME"].ToString();
            }
        }

        private void totalNumber_TextChanged(object sender, EventArgs e)
        {
            int _totalNumber = 0;
            if (int.TryParse(totalNumber.Text,out _totalNumber))
            {

            }
            else
            {
                totalNumber.Text = "";
                TotalChargeEND.Text = "";
            }

        }

    }
}
