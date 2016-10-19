using System;
using System.Data;
using Common.DotNetData;

namespace DBinterface
{
    public class FlowLib
    {
        public FlowLib()
        { }

        private string NSeparete = "";
        private DataTable _dtFlowTree = null;

        public DataTable DtFlowTree
        {
            get { return _dtFlowTree; }
            set { _dtFlowTree = value; }
        }
        public void GetFlowTree(string ParentID)
        {
            NSeparete = ParentID.Equals("0") ? "" : "|-";

            string sqlstr = string.Format("SELECT ROW_NUMBER() OVER (ORDER BY PARENTID) AS ROWNUM,('{0}'+WorkName) AS WorkName,WorkCode,CASE WHEN State=1 THEN '正常' ELSE '未启用' END AS STATE,ModifyDate,ModifyUser,WorkFlowID  FROM Meter_WorkFlow WHERE ParentID='{1}'", NSeparete, ParentID);
            DataTable dt = new DataTable();
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            if (_dtFlowTree == null)
            {
                _dtFlowTree = dt.Clone();
            }
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (ParentID.Equals("0"))
                    {
                        NSeparete = "";
                    }
                    _dtFlowTree.Rows.Add(dr.ItemArray);
                    GetFlowTree(dr["WorkFlowID"].ToString());
                }
            }
        }

    }

    public class FlowFunction
    {
        public FlowFunction()
        { }

        public static bool IsAllowEdit(string taskid, string loginid, int pointsort)
        {
            bool result = false;
            string sqlstr = string.Format("SELECT COUNT(1) FROM Meter_WorkResolve  WHERE TaskID='{0}' AND (SELECT PointSort FROM Meter_WorkTask WHERE TaskID='{0}')<{1} AND loginId LIKE '%{2}%'", taskid, pointsort, loginid);
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            if (DataTableHelper.IsExistRows(dt))
            {
                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public static bool IsAllowEdit(string taskid, string loginid)
        {
            return IsAllowEdit(taskid,loginid,3);
        }

        public static bool IsAllowEdit(string taskid)
        {
            return IsAllowEdit(taskid, AppDomain.CurrentDomain.GetData("LOGINID").ToString(), 3);
        }
    }

}
