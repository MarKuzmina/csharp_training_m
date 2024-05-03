using System;
using NUnit.Framework.Legacy;

namespace webAddressbookTests.tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationTests()
		{
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //проверки
            ClassicAssert.AreEqual(fromTable, fromForm);
            ClassicAssert.AreEqual(fromTable.Address, fromForm.Address);
            ClassicAssert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            ClassicAssert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
	}
}

