using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DoListInWinForm
{
    class DataWriter
    {
        public void WriteIntoCSV(TodoData data)
        {
            using (FileStream file = new FileStream("DoList.dat", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                if (!file.CanWrite)
                    throw new Exception("无法写入文件"); //一个似乎并不必要的验证
                using (StreamWriter streamWriter = new StreamWriter(file))
                    streamWriter.WriteLine($"{data.Name}#{data.DeadLine}#{data.ThingImportance}#{data.ThingType}#{data.IsFinished}#{data.IsRepeat}#{data.RepeatPeriod}");
            }
        }

        public void WriteIntoCSV(List<TodoData> doList)
        {
            using (FileStream file = new FileStream("DoList.dat", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    foreach (var data in doList)
                    {
                        streamWriter.WriteLine($"{data.Name}#{data.DeadLine}#{data.ThingImportance}#{data.ThingType}#{data.IsFinished}#{data.IsRepeat}#{data.RepeatPeriod}");

                    }
                }
            }
        }
    }
}
