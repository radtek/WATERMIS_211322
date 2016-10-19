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
    public partial class FrmDepartment : DockContentEx
    {
        public FrmDepartment()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
        }

        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            BindDEP();
            AddTreeNode("0", null);
        }
        private void BindDEP()
        {
            DataTable dt = new DataTable();
            dt = BLLBASE_DEPARTMENT.QueryDep("");
            cmbParentID.DataSource = dt;
            cmbParentID.DisplayMember = "DEPARTMENTNAME";
            cmbParentID.ValueMember = "DEPARTMENTID";
        }
        Log lg = new Log(Application.StartupPath + "\\Log\\", LogType.Daily);
        PinYinConvert PinYinConvert = new PinYinConvert();
        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENT = new BLLBASE_DEPARTMENT();
        /// <summary>
        /// 构建部门树
        /// </summary>
        /// <param name="strFatherID"></param>
        /// <param name="pNode"></param>
        private void AddTreeNode(string strFatherID, TreeNode pNode)
        {
            DataTable dt = new DataTable();
            dt = BLLBASE_DEPARTMENT.QueryDep("");
            DataView dv = new DataView(dt);
            dv.RowFilter = "[PARENTID]='" + strFatherID + "'";
            foreach (DataRowView dr in dv)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {         //添加根节点   
                    Node.Text = dr["DEPARTMENTNAME"].ToString();
                    Node.Tag = dr["DEPARTMENTID"].ToString();
                    tvDep.Nodes.Add(Node);
                    tvDep.SelectedNode = Node;

                    AddTreeNode(dr["DEPARTMENTID"].ToString(), Node);         //再次递归   
                }
                else
                {       //添加当前节点的子节点   
                    Node.Text = dr["DEPARTMENTNAME"].ToString();
                    Node.Tag = dr["DEPARTMENTID"].ToString();
                    pNode.Nodes.Add(Node);

                    AddTreeNode(dr["DEPARTMENTID"].ToString(), Node); //再次递归   
                    pNode.Expand();
                }
            }
        }

        private void tvDep_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node==null)
                return;
            string strDepID = e.Node.Tag.ToString() ;
            MODELBASE_DEPARTMENT MODELBASE_DEPARTMENT = new MODELBASE_DEPARTMENT();
            MODELBASE_DEPARTMENT = BLLBASE_DEPARTMENT.GetModelBASE_DEPARTMENT(strDepID);
            txtID.Text = strDepID;
            txtName.Text = MODELBASE_DEPARTMENT.DEPARTMENTNAME;
            cmbParentID.SelectedValue = MODELBASE_DEPARTMENT.PARENTID;
            cmbLeader.Text = MODELBASE_DEPARTMENT.DEPARTMENTMANAGER;
            txtTel.Text = MODELBASE_DEPARTMENT.DEPARTMENTTEL;
            txtMemo.Text = MODELBASE_DEPARTMENT.MEMO;
            txtCode.Text = MODELBASE_DEPARTMENT.SIMPLECODE;
            
        }
        Messages mes = new Messages();
        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (tvDep.SelectedNode == null)
                return;
            if (tvDep.SelectedNode.Tag.ToString() == "01")
            {
                mes.Show("该部门无法删除!");
                return;
            }
            if (tvDep.SelectedNode.Nodes.Count > 0)
            {
                mes.Show("该部门含有子部门，无法删除!");
                return;
            }
            string strID = tvDep.SelectedNode.Tag.ToString();
            try
            {
                if (mes.ShowQ("确定要删除此部门吗？") == DialogResult.OK)
                {
                    BLLBASE_DEPARTMENT.DeleteDEP(strID);
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
            IsADD = true;
            txtName.Clear();
            txtTel.Clear();
            txtMemo.Clear();
            cmbLeader.Text = "";
            //cmbParentID.SelectedValue = tvDep.SelectedNode.Tag;
            toolAdd.Enabled = false;
            toolSubmit.Enabled = true;
            tvDep.Enabled = false;
            txtCode.Clear();
        }
        GETTABLEID GETTABLEID = new GETTABLEID();
        private void toolSubmit_Click(object sender, EventArgs e)
        {

            if (!IsADD&&tvDep.SelectedNode.Tag.ToString() == "01")
            {
                mes.Show("该部门无法删除或修改!");
                return;
            }
            if (txtName.Text.Trim() == "")
            {
                mes.Show("请填写部门名称!");
                txtName.Focus();
                return;
            }
            if (txtCode.Text.Trim() == "")
            {
                mes.Show("请填写部门拼音简码!");
                txtCode.Focus();
                return;
            }
            //if (cmbParentID.SelectedValue == null && tvDep.SelectedNode.Tag.ToString()!="00010001")
            if (cmbParentID.SelectedValue == null)
            {
                mes.Show("请选择所属部门!");
                cmbParentID.Focus();
                return;
            }
            MODELBASE_DEPARTMENT MODELBASE_DEPARTMENT = new MODELBASE_DEPARTMENT();
            MODELBASE_DEPARTMENT.DEPARTMENTNAME = txtName.Text;
            //if (tvDep.SelectedNode.Tag.ToString() != "00010001")
            //MODELBASE_DEPARTMENT.PARENTID = cmbParentID.SelectedValue.ToString();
            //else
            //    MODELBASE_DEPARTMENT.PARENTID = "0";
            MODELBASE_DEPARTMENT.PARENTID = cmbParentID.SelectedValue.ToString();
            MODELBASE_DEPARTMENT.DEPARTMENTMANAGER = cmbLeader.Text;
            MODELBASE_DEPARTMENT.DEPARTMENTTEL = txtTel.Text;
            MODELBASE_DEPARTMENT.MEMO = txtMemo.Text;
            MODELBASE_DEPARTMENT.SIMPLECODE = txtCode.Text.Trim();
            if (IsADD)
                MODELBASE_DEPARTMENT.DEPARTMENTID = GETTABLEID.GetTableID(MODELBASE_DEPARTMENT.PARENTID, "BASE_DEPARTMENT");
            else
            {
                MODELBASE_DEPARTMENT.DEPARTMENTID = txtID.Text;
                //if (MODELBASE_DEPARTMENT.DEPARTMENTIDOLD.Substring(0, MODELBASE_DEPARTMENT.PARENTID.Length) == MODELBASE_DEPARTMENT.PARENTID)
                //    MODELBASE_DEPARTMENT.DEPARTMENTID = MODELBASE_DEPARTMENT.DEPARTMENTIDOLD;
                //else
                //MODELBASE_DEPARTMENT.DEPARTMENTID = GETTABLEID.GetTableID(MODELBASE_DEPARTMENT.PARENTID, "BASE_DEPARTMENT");
            }
            try
            {
                if (IsADD)
                {
                    if (BLLBASE_DEPARTMENT.InsertBASE_DEPARTMENT(MODELBASE_DEPARTMENT))
                    {
                        tvDep.Enabled = true;
                        tvDep.Nodes.Clear();
                        AddTreeNode("0", null);
                        toolAdd.Enabled = true;
                        GetSelectedNode(tvDep.Nodes[0],MODELBASE_DEPARTMENT.DEPARTMENTID);
                        BindDEP();
                    }
                }
                else
                {
                    if (BLLBASE_DEPARTMENT.UpdateDEP(MODELBASE_DEPARTMENT))
                    {
                        tvDep.Enabled = true;
                        tvDep.Nodes.Clear();
                        AddTreeNode("0", null);
                        GetSelectedNode(tvDep.Nodes[0], MODELBASE_DEPARTMENT.DEPARTMENTID);
                        BindDEP();
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
                        GetSelectedNode(CNode,strID);
                    }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(txtName.Text.Trim()!="")
            txtCode.Text = PinYinConvert.GetHeadOfChs(txtName.Text);
        }
    }
}
