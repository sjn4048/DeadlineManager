// DoListInWinForm.AddNewForm
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace DoListInWinForm
{
    public class AddNewForm : Form
    {
        private readonly bool isModifyMode = false;

        private readonly TodoData currentData;

        private readonly List<TodoData> currentList;

        private IContainer components = null;

        private Button button1;

        private Label label1;

        private Label label2;

        private Label label4;

        private Label label5;

        private Label label6;

        private TextBox nameLabel;

        private ComboBox typeComboBox;

        private DateTimePicker ddlDateTimePicker;

        private ComboBox importanceComboBox;

        private ComboBox repeatComboBox;

        public AddNewForm()
        {
            this.InitializeComponent();
            this.ddlDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.ddlDateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        public AddNewForm(TodoData todoData, List<TodoData> list = null)
        {
            this.InitializeComponent();
            this.ddlDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.ddlDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.isModifyMode = true;
            if (todoData == null)
            {
                throw new Exception("Null Reference.");
            }

            this.currentData = todoData;
            this.currentList = list;
            this.Text = "修改事件";
            this.nameLabel.Text = todoData.Name;
            this.typeComboBox.SelectedIndex = (int) todoData.ThingType;
            this.ddlDateTimePicker.Value = todoData.DeadLine;
            this.importanceComboBox.SelectedIndex = (int) todoData.ThingImportance;
            if (todoData.IsRepeat)
            {
                if (todoData.RepeatPeriod == new TimeSpan(7, 0, 0, 0))
                {
                    this.repeatComboBox.SelectedIndex = 1;
                }
                else if (todoData.RepeatPeriod == new TimeSpan(365, 0, 0, 0))
                {
                    this.repeatComboBox.SelectedIndex = 1;
                }
            }
            else
            {
                this.repeatComboBox.SelectedIndex = 0;
            }
        }

        private void addButton_click(object sender, EventArgs e)
        {
            bool isRepeat = true;
            TimeSpan repeatPeriod = default(TimeSpan);
            if (this.nameLabel.Text == string.Empty || this.typeComboBox.SelectedIndex == -1 ||
                this.importanceComboBox.SelectedIndex == -1 || this.repeatComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("不合法的输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                switch (this.repeatComboBox.SelectedIndex)
                {
                    case 0:
                        isRepeat = false;
                        break;
                    case 1:
                        repeatPeriod = new TimeSpan(7, 0, 0, 0);
                        break;
                    case 2:
                        repeatPeriod = new TimeSpan(365, 0, 0, 0);
                        break;
                }

                TodoData item = TodoData.CreateNewThing(this.nameLabel.Text, this.ddlDateTimePicker.Value,
                    (TodoData.Importance) this.importanceComboBox.SelectedIndex,
                    (TodoData.Type) this.typeComboBox.SelectedIndex, isRepeat, repeatPeriod, false);
                TodoData.DoList.Add(item);
                List<TodoData> list = this.currentList;
                if (list != null)
                {
                    list.Add(item);
                }

                if (this.isModifyMode)
                {
                    TodoData.DoList.Remove(this.currentData);
                    this.currentList.Remove(this.currentData);
                }

                base.Close();
            }
        }

        private void Form_AddNewThing_Load(object sender, EventArgs e)
        {
        }

        private void Form_AddNewThing_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

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
            this.button1.Location = new System.Drawing.Point(103, 220);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(33, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "任务名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(33, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(33, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "重复";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(33, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "重要程度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(33, 103);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "截止日期";
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(128, 35);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(128, 21);
            this.nameLabel.TabIndex = 1;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "考试",
            "作业",
            "项目",
            "论文",
            "事件",
            "预习",
            "其他"});
            this.typeComboBox.Location = new System.Drawing.Point(128, 71);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(128, 20);
            this.typeComboBox.TabIndex = 2;
            // 
            // ddlDateTimePicker
            // 
            this.ddlDateTimePicker.Location = new System.Drawing.Point(128, 103);
            this.ddlDateTimePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ddlDateTimePicker.Name = "ddlDateTimePicker";
            this.ddlDateTimePicker.Size = new System.Drawing.Size(128, 21);
            this.ddlDateTimePicker.TabIndex = 3;
            // 
            // importanceComboBox
            // 
            this.importanceComboBox.FormattingEnabled = true;
            this.importanceComboBox.Items.AddRange(new object[] {
            "必做",
            "选做",
            "可忽略"});
            this.importanceComboBox.Location = new System.Drawing.Point(128, 135);
            this.importanceComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.importanceComboBox.Name = "importanceComboBox";
            this.importanceComboBox.Size = new System.Drawing.Size(128, 20);
            this.importanceComboBox.TabIndex = 4;
            // 
            // repeatComboBox
            // 
            this.repeatComboBox.FormattingEnabled = true;
            this.repeatComboBox.Items.AddRange(new object[] {
            "无",
            "每周",
            "每年"});
            this.repeatComboBox.Location = new System.Drawing.Point(128, 166);
            this.repeatComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.repeatComboBox.Name = "repeatComboBox";
            this.repeatComboBox.Size = new System.Drawing.Size(128, 20);
            this.repeatComboBox.TabIndex = 5;
            // 
            // AddNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 288);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddNewForm";
            this.Text = "新建事件";
            this.Load += new System.EventHandler(this.AddNewForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AddNewForm_Load(object sender, EventArgs e)
        {

        }
    }
}