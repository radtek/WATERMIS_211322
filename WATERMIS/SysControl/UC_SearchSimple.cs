using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.BLL;
using Common.DotNetUI;

namespace SysControl
{
    public partial class UC_SearchSimple : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;
                return parms;
            }
        }

        public StringBuilder sb = new StringBuilder();


        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler BtnEvent;

        public UC_SearchSimple()
        {
            InitializeComponent();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            sb.Length = 0;
            DateTime dt1;
            DateTime dt2;
            string sqlwhere = "";
            if (CHK_waterMeterProofreadingDate.Checked)
            {
                if (!DateTime.TryParse(DT_waterMeterProofreadingDate_1.Text, out dt1))
                {
                    MessageBox.Show("请重新选择日期！");
                    return;
                }
                if (!DateTime.TryParse(DT_waterMeterProofreadingDate_2.Text, out dt2))
                {
                    MessageBox.Show("请重新选择日期！");
                    return;
                }
                if (dt2 < dt1)
                {
                    MessageBox.Show("请重新选择日期！");
                    return;
                }
                else
                {
                    dt2 = dt2.AddDays(1);
                    sb.AppendFormat(" CreateDate >'{0}' and CreateDate < '{1}'", dt1, dt2);
                }

                if (new SqlServerHelper().GetSqlWhereByControl(this.Controls, ref sqlwhere))
                {
                    sb.Append(" AND ");
                    sb.Append(sqlwhere);
                }
            }
            else
            {
                if (new SqlServerHelper().GetSqlWhereByControl(this.Controls, ref sqlwhere))
                {
                    sb.Append(" ");
                    sb.Append(sqlwhere);
                }
            }

            if (BtnEvent != null)
            {
                BtnEvent(sender, e);
            }   
           
        }

        private void UC_SearchModule_Load(object sender, EventArgs e)
        {
        }
        private void DT_waterMeterProofreadingDate_2_ValueChanged(object sender, EventArgs e)
        {
             DateTime dt1;
            DateTime dt2;
            if (!DateTime.TryParse(DT_waterMeterProofreadingDate_1.Text, out dt1))
            {
                return;
            }
            if (!DateTime.TryParse(DT_waterMeterProofreadingDate_2.Text, out dt2))
            {
                return;
            }
            if (dt2 < dt1)
            {
                DT_waterMeterProofreadingDate_2.Text = DT_waterMeterProofreadingDate_1.Text;
            }
        }

    }
}
