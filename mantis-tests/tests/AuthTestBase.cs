using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void AuthTestBaseTest()
        {
            app.LoginH.Login(new AccountData()
            { Name = "administrator", Password = "root" });
        }
    }
}
