using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz")
            {
                Header = "xxx",
                Footer = "www"
            };

            if (!app.Groups.IsAnyGroupExist())
            {
                app.Groups.Create(new GroupData("ggg"));
            }

            List<GroupData> oldGroups = GroupData.GetAll();                    
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData.Id, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());


            List<GroupData> newGroups = GroupData.GetAll();
            oldData.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
