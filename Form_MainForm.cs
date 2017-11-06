﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoListInWinForm
{
    public partial class Form_MainForm : Form
    {
        Font nameFont = new Font("微软雅黑", 12);
        bool ShowUnfinished = true;

        public Form_MainForm()
        {
            InitializeComponent();
            DataReader dataReader = new DataReader();
            dataReader.ReadAll();
            DisplayAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddNewThing(object sender, EventArgs e)
        {

        }

        public void DisplayAll()
        {
            var homeworkList = TodoData.doList.Where(x => x.IsFinished == !ShowUnfinished).Where(x => x.ThingType == TodoData.Type.Homework || x.ThingType == TodoData.Type.Preview).OrderBy(x => x.DeadLine).ToList();
            var papersList = TodoData.doList.Where(x => x.IsFinished == !ShowUnfinished).Where(x => x.ThingType == TodoData.Type.Paper || x.ThingType == TodoData.Type.Exam).OrderBy(x => x.DeadLine).ToList();
            var interestList = TodoData.doList.Where(x => x.IsFinished == !ShowUnfinished).Where(x => x.ThingType == TodoData.Type.Interest).OrderBy(x => x.DeadLine).ToList();
            var worksList = TodoData.doList.Where(x => x.IsFinished == !ShowUnfinished).Where(x => x.ThingType == TodoData.Type.Work || x.ThingType == TodoData.Type.Meeting || x.ThingType == TodoData.Type.Others).OrderBy(x => x.DeadLine).ToList();
            Display(ddlPanel, homeworkList);
            Display(papersPanel, papersList);
            Display(worksPanel, worksList);
        }

        public void Display(Panel displayPanel, List<TodoData> list = null)
        {
            if (list == null)
                list = TodoData.doList.Where(x => x.IsFinished == false).Where(x => x.ThingType != TodoData.Type.Interest).OrderBy(x => x.DeadLine).ToList();
            var allList = TodoData.doList.Where(x => x.IsFinished == false).Where(x => x.ThingType != TodoData.Type.Interest).ToList();
                ddlTogoLabel.Text = $"您当前有{allList.Count()}个任务，三天内有{allList.Where(x=>x.DeadLine - DateTime.Now < new TimeSpan(3,0,0,0)).Count()}个，一天内有{allList.Where(x => x.DeadLine - DateTime.Now < new TimeSpan(1, 0, 0, 0)).Count()}个";
            displayPanel.Controls.Clear();
            if (list.Count() == 0)
            {
                Label congratsLabel = new Label()
                {
                    Location = new Point(150, 120),
                    Text = "恭喜你，你已经完成了所有的锅！",
                    Font = new Font("微软雅黑", 16),
                    AutoSize = true
                };
                this.Controls.Add(congratsLabel);
            }
            else
            {
                int i = 0, step = 50;
                foreach (var todoData in list)
                {
                    var nameLabel = new Label()
                    {
                        Location = new Point(0, step * i),
                        Text = todoData.Name,
                        AutoSize = true,
                        Font = nameFont,
                    };
                    displayPanel.Controls.Add(nameLabel);

                    var finishCheckBox = new CheckBox()
                    {
                        Location = new Point(280, 5 + step * i),
                        Checked = todoData.IsFinished,
                        Text = string.Empty,
                        AutoSize = true
                    };
                    finishCheckBox.CheckedChanged += (s, arg) => //还是要改
                    {
                        if (todoData.IsRepeat)
                        {
                            todoData.AddDeadLine(todoData.RepeatPeriod);//
                            //这块写的还是不对，要改
                        }
                        else
                        {
                            if (finishCheckBox.Checked)
                                MessageBox.Show(caption: "完成任务", text: $"恭喜你完成了{todoData.Name}~继续加油~");
                            todoData.SetFinishStatus(finishCheckBox.Checked);
                        }
                        Display(displayPanel, list.Where(x => x.IsFinished == !ShowUnfinished).ToList()); //性能仍可以优化
                    };
                    displayPanel.Controls.Add(finishCheckBox);

                    var timeLeft = todoData.DeadLine - DateTime.Now;
                    var timeLeftLabel = new Label()
                    {
                        Location = new Point(180, step * i),
                        Text = $"{timeLeft.Days}天 {(timeLeft).Hours}时", 
                        AutoSize = true,
                        Font = nameFont,
                    };
                    {
                        if (timeLeft.Days < 3)
                            timeLeftLabel.ForeColor = Color.Red;
                        else if (timeLeft.Days < 7)
                            timeLeftLabel.ForeColor = Color.Blue;
                        else if (timeLeft.Days < 28)
                            timeLeftLabel.ForeColor = Color.DarkGreen;
                        else
                            timeLeftLabel.ForeColor = Color.Lime;
                        displayPanel.Controls.Add(timeLeftLabel);
                    }//赋值颜色

                    var deleteLabel = new Label()
                    {
                        Location = new Point(350, step * i),
                        Text = "删除",
                        AutoSize = true,
                        Font = new Font("微软雅黑", 10, FontStyle.Underline),
                        
                    };
                    deleteLabel.Click += (s, arg) => 
                    {
                        if (MessageBox.Show(caption: "删除任务", text: "是否确定删除本任务？（本操作不可逆）", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            TodoData.doList.Remove(todoData);
                            list.ToList().Remove(todoData);
                            Display(displayPanel, list);
                        }
                    };
                    deleteLabel.Cursor = Cursors.Hand;
                    displayPanel.Controls.Add(deleteLabel);

                    var modifyLabel = new Label()
                    {
                        Location = new Point(310, step * i),
                        Text = "修改",
                        AutoSize = true,
                        Font = new Font("微软雅黑", 10, FontStyle.Underline),

                    };
                    modifyLabel.Click += (s, arg) =>
                    {
                        var form = new Form_AddNewThing(todoData, list);
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.Cancel)
                            this.Display(displayPanel, list);
                    };
                    modifyLabel.Cursor = Cursors.Hand;
                    displayPanel.Controls.Add(modifyLabel);

                    if (todoData.IsFinished)
                        nameLabel.ForeColor = timeLeftLabel.ForeColor = Color.DarkGray;

                    i++;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) //仍可以优化
        {
            var form = new Form_AddNewThing();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                this.DisplayAll();
        }

        private void Form_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataWriter dataWriter = new DataWriter();
            dataWriter.WriteIntoCSV(TodoData.doList);
        }

        private void RefreshButton_click(object sender, EventArgs e)
        {
            DisplayAll();
        }

        private void FinishItems_click(object sender, EventArgs e)
        {
            ShowUnfinished = !ShowUnfinished;
            ShiftPictureBox.Image = ShowUnfinished ? Properties.Resources.finished : Properties.Resources.bell;
            DisplayAll();
        }

        private void AboutButton_click(object sender, EventArgs e)
        {
            new Form_AboutForm()
            {
                StartPosition = FormStartPosition.CenterScreen
            }.Show();
        }
    }
}