namespace _05_OOP._08WinForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.csm_1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.csm_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 170);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 90);
            this.button1.TabIndex = 0;
            this.button1.Text = "測試按鈕";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(618, 170);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(258, 90);
            this.button2.TabIndex = 1;
            this.button2.Text = "測試按鈕2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(353, 422);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(277, 102);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1613, 848);
            this.ContextMenuStrip = this.csm_1;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "窗體標題";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.csm_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// 所增加的控制項。(成員變量)
        /// The button1 click event handler.
        /// </summary>
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip csm_1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打開ToolStripMenuItem;
        private System.Windows.Forms.Button button3;
    }
}