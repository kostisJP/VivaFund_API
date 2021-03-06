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
        IEnumerable<Donation> GetAllDonationsByProjectId(int id);
        Donation GetDonationById(int id);
        Donation GetDonationByProjectId(int id);
        IEnumerable<Donation> GetAllDonationByProjectId(int projectId);
        IEnumerable<Donation> GetAllDonationByMemberId(int memberId);
        void InsertOrUpdateDonation(Donation donation);
    }
}
