using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class DeletingContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void TestDeletingContactsFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> contactsToDelete= group.GetContacts();
            List<ContactData> oldList = ContactData.GetAll().Except(contactsToDelete).ToList();

            app.Contact.DeleteAllContactsFromGroup(group);

            List<ContactData> newList = group.GetContacts();
            
            Assert.AreNotEqual(oldList, newList);
            Assert.AreEqual(0, newList.Count);
        }
    }
}