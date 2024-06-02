using System;
using System.Linq;
using NUnit.Framework.Legacy;

namespace webAddressbookTests
{
	public class AddingContactToGroupTests : AuthTestBase
	{
		[Test]
		public void TestAddingContactToGroup()
		{
            //-------1-------
            if (ContactData.GetAll().Count() == 0) //если нет контактов, то создаем
            {
                ContactData newContact = new ContactData(GenerateRandomString(6), GenerateRandomString(7))
                {
                    Address = GenerateRandomString(30),
                    Middlename = GenerateRandomString(5)
                };
                app.Contacts.Create(newContact);
            }
            if (GroupData.GetAll().Count() == 0)//если нет групп, то создаем
            {
                GroupData newGroup = new GroupData(GenerateRandomString(5))
                {
                    Header = GenerateRandomString(20),
                    Footer = GenerateRandomString(15)
                };
                app.Groups.Create(newGroup);
            }

            if (ContactData.GetContactNotInGroup() == null)
            {
                ContactData newContact = new ContactData(GenerateRandomString(6), GenerateRandomString(7))
                {
                    Address = GenerateRandomString(30),
                    Middlename = GenerateRandomString(5)
                };
                app.Contacts.Create(newContact);
            }
            ContactData addingContact = ContactData.GetContactNotInGroup();
            GroupData group = GroupData.GetAll()[0];
			List<ContactData> oldList = group.GetContacts();

			app.Contacts.AddContactToGroup(addingContact, group);

			List<ContactData> newList = group.GetContacts();
			oldList.Add(addingContact);
			newList.Sort();
			oldList.Sort();

			ClassicAssert.AreEqual(oldList, newList);
		}
	}
}

