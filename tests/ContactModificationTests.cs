using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("test1");
            newContactData.LastName = "test1";
            newContactData.MiddleName = "test1";

            app.Contact.Modify(1, newContactData);
        }
    }
}
