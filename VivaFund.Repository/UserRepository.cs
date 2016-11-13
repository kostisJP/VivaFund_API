using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using System.Data.Entity.Infrastructure;

namespace VivaFund.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _context.Users.ToList();

            return users;
        }

        public User GetUserById(int id)
        {

            var user = _context.Users.FirstOrDefault(u => u.UserId == id);

            return user;
        }

        public User GetUserByToken(Guid token)
        {
            throw new NotImplementedException();
        }

        public User InsertOrUpdateUser(User user)
        {
            try
            {
                user.UpdatedDate = DateTime.Now;
                if (_context.Users.Find(user.UserId) == null)
                {
                    _context.Users.Add(user);
                    
                    //_context.Entry(user).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(user).State = EntityState.Modified;
                }
                _context.SaveChanges();
                return user;
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
            return null;
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

    }
}
