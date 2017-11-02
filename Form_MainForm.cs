using System;
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

        public Form_MainForm()
        {
            InitializeComponent();
            DataReader dataReader = new DataReader();
            dataReader.ReadAll();
            DisplayList(TodoData.doList);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddNewThing(object sender, EventArgs e)
        {

        }

        public void DisplayList(List<TodoData> list)
        {
            interestPanel.Controls.Clear();
            ddlPanel.Controls.Clear();
            if (list.Count == 0)
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
                foreach (var todoData in TodoData.doList.Where(x => x.ThingType != TodoData.Type.Interest).OrderBy(x => x.DeadLine).OrderBy(x => x.IsFinished))
                {
                    var nameLabel = new Label()
                    {
                        Location = new Point(20, 20 + step * i),
                        Text = todoData.Name,
                        AutoSize = true,
                        Font = nameFont,
                    };
                    ddlPanel.Controls.Add(nameLabel);
                    
                    ///下面为重要性标签，由于过于反人类，已被删去
                    //var importanceLabel = new Label()
                    //{
                    //    Location = new Point(270, 40 + step * i),
                    //    AutoSize = true,
                    //    Font = nameFont,
                    //};
                    ////给重要程度赋颜色和文本
                    //switch (todoData.ThingImportance)
                    //{
                    //    case TodoData.Importance.Compulsory:
                    //        importanceLabel.Text = "必做";
                    //        importanceLabel.ForeColor = Color.Red;
                    //        break;
                    //    case TodoData.Importance.Alternative:
                    //        importanceLabel.Text = "有空做做";
                    //        importanceLabel.ForeColor = Color.DarkBlue;
                    //        break;
                    //    case TodoData.Importance.NotImportant:
                    //        importanceLabel.Text = "可忽略";
                    //        importanceLabel.ForeColor = Color.DarkGreen;
                    //        break;
                    //} 
                    //ddlPanel.Controls.Add(importanceLabel);

                    var finishCheckBox = new CheckBox()
                    {
                        Location = new Point(330, 25 + step * i),
                        Checked = todoData.IsFinished,
                        Text = string.Empty,
                        AutoSize = true
                    };
                    finishCheckBox.CheckedChanged += (s, arg) => //还是要改
                    {
                        if (todoData.IsRepeat)
                        {
                            todoData.AddDeadLine(todoData.RepeatPeriod);
                            finishCheckBox.Checked = false;
                            return;
                            //这块写的还是不对，要改
                        }
                        else
                        {
                            if (finishCheckBox.Checked)
                                MessageBox.Show(caption: "完成任务", text: $"恭喜你完成了{todoData.Name}~继续加油~");
                            todoData.SetFinishStatus(finishCheckBox.Checked);
                        }
                        DisplayList(TodoData.doList);
                    };
                    ddlPanel.Controls.Add(finishCheckBox);

                    var timeLeft = todoData.DeadLine - DateTime.Now;
                    var timeLeftLabel = new Label()
                    {
                        Location = new Point(210, 20 + step * i),
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
                        ddlPanel.Controls.Add(timeLeftLabel);
                    }//赋值颜色

                    var deleteLabel = new Label()
                    {
                        Location = new Point(410, 20 + step * i),
                        Text = "删除",
                        AutoSize = true,
                        Font = new Font("微软雅黑", 10, FontStyle.Underline),
                        
                    };
                    deleteLabel.Click += (s, arg) => 
                    {
                        if (MessageBox.Show(caption: "删除任务", text: "是否确定删除本任务？（本操作不可逆）", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            TodoData.doList.Remove(todoData);
                            DisplayList(TodoData.doList);
                        }
                    };
                    deleteLabel.Cursor = Cursors.Hand;
                    ddlPanel.Controls.Add(deleteLabel);

                    var modifyLabel = new Label()
                    {
                        Location = new Point(370, 20 + step * i),
                        Text = "修改",
                        AutoSize = true,
                        Font = new Font("微软雅黑", 10, FontStyle.Underline),

                    };
                    modifyLabel.Click += (s, arg) =>
                    {
                        var form = new Form_AddNewThing(todoData);
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.Cancel)
                            this.DisplayList(TodoData.doList);
                    };
                    modifyLabel.Cursor = Cursors.Hand;
                    ddlPanel.Controls.Add(modifyLabel);

                    if (todoData.IsFinished)
                        nameLabel.ForeColor = timeLeftLabel.ForeColor = Color.DarkGray;

                    i++;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var form = new Form_AddNewThing();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                this.DisplayList(TodoData.doList);
        }

        private void Form_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataWriter dataWriter = new DataWriter();
            dataWriter.WriteIntoCSV(TodoData.doList);
        }
    }
}