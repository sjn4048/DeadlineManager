// DoListInWinForm.CalendarForm
using DoListInWinForm;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoListInWinForm
{
    public class CalendarForm : Form
    {
        private Label[] _dateLabels;

        private Label[] _weekdayLabels;

        private Label _warningLabel;

        private RichTextBox _detailLabel;

        private IContainer components = null;

        private DateTimePicker dateTimePicker1;

        private Label label1;

        public CalendarForm()
        {
            this.InitializeComponent();
            this.InitializeLabels();
            this.UpdateLabels(this.dateTimePicker1.Value);
        }

        private void CalendarForm_Load(object sender, EventArgs e)
        {
        }

        private void InitializeLabels()
        {
            int height = this.dateTimePicker1.Height;
            Size size = this.dateTimePicker1.Size;
            int num = height + size.Height + 80;
            size = base.Size;
            int num2 = size.Height - 30 - num;
            size = base.Size;
            int num3 = size.Width - 30;
            int num4 = (int) ((double) num2 / 14.0);
            int num5 = (int) ((double) num3 / 12.0);
            this._dateLabels = new Label[42];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int num6 = i * 7 + j;
                    this._dateLabels[num6] = new Label
                    {
                        Size = new Size(num5, num4),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 15f),
                        Location = new Point((int) ((double) num5 * (1.0 + (double) j * 1.5)),
                            (int) ((double) num + (double) num4 * (1.5 + (double) i * 1.5))),
                        ForeColor = Color.Black,
                        BackColor = this.BackColor
                    };
                    this._dateLabels[num6].MouseEnter += this.label_MouseEnter;
                    this._dateLabels[num6].MouseLeave += this.label_MouseLeave;
                    base.Controls.Add(this._dateLabels[num6]);
                }
            }

            string[] array = new string[7]
            {
                "Mon",
                "Tue",
                "Wed",
                "Thu",
                "Fri",
                "Sat",
                "Sun"
            };
            this._weekdayLabels = new Label[7];
            for (int k = 0; k < 7; k++)
            {
                this._weekdayLabels[k] = new Label
                {
                    Text = array[k],
                    Size = new Size(num5, num4),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 15f, FontStyle.Bold | FontStyle.Italic),
                    Location = new Point((int) ((double) num5 * (1.0 + (double) k * 1.5)), num),
                    ForeColor = Color.Black,
                    BackColor = this.BackColor
                };
                base.Controls.Add(this._weekdayLabels[k]);
            }

            this._warningLabel = new Label
            {
                Location = new Point((int) ((double) num5 * 1.0), (int) ((double) num + (double) num4 * 10.5)),
                Text = string.Empty,
                Size = new Size((int) ((double) num3 - 2.0 * (double) num5), 4 * num4),
                Font = new Font("微软雅黑", 12f, FontStyle.Italic)
            };
            base.Controls.Add(this._warningLabel);
            this._detailLabel = new RichTextBox
            {
                Text = string.Empty,
                Size = new Size(0, 0),
                Font = new Font("微软雅黑", 12f, FontStyle.Italic),
                BackColor = this.BackColor,
                BorderStyle = BorderStyle.None,
                AutoSize = true
            };
            base.Controls.Add(this._detailLabel);
        }

        private void RestoreLabels()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int num = i * 7 + j;
                    this._dateLabels[num].Text = string.Empty;
                    this._dateLabels[num].ForeColor = Color.Black;
                    this._dateLabels[num].BackColor = this.BackColor;
                    this._dateLabels[num].Enabled = false;
                    this._dateLabels[num].Font = new Font("Arial", 15f, FontStyle.Regular);
                    this._dateLabels[num].BorderStyle = BorderStyle.None;
                }
            }
        }

        private void UpdateLabels(DateTime dt)
        {
            DateTime dateTime = dt.AddDays((double) (-dt.Day));
            int num = (int) dateTime.DayOfWeek;
            for (int i = 1; i <= DateTime.DaysInMonth(dt.Year, dt.Month); i++)
            {
                DateTime dateTime2 = dateTime.AddDays((double) i);
                DateTime currentDate = dateTime2.Date;
                this._dateLabels[num].Enabled = true;
                this._dateLabels[num].Text = i.ToString();
                DateTime date = currentDate.Date;
                dateTime2 = DateTime.Now;
                if (date < dateTime2.Date)
                {
                    this._dateLabels[num].BackColor = Color.LightGray;
                }
                else
                {
                    IOrderedEnumerable<TodoData> source = from x in TodoData.DoList.Where(delegate(TodoData x)
                        {
                            DateTime deadLine = x.DeadLine;
                            int result;
                            if (!(deadLine.Date == currentDate) || x.IsFinished)
                            {
                                if (x.IsRepeat)
                                {
                                    deadLine = x.DeadLine;
                                    TimeSpan timeSpan = deadLine.Date - currentDate;
                                    int days = timeSpan.Days;
                                    timeSpan = x.RepeatPeriod;
                                    result = ((days % timeSpan.Days == 0) ? 1 : 0);
                                }
                                else
                                {
                                    result = 0;
                                }
                            }
                            else
                            {
                                result = 1;
                            }

                            return (byte) result != 0;
                        })
                        orderby x.DeadLine
                        select x;
                    TodoData.Type[] array = (from x in source
                        group x by x.ThingType
                        into x
                        select x.First().ThingType).ToArray();
                    if (array.Length == 1)
                    {
                        this._dateLabels[num].BackColor = array[0].GetColor();
                    }
                    else if (array.Length > 1)
                    {
                        this._dateLabels[num].BackColor = Color.DarkRed;
                    }

                    DateTime date2 = currentDate.Date;
                    dateTime2 = DateTime.Now;
                    if (date2 == dateTime2.Date)
                    {
                        this._dateLabels[num].BorderStyle = BorderStyle.FixedSingle;
                        this._dateLabels[num].Font = new Font("Arial", 15f, FontStyle.Bold | FontStyle.Italic);
                    }
                }

                num++;
            }
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            int day = default(int);
            if (int.TryParse(((Label) sender).Text, out day))
            {
                DateTime dateTime = this.dateTimePicker1.Value;
                int year = dateTime.Year;
                dateTime = this.dateTimePicker1.Value;
                dateTime = new DateTime(year, dateTime.Month, day);
                DateTime currentDate = dateTime.Date;
                TodoData[] array = (from x in TodoData.DoList.Where(delegate(TodoData x)
                    {
                        DateTime deadLine = x.DeadLine;
                        int result;
                        if (!(deadLine.Date == currentDate) || x.IsFinished)
                        {
                            if (x.IsRepeat)
                            {
                                deadLine = x.DeadLine;
                                TimeSpan timeSpan = deadLine.Date - currentDate;
                                int days = timeSpan.Days;
                                timeSpan = x.RepeatPeriod;
                                result = ((days % timeSpan.Days == 0) ? 1 : 0);
                            }
                            else
                            {
                                result = 0;
                            }
                        }
                        else
                        {
                            result = 1;
                        }

                        return (byte) result != 0;
                    })
                    orderby x.DeadLine
                    select x).ToArray();
                int num = array.Count();
                this._detailLabel.Text = string.Empty;
                for (int i = 0; i < array.Length; i++)
                {
                    string text = string.Format("{0}  \t{1}", array[i].ThingType.ToNameString("Chinese"),
                        array[i].Name);
                    if (i != array.Length - 1)
                    {
                        text += "\n";
                    }

                    this._detailLabel.AppendText(text, array[i].ThingType.GetColor());
                }

                Label label = (Label) sender;
                this._detailLabel.BringToFront();
                RichTextBox detailLabel = this._detailLabel;
                Point location = label.Location;
                int x2 = location.X;
                location = label.Location;
                detailLabel.Location = new Point(x2, location.Y + (int) ((double) label.Height * 1.4));
                this._detailLabel.Size = new Size(200, 35 * num);
            }
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            this._detailLabel.Size = new Size(0, 0);
            this._detailLabel.Text = string.Empty;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.RestoreLabels();
            this.UpdateLabels(this.dateTimePicker1.Value);
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
            this.dateTimePicker1 = new DateTimePicker();
            this.label1 = new Label();
            base.SuspendLayout();
            this.dateTimePicker1.Anchor = AnchorStyles.Top;
            this.dateTimePicker1.CustomFormat = "yyyy-MM";
            this.dateTimePicker1.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new Point(505, 53);
            this.dateTimePicker1.Margin = new Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new Size(112, 30);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += this.dateTimePicker1_ValueChanged;
            this.label1.Anchor = AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("华文中宋", 21.75f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label1.Location = new Point(358, 44);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(92, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "日历";
            base.AutoScaleDimensions = new SizeF(8f, 15f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(874, 519);
            base.Controls.Add(this.dateTimePicker1);
            base.Controls.Add(this.label1);
            base.Name = "CalendarForm";
            this.Text = "DDL日历";
            base.Load += this.CalendarForm_Load;
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}