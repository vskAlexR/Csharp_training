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
            ContactData contact = new ContactData("aaa");
            contact.LastName = "bbb";
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
    }
}