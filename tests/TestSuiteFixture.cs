using System;
using NUnit.Framework;
namespace webAddressbookTests.tests
{
	[SetUpFixture]
	public class TestSuiteFixture
	{
        [OneTimeSetUp]
		public void InitApplicationManager()
		{
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

		[OneTimeTearDown]
        public void StopApplicationManager()
        {
            ApplicationManager.GetInstance().Stop();
        }
	}
}

