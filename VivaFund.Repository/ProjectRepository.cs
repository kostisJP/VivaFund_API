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
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository()
        {
            _context = new ApplicationDbContext();
        }

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void UndoChanges()
        {
            // https://code.msdn.microsoft.com/How-to-undo-the-changes-in-00aed3c4
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    // Under the covers, changing the state of an entity from  
                    // Modified to Unchanged first sets the values of all  
                    // properties to the original values that were read from  
                    // the database when it was queried, and then marks the  
                    // entity as Unchanged. This will also reject changes to  
                    // FK relationships since the original value of the FK  
                    // will be restored. 
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    // If the EntityState is the Deleted, reload the data from the database.   
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
      

        public Project GetProjectById(int id)
        {
            try
            {
                var project = _context.Projects.Single(u => u.ProjectId == id);

                return project;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }

        }

        public IEnumerable<Project> GetAllProjects()
        {
            try
            {
                var project = _context.Projects
                    .Include(x => x.Member)
                    .Include(x => x.ProjectCategory)
                    .ToList();

                return project;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }

        }

        public IEnumerable<Project> GetProjectsByCategory(int categoryId)
        {
            try
            {
                var project = _context.Projects.Where(u => u.ProjectCategoryId == categoryId).ToList();

                return project;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public IEnumerable<Project> GetProjectsByMember(int memberId)
        {
            try
            {
                var project = _context.Projects.Where(u => u.MemberId == memberId).ToList();

                return project;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }
        public void InsertOrUpdateProject(Project project)
        {
            try
            {
                project.UpdatedDate = DateTime.Now;
                if (_context.Projects.Find(project.ProjectId) == null)
                {
                    _context.Projects.Add(project);

                    //_context.Entry(member).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(project).State = EntityState.Modified;
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
