using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase

    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("aaab3");
            contact.LastName = "bbba3";
            contact.MobileNumber = "77783";

            app.Contacts.CreateIfContactNotExist(contact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}