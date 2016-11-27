using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.ServicesInterfaces
{
    public interface IRewardService
    {
        IEnumerable<Reward> GetAllRewards();

        IEnumerable<Reward> GetAllRewardsByProjectId(int id);

        void SetReward(Reward reward);
    }
}
