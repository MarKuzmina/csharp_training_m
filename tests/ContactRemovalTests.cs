using System;
namespace webAddressbookTests.tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove("7");
        }
    }
}

