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
    [RoutePrefix("api/donation")]
    public class DonationsController : ApiController
    {
        private readonly IDonationService _donationService;

        public DonationsController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Donation> GetAllDonations()
        {
            var allDonations = _donationService.GetAllDonations();
            return allDonations;
        }

        [HttpGet]
        [Route("member/{id}")]
        public IEnumerable<Donation> GetDonationById(int id)
        {
            var donation = _donationService.GetAllDonationsByMemberId(id);

            return donation;
        }

        [HttpPost]
        [Route("save")]
        public Donation SetDonation(Donation donation)
        {
             _donationService.SetDonation(donation);

            return donation;
        }
    }
}