using System;
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

            app.Groups.Modify(1, newData);
        }
    }
}

