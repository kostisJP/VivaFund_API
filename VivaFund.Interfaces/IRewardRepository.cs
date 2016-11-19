using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.Interfaces
{
    public interface IRewardRepository
    {
        IEnumerable<Reward> GetAllRewards();
        IEnumerable<Reward> GetAllRewardsByProjectId(int id);
        void InsertOrUpdateReward(Reward reward);
    }
}
