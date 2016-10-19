using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using Common.DotNetData;

namespace WorkFlow
{
    public partial class FrmUserSelect : Form
    {
        public string UserNames = "";
        public string Loginids = "";

        public FrmUserSelect()
        {
            InitializeComponent();
        }

        private void FrmUserSelect_Load(object sender, EventArgs e)
        {
            AddTreeNode("0", null);
            BindUserCheckBoxSelected();

        }
        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENTS = new BLLBASE_DEPARTMENT();
        private void AddTreeNode(string strFatherID, TreeNode pNode)
        {
            DataTable dt = new DataTable();
            dt = BLLBASE_DEPARTMENTS.QueryDep("");
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

                    AddTreeNode(dr["DEPARTMENTID"].ToString(), Node);//再次递归   
                }
                else
                {       //添加当前节点的子节点   
                    Node.Text = dr["DEPARTMENTNAME"].ToString();
                    Node.Tag = dr["DEPARTMENTID"].ToString();
                    pNode.Nodes.Add(Node);

                    AddTreeNode(dr["DEPARTMENTID"].ToString(), Node);//再次递归   
                    pNode.Expand();
                }
            }
        }

        private void tvDep_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            string strDepID = e.Node.Tag.ToString();
            FP1.Controls.Clear();
            BindUserCheckBox(strDepID);
        }

        private void BindUserCheckBoxSelected()
        {
             UserNames= UserNames.Trim(',');
               Loginids = Loginids.Trim(',');
            if (!string.IsNullOrEmpty(UserNames) && !string.IsNullOrEmpty(Loginids))
            {
                FP2.Controls.Clear();
                string[] users = UserNames.Split(',');
                string[] loginid = Loginids.Split(',');
                if (users.Length > 0)
                {
                    for (int i = 0; i < users.Length; i++)
                    {
                        CheckBox cb = new CheckBox();
                        cb.Text = users[i];
                        cb.Tag = loginid[i];
                        cb.Checked = true;
                        cb.Click += new EventHandler(cb_Click);
                        FP2.Controls.Add(cb);
                    }

                }
            }
        }

        void cb_Click(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            UserNames = UserNames.Replace(cb.Text, "").Replace(",,", ",");
            Loginids = Loginids.Replace(cb.Tag.ToString(), "").Replace(",,", ",");
            BindUserCheckBoxSelected();
        }

        private void BindUserCheckBox(string strDepID)
        {
            string sqlstr = string.Format("SELECT userName,loginId  FROM base_login WHERE userstate=1 AND departmentID={0}", strDepID);

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = dr["userName"].ToString();
                    cb.Tag = dr["loginId"].ToString();
                    if (Loginids.IndexOf(dr["loginId"].ToString()) > -1)
                        cb.Checked = true;
                    cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
                    FP1.Controls.Add(cb);
                }
            }
        }

        void cb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                UserNames += "," + cb.Text;
                Loginids += "," + cb.Tag;
            }
            else
            {
                UserNames = UserNames.Replace(cb.Text, "").Replace(",,", ",");
                Loginids = Loginids.Replace(cb.Tag.ToString(), "").Replace(",,", ",");
            }
            BindUserCheckBoxSelected();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UserNames) && !string.IsNullOrEmpty(Loginids))
            {

                this.Close();
            }
        }

    }
}
