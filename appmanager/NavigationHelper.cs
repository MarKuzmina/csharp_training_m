using OpenQA.Selenium;

namespace webAddressbookTests
{
    public class NavigationHelper : HelperBase
	{
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/index.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/index.php");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
            //driver.Navigate().GoToUrl(baseURL + "/addressbook/group.php");
        }
    }
}

