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
    [RoutePrefix("api/member")]
    public class MemberController : ApiController
    {
        private readonly IMemberService _memberService;

     
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Member> GetAllMembers()
        {
            var allmembers = _memberService.GetAllMembers();
            return allmembers;
        }

        [HttpGet]
        [Route("{id}")]
        public Member GetMemberById(int id)
        {
            var member = _memberService.GetMemberById(id);

            return member;
        }
        [HttpPost]
        [Route("save")]
        public Member SetMember(Member member)
        {
            _memberService.SetMember(member);

            return member;
        }
    }
}