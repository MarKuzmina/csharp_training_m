using System;
using NUnit.Framework.Legacy;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData= new ContactData("Контакта","Редактирование");
            newContactData.Address = null;
            newContactData.Company = null;
            newContactData.Email = null;
            newContactData.Email2 = null;
            newContactData.Email3 = null;
            newContactData.Email3 = null;
            newContactData.Nickname = null;
            newContactData.PhoneFaxNumber = null;
            newContactData.PhoneHomeNumber = null;
            newContactData.PhoneMobileNumber = null;
            newContactData.PhoneWorkNumber = null;
            newContactData.Title = null;
            newContactData.UrlHomepage = null;
            newContactData.Middlename = null;

            if (! app.Contacts.IsContacstListNotEmpty())
            {
                ContactData contact = new ContactData("Дмитрий", "Петрович");
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newContactData);

            ClassicAssert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    ClassicAssert.AreEqual(newContactData.Lastname, contact.Lastname);
                    ClassicAssert.AreEqual(newContactData.Firstname, contact.Firstname);
                }

            }
        }
    }
}