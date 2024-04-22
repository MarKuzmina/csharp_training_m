using System;
namespace webAddressbookTests.tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData= new ContactData("newАлексадр","newПушкин");

            app.Contacts.Modify(1, newContactData);
        }
    }
}

