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
			GroupData group = GroupData.GetAll()[0];
			List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

			app.Contacts.AddContactToGroup(contact, group);

			List<ContactData> newList = group.GetContacts();
			oldList.Add(contact);
			newList.Sort();
			oldList.Sort();

			ClassicAssert.AreEqual(oldList, newList);
		}
	}
}

