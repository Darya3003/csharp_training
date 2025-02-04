using NUnit.Framework;

namespace WebAddressbookTests
{
   [TestFixture]
   public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("aaa")
            {
                Header = "bbb",
                Footer = "ddd"
            };
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }
    }
}
