using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using StructureMap;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.Models;
using VivaFund.Repository;

namespace VivaFund.Controllers
{
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepo;

        public UserController()
        {
            _userRepo = ObjectFactory.GetInstance<IUserRepository>();
        }
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<User> GetAllUsers()
        {
            var allUsers = _userRepo.GetAllUsers();

            return allUsers;
        }

        [HttpGet]
        [Route("{id}")]
        public User GetUserById(int id)
        {
            var user = _userRepo.GetUserById(id);
            
            return user;
        }

    }
}
