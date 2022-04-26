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
            GroupData newData = new GroupData("zzz");
            newData.Header = "yyy";
            newData.Footer = "qqq";

            app.Groups.Modify(1, newData);

            GroupData group = new GroupData("zzz2");
            group.Header = "yyy2";
            group.Footer = "qqq2";

            app.Groups.CreateIfGroupNotExist(group);
        }
    }
}