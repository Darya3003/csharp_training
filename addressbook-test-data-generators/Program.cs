using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Xml.Serialization;
using WebAddressbookTests;

internal class Program
{
    private static void Main(string[] args)
    {
        int count = Convert.ToInt32(args[0]);
        string fileName = args[1];
        string format = args[2];
        
        List<GroupData> groups = new List<GroupData>();

        for (int i = 0; i < count; i++)
        {
            groups.Add(new GroupData(TestBase.GenerateRandomString(10))
            {
                Header = TestBase.GenerateRandomString(10),
                Footer = TestBase.GenerateRandomString(10)
            });
        }

        if(format == "excel")
        {
            WriteGroupsToExcelFile(groups, fileName);
        }
        else 
        {
            StreamWriter writer = new StreamWriter(fileName);
            if (format == "csv")
            {
                WriteGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                WriteGroupsToJsonFile(groups, writer);
            }
            else
            {
                Console.WriteLine("Unrecognzed format" + format);
            }

            writer.Close();
        }

        

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(string.Format("${0},${1},${2}",
                group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
           ;
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }
    }

    static void WriteGroupsToExcelFile(List<GroupData> groups, string fileName)
    {
        Excel.Application app = new Excel.Application();
        app.Visible = true;
        Excel.Workbook wb = app.Workbooks.Add();
        Excel.Worksheet sheet = wb.ActiveSheet;

        int row = 1;
        foreach (GroupData group in groups)
        {
            sheet.Cells[row, 1] = group.Name;
            sheet.Cells[row, 2] = group.Header;
            sheet.Cells[row, 3] = group.Footer;

            row++;
        }
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        File.Delete(fullPath);
        wb.SaveAs(fullPath);
        wb.Close();
        app.Visible = false;
        app.Quit();
    }
}