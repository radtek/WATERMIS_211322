using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.DotNetData;
using System.Data.SqlClient;
using Common.DotNetCode;

namespace SysControl
{
    public partial class UC_FlowList : UserControl
    {
        public UC_FlowList()
        {
            InitializeComponent();
        }
      
        private string _TaskId;
        public string TaskId
        {
            get { return _TaskId; }
            set { _TaskId = value; }
        }

        //private DataTable _DataSource;

        //public DataTable DataSource
        //{
        //    get { return _DataSource; }
        //    set { _DataSource = value; }
        //}
        public void DataBind()
        {
            FP_Flow.Controls.Clear();

            if (ValidateUtil.IsGuid(_TaskId))
            {
                string sqlstr = @"SELECT distinct PointSort,PointName,TaskID,
(SELECT TOP 1 AcceptUser FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=MWR.PointSort) AS AcceptUser,
(SELECT TOP 1 CONVERT(VARCHAR(10),AcceptDate,120) FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort=MWR.PointSort) AS AcceptDate
FROM Meter_WorkResolve MWR where TaskID=@TaskID order by PointSort";
                DataTable _DataSource = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", _TaskId) });

                if (DataTableHelper.IsExistRows(_DataSource))
                {
                    object obj = new SqlServerHelper().GetFirsRowsValue("select PointSort from Meter_WorkTask where TaskID=@TaskID", new SqlParameter[] { new SqlParameter("@TaskID", _TaskId) });
                    int num = int.Parse(obj.ToString());

                    foreach (DataRow dr in _DataSource.Rows)
                    {
                        UC_FlowModule uc = new UC_FlowModule();
                        uc.SLabelText = dr["AcceptUser"].ToString();
                        uc.SLabelDescription = dr["AcceptDate"].ToString();
                        uc.SLablePoint = dr["PointName"].ToString();
                        int pointid = int.Parse(dr["PointSort"].ToString());
                        uc.TaskId = _TaskId;
                        uc.PointSort = pointid;
                        if (pointid < num)
                        {
                            uc.SBackColor = Color.Green;
                        }
                        else
                        {
                            uc.SBackColor = Color.Gray;
                        }
                        uc.FlowModuleClick += new EventHandler(uc_FlowModuleClick);
                        FP_Flow.Controls.Add(uc);
                    }
                }
            }
        }

        void uc_FlowModuleClick(object sender, EventArgs e)
        {
            UC_FlowModule uc = (UC_FlowModule)sender;
            FrmWorkPoint_Show frm = new FrmWorkPoint_Show();
            frm.TaskID = uc.TaskId;
            frm.PointSort = uc.PointSort;
            frm.ShowDialog();

        }

    }
}
