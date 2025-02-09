using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_OOP._08WinForm
{
    public partial class From1Extends:Form

    {
        private ContextMenuStrip csm_1;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 打開ToolStripMenuItem;
        private Button mybutton;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mybutton = new System.Windows.Forms.Button();
            this.csm_1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csm_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mybutton
            // 
            this.mybutton.Location = new System.Drawing.Point(244, 149);
            this.mybutton.Name = "mybutton";
            this.mybutton.Size = new System.Drawing.Size(212, 109);
            this.mybutton.TabIndex = 0;
            this.mybutton.Text = "按鈕";
            this.mybutton.UseVisualStyleBackColor = true;
            this.mybutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // csm_1
            // 
            this.csm_1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.csm_1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.打開ToolStripMenuItem});
            this.csm_1.Name = "csm_1";
            this.csm_1.Size = new System.Drawing.Size(147, 88);
            this.csm_1.Text = "csm_1";
            this.csm_1.Opening += new System.ComponentModel.CancelEventHandler(this.csm_1_Opening);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(146, 42);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打開ToolStripMenuItem
            // 
            this.打開ToolStripMenuItem.Name = "打開ToolStripMenuItem";
            this.打開ToolStripMenuItem.Size = new System.Drawing.Size(146, 42);
            this.打開ToolStripMenuItem.Text = "打開";
            // 
            // From1Extends
            // 
            this.ClientSize = new System.Drawing.Size(1612, 820);
            this.ContextMenuStrip = this.csm_1;
            this.Controls.Add(this.mybutton);
            this.Font = new System.Drawing.Font("新細明體", 15F);
            this.Name = "From1Extends";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.From1Extends_Load);
            this.csm_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void From1Extends_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void csm_1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
