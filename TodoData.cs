using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DoListInWinForm
{
    public class TodoData
    {
        public static List<TodoData> doList = new List<TodoData>();

        //public static bool DataHasChanged = false;
        //等成熟了再加入

        public enum Importance
        {
            Compulsory,
            Alternative,
            NotImportant
        };
        public enum Type
        {
            Exam = 0,
            Homework,
            Paper,
            Preview,
            Meeting,
            Work,
            Interest,
            Others
        }
        public string Name { get; private set; }
        public DateTime DeadLine { get; private set; }
        public Importance ThingImportance { get; private set; }
        public Type ThingType { get; private set; }
        public bool IsFinished { get; private set; }
        public bool IsRepeat { get; private set; }              //是否是重复性工作（如每周作业）
        public TimeSpan RepeatPeriod { get; private set; }      //重复间隔

        public static TodoData CreateNewThing(string name, DateTime deadline, Importance importance, Type type, bool isRepeat, TimeSpan repeatPeriod, bool isFinished = false)
        {
            TodoData newThing = new TodoData()
            {
                Name = name,
                DeadLine = deadline,
                ThingImportance = importance,
                ThingType = type,
                IsRepeat = isRepeat,
                RepeatPeriod = repeatPeriod,
                IsFinished = isFinished
            };
            if (newThing.IsRepeat)   //校正
                newThing.IsFinished = false;
            return newThing;
        }

        public void SetFinishStatus(bool status)
        {
            if (this.IsFinished == status)
            {
                throw new Exception("赋值失败，当前状态等于待赋状态");
            }
            else
                this.IsFinished = status;
        }

        public void AddDeadLine(TimeSpan timeSpan)
        {
            if (timeSpan > TimeSpan.Zero)
                this.DeadLine += timeSpan;
            else
                throw new Exception("输入的时间不合法！");
        }
    }
}
