using System;
namespace webAddressbookTests
{
	public class AuthTestBase : TestBase
	{
		public AuthTestBase()
		{
		}

        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}

