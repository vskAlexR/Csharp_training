using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase

    {

        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("zzz3");
            group.Header = "yyy3";
            group.Footer = "qqq3";

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            if (!app.Groups.IsGroupExist(0))
            {
                app.Groups.Remove(toBeRemoved);
            }
            else
            {
                app.Groups.Create(group);
                oldGroups.Add(group);
                app.Groups.Remove(toBeRemoved);
            }
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();


            oldGroups.RemoveAt(0);
            foreach (GroupData groupData in newGroups)
            {
                Assert.AreNotEqual(groupData.Id, toBeRemoved.Id);
            }

        }
    }
}