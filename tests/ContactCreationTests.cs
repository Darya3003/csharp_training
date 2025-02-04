using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.GoToAddNewContactPage();
            ContactData contactData = new ContactData("test");
            contactData.LastName = "test";
            app.Contact.FillContactForm(contactData);
            app.Navigator.ReturnToHomePage();
            app.Logout.Logout();
        }  
    }
}
