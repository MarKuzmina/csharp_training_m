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
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            //InitNewContactCreation();
            ContactData contact = new ContactData("Александр", "Пушкин");
            //FillContactForm(contact);
            //SubmitContactCreation();
            app.Navigator.GoToContactsPage();
            //Logout();
        }
    }
}
