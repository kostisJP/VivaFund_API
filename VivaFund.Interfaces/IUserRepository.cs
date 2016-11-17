using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByToken(Guid token);
        User InsertOrUpdateUser(User user);

        IEnumerable<ProjectCategory> GetAllProjectCategories();
        ProjectCategory GetProjectCategoryrById(int id);
        ProjectCategory GetProjectCategoryByToken(Guid token);
        ProjectCategory InsertOrUpdateProjectCategory(ProjectCategory projectCategory);

        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int id);
        Project InsertOrUpdateProject(Project project);
        
       
        IEnumerable<Donation> GetAllDonations();
        Donation GetDonationById(int id);
       
        Donation GetDonationByToken(Guid token);
        Donation InsertOrUpdateDonation(Donation donation);

  
        IEnumerable<Member> GetAllMembers();
        Member GetMemberById(int id);
        Member GetMemberByToken(Guid token);
        Member InsertOrUpdateMember(Member user);
       

        void UndoChanges();
    }
}
