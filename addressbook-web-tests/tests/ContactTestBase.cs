using System;
using Google.Protobuf.WellKnownTypes;
using NUnit.Framework.Legacy;

namespace webAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CONTACTS_CHEKS)
            {
                List<ContactData> fromUI = app.Contacts.GetContactList();
                List<ContactData> fromDB = ContactData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                ClassicAssert.AreEqual(fromUI, fromDB);
            }
        }
    }
}

