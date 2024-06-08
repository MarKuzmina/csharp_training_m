using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class DeleteProjectWithWebService : TestBase
    {

        [Test]
        public void TestDeleteProjectFromMantis()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            if (app.API.GetAllProjectsWebService(account).Count > 0)
            {
                ProjectData newProject = new ProjectData()
                {
                    Name = GenerateRandomString(7),
                    Description = GenerateRandomString(100)
                };
                app.ProjectManagement.CreateProject(newProject);
            }

            List<ProjectData> oldProjects = app.API.GetAllProjectsWebService(account);
            ProjectData toBeDeleted = oldProjects[0];

            app.ProjectManagement.DeleteProject(toBeDeleted.Name);

            List<ProjectData> newProjects = app.API.GetAllProjectsWebService(account);

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
               Assert.AreNotEqual(project.Id, toBeDeleted.Id);
            }
        }
    }
}
