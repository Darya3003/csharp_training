using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Xml.Serialization;
using WebAddressbookTests;

internal class Program
{
    private static void Main(string[] args)
    {
        string type = args[0];
        int count = Convert.ToInt32(args[1]);
        string fileName = args[2];
        string format = args[3];       

        List<GroupData> groups = new List<GroupData>();
        List<ContactData> contacts = new List<ContactData>();

        if (type == "group")
        {
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            WriteGroupsToFile(groups, fileName, format);
        }
        else if (type == "contacts")
        {
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                {
                    LastName = TestBase.GenerateRandomString(10)
                });
            }
            WriteContactsToFile(contacts, fileName, format);
        }
        else
        {
            Console.WriteLine("Unrecognzed type" + type);
        }      
    }

    #region groups
    static void WriteGroupsToFile(List<GroupData> groups, string fileName, string format)
    {
        if (format == "excel")
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
    }

    static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
    {
        writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
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
    #endregion

    #region contacts
    static void WriteContactsToFile(List<ContactData> contacts, string fileName, string format)
    {
        if (format == "excel")
        {
            WriteContactsToExcelFile(contacts, fileName);
        }
        else
        {
            StreamWriter writer = new StreamWriter(fileName);
            if (format == "csv")
            {
                WriteContactsToCsvFile(contacts, writer);
            }
            else if (format == "xml")
            {
                WriteContactsToXmlFile(contacts, writer);
            }
            else if (format == "json")
            {
                WriteContactsToJsonFile(contacts, writer);
            }
            else
            {
                Console.WriteLine("Unrecognzed format" + format);
            }

            writer.Close();
        }
    }

    static void WriteContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
    {
        foreach (ContactData contact in contacts)
        {
            writer.WriteLine(string.Format("${0},${1}",
            contact.FirstName, contact.LastName));
        }
    }

    static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
    {
        new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
    }

    static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
    {
        writer.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented));
    }

    static void WriteContactsToExcelFile(List<ContactData> contacts, string fileName)
    {
        Excel.Application app = new Excel.Application();
        app.Visible = true;
        Excel.Workbook wb = app.Workbooks.Add();
        Excel.Worksheet sheet = wb.ActiveSheet;

        int row = 1;
        foreach (ContactData contact in contacts)
        {
            sheet.Cells[row, 1] = contact.FirstName;
            sheet.Cells[row, 2] = contact.LastName;
            
            row++;
        }
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        File.Delete(fullPath);
        wb.SaveAs(fullPath);
        wb.Close();
        app.Visible = false;
        app.Quit();
    }
    #endregion
}