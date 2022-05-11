using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests

{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase

    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("zzz2");
            group.Header = "yyy2";
            group.Footer = "qqq2";

            app.Groups.CreateIfGroupNotExist(group);

            GroupData newData = new GroupData("zzz");
            newData.Header = "yyy";
            newData.Footer = "qqq";

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            if (app.Groups.IsGroupExist(0))
            {
                app.Groups.Modify(0, newData);
            }
            else
            {
                app.Groups.Create(group);
                app.Groups.Modify(0, newData);
            }
            List<GroupData> newGroups = app.Groups.GetGroupLists();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
        }
    }
}