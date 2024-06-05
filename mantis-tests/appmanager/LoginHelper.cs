using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
	public class LoginHelper : HelperBase
	{

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn(account))
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout(account);
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }

        public void Logout(AccountData account)
        {
            if (IsLoggedIn(account))
            {
                driver.FindElement(By.XPath("//i[@class = 'fa fa-angle-down ace-icon']")).Click();
                driver.FindElement(By.XPath("//ul[@class = 'user-menu dropdown-menu dropdown-menu-right dropdown-yellow dropdown-caret dropdown-close']/li[4]")).Click();
            }
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsElementPresent(By.XPath("//span[@class='user-info'][text()='"+account.Name+"']"));
        }

       /* public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Name;
        }

        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            string userName = text.Substring(1, text.Length - 2);
            return userName;
        }*/
    }
}

