using System;
using OpenQA.Selenium;

//using webAddressbookTests;

namespace webAddressbookTests
{
	public class GroupHelper : HelperBase
	{

        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData oldGroupData, GroupData newGroupData)
        {
            SelectGroup(oldGroupData.Id);
            InitGroupModification();
            FillGroupForm(newGroupData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id=\'content\']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+ id +"'])")).Click();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCashe = null;
            return this;
        }

        public bool IsGroupsPage()
        {
            return IsElementPresent(By.XPath("//h1[text()='Groups']"));
        }

        public bool IsGroupListNotEmpty()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.XPath("//input[@type='checkbox']"));
        }

        private List<GroupData> groupCashe = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCashe == null)
            {
                groupCashe = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCashe.Add(new GroupData(element.Text) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupCashe);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}

