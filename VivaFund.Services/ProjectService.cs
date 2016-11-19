using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.ServicesInterfaces;

namespace VivaFund.Services
{
    public class ProjectService : IProjectService 
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IProjectCategoryRepository _projectCategoryRepo;
        public ProjectService(IProjectRepository projectRepo, IProjectCategoryRepository projectCategoryRepo)
        {
            _projectRepo = projectRepo;
            _projectCategoryRepo = projectCategoryRepo;
        }

        #region PROJECTCATEGORY
        public IEnumerable<ProjectCategory> GetAllCategories()
        {
            var allProjectCategories = _projectCategoryRepo.GetAllProjectCategories();
            return allProjectCategories;
        }
        public ProjectCategory GetProjectCategoryById(int id)
        {
            var projectCategory = _projectCategoryRepo.GetProjectCategoryrById(id);

            return projectCategory;
        }
        public ProjectCategory SetCategory(ProjectCategory projectCategory)
        {
            _projectCategoryRepo.InsertOrUpdateProjectCategory(projectCategory);
            return projectCategory;
        }
        #endregion PROJECTCATEGORY

        #region PROJECT
        public IEnumerable<Project> GetAllProjects()
        {
            var allProjects = _projectRepo.GetAllProjects();
            return allProjects;
        }
        public Project GetProjectById(int id)
        {
            var project = _projectRepo.GetProjectById(id);
            return project;
        }
       public void SetProject(Project project)
        {
            _projectRepo.InsertOrUpdateProject(project);
           // return projectCategory;
        }
        #endregion PROJECT


    }
}
