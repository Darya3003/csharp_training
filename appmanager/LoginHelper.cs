using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData accountData)
        {
            Type(By.Name("user"), accountData.Username);
            Type(By.Name("pass"), accountData.Password);

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}
