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
            List<GroupData> groups = GroupData.GetAll(); //выбрали группу с индексом 0
            //List<ContactData> oldListContactsInGroup = group.GetContacts(); //запомнили старый список контактов в группе 

            int i = 0;
            int index = 0;
            do
            {
                index = i;
                i++;
            }
            while ((groups[index].GetContacts().Count == 0) && (i < groups.Count));

            if (i >= groups.Count) //если ни в одной группе нет контактов, то
            {
                Console.Out.WriteLine("Ни в одной группе не найдены контакты. Сначала добавте контакт хотябы в одну группу");
            }
            else
            {
                GroupData group = groups[index];
                List<ContactData> oldListContactsInGroup = group.GetContacts();
                ContactData deletingContactFromGroup = oldListContactsInGroup[0]; //контакт удаляемый из группы
                app.Contacts.DeleteContactFromGroup(deletingContactFromGroup, group);


                List<ContactData> newListContactsInGroup = group.GetContacts();
                oldListContactsInGroup.RemoveAt(0);
                newListContactsInGroup.Sort();
                oldListContactsInGroup.Sort();

                ClassicAssert.AreEqual(oldListContactsInGroup, newListContactsInGroup);
            } 
        }
	}
}

