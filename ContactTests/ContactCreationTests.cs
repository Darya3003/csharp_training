using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.GoToAddNewContactPage();
            ContactData contactData = new ContactData("test");
            contactData.LastName = "test";
            contactHelper.FillContactForm(contactData);
            navigator.ReturnToHomePage();
            logoutHelper.Logout();
        }  
    }
}
