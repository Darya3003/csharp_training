using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {        
        [Test]
        public void GroupRemovalTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            groupHelper.ReturnToGroupsPage();
            logoutHelper.Logout();
        }     
    }
}
