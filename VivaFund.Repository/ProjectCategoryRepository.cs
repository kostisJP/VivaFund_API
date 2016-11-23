using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;

namespace VivaFund.Repository
{
    public class ProjectCategoryRepository : IProjectCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectCategory> GetAllProjectCategories()
        {

            var projectCategories = _context.ProjectCategories.ToList();
            return projectCategories;
        }

        public ProjectCategory GetProjectCategoryrById(int id)
        {
            var category = _context.ProjectCategories.FirstOrDefault(u => u.ProjectCategoryId == id);
            return category;

        }

        public ProjectCategory GetProjectCategoryByToken(Guid token)
        {

            var category = _context.ProjectCategories.FirstOrDefault(u => u.Token == token);
            return category;

        }

        public void InsertOrUpdateProjectCategory(ProjectCategory projectCategory)
        {
            try
            {
                projectCategory.UpdatedDate = DateTime.Now;
                if (_context.Members.Find(projectCategory.ProjectCategoryId) == null)
                {
                    _context.ProjectCategories.Add(projectCategory);

                    //_context.Entry(member).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(projectCategory).State = EntityState.Modified;
                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                            subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        Console.WriteLine(message);
                    }
                }
            }
        }

    }
}
