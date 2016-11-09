using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.Models
{
    public class ProjectMedia: BaseModel
    {
        [Key]
        public int ProjectMediaId { get; set; }

        public bool IsCoverImage { get; set; }

        public int ProjectMediaType { get; set; }

        [MaxLength(500)]
        public string URL { get; set; }

        public int ProjectId { get; set; }
        
        public Project Project { get; set; }
    }
}
