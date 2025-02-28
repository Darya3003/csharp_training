using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("qqq")
            {
                LastName = "www"
            };

            if (!app.Contact.IsAnyContactExist())
            {
                app.Contact.Create(new ContactData("new contact"));
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contactData);
            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }


        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contactData = new ContactData("")
            {
                LastName = ""
            };

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contactData);
            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());


            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
