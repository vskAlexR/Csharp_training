using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    class AddContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
        [Test]
        public void TestRemoveContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            app.Contacts.RemoveContactFromGroup(oldList[0], group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }


        [Test]
        public void AddingContactToGroupTest()
        {
           // var (group, contact) = FindOrCreateContactNotInGroup();
            var  (group,contact) = ContactNotInGroup();

           // GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            List<ContactData> oldContacts = group.GetContacts();
          //  ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);
            List<ContactData> newContacts = group.GetContacts();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test]
        public void RemoveContactFromGroupTest()
        {

            var group = GroupWithContact();

            List<ContactData> contactsOfGroup = group.GetContacts();
            ContactData contactToRemove = contactsOfGroup[0];
            app.Contacts.RemoveContactFromGroup(contactToRemove, group);
            List<ContactData> newContactsOfGroup = group.GetContacts();
            contactsOfGroup.Remove(contactToRemove);
            contactsOfGroup.Sort();
            newContactsOfGroup.Sort();
            Assert.AreEqual(contactsOfGroup, newContactsOfGroup);
        }

        public (GroupData group, ContactData contact) ContactNotInGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();

            foreach (var group  in groups)
            {
                var contactsNotInGroup = contacts.Except(group.GetContacts()).ToList();
                if (contactsNotInGroup.Count() > 0)
                {
                    return (group, contactsNotInGroup[0]);
                }
            }

            app.Contacts.Create(new ContactData(GenerateRandomString(10), GenerateRandomString(10)));

            var newContacts = ContactData.GetAll();
            var newContact = newContacts.Except(contacts).ToList();

            return (groups[0], newContact.First());
        }

        public GroupData GroupWithContact()
        {
            List<GroupData> groups = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();

            foreach (var group in groups)
            {
                var contactsOfGroup = group.GetContacts();
                if (contactsOfGroup.Count > 0)
                {
                    return group;
                }
            }

            var groupWithContacts = groups[0];
            app.Contacts.AddContactToGroup(contacts[1], groupWithContacts);
            return groupWithContacts;
        }

        [SetUp]
        public void CreateContactAndGroupPreconditions()
        {
            app.Contacts.CreateIfContactNotExist();
            app.Groups.CreateIfGroupNotExist();
            app.Navigator.GoToHomePage();
        }
    }
}