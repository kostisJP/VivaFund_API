using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.Services;
using VivaFund.ServicesInterfaces;

namespace VivaFund.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepo;

        public DonationService (IDonationRepository donationRepo)
        {
            _donationRepo = donationRepo;
        }

        public IEnumerable<Donation> GetAllDonations()
        {
            var allDonations = _donationRepo.GetAllDonations();
            return allDonations;
            
        }

      
        public IEnumerable<Donation> GetAllDonationsByMemberId(int id)
        {
            var donation = _donationRepo.GetAllDonationByMemberId(id);

            return donation;
        }

        public Donation GetDonationById(int id)
        {
            var donation = _donationRepo.GetDonationById(id);

            return donation;
        }

        public void SetDonation(Donation donation)
        {
            _donationRepo.InsertOrUpdateDonation(donation);
        }
    }
}
