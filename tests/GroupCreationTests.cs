using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
   public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header= parts[1],
                    Footer= parts[2]
                });
            }
            return groups;
        }
        
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>)
                    new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));           
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb= app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i=1; i<= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>
                   (File.ReadAllText(@"groups.json"));
        }


        [Test, TestCaseSource("GroupDataFromExcelFile")]
        public void GroupCreationTest(GroupData group)
        {      
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();   
            Assert.AreEqual(oldGroups, newGroups);
        }
               
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("'")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            Assert.AreNotEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreNotEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            List<ContactData> contacts = ContactData.GetAll();
            foreach (ContactData contact in contacts)
            {
                Console.WriteLine(contact.FirstName);
            }
        }
    }
}
