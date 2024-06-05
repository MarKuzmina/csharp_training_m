using System;
using OpenQA.Selenium;
using System.Text;
using OpenQA.Selenium.Firefox;
using System.IO;
using mantis_test;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public LoginHelper LoginH { get; set; }
        public ManagementMenuHelper ManagementMenu { get; set; }
        public ProjectManagementHelper ProjectManagement { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            LoginH = new LoginHelper(this);
            ManagementMenu = new ManagementMenuHelper(this);
            ProjectManagement = new ProjectManagementHelper(this);
        }

        //деструктор
        ~ApplicationManager()
         {
             try
             {
                 driver.Quit();
             }
             catch (Exception)
             {
                 // Ignore errors if unable to close the browser
             }
         }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt/mantisbt-2.26.2/login_page.php";
                //newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}

