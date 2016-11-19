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
        Member GetMemberById(int id);
        IList<Member> GetAllMembers();
        Member GetMemberByToken(Guid token);
        void InsertOrUpdateMember(Member user);

        IList<Project> GetAllProjects();
        IList<Project> GetProjectsByCategory(int categoryId);
        IList<Project> GetProjectsByMember(int memberId);
        Project GetProjectById(int id);
        void InsertOrUpdateProject(Project project);

        IList<ProjectCategory> GetAllProjectCategories();
        ProjectCategory GetProjectCategoryrById(int id);
        ProjectCategory GetProjectCategoryByToken(Guid token);
        void InsertOrUpdateProjectCategory(ProjectCategory projectCategory);

        IList<Donation> GetAllDonations();
        Donation GetDonationById(int id);
        IList<Donation> GetAllDonationByProject(int projectId);
        IList<Donation> GetAllDonationByMember(int memberId);
        void InsertOrUpdateDonation(Donation donation);

        IList<Reward> GetAllRewards();
        IList<Reward> GetAllRewardsByProjectId(int id);
        void InsertOrUpdateReward(Reward reward);

        IList<Filter> GetAllFilters();
        IList<Filter> GetAllFiltersByType(int type);

    }
}
