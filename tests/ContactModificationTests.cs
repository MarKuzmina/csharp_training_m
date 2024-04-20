using System;
namespace webAddressbookTests.tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData= new ContactData("newАлексадр","newПушкин");

            app.Contacts.Modify(5, newContactData);
        }
    }
}

