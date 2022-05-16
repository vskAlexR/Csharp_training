using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;



namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase

    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "abcdtest";
            contact.LastName = "bbbtest";
            contact.MobileNumber = "777";
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            oldContacts.Add(contact);
            oldContacts.Sort();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.LastName = "";
            contact.MobileNumber = "";
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

        }

        [Test]
        public void ContactFullInfoCreationTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "ghjk";
            contact.LastName = "asdf";
            contact.NickName = "zxcv";
            contact.Title = "123";
            contact.Company = "123qwer";
            contact.Address = "321asdf";
            contact.HomePhone = "812340987";
            contact.MobilePhone = "8(123)0000000";
            contact.WorkPhone = "83211111111";
            contact.Email = "a@b.com";
            contact.Email2 = "b@a.com";
            contact.Email3 = "c@d.com";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}