using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        [TestFixtureSetUp]
        public void InitApplication() => app = new ApplicationManager();

        [TestFixtureTearDown]
        public void AporStopApplication() => app.Stop();
    }
}
