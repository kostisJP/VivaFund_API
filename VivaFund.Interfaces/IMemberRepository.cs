using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.Interfaces
{
    public interface IMemberRepository
    {
        Member GetMemberById(int id);
        IEnumerable<Member> GetAllMembers();
        Member GetMemberByToken(Guid token);
        void InsertOrUpdateMember(Member user);

    }
}
