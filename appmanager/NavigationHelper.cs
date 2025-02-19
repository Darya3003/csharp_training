using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseUrl;

        public NavigationHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }


        public void GoToHomePage()
        {
            if (driver.Url == baseUrl + "/addressbook/")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseUrl + "/addressbook/");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseUrl + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
                { 
                    return;
                }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
