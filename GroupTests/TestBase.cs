using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text;
using System;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected LogoutHelper logoutHelper;
        protected ContactHelper contactHelper;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            logoutHelper = new LogoutHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
