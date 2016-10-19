using System;
using System.Collections.Generic;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace BASEFUNCTION
{
    public class DockContentEx : DockContent
    {
        //在标签上点击右键显示关闭菜单
        public DockContentEx()
        {
            System.Windows.Forms.ContextMenuStrip cms = new System.Windows.Forms.ContextMenuStrip();
            // 
            // tsmiClose
            // 
            System.Windows.Forms.ToolStripMenuItem tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            tsmiClose.Name = "cms";
            tsmiClose.Size = new System.Drawing.Size(98, 22);
            tsmiClose.Text = "关闭";
            tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // tsmiALLClose
            // 
            System.Windows.Forms.ToolStripMenuItem tsmiALLClose = new System.Windows.Forms.ToolStripMenuItem();
            tsmiALLClose.Name = "cms";
            tsmiALLClose.Size = new System.Drawing.Size(98, 22);
            tsmiALLClose.Text = "全部关闭";
            tsmiALLClose.Click += new System.EventHandler(this.tsmiALLClose_Click);
            // 
            // tsmiApartFromClose
            // 
            System.Windows.Forms.ToolStripMenuItem tsmiApartFromClose = new System.Windows.Forms.ToolStripMenuItem();
            tsmiApartFromClose.Name = "cms";
            tsmiApartFromClose.Size = new System.Drawing.Size(98, 22);
            tsmiApartFromClose.Text = "除此之外全部关闭";
            tsmiApartFromClose.Click += new System.EventHandler(this.tsmiApartFromClose_Click);
            // 
            // tsmiClose
            // 
            cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tsmiClose,tsmiApartFromClose,tsmiALLClose});
            //cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //tsmiClose});
            cms.Name = "tsmiClose";
            cms.Size = new System.Drawing.Size(99, 26);
            this.TabPageContextMenuStrip = cms;
        }
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmiALLClose_Click(object sender, EventArgs e)
        {
            DockContentCollection contents = DockPanel.Contents;
            int num = 0;
            while (num < contents.Count)
            {
                if (contents[num].DockHandler.DockState == DockState.Document)
                {
                    contents[num].DockHandler.Close();
                }
                else
                {
                    num++;
                }
            }
        }
        private void tsmiApartFromClose_Click(object sender, EventArgs e)
        {
            DockContentCollection contents = DockPanel.Contents;
            int num = 0;
            while (num < contents.Count)
            {
                if (contents[num].DockHandler.DockState == DockState.Document && DockPanel.ActiveContent != contents[num])
                {
                    contents[num].DockHandler.Close();
                }
                else
                {
                    num++;
                }
            }
        }
    }
}
