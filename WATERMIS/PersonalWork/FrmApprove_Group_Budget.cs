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
using SysControl;
using Common.DotNetUI;

namespace PersonalWork
{
    public partial class FrmApprove_Group_Budget : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;

        //private string ComputerName = "";
        //private string ip = "";
        private string strLogID;
        private string strName;
        private string strRealName;

        private decimal TotalFee = 0m;
        private decimal _DepTotalFee = 0m;
        //private decimal _Abate = 0m;
        private decimal _BCSS = 0m;
        private decimal _BCYS = 0m;
        private decimal _prestore = 0m;
        // private bool _IsFinal = false;
        private string _SelectResolveID = "";

        private string _LastPointSort;
        // private int _State = 0;
        private string _FeeItems = "";
        //打印数据--格式：{ID|收费项目名称|单价|单位|数量|总费用}
        private string[] _PrintFeeItems;
        private int _FeeType = 0;
        private Hashtable hc = new Hashtable();

        public FrmApprove_Group_Budget()
        {
            InitializeComponent();
        }


        #region
      
        private void FrmApprove_Single_Budget_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            hc["TaskID"] = TaskID;

            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            {
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            }
            else
            {
                MessageBox.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            BindChargeType();

            BindDepartmentFee();

        }

        private void BindDepartmentFee()
        {
            FP_Dep.Controls.Clear();

            DataTable dt = sysidal.GetDepartMentFee(TaskID, PointSort);
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_DepartmentFee UD = new UC_DepartmentFee();
                    UD.DataRowToProperty(dr);
                    UD.Button_Open_Click += new EventHandler(UD_Button_Open_Click);
                    FP_Dep.Controls.Add(UD);
                }

                _LastPointSort = dt.Rows[0]["FeePointSort"].ToString();
                TotalFee = sysidal.GetTotalFeeByPointSort(TaskID, _LastPointSort);
                
                LB_TotalFee.Text = string.Format("总计：{0}元", TotalFee);
            }
        }

        void UD_Button_Open_Click(object sender, EventArgs e)
        {
            UC_DepartmentFee UD = (UC_DepartmentFee)sender;
            FP_Items.Controls.Clear();
            _SelectResolveID = UD.ResolveID;
            DataTable dt = sysidal.GetDepartMentFeeItems(_SelectResolveID);
            if (DataTableHelper.IsExistRows(dt))
            {
                _FeeItems = "";
                foreach (DataRow dr in dt.Rows)
                {
                    UC_ChargeItem UC = new UC_ChargeItem();
                    UC.FeeItem = string.Format("{0}:{1}元;", dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString());
                    _FeeItems += string.Format("{0}:{1};", dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString());
                    FP_Items.Controls.Add(UC);
                }

               // LB_TotalFee.Text = string.Format("{0}-费用总计：{1}元", UD.DepartmentName, dt.Rows[0]["DepartTotalFee"].ToString());
                _BCSS = string.IsNullOrEmpty(dt.Rows[0]["FinalTotalFee"].ToString()) ? 0m : Convert.ToDecimal(dt.Rows[0]["FinalTotalFee"].ToString());
                TOTALCHARGE.Text = _BCSS.ToString();
                CHARGEBCSS.Text = TOTALCHARGE.Text;
            }
        }

        private void BindChargeType()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT * FROM CHARGETYPE ");
            ControlBindHelper.BindComboBoxData(this.CHARGETYPEID, dt, "CHARGETYPENAME", "CHARGETYPEID");
        }
        #endregion

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            if (_BCSS>0m)
            {
                if (Approve_Finance())
                {
                //======================================================================================打印收据

                    MessageBox.Show("收费成功！");
                    BindDepartmentFee();
                    TOTALCHARGE.Text = "";
                    CHARGEBCSS.Text = "";
                    RECEIPTNO.Text = "";
                }
            }
            else
            {
                MessageBox.Show("该条收费记录不能打印收据！");
            }
        }

        private bool Approve_Finance()
        {

            //==============================================================================获取收据编号

            _prestore = sysidal.GetUserPrestore("Meter_Install_Group", TaskID);
            string _chargeID = sysidal.GetNewChargeID(strLogID);
            hc["CHARGEClASS"] = 14;
            hc["TableName"] = "Meter_Install_Group";
            hc["Prestore"] =  _BCSS + _prestore;
            hc["CHARGEID"] = _chargeID;
            hc["TaskID"] = TaskID;
            hc["CHARGEBCSS"] = _BCSS;
            hc["CHARGEBCYS"] = _BCSS;
            hc["TOTALCHARGE"] = _BCSS;
            hc["FeeList"] = _FeeItems;
            hc["CHARGETYPEID"] = CHARGETYPEID.SelectedValue;
            hc["CHARGEWORKERID"] = strLogID;
            hc["CHARGEWORKERNAME"] = strRealName;
            hc["ReceiptPrintSign"] = ReceiptPrintSign.Checked;
            hc["RECEIPTNO"] = RECEIPTNO.Text;
            hc["POSRUNNINGNO"] = POSRUNNINGNO.Text;
            hc["Memo"] = Memo.Text;
            hc["LastPointSort"] = _LastPointSort;
            hc["ResolveID"] = _SelectResolveID;
            return sysidal.ApproveBudgetPrestore(hc);
        }


        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (sysidal.IsChargeOver(TaskID,_LastPointSort))
            {
                MessageBox.Show("收费完成！");
                Btn_Submit.Enabled = false;
                sysidal.UpdateApprove_defalut("Meter_Install_Group", ResolveID, true, "已收费", PointSort, TaskID);

            }
            else
            {
                MessageBox.Show("还有未收费项目！");
            }
        }
    }
}
