using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace mantis_tests
{
    internal class AddProjectWithWebServiceTests : TestBase
    {
        [Test]
        public void TestAddProjectWithWebServise()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            List<ProjectData> oldProjects = app.API.GetAllProjectsWebService(account);

            ProjectData projectData = new ProjectData()
            {
                Name = GenerateRandomString(7),
                Description = GenerateRandomString(100)
            };

            app.ProjectManagement.CreateProject(projectData);

            List<ProjectData> newProjects = app.API.GetAllProjectsWebService(account);

            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(projectData);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
