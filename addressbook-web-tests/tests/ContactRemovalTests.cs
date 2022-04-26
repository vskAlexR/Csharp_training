using NUnit.Framework;

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

            app.Contacts.Remove(1);
        }
    }
}