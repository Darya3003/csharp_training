using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTest : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            if (!app.Contact.IsAnyContactExist())
            {
                app.Contact.Create(new ContactData("qqq") {LastName = "www"});
            }
            if (!app.Groups.IsAnyGroupExist())
            {
                app.Groups.Create(new GroupData("rrr") { Header="kkk", Footer = "lll"});
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).FirstOrDefault();

            if (contact != null)
            {

                app.Contact.AddContactToGroup(contact, group);
            }
            else
            {
                app.Contact.Create(new ContactData("fff") { LastName = "ggg"});
                contact = ContactData.GetLastContact();
                app.Contact.AddContactToGroup(contact, group);
            }

                List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
