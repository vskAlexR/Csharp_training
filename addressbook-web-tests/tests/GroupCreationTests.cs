using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase

    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupLists();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupLists();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupLists();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}