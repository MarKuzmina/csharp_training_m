using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTest() 
        {
            AccountData account = new AccountData()
            { Name = "administrator",
            Password = "root"};
            IssueData issueData = new IssueData()
            { Summary = "summary test text",
            Description = "long test text",
            Category = "General"};
            List<ProjectData> projectList = ProjectData.GetProjectsListDB();
            ProjectData projectData = projectList.First();

            app.API.CreateNewIssue(account, projectData, issueData);
        }
    }
}
