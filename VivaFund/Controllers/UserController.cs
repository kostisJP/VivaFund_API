using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using VivaFund.Interfaces;
using VivaFund.Models;

namespace VivaFund.Controllers
{
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        private readonly IUserRepository userRepo;

        public UserController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllUsers()
        {
            var allUsers = userRepo.GetAllUsers();

            return Ok(Json(allUsers));
        }

        [HttpGet]
        [Route("{id}")]
        public User GetUserById(int id)
        {
            var user = userRepo.GetUserById(1);
            
            return user;
        }

    }
}
