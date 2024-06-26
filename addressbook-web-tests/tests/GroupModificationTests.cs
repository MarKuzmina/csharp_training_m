﻿using System;
using NUnit.Framework.Legacy;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldGroups[0], newData);

            ClassicAssert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

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