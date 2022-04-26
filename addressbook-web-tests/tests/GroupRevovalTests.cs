using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase

    {

        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("zzz3");
            group.Header = "yyy3";
            group.Footer = "qqq3";

            app.Groups.CreateIfGroupNotExist(group);

            app.Groups.Remove(1);
        }
    }
}