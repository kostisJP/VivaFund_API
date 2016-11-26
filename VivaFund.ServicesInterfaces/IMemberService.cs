using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.ServicesInterfaces
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAllMembers();
        Member GetMemberById(string id);
        void SetMember(Member member);
    }
}
