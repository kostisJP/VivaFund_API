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
    [RoutePrefix("api/donation")]
    public class DonationController : ApiController
    {
        private readonly IProjectRepository _userRepo;

        public DonationController()
        {
            _userRepo = ObjectFactory.GetInstance<IProjectRepository>();
        }
        public DonationController(IProjectRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Donation> GetAllDonations()
        {
            var allUsers = _userRepo.GetAllDonations();
            return allUsers;
            //return new StringContent(allUsers.ToString(), System.Text.Encoding.UTF8, "application/json");
        }

        [HttpGet]
        [Route("{id}")]
        public Donation GetDonationById(int id)
        {
            var user = _userRepo.GetDonationById(id);

            return user;
        }
        [HttpPost]
        [Route("save")]
        public Donation SetDonation(Donation donation)
        {
            _userRepo.InsertOrUpdateDonation(donation);

            return donation;
        }
    }
}