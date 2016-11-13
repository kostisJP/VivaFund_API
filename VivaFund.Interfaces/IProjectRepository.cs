using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.Interfaces
{
    public interface IProjectRepository
    {

        void UndoChanges();
        IList<Member> GetAllmembers();
        Member GetMemberById(int id);
        void InsertOrUpdateMember(Member member);
        void InsertOrUpdateProject(Project project);
        Project GetProjectById(int id);
        IList<Project> GetAllProjects();
        IList<Project> GetProjectsByCategory(int categoryId);
        IList<Project> GetProjectsByMember(int memberId);
        IList<ProjectCategory> GetAllCategories();
        void InserOrUpdateDonation(Donation donation);
        IList<Donation> GetAllDonations();
        IList<Donation> GetAllDonationByProject(int projectId);
        IList<Donation> GetAllDonationByMember(int memberId);
        IList<Filter> GetAllFilters();
        IList<Filter> GetAllFiltersByType(int type);

    }
}
