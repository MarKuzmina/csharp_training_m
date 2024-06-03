﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count() == 1)
            {
                GroupData newGroup = new GroupData()
                { Name = "hjkhlk" };
                app.Groups.Add(newGroup);
                oldGroups = app.Groups.GetGroupList();
            }

            app.Groups.Remove(1);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(1);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count(), newGroups.Count());
        }
    }
}
