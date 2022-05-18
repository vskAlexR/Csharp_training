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
            GroupData group = new GroupData();
            group.Name = "sss3";
            group.Header = "yyy3";
            group.Footer = "qqq3";

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            if (app.Groups.IsGroupExist(0))
            {
                app.Groups.Remove(0);
            }
            else
            {
                app.Groups.Create(group);
                app.Groups.Remove(0);
            }
            List<GroupData> newGroups = app.Groups.GetGroupLists();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}