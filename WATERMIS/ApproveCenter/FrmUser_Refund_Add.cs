using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;
using Common.DotNetData;

namespace ApproveCenter
{
    public partial class FrmUser_Refund_Add : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        private string strLogID;
        private string strName;
        private string strRealName;
        private string _CHARGEID = "";
        private string _WATERMETERTYPECLASSID = string.Empty;

        public FrmUser_Refund_Add()
        {
            InitializeComponent();
        }

        private void FrmUser_Refund_Add_Load(object sender, EventArgs e)
        {
            BindCombox();
        }

        private void BindCombox()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("CHARGETYPE", "", "CHARGETYPEID");

            ControlBindHelper.BindComboBoxData(this.CHARGETYPEID, dt, "CHARGETYPENAME", "CHARGETYPEID");
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            _CHARGEID = CHARGEID_IN.Text.Trim();
            if (!string.IsNullOrEmpty(_CHARGEID))
            {
                Hashtable ht = sysidal.GetUserAllowRefund(_CHARGEID);
                if (ht.Count>0)
                {
                    if (sysidal.GetUserExistRefund(ht["CHARGEID"].ToString()))
                    {
                        _CHARGEID = "";
                        MessageBox.Show("退款记录已存在，不要重复申请！");
                        return;
                    }
                    else
                    {
                        new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);
                        _WATERMETERTYPECLASSID = ht["WATERMETERTYPECLASSID"].ToString();
                        
                    }
                }
                else
                {
                    MessageBox.Show("记录不存在！");
                }
            }
            else
            {
                new SqlServerHelper().ClearControls(this.panel1.Controls);
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if(CheckForm())
            {

                //if (sysidal.GetUserExistRefund(CHARGEID_IN.Text.Trim()))
                //{
                //    MessageBox.Show("退款记录已存在，不要重复申请！");
                //    return;
                //}
                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashTableByControl(this.panel1.Controls);
                string SDNO = new SqlServerHelper().GetSDByTable("User_Refund");
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

                ht["ACCEPTID"] = SDNO;
                ht["LOGINID"] = strLogID;
                ht["SD"] = SDNO;
                ht["QueryKey"] = "123456";
                ht["userName"] = strRealName;
                ht["RefundID"] = Guid.NewGuid().ToString();

                string _FlowCode = "User_Refund";
                switch (_WATERMETERTYPECLASSID)
                {
                    case "0003":
                    case "0004":
                        _FlowCode = "User_Refund";
                        break;
                    case "0001":
                    case "0006":
                        _FlowCode = "User_Refund1";
                        break;
                    case "0002":
                    case "0005":
                    case "0007":
                    case "0008":
                    case "0010":
                        _FlowCode = "User_Refund2";
                        break;
                    default:
                        _FlowCode = "User_Refund";
                        break;
                }

                
                if (new SqlServerHelper().Submit_AddOrEdit("User_Refund", "RefundID", "", ht))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["RefundID"].ToString(), SDNO, "User_Refund", "RefundID", "用户退款", _FlowCode);
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
        }

        private bool CheckForm()
        {
           
            if (string.IsNullOrEmpty(CHARGEID_IN.Text.Trim()))
            {
                MessageBox.Show("信息不完整！");
                return false;
            }
            if (!_CHARGEID.Equals(CHARGEID_IN.Text.Trim()))
            {
                //CHARGEID_IN.Text = "";
                CHARGEID_IN.Focus();
                MessageBox.Show("请点击【查询】按钮进行查询！");
                return false;
            }
            if (string.IsNullOrEmpty(CHARGEBCSS_IN.Text.Trim()))
            {
                return false;
            }
            if (string.IsNullOrEmpty(waterPhone.Text.Trim()))
            {
                return false;
            }
            if (string.IsNullOrEmpty(RefundDescribe.Text.Trim()))
            {
                return false;
            }
            decimal _CHARGEBCSS = 0m;
            if (Decimal.TryParse(CHARGEBCSS_IN.Text.Trim(),out _CHARGEBCSS))
            {
                return _CHARGEBCSS > 0m ? true : false;
            }

            return true ;
        }

       
    }
}
