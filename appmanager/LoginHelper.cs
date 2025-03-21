﻿using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData accountData)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(accountData))
                {
                    return;
                }
                Logout();

            }
            Type(By.Name("user"), accountData.Username);
            Type(By.Name("pass"), accountData.Password);

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData accountData)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == accountData.Username;
        }

        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }
    }
}
