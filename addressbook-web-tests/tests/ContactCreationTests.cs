using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("aaa");
            contact.LastName = "bbb";
            contact.MobileNumber = "777";
            app.Contacts.Create(contact);
        }
    }
}