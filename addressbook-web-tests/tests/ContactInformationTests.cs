using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void CheckContactFromTableAndContactFromEditFormAreEqual()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetails()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);

            Assert.AreEqual(fromDetails.AllContactInfo, fromForm.AllContactInfo);
        }
    }
}