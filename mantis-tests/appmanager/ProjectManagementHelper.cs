using mantis_tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_test
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public ProjectManagementHelper CreateProject(ProjectData project)
        {
            manager.ManagementMenu.GoToManagePage();
            manager.ManagementMenu.GoToProjectManage();
            InitNewProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }

        public ProjectManagementHelper DeleteProject(string projectName)
        {
            manager.ManagementMenu.GoToManagePage();
            manager.ManagementMenu.GoToProjectManage();
            SelectProject(projectName);
            SubmitProjectDeleting();
            return this;
        }

        private void SubmitProjectDeleting()
        {
            driver.FindElement(By.XPath("//button[@formaction= 'manage_proj_delete.php']")).Click();
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();
        }

        private void SelectProject(string projectName)
        {
            //"//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr["+indexProject+"]/td/a"
            //driver.FindElement(By.XPath("//tr[" + indexProject + "]/td/a")).Click();
            driver.FindElement(By.LinkText(projectName)).Click();
            //By.LinkText
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            Type(By.Id("project-description"), project.Description);
        }

        public void InitNewProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type = 'submit']")).Click();
        }

        public List<ProjectData> GetListOfProjectsWebBrowser()
        {
            List<ProjectData> listProjects = new List<ProjectData>();
            manager.ManagementMenu.GoToManagePage();
            manager.ManagementMenu.GoToProjectManage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//table)[1]//tbody//tr"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                string eName = cells.ElementAt(0).Text;
                string eDescription = cells.ElementAt(4).Text;
                listProjects.Add(new ProjectData() { Name= eName, Description = eDescription });
            }
            return listProjects;
        }

        public bool IsProjectListNotEmpty()
        {
            if (ProjectData.GetProjectsListDB().Count() > 0) 
            { 
                return true;
            }
            return false;
        }
    }
}
