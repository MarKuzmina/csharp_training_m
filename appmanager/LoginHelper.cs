﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace webAddressbookTests
{
	public class LoginHelper : HelperBase
	{

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            //driver.FindElement(By.Name("user")).Click();
            //driver.FindElement(By.Name("user")).Clear();
            //driver.FindElement(By.Name("user")).SendKeys(account.Username);
            //driver.FindElement(By.Name("pass")).Click();
            //driver.FindElement(By.Name("pass")).Clear();
            //driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

	}
}

