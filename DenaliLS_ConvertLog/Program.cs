using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DenaliLS_ConvertLog {
    internal class Program {
        static void Main(string[] args) {
            List<string> fileAll = GetExcel.File();

            foreach (string file in fileAll)
            {
                Save.fileName = file;

                List<Data> data = GetExcel.All();

                foreach (Data list in data)
                {
                    list.Json = JsonCV.Convert(list.data);
                }

                Save.CreateHead(data[0].Json.ResultString);
                Save.GenData(data);
                File.Delete(Save.fileName);
            }
        }
    }
}
