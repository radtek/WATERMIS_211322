using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using System.Collections;
using Common.DotNetCode;
using DBinterface.IDAL;
using DBinterface.DAL;
using DBinterface;


namespace MeterInstall
{
    public partial class FrmSingle : Form
    {
        public string key;
        public string state;
        public string taskid;
        private int pointSort = 0;

        private string strLogID;
        private string strName;
        private string strRealName;

        private IMeter_Install_Single sysdal = new Meter_Install_Single();

        public FrmSingle()
        {
            InitializeComponent();
        }
        private void FrmSingle_Load(object sender, EventArgs e)
        {
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            Binddata();
        }
        private void Binddata()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("waterUserType", "", "waterUserTypeId");
            ControlBindHelper.BindComboBoxData(this.waterUserTypeId, dt, "waterUserTypeName", "waterUserTypeId");

            DataTable dt2 = new SqlServerHelper().GetDataTable("waterUserHouseType", "", "waterUserHouseTypeID");
            ControlBindHelper.BindComboBoxData(this.waterUserHouseType, dt2, "waterUserHouseType", "waterUserHouseTypeID");

            if (string.IsNullOrEmpty(key))
            {
                userName.Text = strRealName;
                toolEdit.Enabled = false;
            }
            else
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_Install_Single", "SingleID", key);
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox6.Controls);

                Btn_Submit.Enabled = FlowFunction.IsAllowEdit(taskid);
                waterUserNO.Enabled = false;
                waterUserNO.ReadOnly = true;
                toolEdit.Enabled = true;
            }
        }
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();

            if (string.IsNullOrEmpty(waterUserName.Text) || string.IsNullOrEmpty(waterUserAddress.Text) || string.IsNullOrEmpty(waterPhone.Text))
            {
                MessageBox.Show("信息不完整！");
                return;
            }

            ht = new SqlServerHelper().GetHashTableByControl(this.groupBox6.Controls);

            string newKey = Guid.NewGuid().ToString();
            string SDNO = new SqlServerHelper().GetSDByTable("Meter_Install_Single");
            ht["ACCEPTID"] = SDNO;
            ht["LOGINID"] = strLogID;
            ht["SD"] = SDNO;

            AcceptID.Text = SDNO;

            if (string.IsNullOrEmpty(key))
            {
                ht["SingleID"] = newKey;
            }
            else
            {
                ht["SingleID"] = key;
            }

            if (new SqlServerHelper().Submit_AddOrEdit("Meter_Install_Single", "SingleID", key, ht))
            {
                AcceptID.Text = ht["ACCEPTID"].ToString();
                Btn_Submit.Enabled = true;

                if (string.IsNullOrEmpty(key) || state.Equals("0"))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["SingleID"].ToString(), SDNO, "Meter_Install_Single", "SingleID", "用户报装");
                    if (result)
                    {
                        MessageBox.Show("任务创建成功！");
                        new SqlServerHelper().ClearControls(groupBox6.Controls);
                    }
                    else
                    {
                        MessageBox.Show("任务创建失败！");
                    }
                }
                if (!string.IsNullOrEmpty(key))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
        }

        private void waterUserName_TextChanged(object sender, EventArgs e)
        {
            ApplyUser.Text = waterUserName.Text;
        }

        private void waterUserNO_Leave(object sender, EventArgs e)
        {
            Btn_Search_Click(sender, e);
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("waterUser", "waterUserNO", waterUserNO.Text.Trim());
            if (ht.Count > 0)
            {
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox6.Controls);
            }
            else
            {
                waterUserNO.Text = "";
            }
        }

        private void toolSearch_Click(object sender, EventArgs e)
        {

        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            DataTable dtPrint = new SqlServerHelper().GetDataTable("Meter_Install_Single", "", "");

            dtPrint.TableName = "用户报装申请表";
            ds.Tables.Add(dtPrint);
            FastReport.Report report1 = new FastReport.Report();
            try
            {
                // load the existing report
                report1.Load(Application.StartupPath + @"\PRINTModel\业扩模板\用户报装申请表.frx");
                // register the dataset
                report1.RegisterData(ds);
                report1.GetDataSource("用户报装申请表").Enabled = true;
                // run the report
                report1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // free resources used by report
                report1.Dispose();
            }
        }
    }
}
