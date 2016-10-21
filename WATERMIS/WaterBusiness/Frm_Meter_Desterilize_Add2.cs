using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using DBinterface.IDAL;
using System.Collections;
using Common.DotNetData;

namespace WaterBusiness
{
    public partial class Frm_Meter_Desterilize_Add2 : Form
    {
        private WaterBusiness_IDAL sysidal = new WaterBusiness_DAL();

        private string strLogID;
        private string strName;
        private string strRealName;

        public Frm_Meter_Desterilize_Add2()
        {
            InitializeComponent();
        }

        private void Frm_Meter_Desterilize_Add2_Load(object sender, EventArgs e)
        {
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            ApplyUser.Text = strRealName;
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DisuseID.Text.Trim()))
            {
                MessageBox.Show("未查询到用户的报停记录！");
                return;
            }

            bool FormCheck = DisuseNO.ValidateState & DesterilizeDescribe.ValidateState;
            if (!FormCheck)
            {
                MessageBox.Show("信息不完整！");
                return;
            }

            Hashtable ht = new Hashtable();
            ht = new SqlServerHelper().GetHashTableByControl(this.panel1.Controls);

            string _TableName = "Meter_Desterilize";
            string _TablePkName = "DesterilizeID";
            string _FlowCode = "Meter_Desterilize";
            string _TaskName = "水表恢复-营业";

            ht[_TablePkName] = Guid.NewGuid().ToString();
            string SDNO = new SqlServerHelper().GetSDByTable(_TableName);
            ht["ACCEPTID"] = SDNO;
            ht["LOGINID"] = strLogID;
            ht["SD"] = SDNO;
            ht["QueryKey"] = "123456";
            ht["userName"] = strRealName;
            ht["DesterilizeType"] = 1;//0-欠费；1-违章

            if (new SqlServerHelper().Submit_AddOrEdit(_TableName, _TablePkName, "", ht))
            {
                bool result = new SqlServerHelper().CreateWorkTask(ht[_TablePkName].ToString(), SDNO, _TableName, _TablePkName, _TaskName, _FlowCode);
                if (result)
                {
                    MessageBox.Show("任务创建成功！");
                    new SqlServerHelper().ClearControls(panel1.Controls);
                }
                else
                {
                    MessageBox.Show("任务创建失败！");
                }
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            string _DisuseNO = DisuseNO.Text.Trim();
            if (!string.IsNullOrEmpty(_DisuseNO))
            {
                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashtableById("Meter_Disuse", "SD", _DisuseNO, "DisuserType=1 AND [STATE]=5");
                new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);
                if (ht.Contains("WATERUSERNO"))
                {
                    DataTable dt = sysidal.GetWaterUserFee(ht["WATERUSERNO"].ToString());
                    if (DataTableHelper.IsExistRows(dt))
                    {
                        LB_Fee.Text = dt.Rows[0][0].ToString();
                        // LB_Num.Text = dt.Rows[0][1].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("没有相关用户的报停记录！");
                }
            }
        }
    }
}
