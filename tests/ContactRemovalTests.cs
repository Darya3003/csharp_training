using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {        
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Remove();

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
        }
    }
}
