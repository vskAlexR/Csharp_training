using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


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

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupLists();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}