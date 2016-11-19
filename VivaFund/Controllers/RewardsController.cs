using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StructureMap;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.Repository;
using VivaFund.ServicesInterfaces;

namespace VivaFund.Controllers
{
    [RoutePrefix("api/reward")]
    public class RewardsController : ApiController
    {
        private readonly IRewardService _rewardService;


        public RewardsController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Reward> GetAllRewards()
        {
            var allRewards = _rewardService.GetAllRewards();
            return allRewards;
        }

        [HttpGet]
        [Route("project/{id}")]
        public IEnumerable<Reward> GetRewardByProjectId(int id)
        {
            var rewards = _rewardService.GetAllRewardsByProjectId(id);

            return rewards;
        }
        [HttpPost]
        [Route("save")]
        public Reward SetReward(Reward reward)
        {
            _rewardService.SetReward(reward);

            return reward;
        }
    }
}