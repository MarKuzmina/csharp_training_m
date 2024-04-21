using System;
using System.Diagnostics.Contracts;
using OpenQA.Selenium;

namespace webAddressbookTests
{
	public class ContactHelper : HelperBase
	{
		public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
		}

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();

            return this;
        }

        public ContactHelper Modify(int v, ContactData newContactData)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+v+"]/td[8]/a/img")).Click();
            FillContactForm(newContactData);
            SubmitContactModification();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Remove(string v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            RemoveContact();

            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.PhoneHomeNumber);
            Type(By.Name("mobile"), contact.PhoneMobileNumber);
            Type(By.Name("work"), contact.PhoneWorkNumber);
            Type(By.Name("fax"), contact.PhoneFaxNumber);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.UrlHomepage);
            //driver.FindElement(By.Name("firstname")).Click();
            //driver.FindElement(By.Name("firstname")).Clear();
            //driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            //driver.FindElement(By.Name("middlename")).Click();
            //driver.FindElement(By.Name("middlename")).Clear();
            //driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            //driver.FindElement(By.Name("lastname")).Click();
            //driver.FindElement(By.Name("lastname")).Clear();
            //driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            //driver.FindElement(By.Name("nickname")).Click();
            //driver.FindElement(By.Name("nickname")).Clear();
            //driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();

            return this;
        }

        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SelectContact(string v)
        {
            //driver.FindElement(By.XPath("xpath=//input[@id='"+ v +"']")).Click();
            driver.FindElement(By.Id(v)).Click();
            //driver.FindElement(By.XPath("//input[@id=\'"+v+"\']")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}

