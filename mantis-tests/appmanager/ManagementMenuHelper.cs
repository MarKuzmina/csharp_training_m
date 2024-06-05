using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }
        public void GoToManagePage()
        {
            if (! IsElementPresent(By.XPath("//i[@class='fa fa-gears menu-icon']")))
            { 
                driver.FindElement(By.Id("menu-toggler")).Click();
                driver.FindElement(By.XPath("//span[@class='menu-text'][text() = ' Управление ']")).Click(); 
            }
            driver.FindElement(By.XPath("//i[@class='fa fa-gears menu-icon']")).Click();
        }

        public void GoToProjectManage()
        {
            driver.FindElement(By.XPath("//ul[@class='nav nav-tabs padding-18']/li/a[text() = 'Проекты']")).Click();
        }
    }
}
