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
        
        void UndoChanges();
      
    }
}
