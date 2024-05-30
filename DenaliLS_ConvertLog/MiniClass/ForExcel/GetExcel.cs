using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class GetExcel {
    private static Workbook workbook = new Workbook();
    private static Worksheet worksheet;

    public static List<Data> All() {
        workbook.LoadFromFile(Save.fileName);
        worksheet = workbook.Worksheets["Sheet1"];
        int lastRow = worksheet.LastRow;

        List<Data> list = new List<Data>();
        for (int loop = 2; loop <= lastRow; loop++)
        {
            Data data = new Data();
            data.Serial = worksheet.GetText(loop, 1);
            data.data = worksheet.GetText(loop, 3);
            list.Add(data);
        }

        return list;
    }

    public static List<string> File() {
        List<string> excelFiles = new List<string>();
        try
        {
            string exeLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string folderPath = Path.GetDirectoryName(exeLocation);
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            string[] extensions = new[] { ".xlsx", ".xls" };
            FileInfo[] files = directory.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                                       .Where(f => extensions.Contains(f.Extension.ToLower()))
                                       .ToArray();

            foreach (FileInfo file in files)
            {
                excelFiles.Add(file.Name);
            }
        } catch (Exception ex)
        {
            Console.WriteLine("เกิดข้อผิดพลาดในขณะค้นหาไฟล์: " + ex.Message);
        }

        return excelFiles;
    }
}

public class Data {
    public string Serial;
    public string data;
    public JsonData Json;
}
