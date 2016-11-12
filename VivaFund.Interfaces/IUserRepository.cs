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
        User SaveUser(User user);
        void UndoChanges();
        void SaveProject(Project project);
        Project GetProjectById(int id);
        IList<Project> GetAllProjects();
        IList<Project> GetProjectsByCategory(int categoryId);
    }
}
