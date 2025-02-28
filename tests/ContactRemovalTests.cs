using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {        
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();
            
            if (!app.Contact.IsAnyContactExist())
            {
                app.Contact.Create(new ContactData("new contact"));
            }

            app.Contact.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
