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

namespace VivaFund.Controllers
{
    [RoutePrefix("api/project")]
    public class ProjectsController : ApiController
    {
        private readonly IUserRepository _userRepo;

        public ProjectsController()
        {
            _userRepo = ObjectFactory.GetInstance<IUserRepository>();
        }

        public ProjectsController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Project> GetAllCategories()
        {
            var allUsers = _userRepo.GetAllProjects();
            return allUsers;
            //return new StringContent(allUsers.ToString(), System.Text.Encoding.UTF8, "application/json");
        }

        [HttpGet]
        [Route("{id}")]
        public Project GetUserById(int id)
        {
            var user = _userRepo.GetProjectById(id);

            return user;
        }

        [HttpPost]
        [Route("save")]
        public Project SetCategory(Project user)
        {
            var _user = _userRepo.InsertOrUpdateProject(user);

            return _user;
        }
    }
}