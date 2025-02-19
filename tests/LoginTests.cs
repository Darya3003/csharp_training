using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData accountData = new AccountData("admin", "secret");
            app.Auth.Login(accountData);
            
            //varificaton
            Assert.IsTrue(app.Auth.IsLoggedIn(accountData));
        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData accountData = new AccountData("admin", "123456");
            app.Auth.Login(accountData);

            //varificaton
            Assert.IsFalse(app.Auth.IsLoggedIn(accountData));
        }
    }
}
