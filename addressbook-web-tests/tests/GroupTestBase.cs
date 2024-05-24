using System;
using NUnit.Framework.Legacy;

namespace webAddressbookTests
{
	public class GroupTestBase : AuthTestBase
    {
		[TearDown]
		public void CompareGroupsUI_DB()
		{
			if (PERFORM_LONG_UI_CHEKS)
            {
                List<GroupData> fromUI = app.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                ClassicAssert.AreEqual(fromUI, fromDB);
            }
        }
	}
}

