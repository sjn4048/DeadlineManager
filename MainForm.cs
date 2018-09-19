// DoListInWinForm.MainForm
using DoListInWinForm;
using DoListInWinForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// ReSharper disable RedundantBaseQualifier
// ReSharper disable ArrangeThisQualifier
namespace DoListInWinForm
{
    public class MainForm : Form
    {
        private readonly Font _nameFont = new Font("微软雅黑", 12f);

        private bool _showUnfinished = true;

        private readonly Timer _refreshTimer = new Timer
        {
            Interval = 1800000
        };

        private IContainer components = null;

        private PictureBox pictureBox1;

        private Panel homeworkPanel;

        private PictureBox pictureBox2;

        private PictureBox pictureBox4;

        private PictureBox pictureBox5;

        private PictureBox ShiftPictureBox;

        private Label ddlTogoLabel;

        private Panel eventsPanel;

        private Panel papersPanel;

        private Label label1;

        private Label label2;

        private Label label3;

        public MainForm()
        {
            this.InitializeComponent();
            this._refreshTimer.Start();
            this._refreshTimer.Tick += delegate { this.DisplayAll(); };
            DataReader dataReader = new DataReader();
            dataReader.ReadAll();
            this.DisplayAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void DisplayAll()
        {
            List<TodoData> list = (from x in TodoData.DoList
                where x.IsFinished == !this._showUnfinished
                where x.ThingType == TodoData.Type.Homework || x.ThingType == TodoData.Type.Preview
                orderby x.DeadLine
                select x).ToList();
            List<TodoData> list2 = (from x in TodoData.DoList
                where x.IsFinished == !this._showUnfinished
                where x.ThingType == TodoData.Type.Paper || x.ThingType == TodoData.Type.Exam ||
                      x.ThingType == TodoData.Type.Project
                orderby x.DeadLine
                select x).ToList();
            List<TodoData> list3 = (from x in TodoData.DoList
                where x.IsFinished == !this._showUnfinished
                where x.ThingType == TodoData.Type.Event || x.ThingType == TodoData.Type.Others
                orderby x.DeadLine
                select x).ToList();
            this.DisplayInPanel(this.homeworkPanel, list);
            this.DisplayInPanel(this.papersPanel, list2);
            this.DisplayInPanel(this.eventsPanel, list3);
        }

        public void DisplayInPanel(Panel displayPanel, List<TodoData> list = null)
        {
            if (list == null)
            {
                list = (from x in TodoData.DoList
                    where !x.IsFinished
                    orderby x.DeadLine
                    select x).ToList();
            }

            List<TodoData> list2 = (from x in TodoData.DoList
                where !x.IsFinished
                select x).ToList();
            this.ddlTogoLabel.Text = string.Format("您当前有{0}个任务，三天内有{1}个，一天内有{2}个", list2.Count,
                list2.Count((TodoData x) => x.DeadLine - DateTime.Now < new TimeSpan(3, 0, 0, 0)),
                list2.Count((TodoData x) => x.DeadLine - DateTime.Now < new TimeSpan(1, 0, 0, 0)));
            displayPanel.Controls.Clear();
            if (list.Count == 0)
            {
                Label label = new Label
                {
                    Text = "暂无任务",
                    Font = new Font("华文中宋", 14f),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true
                };
                label.Location = new Point((displayPanel.Width - label.Width) / 2,
                    displayPanel.Height / 2 - label.Size.Height);
                displayPanel.Controls.Add(label);
            }
            else
            {
                int num = 0;
                int num2 = 40;
                foreach (TodoData item in list)
                {
                    Label label2 = new Label
                    {
                        Location = new Point(0, num2 * num),
                        Text = item.Name,
                        AutoSize = true,
                        Font = this._nameFont
                    };
                    displayPanel.Controls.Add(label2);
                    CheckBox finishCheckBox = new CheckBox
                    {
                        Location = new Point(280, 5 + num2 * num),
                        Checked = item.IsFinished,
                        Text = string.Empty,
                        AutoSize = true
                    };
                    finishCheckBox.CheckedChanged += delegate
                    {
                        if (item.IsRepeat)
                        {
                            MessageBox.Show(string.Format("恭喜你完成了本周的{0}~继续加油~", item.Name), "完成任务");
                            item.AddDeadLine(item.RepeatPeriod);
                        }
                        else
                        {
                            if (finishCheckBox.Checked)
                            {
                                MessageBox.Show(string.Format("恭喜你完成了{0}~继续加油~", item.Name), "完成任务");
                            }

                            item.SetFinishStatus(finishCheckBox.Checked);
                        }

                        this.DisplayInPanel(displayPanel, (from x in list
                            where x.IsFinished == !this._showUnfinished
                            orderby x.DeadLine
                            select x).ToList());
                    };
                    displayPanel.Controls.Add(finishCheckBox);
                    TimeSpan timeSpan = item.DeadLine - DateTime.Now;
                    Label label3 = new Label
                    {
                        Location = new Point(180, num2 * num),
                        AutoSize = true,
                        Font = this._nameFont
                    };
                    if (timeSpan.Days < 3)
                    {
                        label3.ForeColor = Color.Red;
                    }
                    else if (timeSpan.Days < 7)
                    {
                        label3.ForeColor = Color.Blue;
                    }
                    else if (timeSpan.Days < 28)
                    {
                        label3.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        label3.ForeColor = Color.Lime;
                    }

                    displayPanel.Controls.Add(label3);
                    ControlBindingsCollection dataBindings = label3.DataBindings;
                    TodoData dataSource = item;
                    TimeSpan timeSpan2 = item.DeadLine - DateTime.Now;
                    object arg2 = timeSpan2.Days;
                    timeSpan2 = item.DeadLine - DateTime.Now;
                    dataBindings.Add(new Binding("Text", dataSource, "DeadLine", true,
                        DataSourceUpdateMode.OnPropertyChanged, null,
                        string.Format("{0}天 {1}时", arg2, timeSpan2.Hours)));
                    Label label4 = new Label
                    {
                        Location = new Point(350, num2 * num),
                        Text = "删除",
                        AutoSize = true,
                        Font = new Font("微软雅黑", 10f, FontStyle.Underline)
                    };
                    label4.Click += delegate
                    {
                        if (MessageBox.Show("是否确定删除本任务？（本操作不可逆）", "删除任务", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            TodoData.DoList.Remove(item);
                            list.Remove(item);
                            this.DisplayInPanel(displayPanel, list);
                        }
                    };
                    label4.Cursor = Cursors.Hand;
                    displayPanel.Controls.Add(label4);
                    Label label5 = new Label
                    {
                        Location = new Point(310, num2 * num),
                        Text = "修改",
                        AutoSize = true,
                        Font = new Font("微软雅黑", 10f, FontStyle.Underline)
                    };
                    label5.Click += delegate
                    {
                        AddNewForm addNewForm = new AddNewForm(item, list);
                        addNewForm.ShowDialog();
                        if (addNewForm.DialogResult == DialogResult.Cancel)
                        {
                            list = (from x in list
                                orderby x.DeadLine
                                select x).ToList();
                            this.DisplayInPanel(displayPanel, list);
                        }
                    };
                    label5.Cursor = Cursors.Hand;
                    displayPanel.Controls.Add(label5);
                    if (item.IsFinished)
                    {
                        Label label6 = label2;
                        Label label7 = label3;
                        Color color2 = label6.ForeColor = (label7.ForeColor = Color.DarkGray);
                    }

                    num++;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddNewForm addNewForm = new AddNewForm();
            addNewForm.ShowDialog();
            DataWriter dataWriter = new DataWriter();
            dataWriter.WriteIntoCsv(TodoData.DoList);
            this.DisplayAll();
        }

        private void Form_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataWriter dataWriter = new DataWriter();
            dataWriter.WriteIntoCsv(TodoData.DoList);
        }

        private void RefreshButton_click(object sender, EventArgs e)
        {
            this.DisplayAll();
        }

        private void FinishItems_click(object sender, EventArgs e)
        {
            this._showUnfinished = !this._showUnfinished;
            this.ShiftPictureBox.Image = (this._showUnfinished ? Resources.finished : Resources.bell);
            this.DisplayAll();
        }

        private void AboutButton_click(object sender, EventArgs e)
        {
            CalendarForm calendarForm = new CalendarForm();
            calendarForm.StartPosition = FormStartPosition.CenterScreen;
            calendarForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void worksPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void SettingButton_click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.StartPosition = FormStartPosition.CenterScreen;
            settingForm.Show();
        }

        private void ddlTogoLabel_Click(object sender, EventArgs e)
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
            this.homeworkPanel = new Panel();
            this.ddlTogoLabel = new Label();
            this.eventsPanel = new Panel();
            this.papersPanel = new Panel();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.pictureBox5 = new PictureBox();
            this.ShiftPictureBox = new PictureBox();
            this.pictureBox4 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.pictureBox1 = new PictureBox();
            ((ISupportInitialize) this.pictureBox5).BeginInit();
            ((ISupportInitialize) this.ShiftPictureBox).BeginInit();
            ((ISupportInitialize) this.pictureBox4).BeginInit();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.homeworkPanel.AutoScroll = true;
            this.homeworkPanel.AutoSize = true;
            this.homeworkPanel.Location = new Point(17, 90);
            this.homeworkPanel.Name = "homeworkPanel";
            this.homeworkPanel.Size = new Size(420, 206);
            this.homeworkPanel.TabIndex = 1;
            this.ddlTogoLabel.AutoSize = true;
            this.ddlTogoLabel.Font = new Font("微软雅黑", 10.8f, FontStyle.Underline, GraphicsUnit.Point, 134);
            this.ddlTogoLabel.ForeColor = Color.Red;
            this.ddlTogoLabel.Location = new Point(12, 9);
            this.ddlTogoLabel.Name = "ddlTogoLabel";
            this.ddlTogoLabel.Size = new Size(88, 25);
            this.ddlTogoLabel.TabIndex = 3;
            this.ddlTogoLabel.Text = "温馨提示";
            this.ddlTogoLabel.Click += this.ddlTogoLabel_Click;
            this.eventsPanel.AutoScroll = true;
            this.eventsPanel.AutoSize = true;
            this.eventsPanel.Location = new Point(15, 600);
            this.eventsPanel.Name = "eventsPanel";
            this.eventsPanel.Size = new Size(420, 200);
            this.eventsPanel.TabIndex = 1;
            this.eventsPanel.Paint += this.worksPanel_Paint;
            this.papersPanel.AutoScroll = true;
            this.papersPanel.AutoSize = true;
            this.papersPanel.Location = new Point(17, 350);
            this.papersPanel.Name = "papersPanel";
            this.papersPanel.Size = new Size(420, 194);
            this.papersPanel.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("微软雅黑", 10.8f, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.label1.ForeColor = Color.FromArgb(0, 0, 192);
            this.label1.Location = new Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new Size(50, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "作业";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("微软雅黑", 10.8f, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.label2.ForeColor = Color.FromArgb(0, 0, 192);
            this.label2.Location = new Point(15, 310);
            this.label2.Name = "label2";
            this.label2.Size = new Size(50, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "论文";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("微软雅黑", 10.8f, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.label3.ForeColor = Color.FromArgb(0, 0, 192);
            this.label3.Location = new Point(15, 560);
            this.label3.Name = "label3";
            this.label3.Size = new Size(50, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "日程";
            this.label3.Click += this.label3_Click;
            this.pictureBox5.Cursor = Cursors.Hand;
            this.pictureBox5.Image = Resources.setting;
            this.pictureBox5.Location = new Point(198, 816);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new Size(55, 55);
            this.pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += this.SettingButton_click;
            this.ShiftPictureBox.Cursor = Cursors.Hand;
            this.ShiftPictureBox.Image = Resources.finished;
            this.ShiftPictureBox.Location = new Point(22, 815);
            this.ShiftPictureBox.Name = "ShiftPictureBox";
            this.ShiftPictureBox.Size = new Size(57, 60);
            this.ShiftPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.ShiftPictureBox.TabIndex = 0;
            this.ShiftPictureBox.TabStop = false;
            this.ShiftPictureBox.Click += this.FinishItems_click;
            this.pictureBox4.Cursor = Cursors.Hand;
            this.pictureBox4.Image = Resources.information;
            this.pictureBox4.Location = new Point(110, 814);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Size(55, 60);
            this.pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += this.AboutButton_click;
            this.pictureBox2.Cursor = Cursors.Hand;
            this.pictureBox2.Image = Resources.refresh;
            this.pictureBox2.Location = new Point(280, 811);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(65, 65);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += this.RefreshButton_click;
            this.pictureBox1.Cursor = Cursors.Hand;
            this.pictureBox1.Image = Resources.add_2;
            this.pictureBox1.Location = new Point(372, 816);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(50, 55);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += this.pictureBox1_Click;
            base.AutoScaleDimensions = new SizeF(120f, 120f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.BackColor = Color.MintCream;
            base.ClientSize = new Size(442, 892);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.ddlTogoLabel);
            base.Controls.Add(this.papersPanel);
            base.Controls.Add(this.eventsPanel);
            base.Controls.Add(this.homeworkPanel);
            base.Controls.Add(this.pictureBox5);
            base.Controls.Add(this.ShiftPictureBox);
            base.Controls.Add(this.pictureBox4);
            base.Controls.Add(this.pictureBox2);
            base.Controls.Add(this.pictureBox1);
            base.MaximizeBox = false;
            base.Name = "MainForm";
            this.Text = "DoList";
            base.FormClosing += this.Form_MainForm_FormClosing;
            base.Load += this.Form1_Load;
            ((ISupportInitialize) this.pictureBox5).EndInit();
            ((ISupportInitialize) this.ShiftPictureBox).EndInit();
            ((ISupportInitialize) this.pictureBox4).EndInit();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}