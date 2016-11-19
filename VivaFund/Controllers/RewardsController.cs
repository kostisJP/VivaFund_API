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

namespace VivaFund.Controllers
{
    [RoutePrefix("api/reward")]
    public class RewardsController : ApiController
    {
        private readonly IProjectRepository _userRepo;

        public RewardsController()
        {
            _userRepo = ObjectFactory.GetInstance<IProjectRepository>();
        }
        public RewardsController(IProjectRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Reward> GetAllRewards()
        {
            var allRewards = _userRepo.GetAllRewards();
            return allRewards;
            //return new StringContent(allUsers.ToString(), System.Text.Encoding.UTF8, "application/json");
        }

        [HttpGet]
        [Route("project/{id}")]
        public IEnumerable<Reward> GetRewardByProjectId(int id)
        {
            var reward = _userRepo.GetAllRewardsByProjectId(id);

            return reward;
        }
        [HttpPost]
        [Route("save")]
        public Reward SetReward(Reward reward)
        {
            _userRepo.InsertOrUpdateReward(reward);

            return reward;
        }
    }
}