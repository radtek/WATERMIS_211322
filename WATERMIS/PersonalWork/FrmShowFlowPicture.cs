using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PersonalWork
{
    public partial class FrmShowFlowPicture : Form
    {

        public string PictureName = "";

        public FrmShowFlowPicture()
        {
            InitializeComponent();
        }

        private Image img = null;
        private void FrmShowFlowPicture_Load(object sender, EventArgs e)
        {
            img = Image.FromFile(PictureName);
            this.Width = img.Width;
            this.Height = img.Height;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmShowFlowPicture_Shown(object sender, EventArgs e)
        {

            this.BackgroundImage = img;

        }
    }
}
