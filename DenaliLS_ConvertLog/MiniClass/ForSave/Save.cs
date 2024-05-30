using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Save {
    public static string fileName;
    private static string folder = "Output";

    public static void CreateHead(List<JsonData.ResultString_> data) {
        string header = "Customer,";

        foreach (string step in SelectStep.step)
        {
            foreach (JsonData.ResultString_ list in data)
            {
                if (step == list.Step)
                {
                    header += $"{list.Description},";
                }
            }
        }
        

        string path = Path.Combine(folder, Path.ChangeExtension(fileName, ".csv"));

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(header);
        }
    }

    public static void GenData(List<Data> data) {
        foreach (Data list in data)
        {
            string dataConvert = $"{list.Serial},";
            List<string> stepAll = SelectStep.step;
            foreach (string step in SelectStep.step)
            {
                foreach (JsonData.ResultString_ result in list.Json.ResultString)
                {
                    if (step == result.Step)
                    {
                        if (SelectStep.addString.Contains(result.Step))
                        {
                            dataConvert += $"'{result.Measured.Replace("'", "")},";
                        }
                        else
                        {
                            dataConvert += $"{result.Measured},";
                        }
                        break;
                    }
                }
            }

            string path = Path.Combine(folder, Path.ChangeExtension(fileName, ".csv"));

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(dataConvert);
                Console.WriteLine(dataConvert);
            }
        }
    }
}