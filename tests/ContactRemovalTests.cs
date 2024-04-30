using System;
using NUnit.Framework.Legacy;
using System.Security.Cryptography;

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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);//???
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);
        }
    }
}