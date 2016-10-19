using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Common_UserControls
{
    public partial class UC_FlowModule : UserControl
    {
        public UC_FlowModule()
        {
            InitializeComponent();
            SetStyle(
                  ControlStyles.OptimizedDoubleBuffer
                  | ControlStyles.ResizeRedraw
                  | ControlStyles.Selectable
                  | ControlStyles.AllPaintingInWmPaint
                  | ControlStyles.UserPaint
                  | ControlStyles.SupportsTransparentBackColor,
                  true);
        }

        private void UC_FlowModule_Load(object sender, EventArgs e)
        {
            
        }

        public event EventHandler FlowModuleClick;

        private string _id = System.Guid.NewGuid().ToString();

        [Browsable(true)]
        [Category("ID")]
        [Description("ID")]
        [DefaultValue("0")]//默认值  
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _TaskId = "";
        [Browsable(true)]
        [Category("文本")]
        [Description("任务标记")]
        [DefaultValue("")]//默认值  
        public string TaskId
        {
            get { return _TaskId; }
            set { _TaskId = value; }
        }

        private int _PointSort = 0;
        [Browsable(true)]
        [Category("文本")]
        [Description("任务节点")]
        [DefaultValue("")]//默认值  
        public int PointSort
        {
            get { return _PointSort; }
            set { _PointSort = value; }
        }

        private Color sBackColor = Color.Green;

        [Browsable(true)]
        [Category("颜色")]
        [Description("背景颜色")]
        [DefaultValue("Teal")]//默认值  
        public Color SBackColor
        {
            get { return sBackColor; }
            set { sBackColor = value;
            LB_Point.BackColor = value;
            LB_PointGo.BackColor = value;
            }
        }

        private string _sLabelText = "未审批";//初始值  
        /// <summary>  
        /// Browsable表示该属性是否显示在设计器中,TRUE为显示  
        /// </summary>  
        /// Description表示对属性的描述信息  
        /// Category表示该属性在属性设计器中的分类  
        [Browsable(true)]
        [Category("文本")]
        [Description("审批人")]
        [DefaultValue("未审批")]//默认值  
        public string SLabelText
        {
            get { return _sLabelText; }
            set
            {
                _sLabelText = value;
                LB_Name.Text = value;
            }
        }

        private string _sLabelDate = "2016-07-01";
        [Browsable(true)]
        [Category("文本")]
        [Description("审校日期")]
        [DefaultValue("1900-01-01")]//默认值  
        public string SLabelDescription
        {
            get { return _sLabelDate; }
            set { _sLabelDate = value; LB_Date.Text = value; }
        }

        private string _sLablePoint = "";
        [Browsable(true)]
        [Category("文本")]
        [Description("审核环节")]
        [DefaultValue("")]//默认值  
        public string SLablePoint
        {
            get { return _sLablePoint; }
            set { _sLablePoint = value; LB_Point.Text = value; }
        }

        private void LB_Point_Click(object sender, EventArgs e)
        {
            if (FlowModuleClick != null)
            {
                FlowModuleClick(this, e);
            }
        }


    }
}
