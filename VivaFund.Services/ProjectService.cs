using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.Repository;
using VivaFund.ServicesInterfaces;

namespace VivaFund.Services
{
    public class ProjectService : IProjectService 
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectCategoryRepository _projectCategoryRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IDonationRepository _donationRepository;
        private readonly IFilterRepository _filterRepository;
        private readonly IRewardRepository _rewardRepository;


        public ProjectService()
        {
            _projectRepository = new ProjectRepository();
            _projectCategoryRepository = new ProjectCategoryRepository();
            _memberRepository = new MemberRepository();
            _donationRepository = new DonationRepository();
            _filterRepository = new FilterRepository();
            _rewardRepository = new RewardRepository();

        }
        public ProjectService(IProjectRepository projectRepository, IProjectCategoryRepository projectCategoryRepository)
        {
            _projectRepository = projectRepository;
            _projectCategoryRepository = projectCategoryRepository;
            
        }

        #region PROJECTCATEGORY
        public IEnumerable<ProjectCategory> GetAllCategories()
        {
            var allProjectCategories = _projectCategoryRepository.GetAllProjectCategories();
            return allProjectCategories;
        }
        public ProjectCategory GetProjectCategoryById(int id)
        {
            var projectCategory = _projectCategoryRepository.GetProjectCategoryrById(id);

            return projectCategory;
        }
        public ProjectCategory SetCategory(ProjectCategory projectCategory)
        {
            _projectCategoryRepository.InsertOrUpdateProjectCategory(projectCategory);
            return projectCategory;
        }
        #endregion PROJECTCATEGORY

        #region PROJECT
        public IEnumerable<Project> GetAllProjects()
        {
            var allProjects = _projectRepository.GetAllProjects();
            return allProjects;
        }
        public Project GetProjectById(int id)
        {
            var project = _projectRepository.GetProjectById(id);
            return project;
        }
       public void SetProject(Project project)
        {
            _projectRepository.InsertOrUpdateProject(project);
           // return projectCategory;
        }
        #endregion PROJECT


    }
}
