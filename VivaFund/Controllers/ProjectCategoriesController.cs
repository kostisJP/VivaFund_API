using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StructureMap;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.Repository;
using VivaFund.ServicesInterfaces;

namespace VivaFund.Controllers
{
    [RoutePrefix("api/category")]
    public class ProjectCategoriesController : ApiController
    {
        private readonly IProjectService _projectService ;

    
        public ProjectCategoriesController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<ProjectCategory> GetAllCategories()
        {
            var allCategories = _projectService.GetAllCategories();
            return allCategories;
            //return new StringContent(allUsers.ToString(), System.Text.Encoding.UTF8, "application/json");
        }

        [HttpGet]
        [Route("{id}")]
        public ProjectCategory GetProjectCategoryById(int id)
        {
            var projectCategory = _projectService.GetProjectCategoryById(id);

            return projectCategory;
        }
        [HttpPost]
        [Route("save")]
        public ProjectCategory SetCategory(ProjectCategory projectCategory)
        {
            _projectService.SetCategory(projectCategory);

            return projectCategory;
        }
    }
}