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

            app.Groups.Remove(1);
        }
    }
}
