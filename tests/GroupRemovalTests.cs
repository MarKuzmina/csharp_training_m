﻿namespace webAddressbookTests.tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
    
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
        }
    }
}
