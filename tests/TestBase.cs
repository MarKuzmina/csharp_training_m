using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using webAddressbookTests.tests;

namespace webAddressbookTests
{
    public class TestBase
    {  
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
        }

        /*
        protected void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        */
        

    }

    
}

