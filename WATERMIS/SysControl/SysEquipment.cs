using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SysControl
{
    public partial class SysEquipment : UserControl
    {
        public SysEquipment()
        {
            InitializeComponent();
        }

       

        private int _MEID;

        [Browsable(true)]
        [Category("ID")]
        [Description("MEID")]
        [DefaultValue("0")]
        public int MEID
        {
            get { return _MEID; }
            set { _MEID = value; }
        }

        private string _MECode = string.Empty;

        [Browsable(true)]
        [Category("ID")]
        [Description("设备序列号")]
        [DefaultValue("")]
        public string MECode
        {
            get { return _MECode; }
            set { _MECode = value; }
        }

        private string _UserName = string.Empty;

        [Browsable(true)]
        [Category("文本")]
        [Description("显示名字")]
        [DefaultValue("")]
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _LoginID = string.Empty;

        [Browsable(true)]
        [Category("文本")]
        [Description("用户ID")]
        [DefaultValue("")]
        public string LoginID
        {
            get { return _LoginID; }
            set { _LoginID = value; }
        }

        private string _SelectedID = string.Empty;

        [Browsable(true)]
        [Category("文本")]
        [Description("选中用户")]
        [DefaultValue("")]
        public string SelectedID
        {
            get { return _SelectedID; }
            set { _SelectedID = value; }
        }
        /// <summary>
        /// ValueMember--字段0
        /// DisplayMember--字段1
        /// </summary>
        private DataTable _UserList;

        [Browsable(true)]
        [Category("文本")]
        [Description("选择用户")]
        [DefaultValue("")]
        public DataTable UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler SaveEvent;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler DelEvent;

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("编辑"))
            {
                button1.Text = "确定";
                button2.Text = "取消";
                CB_User.Visible = true;
                LB_UserName.Visible = false;
            }
            else
            {
                button1.Text = "编辑";
                button2.Text = "删除";
                CB_User.Visible = false;
                LB_UserName.Visible = true;

                if (SaveEvent != null)
                    SaveEvent(this, e);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Equals("取消"))
            {
                button1.Text = "编辑";
                button2.Text = "删除";
                CB_User.Visible = false;
                LB_UserName.Visible = true;
            }
            else
            {
                if (DelEvent != null)
                    DelEvent(this, e);
            }
        }

        private void SysEquipment_Load(object sender, EventArgs e)
        {
            this.LB_MECode.Text = _MECode;
            this.LB_UserName.Text = _UserName;

            if (_UserList != null)
            {
                if (_UserList.Rows.Count > 0)
                {
                    CB_User.Items.Clear();
                    CB_User.DataSource = _UserList;
                    CB_User.DisplayMember = _UserList.Columns[1].ToString();
                    CB_User.ValueMember = _UserList.Columns[0].ToString();
                }
            }
        }

        private void CB_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = CB_User.SelectedValue.ToString().Trim();
        }


    }
}
