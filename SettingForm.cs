// DoListInWinForm.SettingForm
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DoListInWinForm
{
    public class SettingForm : Form
    {
        private IContainer components = null;

        private Label label1;

        public SettingForm()
        {
            this.InitializeComponent();
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
            this.label1 = new Label();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("华文中宋", 13.8f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label1.Location = new Point(69, 95);
            this.label1.Name = "label1";
            this.label1.Size = new Size(228, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "正在紧张的设计中...";
            base.AutoScaleDimensions = new SizeF(8f, 15f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(230, 255, 230);
            base.ClientSize = new Size(362, 253);
            base.Controls.Add(this.label1);
            base.Name = "SettingForm";
            this.Text = "设置";
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
