using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("qqq");
            contactData.LastName = "www";

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contactData);
            List<ContactData> newContacts = app.Contact.GetContactList();

            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }


        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contactData = new ContactData("");
            contactData.LastName = "";

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contactData);
            List<ContactData> newContacts = app.Contact.GetContactList();

            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }
    }
}
