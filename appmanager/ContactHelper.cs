﻿using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

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
            int index = v + 2;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
            FillContactForm(newContactData);
            SubmitContactModification();
            ReturnToContactPage();

            return this;
        }

        public ContactHelper Remove(int v)
        {
            SelectContact(v);
            RemoveContact();

            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCashe = null;
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
            int index = v + 2;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            manager.Navigator.GoToHomePage();
            contactCashe = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCashe = null;
            return this;
        }

        public bool IsContacstListNotEmpty()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.XPath("//tr[@name='entry']"));
        }

        private List<ContactData> contactCashe = null;

        public List<ContactData> GetContactList()
        {
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string eLastname = cells[1].Text;
                    string eFistname = cells[2].Text;
                    contactCashe.Add(new ContactData(eFistname, eLastname)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            
            return new List<ContactData>(contactCashe);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].
                FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                PhoneHomeNumber = homePhone,
                PhoneMobileNumber = mobilePhone,
                PhoneWorkNumber = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };
        }

        //получение данных со страницы с детализированной информацией о контакте
        public string GetContactInformationFromDetailsPage(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactShowDetails(index);
            string allDetails = driver.FindElement(By.Id("content")).Text;
            return CleanUpDetailInformation(allDetails);
        }

        //получение полных данных со страницы редактирования контакта
        internal string GetContactDetailInformationFromEdit(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string midlName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string faxNumber = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string details = firstName +
                midlName +
                lastName +
                nickName +
                title +
                company +
                address +
                homePhone +
                mobilePhone +
                workPhone +
                faxNumber +
                email +
                email2 +
                email3 +
                homePage;
            return CleanUpDetailInformation(details);
        }

        //очистка детализированной информации о контакте
        public string CleanUpDetailInformation(string details)
        {
            if (details == null || details == "")
            {
                return "";
            }

            string pattern = "(W:|H:|M:|F:|Homepage:|https://|http://| |\\n)";
            return Regex.Replace(details, pattern, "");
        }

        //переход на страницу детализировнной информации о контакте
        public void InitContactShowDetails(int index) 
        {
            driver.FindElements(By.Name("entry"))[index].
                FindElements(By.TagName("td"))[6].
                FindElement(By.TagName("a")).Click();
        }

        public void InitContactModification(int v)
        {
            driver.FindElements(By.Name("entry"))[v].
                FindElements(By.TagName("td"))[7].
                FindElement(By.TagName("a")).Click();
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return int.Parse(m.Value);
        }
    }
}

