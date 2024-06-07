using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBrowser.WebDriver;
using OpenQA.Selenium.Internal;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseURL;

        public AdminHelper(ApplicationManager manager, string baseURL) : base(manager) 
        { this.baseURL = baseURL; }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.XPath("(//table)[1]//tbody//tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string eName = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                accounts.Add(new AccountData() { 
                    Name = eName,
                    Id = id });
            }
            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.XPath("//form[@id='manage-user-delete-form']/button")).Click();
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = baseURL + "/login_page.php";

            driver.FindElement(By.Name("username")).SendKeys("administrotor");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.Name("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();

            return driver;
        }
    }
}
