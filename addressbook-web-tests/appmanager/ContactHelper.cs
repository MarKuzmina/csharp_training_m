using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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

        public ContactHelper Modify(ContactData oldData, ContactData newContactData)
        {
            ClickEditLink(oldData);
            FillContactForm(newContactData);
            SubmitContactModification();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper ClickEditLink(ContactData contact)
        {
            driver.FindElement(By.XPath("//a[contains(@href,'edit.php?id="+ contact.Id + "')]")).Click();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            SelectContact(v);
            RemoveContact();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            SelectContact(contact.Id);
            RemoveContact();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            manager.Navigator.GoToHomePage();
            contactCashe = null;
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

        public void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        /*public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+ id +"'])")).Click();
            return this;
        }*/

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
            return allDetails;
        }

        //получение полных данных со страницы редактирования контакта
        internal string GetContactDetailInformationFromEdit(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value").Trim();
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value").Trim();
            string midlName = driver.FindElement(By.Name("middlename")).GetAttribute("value").Trim();
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value").Trim();

            string title = driver.FindElement(By.Name("title")).GetAttribute("value").Trim();

            string company = driver.FindElement(By.Name("company")).GetAttribute("value").Trim();

            string address = driver.FindElement(By.Name("address")).GetAttribute("value").Trim();

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value").Trim();
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value").Trim();
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value").Trim();
            string faxNumber = driver.FindElement(By.Name("fax")).GetAttribute("value").Trim();

            string email = driver.FindElement(By.Name("email")).GetAttribute("value").Trim();
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value").Trim();
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value").Trim();

            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value").Trim();

            ContactData contactDataEdit = new ContactData(firstName, lastName)
            {
                Firstname = firstName,
                Lastname = lastName,
                Middlename = midlName,
                Nickname = nickName,
                Title = title,
                Company = company,
                Address = address,
                PhoneHomeNumber = homePhone,
                PhoneMobileNumber = mobilePhone,
                PhoneWorkNumber = workPhone,
                PhoneFaxNumber = faxNumber,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                UrlHomepage = homePage
            };

            return ConcatContactDetailInformation(contactDataEdit);
        }

        internal string ConcatContactDetailInformation(ContactData data)
        {
            //блок 1
            string fullNameContactInfo = "";
            if (data.FullName != ""){ fullNameContactInfo = Regex.Replace(data.FullName,"  ", " ") + "\n"; }
            if (data.Nickname != "") { fullNameContactInfo = fullNameContactInfo + data.Nickname + "\n"; }
            if (data.Title != "") { fullNameContactInfo = fullNameContactInfo + data.Title + "\n"; }
            if (data.Company != "") { fullNameContactInfo = fullNameContactInfo + data.Company + "\n"; }
            if (data.Address != "") { fullNameContactInfo = fullNameContactInfo + data.Address + "\n"; }

            //блок 2
            string phones = "";
            if (data.PhoneHomeNumber!="") { phones = phones + "H: " + data.PhoneHomeNumber + "\n"; }
            if (data.PhoneMobileNumber != "") { phones = phones + "M: " + data.PhoneMobileNumber + "\n"; }
            if (data.PhoneWorkNumber != "") { phones = phones + "W: " + data.PhoneWorkNumber + "\n"; }
            if (data.PhoneFaxNumber != "") { phones = phones + "F: " + data.PhoneFaxNumber + "\n"; }
            
            //блок 3
            string homepage = "";
            if (data.UrlHomepage != ""){ homepage = "Homepage:\n" + data.UrlHomepage;}
            string emailsHomepage = (data.AllEmails + "\n" + homepage).Trim();

            //склеиваем все вместе
            string detailInformation = "";
            if (fullNameContactInfo != "")
            {
                detailInformation = detailInformation + fullNameContactInfo;
                if (phones == "" & emailsHomepage =="") { detailInformation = detailInformation.Trim(); }
            }

            if (detailInformation != "" & phones != "") { detailInformation = detailInformation + "\n"; }

            if (phones != "")
            {
                detailInformation = detailInformation + phones;
                if (emailsHomepage == "") { detailInformation = detailInformation.Trim(); }
            }

            if (detailInformation != "" & emailsHomepage != "") { detailInformation = detailInformation + "\n"; }

            if (emailsHomepage != "")
            {
                detailInformation = detailInformation + emailsHomepage;
            }

            return detailInformation;
        }

        //очистка детализированной информации о контакте
        /* public string CleanUpDetailInformation(string details)
         {
             if (details == null || details == "")
             {
                 return "";
             }

             string pattern = "(W:|H:|M:|F:|Homepage:|https://|http://| |\\n)";
             return Regex.Replace(details, pattern, "");
         }*/

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

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void DeleteContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectGroup(group.Name);
            SelectContact(contact.Id);
            CommitDeleteContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void SelectGroup(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        private void CommitDeleteContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(groupName);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
    }
}

