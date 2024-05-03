using System;
namespace webAddressbookTests.tests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
		[Test]
		public void TestSearch()
		{
            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
		}
	}
}

