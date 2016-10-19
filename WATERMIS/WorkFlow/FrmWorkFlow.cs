using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using Common.DotNetUI;
using Common.DotNetData;
using System.Collections;
using DBinterface;

namespace WorkFlow
{
    public partial class FrmWorkFlow : DockContentEx
    {
        public string WorkFlowID = "";




        public FrmWorkFlow()
        {
            InitializeComponent();
        }

        private void FrmWorkFlow_Load(object sender, EventArgs e)
        {
            BindCombox();
        }

        private void BindCombox()
        {
            DataTable dt2 = new SqlServerHelper().GetDataTable("Meter_WorkFlowState", "", "ID");
            ControlBindHelper.BindComboBoxData(this.State, dt2, "Value", "ID");

            AddTreeNode("0", null);

            FlowLib FL = new FlowLib();
            FL.GetFlowTree("0");
            ControlBindHelper.BindComboBoxData(this.ParentID, FL.DtFlowTree, "WorkName", "WorkFlowID", true);
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
                    TV_Flow.SelectedNode = Node;

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

        private void TV_Flow_Click(object sender, EventArgs e)
        {

        }

        private void TV_Flow_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;

            WorkFlowID = e.Node.Tag.ToString();
            if (!string.IsNullOrEmpty(WorkFlowID))
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkFlow", "WorkFlowID", WorkFlowID);

                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox3.Controls);
            }

            Btn_Submit.Enabled = true;
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WorkName.Text) || string.IsNullOrEmpty(WorkCode.Text))
            {
                MessageBox.Show("信息不完整！");
                return;
            }

            Btn_Submit.Enabled = false;
            Hashtable ht = new Hashtable();

            ht = new SqlServerHelper().GetHashTableByControl(this.groupBox3.Controls);
            if (string.IsNullOrEmpty(ht["PARENTID"].ToString()))
            {
                ht["PARENTID"] = "0";
            }
            if (string.IsNullOrEmpty(WorkFlowID))
            {
                ht["WorkFlowID"] = Guid.NewGuid().ToString();
            }
            else
            {
                ht["WorkFlowID"] = WorkFlowID;
            }

            if (new SqlServerHelper().Submit_AddOrEdit("Meter_WorkFlow", "WorkFlowID", WorkFlowID, ht))
            {
                TV_Flow.Nodes.Clear();
                AddTreeNode("0", null);
                ClearInput();
                MessageBox.Show("提交成功！");
            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

        private void LB_Creaate_Click(object sender, EventArgs e)
        {
            ClearInput();
            Btn_Submit.Enabled = true;
        }

        private void ClearInput()
        {
            new SqlServerHelper().ClearControls(this.groupBox3.Controls);
            this.WorkFlowID = "";

        }

    }
}
