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

        [Test]
        public void TestContactDetailInformation()
        {
            ContactData fromDetail = app.Contact.GetContactDetailInformation(0);
            ContactData fromEditGorm = app.Contact.GetContactInformationEditFrom(0);

            //verification
            Assert.AreEqual(fromDetail, fromEditGorm);
            Assert.AreEqual(fromDetail.Address, fromEditGorm.Address);
            Assert.AreEqual(fromDetail.AllPhones, fromEditGorm.AllPhones);
        }
    }
}
