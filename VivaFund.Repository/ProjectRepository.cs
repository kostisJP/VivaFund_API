﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public void SaveProject(Project project)
        {
            try
            {
                if (_context.Projects.Find(project.ProjectId) == null)
                {
                    _context.Projects.Add(project);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public Project GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Project> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public IList<Project> GetProjectsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

    }
}