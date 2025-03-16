using NUnit.Framework;
using OpenQA.Selenium.BiDi.Modules.Input;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> groupsFromUI = app.Groups.GetGroupList();
                List<GroupData> groupsFromDB = GroupData.GetAll();

                groupsFromUI.Sort();
                groupsFromDB.Sort();
                Assert.AreEqual(groupsFromUI, groupsFromDB);
            }
        }
    }
}
