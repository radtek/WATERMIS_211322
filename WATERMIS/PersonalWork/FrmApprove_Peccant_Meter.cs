using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.DAL;
using DBinterface.IDAL;
using Common.WinDevices;

namespace PersonalWork
{
    public partial class FrmApprove_Peccant_Meter : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public Hashtable hm = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;

        private bool skip = false;
        private string ComputerName = "";
        private string ip = "";
        private string DepartementID = "0";

        public FrmApprove_Peccant_Meter()
        {
            InitializeComponent();
        }

        private void FrmApprove_Peccant_Meter_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            #region //2017-2-22 RONG
            bool IsAllowEdit = false;
            if (ht.Contains("Edit"))
            {
                if (bool.TryParse(ht["Edit"].ToString(), out IsAllowEdit))
                {

                }
            }
            Btn_Submit.Enabled = IsAllowEdit;
            Btn_Add.Enabled = IsAllowEdit;
            #endregion
            hm["TaskID"] = TaskID;
            hm["ModifyUser"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString(); ;
            hm["Memo"] = string.Format("违章用户新装-{0}-{1}", PointSort, ResolveID);
            hm["waterMeterSerialNumber"] = "";
           
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            ComputerName = new Computer().ComputerName;
            ip = new Computer().IpAddress;
            MeterOut();
        }

        private void MeterOut()
        {
            if (sysidal.ApproveMeterOut(hm))
            {
                UpdateApprove();
            }
        }

        private void UpdateApprove()
        {
            int count = sysidal.UpdateApprove_Peccant_defalut(ResolveID, true, UserOpinion.Text.Trim(), ip, ComputerName, PointSort, TaskID);

            if (count > 0)
            {
                MessageBox.Show("提交成功！");
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

        private void waterMeterSerialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    TB_MeterInfos.Text = "";
            //    Btn_Submit.Enabled = false;
            //    BindMeterInfos();
            //}
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            FrmApprove_MeterSelect frm = new FrmApprove_MeterSelect();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                hm["waterMeterSerialNumber"] = string.Format("{0},'{1}'", hm["waterMeterSerialNumber"].ToString(), frm._waterMeterSerialNumber).TrimStart(',');
                waterMeterSerialNumber.Text += "  " + frm._waterMeterSerialNumber;
                TB_MeterInfos.Text += frm.sb.ToString();
                Btn_Submit.Enabled = true;
            }
        }

        //private void BindMeterInfos()
        //{
        //    if (!string.IsNullOrEmpty(waterMeterSerialNumber.Text.Trim()))
        //    {
        //        Hashtable ht = new SqlServerHelper().GetHashtableById("(SELECT * FROM View_MeterDetail WHERE MeterState=0) T ", "waterMeterSerialNumber", waterMeterSerialNumber.Text.Trim());
        //        if (ht.Count>0)
        //        {
        //            StringBuilder sb = new StringBuilder();

        //            sb.AppendFormat("水表出厂编号：{0}\r\n\r\n", ht["WATERMETERSERIALNUMBER"].ToString());
        //            sb.AppendFormat("口径：{0}\r\n\r\n", ht["WATERMETERSIZEVALUE"].ToString());
        //            sb.AppendFormat("水表型号：{0}\r\n\r\n", ht["WATERMETERMODE"].ToString());
        //            sb.AppendFormat("水表状态：{0}\r\n\r\n", ht["STATEDESCRIBE"].ToString());
        //            sb.AppendFormat("初始读数：{0}\r\n\r\n", ht["WATERMETERSTARTNUMBER"].ToString());
        //            sb.AppendFormat("所属用户：{0}\r\n\r\n", ht["WATERUSERID"].ToString());
        //            sb.AppendFormat("水表厂家：{0}\r\n\r\n", ht["WATERMETERPRODUCT"].ToString());
        //            sb.AppendFormat("鉴定日期：{0}\r\n\r\n", ht["WATERMETERPROOFREADINGDATE"].ToString());
        //            sb.AppendFormat("鉴定周期：{0}\r\n\r\n", ht["WATERMETEPROOFREADINGPERIOD"].ToString());

        //            TB_MeterInfos.Text = sb.ToString();

        //            hm["MeterID"] = ht["METERID"];
        //            hm["waterMeterSerialNumber"] = ht["WATERMETERSERIALNUMBER"];
        //            hm["waterMeterEndNumber"] = ht["WATERMETERSTARTNUMBER"];

        //            Btn_Submit.Enabled = true;
        //        }
        //    }
        //}
    }
}
