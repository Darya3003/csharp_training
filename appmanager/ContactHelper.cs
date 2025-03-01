using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactHelper Create(ContactData contactData)
        {
            GoToAddNewContactPage();
            FillContactForm(contactData);
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(int index, ContactData newContactData)
        {
            SelectContact(index);
            InitContactModification();
            FillContactForm(newContactData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            SelectContact(index);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("middlename"), contactData.MiddleName);
            Type(By.Name("lastname"), contactData.LastName);
            Type(By.Name("nickname"), contactData.NickName);
            Type(By.Name("title"), contactData.Title);
            Type(By.Name("company"), contactData.Company);
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("home"), contactData.Home);
            Type(By.Name("mobile"), contactData.Mobile);
            Type(By.Name("work"), contactData.Work);
            Type(By.Name("fax"), contactData.Fax);
            Type(By.Name("email"), contactData.Email);
            Type(By.Name("email2"), contactData.Email2);
            Type(By.Name("email3"), contactData.Email3);
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("homepage"), contactData.Home);

            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }

        public ContactHelper GoToAddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td["+(index+1)+"]")).Click();
            contactCache = null;

            return this;
        }

        
        public bool IsAnyContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;

            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;

            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                IList<IWebElement> rows = driver.FindElements(By.Name("entry"));            

                foreach (IWebElement row in rows)
                {
                    var contact = new ContactData("");
                    IList<IWebElement> cells = row.FindElements(By.TagName("td")); ;
                    contact.FirstName = cells[2].Text;
                    contact.LastName = cells[1].Text;
                    contact.FirstLastName = cells[2].Text+cells[1].Text;
                    contactCache.Add(contact);
                }
            }
                return new List <ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }
    }
}
