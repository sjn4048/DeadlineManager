﻿namespace DoListInWinForm
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
            this.homeworkPanel = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.ShiftPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ddlTogoLabel = new System.Windows.Forms.Label();
            this.worksPanel = new System.Windows.Forms.Panel();
            this.papersPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // homeworkPanel
            // 
            this.homeworkPanel.AutoScroll = true;
            this.homeworkPanel.Location = new System.Drawing.Point(17, 90);
            this.homeworkPanel.Name = "homeworkPanel";
            this.homeworkPanel.Size = new System.Drawing.Size(422, 226);
            this.homeworkPanel.TabIndex = 1;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::DoListInWinForm.Properties.Resources.setting;
            this.pictureBox5.Location = new System.Drawing.Point(193, 908);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(65, 59);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ShiftPictureBox
            // 
            this.ShiftPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShiftPictureBox.Image = global::DoListInWinForm.Properties.Resources.finished;
            this.ShiftPictureBox.Location = new System.Drawing.Point(20, 908);
            this.ShiftPictureBox.Name = "ShiftPictureBox";
            this.ShiftPictureBox.Size = new System.Drawing.Size(59, 60);
            this.ShiftPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShiftPictureBox.TabIndex = 0;
            this.ShiftPictureBox.TabStop = false;
            this.ShiftPictureBox.Click += new System.EventHandler(this.FinishItems_click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::DoListInWinForm.Properties.Resources.information;
            this.pictureBox4.Location = new System.Drawing.Point(107, 908);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(59, 60);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.AboutButton_click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::DoListInWinForm.Properties.Resources.refresh;
            this.pictureBox2.Location = new System.Drawing.Point(281, 903);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.RefreshButton_click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::DoListInWinForm.Properties.Resources.add_2;
            this.pictureBox1.Location = new System.Drawing.Point(372, 908);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ddlTogoLabel
            // 
            this.ddlTogoLabel.AutoSize = true;
            this.ddlTogoLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddlTogoLabel.ForeColor = System.Drawing.Color.Red;
            this.ddlTogoLabel.Location = new System.Drawing.Point(12, 9);
            this.ddlTogoLabel.Name = "ddlTogoLabel";
            this.ddlTogoLabel.Size = new System.Drawing.Size(67, 25);
            this.ddlTogoLabel.TabIndex = 3;
            this.ddlTogoLabel.Text = "label1";
            // 
            // worksPanel
            // 
            this.worksPanel.AutoScroll = true;
            this.worksPanel.Location = new System.Drawing.Point(17, 680);
            this.worksPanel.Name = "worksPanel";
            this.worksPanel.Size = new System.Drawing.Size(420, 200);
            this.worksPanel.TabIndex = 1;
            this.worksPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.worksPanel_Paint);
            // 
            // papersPanel
            // 
            this.papersPanel.AutoScroll = true;
            this.papersPanel.Location = new System.Drawing.Point(17, 400);
            this.papersPanel.Name = "papersPanel";
            this.papersPanel.Size = new System.Drawing.Size(420, 194);
            this.papersPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(17, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "作业";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(17, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "论文";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(17, 641);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "工作";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(444, 992);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlTogoLabel);
            this.Controls.Add(this.papersPanel);
            this.Controls.Add(this.worksPanel);
            this.Controls.Add(this.homeworkPanel);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.ShiftPictureBox);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_MainForm";
            this.Text = "DoList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel homeworkPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox ShiftPictureBox;
        private System.Windows.Forms.Label ddlTogoLabel;
        private System.Windows.Forms.Panel worksPanel;
        private System.Windows.Forms.Panel papersPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

