﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.DomainModels
{
    public class Donation : BaseModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonationID { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public int DonatedAmount { get; set; }

        public int RewardId { get; set; }
        public Reward Reward { get; set; }

    }
}
