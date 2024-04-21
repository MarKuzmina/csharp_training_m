using System;
namespace webAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
	{
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("wwww");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);
        }
    }
}

