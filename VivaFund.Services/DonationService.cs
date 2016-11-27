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
            try
            {
                var allDonations = _donationRepo.GetAllDonations();

                return allDonations;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

      
        public IEnumerable<Donation> GetAllDonationsByMemberId(int id)
        {
            try
            {
                var donation = _donationRepo.GetAllDonationByMemberId(id);

                return donation;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Donation GetDonationById(int id)
        {
            try
            {
                var donation = _donationRepo.GetDonationById(id);

                return donation;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SetDonation(Donation donation)
        {
            _donationRepo.InsertOrUpdateDonation(donation);
        }
    }
}
