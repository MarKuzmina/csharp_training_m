using System;
using webAddressbookTests;
using NUnit.Framework.Legacy;

namespace webAddressbookTests
{
	public class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestDeleteContactFromGroup()
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

            int indexG;
            int indexC;
            app.Contacts.FindPairGroupContact(out indexG, out indexC);
            List<GroupData> groupsList = GroupData.GetAll();
            if (indexC==-1 && indexG==-1) //если нет подходящей пары, то создаем ее
            {
                ContactData deletedContact = ContactData.GetContactNotInGroup();//получаем первый контакт не входящий ни в одну группу
                app.Contacts.AddContactToGroup(deletedContact, groupsList[0]);
                List<ContactData> oldListContactsInGroup = groupsList[0].GetContacts();
                app.Contacts.FindPairGroupContact(out indexG, out indexC);

                app.Contacts.DeleteContactFromGroup(deletedContact, groupsList[0]);

                List<ContactData> newListContactsInGroup = groupsList[0].GetContacts();
                oldListContactsInGroup.RemoveAt(indexC);
                newListContactsInGroup.Sort();
                oldListContactsInGroup.Sort();

                ClassicAssert.AreEqual(oldListContactsInGroup, newListContactsInGroup);
            }
            else
            {
                ContactData deletedContact = groupsList[indexG].GetContacts()[indexC];
                List<ContactData> oldListContactsInGroup = groupsList[indexG].GetContacts();
                app.Contacts.DeleteContactFromGroup(deletedContact, groupsList[indexG]);

                List<ContactData> newListContactsInGroup = groupsList[indexG].GetContacts();
                oldListContactsInGroup.RemoveAt(indexC);
                newListContactsInGroup.Sort();
                oldListContactsInGroup.Sort();

                ClassicAssert.AreEqual(oldListContactsInGroup, newListContactsInGroup);
            }
        }
    }
}

