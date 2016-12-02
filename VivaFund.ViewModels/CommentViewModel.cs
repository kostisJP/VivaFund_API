using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.ViewModels
{
    public class CommentViewModel
    {
        public int CommentID { get; set; }

        public int MemberId { get; set; }

        public int? ProjectId { get; set; }

        public string CommentBody { get; set; }

        public int CounterPlus { get; set; }

        public int CounterMinus { get; set; }
    }
}
