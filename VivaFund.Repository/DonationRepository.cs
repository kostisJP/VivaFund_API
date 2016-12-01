using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;

namespace VivaFund.Repository
{
    public class DonationRepository : IDonationRepository
    {
        private readonly ApplicationDbContext _context;
        
        public DonationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Donation> GetAllDonations()
        {
          
                var donations = _context.Donations.ToList();

                return donations;
         

        }

        public Donation GetDonationById(int id)
        {
            var donation = _context.Donations.FirstOrDefault(u => u.DonationId == id);

            return donation;
        }

        public Donation GetDonationByProjectId(int id)
        {
            var donation = _context.Donations.FirstOrDefault(u => u.ProjectId == id);

            return donation;
        }

        public IEnumerable<Donation> GetAllDonationByProjectId(int projectId)
        {
          
                var donations = _context.Donations.Where(u => u.ProjectId == projectId).ToList();

                return donations;
           
        }

        public IEnumerable<Donation> GetAllDonationByMemberId(int memberId)
        {
                var donations = _context.Donations.Where(u => u.MemberId == memberId).ToList();

                return donations;
           
        }

        public void InsertOrUpdateDonation(Donation donation)
        {
            try
            {
                donation.UpdatedDate = DateTime.Now;
                if (_context.Donations.Find(donation.DonationId) == null)
                {
                    _context.Donations.Add(donation);

                    //_context.Entry(member).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(donation).State = EntityState.Modified;
                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                            subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        Console.WriteLine(message);
                    }
                }
            }
        }
     
    }
}
