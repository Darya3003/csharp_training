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
            if (!app.Contact.IsAnyContactExist())
            {
                app.Contact.Create(new ContactData("new contact"));
            }
            if (!app.Groups.IsAnyGroupExist())
            {
                app.Groups.Create(new GroupData("ggg"));
            }

            GroupData group = GroupData.GetAll()[0];
            ContactData contact = ContactData.GetLastContact();

            List<ContactData> contactsToDelete = group.GetContacts();
            if (contactsToDelete.Count == 0)
            {
                app.Contact.AddContactToGroup(contact, group);
            }

            List<ContactData> oldList = ContactData.GetAll().Except(contactsToDelete).ToList();

            app.Contact.DeleteAllContactsFromGroup(group);

            List<ContactData> newList = group.GetContacts();
            
            Assert.AreNotEqual(oldList, newList);
            Assert.AreEqual(0, newList.Count);
        }
    }
}