using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using StructureMap;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.Models;
using VivaFund.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace VivaFund.Controllers
{
    [RoutePrefix("api/user")]
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
            //return new StringContent(allUsers.ToString(), System.Text.Encoding.UTF8, "application/json");
        }

        [HttpGet]
        [Route("{id}")]
        public User GetUserById(int id)
        {
            var user = _userRepo.GetUserById(id);
            
            return user;
        }
        [HttpPost]
        [Route("save")]
        public User SetUser(User user)
        {
            var _user = _userRepo.SaveUser(user);

            return _user;
        }
    }
}
