using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("test");
            contactData.LastName = "test";

            app.Contact.Create(contactData);
        }  
    }
}
