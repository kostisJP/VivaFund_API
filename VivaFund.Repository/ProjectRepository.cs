using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
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

        public IEnumerable<Project> Recommended(int memberId)
        {
            string query = @"SELECT DISTINCT * FROM Projects WHERE Memberid <> {0}
                                    AND Projects.IsActive = 1 AND Projects.ExpirationDate >= GETDATE()
                            EXCEPT 
                            SELECT Projects.* FROM Projects
                            INNER JOIN Donations ON donations.ProjectId = Projects.ProjectId
                            WHERE Donations.MemberId = {0}";
            query = String.Format(query, memberId);
            var recProjects = _context.Database.SqlQuery<Project>(query).ToList();

            return recProjects;
        }
        public Project GetProjectById(int id)
        {
            var project = _context.Projects.Include(x => x.ProjectCategory)
                            .Include(x=>x.Member)
                            .Single(u => u.ProjectId == id);

            return project;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var project = _context.Projects
                .Include(x => x.Member)
                .Include(x => x.ProjectCategory)
                //.Include(x => x.Donations)
                .Where(p => p.IsActive == true && p.ExpirationDate>=DateTime.Now).Distinct()
                .ToList();

            return project;
        }

        public IEnumerable<Project> GetProjectsByCategory(int categoryId)
        {
            var project = _context.Projects.Where(u => u.ProjectCategoryId == categoryId && u.IsActive == true && u.ExpirationDate >= DateTime.Now).ToList();

            return project;
        }

        public IEnumerable<Project> GetProjectsByMember(int memberId)
        {
            var project = _context.Projects.Where(u => u.MemberId == memberId && u.IsActive == true && u.ExpirationDate >= DateTime.Now).ToList();

            return project;
        }

        public IEnumerable<ProjectMedia> GetProjectMediaByProjectId(int projectId)
        {
            var projectMedia = _context.ProjectMedia.Where(p => p.ProjectId == projectId).ToList();

            return projectMedia;
        }

        public IEnumerable<Comment> GetCommentsByProjectId(int projectId)
        {
            var comments = _context.Comments.Where(c => c.ProjectId == projectId).ToList();

            return comments;
        }

        public void InsertOrUpdateProject(Project project)
        {

            project.UpdatedDate = DateTime.Now;
            //if (_context.Projects.Find(project.ProjectId) == null)
            //{
            //    _context.Projects.Add(project);

            //    //_context.Entry(member).State = EntityState.Added;
            //}
            //else
            //{
            //    _context.Entry(project).State = EntityState.Modified;
            //}
            _context.Set<Project>().AddOrUpdate(project);
            _context.SaveChanges();
        }
    }
}
