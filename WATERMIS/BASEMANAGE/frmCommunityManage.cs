using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using MODEL;
using BASEFUNCTION;

namespace BASEMANAGE
{
    public partial class frmCommunityManage : DockContentEx
    {
        public frmCommunityManage()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        private void frmAreaManage_Load(object sender, EventArgs e)
        {
            AddTreeNode("0", null);
        }
        Log lg = new Log(Application.StartupPath + "\\Log\\", LogType.Daily);
        PinYinConvert PinYinConvert = new PinYinConvert();
        BLLBASE_COMMUNITY BLLBASE_COMMUNITY = new BLLBASE_COMMUNITY();
        /// <summary>
        /// 构建小区树
        /// </summary>
        /// <param name="strFatherID"></param>
        /// <param name="pNode"></param>
        private void AddTreeNode(string strFatherID, TreeNode pNode)
        {
            DataTable dt = new DataTable();
            dt = BLLBASE_COMMUNITY.Query("");
            DataView dv = new DataView(dt);
            dv.RowFilter = "[PARENTID]='" + strFatherID + "'";
            foreach (DataRowView dr in dv)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {         //添加根节点   
                    Node.Text = dr["COMMUNITYNAME"].ToString();
                    Node.Tag = dr["COMMUNITYID"].ToString();
                    tvDep.Nodes.Add(Node);
                    tvDep.SelectedNode = Node;

                    AddTreeNode(dr["COMMUNITYID"].ToString(), Node);         //再次递归   
                }
                else
                {       //添加当前节点的子节点   
                    Node.Text = dr["COMMUNITYNAME"].ToString();
                    Node.Tag = dr["COMMUNITYID"].ToString();
                    pNode.Nodes.Add(Node);

                    AddTreeNode(dr["COMMUNITYID"].ToString(), Node); //再次递归   
                    pNode.Expand();
                }
            }
        }

        private void tvDep_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            string strDepID = e.Node.Tag.ToString();
            MODELBASE_COMMUNITY MODELBASE_COMMUNITY = new MODELBASE_COMMUNITY();
            MODELBASE_COMMUNITY = BLLBASE_COMMUNITY.GetMODELBASE_COMMUNITY(strDepID);
            txtID.Text = strDepID;
            txtName.Text = MODELBASE_COMMUNITY.COMMUNITYNAME;
            txtMemo.Text = MODELBASE_COMMUNITY.MEMO;

        }
        Messages mes = new Messages();
        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (tvDep.SelectedNode == null)
                return;
            if (tvDep.SelectedNode.Tag.ToString() == "0000")
            {
                mes.Show("该小区无法删除!");
                return;
            }
            if (tvDep.SelectedNode.Nodes.Count > 0)
            {
                mes.Show("该小区含有子小区，无法删除!");
                return;
            }
            string strID = tvDep.SelectedNode.Tag.ToString();
            try
            {
                if (mes.ShowQ("确定要删除此小区吗？") == DialogResult.OK)
                {
                    BLLBASE_COMMUNITY.Delete(strID);
                    tvDep.Nodes.Remove(tvDep.SelectedNode);
                }
            }
            catch (Exception ex)
            {
                lg.Write(ex.ToString(), MsgType.Error);
                mes.Show(ex.Message.ToString());
                return;
            }
        }
        bool IsADD;
        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (toolAdd.Text == "添加")
            {
                IsADD = true;
                txtName.Clear();
                txtMemo.Clear();
                tvDep.Enabled = false;
                txtID.Clear();
                toolAdd.Text = "取消";
                txtName.Focus();
            }
            else
            {

                TreeViewEventArgs tve = new TreeViewEventArgs(tvDep.SelectedNode, TreeViewAction.ByMouse);
                tvDep_AfterSelect(null, tve);
                tvDep.Enabled = true;
                toolAdd.Text = "添加";
            }
        }
        GETTABLEID GETTABLEID = new GETTABLEID();
        private void toolSubmit_Click(object sender, EventArgs e)
        {

            if (!IsADD && tvDep.SelectedNode.Tag.ToString() == "0000")
            {
                mes.Show("该小区无法删除或修改!");
                return;
            }
            if (txtName.Text.Trim() == "")
            {
                mes.Show("请填写小区名称!");
                txtName.Focus();
                return;
            }
            MODELBASE_COMMUNITY MODELBASE_COMMUNITY = new MODELBASE_COMMUNITY();
            MODELBASE_COMMUNITY.COMMUNITYNAME = txtName.Text;
            MODELBASE_COMMUNITY.PARENTID ="0000";
            MODELBASE_COMMUNITY.MEMO = txtMemo.Text;
            if (IsADD)
                MODELBASE_COMMUNITY.COMMUNITYID = GETTABLEID.GetTableID("", "BASE_COMMUNITY");
            else
            {
                MODELBASE_COMMUNITY.COMMUNITYID = txtID.Text;
            }
            try
            {
                if (IsADD)
                {
                    if (BLLBASE_COMMUNITY.Insert(MODELBASE_COMMUNITY))
                    {
                        tvDep.Enabled = true;
                        tvDep.Nodes.Clear();
                        AddTreeNode("0", null);
                        toolAdd.Text = "添加";
                        toolAdd.Enabled = true;
                        GetSelectedNode(tvDep.Nodes[0], MODELBASE_COMMUNITY.COMMUNITYID);
                    }
                }
                else
                {
                    if (BLLBASE_COMMUNITY.Update(MODELBASE_COMMUNITY))
                    {
                        tvDep.Enabled = true;
                        tvDep.Nodes.Clear();
                        AddTreeNode("0", null);
                        GetSelectedNode(tvDep.Nodes[0], MODELBASE_COMMUNITY.COMMUNITYID);
                    }
                }

            }
            catch (Exception ex)
            {
                lg.Write(ex.ToString(), MsgType.Error);
                mes.Show(ex.Message.ToString());
                return;
            }
            IsADD = false;
        }
        private void GetSelectedNode(TreeNode Node, string strID)
        {
            if (Node != null)
                if (Node.Tag.ToString() == strID)
                    tvDep.SelectedNode = Node;
                else
                    foreach (TreeNode CNode in Node.Nodes)
                    {
                        GetSelectedNode(CNode, strID);
                    }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
                txtID.Text = PinYinConvert.GetHeadOfChs(txtName.Text);
        }
    }
}
