using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddProjectInMantisTests : AuthTestBase
    {
        [Test]
        public void TestAddProjectInMantis()
        {
            List<ProjectData> oldProjects = ProjectData.GetProjectsListDB();

            ProjectData projectData = new ProjectData(GenerateRandomString(7))
                {
                Description = GenerateRandomString(100)
                };

            app.ProjectManagement.CreateProject(projectData);

            List<ProjectData> newProjects = ProjectData.GetProjectsListDB();

            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(projectData);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
