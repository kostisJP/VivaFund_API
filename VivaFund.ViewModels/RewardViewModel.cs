using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.ViewModels
{
    public class RewardViewModel
    {
        public int RewardID { get; set; }

        public int? ProjectID { get; set; }

        public int Value { get; set; }

        public string Title { get; set; }

        public string RewardDescription { get; set; }
    }
}
