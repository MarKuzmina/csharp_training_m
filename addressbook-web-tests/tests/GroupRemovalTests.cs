using NUnit.Framework.Legacy;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
    
        [Test]
        public void GroupRemovalTest()
        {
            if (! app.Groups.IsGroupListNotEmpty())
            {
                GroupData group = new GroupData("группа для удаления");
                group.Header = "xxx";
                group.Footer = "vvv";
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            ClassicAssert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                ClassicAssert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}