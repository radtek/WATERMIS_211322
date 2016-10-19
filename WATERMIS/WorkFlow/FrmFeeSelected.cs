using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetData;
using DBUtility;

namespace WorkFlow
{
    public partial class FrmFeeSelected : Form
    {
        public string sWorkFlowID = "";
        public string sPointID = "";
        public string sDoID = "";
        public string DepartementName = "";
        public string DepartementID = "";

        public FrmFeeSelected()
        {
            InitializeComponent();
        }

        private void FrmFeeSelected_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sDoID))
            {
                BindUserCheckBoxSelected();
                this.Text = DepartementName + "--收费项目选择";

                //CheckFinal();
                CheckFinal(sDoID);
            }
        }

        private void CheckFinal(string sDoID)
        {
            string sql = string.Format("SELECT DoID,FeeID,IsFinal FROM Meter_WorkDoFee WHERE DoID='{0}'", sDoID);
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sql);
            if (DataTableHelper.IsExistRows(dt))
            {
                DataRow dr = dt.Rows[0];
                RB_Final.Checked = bool.Parse(dr["IsFinal"].ToString());
            }
        }

        //private void CheckFinal()
        //{
        //    string sqlstr = string.Format("SELECT COUNT(1) FROM Meter_WorkDoFee MWF LEFT JOIN Meter_WorkDo MWD ON MWD.DoID=MWF.DoID LEFT JOIN Meter_WorkPoint MWP ON MWD.PointID=MWP.PointID LEFT JOIN Meter_WorkFlow MW ON MWP.WorkFlowID=MW.WorkFlowID WHERE MWF.IsFinal=0 AND MW.WorkFlowID='{0}'", sWorkFlowID);

        //    DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);

        //    int Num = int.Parse(dt.Rows[0][0].ToString());
        //    if (Num > 0)
        //    {
        //        RB_Final.Checked = true;
        //        RB_Final.Enabled = false;
        //    }
        //}

        private void BindUserCheckBoxSelected()
        {
            string sqlstr = "SELECT FeeID,FeeItem  FROM Meter_FeeItmes WHERE State=1 ORDER BY Sort";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            if (DataTableHelper.IsExistRows(dt))
            {
                bool IsInherit = IsEditFeeItem();
                foreach (DataRow dr in dt.Rows)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = dr["FeeItem"].ToString();
                    cb.Tag = dr["FeeID"].ToString();
                    if (IsExistFee(cb.Tag))
                    {
                        cb.Checked = true;
                    }
                    cb.Enabled = IsInherit;
                    FP1.Controls.Add(cb);
                }
            }
        }

        private bool IsExistFee(object p)
        {
            bool isexist = false;
            //string sql = string.Format("SELECT DoID,FeeID,IsFinal FROM Meter_WorkDoFee WHERE DoID='{0}'", sDoID);
            //DataTable dt = new SqlServerHelper().GetDateTableBySql(sql);
            //if (DataTableHelper.IsExistRows(dt))
            //{
            //    //foreach (DataRow dr in dt.Rows)
            //    //{
            //    //    if (dr["FeeID"].ToString().Equals(p.ToString()))
            //    //    {
            //    //        RB_Final.Checked = bool.Parse(dr["IsFinal"].ToString());
            //    //        isexist = true;
            //    //        break;
            //    //    }
            //    //}
            //}
            //else
            //{
            string sql = string.Format(@"DECLARE @WorkFlowID NVARCHAR(50)='{0}'
DECLARE @DepartementID INT={1}
DECLARE @PointSort NVARCHAR(50)=''
SELECT TOP 1 @PointSort=MWP.PointSort FROM Meter_WorkDoFee MWF LEFT JOIN Meter_WorkDo MWD ON MWD.DoID=MWF.DoID LEFT JOIN Meter_WorkPoint MWP ON MWD.PointID=MWP.PointID LEFT JOIN Meter_WorkFlow MW ON MWP.WorkFlowID=MW.WorkFlowID WHERE MW.WorkFlowID=@WorkFlowID AND DepartementID=@DepartementID ORDER BY MWP.PointSort
SELECT FeeID,IsFinal FROM Meter_WorkDoFee MWF LEFT JOIN Meter_WorkDo MWD ON MWD.DoID=MWF.DoID LEFT JOIN Meter_WorkPoint MWP ON MWD.PointID=MWP.PointID LEFT JOIN Meter_WorkFlow MW ON MWP.WorkFlowID=MW.WorkFlowID WHERE MW.WorkFlowID=@WorkFlowID AND DepartementID=@DepartementID AND MWP.PointSort=@PointSort", sWorkFlowID, DepartementID);
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sql);

            if (DataTableHelper.IsExistRows(dt))
            {
                //IsInherit = true;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["FeeID"].ToString().Equals(p.ToString()))
                    {
                        isexist = true;
                        break;
                    }
                }
            }
            //}

            return isexist;
        }

        private bool IsEditFeeItem()
        {
            int num = 0;
            int PointSort = -1;
            string sql = string.Format(@"DECLARE @WorkFlowID NVARCHAR(50)='{0}'
DECLARE @DepartementID INT={1}
DECLARE @PointSort NVARCHAR(50)=''
SELECT TOP 1 MWP.PointSort FROM Meter_WorkDoFee MWF LEFT JOIN Meter_WorkDo MWD ON MWD.DoID=MWF.DoID LEFT JOIN Meter_WorkPoint MWP ON MWD.PointID=MWP.PointID LEFT JOIN Meter_WorkFlow MW ON MWP.WorkFlowID=MW.WorkFlowID WHERE MW.WorkFlowID=@WorkFlowID AND DepartementID=@DepartementID ORDER BY MWP.PointSort", sWorkFlowID, DepartementID);
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sql);
            if (DataTableHelper.IsExistRows(dt))
            {
                num = int.Parse(dt.Rows[0][0].ToString());

            }
            sql = string.Format("SELECT  PointSort FROM Meter_WorkPoint WHERE PointID='{0}'", sPointID);
            dt = new SqlServerHelper().GetDateTableBySql(sql);
            if (DataTableHelper.IsExistRows(dt))
            {
                PointSort = int.Parse(dt.Rows[0][0].ToString());
            }

            return num == 0 ? true : num == PointSort ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SqlServerHelper().DeleteData("Meter_WorkDoFee", "DoID", sDoID);

            StringBuilder sb = new StringBuilder();
            foreach (Control c in FP1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked)
                    {
                        sb.AppendFormat("INSERT INTO Meter_WorkDoFee (DoID,FeeID,IsFinal) VALUES ('{0}','{1}','{2}')\n", sDoID, cb.Tag.ToString(), RB_Final.Checked);
                    }
                }
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                DbHelperSQL.ExecuteSql(sb.ToString());
            }
        }

        private void RB_Final_CheckedChanged_1(object sender, EventArgs e)
        {
            RB_Final.Text = RB_Final.Checked ? "预收" : "决算";
        }


    }
}
