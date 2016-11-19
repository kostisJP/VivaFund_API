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
        #region MEMBER
        public Member GetMemberById(int id)
        {
            try
            {
                var member = _context.Members.Single(u => u.MemberId == id);

                return member;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }

        }

        public IList<Member> GetAllMembers()
        {
            try
            {
                var member = _context.Members.ToList();

                return member;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public Member GetMemberByToken(Guid token)
        {
            try
            {
                var member = _context.Members.FirstOrDefault(u => u.Token == token);
                return member;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public void InsertOrUpdateMember(Member member)
        {
            try
            {
                member.UpdatedDate = DateTime.Now;
                if (_context.Users.Find(member.MemberId) == null)
                {
                    _context.Members.Add(member);

                    //_context.Entry(member).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(member).State = EntityState.Modified;
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
        #endregion MEMBER
        #region PROJECTCATEGORY
        public IList<ProjectCategory> GetAllProjectCategories()
        {
            try
            {
                var projectCategories = _context.ProjectCategories.ToList();

                return projectCategories;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public ProjectCategory GetProjectCategoryrById(int id)
        {
            try
            {
                var category = _context.ProjectCategories.FirstOrDefault(u => u.ProjectCategoryId == id);
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public ProjectCategory GetProjectCategoryByToken(Guid token)
        {
            try
            {
                var category = _context.ProjectCategories.FirstOrDefault(u => u.Token == token);
                return category;
            }catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public void InsertOrUpdateProjectCategory(ProjectCategory projectCategory)
        {
            try
            {
                projectCategory.UpdatedDate = DateTime.Now;
                if (_context.Users.Find(projectCategory.ProjectCategoryId) == null)
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
        #endregion PROJECTCATEGORY
        #region PROJECT
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

        public IList<Project> GetAllProjects()
        {
            try
            {
                var project = _context.Projects.ToList();

                return project;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }

        }

        public IList<Project> GetProjectsByCategory(int categoryId)
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

        public IList<Project> GetProjectsByMember(int memberId)
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
                if (_context.Users.Find(project.ProjectId) == null)
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
        #endregion PROJECT
        #region DONATION
        public IList<Donation> GetAllDonations()
        {
            try
            {
                var donations = _context.Donations.ToList();

                return donations;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }

        }

        public Donation GetDonationById(int id)
        {
            var donation = _context.Donations.FirstOrDefault(u => u.DonationID == id);

            return donation;
        }

        public IList<Donation> GetAllDonationByProject(int projectId)
        {
            try
            {
                var donations = _context.Donations.Where(u => u.ProjectId == projectId).ToList();

                return donations;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public IList<Donation> GetAllDonationByMember(int memberId)
        {
            try
            {
                var donations = _context.Donations.Where(u => u.MemberId == memberId).ToList();

                return donations;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public void InsertOrUpdateDonation(Donation donation)
        {
            try
            {
                donation.UpdatedDate = DateTime.Now;
                if (_context.Donations.Find(donation.DonationID) == null)
                {
                    _context.Donations.Add(donation);

                    //_context.Entry(member).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(donation).State = EntityState.Modified;
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
        #endregion DONATION
        #region FILTER
        public IList<Filter> GetAllFilters()
        {
            try
            {
                var filters = _context.Filters.ToList();

                return filters;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }

        }

        public IList<Filter> GetAllFiltersByType(int type)
        {
            try
            {
                var filters = _context.Filters.Where(u => u.FilterType == type).ToList();

                return filters;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }
        #endregion FILTER
        #region REWARD
        public IList<Reward> GetAllRewards()
        {
            try
            {
                var rewards = _context.Rewards.ToList();

                return rewards;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public IList<Reward> GetAllRewardsByProjectId(int id)
        {
            try
            {
                var rewards = _context.Rewards.Where(u => u.ProjectID == id).ToList();

                return rewards;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} - InnerException: {ex.InnerException}");
            }
        }

        public void InsertOrUpdateReward(Reward reward)
        {
            try
            {
                reward.UpdatedDate = DateTime.Now;
                if (_context.Rewards.Find(reward.RewardID) == null)
                {
                    _context.Rewards.Add(reward);

                    //_context.Entry(member).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(reward).State = EntityState.Modified;
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
        #endregion REWARD
    }
}
