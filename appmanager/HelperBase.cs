using OpenQA.Selenium;

namespace webAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        private ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
        
    }
}