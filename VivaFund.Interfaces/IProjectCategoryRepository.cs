using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.Interfaces
{
    public interface IProjectCategoryRepository
    {
        IEnumerable<ProjectCategory> GetAllProjectCategories();
        ProjectCategory GetProjectCategoryrById(int id);
        ProjectCategory GetProjectCategoryByToken(Guid token);
        void InsertOrUpdateProjectCategory(ProjectCategory projectCategory);

    }
}
