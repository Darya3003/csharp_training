using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseUrl;

        public NavigationHelper(IWebDriver driver, string baseUrl) : base(driver)
        {
            this.baseUrl = baseUrl;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseUrl + "/group.php");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
