using System;
using NUnit.Framework.Legacy;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        //тест для проверки информации о контакте на главной странице
        [Test]
        public void TestContactInformation()
		{
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //проверки
            ClassicAssert.AreEqual(fromTable, fromForm);
            ClassicAssert.AreEqual(fromTable.Address, fromForm.Address);
            ClassicAssert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            ClassicAssert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }


        //тест для проверки детальной информации о контакте
        [Test]
        public void TestContactInformationDetails() 
        {
            string contactDetailsFromTable = app.Contacts.GetContactDetailInformationFromEdit(0);
            string contactDetailsFromDetailsForm = app.Contacts.GetContactInformationFromDetailsPage(0);

            //проверка
            ClassicAssert.AreEqual(contactDetailsFromTable, contactDetailsFromDetailsForm);
        }
    }
}