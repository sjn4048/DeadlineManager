// DoListInWinForm.ExtensionMethods
using DoListInWinForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoListInWinForm
{
    internal static class ExtensionMethods
    {
        public static string ToNameString(this TodoData.Type t, string language = "Chinese")
        {
            string[] array = new string[7]
            {
                "考试",
                "作业",
                "项目",
                "论文",
                "事件",
                "预习",
                "其他"
            };
            string[] array2 = new string[7]
            {
                "Exam",
                "Homework",
                "Project",
                "Paper",
                "Event",
                "Preview",
                "Else"
            };
            if (language == "Chinese")
            {
                return array[(int) t];
            }

            if (language == "English")
            {
                return array2[(int) t];
            }

            throw new ArgumentException("Invalid language.");
        }

        public static Color GetColor(this TodoData.Type t)
        {
            Color[] array = new Color[7]
            {
                Color.DeepPink,
                Color.DodgerBlue,
                Color.Fuchsia,
                Color.Fuchsia,
                Color.DarkOrange,
                Color.DarkTurquoise,
                Color.BlueViolet
            };
            return array[(int) t];
        }

        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}