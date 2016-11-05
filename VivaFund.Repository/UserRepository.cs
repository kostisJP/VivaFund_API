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
        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            //throw new NotImplementedException();
            User x = new User()
            {
                UserId = 1,
                FirstName = "Kostas"
            };

            return x;
        }

        public User GetUserByToken(Guid token)
        {
            throw new NotImplementedException();
        }
    }
}
