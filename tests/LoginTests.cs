﻿using System;
using NUnit.Framework.Legacy;

namespace webAddressbookTests.tests
{
    [TestFixture]
    public class LoginTests : TestBase
	{
		[Test]
		public void LoginWithValidCredentials()
		{
			//подготовка
			app.Auth.Logout();

			//действие
			AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

			//проверка
            ClassicAssert.IsTrue(app.Auth.IsLoggedIn(account));
		}

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //подготовка
            app.Auth.Logout();

            //действие
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);

            //проверка
            ClassicAssert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}

