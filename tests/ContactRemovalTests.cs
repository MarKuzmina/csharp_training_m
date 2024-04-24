using System;
namespace webAddressbookTests.tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (! app.Contacts.IsContacstListNotEmpty())
            {
                ContactData newContact = new ContactData("Для удаления", "Контакт");
                app.Contacts.Create(newContact);
            }

            app.Contacts.Remove(1);
        }
    }
}

