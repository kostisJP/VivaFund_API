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
    public class RewardRepository : IRewardRepository
    {
        private readonly ApplicationDbContext _context;
        public RewardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Reward> GetAllRewards()
        {
            var rewards = _context.Rewards.ToList();

            return rewards;

        }

        public IEnumerable<Reward> GetAllRewardsByProjectId(int id)
        {

            var rewards = _context.Rewards.Where(u => u.ProjectID == id).ToList();

            return rewards;

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

    }
}
