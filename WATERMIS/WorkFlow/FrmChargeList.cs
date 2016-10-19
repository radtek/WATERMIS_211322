using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BASEFUNCTION;

namespace WorkFlow
{
    public partial class FrmChargeList : DockContentEx
    {
        public string FeeID = "";
        public FrmChargeList()
        {
            InitializeComponent();
        }

        private void FrmChargeList_Load(object sender, EventArgs e)
        {
            AddFeeTreeNode();
        }

        private void AddFeeTreeNode()
        {
            TV_FeeItems.Nodes.Clear();
            string sqlstr = "SELECT FeeID,FeeItem,State,DefaultValue,Sort  FROM Meter_FeeItmes  ORDER BY Sort ";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            DataView dv = new DataView(dt);
            foreach (DataRowView dr in dv)
            {
                TreeNode Node = new TreeNode();

                Node.Text = dr["FeeItem"].ToString();
                Node.Tag = dr["FeeID"].ToString();
                if ("0".Equals(dr["State"].ToString()))
                {
                    Node.ForeColor = Color.LightBlue;
                }
                TV_FeeItems.Nodes.Add(Node);
            }
        }

        private void TV_FeeItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            FeeID = e.Node.Tag.ToString();

            if (!string.IsNullOrEmpty(FeeID))
            {
                Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_FeeItmes", "FeeID", FeeID);
                new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);
            }
        }

        private void Btn_submit_Click(object sender, EventArgs e)
        {
            Btn_submit.Enabled = false;

            if (!string.IsNullOrEmpty(FeeItem.Text))
            {
                Hashtable ht = new Hashtable();
                ht = new SqlServerHelper().GetHashTableByControl(this.panel1.Controls);

                if (new SqlServerHelper().Submit_AddOrEdit("Meter_FeeItmes", "FeeID", FeeID, ht))
                {
                    this.FeeID = "";
                    new SqlServerHelper().ClearControls(this.panel1.Controls);
                    AddFeeTreeNode();
                    Btn_submit.Enabled = true;
                    MessageBox.Show("保存成功！");
                }
            }
            else
            {
                Btn_submit.Enabled = true;
            }
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new SqlServerHelper().ClearControls(this.panel1.Controls);
            this.FeeID = "";
            Btn_submit.Enabled = true;
        }

        private void State_CheckedChanged(object sender, EventArgs e)
        {
            State.Text = State.Checked ? "启用" : "不启用";
        }
    }
}
