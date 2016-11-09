using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Common.DotNetData;
using Common.DotNetUI;
using System.Collections;

namespace FinanceOS
{
    public partial class FrmFinance_RefundShow2 : Form
    {
        public string TaskID = string.Empty;

        public FrmFinance_RefundShow2()
        {
            InitializeComponent();
        }

        private void FrmFinance_RefundShow2_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TaskID))
            {
                GetTaskInfos();
            }
        }

        private void GetTaskInfos()
        {
            string sqlstr = "";
            Hashtable ht = new SqlServerHelper().GetHashtableById("View_WorkBase", "TaskID", "TaskID");
           // Hashtable ht = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            
                new SqlServerHelper().BindHashTableToForm(ht, this.panel2.Controls);

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {

        }
    }
}
