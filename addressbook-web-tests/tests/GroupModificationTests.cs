using System;
using NUnit.Framework.Legacy;

namespace webAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("wwww");
            newData.Header = null;
            newData.Footer = null;

            if (! app.Groups.IsGroupListNotEmpty())
            {
                GroupData newGroup = new GroupData("группа для модификации");
                app.Groups.Create(newGroup);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            ClassicAssert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    ClassicAssert.AreEqual(newData.Name, group.Name);
                }

            }
        }
    }
}