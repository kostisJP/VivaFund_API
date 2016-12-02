using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.ServicesInterfaces
{
    public interface IDonationService
    {
        IEnumerable<Donation> GetAllDonationsByProjectId(int id);


        IEnumerable<Donation> GetAllDonationsByMemberId(int id);

        Donation GetDonationById(int id);

        Donation GetDonationByProjectId(int id);

        void SetDonation(Donation donation);
    }
}
