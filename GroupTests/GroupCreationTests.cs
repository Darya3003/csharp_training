using NUnit.Framework;

namespace WebAddressbookTests
{
   [TestFixture]
   public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("aaa")
            {
                Header = "bbb",
                Footer = "ddd"
            };
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
            logoutHelper.Logout();
        }
    }
}
