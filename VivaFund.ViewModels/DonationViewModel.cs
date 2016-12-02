using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.ViewModels
{
    public class DonationViewModel
    {
        public int DonationId { get; set; }

        public int DonatedAmount { get; set; }

        public int? RewardId { get; set; }
    }
}
