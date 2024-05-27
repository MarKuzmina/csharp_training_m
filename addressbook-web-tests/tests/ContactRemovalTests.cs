using System;
using NUnit.Framework.Legacy;
using System.Security.Cryptography;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (! app.Contacts.IsContacstListNotEmpty())
            {
                ContactData newContact = new ContactData("Для удаления", "Контакт");
                app.Contacts.Create(newContact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(oldContacts[0]);

            ClassicAssert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            //ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                ClassicAssert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}