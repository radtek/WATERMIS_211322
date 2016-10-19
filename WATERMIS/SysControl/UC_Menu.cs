using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.IO;
using System.Diagnostics;

namespace SysControl
{
    public partial class UC_Menu : UserControl
    {
        public UC_Menu()
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

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
                return parms;
            }
        }

        private int _id =0;

        [Browsable(true)]
        [Category("ID")]
        [Description("ID")]
        [DefaultValue("0")]//默认值  
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _sLabelText = "未知";//初始值  
        /// <summary>  
        /// Browsable表示该属性是否显示在设计器中,TRUE为显示  
        /// </summary>  
        /// Description表示对属性的描述信息  
        /// Category表示该属性在属性设计器中的分类  
        [Browsable(true)]
        [Category("文本")]
        [Description("标签名字")]
        [DefaultValue("未命名")]//默认值  
        public string SLabelText
        {
            get { return _sLabelText; }
            set
            {
                _sLabelText = value;
                sMetroTitle.Text = value;
                sMetroTitle.Left = (this.Width - sMetroTitle.Width) / 2;
            }
        }

        private string _AssemblyName;
        [Browsable(true)]
        [Category("文本")]
        [Description("目标运行程序类库")]
        [DefaultValue("")]//默认值  
        public string AssemblyName
        {
            get { return _AssemblyName; }
            set { _AssemblyName = value; }
        }

        private string sProcessName;
        [Browsable(true)]
        [Category("文本")]
        [Description("目标运行程序")]
        [DefaultValue("")]//默认值  
        public string SProcessName
        {
            get { return sProcessName; }
            set { sProcessName = value; }
        }

        private string _sHeadImage = "_15";

        [Browsable(true)]
        [Category("外观")]
        [Description("Metro图标")]
        public string SHeadImage
        {
            get { return _sHeadImage; }
            set { _sHeadImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler Button_Open_Click;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Button_Open_Click != null)
                Button_Open_Click(this, e);
        }

        private void UC_Menu_Load(object sender, EventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("SysControl.Properties.Resources", asm);
            //   String             str = rm.GetString("ApplicationName");            //添加到资源文件的字符串
            Image img = rm.GetObject(_sHeadImage) as Image;　　//添加到资源文件的图片
            //nopic_Default.png
            if (img == null)
            {
                sMetroPicture.Image = (Image)rm.GetObject("_15");
            }
            else
            {
                sMetroPicture.Image = (Image)rm.GetObject(_sHeadImage);
            }
        }
    }
}
