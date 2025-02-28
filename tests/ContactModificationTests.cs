using NUnit.Framework;
using System.Collections.Generic;

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

            if (!app.Contact.IsAnyContactExist())
            {
                app.Contact.Create(new ContactData("new contact"));
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(0, newContactData);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
