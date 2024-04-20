using System;
using System.Diagnostics.Contracts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
    
        [Test]
        public void GroupRemovalTest()
        {
            
            app.Navigator.GoToGroupsPage();
            app.Groups
                .SelectGroup(1)
                .RemoveGroup()
                .ReturnToGroupPage();
        }
    }
}
