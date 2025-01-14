﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
             : base(manager)
        { }
        private List<ContactData> contactCache = null;


        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int id, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(id);
            InitContactModification(id);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(ContactData contact, ContactData contactEdit)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(contact.Id);
            FillContactForm(contactEdit);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper Remove(int id)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(id);
            RemoveContact();
            CloseContactAlert();
            manager.Navigator.OpenHomePage();
            return this;
        }
        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.Id);
            RemoveContact();
            CloseContactAlert();
            manager.Navigator.OpenHomePage();
            return this;
        }


        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName    );
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("mobile"), contact.MobileNumber);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int id)
        {
            driver.FindElements(By.Name("entry"))[id]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
        public ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id=" + id + "']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + id+1 + "]")).Click();
            return this;
        }
        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + id + 1 + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper CloseContactAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public void CreateIfContactNotExist(ContactData contact)
        {
            if (!IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
                Create(contact);
            }
        }
        public bool IsContactExist(int id)
        {
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + ( id + 2 ) + "]/td/input"));
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)

            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var elem = element.FindElements(By.CssSelector("td"));
                    var firstName = elem[2].Text;
                    var lastName = elem[1].Text;
                    contactCache.Add(new ContactData(firstName, lastName));
                }
            }
            return new List<ContactData>(contactCache);
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;

        }
        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        internal ContactData GetContactInformationFromEditForm(int id)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(id);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            return new ContactData(firstName, lastName, mobilePhone)
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                MobilePhone = mobilePhone,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                NickName = nickName,
                Title = title,
                Company = company
            };
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;

            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
        public ContactHelper OpenContactDetails(int id)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + ( id + 2 ) + "]/td[7]/a/img")).Click();
            return this;
        }
        public ContactData GetContactInformationFromDetails(int id)
        {
            manager.Navigator.OpenHomePage();
            OpenContactDetails(id);
            var rows = driver.FindElement(By.Id("content")).Text;

            string allContactInfo = driver.FindElement(By.Id("content")).GetAttribute("innerText").Replace("\r\n", "");

            string fullName = driver.FindElement(By.Id("content")).FindElement(By.TagName("b")).Text.Replace("\r\n", "");

            return new ContactData(allContactInfo)
            {
                AllContactInfo = allContactInfo,
                FullName = fullName,
            };

        }
        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContactById(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }
        private void SelectContactById(string contactid)
        {
            driver.FindElement(By.Id(contactid)).Click();
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            SelectGroupWithContacts(group.Name);
            SelectContactById(contact.Id);
            CommitRemoveContactFromGroup();
        }
        private void CommitRemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }
        private void SelectGroupWithContacts(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

    }
}