using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginTest()
        {
            AccountData account = new AccountData()
            { Name = "administrator", Password = "root" };
            app.LoginH.Login(account);
            Assert.IsTrue(app.LoginH.IsLoggedIn(account));
        }
    }
}
