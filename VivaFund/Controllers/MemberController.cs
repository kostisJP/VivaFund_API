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
    [RoutePrefix("api/member")]
    public class MemberController : ApiController
    {
        private readonly IProjectRepository _userRepo;

        public MemberController()
        {
            _userRepo = ObjectFactory.GetInstance<IProjectRepository>();
        }
        public MemberController(IProjectRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Member> GetAllMembers()
        {
            var allUsers = _userRepo.GetAllMembers();
            return allUsers;
            //return new StringContent(allUsers.ToString(), System.Text.Encoding.UTF8, "application/json");
        }

        [HttpGet]
        [Route("{id}")]
        public Member GetMemberById(int id)
        {
            var user = _userRepo.GetMemberById(id);

            return user;
        }
        [HttpPost]
        [Route("save")]
        public Member SetMember(Member user)
        {
            _userRepo.InsertOrUpdateMember(user);

            return user;
        }
    }
}