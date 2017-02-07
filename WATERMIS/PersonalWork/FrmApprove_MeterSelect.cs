using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MeterBusiness;

namespace PersonalWork
{
    public partial class FrmApprove_MeterSelect : Form
    {
        public string _waterMeterSerialNumber = "";
        public StringBuilder sb = new StringBuilder();
        public FrmApprove_MeterSelect()
        {
            InitializeComponent();
        }

        private void waterMeterSerialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_MeterInfos.Text = "";
                BindMeterInfos();
            }
        }

        private void BindMeterInfos()
        {
            if (!string.IsNullOrEmpty(waterMeterSerialNumber.Text.Trim()))
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("(SELECT * FROM View_MeterDetail WHERE MeterState=0) T ", "waterMeterSerialNumber", waterMeterSerialNumber.Text.Trim());
                if (ht.Count > 0)
                {
                    sb.AppendFormat("水表出厂编号：{0}\r\n\r\n", ht["WATERMETERSERIALNUMBER"].ToString());
                    sb.AppendFormat("口径：{0}\r\n\r\n", ht["WATERMETERSIZEVALUE"].ToString());
                    sb.AppendFormat("水表型号：{0}\r\n\r\n", ht["WATERMETERMODE"].ToString());
                    sb.AppendFormat("水表状态：{0}\r\n\r\n", ht["STATEDESCRIBE"].ToString());
                    sb.AppendFormat("初始读数：{0}\r\n\r\n", ht["WATERMETERSTARTNUMBER"].ToString());
                    sb.AppendFormat("所属用户：{0}\r\n\r\n", ht["WATERUSERID"].ToString());
                    sb.AppendFormat("水表厂家：{0}\r\n\r\n", ht["WATERMETERPRODUCT"].ToString());
                    sb.AppendFormat("鉴定日期：{0}\r\n\r\n", ht["WATERMETERPROOFREADINGDATE"].ToString());
                    sb.AppendFormat("鉴定周期：{0}\r\n\r\n", ht["WATERMETEPROOFREADINGPERIOD"].ToString());
                    sb.Append("---------------------------\r\n");

                    TB_MeterInfos.Text = sb.ToString();
                    _waterMeterSerialNumber = ht["WATERMETERSERIALNUMBER"].ToString();
                   
                }
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            TB_MeterInfos.Text = "";
            BindMeterInfos();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_MeterIN_Click(object sender, EventArgs e)
        {
            FrmEntering frm = new FrmEntering();
            //frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                waterMeterSerialNumber.Text = frm.Tag.ToString();
                Btn_Search_Click(sender,e);
            }
        }
    }
}
