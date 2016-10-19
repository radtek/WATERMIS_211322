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
    public partial class Meter_WorkDo : DockContentEx
    {
        public string sWorkFlowID = "";
        public string sPointID = "";
        public string sDoID = "";
        public Meter_WorkDo()
        {
            InitializeComponent();
        }

        private void Meter_WorkDo_Load(object sender, EventArgs e)
        {
            BindCombox();
            AddTreeNode(null, "Meter_WorkFlow", "WorkName", "WorkFlowID", "ParentID", "0");
        }

        private void BindCombox()
        {
            DataTable dt1 = new SqlServerHelper().GetDataTable("base_department", "", "departmentID");
            ControlBindHelper.BindComboBoxData(this.DepartementID, dt1, "departmentName", "departmentID");


            DataTable dt2 = new SqlServerHelper().GetDataTable("Meter_WorkFlowState", "", "ID");
            ControlBindHelper.BindComboBoxData(this.State, dt2, "Value", "ID");
        }

        #region TreeNode
        private void AddTreeNode(TreeNode pNode, string TablekName, string showValue, string pkName, string ParentName, string ParentID)
        {
            string sqlstr = string.Format("SELECT ROW_NUMBER() OVER (ORDER BY PARENTID) AS ROWNUM,{0},{1},{2}  FROM {3} WHERE {2}='{4}'", showValue, pkName, ParentName, TablekName, ParentID);

            DataTable dt = new DataTable();
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            DataView dv = new DataView(dt);
            dv.RowFilter = "[" + ParentName + "]='" + ParentID + "'";
            foreach (DataRowView dr in dv)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {         //添加根节点   
                    Node.Text = dr[showValue].ToString();
                    Node.Tag = dr[pkName].ToString();
                    TV_Flow.Nodes.Add(Node);
                    //TV_Flow.SelectedNode = Node;

                    AddTreeNode(Node, TablekName, showValue, pkName, ParentName, dr[pkName].ToString());//再次递归   
                }
                else
                {       //添加当前节点的子节点   
                    Node.Text = dr[showValue].ToString();
                    Node.Tag = dr[pkName].ToString();
                    pNode.Nodes.Add(Node);

                    AddTreeNode(Node, TablekName, showValue, pkName, ParentName, dr[pkName].ToString());//再次递归  
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
            TV_Do.Nodes.Clear();
            AddDoTreeNode(sPointID);

            DataTable dt3 = new SqlServerHelper().GetDataTable("Meter_WorkPoint", " WorkFlowID='" + sWorkFlowID + "'", "PointSort");

            ControlBindHelper.BindComboBoxData(this.GoPointID, dt3, "PointName", "PointID");
           
        }

        private void AddDoTreeNode(string PointID)
        {
            string sqlstr = string.Format("SELECT DoID,DoName  FROM Meter_WorkDo WHERE PointID='{0}' ORDER BY CreateDate", PointID);

            DataTable dt = new DataTable();
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            DataView dv = new DataView(dt);
            foreach (DataRowView dr in dv)
            {
                TreeNode Node = new TreeNode();

                Node.Text = dr["DoName"].ToString();
                Node.Tag = dr["DoID"].ToString();

                TV_Do.Nodes.Add(Node);
            }
        }

        private void TV_Do_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            sDoID = e.Node.Tag.ToString();
            Btn_Submit.Enabled = true;
            if (!string.IsNullOrEmpty(sDoID))
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkDo", "DoID", sDoID);
                new SqlServerHelper().BindHashTableToForm(ht, this.groupBox1.Controls);

                if (string.IsNullOrEmpty(this.FrmAssemblyName.Text.Trim()))
                {
                    this.FrmAssemblyName.Text = "PersonalWork";
                }

                GetChargeItems();
            }
        }
        #endregion

        #region ControlEvent
        private void LB_Creaate_Click(object sender, EventArgs e)
        {
            new SqlServerHelper().ClearControls(this.groupBox1.Controls);
            this.sDoID = "";
            this.FrmAssemblyName.Text = "PersonalWork";
            Btn_Submit.Enabled = true;
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            if (checkFormVaild())
            {
                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashTableByControl(this.groupBox1.Controls);
                if (string.IsNullOrEmpty(sDoID))
                {
                    ht["DoID"] = Guid.NewGuid().ToString();
                    ht["CreateDate"] = DateTime.Now.ToString();
                    ht["CreateUser"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                }
                else
                {
                    ht["DoID"] = sDoID;
                    ht["ModifyDate"] = DateTime.Now.ToString();
                    ht["ModifyUserr"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                }
                ht["PointID"] = sPointID;
                if (new SqlServerHelper().Submit_AddOrEdit("Meter_WorkDo", "DoID", sDoID, ht))
                {
                    this.sDoID = "";
                    new SqlServerHelper().ClearControls(this.groupBox1.Controls);
                    TV_Do.Nodes.Clear();
                    AddDoTreeNode(sPointID);
                    Btn_Submit.Enabled = true;
                    MessageBox.Show("保存成功！");
                }
            }
            else
            {
                MessageBox.Show("信息不完整！");
                Btn_Submit.Enabled = true;
            }
        }

        private void IsSkip_CheckedChanged(object sender, EventArgs e)
        {
            LB_Skip.Visible = IsSkip.Checked;
            GoPointID.Visible = IsSkip.Checked;
            IsSkip.Text = IsSkip.Checked ? "允许跳转" : "不允许跳转";
        }

        private void IsCharge_CheckedChanged(object sender, EventArgs e)
        {
            LB_Charge.Visible = IsCharge.Checked;
            RTB_Charge.Visible = IsCharge.Checked;
            IsCharge.Text = IsCharge.Checked ? "允许收费，点击【收费项目】框，选择收费项目" : "不允许收费";
        }

        private bool checkFormVaild()
        {
            if (string.IsNullOrEmpty(DoName.Text) || string.IsNullOrEmpty(TimeLimit.Text) || string.IsNullOrEmpty(loginId.Text) || string.IsNullOrEmpty(userName.Text) || string.IsNullOrEmpty(DepartementID.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void IsVoided_CheckedChanged(object sender, EventArgs e)
        {
            IsVoided.Text = IsVoided.Checked ? "允许作废" : "不允许作废";
        }

        private void IsViewCharge_CheckedChanged(object sender, EventArgs e)
        {
            IsViewCharge.Text = IsViewCharge.Checked ? "允许查看收费明细" : "不允许查看收费明细";
        }

        private void userName_Click(object sender, EventArgs e)
        {
                FrmUserSelect frm = new FrmUserSelect();
                frm.Loginids = loginId.Text;
                frm.UserNames = userName.Text;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    loginId.Text = frm.Loginids;
                    userName.Text = frm.UserNames;
                }
        }

        private void RTB_Charge_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sDoID))
            {
                FrmFeeSelected frm = new FrmFeeSelected();
                frm.sDoID = sDoID;
                frm.sWorkFlowID = sWorkFlowID;
                frm.sPointID = sPointID;
                frm.DepartementName = DepartementID.Text;
                frm.DepartementID = DepartementID.SelectedValue.ToString();
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    GetChargeItems();
                }
            }
        }
        #endregion

        private void GetChargeItems()
        {
            string sqlstr =string.Format("SELECT STUFF((SELECT ','+FeeItem FROM (SELECT MF.FeeItem FROM Meter_WorkDoFee MWD LEFT JOIN Meter_FeeItmes MF ON MWD.FeeID=MF.FeeID WHERE MWD.DoID='{0}') T FOR xml path('')),1,1,'')",sDoID);

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            if (DataTableHelper.IsExistRows(dt))
            {
                RTB_Charge.Text = dt.Rows[0][0].ToString();
            }
        }

       


    }
}
