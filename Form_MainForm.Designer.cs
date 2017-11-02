namespace DoListInWinForm
{
    partial class Form_MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ddlPanel = new System.Windows.Forms.Panel();
            this.interestPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::DoListInWinForm.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point(413, 638);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ddlPanel
            // 
            this.ddlPanel.AutoScroll = true;
            this.ddlPanel.Location = new System.Drawing.Point(12, 12);
            this.ddlPanel.Name = "ddlPanel";
            this.ddlPanel.Size = new System.Drawing.Size(488, 608);
            this.ddlPanel.TabIndex = 1;
            // 
            // interestPanel
            // 
            this.interestPanel.Location = new System.Drawing.Point(12, 635);
            this.interestPanel.Name = "interestPanel";
            this.interestPanel.Size = new System.Drawing.Size(397, 97);
            this.interestPanel.TabIndex = 2;
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 744);
            this.Controls.Add(this.interestPanel);
            this.Controls.Add(this.ddlPanel);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MainForm";
            this.Text = "DoList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel ddlPanel;
        private System.Windows.Forms.Panel interestPanel;
    }
}

