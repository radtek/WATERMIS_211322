using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using System.Collections;
using DBinterface;
using System.Globalization;
using SysControl;



namespace MeterInstall
{
    public partial class FrmTransition : Form
    {
        public string key;
        public string state;
        public string taskid;
        private int pointSort = 0;

        private string strLogID;
        private string strName;
        private string strRealName;

        public FrmTransition()
        {
            InitializeComponent();
        }

        private void FrmTransition_Load(object sender, EventArgs e)
        {
            strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
            strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            if (string.IsNullOrEmpty(key))
            {
                userName.Text = strRealName;
            }
            else
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_Install_Transition", "TransitionID", key);
                new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);

                Btn_Submit.Enabled = FlowFunction.IsAllowEdit(taskid);
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();

            if (!(waterUserName.ValidateState && ProjectName.ValidateState && ApplyUser.ValidateState && ProjectNum.ValidateState && waterPhone.ValidateState && waterUserAddress.ValidateState))
            {
                MessageBox.Show("信息不完整！");
                return;
            }

            ht = new SqlServerHelper().GetHashTableByControl(this.panel1.Controls);

            string newKey = Guid.NewGuid().ToString();
            string SDNO = new SqlServerHelper().GetSDByTable("Meter_Install_Transition");
            ht["ACCEPTID"] = SDNO;
            ht["LOGINID"] = strLogID;
            ht["SD"] = SDNO;

            AcceptID.Text = SDNO;

            if (string.IsNullOrEmpty(key))
            {
                ht["TransitionID"] = newKey;
            }
            else
            {
                ht["TransitionID"] = key;
            }

            if (new SqlServerHelper().Submit_AddOrEdit("Meter_Install_Transition", "TransitionID", key, ht))
            {
                AcceptID.Text = ht["ACCEPTID"].ToString();
                Btn_Submit.Enabled = true;

                if (string.IsNullOrEmpty(key) || state.Equals("0"))
                {
                    bool result = new SqlServerHelper().CreateWorkTask(ht["TransitionID"].ToString(), SDNO, "Meter_Install_Transition", "TransitionID", "临时用水报装");

                    if (result)
                    {
                        MessageBox.Show("任务创建成功！");
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

        private void WaterUseStartDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = WaterUseStartDate.Value;

            this.WaterUseOverDate.Value = dt.AddYears(2);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string FileAgreeID = string.IsNullOrEmpty(FileAgree.Text) ? Guid.NewGuid().ToString() : FileAgree.Text;

            FrmFileUpload frm = new FrmFileUpload();
            frm.UnsubscribeID = FileAgreeID;
            frm.ShowName = "安装协议书";
            frm.TableNames = "Meter_Install_Transition";
            FileAgree.Text = FileAgreeID;
            frm.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string FileReplyID = string.IsNullOrEmpty(FileReply.Text) ? Guid.NewGuid().ToString() : FileReply.Text;

            FrmFileUpload frm = new FrmFileUpload();
            frm.UnsubscribeID = FileReplyID;
            frm.ShowName = "发改委批复文件";
            frm.TableNames = "Meter_Install_Transition";
            FileReply.Text = FileReplyID;
            frm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string FileApplyID = string.IsNullOrEmpty(FileApply.Text) ? Guid.NewGuid().ToString() : FileApply.Text;

            FrmFileUpload frm = new FrmFileUpload();
            frm.UnsubscribeID = FileApplyID;
            frm.ShowName = "申请表";
            frm.TableNames = "Meter_Install_Transition";
            FileApply.Text = FileApplyID;
            frm.ShowDialog();
        }
    }
}
