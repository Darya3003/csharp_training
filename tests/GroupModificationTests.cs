using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("aaa")
            {
                Header = null,
                Footer = null
            };

            if (!app.Groups.IsAnyGroupExist())
            {
                app.Groups.Create(new GroupData("ggg"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();                   

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
