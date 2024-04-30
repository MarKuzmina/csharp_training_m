using NUnit.Framework.Legacy;

namespace webAddressbookTests.tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);
        }
    }
}