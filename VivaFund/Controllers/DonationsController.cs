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
    public class DonationsController : ApiController
    {
        private readonly IProjectRepository _userRepo;

        public DonationsController()
        {
            _userRepo = ObjectFactory.GetInstance<IProjectRepository>();
        }

        public DonationsController(IProjectRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Donation> GetAllDonations()
        {
            var allDonations = _userRepo.GetAllDonations();
            return allDonations;
            //return new StringContent(allUsers.ToString(), System.Text.Encoding.UTF8, "application/json");
        }

        [HttpGet]
        [Route("member/{id}")]
        public IEnumerable<Donation> GetDonationById(int id)
        {
            var donation = _userRepo.GetAllDonationByMember(id);

            return donation;
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