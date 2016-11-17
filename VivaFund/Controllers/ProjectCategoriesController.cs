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
    [RoutePrefix("api/category")]
    public class ProjectCategoriesController : ApiController
    {
        private readonly IUserRepository _userRepo;

        public ProjectCategoriesController()
        {
            _userRepo = ObjectFactory.GetInstance<IUserRepository>();
        }
        public ProjectCategoriesController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<ProjectCategory> GetAllCategories()
        {
            var allUsers = _userRepo.GetAllProjectCategories();
            return allUsers;
            //return new StringContent(allUsers.ToString(), System.Text.Encoding.UTF8, "application/json");
        }

        [HttpGet]
        [Route("{id}")]
        public ProjectCategory GetUserById(int id)
        {
            var user = _userRepo.GetProjectCategoryrById(id);

            return user;
        }
        [HttpPost]
        [Route("save")]
        public ProjectCategory SetCategory(ProjectCategory user)
        {
            var _user = _userRepo.InsertOrUpdateProjectCategory(user);

            return _user;
        }
    }
}