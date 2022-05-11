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

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            if (!app.Groups.IsGroupExist(0))
            {
                app.Groups.Remove(0);
            }
            else
            {
                app.Groups.Create(group);
                oldGroups.Add(group);
                app.Groups.Remove(0);
            }
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupLists();

            GroupData toBeRemoved = oldGroups[0];

            oldGroups.RemoveAt(0);
            foreach (GroupData groupData in newGroups)
            {
                Assert.AreNotEqual(groupData.Id, toBeRemoved.Id);
            }

        }
    }
}