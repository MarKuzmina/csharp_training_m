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
        private string baseURL;
        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager) 
        { this.baseURL = baseURL; }
        public void GoToManagePage()
        {
            if ((driver.Url == baseURL + "/mantisbt/mantisbt-2.26.2/manage_overview_page.php") && IsElementPresent(By.XPath("//i[@class = 'fa fa-info ace-icon']"))) 
            { return; }
            if (! IsElementPresent(By.XPath("//i[@class='fa fa-gears menu-icon']")))
            { 
                driver.FindElement(By.Id("menu-toggler")).Click();
                driver.FindElement(By.XPath("//span[@class='menu-text'][text() = ' Управление ']")).Click(); 
            }
            driver.FindElement(By.XPath("//i[@class='fa fa-gears menu-icon']")).Click();
        }

        public void GoToProjectManage()
        {
            if ((driver.Url == baseURL + "/mantisbt/mantisbt-2.26.2/manage_proj_page.php") && IsElementPresent(By.XPath("//form[@action = 'manage_proj_create_page.php']")))
            {
                return;            
            }
            driver.FindElement(By.XPath("//ul[@class='nav nav-tabs padding-18']/li/a[text() = 'Проекты']")).Click();
        }
    }
}
