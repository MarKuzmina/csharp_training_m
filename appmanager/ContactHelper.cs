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
            manager.Navigator.GoToHomePage();
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();

            return this;
        }

        public ContactHelper Modify(int v, ContactData newContactData)
        {
            if (IsContacstListNotEmpty())
            {
                int index = v + 1;
                driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
                FillContactForm(newContactData);
                SubmitContactModification();
                ReturnToContactPage();
            }
            else
            {
                ContactData contact = new ContactData("Дмитрий", "Петрович");
                Create(contact);
                Modify(v,newContactData);
            }
            return this;
        }

        public ContactHelper Remove(int v)
        {
            if (IsContacstListNotEmpty())
            {
                SelectContact(v);
                RemoveContact();
            }
            else
            {
                ContactData contact = new ContactData("Для удаления", "Контакт");
                Create(contact);
                Remove(v);
            }

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

        public ContactHelper SelectContact(int v)
        {
            int index = v + 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
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

        public bool IsContacstListNotEmpty()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.XPath("//tr[@name='entry']"));
            //tr[@name='entry']
            //img[@title='Edit']
        }
    }
}

