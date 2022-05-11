using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase

    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("aaab2");
            contact.LastName = "bbba2";
            contact.MobileNumber = "77782";

            app.Contacts.CreateIfContactNotExist(contact);

            ContactData newData = new ContactData("aaab");
            newData.LastName = "bbba";
            newData.MobileNumber = "7778";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            if (app.Contacts.IsContactExist(0))
            {
                app.Contacts.Modify(0, newData);
            }
            else
            {
                app.Contacts.Create(contact);
                app.Contacts.Modify(0, newData);
            }

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
        }
    }
}