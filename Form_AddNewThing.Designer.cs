namespace DoListInWinForm
{
    partial class Form_AddNewThing
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.TextBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.ddlDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.importanceComboBox = new System.Windows.Forms.ComboBox();
            this.repeatComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addButton_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(44, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "任务名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(44, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(44, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "重复";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(44, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "重要程度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(44, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "截止日期";
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(170, 44);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(169, 25);
            this.nameLabel.TabIndex = 1;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "考试",
            "作业",
            "论文",
            "预习",
            "会议/培训",
            "工作",
            "兴趣爱好",
            "其他"});
            this.typeComboBox.Location = new System.Drawing.Point(170, 89);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(169, 23);
            this.typeComboBox.TabIndex = 2;
            // 
            // ddlDateTimePicker
            // 
            this.ddlDateTimePicker.Location = new System.Drawing.Point(170, 129);
            this.ddlDateTimePicker.Name = "ddlDateTimePicker";
            this.ddlDateTimePicker.Size = new System.Drawing.Size(169, 25);
            this.ddlDateTimePicker.TabIndex = 3;
            // 
            // importanceComboBox
            // 
            this.importanceComboBox.FormattingEnabled = true;
            this.importanceComboBox.Items.AddRange(new object[] {
            "必做",
            "选做",
            "可忽略"});
            this.importanceComboBox.Location = new System.Drawing.Point(170, 169);
            this.importanceComboBox.Name = "importanceComboBox";
            this.importanceComboBox.Size = new System.Drawing.Size(169, 23);
            this.importanceComboBox.TabIndex = 4;
            // 
            // repeatComboBox
            // 
            this.repeatComboBox.FormattingEnabled = true;
            this.repeatComboBox.Items.AddRange(new object[] {
            "无",
            "每周",
            "每年"});
            this.repeatComboBox.Location = new System.Drawing.Point(170, 207);
            this.repeatComboBox.Name = "repeatComboBox";
            this.repeatComboBox.Size = new System.Drawing.Size(169, 23);
            this.repeatComboBox.TabIndex = 5;
            // 
            // Form_AddNewThing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 360);
            this.Controls.Add(this.ddlDateTimePicker);
            this.Controls.Add(this.repeatComboBox);
            this.Controls.Add(this.importanceComboBox);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form_AddNewThing";
            this.Text = "新建事件";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_AddNewThing_FormClosed);
            this.Load += new System.EventHandler(this.Form_AddNewThing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nameLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.DateTimePicker ddlDateTimePicker;
        private System.Windows.Forms.ComboBox importanceComboBox;
        private System.Windows.Forms.ComboBox repeatComboBox;
    }
}