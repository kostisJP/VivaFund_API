﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.Interfaces
{
    public interface IDonationRepository
    {
        IEnumerable<Donation> GetAllDonations();
        Donation GetDonationById(int id);
        IEnumerable<Donation> GetAllDonationByProjectId(int projectId);
        IEnumerable<Donation> GetAllDonationByMemberId(int memberId);
        void InsertOrUpdateDonation(Donation donation);
    }
}