using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase    
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromEditGorm = app.Contact.GetContactInformationEditFrom(0);
            
            //verification
            Assert.AreEqual(fromTable, fromEditGorm);
            Assert.AreEqual(fromTable.Address, fromEditGorm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromEditGorm.AllPhones);
        }
    }
}
