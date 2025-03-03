using NUnit.Framework;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            Console.WriteLine(app.Contact.GetNumberofSearchResults());
        }
    }
}
