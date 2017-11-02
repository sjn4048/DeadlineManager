using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DoListInWinForm
{
    class DataReader
    {
        public void ReadAll() //
        {
            FileStream file = new FileStream("DoList.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader streamReader = new StreamReader(file);
            string dataLine;

            while ((dataLine = streamReader.ReadLine()) != null)
            {
                string[] dataPart = dataLine.Split('#');
                string name = dataPart[0];
                DateTime deadline = DateTime.Parse(dataPart[1]);
                TodoData.Importance importance = (TodoData.Importance)Enum.Parse(typeof(TodoData.Importance), dataPart[2]);
                TodoData.Type type = (TodoData.Type)Enum.Parse(typeof(TodoData.Type), dataPart[3]);
                bool isFinished = bool.Parse(dataPart[4]);
                bool isRepeat = bool.Parse(dataPart[5]);
                TimeSpan repeatPeriod = TimeSpan.Parse(dataPart[6]);
                TodoData.CreateNewThing(name, deadline, importance, type, isRepeat, repeatPeriod, isFinished);
            }
            ///
            ///To Be Written
            ///
        }
    }
}
