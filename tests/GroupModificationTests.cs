using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz")
            {
                Header = "ttt",
                Footer = "qqq"
            };
            app.Groups.Modify(1, newData);
        }
    }
}
