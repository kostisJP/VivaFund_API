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
        
        public ProjectService(IProjectRepository projectRepository 
                        ,IProjectCategoryRepository projectCategoryRepository
                        ,IMemberRepository memberRepository
                        ,IDonationRepository donationRepository
                        ,IFilterRepository filterRepository
                        ,IRewardRepository rewardRepository)
        {
            _projectRepository = projectRepository;
            _projectCategoryRepository = projectCategoryRepository;
            _memberRepository = memberRepository;
            _donationRepository = donationRepository;
            _filterRepository = filterRepository;
            _rewardRepository = rewardRepository;
            
        }

        #region PROJECTCATEGORY
        public IEnumerable<ProjectCategory> GetAllCategories()
        {
            try
            {
                var allProjectCategories = _projectCategoryRepository.GetAllProjectCategories();

                return allProjectCategories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProjectCategory GetProjectCategoryById(int id)
        {
            try
            {
                var projectCategory = _projectCategoryRepository.GetProjectCategoryrById(id);

                return projectCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProjectCategory SetCategory(ProjectCategory projectCategory)
        {
            try
            {
                _projectCategoryRepository.InsertOrUpdateProjectCategory(projectCategory);

                return projectCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion PROJECTCATEGORY

        #region PROJECT
        public IEnumerable<Project> GetAllProjects()
        {
            try
            {
                var allProjects = _projectRepository.GetAllProjects();
                
                return allProjects;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        public Project GetProjectById(int id)
        {
            try
           {
                var project = _projectRepository.GetProjectById(id);

                return project;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       public void SetProject(Project project)
        {
            try
            {
                _projectRepository.InsertOrUpdateProject(project);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException);
            }
        }
        #endregion PROJECT


    }
}
