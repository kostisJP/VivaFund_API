using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.ServicesInterfaces;

namespace VivaFund.Services
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepo;

        public RewardService(IRewardRepository rewardRepo)
        {
            _rewardRepo = rewardRepo;
        }

        public IEnumerable<Reward> GetAllRewards()
        {
            var allRewards = _rewardRepo.GetAllRewards();
            return allRewards;
        }

        public IEnumerable<Reward> GetAllRewardsByProjectId(int id)
        {
            var reward = _rewardRepo.GetAllRewardsByProjectId(id);

            return reward;
        }
      
        public void SetReward(Reward reward)
        {
            _rewardRepo.InsertOrUpdateReward(reward);
        }
    }
}
