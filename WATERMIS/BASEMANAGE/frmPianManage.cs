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
    public partial class frmPianManage : DockContentEx
    {
        public frmPianManage()
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
        BLLBASE_PIAN BLLBASE_PIAN = new BLLBASE_PIAN();
        /// <summary>
        /// 构建片区树
        /// </summary>
        /// <param name="strFatherID"></param>
        /// <param name="pNode"></param>
        private void AddTreeNode(string strFatherID, TreeNode pNode)
        {
            DataTable dt = new DataTable();
            dt = BLLBASE_PIAN.Query("");
            DataView dv = new DataView(dt);
            dv.RowFilter = "[PARENTID]='" + strFatherID + "'";
            foreach (DataRowView dr in dv)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {         //添加根节点   
                    Node.Text = dr["PIANNAME"].ToString();
                    Node.Tag = dr["PIANID"].ToString();
                    tvDep.Nodes.Add(Node);
                    tvDep.SelectedNode = Node;

                    AddTreeNode(dr["PIANID"].ToString(), Node);         //再次递归   
                }
                else
                {       //添加当前节点的子节点   
                    Node.Text = dr["PIANNAME"].ToString();
                    Node.Tag = dr["PIANID"].ToString();
                    pNode.Nodes.Add(Node);

                    AddTreeNode(dr["PIANID"].ToString(), Node); //再次递归   
                    pNode.Expand();
                }
            }
        }

        private void tvDep_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            string strDepID = e.Node.Tag.ToString();
            MODELBASE_PIAN MODELBASE_PIAN = new MODELBASE_PIAN();
            MODELBASE_PIAN = BLLBASE_PIAN.GetMODELBASE_PIAN(strDepID);
            txtID.Text = strDepID;
            txtName.Text = MODELBASE_PIAN.PIANNAME;
            txtMemo.Text = MODELBASE_PIAN.MEMO;

        }
        Messages mes = new Messages();
        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (tvDep.SelectedNode == null)
                return;
            if (tvDep.SelectedNode.Tag.ToString() == "0000")
            {
                mes.Show("该片区无法删除!");
                return;
            }
            if (tvDep.SelectedNode.Nodes.Count > 0)
            {
                mes.Show("该片区含有子片区，无法删除!");
                return;
            }
            string strID = tvDep.SelectedNode.Tag.ToString();
            try
            {
                if (mes.ShowQ("确定要删除此片区吗？") == DialogResult.OK)
                {
                    BLLBASE_PIAN.Delete(strID);
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
                mes.Show("该片区无法删除或修改!");
                return;
            }
            if (txtName.Text.Trim() == "")
            {
                mes.Show("请填写片区名称!");
                txtName.Focus();
                return;
            }
            MODELBASE_PIAN MODELBASE_PIAN = new MODELBASE_PIAN();
            MODELBASE_PIAN.PIANNAME = txtName.Text;
            MODELBASE_PIAN.PARENTID ="0000";
            MODELBASE_PIAN.MEMO = txtMemo.Text;
            if (IsADD)
                MODELBASE_PIAN.PIANID = GETTABLEID.GetTableID("", "BASE_PIAN");
            else
            {
                MODELBASE_PIAN.PIANID = txtID.Text;
            }
            try
            {
                if (IsADD)
                {
                    if (BLLBASE_PIAN.Insert(MODELBASE_PIAN))
                    {
                        tvDep.Enabled = true;
                        tvDep.Nodes.Clear();
                        AddTreeNode("0", null);
                        toolAdd.Text = "添加";
                        toolAdd.Enabled = true;
                        GetSelectedNode(tvDep.Nodes[0], MODELBASE_PIAN.PIANID);
                    }
                }
                else
                {
                    if (BLLBASE_PIAN.Update(MODELBASE_PIAN))
                    {
                        tvDep.Enabled = true;
                        tvDep.Nodes.Clear();
                        AddTreeNode("0", null);
                        GetSelectedNode(tvDep.Nodes[0], MODELBASE_PIAN.PIANID);
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
