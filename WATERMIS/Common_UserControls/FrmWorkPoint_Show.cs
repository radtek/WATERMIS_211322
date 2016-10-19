using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common_UserControls
{
    public partial class FrmWorkPoint_Show : Form
    {
        public FrmWorkPoint_Show()
        {
            InitializeComponent();
        }

        public string TaskID = "";
        public int PointSort = 0;

        private void FrmWorkPoint_Show_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TaskID))
            {
                return;
            }
            if (PointSort==0)
            {
                return;
            }
            string sqlstr = string.Format("SELECT MW.PointName,MW.DoName,MW.userName,MW.AcceptUser,CASE MW.IsPass WHEN '1' THEN '√' WHEN '0' THEN '×' ELSE '-' END AS IsPass,MW.UserOpinion,MW.TimeLimit,MWT.PointTime,CASE MW.IsSkip WHEN '1' THEN '√' ELSE '' END AS IsSkip,MW.GoPointID AS GoPoint FROM Meter_WorkResolve MW LEFT JOIN Meter_WorkTask MWT ON MW.TaskID=MWT.TaskID LEFT JOIN Meter_WorkPoint MWP ON MW.GoPointID=MWP.PointID WHERE MW.TaskID='{0}' AND MW.PointSort={1}", TaskID, PointSort);

            DataTable dtList = new SqlServerHelper().GetDateTableBySql(sqlstr);
            dgList.DataSource = dtList;
        }
    }
}
