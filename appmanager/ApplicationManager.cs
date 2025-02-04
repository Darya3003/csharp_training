using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected LogoutHelper logoutHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";

            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            logoutHelper = new LogoutHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        public LoginHelper Auth { get { return loginHelper; } }
        public NavigationHelper Navigator { get { return navigator; } }
        public GroupHelper Groups { get { return groupHelper; } }
        public LogoutHelper Logout { get { return logoutHelper; } }
        public ContactHelper Contact { get { return contactHelper; } }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
