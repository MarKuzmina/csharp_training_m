using System;
namespace webAddressbookTests.tests
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

            app.Contacts.Modify(1, newContactData);    
        }
    }
}

