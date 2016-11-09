using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.Interfaces;
using VivaFund.Models;

namespace VivaFund.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = dbContext.Users.ToList();

            return users;
        }

        public User GetUserById(int id)
        {
            
            var user = dbContext.Users.Where(u => u.UserId == id).FirstOrDefault();

            return user;
        }

        public User GetUserByToken(Guid token)
        {
            throw new NotImplementedException();
        }
    }
}
