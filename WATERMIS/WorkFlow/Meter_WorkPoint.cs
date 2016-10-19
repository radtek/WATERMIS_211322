using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using Common.DotNetUI;
using System.Collections;
using Common.DotNetData;

namespace WorkFlow
{
    public partial class Meter_WorkPoint : DockContentEx
    {
        public Meter_WorkPoint()
        {
            InitializeComponent();
        }

        public string sWorkFlowID = "";
        public string sPointID = "";

        private void Meter_WorkPoint_Load(object sender, EventArgs e)
        {
            BindCombox();
        }
        private void BindCombox()
        {
            DataTable dt2 = new SqlServerHelper().GetDataTable("Meter_WorkFlowState", "", "ID");
            ControlBindHelper.BindComboBoxData(this.State, dt2, "Value", "ID");

            AddTreeNode("0", null);

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            if (string.IsNullOrEmpty(sWorkFlowID))
            {
                Btn_Submit.Enabled = true;
                MessageBox.Show("请重新选择节点！");
                return;
            }
            else
            {
             string   strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
             string strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

                Btn_Submit.Enabled = false;

                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashTableByControl(this.groupBox3.Controls);

                if (string.IsNullOrEmpty(sPointID))
                {
                    ht["PointID"] = Guid.NewGuid().ToString();
                    ht["CreateUser"] = strLogID;
                }
                else
                {
                    ht["PointID"] = sPointID;
                    ht["ModifyUserr"] = strLogID;
                    ht["ModifyDate"] = DateTime.Now.ToString();
                }
                ht["WorkFlowID"] = sWorkFlowID;
               
                if (new SqlServerHelper().Submit_AddOrEdit("Meter_WorkPoint", "PointID", sPointID, ht))
                {
                    TV_Point.Nodes.Clear();
                    AddPointTreeNode(sWorkFlowID);
                    ClearInput();
                    MessageBox.Show("提交成功！");
                }
                else
                {
                    Btn_Submit.Enabled = true;
                }
            }
        }

        private void ClearInput()
        {
            new SqlServerHelper().ClearControls(this.groupBox3.Controls);
            this.sPointID = "";
            PointSort.Text = getNextPoint();

        }

        private void AddTreeNode(string strFatherID, TreeNode pNode)
        {
            string sqlstr = string.Format("SELECT ROW_NUMBER() OVER (ORDER BY PARENTID) AS ROWNUM,WorkName,ParentID,WorkCode,State,ModifyDate,ModifyUser,WorkFlowID  FROM Meter_WorkFlow WHERE ParentID='{0}'", strFatherID);

            DataTable dt = new DataTable();
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            DataView dv = new DataView(dt);
            dv.RowFilter = "[ParentID]='" + strFatherID + "'";
            foreach (DataRowView dr in dv)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {         //添加根节点   
                    Node.Text = dr["WorkName"].ToString();
                    Node.Tag = dr["WorkFlowID"].ToString();
                    TV_Flow.Nodes.Add(Node);
                    //TV_Flow.SelectedNode = Node;

                    AddTreeNode(dr["WorkFlowID"].ToString(), Node);         //再次递归   
                }
                else
                {       //添加当前节点的子节点   
                    Node.Text = dr["WorkName"].ToString();
                    Node.Tag = dr["WorkFlowID"].ToString();
                    pNode.Nodes.Add(Node);

                    AddTreeNode(dr["WorkFlowID"].ToString(), Node); //再次递归   
                    pNode.Expand();
                }
            }
        }

        private void TV_Flow_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            sWorkFlowID = e.Node.Tag.ToString();
            TV_Point.Nodes.Clear();
            AddPointTreeNode(sWorkFlowID);

            PointSort.Text = getNextPoint();
        }

        private void AddPointTreeNode(string WorkFlowID)
        {
            string sqlstr = string.Format("SELECT PointID,PointName,PointSort,State  FROM Meter_WorkPoint WHERE WorkFlowID='{0}' ORDER BY PointSort", WorkFlowID);

            DataTable dt = new DataTable();
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            DataView dv = new DataView(dt);
            foreach (DataRowView dr in dv)
            {
                TreeNode Node = new TreeNode();

                Node.Text = string.Format("{0}、{1}", dr["PointSort"].ToString(), dr["PointName"].ToString());
                Node.Tag = dr["PointID"].ToString();
                if ("0".Equals(dr["State"].ToString()))
                {
                    Node.ForeColor = Color.Gray;
                }
                TV_Point.Nodes.Add(Node);
                // TV_Point.SelectedNode = Node;
            }
        }

        private void TV_Point_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            sPointID = e.Node.Tag.ToString();
            Btn_Submit.Enabled = true;
            if (!string.IsNullOrEmpty(sPointID))
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkPoint", "PointID", sPointID);
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox3.Controls);
            }
        }

        private void LB_Creaate_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = true;
            ClearInput();
        }

        private string getNextPoint()
        {
            string result = "1";
            string sqlstr = string.Format("SELECT MAX(PointSort)+1  FROM Meter_WorkPoint  WHERE WorkFlowID='{0}' AND STATE=1", sWorkFlowID);

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            if (DataTableHelper.IsExistRows(dt))
            {
                result = dt.Rows[0][0].ToString();
            }
            return result;
        }

    }
}
