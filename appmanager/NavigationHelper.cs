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
            driver.Navigate().GoToUrl(baseURL + "/addressbook/index.php");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.Navigate().GoToUrl(baseURL + "/addressbook/group.php");
        }

        public void GoToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            driver.Navigate().GoToUrl(baseURL + "/addressbook/group.php");
        }
    }
}

