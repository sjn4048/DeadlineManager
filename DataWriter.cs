using System;
using System.Collections.Generic;
using System.IO;

namespace DoListInWinForm
{
    internal class DataWriter
    {
        public void WriteIntoCsv(TodoData data)
        {
            using (FileStream file = new FileStream("DoList.dat", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                if (!file.CanWrite || data == null)
                    throw new Exception("无法写入文件"); //一个似乎并不必要的验证
                using (StreamWriter streamWriter = new StreamWriter(file))
                    streamWriter.WriteLine($"{data.Name}#{data.DeadLine}#{data.ThingImportance}#{data.ThingType}#{data.IsFinished}#{data.IsRepeat}#{data.RepeatPeriod}");
            }
        }

        public void WriteIntoCsv(List<TodoData> doList)
        {
            using (FileStream file = new FileStream("DoList.dat", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    if (doList.Count == 0)
                        return;
                    foreach (var data in doList)
                    {
                        streamWriter.WriteLine($"{data.Name}#{data.DeadLine}#{data.ThingImportance}#{data.ThingType}#{data.IsFinished}#{data.IsRepeat}#{data.RepeatPeriod}");

                    }
                }
            }
        }
    }
}
