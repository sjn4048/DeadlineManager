using System;
using System.IO;

namespace DoListInWinForm
{
    internal class DataReader
    {
        public void ReadAll() //
        {
            var file = new FileStream("DoList.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            var streamReader = new StreamReader(file);
            string dataLine;

            while ((dataLine = streamReader.ReadLine()) != null)
            {
                var dataPart = dataLine.Split('#');
                string name = dataPart[0];
                var deadline = DateTime.Parse(dataPart[1]);
                var importance = (TodoData.Importance)Enum.Parse(typeof(TodoData.Importance), dataPart[2]);
                var type = (TodoData.Type)Enum.Parse(typeof(TodoData.Type), dataPart[3]);
                bool isFinished = bool.Parse(dataPart[4]);
                bool isRepeat = bool.Parse(dataPart[5]);
                var repeatPeriod = TimeSpan.Parse(dataPart[6]);
                var newThing = TodoData.CreateNewThing(name, deadline, importance, type, isRepeat, repeatPeriod, isFinished);
                TodoData.DoList.Add(newThing);
            }
        }
    }
}
