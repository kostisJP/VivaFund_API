using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int ProjectCategoryId { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
        public string TitleEn { get; set; }
        public string TitleEl { get; set; }
        public string SubtitleEn { get; set; }
        public string SubtitleEl { get; set; }
        public string BodyEn { get; set; }
        public string BodyEl { get; set; }
        public int Goal { get; set; }
        public int Views { get; set; }
        public bool Completed { get; set; }

        //IEnumerable<Donation> Donations;
        //IEnumerable<ProjectMedia> Media;
    }
}
