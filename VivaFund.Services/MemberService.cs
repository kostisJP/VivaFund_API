using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.ServicesInterfaces;

namespace VivaFund.Services
{
    public class MemberService : IMemberService 
    {
        private readonly IMemberRepository _memberRepo;
       
        public MemberService(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            var allUsers = _memberRepo.GetAllMembers();
            return allUsers;
        }

        public Member GetMemberById(string id)
        {
            var member = _memberRepo.GetMemberById(id);

            return member;
        }     

        public void SetMember(Member member)
        {
            _memberRepo.InsertOrUpdateMember(member);
            
        }
    }
}
