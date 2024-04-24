using System;
using OpenQA.Selenium;
using webAddressbookTests.tests;

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
            if (IsGroupListNotEmpty())
            {
                SelectGroup(v);
                InitGroupModification();
                FillGroupForm(newData);
                SubmitGroupModification();
                ReturnToGroupPage();
            }
            else
            {
                GroupData group = new GroupData("группа для модификации");
                Create(group);
                Modify(v, newData);
            }

            return this;
        }

        public GroupHelper Remove(int v)
        {
            if (IsGroupListNotEmpty())
            {
                SelectGroup(v);
                RemoveGroup();
                ReturnToGroupPage();
            }
            else
            {
                GroupData group = new GroupData("группа для удаления");
                group.Header = "xxx";
                group.Footer = "vvv";
                Create(group);
                Remove(v);
            }
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
            driver.FindElement(By.XPath("//div[@id=\'content\']/form/span[" + index + "]/input")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
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

    }
}

