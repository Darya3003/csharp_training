using System.Xml.Serialization;
using WebAddressbookTests;

internal class Program
{
    private static void Main(string[] args)
    {
        int count = Convert.ToInt32(args[0]);
        StreamWriter writer = new StreamWriter(args[1]);
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
        if (format == "csv")
        {
            WriteGroupsToCsvFile(groups, writer);
        }
        else if (format == "xml")
        {
            WriteGroupsToXmlFile(groups, writer);
        }
        else
        {
            Console.WriteLine("Unrecognzed format" + format);
        }

        writer.Close();

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
    }
}