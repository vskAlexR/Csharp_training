﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
             : base(manager)
        { }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int j)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(j);
            RemoveContact();
            CloseContactAlert();
            manager.Navigator.OpenToHomePage();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int id)
        {
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr/td[" + id + "]/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper CloseContactAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

    }
}