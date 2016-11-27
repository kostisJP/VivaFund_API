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
    [RoutePrefix("api/project")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectService _projectService;

    

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Project> GetAllProjects()
        {
            var projects = _projectService.GetAllProjects();

            return projects;
        }
        [HttpGet]
        [Route("Category/{id}")]
        public IEnumerable<Project> GetAllProjectsByCategory(int id)
        {
            var projects = _projectService.GetAllProjects().Where(u=>u.ProjectCategoryId==id);

            return projects;
        }
        [HttpGet]
        [Route("{id}")]
        public Project GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);

            return project;
        }

        [HttpPost]
        [Route("save")]
        public Project SetProject(Project project)
        {
             _projectService.SetProject(project);

            return project;
        }
    }
}