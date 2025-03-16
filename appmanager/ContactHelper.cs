using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

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

        public ContactHelper Modify(string oldId, ContactData newContactData)
        {
            SelectContact(oldId);
            InitContactModification(oldId);
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

        public ContactHelper Remove(ContactData contact)
        {
            SelectContact(contact.Id);
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
            Type(By.Name("home"), contactData.HomePhone);
            Type(By.Name("mobile"), contactData.MobilePhone);
            Type(By.Name("work"), contactData.WorkPhone);
            Type(By.Name("fax"), contactData.Fax);
            Type(By.Name("email"), contactData.Email);
            Type(By.Name("email2"), contactData.Email2);
            Type(By.Name("email3"), contactData.Email3);
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("homepage"), contactData.HomePhone);

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

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
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
            contactCache = null;
            return this;
        }
        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactHelper InitContactModification(string id)
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/edit.php?id="+id+"");
            contactCache = null;
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
                    contact.Id = cells[0].FindElement(By.TagName("input")).GetAttribute("id");
                    contactCache.Add(contact);
                }
            }
                return new List <ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName)
            {
                LastName = lastName,
                Address = address,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationEditFrom(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName)
            {
                LastName = lastName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };

        }

       
        public int GetNumberofSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);

            return Int32.Parse(m.Value);
        }

        public ContactData GetContactDetailInformation(int v)
        {
            manager.Navigator.GoToHomePage();
            GoToContactDetailPage(0);

            string detailInformation = driver.FindElement(By.Id("content")).Text;
            string firstName = detailInformation.Split(' ')[0];
            
            //string lastName = detailInformation.Split(' ')[1].Split('\\')[0];
            //string firstName = new Regex(@"\+").Match(detailInformation).Value;

            return new ContactData("");
        }

        public void GoToContactDetailPage(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
              .FindElements(By.TagName("td"))[6]
              .FindElement(By.TagName("a")).Click();
        }  
        
        public void AddContactToGroup (ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
        }

        private void CommitAddingContactToGroup()
        {
            throw new NotImplementedException();
        }

        private void SelectGroupToAdd(string name)
        {
            throw new NotImplementedException();
        }

        private void ClearGroupFilter()
        {
            throw new NotImplementedException();
        }
    }
}
