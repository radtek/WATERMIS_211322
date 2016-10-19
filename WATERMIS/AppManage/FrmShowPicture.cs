using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AppManage
{
    public partial class FrmShowPicture : Form
    {
        public object ImageFile = "";
        public FrmShowPicture()
        {
            InitializeComponent();
        }
        private Image img = null;
        private void FrmShowPicture_Load(object sender, EventArgs e)
        {

            byte[] imagedata = (byte[])(ImageFile);
            MemoryStream myStream = new MemoryStream();
            foreach (byte a in imagedata)
            {
                myStream.WriteByte(a);
            }
            Image myImage = Image.FromStream(myStream);
            //myStream.Close();

            img = myImage;
          
            this.Width = img.Width;
            this.Height = img.Height;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmShowPicture_Shown(object sender, EventArgs e)
        {
            this.BackgroundImage = img;
        }
    }
}
