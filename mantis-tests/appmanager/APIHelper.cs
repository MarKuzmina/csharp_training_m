using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBrowser.WebDriver;
using OpenQA.Selenium.Internal;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Mantis;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) {}

        public void CreateNewIssue(AccountData account, ProjectData projectData, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = projectData.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetAllProjectsWebService(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            List<ProjectData> listProjects = new List<ProjectData>();

            Mantis.ProjectData[] mantisListProjects = 
                client.mc_projects_get_user_accessible(account.Name, account.Password);

            foreach (Mantis.ProjectData mantisProject in mantisListProjects)
            {
                listProjects.Add(new ProjectData()
                { 
                    Name = mantisProject.name,
                    Description = mantisProject.description,
                    Id = mantisProject.id,
                });
            }
            return listProjects;
        }

        public void AddNewProjectWebService(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData mantisProject = new Mantis.ProjectData();
            mantisProject.name = projectData.Name;
            mantisProject.description = projectData.Description;
            client.mc_project_add(account.Name, account.Password, mantisProject);
        }
    }
}
