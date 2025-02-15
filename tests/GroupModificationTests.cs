using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("aaa")
            {
                Header = null,
                Footer = null
            };
            app.Groups.Modify(1, newData);
        }
    }
}
