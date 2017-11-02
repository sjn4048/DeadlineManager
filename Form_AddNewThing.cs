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
    public partial class Form_AddNewThing : Form
    {
        private bool isModifyMode = false;
        TodoData currentData;

        public Form_AddNewThing()
        {
            InitializeComponent();

            this.ddlDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.ddlDateTimePicker.Format = DateTimePickerFormat.Custom;
            //this.ddlDateTimePicker.ShowUpDown = true;
        }

        public Form_AddNewThing(TodoData todoData)
        {
            InitializeComponent();

            this.ddlDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.ddlDateTimePicker.Format = DateTimePickerFormat.Custom;
            isModifyMode = true;
            currentData = todoData ?? throw new Exception("Null Reference.");
            Text = "修改事件";
            nameLabel.Text = todoData.Name;
            typeComboBox.SelectedIndex = (int)todoData.ThingType;
            ddlDateTimePicker.Value = todoData.DeadLine;
            importanceComboBox.SelectedIndex = (int)todoData.ThingImportance;

            if (todoData.IsRepeat)
            {
                if (todoData.RepeatPeriod == new TimeSpan(7, 0, 0, 0))
                    repeatComboBox.SelectedIndex = 1;
                else if (todoData.RepeatPeriod == new TimeSpan(365, 0, 0, 0))
                    repeatComboBox.SelectedIndex = 1;
            }
            else
                repeatComboBox.SelectedIndex = 0;
        }

        private void addButton_click(object sender, EventArgs e)
        {
            bool isRepeat = true;
            TimeSpan repeatPeriod = new TimeSpan();
            if (nameLabel.Text == string.Empty
                || typeComboBox.SelectedIndex == -1
                || ddlDateTimePicker.Value < DateTime.Today
                || importanceComboBox.SelectedIndex == -1
                || repeatComboBox.SelectedIndex == -1
                )
            {
                MessageBox.Show(text:"不合法的输入", icon:MessageBoxIcon.Error, caption:"错误", buttons:MessageBoxButtons.OK);
                return;
            }
            switch(repeatComboBox.SelectedIndex)
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
            var newThing = TodoData.CreateNewThing(nameLabel.Text, ddlDateTimePicker.Value,(TodoData.Importance)importanceComboBox.SelectedIndex, (TodoData.Type)typeComboBox.SelectedIndex, isRepeat, repeatPeriod);
            if (isModifyMode)
                TodoData.doList.Remove(currentData);//还是有小bug
            //DataWriter dataWriter = new DataWriter();
            //dataWriter.WriteIntoCSV(newThing);
            this.Close();
        }

        private void Form_AddNewThing_Load(object sender, EventArgs e)
        {

        }

        private void Form_AddNewThing_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
