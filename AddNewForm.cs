// DoListInWinForm.AddNewForm
using DoListInWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
            this.button1 = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.nameLabel = new TextBox();
            this.typeComboBox = new ComboBox();
            this.ddlDateTimePicker = new DateTimePicker();
            this.importanceComboBox = new ComboBox();
            this.repeatComboBox = new ComboBox();
            base.SuspendLayout();
            this.button1.Location = new Point(137, 275);
            this.button1.Name = "button1";
            this.button1.Size = new Size(99, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += this.addButton_click;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("幼圆", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label1.Location = new Point(44, 49);
            this.label1.Name = "label1";
            this.label1.Size = new Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "任务名";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("幼圆", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label2.Location = new Point(44, 89);
            this.label2.Name = "label2";
            this.label2.Size = new Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "类型";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("幼圆", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label4.Location = new Point(44, 209);
            this.label4.Name = "label4";
            this.label4.Size = new Size(49, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "重复";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("幼圆", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label5.Location = new Point(44, 169);
            this.label5.Name = "label5";
            this.label5.Size = new Size(89, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "重要程度";
            this.label6.AutoSize = true;
            this.label6.Font = new Font("幼圆", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label6.Location = new Point(44, 129);
            this.label6.Name = "label6";
            this.label6.Size = new Size(89, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "截止日期";
            this.nameLabel.Location = new Point(170, 44);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new Size(169, 25);
            this.nameLabel.TabIndex = 1;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[7]
            {
                "考试",
                "作业",
                "项目",
                "论文",
                "事件",
                "预习",
                "其他"
            });
            this.typeComboBox.Location = new Point(170, 89);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new Size(169, 23);
            this.typeComboBox.TabIndex = 2;
            this.ddlDateTimePicker.Location = new Point(170, 129);
            this.ddlDateTimePicker.Name = "ddlDateTimePicker";
            this.ddlDateTimePicker.Size = new Size(169, 25);
            this.ddlDateTimePicker.TabIndex = 3;
            this.importanceComboBox.FormattingEnabled = true;
            this.importanceComboBox.Items.AddRange(new object[3]
            {
                "必做",
                "选做",
                "可忽略"
            });
            this.importanceComboBox.Location = new Point(170, 169);
            this.importanceComboBox.Name = "importanceComboBox";
            this.importanceComboBox.Size = new Size(169, 23);
            this.importanceComboBox.TabIndex = 4;
            this.repeatComboBox.FormattingEnabled = true;
            this.repeatComboBox.Items.AddRange(new object[3]
            {
                "无",
                "每周",
                "每年"
            });
            this.repeatComboBox.Location = new Point(170, 207);
            this.repeatComboBox.Name = "repeatComboBox";
            this.repeatComboBox.Size = new Size(169, 23);
            this.repeatComboBox.TabIndex = 5;
            base.AutoScaleDimensions = new SizeF(8f, 15f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(385, 360);
            base.Controls.Add(this.ddlDateTimePicker);
            base.Controls.Add(this.repeatComboBox);
            base.Controls.Add(this.importanceComboBox);
            base.Controls.Add(this.typeComboBox);
            base.Controls.Add(this.nameLabel);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.button1);
            base.Name = "AddNewForm";
            this.Text = "新建事件";
            base.FormClosed += this.Form_AddNewThing_FormClosed;
            base.Load += this.Form_AddNewThing_Load;
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}