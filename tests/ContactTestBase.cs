using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactData> contactsFromUI = app.Contact.GetContactList();
                List<ContactData> contactsFromDB = ContactData.GetAll();

                contactsFromUI.Sort();
                contactsFromDB.Sort();
                Assert.AreEqual(contactsFromUI, contactsFromDB);
            }
        }
    }
}
