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

            if (app.Contacts.IsContactExist(0))
            {
                app.Contacts.Remove(0);
            }
            else
            {
                app.Contacts.Create(contact);
                oldContacts.Add(contact);
                app.Contacts.Remove(0);
            }
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);
            foreach (ContactData contactData in newContacts)
            {
                Assert.AreNotEqual(contactData.Id, toBeRemoved.Id);
            }
        }
    }
}