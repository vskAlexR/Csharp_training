﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("aaab");
            newData.LastName = "bbba";
            newData.MobileNumber = "7778";

            app.Contacts.Modify(1, newData);
        }
    }
}